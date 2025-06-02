using Cosmos.Data;
using Cosmos.HttpBuilders;
using Cosmos.Util;
using BranchPromotion.Domain.Repositories.Bars;
using BranchPromotion.Domain.Services.Bazs;
using BranchPromotion.Infrastructure.Repositories;
using BranchPromotion.Infrastructure.Repositories.Abstracts;
using BranchPromotion.Infrastructure.Repositories.Bars;
using BranchPromotion.Infrastructure.Repositories.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Refit;

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

        services.AddDbContext<BarDbContext>(
            (sp, dbContextOptions) => dbContextOptions
                .UseMySql(configuration.GetConnectionString("DatabaseConnection"),
                    sp.GetRequiredService<ServerVersion>())
        );

        //MsSql Connection
        //services.AddScoped<IConnectionProvider>(_ => new ConnectionProvider(() =>
        //    new SqlConnection(configuration.GetConnectionString("DatabaseConnection"))));

        //services.AddDbContext<BarDbContext>(
        //    dbContextOptions => dbContextOptions
        //        .UseSqlServer(configuration.GetConnectionString("DatabaseConnection")));

        services.AddScoped<IBarRepository, BarRepository>();
        
        var bazServiceUrl = configuration.GetValue<string>("ServiceUrls:Baz");

        var refitSettings = new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer(JsonSerializerOptionsProvider.Options())
        };

        services.AddRefitClient<IBazService>(refitSettings).ConfigureInternalHttpClient(services, bazServiceUrl);
    }
}
