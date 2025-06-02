namespace BranchPromotion.Api.Models.Bars;

public record GetBarsRequest
{
    public int Page { get; init; }
    public int Size { get; init; }
}
