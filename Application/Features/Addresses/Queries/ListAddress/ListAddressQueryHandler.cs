using Application.Features.Addresses.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Addresses.Queries.ListAddress;

public class ListAddressQueryHandler : IRequestHandler<ListAddressQueryRequest, ListAddressModel>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;

    public ListAddressQueryHandler(IAddressRepository addressRepository, IMapper mapper)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
    }

    public async Task<ListAddressModel> Handle(ListAddressQueryRequest request, CancellationToken cancellationToken)
    {
        IPaginate<Address> addresses = await _addressRepository.GetListAsync(index: request.PageRequest.Page,
                                                                            size: request.PageRequest.PageSize);
        ListAddressModel listAddressModel = _mapper.Map<ListAddressModel>(addresses);
        return listAddressModel;
    }
}
