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
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapper _mapper;

        public ListUserDetailAddressQueryHandler(IUserDetailAddressRepository userDetailAddressRepository, IMapper mapper, IUserDetailRepository userDetailRepository)
        {
            _userDetailAddressRepository = userDetailAddressRepository;
            _mapper = mapper;
            _userDetailRepository = userDetailRepository;
        }

        public async Task<ListUserDetailAddressModel> Handle(ListUserDetailAddressQueryRequest request, CancellationToken cancellationToken)
        {
            //Request'e UserId geliyor.Yani dısardan bi userId geliyor.Bu UserId'nin UserDetail'in UserId'si olduğunu belirtiyoruz.Çünkü UserId UserDetail'e ait bir property
            UserDetail userDetail = await _userDetailRepository.GetAsync(u => u.UserId == Guid.Parse(request.UserId));
            IPaginate<UserDetailAddress> userDetailAddresses = await _userDetailAddressRepository
                .GetListAsync(predicate:u=>u.UserDetailId == userDetail.Id
                ,include: p => p.Include(b => b.UserDetail).Include(k => k.Address));
            ListUserDetailAddressModel listModel = _mapper.Map<ListUserDetailAddressModel>(userDetailAddresses);
            return listModel;
        }
    }
}
