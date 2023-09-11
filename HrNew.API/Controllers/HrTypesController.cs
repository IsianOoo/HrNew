using HrNew.Application.DTOs.HrType;
using HrNew.Application.Features.HrTypes.Requests.Commands;
using HrNew.Application.Features.HrTypes.Requests.Queries;
using HrNew.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace HrNew.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]

    public class HrTypesController : ControllerBase
    {
        public readonly IMediator _mediator;
        public HrTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<HrTypesController>
        [HttpGet]
        public async Task<ActionResult<List<HrTypeDto>>> Get()
        {
            var hrTypes = await _mediator.Send(new GetHrTypeListRequest());
            return Ok(hrTypes);
        }

        // GET api/<HrTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HrTypeDto>> Get(int id)
        {
            var hrType = await _mediator.Send(new GetHrTypeDetailRequest { Id = id });
            return Ok(hrType);
        }

        // POST api/<HrTypesController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateHrTypeDto hrType)
        {
            var command = new CreateHrTypeCommand { HrTypeDto = hrType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<HrTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] HrTypeDto hrType)
        {
            var command = new UpdateHrTypeCommand { HrTypeDto = hrType };
            await _mediator.Send(command);
            return NoContent();
        }

        // DELETE api/<HrTypesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteHrTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
