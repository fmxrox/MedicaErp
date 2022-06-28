using MedicaERPMVC.Domain;
using MedicaERPMVC.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.MedicaERPMVC
{
    public class MedicaErpDbContext : IdentityDbContext
    {
        public DbSet<Visit> Visits { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<SpecialitzationOfDoctor> SpecializationOfDoctors { get; set; }
        public DbSet<UserContactInformation> UserContactInformation { get; set; }
        public DbSet<VisitType> VisitTypes { get; set; }
        public MedicaErpDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            //builder.Entity<User>()
            //    .HasOne(a => a.UserContactInformation).WithOne(b => b.User)
            //    .HasForeignKey<UserContactInformation>(c => c.UserId);
            base.OnModelCreating(builder);
        }

    }
}
