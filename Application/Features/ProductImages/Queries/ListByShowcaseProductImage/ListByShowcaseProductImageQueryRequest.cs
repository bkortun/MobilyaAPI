using Application.Features.ProductImages.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Queries.ListByShowcaseImage
{
    public class ListByShowcaseProductImageQueryRequest : IRequest<ListByShowcaseProductImageModel>
    {
        public string ProductId { get; set; }
    }
}
