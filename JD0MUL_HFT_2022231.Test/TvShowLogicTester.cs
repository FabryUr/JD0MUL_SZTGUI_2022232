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

        TvShowLogic TvShowLogic;
        StudioLogic StudioLogic;
        ActorLogic ActorLogic;
        RoleLogic RoleLogic;

        IQueryable<TvShow> TvShows;
        IQueryable<Studio> Studios;
        IQueryable<Actor> Actors;
        IQueryable<Role> Roles;

        [SetUp]
        public void SetUp()
        {
            TvShows = new List<TvShow>()
            {
                new TvShow("1#TvShowA#2#2004#2008#9,4"),
                new TvShow("2#TvShowB#1#2019#2020#6,5"),
                new TvShow("3#TvShowC#3#2006#2010#8"),
                new TvShow("4#TvShowD#1#2007#2010#10")
            }.AsQueryable();
            Studios = new List<Studio>()
            {
                new Studio("1#StudioA"),
                new Studio("2#StudioB"),
                new Studio("3#StudioC"),
                new Studio("4#StudioD")
            }.AsQueryable();
            Actors = new List<Actor>()
            {
                new Actor("1#ActorA"),
                new Actor("2#ActorB"),
                new Actor("3#ActorC"),
                new Actor("4#ActorD")
            }.AsQueryable();
            Roles = new List<Role>()
            {
                new Role("1#1#1#RoleA"),
                new Role("2#2#2#RoleB"),
                new Role("3#3#3#RoleC"),
                new Role("4#3#4#RoleD")
            }.AsQueryable();

            mockTvShowRepo = new();
            mockStudioRepo = new();
            mockActorRepo = new();
            mockRoleRepo = new();

            mockTvShowRepo.Setup(m => m.ReadAll()).Returns(TvShows);
            mockStudioRepo.Setup(m => m.ReadAll()).Returns(Studios);
            mockActorRepo.Setup(m => m.ReadAll()).Returns(Actors);
            mockRoleRepo.Setup(m => m.ReadAll()).Returns(Roles);

            TvShowLogic = new TvShowLogic(mockTvShowRepo.Object);
            StudioLogic = new StudioLogic(mockStudioRepo.Object);
            ActorLogic = new ActorLogic(mockActorRepo.Object);
            RoleLogic = new RoleLogic(mockRoleRepo.Object);
        }        
        [Test]
        public void ReadTvShowExceptionTest()
        {
            ////Arrange
            //TvShow expected = new TvShow
            //{
            //    TvShowId = 1,
            //    Title = "TvShowA"
            //};
            //mockTvShowRepo
            //    .Setup(r => r.Read(1))
            //    .Returns(expected);
            ////Act
            //var actual = TvShowLogic.Read(1);
            ////ASSERT
            //Assert.That(actual, Is.EqualTo(expected))
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
