using Mapster;
using PortfolioV1.Application.HelperServices.CustomErrorService;
using PortfolioV1.Application.IManagements.HeroManagementsServices;
using PortfolioV1.Application.Validations;
using PortfolioV1.Domain.Entities;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.ServiceManagers.HeroServiceManagers;

public class HeroService : IHeroService
{
    private readonly IHeroManagementService _heroManagementService;
    private readonly IValidatorService _validatorService;
    private readonly IErrorHandlingService _errorHandlingService;

    public HeroService(IHeroManagementService heroManagementService, IValidatorService validatorService, IErrorHandlingService errorHandlingService)
    {
        _heroManagementService = heroManagementService;
        _validatorService = validatorService;
        _errorHandlingService = errorHandlingService;
    }

    // Write

    public async Task CreateHeroAsync(CreateHeroDto createHeroDto, CancellationToken cancellationToken = default)
    {
        await _validatorService.ValidateAsync(createHeroDto);

        var hero = createHeroDto.Adapt<Hero>();

        await _heroManagementService.CreateHeroAsync(hero);
    }

    public async Task<UpdateHeroDto> UpdateHeroAsync(UpdateHeroDto updateHeroDto, CancellationToken cancellationToken = default)
    {
        await _validatorService.ValidateAsync(updateHeroDto);

        var existingHero = await _heroManagementService.GetByIdAsync(updateHeroDto.Id, cancellationToken);

        await _errorHandlingService.ThrowIfNullAsync(existingHero, "Hero not found");

        updateHeroDto.Adapt(existingHero);

        await _heroManagementService.UpdateHeroAsync(existingHero);

        return existingHero.Adapt<UpdateHeroDto>();
    }

    // Read

    public async Task<IList<HeroDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _heroManagementService.GetAllAsync(cancellationToken);

        return list.Adapt<IList<HeroDto>>();
    }

    public async Task<GetHeroByIdDto?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var heroId = await _heroManagementService.GetByIdAsync(id, cancellationToken);

        await _errorHandlingService.ThrowIfNullAsync(heroId, "Hero not found");

        return heroId?.Adapt<GetHeroByIdDto>();
    }


}
