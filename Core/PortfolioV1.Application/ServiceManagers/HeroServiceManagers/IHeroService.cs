using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.ServiceManagers.HeroServiceManagers;

public interface IHeroService
{
    // Write operations
    Task CreateHeroAsync(CreateHeroDto createHeroDto, CancellationToken cancellationToken = default);
    Task<UpdateHeroDto> UpdateHeroAsync(UpdateHeroDto updateHeroDto, CancellationToken cancellationToken = default);
    Task<bool> DeleteHeroAsync(string id, CancellationToken cancellationToken = default);
    Task<DeleteHeroesRangeResponseDto> DeleteHeroRangeAsync(DeleteHeroesRangeRequestDto requestDto, CancellationToken cancellationToken = default);

    // Read operations
    Task<IList<HeroDto>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<GetHeroByIdDto?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
}
