using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roller.Appication.Features.Roll;


namespace Roller.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RollController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RollController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<RollResult>>> Get()
        {
            var query = new GetAllRolls();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RollResult>> Get(int id)
        {
            var query = new GetRoll(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RollResult>> Post([FromBody] CreateRoll command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}