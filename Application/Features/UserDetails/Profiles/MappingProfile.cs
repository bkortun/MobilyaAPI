using Application.Features.UserDetails.Commands.CreateUserDetail;
using Application.Features.UserDetails.Commands.DeleteUserDetail;
using Application.Features.UserDetails.Commands.UpdateUserDetail;
using Application.Features.UserDetails.Dtos;
using Application.Features.UserDetails.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserDetails.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDetail, CreateUserDetailCommandRequest>().ReverseMap();
            CreateMap<UserDetail, CreateUserDetailDto>().ReverseMap();

            CreateMap<UserDetail, DeleteUserDetailCommandRequest>().ReverseMap();
            CreateMap<UserDetail, DeleteUserDetailDto>().ReverseMap();

            CreateMap<UserDetail, UpdateUserDetailCommandRequest>().ReverseMap();
            CreateMap<UserDetail, UpdateUserDetailDto>().ReverseMap();

            CreateMap<IPaginate<UserDetail>, ListUserDetailModel>().ReverseMap();
            CreateMap<UserDetail, ListUserDetailDto>().ForMember(u => u.UserId, opt => opt.MapFrom(d => d.User.Id))//UserDetail'deki UserId'yi User'in Id'si olarak mapla
                                                        .ForMember(u => u.FirstName, opt => opt.MapFrom(d => d.User.FirstName))
                                                        .ForMember(u => u.LastName, opt => opt.MapFrom(d => d.User.LastName))
                                                        .ForMember(u => u.Email, opt => opt.MapFrom(d => d.User.Email)).ReverseMap();

            CreateMap<UserDetail, ListByIdUserDetailDto>().ForMember(u => u.UserId, opt => opt.MapFrom(d => d.User.Id))
                                                        .ForMember(u => u.FirstName, opt => opt.MapFrom(d => d.User.FirstName))
                                                        .ForMember(u => u.LastName, opt => opt.MapFrom(d => d.User.LastName))
                                                        .ForMember(u => u.Email, opt => opt.MapFrom(d => d.User.Email)).ReverseMap();

        }
    }
}
