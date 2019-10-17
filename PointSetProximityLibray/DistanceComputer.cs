using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace PointSetProximityLibray
{
    public static class DistanceComputer
    {
        public static double ComputeSquaredDistance(Point p1, Point p2)
        {
            //throw new ArgumentException("Punkt 1 muss bei 0, 0 liegen");
            int dX = p1.X - p2.X;
            int dY = p1.Y - p2.Y;
            int dYSquared = dY * dY;
            int dXSquared = dX * dX;
            return dXSquared + dYSquared;
        }
    }
    
}
