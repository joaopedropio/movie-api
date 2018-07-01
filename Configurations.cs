using Microsoft.Extensions.Configuration;

namespace Movie
{
    public class Configurations
    {
        public string Port { get; private set; }
        public string Domain { get; private set; }
        public string URL { get; private set; }
        public string DBServer { get; private set; }
        public string DBName { get; private set; }
        public string DBUser { get; private set; }
        public string DBPass { get; private set; }
        public string ConnectionString { get; set; }

        public Configurations() : this(new ConfigurationBuilder().AddEnvironmentVariables().Build()) { }

        public Configurations(IConfigurationRoot configuration)
        {
            Domain = configuration.GetValue<string>("API_DOMAIN") ?? "*";
            Port = configuration.GetValue<string>("API_PORT") ?? "80";
            URL = string.Format($"http://{this.Domain}:{this.Port}");
            DBServer = configuration.GetValue<string>("DB_SERVER") ?? "mysql";
            DBName = configuration.GetValue<string>("DB_NAME") ?? "Movies";
            DBUser = configuration.GetValue<string>("DB_USER") ?? "movieapi";
            DBPass = configuration.GetValue<string>("DB_PASS") ?? "movieapi1234";
            ConnectionString = $"Server={DBServer};Database={DBName};Uid={DBUser};Pwd={DBPass};";
        }
    }
}
