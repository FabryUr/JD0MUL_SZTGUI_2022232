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
    public class TvShowController : ControllerBase
    {
        ITvShowLogic logic;
        IHubContext<SignalRHub> hub;

        public TvShowController(ITvShowLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<TvShowController>
        [HttpGet]
        public IEnumerable<TvShow> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<TvShowController>/5
        [HttpGet("{id}")]
        public TvShow Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<TvShowController>
        [HttpPost]
        public void Create([FromBody] TvShow value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("TvShowCreated", value);
        }

        // PUT api/<TvShowController>/5
        [HttpPut]
        public void Update([FromBody] TvShow value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("TvShowUpdated", value);
        }

        // DELETE api/<TvShowController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var tvShowToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("TvShowDeleted", tvShowToDelete);
        }
    }
}
