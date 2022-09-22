using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CheckRequestedEmailWhenLogin(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user == null)
                throw new Exception("Böyle bir email kayıtlı değil");
            return user;
        }

        public void VerifyPassword(string password, byte[] passwordHash,byte[] passwordSalt)
        {
            if (!HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt))
                throw new Exception("Şifre hatalı");
        }

        public async Task CheckRequestedEmailWhenRegister(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email == email);
            if (user != null)
                throw new Exception("Böyle bir email kayıtlı");
        }
    }
}
