using MediatR;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Features.MediatR.Hero.GetAllHero.Queries;

public class GetAllHeroQuery : IRequest<IList<HeroDto>>
{
}
