using System;
using N3U1P9_HFT_2022231.Models;
using System.Linq;
using ConsoleTools;
using System.Collections.Generic;

namespace N3U1P9_HFT_2022231.Client
{
    internal class Program
    {
        static RestService Rest;

        static void Create(string entity)
        {
            switch (entity)
            {
                case "Shelter":
                    Shelter shelter = new Shelter();

                    Console.WriteLine("[Required] Name of the new shelter: ");
                    shelter.Name = Console.ReadLine();

                    Console.WriteLine("[Not Required] Address of the new shelter: ");
                    shelter.Address = Console.ReadLine();

                    Console.WriteLine("[Not Required] Annual budget of the new shelter: ");
                    shelter.AnnualBudget = NumCheck(Console.ReadLine());

                    Rest.Post<Shelter>(shelter, "Shelter");
                    break;
                case "Animal":
                    Animal animal = new Animal();

                    Console.WriteLine("[Required] Name of the new animal: ");
                    animal.Name = Console.ReadLine();

                    Console.WriteLine("[Required] ID of the shelter where the new animal lives at: ");
                    animal.ShelterId = NumCheck(Console.ReadLine());

                    Console.WriteLine("[Not Required] Age of the new animal: ");
                    animal.Age = NumCheck(Console.ReadLine());

                    Console.WriteLine("[Not Required] Species of the new animal: ");
                    animal.Species = Console.ReadLine();

                    break;
                case "ShelterWorker":
                    ShelterWorker worker = new ShelterWorker();

                    Console.WriteLine("[Required] Name of the new worker: ");
                    worker.Name = Console.ReadLine();

                    Console.WriteLine("[Required] ID of the shelter where the new worker works at: ");
                    worker.ShelterId = NumCheck(Console.ReadLine());

                    Console.WriteLine("[Not Required] Age of the new worker: ");
                    worker.Age = NumCheck(Console.ReadLine());

                    Console.WriteLine("[Not Required] Salary of the new worker: ");
                    worker.Salary = NumCheck(Console.ReadLine());

                    Console.WriteLine("[Not Required] Occupation of the new worker: ");
                    worker.Occupation = Console.ReadLine();

                    Console.WriteLine("[Not Required] Hire data of the new worker: (Empty = Now)");
                    DateTime date;
                    if (DateTime.TryParse(Console.ReadLine(), out date)) worker.HireDate = date;
                    else worker.HireDate = DateTime.Now;

                    Console.WriteLine();
                    break;
            }
        }
        
        static void List(string entity)
        {
            switch (entity)
            {
                case "Shelter":
                    List<Shelter> shelters = Rest.Get<Shelter>("Shelter");
                    foreach (Shelter shelter in shelters)
                    {
                        Console.WriteLine($"{shelter.ShelterId}: {shelter.Name} ({shelter.Address})");
                    }
                    break;
                case "Animal":
                    List<Animal> animals = Rest.Get<Animal>("Animal");
                    foreach (var animal in animals)
                    {
                        Console.WriteLine($"{animal.AnimalId}: {animal.Name} ({animal.Age}yr / {animal.Species})");
                    }
                    break;
                case "ShelterWorker":
                    List<ShelterWorker> workers = Rest.Get<ShelterWorker>("ShelterWorker");
                    foreach (ShelterWorker worker in workers)
                    {
                        Console.WriteLine($"{worker.WorkerId}: {worker.Name} [{worker.Occupation}]");
                    }
                    break;
                default:
                    break;
            }
            Console.ReadLine();
        }

        static void Update(string entity)
        {
            switch (entity)
            {
                case "Shelter":
                    break;
                case "Animal":
                    break;
                case "ShelterWorker":
                    break;
                default:
                    break;
            }
        }

        static void Delete(string entity)
        {
            int id;
            switch (entity)
            {
                case "Shelter":
                    Console.WriteLine("ID to delete:");
                    id = int.Parse(Console.ReadLine());
                    Rest.Delete(id, "Shelter");
                    break;
                case "Animal":
                    Console.WriteLine("ID to delete:");
                    id = int.Parse(Console.ReadLine());
                    Rest.Delete(id, "Animal");
                    break;
                case "ShelterWorker":
                    Console.WriteLine("ID to delete:");
                    id = int.Parse(Console.ReadLine());
                    Rest.Delete(id, "ShelterWorker");
                    break;
                default:
                    break;
            }
        }

        static int NumCheck(string n)
        {
            int number;
            bool isNumber = int.TryParse(n, out number);

            return isNumber ? number : 0;
        }

        static void Main(string[] args)
        {
            Rest = new RestService("http://localhost:45007/");

            var ShelterSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Shelter"))
                .Add("Create", () => Create("Shelter"))
                .Add("Delete", () => Delete("Shelter"))
                .Add("Update", () => Update("Shelter"))
                .Add("Exit", ConsoleMenu.Close);

            var AnimalSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Animal"))
                .Add("Create", () => Create("Animal"))
                .Add("Delete", () => Delete("Animal"))
                .Add("Update", () => Update("Animal"))
                .Add("Exit", ConsoleMenu.Close);

            var ShelterWorkerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("ShelterWorker"))
                .Add("Create", () => Create("ShelterWorker"))
                .Add("Delete", () => Delete("ShelterWorker"))
                .Add("Update", () => Update("ShelterWorker"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Shelters", () => ShelterSubMenu.Show())
                .Add("Animals", () => AnimalSubMenu.Show())
                .Add("Shelter Workers", () => ShelterWorkerSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
