﻿using Microsoft.AspNetCore.Http;
using Utilities.Core.UtilityApplication.Abstractions.Services.Storage;
using Utilities.Core.UtilityApplication.DTOs.File;

namespace Utilities.Infrastructure.UtilityInfrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        IStorage _storage;

        public StorageService(IStorage storage)
        {
            _storage = storage;
        }

        public string StorageName { get => _storage.GetType().Name; }

        public Task DeleteAsync(string pathOrContainerName, string fileName)
            => _storage.DeleteAsync(pathOrContainerName, fileName);

        public List<string> GetFiles(string pathOrContainerName)
            => _storage.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string fileName)
            => _storage.HasFile(pathOrContainerName, fileName);

        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
            => _storage.UploadAsync(pathOrContainerName, files);

        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, List<FileOptionDTO> fileOptions)
            => _storage.UploadAsync(pathOrContainerName, fileOptions);
    }
}
