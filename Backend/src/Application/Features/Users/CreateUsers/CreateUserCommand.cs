using MediatR;

namespace Backend.Application.Features.Users.CreateUsers;

public record CreateUserCommand(string FullName,
    string Email,
    string Username,
    string Password,
    string ConfirmPassword
) : IRequest<CreateUserResponse>;
