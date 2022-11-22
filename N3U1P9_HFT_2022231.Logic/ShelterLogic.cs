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
        IRepository<ShelterWorker> WorkerRepository;
        public ShelterLogic(IRepository<Shelter> repository, IRepository<Animal> animalrepository, IRepository<ShelterWorker> workerrepository)
        {
            Repository = repository;
            AnimalRepository = animalrepository;
            WorkerRepository = workerrepository;
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

        public IEnumerable<WorkerInfo> GetWorkersByOccupation()
        {
            var shelters = Repository.ReadAll();
            return from shelter in shelters
                   join worker in WorkerRepository.ReadAll() on shelter.ShelterId equals worker.ShelterId
                   group worker by new { worker.ShelterId, worker.Occupation } into g
                   select new WorkerInfo
                   {
                       ShelterName = shelters.First(t => t.ShelterId == g.Key.ShelterId).Name,
                       Occupation = g.Key.Occupation,
                       WorkerNames = g.Select(t => t.Name)
                   };
        }
    }

    public class WorkerInfo
    {
        public string ShelterName { get; set; }
        public string Occupation { get; set; }
        public IEnumerable<string> WorkerNames { get; set; }
    }
}
