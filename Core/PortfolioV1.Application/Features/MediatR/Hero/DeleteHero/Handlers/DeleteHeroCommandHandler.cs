using MediatR;
using PortfolioV1.Application.Features.MediatR.Hero.DeleteHero.Commands;
using PortfolioV1.Application.ServiceManagers.HeroServiceManagers;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Features.MediatR.Hero.DeleteHero.Handlers;

public class DeleteHeroCommandHandler : IRequestHandler<DeleteHeroCommand, DeleteHeroDtoResponse>
{
    private readonly IHeroService _heroService;

    public DeleteHeroCommandHandler(IHeroService heroService)
    {
        _heroService = heroService;
    }

    public async Task<DeleteHeroDtoResponse> Handle(DeleteHeroCommand request, CancellationToken cancellationToken)
    {
        await _heroService.DeleteHeroAsync(request.Id, cancellationToken);

        return new DeleteHeroDtoResponse
        {
            Id = request.Id,
            Message = "Hero deleted successfully."
        };
    }
}
