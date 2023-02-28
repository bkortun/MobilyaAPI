using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Storage.Services
{
    public interface IStorage
    {
        Task<List<Domain.Entities.File>> UploadAsync(string pathOrContainerName, IFormFileCollection formFiles);
        Task DeleteFileAsync(string pathOrContainerName, string fileName);
        List<string> GetFilesName(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}
