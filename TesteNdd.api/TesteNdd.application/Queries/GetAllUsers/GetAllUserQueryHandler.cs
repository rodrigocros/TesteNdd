using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNdd.application.ViewModel;
using TesteNdd.infrastructure.Persistence;
using TesteNDD.domain.Repositories;

namespace TesteNdd.application.Queries.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserViewModel>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var dbUser = await _userRepository.GetAllAsync();
            var usersViewModel = dbUser.Select(x => _mapper.Map<UserViewModel>(x)).ToList();
            return usersViewModel;
        }
    }
}
