using BranchPromotion.Domain.Enums;
using BranchPromotion.Domain.Services;

namespace BranchPromotion.Application.Services;

public class ValueConverter : IValueConverter
{
    public MainCategories MapMainCategories(int[] categories)
    {
        var result = MainCategories.None;
        var mapping = new Dictionary<int, MainCategories>
        {
            { 216, MainCategories.Flower },
            { 242, MainCategories.BonnyFood },
            { 255, MainCategories.Gift }
        };

        foreach (var category in categories)
        {
            if (mapping.TryGetValue(category, out var mappedCategory)) 
                result |= mappedCategory;
        }

        return result;
    }

    public BranchTypes MapBranchTypes(int[] types)
    {
        var result = BranchTypes.None;
        var mapping = new Dictionary<int, BranchTypes>
        {
            { 1, BranchTypes.Agency },
            { 2, BranchTypes.Seller },
            { 3, BranchTypes.Boutique }
        };

        foreach (var type in types)
        {
            if (mapping.TryGetValue(type, out var mappedType)) 
                result |= mappedType;
        }

        return result;
    }
}
