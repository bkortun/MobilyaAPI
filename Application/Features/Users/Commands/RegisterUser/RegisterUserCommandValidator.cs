using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandValidator:AbstractValidator<RegisterUserCommandRequest>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(r => r.UserForRegisterDto.FirstName).NotEmpty();
            RuleFor(r => r.UserForRegisterDto.LastName).NotEmpty();
            RuleFor(r => r.UserForRegisterDto.Email).EmailAddress().WithMessage("Please enter a correct email address!");
            RuleFor(r => r.UserForRegisterDto.Email).NotEmpty();
            RuleFor(r => r.UserForRegisterDto.Password).NotEmpty();
            RuleFor(r => r.UserForRegisterDto.Password).MinimumLength(6).WithMessage("Password should be minimum 6 character");
        }
    }
}
