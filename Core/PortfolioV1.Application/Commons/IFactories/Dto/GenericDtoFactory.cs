using Mapster;
using PortfolioV1.Application.Commons.Operations;

namespace PortfolioV1.Application.Commons.IFactories.Dto;

public class GenericDtoFactory<TDto, TEntity> : IGenericDtoFactory<TDto, TEntity>
{
    public TDto CreateDto(TEntity entity)
    {
        if (entity == null)
            throw new DtoNullException(typeof(TEntity).Name, "Entity cannot be null");

        return entity.Adapt<TDto>();
    }

    public TEntity CreateEntity(TDto dto)
    {
        if(dto is null ) throw new DtoNullException(typeof(TDto).Name , "Dto cannot be null");

        return dto.Adapt<TEntity>();
    }
}
