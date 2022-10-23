using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.BasketItems.Dtos
{
    public class CreateBasketItemDto
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string Quantity { get; set; }
        public string BasketId { get; set; }
    }
}
