using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N3U1P9_HFT_2022231.Repository;
using N3U1P9_HFT_2022231.Models;

namespace N3U1P9_HFT_2022231.Logic.Classes
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
            Repository.Create(item);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }

        public Animal Read(int id)
        {
            return Repository.Read(id);
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
