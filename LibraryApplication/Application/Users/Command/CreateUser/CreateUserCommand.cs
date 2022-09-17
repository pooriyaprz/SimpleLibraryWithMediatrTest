using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Users.Command.CreateUser
{
    public record CreateUserCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private  UserManager<ApplicationUser> _usermanager;

        public CreateUserCommandHandler(UserManager<ApplicationUser> usermanager)
        {
            _usermanager = usermanager;
        }
        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = new Domain.Entities.ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,

            };

            var res = await _usermanager.CreateAsync(entity, request.Password);

            if (res.Succeeded)
            {
                return entity.Id.ToString();
            }
            else
            {
                throw new Exception();
            }


        }

    }
}
