using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Repository;

namespace JD0MUL_HFT_2022231.Logic
{
    internal class RoleLogic
    {
        IRepository<Role> repository;

        public RoleLogic(IRepository<Role> repository)
        {
            this.repository = repository;
        }

        public void Create(Role item)
        {
            if (item.RoleName.Length <6 )
            {
                throw new ArgumentException("Role name is too short!");
            }
            this.repository.Create(item);
        }

        public void Delete(int id)
        {
            this.repository.Delete(id);
        }

        public Role Read(int id)
        {
            var role = this.repository.Read(id);
            if (role == null)
            {
                throw new ArgumentException("Role does not exist!");
            }
            return this.repository.Read(id);
        }

        public IQueryable<Role> ReadAll()
        {
            return this.repository.ReadAll();
        }

        public void Update(Role item)
        {
            this.repository.Update(item);
        }
    }
}
