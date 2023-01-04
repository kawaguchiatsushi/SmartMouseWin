using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMouseWin
{
    /// <summary>
    /// mesureの変数を管理する
    /// </summary>
    public class MesureModel
    {
        public Point Start;
        public Point End;
        public double PixcelLength;
        public double Centimeter;
        public string CentimeterStr;
        public Panel panel_value;
        private Label label_value;
        

        public MesureModel(
            Point start,
            Point end,
            double objectPixcelLength,
            int magnification = 10

            )
        {
            this.Start = start;
            this.End = end;
            this.PixcelLength = MathClass.PixcelMeasere(start, end);
            this.Centimeter = MathClass.PixcelLengthtoCMLength(
                this.PixcelLength,
                objectPixcelLength,
                magnification
                );
            this.CentimeterStr =
                String.Format(
                    "{0}cm",
                    Centimeter.ToString("0.00")
                    );
            this.panel_value = new Panel();
            this.label_value = new Label();
            SetCompornent.Set_Lavel(this.label_value, this.CentimeterStr);
            SetCompornent.Set_Panel(this.panel_value, this.label_value, this.End);            
        }


    }

    


    public class PixcelLengthModel
    {
        public Point Start;
        public Point End;
        public double PixcelLength;
        public string PixcelLengthStr;
        private Panel panel_value;
        private Label label_value;


        public PixcelLengthModel(Point start,Point end)
        {
            this.Start = start;
            this.End = end;
            this.PixcelLength = MathClass.PixcelMeasere(start, end);
            
            this.PixcelLengthStr =
                String.Format(
                    "{0}pixcel",
                    PixcelLength.ToString("0.00")
                    );

            this.panel_value = new Panel();
            this.label_value= new Label();
            SetCompornent.Set_Lavel(this.label_value,this.PixcelLengthStr);
            SetCompornent.Set_Panel(this.panel_value,this.label_value,this.End);
        }


        

    }

    public class SetCompornent
    {
        public static void Set_Lavel(Label label, string str)
        {

            label.AutoSize = true;
            label.Size = new System.Drawing.Size(0, 15);
            label.TabIndex = 0;
            label.Font = new Font("Arial",12f);
            label.Text = str;
        }

        public static void Set_Panel(Panel panel, Label label, Point end)
        {
            // 
            // panel_value
            // 
            panel.AutoSize = true;
            panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            panel.Controls.Add(label);
            panel.Size = new System.Drawing.Size(100, 43);
            panel.TabIndex = 1;
            var changLocation = LocationClass.ChangeValuePanelLocation(
                end,
                Screen.PrimaryScreen.Bounds.Size,
                panel.Size
                );
            panel.Location = new Point(
                end.X + changLocation.Item1, end.Y + changLocation.Item2);
        }

    }
}
