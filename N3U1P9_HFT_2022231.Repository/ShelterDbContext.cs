using Microsoft.EntityFrameworkCore;

using N3U1P9_HFT_2022231.Models;
using System;
using System.Globalization;

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

            builder.Entity<Shelter>().HasData(new Shelter[]
            {
                new Shelter { ShelterId = 1, Name = "Animal Haven", Address = "7001 W. Jennings St. Dalton, GA 30721", AnnualBudget = 12130921 },
                new Shelter { ShelterId = 2, Name = "Loved Pet Shelter", Address = "91 Smith Store Dr. Windsor Mill, MD 21244", AnnualBudget = 18902344 },
                new Shelter { ShelterId = 3, Name = "Furry Friends Pet Shelter", Address = "39 Laurel St. Atlantic City, NJ 08401", AnnualBudget = 9521546 },
                new Shelter { ShelterId = 4, Name = "Helping Hands", Address = "7666 S. James St. Kennewick, WA 99337", AnnualBudget = 13084597 },
                new Shelter { ShelterId = 5, Name = "Small Paws", Address = "451 Lakeview St. Indiana, PA 15701", AnnualBudget = 11875905 },
                new Shelter { ShelterId = 6, Name = "Animal Kindness", Address = "82 Border Ave. Venice, FL 34293", AnnualBudget = 14939968 },
                new Shelter { ShelterId = 7, Name = "Animal Adoption Center", Address = "89 Vine Street Cedar Falls, IA 50613", AnnualBudget = 17409605 },
                new Shelter { ShelterId = 8, Name = "Home for Lost Pets", Address = "12 John Drive Dearborn Heights, MI 48127", AnnualBudget = 5485511 },
                new Shelter { ShelterId = 9, Name = "Companionship", Address = "373 NW. Wellington St. Norristown, PA 19401", AnnualBudget = 10864797 },
                new Shelter { ShelterId = 10, Name = "Tree House Animal Rescue", Address = "70 SE. Parker Drive Hanover, PA 17331", AnnualBudget = 8118943 }
            });

            builder.Entity<Animal>().HasData(new Animal[]
            {
                new Animal { AnimalId = 1, Name = "Lacy", Species = "Parrot", Age = 5, ShelterId = 7 },
                new Animal { AnimalId = 2, Name = "Lionel", Species = "Cat", Age = 14, ShelterId = 7 },
                new Animal { AnimalId = 3, Name = "Lillith", Species = "Parrot", Age = 2, ShelterId = 6 },
                new Animal { AnimalId = 4, Name = "Keefe", Species = "Hamster", Age = 12, ShelterId = 3 },
                new Animal { AnimalId = 5, Name = "Nomlanga", Species = "Cat", Age = 8, ShelterId = 4 },
                new Animal { AnimalId = 6, Name = "Jeremy", Species = "Hamster", Age = 11, ShelterId = 4 },
                new Animal { AnimalId = 7, Name = "Britanney", Species = "Parrot", Age = 9, ShelterId = 7 },
                new Animal { AnimalId = 8, Name = "Axel", Species = "Rabbit", Age = 14, ShelterId = 4 },
                new Animal { AnimalId = 9, Name = "Holmes", Species = "Dog", Age = 5, ShelterId = 6 },
                new Animal { AnimalId = 10, Name = "Alea", Species = "Rabbit", Age = 3, ShelterId = 4 },
                new Animal { AnimalId = 11, Name = "Kelly", Species = "Dog", Age = 7, ShelterId = 5 },
                new Animal { AnimalId = 12, Name = "Jolene", Species = "Rabbit", Age = 9, ShelterId = 4 },
                new Animal { AnimalId = 13, Name = "Paki", Species = "Rabbit", Age = 1, ShelterId = 3 },
                new Animal { AnimalId = 14, Name = "Teegan", Species = "Parrot", Age = 5, ShelterId = 3 },
                new Animal { AnimalId = 15, Name = "Heather", Species = "Hamster", Age = 7, ShelterId = 9 },
                new Animal { AnimalId = 16, Name = "Gil", Species = "Hamster", Age = 14, ShelterId = 5 },
                new Animal { AnimalId = 17, Name = "Kalia", Species = "Hamster", Age = 11, ShelterId = 9 },
                new Animal { AnimalId = 18, Name = "Remedios", Species = "Parrot", Age = 2, ShelterId = 6 },
                new Animal { AnimalId = 19, Name = "Lael", Species = "Rabbit", Age = 3, ShelterId = 2 },
                new Animal { AnimalId = 20, Name = "Karly", Species = "Parrot", Age = 8, ShelterId = 7 },
                new Animal { AnimalId = 21, Name = "Quon", Species = "Parrot", Age = 7, ShelterId = 5 },
                new Animal { AnimalId = 22, Name = "Grace", Species = "Hamster", Age = 12, ShelterId = 3 },
                new Animal { AnimalId = 23, Name = "Cody", Species = "Rabbit", Age = 15, ShelterId = 6 },
                new Animal { AnimalId = 24, Name = "Nathan", Species = "Cat", Age = 7, ShelterId = 2 },
                new Animal { AnimalId = 25, Name = "Madeline", Species = "Rabbit", Age = 6, ShelterId = 5 },
                new Animal { AnimalId = 26, Name = "Wynne", Species = "Rabbit", Age = 6, ShelterId = 4 },
                new Animal { AnimalId = 27, Name = "Leonard", Species = "Parrot", Age = 8, ShelterId = 5 },
                new Animal { AnimalId = 28, Name = "Keaton", Species = "Rabbit", Age = 2, ShelterId = 6 },
                new Animal { AnimalId = 29, Name = "Cadman", Species = "Hamster", Age = 4, ShelterId = 2 },
                new Animal { AnimalId = 30, Name = "Aileen", Species = "Cat", Age = 8, ShelterId = 10 },
                new Animal { AnimalId = 31, Name = "Declan", Species = "Dog", Age = 7, ShelterId = 10 },
                new Animal { AnimalId = 32, Name = "Jameson", Species = "Dog", Age = 13, ShelterId = 10 },
                new Animal { AnimalId = 33, Name = "Talon", Species = "Rabbit", Age = 2, ShelterId = 7 },
                new Animal { AnimalId = 34, Name = "Jackson", Species = "Rabbit", Age = 12, ShelterId = 1 },
                new Animal { AnimalId = 35, Name = "Winifred", Species = "Cat", Age = 4, ShelterId = 7 },
                new Animal { AnimalId = 36, Name = "Tiger", Species = "Rabbit", Age = 9, ShelterId = 4 },
                new Animal { AnimalId = 37, Name = "Jonas", Species = "Hamster", Age = 5, ShelterId = 8 },
                new Animal { AnimalId = 38, Name = "Dillon", Species = "Parrot", Age = 13, ShelterId = 9 },
                new Animal { AnimalId = 39, Name = "Holmes", Species = "Parrot", Age = 13, ShelterId = 8 },
                new Animal { AnimalId = 40, Name = "Isaiah", Species = "Parrot", Age = 10, ShelterId = 6 },
                new Animal { AnimalId = 41, Name = "Malcolm", Species = "Rabbit", Age = 7, ShelterId = 7 },
                new Animal { AnimalId = 42, Name = "Elvis", Species = "Hamster", Age = 11, ShelterId = 9 },
                new Animal { AnimalId = 43, Name = "Chiquita", Species = "Cat", Age = 3, ShelterId = 5 },
                new Animal { AnimalId = 44, Name = "Tanek", Species = "Dog", Age = 12, ShelterId = 6 },
                new Animal { AnimalId = 45, Name = "Briar", Species = "Cat", Age = 13, ShelterId = 5 },
                new Animal { AnimalId = 46, Name = "Kai", Species = "Cat", Age = 4, ShelterId = 3 },
                new Animal { AnimalId = 47, Name = "Dennis", Species = "Cat", Age = 10, ShelterId = 8 },
                new Animal { AnimalId = 48, Name = "Abra", Species = "Hamster", Age = 8, ShelterId = 3 },
                new Animal { AnimalId = 49, Name = "Magee", Species = "Cat", Age = 13, ShelterId = 5 },
                new Animal { AnimalId = 50, Name = "Elton", Species = "Cat", Age = 10, ShelterId = 5 },
                new Animal { AnimalId = 51, Name = "Yael", Species = "Rabbit", Age = 5, ShelterId = 2 },
                new Animal { AnimalId = 52, Name = "Rebekah", Species = "Cat", Age = 10, ShelterId = 6 },
                new Animal { AnimalId = 53, Name = "Claire", Species = "Dog", Age = 2, ShelterId = 8 },
                new Animal { AnimalId = 54, Name = "Hilary", Species = "Rabbit", Age = 5, ShelterId = 3 },
                new Animal { AnimalId = 55, Name = "Kevyn", Species = "Hamster", Age = 12, ShelterId = 9 },
                new Animal { AnimalId = 56, Name = "Harrison", Species = "Cat", Age = 6, ShelterId = 9 },
                new Animal { AnimalId = 57, Name = "Alyssa", Species = "Parrot", Age = 15, ShelterId = 8 },
                new Animal { AnimalId = 58, Name = "Yeo", Species = "Hamster", Age = 4, ShelterId = 4 },
                new Animal { AnimalId = 59, Name = "Germaine", Species = "Cat", Age = 1, ShelterId = 10 },
                new Animal { AnimalId = 60, Name = "Dahlia", Species = "Parrot", Age = 14, ShelterId = 3 },
                new Animal { AnimalId = 61, Name = "Raphael", Species = "Hamster", Age = 7, ShelterId = 8 },
                new Animal { AnimalId = 62, Name = "Amy", Species = "Hamster", Age = 14, ShelterId = 7 },
                new Animal { AnimalId = 63, Name = "Illana", Species = "Dog", Age = 9, ShelterId = 6 },
                new Animal { AnimalId = 64, Name = "Tanisha", Species = "Cat", Age = 4, ShelterId = 3 },
                new Animal { AnimalId = 65, Name = "Allegra", Species = "Dog", Age = 8, ShelterId = 7 },
                new Animal { AnimalId = 66, Name = "Vladimir", Species = "Dog", Age = 14, ShelterId = 7 },
                new Animal { AnimalId = 67, Name = "Garrison", Species = "Parrot", Age = 14, ShelterId = 6 },
                new Animal { AnimalId = 68, Name = "Judah", Species = "Parrot", Age = 3, ShelterId = 9 },
                new Animal { AnimalId = 69, Name = "Kai", Species = "Rabbit", Age = 5, ShelterId = 6 },
                new Animal { AnimalId = 70, Name = "Cody", Species = "Rabbit", Age = 11, ShelterId = 1 },
                new Animal { AnimalId = 71, Name = "Teagan", Species = "Hamster", Age = 7, ShelterId = 10 },
                new Animal { AnimalId = 72, Name = "Alexandra", Species = "Cat", Age = 6, ShelterId = 4 },
                new Animal { AnimalId = 73, Name = "Noelani", Species = "Parrot", Age = 7, ShelterId = 4 },
                new Animal { AnimalId = 74, Name = "Acton", Species = "Cat", Age = 14, ShelterId = 10 },
                new Animal { AnimalId = 75, Name = "Forrest", Species = "Dog", Age = 10, ShelterId = 3 },
                new Animal { AnimalId = 76, Name = "Jordan", Species = "Cat", Age = 2, ShelterId = 4 },
                new Animal { AnimalId = 77, Name = "Haley", Species = "Parrot", Age = 2, ShelterId = 8 },
                new Animal { AnimalId = 78, Name = "Claire", Species = "Dog", Age = 8, ShelterId = 5 },
                new Animal { AnimalId = 79, Name = "Stacey", Species = "Parrot", Age = 3, ShelterId = 4 },
                new Animal { AnimalId = 80, Name = "Keegan", Species = "Parrot", Age = 2, ShelterId = 5 },
                new Animal { AnimalId = 81, Name = "Ariana", Species = "Hamster", Age = 9, ShelterId = 1 },
                new Animal { AnimalId = 82, Name = "Neville", Species = "Hamster", Age = 8, ShelterId = 10 },
                new Animal { AnimalId = 83, Name = "Brynne", Species = "Parrot", Age = 11, ShelterId = 3 },
                new Animal { AnimalId = 84, Name = "Alexa", Species = "Cat", Age = 12, ShelterId = 1 },
                new Animal { AnimalId = 85, Name = "Halla", Species = "Rabbit", Age = 3, ShelterId = 9 },
                new Animal { AnimalId = 86, Name = "Alden", Species = "Hamster", Age = 13, ShelterId = 10 },
                new Animal { AnimalId = 87, Name = "Walker", Species = "Rabbit", Age = 3, ShelterId = 2 },
                new Animal { AnimalId = 88, Name = "Burton", Species = "Cat", Age = 12, ShelterId = 8 },
                new Animal { AnimalId = 89, Name = "Melvin", Species = "Cat", Age = 10, ShelterId = 3 },
                new Animal { AnimalId = 90, Name = "Jorden", Species = "Dog", Age = 6, ShelterId = 9 },
                new Animal { AnimalId = 91, Name = "Ignacia", Species = "Parrot", Age = 9, ShelterId = 1 },
                new Animal { AnimalId = 92, Name = "Jamalia", Species = "Rabbit", Age = 12, ShelterId = 2 },
                new Animal { AnimalId = 93, Name = "Armand", Species = "Rabbit", Age = 3, ShelterId = 2 },
                new Animal { AnimalId = 94, Name = "Tate", Species = "Hamster", Age = 8, ShelterId = 7 },
                new Animal { AnimalId = 95, Name = "Unity", Species = "Rabbit", Age = 5, ShelterId = 6 },
                new Animal { AnimalId = 96, Name = "Murphy", Species = "Hamster", Age = 1, ShelterId = 10 },
                new Animal { AnimalId = 97, Name = "Xander", Species = "Rabbit", Age = 6, ShelterId = 7 },
                new Animal { AnimalId = 98, Name = "Yardley", Species = "Dog", Age = 10, ShelterId = 9 },
                new Animal { AnimalId = 99, Name = "Oren", Species = "Hamster", Age = 6, ShelterId = 2 },
                new Animal { AnimalId = 100, Name = "Penelope", Species = "Cat", Age = 3, ShelterId = 8 }
                });

            builder.Entity<ShelterWorker>().HasData(new ShelterWorker[]
{
    new ShelterWorker
    {
        WorkerId = 1,
        Name = "Ramona Finley",
        Age = 53,
        Occupation = "Caretaker",
        HireDate = GetDate("2023-09-05"),
        Salary = 974485,
        ShelterId = 8
    },
    new ShelterWorker
    {
        WorkerId = 2,
        Name = "Fleur Lloyd",
        Age = 59,
        Occupation = "Caretaker",
        HireDate = GetDate("2023-02-07"),
        Salary = 838951,
        ShelterId = 7
    },
    new ShelterWorker
    {
        WorkerId = 3,
        Name = "Rae Owen",
        Age = 32,
        Occupation = "Caretaker",
        HireDate = GetDate("2022-04-15"),
        Salary = 717054,
        ShelterId = 10
    },
    new ShelterWorker
    {
        WorkerId = 4,
        Name = "Hiram Wright",
        Age = 35,
        Occupation = "Veterinarian",
        HireDate = GetDate("2022-06-04"),
        Salary = 327110,
        ShelterId = 2
    },
    new ShelterWorker
    {
        WorkerId = 5,
        Name = "Rhea Casey",
        Age = 21,
        Occupation = "Caretaker",
        HireDate = GetDate("2022-12-05"),
        Salary = 604499,
        ShelterId = 2
    },
    new ShelterWorker
    {
        WorkerId = 6,
        Name = "Caleb Wolfe",
        Age = 43,
        Occupation = "Administration",
        HireDate = GetDate("2022-06-17"),
        Salary = 322198,
        ShelterId = 5
    },
    new ShelterWorker
    {
        WorkerId = 7,
        Name = "Lance Fowler",
        Age = 62,
        Occupation = "Administration",
        HireDate = GetDate("2023-02-18"),
        Salary = 648840,
        ShelterId = 3
    },
    new ShelterWorker
    {
        WorkerId = 8,
        Name = "Vivien Barr",
        Age = 58,
        Occupation = "Administration",
        HireDate = GetDate("2023-09-09"),
        Salary = 1047944,
        ShelterId = 5
    },
    new ShelterWorker
    {
        WorkerId = 9,
        Name = "Jessamine Adams",
        Age = 59,
        Occupation = "Administration",
        HireDate = GetDate("2023-07-04"),
        Salary = 580633,
        ShelterId = 8
    },
    new ShelterWorker
    {
        WorkerId = 10,
        Name = "Destiny Buckley",
        Age = 58,
        Occupation = "Administration",
        HireDate = GetDate("2022-10-06"),
        Salary = 963575,
        ShelterId = 6
    },
    new ShelterWorker
    {
        WorkerId = 11,
        Name = "Gary Velasquez",
        Age = 59,
        Occupation = "Administration",
        HireDate = GetDate("2023-06-13"),
        Salary = 613648,
        ShelterId = 3
    },
    new ShelterWorker
    {
        WorkerId = 12,
        Name = "Ciaran Mitchell",
        Age = 44,
        Occupation = "Administration",
        HireDate = GetDate("2022-05-20"),
        Salary = 1145435,
        ShelterId = 6
    },
    new ShelterWorker
    {
        WorkerId = 13,
        Name = "Chadwick Collier",
        Age = 41,
        Occupation = "Administration",
        HireDate = GetDate("2023-02-16"),
        Salary = 437200,
        ShelterId = 10
    },
    new ShelterWorker
    {
        WorkerId = 14,
        Name = "Darryl Pollard",
        Age = 20,
        Occupation = "Veterinarian",
        HireDate = GetDate("2023-04-15"),
        Salary = 525223,
        ShelterId = 1
    },
    new ShelterWorker
    {
        WorkerId = 15,
        Name = "Cedric Blevins",
        Age = 63,
        Occupation = "Caretaker",
        HireDate = GetDate("2022-02-11"),
        Salary = 1078317,
        ShelterId = 7
    },
    new ShelterWorker
    {
        WorkerId = 16,
        Name = "Nasim Reilly",
        Age = 44,
        Occupation = "Vet Assistant",
        HireDate = GetDate("2023-02-10"),
        Salary = 367248,
        ShelterId = 2
    },
    new ShelterWorker
    {
        WorkerId = 17,
        Name = "Noel Rutledge",
        Age = 59,
        Occupation = "Caretaker",
        HireDate = GetDate("2022-12-17"),
        Salary = 665719,
        ShelterId = 9
    },
    new ShelterWorker
    {
        WorkerId = 18,
        Name = "Dominic Shaw",
        Age = 61,
        Occupation = "Vet Assistant",
        HireDate = GetDate("2022-12-02"),
        Salary = 706852,
        ShelterId = 3
    },
    new ShelterWorker
    {
        WorkerId = 19,
        Name = "Baxter Rivers",
        Age = 20,
        Occupation = "Veterinarian",
        HireDate = GetDate("2022-08-19"),
        Salary = 611259,
        ShelterId = 5
    },
    new ShelterWorker
    {
        WorkerId = 20,
        Name = "Porter Moreno",
        Age = 41,
        Occupation = "Vet Assistant",
        HireDate = GetDate("2022-07-15"),
        Salary = 916006,
        ShelterId = 3
    },
    new ShelterWorker
    {
        WorkerId = 21,
        Name = "Eve Browning",
        Age = 41,
        Occupation = "Veterinarian",
        HireDate = GetDate("2023-05-20"),
        Salary = 1093016,
        ShelterId = 8
    },
    new ShelterWorker
    {
        WorkerId = 22,
        Name = "Stephanie Roy",
        Age = 44,
        Occupation = "Veterinarian",
        HireDate = GetDate("2023-09-09"),
        Salary = 638491,
        ShelterId = 2
    },
    new ShelterWorker
    {
        WorkerId = 23,
        Name = "Quinn Morse",
        Age = 34,
        Occupation = "Vet Assistant",
        HireDate = GetDate("2022-03-16"),
        Salary = 319376,
        ShelterId = 2
    },
    new ShelterWorker
    {
        WorkerId = 24,
        Name = "Bevis Flynn",
        Age = 21,
        Occupation = "Vet Assistant",
        HireDate = GetDate("2022-12-28"),
        Salary = 318252,
        ShelterId = 3
    },
    new ShelterWorker
    {
        WorkerId = 25,
        Name = "Abra Sawyer",
        Age = 57,
        Occupation = "Veterinarian",
        HireDate = GetDate("2023-03-12"),
        Salary = 1193808,
        ShelterId = 2
    },
    new ShelterWorker
    {
        WorkerId = 26,
        Name = "Aidan Rich",
        Age = 19,
        Occupation = "Administration",
        HireDate = GetDate("2022-10-06"),
        Salary = 1134965,
        ShelterId = 2
    },
    new ShelterWorker
    {
        WorkerId = 27,
        Name = "August English",
        Age = 39,
        Occupation = "Administration",
        HireDate = GetDate("2022-11-28"),
        Salary = 880254,
        ShelterId = 2
    },
    new ShelterWorker
    {
        WorkerId = 28,
        Name = "Azalia Mercado",
        Age = 28,
        Occupation = "Veterinarian",
        HireDate = GetDate("2022-11-04"),
        Salary = 961280,
        ShelterId = 9
    },
    new ShelterWorker
    {
        WorkerId = 29,
        Name = "Kevyn Webster",
        Age = 37,
        Occupation = "Vet Assistant",
        HireDate = GetDate("2023-02-13"),
        Salary = 262004,
        ShelterId = 3
    },
    new ShelterWorker
    {
        WorkerId = 30,
        Name = "Gillian Crawford",
        Age = 34,
        Occupation = "Administration",
        HireDate = GetDate("2022-01-11"),
        Salary = 934079,
        ShelterId = 7
    },
    new ShelterWorker
    {
        WorkerId = 31,
        Name = "Barry Phelps",
        Age = 34,
        Occupation = "Caretaker",
        HireDate = GetDate("2022-03-11"),
        Salary = 1011357,
        ShelterId = 10
    },
    new ShelterWorker
    {
        WorkerId = 32,
        Name = "Amity Shepard",
        Age = 25,
        Occupation = "Vet Assistant",
        HireDate = GetDate("2023-01-19"),
        Salary = 753697,
        ShelterId = 9
    },
    new ShelterWorker
    {
        WorkerId = 33,
        Name = "Drake Parrish",
        Age = 22,
        Occupation = "Veterinarian",
        HireDate = GetDate("2022-08-05"),
        Salary = 451124,
        ShelterId = 7
    },
    new ShelterWorker
    {
        WorkerId = 34,
        Name = "Neil Donaldson",
        Age = 37,
        Occupation = "Vet Assistant",
        HireDate = GetDate("2022-07-10"),
        Salary = 574744,
        ShelterId = 6
    },
    new ShelterWorker
    {
        WorkerId = 35,
        Name = "Breanna Roach",
        Age = 25,
        Occupation = "Administration",
        HireDate = GetDate("2022-08-01"),
        Salary = 267398,
        ShelterId = 2
    },
    new ShelterWorker
    {
        WorkerId = 36,
        Name = "Neville Daniel",
        Age = 49,
        Occupation = "Veterinarian",
        HireDate = GetDate("2022-07-09"),
        Salary = 411362,
        ShelterId = 9
    },
    new ShelterWorker
    {
        WorkerId = 37,
        Name = "Daryl Porter",
        Age = 57,
        Occupation = "Administration",
        HireDate = GetDate("2023-05-15"),
        Salary = 344633,
        ShelterId = 9
    },
    new ShelterWorker
    {
        WorkerId = 38,
        Name = "Hakeem Hanson",
        Age = 45,
        Occupation = "Veterinarian",
        HireDate = GetDate("2021-12-06"),
        Salary = 938026,
        ShelterId = 4
    },
    new ShelterWorker
    {
        WorkerId = 39,
        Name = "Astra Mckinney",
        Age = 52,
        Occupation = "Vet Assistant",
        HireDate = GetDate("2021-12-13"),
        Salary = 332178,
        ShelterId = 7
    },
    new ShelterWorker
    {
        WorkerId = 40,
        Name = "Blaze Rowe",
        Age = 23,
        Occupation = "Administration",
        HireDate = GetDate("2023-05-15"),
        Salary = 1124352,
        ShelterId = 6
    },
    new ShelterWorker
    {
        WorkerId = 41,
        Name = "Delilah Kennedy",
        Age = 24,
        Occupation = "Veterinarian",
        HireDate = GetDate("2023-06-23"),
        Salary = 879199,
        ShelterId = 7
    },
    new ShelterWorker
    {
        WorkerId = 42,
        Name = "Nolan Calderon",
        Age = 37,
        Occupation = "Veterinarian",
        HireDate = GetDate("2022-11-05"),
        Salary = 910532,
        ShelterId = 9
    },
    new ShelterWorker
    {
        WorkerId = 43,
        Name = "Simone Maldonado",
        Age = 57,
        Occupation = "Veterinarian",
        HireDate = GetDate("2022-12-06"),
        Salary = 393045,
        ShelterId = 3
    },
    new ShelterWorker
    {
        WorkerId = 44,
        Name = "Barrett Small",
        Age = 41,
        Occupation = "Veterinarian",
        HireDate = GetDate("2022-10-04"),
        Salary = 754860,
        ShelterId = 6
    },
    new ShelterWorker
    {
        WorkerId = 45,
        Name = "Paula Johns",
        Age = 49,
        Occupation = "Vet Assistant",
        HireDate = GetDate("2022-06-16"),
        Salary = 1059384,
        ShelterId = 6
    },
    new ShelterWorker
    {
        WorkerId = 46,
        Name = "Adele Sawyer",
        Age = 46,
        Occupation = "Administration",
        HireDate = GetDate("2023-01-08"),
        Salary = 426426,
        ShelterId = 4
    },
    new ShelterWorker
    {
        WorkerId = 47,
        Name = "Upton Robinson",
        Age = 41,
        Occupation = "Vet Assistant",
        HireDate = GetDate("2022-02-21"),
        Salary = 1183059,
        ShelterId = 9
    },
    new ShelterWorker
    {
        WorkerId = 48,
        Name = "Whilemina Parks",
        Age = 44,
        Occupation = "Veterinarian",
        HireDate = GetDate("2022-12-25"),
        Salary = 527594,
        ShelterId = 3
    },
    new ShelterWorker
    {
        WorkerId = 49,
        Name = "Sylvia Glenn",
        Age = 30,
        Occupation = "Vet Assistant",
        HireDate = GetDate("2023-05-25"),
        Salary = 1001325,
        ShelterId = 7
    },
    new ShelterWorker
    {
        WorkerId = 50,
        Name = "Wade Todd",
        Age = 25,
        Occupation = "Caretaker",
        HireDate = GetDate("2023-01-04"),
        Salary = 467798,
        ShelterId = 10
    }
});
        }

        private static DateTime GetDate(string date)
        {
            DateTime Date;
            if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out Date))
            {
                return Date;
            }
            else
            {
                return DateTime.Now;
            }

        }
    }
}
