using PortfolioV1.Domain.Entities;
using PortfolioV1.Domain.IRepositories.IGenerics;

namespace PortfolioV1.Domain.IRepositories.IAbstracts.IHeroRepositories;

public interface IHeroReadRepository : IGenericReadRepository<Hero>
{
    Task<IList<Hero>> GetAllHeroListAsync(bool trackingChanges = false , CancellationToken cancellationToken = default);
    Task<Hero> GetHeroByIdAsync(string id, bool trackingChanges = false, CancellationToken cancellationToken = default);
}
