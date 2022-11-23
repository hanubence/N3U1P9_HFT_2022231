﻿using Microsoft.AspNetCore.Mvc;
using N3U1P9_HFT_2022231.Logic;
using N3U1P9_HFT_2022231.Models;
using System.Collections.Generic;

namespace N3U1P9_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShelterWorkerController : ControllerBase
    {
        IShelterWorkerLogic logic;

        public ShelterWorkerController(IShelterWorkerLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut("{id}")]
        public void Put([FromBody] ShelterWorker value)
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