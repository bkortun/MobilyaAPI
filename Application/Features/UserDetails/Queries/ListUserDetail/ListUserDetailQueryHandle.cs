using Application.Features.UserDetails.Models;
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

namespace Application.Features.UserDetails.Queries.ListUserDetail
{
    public class ListUserDetailQueryHandle : IRequestHandler<ListUserDetailQueryRequest, ListUserDetailModel>
    {
        private readonly IUserDetailRepository _userDetailRepository;
        private readonly IMapper _mapper;

        public ListUserDetailQueryHandle(IUserDetailRepository userDetailRepository, IMapper mapper)
        {
            _userDetailRepository = userDetailRepository;
            _mapper = mapper;
        }

        public async Task<ListUserDetailModel> Handle(ListUserDetailQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<UserDetail> userDetails = await _userDetailRepository//UserDetail tablosunu getir ve bununla ilişkisi olan user tablosunu da getir.(join işlemi)
                .GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize,include:u=>u.Include(p=>p.User));
            ListUserDetailModel userDetailModels = _mapper.Map<ListUserDetailModel>(userDetails);
            return userDetailModels;
        }
    }
}
