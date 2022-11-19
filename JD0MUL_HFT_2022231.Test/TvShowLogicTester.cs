using JD0MUL_HFT_2022231.Logic;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Models.SideClasses;
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

        TvShowLogic TvShowLogic;

        IQueryable<TvShow> TvShows;

        [SetUp]
        public void SetUp()
        {
            TvShows = new List<TvShow>()
            {
                new TvShow("1#TvShowA#2#2004#2008#9,4")
                {
                    Actors = new List<Actor>()
                    {
                        new Actor("1#ActorA")
                    },
                    Roles = new List<Role>()
                    {
                        new Role("1#1#1#RoleA")
                    },
                    Studio=new Studio("2#StudioB")
                },
                new TvShow("2#TvShowB#1#2019#2020#6,5")
                {
                    Actors = new List<Actor>()
                    {
                        new Actor("2#ActorB")
                    },
                    Roles = new List<Role>()
                    {
                        new Role("2#2#2#RoleB")
                    },
                    Studio=new Studio("1#StudioA")
                },
                new TvShow("3#TvShowC#3#2006#2010#8")
                {
                    Actors = new List<Actor>()
                    {
                        new Actor("3#ActorC"),
                        new Actor("4#ActorD")
                    },
                    Roles = new List<Role>()
                    {
                        new Role("3#3#3#RoleC"),
                        new Role("4#3#4#RoleD")
                    },
                    Studio=new Studio("3#StudioC")
                },
                new TvShow("4#TvShowD#1#2007#2010#10")
                {
                    Actors = new List<Actor>()
                    {
                        new Actor("1#ActorA")
                    },
                    Roles = new List<Role>()
                    {
                        new Role("5#4#1#RoleE")
                    },
                    Studio=new Studio("1#StudioA")
                }
            }.AsQueryable();

            mockTvShowRepo = new();

            mockTvShowRepo.Setup(m => m.ReadAll()).Returns(TvShows);

            mockTvShowRepo.Setup(m => m.Read(It.IsAny<int>())).Returns((int id)=>TvShows.Where(t=>t.TvShowId==id).FirstOrDefault());

            TvShowLogic = new TvShowLogic(mockTvShowRepo.Object);
        }
        [Test]
        public void WorstShowActorsTest()
        {
            //Act
            var actual = TvShowLogic.WorstShowActors();
            var expected = new List<Worst>() { new Worst(){  Title= "TvShowB", Actors=new List<Actor> { new Actor("2#ActorB") } } };
            //ASSERT
            Assert.AreEqual(expected,actual);
        }
        [Test]
        public void BestTvShowRolesTest()
        {
            //Act
            var actual =TvShowLogic.BestTvShowRoles();
            var expected =new List<Best>()
            {
                new Best()
                {
                    Title="TvShowD",
                    Roles=new List<Role>()
                    {
                        new Role("5#4#1#RoleE")
                    }
                }
            };
            //ASSERT
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ReadTvShowExceptionTest()
        {
            //ASSERT
            Assert.That(() => TvShowLogic.Read(5), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void CreateTvShowExceptionTest()
        {
            var tvShow = new TvShow() { Title = "Me" };
            //ASSERT
            Assert.That(() => TvShowLogic.Create(tvShow), Throws.TypeOf<ArgumentException>());
        }
    }
}
