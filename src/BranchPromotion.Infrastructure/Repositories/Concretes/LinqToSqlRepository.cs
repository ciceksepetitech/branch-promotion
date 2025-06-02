using Cosmos.Data.EntityFramework;

namespace BranchPromotion.Infrastructure.Repositories.Concretes;

public class LinqToSqlRepository<T> : RepositoryBase<T> where T : class
{
    public LinqToSqlRepository(BarDbContext dbContext) : base(dbContext)
    {
    }
}
