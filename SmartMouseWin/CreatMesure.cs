using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMouseWin
{
    public enum MouseState
    {
        RUp, RDown,LUp,LDown,Move
    }
    public class SendState
    {
        public Point Point;
        public MouseState MouseState;
    }
    public class CreatMesure
    {

        public Form transparentForm;
        readonly PictureBox PictureBox = new PictureBox();
        public CreatMesure() 
        {
            transparentForm = new Form
            {
                BackColor = Color.White,
                
            };
            
            this.transparentForm.Load += TransparentForm_Load;
            SetPictureBox();

            
            

        }

        private void SetPictureBox()
        {
            PictureBox.Parent = transparentForm;
            PictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            PictureBox.Width = transparentForm.Width;
            PictureBox.Height = transparentForm.Height;
            PictureBox.Location = new Point(0, 0);

            Bitmap bitmap = new Bitmap(
                    PictureBox.Width,
                    PictureBox.Height,
                    System.Drawing.Imaging.PixelFormat.Format32bppPArgb
                    );
            Graphics g = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Red, 2);
            g.DrawLine(pen, 0, 0, 100, 200);
            PictureBox.Image = bitmap;
        }

        

        public static SendState sendState = new SendState();
        //public SendState SendStates
        //{
        //    get { return sendState; }
        //    set
        //    { 
        //        sendState = value;
        //        Debug.WriteLine("Senddata");
        //        if (sendState != null)
        //        {
        //            if(sendState.MouseState==MouseState.LDown)
        //            {
        //                Debug.WriteLine("rdown");
        //                this.transparentForm.Visible= true;
        //                this.transparentForm.Show();
        //            }
        //            else if(sendState.MouseState== MouseState.Move)
        //            {
        //                Debug.WriteLine("Move");
        //            }
        //            else if(sendState.MouseState== MouseState.LUp)
        //            {
        //                Debug.WriteLine("RUp");
        //                //this.transparentForm.Visible = false;
        //            }
        //        }
        //    }
        //}


        private void TransparentForm_Load(object? sender,EventArgs e)
        {
            var F = this.transparentForm;
            if (transparentForm != null)
            {
                //F.TransparencyKey = F.BackColor;
                F.StartPosition = FormStartPosition.Manual;
                F.Location= new Point(0, 0);
                //F.FormBorderStyle= FormBorderStyle.None;
                F.WindowState = FormWindowState.Minimized;
                F.TopMost= true;
                F.Show();
                
            }
        }
    }
}
