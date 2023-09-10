using HrNew.Application.DTOs.HrAllocation;
using HrNew.Application.Features.HrAllocations.Requests.Commands;
using HrNew.Application.Features.HrAllocations.Requests.Queries;
using HrNew.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HrNew.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class HrAllocationsController : ControllerBase
    {
        public readonly IMediator _mediator;
        public HrAllocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<HrAllocationsController>
        [HttpGet]
        public async Task<ActionResult<List<HrAllocationDto>>> Get()
        {
            var hrAllocations = await _mediator.Send(new GetHrAllocationListRequest());
            return Ok(hrAllocations);
        }

        // GET api/<HrAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HrAllocationDto>> Get(int id)
        {
            var hrAllocation = await _mediator.Send(new GetHrAllocationDetailRequest { Id = id });
            return Ok(hrAllocation);
        }

        // POST api/<HrAllocationsController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateHrAllocationDto hrAllocation)
        {
            var command = new CreateHrAllocationCommand { HrAllocationDto = hrAllocation };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<HrAllocationsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] HrAllocationDto hrAllocation)
        {
            var command = new UpdateHrAllocationCommand { HrAllocationDto = hrAllocation };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<HrAllocationsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteHrAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
