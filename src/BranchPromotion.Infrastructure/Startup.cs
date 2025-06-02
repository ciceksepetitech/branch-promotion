using BranchPromotion.Domain.Repositories;
using BranchPromotion.Infrastructure.Repositories;
using BranchPromotion.Infrastructure.Repositories.Abstracts;
using BranchPromotion.Infrastructure.Repositories.Concretes;
using Cosmos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace BranchPromotion.Infrastructure;

public static class Startup
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(LinqToSqlRepository<>));

        //MySql Connection
        services.AddScoped<IConnectionProvider>(_ => new ConnectionProvider(() =>
            new MySqlConnection(configuration.GetConnectionString("DatabaseConnection"))));
        
        services.AddSingleton(sp =>
            ServerVersion.AutoDetect(configuration.GetConnectionString("DatabaseConnection"))
        );

        services.AddDbContext<ApplicationDbContext>(
            (sp, dbContextOptions) => dbContextOptions
                .UseMySql(configuration.GetConnectionString("DatabaseConnection"),
                    sp.GetRequiredService<ServerVersion>())
        );

        services.AddScoped<IBranchPromotionVariantRepository, BranchPromotionVariantRepository>();
    }
}
