using System;
using System.Collections.Generic;
using System.Drawing;

namespace PointSetProximityLibray
{
    public class RandomPointListGenerator : IPointGenerator
    {
        List<Point> points;
        readonly Random random;
        public RandomPointListGenerator(int seed = int.MaxValue)
        {
            if(seed == int.MaxValue)
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
            for (int i =1; i <= count; i++)
            {
                points.Add(GenerateRandomPoint(width,height,random));
            }
        }

        private Point GenerateRandomPoint(int width, int height, Random random)
        {
            int x = random.Next(0, width + 1);
            int y = random.Next(0, height + 1);
            Point p = new Point(x, y);

            return p;            
        }

        public List<Point> GetList()
        {
            return points;
        }
    }
}
