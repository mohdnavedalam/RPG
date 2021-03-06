using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RPG.Dtos.Character;
using RPG.Models;
using RPG.Services.CharacterService;

namespace RPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        //[Route("GetAll")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            //return Ok(characters[0]);
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            //return Ok(await _characterService.UpdateCharacter(updatedCharacter));

            ServiceResponse<GetCharacterDto> serviceResponse = await _characterService.UpdateCharacter(updatedCharacter);
            if (serviceResponse.Data == null)
                return NotFound(serviceResponse);
            return Ok(serviceResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = await _characterService.DeleteCharacter(id);
            if (serviceResponse.Data == null)
                return NotFound(serviceResponse);
            return Ok(serviceResponse);
        }
    }
}