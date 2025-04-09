using PortfolioV1.Domain.Entities;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Commons.IFactories.HeroDtoTestting;

public interface IHeroDtoFactory
{
    Hero CreateEntity(CreateHeroDto dto);
    Hero CreateEntity(UpdateHeroDto dto);
    HeroDto CreateDto(Hero entity);
    UpdateHeroDto CreateUpdateDto(Hero entity);
    GetHeroByIdDto CreateGetDto(Hero entity);

    DeleteHeroesRangeRequestDto CreateDeleteHeroesRangeRequestDto(IList<string> ids, string message);

    DeleteHeroesRangeResponseDto GetDeleteHeroesRangeResponseDto(IList<string> ids, string message);
}
