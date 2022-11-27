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
        IRepository<ShelterWorker> WorkerRepository;
        IRepository<Animal> AnimalRepository;
        public ShelterLogic(IRepository<Shelter> shelterRepo, IRepository<ShelterWorker> workerRepo, IRepository<Animal> animalRepo)
        {
            Repository = shelterRepo;
            WorkerRepository = workerRepo;
            AnimalRepository = animalRepo;
        }

        public void Create(Shelter item)
        {
            if (item.Name.Length < 5 || item.Name.Length > 40) throw new ArgumentException("Name is either too short or too long (5-40)");
            Repository.Create(item);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }

        public Shelter Read(int id)
        {
            Shelter item = Repository.Read(id);
            if (item == null) throw new ArgumentException("No animal exists with the given ID");
            return item;
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

        //Átlagfizetés menhelyenként
        public IEnumerable<ShelterSalaryInfo> GetAverageSalaryByShelter()
        {
            var shelters = Repository.ReadAll().ToList();
            var workers = WorkerRepository.ReadAll().ToList();
            return from shelter in shelters
                   join worker in workers on shelter.ShelterId equals worker.ShelterId
                   group worker by worker.ShelterId into grp
                   select new ShelterSalaryInfo
                   {
                       ShelterName = shelters.First(t => t.ShelterId == grp.Key).Name,
                       AverageSalary = (int) grp.Average(t => t.Salary)
                   };
        }

        //Dologozók száma beosztásonként, menhelyenként
        public IEnumerable<WorkerOccupationInfo> GetWorkerOccupationCountByShelter()
        {
            var shelters = Repository.ReadAll();

            List<WorkerOccupationInfo> list = new List<WorkerOccupationInfo>();

            foreach (var shelter in shelters)
            {
                WorkerOccupationInfo info = new WorkerOccupationInfo()
                {
                    ShelterName = shelter.Name
                };

                info.Occupations = (from worker in shelter.Workers
                                    group worker by worker.Occupation into g
                                    select new OccupationCount
                                    {
                                        Name = g.Key,
                                        Count = g.Count()
                                    });

                list.Add(info);
            }

            return list;
        }

        //Állatok száma menhelyenként, faj szerint
        public IEnumerable<AnimalSpecieInfo> GetAnimalSpeciesCountByShelter()
        {
            var shelters = Repository.ReadAll();

            List<AnimalSpecieInfo> list = new List<AnimalSpecieInfo>();

            foreach (var shelter in shelters)
            {
                AnimalSpecieInfo info = new AnimalSpecieInfo()
                {
                    ShelterName = shelter.Name
                };

                info.Species = (from animal in shelter.Animals
                                group animal by animal.Species into g
                                select new SpecieCount
                                {
                                    Name = g.Key,
                                    Count = g.Count()
                                });

                list.Add(info);
            }

            return list;
        }

        //Állatok átlag életkora menhelyenként
        public IEnumerable<AgeInfo> GetAverageAnimalAgeByShelter()
        {
            var shelters = Repository.ReadAll().ToList();
            var animals = AnimalRepository.ReadAll().ToList();
            return from shelter in shelters
                   join animal in animals on shelter.ShelterId equals animal.ShelterId
                   group animal by animal.ShelterId into grp
                   select new AgeInfo
                   {
                       ShelterName = shelters.First(t => t.ShelterId == grp.Key).Name,
                       Average = grp.Average(t => t.Age)
                   };
        }

        //Dolgozók átlag életkora menhelyenként
        public IEnumerable<AgeInfo> GetAverageWorkerAgeByShelter()
        {
            var shelters = Repository.ReadAll().ToList();
            var workers = WorkerRepository.ReadAll().ToList();
            return from shelter in shelters
                   join worker in workers on shelter.ShelterId equals worker.ShelterId
                   group worker by worker.ShelterId into grp
                   select new AgeInfo
                   {
                       ShelterName = shelters.First(t => t.ShelterId == grp.Key).Name,
                       Average = grp.Average(t => t.Age)
                   };
        }
    }


    //Helper classes for non-crud methods
    public class ShelterSalaryInfo
    {
        public string ShelterName { get; set; }
        public int AverageSalary { get; set; }
    }
    
    public class WorkerOccupationInfo
    {
        public string ShelterName { get; set; }
        public IEnumerable<OccupationCount> Occupations { get; set; }

        public override bool Equals(object obj)
        {
            WorkerOccupationInfo w = (obj as WorkerOccupationInfo);
            if (w == null) return false;

            return (this.ShelterName == w.ShelterName) && (this.Occupations == w.Occupations);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.ShelterName, this.Occupations);
        }
    }

    public class OccupationCount
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public override bool Equals(object obj)
        {
            OccupationCount o = (obj as OccupationCount);
            if (o == null) return false;

            return (this.Name == o.Name && this.Count == o.Count);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Count);
        }
    }

    public class AnimalSpecieInfo
    {
        public string ShelterName { get; set; }
        public IEnumerable<SpecieCount> Species { get; set; }

        public override bool Equals(object obj)
        {
            AnimalSpecieInfo a = (obj as AnimalSpecieInfo);
            if (a == null) return false;
            return (this.ShelterName == a.ShelterName && this.Species == a.Species);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.ShelterName, this.Species);
        }
    }

    public class SpecieCount
    {
        public string Name { get; set; }
        public int Count { get; set; }

        public override bool Equals(object obj)
        {
            SpecieCount s = (obj as SpecieCount);
            if (s == null) return false;
            return (s.Name == this.Name && s.Count == this.Count);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Name, this.Count);
        }
    }

    public class AgeInfo
    {
        public string ShelterName { get; set; }
        public double Average { get; set; }
    }

}
