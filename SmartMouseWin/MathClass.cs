﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMouseWin
{
    internal class MathClass
    {
        public double PixcelMeasere(Point point1, Point point2)
        {
            return Math.Sqrt(
                    (Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2))
                    );
        }


        /// <summary>
        /// pixcelの長さが何センチか。デフォルトでは10㎝のピクセル距離基準として計算する。
        /// magnificationを変更することで調整。
        /// </summary>
        /// <param name="pixcelLength"></param>
        /// <param name="magnification"></param>
        /// <returns></returns>
        public double PixcelLengthtoCMLength(double pixcelLength,double objectpixcelLength,int magnification=10)
        {
            return objectpixcelLength / (pixcelLength / magnification);
        }

        public static double Angle(Point point1,Point point2)
        {
            Point p1 = point1;
            Point p2 = point2;

            if (p1.X > p2.X)
            {
                p2.X= point1.X;
                p1.X= point2.X;
            }
            if (p1.Y> p2.Y)
            {
                p2.Y= point1.Y;
                p2.Y=point2.Y;
            }

            var r = Math.Atan2(p2.Y - p1.Y,p2.X-p1.X);
            //Debug.WriteLine("こちらはrad" + r.ToString());
            if (r<0)
            {
                r = r + (2* Math.PI);
            }
            double angle =  r * (180 / Math.PI);

            return angle;

        }

        public static Point RightAngledPoint1(double angle, Point point)
        {
            int rlength = 20;
            double rightAngle = 0;
            Debug.WriteLine("こちらはangle: "+angle.ToString());
            rightAngle = angle + 90;

            //if (angle >= 360)
            //{
            //    rightAngle = rightAngle - 360;
            //}
            Debug.WriteLine("こちらはcos: " + Math.Cos(rightAngle).ToString());
            Debug.WriteLine("こちらはsin: " + Math.Sin(rightAngle).ToString());

            //double newX = rlength * Math.Cos(rightAngle) + point.X;
            //double newY = rlength * Math.Sin(rightAngle) + point.Y;
            double newX = (rlength* Math.Cos(rightAngle))-(rlength *Math.Sin(rightAngle))+point.X;
            double newY = (rlength * Math.Sin(rightAngle)) - (rlength * Math.Cos(rightAngle )) + point.Y;
            Point newPoint = new Point((int)newX, (int)newY);
            Debug.WriteLine("こちらは新たな座標: " + newPoint.ToString());
            return newPoint;


        }
    }
}