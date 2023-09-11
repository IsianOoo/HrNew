using HrNew.Application.DTOs.HrRequest;
using HrNew.Application.Features.HrRequests.Requests.Commands;
using HrNew.Application.Features.HrRequests.Requests.Queries;
using HrNew.Application.Features.HrTypes.Requests.Commands;
using HrNew.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HrNew.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator,Employee")]

    public class HrRequestsController : ControllerBase
    {
        public readonly IMediator _mediator;
        public HrRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<HrRequestsController>
        [HttpGet]
        public async Task<ActionResult<List<HrRequestDto>>> Get()
        {
            var hrRequests = await _mediator.Send(new GetHrRequestListRequest());
            return Ok(hrRequests);
        }

        // GET api/<HrRequestsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HrRequestDto>> Get(int id)
        {
            var hrAllocation = await _mediator.Send(new GetHrRequestDetailRequest { Id = id });
            return Ok(hrAllocation);
        }

        // POST api/<HrRequestsController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateHrRequestDto hrRequest)
        {
            var command = new CreateHrRequestCommand { HrRequestDto = hrRequest };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<HrRequestsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateHrRequestDto hrRequest)
        {
            var command = new UpdateHrRequestCommand { Id = id, HrRequestDto = hrRequest };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<HrRequestsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteHrTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
