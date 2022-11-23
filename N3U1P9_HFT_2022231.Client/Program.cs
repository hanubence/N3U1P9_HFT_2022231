using System;
using N3U1P9_HFT_2022231.Models;
using System.Linq;
using ConsoleTools;

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
                    break;
                case "Animal":
                    break;
                case "ShelterWorker":
                    break;
                default:
                    break;
            }
        }
        
        static void List(string entity)
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

        static void Main(string[] args)
        {
            Rest = new RestService("http://localhost:45007", "shelter");

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

            Console.ReadLine();
            ;
        }
    }
}
