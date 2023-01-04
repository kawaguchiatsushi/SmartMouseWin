﻿using System;
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
        DrawLineClass drawLine = new DrawLineClass();
        double myOpacity = 0.01;
        Bitmap camvas;
        Bitmap captureBitmap;
        Bitmap backCamvas;
        public static readonly int Swidth =  Screen.PrimaryScreen.Bounds.Width;
        public static readonly int Sheight = Screen.PrimaryScreen.Bounds.Height;

        LinkedList<Point> myPoints = new LinkedList<Point>();
        List<Point> points= new List<Point>();
        LinkedList<Point> pixcelLengths= new LinkedList<Point>();
        bool isPixcelLength = true;
        bool isButtonCloseMove = false;
        bool isMesure = true;
        //bool isMesure = false;
        PixcelLengthModel? MyPixcelLength;
        LinkedList<MesureModel> mesures= new LinkedList<MesureModel>();

        public MesureForm()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(Swidth,Sheight);


            pictureBox1.Location = new Point(0, 0);
            pictureBox2.Location = new Point(0, 0);
            pictureBox3.Location = new Point(0, 0);

            pictureBox1.Margin= new Padding(0);
            pictureBox2.Margin= new Padding(0);
            pictureBox3.Margin = new Padding(0);

            pictureBox1.ClientSize = new Size(Swidth, Sheight);
            pictureBox2.ClientSize = new Size(Swidth, Sheight);
            pictureBox3.ClientSize = new Size(Swidth, Sheight);


            pictureBox2.Parent = pictureBox1;
            pictureBox3.Parent = pictureBox2;

            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox3.BackColor = Color.Transparent;
            camvas = new Bitmap(Swidth, Sheight);
            backCamvas= new Bitmap(Swidth, Sheight);
            pictureBox2.Image = backCamvas;
            pictureBox3.Image= camvas;
            Settings_panel.Parent = pictureBox3;
            Settings_panel.Visible = false;
            Control_button.Parent = pictureBox3;

            panel_values.Parent = pictureBox3;
            panel_values.Visible = false;
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
            
            
        }

        

        private void Button_close_Click(object sender, EventArgs e)
        {
            //Close_Processing();
            //isPixcelLength = true;
            //this.Visible= false;
            this.Close();
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
            if (Settings_panel.Visible)
            {
                Settings_panel.Visible = false;
            }
            this.panel_values.BackColor = Color.FromArgb(224, 224, 224);
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
                        DrawLineClass.DrawMesure(
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
            if (mesures.Count > 0)
            {
                MesureModel.Value_Save();
            }
        }
    }
}
