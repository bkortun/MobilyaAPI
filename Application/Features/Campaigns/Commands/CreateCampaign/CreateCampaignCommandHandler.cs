using Application.Features.Campaigns.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Commands.CreateCampaign
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommandRequest, CreateCampaignDto>
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;

        public CreateCampaignCommandHandler(ICampaignRepository campaignRepository, IMapper mapper)
        {
            _campaignRepository = campaignRepository;
            _mapper = mapper;
        }

        public async Task<CreateCampaignDto> Handle(CreateCampaignCommandRequest request, CancellationToken cancellationToken)

        {
            Campaign campaign = _mapper.Map<Campaign>(request);
            Campaign addedCampaign = await _campaignRepository.AddAsync(campaign);
            CreateCampaignDto createCampaignDto = _mapper.Map<CreateCampaignDto>(addedCampaign);
            return createCampaignDto;
        }
    }
}
