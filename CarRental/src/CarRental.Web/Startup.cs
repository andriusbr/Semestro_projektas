using CarRental.DataAccess;
using CarRental.DataAccess.Entities;
using CarRental.Services;
using CarRental.ServicesContracts;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Globalization;

namespace Canplanet.Web
{
    public class Startup
    {        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<IAutoService, AutoService>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<CarRentalDbContext>();


            services.AddTransient<ILoginService, LoginService>();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<LoginDbContext>();

            services.AddIdentity<User, IdentityRole>(o => {
                o.Password.RequireDigit = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonLetterOrDigit = false; ;
                o.Password.RequiredLength = 6;
            })
                .AddEntityFrameworkStores<LoginDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.GetCultureInfo("lt");
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.GetCultureInfo("lt");

            // Klaidų puslapis
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseRuntimeInfoPage(); // default path is /runtimeinfo
            }
            else
            {
                // specify production behavior for error handling, for example:
                // app.UseExceptionHandler("/Home/Error");
                // if nothing is set here, exception will not be handled.
            }

            app.UseIISPlatformHandler();

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMvc(config => {
                config.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });

            createRoles();
        }


        private void createRoles()
        {
            LoginDbContext context = new LoginDbContext();
            LoginService service = new LoginService(context);

            if (!service.RoleExists(UserStatus.Regular))
            {
                IdentityRole Role = new IdentityRole(UserStatus.Regular);
                context.Roles.Add(Role);
                context.SaveChanges();
            }

            if (!service.RoleExists(UserStatus.Admin))
            {
                IdentityRole Role = new IdentityRole(UserStatus.Admin);
                context.Roles.Add(Role);
                context.SaveChanges();
            }

            if (!service.RoleExists(UserStatus.Master))
            {
                IdentityRole Role = new IdentityRole(UserStatus.Master);
                context.Roles.Add(Role);
                context.SaveChanges();
            }

            if (!service.RoleExists(UserStatus.SuperAdmin))
            {
                IdentityRole Role = new IdentityRole(UserStatus.SuperAdmin);
                context.Roles.Add(Role);
                context.SaveChanges();
            }
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
