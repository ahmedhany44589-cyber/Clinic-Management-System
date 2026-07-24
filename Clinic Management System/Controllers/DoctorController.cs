using ClinicManagementSystem.Application.Features.Doctors.Commands.CreateDoctor;
using ClinicManagementSystem.Application.Features.Doctors.Commands.DeleteDoctor;
using ClinicManagementSystem.Application.Features.Doctors.Queries.GetAllDoctors;
using ClinicManagementSystem.Application.Features.Doctors.Queries.GetById;
using ClinicManagementSystem.Application.Features.Patients.Commands.DeletePatient;
using ClinicManagementSystem.Application.Features.Patients.Commands.UpdatePatient;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator mediator;
        public DoctorController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateDoctor(CreateDoctorCommand request)
        {
            var Id = await mediator.Send(request);
            return Ok(Id);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery]GetAllDoctorsQuery query )
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDoctorById(int Id)
        {
            GetDoctorByIdQuery request = new GetDoctorByIdQuery();
            request.Id=Id;
            var result = await mediator.Send(request);
            if (result == null) 
                return NotFound();
            return Ok(result);
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteDoctor(int id)
        {
            DeleteDoctorCommand reqest = new DeleteDoctorCommand();
            reqest.Id = id;
            await mediator.Send(reqest);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePatient(int Id, [FromBody] UpdatePatientCommand request)
        {
            if (Id != request.Id)
                return BadRequest("Id Mismatch");
            bool result = await mediator.Send(request);
            if (result == false) return NotFound();
            return Ok();
        }

    }
}
