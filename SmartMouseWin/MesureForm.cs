using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartMouseWin
{
    public partial class MesureForm : Form
    {
        MouseHook mouseHook = new MouseHook();
        DrawLineClass drawLine = new DrawLineClass();
        double myOpacity = 0.1;


        LinkedList<Point> myPoints = new LinkedList<Point>();

        public MesureForm()
        {
            InitializeComponent();

            //mouseHook.Hook();
            mouseHook.UnHook();
            mouseHook.LButtonDownEvent += MouseHook_LButtonDownEvent;
            mouseHook.MouseMoveEvent += MouseHook_MouseMoveEvent;
            mouseHook.LButtonUpEvent += MouseHook_LButtonUpEvent;
        }
        bool isMesure = false;

        private void MesureForm_Load(object sender, EventArgs e)
        {
            this.Opacity = myOpacity; // この値は調整
            //this.panel_background.BackColor= Color.FromArgb(0,Color.White); //0~255で透明度を調整できる。 
        }

        private void MesureForm_MouseDown(object sender, MouseEventArgs e)
        {
            isMesure = !isMesure;
            if (isMesure)
            {
                this.TransparencyKey = this.BackColor;
                this.Opacity = 1.0;
                myPoints.Clear();
                myPoints.AddLast(new Point(e.X, e.Y));
                mouseHook.Hook();
                
            }
     
            
        }

        

        private void MesureForm_MouseMove(object sender, MouseEventArgs e)
        {
            
            

        }

        private void MesureForm_MouseUp(object sender, MouseEventArgs e)
        {
           
        }




        private void MouseHook_LButtonDownEvent(object sender, MouseEventArg e)
        {
            if (isMesure)
            {
                mouseHook.UnHook();
                this.Opacity = myOpacity;
                this.TransparencyKey = Color.Empty;
                isMesure = !isMesure;
            }
            


        }

        private void MouseHook_MouseMoveEvent(object sender, MouseEventArg e)
        {
            
            
            if (isMesure)
            {
                if (this.myPoints.Count == 2)
                {
                    this.myPoints.RemoveLast();
                }
                this.myPoints.AddLast(e.Point);



                string s = String.Format(
                    "X:{0}Y:{1}///X:{2}Y:{3}",
                    myPoints.ElementAt(0).X.ToString(), 
                    myPoints.ElementAt(0).Y.ToString(),
                    myPoints.ElementAt(1).X.ToString(),
                    myPoints.ElementAt(1).Y.ToString()
                    );
                this.label_value1.Text = s;
                this.panel_values.Location= new Point(e.Point.X+10,e.Point.Y+10);
                
                //this.Paint += Panel_background_Paint;
                Debug.WriteLine(s);
            }



        }


        private void MouseHook_LButtonUpEvent(object sender, MouseEventArg e)
        {
            
        }

        
        private void Panel_background_Paint(object? sender, PaintEventArgs e)
        {
            drawLine.DrawLine(e, myPoints.ElementAt(0), myPoints.ElementAt(1));

        }
    }
}
