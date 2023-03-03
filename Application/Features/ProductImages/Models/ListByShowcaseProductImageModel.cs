using Application.Features.ProductImages.Dtos;
using Application.Features.Products.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Models
{
    public class ListByShowcaseProductImageModel : BasePageableModel
    {
        public IList<ListByShowcaseProductImageDto> Items { get; set; }

    }
}
