using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Commons.IFactories.Dto;

public interface IDtoFactory
{
    CreateHeroDto CreateCreateHeroDto(string name, string description, string power);
    DeleteHeroesRangeRequestDto CreateDeleteHeroesRangeRequestDto(IList<string> ids, string message);

}
