using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCloudCover
{
    class CLeastBitmapTree
    {
        public Int64 CountCloudPixels = 0;
        public double X = 0;
        public double Y = 0;
        public double WIDTH = 0;
        public double HEIGHT = 0;
        public int NumLevel = 0;
        public List<CLeastBitmapTree> LowLevel = new List<CLeastBitmapTree>();
        public int matrixX = 0;
        public int matrixY = 0;
    };
}
