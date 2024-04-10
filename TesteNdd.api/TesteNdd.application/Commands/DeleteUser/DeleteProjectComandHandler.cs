using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNDD.domain.Repositories;

namespace TesteNdd.application.Commands.DeleteUser
{
    public class DeleteProjectComandHandler : IRequestHandler<DeleteProjectComand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteProjectComandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteProjectComand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new Exception("Usuario nao existe");
            }
            await _userRepository.DeleteAsync(user.Id);

        }
    }
}
