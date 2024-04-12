using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteNdd.application.ViewModel;

namespace TesteNdd.application.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserViewModel>>
    {


    }
}
