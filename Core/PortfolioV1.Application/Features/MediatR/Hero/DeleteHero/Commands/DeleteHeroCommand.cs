using MediatR;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Features.MediatR.Hero.DeleteHero.Commands;

public class DeleteHeroCommand : IRequest<DeleteHeroDtoResponse>
{
    public string Id { get; set; }
    public string Message { get; set; }
}
