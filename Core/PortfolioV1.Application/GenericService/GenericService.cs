
using PortfolioV1.Application.Commons.IFactories.Dto;
using PortfolioV1.Domain.Entities.IBase;
using PortfolioV1.Domain.IRepositories.IUnitOfWorks;

namespace PortfolioV1.Application.GenericService;

public class GenericService<TDto, TEntity> : IGenericService<TDto, TEntity>
        where TDto : class, new()
        where TEntity : class, IBaseEntity, new()
{
    private readonly IGenericDtoFactory<TDto, TEntity> _dtoFactory;
    private readonly IUnitOfWork _unitOfWork;


    public GenericService(IGenericDtoFactory<TDto, TEntity> dtoFactory, IUnitOfWork unitOfWork)
    {
        _dtoFactory = dtoFactory;
        _unitOfWork = unitOfWork;
    }

    public async Task<TDto> CreateAsync(TDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _dtoFactory.CreateEntity(dto);

        await _unitOfWork.GetGenericWriteRepository<TEntity>().AddAsync(entity);

        await _unitOfWork.SaveAsync();

        return _dtoFactory.CreateDto(entity);

    }

    public async Task<TDto> UpdateAsync(TDto dto, CancellationToken cancellationToken = default)
    {
        var entity = _dtoFactory.CreateEntity(dto);

        await _unitOfWork.GetGenericWriteRepository<TEntity>().UpdateAsync(entity);

        await _unitOfWork.SaveAsync();

        return _dtoFactory.CreateDto(entity);
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.GetGenericReadRepository<TEntity>().GetAsync(q => q.Id == id);

        if (entity == null) return false;

        await _unitOfWork.GetGenericWriteRepository<TEntity>().DeleteAsync(entity);

        await _unitOfWork.SaveAsync();

        return true;
    }

    public async Task<TDto> GetByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var entity = await _unitOfWork.GetGenericReadRepository<TEntity>().FindAsync(q => q.Id == id);
        if (entity == null) return null;
        return _dtoFactory.CreateDto(entity);

    }

    public async Task<IList<TDto>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var entities = await _unitOfWork.GetGenericReadRepository<TEntity>().GetAllAsync();

        if (entities == null) return new List<TDto>();  // Return empty list instead of null

        // Map entities to DTOs
        var dtos = entities.Select(entity => _dtoFactory.CreateDto(entity)).ToList();

        return dtos;  // Return the mapped DTOs
    }

    public async Task<bool> DeleteRangeAsync(IList<string> ids, CancellationToken cancellationToken = default)
    {
        //var entities = await _unitOfWork.GetGenericReadRepository<TEntity>().GetByIdsAsync(ids);

        //if (entities == null || entities.Count == 0)
        //{
        //    return false;
        //}

        //await _unitOfWork.GetGenericWriteRepository<TEntity>().DeleteRangeAsync(entities);

        //await _unitOfWork.SaveAsync(cancellationToken);

        return true;

    }
}
