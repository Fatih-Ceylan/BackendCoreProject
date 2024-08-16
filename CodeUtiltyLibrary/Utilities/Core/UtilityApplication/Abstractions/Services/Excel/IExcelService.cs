namespace Utilities.Core.UtilityApplication.Abstractions.Services.Excel
{
    public interface IExcelService
    {
        void WriteDataToExcel<T>(List<T> data, string filePath);
    }
}
