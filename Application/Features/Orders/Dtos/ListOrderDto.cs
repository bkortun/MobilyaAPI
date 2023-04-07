using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Dtos
{
    public class ListOrderDto
    {
        public string Id { get; set; }
        public string BasketId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float TotalPrice { get; set; }
        public int TotalProduct { get; set; }
        public bool Completed { get; set; }
        public bool Canceled { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
