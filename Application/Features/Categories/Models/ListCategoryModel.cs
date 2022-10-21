using Application.Features.Categories.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Models
{
    public class ListCategoryModel:BasePageableModel
    {
        public IList<ListCategoryDto> Items { get; set; }
    }
}
