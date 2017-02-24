using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace dojo_surveyModule
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }
        public void Configure(IApplicationBuilder App)
        {
            App.UseMvc();
            App.UseStaticFiles();
        }
    }
}

