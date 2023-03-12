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

namespace Application.Features.Campaigns.Commands.UpdateCampaign
{
    public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommandRequest, UpdateCampaignDto>
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;

        public UpdateCampaignCommandHandler(ICampaignRepository campaignRepository, IMapper mapper)
        {
            _campaignRepository = campaignRepository;
            _mapper = mapper;
        }

        public async Task<UpdateCampaignDto> Handle(UpdateCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            Campaign campaign = _mapper.Map<Campaign>(request);
            Campaign updatedCampaign = await _campaignRepository.UpdateAsync(campaign);
            UpdateCampaignDto updateCampaignDto = _mapper.Map<UpdateCampaignDto>(updatedCampaign);
            return updateCampaignDto;
        }
    }
}
