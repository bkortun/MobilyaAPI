using Application.Features.Addresses.Commands.CreateAddress;
using Application.Features.Addresses.Commands.DeleteAddress;
using Application.Features.Addresses.Commands.UpdateAddress;
using Application.Features.Addresses.Dtos;
using Application.Features.Addresses.Models;
using Application.Features.Addresses.Queries.ListAddress;
using Application.Features.Addresses.Query.ListByIdAddress;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateAddressCommandRequest request)
        {
            CreateAddressDto result = await Mediator.Send(request);
            return Created("",result);

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAddressCommandRequest request)
        {
            UpdateAddressDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteAddressCommandRequest request)
        {
            DeleteAddressDto result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] PageRequest pageRequest)
        {
            ListAddressQueryRequest request = new() { PageRequest = pageRequest };
            ListAddressModel result = await Mediator.Send(request);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> ListById([FromRoute] ListByIdAddressQueryRequest request)
        {
            ListByIdAddressDto result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
