using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using KDTreeDLL;

namespace AppCloudCover
{
    class CTriangulation
    {
        
        /// <summary>
        ///  Алгоритм ТРИАНГУЛЯЦИИ http://algolist.manual.ru/maths/geom/deluanay.php
        ///  http://algolist.manual.ru/maths/geom/datastruct.php
        /// </summary>
        /// <param name="BitmapTree"></param>
        /// <param name="ArrayImgObjects">Массив найденных объектов</param>
        /// <param name="checkBox_ShowProcess">Показывать процесс триангуляции в pictureBox1 </param>
        /// <param name="pictureBox1">Вывод триангуляционной дииграммы на изображение</param>
        /// <returns></returns>
        static public List<CTriangle> Triangulate_func( Bitmap BitmapTree, List<CObjectImg> ArrayImgObjects ,bool checkBox_ShowProcess, System.Windows.Forms.PictureBox pictureBox1)
        {
            if (ArrayImgObjects == null) return null;
            if (ArrayImgObjects.Count == 0) return null;
            if (BitmapTree == null) return null;

            ////////////////////////////
            Bitmap bitmapPaint = new Bitmap(BitmapTree.Width, BitmapTree.Height, BitmapTree.PixelFormat);
            Graphics gBmp = Graphics.FromImage(bitmapPaint);
            //gBmp.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

            Pen penPaint = new Pen(Color.Gold, BitmapTree.Width / 200);

            Brush brushPaint = new SolidBrush(Color.Red);

            int RaduisCenter = BitmapTree.Width / 200;

            Pen PenBox = new Pen(Color.Green, BitmapTree.Width / 200);
            Brush brushBox = new SolidBrush(Color.Aquamarine);

            foreach (CObjectImg Obj in ArrayImgObjects)
            {
                //    gBmp.DrawRectangle(PenBox, Obj.BoundRectangle);
                gBmp.FillEllipse(brushBox, Obj.Center.X - RaduisCenter, Obj.Center.Y - RaduisCenter, RaduisCenter * 2, RaduisCenter * 2);

                int x_point = Obj.Center.X - 10;
                int y_point = Obj.Center.Y + 15;


                gBmp.DrawString("" + Obj.Center.X.ToString() + "," + Obj.Center.Y.ToString() + "", new Font("Times New Roman", 12), brushPaint, x_point, y_point);
            }
            ///////////////////////////////////////


            List<CObjectImg> workObj = new List<CObjectImg>(ArrayImgObjects);

            CObjectImg object1 = null;
            CObjectImg object2 = null;

            object1 = workObj[0];
            /// Ищем самые правые объекты
            foreach (CObjectImg obj in workObj)
            {
                if (Math.Pow(Math.Pow(object1.Center.X, 2) + Math.Pow(object1.Center.Y, 2), 0.5)
                    >
                    Math.Pow(Math.Pow(obj.Center.X, 2) + Math.Pow(obj.Center.Y, 2), 0.5)
                    )
                {
                    object1 = obj;
                }
            }

            workObj.Remove(object1);

            if (workObj.Count == 0) return null;

            object2 = workObj[0];

            /// Ищем самые правые объекты
            foreach (CObjectImg obj in workObj)
            {
                if (Math.Pow(Math.Pow(object2.Center.X, 2) + Math.Pow(object2.Center.Y, 2), 0.5)
                    >
                    Math.Pow(Math.Pow(obj.Center.X, 2) + Math.Pow(obj.Center.Y, 2), 0.5)
                    )
                {
                    object2 = obj;
                }
            }

            workObj.Remove(object2);

            // заново берём все вершины
            workObj = new List<CObjectImg>(ArrayImgObjects);

            /// Нашли первое живое ребро
            /// берем первое ребро
            CLine line_first = new CLine(object1, object2);

            line_first.State = 1;

            List<CTriangle> listTirangles = new List<CTriangle>();

            /// Массив всех рёбер
            List<CLine> aliveLines = new List<CLine>();
            // Добавили первое ребро в массив
            aliveLines.Add(line_first);


            List<CLine> tmpLines = new List<CLine>();

            // Строим KD дерево размерностью 2. Так как координаты на плоскости.
            KDTree KDTreeAllImgObjects = new KDTree(2);
            foreach (CObjectImg Obj in workObj)
            {
                KDTreeAllImgObjects.insert(new double[] { Obj.Center.X, Obj.Center.Y }, Obj);
            }

            int GlobalWidthKvadrat = BitmapTree.Width; //line_first.End.X;
            int WidthKvadrat = BitmapTree.Width; //line_first.End.X;


            while (true)
            {


                // добавляем найденные рёбра
                aliveLines.AddRange(tmpLines);

                tmpLines.Clear();

                // Бежим по всем ребрам ищем живое ребро и для него пытаемся найти сопряженную точку
                CLine liveLine = null;
                if (aliveLines.Count > 0)
                {
                    liveLine = aliveLines[0];
                }
                else
                    break;

                if (liveLine == null) continue;
                aliveLines.Remove(liveLine);

                // смотрим если это живое ребро (или спящее - первое) то ищем сопряжённую точку
                if (liveLine.State == 1 || liveLine.State == 0)
                {

                    // строим перпендикуляр к живому ребру
                    CLine cross_liveLine = liveLine.CrossLine();
                    CObjectImg NextObj = null;
                    double BestKoeff = 100000;

                    object[] FounedeObject = null;
                    bool flwascheck = false;
                    do
                    {
                        FounedeObject = KDTreeAllImgObjects.range(new double[] { 0, 0 }, new double[] { WidthKvadrat, WidthKvadrat });

                        if (FounedeObject != null)
                            foreach (CObjectImg obj in FounedeObject)
                            {
                                bool flGoodPoint = false;
                                // Если это первое ребро то его точки не берём во внимание
                                if (obj == liveLine.StartObj || obj == liveLine.EndObj)
                                {
                                    flGoodPoint = true;
                                    continue;
                                }

                                /// Смотрим - добавлена ли эта точка в какой нить треугольник                            

                                foreach (CTriangle tri in listTirangles)
                                {
                                    if ((tri.objPoint1 == liveLine.StartObj && tri.objPoint2 == liveLine.EndObj && tri.objPoint3 == obj) ||
                                         (tri.objPoint1 == liveLine.StartObj && tri.objPoint2 == obj && tri.objPoint3 == liveLine.EndObj) ||
                                         (tri.objPoint1 == liveLine.EndObj && tri.objPoint2 == liveLine.StartObj && tri.objPoint3 == obj) ||
                                         (tri.objPoint1 == liveLine.EndObj && tri.objPoint2 == obj && tri.objPoint3 == liveLine.StartObj) ||
                                         (tri.objPoint1 == obj && tri.objPoint2 == liveLine.StartObj && tri.objPoint3 == liveLine.EndObj) ||
                                         (tri.objPoint1 == obj && tri.objPoint2 == liveLine.EndObj && tri.objPoint3 == liveLine.StartObj)
                                        )
                                    {
                                        flGoodPoint = true;
                                        break;
                                    }

                                }

                                // если все 3 точки лежат на одной прямой - это не нужная точка
                                if (liveLine.isPointInLine(obj.Center))
                                {
                                    flGoodPoint = true;
                                    continue;
                                    // break;
                                }


                                // Если точка ещё не добавлена. то можно попытаться её посчитать
                                if (!flGoodPoint)
                                {
                                    flwascheck = true;

                                    //if (liveLine.classify(obj.Center) == CLine.position.RIGHT)
                                    {
                                        bool goodPoint = true;
                                        CLine line_second = new CLine(liveLine.End, obj.Center);
                                        // перпендикуляр второй
                                        CLine cross_line_second = line_second.CrossLine();

                                        // коэффициент пересечения
                                        double koeff = cross_liveLine.KoefIntersect(cross_line_second);

                                        if (koeff == 0)
                                        {
                                            goodPoint = false;
                                            continue;
                                        }

                                        // Проверка условия делоне.
                                        // Получаем центр окружности

                                        Point centerNewCircle = cross_liveLine.point(koeff);
                                        double Raduis2NewCircle = Math.Pow(centerNewCircle.X - liveLine.Start.X, 2) + Math.Pow(centerNewCircle.Y - liveLine.Start.Y, 2);

                                        if ((centerNewCircle.Y < 0 || centerNewCircle.Y > 3000) ||
                                            (centerNewCircle.X < 0 || centerNewCircle.X > 3000))
                                        {
                                            goodPoint = false;
                                            continue;
                                        }


                                        /* вывод на экран перпендикуляров */
                                        /*
                                       double RaduisNewCircle = Math.Pow(Raduis2NewCircle, 0.5);

                                       Pen PenCross = new Pen(Color.AntiqueWhite, BitmapTree.Width / 150);

                                       gBmp.DrawLine(PenCross, cross_liveLine.Start, cross_liveLine.End);
                                       gBmp.DrawLine(PenCross, cross_line_second.Start, cross_line_second.End);
                                       gBmp.DrawEllipse(PenCross, (float)(centerNewCircle.X - RaduisNewCircle), (float)(centerNewCircle.Y - RaduisNewCircle), (float)RaduisNewCircle * 2, (float)RaduisNewCircle * 2);
                                       gBmp.FillEllipse(brushPaint, (float)(centerNewCircle.X - 5), (float)(centerNewCircle.Y - 5), (float)5 * 2, (float)5 * 2);
                                        */

                                        // бежим по всем точкам и смотрим попадает ли какая нить левая точка в оружность
                                        foreach (CObjectImg verifyObj in workObj)
                                        {
                                            if (verifyObj == obj || verifyObj == liveLine.StartObj || verifyObj == liveLine.EndObj) continue;

                                            double tmpVal = Math.Pow(verifyObj.Center.X - centerNewCircle.X, 2) + Math.Pow(verifyObj.Center.Y - centerNewCircle.Y, 2);

                                            if (tmpVal <= Raduis2NewCircle)
                                            {
                                                goodPoint = false;
                                                break;
                                            }
                                        }


                                        if (goodPoint == true && BestKoeff > koeff)
                                        {
                                            /* проверка - пересекают ли новые отрезки уже существующие линии треугольников
                                            CLine line2_calc = new CLine(obj, liveLine.StartObj);
                                            CLine line3_calc = new CLine(liveLine.EndObj, obj);

                                        
                                            foreach (CTriangle tri in listTirangles)
                                            { 
                                                foreach (CLine searchLine in tri.lines)
                                                {
                                                   if (line2_calc.isIntersection(searchLine) || 
                                                     line3_calc.isIntersection(searchLine) )                                                 
                                                        goodPoint = false;
                                                }
                                            }
                                            */


                                            //if (goodPoint == true)
                                            {
                                                BestKoeff = koeff;
                                                NextObj = obj;
                                            }
                                        }
                                    }
                                }
                            }


                        if (flwascheck == false || NextObj == null)
                        {
                            WidthKvadrat = WidthKvadrat * 3;

                            if (WidthKvadrat > BitmapTree.Width)
                            {
                                WidthKvadrat = BitmapTree.Width;
                                break;
                            }

                            continue;
                        }

                    }
                    while (flwascheck == false);

                    // если для этого ребра не можем найти сопряжённую точку... - это плохо
                    if (NextObj == null)
                    {
                        GlobalWidthKvadrat = GlobalWidthKvadrat * 2;
                        if (GlobalWidthKvadrat > BitmapTree.Width)
                            GlobalWidthKvadrat = BitmapTree.Width;
                        WidthKvadrat = GlobalWidthKvadrat;
                    }


                    if (NextObj != null)
                    {

                        // Создаём треугольник - и добавляем туда первое ребро
                        CTriangle newTriangle = new CTriangle();
                        newTriangle.objPoint1 = liveLine.StartObj;
                        newTriangle.objPoint2 = liveLine.EndObj;
                        newTriangle.addLine(liveLine);

                        // Добавляем 3ю вершину в треугольник
                        newTriangle.objPoint3 = NextObj;
                        // Создаём остальных 2 ребра к этой вершине
                        CLine line2_tmp = new CLine(NextObj, newTriangle.objPoint1);
                        CLine line3_tmp = new CLine(newTriangle.objPoint2, NextObj);

                        CLine line2 = line2_tmp;//.CrossLine().CrossLine();
                        CLine line3 = line3_tmp;//.CrossLine().CrossLine();

                        // Добавляем их в треугольник
                        newTriangle.addLine(line2);
                        newTriangle.addLine(line3);

                        // добавляем в писок  
                        tmpLines.Add(line2);
                        tmpLines.Add(line3);

                        // Получаем центр окружности и радиус окружности
                        Point centerCircle = cross_liveLine.point(BestKoeff);
                        double RaduisCircle = Math.Pow(Math.Pow(centerCircle.X - liveLine.Start.X, 2) + Math.Pow(centerCircle.Y - liveLine.Start.Y, 2), 0.5);

                        newTriangle.center = centerCircle;
                        newTriangle.raduisCircle = RaduisCircle;

                        // Треугольник добавляем к списку треугольников
                        listTirangles.Add(newTriangle);

                        // Выводим треугольник 
                        if (checkBox_ShowProcess)
                        {
                            gBmp.DrawLine(penPaint, newTriangle.objPoint1.Center, newTriangle.objPoint2.Center);
                            gBmp.DrawLine(penPaint, newTriangle.objPoint2.Center, newTriangle.objPoint3.Center);
                            gBmp.DrawLine(penPaint, newTriangle.objPoint3.Center, newTriangle.objPoint1.Center);

                            /* вывод на экран перпендикуляров */
                            /*
                            int r = rnd.Next(0xFF);
                            int g = rnd.Next(0xFF);
                            int b = rnd.Next(0xFF);
                            Color rndColor = Color.FromArgb(r,g,b);

                            Pen PenCross = new Pen(rndColor, BitmapTree.Width / 150);

                           CLine cross1 = newTriangle.lines[0].CrossLine();
                           CLine cross2 = newTriangle.lines[1].CrossLine();
                           gBmp.DrawLine(PenCross, cross1.Start, cross1.End);
                           gBmp.DrawLine(PenCross, cross2.Start, cross2.End);
                                
                           gBmp.DrawEllipse(PenCross, (float)(newTriangle.center.X - newTriangle.raduisCircle), (float)(newTriangle.center.Y - newTriangle.raduisCircle), (float)newTriangle.raduisCircle * 2, (float)newTriangle.raduisCircle * 2);
                           gBmp.FillEllipse(brushPaint, (float)(newTriangle.center.X - 5), (float)(newTriangle.center.Y - 5), (float)5 * 2, (float)5 * 2);
                            */
                        }

                        pictureBox1.Image = bitmapPaint;
                        pictureBox1.Refresh();

                        // Задержка
                        /*
                        for (Int64 iii = 0; iii < 500000; iii++)
                            Application.DoEvents();
                        */


                    }
                }


            }

            /*
            Bitmap bitmapPaint = new Bitmap(BitmapTree.Width, BitmapTree.Height, BitmapTree.PixelFormat);
            Graphics gBmp = Graphics.FromImage(bitmapPaint);
            gBmp.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            
            Pen penPaint = new Pen(Color.Green,BitmapTree.Width / 100);

            Brush brushPaint = new SolidBrush(Color.Red);

            int RaduisCenter = BitmapTree.Width / 50;
            */

            Pen penForCircle = new Pen(Color.White, BitmapTree.Width / 250);

            // Выводим треугольники
            foreach (CTriangle tri in listTirangles)
            {
                gBmp.DrawLine(penPaint, tri.objPoint1.Center, tri.objPoint2.Center);
                gBmp.DrawLine(penPaint, tri.objPoint2.Center, tri.objPoint3.Center);
                gBmp.DrawLine(penPaint, tri.objPoint3.Center, tri.objPoint1.Center);

                //gBmp.DrawEllipse(penForCircle, (float)(tri.center.X - tri.raduisCircle), (float)(tri.center.Y - tri.raduisCircle), (float)tri.raduisCircle * 2, (float)tri.raduisCircle * 2);

                //gBmp.DrawEllipse(penPaint, (int)(centerCircle.X - RaduisCircle), (int)(centerCircle.Y - RaduisCircle), (int)RaduisCircle * 2, (int)RaduisCircle * 2);
            }


            pictureBox1.Image = bitmapPaint;
            pictureBox1.Refresh();

            

            return listTirangles;

        }
    }
}
