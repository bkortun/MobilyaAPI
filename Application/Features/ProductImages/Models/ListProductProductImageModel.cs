using Application.Features.ProductImages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Models
{
    public class ListProductProductImageModel: BasePageableModel
    {
        public IList<GetByProductProductImageDto> Items { get; set; }
    }
}
