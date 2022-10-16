using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.ListOperationClaim;
using Application.Features.Users.Commands.AddOperationClaim;
using Application.Features.Users.Commands.LoginUser;
using Application.Features.Users.Commands.RegisterUser;
using Application.Features.Users.Dtos;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] UserForLoginDto userForLoginDto)
        {
            LoginUserCommandRequest loginUserCommandRequest = new()
            {
                UserForLoginDto = userForLoginDto,
                IpAddress = GetIpAddress(),
            };
            LoginUserDto loginUserDto = await Mediator.Send(loginUserCommandRequest);
            SetRefreshTokenToCookie(loginUserDto.RefreshToken);
            return Ok(loginUserDto.AccessToken);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterUserCommandRequest registerAuthCommandRequest = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress(),
            };
            RegisterUserDto registerUserDto = await Mediator.Send(registerAuthCommandRequest);
            SetRefreshTokenToCookie(registerUserDto.RefreshToken);
            return Created("", registerUserDto.AccessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOperationClaim([FromBody] CreateOperationClaimCommandRequest createOperationClaimCommandRequest)
        {
            CreateOperationClaimDto response = await Mediator.Send(createOperationClaimCommandRequest);
            return Ok(response);
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteOperationClaim([FromQuery] DeleteOperationClaimCommandRequest deleteOperationClaimCommandRequest)
        {
            DeleteOperationClaimDto response = await Mediator.Send(deleteOperationClaimCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOperationClaimToUser([FromBody] AddOperationClaimCommandRequest addOperationClaimCommandRequest)
        {
            AddOperationClaimDto response = await Mediator.Send(addOperationClaimCommandRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListOperationClaim([FromQuery] ListOperationClaimQueryRequest listOperationClaimQueryRequest)
        {
            ListOperationClaimModel response = await Mediator.Send(listOperationClaimQueryRequest);
            return Ok(response);
        }
    }
}
