using System.Security.Cryptography;
using System.Text;
using Utilities.Core.UtilityApplication.Abstractions.Services.Encryption.Sha256;

namespace Utilities.Infrastructure.UtilityInfrastructure.Services.Sha256
{

    public class Sha256Service : ISha256Service
    {
        /// <summary>
        /// kullanımdan kaldırılacak alttaki hashpassword metodu entegre edilecek.
        /// </summary>
        public string PasswordEncrypt(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// kullanımdan kaldırılacak alttaki hashpassword metodu entegre edilecek.
        /// </summary>
        public string GenerateUniqueCode()
        {
            var currentTime = DateTime.UtcNow;
            string timeString = currentTime.ToString("yyyyMMddHHmmssffff");

            using (var sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(timeString));
                StringBuilder hexString = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    hexString.Append(b.ToString("X2"));
                }

                string uniqueCode = hexString.ToString().Substring(0, 20);

                return uniqueCode;
            }
        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredHash = HashPassword(enteredPassword);

            return enteredHash.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
