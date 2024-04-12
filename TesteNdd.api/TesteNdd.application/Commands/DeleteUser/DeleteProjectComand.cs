using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteNdd.application.Commands.DeleteUser
{
    public class DeleteProjectComand : IRequest
    {
        public DeleteProjectComand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
