using BranchPromotion.Domain.Enums;

namespace BranchPromotion.Domain.Entities.Bars;

public class Bar
{
    public int Id { get; set; }
    public string Name { get; set; }
    public BarType Type { get; set; }
}
