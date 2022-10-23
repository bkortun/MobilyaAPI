using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Commands.DeleteOrder;
using Application.Features.Orders.Commands.UpdateOrder;
using Application.Features.Orders.Dtos;
using Application.Features.Orders.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateOrderCommandRequest, Order>().ReverseMap();
            CreateMap<CreateOrderDto, Order>().ReverseMap();

            CreateMap<DeleteOrderDto, Order>().ReverseMap();
            CreateMap<DeleteOrderCommandRequest, Order>().ReverseMap();

            CreateMap<UpdateOrderDto, Order>().ReverseMap();
            CreateMap<UpdateOrderCommandRequest, Order>().ReverseMap();

            CreateMap<Order, ListOrderDto>().ForMember(c=>c.BasketId,opt=>opt.MapFrom(c=>c.Basket.Id)).ReverseMap();
            CreateMap<ListOrderModel, IPaginate<Order>>().ReverseMap();
        }
    }
}
