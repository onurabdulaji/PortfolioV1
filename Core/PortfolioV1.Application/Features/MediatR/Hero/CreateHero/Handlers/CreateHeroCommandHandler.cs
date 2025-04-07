using MediatR;
using PortfolioV1.Application.Features.MediatR.Hero.CreateHero.Commands;
using PortfolioV1.Application.ServiceManagers.HeroServiceManagers;

namespace PortfolioV1.Application.Features.MediatR.Hero.CreateHero.Handlers;

public class CreateHeroCommandHandler : IRequestHandler<CreateHeroCommand>
{
    private readonly IHeroService _heroService;

    public CreateHeroCommandHandler(IHeroService heroService)
    {
        _heroService = heroService;
    }

    public async Task Handle(CreateHeroCommand request, CancellationToken cancellationToken)
    {
        await _heroService.CreateHeroAsync(request.CreateHeroDto, cancellationToken);
    }
}
