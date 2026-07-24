using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommandHandler(IUnitOfWork unit, IMapper mapper) : IRequestHandler<UpdateDoctorCommand, bool>
    {
        public async Task<bool> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await unit.Doctors.GetByIdasync(request.Id);
            if (doctor == null)
            {
                throw new Exception("Doctor Not Found");
            }
            mapper.Map(request, doctor);
             unit.Doctors.Updtae(doctor);
            unit.SaveChangesAsync();
            return true;

        }
    }
}
