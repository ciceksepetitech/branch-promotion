using BranchPromotion.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BranchPromotion.Infrastructure.Repositories;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<BranchPromotionVariant> BranchPromotionVariant { get; set; }
}
