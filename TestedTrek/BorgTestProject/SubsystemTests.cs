using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationProject;
using System;

namespace BorgTestProject
{
    [TestClass]
    public class SubsystemTests
    {

        [TestMethod]
        public void GetDamage()
        {
            var subsystem = new Subsystem();

            subsystem.Damage = 100;

            Assert.AreEqual(100, subsystem.Damage);
        }


        [TestMethod]
        public void TakeDamage()
        {
            var subsystem = new Subsystem();

            subsystem.TakeDamage(100);

            Assert.AreEqual(100, subsystem.Damage);
        }


        [TestMethod]
        public void IsOperationalTrue()
        {
            var subsystem = new Subsystem();

            Assert.IsTrue(subsystem.IsOperational);
        }


        [TestMethod]
        public void IsOperationalFalse()
        {
            var subsystem = new Subsystem();

            subsystem.TakeDamage(100);

            Assert.IsFalse(subsystem.IsOperational);
        }

        [DataRow("Phasers", 300)]
        [TestMethod]
        public void Repair(string subsystemName, int repairRate)
        {
            var subsystem = new Subsystem(subsystemName, repairRate);

            subsystem.TakeDamage(300);

            subsystem.Repair(1);

            Assert.IsTrue(subsystem.IsOperational);
        }


    }

}
