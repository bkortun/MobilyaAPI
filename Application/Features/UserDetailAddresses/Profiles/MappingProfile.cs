using Application.Features.UserDetailAddresses.Commands.CreateUserDetailAddress;
using Application.Features.UserDetailAddresses.Commands.DeleteUserDetailAddress;
using Application.Features.UserDetailAddresses.Commands.UpdateUserDetailAddress;
using Application.Features.UserDetailAddresses.Dtos;
using Application.Features.UserDetailAddresses.Models;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetailAddresses.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDetailAddress, CreateUserDetailAddressCommandRequest>().ReverseMap();
            CreateMap<UserDetailAddress,CreateUserDetailAddressDto>().ReverseMap();

            CreateMap<UserDetailAddress, DeleteUserDetailAddressCommandRequest>().ReverseMap();
            CreateMap<UserDetailAddress, DeleteUserDetailAddressDto>().ReverseMap();

            CreateMap<UserDetailAddress, UpdateUserDetailAddressCommandRequest>().ReverseMap();
            CreateMap<UserDetailAddress, UpdateUserDetailAddressDto>().ReverseMap();
            
            CreateMap<UserDetailAddress, ListUserDetailAddressModel>().ReverseMap();
            CreateMap<UserDetailAddress, ListUserDetailAddressDto>().ReverseMap();

            
        }
    }
}
