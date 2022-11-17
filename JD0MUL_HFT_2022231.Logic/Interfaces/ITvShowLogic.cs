using JD0MUL_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace JD0MUL_HFT_2022231.Logic.Interfaces
{
    public interface ITvShowLogic
    {
        IEnumerable<TvShowLogic.Best> BestTvShowRoles();
        void Create(TvShow item);
        void Delete(int id);
        TvShow Read(int id);
        IQueryable<TvShow> ReadAll();
        void Update(TvShow item);
        IEnumerable<Actor> WorstShowActors();
    }
}