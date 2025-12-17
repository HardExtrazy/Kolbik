using Kolbik.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Kolbik.UI
{
    public class TempContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public TempContext(DbContextOptions<TempContext> opt) : base(opt)
        {
        }
    }
}
