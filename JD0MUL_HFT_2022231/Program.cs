using System;
using System.Linq;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Repository;

namespace JD0MUL_HFT_2022231
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            TvShowDbContext ctx = new TvShowDbContext();
            var items = ctx.TvShows.ToArray();
            ;
        }
    }
}
