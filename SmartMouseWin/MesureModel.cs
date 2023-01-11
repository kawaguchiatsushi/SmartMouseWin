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
        public double ObjectPixcelLength;
        public Panel panel_value;
        public Label label_value;
        

        public MesureModel(
            Point start,
            Point end,
            double pixcelLength,
            int magnification = 10

            )
        {
            this.Start = start;
            this.End = end;
            MathClass mathClass = new MathClass();
            this.PixcelLength = pixcelLength;
            this.ObjectPixcelLength = mathClass.PixcelMeasere(start, end);

            this.Centimeter = mathClass.PixcelLengthtoCMLength(
                this.PixcelLength,
                this.ObjectPixcelLength,
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
        public Panel panel_value;
        public Label label_value;


        public PixcelLengthModel(Point start,Point end)
        {
            this.Start = start;
            this.End = end;
            MathClass mathClass = new MathClass();
            this.PixcelLength = mathClass.PixcelMeasere(start, end);
            
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
            label.TabIndex = 0;
            label.Font = new Font("Arial",12f);
            label.Text = str;
            label.Size = new System.Drawing.Size(0, 13);
        }

        public static void Set_Panel(Panel panel, Label label, Point end)
        {
            // 
            // panel_value
            // 
            panel.Size = new System.Drawing.Size(0, 13);
            panel.AutoSize = true;
            //panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            panel.BackColor = System.Drawing.Color.White;
            panel.Controls.Add(label);
            
            panel.TabIndex = 1;
            var changLocation = LocationClass.ChangeValuePanelLocation(
                end,
                MesureForm.Swidth,
                MesureForm.Sheight,
                new Size(70,13)
                );
            panel.Location = new Point(
                end.X + changLocation.Item1, end.Y + changLocation.Item2);
        }

    }
}
