using ClinicManagementSystem.Application.Features.Patients.Commands.CreatePatient;
using ClinicManagementSystem.Application.Features.Patients.Commands.DeletePatient;
using ClinicManagementSystem.Application.Features.Patients.Commands.UpdatePatient;
using ClinicManagementSystem.Application.Features.Patients.Queries.GetAllPatient;
using ClinicManagementSystem.Application.Features.Patients.Queries.GetById;
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
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetPatientById(int Id)
        {
            GetPatientByIdQuery reqest = new GetPatientByIdQuery() ;
            reqest.Id = Id ;
            
            var result = await _mediator.Send(reqest);
            if (result == null)
                return NotFound();

            return Ok(result);
        }
        [HttpPut("Id")]
        public async Task<IActionResult> UpdatePatient(int Id , [FromBody ] UpdatePatientCommand request)
        {
            if (Id != request.Id)
                return BadRequest("Id Mismatch");
            bool result = await _mediator.Send(request);
            if (result == false) return NotFound();
            return Ok();
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            DeletePatientCommand reqest = new DeletePatientCommand() ;
            reqest.Id = id ;
            await _mediator.Send(reqest);
            return Ok();
        }


    }
}
