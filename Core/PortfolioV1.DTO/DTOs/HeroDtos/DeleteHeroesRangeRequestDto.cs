using PortfolioV1.Domain.Entities;
using PortfolioV1.DTO.Configuration;

namespace PortfolioV1.DTO.DTOs.HeroDtos;

public class DeleteHeroesRangeRequestDto : BaseDTO<DeleteHeroesRangeRequestDto, Hero>
{
    public IList<string> Ids { get; set; }
    public string Message { get; set; }
}
