using BranchPromotion.Domain.Repositories;
using MediatR;

namespace BranchPromotion.Application.Queries.GetProductBranchPromotions;

public sealed class GetProductBranchPromotionsQueryHandler : IRequestHandler<GetProductBranchPromotionsQuery, GetProductBranchPromotionsQueryResult>
{
    private readonly IBranchPromotionVariantRepository _branchPromotionVariantRepository;

    public GetProductBranchPromotionsQueryHandler(IBranchPromotionVariantRepository branchPromotionVariantRepository)
    {
        _branchPromotionVariantRepository = branchPromotionVariantRepository;
    }

    public async Task<GetProductBranchPromotionsQueryResult> Handle(GetProductBranchPromotionsQuery request, CancellationToken cancellationToken)
    {
        var branchPromotions = await _branchPromotionVariantRepository.GetByProductAsync(request.ProductId);
        return new GetProductBranchPromotionsQueryResult
        {
            BranchPromotions = new()
        };
    }
}
