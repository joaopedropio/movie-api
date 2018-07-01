using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Movie
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            var config = new Configurations();

            Database.Bootstrap(config.ConnectionString);

            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseUrls(config.URL)
                .Build();
        }
    }
}
