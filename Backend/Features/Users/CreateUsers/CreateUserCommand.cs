using MediatR;

namespace Backend.Features.Users.CreateUsers;

public record CreateUserCommand(string FullName,
    string Email,
    string Username,
    string Password,
    string ConfirmPassword
) : IRequest<string>;