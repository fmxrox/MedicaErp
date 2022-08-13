using MedicaERPMVC.Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.MedicaERPMVC
{
    public class MedicaErpDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<SpecialitzationOfDoctor> SpecializationOfDoctors { get; set; }
        //public DbSet<UserContactInformation> UserContactInformation { get; set; }
        public DbSet<VisitType> VisitTypes { get; set; }
        public MedicaErpDbContext(DbContextOptions<MedicaErpDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Visit>()
                .HasOne(d=>d.Doctor)
                .WithMany(v=>v.DoctorVisits)
                .HasForeignKey(d => d.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<SpecialitzationOfDoctor>()
              .HasMany(d => d.Doctors)
              .WithOne(s => s.SpecialitzationOfDoctor)
              .HasForeignKey(drid => drid.SpecializationId);

            builder
                .Entity<Clinic>()
                .HasMany(e => e.Employees)
                .WithOne(c => c.Clinic)
                .HasForeignKey(cId => cId.ClinicId);//wiele do wielu moze zrobic 
            //jeden pracownik w wiielu klinikach moze pracować

            builder
                .Entity<Visit>()
                .HasOne(p => p.Patient)
                .WithMany(v => v.PatientVisits)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
                

            base.OnModelCreating(builder);
        }

    }
}
