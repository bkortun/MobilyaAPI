using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Dtos
{
    public class AddCategoryDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
    }
}
