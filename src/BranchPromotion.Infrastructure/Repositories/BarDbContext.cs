using Microsoft.EntityFrameworkCore;

namespace BranchPromotion.Infrastructure.Repositories;

public class BarDbContext : DbContext
{
    public BarDbContext(DbContextOptions<BarDbContext> options) : base(options)
    {
    }
}
