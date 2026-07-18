using ClinicManagementSystem.Application.Features.Patients.Commands;
using ClinicManagementSystem.Application.Features.Patients.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PatientsController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient(CreatePatientCommand command)
        { 
            var Patient_Id=await _mediator.Send(command);
            return Ok(Patient_Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPatients([FromQuery] GetAllPatientQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

    }
}
