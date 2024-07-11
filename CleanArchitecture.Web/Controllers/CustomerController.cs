
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.Web.Controllers;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Features.Customer.Queries.DTOs;
using CleanArchitecture.Application.Features.Customer.Commands.DTOs;
using CleanArchitecture.Application.Features.Customer.Queries.Requests;
using CleanArchitecture.Application.Features.Customer.Commands.Requests;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly IMediator _mediator;
    public CustomerController(IMediator mediator) => _mediator = mediator;
    // GET: api/<CustomerController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<CustomerDto>>> Get()
    {
        var customers = await _mediator.Send(new GetCustomerList());
        return customers;
    }

    // GET api/<CustomerController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CustomerDto>> Get(Guid id)
    {
        var customer = await _mediator.Send(new GetCustomerById { CustomerId = id });
        return Ok(customer);
    }

    // POST api/<CustomerController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Post([FromBody] AddCustomerDto customer)
    {
        await _mediator.Send(new AddCustomerCommand { Customer = customer });
        return CreatedAtAction(nameof(Post), customer);
    }

    // PUT api/<CustomerController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> Put(int id, [FromBody] UpdateCustomerDto customer)
    {
        await _mediator.Send(new UpdateCustomerCommand { Customer = customer });
        return NoContent();
    }

    // DELETE api/<CustomerController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> Delete(Guid id)
    {
        await _mediator.Send(new DeleteCustomerCommand { CustomerId = id });
        return NoContent();
    }
}
