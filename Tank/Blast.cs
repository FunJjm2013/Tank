/*
 * 时间：2012-10-08 
 * 创建人：杨卫
 * 说明：Blast类，坦克被击毁瞬间特效
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    class Blast : Element
    {
        private int count = 0;
        private static Image[] imgBlast = new Image[] //申明效果图片
        {
             Resources.blast1,
             Resources.blast2,
             Resources.blast3,
             Resources.blast4,
             Resources.blast5,
             Resources.blast6,
             Resources.blast7,
             Resources.blast8
        };
        public Blast(int x, int y)  //构造函数
            : base(x,y)
        { }
        public override void Draw(Graphics g)  //重写父类的Draw方法
        {
            if (count<imgBlast.Length )
            {
                g.DrawImage(imgBlast[count],this.X ,this.Y  );
                count++;
            }
            else
            {
                Singleton.Instance.RemoveElement(this);
            }
        }
    }
}
