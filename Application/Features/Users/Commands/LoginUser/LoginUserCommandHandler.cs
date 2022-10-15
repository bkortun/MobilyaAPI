using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserDto>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IAuthService _authService;
        private readonly UserBusinessRules _businessRules;

        public LoginUserCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, UserBusinessRules businessRules, IAuthService authService)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _businessRules = businessRules;
            _authService = authService;
        }

        public async Task<LoginUserDto> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            //Todo sorulacak burda iki kere _businessRules sınıfından method çağırmak yerine _businessRules sınıfında ikisini içeren bir method yazamak
            //daha mı uygun?
            User user = await _businessRules.CheckRequestedEmailWhenLogin(request.UserForLoginDto.Email);
            _businessRules.VerifyPassword(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);
            AccessToken createdAccessToken = await _authService.CreateAccessTokenAsync(user);
            RefreshToken createdRefreshToken = await _authService.CreateRefreshTokenAsync(user, request.IpAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefreshTokenAsync(createdRefreshToken);
            return new()
            {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefreshToken,
            };
        }
    }
}
