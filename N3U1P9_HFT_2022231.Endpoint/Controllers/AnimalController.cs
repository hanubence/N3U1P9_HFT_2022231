using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using N3U1P9_HFT_2022231.Endpoint.Services;
using N3U1P9_HFT_2022231.Logic;
using N3U1P9_HFT_2022231.Models;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace N3U1P9_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        IAnimalLogic logic;
        IHubContext<SignalRHub> hub;

        public AnimalController(IAnimalLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("AnimalCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Animal value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("AnimalUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var animalToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("AnimalDeleted", animalToDelete);
        }
    }
}
