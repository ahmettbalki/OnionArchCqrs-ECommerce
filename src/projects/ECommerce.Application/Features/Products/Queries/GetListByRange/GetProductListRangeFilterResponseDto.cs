namespace ECommerce.Application.Features.Products.Queries.GetListByRange;

public class GetProductListRangeFilterResponseDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }

    public int SubCategoryId { get; set; }
}