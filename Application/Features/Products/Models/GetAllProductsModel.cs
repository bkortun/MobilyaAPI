using Application.Features.Products.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Models
{
    public class GetAllProductsModel
    {
        public int TotalCount { get; set; }
        public object Items { get; set; }
    }
}
