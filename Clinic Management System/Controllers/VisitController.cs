using ClinicManagementSystem.Application.Features.Visits.Commands.CreateVisit;
using ClinicManagementSystem.Application.Features.Visits.Commands.DeleteVisit;
using ClinicManagementSystem.Application.Features.Visits.Commands.UpdateVisit;
using ClinicManagementSystem.Application.Features.Visits.Queries.GetAllVisits;
using ClinicManagementSystem.Application.Features.Visits.Queries.GetVisitById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitController : ControllerBase
    {
        private readonly IMediator mediator;
        public VisitController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllVisits([FromQuery] GetAllVisitsQuery request)
        {
            var visits = await mediator.Send(request);
            return Ok(visits);
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetVisitById(int Id)
        {
            var request = new GetVisitByIdQuery();
            request.Id = Id;
            var result = await mediator.Send(request);
            if (result == null) return NotFound();

            return Ok(result);
        }
        [HttpPut("Id")]
        public async Task<IActionResult> UpdateVisit(int Id, [FromQuery] UpdateVisitCommand request)
        {
            if (Id != request.Id) return BadRequest("Id Mismatch");
            var result = mediator.Send(request);
            if (result == null) return NotFound();
            return Ok(result);
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteVisit(int Id)
        {
            var request = new DeleteVisitCommand() { Id = Id };
            var result = await mediator.Send(request);
            if (!result) return NotFound();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateVisit([FromBody]CreateVisitCommand request)
        {
            var Id = await mediator.Send(request);
            return Ok(Id);
        }
    }
}
