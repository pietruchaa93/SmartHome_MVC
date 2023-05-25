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

        }

    }

}
