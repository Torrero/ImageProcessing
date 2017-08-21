using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace AppCloudCover
{
    class CKvadroTree
    {
        static public Int64 calcCloudsPixels(Bitmap img)
        {
            if (img == null) return 0;

            Int64 countWhitePixels = 0;
            Color searchColor = Color.FromArgb(255, 255, 255, 255);

            for (int i = 0; i < img.Width; i++)
                for (int j = 0; j < img.Height; j++)
                {
                    Color cl = img.GetPixel(i, j);

                    if (cl == searchColor)
                    {
                        countWhitePixels++;
                    }
                }

            return countWhitePixels;
        }

        // Вычислить количество облачных(белых) пикселей в заданном участке
        // Бежим по выбранному участку изображения и считаем пикселы с нужными значениями. (В нашем случае белые)
        static public Int64 calcCloudsPixels2(Bitmap img, int x0, int y0, int width, int heigth)
        {
            if (img == null) return 0;

            Int64 countWhitePixels = 0;

            BitmapData bmpData = img.LockBits(new Rectangle(x0, y0, width, heigth), ImageLockMode.ReadOnly, img.PixelFormat);

            IntPtr PtrImg = bmpData.Scan0;
            int imHeight = bmpData.Height;
            int imWidth = bmpData.Width;

            unsafe
            {
                byte* PtrByte = (byte*)PtrImg.ToPointer();
                byte* oldBPtrHelper = PtrByte;

                for (int y = 0; y < imHeight; y++)
                {
                    for (int x = 0; x < imWidth; x++)
                    {
                        byte pxRed = *(PtrByte++);
                        byte pxGreen = *(PtrByte++);
                        byte pxBlue = *(PtrByte++);

                        if (pxRed >= 250 && pxGreen >= 250 && pxBlue >= 250)
                            countWhitePixels++;
                    }
                    oldBPtrHelper += bmpData.Stride;
                    PtrByte = oldBPtrHelper;
                }
            }
            img.UnlockBits(bmpData);

            return countWhitePixels;
        }


        /// <summary>
        /// // Построение дерева квадрантов. Рекурсия.
        /// </summary>
        /// <param name="BitmapTree">Анализируемое изображение</param>
        /// <param name="AnalysImg"></param>
        /// <param name="globX">ограничение по X</param>
        /// <param name="globY">ограничение по Н</param>
        /// <param name="CONST_MIN_BOX_OF_PIXELS"> Размер примитива( X:Y) (пикс):</param>
        /// <param name="MAX_NEED_PIXELS_FOR_CLOUDS"> Порог кол-ва облачных пикселей в квадранте:</param>
        static public void BildTree(Bitmap BitmapTree, CLeastBitmapTree AnalysImg, double globX, double globY, int CONST_MIN_BOX_OF_PIXELS, int MAX_NEED_PIXELS_FOR_CLOUDS)
        {
            if (BitmapTree == null) return;

            // Если на картинке есть облачность, то делим её на квадранты иначе просто выходим
            AnalysImg.CountCloudPixels = calcCloudsPixels2(BitmapTree, (int)AnalysImg.X, (int)AnalysImg.Y, (int)AnalysImg.WIDTH, (int)AnalysImg.HEIGHT);


            if (AnalysImg.HEIGHT <= CONST_MIN_BOX_OF_PIXELS || AnalysImg.WIDTH <= CONST_MIN_BOX_OF_PIXELS) return;

            if (AnalysImg.CountCloudPixels >= MAX_NEED_PIXELS_FOR_CLOUDS)
            {
                double WidthImg = AnalysImg.WIDTH;
                double HeightImg = AnalysImg.HEIGHT;
                double newWidthImg = WidthImg / 2;
                double newHeightImg = HeightImg / 2;
                double newX = 0;
                double newY = 0;

                CLeastBitmapTree newList = null;

                newList = new CLeastBitmapTree();
                newX = 0; newY = 0;
                newList.X = globX + newX;
                newList.Y = globY + newY;
                newList.WIDTH = newWidthImg; newList.HEIGHT = newHeightImg;
                newList.NumLevel = AnalysImg.NumLevel + 1;
                AnalysImg.LowLevel.Add(newList);

                newList = new CLeastBitmapTree();
                newX = newWidthImg; newY = 0;
                newList.X = globX + newX;
                newList.Y = globY + newY;
                newList.WIDTH = newWidthImg; newList.HEIGHT = newHeightImg;
                newList.NumLevel = AnalysImg.NumLevel + 1;
                AnalysImg.LowLevel.Add(newList);

                newList = new CLeastBitmapTree();
                newX = 0; newY = newHeightImg;
                newList.X = globX + newX;
                newList.Y = globY + newY;
                newList.WIDTH = newWidthImg; newList.HEIGHT = newHeightImg;
                newList.NumLevel = AnalysImg.NumLevel + 1;
                AnalysImg.LowLevel.Add(newList);

                newList = new CLeastBitmapTree();
                newX = newWidthImg; newY = newHeightImg;
                newList.X = globX + newX;
                newList.Y = globY + newY;
                newList.WIDTH = newWidthImg; newList.HEIGHT = newHeightImg;
                newList.NumLevel = AnalysImg.NumLevel + 1;
                AnalysImg.LowLevel.Add(newList);

                foreach (CLeastBitmapTree least in AnalysImg.LowLevel)
                {

                    BildTree(BitmapTree, least, least.X, least.Y, CONST_MIN_BOX_OF_PIXELS, MAX_NEED_PIXELS_FOR_CLOUDS);
                }

            }
            else
                return;
        }
    }
}
