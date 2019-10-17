using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;

namespace PointSetProximityLibray.Test
{
    [TestClass]
    public class IPointProximityTests
    {
        [TestMethod]
        public void TestIPointProximity()
        {
            double epsilon = 2;
            Point p = new Point(0, 0);
            List<Point> points = new List<Point>();
            IPointProximity testGrid = new Grid(points, epsilon);
            IPointProximity testBruteforce = new Bruteforce(points, epsilon);
            bool PointIsCloseGrid = testGrid.PointIsCloseToOtherPoints(p);
            bool PointIsCloseBruteforce = testBruteforce.PointIsCloseToOtherPoints(p);
            Assert.IsFalse(PointIsCloseGrid && PointIsCloseBruteforce);
        }
    }
}
