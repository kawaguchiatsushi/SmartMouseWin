using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartMouseWin
{
    public partial class MagForm : Form
    {
        
        public MagForm()
        {
            InitializeComponent();
            Bitmap magBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Color lineColer = Color.SpringGreen;
            int lineBorder = 1;
            Pen linePen = new Pen(lineColer, lineBorder);
            Graphics g = Graphics.FromImage(magBitmap);
            g.Clear(Color.Transparent);
            g.DrawLine(linePen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
            g.DrawLine(linePen, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            g.Dispose();
            pictureBox1.Image = magBitmap;
        }
    }
}
