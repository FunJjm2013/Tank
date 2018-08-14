/*
 * 时间：2013-01-09
 * 作者：杨卫
 * 说明：铁墙类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    class Steel:Module 
    {
        private static Image imgSteel = Resources.steel;
        public Steel(int x, int y)
            : base(x, y, imgSteel.Width, imgSteel.Height)
        { }
        public override void Draw(Graphics g)
        {
            g.DrawImage(imgSteel,X,Y);
        }
    }
}
