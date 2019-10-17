using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PointSetProximityLibray
{
    public class Grid : IPointProximity
    {
        private readonly List<Point> points;
        private readonly double epsilon;
        private readonly int width;
        private readonly int height;
        private readonly List<Point>[,] pointarray;
        private readonly int xMin;
        private readonly int yMin;



        public Grid(List<Point> points, double epsilon)
        {
            this.points = points;
            this.epsilon = epsilon;
            if (this.points.Any())
            {
                xMin = this.points.Min(p => p.X);
                yMin = this.points.Min(p => p.Y);
                int xMax = this.points.Max(p => p.X);
                int yMax = this.points.Max(p => p.Y);

                width = Math.Abs(xMax - xMin) + 2;
                height = Math.Abs(yMax - yMin) + 2;

                int arrayWidth = (int)Math.Ceiling(Math.Sqrt(points.Count()) * ((double)width / height));
                int arrayHeight = (int)Math.Ceiling(Math.Sqrt(points.Count()) * ((double)height / width));

                pointarray = new List<Point>[arrayWidth, arrayHeight];
                FillArrayWithEmptyLists();
                AddPointsToArray();
            }
            
        }

        private void FillArrayWithEmptyLists()
        {
            for (int x = 0; x < pointarray.GetLength(0); x++)
            {
                for (int y = 0; y < pointarray.GetLength(1); y++)
                {
                    FillWithEmptyPointList(x, y);
                }
            }
        }

        private void FillWithEmptyPointList(int x, int y)
        {
            List<Point> boxlist = new List<Point>();
            pointarray[x, y] = boxlist;
        }

        private void AddPointsToArray()
        {
            foreach (Point p in points)
            {
                AddPointToArray(p);
            }
        }

        private void AddPointToArray(Point p)
        {
            pointarray[GetPointPositionX(p), GetPointPositionY(p)].Add(p);
        }

        private int GetPointPositionX(Point p)
        {
            return (p.X-xMin) * pointarray.GetLength(0) / width;
        }

        private int GetPointPositionY(Point p)
        {
            return(p.Y-yMin) * pointarray.GetLength(1) / height;
        }


        public bool PointIsCloseToOtherPoints(Point p)
        {
            if (!points.Any())
            {
                return false;
            }
            int widthX = (int)(epsilon * pointarray.GetLength(0) / width) + 1;
            int widthY = (int)(epsilon * pointarray.GetLength(1) / height) + 1;


            for (int counterx = (p.X * pointarray.GetLength(0) / width) - widthX; counterx <= (p.X * pointarray.GetLength(0) / width) + widthY; counterx++)
            {
                for (int countery = (p.Y * pointarray.GetLength(1) / height) - widthY; countery <= (p.Y * pointarray.GetLength(1) / height) + widthY; countery++)
                {
                    int x = ReturnInRangeRightClosed(counterx, 0, pointarray.GetLength(0));
                    int y = ReturnInRangeRightClosed(countery, 0, pointarray.GetLength(1));

                    foreach (Point i in pointarray[x, y])
                    {
                        double d = double.PositiveInfinity;
                        if (i != p)
                        {
                            d = DistanceComputer.ComputeSquaredDistance(p, i);
                        }
                        if (d <= epsilon * epsilon)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private int ReturnInRangeRightClosed(int val, int min, int max)
        {
            if (val < min) return min;
            if (val >= max) return max - 1;

            return val;
        }
    }
}
