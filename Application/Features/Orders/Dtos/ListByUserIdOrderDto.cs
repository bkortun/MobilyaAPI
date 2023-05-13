using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Dtos
{
    public class ListByUserIdOrderDto
    {
        public string Id { get; set; }
        public string BasketId { get; set; }
        public float TotalPrice { get; set; }
        public int TotalProduct { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsCanceled { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
