using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Features.Users.Dtos
{
    public class LoginUserDto
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}
