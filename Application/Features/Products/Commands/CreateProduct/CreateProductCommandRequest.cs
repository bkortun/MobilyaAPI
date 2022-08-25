﻿using Application.Features.Products.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandRequest:IRequest<CreatedProductDto>
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public long Stock { get; set; }
    }
}
