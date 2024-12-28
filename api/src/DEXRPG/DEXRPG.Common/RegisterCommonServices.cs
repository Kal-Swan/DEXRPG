using DEXRPG.Common.Database;
using DEXRPG.Common.Database.InMemoryDatabase;
using Microsoft.Extensions.DependencyInjection;

namespace DEXRPG.Common;

public static class RegisterCommonServices
{
    public static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(InMemoryRepository<>));    
        return services;
    }
}