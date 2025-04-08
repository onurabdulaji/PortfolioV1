using PortfolioV1.Domain.Entities;
using PortfolioV1.DTO.Configuration;

namespace PortfolioV1.DTO.DTOs.HeroDtos;

public class DeleteHeroDto : BaseDTO<DeleteHeroDto, Hero>
{
    public string? Id { get; set; }
    public string? Message { get; set; }
}