using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Patients.Commands.DeletePatient
{
    public class DeletePatientCommandHandler(IUnitOfWork unit, IMapper mapper) : IRequestHandler<DeletePatientCommand, bool>
    {
        public async Task<bool> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await unit.Patients.GetByIdasync(request.Id);
            if (patient == null)
            {
                throw new Exception("Patient Not Found");
            }
            await unit.Patients.Delete(patient);
            await unit.SaveChangesAsync();
            return true;

        }
    }
}
