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
    public class StudioLogicTester
    {
        StudioLogic logic;
        Mock<IRepository<Studio>> mockStudioRepo;
        [SetUp]
        public void Init()
        {
            mockStudioRepo = new Mock<IRepository<Studio>>();
            mockStudioRepo.Setup(s => s.ReadAll()).Returns(new List<Studio>()
            {
                new Studio("1#StudioA"),
                new Studio("2#StudioB"),
                new Studio("3#StudioC"),
                new Studio("4#StudioD")
            }.AsQueryable());
            logic = new StudioLogic(mockStudioRepo.Object);
        }
    }
}
