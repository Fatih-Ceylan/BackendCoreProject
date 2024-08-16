using Microsoft.AspNetCore.Http;
using Utilities.Core.UtilityApplication.DTOs.File;

namespace Utilities.Core.UtilityApplication.Abstractions.Services.Storage
{
    public interface IStorage
    {
        Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);

        Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, List<FileOptionDTO> fileOptions);

        Task DeleteAsync(string pathOrContainerName, string fileName);

        List<string> GetFiles(string pathOrContainerName);

        bool HasFile(string pathOrContainerName, string fileName);
    }
}
