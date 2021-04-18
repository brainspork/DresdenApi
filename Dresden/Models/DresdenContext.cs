using Microsoft.EntityFrameworkCore;

namespace Dresden.Models
{
    public class DresdenContext : DbContext
    {
        public DresdenContext(DbContextOptions options) : base(options) { }

        public DbSet<Skill> Skills { get; set; }
        public DbSet<Trapping> Trappings { get; set; }
        public DbSet<Stunt> Stunts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Skill>()
                .HasMany(s => s.Trappings)
                .WithOne(t => t.Skill)
                .IsRequired();

            modelBuilder
                .Entity<Skill>()
                .HasMany(s => s.Stunts)
                .WithOne(t => t.Skill)
                .IsRequired();

            modelBuilder
                .Entity<Skill>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Trapping>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Stunt>()
                .Property(s => s.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
