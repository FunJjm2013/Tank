/*
 * 时间：2012-10-09 12：35
 * 创建人：杨卫
 * 说明：坦克的装备类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    class Equiment:Module 
    {
        private static Image imgStar = Resources.star;
        private static Image imgBomb = Resources.bomb;
        private static Image imgTimer = Resources.timer;
        private int flag;

        public int Flag
        {
            get { return flag; }
            set { flag = value; }
        }

        public Equiment(int x,int y,int flag)
            : base(x,y,imgStar.Width,imgStar.Height)
        { }
        public override void Draw(Graphics g)
        {
            switch (flag)
            {
                case 0:

                    break;
                default:
                    break;
            }
        }
        
    }
}
