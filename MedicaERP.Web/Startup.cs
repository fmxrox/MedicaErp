using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.MedicaERPMVC;
using Infrastructure.MedicaERPMVC.Repositories;
using Infrastructure.MedicaERPMVC.Repositories.User;
using MedicaERPMVC.Application.Interfaces;
using MedicaERPMVC.Application.Mapping;
using MedicaERPMVC.Application.Services;
using MedicaERPMVC.Application.Services.Doctor;
using MedicaERPMVC.Application.Services.Visit;
using MedicaERPMVC.Application.ViewModels.Patient;
using MedicaERPMVC.Domain.Interface;
using MedicaERPMVC.Domain.Interfaces;
using MedicaERPMVC.Domain.Interfaces.Doctor;
using MedicaERPMVC.Domain.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using static MedicaERPMVC.Application.ViewModels.Patient.NewPatientViewModel;

namespace MedicaERP.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MedicaErpDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddIdentity<UserOfClinic, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<MedicaErpDbContext>()
                .AddDefaultTokenProviders();





            //    services.AddIdentity<UserOfClinic, IdentityRole>()
            //.AddEntityFrameworkStores<MedicaErpDbContext>();
            //    services.AddDefaultIdentity<IdentityUser>(options=>options.SignIn.RequireConfirmedAccount=false).AddRoles<IdentityRole>().AddEntityFrameworkStores<MedicaErpDbContext>();
            //    services.Configure<IdentityOptions>(options =>
            //    {
            //        options.Password.RequireDigit = false;
            //        options.Password.RequiredLength = 5;
            //        options.Password.RequireLowercase = false;
            //        options.SignIn.RequireConfirmedEmail = false;
            //        options.User.RequireUniqueEmail = true;
            //    });
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("CanEditPatient", policy =>
            //    {
            //        policy.RequireClaim("EditPatient");
            //        policy.RequireClaim("ShowPatient");
            //        policy.RequireRole("Admin");
            //    });
            //});
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<IVisitRepository, VisitRepository>();
            services.AddTransient<IVisitService, VisitService>();          
            services.AddTransient<IPatientRepository, PatientRepository>();
            services.AddTransient<IDoctorRepository, DoctorRepository>();
            services.AddTransient<IDoctorService, DoctorService>();
            //services.AddControllersWithViews().AddFluentValidation(/*fv => fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false*/);
            services.AddRazorPages();
            services.AddTransient<IValidator<NewPatientViewModel>, NewCustomerValidation>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
