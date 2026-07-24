using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Interfaces;
using MediatR;

namespace ClinicManagementSystem.Application.Features.Patients.Commands.UpdatePatient
{
    public class UpdatePatientCommandHandler (IUnitOfWork unit , IMapper mapper) : IRequestHandler<UpdatePatientCommand, bool>
    {
        public async Task<bool> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await unit.Patients.GetByIdasync(request.Id);
            if (patient == null) { 
            return false;
            }
            mapper.Map(request,patient);
             unit.Patients.Updtae(patient);
           await unit.SaveChangesAsync();
            return true;
        }
    }
}
