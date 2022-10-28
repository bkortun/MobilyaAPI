using Application.Features.Baskets.Commands.CreateBasket;
using Application.Features.Baskets.Commands.DeleteBasket;
using Application.Features.Baskets.Commands.UpdateBasket;
using Application.Features.Baskets.Dtos;
using Application.Features.Baskets.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateBasketCommandRequest,Basket>().ReverseMap();
            CreateMap<CreateBasketDto,Basket>().ReverseMap();

            CreateMap<DeleteBasketDto,Basket>().ReverseMap();
            CreateMap<DeleteBasketCommandRequest,Basket>().ReverseMap();

            CreateMap<UpdateBasketDto, Basket>().ReverseMap();
            CreateMap<UpdateBasketCommandRequest, Basket>().ReverseMap();

            CreateMap<Basket, ListBasketDto>().ForMember(p=>p.Email,opt=>opt.MapFrom(p=>p.User.Email)).ReverseMap();
            CreateMap<ListBasketModel, IPaginate<Basket>>().ReverseMap();

            CreateMap<ListByUserBasketDto,Basket>().ReverseMap();
        }
    }
}
