using System;
using Microsoft.EntityFrameworkCore;

using N3U1P9_HFT_2022231.Models;

namespace N3U1P9_HFT_2022231.Repository
{
    public class ShelterDbContext : DbContext
    {
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<ShelterWorker> Workers { get; set; }

        public ShelterDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\ShelterDB.mdf;Integrated Security=True";

                builder.UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Shelter>(sh => sh
                .HasMany<Animal>()
                .OnDelete(DeleteBehavior.Cascade)
            );
        }
    }
}
