using Application.Features.Images.Dtos;
using Application.Features.Images.Models;
using Application.Features.UserDetails.Dtos;
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

namespace Application.Features.UserDetails.Commands.UploadUserDetail
{
    public class UploadUserDetailCommandHandler : IRequestHandler<UploadUserDetailCommandRequest, UploadUserDetailDto>
    {
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IFileRepository _fileRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IStorageService _storageService;

        public UploadUserDetailCommandHandler(IUserDetailRepository userDetailRepository, IStorageService storageService, IFileRepository fileRepository, IImageRepository imageRepository)
        {
            _userDetailRepository = userDetailRepository;
            _storageService = storageService;
            _fileRepository = fileRepository;
            _imageRepository = imageRepository;
        }

        async public Task<UploadUserDetailDto> Handle(UploadUserDetailCommandRequest request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.File> files = await _storageService.UploadAsync("profile-images", request.ProfilePhoto);
            
            foreach (var file in files)
            {
                file.Storage = _storageService.StorageType;
                Domain.Entities.File addedFile = await _fileRepository.AddAsync(file);

                Image image = new() { FileId = file.Id };
                Image addedImage = await _imageRepository.AddAsync(image);
                UserDetail requestedUserDetail = await _userDetailRepository.GetAsync(u => u.UserId == Guid.Parse(request.UserId));
                requestedUserDetail.ProfilePhotoId = addedImage.Id;
                UserDetail updatedUserDetail = await _userDetailRepository.UpdateAsync(requestedUserDetail);
                UploadUserDetailDto uploadUserDetailDto = new()
                {
                    UserId = request.UserId,
                    ProfilePhotoId = updatedUserDetail.ProfilePhotoId.ToString(),
                };
                return uploadUserDetailDto;
            }
            throw new Exception("User profile photo eklenirken bir sorun meydana geldi.");
        }
    }
}
