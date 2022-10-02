using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImage.Dtos
{
    public class UploadProductImageDto
    {
        public string Id { get; set; }
        public string FileId { get; set; }
        public string ImageId { get; set; }
    }
}
