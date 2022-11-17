using JD0MUL_HFT_2022231.Models;
using System.Linq;

namespace JD0MUL_HFT_2022231.Logic.Interfaces
{
    public interface IRoleLogic
    {
        void Create(Role item);
        void Delete(int id);
        Role Read(int id);
        IQueryable<Role> ReadAll();
        void Update(Role item);
    }
}