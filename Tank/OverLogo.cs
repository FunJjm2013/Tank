using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    class OverLogo : Element
    {
        private static Image imgOverLogo = Resources.over;
        public OverLogo(int x, int y)
            : base(x, y)
        { }
        public override void Draw(Graphics g)
        {
            g.DrawImage(imgOverLogo, this.X, this.Y);
            if (this.Y > 300)
            {
                this.Y -= 3;
            }
        }
    }
}
