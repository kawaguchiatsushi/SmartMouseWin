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
            int margin = 10;

            int myNum = 2;

            bool right = point.X > (width - (panelsize.Width+margin));

            bool left = point.X < (panelsize.Width + margin);

            bool up = point.Y < (panelsize.Height+margin);

            bool down = point.Y > (height - (panelsize.Height + margin));

            bool isAboveCenter = point.Y < (height/myNum);

            bool isLeftofCenter = point.X < (width/myNum);


            var myPosition = (margin,margin);
            if (isAboveCenter)
            {
                myPosition.Item2 = - panelsize.Height - margin;
            }
           
            if (isLeftofCenter)
            {
                myPosition.Item1 = - panelsize.Width - margin;
            }
            

            if (right)
            {
                myPosition.Item1 = - panelsize.Width - margin;
            }
            if (left)
            {
                myPosition.Item1 =  margin;
            }
            if (up)
            {
                myPosition.Item2 =  margin;
            }
            if (down)
            {
                myPosition.Item2 = - panelsize.Height - margin;
            }

            return myPosition;
        }

        public static (int, int) ChangeValuePanelLocation(Point point, Size screenSize, Size panelsize)
            => ChangeValuePanelLocation(point, screenSize.Width, screenSize.Height, panelsize);

        public static (int, int) ChangeValuePanelLocation(Point point, Size screenSize, int panelwidth,int panelheight)
            => ChangeValuePanelLocation(point, screenSize.Width, screenSize.Height, new Size(panelwidth,panelheight));


    }
}
