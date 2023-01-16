using System;
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
        /// Calculates how many pixels are in 1 cm length. 
        /// By default, it is calculated based on a pixel distance of 10 cm.
        /// Adjust by changing magnification.
        /// </summary>
        /// <param name="pixcelLength"></param>
        /// <param name="magnification"></param>
        /// <returns></returns>
        public double PixcelLengthtoCMLength(double pixcelLength,double objectpixcelLength,int magnification=10)
        {
            return objectpixcelLength / (pixcelLength / magnification);
        }
    }
}
