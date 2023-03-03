using Application.Features.ProductImages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Queries.ListByShowcaseImage
{
    public class ListByShowcaseProductImageQueryHandler : IRequestHandler<ListByShowcaseProductImageQueryRequest, ListByShowcaseProductImageModel>
    {
        private readonly IProductImageRepository _productImageRepository;
        private readonly IMapper _mapper;

        public ListByShowcaseProductImageQueryHandler(IProductImageRepository productImageRepository, IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _mapper = mapper;
        }

        public async Task<ListByShowcaseProductImageModel> Handle(ListByShowcaseProductImageQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<ProductImage> productImages= await _productImageRepository.GetListAsync(
                p => p.ProductId == Guid.Parse(request.ProductId) && 
                p.Image.Showcase==true
                ,include: m => m.Include(p => p.Image).ThenInclude(i => i.File));
            ListByShowcaseProductImageModel listByShowcaseProductImageModel =_mapper.Map<ListByShowcaseProductImageModel>(productImages);
            return listByShowcaseProductImageModel;
        }
    }
}
