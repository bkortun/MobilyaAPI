using Application.Features.ProductImages.Dtos;
using Application.Features.ProductImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Infrastructure.Storage.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProductImages.Commands.DeleteProductImage
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommandRequest, DeleteProductImageDto>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;
        private readonly ProductImageBusinessRules _businessRules;

        public DeleteProductImageCommandHandler(IFileRepository fileRepository, IMapper mapper, ProductImageBusinessRules businessRules, IStorageService storageService)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
            _businessRules = businessRules;
            _storageService = storageService;
        }

        public async Task<DeleteProductImageDto> Handle(DeleteProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            //todo Requesten file id alındı 
            Domain.Entities.File file= await _businessRules.CheckRequestedFilesNotNull(request.FileId);
            Domain.Entities.File deletedFile = await _fileRepository.DeleteAsync(file);
            await _storageService.DeleteFileAsync(file.Path, file.Name);
            DeleteProductImageDto deleteProductImageDto =_mapper.Map<DeleteProductImageDto>(deletedFile);
            return deleteProductImageDto;

        }
    }
}
