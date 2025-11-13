using EFilmStore.Models;
using Microsoft.EntityFrameworkCore;

namespace EFilmStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        base.OnModelCreating(modelBuilder);
        
        // Fix the decimal precision warning
        modelBuilder.Entity<Film>()
            .Property(f => f.Price)
            .HasPrecision(18, 2); // 18 total digits, 2 decimal places
    }
        public DbSet<Film> Films { get; set; }
        public DbSet<Director> Directors { get; set; }
    }
    
}
