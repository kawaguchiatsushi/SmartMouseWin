using System.Diagnostics;

namespace SmartMouseWin
{
    public partial class MesureForm : Form
    {
        /// <summary>
        /// Screen Size
        /// </summary>
        public static readonly int Swidth = Screen.PrimaryScreen.Bounds.Width;
        public static readonly int Sheight = Screen.PrimaryScreen.Bounds.Height;
        public static readonly Size S_Size = Screen.PrimaryScreen.Bounds.Size;

        /// <summary>
        /// private settings
        /// </summary>
        private Point zeroPoint = new(0,0);
        private Padding zeroPadding = new(0);
        private readonly string pixModeName = "ピクセル距離";
        private readonly string cmModeName = "㎝モード";

        bool isPixcelLength = true;
        bool isButtonCloseMove = false;
        bool isMesure = true;

        Bitmap camvas, captureBitmap, backCamvas;       

        LinkedList<Point> myPoints = new();
        LinkedList<Point> pixcelLengths = new ();
        
        PixcelLengthModel? MyPixcelLength;
        LinkedList<MesureModel> mesures= new LinkedList<MesureModel>();

        /// <summary>
        /// for magnification
        /// </summary>
        Form magform;
        Magnifier magnifier;

        /// <summary>
        /// Class for drawing lines
        /// </summary>
        DrawLineClass drawLine = new();

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
            this.TransparencyKey = this.BackColor;
            this.panel_values.BackColor= Color.Transparent;
            captureBitmap = new Bitmap(Swidth, Sheight);
            Graphics g = Graphics.FromImage(captureBitmap);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), captureBitmap.Size);
            g.Dispose();
            pictureBox1.Image= captureBitmap;
            this.Opacity = 1.0;
            this.TransparencyKey = Color.Empty;
            button_close.Visible = true;

            Magform();
        }

        /// <summary>
        /// Form for magnification
        /// </summary>
        private void Magform()
        {
            Size magformSize = new(100, 100);
            this.magform = new Form();

            this.magnifier = new Magnifier(this.magform);

            this.magform.FormBorderStyle = FormBorderStyle.None;
            this.magform.Size = magformSize;

            this.magform.Location = new Point(
                this.Control_button.Location.X + this.Control_button.Width + 20,
                this.Control_button.Location.Y);

            this.magform.TopMost = true;
            this.magform.Visible = true;
            this.Color_button.BackColor = Color.SpringGreen;
        }


        private void Button_close_Click(object sender, EventArgs e)
        {
            StartForm.model.ChangeMode();
            StartForm.model.ShowMode();
            this.Close();
            this.magform.Close();
        }

        private void Button_close_MouseDown(object sender, MouseEventArgs e)
        {
            isButtonCloseMove=true;
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
            
            if (button_mode.Text == pixModeName)
            {
                if (MyPixcelLength!=null)
                {
                    button_mode.Text = cmModeName;
                    this.isPixcelLength = false;
                }
            }
            else if (button_mode.Text == cmModeName)
            {
                button_mode.Text = pixModeName;
                foreach (var mesure in mesures)
                {
                    mesure.panel_value.Dispose();
                }
                mesures.Clear();
                MyPixcelLength = null;
                Close_Processing();
                isPixcelLength = !isPixcelLength;
            }

        }

        private void PictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button== MouseButtons.Left)
            {
                magform.Visible = true;

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
                            button_mode.Text = cmModeName;

                        }
                        pictureBox3.Refresh();
                        return;

                    }

                    if (myPoints.Count == 2)
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
                        DrawLineClass.ClearMesure(ref camvas, pictureBox3);
                        panel_values.Visible = false;

                        if (mesures.Count > 0)
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
            else if(e.Button== MouseButtons.Right)
            {
                if(mesures.Count > 0)
                {
                    if (MyPixcelLength == null)
                    {
                        return;
                    }
                    (mesures.Last().Start,mesures.Last().End) =(mesures.Last().End,mesures.Last().Start);
                    DrawLineClass.ClearMesure(ref backCamvas, pictureBox2);
                    DrawLineClass.DrawMesure_D(
                            ref backCamvas,
                            pictureBox2,
                            pictureBox3,
                            mesures,
                            MyPixcelLength
                            );

                }
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
                    DrawLineClass.DrawMesure_D(
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


        /// <summary>
        /// Deleting lines and other information when closing a form.
        /// </summary>
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

        private void Help_button_Click(object sender, EventArgs e)
        {
            string helpstr = "①まずメジャーなどの写真から10㎝の画面上の長さを左クリックを2回で計測\n\r" +
                "②次に、左クリックで計測したい長さを測る。\n\r" +
                "③右クリックで、寸法線の描画向きを変更できる。\n\r" +
                "・設定画面から保存するとテキストクリップボードに計測寸法が記録される。";
            MessageBox.Show(helpstr,"説明",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (mesures.Count > 0)
                {
                    string clipBoardText = string.Empty;
                    for (int i = 0; i < mesures.Count; i++)
                    {
                        clipBoardText += String.Format
                            (
                               "{0}:{1}  ",
                               (i + 1).ToString(),
                                mesures.ElementAt(i).CentimeterStr
                            );
                    }

                    Clipboard.SetText(clipBoardText);
                    string message = String.Format
                            (
                                "{0}個の長さがクリップボードに保存されました。", mesures.Count.ToString()
                            );
                    MessageBox.Show(message, "長さの保存");

                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return;
            }


        }

        /// <summary>
        /// Select a color from the color palette to change the line color.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Color_button_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new()
            {
                Color = Dimension.LineColor,
                AllowFullOpen = true,
                SolidColorOnly = false,
                CustomColors = new int[] {
                0x33, 0x66, 0x99, 0xCC, 0x3300, 0x3333,
                0x3366, 0x3399, 0x33CC, 0x6600, 0x6633,
                0x6666, 0x6699, 0x66CC, 0x9900, 0x9933}
            };
            if (cd.ShowDialog() == DialogResult.OK)            
                Dimension.LineColor = Color_button.BackColor = cd.Color;
        }
    }
}
