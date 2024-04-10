using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TesteNdd.Entity;

namespace TesteNdd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllHeroes()
        {
            var heroes = new List<Superhero>
            {
                new Superhero
                {   Id = 1,
                    Name = "Rodrigo",
                    Description = "teste"
                }

            };
            return Ok(heroes);

        }
    }
}
