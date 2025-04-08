using MediatR;
using Microsoft.AspNetCore.Mvc;
using PortfolioV1.Application.Features.MediatR.Hero.CreateHero.Commands;
using PortfolioV1.Application.Features.MediatR.Hero.DeleteHero.Commands;
using PortfolioV1.Application.Features.MediatR.Hero.DeleteMultipleHero.Commands;
using PortfolioV1.Application.Features.MediatR.Hero.GetAllHero.Queries;
using PortfolioV1.Application.Features.MediatR.Hero.GetHeroById.Queries;
using PortfolioV1.Application.Features.MediatR.Hero.UpdateHero.Commands;
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

    [HttpGet("GetAllHero")]
    public async Task<IActionResult> GetAllHeros()
    {
        var result = await _mediator.Send(new GetAllHeroQuery());
        return Ok(result);
    }
    //[HttpGet("{id}", Name = "GetHeroById")]
    [HttpGet("GetHeroById/{id}")]
    public async Task<ActionResult<GetHeroByIdDto>> GetHeroById(string id)
    {
        var result = await _mediator.Send(new GetHeroByIdQuery(id));
        return Ok(result);
    }

    [HttpPost("CreateHero")]
    public async Task<IActionResult> CreateHero([FromBody] CreateHeroDto createHeroDto)
    {
        var command = new CreateHeroCommand(createHeroDto);
        await _mediator.Send(command);
        return Ok(new { message = "Hero Created Successfuly" });
    }
    [HttpPut("UpdateHero")]
    public async Task<IActionResult> UpdateHero([FromBody] UpdateHeroDto updateHeroDto)
    {
        var command = new UpdateHeroCommand(updateHeroDto);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("DeleteHero/{id}")]
    public async Task<IActionResult> DeleteHero(string id)
    {
        var command = new DeleteHeroCommand { Id = id };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("DeleteHeroRange")]
    public async Task<IActionResult> DeleteRange([FromBody] DeleteHeroesRangeResponseDto responseDto)
    {
        var command = new DeleteMultipleHeroCommand { Ids = responseDto.DeletedIds };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

}
