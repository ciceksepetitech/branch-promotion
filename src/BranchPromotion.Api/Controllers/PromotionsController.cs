using BranchPromotion.Api.Models.Promotions;
using BranchPromotion.Application.Commands.CreatePromotion;
using BranchPromotion.Application.Queries.GetPromotions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BranchPromotion.Api.Controllers;

[ApiController]
[Route("api/v1/promotions")]
public class PromotionsController : ControllerBase
{
    private readonly ISender _sender;

    public PromotionsController(ISender sender)
    {
        _sender = sender;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(GetPromotionsResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<GetPromotionsResponse> Get([FromQuery] GetPromotionsRequest request)
    {
        var result = await _sender.Send(new GetPromotionsQuery
        {
        });

        return new GetPromotionsResponse()
        {
            
        };
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Post([FromBody] CreatePromotionRequest request)
    {
        var command = ToCreatePromotionCommand(request);
        await _sender.Send(command);
        return NoContent();
    }

    private static CreatePromotionCommand ToCreatePromotionCommand(CreatePromotionRequest request)
    {
        return new CreatePromotionCommand
        {
            ProductId = request.ProductId,
            ProductName = request.ProductName,
            VariantId = request.VariantId,
            VariantCode = request.VariantCode,
            BranchId = request.BranchId,
            SenderBranchId = request.SenderBranchId,
            MainCategoryIds = request.MainCategoryIds,
            BranchTypes = request.BranchTypes,
            MinimumPrice = request.MinimumPrice,
            MaximumPrice = request.MaximumPrice,
            IsActive = request.IsActive
        };
    }
}
