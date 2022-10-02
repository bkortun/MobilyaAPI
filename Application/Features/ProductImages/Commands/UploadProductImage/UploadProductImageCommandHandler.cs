using Application.Features.ProductImage.Dtos;
using Application.Features.ProductImages.Models;
using Application.Features.ProductImages.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImage.Commands.UploadProductImage
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageModel>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ProductImageBusinessRules _businessRules;

        public UploadProductImageCommandHandler(IProductImageRepository productImageRepository, IProductRepository productRepository, IFileRepository fileRepository, IImageRepository imageRepository, ProductImageBusinessRules businessRules)
        {
            _productImageRepository = productImageRepository;
            _productRepository = productRepository;
            _fileRepository = fileRepository;
            _imageRepository = imageRepository;
            _businessRules = businessRules;
        }

        public async Task<UploadProductImageModel> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
           Product product= await _businessRules.CheckRequestedProductIsNotNull(request.ProductId);
            //Todo Refactor edilecek
            List<Domain.Entities.File> files = await _fileRepository.UploadAsync("product-images", request.Files);
            foreach (var file in files)
            {
                await _fileRepository.AddAsync(file);
                Image addedImage = new() { FileId = file.Id };
                await _imageRepository.AddAsync(addedImage);

                Domain.Entities.ProductImage productImage = new()
                {
                    ImageId = addedImage.Id,
                    ProductId = product.Id
                };
                await _productImageRepository.AddAsync(productImage);
            }
            return new();
        }
    }
}
