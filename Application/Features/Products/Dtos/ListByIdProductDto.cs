﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Dtos
{
    public class ListByIdProductDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public long Stock { get; set; }
        public string Description { get; set; }
        public int ViewCount { get; set; }
        public int LikeCount { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool Status { get; set; }
    }
}
