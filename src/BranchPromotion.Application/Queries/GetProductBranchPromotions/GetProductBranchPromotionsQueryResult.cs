using BranchPromotion.Domain.Entities;

namespace BranchPromotion.Application.Queries.GetProductBranchPromotions;

public sealed record GetProductBranchPromotionsQueryResult
{
    public List<GetProductBranchPromotionsQueryResultItemDto> BranchPromotions { get; init; } = new();
}

public sealed record GetProductBranchPromotionsQueryResultItemDto
{
    public int Id { get; init; }
    
    public string ProductName { get; init; }

    public int VariantId { get; set; }

    public string VariantCode { get; set; }

    public bool IsActive { get; set; }
}
