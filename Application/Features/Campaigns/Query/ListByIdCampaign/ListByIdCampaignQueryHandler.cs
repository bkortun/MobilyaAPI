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

namespace Application.Features.Campaigns.Query.ListByIdCampaign
{
    public class ListByIdCampaignQueryHandler : IRequestHandler<ListByIdCampaignQueryRequest, ListByIdCampaignDto>
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;

        public ListByIdCampaignQueryHandler(ICampaignRepository campaignRepository, IMapper mapper)
        {
            _campaignRepository = campaignRepository;
            _mapper = mapper;
        }

        public async Task<ListByIdCampaignDto> Handle(ListByIdCampaignQueryRequest request, CancellationToken cancellationToken)
        {
            Campaign campaign = await _campaignRepository.GetAsync(p => p.Id == Guid.Parse(request.Id));
            ListByIdCampaignDto listByIdCampaignDto = _mapper.Map<ListByIdCampaignDto>(campaign);
            return listByIdCampaignDto;
        }
    }
}
