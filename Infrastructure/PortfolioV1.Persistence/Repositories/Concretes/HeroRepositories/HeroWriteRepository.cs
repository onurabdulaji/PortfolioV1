using Microsoft.EntityFrameworkCore;
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

    public async Task DeleteHeroRange(IList<string> ids)
    {
        var heroes = await _context.Heroes.Where(x => ids.Contains(x.Id)).ToListAsync();
        if (heroes.Count == 0) throw new InvalidOperationException($"No heroes found with the provided ids: {string.Join(", ", ids)}.");
        _context.Heroes.RemoveRange(heroes);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHero(string id)
    {
        var hero = await _context.Heroes.FindAsync(id) ?? throw new InvalidOperationException($"Hero with id {id} not found.");
        _context.Heroes.Remove(hero);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateHero(Hero updateHero)
    {
        var hero = await _context.Heroes.FindAsync(updateHero.Id);
        if (hero == null) throw new InvalidOperationException($"Hero with id {updateHero.Id} not found.");

        _context.Entry(hero).CurrentValues.SetValues(updateHero);
        _context.Entry(hero).Entity.UpdatedDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }

    public async Task ChangeStatus(string id)
    {
        var hero = await _context.Heroes.FindAsync(id);

        if (hero == null) throw new InvalidOperationException($"Hero with id {id} not found.");

        hero.Status = !hero.Status;
        if (hero.Status == true)
        {
            hero.UpdatedDate = DateTime.UtcNow;
        }
        else
        {
            hero.DeletedDate = DateTime.UtcNow;
        }

        _context.Heroes.Update(hero);
        await _context.SaveChangesAsync();
    }
    
}
