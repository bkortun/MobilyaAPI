using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryCommandRequest>().ReverseMap();


            CreateMap<Category, UpdateCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();

            CreateMap<Category, DeleteCategoryCommandRequest>().ReverseMap();
            CreateMap<Category, DeleteCategoryDto>().ReverseMap();

            CreateMap<IPaginate<Category>, ListCategoryModel>().ReverseMap();
            CreateMap<Category, ListCategoryDto>().ReverseMap();

            CreateMap<IPaginate<ProductCategory>, ListCategoryByProductIdModel>().ReverseMap();
            CreateMap<ProductCategory, ListCategoryByProductIdDto>().ForMember(n=>n.Name, opt => opt.MapFrom(p=>p.Category.Name))
                .ReverseMap();
        }
    }
}
