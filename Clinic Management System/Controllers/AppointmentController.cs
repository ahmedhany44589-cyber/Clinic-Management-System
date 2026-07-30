using ClinicManagementSystem.Application.Features.Appointments.Commands.CreateAppointment;
using ClinicManagementSystem.Application.Features.Appointments.Commands.DeleteAppointment;
using ClinicManagementSystem.Application.Features.Appointments.Commands.UpdateAppointment;
using ClinicManagementSystem.Application.Features.Appointments.Queries.GetAllAppointments;
using ClinicManagementSystem.Application.Features.Appointments.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator mediator;
        public AppointmentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppointment(CreateAppointmentCommand request)
        {
          int Id=  await mediator.Send(request);
            return Ok(Id);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            GetByIdAppointmentQuery request = new GetByIdAppointmentQuery();
            request.Id = Id;
            var result = await mediator.Send(request);
            return Ok(result);
        }
        [HttpPost("Id")]
        public async Task<IActionResult> UpdateAppointment(int Id, [FromBody] UpdateAppointmentCommand request)
        { 
            if (Id !=request.Id)
              return BadRequest("Id Mismatch");
            var result = await mediator.Send(request);
            if (result == false) return NotFound();
            return Ok(result);
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteAppointment(int Id)
        {
            DeleteAppointmentCommand reqest = new DeleteAppointmentCommand();
            reqest.Id = Id;
            var result = await mediator.Send(reqest);
            if (result == false) return NotFound();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments([FromQuery]GetAllAppointmentsQuery query)
        {
           var result = await mediator.Send(query);
            return Ok(result);
        }


    }
}
