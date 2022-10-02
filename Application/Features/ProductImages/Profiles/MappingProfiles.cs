using Application.Features.ProductImages.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
             CreateMap<DeleteProductImageDto,Domain.Entities.File>().ReverseMap();
        }
    }
}
