namespace PortfolioV1.Application.Commons.IFactories.Dto;

public interface IDtoFactory
{
    // Write 
    TEntity CreateEntityFromDto<TEntity, TDto>(TDto dto);
    TDto CreateDtoFromEntity<TEntity, TDto>(TEntity entity);

    // Read

}
