using MediatR;
using TesteNDD.domain.Repositories;

namespace TesteNdd.application.Commands.User
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userCreated = new TesteNDD.domain.Entities.User(request.Nome, request.CPF, request.Sexo, request.Telefone, request.Email, request.DataNascimento, request.Observacao);
            await _userRepository.AddAsync(userCreated);
            Guid id = userCreated.Id;
            return id;

        }
    }
}
