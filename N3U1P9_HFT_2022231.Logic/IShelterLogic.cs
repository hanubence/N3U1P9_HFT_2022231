using N3U1P9_HFT_2022231.Models;
using System.Linq;

namespace N3U1P9_HFT_2022231.Logic
{
    public interface IShelterLogic
    {
        void Create(Shelter item);
        void Delete(int id);
        double? GetAverageBudget();
        Shelter Read(int id);
        IQueryable<Shelter> ReadAll();
        void Update(Shelter item);
    }
}