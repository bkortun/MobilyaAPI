using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryRequest, List<GetAllProductsDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllProductsDto>> Handle(GetAllProductsQueryRequest request, CancellationToken cancellationToken)
        {
            var products=_productRepository.GetAll(null,false);
           
             List<GetAllProductsDto> result= _mapper.Map<List<GetAllProductsDto>>(products);
            
            return result;
        }
    }
}
