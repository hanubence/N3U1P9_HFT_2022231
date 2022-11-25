using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N3U1P9_HFT_2022231.Repository;
using N3U1P9_HFT_2022231.Models;

namespace N3U1P9_HFT_2022231.Logic
{
    public class AnimalLogic : IAnimalLogic
    {
        IRepository<Animal> Repository;

        public AnimalLogic(IRepository<Animal> animalRepo)
        {
            Repository = animalRepo;
        }

        public void Create(Animal item)
        {
            if (item.Name.Length <= 1 || item.Name.Length > 30) throw new ArgumentException("The name provided was either too short or too long");
            else if (item.Age < 0) throw new ArgumentException("Age cannot be negative");
            else if (item.Species.Length < 3) throw new ArgumentException("Species name needs to be longer than 2 characters");
            else if (item.ShelterId < 0) throw new ArgumentException("Incorrect shelterID was provided");
            Repository.Create(item);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }

        public Animal Read(int id)
        {
            Animal item = Repository.Read(id);
            if (item == null) throw new ArgumentException("No animal exists with the given ID");
            return item;
        }

        public IQueryable<Animal> ReadAll()
        {
            return Repository.ReadAll();
        }

        public void Update(Animal item)
        {
            Repository.Update(item);
        }
    }
}
