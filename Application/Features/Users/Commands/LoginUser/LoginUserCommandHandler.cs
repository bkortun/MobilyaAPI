using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly UserBusinessRules _businessRules;

        public LoginUserCommandHandler(IUserRepository userRepository, ITokenHelper tokenHelper, UserBusinessRules businessRules)
        {
            _userRepository = userRepository;
            _tokenHelper = tokenHelper;
            _businessRules = businessRules;
        }

        public async Task<AccessToken> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            User user = await _businessRules.CheckRequestedEmailWhenLogin(request.Email);
            _businessRules.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);
            IList<OperationClaim> operationClaims = _userRepository.GetClaims(user);
            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }
    }
}
