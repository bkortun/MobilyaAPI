using Application.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Files.Rules
{
    public class FileBusinessRules
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileRepository _fileRepository;

        public FileBusinessRules(IProductRepository productRepository, IFileRepository fileRepository)
        {
            _productRepository = productRepository;
            _fileRepository = fileRepository;
        }

        public async Task<Domain.Entities.File> CheckRequestedFilesNotNull(string fileId)
        {
            Domain.Entities.File? file = await _fileRepository.GetAsync(p => p.Id == Guid.Parse(fileId));
            if (file == null)
                throw new Exception("Böyle bir dosya mevcut değil");
            return file;
        }
    }
}
