using OfficeOpenXml;
using Utilities.Core.UtilityApplication.Abstractions.Services.Excel;

namespace Utilities.Infrastructure.UtilityInfrastructure.Services.Excel
{
    public class ExcelService : IExcelService
    {
        public void WriteDataToExcel<T>(List<T> data, string filePath)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");

                if (data.Count > 0)
                {
                    var properties = typeof(T).GetProperties();

                    // Başlıklar
                    for (int i = 0; i < properties.Length; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = properties[i].Name;
                    }

                    // Satırlar
                    for (int i = 0; i < data.Count; i++)
                    {
                        for (int j = 0; j < properties.Length; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = properties[j].GetValue(data[i]);
                        }
                    }
                }

                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }
    }
}
