using JD0MUL_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD0MUL_HFT_2022231.Repository
{
    public class TvShowRepository : Repository<TvShow>, IRepository<TvShow>
    {
        public TvShowRepository(TvShowDbContext ctx) : base(ctx)
        {
        }

        public override TvShow Read(int id)
        {
            return ctx.TvShows.FirstOrDefault(t => t.TvShowId == id);
        }

        public override void Update(TvShow item)
        {
            var old = Read(item.TvShowId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
