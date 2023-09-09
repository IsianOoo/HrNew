﻿using HrNew.Application.DTOs.HrAllocation;
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
            var deliveryAllocations = await _mediator.Send(new GetHrAllocationListRequest());
            return Ok(deliveryAllocations);
        }

        // GET api/<HrAllocationsController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HrAllocationDto>> Get(int id)
        {
            var deliveryAllocation = await _mediator.Send(new GetHrAllocationDetailRequest { Id = id });
            return Ok(deliveryAllocation);
        }

        // POST api/<HrAllocationsController>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateHrAllocationDto deliveryAllocation)
        {
            var command = new CreateHrAllocationCommand { HrAllocationDto = deliveryAllocation };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<HrAllocationsController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] HrAllocationDto deliveryAllocation)
        {
            var command = new UpdateHrAllocationCommand { HrAllocationDto = deliveryAllocation };
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
