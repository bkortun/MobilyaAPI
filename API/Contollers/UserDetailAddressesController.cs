using Application.Features.UserDetailAddresses.Commands.CreateUserDetailAddress;
using Application.Features.UserDetailAddresses.Commands.DeleteUserDetailAddress;
using Application.Features.UserDetailAddresses.Commands.UpdateUserDetailAddress;
using Application.Features.UserDetailAddresses.Dtos;
using Application.Features.UserDetailAddresses.Models;
using Application.Features.UserDetailAddresses.Queries.ListByIdUserDetailAddress;
using Application.Features.UserDetailAddresses.Queries.ListUserDetailAddress;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailAddressesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserDetailAddressCommandRequest request)
        {
            CreateUserDetailAddressDto result = await Mediator.Send(request);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDetailAddressCommandRequest request)
        {
            UpdateUserDetailAddressDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteUserDetailAddressCommandRequest request)
        {
            DeleteUserDetailAddressDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] ListUserDetailAddressQueryRequest request)
        {
            ListUserDetailAddressModel result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> ListById([FromRoute] ListByIdUserDetailAddressQueryRequest request)
        {
            ListByIdUserDetailAddressDto result = await Mediator.Send(request);
            return Ok(result);

        }
    }
}