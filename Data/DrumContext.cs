using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DrumWebshop.Models;

namespace DrumWebshop.Data
{
    public class DrumContext: IdentityDbContext<IdentityUser>
    {
        public DrumContext(DbContextOptions<DrumContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Snare> Snares { get; set; }
        public DbSet<Shell> Shells { get; set; }
        public DbSet<Cymbal> Cymbals { get; set; }
        public DbSet<Hardware> Hardware { get; set; }
        public DbSet<HwComponent> HwComponents { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Hardware>()
                .OwnsMany(h => h.HwComponents); // Configure HwComponents as a complex type owned by Hardware

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(l => new { l.LoginProvider, l.ProviderKey });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DrumWebshop;Integrated Security=True;");
        }
    }
}
