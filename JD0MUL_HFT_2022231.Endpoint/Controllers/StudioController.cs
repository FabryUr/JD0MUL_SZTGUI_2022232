using JD0MUL_HFT_2022231.Logic.Interfaces;
using JD0MUL_HFT_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JD0MUL_HFT_2022231.Endpoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudioController : ControllerBase
    {
        IStudioLogic logic;

        public StudioController(IStudioLogic logic)
        {
            this.logic = logic;
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
        }

        // PUT api/<StudioController>/5
        [HttpPut]
        public void Update([FromBody] Studio value)
        {
            this.logic.Update(value);
        }

        // DELETE api/<StudioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
