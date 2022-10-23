using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Repository;

namespace JD0MUL_HFT_2022231.Logic
{
    internal class StudioLogic
    {
        IRepository<Studio> repository;

        public StudioLogic(IRepository<Studio> repository)
        {
            this.repository = repository;
        }

        public void Create(Studio item)
        {
            if (item.StudioName.Length < 3)
            {
                throw new ArgumentException("Studio name too short!");
            }
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Studio Read(int id)
        {
            var studio = this.repository.Read(id);
            if (studio == null)
            {
                throw new ArgumentException("Studio does not exist!");
            }
            return this.repository.Read(id);
        }

        public IQueryable<Studio> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Studio item)
        {
            this.repository.Update(item);
        }
    }
}
