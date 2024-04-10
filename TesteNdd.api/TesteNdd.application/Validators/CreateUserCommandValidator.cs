using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TesteNdd.application.Commands.User;

namespace TesteNdd.application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(p => p.Nome).NotEmpty().NotNull().WithMessage("Nome e obrigatorio");
            RuleFor(p => p.Telefone).NotEmpty().NotNull().WithMessage("Telefone e obrigatorio");
            RuleFor(p => p.Sexo).NotEmpty().NotNull().WithMessage("Sexo e obrigatorio");
            RuleFor(p => p.DataNascimento).NotEmpty().NotNull().WithMessage("Data de Nascimento obrigatoria");
            RuleFor(p => p.Email).NotEmpty().NotNull().EmailAddress().WithMessage("Email nao valido");
            RuleFor(p => p.CPF).NotEmpty().NotNull().Must(cPFisValid).WithMessage("CPF nao valido");

        }

        public bool cPFisValid(string cpf)
        {
            var regex = new Regex(@"^\d{2}.\d{3}.\d{3}/\d{4}-\d{2}$");

            return regex.IsMatch(cpf);
        }
    }
}
