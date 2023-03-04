using Application.Features.ProductImages.Models;
using Core.Application.Requests;
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
    }
}
