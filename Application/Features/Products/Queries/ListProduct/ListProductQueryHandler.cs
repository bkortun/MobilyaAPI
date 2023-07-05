using Application.Features.Products.Dtos;
using Application.Features.Products.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Caching;
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
        private readonly ICacheManager _cacheManager;

        public ListProductQueryHandler(IProductRepository productRepository, IMapper mapper, ICacheManager cacheManager)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _cacheManager = cacheManager;
        }

        public async Task<ListProductModel> Handle(ListProductsQueryRequest request, CancellationToken cancellationToken)
        {
            if (!_cacheManager.IsAdd("products"))
            {
                IPaginate<Product> products = await _productRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                ListProductModel getAllProductsModel = _mapper.Map<ListProductModel>(products);
                _cacheManager.Add("products", getAllProductsModel, 10);
                return getAllProductsModel;
            }
            else
            {
                return _cacheManager.Get<ListProductModel>("products");
            }
        }
    }
}
