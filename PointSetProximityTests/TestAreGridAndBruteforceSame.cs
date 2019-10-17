using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PointSetProximityLibray.Test
{
    [TestClass]
    public class TestAreGridAndBruteforceSame
    {
        private double epsilon;
        private int width = 800;
        private int height = 800;
        private int count = 10000;
        List<Point> points;
        List<bool> ClosePoints;

       [TestMethod]
        public void RandomTest()
        {
            GeneratePoints();
            epsilon = CalculateEpsilon();
            CheckEachPointAndMakeBoolList();
            int AmountNotEqual = ClosePoints.Count(c => c == false);
            bool AllEqual = !ClosePoints.Contains(false);
            Assert.IsTrue(AllEqual);
        }

        private void GeneratePoints()
        {
            RandomPointListGenerator random = new RandomPointListGenerator(10);
            random.CreateList(height, width, count);
            points = random.GetList();
        }

        public void CheckEachPointAndMakeBoolList()
        {
            IPointProximity bruteforce = new Bruteforce(points, epsilon);
            IPointProximity grid = new Grid(points, epsilon);
            ClosePoints = new List<bool>();
            foreach (Point p in points)
            {
                bool equalBruteforce = bruteforce.PointIsCloseToOtherPoints(p);
                bool equalGrid = grid.PointIsCloseToOtherPoints(p);
                ClosePoints.Add(equalBruteforce == equalGrid);
            }
        }

        
             
        private double CalculateEpsilon() => Math.Sqrt(width * height / count) / 2.0;
    }
}
