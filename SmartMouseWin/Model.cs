using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartMouseWin
{
    public enum Modes
    {
        NomalMode,
        MeasuringMode,
       
    }

    public class Modeproperty
    {
        public string ModeName;

        public string IconName;

        public Modeproperty(String modename, string iconName)
        {
            this.ModeName = modename;
            this.IconName = iconName;
        }
    }
    


    /// <summary>
    /// Variables for Settings
    /// </summary>
    public class Model
    {
        private static String SetIconName(String iconname)
        {
            return String.Format(
                @"{0}\icons\{1}.ico",
                Directory.GetCurrentDirectory(),
                iconname
                );
        }
        private static void CreateDir(String folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

        }

        

        public static readonly string mesuringMode_Name = "測定モード";
        
        public static readonly string mesuringMode_Icon = SetIconName("meruring");

        public static readonly string nomalMode_Name = "ノーマルモード";

        public static readonly string nomalMode_Icon = SetIconName("nomal");

        private readonly string balloonTipTitle = "モード変更";

        private readonly string setBalloonTipText_ChangeMode = "モードが{0}から{1}に変更されました。";

        private string previousMode_Name;

        private int modescount = Enum.GetValues(typeof(Modes)).Length;

        Modeproperty Mode_Property;

        public List<Modeproperty> modeproperties = new();

        Modeproperty MP_meuring = new Modeproperty(mesuringMode_Name,mesuringMode_Icon);
        Modeproperty MP_nomal = new Modeproperty(nomalMode_Name,nomalMode_Icon);
        


        public NotifyIcon notifyIcon;
        public Modes mode;

        public Model()
        {
            ///start nomalmode, nothig
            ///
            this.modeproperties.AddRange(
                new Modeproperty[]
                {
                    MP_nomal, MP_meuring
                });
            this.Mode_Property =  this.modeproperties[0];
            this.notifyIcon = new NotifyIcon
            {
                Icon = new Icon(this.Mode_Property.IconName),
                Visible = true,
                Text = this.Mode_Property.ModeName
            };
            this.previousMode_Name = this.Mode_Property.ModeName;
            this.mode = new Modes();
            this.mode = Modes.NomalMode;

            
        }
       

        /// <summary>
        /// Function to change mode in turn
        /// </summary>
        public void ChangeMode()
        {
            
            if ((int)this.mode == modescount-1)
            {
                this.mode = (Modes)0;
                this.previousMode_Name = this.Mode_Property.ModeName;
                this.Mode_Property = modeproperties[(int)this.mode];
            }
            else
            {
                this.mode = (Modes)this.mode + 1;
                this.previousMode_Name = this.Mode_Property.ModeName;
                this.Mode_Property = modeproperties[(int)this.mode];
            }
            
        }

        public void ShowMode()
        {
            if (this.notifyIcon != null)
            {
                this.notifyIcon.Text = this.Mode_Property.ModeName;
                this.notifyIcon.Icon.Dispose();
                this.notifyIcon.Icon = new Icon(this.Mode_Property.IconName);

                this.notifyIcon.BalloonTipTitle = balloonTipTitle;
                this.notifyIcon.BalloonTipText = 
                    String.Format
                    (
                        this.setBalloonTipText_ChangeMode,
                        this.previousMode_Name,
                        this.Mode_Property.ModeName
                    );
                this.notifyIcon.ShowBalloonTip(3000);
            }

        }


    }


}
