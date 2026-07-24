using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Entities;
using ClinicManagementSystem.Domain.Interfaces;
using ClinicManagementSystem.Infrastructure.Persistence;

namespace ClinicManagementSystem.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IRepository<Patient> Patients => new Repository<Patient>(_context);

        public DoctorIRepository Doctors => new DoctorRepository(_context);

        public IRepository<Specialization> Specialization => new Repository<Specialization>(_context);

        public IRepository<Appointment> Appointment => new Repository<Appointment>(_context);

        public IRepository<MedicalFile> MedicalFile => new Repository<MedicalFile>(_context);

        public IRepository<Visit> Visit => new Repository<Visit>(_context);

        public IRepository<Invoice> Invoice => new Repository<Invoice>(_context);

        public IRepository<Payment> Payment => new Repository<Payment>(_context);

        public IRepository<Prescription> Prescription => new Repository<Prescription>(_context);

        public IRepository<PrescriptionItem> PrescriptionItem => new Repository<PrescriptionItem>(_context);

        public IRepository<LabResult> LabResult => new Repository<LabResult>(_context);

        public IRepository<Department> Department => new Repository<Department>(_context);

        public IRepository<Employee> Employee => new Repository<Employee>(_context);
        public IRepository<Attendance> Attendance => new Repository<Attendance>(_context);

        public IRepository<LeaveRequest> LeaveRequest => new Repository<LeaveRequest>(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
