using Application.Features.Baskets.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Models
{
    public class ListBasketModel:BasePageableModel
    {
        public IList<ListBasketDto> Items { get; set; }
    }
}
