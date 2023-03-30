using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.DeleteCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
using Application.Features.Categories.Queries.ListCategory;
using Application.Features.Categories.Queries.ListCategoryByProductId;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] PageRequest pageRequest)
        {
            ListCategoryQueryRequest listProductsQueryRequest = new()
            {
                PageRequest = pageRequest,
            };
            ListCategoryModel result = await Mediator.Send(listProductsQueryRequest);
            return Ok(result);
        }
        [HttpGet("{ProductId}")]
        public async Task<IActionResult> ListByProductId([FromRoute] PageRequest pageRequest,[FromQuery] string productId)
        {
            ListCategoryByProductIdQueryRequest request = new() { PageRequest = pageRequest ,ProductId=productId};
            ListCategoryByProductIdModel result =await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommandRequest createProductCommandRequest)
        {
            CreateCategoryDto result = await Mediator.Send(createProductCommandRequest);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommandRequest updateProductCommandRequest)
        {
            UpdateCategoryDto result = await Mediator.Send(updateProductCommandRequest);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCategoryCommandRequest deleteProductCommandRequest)
        {
            DeleteCategoryDto result = await Mediator.Send(deleteProductCommandRequest);
            return Ok(result);
        }
    }
}
