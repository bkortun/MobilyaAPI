using Application.Features.Campaigns.Dtos;
using Application.Features.Campaigns.Models;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Storage.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Query.ListCampaignImage
{
    public class ListCampaignImageQueryHandler : IRequestHandler<ListCampaignImageQueryRequest, ListCampaignImageModel>
    {
        private readonly IImageRepository _imageRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;

        public ListCampaignImageQueryHandler(IImageRepository imageRepository, IStorageService storageService, IMapper mapper, IFileRepository fileRepository)
        {
            _imageRepository = imageRepository;
            _storageService = storageService;
            _mapper = mapper;
            _fileRepository = fileRepository;
        }

        public async Task<ListCampaignImageModel> Handle(ListCampaignImageQueryRequest request, CancellationToken cancellationToken)
        {
            //Todo nullcheck and refactor
            Image image = await _imageRepository.GetAsync(i => i.Campaign.Id == Guid.Parse(request.CampaignId));
            Domain.Entities.File file = await _fileRepository.GetAsync(f => f.Id == image.FileId);
            ListCampaignImageDto listCampaignImageDto = new()
            {
                CampaignId = request.CampaignId,
                FileId = image.FileId.ToString(),
                ImageId = image.Id.ToString(),
                ImageName = file.Name,
                Path = file.Path
            };
            ListCampaignImageModel listCampaignImageModel = new();
            List<ListCampaignImageDto> listCampaignImageDtoList = new();
            listCampaignImageDtoList.Add(listCampaignImageDto);
            listCampaignImageModel.Items=listCampaignImageDtoList;
            return listCampaignImageModel;
        }
    }
}
