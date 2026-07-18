using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Application.DTOs;
using ClinicManagementSystem.Application.Features.Patients.Commands;
using ClinicManagementSystem.Domain.Entities;

namespace ClinicManagementSystem.Application.Common.Mappings
{
    public class    MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap< CreatePatientCommand,Patient>().ReverseMap();
           
        }
    }
}
