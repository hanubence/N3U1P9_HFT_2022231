using Microsoft.AspNetCore.Mvc;
using N3U1P9_HFT_2022231.Logic;
using System.Collections.Generic;

namespace N3U1P9_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatsController : ControllerBase
    {
        IShelterLogic logic;
        public StatsController(IShelterLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public double? GetAverageBudget()
        {
            return this.logic.GetAverageBudget();
        }

        [HttpGet]
        public IEnumerable<ShelterSalaryInfo> GetAverageSalaryByShelter()
        {
            return this.logic.GetAverageSalaryByShelter();
        }

        [HttpGet]
        public IEnumerable<WorkerOccupationInfo> GetWorkerOccupationCountByShelter()
        {
            return this.logic.GetWorkerOccupationCountByShelter();
        }

        [HttpGet]
        public IEnumerable<AnimalSpecieInfo> GetAnimalSpeciesCountByShelter()
        {
            return this.logic.GetAnimalSpeciesCountByShelter();
        }

        [HttpGet]
        public IEnumerable<AnimalAgeInfo> GetAverageAnimalAgeByShelter()
        {
            return this.logic.GetAverageAnimalAgeByShelter();
        }
    }
}
