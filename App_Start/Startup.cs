using Coravel;
using Microsoft.AspNetCore.Http;
using SmartHome_Database;

namespace SmartHome_MVC.App_Start
{
    
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // ...
            services.AddScheduler();
            // ...
            services.AddSession();


            

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Inne konfiguracje

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                // Konfiguracje endpointów...
            });

            

            // Inne konfiguracje
        }

    }

}
