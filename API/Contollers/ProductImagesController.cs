using Application.Features.ProductImages.Commands.UploadProductImage;
using Application.Features.ProductImages.Models;
using Application.Features.ProductImages.Queries.ListByShowcaseImage;
using Application.Features.ProductImages.Queries.ListProductProductImage;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : BaseController
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> ProductImageUpload([FromQuery] UploadProductImageCommandRequest request)
        {
            request.Files = Request.Form.Files;
            UploadProductImageModel response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{ProductId}")]
        public async Task<IActionResult> ListProductImages([FromRoute] ListProductImageQueryRequest request)
        {
            ListProductImageModel response = await Mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ListByShowcase()
        {
            ListByShowcaseProductImageQueryRequest request = new();
            ListByShowcaseProductImageModel result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
