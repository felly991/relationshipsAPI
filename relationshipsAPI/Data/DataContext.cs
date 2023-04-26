using Microsoft.EntityFrameworkCore;
using relationshipsAPI.Models;

namespace relationshipsAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Character> characters { get; set; }
        public DbSet<Backpack> backpacks { get; set; }
        public DbSet<Weapon> weapons { get; set; }
        public DbSet<Faction> factions { get; set; }

    }
}
