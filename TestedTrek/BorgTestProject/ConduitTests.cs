using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ImplementationProject;

namespace BorgTestProject
{
    [TestClass]
    public class ConduitTests
    {
        [TestMethod]
        public void SendsEnergy()
        {
            var shield1 = new Shield();
            var shield2 = new Shield();

            var conduit = new EnergyTransfer(shield1, shield2);

            conduit.SendEnergy(100);

            Assert.AreEqual(7900, shield1.Units);
            Assert.AreEqual(8100, shield2.Units);
        }
    }
}
