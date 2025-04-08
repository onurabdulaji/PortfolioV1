using MediatR;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Features.MediatR.Hero.GetHeroById.Queries;

public class GetHeroByIdQuery : IRequest<GetHeroByIdDto>
{
    public string? Id { get; set; }
    public GetHeroByIdQuery( string id)
    {
        Id = id;
    }
}
