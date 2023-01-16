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
            Dimension.DrawDimensionLine(graphics, point1, point2,offset);
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
                Dimension.DrawDimensionLine(graphics, pixcelLengthModel.Start, pixcelLengthModel.End, offset);
            }
            if (mesures != null)
            {
                foreach (var mesure in mesures)
                {
                    Dimension.DrawDimensionLine(graphics, mesure.Start, mesure.End, offset);
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
