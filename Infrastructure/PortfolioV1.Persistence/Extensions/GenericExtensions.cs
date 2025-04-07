using Microsoft.Extensions.DependencyInjection;
using PortfolioV1.Domain.IRepositories.IGenerics;
using PortfolioV1.Persistence.Repositories.Generics;

namespace PortfolioV1.Persistence.Extensions;

public static class GenericExtensions
{
    public static void AddGenericPatternExtension(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericReadRepository<>), typeof(GenericReadRepository<>));
        services.AddScoped(typeof(IGenericWriteRepository<>), typeof(GenericWriteRepository<>));
    }
}
