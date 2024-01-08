using Api.Application.Dto;
using Api.Application.Sql;
using Api.Domain.Specifications;
using Api.Helper;
using Api.Infrastructure.Shared;

namespace Api.Application.Commands
{
    public interface ISignUpUserCommand
    {
        Result<Unit> Handle(IUserSignUpDto userDto);
    }

    public class SignUpUserCommand : ISignUpUserCommand
    {
        private readonly ITrustAccessDb _trustAccessDb;
        private readonly ILogger<SignUpUserCommand> _logger;
        public SignUpUserCommand(
            ITrustAccessDb trustAccessDb,
            ILogger<SignUpUserCommand> logger)
        {
            _trustAccessDb = trustAccessDb;
            _logger = logger;
        }
            
        // TODO: check user email is not in db/ simple better error message
            // transaction scope...
        // TODO: extend the error handling into the _db savedata function...
        public Result<Unit> Handle(IUserSignUpDto userDto)
        {
            var isValidUserEmail = ValidUserEmailSpecification.IsSatisfiedBy(userDto.Email);
            if(isValidUserEmail.IsErr())
            {
                _logger.LogWarning("SignUpUserCommand - {err}", isValidUserEmail);
                return isValidUserEmail;
            }

            var isValidUserPassword = ValidUserPasswordSpecification
                .IsSatisfiedBy(userDto.Password);
            if (isValidUserPassword.IsErr())
            {
                _logger.LogWarning("SignUpUserCommand - {err}", isValidUserPassword);
                return isValidUserPassword;
            }

            return _trustAccessDb.SaveData(
                REGISTER_USER.value, 
                new 
                { 
                    userDto.Email, 
                    passwordHash = PasswordHasher.Hash(userDto.Password)
                })
                .Result;
        }
    }
}