using PortfolioV1.Domain.Entities;
using PortfolioV1.DTO.Configuration;

namespace PortfolioV1.DTO.DTOs.HeroDtos;

public class GetHeroByIdDto : BaseDTO<GetHeroByIdDto , Hero>
{
    public string? Id { get; set; }
    public string? Title { get; set; }
    public string? SubTitle { get; set; }
    public string? BackgroundImageUrl { get; set; }
}
