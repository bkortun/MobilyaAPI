using Application.Features.Products.Dtos;
using Application.Features.Products.Rules;
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
        private readonly ProductBusinessRules _productBusinessRules;

        public DeleteProductCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules productBusinessRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<DeleteProductDto> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            //Todo entity mevcut mu, kontrolü yapılacak
            //Product product = await _productRepository.GetAsync(p => p.Id == Guid.Parse(request.Id));

            Product checkedProduct = await _productBusinessRules.CheckRequestedIsNotNull(request.Id);

            Product deletedProduct=await _productRepository.DeleteAsync(checkedProduct);
            DeleteProductDto deleteProductDto = _mapper.Map<DeleteProductDto>(deletedProduct);
            return deleteProductDto;
        }
    }
}   
