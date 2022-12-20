using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Application.Features.Users.Commands.RegisterUser;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Dtos;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserForRegisterDto>().ReverseMap();

            CreateMap<UserOperationClaim, ListOperationClaimByUserEmailDto>()
                .ForMember(c=>c.Name,opt=>opt.MapFrom(p=>p.OperationClaim.Name))
                .ForMember(c=>c.Email,opt=>opt.MapFrom(p=>p.User.Email))
                .ReverseMap();
            CreateMap<IPaginate<UserOperationClaim>, ListOperationClaimByUserEmailModel>().ReverseMap();
        }
    }
}
