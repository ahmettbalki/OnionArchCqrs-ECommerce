﻿using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Transaction;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;
namespace ECommerce.Application.Features.Products.Commands.Update;
public class ProductUpdateCommand : MediatR.IRequest<ProductUpdateResponseDto>, ITransactionalRequest, ICacheRemoverRequest
// ,ISecuredRequest 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public int SubCategoryId { get; set; }
    public string CacheKey => "";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "Products";
    // public string[] Roles => [GeneralOperationClaims.Admin];
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, ProductUpdateResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IElasticClient _elasticClient;
        public ProductUpdateCommandHandler(IMapper mapper, IProductRepository productRepository, IElasticClient elasticClient)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _elasticClient = elasticClient;
        }
        public async Task<ProductUpdateResponseDto> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            var updated = await _productRepository.UpdateAsync(product);
            var responseDto = _mapper.Map<ProductUpdateResponseDto>(updated);
            var updatedResponse = await _elasticClient.UpdateAsync<ProductUpdateResponseDto>(
                product.Id.ToString(), u => u.Index("products")
                    .Doc(responseDto)
            );
            if (!updatedResponse.IsValid)
            {
                throw new BusinessException(updatedResponse.OriginalException.Message);
            }
            return responseDto;
        }
    }
}
