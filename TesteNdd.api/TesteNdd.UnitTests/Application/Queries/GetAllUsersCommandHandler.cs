using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNdd.api.Controllers;
using TesteNdd.application.Commands.User;
using TesteNdd.application.Profiles;
using TesteNdd.application.Queries.GetAllUsers;
using TesteNdd.application.ViewModel;
using TesteNDD.domain.Entities;
using TesteNDD.domain.Repositories;

namespace TesteNdd.UnitTests.Application.Queries
{
    public class GetAllUsersCommandHandler
    {
        private readonly IMapper _mapper;
        public GetAllUsersCommandHandler()
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new UserProfile());
            });
            
            _mapper = config.CreateMapper();
        }


        [Fact]
        public async void IfComandHandlerWorksWithAutomaper()
        {

            //Arrange
            var users = new List<User>()
            {
                new User("Rodrigo1", "005.339.502-53", "Masculino", "999999999", "teste@gmail.com", new DateTime(1990,5,5) ,"teste"),
                new User("Rodrigo2", "005.339.502-53", "Masculino", "999999999", "teste@gmail.com", new DateTime(1990,5,5) ,"teste"),
                new User("Rodrigo3", "005.339.502-53", "Masculino", "999999999", "teste@gmail.com", new DateTime(1990,5,5) ,"teste"),
            };

            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(pr => pr.GetAllAsync()).ReturnsAsync(users);

            var getAllUsersQuery = new GetAllUsersQuery();
            var getAllUsersQueryHandler = new GetAllUserQueryHandler(userRepositoryMock.Object, _mapper);

            //Act

            var UserViewModelList = await getAllUsersQueryHandler.Handle(getAllUsersQuery, new CancellationToken());

            //Assert

            Assert.NotNull(UserViewModelList);
            userRepositoryMock.Verify(u => u.GetAllAsync().Result, Times.Once);
        }
    }
}
