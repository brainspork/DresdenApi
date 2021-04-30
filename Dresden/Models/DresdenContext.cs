using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Dresden.Models
{
    public class DresdenContext : DbContext
    {
        public DresdenContext(DbContextOptions options) : base(options) { }

        public DbSet<CharacterAspect> CharacterAspects { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterSkill> CharacterSkills { get; set; }
        public DbSet<CharacterStunt> CharacterStunts { get; set; }
        public DbSet<CharacterVersion> CharacterVersions { get; set; }
        public DbSet<Consequence> Consequences { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Stunt> Stunts { get; set; }
        public DbSet<TemporaryAspect> TemporaryAspects { get; set; }
        public DbSet<Trapping> Trappings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);

            #region Skills
            modelBuilder
                .Entity<Skill>()
                .HasMany(s => s.Trappings)
                .WithOne(t => t.Skill)
                .HasForeignKey(t => t.SkillId)
                
                .IsRequired();

            modelBuilder
                .Entity<Skill>()
                .HasMany(s => s.Stunts)
                .WithOne(st => st.Skill)
                .HasForeignKey(st => st.SkillId)
                
                .IsRequired();

            modelBuilder
                .Entity<Skill>()
                .HasMany<CharacterSkill>()
                .WithOne(cs => cs.Skill)
                .HasForeignKey(cs => cs.SkillId)
                
                .IsRequired();

            modelBuilder
                .Entity<Stunt>()
                .Property(s => s.RefreshCost)
                .HasDefaultValue(-1);

            modelBuilder
                .Entity<Stunt>()
                .HasMany<CharacterStunt>()
                .WithOne(cs => cs.Stunt)
                .HasForeignKey(cs => cs.StuntId)
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
            #endregion

            #region Character
            modelBuilder
                .Entity<Character>()
                .HasMany(c => c.CharacterVersions)
                .WithOne(cv => cv.Character)
                .HasForeignKey(cv => cv.CharacterId)
                
                .IsRequired();

            modelBuilder
                .Entity<Character>()
                .HasMany(c => c.Consequences)
                .WithOne(c => c.Character)
                .HasForeignKey(c => c.CharacterId)
                
                .IsRequired();

            modelBuilder
                .Entity<Character>()
                .HasMany(c => c.TemporaryAspects)
                .WithOne(ta => ta.Character)
                .HasForeignKey(ta => ta.CharacterId)
                
                .IsRequired();

            modelBuilder
                .Entity<CharacterVersion>()
                .HasMany(cv => cv.Aspects)
                .WithOne(ca => ca.CharacterVersion)
                .HasForeignKey(ca => ca.CharacterVersionId)
                
                .IsRequired();

            modelBuilder
                .Entity<CharacterVersion>()
                .HasMany(cv => cv.Skills)
                .WithOne(cs => cs.CharacterVersion)
                .HasForeignKey(cs => cs.CharacterVersionId)
                
                .IsRequired();

            modelBuilder
                .Entity<CharacterVersion>()
                .HasMany(cv => cv.Stunts)
                .WithOne(cs => cs.CharacterVersion)
                .HasForeignKey(cs => cs.CharacterVersionId)
                
                .IsRequired();

            modelBuilder
                .Entity<Character>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<CharacterVersion>()
                .Property(cv => cv.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<CharacterAspect>()
                .Property(ca => ca.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<CharacterSkill>()
                .Property(cs => cs.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<CharacterStunt>()
                .Property(cs => cs.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Consequence>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();

            modelBuilder
                .Entity<TemporaryAspect>()
                .Property(ta => ta.Id)
                .ValueGeneratedOnAdd();
            #endregion

            #region User
            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Characters)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                
                .IsRequired();

            modelBuilder
                .Entity<User>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();
            #endregion

            #region Game
            modelBuilder
                .Entity<Game>()
                .HasMany(g => g.PlayerCharacters)
                .WithMany(c => c.PlayerGames)
                .UsingEntity<Dictionary<string, object>>(
                    "GamePlayerCharacter",
                    gpc => gpc.HasOne<Character>().WithMany().HasForeignKey("CharacterId").OnDelete(DeleteBehavior.Restrict),
                    gpc => gpc.HasOne<Game>().WithMany().HasForeignKey("GameId").OnDelete(DeleteBehavior.Restrict)
                );

            modelBuilder
                .Entity<Game>()
                .HasMany(g => g.NonPlayerCharacters)
                .WithMany(c => c.NonPlayerGames)
                .UsingEntity<Dictionary<string, object>>(
                    "GameNonPlayerCharacter",
                    gpc => gpc.HasOne<Character>().WithMany().HasForeignKey("CharacterId").OnDelete(DeleteBehavior.Restrict),
                    gpc => gpc.HasOne<Game>().WithMany().HasForeignKey("GameId").OnDelete(DeleteBehavior.Restrict)
                );
            #endregion
        }
    }
}
