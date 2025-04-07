namespace PortfolioV1.Application.Validations;

public interface IValidatorService
{
    Task ValidateAsync<T>(T dto);
}
