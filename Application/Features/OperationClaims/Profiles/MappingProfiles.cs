using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Dtos;
using AutoMapper;
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
        }
    }
}
