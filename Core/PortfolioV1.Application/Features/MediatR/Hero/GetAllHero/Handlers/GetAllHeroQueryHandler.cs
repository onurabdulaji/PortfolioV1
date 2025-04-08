using MediatR;
using PortfolioV1.Application.Features.MediatR.Hero.GetAllHero.Queries;
using PortfolioV1.Application.ServiceManagers.HeroServiceManagers;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Features.MediatR.Hero.GetAllHero.Handlers;

public class GetAllHeroQueryHandler : IRequestHandler<GetAllHeroQuery, IList<HeroDto>>
{
    private readonly IHeroService _heroService;

    public GetAllHeroQueryHandler(IHeroService heroService)
    {
        _heroService = heroService;
    }

    public async Task<IList<HeroDto>> Handle(GetAllHeroQuery request, CancellationToken cancellationToken)
    {
        var result = await _heroService.GetAllAsync(cancellationToken);
        return result;
    }
}
