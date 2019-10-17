using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace PointSetProximityLibray.Test
{
    [TestClass]
    public class DistanceComputerTests
    {
        [TestMethod]
        public void EqualPointsHaveDistanceZero()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 0);
            double expected = 0;
            double actual = DistanceComputer.ComputeSquaredDistance(p1, p2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XareEqualYareDifferent()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 4);
            double expected = 16;
            double actual = DistanceComputer.ComputeSquaredDistance(p1, p2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void YareEqualXareDifferent()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(4, 0);
            double expected = 16;
            double actual = DistanceComputer.ComputeSquaredDistance(p1, p2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void XandYareDifferent()
        {
            Point p1 = new Point(3, 5);
            Point p2 = new Point(7, 2);
            double expected = 25;
            double actual = DistanceComputer.ComputeSquaredDistance(p1, p2);
            Assert.AreEqual(expected, actual);
        }

        /*[TestMethod, ExpectedException(typeof(ArgumentException))] 
        public void DoesThrowExeption()
        {
            Point p1 = new Point(3, 5);
            Point p2 = new Point(7, 2);
            double test = DistanceComputer.ComputeDistance(p1, p2 
        }*/
    }
}
