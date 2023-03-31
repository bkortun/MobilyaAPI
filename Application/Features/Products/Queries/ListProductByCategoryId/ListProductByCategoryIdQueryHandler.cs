using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
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

namespace Application.Features.Products.Queries.ListProductByCategoryId
{
    public class ListProductsByCategoryIdQueryHandler : IRequestHandler<ListProductsByCategoryIdQueryRequest, ListProductsByCategoryIdModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ListProductsByCategoryIdQueryHandler(IProductRepository productRepository, IMapper mapper, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<ListProductsByCategoryIdModel> Handle(ListProductsByCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<ProductCategory> productCategories = await _productCategoryRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize
            ,predicate:c=>c.CategoryId == Guid.Parse(request.CategoryId),include:p=>p.Include(d=>d.Product).Include(k=>k.Category));
            ListProductsByCategoryIdModel listByCategoryId = _mapper.Map<ListProductsByCategoryIdModel>(productCategories);
            return listByCategoryId;
        }
    }
}
