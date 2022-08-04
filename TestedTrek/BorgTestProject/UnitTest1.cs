using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationProject;

namespace BorgTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShieldDownByDefault()
        {
            var shield = new Shield();

            Assert.IsFalse(shield.IsUp());
        }

        [TestMethod]
        public void ShieldCanBeRaise()
        {
            var shield = new Shield();

            shield.Raise();

            Assert.IsTrue(shield.IsUp());
        }

        [TestMethod]
        public void ShieldCanBeLowered()
        {
            var shield = new Shield();

            shield.Raise();

            shield.Lower();

            Assert.IsFalse(shield.IsUp());
        }

        [TestMethod]
        public void ShieldHasUnitsByDefault()
        {
            var shield = new Shield();

            Assert.AreEqual(8000, shield.Units);
        }

    }
}
