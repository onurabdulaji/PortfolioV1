using PortfolioV1.Domain.Entities;
using PortfolioV1.Domain.IRepositories.IGenerics;

namespace PortfolioV1.Domain.IRepositories.IAbstracts.IHeroRepositories;

public interface IHeroWriteRepository : IGenericWriteRepository<Hero>
{
    Task CreateHero(Hero createHero);
}
