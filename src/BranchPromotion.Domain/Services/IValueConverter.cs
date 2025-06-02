using BranchPromotion.Domain.Enums;

namespace BranchPromotion.Domain.Services;

public interface IValueConverter
{
    MainCategories MapMainCategories(int[] categories);

    BranchTypes MapBranchTypes(int[] types);
}
