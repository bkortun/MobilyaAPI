using Application.Features.ProductImages.Dtos;
using Application.Features.ProductImages.Rules;
using Application.Services.FileService;
using Application.Services.Repositories;
using AutoMapper;
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
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        private readonly ProductImageBusinessRules _businessRules;

        public DeleteProductImageCommandHandler(IFileRepository fileRepository, IMapper mapper, ProductImageBusinessRules businessRules, IFileService fileService)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
            _businessRules = businessRules;
            _fileService = fileService;
        }

        public async Task<DeleteProductImageDto> Handle(DeleteProductImageCommandRequest request, CancellationToken cancellationToken)
        {
            //todo Requesten file id alındı 
            Domain.Entities.File file= await _businessRules.CheckRequestedFileIsNotNull(request.FileId);
            Domain.Entities.File deletedFile = await _fileRepository.DeleteAsync(file);
            _fileService.DeleteLocal(file.Path, file.Name);
            DeleteProductImageDto deleteProductImageDto =_mapper.Map<DeleteProductImageDto>(deletedFile);
            return deleteProductImageDto;

        }
    }
}
