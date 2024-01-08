using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Infrastructure.Tables;
using Serilog;

namespace Api.Infrastructure.Sql
{
    public class GET_USER_BY_CREDENTIALS
    {
        public static readonly string value = $@"
            SELECT 1
            FROM Users
            WHERE {UsersTableDefinition.Email} = @Email
            AND {UsersTableDefinition.PasswordHash} = @PasswordHash
        ";
    }

    public record GET_USER_BY_CREDENTIALS_props
    {
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        private static readonly ILoggerFactory _loggerFactory = new LoggerFactory()
            .AddSerilog(); // Add Serilog as the logging provider
        private static readonly Microsoft.Extensions.Logging.ILogger _logger = _loggerFactory.CreateLogger<Program>();

        public GET_USER_BY_CREDENTIALS_props(string email, byte[] passwordHash)
        {
            _logger.LogInformation("Initiating new user");

            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
