
namespace CleanArchitecture.Presentation.Controllers;

using MediatR;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using CleanArchitecture.Application.Features.Activity.Queries.DTOs;
using CleanArchitecture.Application.Features.Activity.Commands.DTOs;
using CleanArchitecture.Application.Features.Activity.Queries.Requests;
using CleanArchitecture.Application.Features.Activity.Commands.Requests;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/[controller]")]
[Authorize]
public class ActivityController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    // GET: api/<ActivityController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<GetActivityDto>>> Get()
    {
        var activities = await _mediator.Send(new GetActivityListRequest());
        return activities.ToList();
    }

    // POST api/<ActivityController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post([FromBody] AddActivityDto activity)
    {
        await _mediator.Send(new AddActivityCommandRequest { Activity = activity });
        return CreatedAtAction(nameof(Post), activity);
    }

    // GET api/<ActivityController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetActivityDto>> Get(Guid id)
    {
        var activity = await _mediator.Send(new GetActivityByIdRequest { ActivityId = id });
        return Ok(activity);
    }

    // DELETE api/<ActivityController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteActivityCommandRequest { ActivityId = id });
        return NoContent();
    }
}
