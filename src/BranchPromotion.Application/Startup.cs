using Cosmos.Caching.Redis.Resilience;
using Cosmos.MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BranchPromotion.Application;

public static class Startup
{
    public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCosmosMediatR(typeof(Startup));

        services.AddCosmosRedisResilienceCache(configuration);
    }
}
