using Application.Features.Campaigns.Commands.DeleteCampaign;
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

namespace Application.Features.Campaigns.Commands.DeleteCampaign
{
    public class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommandRequest, DeleteCampaignDto>
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;

        public DeleteCampaignCommandHandler(ICampaignRepository campaignRepository, IMapper mapper)
        {
            _campaignRepository = campaignRepository;
            _mapper = mapper;
        }

        public async Task<DeleteCampaignDto> Handle(DeleteCampaignCommandRequest request, CancellationToken cancellationToken)
        {
            Campaign campaign = _mapper.Map<Campaign>(request);
            Campaign mappedCampaign = await _campaignRepository.DeleteAsync(campaign);
            DeleteCampaignDto deleteCampaignDto = _mapper.Map<DeleteCampaignDto>(mappedCampaign);
            return deleteCampaignDto;
        }
    }
}
