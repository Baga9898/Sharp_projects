using Microsoft.EntityFrameworkCore;

namespace MainAdiLink.Models
{
    public class WeblinksContext : DbContext
    {
        public DbSet<Weblink> Weblinks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public WeblinksContext(DbContextOptions<WeblinksContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
