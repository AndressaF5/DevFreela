
using DevFreela.Application.Models;
using FluentValidation;

namespace DevFreela.Application.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserInputModel>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.Email)
                .EmailAddress()
                    .WithMessage("E-mail inválido.");

            RuleFor(u => u.BithDate)
                .Must(d => d < DateTime.Now.AddYears(-18))
                    .WithMessage("Deve ser maior de idade.");
        }
    }
}