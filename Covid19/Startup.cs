using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Covid19.Areas.Identity;
using Covid19.Data;
using Covid19.Service;
using Microsoft.AspNetCore.Http;

namespace Covid19
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Transient);
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                //options.SignIn.RequireConfirmedEmail = false;
                //options.SignIn.RequireConfirmedPhoneNumber = false;
                //options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            })
                 .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<IReportingService, ReportingService>();
            services.AddScoped<IMuncipalityService, MuncipalityService>();
            services.AddScoped<IStateService, StateService>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IHospitalService, HospitalService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        private async Task CreateUserAndRoles(IServiceProvider serviceProvider)
        {
            //initializing custom roles   
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "SMOH Epidemiology", "Call Center", "Ambulance Team", "Lab Team", "Medical Officer" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {

                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            string adminEmail = "superadmin@sudancovid19.com";

            IdentityUser rootUser = await UserManager.FindByEmailAsync(adminEmail);

            if (rootUser == null)
            {
                rootUser = new IdentityUser()
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                };
                var result = await UserManager.CreateAsync(rootUser, "Test@2462244__!");
            }
            await UserManager.AddToRoleAsync(rootUser, "Admin");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            CreateUserAndRoles(serviceProvider).Wait();
        }
    }
}
