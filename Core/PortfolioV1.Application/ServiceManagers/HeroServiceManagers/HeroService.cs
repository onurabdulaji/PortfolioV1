using Mapster;
using PortfolioV1.Application.IManagements.HeroManagementsServices;
using PortfolioV1.Application.Validations;
using PortfolioV1.Domain.Entities;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.ServiceManagers.HeroServiceManagers;

public class HeroService : IHeroService
{
    private readonly IHeroManagementService _heroManagementService;
    private readonly IValidatorService _validatorService;

    public HeroService(IHeroManagementService heroManagementService, IValidatorService validatorService)
    {
        _heroManagementService = heroManagementService;
        _validatorService = validatorService;
    }

    public async Task CreateHeroAsync(CreateHeroDto createHeroDto, CancellationToken cancellationToken = default)
    {
        await _validatorService.ValidateAsync(createHeroDto);

        var hero = createHeroDto.Adapt<Hero>();

        await _heroManagementService.CreateHeroAsync(hero);
    }

    public async Task<IList<HeroDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var list = await _heroManagementService.GetAllAsync(cancellationToken);
        return list.Adapt<IList<HeroDto>>();
    }
}
