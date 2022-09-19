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

namespace Application.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, DeleteProductDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<DeleteProductDto> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            Product product =await _productRepository.GetAsync(p=>p.Id==Guid.Parse(request.Id));
            Product deletedProduct=await _productRepository.DeleteAsync(product);
            DeleteProductDto deleteProductDto = _mapper.Map<DeleteProductDto>(deletedProduct);
            return deleteProductDto;
        }
    }
}
