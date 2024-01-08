using Api.Application.Dto;
using Api.Helper;
using Api.Infrastructure.Shared;
using Api.Infrastructure.Sql;

namespace Api.Application.Commands
{
    public interface IAuthenticateUserCommand
    {
        Result<ICredentialedUserDto> Handle(IUserSignInDto userDto);
    }

    public class AuthenticateUserCommand : IAuthenticateUserCommand
    {
        private readonly ITrustAccessDb _trustAccessDb;
        private readonly ILogger<AuthenticateUserCommand> _logger;
        public AuthenticateUserCommand(
            ITrustAccessDb trustAccessDb,
            ILogger<AuthenticateUserCommand> logger)
        {
            _trustAccessDb = trustAccessDb;
            _logger = logger;
        }

        public Result<ICredentialedUserDto> Handle(IUserSignInDto userDto)
        {
            _logger.LogInformation("Handle sign in user");
            
            try
            {
                ICredentialedUserDto? user = _trustAccessDb
                    .LoadData<GET_USER_BY_CREDENTIALS_props, ICredentialedUserDto>(
                            GET_USER_BY_CREDENTIALS.value,
                            new GET_USER_BY_CREDENTIALS_props(
                                userDto.Email, 
                                PasswordHasher.Hash(userDto.Password)))
                    .Result
                    .FirstOrDefault();

                return user != null 
                    ? Result<ICredentialedUserDto>.Ok(user)
                    : Result<ICredentialedUserDto>.Err("No user found matching credentials.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return Result<ICredentialedUserDto>.Err(ex.Message);
            }
        }
    }
}