using CarRental.DataAccess;
using CarRental.Services;
using CarRental.ServicesContracts;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Canplanet.Web
{
    public class Startup
    {        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddTransient<IAutoService, AutoService>();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<CarRentalDbContext>();


            services.AddTransient<ILoginService, LoginService>();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<LoginDbContext>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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

            app.UseMvc(config => {
                config.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
