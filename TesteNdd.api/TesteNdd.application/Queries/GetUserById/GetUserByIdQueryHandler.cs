using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNdd.application.ViewModel;
using TesteNDD.domain.Repositories;

namespace TesteNdd.application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(query.Id);
            if (user == null)
            {
                throw new ArgumentException("Usuário nao existe");
            }

            var userViewModel = _mapper.Map<UserViewModel>(user);
                //new UserViewModel(user.Nome, user.Sexo, user.Telefone, user.Email,user.DataNascimento, user.Observacao);
            return userViewModel;

        }
    }
}
