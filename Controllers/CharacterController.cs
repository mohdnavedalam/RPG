using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RPG.Models;

namespace RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            //new Character{Name = "Sam"}
            new Character{ID = 1, Name = "Sam"}
        };

        //[Route("GetAll")]
        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public IActionResult GetSingle(int id)
        {
            //return Ok(characters[0]);
            return Ok(characters.FirstOrDefault(c => c.ID == id));
        }
    }
}