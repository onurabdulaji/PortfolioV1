namespace PortfolioV1.Application.HelperServices.CustomErrorService;

public interface IErrorHandlingService
{
    void ThrowIfNull<T>(T item, string itemName);
    Task ThrowIfNullAsync<T>(T item, string itemName);
}
