using JD0MUL_HFT_2022231.Logic.Interfaces;
using JD0MUL_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JD0MUL_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        IActorLogic logic;

        public ActorController(IActorLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<ActorController>
        [HttpGet]
        public IEnumerable<Actor> ReadAll()
        {
            return this.logic.ReadAll();
        }

        // GET api/<ActorController>/5
        [HttpGet("{id}")]
        public Actor Read(int id)
        {
            return this.logic.Read(id);
        }

        // POST api/<ActorController>
        [HttpPost]
        public void Create([FromBody] Actor value)
        {
            this.logic.Create(value);
        }

        // PUT api/<ActorController>/5
        [HttpPut]
        public void Update([FromBody] Actor value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<ActorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
