using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JD0MUL_HFT_2022231.Logic.Interfaces;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Models.SideClasses;
using JD0MUL_HFT_2022231.Repository;

namespace JD0MUL_HFT_2022231.Logic
{
    public class ActorLogic : IActorLogic
    {
        IRepository<Actor> repository;
        public ActorLogic(IRepository<Actor> repository)
        {
            this.repository = repository;
        }
        #region CRUD
        public void Create(Actor item)
        {
            if (item.ActorName.Length < 6)
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
            var actor = this.repository.Read(id);
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
        public ActorRateInfo ActorShowsAverage(int actorId)
        {
            var temp = repository.ReadAll().FirstOrDefault(t => t.ActorId == actorId);
            if (temp!=null)
            {
                return new ActorRateInfo { ActorName = repository.Read(actorId).ActorName, avgRating = temp.TvShows.Average(t => t.Rating) };
            }
            throw new ArgumentNullException("Id does not exist!");
        }
        public IEnumerable<ActorInfo> ActorBestTvShowRating()
        {
            var infos= new List<ActorInfo>();
            List<ActorInfoHelper> helper = repository.ReadAll().Select(t => new ActorInfoHelper
            {
                Actor = t,
                Titles = t.TvShows,
                Rating = t.TvShows.Select(t=>t.Rating)
            }).ToList();
            foreach (ActorInfoHelper info in helper)
            {
                infos.Add(new ActorInfo
                {
                    ActorName = info.Actor.ActorName,
                    Rating = info.Rating.Max(),
                    Titles = info.Titles.Where(t => t.Rating == info.Rating.Max()).Select(t => t.Title)//i dont understand why is it working with this solution, and no with another one, but working so i am glad with it
                });
            }
            return infos;
        }
        public class ActorInfoHelper
        {
            public Actor Actor { get; set; }
            public IEnumerable<TvShow> Titles { get; set; }
            public IEnumerable<double> Rating { get; set; }
        }
        #endregion
    }
}
