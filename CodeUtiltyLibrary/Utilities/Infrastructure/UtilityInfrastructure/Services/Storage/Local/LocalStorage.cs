using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage.Local;
using Utilities.Core.UtilityApplication.DTOs.File;

namespace Utilities.Infrastructure.UtilityInfrastructure.Services.Storage.Local
{
    public class LocalStorage : Storage, ILocalStorage
    {
        readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteAsync(string path, string fileName)
        {
            var wrp = _webHostEnvironment.WebRootPath;
            File.Delete($"{wrp}\\{path}\\{fileName}");
        }

        public List<string> GetFiles(string path)
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string fullPath = Path.Combine(webRootPath, path);

            DirectoryInfo directory = new DirectoryInfo(fullPath);
            return directory.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName)
        {
            var wrp = _webHostEnvironment.WebRootPath;
            var result = File.Exists($"{wrp}\\{path}\\{fileName}");
            return result;
        }

        public async Task<bool> CopyFileAsync(string path, IFormFile file)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None,
                                                        1024 * 1024, useAsync: false);

                await file.CopyToAsync(fileStream);
                await fileStream.FlushAsync(); //file stream boşaltma.

                return true;
            }
            catch (Exception ex)
            {
                //todo log! 
                throw ex;
            }
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, IFormFileCollection files)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            List<(string fileName, string path)> datas = new();

            foreach (IFormFile file in files)
            {
                string fileNewName = await FileRenameAsync(path, file.FileName, HasFile);

                await CopyFileAsync($"{uploadPath}\\{fileNewName}", file);
                datas.Add((fileNewName, $"{path}\\{fileNewName}"));
            }

            return datas;
        }

        public async Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string path, List<FileOptionDTO> fileOptions)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            List<(string fileName, string path)> datas = new();
            foreach (var file in fileOptions)
            {
                byte[] bytes = Convert.FromBase64String(file.Base64String);
                string fileNewName = await FileRenameAsync(path, file.FileName, HasFile);
                string lastPath = Path.Combine(uploadPath, fileNewName);
                File.WriteAllBytes(lastPath, bytes);
                datas.Add((fileNewName, $"{path}\\{fileNewName}"));
            }

            return datas;
        }
    }
}