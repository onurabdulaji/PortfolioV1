using PortfolioV1.Domain.Entities.IBase;

namespace PortfolioV1.Domain.IRepositories.IGenerics;

public interface IGenericWriteRepository<T> where T : class , IBaseEntity , new()
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IList<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}
