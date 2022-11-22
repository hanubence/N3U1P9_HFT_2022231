using N3U1P9_HFT_2022231.Models;
using System.Linq;

namespace N3U1P9_HFT_2022231.Logic
{
    public interface IAnimalLogic
    {
        void Create(Animal item);
        void Delete(int id);
        Animal Read(int id);
        IQueryable<Animal> ReadAll();
        void Update(Animal item);
    }
}