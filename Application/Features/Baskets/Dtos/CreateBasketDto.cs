using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Baskets.Dtos
{
    public class CreateBasketDto
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public int TotalProduct { get; set; }
        public int TotalPrice { get; set; }
    }
}
