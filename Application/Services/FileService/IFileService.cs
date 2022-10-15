using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.FileService
{
    public interface IFileService
    {
        Task<List<Domain.Entities.File>> UploadAsync(string pathOrContainerName, IFormFileCollection formFiles);
        void DeleteLocal(string pathOrContainerName, string fileName);
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}
