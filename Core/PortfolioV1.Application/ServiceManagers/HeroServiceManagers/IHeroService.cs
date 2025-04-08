using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.ServiceManagers.HeroServiceManagers;

public interface IHeroService
{
    // Write
    Task CreateHeroAsync(CreateHeroDto createHeroDto , CancellationToken cancellationToken= default);
    Task<UpdateHeroDto> UpdateHeroAsync(UpdateHeroDto updateHeroDto , CancellationToken cancellationToken= default);
    // Read
    Task<IList<HeroDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<GetHeroByIdDto?> GetByIdAsync(string id, CancellationToken cancellationToken = default);

}
