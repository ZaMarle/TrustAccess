using Api.Application.Commands;
using Api.Application.Dto;
using Api.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ISignUpUserCommand _signUpUserCommand;
        private readonly IAuthenticateUserCommand _authenticateUserCommand;
        private readonly ILogger<UsersController> _logger;
        
        public UsersController(
            ISignUpUserCommand signUpUserCommand,
            IAuthenticateUserCommand authenticateUserCommand,
            ILogger<UsersController> logger)
        {
            _signUpUserCommand = signUpUserCommand;
            _authenticateUserCommand = authenticateUserCommand;
            _logger = logger;
        }

        [HttpPost("SignUp")]
        public ActionResult SignUp([FromBody] IUserSignUpDto userDto)
        {
            return _signUpUserCommand.Handle(userDto)
                .Match<ActionResult>(
                    ok: _ => Ok(),
                    err: BadRequest
                );
        }

        [HttpPost("SignIn")]
        public ActionResult SignIn([FromBody] IUserSignInDto userDto)
        {
            return _authenticateUserCommand.Handle(userDto)
                .Match<ActionResult>(
                    ok: user => 
                    {
                        _logger.LogInformation("Successful user authentication");
                        var jwt = JwtProvider.GenerateToken(user.Id);
                        return Ok(jwt);
                    },
                    err: error => 
                    {
                        _logger.LogError(error);
                        return BadRequest();
                    }
                );
        }
    }
}