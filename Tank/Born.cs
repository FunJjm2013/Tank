/*
 * 时间：2012-10-08 22：29
 * 创建人：杨卫
 * 说明：born类，坦克产生时的闪烁
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    class Born:Element 
    {
        private int bornTimer = 0;
        private static Image[] imgBorn = new Image[] 
        {
            Resources.born1,
            Resources.born2,
            Resources.born3,
            Resources.born4
        };
        public Born(int x, int y)
            : base(x, y)
        { }
        public override void Draw(Graphics g)
        {
            if (bornTimer<48)
            {
                switch (bornTimer%8)
                {
                    case 0:
                    case 1:
                        g.DrawImage(imgBorn[0],this.X,this.Y );
                        break;
                    case 2:
                    case 3:
                        g.DrawImage(imgBorn[0], this.X, this.Y);
                        break;
                    case 4:
                    case 5:
                        break;
                    case 6:
                    case 7:
                        g.DrawImage(imgBorn[0], this.X, this.Y);
                        break;
                    default:
                        break;
                }
                bornTimer++;
            }
        } 
    }
}
