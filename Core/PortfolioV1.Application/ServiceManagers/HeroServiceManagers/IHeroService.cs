using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.ServiceManagers.HeroServiceManagers;

public interface IHeroService
{
   Task CreateHeroAsync(CreateHeroDto createHeroDto , CancellationToken cancellationToken= default);
    Task<IList<HeroDto>> GetAllAsync(CancellationToken cancellationToken = default);

}
