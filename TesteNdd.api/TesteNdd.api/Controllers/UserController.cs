using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using TesteNdd.application.Commands.DeleteUser;
using TesteNdd.application.Commands.UpdateUser;
using TesteNdd.application.Commands.User;
using TesteNdd.application.Queries.GetAllUsers;
using TesteNdd.application.Queries.GetUserById;

namespace TesteNdd.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var getAllProjectsQuery = await _mediator.Send(new GetAllUsersQuery());
            return Ok(getAllProjectsQuery);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserbyId(Guid id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));

            return Ok(user);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                var messages = ModelState.SelectMany(ms => ms.Value.Errors).Select(e => e.ErrorMessage).ToList(); 
                return BadRequest(messages);
            }
           
            var id = await _mediator.Send(command);
            //var user = GetUserbyId(id);
            //return Ok(user);
            return CreatedAtAction(nameof(GetUserbyId), new { id = id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateUserCommand UpdateUser)
        {

            var command = new UpdateUserCommand(id, UpdateUser.Telefone, UpdateUser.Email, UpdateUser.Observacao);

            await _mediator.Send(command);

            return NoContent();

        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProjectComand(id);
            await _mediator.Send(command);
            return NoContent();

        }



    }
}
