using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNDD.domain.Repositories;

namespace TesteNdd.application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(query.Id);
            if (user == null)
            {
                throw new ArgumentException("Nao tem esse usuário");
            }
            var userViewModel = new UserViewModel(user.Nome, user.Sexo, user.Telefone, user.Email,user.DataNascimento, user.Observacao);
            return userViewModel;

        }
    }
}
