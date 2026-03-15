namespace Backend.Api.Endpoints;

using Backend.Application.Features.Users.CreateUsers;
using MediatR;

public static class CreateUserEndpoint
{
    public static IEndpointRouteBuilder MapCreateUserEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/users", async (CreateUserCommand command, ISender sender, CancellationToken cancellationToken) =>
            {
                var result = await sender.Send(command, cancellationToken);
                return Results.Created($"/api/users/{result.UserId}", result);
            })
            .WithName("CreateUser")
            .WithTags("Users");

        return app;
    }
}
