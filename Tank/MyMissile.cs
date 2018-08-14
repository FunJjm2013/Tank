/*
 * 时间：2012-10-09
 * 创建人：杨卫
 * 说明：玩家炮弹类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    public class MyMissile:Missile 
    {
        public static Image imgMyMissile = Resources.tankmissile;
        public MyMissile(Roles role,int life,int speed,int power) :base(role,life,imgMyMissile.Width,imgMyMissile.Height,speed,power )
        { 

        }
        public override void Draw(Graphics g)
        {
            base.Move();
            g.DrawImage(imgMyMissile,this.X,this.Y );
        }
    }
}
