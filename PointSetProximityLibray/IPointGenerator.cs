using System.Collections.Generic;
using System.Drawing;

namespace PointSetProximityLibray
{
    public interface IPointGenerator
    {
        void CreateList(int width, int height, int count);
        List<Point> GetList();
    }
}
