using DrumWebshop.Models;
using Microsoft.EntityFrameworkCore;

namespace DrumWebshop.Data
{
    public class DrumContext: DbContext
    {
        public DrumContext(DbContextOptions<DrumContext> options) : base(options)
        {
        }

        public DbSet<Snare> Snares { get; set; }
        public DbSet<Shell> Shells { get; set; }
        public DbSet<Cymbal> Cymbals { get; set; }
        public DbSet<Hardware> Hardware { get; set; }
        public DbSet<HwComponent> HwComponents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hardware>()
                .OwnsMany(h => h.HwComponents); // Configure HwComponents as a complex type owned by Hardware
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DrumWebshop;Integrated Security=True;");
        }
    }
}
