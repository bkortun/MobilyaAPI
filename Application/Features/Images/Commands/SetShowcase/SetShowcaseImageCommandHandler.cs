using Application.Features.Images.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Images.Commands.SetShowcase
{
    public class SetShowcaseImageCommandHandler : IRequestHandler<SetShowcaseImageCommandRequest, SetShowcaseImageDto>
    {
        private readonly IImageRepository _imageRepository;
        private readonly IMapper _mapper;

        public SetShowcaseImageCommandHandler(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
        }

        public async Task<SetShowcaseImageDto> Handle(SetShowcaseImageCommandRequest request, CancellationToken cancellationToken)
        {
            //Todo null check
            Image image = await _imageRepository.GetAsync(i => i.Id == Guid.Parse(request.ImageId));
            image.Showcase = request.Showcase;
            Image updatedImage = await _imageRepository.UpdateAsync(image);
            SetShowcaseImageDto setShowcaseImageDto = _mapper.Map<SetShowcaseImageDto>(updatedImage);
            return setShowcaseImageDto;
        }
    }
}
