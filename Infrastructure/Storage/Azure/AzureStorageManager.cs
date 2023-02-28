using Application.Services.Storage.Azure;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Storage.Azure
{
    public class AzureStorageManager : IAzureStorageService
    {
        public Task DeleteFileAsync(string pathOrContainerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public List<string> GetFilesName(string pathOrContainerName)
        {
            throw new NotImplementedException();
        }

        public bool HasFile(string pathOrContainerName, string fileName)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Entities.File>> UploadAsync(string pathOrContainerName, IFormFileCollection formFiles)
        {
            throw new NotImplementedException();
        }
    }
}
