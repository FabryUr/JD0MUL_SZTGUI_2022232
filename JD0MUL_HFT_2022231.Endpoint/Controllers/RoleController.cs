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
    public class RoleController : ControllerBase
    {
        IRoleLogic logic;
        IHubContext<SignalRHub> hub;

        public RoleController(IRoleLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public IEnumerable<Role> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public Role Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public void Create([FromBody] Role value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("RoleCreated", value);
        }

        // PUT api/<RoleController>/5
        [HttpPut]
        public void Update([FromBody] Role value)
        {
            this.logic.Update(value);
            this.hub.Clients.All.SendAsync("RoleUpdated", value);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var roleToDelete = this.logic.Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("RoleDeleted", roleToDelete);
        }
    }
}
