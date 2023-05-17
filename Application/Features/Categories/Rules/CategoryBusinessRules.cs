using Application.Services.Repositories;
using Core.Application.BusinessRules;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Rules
{
    public class CategoryBusinessRules : BaseBusinessRules<ICategoryRepository, Category>
    {
        public CategoryBusinessRules(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
        }
    }
}
