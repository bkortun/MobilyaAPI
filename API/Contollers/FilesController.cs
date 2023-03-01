using Application.Features.Files.Commands.DeleteFile;
using Application.Features.Files.Dtos;
using Application.Features.ProductImages.Commands.DeleteProductImage;
using Application.Features.ProductImages.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Contollers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : BaseController
    {
        [HttpDelete("[action]/{FileId}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteFileCommandRequest request)
        {
            DeleteFileDto response = await Mediator.Send(request);
            return Ok(response);
        }
    }
}
