
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.AspNetCore.Hosting;

namespace AB.Service.Core
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

        public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
      .ConfigureServices(services =>
      {
          services.Configure<EventLogSettings>(config =>
          {
              config.LogName = "Sample API Service";
              config.SourceName = "Sample API Service Source";
          });
      })
      .ConfigureWebHostDefaults(webBuilder =>
      {
          webBuilder.UseStartup<Startup>();
      })
      .ConfigureWebHost(config =>
      {
          config.UseUrls("http://*:9002");
      }).UseWindowsService();
    }
}

