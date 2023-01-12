using System.Diagnostics;

namespace SmartMouseWin
{
    public partial class StartForm : Form
    {
        public static Model model = new();
        private MesureForm MesureForm = new();

        //private static bool isMesureFormVisible=false;
        //public static bool IsMesureFormVisible 
        //{
        //    get
        //    {
        //        return (isMesureFormVisible);
        //    }
        //    set
        //    { 
        //        isMesureFormVisible = value;
        //        if (isMesureFormVisible==false)
        //        {
        //            model.ChangeMode();
        //        }
        //    }
        //}

        public StartForm()
        {
            InitializeComponent();

            ContextMenuStrip contextMenuStrip = new();
            ToolStripMenuItem toolStripMenuItem_close = new()
            {
                Text = "&èIóπ"
            };
            contextMenuStrip.Items.Add(toolStripMenuItem_close);
            model.notifyIcon.ContextMenuStrip = contextMenuStrip;
            toolStripMenuItem_close.Click += ToolStripMenuItem_close_Click;
            model.notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
        }

        /// <summary>
        /// App Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_close_Click(object? sender, EventArgs e)
        {
            model.notifyIcon.Visible = false;
            model.notifyIcon.Icon.Dispose();
            model.notifyIcon.Icon = null;
            Application.Exit();
        }       

        /// <summary>
        /// open mesureform
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NotifyIcon_DoubleClick(object? sender, EventArgs e)
        {
            MouseEventArgs me =(MouseEventArgs)e;
            if (me.Button == MouseButtons.Left)
            {
                model.ChangeMode();
                model.ShowMode();
                if (model.mode == Modes.MeasuringMode)
                {
                    if (MesureForm.IsDisposed)
                    {
                        MesureForm = new();
                    }
                    MesureForm.Visible = true;
                    MesureForm.TopMost = true;
                }
                else if (model.mode == Modes.NomalMode)                
                    MesureForm.Visible = false;
            }   
        }
    }
}