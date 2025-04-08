using Microsoft.Extensions.DependencyInjection;
using PortfolioV1.Application.HelperServices.CustomErrorService;

namespace PortfolioV1.Application.Extensions;

public static class ErrorHandlingServiceExtension
{
    public static void AddErrorHandlingServiceExtensions(this IServiceCollection services)
    {
        services.AddScoped<IErrorHandlingService, ErrorHandlingService>();
    }
}
