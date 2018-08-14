/*
 * 时间：2012-10-6
 * 创建人：杨卫
 * 说明：游戏中的角色
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tank
{
    public abstract  class Roles:Member 
    {
        public Roles(int x,int y,int life,int speed,int width,int height,directions dir): base (x,y,life,speed,width,height,dir )
        { }
        private int borTime = 0;

        public int BorTime
        {
            get { return borTime; }
            set { borTime = value; }
        }

        private bool enable = true;

        public bool Enable
        {
            get { return enable; }
            set { enable = value; }
        }

        public override void Move()
        {
            base.AdjustDirection();
            if (this.X > 600) this.X = 600;
            if (this.X < 0) this.X = 0;
            if (this.Y > 600) this.Y = 600;
            if (this.Y < 0) this.Y = 0;
        }
        /// <summary>
        /// 开火方法
        /// </summary>
        public abstract void Fire();
        /// <summary>
        /// 出生方法
        /// </summary>
        public abstract void BeBorn();
    }
}
