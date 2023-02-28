using Application.Services.Storage.Local;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Storage.Local
{
    public class LocalStorageManager:Storage,ILocalStorageService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public LocalStorageManager(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task DeleteFileAsync(string path, string fileName) => System.IO.File.Delete(path);

        public List<string> GetFilesName(string path)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.GetFiles().Select(f => f.Name).ToList();
        }

        public bool HasFile(string path, string fileName) => System.IO.File.Exists($"{path}\\{fileName}");

        public async Task<List<Domain.Entities.File>> UploadAsync(string path, IFormFileCollection formFiles)
        {
            string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, path);

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            List<Domain.Entities.File> files = new();
            List<bool> results = new();
            foreach (IFormFile file in formFiles)
            {
                string fileNewName = await FileRenameAsync(file.FileName);
                bool result = await CopyFileAsync($"{uploadPath}//{fileNewName}", file);
                Domain.Entities.File addedFile = new() { Name = fileNewName, Path = $"wwwroot//{path}//{fileNewName}" };
                files.Add(addedFile);

                results.Add(result);
            }

            if (results.TrueForAll(r => r.Equals(true)))
                return files;
            throw new Exception("Dosya yüklenirken hata meydana geldi");
        }

        async Task<bool> CopyFileAsync(string path, IFormFile formFile)
        {
            try
            {
                await using FileStream fileStream = new(path, FileMode.Create, FileAccess.Write, FileShare.None, 1920 * 1920, useAsync: false);
                await formFile.CopyToAsync(fileStream);
                await fileStream.FlushAsync();
                return true;
            }
            catch (Exception ex)
            {
                //todo log!
                throw ex;
            }
        }
    }
}
