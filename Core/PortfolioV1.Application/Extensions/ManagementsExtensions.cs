using Microsoft.Extensions.DependencyInjection;
using PortfolioV1.Application.IManagements.HeroManagementsServices;

namespace PortfolioV1.Application.Extensions;

public static class ManagementsExtensions
{
    public static void AddManagementsExtension(this IServiceCollection services)
    {
        services.AddScoped<IHeroManagementService, HeroManagementService>();
    }
}

