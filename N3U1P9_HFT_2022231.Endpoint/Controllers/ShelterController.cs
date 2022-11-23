using Microsoft.AspNetCore.Mvc;
using N3U1P9_HFT_2022231.Logic;
using N3U1P9_HFT_2022231.Models;
using System.Collections.Generic;

namespace N3U1P9_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShelterController : ControllerBase
    {
        IShelterLogic logic;

        public ShelterController(IShelterLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Shelter> Get()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Shelter Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Shelter value)
        {
            this.logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Shelter value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
