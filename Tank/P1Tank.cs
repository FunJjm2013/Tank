/*
 * 时间：2012-10-06
 * 创建人：杨卫
 * 说明：玩家1坦克类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Tank.Properties;

namespace Tank
{
    public class P1Tank : Player
    {
        private static Image[] imgTank1 = new Image[]
        {
            Resources.p1tankU,
            Resources.p1tankD,
            Resources.p1tankL,
            Resources.p1tankR,
        };

        public P1Tank(int x, int y, int speed, int life, directions dir)
            : base(x, y, life, speed, dir, imgTank1)
        {
        }

        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    dirU = true;
                    break;
                case Keys.S:
                    dirD = true;
                    break;
                case Keys.A:
                    dirL = true;
                    break;
                case Keys.D:
                    dirR = true;
                    break;
                default:
                    break;
            }
            if (e.KeyCode==Keys.W || e.KeyCode==Keys.S || e.KeyCode==Keys.A || e.KeyCode==Keys.D)
            {
                isMove = true;
            }
            AdjustDirection();
        }

        public void KeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    dirU = false;
                    break;
                case Keys.S:
                    dirD = false;
                    break;
                case Keys.A:
                    dirL = false;
                    break;
                case Keys.D:
                    dirR = false;
                    break;
                case Keys.K:
                    Fire();
                    break;
                default:
                    break;
            }
            isMove = false;
            AdjustDirection();
        }
        public override void BeBorn()
        {
            this.X = 200;
            this.Y = 600;
            Singleton.Instance.AddElement(new Born(this.X,this.Y ));
        }
    }
}
