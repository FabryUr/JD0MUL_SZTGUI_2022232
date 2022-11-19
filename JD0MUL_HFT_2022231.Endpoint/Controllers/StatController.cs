using JD0MUL_HFT_2022231.Logic.Interfaces;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Models.SideClasses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static JD0MUL_HFT_2022231.Logic.ActorLogic;
using static JD0MUL_HFT_2022231.Logic.StudioLogic;
using static JD0MUL_HFT_2022231.Logic.TvShowLogic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JD0MUL_HFT_2022231.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        ITvShowLogic tvShowLogic;
        IStudioLogic studioLogic;
        IActorLogic actorLogic;

        public StatController(ITvShowLogic tvShowLogic, IStudioLogic studioLogic, IActorLogic actorLogic)
        {
            this.tvShowLogic = tvShowLogic;
            this.studioLogic = studioLogic;
            this.actorLogic = actorLogic;
        }

        // GET: api/<StatController>
        [HttpGet]
        public IEnumerable<Best> BestTvShowRoles()
        {
            return tvShowLogic.BestTvShowRoles();
        }
        [HttpGet]
        public IEnumerable<Worst> WorstShowActors()
        {
            return tvShowLogic.WorstShowActors();
        }
        [HttpGet]
        public IEnumerable<StudioInfo> LargestStudio()
        {
            return studioLogic.LargestStudio();
        }
        [HttpGet("{id}")]
        public ActorRateInfo ActorShowsAverage(int id)
        {
            return actorLogic.ActorShowsAverage(id);
        }
        [HttpGet]
        public IEnumerable<ActorInfo> ActorBestTvShowRating()
        {
            return actorLogic.ActorBestTvShowRating();
        }
    }
}
