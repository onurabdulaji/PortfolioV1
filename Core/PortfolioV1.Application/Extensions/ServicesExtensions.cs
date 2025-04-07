using Microsoft.Extensions.DependencyInjection;
using PortfolioV1.Application.ServiceManagers.HeroServiceManagers;

namespace PortfolioV1.Application.Extensions;

public static class ServicesExtensions
{
    public static void AddServicesExtension(this IServiceCollection services)
    {
        services.AddScoped<IHeroService, HeroService>();
    }
}

