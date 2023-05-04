using JD0MUL_HFT_2022231.Endpoint.Services;
using JD0MUL_HFT_2022231.Logic.Interfaces;
using JD0MUL_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JD0MUL_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        IStudioLogic logic;
        IHubContext<SignalRHub> hub;

        public StudioController(IStudioLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<StudioController>
        [HttpGet]
        public IEnumerable<Studio> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<StudioController>/5
        [HttpGet("{id}")]
        public Studio Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<StudioController>
        [HttpPost]
        public void Create([FromBody] Studio value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("StudioCreated", value);
        }

        // PUT api/<StudioController>/5
        [HttpPut]
        public void Update([FromBody] Studio value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("StudioUpdated", value);
        }

        // DELETE api/<StudioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var studioToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("StudioDeleted", studioToDelete);
        }
    }
}
