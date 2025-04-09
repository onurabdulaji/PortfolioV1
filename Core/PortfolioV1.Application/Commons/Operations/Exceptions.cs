namespace PortfolioV1.Application.Commons.Operations;

public class DtoNullException : Exception
{
    public DtoNullException(string param, string message)
        : base($"{param}: {message}")
    {
    }
}
