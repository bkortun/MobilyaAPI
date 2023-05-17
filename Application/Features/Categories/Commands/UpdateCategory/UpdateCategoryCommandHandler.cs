using Application.Features.Categories.Dtos;
using Application.Features.Categories.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _businessRules;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules businessRules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }
        public async Task<UpdateCategoryDto> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            //await _businessRules.CheckRequestedIsNotNull(request.Id);
            Category category = _mapper.Map<Category>(request);
            Category updatedCategory = await _categoryRepository.UpdateAsync(category);
            UpdateCategoryDto updateCategoryDto = _mapper.Map<UpdateCategoryDto>(updatedCategory);
            return updateCategoryDto;
        }
    }
}
