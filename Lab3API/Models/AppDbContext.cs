using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserInterest.Model;

namespace Lab3API.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Interest> Interests { get; set; }

        public DbSet<UserInterests> UserInterests { get; set; }


        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Seed User
            modelBuilder.Entity<User>().
                HasData(new User
                {
                    UserID = 1,
                    FirstName = "Per",
                    LastName = "Andersson",
                    Address = "Blåbärsvägen 11B",
                    Phone = "082767829"

                });
            modelBuilder.Entity<User>().
                HasData(new User
                {
                    UserID = 2,
                    FirstName = "Johan",
                    LastName = "Karlsson",
                    Address = "Långvägen 5",
                    Phone = "0313456789"
                });
            modelBuilder.Entity<User>().
                HasData(new User
                {
                    UserID = 3,
                    FirstName = "Johanna",
                    LastName = "Nordin",
                    Address = "Fabriksgatan 5",
                    Phone = "0903456789"
                });

            //Seed Interests
            modelBuilder.Entity<Interest>().
                HasData(new Interest
                {
                    InterestID = 1,                    
                    Title = "Musik",
                    Description = "Lyssna, spela och sjunga"                    
                });
            modelBuilder.Entity<Interest>().
                HasData(new Interest
                {
                    InterestID = 2,                    
                    Title = "Programmering",
                    Description = "Skapa applikationer, databaser, använda C#"                    
                });
            modelBuilder.Entity<Interest>().
                HasData(new Interest
                {
                    InterestID = 3,                    
                    Title = "Läsning",
                    Description = "Läsa faktaböcker, sköntlitteratur och självbiografier"
                });
            modelBuilder.Entity<Interest>().
                HasData(new Interest
                {
                    InterestID = 4,                    
                    Title = "Träning",
                    Description = "Träna kondition, styrka och rörlighet"                    
                });

            //Seed User with interests
            modelBuilder.Entity<UserInterests>().
                HasData(new UserInterests
                {
                    UserInterestID = 1,
                    UserID = 1,
                    InterestID = 2
                });
            modelBuilder.Entity<UserInterests>().
                HasData(new UserInterests
                {
                    UserInterestID = 2,
                    UserID = 1,
                    InterestID = 1
                });
            modelBuilder.Entity<UserInterests>().
                HasData(new UserInterests
                {
                    UserInterestID = 3,
                    UserID = 2,
                    InterestID = 3
                });
            modelBuilder.Entity<UserInterests>().
                HasData(new UserInterests
                {
                    UserInterestID = 4,
                    UserID = 3,
                    InterestID = 4
                });

        }
    }
}
