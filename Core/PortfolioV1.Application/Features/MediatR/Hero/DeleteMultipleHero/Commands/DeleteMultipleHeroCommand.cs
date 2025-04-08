using MediatR;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Features.MediatR.Hero.DeleteMultipleHero.Commands;

public class DeleteMultipleHeroCommand : IRequest<DeleteHeroesRangeResponseDto>
{
    public IList<string> Ids { get; set; }
    public string Message { get; set; }
}
