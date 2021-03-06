﻿/*
 * 时间：2013-01-08
 * 作者：杨卫
 * 说明：墙类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    class Wall:Module 
    {
        private static Image imgWall = Resources.wall;
        public Wall(int x, int y)
            : base(x, y, imgWall.Width, imgWall.Height)
        { }
        public override void Draw(Graphics g)
        {
            g.DrawImage(imgWall,X,Y );
        }
    }
}
