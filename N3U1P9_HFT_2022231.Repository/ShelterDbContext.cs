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
            builder.Entity<Shelter>()
                .HasMany(x => x.animals)
                .WithOne(x => x.shelter)
                .HasForeignKey(x => x.shelterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Shelter>()
                .HasMany(x => x.workers)
                .WithOne(x => x.shelter)
                .HasForeignKey(x => x.shelterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Animal>()
                .HasOne(x => x.shelter)
                .WithMany(x => x.animals)
                .HasForeignKey(x => x.shelterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ShelterWorker>()
                .HasOne(x => x.shelter)
                .WithMany(x => x.workers)
                .HasForeignKey(x => x.shelterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Shelter>().HasData(new Shelter[] {
                //fill with data
            });

            builder.Entity<Animal>().HasData(new Animal[] {
                //fill with data
            });

            builder.Entity<ShelterWorker>().HasData(new ShelterWorker[] {
                //fill with data
            });
        }
    }
}
