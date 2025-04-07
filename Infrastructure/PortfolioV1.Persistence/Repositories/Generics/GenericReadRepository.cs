using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using PortfolioV1.Domain.Entities.IBase;
using PortfolioV1.Domain.IRepositories.IGenerics;
using PortfolioV1.Persistence.Context.Data;
using System.Linq.Expressions;

namespace PortfolioV1.Persistence.Repositories.Generics;

public class GenericReadRepository<T> : IGenericReadRepository<T> where T : class, IBaseEntity, new()
{
    protected readonly AppDbContext _context;

    public GenericReadRepository(AppDbContext context)
    {
        _context = context;
    }

    protected DbSet<T> Table { get => _context.Set<T>(); }

    public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);
        if (predicate is not null) queryable = queryable.Where(predicate);
        if (orderBy is not null)
            queryable = orderBy(queryable);

        return await queryable.ToListAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include is not null) queryable = include(queryable);

        return await queryable.FirstOrDefaultAsync(predicate);
    }
    public async Task<T> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return await Table.AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
    {
        IQueryable<T> queryable = Table;

        if (!enableTracking) queryable = queryable.AsNoTracking();

        return queryable.Where(predicate);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> queryable = Table;

        if (predicate is not null) queryable = queryable.Where(predicate);

        return await queryable.AsNoTracking().CountAsync();
    }
}
