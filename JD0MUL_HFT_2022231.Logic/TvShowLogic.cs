using System;
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
                throw new ArgumentException("TvShow does not exist");
            }
            return this.repository.Read(id);
        }

        public IQueryable<TvShow> ReadAll()
        {
            return repository.ReadAll();
        }

        public void Update(TvShow item)
        {
            this.repository.Update(item);
        }
    }
}
