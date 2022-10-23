using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Repository;

namespace JD0MUL_HFT_2022231.Logic
{
    internal class ActorLogic
    {
        IRepository<Actor> repository;
        public ActorLogic(IRepository<Actor> repository)
        {
            this.repository = repository;
        }
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
    }
}
