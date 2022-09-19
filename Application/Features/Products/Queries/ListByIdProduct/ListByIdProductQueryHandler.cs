using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Queries.ListByIdProduct
{
    public class ListByIdProductQueryHandler : IRequestHandler<ListByIdProductQueryRequest, ListByIdProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ListByIdProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ListByIdProductDto> Handle(ListByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            Product product = await _productRepository.GetAsync(p => p.Id == Guid.Parse(request.Id));
            ListByIdProductDto listByIdProductDto = _mapper.Map<ListByIdProductDto>(product);
            return listByIdProductDto;
        }
    }
}
