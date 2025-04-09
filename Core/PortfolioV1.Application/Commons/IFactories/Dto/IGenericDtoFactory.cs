namespace PortfolioV1.Application.Commons.IFactories.Dto;

public interface IGenericDtoFactory<TDto , TEntity>
{
    TEntity CreateEntity(TDto dto);
    TDto CreateDto(TEntity entity);
}
