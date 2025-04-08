using Mapster;
using PortfolioV1.Domain.Entities;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Commons.IFactories.Dto;

public class DtoFactory : IDtoFactory
{
    public DeleteHeroesRangeRequestDto CreateDeleteHeroesRangeRequestDto(IList<string> ids, string message)
    {
        return new DeleteHeroesRangeRequestDto
        {
            Ids = ids,
            Message = message
        };
    }

    public Hero CreateHeroFromDto(CreateHeroDto createHeroDto)
    {
        if (createHeroDto is null) throw new CheckNullExceptionGloballay("createHeroDto is null");

        return createHeroDto.Adapt<Hero>();
    }

    public class CheckNullExceptionGloballay : Exception
    {
        public CheckNullExceptionGloballay(string message) : base(message)
        {
        }
    }
}


