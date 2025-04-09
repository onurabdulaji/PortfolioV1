using PortfolioV1.Application.Commons.IFactories.HeroDtoTestting;
using PortfolioV1.Application.IManagements.HeroManagementsServices;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.ServiceManagers.HeroServiceManagers;

public class HeroService : IHeroService
{
    private readonly IHeroManagementService _heroManagementService;
    private readonly IHeroDtoFactory _heroDtoFactory;

    public HeroService(IHeroManagementService heroManagementService, IHeroDtoFactory heroDtoFactory)
    {
        _heroManagementService = heroManagementService;
        _heroDtoFactory = heroDtoFactory;
    }

    public async Task CreateHeroAsync(CreateHeroDto createHeroDto, CancellationToken cancellationToken = default)
    {
        // Create Hero from DTO

        if (createHeroDto is null)
            throw new ArgumentNullException(nameof(createHeroDto));

        var hero = _heroDtoFactory.CreateEntity(createHeroDto);

        await _heroManagementService.CreateHeroAsync(hero);

    }

    public async Task<bool> DeleteHeroAsync(string id, CancellationToken cancellationToken = default)
    {
        var hero = await _heroManagementService.GetByIdAsync(id, cancellationToken);

        if (hero.Id is null)
            throw new ArgumentNullException(nameof(hero));

        await _heroManagementService.DeleteHeroAsync(id);

        return true;
    }

    public async Task<DeleteHeroesRangeResponseDto> DeleteHeroRangeAsync(DeleteHeroesRangeRequestDto requestDto, CancellationToken cancellationToken = default)
    {
        var heroes = await _heroManagementService.TGetByIdsAsync(requestDto.Ids, cancellationToken);

        if (heroes.Count == 0)
            throw new ArgumentNullException(nameof(heroes), "No heroes found with the provided IDs.");

        var deletedIds = new List<string>();

        foreach (var hero in heroes)
        {
            await _heroManagementService.DeleteHeroAsync(hero.Id);
            deletedIds.Add(hero.Id);
        }

        var responseDto = _heroDtoFactory.GetDeleteHeroesRangeResponseDto(deletedIds, requestDto.Message);

        return responseDto;
    }

    public Task<IList<HeroDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<GetHeroByIdDto?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<UpdateHeroDto> UpdateHeroAsync(UpdateHeroDto updateHeroDto, CancellationToken cancellationToken = default)
    {
        // Mevcut Hero'yu ID'ye göre al
        var existingHero = await _heroManagementService.GetByIdAsync(updateHeroDto.Id, cancellationToken);

        if (existingHero == null)
            throw new ArgumentNullException(nameof(existingHero), "Hero not found.");

        // DTO'dan Hero entity'sine dönüşüm
        var hero = _heroDtoFactory.CreateEntity(updateHeroDto);

        // Hero'yu güncelle
        await _heroManagementService.UpdateHeroAsync(hero);

        // Güncellenen Hero'yu DTO'ya dönüştür
        return _heroDtoFactory.CreateUpdateDto(hero);

    }
}
