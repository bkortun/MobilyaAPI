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
        private readonly ICategoryRepository _categoryRepository;

        public ListProductsByCategoryIdQueryHandler(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<ListProductsByCategoryIdModel> Handle(ListProductsByCategoryIdQueryRequest request, CancellationToken cancellationToken)
        {
            Category category = await _categoryRepository.GetAsync(c => c.Id == Guid.Parse(request.CategoryId));
            IPaginate<Product> products = await _productRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            ListProductsByCategoryIdModel listByCategoryId = _mapper.Map<ListProductsByCategoryIdModel>(products);
            return listByCategoryId;
        }
    }
}
