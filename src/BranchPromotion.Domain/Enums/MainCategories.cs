namespace BranchPromotion.Domain.Enums
{
    [Flags]
    public enum MainCategories : byte
    {
        None = 0,
        Flower = 1,        // Çiçek - 216
        BonnyFood = 2,    // Yenilebilir Çiçek - 242
        Gift = 4          // Hediye - 255
    }
} 
