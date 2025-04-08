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
}
