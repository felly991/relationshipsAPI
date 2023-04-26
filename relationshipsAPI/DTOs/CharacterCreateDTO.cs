namespace relationshipsAPI.DTOs
{
    public class CharacterCreateDTO
    {
        public string Name { get; set; }
        public BackpackCreateDTO Backpack { get; set; }
        public List<WeaponCreateDTO> Weapons { get; set; }
        public List<FactionCreateDTO> Factions { get; set; }
    }
}
