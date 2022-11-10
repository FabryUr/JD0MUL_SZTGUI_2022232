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
using static JD0MUL_HFT_2022231.Logic.StudioLogic;

namespace JD0MUL_HFT_2022231.Test
{
    [TestFixture]
    public class StudioLogicTester
    {
        StudioLogic StudioLogic;
        Mock<IRepository<Studio>> mockStudioRepo;
        IQueryable<Studio> Studios;
        [SetUp]
        public void SetUp()
        {
            mockStudioRepo = new Mock<IRepository<Studio>>();
            Studios = new List<Studio>()
            {
                new Studio("1#StudioA")
                {
                    TvShows = new List<TvShow>()
                    {
                        new TvShow("2#TvShowB#1#2019#2020#6,5"),
                        new TvShow("4#TvShowD#1#2007#2010#10")
                    }
                },
                new Studio("2#StudioB")
                {
                    TvShows = new List<TvShow>()
                    {
                    new TvShow("1#TvShowA#2#2004#2008#9,4")
                    }
                },
                new Studio("3#StudioC")
                {
                TvShows = new List < TvShow >()
                {
                new TvShow("3#TvShowC#3#2006#2010#8")
                }
                }
            }.AsQueryable();
            mockStudioRepo.Setup(s => s.ReadAll()).Returns(Studios);
            StudioLogic = new StudioLogic(mockStudioRepo.Object);
        }
        [Test]
        public void ReadStudioExceptionTest()
        {
            //ASSERT
            Assert.That(() => StudioLogic.Read(5), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void CreateStudioExceptionTest()
        {
            var studio = new Studio() { StudioName = "CN" };
            //ASSERT
            Assert.That(() => StudioLogic.Create(studio), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void LargestStudioTest()
        {
            var actual=StudioLogic.LargestStudio();
            var expected = new List<StudioInfo>()
            {
                new StudioInfo(){
                StudioId = 1,
                StudioName = "StudioA",
                ShowNumber = 2,
                TvShowTitles = new List<string>
                {
                    "TvShowB","TvShowD"
                }
                }
            };
            //ASSERT
            Assert.AreEqual(expected, actual);
            ;
        }
    }
}
