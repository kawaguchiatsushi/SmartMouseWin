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

        public static void DrawMesure(ref Bitmap camvas, PictureBox pictureBox,Point point1, Point point2)
        {

            Graphics graphics = Graphics.FromImage(camvas);

            Color lineColer = Color.SpringGreen;
            int lineBorder = 3;
            graphics.Clear(Color.Transparent);
            var linePen = new Pen(lineColer, lineBorder);
            //四角形の描写
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            

            //var angle = MathClass.Angle(point1, point2);
            ////var rightAngledPoint1 = MathClass.RightAngledPoint1(angle,point1);
            //var rightAngledPoint2 = MathClass.RightAngledPoint1(angle, point2);

            ////graphics.DrawLine(linePen, point1.X, point1.Y,rightAngledPoint1.X,rightAngledPoint1.Y);
            //graphics.DrawLine(linePen, point2.X, point2.Y, rightAngledPoint2.X, rightAngledPoint2.Y);
            //int ang = 180;
            ////double newX = ((point2.X-point1.X)* Math.Cos(ang))-((point2.Y-point1.Y)*Math.Sin(ang))+point1.X;
            ////double newY = ((point2.X - point1.X) * Math.Sin(ang)) - ((point2.Y - point1.Y) * Math.Cos(ang)) + point1.Y;

            ////graphics.DrawLine(linePen,point1.X,point1.Y,(int)newX, (int)newY);
            graphics.DrawLine(linePen, point1.X, point1.Y, point2.X, point2.Y);
            

            //graphicsの開放
            graphics.Dispose();
            pictureBox.Image = camvas;

            
        }

        public static void DrawMesure(ref Bitmap camvas, PictureBox pictureBox, LinkedList<MesureModel> mesures)
        {

            Graphics graphics = Graphics.FromImage(camvas);

            Color lineColer = Color.SpringGreen;
            int lineBorder = 3;
            graphics.Clear(Color.Transparent);
            var linePen = new Pen(lineColer, lineBorder);
            //四角形の描写
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            if(mesures != null)
            {
                foreach(var mesure in mesures)
                {
                    //var angle = MathClass.Angle(mesure.Start, mesure.End);
                    //var rightAngledPoint1 = MathClass.RightAngledPoint1(angle,point1);
                    //var rightAngledPoint2 = MathClass.RightAngledPoint1(angle, mesure.End);

                    //graphics.DrawLine(linePen, point1.X, point1.Y,rightAngledPoint1.X,rightAngledPoint1.Y);
                    //graphics.DrawLine(linePen, mesure.End.X, mesure.End.Y, rightAngledPoint2.X, rightAngledPoint2.Y);
                    //int ang = 180;
                    //double newX = ((point2.X-point1.X)* Math.Cos(ang))-((point2.Y-point1.Y)*Math.Sin(ang))+point1.X;
                    //double newY = ((point2.X - point1.X) * Math.Sin(ang)) - ((point2.Y - point1.Y) * Math.Cos(ang)) + point1.Y;

                    //graphics.DrawLine(linePen,point1.X,point1.Y,(int)newX, (int)newY);
                    graphics.DrawLine(linePen, mesure.Start.X, mesure.Start.Y, mesure.End.X, mesure.End.Y);

                    mesure.panel_value.Parent = pictureBox;
                }
            }
            
            //graphicsの開放
            graphics.Dispose();
            pictureBox.Image = camvas;


        }

        public static void DrawMesure(ref Bitmap camvas, PictureBox pictureBox,PictureBox parentBox, LinkedList<MesureModel> mesures,PixcelLengthModel pixcelLengthModel)
        {

            Graphics graphics = Graphics.FromImage(camvas);

            Color lineColer = Color.SpringGreen;
            int lineBorder = 3;
            graphics.Clear(Color.Transparent);
            var linePen = new Pen(lineColer, lineBorder);
            //四角形の描写
            SolidBrush blueBrush = new SolidBrush(Color.Blue);

            if(pixcelLengthModel!= null)
            {
                graphics.DrawLine(linePen,pixcelLengthModel.Start,pixcelLengthModel.End);
            }

            if (mesures != null)
            {
                foreach (var mesure in mesures)
                {
                    //var angle = MathClass.Angle(mesure.Start, mesure.End);
                    //var rightAngledPoint1 = MathClass.RightAngledPoint1(angle,point1);
                    //var rightAngledPoint2 = MathClass.RightAngledPoint1(angle, mesure.End);

                    //graphics.DrawLine(linePen, point1.X, point1.Y,rightAngledPoint1.X,rightAngledPoint1.Y);
                    //graphics.DrawLine(linePen, mesure.End.X, mesure.End.Y, rightAngledPoint2.X, rightAngledPoint2.Y);
                    //int ang = 180;
                    //double newX = ((point2.X-point1.X)* Math.Cos(ang))-((point2.Y-point1.Y)*Math.Sin(ang))+point1.X;
                    //double newY = ((point2.X - point1.X) * Math.Sin(ang)) - ((point2.Y - point1.Y) * Math.Cos(ang)) + point1.Y;

                    //graphics.DrawLine(linePen,point1.X,point1.Y,(int)newX, (int)newY);
                    graphics.DrawLine(linePen, mesure.Start.X, mesure.Start.Y, mesure.End.X, mesure.End.Y);

                    mesure.panel_value.Parent = parentBox;
                    //mesure.label_value.Visible= true;
                }
            }

            //graphicsの開放
            graphics.Dispose();
            pictureBox.Image = camvas;


        }

        public static void ClearMesure(ref Bitmap camvas, PictureBox pictureBox)
        {

            Graphics graphics = Graphics.FromImage(camvas);
            graphics.Clear(Color.Transparent);
            graphics.Dispose();
            pictureBox.Image = camvas;


        }


    }
}
