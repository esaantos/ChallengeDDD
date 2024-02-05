using Challenge.Application.Commands.CreateAssociate;
using Challenge.Application.Commands.DeleteAssociate;
using Challenge.Application.Commands.UpdateAssociate;
using Challenge.Application.Queries.GetAllAssociates;
using Challenge.Application.Queries.GetAssociateById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AssociateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]       
        public async Task<IActionResult> GetAssociates()
        {
            var getAssociates = new GetAllAssociatesQuery();

            var associates = await _mediator.Send(getAssociates);
            return Ok(associates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssociateById(int id)
        {
            var query = new GetAssociateByIdQuery(id);

            var associate = await _mediator.Send(query);

            if (associate == null)
                return NotFound();

            return Ok(associate);
        }
        [HttpPost]
        public async Task<IActionResult> PostAssociate([FromBody] CreateAssociateCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetAssociateById), new { id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssociate(int id,[FromBody] UpdateAssociateCommand command)
        {
            try
            {
                await _mediator.Send(command);

                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound("Associado não encontrado!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssociate(int id)
        {
            var command = new DeleteAssociateCommand(id);

            try
            {
                await _mediator.Send(command);

                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound("Associado não encontrado!");
            }

        }
    }
}
