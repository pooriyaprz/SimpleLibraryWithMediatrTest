using Application.Common.Interfaces;
using Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Command.SignIn
{
    public record SignInCommand : IRequest<TokenObJ>
    {
        public string Email { get; init; }
        public string Password { get; init; }
    }
    public class SignInCommandHandler : IRequestHandler<SignInCommand, TokenObJ>
    {
        private SignInManager<Domain.Entities.ApplicationUser> signInManager;
        private UserManager<Domain.Entities.ApplicationUser> userManager;
        private readonly IApplicationDbContext _dbContext;
        private readonly string key;
        private readonly ITokenService tokenService;
        public SignInCommandHandler(SignInManager<Domain.Entities.ApplicationUser> signInManager, ITokenService tokenService, IApplicationDbContext dbContext, UserManager<Domain.Entities.ApplicationUser> userManager)
        {



            this.signInManager = signInManager;
            this.tokenService = tokenService;
            _dbContext = dbContext;
            this.userManager = userManager;
        }
        public async Task<TokenObJ> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.AspNetUsers.FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null)
            {
                //throw new NotFoundException("User not found!");
            }
            var result = await signInManager.PasswordSignInAsync(user, request.Password, true, false);
            if (result.Succeeded)
            {
                var token=  await tokenService.DoAuthenticate(user);
                //string curTime = ((((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds() * 1000).ToString());
                //await userManager.SetAuthenticationTokenAsync(user, "Default", "RefreshToken", token.RefreshTokenKey);

                //await userManager.AddLoginAsync(user, new UserLoginInfo(curTime, "", token.RefreshTokenKey));
               

                return token;
            }
            else
            {
                throw new Exception();
            }
        }

    }
}
