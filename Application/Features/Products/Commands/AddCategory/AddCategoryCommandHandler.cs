using Application.Features.Products.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.AddCategory
{
    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommandRequest, AddCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public AddCategoryCommandHandler(ICategoryRepository categoryRepository, IProductRepository productRepository, IProductCategoryRepository productCategoryRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<AddCategoryDto> Handle(AddCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            //Todo entity mevcutmu kontrolü yapılacak
            Category category =await _categoryRepository.GetAsync(c => c.Id ==Guid.Parse( request.CategoryId));
            Product product=await _productRepository.GetAsync(p => p.Id ==Guid.Parse( request.ProductId));
            ProductCategory productCategory = new()
            {
                CategoryId = category.Id,
                ProductId = product.Id,
            };
            ProductCategory addedProductCategory=await _productCategoryRepository.AddAsync(productCategory);
            return new()
            {
                Id = addedProductCategory.Id.ToString(),
                CategoryName = category.Name,
                ProductName = product.Name,
            };
        }
    }
}
