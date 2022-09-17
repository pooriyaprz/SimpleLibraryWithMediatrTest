using Application.Common.Models;
using Application.Users.Command.CreateUser;
using Application.Users.Command.SignIn;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<string>> Create(CreateUserCommand command)
        {
            return await Mediator.Send(command);
        }
        [HttpPost("signIn")]
        public async Task<ActionResult<TokenObJ>> SignIn(SignInCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}
