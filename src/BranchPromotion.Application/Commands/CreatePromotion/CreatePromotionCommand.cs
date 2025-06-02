using MediatR;

namespace BranchPromotion.Application.Commands.CreatePromotion;

public sealed record CreatePromotionCommand : IRequest
{
    public int VariantId { get; init; }

    public string VariantCode { get; init; }
    
    public int ProductId { get; set; }
    
    public string ProductName { get; init; }
    
    public int? BranchId { get; init; }
    
    public int? SenderBranchId { get; init; }
    
    public int[] MainCategoryIds { get; init; }
    
    public int[] BranchTypes { get; init; }
    
    public decimal MinimumPrice { get; init; }
    
    public decimal MaximumPrice { get; init; }

    public ushort Sequence { get; init; }
    
    public bool IsActive { get; init; }

    public int UserId { get; set; }
}
