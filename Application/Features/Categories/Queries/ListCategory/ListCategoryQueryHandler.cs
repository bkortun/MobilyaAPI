using Application.Features.Categories.Models;
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

namespace Application.Features.Categories.Queries.ListCategory
{
    public class ListCategoryQueryHandler : IRequestHandler<ListCategoryQueryRequest, ListCategoryModel>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ListCategoryQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<ListCategoryModel> Handle(ListCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            IPaginate<Category> categories = await _categoryRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
            ListCategoryModel listCategoryModel = _mapper.Map<ListCategoryModel>(categories);
            return listCategoryModel;
        }
    }
}
