using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationProject;
using System;

namespace BorgTestProject
{
    [TestClass]
    public class ShipTests
    {
        //20000


        [TestMethod]
        public void InitialRandomValue()
        {
            var ship = new Ship
            {
                SubsystemCount = 1
            };
            Assert.AreEqual(0, ship.GetRandomValue(ship.SubsystemCount));
        }


        [TestMethod]
        public void GetRandomSystem()
        {
            var ship = new Ship
            {
                SubsystemCount = 1
            };
            Assert.IsNotNull(ship.GetRandomSystem());
        }


    }

}
