using Backend.Domain.Exceptions;

namespace Backend.Api.Endpoints;

public static class TestExceptionHandlerEndpoint
{
    public static void ExceptionHandlerEndpoint(this WebApplication app)
    {
        app.MapGet("/500", async () =>
        {
            throw new Exception("Something went wrong on the server.");
        });
        
        app.MapGet("/404", async () =>
        {
            throw new NotFoundException("not found bro");
        });
        
        app.MapGet("/400", async () =>
        {
            throw new BadRequestException("bad request bro");
        });
        
        app.MapGet("/401", async () =>
        {
            throw new UnauthorizedException("unauthorized bro");
        });
    }
}