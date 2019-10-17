using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PointSetProximityLibray
{
    public class Bruteforce : IPointProximity
    {
        readonly List<Point> points;
        readonly double epsilon;
        public Bruteforce(List<Point> points, double epsilon)
        {
            this.points = points;
            this.epsilon = epsilon;
        }

        public bool PointIsCloseToOtherPoints(Point p)
        {
            foreach (Point i in points)
            {
                double d = double.PositiveInfinity;
                if (p != i)
                {
                    d = DistanceComputer.ComputeSquaredDistance(p, i);
                }
                if (d <= epsilon * epsilon)
                {
                    return true;
                }
            }
            return false;

        }
    }
}
