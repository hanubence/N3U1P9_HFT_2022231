using N3U1P9_HFT_2022231.Models;
using System.Linq;

namespace N3U1P9_HFT_2022231.Logic.Classes
{
    public interface IShelterWorkerLogic
    {
        void Create(ShelterWorker item);
        void Delete(int id);
        ShelterWorker Read(int id);
        IQueryable<ShelterWorker> ReadAll();
        void Update(ShelterWorker item);
    }
}