using Application.Features.Users.Commands.RemoveOperationClaim;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Dtos;
using Core.Security.Entities;

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
