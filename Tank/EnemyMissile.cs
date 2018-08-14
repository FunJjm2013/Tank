/*
 * 时间：2012-10-08
 * 创建人：杨卫
 * 说明：敌人的炮弹类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    public class EnemyMissile:Missile 
    {
        public static Image imgEnemyMissile = Resources.enemymissile;
        
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="role">发子弹的角色</param>
        /// <param name="life">子弹的生命</param>
        /// <param name="speed">子弹的速度</param>
        /// <param name="power">子弹的威力</param>
        public EnemyMissile(Roles role,int life,int speed,int power) :base(role,life,imgEnemyMissile.Width,imgEnemyMissile.Height,speed,power )
        { 

        }
        public override void Draw(Graphics g)
        {
            base.Move();
            g.DrawImage(imgEnemyMissile,this.X,this.Y );
        }
    }
}
