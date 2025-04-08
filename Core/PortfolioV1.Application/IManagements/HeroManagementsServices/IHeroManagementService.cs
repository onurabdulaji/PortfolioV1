using PortfolioV1.Domain.Entities;

namespace PortfolioV1.Application.IManagements.HeroManagementsServices;

public interface IHeroManagementService
{
    // Write
    Task CreateHeroAsync(Hero createHero);
    Task UpdateHeroAsync(Hero updateHero);
    //Task DeleteHeroAsync(string id);

    // Read
    Task<IList<Hero>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Hero?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
}
