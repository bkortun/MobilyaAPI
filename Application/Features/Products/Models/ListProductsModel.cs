using Application.Features.Products.Dtos;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Models
{
    public class ListProductsModel:BasePageableModel
    {
        public IList<ListProductDto> Items { get; set; }
    }
}
