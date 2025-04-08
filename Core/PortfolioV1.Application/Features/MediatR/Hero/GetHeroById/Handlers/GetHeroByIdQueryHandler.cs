using MediatR;
using PortfolioV1.Application.Features.MediatR.Hero.GetHeroById.Queries;
using PortfolioV1.Application.ServiceManagers.HeroServiceManagers;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Features.MediatR.Hero.GetHeroById.Handlers;

public class GetHeroByIdQueryHandler : IRequestHandler<GetHeroByIdQuery, GetHeroByIdDto>
{
    private readonly IHeroService _heroService;

    public GetHeroByIdQueryHandler(IHeroService heroService)
    {
        _heroService = heroService;
    }

    public async Task<GetHeroByIdDto> Handle(GetHeroByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _heroService.GetByIdAsync(request.Id, cancellationToken);
        return result;
    }
}
