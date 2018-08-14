/*
 * 时间：2012-10-06
 * 创建人：杨卫
 * 说明：玩家的基类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    public abstract class Player : Roles
    {
        private Image[] img = new Image[] { };
        protected bool isMove = false;
        private int live = 2;

        public int Live
        {
            get { return live; }
            set { live = value; }
        }

        private int misLv;

        public int MisLv
        {
            get { return misLv; }
            set { misLv = value; }
        }
        protected bool dirU = false, dirD = false, dirL = false, dirR = false;
        public Player(int x, int y, int life, int speed, directions dir, Image[] img)
            : base(x, y, life, speed, img[0].Width, img[0].Height, dir)
        {
            this.img = img;
            BeBorn();
        }
        public override void AdjustDirection()
        {
            if (dirU && !dirD && !dirL && !dirR)
            {
                dir = directions.U;
            }
            else if (!dirU && dirD && !dirL && !dirR)
            {
                dir = directions.D;
            }
            else if (!dirU && !dirD && dirL && !dirR)
            {
                dir = directions.L;
            }
            else if (!dirU && !dirD && !dirL && dirR)
            {
                dir = directions.R;
            }
        }
        public override void Move()
        {
            if (!isMove)
            {
                return;
            }
            base.Move();
        }
        public override void Draw(Graphics g)
        {
            if (BorTime < 48)  //出生点闪烁时坦克无法显示
            {
                BorTime++;
                return;
            }
            if (live < 0)   //生命小于零则不复活
            {
                return;
            }
            Move();
            switch (dir)
            {
                case directions.U:
                    g.DrawImage(img[0], this.X, this.Y);
                    break;
                case directions.D:
                    g.DrawImage(img[1], this.X, this.Y);
                    break;
                case directions.L:
                    g.DrawImage(img[2], this.X, this.Y);
                    break;
                case directions.R:
                    g.DrawImage(img[3], this.X, this.Y);
                    break;
                default:
                    break;
            }
        }
        public override void Fire()
        {
            if (live>=0)
            {
                //Sounds soundsFire = new Sounds(Resources.fire);
                //soundsFire.Play();
                switch (misLv)
                {
                    case 0:
                        Singleton.Instance.AddElement(new MyMissile(this, 1, 10, 1));
                        break;
                    case 1:
                        Singleton.Instance.AddElement(new MyMissile(this, 1, 20, 1));
                        break;
                    case 2:
                        Singleton.Instance.AddElement(new MyMissile(this, 1, 30, 1));
                        break;
                    default:
                        break;
                }
            }
        }
        public void IsDead()
        {
            if (live == 0)
            {
                //Sounds soundsBlast = new Sounds(Resources.blast);
                //soundsBlast.Play();
                Singleton.Instance.AddElement(new Blast(this.X - 25, this.Y - 25));
                live = -1;
                return;
            }
            if (Life == 0 && live != 0)
            {
                //Sounds soundsBlast = new Sounds(Resources.blast);
                //soundsBlast.Play();
                Singleton.Instance.AddElement(new Blast(this.X - 25, this.Y - 25));
                BeBorn();
                live--;
                if (live > 0)
                {
                    this.Life++;
                }
            }

        }
    }
}
