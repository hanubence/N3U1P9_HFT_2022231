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
                    shelter.AnnualBudget = NumberCheck(Console.ReadLine());

                    Rest.Post<Shelter>(shelter, "Shelter");
                    break;
                case "Animal":
                    Animal animal = new Animal();

                    Console.WriteLine("[Required] Name of the new animal: ");
                    animal.Name = Console.ReadLine();

                    Console.WriteLine("[Required] ID of the shelter where the new animal lives at: ");
                    animal.ShelterId = NumberCheck(Console.ReadLine());

                    Console.WriteLine("[Not Required] Age of the new animal: ");
                    animal.Age = NumberCheck(Console.ReadLine());

                    Console.WriteLine("[Not Required] Species of the new animal: ");
                    animal.Species = Console.ReadLine();

                    Rest.Post<Animal>(animal, "Animal");
                    break;
                case "ShelterWorker":
                    ShelterWorker worker = new ShelterWorker();

                    Console.WriteLine("[Required] Name of the new worker: ");
                    worker.Name = Console.ReadLine();

                    Console.WriteLine("[Required] ID of the shelter where the new worker works at: ");
                    worker.ShelterId = NumberCheck(Console.ReadLine());

                    Console.WriteLine("[Not Required] Age of the new worker: ");
                    worker.Age = NumberCheck(Console.ReadLine());

                    Console.WriteLine("[Not Required] Salary of the new worker: ");
                    worker.Salary = NumberCheck(Console.ReadLine());

                    Console.WriteLine("[Not Required] Occupation of the new worker: ");
                    worker.Occupation = Console.ReadLine();

                    Rest.Post<ShelterWorker>(worker, "ShelterWorker");
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
            }
            Console.ReadLine();
        }
        static void ListStatistics(string endpoint)
        {
            dynamic res = Rest.GetNonCrud<dynamic>($"Stats", endpoint);
            if (endpoint == "GetAverageBudget") Console.WriteLine($"Average annual budget of all shelters: {res}");
            else if (endpoint == "GetAverageSalaryByShelter")
            {
                foreach (var item in res)
                {
                    Console.WriteLine($"Shelter name: {item.shelterName}\tAverage salary: {item.averageSalary}");
                }
            }
            else if (endpoint == "GetWorkerOccupationCountByShelter")
            {
                foreach (var item in res)
                {
                    Console.WriteLine($"Shelter: {item.shelterName}");

                    foreach (var occ in item.occupations)
                    {
                        Console.WriteLine($"{occ.name}: {occ.count}");
                    }

                    Console.WriteLine();
                }
            } else if (endpoint == "GetAnimalSpeciesCountByShelter")
            {
                foreach (var item in res)
                {
                    Console.WriteLine($"Shelter: {item.shelterName}");

                    foreach (var s in item.species)
                    {
                        Console.WriteLine($"{s.name}: {s.count}");
                    }

                    Console.WriteLine();
                }
            } else if (endpoint == "GetAverageAnimalAgeByShelter")
            {
                foreach (var item in res)
                {
                    Console.WriteLine($"Shelter: {item.shelterName} Average age of animals: {item.average}");
                }
            } else if (endpoint == "GetAverageWorkerAgeByShelter")
            {
                foreach (var item in res)
                {
                    Console.WriteLine($"Shelter: {item.shelterName} Average age of workers: {item.average}");
                }
            }

            Console.ReadLine();
        }
        static void Update(string entity)
        {
            switch (entity)
            {
                case "Shelter":
                    Console.WriteLine("Enter ID of which shelter to update: ");
                    int shelterid = int.Parse(Console.ReadLine());

                    Shelter shelter = Rest.Get<Shelter>(shelterid, "Shelter");

                    Console.WriteLine($"New name of the shelter: [Current: {shelter.Name}]");
                    shelter.Name = StringUpdate(Console.ReadLine(), shelter.Name);

                    Console.WriteLine($"New address of the shelter: [Current: {shelter.Address}]");
                    shelter.Address = StringUpdate(Console.ReadLine(), shelter.Address);

                    Console.WriteLine($"New annual budget of the shelter: [Current: {shelter.AnnualBudget}]");
                    shelter.AnnualBudget = NumberUpdate(Console.ReadLine(), shelter.AnnualBudget);

                    Rest.Put(shelter, "Shelter");

                    break;

                case "Animal":
                    Console.WriteLine("Enter ID of which animal to update: ");
                    int animalid = int.Parse(Console.ReadLine());

                    Animal animal = Rest.Get<Animal>(animalid, "Animal");

                    Console.WriteLine($"New Shelter ID of the animal: [Current: {animal.ShelterId}]");
                    animal.ShelterId = NumberUpdate(Console.ReadLine(), animal.ShelterId);

                    Console.WriteLine($"New name of the animal: [Current: {animal.Name}]");
                    animal.Name = StringUpdate(Console.ReadLine(), animal.Name);

                    Console.WriteLine($"New species of the animal: [Current: {animal.Species}]");
                    animal.Species = StringUpdate(Console.ReadLine(), animal.Species);

                    Console.WriteLine($"New age of the animal: [Current: {animal.Age}]");
                    animal.Age = NumberUpdate(Console.ReadLine(), animal.Age);

                    Rest.Put(animal, "Animal");

                    break;

                case "ShelterWorker":
                    Console.WriteLine("Enter ID of which worker to update: ");
                    int workerid = int.Parse(Console.ReadLine());

                    ShelterWorker worker = Rest.Get<ShelterWorker>(workerid, "ShelterWorker");

                    Console.WriteLine($"New name of the worker: [Current: {worker.Name}]");
                    worker.Name = StringUpdate(Console.ReadLine(), worker.Name);

                    Console.WriteLine($"New Shelter ID of the worker: [Current: {worker.ShelterId}]");
                    worker.ShelterId = NumberUpdate(Console.ReadLine(), worker.ShelterId);

                    Console.WriteLine($"New age of the worker: [Current: {worker.Age}]");
                    worker.Age = NumberUpdate(Console.ReadLine(), worker.Age);

                    Console.WriteLine($"New salary of the worker: [Current: {worker.Salary}]");
                    worker.Salary = NumberUpdate(Console.ReadLine(), worker.Salary);

                    Console.WriteLine($"New occupation of the worker: [Current: {worker.Occupation}]");
                    worker.Occupation = StringUpdate(Console.ReadLine(), worker.Occupation);

                    Rest.Put(worker, "ShelterWorker");

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
            }
        }

        //Helper methods for correcting data input
        static int NumberCheck(string num)
        {
            int number;
            bool isNumber = int.TryParse(num, out number);

            if (isNumber) return number;
            else return 0;
        } 
        static string StringUpdate(string newData, string OldData)
        {
            if (newData != "" && newData != OldData) return newData;
            else return OldData;
        }
        static int NumberUpdate(string newData, int OldData)
        {
            int number;
            bool isNumber = int.TryParse(newData, out number);

            if (isNumber && number != OldData) return number;
            else return OldData;
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

            var StatsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Average annual budget per shelter", () => ListStatistics("GetAverageBudget"))
                .Add("Average salary of all workers per shelter", () => ListStatistics("GetAverageSalaryByShelter"))
                .Add("Number of workers having each occupation, per shelter", () => ListStatistics("GetWorkerOccupationCountByShelter"))
                .Add("Number of each specie per shelter", () => ListStatistics("GetAnimalSpeciesCountByShelter"))
                .Add("Average age of the animals per shelter", () => ListStatistics("GetAverageAnimalAgeByShelter"))
                .Add("Average age of the employess per shelter", () => ListStatistics("GetAverageWorkerAgeByShelter"))
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Shelters", () => ShelterSubMenu.Show())
                .Add("Animals", () => AnimalSubMenu.Show())
                .Add("Shelter Workers", () => ShelterWorkerSubMenu.Show())
                .Add("Statistics", () => StatsSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
