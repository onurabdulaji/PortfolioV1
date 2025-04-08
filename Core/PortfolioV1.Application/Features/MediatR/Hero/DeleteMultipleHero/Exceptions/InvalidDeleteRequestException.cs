namespace PortfolioV1.Application.Features.MediatR.Hero.DeleteMultipleHero.Exceptions;

public class InvalidDeleteRequestException : Exception
{
    public InvalidDeleteRequestException(string message) : base(message)
    {
    }
}
