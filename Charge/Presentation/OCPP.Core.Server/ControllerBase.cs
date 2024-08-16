/*
 * OCPP.Core - https://github.com/dallmann-consulting/OCPP.Core
 * Copyright (C) 2020-2021 dallmann consulting GmbH.
 * All Rights Reserved.
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using GCharge.Persistence.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Transactions;
using T = GCharge.Domain.Entities.Definitions;

namespace OCPP.Core.Server
{
    public partial class ControllerBase
    {
        /// <summary>
        /// Internal string for OCPP protocol version
        /// </summary>
        protected virtual string ProtocolVersion { get; }

        /// <summary>
        /// Configuration context for reading app settings
        /// </summary>
        protected IConfiguration Configuration { get; set; }

        /// <summary>
        /// Chargepoint status
        /// </summary>
        protected ChargePointStatus ChargePointStatus { get; set; }

        /// <summary>
        /// ILogger object
        /// </summary>
        protected ILogger Logger { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ControllerBase(IConfiguration config, ILoggerFactory loggerFactory, ChargePointStatus chargePointStatus)
        {
            Configuration = config;

            if (chargePointStatus != null)
            {
                ChargePointStatus = chargePointStatus;
            }
            else
            {
                Logger.LogError("New ControllerBase => empty chargepoint status");
            }
        }

        /// <summary>
        /// Deserialize and validate JSON message (if schema file exists)
        /// </summary>
        protected T DeserializeMessage<T>(OCPPMessage msg)
        {
            string path = Assembly.GetExecutingAssembly().Location;
            string codeBase = Path.GetDirectoryName(path);

            bool validateMessages = Configuration.GetValue<bool>("ValidateMessages", false);

            string schemaJson = null;
            if (validateMessages &&
                !string.IsNullOrEmpty(codeBase) &&
                Directory.Exists(codeBase))
            {
                string msgTypeName = typeof(T).Name;
                string filename = Path.Combine(codeBase, $"Schema{ProtocolVersion}", $"{msgTypeName}.json");
                if (File.Exists(filename))
                {
                    Logger.LogTrace("DeserializeMessage => Using schema file: {0}", filename);
                    schemaJson = File.ReadAllText(filename);
                }
            }

            JsonTextReader reader = new JsonTextReader(new StringReader(msg.JsonPayload));
            JsonSerializer serializer = new JsonSerializer();

            if (!string.IsNullOrEmpty(schemaJson))
            {
                JSchemaValidatingReader validatingReader = new JSchemaValidatingReader(reader);
                validatingReader.Schema = JSchema.Parse(schemaJson);

                IList<string> messages = new List<string>();
                validatingReader.ValidationEventHandler += (o, a) => messages.Add(a.Message);
                T obj = serializer.Deserialize<T>(validatingReader);
                if (messages.Count > 0)
                {
                    foreach (string err in messages)
                    {
                        Logger.LogWarning("DeserializeMessage {0} => Validation error: {1}", msg.Action, err);
                    }
                    throw new FormatException("Message validation failed");
                }
                return obj;
            }
            else
            {
                // Deserialization WITHOUT schema validation
                Logger.LogTrace("DeserializeMessage => Deserialization without schema validation");
                return serializer.Deserialize<T>(reader);
            }
        }


        /// <summary>
        /// Helper function for creating and updating the ConnectorStatus in then database
        /// </summary>
        protected bool UpdateConnectorStatus(int connectorId, string status, DateTimeOffset? statusTime, double? meter, DateTimeOffset? meterTime)
        {
            try
            {
                DbContextOptions<GChargeDbContext> options = new();

                IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
                using (GChargeDbContext dbContext = new GChargeDbContext(options, Configuration, httpContextAccessor))
                {
                    T.ConnectorStatus connectorStatus = dbContext.Find<T.ConnectorStatus>(ChargePointStatus.Id, connectorId);
                    if (connectorStatus == null)
                    {
                        // no matching entry => create connector status
                        connectorStatus = new T.ConnectorStatus();
                        connectorStatus.ChargePointId = ChargePointStatus.Id;
                        connectorStatus.ConnectorId = connectorId;
                        Logger.LogTrace("UpdateConnectorStatus => Creating new DB-ConnectorStatus: ID={0} / Connector={1}", connectorStatus.ChargePointId, connectorStatus.ConnectorId);
                        dbContext.Add<T.ConnectorStatus>(connectorStatus);
                    }

                    if (!string.IsNullOrEmpty(status))
                    {
                        connectorStatus.LastStatus = status;
                        connectorStatus.LastStatusTime = ((statusTime.HasValue) ? statusTime.Value : DateTimeOffset.UtcNow).DateTime;
                    }

                    if (meter.HasValue)
                    {
                        connectorStatus.LastMeter = meter.Value;
                        connectorStatus.LastMeterTime = ((meterTime.HasValue) ? meterTime.Value : DateTimeOffset.UtcNow).DateTime;
                    }
                    dbContext.SaveChanges();
                    Logger.LogInformation("UpdateConnectorStatus => Save ConnectorStatus: ID={0} / Connector={1} / Status={2} / Meter={3}", connectorStatus.ChargePointId, connectorId, status, meter);
                    return true;
                }
            }
            catch (Exception exp)
            {
                Logger.LogError(exp, "UpdateConnectorStatus => Exception writing connector status (ID={0} / Connector={1}): {2}", ChargePointStatus?.Id, connectorId, exp.Message);
            }

            return false;
        }

        /// <summary>
        /// Clean charge tag Id from possible suffix ("..._abc")
        /// </summary>
        protected static string CleanChargeTagId(string rawChargeTagId, ILogger logger)
        {
            string idTag = rawChargeTagId;

            // KEBA adds the serial to the idTag ("<idTag>_<serial>") => cut off suffix
            if (!string.IsNullOrWhiteSpace(rawChargeTagId))
            {
                int sep = rawChargeTagId.IndexOf('_');
                if (sep >= 0)
                {
                    idTag = rawChargeTagId.Substring(0, sep);
                    logger.LogTrace("CleanChargeTagId => Charge tag '{0}' => '{1}'", rawChargeTagId, idTag);
                }
            }

            return idTag;
        }

        protected static DateTimeOffset MaxExpiryDate
        {
            get
            {
                return new DateTime(2199, 12, 31);
            }
        }
        protected bool SaveTransactionDetail(int transactionId, int connectorId, DateTimeOffset? meterTime, double currentChargeKW, double meterKWH, double stateOfCharge)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<GChargeDbContext>();
                IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();
                using var dbContext = new GChargeDbContext(optionsBuilder.Options, Configuration, httpContextAccessor);

                var transaction = dbContext.Transactions.FirstOrDefault(t => t.TransactionId == transactionId);

                if (transaction == null)
                {
                    Logger.LogError("SaveTransactionDetail => Transaction not found with ID={0}", transactionId);
                    return false;
                }

                var transactionDetail = dbContext.TransactionDetails.FirstOrDefault(t => t.TransactionId == transactionId);

                if (transactionDetail == null)
                {
                    transactionDetail = new T.TransactionDetail
                    {
                        TransactionId = transactionId,
                        ChargePointId = transaction.ChargePointId,
                        ConnectorId = connectorId,
                        Timestamp = meterTime ?? DateTimeOffset.UtcNow,
                        CurrentChargeKW = currentChargeKW,
                        MeterKWH = meterKWH,
                        StateOfCharge = stateOfCharge,
                    };
                    dbContext.TransactionDetails.Add(transactionDetail);
                }
                else
                {
                    transactionDetail.Timestamp = meterTime ?? DateTimeOffset.UtcNow;
                    transactionDetail.CurrentChargeKW = currentChargeKW;
                    transactionDetail.MeterKWH = meterKWH;
                    transactionDetail.StateOfCharge = stateOfCharge;

                    dbContext.TransactionDetails.Update(transactionDetail);
                }

                dbContext.SaveChanges();
                Logger.LogInformation("SaveTransactionDetail => TransactionDetail added/updated successfully: TransactionId={0}, ConnectorId={1}", transactionId, connectorId);
                scope.Complete();
                return true;
            }
            catch (Exception exp)
            {
                Logger.LogError(exp, "SaveTransactionDetail => Exception adding/updating TransactionDetail: TransactionId={0}, ConnectorId={1}, Error: {2}", transactionId, connectorId, exp.Message);
                return false;
            }
        }


        protected bool SaveUserTransaction(T.Transaction transaction)
        {
            using var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted });
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<GChargeDbContext>();
                IHttpContextAccessor httpContextAccessor = new HttpContextAccessor();

                using var dbContext = new GChargeDbContext(optionsBuilder.Options, Configuration, httpContextAccessor);

                var electricitySalesPrice = dbContext.ElectricitySalesPrices
                    .FirstOrDefault(esp => esp.ChargePointId == transaction.ChargePointId && esp.IsDefault);

                if (electricitySalesPrice == null)
                {
                    Logger.LogError("SaveUserTransaction => ElectricitySalesPrice not found for ChargePointId={0}", transaction.ChargePointId);
                    return false;
                }

                decimal electricityLoadedKWh = (decimal)(transaction.MeterStop - transaction.MeterStart);
                decimal pricePerKWh = electricitySalesPrice.PricePerKWh;
                decimal totalAmount = electricityLoadedKWh * pricePerKWh;
                decimal vatRate = electricitySalesPrice.VatRate / 100;
                decimal vatAmount = totalAmount * vatRate;
                decimal grandTotal = totalAmount + vatAmount;

                var user = dbContext.UserChargeTags.FirstOrDefault(u => u.TagId == transaction.StopTagId);

                if (user == null)
                {
                    Logger.LogError("SaveUserTransaction => User not found for UserId={0}", transaction.StopTagId);
                    return false;
                }

                var userTransaction = dbContext.UserTransactions.FirstOrDefault(ut => ut.TransactionId == transaction.TransactionId);

                if (userTransaction == null)
                {
                    userTransaction = new T.UserTransaction
                    {
                        UserId = user.UserId.ToString(),
                        TransactionId = transaction.TransactionId,
                        ChargePointId = transaction.ChargePointId,
                        ElectricityLoadedKWh = electricityLoadedKWh,
                        PricePerKWh = pricePerKWh,
                        TotalAmount = totalAmount,
                        VatRate = vatRate,
                        VatAmount = vatAmount,
                        GrandTotal = grandTotal,
                        CreatedDate = DateTime.UtcNow,
                        CreatedBy = "GChargeServer",
                    };

                    dbContext.UserTransactions.Add(userTransaction);
                    dbContext.SaveChanges();

                    Logger.LogInformation("SaveUserTransaction => UserTransaction added successfully: TransactionId={0}", transaction.TransactionId);
                    scope.Complete();
                    return true;
                }
                else
                {
                    Logger.LogInformation("SaveUserTransaction => UserTransaction already exists: TransactionId={0}", transaction.TransactionId);
                    return false;
                }
            }
            catch (Exception exp)
            {
                Logger.LogError(exp, "SaveUserTransaction => Exception adding UserTransaction: TransactionId={0}, Error: {1}", transaction.TransactionId, exp.Message);
                return false;
            }
        }

    }
}
