using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteNdd.application.Commands.User
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Observacao { get; set; }
    }
}
