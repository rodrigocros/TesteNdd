using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNDD.domain.Repositories;

namespace TesteNdd.application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserViewModel>
    {
        private readonly IUserRepository _userRepoisitory;

        public UpdateUserCommandHandler(IUserRepository userRepoisitory)
        {
            _userRepoisitory = userRepoisitory;
        }

        public async Task<UserViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepoisitory.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new ArgumentException("Usuário nao existe nao existe");
            }
            user.Update(request.Telefone, request.Email, request.Observacao);
            await _userRepoisitory.SaveChangesAsync();

            UserViewModel userView = new UserViewModel(user.Nome, user.Sexo, user.Telefone, user.Email, user.DataNascimento, user.Observacao);
            return userView;
            
            
          
        }
    }
 
}
