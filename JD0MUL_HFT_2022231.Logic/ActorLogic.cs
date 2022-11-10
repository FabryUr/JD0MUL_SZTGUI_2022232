using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Repository;
using static JD0MUL_HFT_2022231.Logic.TvShowLogic;

namespace JD0MUL_HFT_2022231.Logic
{
    public class ActorLogic
    {
        IRepository<Actor> repository;
        public ActorLogic(IRepository<Actor> repository)
        {
            this.repository = repository;
        }
        #region CRUD
        public void Create(Actor item)
        {
            if (item.ActorName.Length<6)
            {
                throw new ArgumentException("Actor name too short!");
            }
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Actor Read(int id)
        {
            var actor=this.repository.Read(id);
            if (actor == null)
            {
                throw new ArgumentException("Actor does not exist");
            }
            return this.repository.Read(id);
        }

        public IQueryable<Actor> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Actor item)
        {
            this.repository.Update(item);
        }
#endregion
        #region nonCRUDs
        public double ActorShowsAverage(int actorId)
        {
            return repository.ReadAll()
                .FirstOrDefault(t => t.ActorId == actorId).TvShows.Average(t=>t.Rating);
        }
        public IEnumerable<ActorInfo> ActorBestTvShowRating()
        {
             return this.repository.ReadAll()
                .Select(t=>new ActorInfo { ActorName=t.ActorName, Rating=t.TvShows
                    .Max(t=>t.Rating), Title=t.TvShows
                        .Where(r=>r.Rating==t.TvShows.Max(z=>z.Rating)).Select(r=>r.Title)});
        }
        public class ActorInfo
        {
            public string ActorName { get; set; }
            public IEnumerable<string> Title { get; set; }
            public double Rating { get; set; }
            public override bool Equals(object obj)
            {
                ActorInfo b = obj as ActorInfo;
                if (b == null) return false;
                else
                    return this.ActorName == b.ActorName && this.Rating == b.Rating;
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.ActorName, this.Rating);
            }
        }
        #endregion
    }
}
