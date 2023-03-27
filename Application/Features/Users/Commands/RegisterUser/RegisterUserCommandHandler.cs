using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.AuthService;
using Application.Services.BasketService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _businessRules;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules businessRules, IAuthService authService, IBasketService basketService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _businessRules = businessRules;
            _authService = authService;
            _basketService = basketService;
        }

        public async Task<RegisterUserDto> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            byte[] passwordHash, passwordSalt;

            await _businessRules.CheckRequestedEmailWhenRegister(request.UserForRegisterDto.Email);
            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password,out passwordHash,out passwordSalt);
            User user = _mapper.Map<User>(request.UserForRegisterDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            //Todo PasswordConfirm işlemi yapılacak


            //Sistem otomatik ekliyor
            //user.CreatedDate = DateTime.UtcNow;
            //user.Status = true;

            User addedUser = await _userRepository.AddAsync(user);
            AccessToken createdAccessToken =await _authService.CreateAccessTokenAsync(addedUser);
            RefreshToken refreshToken = await _authService.CreateRefreshTokenAsync(addedUser, request.IpAddress);
            RefreshToken addedRefreshToken = await _authService.AddRefreshTokenAsync(refreshToken);
            await _basketService.CreateNewActiveBasket(addedUser);
            await _authService.CreateUserDetailAsync(addedUser.Id.ToString());
            return new()
            {
                AccessToken = createdAccessToken,
                RefreshToken = addedRefreshToken,
            };
        }
    }
}
