using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Commands.DeleteOrder;
using Application.Features.Orders.Commands.UpdateOrder;
using Application.Features.Orders.Dtos;
using Application.Features.Orders.Models;
using Application.Features.Orders.Queries.ListOrder;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] PageRequest pageRequest)
        {
            ListOrderQueryRequest request = new()
            {
                PageRequest = pageRequest,
            };
            ListOrderModel result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOrderCommandRequest request)
        {
            CreateOrderDto result = await Mediator.Send(request);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOrderCommandRequest request)
        {
            UpdateOrderDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteOrderCommandRequest request)
        {
            DeleteOrderDto result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
