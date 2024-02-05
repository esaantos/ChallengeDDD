using Challenge.Application.Commands.UpdateAssociate;
using FluentValidation;

namespace Challenge.Application.Validator
{
    public class UpdateAssociateCommandValidator : AbstractValidator<UpdateAssociateCommand>
    {
        public UpdateAssociateCommandValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome é obrigatório.")
                .MaximumLength(200)
                .WithMessage("Tamanho máximo do Nome é 200 caracteres");

            RuleFor(a => a.Cpf)
                .NotEmpty()
                .NotNull()
                .MinimumLength(11)
                .MaximumLength(11)
                .WithMessage("CPF deve conter 11 caracteres.");

            RuleFor(a => a.DateBirth)
                .NotEmpty()
                .NotNull();
        }
    }
}
