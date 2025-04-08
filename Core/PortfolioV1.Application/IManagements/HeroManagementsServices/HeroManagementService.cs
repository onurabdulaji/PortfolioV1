using PortfolioV1.Domain.Entities;
using PortfolioV1.Domain.IRepositories.IUnitOfWorks;

namespace PortfolioV1.Application.IManagements.HeroManagementsServices;

public class HeroManagementService : IHeroManagementService
{
    private readonly IUnitOfWork _unitOfWork;

    public HeroManagementService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // Write

    public async Task CreateHeroAsync(Hero createHero)
    {
        await _unitOfWork.GetHeroWriteRepository.CreateHero(createHero);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateHeroAsync(Hero updateHero)
    {
        await _unitOfWork.GetHeroWriteRepository.UpdateHero(updateHero);
        await _unitOfWork.SaveAsync();
    }

    // Read

    public async Task<IList<Hero>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _unitOfWork.GetHeroReadRepository.GetAllHeroListAsync(cancellationToken: cancellationToken);
    }

    public async Task<Hero?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        return await _unitOfWork.GetHeroReadRepository.GetHeroByIdAsync(id, cancellationToken: cancellationToken);
    }
   
}
