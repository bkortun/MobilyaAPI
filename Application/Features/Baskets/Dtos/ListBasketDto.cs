using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Dtos
{
    public class ListBasketDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public int TotalProduct { get; set; }
        public int TotalPrice { get; set; }
    }
}
