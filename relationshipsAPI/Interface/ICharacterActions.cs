using Microsoft.AspNetCore.Mvc;
using relationshipsAPI.DTOs;
using relationshipsAPI.Models;

namespace relationshipsAPI.Interface
{
    public interface ICharacterActions
    {
        public Task<ActionResult<Character>> CreateCharacter(CharacterCreateDTO createDTO);
        public Task<ActionResult<Character>> GetSingleCharacter(int id);
        public Task<ActionResult<List<Character>>> DeleteCharacter(int id);
    }
}
