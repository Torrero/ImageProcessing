using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AppCloudCover
{
    class CTriangle
    {
        public CObjectImg objPoint1;
        public CObjectImg objPoint2;
        public CObjectImg objPoint3;

        public Point center;
        public double raduisCircle;
        public double Ci = 0;


        public List<CLine> lines = new List<CLine>();

        // Добавить новое ребро
        public void addLine(CLine newLine)
        {
            // Увеличиваем счётчик в скольки треугольниках это это ребро содержиться. Максимум должно быть 2 
            newLine.State++;
            lines.Add(newLine);
        }

        public double calcCi()
        {
            // сумма площадей объектов - считаем количество
            double squareOfObjects = 0;
            foreach (CLeastBitmapTree leastKv in objPoint1.arrayKvadro)
            {
                squareOfObjects += leastKv.CountCloudPixels;
            }
            foreach (CLeastBitmapTree leastKv in objPoint2.arrayKvadro)
            {
                squareOfObjects += leastKv.CountCloudPixels;
            }
            foreach (CLeastBitmapTree leastKv in objPoint3.arrayKvadro)
            {
                squareOfObjects += leastKv.CountCloudPixels;
            }

            double squareOfTriangle = getSquare();

            Ci = squareOfObjects / squareOfTriangle;

            if (squareOfObjects == 0)
                squareOfObjects = 0;
            if (Ci == 0)
                Ci = 0;

            return Ci;
        }

        // вычислить площадь треугольника
        public double getSquare()
        {
            double pp = 0;
            double a = 0, b = 0, c = 0;
            if (lines.Count != 3)
                return 0;

            // длины сторон треугольника
            a = lines[0].getLength();
            b = lines[1].getLength();
            c = lines[2].getLength();

            // полупериметр
            pp = (a + b + c) / 2;

            // площадь
            return Math.Pow(pp * (pp - a) * (pp - b) * (pp - c), 0.5);
            //   S(т-ка)=1/2((x1-x3)*(y2-y3)-(x2-x3)*(y1-y3))

        }
    };
}
