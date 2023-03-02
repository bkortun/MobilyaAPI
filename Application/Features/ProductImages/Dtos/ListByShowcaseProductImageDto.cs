using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Dtos
{
    public class ListByShowcaseProductImageDto
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string ImageId { get; set; }
        public string FileId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
