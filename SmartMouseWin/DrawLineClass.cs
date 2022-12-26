using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace SmartMouseWin
{
    public class DrawLineClass
    {
        public void DrawLine(PaintEventArgs eventArgs,Point point1,Point point2)
        {
            try
            {
                var pen = new Pen(Color.Gray, 10);
                pen.DashStyle = DashStyle.Dash;
                Graphics g = eventArgs.Graphics;
                g.DrawLine(pen, point1, point2);
                g.Dispose();

            }
            catch(Exception ex)
            {

            }


        }

        /// <summary>
        /// 画像に線を引く。画像に長さを表示する。
        /// </summary>
        /// <param name="canvas"></param>
        /// <param name="backupImage"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <param name="length"></param>
        public static void DrawLengthLine(ref Bitmap canvas, ref Bitmap backupImage,
            Point point1, Point point2, string length)
        {
            try
            {
                Color lineColer = Color.SpringGreen;
                int lineBorder = 3;
                var g = Graphics.FromImage(canvas);
                var linePen = new Pen(lineColer, lineBorder);

                g.DrawImage(backupImage, 0, 0);

                linePen.DashStyle = DashStyle.Solid;

                Font cfont = new Font("Arial", 11);
                g.DrawString(length + "cm", cfont, Brushes.SpringGreen, point2.X + 10, point2.Y + 10);
                g.DrawLine(linePen, point1.X, point1.Y, point2.X, point2.Y);

                g.Dispose();
            }
            catch (Exception)
            {

            }

        }




    }
}
