using Application.Features.UserDetails.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Queries.ListProfilePhoto
{
    public class ListProfilePhotoQueryHandler : IRequestHandler<ListProfilePhotoQueryRequest, ListProfilePhotoDto>
    {
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IImageRepository _imageRepository;
        private readonly IFileRepository _fileRepository;

        public ListProfilePhotoQueryHandler(IUserDetailRepository userDetailRepository, IImageRepository imageRepository, IFileRepository fileRepository)
        {
            _userDetailRepository = userDetailRepository;
            _imageRepository = imageRepository;
            _fileRepository = fileRepository;
        }

        public async Task<ListProfilePhotoDto> Handle(ListProfilePhotoQueryRequest request, CancellationToken cancellationToken)
        {
            UserDetail userDetail = await _userDetailRepository.GetAsync(u => u.UserId == Guid.Parse(request.UserId));
            Image image = await _imageRepository.GetAsync(i => i.Id == userDetail.ProfilePhotoId);
            Domain.Entities.File file = await _fileRepository.GetAsync(f => f.Id == image.FileId);
            return new()
            {
                FileId = file.Id.ToString(),
                ImageId = image.Id.ToString(),
                ImageName = file.Name,
                Path = file.Path,
                UserId = userDetail.UserId.ToString()
            };
        }
    }
}
