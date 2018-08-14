/*
 * 时间：2012-10-08
 * 创建人：杨卫
 * 说明：敌人和玩家的炮弹的基类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tank
{
    public abstract class Missile:Member 
    {
        public int power;
        public Missile(Roles role, int life, int width, int height, int speed, int power)
            : base(role.X+role.Width/2-6,role.Y+role.Height/2-6,life,speed,width,height,role.dir)
        {
            this.power = power;
        }
        public override void Move()
        {
            if (this.X<0|| this.X>660||this.Y<0||this.Y>660)
            {
                this.Life = 0;
            }
            AdjustDirection();
        }
    }
}
