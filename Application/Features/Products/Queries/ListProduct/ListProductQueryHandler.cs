using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries
{
    public class ListProductQueryHandler : IRequestHandler<ListProductsQueryRequest, ListProductModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ListProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ListProductModel> Handle(ListProductsQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<Product> products = await _productRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);
            ListProductModel getAllProductsModel = _mapper.Map<ListProductModel>(products);
            return getAllProductsModel;
        }
    }
}
