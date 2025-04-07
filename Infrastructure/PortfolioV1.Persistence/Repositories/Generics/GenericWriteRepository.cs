using Microsoft.EntityFrameworkCore;
using PortfolioV1.Domain.Entities.IBase;
using PortfolioV1.Domain.IRepositories.IGenerics;
using PortfolioV1.Persistence.Context.Data;

namespace PortfolioV1.Persistence.Repositories.Generics;

public class GenericWriteRepository<T> : IGenericWriteRepository<T> where T : class, IBaseEntity, new()
{
    protected readonly AppDbContext _context;
    public GenericWriteRepository(AppDbContext context)
    {
        _context = context;
    }
    protected DbSet<T> Table { get => _context.Set<T>(); }

    public async Task AddAsync(T entity)
    {
        await Table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task AddRangeAsync(IList<T> entities)
    {
        await Table.AddRangeAsync(entities);
        await _context.SaveChangesAsync();
    }

    public async Task<T> DeleteAsync(T entity)
    {
        Table.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<T> UpdateAsync(T entity)
    {
        Table.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}
