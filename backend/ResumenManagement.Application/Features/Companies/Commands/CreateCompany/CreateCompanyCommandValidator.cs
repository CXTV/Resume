using FluentValidation;


namespace ResumenManagement.Application.Features.Companies.Commands.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Size)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .IsInEnum().WithMessage("{PropertyName} must be a valid CompanySize value.")
                .NotNull();
        }
    }
}
