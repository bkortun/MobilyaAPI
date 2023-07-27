using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator:AbstractValidator<CreateProductCommandRequest>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Description).MinimumLength(8);
            RuleFor(p => p.Description).NotEmpty();
            RuleFor(p => p.Price).NotEmpty();
            RuleFor(p => p.Stock).NotEmpty();

        }
    }
}
