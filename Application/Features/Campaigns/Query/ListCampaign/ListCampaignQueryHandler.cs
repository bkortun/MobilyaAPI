using Application.Features.Campaigns.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Query.ListCampaign
{
    public class ListCampaignQueryHandler : IRequestHandler<ListCampaignQueryRequest, ListCampaignModel>
    {
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;
        public ListCampaignQueryHandler(ICampaignRepository campaignRepository, IMapper mapper)
        {
            _campaignRepository = campaignRepository;
            _mapper = mapper;
        }

        public async Task<ListCampaignModel> Handle(ListCampaignQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<Campaign> campaigns = await _campaignRepository.GetListAsync(index: request.PageRequest.Page,
                                                                        size: request.PageRequest.PageSize);
            ListCampaignModel mappedCampaign = _mapper.Map<ListCampaignModel>(campaigns);
            return mappedCampaign;
        }
    }
}
