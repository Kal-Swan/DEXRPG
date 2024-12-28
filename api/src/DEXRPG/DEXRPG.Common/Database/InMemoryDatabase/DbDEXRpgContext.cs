using DEXRPG.Common.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DEXRPG.Common.Database.InMemoryDatabase;

public class DbDexRpgContext : DbContext
{
    public DbDexRpgContext(DbContextOptions<DbDexRpgContext> options) : base(options)
    {
    }
    
    public DbSet<Character> Characters { get; set; }
}