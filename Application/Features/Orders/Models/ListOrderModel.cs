﻿using Application.Features.Orders.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Models
{
    public class ListOrderModel:BasePageableModel
    {
        public IList<ListOrderDto> Items { get; set; }
    }
}
