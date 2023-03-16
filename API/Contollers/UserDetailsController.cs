using Application.Features.UserDetailAddresses.Models;
using Application.Features.UserDetails.Commands.CreateUserDetail;
using Application.Features.UserDetails.Commands.DeleteUserDetail;
using Application.Features.UserDetails.Commands.UpdateUserDetail;
using Application.Features.UserDetails.Commands.UploadUserDetail;
using Application.Features.UserDetails.Dtos;
using Application.Features.UserDetails.Models;
using Application.Features.UserDetails.Queries.ListByIdUserDetail;
using Application.Features.UserDetails.Queries.ListProfilePhoto;
using Application.Features.UserDetails.Queries.ListUserDetail;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserDetailCommandRequest request)
        {
            CreateUserDetailDto result = await Mediator.Send(request);
            return Created("", result);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserDetailCommandRequest request)
        {
            UpdateUserDetailDto result = await Mediator.Send(request);
            return Ok(result);
        }
        //[HttpDelete("{Id}")]
        //public async Task<IActionResult> Delete([FromRoute] DeleteUserDetailCommandRequest request)
        //{
        //    DeleteUserDetailDto result = await Mediator.Send(request);
        //    return Ok(result);
        //}
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] PageRequest pageRequest)
        {
            ListUserDetailQueryRequest request = new() { PageRequest = pageRequest };
            ListUserDetailModel result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("{UserId}")]
        public async Task<IActionResult> ListById([FromRoute] ListByIdUserDetailQueryRequest request)
        {
            ListByIdUserDetailDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadUserDetailCommandRequest request)
        {
            request.ProfilePhoto = Request.Form.Files;
            UploadUserDetailDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("[action]/{UserId}")]
        public async Task<IActionResult> ListProfilePhoto([FromRoute] ListProfilePhotoQueryRequest request)
        {
            ListProfilePhotoDto result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
