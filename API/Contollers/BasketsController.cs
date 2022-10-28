using Application.Features.Baskets.Commands.CreateBasket;
using Application.Features.Baskets.Commands.DeleteBasket;
using Application.Features.Baskets.Commands.UpdateBasket;
using Application.Features.Baskets.Dtos;
using Application.Features.Baskets.Models;
using Application.Features.Baskets.Queries.ListBasket;
using Application.Features.Baskets.Queries.ListByUserBasket;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] PageRequest pageRequest)
        {
            ListBasketQueryRequest request = new()
            {
                PageRequest = pageRequest,
            };
            ListBasketModel result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListByUser([FromQuery] ListByUserBasketQueryRequest request)
        {
            ListByUserBasketDto result = await Mediator.Send(request);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBasketCommandRequest request)
        {
            CreateBasketDto result = await Mediator.Send(request);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBasketCommandRequest request)
        {
            UpdateBasketDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBasketCommandRequest request)
        {
            DeleteBasketDto result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}

