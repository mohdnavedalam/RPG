using Microsoft.AspNetCore.Mvc;
using RPG.Models;

namespace RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static Character knight = new Character();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(knight);
        }
    }
}