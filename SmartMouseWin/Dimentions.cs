using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMouseWin
{
    public class Dimension
    {
        ///<summary>
        /// get line Color
        /// </summary>
        public static Color LineColor { get; set; } = Color.SpringGreen;

        ///// <summary>
        ///// 文字の色を取得設定します。
        ///// </summary>
        //public static Color TextColor { get; set; } = Color.;

        /// <summary>
        /// フォントの名前を取得設定します。
        /// </summary>
        public static FontFamily Family { get; set; } = new FontFamily("Arial");

        /// <summary>
        /// フォントのスタイルを取得設定します。
        /// </summary>
        public static FontStyle Style { get; set; } = FontStyle.Regular;

        /// <summary>
        /// 文字のサイズ（emスクエア）を取得設定します。
        /// </summary>
        public static float EmSize { get; set; } = 18.0f;

        /// <summary>
        /// 文字の書式設定を取得設定します。
        /// </summary>
        public static StringFormat Format { get; set; } = new StringFormat();

        /// <summary>
        /// 寸法値の表示位置の中心からのズレを取得設定します。
        /// </summary>
        public static float TextOffsetX { get; set; } = 0.0f;

        /// <summary>
        /// 寸法値の表示位置の寸法線からの距離を取得設定します。
        /// </summary>
        public static float TextOffsetY { get; set; } = 8.0f;

        /// <summary>
        /// 寸法線の線幅を取得設定します。
        /// </summary>
        public static float LineWidth { get; set; } = 2f;



    
        public static void DrawDimension(Graphics g, PointF StartPoint, PointF EndPoint, float Offset)
        {
            
            //// 文字の回転角度
            float thRad = (float)Math.Atan2(EndPoint.Y - StartPoint.Y, EndPoint.X - StartPoint.X);  // ラジアン
          
            //////////////////////////////////////////////////////////////////
            // 寸法補助線の描画

            // 寸法線用ペンの作成
            var penLine = new Pen(LineColor, LineWidth);

            float lineLength = Offset + 5f; // 少し飛び出させる

            // StartPoint側の描画
            var StartPointDst = new PointF(
                StartPoint.X + lineLength * (float)Math.Cos(thRad - Math.PI / 2.0),
                StartPoint.Y + lineLength * (float)Math.Sin(thRad - Math.PI / 2.0)
                );
            g.DrawLine(penLine, StartPoint, StartPointDst);

            // EndPoint側の描画
            var EndPointDst = new PointF(
                EndPoint.X + lineLength * (float)Math.Cos(thRad - Math.PI / 2.0),
                EndPoint.Y + lineLength * (float)Math.Sin(thRad - Math.PI / 2.0)
                );
            g.DrawLine(penLine, EndPoint, EndPointDst);

            //////////////////////////////////////////////////////////////////
            

            var StartPointOffset = new PointF(
                StartPoint.X + Offset * (float)Math.Cos(thRad - Math.PI / 2.0),
                StartPoint.Y + Offset * (float)Math.Sin(thRad - Math.PI / 2.0)
                );

            var EndPointOffset = new PointF(
                EndPoint.X + Offset * (float)Math.Cos(thRad - Math.PI / 2.0),
                EndPoint.Y + Offset * (float)Math.Sin(thRad - Math.PI / 2.0)
                );

            // 矢印の描画
            g.DrawLine(penLine, StartPointOffset, EndPointOffset);
        }
    }
}
