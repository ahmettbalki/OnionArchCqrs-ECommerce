using MediatR;
using Nest;
namespace ECommerce.Application.Features.Products.Queries.GetListByRange;
public class GetProductListRangeFilterQuery : MediatR.IRequest<List<GetProductListRangeFilterResponseDto>>
{
    public double? StockMin { get; set; }
    public double? StockMax { get; set; }
    public double? PriceMin { get; set; }
    public double? PriceMax { get; set; }
    public class GetProductListRangeFilterQueryHandler : IRequestHandler<GetProductListRangeFilterQuery, List<GetProductListRangeFilterResponseDto>>
    {
        private readonly IElasticClient _elasticClient;
        public GetProductListRangeFilterQueryHandler(IElasticClient elasticClient)
        {
            _elasticClient = elasticClient;
        }
        public async Task<List<GetProductListRangeFilterResponseDto>> Handle(GetProductListRangeFilterQuery request, CancellationToken cancellationToken)
        {
            var searchResponse = await _elasticClient.SearchAsync<GetProductListRangeFilterResponseDto>(
                s =>
                    s.Index("products")
                        .Query(q =>
                            q.Bool(b =>
                                b.Filter(f =>
                                    f.Range(r =>
                                        r.Field(p => p.Stock)
                                            .GreaterThanOrEquals(request.StockMin.HasValue ? request.StockMin : 0)
                                            .LessThanOrEquals(request.StockMax.HasValue ? request.StockMax : double.MaxValue)
                                        ) &&
                                    f.Range(r =>
                                        r.Field(p => p.Price)
                                            .GreaterThanOrEquals(request.PriceMin.HasValue ? request.PriceMin : 0)
                                            .LessThanOrEquals(request.PriceMax.HasValue ? request.PriceMax : double.MaxValue)
                                        )

                                    )

                                )
                            )
                );
            return searchResponse.Documents.ToList();
        }
    }
}
