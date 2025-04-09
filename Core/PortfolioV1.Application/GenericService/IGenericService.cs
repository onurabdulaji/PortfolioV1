namespace PortfolioV1.Application.GenericService;

public interface IGenericService<TDto, TEntity>
{
    Task<TDto> CreateAsync(TDto dto, CancellationToken cancellationToken = default);
    Task<TDto> UpdateAsync(TDto dto, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default);
    Task<TDto> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IList<TDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> DeleteRangeAsync(IList<string> ids, CancellationToken cancellationToken = default);  // Yeni metod

}
