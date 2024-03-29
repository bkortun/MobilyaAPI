﻿using Application.Features.Categories.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest:IRequest<UpdateCategoryDto>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
