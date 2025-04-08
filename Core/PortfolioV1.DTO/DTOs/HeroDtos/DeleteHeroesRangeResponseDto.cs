using PortfolioV1.Domain.Entities;
using PortfolioV1.DTO.Configuration;

namespace PortfolioV1.DTO.DTOs.HeroDtos;

public class DeleteHeroesRangeResponseDto : BaseDTO<DeleteHeroesRangeResponseDto,Hero>
{
    public IList<string> DeletedIds { get; set; } = new List<string>();
    public string Message { get; set; } = string.Empty;
}
