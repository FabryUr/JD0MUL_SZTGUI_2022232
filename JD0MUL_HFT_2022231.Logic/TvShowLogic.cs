using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Repository;
using Microsoft.EntityFrameworkCore;

namespace JD0MUL_HFT_2022231.Logic
{
    public class TvShowLogic
    {
        IRepository<TvShow> repository;
        public TvShowLogic(IRepository<TvShow> repository)
        {
            this.repository = repository;
        }
        #region CRUD
        public void Create(TvShow item)
        {
            if (item.Title.Length <3)//because the "YOU" TVshow is 3 letter long, shorter is not accepted
            {
                throw new ArgumentException("Title is too short!");
            }
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public TvShow Read(int id)
        {
            var tvShow = this.repository.Read(id);
            if (tvShow == null)
            {
                throw new ArgumentException("TvShow does not exist!");
            }
            return this.repository.Read(id);
        }

        public IQueryable<TvShow> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(TvShow item)
        {
            this.repository.Update(item);
        }
        #endregion
        //non CRUDs        
        //Who are the worst show's actors
        public IEnumerable<Actor> WorstShowActors()
        {
            var worstShowRating = this.repository.ReadAll().Min(t => t.Rating);
            var worstShow = this.repository.ReadAll().FirstOrDefault(t => t.Rating == worstShowRating);
            return this.repository.Read(worstShow.TvShowId).Actors.ToList();
        }
        public IEnumerable<Best> BestTvShowRoles()
        {
            var maxrating = repository.ReadAll().Max(t => t.Rating);
            return repository.ReadAll()
                .Where(t => t.Rating == maxrating)
                .Select(t=>new Best {Title=t.Title, Roles=t.Roles });
        }
        public class Best
        {
            public string Title { get; set; }
            public ICollection<Role> Roles { get; set; }
        }  
    }
}
