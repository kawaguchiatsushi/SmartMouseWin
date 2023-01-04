using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace SmartMouseWin
{
    public class DrawLineClass
    {
        private static Color lineColer = Color.SpringGreen;
        private static int lineBorder = 3;
        private static Pen linePen = new Pen(lineColer, lineBorder);
        private static Font cfont = new Font("Arial", 11);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eventArgs"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
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
                Debug.WriteLine(ex.ToString());
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
                var g = Graphics.FromImage(canvas);
                
                g.DrawImage(backupImage, 0, 0);

                g.DrawString(length + "cm", cfont, Brushes.SpringGreen, point2.X + 10, point2.Y + 10);
                g.DrawLine(linePen, point1.X, point1.Y, point2.X, point2.Y);

                g.Dispose();
            }
            catch (Exception)
            {

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="camvas"></param>
        /// <param name="pictureBox"></param>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        public static void DrawMesure(ref Bitmap camvas, PictureBox pictureBox,Point point1, Point point2)
        {
            Graphics graphics = Graphics.FromImage(camvas);
            graphics.Clear(Color.Transparent);
            graphics.DrawLine(linePen, point1.X, point1.Y, point2.X, point2.Y);
            graphics.Dispose();
            pictureBox.Image = camvas;
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="camvas"></param>
        /// <param name="pictureBox"></param>
        /// <param name="parentBox"></param>
        /// <param name="mesures"></param>
        /// <param name="pixcelLengthModel"></param>
        public static void DrawMesure(ref Bitmap camvas, PictureBox pictureBox,PictureBox parentBox, LinkedList<MesureModel> mesures,PixcelLengthModel pixcelLengthModel)
        {

            Graphics graphics = Graphics.FromImage(camvas);
            graphics.Clear(Color.Transparent);
            
            if (pixcelLengthModel!= null)
            {
                graphics.DrawLine(linePen,pixcelLengthModel.Start,pixcelLengthModel.End);
            }
            if (mesures != null)
            {
                foreach (var mesure in mesures)
                {
                    graphics.DrawLine(linePen, mesure.Start.X, mesure.Start.Y, mesure.End.X, mesure.End.Y);
                    mesure.panel_value.Parent = parentBox;
                }
            }
            graphics.Dispose();
            pictureBox.Image = camvas;
        }

        /// <summary>
        /// bitmapClear
        /// </summary>
        /// <param name="camvas"></param>
        /// <param name="pictureBox"></param>
        public static void ClearMesure(ref Bitmap camvas, PictureBox pictureBox)
        {

            Graphics graphics = Graphics.FromImage(camvas);
            graphics.Clear(Color.Transparent);
            graphics.Dispose();
            pictureBox.Image = camvas;


        }

        


    }
}
