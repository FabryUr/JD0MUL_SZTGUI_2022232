using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Models.SideClasses;
using System.Collections.Generic;
using System.Linq;

namespace JD0MUL_HFT_2022231.Logic.Interfaces
{
    public interface IActorLogic
    {
        IEnumerable<ActorInfo> ActorBestTvShowRating();
        ActorRateInfo ActorShowsAverage(int actorId);
        void Create(Actor item);
        void Delete(int id);
        Actor Read(int id);
        IQueryable<Actor> ReadAll();
        void Update(Actor item);
    }
}