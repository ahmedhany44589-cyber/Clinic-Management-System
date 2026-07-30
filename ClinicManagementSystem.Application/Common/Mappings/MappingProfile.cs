using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ClinicManagementSystem.Application.DTOs;
using ClinicManagementSystem.Application.Features.Appointments.Commands.CreateAppointment;
using ClinicManagementSystem.Application.Features.Appointments.Commands.UpdateAppointment;
using ClinicManagementSystem.Application.Features.Appointments.Queries.GetById;
using ClinicManagementSystem.Application.Features.Doctors.Commands.CreateDoctor;
using ClinicManagementSystem.Application.Features.Patients.Commands.CreatePatient;
using ClinicManagementSystem.Application.Features.Patients.Commands.UpdatePatient;
using ClinicManagementSystem.Application.Features.Visits.Commands.CreateVisit;
using ClinicManagementSystem.Domain.Entities;

namespace ClinicManagementSystem.Application.Common.Mappings
{
    public class    MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap< CreatePatientCommand,Patient>().ReverseMap();
            CreateMap<CreateDoctorCommand,Doctor>();
            CreateMap<UpdatePatientCommand, Patient>();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<CreateAppointmentCommand, Appointment>();

            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.doctor.Name))
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.patient.Name))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
            CreateMap<UpdateAppointmentCommand, Appointment>();
            CreateMap<CreateVisitCommand, Visit>();
            CreateMap<Visit, VisitDto>();

        }
    }
}
