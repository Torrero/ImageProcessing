using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using KDTreeDLL;



/*
РАЗРАБОТЧИК: МАЛЬЦЕВ Е.А. (mtorrero@mail.ru). 2010 г.
ПРОГРАММА ПРЕДНАЗНАЧЕНА ДЛЯ ОБРАБОТКИ ИЗОБРАЖЕНИЙ (В ОСНОВНОМ ИЗОБРАЖЕНИЙ ДЗЗ, ДЛЯ ВЫДЕЛЕНИЯ ОБЛАЧНОСТИ И ВЫЧИСЛЕНИЯ ГЕОМЕТРИЧЕСКОЙ КОНЦЕНТРАЦИИ)
All rights reserved =)
 * на вход принимает изображение в формате JPG.
 * строит дерево квадрантов и находит объекты на изображении. Объекты на изображении светлые области, в данном  случае облачность.
 * строит триангуляционную диаграмму
 * расчитывает геометрическую концентрацию объектов на плоскости (аналог физической величины "плотность", но для объектов в 2D, на плоскости)
 * визуализирует результаты
*/



namespace AppCloudCover
{
    public partial class Form1 : Form
    {

        // Размер примитива( X:Y) (пикс):        
        int CONST_MIN_BOX_OF_PIXELS = 10;
        // Порог кол-ва облачных пикселей в квадранте:        
        int MAX_NEED_PIXELS_FOR_CLOUDS = 300;
        Random rnd = new Random(DateTime.Now.Second);

        // Построенное дерево квадрантов
        CLeastBitmapTree Tree = null; // new leastBitmapTree();
        // Обрабатываемое изображение
        Bitmap BitmapTree = null;
        // дерево квадрантов разбитое по уровням
        Dictionary<int, List<CLeastBitmapTree>> LevelsTree = null;

        // нижний уровень дерева
        List<CLeastBitmapTree> LowestLevelOfTree = null;

        // Матрица примитивов изображения 
        CLeastBitmapTree[,] matrixKvadro = null; //new CLeastBitmapTree[countKvadroX, countKvadroY];
        // вспомогательная битовая матрица
        byte[,] matrixBit = null; //new byte[countKvadroX, countKvadroY];            

        // Массив найденных объектов
        List<CObjectImg> ArrayImgObjects = null;

        // Массив полученных треугольников
        List<CTriangle> ArrayTriangles = null;

         

        


        public Form1()
        {
            InitializeComponent();
            textBox_size_box.Text = CONST_MIN_BOX_OF_PIXELS.ToString();
            textBox_level_of_clouds.Text = MAX_NEED_PIXELS_FOR_CLOUDS.ToString();

            txtBox_koef1.BackColor = Color.LightGreen;
            txtBox_koef2.BackColor = Color.LimeGreen;
            txtBox_koef3.BackColor = Color.Green;


             
        }


       
       

        // Изменение порогов 
        private void textBox_size_box_TextChanged(object sender, EventArgs e)
        {
            int aa = CONST_MIN_BOX_OF_PIXELS;
            int bb = MAX_NEED_PIXELS_FOR_CLOUDS;

            try
            {
                aa = Convert.ToInt32(textBox_size_box.Text);
                bb = Convert.ToInt32(textBox_level_of_clouds.Text);
            }catch(Exception )
            {
                textBox_size_box.Text = CONST_MIN_BOX_OF_PIXELS.ToString();
                textBox_level_of_clouds.Text = MAX_NEED_PIXELS_FOR_CLOUDS.ToString();
            }

            CONST_MIN_BOX_OF_PIXELS = aa;
            MAX_NEED_PIXELS_FOR_CLOUDS = bb;

            textBox_count_pixels_in_box.Text = Convert.ToString(CONST_MIN_BOX_OF_PIXELS * CONST_MIN_BOX_OF_PIXELS);
        }
         


		// Загрузка изображения
        private void button1_Click(object sender, EventArgs e)
        {  
            OpenFileDialog OFD = new OpenFileDialog();
            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox_fileName.Text = OFD.FileName;

                Bitmap imgLoad = new Bitmap(textBox_fileName.Text); //@"D:\Projects\ГИС - нефть\Отчёты & Документы\2010\Статья СФУ\Картинки_Spot4 олачность 22-25\Облачность JPG\1.jpg"); //bmp.Width, bmp.Height, PixelFormat.Format24bppRgb);
                pictureBox_preview.Image = imgLoad;
                pictureBox_preview.Refresh();
                Application.DoEvents();

                pictureBox1.Image = null;
                pictureBox1.Refresh();

				textBox_SizeImage.Text = imgLoad.Size.Width.ToString() + "x" + imgLoad.Size.Height.ToString();

                BitmapTree = imgLoad;

                ArrayTriangles = null;
                ArrayImgObjects = null;
            } 
        }

		/// <summary>
        /// Обработка изображения, построения дерева квадрантов
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void button_processing_Click(object sender, EventArgs e)
        {
            if (BitmapTree == null) return; 
             
            Tree = new CLeastBitmapTree();
            Tree.X = 0;
            Tree.Y = 0;
            Tree.NumLevel = 1;
            Tree.WIDTH = BitmapTree.Width;
            Tree.HEIGHT = BitmapTree.Height;

            /// Строим дерево квадрантов
            CKvadroTree.BildTree(BitmapTree, Tree, Tree.X, Tree.Y, CONST_MIN_BOX_OF_PIXELS, MAX_NEED_PIXELS_FOR_CLOUDS);

            // Разбиение дерева по уровням
            LevelsTree = new Dictionary<int, List<CLeastBitmapTree>>();
            recursWalkOnTree(Tree, LevelsTree);
             
            // Копируем список самый нижний уровень квадратов.
            LowestLevelOfTree = new List<CLeastBitmapTree>(LevelsTree[LevelsTree.Keys.Last()]);
            if (LowestLevelOfTree.Count == 0) return;

            // берем ширину одного квадратика и считаем количество квадратов в изобржании что бы построить матрицу
            double widthKvadro = LowestLevelOfTree[0].WIDTH;
            double heigthKvadro = LowestLevelOfTree[0].HEIGHT;
            int countKvadroX = (int)(BitmapTree.Width / widthKvadro);
            int countKvadroY = (int)(BitmapTree.Height / heigthKvadro);

            matrixKvadro = new CLeastBitmapTree[countKvadroX, countKvadroY];
            // вспомогательная матрица
            matrixBit = new byte[countKvadroX, countKvadroY];
            // Заполняем матрицы
            // Привязываем квадратики к матрице            
            foreach (CLeastBitmapTree oneLeast in LowestLevelOfTree)
            {                
                int x = (int)((oneLeast.X ) / widthKvadro);
                int y = (int)((oneLeast.Y ) / heigthKvadro);
                                     
                matrixKvadro[x, y] = oneLeast;
                oneLeast.matrixX = x;
                oneLeast.matrixY = y;
            } 
               
            #region выводим матрицу
            /*
            //выводим матрицу
            Pen pp = new Pen(Color.Green, 1);
            Brush br = new SolidBrush(Color.Red);
            for (int i = 0; i < countKvadroX; i++)
            {
                for (int j = 0; j < countKvadroY; j++)
                {
                    if (matrixKvadro[i, j] != null)
                    {
                        gBmp.DrawRectangle(pp, matrixKvadro[i, j].X, matrixKvadro[i, j].Y, matrixKvadro[i, j].WIDTH, matrixKvadro[i, j].HEIGHT);
                        int centerX = (matrixKvadro[i, j].X + 2);
                        int centerY = (matrixKvadro[i, j].Y + 2);
                        gBmp.DrawString(""+i.ToString()+","+j.ToString()+"",new Font("Times New Roman",7),br,centerX,centerY);
                    }
                }
            }
              
             

            pictureBox1.Image = newBitmap;

            pictureBox1.Refresh();
            

            return;
             */
            //////////////////////////////// <<<<<<<<<<<<<<<<<<<
            #endregion

            fillMatrixBit(matrixKvadro,matrixBit,countKvadroX, countKvadroY);

            ArrayImgObjects = new List<CObjectImg>();

            SearchImgObjects(matrixKvadro, matrixBit, countKvadroX, countKvadroY, ArrayImgObjects);


            long countCloudsPixels = 0;
            foreach (CObjectImg ObjIm in ArrayImgObjects)
            {
                foreach (CLeastBitmapTree kv in ObjIm.arrayKvadro)
                {
                    countCloudsPixels += kv.CountCloudPixels;
                }            
            }

            txtBox_countCloudPixels.Text = countCloudsPixels.ToString();
             

            DrawRectanglesOnImage(Tree, ArrayImgObjects); 
        }
              
       
        /// <summary>
        /// Строим из дерева Хеш таблицу
        /// </summary> 
        void recursWalkOnTree(CLeastBitmapTree least,Dictionary<int, List<CLeastBitmapTree>> Levels)
        {
            if (least == null) return;

            if (Levels != null)
            {
                if (!Levels.ContainsKey(least.NumLevel))
                    Levels.Add(least.NumLevel, new List<CLeastBitmapTree>());

                if (least.CountCloudPixels >= 1) //MAX_NEED_PIXELS_FOR_CLOUDS)
                    Levels[least.NumLevel].Add(least);                
            }

            //if (least.LowLevel.Count == 0)
            

            foreach (CLeastBitmapTree ls in least.LowLevel)
            {
                recursWalkOnTree(ls, Levels);                
            }
        }
         

        /// <summary>
        ///  Поиск объектов в построенном дереве квадрантов
        /// </summary> 
        void SearchImgObjects(CLeastBitmapTree[,] matrixKvadro, byte[,] matrixBit, int countKvadroX,int countKvadroY, List<CObjectImg> ArrayImgObjects)
         {
             // Поиск объектов
            for (int i = 0; i < countKvadroX; i++)
            {
                for (int j = 0; j < countKvadroY; j++)
                {
                    if (matrixBit[i,j] == 1) 
                    {   
                        CObjectImg newObj = new CObjectImg();
                        GetKvadroOfObjects(matrixKvadro, matrixBit, newObj.arrayKvadro, i, j, countKvadroX, countKvadroY);

                        ArrayImgObjects.Add(newObj);
                    }

                }
            }

            /// Считаем прямоугольники объектов и их центры
            foreach (CObjectImg imgObj in ArrayImgObjects)
            {
                int minX = 100000, minY = 100000, maxX = 0, maxY = 0;
                // Берём один объект
                foreach (CLeastBitmapTree least in imgObj.arrayKvadro)
                {
                    if (least.X < minX)
                        minX = (int)least.X;
                    if (least.Y < minY)
                        minY = (int)least.Y;
                    if (least.X + least.WIDTH > maxX)
                        maxX = (int)least.X + (int)least.WIDTH;
                    if (least.Y + least.HEIGHT > maxY)
                        maxY = (int)least.Y + (int)least.HEIGHT;
                }
                imgObj.BoundRectangle = new Rectangle(minX, minY, maxX - minX, maxY - minY);
                imgObj.Center = new Point((maxX + minX) / 2, (maxY + minY) / 2);
            }


         }
        /// <summary>
        /// Заполнение вспомогательной матрицы: 0 - ничего нет; 1 - есть квардрат; 2 - этот квардрат мы уже смотрели
        /// </summary>
        /// <param name="matrixKvadro"></param>
        /// <param name="matrixBit"></param>
        /// <param name="countX"></param>
        /// <param name="countY"></param>
        void fillMatrixBit(CLeastBitmapTree[,] matrixKvadro, byte[,] matrixBit, int countX, int countY)
        {
            for (int i=0;i < countX;i++)
            {
                for (int j=0;j < countY;j++)
                {
                    if (matrixKvadro[i,j] == null)
                        matrixBit[i,j] = 0;
                    else
                        matrixBit[i, j] = 1;
                }            
            }        
        }

        /// <summary>
        /// Рекурсивный алгоритм обхода матрицы
        /// </summary>
        /// <param name="matrixKvadro"></param>
        /// <param name="matrixBit"></param>
        /// <param name="obj"></param>
        /// <param name="searchX"></param>
        /// <param name="searchY"></param>
        /// <param name="maxX"></param>
        /// <param name="maxY"></param>
        void GetKvadroOfObjects(CLeastBitmapTree[,] matrixKvadro, byte[,] matrixBit, List<CLeastBitmapTree> obj, int searchX, int searchY, int maxX, int maxY)
        {
            if (obj == null) return;
            if (searchX >= maxX || searchY >= maxY || searchX < 0 || searchY < 0 ) return;

            // Если мы здесь уже были.  или здесь ничего. возврат.
            if (matrixBit[searchX, searchY] != 1) return;

            CLeastBitmapTree kvdr = matrixKvadro[searchX, searchY];
            obj.Add(kvdr);
            // Ставим флаг что мы здесь уже были
            matrixBit[searchX, searchY] = 2;

            GetKvadroOfObjects(matrixKvadro, matrixBit, obj, searchX + 1, searchY, maxX, maxY);
            GetKvadroOfObjects(matrixKvadro, matrixBit, obj, searchX - 1, searchY, maxX, maxY);
            GetKvadroOfObjects(matrixKvadro, matrixBit, obj, searchX, searchY + 1, maxX, maxY);
            GetKvadroOfObjects(matrixKvadro, matrixBit, obj, searchX, searchY - 1, maxX, maxY);

            GetKvadroOfObjects(matrixKvadro, matrixBit, obj, searchX + 1, searchY + 1, maxX, maxY);
            GetKvadroOfObjects(matrixKvadro, matrixBit, obj, searchX - 1, searchY + 1, maxX, maxY);
            GetKvadroOfObjects(matrixKvadro, matrixBit, obj, searchX - 1, searchY - 1, maxX, maxY);
            GetKvadroOfObjects(matrixKvadro, matrixBit, obj, searchX + 1, searchY - 1, maxX, maxY);                    
        }

        /// <summary>
        /// Вывод полчученных объектов изображения
        /// </summary>        
        void DrawRectanglesOnImage(CLeastBitmapTree Tree, List<CObjectImg> ArrayImgObjects)
        {
            if (ArrayImgObjects == null) return;
            if (BitmapTree == null) return;
            if (Tree == null) return;

            Bitmap newBitmap = BitmapTree.Clone(new Rectangle(0, 0, BitmapTree.Width, BitmapTree.Height), BitmapTree.PixelFormat);

            // Create a Bitmap image in memory and set its CompositingMode            
            Graphics gBmp = Graphics.FromImage(newBitmap);
            gBmp.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

            /// Здесь нашли уже объекты

            // Отрисовка
            /*
            Pen PenBox = new Pen(Color.Gold, 30);
            foreach (CObjectImg Obj in ArrayImgObjects)
            { 
                gBmp.DrawRectangle(PenBox, Obj.BoundRectangle);
            }
            */

            int ggg = 0;
            int colR = 250;
            int colG = 200;
            int colB = 0;
            foreach (CObjectImg Obj in ArrayImgObjects)
            {
                colR = colR - 10;
                colG = colG + 3;
                colB = colB + 50;

                if (colR > 255) colR = 255; if (colR <= 0) colR = 255;
                if (colG > 255) colG = 0; if (colG <= 0) colG = 0;
                if (colB > 255) colB = 0; if (colB <= 0) colB = 0;

                Pen NewPen = new Pen(Color.FromArgb(colR, colG, colB), 6);

                // Берём один объект
                foreach (CLeastBitmapTree least in Obj.arrayKvadro)
                {
                    gBmp.DrawRectangle(NewPen, (int)least.X, (int)least.Y, (int)least.WIDTH, (int)least.HEIGHT);
                }

                //if (++ggg == 2) break;
            }

            pictureBox1.Image = newBitmap;
            pictureBox1.Refresh();
        }

        /// <summary>
        ///  Очистить изображение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearImg_Click(object sender, EventArgs e)
        {            
            if (BitmapTree == null) return;            

            Bitmap newBitmap = BitmapTree.Clone(new Rectangle(0, 0, BitmapTree.Width, BitmapTree.Height), BitmapTree.PixelFormat);
             
            pictureBox1.Image = newBitmap;
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Закрасить объекты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawFillRectangles_Click(object sender, EventArgs e)
        {
            if (ArrayImgObjects == null) return;
            if (pictureBox1.Image == null) return;
            if (Tree == null) return;

            Bitmap newBitmap = (Bitmap)pictureBox1.Image.Clone();//new Rectangle(0, 0, BitmapTree.Width, BitmapTree.Height), BitmapTree.PixelFormat);

            // Create a Bitmap image in memory and set its CompositingMode            
            Graphics gBmp = Graphics.FromImage(newBitmap);
            gBmp.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

            // Отрисовка
            int ggg = 0;
            int colR = 255;
            int colG = 0;
            int colB = 0;
            foreach (CObjectImg Obj in ArrayImgObjects)
            {
                colR = colR - 10;
                colG = colG + 3;
                colB = colB + 50;

                if (colR > 255) colR = 255; if (colR <= 0) colR = 255;
                if (colG > 255) colG = 0; if (colG <= 0) colG = 0;
                if (colB > 255) colB = 0; if (colB <= 0) colB = 0;

                Brush NewBrush = new SolidBrush(Color.FromArgb(colR, colG, colB) );

                // Берём один объект
                foreach (CLeastBitmapTree least in Obj.arrayKvadro)
                {
                    gBmp.FillRectangle(NewBrush, (int)least.X, (int)least.Y, (int)least.WIDTH, (int)least.HEIGHT);
                }

                //if (++ggg == 2) break;
            }

            pictureBox1.Image = newBitmap;
            pictureBox1.Refresh();

        }
                

        /// <summary>
        /// Отобразить рамки объектов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDrawBoxes_Click(object sender, EventArgs e)
        {
            if (ArrayImgObjects == null) return;
            if (pictureBox1.Image == null) return;
            if (Tree == null) return;

            Bitmap newBitmap = (Bitmap)pictureBox1.Image.Clone();//new Rectangle(0, 0, BitmapTree.Width, BitmapTree.Height), BitmapTree.PixelFormat);

            // Create a Bitmap image in memory and set its CompositingMode            
            Graphics gBmp = Graphics.FromImage(newBitmap);
            gBmp.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
             
            // Отрисовка
            Pen PenBox = new Pen(Color.LightGreen, newBitmap.Width/200);
            Brush brushBox = new SolidBrush(Color.Aquamarine);
            int RaduisCenter = newBitmap.Width/200;
            foreach (CObjectImg Obj in ArrayImgObjects)
            {
                gBmp.DrawRectangle(PenBox, Obj.BoundRectangle);
                gBmp.FillEllipse(brushBox, Obj.Center.X - RaduisCenter, Obj.Center.Y - RaduisCenter, RaduisCenter * 2, RaduisCenter * 2);
            }

            pictureBox1.Image = newBitmap;
            pictureBox1.Refresh();
        }

        /// <summary>
        /// Построение триангуляции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTriangle_Click(object sender, EventArgs e)
        {
            
           

            List<CTriangle> listTirangles = CTriangulation.Triangulate_func(BitmapTree, ArrayImgObjects, checkBox_ShowProcess.Checked, pictureBox1);

            double SumCi = 0;
            double maxCi = 0;

            if (listTirangles != null)
            {
                // Расчёт коэффициентов            
                foreach (CTriangle tri in listTirangles)
                {
                    double ci = tri.calcCi();
                    SumCi += ci;
                    if (maxCi < ci)
                        maxCi = ci;
                }
            }

            txtBox_MaxCi.Text = maxCi.ToString();

            txtBox_AverageCi.Text = (SumCi / listTirangles.Count).ToString();

            ArrayTriangles = listTirangles;

            MessageBox.Show("Триангуляция окончена");
             


            
        }

         


        /// <summary>
        /// Показать треугольники
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_show_triangles_Click(object sender, EventArgs e)
        {
            if (ArrayTriangles == null) return;
            if (pictureBox1.Image == null) return;
                         

            Bitmap newBitmap = (Bitmap)pictureBox1.Image.Clone();//new Rectangle(0, 0, BitmapTree.Width, BitmapTree.Height), BitmapTree.PixelFormat);

            // Create a Bitmap image in memory and set its CompositingMode            
            Graphics gBmp = Graphics.FromImage(newBitmap);
            gBmp.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;

            // Отрисовка 

            Pen penPaint = new Pen(Color.Gold, BitmapTree.Width / 200);
            Pen penForCircle = new Pen(Color.White, BitmapTree.Width / 250);

            // Выводим треугольники
            foreach (CTriangle tri in ArrayTriangles)
            {
                gBmp.DrawLine(penPaint, tri.objPoint1.Center, tri.objPoint2.Center);
                gBmp.DrawLine(penPaint, tri.objPoint2.Center, tri.objPoint3.Center);
                gBmp.DrawLine(penPaint, tri.objPoint3.Center, tri.objPoint1.Center);

                //gBmp.DrawEllipse(penForCircle, (float)(tri.center.X - tri.raduisCircle), (float)(tri.center.Y - tri.raduisCircle), (float)tri.raduisCircle * 2, (float)tri.raduisCircle * 2);

                //gBmp.DrawEllipse(penPaint, (int)(centerCircle.X - RaduisCircle), (int)(centerCircle.Y - RaduisCircle), (int)RaduisCircle * 2, (int)RaduisCircle * 2);

            }

            pictureBox1.Image = newBitmap;
            pictureBox1.Refresh();

             

        }

        /// <summary>
        /// Расчёт коэффициентов геометрической концентрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCalcCi_Click(object sender, EventArgs e)
        {
            if (ArrayTriangles == null) return;
            if (pictureBox1.Image == null) return;

            Bitmap newBitmap = (Bitmap)pictureBox1.Image.Clone();//new Rectangle(0, 0, BitmapTree.Width, BitmapTree.Height), BitmapTree.PixelFormat);

            // Create a Bitmap image in memory and set its CompositingMode            
            Graphics gBmp = Graphics.FromImage(newBitmap);
            gBmp.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;//.SourceCopy;

            // Отрисовка 

            Pen penPaint = new Pen(Color.Gold, BitmapTree.Width / 200);
            Pen penForCircle = new Pen(Color.White, BitmapTree.Width / 250);

            Font fontStr = new Font("Times New Roman", BitmapTree.Width / 50);
            

            int AlphaChannel = trackBar_alpha.Value;

            int CountTriCi1 = 0;
            double SquareTriCi1 = 0;
            int CountTriCi2 = 0;
            double SquareTriCi2 = 0;
            int CountTriCi3 = 0;
            double SquareTriCi3 = 0;

            // Отображение
            foreach (CTriangle tri in ArrayTriangles)
            { 

                Brush br1 = new SolidBrush(Color.FromArgb(AlphaChannel, txtBox_koef1.BackColor)); //Color.LightGreen);
                Brush br2 = new SolidBrush(Color.FromArgb(AlphaChannel, txtBox_koef2.BackColor)); //Color.LimeGreen);
                Brush br3 = new SolidBrush(Color.FromArgb(AlphaChannel, txtBox_koef3.BackColor)); //Color.Green);

                if (tri.Ci > Convert.ToDouble(txtBox_koef3.Text)) //(maxCi / 3) * 2)
                {
                    gBmp.FillPolygon(br3, new Point[] { tri.objPoint1.Center, tri.objPoint2.Center, tri.objPoint3.Center });

                    CountTriCi3++;
                    SquareTriCi3 += tri.getSquare();
                }
                else if (tri.Ci > Convert.ToDouble(txtBox_koef2.Text)) //maxCi / 3)
                {
                    gBmp.FillPolygon(br2, new Point[] { tri.objPoint1.Center, tri.objPoint2.Center, tri.objPoint3.Center });

                    CountTriCi2++;
                    SquareTriCi2 += tri.getSquare();
                }
                else
                { 
                    
                    CountTriCi1++;
                    SquareTriCi1 += tri.getSquare();

                    gBmp.FillPolygon(br1, new Point[] { tri.objPoint1.Center, tri.objPoint2.Center, tri.objPoint3.Center });
                }
            }
			 
            label_ci1.Text = "0 - " + txtBox_koef2.Text;
            txtBoxCi1.Text = "Кол-во: " + CountTriCi1.ToString() + "   Пл.:" + SquareTriCi1.ToString();

            label_ci2.Text = txtBox_koef2.Text + " - " + txtBox_koef3.Text;
            txtBoxCi2.Text = "Кол-во: " + CountTriCi2.ToString() + "   Пл.:" + SquareTriCi2.ToString();

            label_ci3.Text = txtBox_koef3.Text + " - " + txtBox_MaxCi.Text;
            txtBoxCi3.Text = "Кол-во: " + CountTriCi3.ToString() + "   Пл.:" + SquareTriCi3.ToString();

            foreach (CTriangle tri in ArrayTriangles)
            {
              //  gBmp.DrawString(Math.Round(tri.Ci, 2).ToString(), fontStr, br, (tri.objPoint1.Center.X + tri.objPoint2.Center.X + tri.objPoint3.Center.X) / 3 - 5, (tri.objPoint1.Center.Y + tri.objPoint2.Center.Y + tri.objPoint3.Center.Y) / 3 - 5);
            }

            txtBox_TotalKoeff.Text = ((SquareTriCi2 + SquareTriCi3) / (pictureBox1.Image.Width * pictureBox1.Image.Height) * 100).ToString() + "%";


            pictureBox1.Image = newBitmap;
            pictureBox1.Refresh();
            
        }
 
 
        /// <summary>
        /// Изменение цвета одного из порогов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBox_koef2_DoubleClick(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox txBox = sender as TextBox;
                //txBox.Tag
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    txBox.BackColor = colorDialog1.Color;
                }
            }

        }

        /// <summary>
        /// Расчёт  распредения  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void button_calc_distribution_Click(object sender, EventArgs e)
		{
			chart_distribution.Series[0].Points.Clear();
			//Series_Line_distribution.
			//chart_distribution.Series[0].Points.AddXY();
			Dictionary<long, long> arrayCountObjBySquare = new Dictionary<long, long>();

			long widthCOLUMN = 20; 

			long threshold = 0;
			long outVal = 0;
            if (ArrayImgObjects != null)
            {
                foreach (CObjectImg Obj in ArrayImgObjects)
                {
                    threshold = Obj.calcPixels() / widthCOLUMN;

                    if (!arrayCountObjBySquare.TryGetValue(threshold, out outVal))
                        arrayCountObjBySquare.Add(threshold, 0);

                    arrayCountObjBySquare[threshold]++;
                }
            }
             
		

			foreach (KeyValuePair<long, long> point in arrayCountObjBySquare)
			{
				// point.Key - площадь
				// point.Value - количество объектов
				chart_distribution.Series[0].Points.AddXY(point.Key * widthCOLUMN, (double)point.Value / (double)arrayCountObjBySquare.Count);
				
			}
			
			
		}

 

        
           
    }
}
