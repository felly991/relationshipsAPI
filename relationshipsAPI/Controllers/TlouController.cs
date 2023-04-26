using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relationshipsAPI.Data;
using relationshipsAPI.DTOs;
using relationshipsAPI.Interface;
using relationshipsAPI.Models;

namespace relationshipsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TlouController : ControllerBase
    {
        private readonly ICharacterActions _characterActions;

        public TlouController(ICharacterActions characterActions)
        {
            _characterActions = characterActions;
        }

        [HttpPost]
        public async Task<ActionResult<Character>> CreateCharacter(CharacterCreateDTO characterCreateDTO)
        {
            return await _characterActions.CreateCharacter(characterCreateDTO);
        }

        [HttpGet("id")]
        public async Task<ActionResult<Character>> GetCharacterById(int id)
        {
            var character = await _characterActions.GetSingleCharacter(id);
            if(character == null)
            {
                return NotFound("Character not found");
            }
            else
            {
                return Ok(character);
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<List<Character>>> DeleteCharacter(int id)
        {
            var character = await _characterActions.DeleteCharacter(id);
            if(character == null )
            {
                return NotFound("Character not found");
            }
            else
            {
                return character;
            }
        }

    }
}
