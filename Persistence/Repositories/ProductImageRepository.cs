using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProductImageRepository : EfRepositoryBase<ProductImage, MobilyaDbContext>, IProductImageRepository
    {
        public ProductImageRepository(MobilyaDbContext context) : base(context)
        {
        }
    }
}
