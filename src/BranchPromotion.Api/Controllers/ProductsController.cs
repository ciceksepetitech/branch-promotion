using BranchPromotion.Application.Queries.GetProductBranchPromotions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BranchPromotion.Api.Controllers;

[ApiController]
[Route("api/v1/products")]
public class ProductsController : ControllerBase
{
    private readonly ISender _sender;

    public ProductsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet("{productId}/branch-promotions")]
    public async Task<IActionResult> GetProductBranchPromotions([FromRoute] int productId)
    {
        var result = await _sender.Send(new GetProductBranchPromotionsQuery
        {
            ProductId = productId
        });

        return Ok(result);
    }
}
