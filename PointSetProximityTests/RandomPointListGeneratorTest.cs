using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PointSetProximityLibray.Test
{
    [TestClass]
    public class RandomPointListGeneratorTest
    {
        IPointGenerator random = new RandomPointListGenerator(10);

        [TestMethod]
        public void getEmtpyList()
        {
            PointListGeneratorMethods.getEmptyList(random);
        }

        [TestMethod]
        public void getOneZeroPointList()
        {
            PointListGeneratorMethods.getOneZeroPointList(random);
        }

        [TestMethod]
        public void getMultipleZeroPointsTest()
        {
            PointListGeneratorMethods.getMultipleZeroPointsTest(random);
        }

        [TestMethod]
        public void ThreePointsNotTheSame()
        {
            PointListGeneratorMethods.ThreePointsNotTheSame(random);
        }

        [TestMethod]
        public void PointsAreInRange()
        {
            PointListGeneratorMethods.ThreePointsNotTheSame(random);
        }

        [TestMethod]
        public void AmountOfPointsEqualsCount()
        {
            PointListGeneratorMethods.AmountOfPointsEqualsCount(random);
        }

        [TestMethod]
        public void DistrubutionIsEqual()
        {
            IPointGenerator pointGenerator = new RandomPointListGenerator(10);
            int count = 10000;
            int width = 200;
            int height = 200;
            pointGenerator.CreateList(width, height, count);
            List<Point> output = pointGenerator.GetList();
            double countXLargerThanHundred = output.Count(c => c.X > 100);
            double countYLargerThanHundred = output.Count(c => c.Y > 100);
            double percentXLargerThanHundret = countXLargerThanHundred / count;
            double percentYLargerThanHundret = countYLargerThanHundred / count;

            Assert.AreEqual(0.5, percentXLargerThanHundret, 0.01);
            Assert.AreEqual(0.5, percentYLargerThanHundret, 0.01);
        }
    }   
}
