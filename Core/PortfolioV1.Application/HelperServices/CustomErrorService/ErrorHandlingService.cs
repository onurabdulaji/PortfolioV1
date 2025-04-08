
namespace PortfolioV1.Application.HelperServices.CustomErrorService;

public class ErrorHandlingService : IErrorHandlingService
{
    public void ThrowIfNull<T>(T item, string itemName)
    {
        if ( item == null)
        {
            throw new ArgumentNullException(itemName, $"{itemName} not found.");
        }
    }

    public async Task ThrowIfNullAsync<T>(T item, string itemName)
    {
        if (item == null)
        {
            await Task.CompletedTask;
            throw new KeyNotFoundException($"{itemName} not found.");
        }
    }
}
