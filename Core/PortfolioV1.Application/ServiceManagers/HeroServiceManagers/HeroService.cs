using Mapster;
using PortfolioV1.Application.Commons.IFactories.Dto;
using PortfolioV1.Application.GenericService;
using PortfolioV1.Application.HelperServices.CustomErrorService;
using PortfolioV1.Application.IManagements.HeroManagementsServices;
using PortfolioV1.Application.Validations;
using PortfolioV1.Domain.Entities;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.ServiceManagers.HeroServiceManagers;

public class HeroService : IGenericService<HeroDto, Hero>
{
    private readonly IGenericDtoFactory<HeroDto, Hero> _dtoFactory;
    private readonly IHeroManagementService _heroManagementService;
    private readonly IValidatorService _validatorService;
    private readonly IErrorHandlingService _errorHandlingService;

    public HeroService(
        IGenericDtoFactory<HeroDto, Hero> dtoFactory,
        IHeroManagementService heroManagementService,
        IValidatorService validatorService,
        IErrorHandlingService errorHandlingService)
    {
        _dtoFactory = dtoFactory;
        _heroManagementService = heroManagementService;
        _validatorService = validatorService;
        _errorHandlingService = errorHandlingService;
    }

    public async Task<HeroDto> CreateAsync(HeroDto dto, CancellationToken cancellationToken = default)
    {
        await _validatorService.ValidateAsync(dto);

        var entity = _dtoFactory.CreateEntity(dto);

        await _heroManagementService.CreateHeroAsync(entity);

        return _dtoFactory.CreateDto(entity);
    }

    public async Task<HeroDto> UpdateAsync(HeroDto dto, CancellationToken cancellationToken = default)
    {
        await _validatorService.ValidateAsync(dto);
        
        var existingHero = await _heroManagementService.GetByIdAsync(dto.Id, cancellationToken);
        await _errorHandlingService.ThrowIfNullAsync(existingHero, nameof(existingHero));

        dto.Adapt(existingHero);

        await _heroManagementService.UpdateHeroAsync(existingHero);

        return _dtoFactory.CreateDto(existingHero);
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var existingHero = await _heroManagementService.GetByIdAsync(id, cancellationToken);
        await _errorHandlingService.ThrowIfNullAsync(existingHero, nameof(existingHero));

        await _heroManagementService.DeleteHeroAsync(id);

        return true;
    }

    public async Task<IList<HeroDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var heroes = await _heroManagementService.GetAllAsync(cancellationToken);
        return heroes.Adapt<IList<HeroDto>>();
    }

    public async Task<HeroDto> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var hero = await _heroManagementService.GetByIdAsync(id, cancellationToken);
        await _errorHandlingService.ThrowIfNullAsync(hero, nameof(hero));

        return _dtoFactory.CreateDto(hero);
    }

    public async Task<bool> DeleteRangeAsync(IList<string> ids, CancellationToken cancellationToken = default)
    {
        var heroesToDelete = await _heroManagementService.TGetByIdsAsync(ids, cancellationToken);

        await _errorHandlingService.ThrowIfNullAsync(heroesToDelete, nameof(heroesToDelete));

        await _heroManagementService.TDeleteRangeAsync(heroesToDelete, cancellationToken);

        return true;
    }
}
