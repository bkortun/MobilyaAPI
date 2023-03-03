using Application.Features.ProductImages.Dtos;
using Application.Features.ProductImages.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
             CreateMap<DeleteProductImageDto,Domain.Entities.File>().ReverseMap();
             CreateMap<IPaginate<ProductImage>,ListProductProductImageModel>().ReverseMap();
             CreateMap<ProductImage,GetByProductProductImageDto>().ForMember(c=>c.FileId,opt=>opt.MapFrom(p=>p.Image.FileId))
                                                                                                                .ForMember(c=>c.Name,opt=>opt.MapFrom(p=>p.Image.File.Name))
                                                                                                                .ForMember(c => c.Path, opt => opt.MapFrom(p => p.Image.File.Path)).ReverseMap();
        }
    }
}
