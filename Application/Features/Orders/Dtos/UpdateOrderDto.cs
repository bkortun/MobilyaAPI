﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Dtos
{
    public class UpdateOrderDto
    {
        public string Id { get; set; }
        public Guid BasketId { get; set; }
    }
}
