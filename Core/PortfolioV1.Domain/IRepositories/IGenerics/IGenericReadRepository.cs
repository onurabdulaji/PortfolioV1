using Microsoft.EntityFrameworkCore.Query;
using PortfolioV1.Domain.Entities.IBase;
using System.Linq.Expressions;

namespace PortfolioV1.Domain.IRepositories.IGenerics;

public interface IGenericReadRepository<T> where T : class , IBaseEntity , new()
{
    Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
          Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
          bool enableTracking = false);
    Task<T> GetAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false);
    IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false);

    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

    Task<T> FindAsync(Expression<Func<T, bool>> predicate);
}
