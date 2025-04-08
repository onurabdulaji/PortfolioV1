using MediatR;
using PortfolioV1.Application.Features.MediatR.Hero.UpdateHero.Commands;
using PortfolioV1.Application.ServiceManagers.HeroServiceManagers;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Features.MediatR.Hero.UpdateHero.Handlers;

public class UpdateHeroCommandHandler : IRequestHandler<UpdateHeroCommand, UpdateHeroDto>
{
    private readonly IHeroService _heroService;

    public UpdateHeroCommandHandler(IHeroService heroService)
    {
        _heroService = heroService;
    }

    public async Task<UpdateHeroDto> Handle(UpdateHeroCommand request, CancellationToken cancellationToken)
    {
        var updatedHero = await _heroService.UpdateHeroAsync(request.UpdateHeroDto, cancellationToken);
        return updatedHero;
    }
}
