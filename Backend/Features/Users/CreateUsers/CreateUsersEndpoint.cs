using MediatR;

namespace Backend.Features.Users.CreateUsers;

public static class CreateUsersEndpoint
{
    public static void CreateUser(this WebApplication app)
    {
        app.MapPost("/users", async (CreateUserCommand command, IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return Results.Created($"/users/{result}", new { message = "User Successfully Created", id = result });
        });
    }
}