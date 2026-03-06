using FluentValidation;

namespace Backend.Features.Users.CreateUsers;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .Length(2, 100).WithMessage("Full name must be between 2 and 100 characters.");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");
        
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .Length(3, 50).WithMessage("Username must be between 3 and 50 characters.");
        
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage("Passwords do not match.");
    }
}