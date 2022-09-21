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

namespace Application.Features.Products.Queries.ListDynamicProduct
{
    public class ListDynamicProductQueryHandler : IRequestHandler<ListDynamicProductQueryRequest, ListProductModel>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ListDynamicProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ListProductModel> Handle(ListDynamicProductQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<Product> products = await _productRepository.GetListByDynamicAsync(request.Dynamic, index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            ListProductModel listProductModel = _mapper.Map<ListProductModel>(products);
            return listProductModel;
        }
    }
}
