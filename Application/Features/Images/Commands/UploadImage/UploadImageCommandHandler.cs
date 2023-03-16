using Application.Features.Images.Dtos;
using Application.Features.Images.Models;
using Application.Services.Repositories;
using Domain.Entities;
using Infrastructure.Storage.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Commands.Upload
{
    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommandRequest, UploadImageModel>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IStorageService _storageService;
        private readonly IImageRepository _imageRepository;

        public UploadImageCommandHandler(IFileRepository fileRepository, IStorageService storageService, IImageRepository imageRepository)
        {
            _fileRepository = fileRepository;
            _storageService = storageService;
            _imageRepository = imageRepository;
        }

        async public Task<UploadImageModel> Handle(UploadImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.File> files=await _storageService.UploadAsync("images",request.Files);
            UploadImageModel uploadImageModel = new();
            foreach (var file in files)
            {
                file.Storage = _storageService.StorageType;
                Domain.Entities.File addedFile= await _fileRepository.AddAsync(file);

                Image image = new() { FileId = file.Id };
                Image addedImage=await _imageRepository.AddAsync(image);
                UploadImageDto dto = new() { FileId = addedFile.Id.ToString(), ImageId = addedImage.Id.ToString() };
                //uploadImageModel.Items.Add(dto);
            }
            //todo response a el atılcak
            return uploadImageModel;
        }
    }
}
