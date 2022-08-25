using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Dtos;
using Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetAllProductsQueryRequest getAllProductsQueryRequest)
        {
            List<GetAllProductsDto> result = await Mediator.Send(getAllProductsQueryRequest);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommandRequest createProductCommandRequest)
        {
            CreatedProductDto result = await Mediator.Send(createProductCommandRequest);
            return Created("", result);
        }
    }
}
