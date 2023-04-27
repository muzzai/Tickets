using CustomerService.Auth.DTO;
using FluentValidation;

namespace CustomerService.Auth.Validators;

/// <summary>
/// Validator for AuthRequest
/// </summary>
internal sealed class AuthRequestValidator : AbstractValidator<AuthRequest>
{
  public AuthRequestValidator()
  {
    RuleFor(request => request.Login).NotEmpty();
    RuleFor(request => request.Password).NotEmpty().MinimumLength(6);
  }
}
