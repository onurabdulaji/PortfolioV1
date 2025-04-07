using PortfolioV1.Domain.Entities.IBase;
using PortfolioV1.Domain.IRepositories.IGenerics;

namespace PortfolioV1.Domain.IRepositories.IUnitOfWorks;

public interface IUnitOfWork : IDisposable , IAsyncDisposable
{
    IGenericReadRepository<T> GetGenericReadRepository<T>() where T : class, IBaseEntity, new();
    IGenericWriteRepository<T> GetGenericWriteRepository<T>() where T : class, IBaseEntity, new();
    Task<int> SaveAsync();
}
