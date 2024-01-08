namespace Api
{
    public static class AppSettings
    {
        private static readonly IConfiguration _config;

        static AppSettings()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _config = builder.Build();
        }

        public static class Jwt
        {
            public static string Key = _config["Jwt:Key"];
            public static string Issuer = _config["Jwt:Issuer"];
        }
        
        public static class ConnectionStrings
        {
            public static string DefaultConnection = _config["ConnectionStrings:DefaultConnection"];
        }
    }
}