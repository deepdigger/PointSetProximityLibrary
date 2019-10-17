using System;
using System.Collections.Generic;
using System.Drawing;

namespace PointSetProximityLibray
{
    public class XSquaredPointListGenerator : IPointGenerator
    {
        List<Point> points;
        Random random;

        public XSquaredPointListGenerator(int seed = int.MaxValue)
        {
            if (seed == int.MaxValue)
            {
                random = new Random();
            }
            else
            {
                random = new Random(seed);
            }
        }

        public void CreateList(int width, int height, int count)
        {
            points = new List<Point>();
            for (int i = 1; i <= count; i++)
            {
                int newHeight = (int)Math.Sqrt(random.Next(0, height*height));
                int newWidth = (int)Math.Sqrt(random.Next(0, width*width));
                points.Add(new Point(newHeight, newWidth));
            }
        }

        public List<Point> GetList()
        {
            return points;
        }
    }
}
