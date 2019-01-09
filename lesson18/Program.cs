using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.Util;
using System.Drawing;
using Emgu.CV.Util;

namespace Lesson18
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ///累计霍夫变换
            //Mat srcImg = CvInvoke.Imread("1.bmp");
            //CvInvoke.Imshow("src", srcImg);
            //Mat grayImg = new Mat();
            //CvInvoke.CvtColor(srcImg, grayImg, ColorConversion.Bgr2Gray);
            //CvInvoke.Canny(grayImg, grayImg, 30, 200);

            //LineSegment2D[] lines = CvInvoke.HoughLinesP(grayImg, 1, Math.PI / 180, 30, 5, 10);
            //for (int i = 0; i < lines.Length; i++)
            //{
            //    Point pt1 = lines[i].P1;
            //    Point pt2 = lines[i].P2;
            //    CvInvoke.Line(srcImg, pt1, pt2, new MCvScalar(0, 255, 0), 2);
            //}

            //VectorOfRect lines = new VectorOfRect();
            //CvInvoke.HoughLinesP(grayImg, lines, 1, Math.PI / 180, 30, 5, 10);
            //for (int i = 0; i < lines.Size; i++)
            //{
            //    Point pt1 = new Point(lines[i].X, lines[i].Y);
            //    Point pt2 = new Point(lines[i].Width, lines[i].Height);
            //    CvInvoke.Line(srcImg, pt1, pt2, new MCvScalar(0, 255, 0), 2);
            //}

            ///霍夫圆变换
            VideoCapture cap = new VideoCapture(0);
          //  VideoWriter writer = new VideoWriter("out.avi", -1, 20, new Size(640, 480), false);
            if (!cap.IsOpened)
            {
                Console.WriteLine("Open video failed!");
                return;
            }
           
            while (true)
            {
                Mat srcImg = new Mat();
                Mat grayImg = new Mat();
                cap.Read(srcImg);
                //Mat srcImg = CvInvoke.Imread("circle.jpg");
                CvInvoke.Imshow("src", srcImg);
           // Mat grayImg = new Mat();
            CvInvoke.CvtColor(srcImg, grayImg, ColorConversion.Bgr2Gray);

            CircleF[] circles = CvInvoke.HoughCircles(grayImg, HoughType.Gradient, 1.5, 10, 100, 100, 0, 50);
            for (int i = 0; i < circles.Length; i++)
            {
                Console.WriteLine("{0}", i);
                CvInvoke.Circle(srcImg, new Point((int)circles[i].Center.X, (int)circles[i].Center.Y), (int)circles[i].Radius, new MCvScalar(255, 255, 0), 5);
                CvInvoke.Circle(srcImg, new Point((int)circles[i].Center.X, (int)circles[i].Center.Y), 5, new MCvScalar(0, 0, 255), -1);
            }

            CvInvoke.Imshow("dst", srcImg);
                if (CvInvoke.WaitKey(30) == 27)
                    break;
            }
        }
    }
}
  