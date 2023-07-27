using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator:AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(u => u.Name).NotEmpty();
            RuleFor(u => u.Name).MinimumLength(2);
            RuleFor(u => u.Description).NotEmpty();
            RuleFor(u => u.Description).MinimumLength(8);
            RuleFor(u => u.Price).NotEmpty();
            RuleFor(u => u.Stock).NotEmpty();
        }
    }
}
