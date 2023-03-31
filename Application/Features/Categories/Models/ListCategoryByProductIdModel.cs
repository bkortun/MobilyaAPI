using Application.Features.Categories.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Models
{
    public class ListCategoryByProductIdModel:BasePageableModel
    {
        public IList<ListCategoryByProductIdDto> Items { get; set; }
    }
}
