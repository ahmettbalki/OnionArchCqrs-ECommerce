﻿using AutoMapper;
using ECommerce.Application.Features.Categories.Rules;
using ECommerce.Domain.Entities;
using ECommerce.Application.Services.Repositories;
using MediatR;
using Core.Application.Pipelines.Authorization;
using Core.Security.Constants;
using Core.Application.Pipelines.Logging;
namespace ECommerce.Application.Features.Categories.Commands.Create;
public sealed class CategoryAddCommand : IRequest<CategoryAddedResponseDto>, ILoggableRequest, ISecuredRequest
{
    public string Name { get; set; }

    public string[] Roles => [GeneralOperationClaims.Admin];

    public sealed class CategoryAddCommandHandler
        (IMapper mapper, ICategoryRepository categoryRepository, CategoryBusinessRules categoryBusinessRules)
        : IRequestHandler<CategoryAddCommand, CategoryAddedResponseDto>
    {
        public async Task<CategoryAddedResponseDto> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            await categoryBusinessRules.CategoryNameMustBeUniqueAsync(request.Name, cancellationToken);
            Category category = mapper.Map<Category>(request);
            Category addedCategory =  await categoryRepository.AddAsync(category);
            CategoryAddedResponseDto response = mapper.Map<CategoryAddedResponseDto>(addedCategory); 
            return response;
        }
    }
}