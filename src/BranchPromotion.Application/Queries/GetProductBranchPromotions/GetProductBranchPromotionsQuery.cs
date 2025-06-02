using MediatR;

namespace BranchPromotion.Application.Queries.GetProductBranchPromotions;

public sealed record GetProductBranchPromotionsQuery : IRequest<GetProductBranchPromotionsQueryResult>
{
    public int ProductId { get; init; }
}
