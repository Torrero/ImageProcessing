using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace AppCloudCover
{
    class CLine
    {
        /// <summary>
        /// Начальная точка
        /// </summary>
        public Point Start;
        /// <summary>
        /// Конечная точка
        /// </summary>
        public Point End;

        public CObjectImg StartObj;
        public CObjectImg EndObj;
        
        public int State = 0;
        public CLine()
        {
            Start.X = 0;
            Start.Y = 0;
            End.X = 0;
            End.Y = 0;
        }

        /// <summary>
        /// Конструктор с объектами
        /// </summary>
        /// <param name="mStart"></param>
        /// <param name="mEnd"></param>
        public CLine(CObjectImg mStart, CObjectImg mEnd)
        {
            StartObj = mStart;
            EndObj = mEnd;

            Start = mStart.Center;
            End = mEnd.Center;
        }

        /// <summary>
        /// Конструктор с точками
        /// </summary>
        /// <param name="mStart"></param>
        /// <param name="mEnd"></param>
        public CLine(Point mStart, Point mEnd)
        {
            Start = mStart;
            End = mEnd;
        }

        /// <summary>
        /// получить длину отрезка
        /// </summary>
        /// <returns></returns>
        public double getLength()
        {
            return Math.Pow(Math.Pow(End.X - Start.X, 2) + Math.Pow(End.Y - Start.Y, 2), 0.5);
        }

        /// <summary>
        ///  Получить перпендикуляр
        /// </summary>
        /// <returns></returns>
        public CLine CrossLine()
        {
            Point pointM = new Point((Start.X + End.X) / 2, (Start.Y + End.Y) / 2);
            Point pointV = new Point(Start.X - End.X, Start.Y - End.Y);
            Point pointN = new Point(pointV.Y, -pointV.X);
            Point pointSTART = new Point(pointM.X - (pointN.X / 2), pointM.Y - (pointN.Y / 2));
            Point pointEND = new Point(pointM.X + (pointN.X / 2), pointM.Y + (pointN.Y / 2));

            CLine resLine = new CLine(pointSTART, pointEND);
            resLine.StartObj = StartObj;
            resLine.EndObj = EndObj;
            return resLine;
        }

        /// <summary>
        /// Проверить лежит ли точка на прямой
        /// </summary>
        /// <param name="checkPoint"></param>
        /// <returns></returns>
        public bool isPointInLine(Point checkPoint)
        {
            Point A = checkPoint;
            Point B = Start;
            Point C = End;

            return ((B.X - A.X) * (C.Y - A.Y) - (C.X - A.X) * (B.Y - A.Y) == 0);
            // return (Math.Abs((B.X - A.X) * (C.Y - A.Y) - (C.X - A.X) * (B.Y - A.Y)) <= 0.5);                
        }

        /// <summary>
        /// Проверка пересечения отрезков
        /// </summary>
        /// <param name="line2"></param>
        /// <returns></returns>
        public bool isIntersection(CLine line2)
        {
            double v1, v2, v3, v4;
            int ax1, ax2, ay1, ay2;
            int bx1, bx2, by1, by2;

            ax1 = Start.X;
            ax2 = End.X;
            ay1 = Start.Y;
            ay2 = End.Y;

            bx1 = line2.Start.X;
            bx2 = line2.End.X;

            by1 = line2.Start.Y;
            by2 = line2.End.Y;

            v1 = (bx2 - bx1) * (ay1 - by1) - (by2 - by1) * (ax1 - bx1);
            v2 = (bx2 - bx1) * (ay2 - by1) - (by2 - by1) * (ax2 - bx1);
            v3 = (ax2 - ax1) * (by1 - ay1) - (ay2 - ay1) * (bx1 - ax1);
            v4 = (ax2 - ax1) * (by2 - ay1) - (ay2 - ay1) * (bx2 - ax1);

            if ((v1 * v2 < 0) && (v3 * v4 < 0)) return true;
            else return false;
        }


        /// <summary>
        /// Коэффициент пересечения
        /// </summary>
        /// <param name="line_second"></param>
        /// <returns></returns>
        public double KoefIntersect(CLine line_second)
        {
            Point a = Start;
            Point b = End;
            Point c = line_second.Start;
            Point d = line_second.End;

            Point n = new Point(d.Y - c.Y, c.X - d.X);

            Point tmpP = new Point(b.X - a.X, b.Y - a.Y);
            double denom = dotProduct(n, tmpP);
            if (denom == 0.0)
                return 0;

            tmpP = new Point(a.X - c.X, a.Y - c.Y);
            double num = dotProduct(n, tmpP);

            return -num / denom;

        }

        /// <summary>
        /// Скалярное произведение 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public static double dotProduct(Point p, Point q)
        {
            return (p.X * q.X + p.Y * q.Y);
        }

        /// <summary>
        /// Получить точку прямой
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public Point point(double t)
        {
            return new Point((int)(Start.X + t * (End.X - Start.X)), (int)(Start.Y + t * (End.Y - Start.Y)));
        }

        /// <summary>
        /// Позиция точки СЛЕВА, СПРАВА, НЕ ИЗВЕСТНО 
        /// </summary>
        public enum position { LEFT = 1, RIGHT = 2, I_DONT_KNOW = 3 };
        //    СЛЕВА, СПРАВА, ВПЕРЕДИ, ПОЗАДИ, МЕЖДУ,   НАЧАЛО, КОНЕЦ

        /// <summary>
        /// Позиция точки относительно прямой
        /// </summary>
        /// <param name="p2"></param>
        /// <returns></returns>
        public position classify(Point p2)
        {

            Point a = new Point(Start.X - End.X, Start.Y - End.Y);
            Point b = new Point(p2.X - Start.X, p2.Y - Start.Y);
            double sa = a.X * b.Y - b.X * a.Y;
            if (sa > 0.0)
                return position.LEFT;
            if (sa < 0.0)
                return position.RIGHT;

            return position.I_DONT_KNOW;
            /*
             if ((a.x * b.x < 0.0) || (a.y * b.y < 0.0))
                 return position.BEHIND;
             if (a.length() < b.length())
                 return position.BEYOND;
             if (pO == p2)
                 return position.ORIGIN;
             if (p1 == p2)
                 return position.DESTINATION;
             return position.BETWEEN;
             * */
        }





    };
}
