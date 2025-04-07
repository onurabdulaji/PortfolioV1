using Microsoft.EntityFrameworkCore;
using PortfolioV1.Domain.Entities;
using PortfolioV1.Domain.IRepositories.IAbstracts.IHeroRepositories;
using PortfolioV1.Persistence.Context.Data;
using PortfolioV1.Persistence.Repositories.Generics;

namespace PortfolioV1.Persistence.Repositories.Concretes.HeroRepositories;

public class HeroReadRepository : GenericReadRepository<Hero>, IHeroReadRepository
{
    public HeroReadRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IList<Hero>> GetAllHeroListAsync(bool trackingChanges = false, CancellationToken cancellationToken = default)
    {
        IQueryable<Hero> query = Table;

        if(!trackingChanges) query = query.AsNoTracking();

        return await query.ToListAsync(cancellationToken);

    }

    public async Task<Hero> GetHeroByIdAsync(string id, bool trackingChanges = false, CancellationToken cancellationToken = default)
    {
        IQueryable<Hero> query = Table;

        if (!trackingChanges) query = query.AsNoTracking();

        return await query.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
