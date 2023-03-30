using Application.Features.Categories.Dtos;
using Application.Features.Categories.Models;
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

namespace Application.Features.Categories.Queries.ListCategoryByProductId
{
    public class ListCategoryByProductIdQueryHandler : IRequestHandler<ListCategoryByProductIdQueryRequest, ListCategoryByProductIdModel>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ListCategoryByProductIdQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, IProductCategoryRepository productCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<ListCategoryByProductIdModel> Handle(ListCategoryByProductIdQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<ProductCategory> productCategories = await _productCategoryRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize
            ,predicate: p => p.ProductId == Guid.Parse(request.ProductId),include:p=>p.Include(a=>a.Category));
            ListCategoryByProductIdModel listCategoryModel = _mapper.Map<ListCategoryByProductIdModel>(productCategories);
            return listCategoryModel;
        }
    }
}
