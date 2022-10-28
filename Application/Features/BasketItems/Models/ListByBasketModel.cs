using Application.Features.BasketItems.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BasketItems.Models
{
    public class ListByBasketModel:BasePageableModel
    {
        public  IList<ListByBasketDto> Items { get; set; }
    }
}
