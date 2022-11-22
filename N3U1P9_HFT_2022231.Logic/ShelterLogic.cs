using System;
using System.Linq;
using N3U1P9_HFT_2022231.Models;
using N3U1P9_HFT_2022231.Repository;

namespace N3U1P9_HFT_2022231.Logic
{
    public class ShelterLogic : IShelterLogic
    {
        IRepository<Shelter> Repository;
        public ShelterLogic(IRepository<Shelter> repository)
        {
            Repository = repository;
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
    }
}
