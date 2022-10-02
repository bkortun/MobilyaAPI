using Application.Services.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Rules
{
    public class ProductImageBusinessRules
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileRepository _fileRepository;

        public ProductImageBusinessRules(IProductRepository productRepository, IFileRepository fileRepository)
        {
            _productRepository = productRepository;
            _fileRepository = fileRepository;
        }

        public async Task<Product> CheckRequestedProductIsNotNull(string productId)
        {
            Product? product = await _productRepository.GetAsync(p => p.Id == Guid.Parse(productId));
            if (product == null)
                throw new Exception("Böyle bir ürün mevcut değil");
            return product;
        }

        public async Task<Domain.Entities.File> CheckRequestedFileIsNotNull(string fileId)
        {
            Domain.Entities.File? file = await _fileRepository.GetAsync(p => p.Id == Guid.Parse(fileId));
            if (file == null)
                throw new Exception("Böyle bir dosya mevcut değil");
            return file;
        }
    }
}
