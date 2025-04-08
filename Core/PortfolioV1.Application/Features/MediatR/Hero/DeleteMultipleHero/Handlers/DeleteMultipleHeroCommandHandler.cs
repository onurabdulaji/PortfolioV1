using MediatR;
using PortfolioV1.Application.Commons.IFactories.Dto;
using PortfolioV1.Application.Features.MediatR.Hero.DeleteMultipleHero.Commands;
using PortfolioV1.Application.Features.MediatR.Hero.DeleteMultipleHero.Exceptions;
using PortfolioV1.Application.ServiceManagers.HeroServiceManagers;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.Application.Features.MediatR.Hero.DeleteMultipleHero.Handlers;

public class DeleteMultipleHeroCommandHandler : IRequestHandler<DeleteMultipleHeroCommand, DeleteHeroesRangeResponseDto>
{
    private readonly IHeroService _heroService;
    private readonly IDtoFactory _dtoFactory;

    public DeleteMultipleHeroCommandHandler(IHeroService heroService, IDtoFactory dtoFactory)
    {
        _heroService = heroService;
        _dtoFactory = dtoFactory;
    }

    public async Task<DeleteHeroesRangeResponseDto> Handle(DeleteMultipleHeroCommand request, CancellationToken cancellationToken)
    {
        var dto = _dtoFactory.CreateDeleteHeroesRangeRequestDto(request.Ids, request.Message ?? "Seçilen kahramanlar başarıyla silindi.");

        var response = await _heroService.DeleteHeroRangeAsync(dto.Ids, dto.Message, cancellationToken);

        return new DeleteHeroesRangeResponseDto
        {
            DeletedIds = response.DeletedIds,
            Message = response.Message
        };

    }
}
