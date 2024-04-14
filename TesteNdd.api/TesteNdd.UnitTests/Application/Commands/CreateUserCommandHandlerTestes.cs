using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNdd.application.Commands.User;
using TesteNDD.domain.Entities;
using TesteNDD.domain.Repositories;

namespace TesteNdd.UnitTests.Application.Commands
{
    public class CreateUserCommandHandlerTestes
    {

        [Fact]
        public async void AddAsyncTeste_Execute() 
        {
            //Arrange
            var userRepository = new Mock<IUserRepository>();

            var createUserCommandHandler = new CreateUserCommandHandler(userRepository.Object);

            var createUserCommand = new CreateUserCommand()
            {
                Nome = "Rodrigo",
                CPF = "22222222222",
                Sexo = "Masculino",
                Email = "teste@gmail.com",
                Telefone = "999999999",
                DataNascimento = new DateTime(1990, 05, 11),
                Observacao = "obs"

            };
            // Act
            var id = await createUserCommandHandler.Handle(createUserCommand, new CancellationToken());

            //Assert
            userRepository.Verify(u => u.AddAsync(It.IsAny<User>()), Times.Once);

        }
    }
}
