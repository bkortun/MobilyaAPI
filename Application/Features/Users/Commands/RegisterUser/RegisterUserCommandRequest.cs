using Core.Security.Dtos;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandRequest:UserForRegisterDto,IRequest<AccessToken>
    {
    }
}
