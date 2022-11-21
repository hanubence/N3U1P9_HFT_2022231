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
                builder
                .UseInMemoryDatabase("shelter_database")
                .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Shelter>()
                .HasMany(x => x.Animals)
                .WithOne(x => x.Shelter)
                .HasForeignKey(x => x.ShelterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Shelter>()
                .HasMany(x => x.Workers)
                .WithOne(x => x.Shelter)
                .HasForeignKey(x => x.ShelterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Animal>()
                .HasOne(x => x.Shelter)
                .WithMany(x => x.Animals)
                .HasForeignKey(x => x.ShelterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<ShelterWorker>()
                .HasOne(x => x.Shelter)
                .WithMany(x => x.Workers)
                .HasForeignKey(x => x.ShelterId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Shelter>().HasData(new Shelter[] {
                new Shelter("1;Teszt Menhely;2111 Teszt utca 2;3000000"),
                new Shelter("2;Cica Menhely;2112 Cica utca 2;4000000"),
                new Shelter("3;Kutya Menhely;2113 Kutya utca 2;5000000")
            });

            builder.Entity<Animal>().HasData(new Animal[] {
                new Animal("1;Morzsi;Kutya;3;3"),
                new Animal("2;Pöttyös;Kutya;4;1"),
                new Animal("3;Béla;Macska;1;1"),
                new Animal("4;Jani;Hörcsög;5;2")
            });

            builder.Entity<ShelterWorker>().HasData(new ShelterWorker[] {
                new ShelterWorker("1;B József;Állatorvos;43;2022-10-13;3"),
                new ShelterWorker("2;H Hanna;Adminisztráció;27;2022-7-8;1"),
                new ShelterWorker("3;Ádám;Állatorvos;32;2021-1-5;2"),
                new ShelterWorker("4;István;Gondozó;23;2022-5-12;2")
            });
        }
    }
}
