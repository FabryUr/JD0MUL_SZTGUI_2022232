using JD0MUL_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;

namespace JD0MUL_HFT_2022231.Logic.Interfaces
{
    public interface IStudioLogic
    {
        void Create(Studio item);
        void Delete(int id);
        IEnumerable<StudioLogic.StudioInfo> LargestStudio();
        Studio Read(int id);
        IQueryable<Studio> ReadAll();
        void Update(Studio item);
    }
}