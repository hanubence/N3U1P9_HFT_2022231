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
    public class ShelterController : ControllerBase
    {
        IShelterLogic logic;
        IHubContext<SignalRHub> hub;

        public ShelterController(IShelterLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("ShelterCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] Shelter value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("ShelterUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ShelterDeleted", id);
        }
    }
}
