using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using relationshipsAPI.Data;
using relationshipsAPI.DTOs;
using relationshipsAPI.Interface;
using relationshipsAPI.Models;

namespace relationshipsAPI.Controller
{
    public class CharacterActions : ICharacterActions
    {
        private readonly DataContext _context;

        public CharacterActions(DataContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<Character>> CreateCharacter(CharacterCreateDTO createDTO)
        {
            var newCharacter = new Character()
            {
                Name = createDTO.Name,

            };
            var backpack = new Backpack
            {
                Description = createDTO.Backpack.Description,
                Character = newCharacter
            };
            var weapons = createDTO.Weapons.Select(w => new Weapon
            {
                Name = w.Name,
                Character = newCharacter
            }).ToList();
            var factions = createDTO.Factions.Select(f => new Faction
            {
                Name = f.Name,
                Characters = new List<Character> { newCharacter }
            }).ToList();

            newCharacter.Backpack = backpack;
            newCharacter.Weapons = weapons;
            newCharacter.Factions = factions;

            _context.characters.Add(newCharacter);
            await _context.SaveChangesAsync();

            return newCharacter;

        }

        public async Task<ActionResult<Character>> GetSingleCharacter(int id)
        {
            var character = await _context.characters.Include(b => b.Backpack)
                .Include(b => b.Weapons).Include(f => f.Factions)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (character == null)
            {
                return null;
            }

            return character;
        }

        public async Task<ActionResult<List<Character>>> DeleteCharacter(int id)
        {
            var character = await _context.characters.FindAsync(id);
            if (character == null)
            {
                return null;
            }
            _context.characters.Remove(character);
            await _context.SaveChangesAsync();

            return _context.characters.Include(b => b.Backpack)
                .Include(w => w.Weapons).Include(f => f.Factions)
                .ToList();
            

        }
    }
}
