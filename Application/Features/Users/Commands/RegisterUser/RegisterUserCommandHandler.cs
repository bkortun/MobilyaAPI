using Application.Features.Users.Rules;
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
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, AccessToken>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        private readonly UserBusinessRules _businessRules;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules businessRules, ITokenHelper tokenHelper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _businessRules = businessRules;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            byte[] passwordHash, passwordSalt;

            await _businessRules.CheckRequestedEmailWhenRegister(request.Email);

            HashingHelper.CreatePasswordHash(request.Password,out passwordHash,out passwordSalt);
            User user = _mapper.Map<User>(request);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            //Todo Geliştirilebilir mi kontrol et user.CreatedDate = DateTime.UtcNow;   user.Status = true;
            user.CreatedDate = DateTime.UtcNow;
            user.Status = true;

            User addedUser = await _userRepository.AddAsync(user);
            AccessToken accessToken = _tokenHelper.CreateToken(user,new List<OperationClaim>());
            return accessToken;
        }
    }
}
