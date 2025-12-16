using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReproductionService.Application.Commands.CancelReproductionEvent;
using ReproductionService.Application.Commands.CreateReproductionEvent;
using ReproductionService.Application.DTOs;
using ReproductionService.Application.Queries.GetReproductionEventById;
using ReproductionService.Application.Queries.GetReproductionEventsByAnimal;
using ReproductionService.Application.Queries.GetReproductionEventsByFarm;
using ReproductionService.Application.Queries.GetReproductionEventsByType;
using ReproductionService.Domain.Enums;

namespace ReproductionService.Presentation.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ReproductionController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReproductionController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Get reproduction event by ID
    /// </summary>
    [HttpGet("{id}")]
    public async Task<ActionResult<ReproductionEventResponse>> GetById(long id)
    {
        var query = new GetReproductionEventByIdQuery(id);
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound($"Reproduction event with id {id} not found");

        return Ok(result);
    }

    /// <summary>
    /// Get reproduction events by animal
    /// </summary>
    [HttpGet("animal/{animalId}")]
    public async Task<ActionResult<ReproductionEventListResponse>> GetByAnimal(
        long animalId,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var query = new GetReproductionEventsByAnimalQuery(animalId, page, pageSize);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Get reproduction events by farm with optional date range
    /// </summary>
    [HttpGet("farm/{farmId}")]
    public async Task<ActionResult<ReproductionEventListResponse>> GetByFarm(
        int farmId,
        [FromQuery] DateTime? fromDate,
        [FromQuery] DateTime? toDate,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var query = new GetReproductionEventsByFarmQuery(farmId, fromDate, toDate, page, pageSize);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Get reproduction events by type
    /// </summary>
    [HttpGet("type/{type}")]
    public async Task<ActionResult<ReproductionEventListResponse>> GetByType(
        ReproductionEventType type,
        [FromQuery] int farmId,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var query = new GetReproductionEventsByTypeQuery(type, farmId, page, pageSize);
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    /// <summary>
    /// Create a new reproduction event
    /// </summary>
    [HttpPost]
    public async Task<ActionResult<ReproductionEventResponse>> Create(CreateReproductionEventCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    /// <summary>
    /// Cancel a reproduction event (Soft Delete)
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult<ReproductionEventResponse>> Cancel(long id)
    {
        var command = new CancelReproductionEventCommand(id);
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}
