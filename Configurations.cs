using Microsoft.Extensions.Configuration;

namespace Movie
{
    public class Configurations
    {
        public string Port { get; private set; }
        public string Domain { get; private set; }
        public string URL { get; private set; }
        public string ConnectionString { get; private set; }

        public Configurations() : this(new ConfigurationBuilder().AddEnvironmentVariables().Build()) { }

        public Configurations(IConfigurationRoot configuration)
        {
            this.ConnectionString = configuration.GetValue<string>("CONNECTION_STRING");
            this.Domain = configuration.GetValue<string>("API_DOMAIN") ?? "*";
            this.Port = configuration.GetValue<string>("API_PORT") ?? "5000";
            this.URL = string.Format($"http://{this.Domain}:{this.Port}");
        }
    }
}
