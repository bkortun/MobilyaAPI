using Application.Features.Products.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.AddCategory
{
    public class AddCategoryCommandRequest:IRequest<AddCategoryDto>
    {
        
        public string ProductId { get; set; }
        public string CategoryId { get; set; }
    }
}
