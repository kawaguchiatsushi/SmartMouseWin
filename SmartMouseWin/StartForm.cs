using System.Diagnostics;

namespace SmartMouseWin
{
    public partial class StartForm : Form
    {
        
        public Model model = new Model();
        //public static CreatMesure creatMesure = new CreatMesure();
        MesureForm MesureForm = new MesureForm();

        private bool isStart = false;

        public StartForm()
        {
            InitializeComponent();



            model.notifyIcon.DoubleClick += NotifyIcon_DoubleClick;


        }
        private void NotifyIcon_DoubleClick(object? sender, EventArgs e)
        {
            model.ChangeMode();
            model.ShowMode();
            if(model.mode == Modes.MeasuringMode)
            {
                //mouseHook.Hook();
                if (MesureForm.Visible == false)
                {
                    MesureForm.Visible = true;
                    MesureForm.TopMost = true;
                }

            }
            else if(model.mode == Modes.NomalMode)
            {
                //mouseHook.UnHook();
                if (MesureForm.Visible==true)
                {
                    MesureForm.Visible = false;
                }

            }
        }

        

    }
}