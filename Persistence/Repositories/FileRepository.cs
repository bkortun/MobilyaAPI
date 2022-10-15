using Application.Services.Repositories;
using Core.Persistence.Repositories;
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
    public class FileRepository:EfRepositoryBase<Domain.Entities.File,MobilyaDbContext>,IFileRepository
    {
        public FileRepository(MobilyaDbContext context) : base(context)
        {
        }
    }
}
