using PortfolioV1.Domain.Entities;
using PortfolioV1.Domain.IRepositories.IAbstracts.IHeroRepositories;
using PortfolioV1.Persistence.Context.Data;
using PortfolioV1.Persistence.Repositories.Generics;

namespace PortfolioV1.Persistence.Repositories.Concretes.HeroRepositories;

public class HeroWriteRepository : GenericWriteRepository<Hero>, IHeroWriteRepository
{
    public HeroWriteRepository(AppDbContext context) : base(context)
    {
    }

    public async Task CreateHero(Hero createHero)
    {
        await _context.Heroes.AddAsync(createHero);
        await _context.SaveChangesAsync();
    }
}
