
namespace CleanArchitecture.Presentation.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CleanArchitecture.Application.Features.Activity.Queries.DTOs;
using CleanArchitecture.Application.Features.Activity.Queries.Requests;

[Route("api/[controller]")]
[ApiController]
public class ActivityController : ControllerBase
{
    private readonly IMediator _mediator;
    public ActivityController(IMediator mediator) => _mediator = mediator;

    // GET: api/<ActivityController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<GetActivityDto>>> Get()
    {
        var activities = await _mediator.Send(new GetActivityListRequest());
        return activities.ToList();
    }
}
