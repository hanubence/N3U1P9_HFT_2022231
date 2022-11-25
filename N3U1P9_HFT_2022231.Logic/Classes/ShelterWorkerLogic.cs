using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using N3U1P9_HFT_2022231.Repository;
using N3U1P9_HFT_2022231.Models;

namespace N3U1P9_HFT_2022231.Logic
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
            if (item.Name == null || item.Name.Length < 5 || item.Name.Length > 30) throw new ArgumentException("The name provided was either too short or too long");
            else if (item.ShelterId < 0) throw new ArgumentException("Incorrect was shelterID provided");
            Repository.Create(item);
        }

        public void Delete(int id)
        {
            Repository.Delete(id);
        }

        public ShelterWorker Read(int id)
        {
            ShelterWorker item = Repository.Read(id);
            if (item == null) throw new ArgumentException("No shelter worker exists with the given ID");
            return item;
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
