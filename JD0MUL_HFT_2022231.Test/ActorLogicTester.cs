using JD0MUL_HFT_2022231.Logic;
using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JD0MUL_HFT_2022231.Test
{
    [TestFixture]
    public class ActorLogicTester
    {
        ActorLogic logic;
        Mock<IRepository<Actor>> mockActorRepo;
        IQueryable<Actor> Actors;
        [SetUp]
        public void SetUp()
        {
            mockActorRepo = new Mock<IRepository<Actor>>();
            Actors = new List<Actor>()
            {
                new Actor("1#ActorA"),
                new Actor("2#ActorB"),
                new Actor("3#ActorC"),
                new Actor("4#ActorD")
            }.AsQueryable();
            mockActorRepo.Setup(s => s.ReadAll()).Returns(Actors);
            logic = new ActorLogic(mockActorRepo.Object);
        }
        [Test]
        public void CreateActorWithCorrectNameTest()
        {
            var actor = new Actor() { ActorName="Jason Stathan" };
            //ACT
            logic.Create(actor);
            //ASSERT
            mockActorRepo.Verify(r => r.Create(actor), Times.Once);
        }
        [Test]
        public void ReadActorExceptionTest()
        {
            //ASSERT
            Assert.That(() => logic.Read(5), Throws.TypeOf<ArgumentException>());
        }
        [Test]
        public void CreateActorExceptionTest()
        {
            var actor = new Actor() { ActorName = "Jolly" };
            //ASSERT
            Assert.That(()=>logic.Create(actor), Throws.TypeOf<ArgumentException>());
        }
    }
}
