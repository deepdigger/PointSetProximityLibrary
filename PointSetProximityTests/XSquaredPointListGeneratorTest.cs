using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PointSetProximityLibray.Test
{
    [TestClass]
    public class XSquaredPointListGeneratorTest
    {
        IPointGenerator generator = new XSquaredPointListGenerator(10);

        [TestMethod]
        public void getEmtpyList()
        {
            PointListGeneratorMethods.getEmptyList(generator);
        }

        [TestMethod]
        public void getOneZeroPointList()
        {
            PointListGeneratorMethods.getOneZeroPointList(generator);
        }

        [TestMethod]
        public void getMultipleZeroPointsTest()
        {
            PointListGeneratorMethods.getMultipleZeroPointsTest(generator);
        }

        [TestMethod]
        public void ThreePointsNotTheSame()
        {
            PointListGeneratorMethods.ThreePointsNotTheSame(generator);
        }

        [TestMethod]
        public void PointsAreInRange()
        {
            PointListGeneratorMethods.ThreePointsNotTheSame(generator);
        }

        [TestMethod]
        public void AmountOfPointsEqualsCount()
        {
            PointListGeneratorMethods.AmountOfPointsEqualsCount(generator);
        }

        [TestMethod]
        public void DistrubutionIsNotEqual()
        {
            IPointGenerator pointGenerator = new XSquaredPointListGenerator(10);
            int count = 10000;
            int width = 200;
            int height = 200;
            pointGenerator.CreateList(width, height, count);
            List<Point> output = pointGenerator.GetList();
            double countXLargerThanHundred = output.Count(c => c.X > 100);
            double countYLargerThanHundred = output.Count(c => c.Y > 100);
            double percentXLargerThanHundret = countXLargerThanHundred / count;
            double percentYLargerThanHundret = countYLargerThanHundred / count;

            Assert.AreEqual(0.75, percentXLargerThanHundret, 0.01);
            Assert.AreEqual(0.75, percentYLargerThanHundret, 0.01);
        }
        
    }
}
