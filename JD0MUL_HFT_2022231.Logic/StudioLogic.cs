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
    public class StudioLogic
    {
        IRepository<Studio> repository;

        public StudioLogic(IRepository<Studio> repository)
        {
            this.repository = repository;
        }
        #region CRUDs
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
        #endregion
        #region nonCRUDs
        //Which studio did make most shows
        public IEnumerable<StudioInfo> LargestStudio()
        {
            var maxTvShow = repository.ReadAll().Max(t => t.TvShows.Count);
           return repository.ReadAll()
                .Where(t => t.TvShows.Count == maxTvShow)
                .Select(t => new StudioInfo { StudioId=t.StudioId, StudioName=t.StudioName, ShowNumber=maxTvShow, TvShowTitles=t.TvShows.Select(t=>t.Title) });
        }
        public class StudioInfo
        {
            public int StudioId { get; set; }
            public string StudioName { get; set; }
            public int ShowNumber { get; set; }
            public IEnumerable<string> TvShowTitles { get; set; }
            public override bool Equals(object obj)
            {
                StudioInfo b = obj as StudioInfo;
                if (b == null) return false;
                else
                    return this.StudioName == b.StudioName && this.StudioId == b.StudioId && this.ShowNumber== b.ShowNumber;
            }
            public override int GetHashCode()
            {
                return HashCode.Combine(this.StudioName, this.StudioId, this.ShowNumber);
            }
        }
        #endregion
    }
}
