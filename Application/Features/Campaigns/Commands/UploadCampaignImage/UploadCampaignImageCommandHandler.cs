using Application.Features.Campaigns.Dtos;
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

namespace Application.Features.Campaigns.Commands.UploadCampaignImage
{
    public class UploadCampaignImageCommandHandler : IRequestHandler<UploadCampaignImageCommandRequest, UploadCampaignImageDto>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IStorageService _storageService;
        private readonly IImageRepository _imageRepository;

        public UploadCampaignImageCommandHandler(IFileRepository fileRepository, IStorageService storageService, IImageRepository imageRepository)
        {
            _fileRepository = fileRepository;
            _storageService = storageService;
            _imageRepository = imageRepository;
        }

        async public Task<UploadCampaignImageDto> Handle(UploadCampaignImageCommandRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.File> files = await _storageService.UploadAsync("campaign-images", request.Files);
            UploadCampaignImageDto campaignImageDto = new();
            foreach (var file in files)
            {
                file.Storage = _storageService.StorageType;
                Domain.Entities.File addedFile = await _fileRepository.AddAsync(file);

                Image image = new() { FileId = file.Id };
                Image addedImage = await _imageRepository.AddAsync(image);
                campaignImageDto = new() { FileId = addedFile.Id.ToString(), Id = addedImage.Id.ToString() };
            }
            //todo response a el atılcak
            return campaignImageDto ;
        }
    }
}
