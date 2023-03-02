using Application.Features.ProductImages.Models;
using Application.Features.ProductImages.Queries.ListByShowcaseImage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : BaseController
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> ListByShowcase([FromQuery] ListByShowcaseProductImageQueryRequest request)
        {
            ListByShowcaseProductImageModel result = await Mediator.Send(request);
            return Ok(result);
        }
    }
}
