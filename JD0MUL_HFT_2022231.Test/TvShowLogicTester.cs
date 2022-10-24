using JD0MUL_HFT_2022231.Logic;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static JD0MUL_HFT_2022231.Logic.TvShowLogic;

namespace JD0MUL_HFT_2022231.Test
{
    [TestFixture]
    public class TvShowLogicTester
    {
        Mock<IRepository<TvShow>> mockTvShowRepo;
        Mock<IRepository<Studio>> mockStudioRepo;
        Mock<IRepository<Actor>> mockActorRepo;
        Mock<IRepository<Role>> mockRoleRepo;

        TvShowLogic TvShowlogic;
        StudioLogic StudioLogic;


        IQueryable<TvShow> TvShows;

        [SetUp]
        public void Init()
        {
            TvShows = new List<TvShow>()
            {
                new TvShow("1#TvShowA#2#2004#2008#9,4"),
                new TvShow("2#TvShowB#1#2019#2020#6,5"),
                new TvShow("3#TvShowC#3#2006#2010#8"),
                new TvShow("4#TvShowD#1#2007#2010#10")
            }.AsQueryable();
            mockTvShowRepo = new();
            //Assert.Throws<ArgumentException>(()=>Logic.create(mintaadat))
            //mockTvShowRepo.Setup(m => m.ReadAll()).Returns(new List<TvShow>()
            //{
            //    new TvShow("1#TvShowA#2#2004#2008#9,4"),
            //    new TvShow("2#TvShowB#1#2019#2020#6,5"),
            //    new TvShow("3#TvShowC#3#2006#2010#8"),
            //    new TvShow("4#TvShowD#1#2007#2010#10")
            //}.AsQueryable())
            //    mockTvShowRepo.Setup(m => m.Read(It.IsAny<int>())).Returns((int id)
            //logic = new TvShowLogic(mockTvShowRepo.Object);
            
            //mockStudioRepo = new Mock<IRepository<Studio>>();
            //mockStudioRepo.Setup(m => m.ReadAll()).Returns(new List<Studio>()
            //{
            //    new Studio("1#StudioA"),
            //    new Studio("2#StudioB"),
            //    new Studio("3#StudioC"),
            //    new Studio("4#StudioD")
            //}.AsQueryable());

            //mockActorRepo = new Mock<IRepository<Actor>>();
            //mockActorRepo.Setup(m => m.ReadAll()).Returns(new List<Actor>()
            //{
            //    new Actor("1#1#1#RoleA"),
            //    new Actor("2#2#2#RoleB"),
            //    new Actor("3#3#3#RoleC"),
            //    new Actor("4#4#4#RoleD")
            //}.AsQueryable());

            //mockRoleRepo = new Mock<IRepository<Role>>();
            //mockRoleRepo.Setup(m => m.ReadAll()).Returns(new List<Role>()
            //{
            //    new Role("1#1#1#RoleA"),
            //    new Role("2#2#2#RoleB"),
            //    new Role("3#3#3#RoleC"),
            //    new Role("4#4#4#RoleD")
            //}.AsQueryable());
        }
        [Test]
        public void ShowLengthTest()
        {
            var all = logic.ReadAll();
            var data = logic.Read(2);
            var actual = logic.ShowLength();
            var expected = new List<LengthInfo>()
            {
                new LengthInfo()
                {
                    Seasons=5,
                    TvShowNumber=2,
                    RoleNumber=4
                },
                new LengthInfo()
                {
                    Seasons=2,
                    TvShowNumber=1,
                    RoleNumber=2
                },
                new LengthInfo()
                {
                    Seasons=4,
                    TvShowNumber=1,
                    RoleNumber=2
                },
            };
            Assert.AreEqual(expected, actual);
        }
    }
}
