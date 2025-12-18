using Microsoft.EntityFrameworkCore;
using Kolbik.Domain.Entities;

namespace Kolbik.API.Data;

public class AppDbContext: DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Author { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt)
    {
        
    }
}
