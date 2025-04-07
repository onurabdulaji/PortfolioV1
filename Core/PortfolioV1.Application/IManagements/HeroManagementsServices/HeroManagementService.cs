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

    public async Task CreateHeroAsync(Hero createHero)
    {
        await _unitOfWork.GetHeroWriteRepository.CreateHero(createHero);
        await _unitOfWork.SaveAsync();
    }

    public async Task<IList<Hero>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _unitOfWork.GetHeroReadRepository.GetAllHeroListAsync();
    }
}
