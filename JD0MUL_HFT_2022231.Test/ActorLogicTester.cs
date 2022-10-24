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
        [SetUp]
        public void Init()
        {
            mockActorRepo = new Mock<IRepository<Actor>>();
            mockActorRepo.Setup(s => s.ReadAll()).Returns(new List<Actor>()
            {
                new Actor("1#1#1#RoleA"),
                new Actor("2#2#2#RoleB"),
                new Actor("3#3#3#RoleC"),
                new Actor("4#4#4#RoleD")
            }.AsQueryable());
            logic = new ActorLogic(mockActorRepo.Object);
        }
    }
}
