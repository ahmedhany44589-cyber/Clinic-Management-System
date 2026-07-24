using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommandHandler(IUnitOfWork unit , IMapper mapper) : IRequestHandler<DeleteDoctorCommand, bool>
    {
        public async Task<bool> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = await unit.Doctors.GetByIdWithSpecializationAsync(request.Id);
            if (doctor == null) {
                throw new Exception("Doctor Not Found");

            }
            await unit.Doctors.Delete(doctor);
            await unit.SaveChangesAsync();
            return true;
        }
    }
}
