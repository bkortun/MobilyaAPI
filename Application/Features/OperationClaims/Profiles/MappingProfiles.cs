using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateOperationClaimCommandRequest,OperationClaim>().ReverseMap();
            CreateMap<CreateOperationClaimDto,OperationClaim>().ReverseMap();

            CreateMap<DeleteOperationClaimDto,OperationClaim>().ReverseMap();

            CreateMap<IPaginate<OperationClaim>, ListOperationClaimModel>().ReverseMap();
            CreateMap<ListOperationClaimDto,OperationClaim>().ReverseMap();
        }
    }
}
