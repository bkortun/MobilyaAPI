﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Dtos
{
    public class ListCategoryByProductIdDto
    {
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string ProductId { get; set; }
    }
}
