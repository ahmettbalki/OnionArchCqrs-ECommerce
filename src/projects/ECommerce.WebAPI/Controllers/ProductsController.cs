using ECommerce.Application.Features.Products.Commands.Create;
using ECommerce.Application.Features.Products.Commands.Update;
using ECommerce.Application.Features.Products.Commands.Delete;
using ECommerce.Application.Features.Products.Queries.GetList;
using ECommerce.Application.Features.Products.Queries.GetListByImages;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.Features.Products.Queries.GetListByElasticSearch;
using ECommerce.Application.Features.Products.Queries.GetListFilterByElasticSearch;
namespace ECommerce.WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController(IMediator mediator) : BaseController
{

    [HttpPost("add")]
    public async Task<IActionResult> Add(ProductAddCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var response = await mediator.Send(new GetListProductQuery());

        return Ok(response);
    }

    [HttpGet("getallbyimages")]
    public async Task<IActionResult> GetAllByImageUrls()
    {
        var response = await mediator.Send(new GetListProductByProductImageQuery());
        return Ok(response);
    }

    [HttpGet("elasticall")]
    public async Task<IActionResult> GetAllElastic()
    {
        var response = await mediator.Send(new GetProductListElasticSearchQuery());
        return Ok(response);
    }

    [HttpGet("filter")]
    public async Task<IActionResult> GetAllByFilter([FromQuery] string text)
    {
        var query = new GetProductListFilterByElasticSearchQuery() { Text = text };

        var response = await mediator.Send(query);
        return Ok(response);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] Guid id)
    {
        var command = new ProductDeleteCommand() { Id = id };

        var response = await mediator.Send(command);

        return Ok(response);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] ProductUpdateCommand command) => Ok(
        await mediator.Send(command)
    );

}