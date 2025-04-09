using PortfolioV1.Domain.Entities;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Commons.IFactories.HeroDtoTestting;

public class HeroDtoFactory : IHeroDtoFactory
{

    public HeroDto CreateDto(Hero entity)
    {
        // Hero entity'sini HeroDto'ya dönüştürür

        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        return new HeroDto
        {
            Title = entity.Title,
            SubTitle = entity.SubTitle,
            BackgroundImageUrl = entity.BackgroundImageUrl,
        };
    }

    public Hero CreateEntity(CreateHeroDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        // CreateHeroDto'yu Hero entity'sine dönüştürür

        return new Hero
        {
            Title = dto.Title,
            SubTitle = dto.SubTitle,
            BackgroundImageUrl = dto.BackgroundImageUrl,
        };
    }

    public Hero CreateEntity(UpdateHeroDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        return new Hero
        {
            Id = dto.Id,
            Title = dto.Title,
            SubTitle = dto.SubTitle,
            BackgroundImageUrl = dto.BackgroundImageUrl,
        };
    }

    public GetHeroByIdDto CreateGetDto(Hero entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        // Hero entity'sini GetHeroByIdDto'ya dönüştürür

        return new GetHeroByIdDto
        {
            Id = entity.Id,
            Title = entity.Title,
            SubTitle = entity.SubTitle,
            BackgroundImageUrl = entity.BackgroundImageUrl,
        };
    }

    public UpdateHeroDto CreateUpdateDto(Hero entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        // Hero entity'sini UpdateHeroDto'ya dönüştürür

        return new UpdateHeroDto
        {
            Id = entity.Id,
            Title = entity.Title,
            SubTitle = entity.SubTitle,
            BackgroundImageUrl = entity.BackgroundImageUrl,
        };

    }
}
