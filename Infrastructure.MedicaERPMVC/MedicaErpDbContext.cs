using MedicaERPMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.MedicaERPMVC
{
    
    public class MedicaErpDbContext : IdentityDbContext<User>
    {
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<SpecialitzationOfDoctor> SpecializationOfDoctors { get; set; }
        //public DbSet<UserContactInformation> UserContactInformation { get; set; }
        public DbSet<VisitType> VisitTypes { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public MedicaErpDbContext(DbContextOptions<MedicaErpDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder
            //    .Entity<Visit>()
            //    .HasOne(d=>d.Doctor)
            //    .WithMany(v=>v.DoctorVisits)
            //    .HasForeignKey(d => d.DoctorId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .Entity<Clinic>()
            //    .HasMany(e => e.Doctors)
            //    .WithOne(c => c.Clinic)
            //    .HasForeignKey(c => c.ClinicId)
            //     .OnDelete(DeleteBehavior.ClientNoAction);

            builder
                .Entity<Visit>()
                .HasOne(p => p.Patient)
                .WithMany(v => v.PatientVisits)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.NoAction);
       

            base.OnModelCreating(builder);
        }

    }
}
