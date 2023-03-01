using Application.Features.Files.Dtos;
using Application.Features.Files.Rules;
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

namespace Application.Features.Files.Commands.DeleteFile
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommandRequest, DeleteFileDto>
    {
        private readonly IFileRepository _fileRepository;
        private readonly IStorageService _storageService;
        private readonly IMapper _mapper;
        private readonly FileBusinessRules _businessRules;

        public DeleteFileCommandHandler(IFileRepository fileRepository, IStorageService storageService, IMapper mapper, FileBusinessRules businessRules)
        {
            _fileRepository = fileRepository;
            _storageService = storageService;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<DeleteFileDto> Handle(DeleteFileCommandRequest request, CancellationToken cancellationToken)
        {
            //todo Requesten file id alındı 
            Domain.Entities.File file = await _businessRules.CheckRequestedFilesNotNull(request.FileId);
            Domain.Entities.File deletedFile = await _fileRepository.DeleteAsync(file);
            await _storageService.DeleteFileAsync(file.Path, file.Name);
            DeleteFileDto deleteFileDto = _mapper.Map<DeleteFileDto>(deletedFile);
            return deleteFileDto;
        }
    }
}
