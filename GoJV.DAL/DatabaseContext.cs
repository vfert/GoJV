using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace GoJV.DAL
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var pathDbFile = @".\DbGoJV.db";
            if (!File.Exists(pathDbFile))
                File.Create(pathDbFile);
            optionsBuilder.UseSqlite(@"Filename=.\DbGoJV.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
