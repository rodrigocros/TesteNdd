using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNdd.infrastructure.Persistence;
using TesteNDD.domain.Repositories;

namespace TesteNdd.application.Queries.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly TesteNddContext _testeNddContext;

        public GetAllUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetAllAsync();
            var usersViewModel = dbUser.Select(x => new UserViewModel(x.Nome, x.Sexo, x.Telefone, x.Email, x.DataNascimento, x.Observacao)).ToList();
            return usersViewModel;
        }
    }
}
