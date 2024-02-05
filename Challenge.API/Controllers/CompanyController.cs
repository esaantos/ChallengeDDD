using Challenge.Application.Commands.CreateCompany;
using Challenge.Application.Commands.DeleteCompany;
using Challenge.Application.Commands.UpdateCompany;
using Challenge.Application.Queries.GetAllCompanies;
using Challenge.Application.Queries.GetCompanyById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var getCompanies = new GetAllCompaniesQuery();

            var companies = await _mediator.Send(getCompanies);
            return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCompanyById(int id)
        {
            var getById = new GetCompanyByIdQuery(id);
            var company = await _mediator.Send(getById);

            if (company == null)
                return NotFound();

            return Ok(company);
        }
        [HttpPost]
        public async Task<IActionResult> PostCompany([FromBody] CreateCompanyCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCompanyById), new { id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompany(int id, [FromBody] UpdateCompanyCommand command)
        {
            try
            {
                await _mediator.Send(command);

                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound("Empresa não encontrada!");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var command = new DeleteCompanyCommand(id);

            try
            {
                await _mediator.Send(command);

                return NoContent();
            }
            catch (InvalidOperationException)
            {
                return NotFound("Empresa não encontrada!");
            }

        }
    }
}
