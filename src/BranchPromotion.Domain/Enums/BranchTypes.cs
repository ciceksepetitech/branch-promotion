namespace BranchPromotion.Domain.Enums
{
    [Flags]
    public enum BranchTypes : byte
    {
        None = 0,
        Agency = 1, 
        Seller = 2,  
        Boutique = 4
    }
} 
