using PortfolioV1.Domain.Entities;
using PortfolioV1.Domain.IRepositories.IGenerics;

namespace PortfolioV1.Domain.IRepositories.IAbstracts.IHeroRepositories;

public interface IHeroWriteRepository : IGenericWriteRepository<Hero>
{
    Task CreateHero(Hero createHero);
    Task UpdateHero(Hero updateHero);
    Task DeleteHero(string id);
    Task DeleteHeroRange(IList<string> ids);
    Task ChangeStatus(string id);
    Task DeleteRangeAsync(IList<Hero> heroes, CancellationToken cancellationToken = default);

}
