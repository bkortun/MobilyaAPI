using Application.Features.BasketItems.Commands.CreateBasketItem;
using Application.Features.BasketItems.Commands.UpdateBasketItem;
using Application.Features.BasketItems.Commands.UpdateBasketItemQuantity;
using Application.Features.BasketItems.Dtos;
using Application.Features.BasketItems.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BasketItems.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<DeleteBasketItemDto, BasketItem>().ReverseMap();

            CreateMap<UpdateBasketItemDto, BasketItem>().ReverseMap();
            CreateMap<UpdateBasketItemCommandRequest, BasketItem>().ReverseMap();

            CreateMap<BasketItem, CreateBasketItemDto>().ReverseMap();
            CreateMap<CreateBasketItemCommandRequest, BasketItem>().ReverseMap();

            CreateMap<IPaginate<BasketItem>, ListBasketItemModel>().ReverseMap();
            CreateMap<BasketItem, ListBasketItemDto>().ForMember(c => c.ProductName, opt => opt.MapFrom(p => p.Product.Name)).ReverseMap(); ;
        
            CreateMap<IPaginate<BasketItem>,ListByBasketModel>().ReverseMap();
            CreateMap<BasketItem,ListByBasketDto>().ForMember(c=>c.ProductName,opt=>opt.MapFrom(p=>p.Product.Name)).ReverseMap();
        }
    }
}
