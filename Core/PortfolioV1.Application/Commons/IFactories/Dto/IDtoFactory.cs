using PortfolioV1.Application.IManagements.HeroManagementsServices;
using PortfolioV1.Application.ServiceManagers.HeroServiceManagers;
using PortfolioV1.Domain.Entities;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Commons.IFactories.Dto;

public interface IDtoFactory
{
    // Write 
    TEntity CreateEntityFromDto<TEntity, TDto>(TDto dto);
    TDto CreateDtoFromEntity<TEntity, TDto>(TEntity entity);


    //Hero CreateHeroFromDto(CreateHeroDto createHeroDto);
    //UpdateHeroDto CreateUpdateHeroDtoFromEntity(Hero hero);

    // Read

}


//public class HeroDtoFactory : IHeroDtoFactory
//{
//    public Hero CreateHeroFromDto(CreateHeroDto createHeroDto)
//    {
//        if (createHeroDto == null)
//            throw new ArgumentNullException(nameof(createHeroDto), "DTO cannot be null");

//        // Hero yaratmak için özel mantık
//        return new Hero
//        {
//            Name = createHeroDto.Name,
//            Power = createHeroDto.Power
//        };
//    }

//    public UpdateHeroDto CreateUpdateHeroDtoFromEntity(Hero hero)
//    {
//        return new UpdateHeroDto
//        {
//            Id = hero.Id,
//            Name = hero.Name,
//            Power = hero.Power
//        };
//    }
//}

//public class HeroService : IHeroService
//{
//    private readonly IHeroDtoFactory _heroDtoFactory;
//    private readonly IHeroManagementService _heroManagementService;

//    public HeroService(IHeroDtoFactory heroDtoFactory, IHeroManagementService heroManagementService)
//    {
//        _heroDtoFactory = heroDtoFactory;
//        _heroManagementService = heroManagementService;
//    }

//    public async Task CreateHeroAsync(CreateHeroDto createHeroDto, CancellationToken cancellationToken = default)
//    {
//        var hero = _heroDtoFactory.CreateHeroFromDto(createHeroDto);
//        await _heroManagementService.CreateHeroAsync(hero);
//    }

//    public async Task<UpdateHeroDto> UpdateHeroAsync(UpdateHeroDto updateHeroDto, CancellationToken cancellationToken = default)
//    {
//        var hero = await _heroManagementService.GetByIdAsync(updateHeroDto.Id);
//        hero.UpdateFromDto(updateHeroDto);
//        await _heroManagementService.UpdateHeroAsync(hero);
//        return _heroDtoFactory.CreateUpdateHeroDtoFromEntity(hero);
//    }
//}
