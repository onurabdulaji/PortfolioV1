using PortfolioV1.Domain.Entities;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Commons.IFactories.Dto;

public interface IDtoFactory
{
    DeleteHeroesRangeRequestDto CreateDeleteHeroesRangeRequestDto(IList<string> ids, string message);

    Hero CreateHeroFromDto(CreateHeroDto createHeroDto);

}
