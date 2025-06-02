using BranchPromotion.Domain.Enums;

namespace BranchPromotion.Domain.Entities
{
    public class BranchPromotionVariant
    {
        public int Id { get; set; }

        public int VariantId { get; set; }

        public string VariantCode { get; set; }
        
        public int ProductId { get; set; }
        
        public string ProductName { get; set; }
        
        public MainCategories MainCategory { get; set; }
        
        public BranchTypes BranchType { get; set; }
        
        public int? BranchId { get; set; }
        
        public int? SenderBranchId { get; set; }
        
        public decimal MinimumPrice { get; set; }
        
        public decimal MaximumPrice { get; set; }
        
        public ushort Sequence { get; set; }
        
        public bool IsActive { get; set; }
        
        public int CreatedBy { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        public int ModifiedBy { get; set; }
        
        public DateTime ModifiedOn { get; set; }
    }
} 
