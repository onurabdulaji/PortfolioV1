using Microsoft.Extensions.DependencyInjection;
using PortfolioV1.Domain.IRepositories.IUnitOfWorks;
using PortfolioV1.Persistence.Repositories.UnitOfWorks;

namespace PortfolioV1.Persistence.Extensions;

public static class UoWExtensions
{
    public static void AddUnitOfWorkExtension(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
