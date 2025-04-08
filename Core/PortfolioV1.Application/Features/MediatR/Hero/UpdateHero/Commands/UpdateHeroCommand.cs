using MediatR;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Features.MediatR.Hero.UpdateHero.Commands;

public class UpdateHeroCommand : IRequest<UpdateHeroDto>
{
    public UpdateHeroDto UpdateHeroDto { get; init; }
    public UpdateHeroCommand(UpdateHeroDto updateHeroDto)
    {
        UpdateHeroDto = updateHeroDto;
    }
}
