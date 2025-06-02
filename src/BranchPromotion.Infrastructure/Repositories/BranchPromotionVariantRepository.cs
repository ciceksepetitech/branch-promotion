using BranchPromotion.Domain.Entities;
using BranchPromotion.Domain.Enums;
using BranchPromotion.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BranchPromotion.Infrastructure.Repositories
{
    public class BranchPromotionVariantRepository : IBranchPromotionVariantRepository
    {
        private readonly ApplicationDbContext _context;

        public BranchPromotionVariantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BranchPromotionVariant> InsertAsync(BranchPromotionVariant branchPromotionVariant)
        {
            await _context.BranchPromotionVariant.AddAsync(branchPromotionVariant);
            await _context.SaveChangesAsync();
            return branchPromotionVariant;
        }

        public async Task<BranchPromotionVariant> GetByIdAsync(int id)
        {
            return await _context.BranchPromotionVariant.FindAsync(id);
        }

        public async Task<List<BranchPromotionVariant>> GetByProductAsync(int productId)
        {
            return await _context.BranchPromotionVariant.Where(x => x.ProductId == productId).ToListAsync();
        }

        public async Task<bool> ExistsAsync(int variantId, MainCategories mainCategories, BranchTypes branchTypes, int? branchId, int? senderBranchId)
        {
            var query = _context.BranchPromotionVariant.Where(x => x.VariantId == variantId && 
                               x.MainCategory == mainCategories && 
                               x.BranchType == branchTypes);
            
            if (branchId.HasValue) 
                query = query.Where(x => x.BranchId == branchId.Value);

            if (senderBranchId.HasValue) 
                query = query.Where(x => x.SenderBranchId == senderBranchId.Value);

            return await query.AnyAsync();
        }
    }
} 
