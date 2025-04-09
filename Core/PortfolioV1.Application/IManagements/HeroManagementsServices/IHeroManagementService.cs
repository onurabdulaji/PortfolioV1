using PortfolioV1.Domain.Entities;

namespace PortfolioV1.Application.IManagements.HeroManagementsServices;

public interface IHeroManagementService
{
    // Write
    Task CreateHeroAsync(Hero createHero);
    Task UpdateHeroAsync(Hero updateHero);
    Task DeleteHeroAsync(string id);
    Task DeleteHeroRangeAsync(IList<string> heroesIds);

    // Read
    Task<IList<Hero>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Hero?> GetByIdAsync(string id, CancellationToken cancellationToken = default);


    /// 

    Task<IList<Hero>> TGetByIdsAsync(IList<string> ids, CancellationToken cancellationToken = default);
    Task TDeleteRangeAsync(IList<Hero> heroes, CancellationToken cancellationToken = default);


}
