using Application.Features.BasketItems.Commands.CreateBasketItem;
using Application.Features.BasketItems.Commands.DeleteBasketItem;
using Application.Features.BasketItems.Commands.UpdateBasketItem;
using Application.Features.BasketItems.Commands.UpdateBasketItemQuantity;
using Application.Features.BasketItems.Dtos;
using Application.Features.BasketItems.Models;
using Application.Features.BasketItems.Queries.ListBasketItem;
using Application.Features.BasketItems.Queries.ListByBasket;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketItemsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] PageRequest pageRequest)
        {
            ListBasketItemQueryRequest request = new()
            {
                PageRequest = pageRequest,
            };
            ListBasketItemModel result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListByBasket([FromQuery] PageRequest pageRequest,string basketId)
        {
            ListByBasketQueryRequest request = new()
            {
                PageRequest = pageRequest,
                BasketId=basketId
            };
            ListByBasketModel result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBasketItemCommandRequest request)
        {
            CreateBasketItemDto result = await Mediator.Send(request);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBasketItemCommandRequest request)
        {
            UpdateBasketItemDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateQuantity([FromBody] UpdateBasketItemQuantityCommandRequest request)
        {
            UpdateBasketItemQuantityDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBasketItemCommandRequest request)
        {
            DeleteBasketItemDto result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
