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
    public class RoleLogicTester
    {
        RoleLogic logic;
        Mock<IRepository<Role>> mockRoleRepo;
        [SetUp]
        public void Init()
        {
            mockRoleRepo = new Mock<IRepository<Role>>();
            mockRoleRepo.Setup(s => s.ReadAll()).Returns(new List<Role>()
            {
                new Role("1#1#1#RoleA"),
                new Role("2#2#2#RoleB"),
                new Role("3#3#3#RoleC"),
                new Role("4#4#4#RoleD")
            }.AsQueryable());
            logic = new RoleLogic(mockRoleRepo.Object);
        }
    }
}
