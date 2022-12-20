using Application.Features.Users.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.ListOperationClaimByUserEmail
{
    public class ListOperationClaimByUserEmailQueryHandler : IRequestHandler<ListOperationClaimByUserEmailQueryRequest, ListOperationClaimByUserEmailModel>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public ListOperationClaimByUserEmailQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        async Task<ListOperationClaimByUserEmailModel> IRequestHandler<ListOperationClaimByUserEmailQueryRequest, ListOperationClaimByUserEmailModel>.Handle(ListOperationClaimByUserEmailQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<UserOperationClaim> paginate = await _userOperationClaimRepository.GetListAsync(u => u.User.Email == request.Email, include: o => o.Include(p => p.OperationClaim).Include(p => p.User));
            ListOperationClaimByUserEmailModel listOperationClaimByUserEmailModel = _mapper.Map<ListOperationClaimByUserEmailModel>(paginate);
            return listOperationClaimByUserEmailModel;
        }
    }
}
