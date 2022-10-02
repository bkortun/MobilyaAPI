using Core.Persistence.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface IProductImageRepository:IAsyncRepository<ProductImage>
    {
    }
}
