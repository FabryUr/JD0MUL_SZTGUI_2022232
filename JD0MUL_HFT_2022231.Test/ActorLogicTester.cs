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
        }
    }
}
