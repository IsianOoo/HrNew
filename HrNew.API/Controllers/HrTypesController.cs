using HrNew.Application.DTOs.HrType;
using HrNew.Application.Features.HrTypes.Requests.Commands;
using HrNew.Application.Features.HrTypes.Requests.Queries;
using HrNew.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HrNew.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

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
            var deliveryTypes = await _mediator.Send(new GetHrTypeListRequest());
            return Ok(deliveryTypes);
        }

        // GET api/<HrTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HrTypeDto>> Get(int id)
        {
            var deliveryType = await _mediator.Send(new GetHrTypeDetailRequest { Id = id });
            return Ok(deliveryType);
        }

        // POST api/<HrTypesController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateHrTypeDto deliveryType)
        {
            var command = new CreateHrTypeCommand { HrTypeDto = deliveryType };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // PUT api/<HrTypesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] HrTypeDto deliveryType)
        {
            var command = new UpdateHrTypeCommand { HrTypeDto = deliveryType };
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
