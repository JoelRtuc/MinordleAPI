using Microsoft.EntityFrameworkCore;

namespace MinordleAPI.Data;

public class MinordleDbContext(DbContextOptions<MinordleDbContext> options) : DbContext(options)
{
    public DbSet<LanguageBase> Languages => Set<LanguageBase>();
    public DbSet<User> Users => Set<User>();
}
