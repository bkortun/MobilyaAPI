using Application.Features.ProductImage.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Models
{
    public class UploadProductImageModel
    {
        IList<UploadProductImageDto> Items { get; set; }
    }
}
