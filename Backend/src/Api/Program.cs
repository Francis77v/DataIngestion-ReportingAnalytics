using Backend.Api.Endpoints;
using Backend.Api.Middleware;
using Backend.Api.Middleware.ExceptionHandlerMiddleware;
using Backend.Application.Features.Users.CreateUsers;
using Backend.Domain.Models;
using Backend.Infrastructure.Context;
using FluentValidation;
using MediatR;
using Scalar.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Console.WriteLine("Environment: " + builder.Environment.EnvironmentName);
Console.WriteLine("ContentRoot: " + builder.Environment.ContentRootPath);
Console.WriteLine("ConnectionString: " + builder.Configuration.GetConnectionString("DefaultConnection"));
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                       ?? throw new InvalidOperationException("Connection string"
                                                              + "'DefaultConnection' not found.");

builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseNpgsql(connectionString));


builder.Services.AddAuthorization();

//REGISTER IDENTITY
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<MyDbContext>()
    .AddDefaultTokenProviders();

//REGISTER MEDIATR
builder.Services.AddMediatR(cfg => 
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

//REGISTER FLUENT VALIDATION + MEDIATR VALIDATION PIPELINE
builder.Services.AddTransient<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

//register exception handler
builder.Services.AddExceptionHandler<BadRequestExceptionHandler>();
builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
builder.Services.AddExceptionHandler<UnauthorizedExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler();

//Endpoints
app.ExceptionHandlerEndpoint();
app.MapCreateUserEndpoint();

app.Run();
