using ClinicManagementSystem.Application.Features.Doctors.Commands.CreateDoctor;
using ClinicManagementSystem.Application.Features.Doctors.Queries.GetAllDoctors;
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
        public async Task<IActionResult> GetAllAsync(GetAllDoctorsQuery query )
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
