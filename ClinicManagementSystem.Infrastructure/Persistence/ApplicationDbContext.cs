using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicManagementSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.Infrastructure.Persistence
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<MedicalFile> MedicalFiles { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionItem> PrescriptionItems { get; set; }
        public DbSet<LabResult> LabResults { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ============ علاقات 1:1 ============

            // Patient <-> MedicalFile
            modelBuilder.Entity<MedicalFile>()
                .HasOne(mf => mf.Patient)
                .WithOne(p => p.medicalFile)
                .HasForeignKey<MedicalFile>(mf => mf.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            // Visit <-> Invoice
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.visit)
                .WithOne(v => v.invoice)
                .HasForeignKey<Invoice>(i => i.VisitId)
                .OnDelete(DeleteBehavior.Restrict);

            // Appointment <-> Visit
            modelBuilder.Entity<Visit>()
                .HasOne(v => v.appointment)
                .WithOne(a => a.Visit)
                .HasForeignKey<Visit>(v => v.AppointmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // ============ علاقات 1:M ============

            // Specialization -> Doctor
            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Specialization)
                .WithMany(s => s.doctors)
                .HasForeignKey(d => d.SpecializationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Doctor -> Appointment
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.doctor)
                .WithMany(d => d.appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Patient -> Appointment
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            // Visit -> Prescription
            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.visit)
                .WithMany(v => v.Prescriptions)
                .HasForeignKey(p => p.VisitId)
                .OnDelete(DeleteBehavior.Restrict);

            // Prescription -> PrescriptionItem
            modelBuilder.Entity<PrescriptionItem>()
                .HasOne(pi => pi.prescription)
                .WithMany(p => p.PrescriptionItems)
                .HasForeignKey(pi => pi.PrescriptionId)
                .OnDelete(DeleteBehavior.Cascade);

            // Visit -> LabResult
            modelBuilder.Entity<LabResult>()
                .HasOne(lr => lr.visit)
                .WithMany(v => v.LabResults)
                .HasForeignKey(lr => lr.VisitId)
                .OnDelete(DeleteBehavior.Restrict);

            // Invoice -> Payment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.invoice)
                .WithMany(i => i.Payments)
                .HasForeignKey(p => p.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            // Department -> Employee
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee -> Attendance
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.employee)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee -> LeaveRequest
            modelBuilder.Entity<LeaveRequest>()
                .HasOne(lr => lr.employee)
                .WithMany(e => e.LeaveRequests)
                .HasForeignKey(lr => lr.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Doctor>()
    .Property(d => d.ConsultationFees)
    .HasPrecision(10, 2);

            modelBuilder.Entity<Invoice>()
                .Property(i => i.Amount)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(10, 2);
        }

    }
}
