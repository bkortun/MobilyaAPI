using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Application.Features.Products.Queries;
using Application.RequestParameters;
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
        public async Task<IActionResult> GetAll([FromQuery]Pagination pagination)
        {
            GetAllProductQueryRequest getAllProductsQueryRequest = new()
            {
                Pagination = pagination,
            };
            GetAllProductsModel result = await Mediator.Send(getAllProductsQueryRequest);
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
