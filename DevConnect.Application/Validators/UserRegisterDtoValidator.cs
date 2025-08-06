
using FluentValidation;

public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
{
    public UserRegisterDtoValidator()
    {
        RuleFor(x => x.Email)
        .NotEmpty().WithMessage("Email is requerid")
        .EmailAddress().WithMessage("Email adress format is invalid");

        RuleFor(x => x.Password)
        .NotEmpty().WithMessage("Password is requeried")
        .MinimumLength(8).WithMessage("Password must be at least 8 characters")
        .Matches(@"[A-Z]+").WithMessage("Your Password must contain at least one upper case, one lower case, one number")
        .Matches(@"[a\a-z]+").WithMessage("Your Password must contain at least one upper case, one lower case, one number")
        .Matches(@"[0-9]+").WithMessage("Your Password must contain at least one upper case, one lower case, one number");
    }
}