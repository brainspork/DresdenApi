// <auto-generated />
using System;
using Dresden.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dresden.Migrations
{
    [DbContext(typeof(DresdenContext))]
    [Migration("20210509014715_AddStressCategory")]
    partial class AddStressCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dresden.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<int?>("MentalStressTaken")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PhysicalStressTaken")
                        .HasColumnType("int");

                    b.Property<int?>("RefreshUsed")
                        .HasColumnType("int");

                    b.Property<int?>("SocialStressTaken")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("UpdateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Dresden.Models.CharacterAspect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AspectType")
                        .HasColumnType("int");

                    b.Property<int>("CharacterVersionId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterVersionId");

                    b.ToTable("CharacterAspects");
                });

            modelBuilder.Entity("Dresden.Models.CharacterSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterVersionId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.Property<int>("SkillLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterVersionId");

                    b.HasIndex("SkillId");

                    b.ToTable("CharacterSkills");
                });

            modelBuilder.Entity("Dresden.Models.CharacterStunt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterVersionId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StuntId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterVersionId");

                    b.HasIndex("StuntId");

                    b.ToTable("CharacterStunts");
                });

            modelBuilder.Entity("Dresden.Models.CharacterVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BaseReferesh")
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("MentalStressBoxes")
                        .HasColumnType("int");

                    b.Property<int>("PhysicalStressBoxes")
                        .HasColumnType("int");

                    b.Property<int>("SocialStressBoxes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("CharacterVersions");
                });

            modelBuilder.Entity("Dresden.Models.Consequence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Aspect")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("StressCategory")
                        .HasColumnType("int");

                    b.Property<int>("StressType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Consequences");
                });

            modelBuilder.Entity("Dresden.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("GameManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GameManagerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("Dresden.Models.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("DeleteUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdateUtc")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Dresden.Models.Stunt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("DeleteUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastUpdateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RefreshCost")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(-1);

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("Stunts");
                });

            modelBuilder.Entity("Dresden.Models.TemporaryAspect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("TemporaryAspects");
                });

            modelBuilder.Entity("Dresden.Models.Trapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset?>("DeleteUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("LastUpdateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SkillId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("Trappings");
                });

            modelBuilder.Entity("Dresden.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("CreateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("DeleteUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset?>("UpdateUtc")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GameNonPlayerCharacter", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GameNonPlayerCharacter");
                });

            modelBuilder.Entity("GamePlayerCharacter", b =>
                {
                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("GamePlayerCharacter");
                });

            modelBuilder.Entity("Dresden.Models.Character", b =>
                {
                    b.HasOne("Dresden.Models.User", "User")
                        .WithMany("Characters")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Dresden.Models.CharacterAspect", b =>
                {
                    b.HasOne("Dresden.Models.CharacterVersion", "CharacterVersion")
                        .WithMany("Aspects")
                        .HasForeignKey("CharacterVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacterVersion");
                });

            modelBuilder.Entity("Dresden.Models.CharacterSkill", b =>
                {
                    b.HasOne("Dresden.Models.CharacterVersion", "CharacterVersion")
                        .WithMany("Skills")
                        .HasForeignKey("CharacterVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dresden.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacterVersion");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Dresden.Models.CharacterStunt", b =>
                {
                    b.HasOne("Dresden.Models.CharacterVersion", "CharacterVersion")
                        .WithMany("Stunts")
                        .HasForeignKey("CharacterVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dresden.Models.Stunt", "Stunt")
                        .WithMany()
                        .HasForeignKey("StuntId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CharacterVersion");

                    b.Navigation("Stunt");
                });

            modelBuilder.Entity("Dresden.Models.CharacterVersion", b =>
                {
                    b.HasOne("Dresden.Models.Character", "Character")
                        .WithMany("CharacterVersions")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Dresden.Models.Consequence", b =>
                {
                    b.HasOne("Dresden.Models.Character", "Character")
                        .WithMany("Consequences")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Dresden.Models.Game", b =>
                {
                    b.HasOne("Dresden.Models.User", "GameManager")
                        .WithMany()
                        .HasForeignKey("GameManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameManager");
                });

            modelBuilder.Entity("Dresden.Models.Stunt", b =>
                {
                    b.HasOne("Dresden.Models.Skill", "Skill")
                        .WithMany("Stunts")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Dresden.Models.TemporaryAspect", b =>
                {
                    b.HasOne("Dresden.Models.Character", "Character")
                        .WithMany("TemporaryAspects")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("Dresden.Models.Trapping", b =>
                {
                    b.HasOne("Dresden.Models.Skill", "Skill")
                        .WithMany("Trappings")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("GameNonPlayerCharacter", b =>
                {
                    b.HasOne("Dresden.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dresden.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("GamePlayerCharacter", b =>
                {
                    b.HasOne("Dresden.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Dresden.Models.Game", null)
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("Dresden.Models.Character", b =>
                {
                    b.Navigation("CharacterVersions");

                    b.Navigation("Consequences");

                    b.Navigation("TemporaryAspects");
                });

            modelBuilder.Entity("Dresden.Models.CharacterVersion", b =>
                {
                    b.Navigation("Aspects");

                    b.Navigation("Skills");

                    b.Navigation("Stunts");
                });

            modelBuilder.Entity("Dresden.Models.Skill", b =>
                {
                    b.Navigation("Stunts");

                    b.Navigation("Trappings");
                });

            modelBuilder.Entity("Dresden.Models.User", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
