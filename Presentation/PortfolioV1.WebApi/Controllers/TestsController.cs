using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortfolioV1.Application.Features.MediatR.Hero.CreateHero.Commands;
using PortfolioV1.DTO.DTOs.HeroDtos;

namespace PortfolioV1.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("CreateHero")]
    public async Task<IActionResult> CreateHero([FromBody] CreateHeroDto createHeroDto)
    {
        var command = new CreateHeroCommand(createHeroDto);
        await _mediator.Send(command);
        return Ok(new { message = "Hero Created Successfuly" });
    }
}
