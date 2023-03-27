using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserDetailRepository _userDetailRepository;

        public AuthManager(IUserOperationClaimRepository userOperationClaimRepository, IRefreshTokenRepository refreshTokenRepository, ITokenHelper tokenHelper, IUserDetailRepository userDetailRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _refreshTokenRepository = refreshTokenRepository;
            _tokenHelper = tokenHelper;
            _userDetailRepository = userDetailRepository;
        }

        public async Task<RefreshToken> AddRefreshTokenAsync(RefreshToken refreshToken)
        {
            RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
            return addedRefreshToken;
        }

        public async Task<AccessToken> CreateAccessTokenAsync(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await _userOperationClaimRepository.GetListAsync(u=>u.UserId == user.Id,
                include:u=>u.Include(o=>o.OperationClaim));
            IList<OperationClaim> operationClaims = userOperationClaims.Items.Select(u=> new OperationClaim 
            {Id=u.OperationClaim.Id,Name=u.OperationClaim.Name }).ToList();
            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;

        }

        public  Task<RefreshToken> CreateRefreshTokenAsync(User user, string ipAddress)
        {
            RefreshToken createdRefreshToken= _tokenHelper.CreateRefreshToken(user, ipAddress);
            return Task.FromResult(createdRefreshToken);
        }

        public async Task CreateUserDetailAsync(string userId)
        {
            //Todo refactor edilecek
            UserDetail userDetail = new()
            {
                UserId = Guid.Parse(userId),
            };
            await _userDetailRepository.AddAsync(userDetail);
        }

        //Todo Kullanıcı şifre değiştirme operasyonu eklenecek ve email/otp ile kontrol edilecek
    }
}
