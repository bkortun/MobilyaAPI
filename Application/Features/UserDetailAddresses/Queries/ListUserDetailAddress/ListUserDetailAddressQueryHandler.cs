using Application.Features.UserDetailAddresses.Models;
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

namespace Application.Features.UserDetailAddresses.Queries.ListUserDetailAddress
{
    public class ListUserDetailAddressQueryHandler : IRequestHandler<ListUserDetailAddressQueryRequest, ListUserDetailAddressModel>
    {
        private readonly IUserDetailAddressRepository _userDetailAddressRepository;
        private readonly IMapper _mapper;

        public ListUserDetailAddressQueryHandler(IUserDetailAddressRepository userDetailAddressRepository, IMapper mapper)
        {
            _userDetailAddressRepository = userDetailAddressRepository;
            _mapper = mapper;
        }

        public async Task<ListUserDetailAddressModel> Handle(ListUserDetailAddressQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<UserDetailAddress> userDetailAddresses = await _userDetailAddressRepository
                .GetListAsync(predicate:p=>p.Id == Guid.Parse(request.UserId),
                include: m => m.Include(b => b.Address).Include(t => t.UserDetail));
            ListUserDetailAddressModel listModel = _mapper.Map<ListUserDetailAddressModel>(userDetailAddresses);
            return listModel;
        }
    }
}
