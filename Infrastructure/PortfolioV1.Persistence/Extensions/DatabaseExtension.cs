using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortfolioV1.Persistence.Context.Data;

namespace PortfolioV1.Persistence.Extensions;

public static class DatabaseExtension
{
    public static void AddDatabaseExtension(this IServiceCollection services , IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("PortfolioV1DatabaseConnection"));
        });
    }
}
