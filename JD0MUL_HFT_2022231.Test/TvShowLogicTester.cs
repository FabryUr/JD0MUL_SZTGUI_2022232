using JD0MUL_HFT_2022231.Logic;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD0MUL_HFT_2022231.Test
{
    [TestFixture]
    public class TvShowLogicTester
    {
        TvShowLogic logic;
        Mock<IRepository<TvShow>> mockTvShowRepo;
        [SetUp]
        public void Init()
        {
            mockTvShowRepo = new Mock<IRepository<TvShow>>();
            mockTvShowRepo.Setup(m => m.ReadAll()).Returns(new List<TvShow>()
            {
                new TvShow("1#TvShowA#2#2004#2008#9,4"),
                new TvShow("2#TvShowB#1#2019#2020#6,5"),
                new TvShow("3#TvShowC#1#2006#2010#8"),
                new TvShow("4#TvShowD#1#2007#2010#10")
            }.AsQueryable());
            logic= new TvShowLogic(mockTvShowRepo.Object);
        }
    }
}
