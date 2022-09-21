﻿using Application.Features.Products.Commands.CreateProduct;
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
            GetAllProductQueryRequest getAllProductsQueryRequest = new()
            {
                PageRequest = pageRequest,
            };
            ListProductModel result = await Mediator.Send(getAllProductsQueryRequest);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> ListById([FromRoute] ListByIdProductQueryRequest listByIdProductQueryRequest)
        {
            ListByIdProductDto result = await Mediator.Send(listByIdProductQueryRequest);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> ListDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            ListDynamicProductQueryRequest listDynamicProductQueryRequest = new()
            {
                PageRequest = pageRequest,
                Dynamic = dynamic
            };
            ListProductModel result = await Mediator.Send(listDynamicProductQueryRequest);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductDto result = await Mediator.Send(createProductCommandRequest);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductDto result = await Mediator.Send(updateProductCommandRequest);
            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProductCommandRequest deleteProductCommandRequest)
        {
            DeleteProductDto result = await Mediator.Send(deleteProductCommandRequest);
            return Ok(result);
        }
    }
}
