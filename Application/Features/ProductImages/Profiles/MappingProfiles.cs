﻿using Application.Features.ProductImages.Dtos;
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
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DeleteProductImageDto, Domain.Entities.File>().ReverseMap();
            CreateMap<IPaginate<ProductImage>, ListProductImageModel>().ReverseMap();
            CreateMap<ProductImage, ListProductImageDto>().ForMember(c => c.FileId, opt => opt.MapFrom(p => p.Image.FileId))
                                                                                                               .ForMember(c => c.ProductName, opt => opt.MapFrom(p => p.Product.Name))
                                                                                                               .ForMember(c => c.Price, opt => opt.MapFrom(p => p.Product.Price))
                                                                                                               .ForMember(c => c.Stock, opt => opt.MapFrom(p => p.Product.Stock))
                                                                                                               .ForMember(c => c.ImageName, opt => opt.MapFrom(p => p.Image.File.Name))
                                                                                                               .ForMember(c => c.Showcase, opt => opt.MapFrom(p => p.Image.Showcase))
                                                                                                               .ForMember(c => c.Path, opt => opt.MapFrom(p => p.Image.File.Path)).ReverseMap();

            CreateMap<IPaginate<ProductImage>, ListByShowcaseProductImageModel>().ReverseMap();
            CreateMap<ProductImage, ListByShowcaseProductImageDto>().ForMember(c => c.FileId, opt => opt.MapFrom(p => p.Image.FileId))
                                                                                                               .ForMember(c => c.ImageName, opt => opt.MapFrom(p => p.Image.File.Name))
                                                                                                               .ForMember(c => c.Showcase, opt => opt.MapFrom(p => p.Image.Showcase))
                                                                                                               .ForMember(c => c.Path, opt => opt.MapFrom(p => p.Image.File.Path)).ReverseMap();
        }
    }
}
