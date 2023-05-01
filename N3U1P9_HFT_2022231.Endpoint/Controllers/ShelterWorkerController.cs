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
    public class ShelterWorkerController : ControllerBase
    {
        IShelterWorkerLogic logic;
        IHubContext<SignalRHub> hub;

        public ShelterWorkerController(IShelterWorkerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<ShelterWorker> Get()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public ShelterWorker Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] ShelterWorker value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("ShelterWorkerCreated", value);
        }

        [HttpPut]
        public void Put([FromBody] ShelterWorker value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("ShelterWorkerUpdated", value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("ShelterWorkerDeleted", id);
        }
    }
}
