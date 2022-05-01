﻿// <auto-generated />
using Lab3API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab3API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.24")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserInterest.Model.Interest", b =>
                {
                    b.Property<int>("InterestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestID");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            InterestID = 1,
                            Description = "Lyssna, spela och sjunga",
                            Title = "Musik"
                        },
                        new
                        {
                            InterestID = 2,
                            Description = "Skapa applikationer, databaser, använda C#",
                            Title = "Programmering"
                        },
                        new
                        {
                            InterestID = 3,
                            Description = "Läsa faktaböcker, sköntlitteratur och självbiografier",
                            Title = "Läsning"
                        },
                        new
                        {
                            InterestID = 4,
                            Description = "Träna kondition, styrka och rörlighet",
                            Title = "Träning"
                        });
                });

            modelBuilder.Entity("UserInterest.Model.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Address = "Blåbärsvägen 11B",
                            FirstName = "Per",
                            LastName = "Andersson",
                            Phone = "082767829"
                        },
                        new
                        {
                            UserID = 2,
                            Address = "Långvägen 5",
                            FirstName = "Johan",
                            LastName = "Karlsson",
                            Phone = "0313456789"
                        },
                        new
                        {
                            UserID = 3,
                            Address = "Fabriksgatan 5",
                            FirstName = "Johanna",
                            LastName = "Nordin",
                            Phone = "0903456789"
                        });
                });

            modelBuilder.Entity("UserInterest.Model.UserInterests", b =>
                {
                    b.Property<int>("UserInterestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InterestID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("UserInterestID");

                    b.HasIndex("InterestID");

                    b.HasIndex("UserID");

                    b.ToTable("UserInterests");

                    b.HasData(
                        new
                        {
                            UserInterestID = 1,
                            InterestID = 2,
                            UserID = 1
                        },
                        new
                        {
                            UserInterestID = 2,
                            InterestID = 1,
                            UserID = 1
                        },
                        new
                        {
                            UserInterestID = 3,
                            InterestID = 3,
                            UserID = 2
                        },
                        new
                        {
                            UserInterestID = 4,
                            InterestID = 4,
                            UserID = 3
                        });
                });

            modelBuilder.Entity("UserInterest.Model.UserInterests", b =>
                {
                    b.HasOne("UserInterest.Model.Interest", "Interest")
                        .WithMany("UserInterests")
                        .HasForeignKey("InterestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserInterest.Model.User", "User")
                        .WithMany("UserInterests")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}