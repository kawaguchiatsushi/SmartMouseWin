namespace SmartMouseWin
{
    public class Dimension
    {
        ///<summary>
        /// get line Color
        /// </summary>
        public static Color LineColor { get; set; } = Color.SpringGreen;
        public static float LineWidth { get; set; } = 2f;



    
        public static void DrawDimensionLine(Graphics g, PointF StartPoint, PointF EndPoint, float Offset)
        {
            float thRad = (float)Math.Atan2(EndPoint.Y - StartPoint.Y, EndPoint.X - StartPoint.X); 

            var penLine = new Pen(LineColor, LineWidth);

            float lineLength = Offset + 5f;

            var StartPointDst = new PointF(
                StartPoint.X + lineLength * (float)Math.Cos(thRad - Math.PI / 2.0),
                StartPoint.Y + lineLength * (float)Math.Sin(thRad - Math.PI / 2.0)
                );
            g.DrawLine(penLine, StartPoint, StartPointDst);

            var EndPointDst = new PointF(
                EndPoint.X + lineLength * (float)Math.Cos(thRad - Math.PI / 2.0),
                EndPoint.Y + lineLength * (float)Math.Sin(thRad - Math.PI / 2.0)
                );
            g.DrawLine(penLine, EndPoint, EndPointDst);

            var StartPointOffset = new PointF(
                StartPoint.X + Offset * (float)Math.Cos(thRad - Math.PI / 2.0),
                StartPoint.Y + Offset * (float)Math.Sin(thRad - Math.PI / 2.0)
                );

            var EndPointOffset = new PointF(
                EndPoint.X + Offset * (float)Math.Cos(thRad - Math.PI / 2.0),
                EndPoint.Y + Offset * (float)Math.Sin(thRad - Math.PI / 2.0)
                );
            g.DrawLine(penLine, StartPointOffset, EndPointOffset);
        }
    }
}
