using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N3U1P9_HFT_2022231.Repository;
using N3U1P9_HFT_2022231.Models;

namespace N3U1P9_HFT_2022231.Logic.Classes
{
    public class ShelterWorkerLogic : IShelterWorkerLogic
    {
        IRepository<ShelterWorker> Repository;

        public ShelterWorkerLogic(IRepository<ShelterWorker> workerRepo)
        {
            Repository = workerRepo;
        }

        public void Create(ShelterWorker item)
        {
            Repository.Create(item);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }

        public ShelterWorker Read(int id)
        {
            return Repository.Read(id);
        }

        public IQueryable<ShelterWorker> ReadAll()
        {
            return Repository.ReadAll();
        }

        public void Update(ShelterWorker item)
        {
            Repository.Update(item);
        }
    }
}
