using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartMouseWin
{
    public partial class MesureForm : Form
    {
        private Point zeroPoint = new(0,0);
        private Padding zeroPadding = new(0);
        
        DrawLineClass drawLine = new DrawLineClass();
        double myOpacity = 0.01;
        Bitmap camvas;
        Bitmap captureBitmap;
        Bitmap backCamvas;
        public static readonly int Swidth =  Screen.PrimaryScreen.Bounds.Width;
        public static readonly int Sheight = Screen.PrimaryScreen.Bounds.Height;
        public static readonly Size S_Size = Screen.PrimaryScreen.Bounds.Size;

        LinkedList<Point> myPoints = new LinkedList<Point>();
        List<Point> points= new List<Point>();
        LinkedList<Point> pixcelLengths= new LinkedList<Point>();
        bool isPixcelLength = true;
        bool isButtonCloseMove = false;
        bool isMesure = true;
        //bool isMesure = false;
        PixcelLengthModel? MyPixcelLength;
        LinkedList<MesureModel> mesures= new LinkedList<MesureModel>();
        Form magform;
        Magnifier magnifier;
        //MagForm magform;

        public MesureForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = S_Size;

            pictureBox1.Location = pictureBox2.Location = pictureBox3.Location = zeroPoint;

            pictureBox1.Margin= pictureBox2.Margin = pictureBox3.Margin= zeroPadding;

            pictureBox1.ClientSize = pictureBox2.ClientSize = pictureBox3.ClientSize = S_Size;

            pictureBox1.BackColor = pictureBox2.BackColor = pictureBox3.BackColor = Color.Transparent;
            
            camvas = new Bitmap(Swidth, Sheight);
            backCamvas= new Bitmap(Swidth, Sheight);
            pictureBox2.Image = backCamvas;
            pictureBox3.Image= camvas;
            pictureBox2.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox2;

            Settings_panel.Parent = panel_values.Parent = Control_button.Parent = pictureBox3;
            Settings_panel.Visible = panel_values.Visible = false;
 
            label_value1.Size = new Size(0, 13);
            panel_values.Size = new Size(0, 13);

        }

        


        

        private void MesureForm_Load(object sender, EventArgs e)
        {
            this.Opacity = myOpacity;
            this.TransparencyKey = this.BackColor;
            this.panel_values.BackColor= Color.Transparent;
            captureBitmap = new Bitmap(Swidth, Sheight);
            Graphics g = Graphics.FromImage(captureBitmap);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), captureBitmap.Size);
            g.Dispose();
            pictureBox1.Image= captureBitmap;
            this.Opacity = 1.0;
            this.TransparencyKey = Color.Empty;
            //panel_values.BackColor = Color.FromArgb(100,Color.Gray);
            button_close.Visible = true;
            
            //magform = new MagForm();
            Magform();
            //this.magnifier = new Magnifier(magform);
        }

        private void Magform()
        {
            Size magformSize = new Size(100, 100);
            this.magform = new Form();

            this.magnifier = new Magnifier(this.magform);

            this.magform.FormBorderStyle = FormBorderStyle.None;
            this.magform.Size = magformSize;

            this.magform.Location = new Point(
                this.Control_button.Location.X + this.Control_button.Width + 20,
                this.Control_button.Location.Y);

            ///
            PictureBox magPicBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(magPicBox)).BeginInit();
            magPicBox.Parent = this.magform;

            magPicBox.BackColor = Color.Transparent;
            magPicBox.Location = zeroPoint;
            magPicBox.Size = magformSize;
            magPicBox.Margin = zeroPadding;
            Bitmap magBitmap = new Bitmap(magformSize.Width, magformSize.Height);
            Color lineColer = Color.SpringGreen;
            int lineBorder = 1;
            Pen linePen = new Pen(lineColer, lineBorder);
            Graphics g = Graphics.FromImage(magBitmap);
            g.Clear(Color.Transparent);
            g.DrawLine(linePen, magformSize.Width / 2, 0, magformSize.Width / 2, magformSize.Height);
            g.DrawLine(linePen, 0, magformSize.Height / 2, magformSize.Width, magformSize.Height / 2);
            g.Dispose();
            magPicBox.Image = magBitmap;

            ///

            this.magform.TopMost = true;
            this.magform.Visible = true;
        }


        private void Button_close_Click(object sender, EventArgs e)
        {

            this.Close();
            this.magform.Close();
        }

        private void Button_close_MouseDown(object sender, MouseEventArgs e)
        {
            isButtonCloseMove=true;
            
        }

        private void Button_close_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void Button_close_MouseUp(object sender, MouseEventArgs e)
        {
            if (isButtonCloseMove)
            {
                button_close.Location = e.Location;
            }
            isButtonCloseMove = !isButtonCloseMove;
        }

        private void Button_mode_Click(object sender, EventArgs e)
        {
            string pixModeName = "pixcelmode";
            string cmModeName  = "cmモード";
            if (button_mode.Text == pixModeName)
            {
                button_mode.Text = cmModeName;
                this.isPixcelLength= false;
            }
            else if (button_mode.Text == cmModeName)
            {
                button_mode.Text = pixModeName;
                this.isPixcelLength= true;
                mesures.Clear();
                
            }

        }

        private void PictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            magform.Visible= true;

            if (Settings_panel.Visible)
            {
                Settings_panel.Visible = false;
            }
            this.panel_values.BackColor = Color.White;
            if (isMesure)
            {
                
                if (isPixcelLength)
                {
                    pixcelLengths.AddLast(new Point(e.X, e.Y));
                    if (pixcelLengths.Count > 1)
                    {
                        MyPixcelLength = new PixcelLengthModel(
                            pixcelLengths.ElementAt(0),
                            pixcelLengths.ElementAt(1)
                            );
                        isPixcelLength = !isPixcelLength;
                        pixcelLengths.Clear();
                        
                        DrawLineClass.DrawMesure(
                            ref backCamvas,
                            pictureBox2,
                            MyPixcelLength.Start,
                            MyPixcelLength.End
                            );

                    }
                    pictureBox3.Refresh();
                    return;

                }
                
                if (myPoints.Count ==2)
                {
                    if (MyPixcelLength == null)
                    {
                        return;
                    }
                    MesureModel mesureModel = new MesureModel(
                        myPoints.ElementAt(0),
                        myPoints.ElementAt(1),
                        MyPixcelLength.PixcelLength,
                        magnification: 10
                        );
                    mesures.AddLast(mesureModel);
                    myPoints.Clear();
                    DrawLineClass.ClearMesure(ref camvas,pictureBox3);
                    panel_values.Visible = false;
                    
                    if (mesures.Count>0)
                    {
                        DrawLineClass.DrawMesure_D(
                            ref backCamvas,
                            pictureBox2,
                            pictureBox3,
                            mesures,
                            MyPixcelLength
                            );
                        
                    }
                    pictureBox3.Refresh();
                    return;
                }
                myPoints.AddLast(new Point(e.X, e.Y));

            }
        }

        private void PictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMesure)
            {
                return;
            }
            if (isPixcelLength && pixcelLengths.Count > 0)
            {
                DrawLineClass.DrawMesure(ref camvas,
                    pictureBox3, pixcelLengths.ElementAt(0), e.Location);
                return;
            }
            if (myPoints.Count < 1)
            {
                return;
            }
            panel_values.Visible = true;
            int myX = e.Location.X;
            int myY = e.Location.Y;



            if (this.myPoints.Count == 2)
            {
                this.myPoints.RemoveLast();
            }
            this.myPoints.AddLast(e.Location);

            var p1 = myPoints.ElementAt(0);
            var p2 = myPoints.ElementAt(1);
            MathClass mathClass = new();
            var pixlength = mathClass.PixcelMeasere(p1, p2);


            DrawLineClass.DrawMesure(ref camvas, pictureBox3, p1, p2);

            string s = String.Format(
                "{0}pixcel",

                pixlength.ToString("0.00")

                 );
            this.label_value1.Text = s;
            var changLocation = LocationClass.ChangeValuePanelLocation(e.Location, Swidth, Sheight, panel_values.Size);
            this.panel_values.Location = new Point(myX + changLocation.Item1, myY + changLocation.Item2);


        }

        private void PictureBox3_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void Button_return_Click(object sender, EventArgs e)
        {
            if (panel_values.Visible)
            {
                panel_values.Visible = false;
                DrawLineClass.ClearMesure(ref camvas, pictureBox3);
                return;
            }
            
            if (mesures.Count>0)
            {
                mesures.Last().panel_value.Dispose();
                mesures.RemoveLast();
                if (MyPixcelLength==null)
                {
                    return;
                }
                DrawLineClass.ClearMesure(ref backCamvas, pictureBox2);
                if (mesures.Count==0)
                {
                    DrawLineClass.DrawMesure(
                             ref backCamvas,
                             pictureBox2,
                             MyPixcelLength.Start,
                             MyPixcelLength.End
                             );
                    return;
                }
                else
                {
                    DrawLineClass.DrawMesure(
                            ref backCamvas,
                            pictureBox2,
                            pictureBox3,
                            mesures,
                            MyPixcelLength
                            );

                }

            }

            if (mesures.Count==0 && MyPixcelLength!=null)
            {
                Close_Processing();
                isPixcelLength = !isPixcelLength;
            }
        }

        private void Close_Processing()
        {
            MyPixcelLength = null;
            DrawLineClass.ClearMesure(ref backCamvas, pictureBox2);
            DrawLineClass.ClearMesure(ref camvas, pictureBox3);
            panel_values.Visible = false;
            if (myPoints.Count > 0)
            {
                myPoints.Clear();
            }

            
        }

        private void Control_button_Click(object sender, EventArgs e)
        {
            Settings_panel.Visible = !Settings_panel.Visible;
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            //if (mesures.Count > 0)
            //{
            //    MesureModel.Value_Save();
            //}
            

        }
    }
}
