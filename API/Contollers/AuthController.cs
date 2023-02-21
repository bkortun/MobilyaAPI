using Application.Features.OperationClaims.Commands.CreateOperationClaim;
using Application.Features.OperationClaims.Commands.DeleteOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.OperationClaims.Queries.ListOperationClaim;
using Application.Features.Users.Commands.AddOperationClaim;
using Application.Features.Users.Commands.LoginUser;
using Application.Features.Users.Commands.RegisterUser;
using Application.Features.Users.Commands.RemoveOperationClaim;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Features.Users.Queries.ListOperationClaimByUserEmail;
using Core.Application.Requests;
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
            LoginUserCommandRequest request = new()
            {
                UserForLoginDto = userForLoginDto,
                IpAddress = GetIpAddress(),
            };
            LoginUserDto loginUserDto = await Mediator.Send(request);
            SetRefreshTokenToCookie(loginUserDto.RefreshToken);
            return Ok(loginUserDto.AccessToken);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody] UserForRegisterDto userForRegisterDto)
        {
            RegisterUserCommandRequest request = new()
            {
                UserForRegisterDto = userForRegisterDto,
                IpAddress = GetIpAddress(),
            };
            RegisterUserDto registerUserDto = await Mediator.Send(request);
            SetRefreshTokenToCookie(registerUserDto.RefreshToken);
            return Created("", registerUserDto.AccessToken);
        }

        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOperationClaim([FromBody] CreateOperationClaimCommandRequest request)
        {
            CreateOperationClaimDto response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteOperationClaim([FromQuery] DeleteOperationClaimCommandRequest request)
        {
            DeleteOperationClaimDto response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddOperationClaimToUser([FromBody] AddOperationClaimCommandRequest request)
        {
            AddOperationClaimDto response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveOperationClaimFromUser([FromRoute] RemoveOperationClaimCommandRequest request)
        {
            RemoveOperationClaimDto response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListOperationClaim([FromQuery] PageRequest pageRequest)
        {
            ListOperationClaimQueryRequest request = new() { PageRequest=pageRequest };
            ListOperationClaimModel response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListOperationClaimByUserEmail([FromQuery] ListOperationClaimByUserEmailQueryRequest request)
        {
            ListOperationClaimByUserEmailModel response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
