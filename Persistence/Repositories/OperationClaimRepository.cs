﻿using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class OperationClaimRepository : EfRepositoryBase<OperationClaim, MobilyaDbContext>, IOperationClaimRepository
    {
        public OperationClaimRepository(MobilyaDbContext context) : base(context)
        {
        }
    }
}
