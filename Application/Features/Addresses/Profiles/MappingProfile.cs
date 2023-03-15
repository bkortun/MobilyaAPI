using Application.Features.Addresses.Commands.CreateAddress;
using Application.Features.Addresses.Commands.DeleteAddress;
using Application.Features.Addresses.Commands.UpdateAddress;
using Application.Features.Addresses.Dtos;
using Application.Features.Addresses.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Address, CreateAddressCommandRequest>().ReverseMap();
            CreateMap<Address, CreateAddressDto>().ReverseMap();

            CreateMap<Address, UpdateAddressCommandRequest>().ReverseMap();
            CreateMap<Address, UpdateAddressDto>().ReverseMap();

            CreateMap<Address, DeleteAddressCommandRequest>().ReverseMap();
            CreateMap<Address, DeleteAddressDto>().ReverseMap();

            CreateMap<IPaginate<Address>, ListAddressModel>().ReverseMap();
            CreateMap<Address, ListAddressDto>().ReverseMap();

            CreateMap<Address,ListByIdAddressDto>().ReverseMap();


            //listbyid için yok
        }
    }
}
