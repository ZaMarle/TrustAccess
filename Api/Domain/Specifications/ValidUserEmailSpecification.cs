using System.Text.RegularExpressions;
using Api.Helper;
using Serilog;

namespace Api.Domain.Specifications
{
    public static class ValidUserEmailSpecification
    {
        private static readonly ILoggerFactory _loggerFactory = new LoggerFactory()
            .AddSerilog();
        private static readonly Microsoft.Extensions.Logging.ILogger _logger = _loggerFactory.CreateLogger<Program>();
        
        public static Result<Unit> IsSatisfiedBy(string email)
        {
            _logger.LogInformation("ValidUserEmailSpecification");
            var EmailPattern = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$";

            if(!Regex.IsMatch(email, EmailPattern)) {
                _logger.LogInformation("False");
                return Result<Unit>.Err("Invalid email address");
            } 
            
            _logger.LogInformation("True");
            return Result<Unit>.Ok(Unit.New);
        }
    }
}