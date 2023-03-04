using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Dtos
{
    public class ListProductImageDto
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public float Price { get; set; }
        public long Stock { get; set; }
        public string ImageId { get; set; }
        public string FileId { get; set; }
        public string ImageName { get; set; }
        public string Path { get; set; }
        public bool Showcase { get; set; }
    }
}
