using Microsoft.Extensions.DependencyInjection;
using PortfolioV1.Domain.IRepositories.IAbstracts.IHeroRepositories;
using PortfolioV1.Persistence.Repositories.Concretes.HeroRepositories;

namespace PortfolioV1.Persistence.Extensions;

public static class RepositoriesExtensions
{
    public static void AddRepositoriesExtension(this IServiceCollection services)
    {
        services.AddScoped<IHeroReadRepository, HeroReadRepository>();
        services.AddScoped<IHeroWriteRepository, HeroWriteRepository>();
    }
}
