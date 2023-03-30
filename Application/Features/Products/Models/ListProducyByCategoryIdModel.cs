﻿using Application.Features.Products.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Models
{
    public class ListProductsByCategoryIdModel:BasePageableModel
    {
        public IList<ListProductsByCategoryIdDto> Items { get; set; }
    }
}
