using Infrastructure.Storage.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Storage
{
    public class StorageManager : IStorageService
    {
        private readonly IStorage _storage;
        public StorageManager(IStorage storage)
        {
            _storage = storage;
        }
        public string StorageType => _storage.GetType().Name;

        public Task DeleteFileAsync(string pathOrContainerName, string fileName)
        {
            return _storage.DeleteFileAsync(pathOrContainerName, fileName);
        }

        public List<string> GetFilesName(string pathOrContainerName)
        {
            return _storage.GetFilesName(pathOrContainerName);
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            return _storage.HasFile(pathOrContainerName, fileName);
        }

        public Task<List<Domain.Entities.File>> UploadAsync(string pathOrContainerName, IFormFileCollection formFiles)
        {
            return _storage.UploadAsync(pathOrContainerName, formFiles);
        }
    }
}
