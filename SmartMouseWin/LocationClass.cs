using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMouseWin
{
    internal class LocationClass
    {
        public static (int,int) ChangeValuePanelLocation(Point point,int width,int height,Size panelsize)
        {
            bool left = point.X < (width / 2);
            bool up = point.Y < (height/2);
            int margin = 10;
            
            var myPosition = (margin,margin);

            if (!left)
            {
                myPosition.Item1 = -panelsize.Width - margin;
            }
            if(!up)
            {
                myPosition.Item2 = -panelsize.Height -margin;
            }

            return myPosition;
        }

        public static (int, int) ChangeValuePanelLocation(Point point, Size screenSize, Size panelsize)
        {
            var width = screenSize.Width;
            var height = screenSize.Height;
            bool left = point.X < (width / 2);
            bool up = point.Y < (height / 2);
            int margin = 10;

            var myPosition = (margin, margin);

            if (!left)
            {
                myPosition.Item1 = -panelsize.Width - margin;
            }
            if (!up)
            {
                myPosition.Item2 = -panelsize.Height - margin;
            }

            return myPosition;
        }
    }
}
