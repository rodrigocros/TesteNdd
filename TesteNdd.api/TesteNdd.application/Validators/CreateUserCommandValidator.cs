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
            RuleFor(p => p.Nome).NotEmpty().NotNull().WithMessage("Nome é obrigatório");
            RuleFor(p => p.Telefone).NotEmpty().NotNull().WithMessage("Telefone é obrigatório");
            RuleFor(p => p.Sexo).NotEmpty().NotNull().WithMessage("Sexo é obrigatório");
            RuleFor(p => p.DataNascimento).NotEmpty().NotNull().WithMessage("Data de Nascimento obrigatória");
            RuleFor(p => p.Email).NotEmpty().NotNull().EmailAddress().WithMessage("Email nao válido");
            RuleFor(p => p.CPF).NotEmpty().NotNull().Length(0, 11);

        }

        //public bool cPFisValid(string cpf)
        //{
        //    var regex = new Regex(@"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}");

        //    return regex.IsMatch(cpf);
        //}
    }
}
