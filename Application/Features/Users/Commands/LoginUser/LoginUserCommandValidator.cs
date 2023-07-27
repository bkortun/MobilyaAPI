using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandValidator:AbstractValidator<LoginUserCommandRequest>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(l => l.UserForLoginDto.Email).EmailAddress().WithMessage("Please enter a correct email address!");
            RuleFor(l => l.UserForLoginDto.Password).MinimumLength(6).WithMessage("Password should be minimum 6 character!");
        }
    }
}
