using System.Drawing;

namespace PointSetProximityLibray
{
    public interface IPointProximity
    {
        bool PointIsCloseToOtherPoints(Point p);
    }
}
