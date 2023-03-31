using Application.Features.UserDetailAddresses.Commands.CreateUserDetailAddress;
using Application.Features.UserDetailAddresses.Commands.DeleteUserDetailAddress;
using Application.Features.UserDetailAddresses.Commands.UpdateUserDetailAddress;
using Application.Features.UserDetailAddresses.Dtos;
using Application.Features.UserDetailAddresses.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetailAddresses.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDetailAddress, CreateUserDetailAddressCommandRequest>().ReverseMap();
            CreateMap<UserDetailAddress, CreateUserDetailAddressDto>().ReverseMap();

            CreateMap<UserDetailAddress, DeleteUserDetailAddressCommandRequest>().ReverseMap();
            CreateMap<UserDetailAddress, DeleteUserDetailAddressDto>().ReverseMap();

            CreateMap<UserDetailAddress, UpdateUserDetailAddressCommandRequest>().ReverseMap();
            CreateMap<UserDetailAddress, UpdateUserDetailAddressDto>().ReverseMap();

            CreateMap<IPaginate<UserDetailAddress>, ListUserDetailAddressModel>().ReverseMap();
            CreateMap<UserDetailAddress, ListUserDetailAddressDto>().ForMember(u => u.AddressId, opt => opt.MapFrom(d => d.Address.Id))
                                                                    .ForMember(u => u.City, opt => opt.MapFrom(d => d.Address.City))
                                                                    .ForMember(u => u.Neighbourhood, opt => opt.MapFrom(d => d.Address.Neighbourhood))
                                                                    .ForMember(u => u.Country, opt => opt.MapFrom(d => d.Address.Country))
                                                                    .ForMember(u => u.AddressDetail, opt => opt.MapFrom(d => d.Address.AddressDetail))
                                                                    .ForMember(u => u.District, opt => opt.MapFrom(d => d.Address.District))
                                                                    .ForMember(u => u.Title, opt => opt.MapFrom(d => d.Address.Title))
                                                                    .ForMember(u => u.ZipCode, opt => opt.MapFrom(d => d.Address.ZipCode))
                                                                    .ForMember(u => u.UserId, opt => opt.MapFrom(d => d.UserDetail.UserId))
                                                                    .ReverseMap();

            CreateMap<UserDetailAddress, ListByIdUserDetailAddressDto>().ReverseMap();

        }
    }
}
