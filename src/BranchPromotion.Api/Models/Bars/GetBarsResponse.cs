namespace BranchPromotion.Api.Models.Bars;

public class GetBarsResponse
{
    public int TotalCount { get; set; }
    public List<GetBarResponse> Bars { get; set; }
}
