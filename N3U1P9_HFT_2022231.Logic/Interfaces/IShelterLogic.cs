using N3U1P9_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace N3U1P9_HFT_2022231.Logic
{
    public interface IShelterLogic
    {
        void Create(Shelter item);
        void Delete(int id);
        IEnumerable<AnimalSpecieInfo> GetAnimalSpeciesCountByShelter();
        IEnumerable<AnimalAgeInfo> GetAverageAnimalAgeByShelter();
        double? GetAverageBudget();
        IEnumerable<ShelterSalaryInfo> GetAverageSalaryByShelter();
        IEnumerable<WorkerOccupationInfo> GetWorkerOccupationCountByShelter();
        Shelter Read(int id);
        IQueryable<Shelter> ReadAll();
        void Update(Shelter item);
    }
}