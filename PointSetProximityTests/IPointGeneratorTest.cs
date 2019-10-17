using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;

namespace PointSetProximityLibray.Test
{
    [TestClass]
    public class IPointGeneratorTest
    {
        
        [TestMethod]
        public void CreateInterfaceDerivative()
        {
            IPointGenerator randomgenerator = new RandomPointListGenerator(10);
            IPointGenerator functiongenerator = new XSquaredPointListGenerator(10);
        }
    }
}
