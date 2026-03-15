using Backend.Domain.Models;
using Backend.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Backend.Application.Features.Users.CreateUsers;

public class CreateUserHandler(UserManager<ApplicationUser> manager) : IRequestHandler<CreateUserCommand, CreateUserResponse>
{
    public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var fullName = request.FullName.Trim();
        var email = request.Email.Trim();
        var username = request.Username.Trim();

        if (request.Password != request.ConfirmPassword)
        {
            throw new BadRequestException("Passwords do not match.");
        }

        var existingByEmail = await manager.FindByEmailAsync(email);
        if (existingByEmail is not null)
        {
            throw new BadRequestException("Email is already in use.");
        }

        var existingByUsername = await manager.FindByNameAsync(username);
        if (existingByUsername is not null)
        {
            throw new BadRequestException("Username is already in use.");
        }

        var user = new ApplicationUser
        {
            FullName = fullName,
            Email = email,
            UserName = username,
        };

        var result = await manager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(x => x.Description));
            throw new BadRequestException(errors);
        }

        return new CreateUserResponse(user.Id, "User created successfully.");
    }
}
