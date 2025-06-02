using System.Data;

namespace BranchPromotion.Infrastructure.Repositories.Abstracts;

public interface IConnectionProvider
{
    IDbConnection Connection { get; }
}
