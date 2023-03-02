using Application.Features.Images.Commands.SetShowcase;
using Application.Features.Images.Dtos;
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
    }
}
