/*
 * 时间：2013-01-08
 * 作者：杨卫
 * 说明：水类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    class Water:Module 
    {
        private static Image imgWater = Resources.water;
        public Water(int x, int y)
            : base(x, y, imgWater.Width, imgWater.Height)
        { }
        public override void Draw(Graphics g)
        {
            g.DrawImage(imgWater, X, Y);
        }
    }
}
