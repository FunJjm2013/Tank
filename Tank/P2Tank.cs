/*
 * 时间：2012-10-11 21：16
 * 创建人：杨卫
 * 说明：玩家2的坦克类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;
using System.Windows.Forms;
using System.Media;

namespace Tank
{
    public class P2Tank : Player
    {
        private static Image[] imgTank2 = new Image[]
        {
            Resources.p2tankU,
            Resources.p2tankD,
            Resources.p2tankL,
            Resources.p2tankR
        };

        public P2Tank(int x, int y, int speed, int life,directions dir)
            : base(x, y,life,  speed,dir,imgTank2)
        {
        }

        public void KeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up: 
                    dirU = true;
                    break;
                case Keys.Down:
                    dirD = true;
                    break;
                case Keys.Left: 
                    dirL = true;
                    break;
                case Keys.Right: 
                    dirR = true;
                    break;
                default: break;
            }
            if (e.KeyCode == Keys.Up | e.KeyCode == Keys.Down | e.KeyCode == Keys.Left | e.KeyCode == Keys.Right)
            {
                isMove = true;
            }
            AdjustDirection();
        }
        public void KeyUp(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    dirU = false;
                    break;
                case Keys.Down:
                    dirD = false;
                    break;
                case Keys.Left:
                    dirL = false;
                    break;
                case Keys.Right:
                    dirR = false;
                    break;
                case Keys.NumPad2:
                    Fire();
                    break;
                default: break;
            }
            isMove = false;
            AdjustDirection();
        }
        public override void BeBorn()
        {
            this.X = 400;
            this.Y = 600;
            Singleton.Instance.AddElement(new Born(this.X, this.Y));
        }
    }
}
