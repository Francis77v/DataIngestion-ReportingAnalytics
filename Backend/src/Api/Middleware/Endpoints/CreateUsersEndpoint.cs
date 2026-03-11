using Backend.Domain.Exceptions;


namespace Backend.Api.Middleware.Endpoints;

public static class CreateUsersEndpoint
{
    public static void CreateUser(this WebApplication app)
    {
        app.MapGet("/users", async () =>
        {
            throw new NotFoundException("Not Found bro");
        });
        
        app.MapGet("/u", async () =>
        {
            throw new BadRequestException("bad request bro");
        });
    }
}