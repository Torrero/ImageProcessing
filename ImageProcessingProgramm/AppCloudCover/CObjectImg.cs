using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AppCloudCover
{
    class CObjectImg
    {
        public List<CLeastBitmapTree> arrayKvadro = new List<CLeastBitmapTree>();
        public Rectangle BoundRectangle;
        public Point Center;
        // Посчитать кол-во пикселей объекта.
        public long calcPixels()
        {
            long res = 0;
            foreach (CLeastBitmapTree bmtl in arrayKvadro)
            {
                res += bmtl.CountCloudPixels;
            }
            return res;
        }

    };
}
