using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNDD.domain.Entities;

namespace TesteNdd.UnitTests.Domain.Entity.UserTests
{
 
    public class UserTest
    {
        [Fact]
        public void TestIfUserWorks()
        {
            var user = new User("Rodrigo", "005.339.502-53", "Masculino", "999999999", "teste@gmail.com", new DateTime(1990,5,5) ,"teste");
            Assert.NotNull(user);

            Assert.NotEmpty(user.CPF);
        }
    }
}
