using Application.Features.ProductImages.Dtos;
using Application.Features.ProductImages.Models;
using Application.Features.ProductImages.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Infrastructure.Storage.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Commands.UploadProductImage
{
    public class UploadProductImageCommandHandler : IRequestHandler<UploadProductImageCommandRequest, UploadProductImageModel>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IStorageService _storageService;
        private readonly IImageRepository _imageRepository;
        private readonly ProductImageBusinessRules _businessRules;

        public UploadProductImageCommandHandler(IProductImageRepository productImageRepository, IFileRepository fileRepository, IImageRepository imageRepository, ProductImageBusinessRules businessRules, IStorageService storageService)
        {
            _productImageRepository = productImageRepository;
            _fileRepository = fileRepository;
            _imageRepository = imageRepository;
            _businessRules = businessRules;
            _storageService = storageService;
        }

        public async Task<UploadProductImageModel> Handle(UploadProductImageCommandRequest request, CancellationToken cancellationToken)
        {
           Product product= await _businessRules.CheckRequestedProductIsNotNull(request.ProductId);
            //Todo Refactor edilecek
            List<Domain.Entities.File> files = await _storageService.UploadAsync("product-images", request.Files);
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
            //todo response a el atılcak
            return new();
        }
    }
}
