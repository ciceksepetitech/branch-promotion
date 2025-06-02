using Cosmos.Data;
using Dapper;
using BranchPromotion.Domain.Entities.Bars;
using BranchPromotion.Domain.Repositories.Bars;
using BranchPromotion.Infrastructure.Repositories.Abstracts;

namespace BranchPromotion.Infrastructure.Repositories.Bars;

public class BarRepository : IBarRepository
{
    private readonly IConnectionProvider _db;
    private readonly IRepository<Bar> _barRepository;

    public BarRepository(IConnectionProvider db,
        IRepository<Bar> barRepository)
    {
        _db = db;
        _barRepository = barRepository;
    }

    public Task<Bar> Get(int id)
    {
        return _db.Connection.QueryFirstAsync<Bar>("SELECT Name FROM Bar b WHERE id = @id", new { id });
    }

    public Task<(int, List<Bar>)> GetBars()
    {
        throw new NotImplementedException();
    }

    public async Task Create(Bar bar)
    {
        await _barRepository.InsertAsync(bar);
        await _barRepository.SaveAllAsync();
    }
}
