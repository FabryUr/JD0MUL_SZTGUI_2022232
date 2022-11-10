using JD0MUL_HFT_2022231.Logic;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using static JD0MUL_HFT_2022231.Logic.ActorLogic;

namespace JD0MUL_HFT_2022231.Test
{
    [TestFixture]
    public class ActorLogicTester
    {
        ActorLogic ActorLogic;
        Mock<IRepository<Actor>> mockActorRepo;
        IQueryable<Actor> Actors;
        [SetUp]
        public void SetUp()
        {
            mockActorRepo = new Mock<IRepository<Actor>>();
            Actors = new List<Actor>()
            {
                new Actor("1#ActorA")
                {
                   TvShows= new List<TvShow>()
                   {new TvShow("1#TvShowA#2#2004#2008#9"),
                   new TvShow("3#TvShowC#3#2006#2010#8")
                   }
                },
                new Actor("2#ActorB")
                {
                    TvShows= new List<TvShow>()
                    {new TvShow("1#TvShowA#2#2004#2008#9"),
                    new TvShow("4#TvShowE#1#2007#2014#10")
                    }
                }
            }.AsQueryable();
            mockActorRepo.Setup(s => s.ReadAll()).Returns(Actors);
            ActorLogic = new ActorLogic(mockActorRepo.Object);
        }
        #region CRUD Tests
        [Test]
        public void CreateActorWithCorrectNameTest()
        {
            var actor = new Actor() { ActorName="Jason Stathan" };
            //ACT
            ActorLogic.Create(actor);
            //ASSERT
            mockActorRepo.Verify(r => r.Create(actor), Times.Once);
        }
        [Test]
        public void ReadActorExceptionTest()
        {
            //ASSERT
            Assert.That(() => ActorLogic.Read(5), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void CreateActorExceptionTest()
        {
            var actor = new Actor() { ActorName = "Jolly" };
            //ASSERT
            Assert.That(()=>ActorLogic.Create(actor), Throws.TypeOf<ArgumentException>());
        }
        #endregion
        #region nonCRUD Tests
        [Test]
        public void ActorShowsAverageTest()
        {
            var expected =8.5;
            var actual = ActorLogic.ActorShowsAverage(1);
            //ASSERT
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ActorBestTvShowRatingTest()
        {
            var expected = new List<ActorInfo>
            {
                new ActorInfo()
                {
                    ActorName="ActorA",
                    Rating=9,
                    Title=new List<string>(){ "TvShowA" }
                },
                new ActorInfo()
                {
                    ActorName="ActorB",
                    Rating=10,
                    Title=new List<string>(){ "TvShowE" }
                }
            };
            var actual = ActorLogic.ActorBestTvShowRating();
            //ASSERT
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
