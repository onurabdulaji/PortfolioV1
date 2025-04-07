using MediatR;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Features.MediatR.Hero.CreateHero.Commands;

public class CreateHeroCommand : IRequest
{
    public CreateHeroDto CreateHeroDto { get; set; }
}
