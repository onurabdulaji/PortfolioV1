using PortfolioV1.Domain.Entities;
using PortfolioV1.DTO.Configuration;

namespace PortfolioV1.DTO.DTOs.HeroDtos;

public class DeleteHeroesRangeResponseDto : BaseDTO<DeleteHeroesRangeResponseDto,Hero>
{
    public IList<string> DeletedIds { get; set; } 
    public string Message { get; set; }
}
