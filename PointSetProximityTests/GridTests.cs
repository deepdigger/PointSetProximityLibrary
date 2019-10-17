using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;

namespace PointSetProximityLibray.Test
{
    [TestClass]
    public class GridTests
    {
        [TestMethod]
        public void TestIsPointCloseToEmptyListOfPoints()
        {
            Point p1 = new Point(0, 0);
            List<Point> points = new List<Point>();
            Grid grid = new Grid(points, 2.0);
            bool actual = grid.PointIsCloseToOtherPoints(p1);
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void TestSamePoints()
        {
            Point p1 = new Point(0, 0);
            Point ListPoint = new Point(0, 0);
            List<Point> points = new List<Point>
            {
                ListPoint
            };
            Grid grid = new Grid(points, 2.0);
            bool actual = grid.PointIsCloseToOtherPoints(p1);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddedEpsilon_OtherPointDistanceLowerThanEpsilon()
        {
            Point p1 = new Point(0, 0);
            Point ListPoint = new Point(1, 0);
            double epsilon = 2;
            List<Point> points = new List<Point>
            {
                ListPoint
            };
            Grid grid = new Grid(points, epsilon);
            bool actual = grid.PointIsCloseToOtherPoints(p1);
            bool expected = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddedEpsilon_OtherPointDistanceLargerThanEpsilon()
        {
            Point p1 = new Point(0, 0);
            Point ListPoint = new Point(3, 0);
            double epsilon = 2;
            List<Point> points = new List<Point>
            {
                ListPoint
            };
            Grid grid = new Grid(points, epsilon);
            bool actual = grid.PointIsCloseToOtherPoints(p1);
            bool expected = false;
            Assert.AreEqual(expected, actual);
        }

    }
}
