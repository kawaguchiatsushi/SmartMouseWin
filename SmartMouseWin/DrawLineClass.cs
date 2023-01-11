using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace SmartMouseWin
{
    public class DrawLineClass
    {
        private static Color lineColer = Color.SpringGreen;
        private static int lineBorder = 3;
        private static Pen linePen = new Pen(lineColer, lineBorder);
        private static Font cfont = new Font("Arial", 11);
        private static int offset = 20;

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
        /// 
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
            Dimension.DrawDimension(graphics, point1, point2,offset);
            //graphics.DrawLine(linePen, point1.X, point1.Y, point2.X, point2.Y);
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
        /// Main use
        /// </summary>
        /// <param name="camvas"></param>
        /// <param name="pictureBox"></param>
        /// <param name="parentBox"></param>
        /// <param name="mesures"></param>
        /// <param name="pixcelLengthModel"></param>
        public static void DrawMesure_D(ref Bitmap camvas, PictureBox pictureBox, PictureBox parentBox, LinkedList<MesureModel> mesures, PixcelLengthModel pixcelLengthModel)
        {
            

            Graphics graphics = Graphics.FromImage(camvas);
            graphics.Clear(Color.Transparent);

            if (pixcelLengthModel != null)
            {
                if (pixcelLengthModel.Start.Y >pixcelLengthModel.End.Y)
                {
                    Dimension.DrawDimension(graphics, pixcelLengthModel.Start, pixcelLengthModel.End, offset);
                }
                else if (pixcelLengthModel.Start.Y <= pixcelLengthModel.End.Y)
                {
                    Dimension.DrawDimension(graphics, pixcelLengthModel.End,pixcelLengthModel.Start , offset);
                }
                
                
                
            }
            if (mesures != null)
            {
                foreach (var mesure in mesures)
                {
                    
                    if (mesure.Start.Y < MesureForm.Sheight/2)
                    {
                        if (mesure.Start.X > mesure.End.X)
                        {
                            Dimension.DrawDimension(graphics, mesure.End, mesure.Start, offset);
                        }
                        else
                        {
                            Dimension.DrawDimension(graphics, mesure.Start, mesure.End, offset);
                        }
                            
                    }
                    else
                    {
                        if(mesure.Start.X > mesure.End.X)
                        {
                            Dimension.DrawDimension(graphics, mesure.Start, mesure.End, offset);
                        }
                        else
                        {
                            Dimension.DrawDimension(graphics, mesure.End, mesure.Start, offset);
                        }
                        
                    }


                    //Dimension.DrawDimension(graphics,mesure.Start,mesure.End,offset);
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
