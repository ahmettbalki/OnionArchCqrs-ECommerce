using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using Core.Security.Constants;
using ECommerce.Application.Features.Products.Commands.Create;
using ECommerce.Application.Services.Repositories;
using MediatR;
namespace ECommerce.Application.Features.Products.Commands.Delete;
internal class ProductDeleteCommand : IRequest<string>,
    ICacheRemoverRequest,
    ILoggableRequest,
    ISecuredRequest,
    ITransactionalRequest
{
    public string CacheKey => "";
    public bool ByPassCache => false;
    public string? CacheGroupKey => "Products";
    public string[] Roles => [GeneralOperationClaims.Admin];
    public Guid Id { get; set; }
    public sealed class ProductDeleteCommandHandler : IRequestHandler<ProductDeleteCommand, string>
    {
        private readonly IProductRepository _productRepository;
        private readonly IElasticClient _elasticClient;
        public ProductDeleteCommandHandler(IProductRepository productRepository, IElasticClient elasticClient)
        {
            _productRepository = productRepository;
            _elasticClient = elasticClient;
        }
        public async Task<string> Handle(ProductDeleteCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetAsync(x => x.Id == request.Id);
            var deletedResponse = await _elasticClient.DeleteAsync<ProductAddResponseDto>(product!.Id,
                idx => idx.Index("products")
                );
            if (!deletedResponse.IsValid)
            {
                throw new BusinessException(deletedResponse.ServerError.Error.Reason);
            }
            await _productRepository.DeleteAsync(product, true);
            return "Ürün Silindi.";
        }
    }
}
