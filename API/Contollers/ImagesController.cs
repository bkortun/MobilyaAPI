using Application.Features.Images.Commands.SetShowcase;
using Application.Features.Images.Commands.Upload;
using Application.Features.Images.Dtos;
using Application.Features.Images.Models;
using Application.Features.ProductImages.Commands.UploadProductImage;
using Application.Features.ProductImages.Models;
using Application.Features.ProductImages.Queries.ListByShowcaseImage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : BaseController
    {
        [HttpPut("[action]")]
        public async Task<IActionResult> SetShowcase([FromBody] SetShowcaseImageCommandRequest request)
        {
            SetShowcaseImageDto result = await Mediator.Send(request);
            return Ok(result);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadImageCommandRequest request)
        {
            request.Files = Request.Form.Files;
            UploadImageModel response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
