using Application.Features.Campaigns.Commands.CreateCampaign;
using Application.Features.Campaigns.Commands.DeleteCampaign;
using Application.Features.Campaigns.Commands.UpdateCampaign;
using Application.Features.Campaigns.Dtos;
using Application.Features.Campaigns.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Campaign, CreateCampaignCommandRequest>().ReverseMap();
            CreateMap<Campaign, DeleteCampaignCommandRequest>().ReverseMap();
            CreateMap<Campaign, UpdateCampaignCommandRequest>().ReverseMap();
            CreateMap<Campaign, CreateCampaignDto>().ReverseMap();
            CreateMap<IPaginate<Campaign>, ListCampaignModel>().ReverseMap();
            CreateMap<Campaign, DeleteCampaignDto>().ReverseMap();
            CreateMap<Campaign, UpdateCampaignDto>().ReverseMap();
            CreateMap<Campaign, ListByIdCampaignDto>().ReverseMap();
            CreateMap<Campaign, ListCampaignDto>().ReverseMap();

        }
    }
}
