using System.Text.RegularExpressions;
using Api.Helper;
using Serilog;

namespace Api.Domain.Specifications
{
    public static class ValidUserPasswordSpecification
    {
        private static readonly ILoggerFactory _loggerFactory = new LoggerFactory()
            .AddSerilog();
        private static readonly Microsoft.Extensions.Logging.ILogger _logger = _loggerFactory.CreateLogger<Program>();
        
        public static Result<Unit> IsSatisfiedBy(string password)
        {
            _logger.LogInformation("ValidUserPasswordSpecification");

            var UppercasePattern = "(?=.*[A-Z])";
            var DigitPattern = "(?=.*\\d)";
            var LengthPattern = ".{8,}";
            var SpecialCharPattern = "[!@#$%^&*()_]";
     
            if(!Regex.IsMatch(password, UppercasePattern)) {
                _logger.LogInformation("Error - ValidUserPasswordSpecification - UppercasePattern");
                return Result<Unit>.Err("Error - ValidUserPasswordSpecification - UppercasePattern");
            } else if(!Regex.IsMatch(password, DigitPattern)) {
                _logger.LogInformation("Error - ValidUserPasswordSpecification - DigitPattern");
                return Result<Unit>.Err("Error - ValidUserPasswordSpecification - DigitPattern");
            } else if(!Regex.IsMatch(password, LengthPattern)) {
                _logger.LogInformation("Error - ValidUserPasswordSpecification - LengthPattern");
                return Result<Unit>.Err("Error - ValidUserPasswordSpecification - LengthPattern");
            } else if(!Regex.IsMatch(password, SpecialCharPattern)) {
                _logger.LogInformation("Error - ValidUserPasswordSpecification - SpecialCharPattern");
                return Result<Unit>.Err("Error - ValidUserPasswordSpecification - SpecialCharPattern");
            }

            _logger.LogInformation("True");
            return Result<Unit>.Ok(Unit.New);
        }
    }
}