using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Repository;

namespace JD0MUL_HFT_2022231.Logic
{
    public class TvShowLogic
    {
        IRepository<TvShow> repository;

        public TvShowLogic(IRepository<TvShow> repository)
        {
            this.repository = repository;
        }

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

        //non CRUDs
        public IEnumerable<LengthInfo> ShowLength()
        {
            return from x in this.repository.ReadAll()
                   group x by x.ReleaseYear - x.EndYear into g
                   select new LengthInfo()
                   {
                       Seasons = g.Key+1,
                       TvShowNumber=g.Count(),
                       RoleNumber=g.Sum(t=>t.Roles.Count())
                   };
        }
        public class LengthInfo
        {
            public int Seasons { get; set; }
            public int TvShowNumber { get; set; }
            public int RoleNumber { get; set; }

            public override bool Equals(object obj)
            {
                LengthInfo b=obj as LengthInfo;
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return this.Seasons == b.Seasons && this.TvShowNumber == b.TvShowNumber && this.RoleNumber == b.RoleNumber;
                }
            }

            public override int GetHashCode()
            {
                return HashCode.Combine(this.Seasons, this.TvShowNumber, this.RoleNumber);
            }
        }
    }
}
