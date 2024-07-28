namespace CleanArchitecture.Web.Controllers
{

    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using CleanArchitecture.Application.Features.CustomerQuery.Queries.DTOs;
    using CleanArchitecture.Application.Features.CustomerQuery.Commands.DTOs;
    using CleanArchitecture.Application.Features.CustomerQuery.Queries.Requests;
    using CleanArchitecture.Application.Features.CustomerQuery.Commands.Requests;

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerQueryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;


        // GET: api/<CustomerQueryController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CustomerQueryDto>>> Get()
        {
            var customerQueries = await _mediator.Send(new GetCustomerQueryQuery());
            return customerQueries.ToList();
        }

        // GET api/<CustomerQueryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerQueryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddCustomerQueryDto customerQuery)
        {
            await _mediator.Send(new AddCustomerQueryCommand { CustomerQuery = customerQuery });
            return CreatedAtAction(nameof(Post), customerQuery);
        }

        // PUT api/<CustomerQueryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerQueryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
