using PortfolioV1.Domain.Entities;

namespace PortfolioV1.Application.IManagements.HeroManagementsServices;

public interface IHeroManagementService
{
    // Write
    Task CreateHeroAsync(Hero createHero);

    // Read
    Task<IList<Hero>> GetAllAsync(CancellationToken cancellationToken = default);
}
