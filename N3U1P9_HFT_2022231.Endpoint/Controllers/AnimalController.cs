using Microsoft.AspNetCore.Mvc;
using N3U1P9_HFT_2022231.Logic;
using N3U1P9_HFT_2022231.Models;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace N3U1P9_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        IAnimalLogic logic;

        public AnimalController(IAnimalLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Animal> Get()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Animal Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Animal value)
        {
            this.logic.Create(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Animal value)
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
