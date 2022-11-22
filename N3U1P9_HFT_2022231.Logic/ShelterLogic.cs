using System;
using System.Collections.Generic;
using System.Linq;
using N3U1P9_HFT_2022231.Models;
using N3U1P9_HFT_2022231.Repository;

namespace N3U1P9_HFT_2022231.Logic
{
    public class ShelterLogic : IShelterLogic
    {
        IRepository<Shelter> Repository;
        IRepository<Animal> AnimalRepository;
        public ShelterLogic(IRepository<Shelter> repository, IRepository<Animal> animalrepository)
        {
            Repository = repository;
            AnimalRepository = animalrepository;
        }

        public void Create(Shelter item)
        {
            Repository.Create(item);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }

        public Shelter Read(int id)
        {
            return Repository.Read(id);
        }

        public IQueryable<Shelter> ReadAll()
        {
            return Repository.ReadAll();
        }

        public void Update(Shelter item)
        {
            Repository.Update(item);
        }

        public double? GetAverageBudget()
        {
            return Repository.ReadAll().Average(t => t.AnnualBudget);
        }

        public IQueryable<ShelterInfo> GetAnimalsByShelter()
        {
            return from shelter in Repository.ReadAll()
                   join animal in AnimalRepository.ReadAll() on shelter.ShelterId equals animal.ShelterId
                   group shelter by shelter.ShelterName into g
                   select new ShelterInfo
                   {
                       ShelterName = g.First().ShelterName,
                       Animals = shel
                   }
        }
    }

    public class ShelterInfo
    {
        public string ShelterName { get; set; }
        public IEnumerable<Animal> Animals { get; set; }
    }
}
