using Coravel;


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

            //services.AddHostedService<SerialPortService>();
            //services.AddSingleton<IHostedService, SerialPortService>();
            services.AddSingleton<SerialPortService>();



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
