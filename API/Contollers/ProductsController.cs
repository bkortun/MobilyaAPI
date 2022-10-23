using Application.Features.ProductImages.Commands.DeleteProductImage;
using Application.Features.ProductImages.Commands.UploadProductImage;
using Application.Features.ProductImages.Dtos;
using Application.Features.ProductImages.Models;
using Application.Features.ProductImages.Queries.ListProductProductImage;
using Application.Features.Products.Commands.AddCategory;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.DeleteProduct;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Application.Features.Products.Queries;
using Application.Features.Products.Queries.ListByIdProduct;
using Application.Features.Products.Queries.ListDynamicProduct;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> List([FromQuery]PageRequest pageRequest)
        {
            ListProductsQueryRequest request = new()
            {
                PageRequest = pageRequest,
            };
            ListProductModel result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> ListById([FromRoute] ListByIdProductQueryRequest request)
        {
            ListByIdProductDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            ListDynamicProductQueryRequest request = new()
            {
                PageRequest = pageRequest,
                Dynamic = dynamic
            };
            ListProductModel result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommandRequest request)
        {
            CreateProductDto result = await Mediator.Send(request);
            return Created("", result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryCommandRequest request)
        {
            AddCategoryDto result = await Mediator.Send(request);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommandRequest request)
        {
            UpdateProductDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommandRequest request)
        {
            DeleteProductDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ProductImageUpload([FromQuery] UploadProductImageCommandRequest request)
        {
            request.Files = Request.Form.Files;
            UploadProductImageModel response =await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{ProductId}")]
        public async Task<IActionResult> ListProductImages([FromRoute] ListProductProductImageQueryRequest request)
        {
            ListProductProductImageModel response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{FileId}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] DeleteProductImageCommandRequest request)
        {
            DeleteProductImageDto response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
