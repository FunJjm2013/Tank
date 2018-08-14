/*
 * 时间：2013-01-09
 * 作者：杨卫
 * 说明：草类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    class Grass:Module 
    {
        private static Image imgGrass = Resources.grass;
        public Grass(int x, int y)
            : base(x, y, imgGrass.Width, imgGrass.Height)
        { }
        public override void Draw(Graphics g)
        {
            g.DrawImage(imgGrass,X,Y );
        }
    }
}
