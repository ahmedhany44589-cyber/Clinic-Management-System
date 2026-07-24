using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Entities;

namespace ClinicManagementSystem.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Patient> Patients { get; }
        DoctorIRepository Doctors{ get; }
        IRepository<Specialization> Specialization { get; }
        IRepository<Appointment> Appointment { get; }
        IRepository<MedicalFile> MedicalFile { get; }
        IRepository<Visit> Visit { get; }
        IRepository<Invoice> Invoice { get; }
        IRepository<Payment> Payment { get; }
        IRepository<Prescription> Prescription { get; }
        IRepository<PrescriptionItem> PrescriptionItem { get; }
        IRepository<LabResult> LabResult { get; }
        IRepository<Department> Department { get; }
        IRepository<Employee> Employee { get; }
        IRepository<Attendance> Attendance { get; }
        IRepository<LeaveRequest> LeaveRequest { get; }
        Task<int> SaveChangesAsync();
    }
}
