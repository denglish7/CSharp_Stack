using Microsoft.AspNetCore.Builder;
using Nancy.Owin;
using Microsoft.Extensions.Logging;

namespace loginregModule
{
    public class Startup
    {
        public void Configure(IApplicationBuilder App, ILoggerFactory LoggerFactory)
        {
            LoggerFactory.AddConsole();
            App.UseOwin(x => x.UseNancy());
        }
    }
}