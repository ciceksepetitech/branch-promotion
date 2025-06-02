namespace BranchPromotion.Api.Models.Promotions;

public sealed record CreatePromotionRequest
{
    public int ProductId { get; init; }

    public string ProductName { get; init; }
    
    public int VariantId { get; init; }

    public string VariantCode { get; init; }
    
    public int? BranchId { get; init; }

    public int? SenderBranchId { get; init; }

    public int[] MainCategoryIds { get; init; }

    public int[] BranchTypes { get; init; }

    public decimal MinimumPrice { get; init; }

    public decimal MaximumPrice { get; init; }

    public bool IsActive { get; init; }
}
