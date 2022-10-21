using Application.Features.Categories.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler:IRequestHandler<DeleteCategoryCommandRequest,DeleteCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<DeleteCategoryDto> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<Category>(request);
            Category deletedCategory = await _categoryRepository.DeleteAsync(category);
            DeleteCategoryDto deleteCategoryDto = _mapper.Map<DeleteCategoryDto>(deletedCategory);
            return deleteCategoryDto;
        }
    }
}
