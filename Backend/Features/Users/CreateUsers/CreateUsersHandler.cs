using Backend.Domains;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Backend.Features.Users.CreateUsers;

public class CreateUsersHandler(UserManager<ApplicationUser> manager) : IRequestHandler<CreateUserCommand, string>
{
    
    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (request.Password != request.ConfirmPassword) throw new Exception("Password mismatched!");
        
        var user = new ApplicationUser()
        {
            FullName = request.FullName,
            Email = request.Email,
            UserName = request.Username,
        };
        var result = await manager.CreateAsync(user, request.Password);
        return user.Id.ToString();
    }
}