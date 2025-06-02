using BranchPromotion.Domain.Entities.Bars;

namespace BranchPromotion.Domain.Repositories.Bars;

public interface IBarRepository
{
    Task<Bar> Get(int id);
    Task<(int, List<Bar>)> GetBars();
    Task Create(Bar bar);
}
