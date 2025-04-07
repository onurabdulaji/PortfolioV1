
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace PortfolioV1.Application.Validations;

public class ValidatorService : IValidatorService
{
    private readonly IServiceProvider _serviceProvider;

    public ValidatorService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task ValidateAsync<T>(T dto)
    {
        var validator = _serviceProvider.GetService<IValidator<T>>();
        if(validator == null) throw new InvalidOperationException($"Validator for type {typeof(T).Name} not found.");

        var result = await validator.ValidateAsync(dto);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ValidationException($"Validation failed: {string.Join(", ", errors)}");
        }
    }
}
