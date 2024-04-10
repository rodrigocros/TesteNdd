using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteNdd.application.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserViewModel>
    {
        public UpdateUserCommand(Guid id, string telefone, string email, string observacao)
        {
            Id = id;
            Telefone = telefone;
            Email = email;
            Observacao = observacao;
        }

        public Guid Id { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Observacao { get; set; }
    }
}
