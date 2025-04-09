using Mapster;

namespace PortfolioV1.Application.Commons.IFactories.Dto;

public class DtoFactory : IDtoFactory
{
    // Entity'den DTO'ya dönüşüm
    public TDto CreateDtoFromEntity<TEntity, TDto>(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null");

        return entity.Adapt<TDto>();
    }

    // DTO'dan Entity'ye dönüşüm
    public TEntity CreateEntityFromDto<TEntity, TDto>(TDto dto)
    {
        if (dto == null)
            throw new ArgumentNullException(nameof(dto), "DTO cannot be null");

        return dto.Adapt<TEntity>();
    }

    //public Hero CreateHeroFromDto(CreateHeroDto createHeroDto)
    //{
    //    if (createHeroDto is null)
    //        throw new DtoNullException(nameof(createHeroDto), "This object is null please check it !");

    //    return createHeroDto.Adapt<Hero>();
    //}

    //public DeleteHeroesRangeRequestDto CreateDeleteHeroesRangeRequestDto(IList<string> ids, string message)
    //{
    //    return new DeleteHeroesRangeRequestDto
    //    {
    //        Ids = ids,
    //        Message = message
    //    };
    //}

}

