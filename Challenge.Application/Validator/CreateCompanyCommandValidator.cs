using Challenge.Application.Commands.CreateCompany;
using FluentValidation;

namespace Challenge.Application.Validator
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório.")
                .MaximumLength(200)
                .WithMessage("Tamanho máximo do Nome é 200 caracteres");

            RuleFor(c => c.Cnpj)
                .NotEmpty()
                .NotNull()
                .MinimumLength(14)
                .MaximumLength(14)
                .WithMessage("CNPJ deve conter 14 caracteres.");
        }
    }
}
