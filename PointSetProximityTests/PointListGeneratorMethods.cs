using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PointSetProximityLibray.Test
{
    internal static class PointListGeneratorMethods
    {
        public static void getEmptyList(IPointGenerator pointGenerator)
        {
            pointGenerator.CreateList(0, 0, 0);
            List<Point> output = pointGenerator.GetList();
            List<Point> expected = new List<Point>();

            CollectionAssert.AreEqual(output, expected);
        }

        
        public static void getOneZeroPointList(IPointGenerator pointGenerator)
        {
            pointGenerator.CreateList(0, 0, 1);
            List<Point> output = pointGenerator.GetList();
            List<Point> expected = new List<Point>()
            {
                new Point(0,0)
            };

            CollectionAssert.AreEqual(output, expected);
        }

        
        public static void getMultipleZeroPointsTest(IPointGenerator pointGenerator)
        {
            int count = 20;
            pointGenerator.CreateList(0, 0, count);
            List<Point> output = pointGenerator.GetList();
            List<Point> expected = new List<Point>();
            for (int i = 1; i <= count; i++)
            {
                expected.Add(new Point(0, 0));
            }

            CollectionAssert.AreEqual(expected, output);
        }

        
        public static void ThreePointsNotTheSame(IPointGenerator pointGenerator)
        {
            int count = 200;
            int width = 200;
            int height = 200;
            pointGenerator.CreateList(width, height, count);
            List<Point> output = pointGenerator.GetList();

            Assert.IsFalse((output[0] == output[1]) && (output[0] == output[2]));
        }

        
        public static void PointsAreInRange(IPointGenerator pointGenerator)
        { 
            int count = 10000;
            int width = 20;
            int height = 20;
            pointGenerator.CreateList(width, height, count);
            List<Point> output = pointGenerator.GetList();
            int xMin = output.Min(p => p.X);
            int yMin = output.Min(p => p.Y);
            int xMax = output.Max(p => p.X);
            int yMax = output.Max(p => p.Y);
            bool MinInRange = xMin == 0 && yMin == 0;
            bool MaxInRange = xMax == width && yMax == height;

            Assert.IsTrue(MinInRange && MaxInRange);
        }

        
        public static void AmountOfPointsEqualsCount(IPointGenerator pointGenerator)
        {
            
            int count = 2342;
            int width = 200;
            int height = 200;
            pointGenerator.CreateList(width, height, count);
            List<Point> output = pointGenerator.GetList();
            int amountpoints = output.Count();

            Assert.IsTrue(amountpoints == count);
        }
    }
}
