using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductsModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<GetAllProductsModel> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            IList<Product> products = _productRepository.GetAll(tracking: false).Skip(request.Pagination.PageIndex * request.Pagination.PageSize).Take(request.Pagination.PageSize).ToList();
            int totalCount = _productRepository.GetAll(tracking: false).Count();
            return new()
            {
                TotalCount = totalCount,
                Items = products
            };
        }
    }
}
