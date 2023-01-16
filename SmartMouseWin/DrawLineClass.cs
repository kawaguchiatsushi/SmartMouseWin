using System.Diagnostics;
using System.Drawing.Drawing2D;

namespace SmartMouseWin
{
    public class DrawLineClass
    {
        private static int offset = 20;

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
