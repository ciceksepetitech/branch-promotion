using BranchPromotion.Domain.Entities;
using BranchPromotion.Domain.Enums;

namespace BranchPromotion.Domain.Repositories
{
    public interface IBranchPromotionVariantRepository
    {
        Task<BranchPromotionVariant> InsertAsync(BranchPromotionVariant branchPromotionVariant);
        Task<BranchPromotionVariant> GetByIdAsync(int id);
        Task<List<BranchPromotionVariant>> GetByProductAsync(int productId);
        Task<bool> ExistsAsync(int variantId, MainCategories mainCategories, BranchTypes branchTypes, int? branchId, int? senderBranchId);
    }
} 
