/*
 * 时间：2012-10-08
 * 创建人：杨卫
 * 说明：敌人的类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    public class Enemy:Roles 
    {
        private static Image[] imgEnemy1 = new Image[]
        {
            Resources.enemy1U,
            Resources.enemy1D,
            Resources.enemy1L,
            Resources.enemy1R,
        };
        private static Image[] imgEnemy2 = new Image[]
        {
            Resources.enemy2U,
            Resources.enemy2D,
            Resources.enemy2L,
            Resources.enemy2R,
        };
        private static Image[] imgEnemy3 = new Image[]
        {
            Resources.enemy3U,
            Resources.enemy3D,
            Resources.enemy3L,
            Resources.enemy3R,
        };

        private Random rdm = new Random();
        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

        private static int speed;
        private static int life;
        private int timer = 0;

        public int Timer
        {
            get { return timer; }
            set { timer = value; }
        }

        

        private static int SetSpeed(int type)
        {
            switch (type)
            {
                case 0:
                    speed = 2;
                    break;
                case 1:
                    speed = 3;
                    break;
                case 2:
                    speed = 1;
                    break;
                default:
                    break;
            }
            return speed;
        }
        private static int SetLife(int type)
        {
            switch (type )
            {
                case 0:
                    life = 1;
                    break;
                case 1:
                    life = 2;
                    break;
                case 2:
                    life = 4;
                    break;
                default:
                    break;
            }
            return life;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x">敌人的x座标</param>
        /// <param name="y">敌人的y座标</param>
        /// <param name="life">敌人的生命</param>
        /// <param name="speed">敌人的速度</param>
        /// <param name="dir">敌人的方向</param>
        public Enemy(int x, int y, int type, directions dir)
            : base(x,y,SetLife(type),SetSpeed(type) ,imgEnemy1[0].Width,imgEnemy1[0].Height,dir)
        {
            this.type = type;
            BeBorn();
        }

        public void EnemyAI()
        {
            if (rdm.Next(0,100)<2)
            {
                switch(rdm.Next(0,4))
                {
                    case 0:
                        dir = directions.U;
                        break;
                    case 1:
                        dir = directions.D;
                        break;
                    case 2:
                        dir = directions.L;
                        break;
                    case 3:
                        dir = directions.R;
                        break;
                    default: break;
                }
            }
        }

        /// <summary>
        /// 敌人的移动方法
        /// </summary>
        public override void Move()
        {
            if (!Enable )
            {
                return;
            }
            EnemyAI();
            AdjustDirection();
            if (this.X<0 || this.X>600|| this.Y<0 || this.Y>600)
            {
                switch (rdm.Next(0,4))
                {
                    case 0:
                        dir = directions.U;
                        break;
                    case 1:
                        dir = directions.D;
                        break;
                    case 2:
                        dir = directions.L;
                        break;
                    case 3:
                        dir = directions.R;
                        break;
                    default:
                        break;
                }
                base.Move();
            }
        }
        /// <summary>
        /// 画出敌人
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            if (BorTime<48)
            {
                BorTime++;
                return;
            }
            if (!Enable)
            {
                timer++;
                if (timer == 150)
                {
                    Enable = true;
                }
                if (timer % 10 == 0)
                {
                    return;
                }
            }
            Move();
            switch (type )
            {
                case 0:
                    switch (dir)
	               {
                       case directions.U:
                           g.DrawImage(imgEnemy1[0],this.X,this.Y );
                           break;
                       case directions.D:
                           g.DrawImage(imgEnemy1[1], this.X, this.Y);
                           break;
                       case directions.L:
                           g.DrawImage(imgEnemy1[2], this.X, this.Y);
                           break;
                       case directions.R:
                           g.DrawImage(imgEnemy1[3], this.X, this.Y);
                           break;
                       default:
                           break;
	                }
                    break;
                case 1:
                    switch (dir)
                    {
                        case directions.U:
                            g.DrawImage(imgEnemy2[0], this.X, this.Y);
                            break;
                        case directions.D:
                            g.DrawImage(imgEnemy2[1], this.X, this.Y);
                            break;
                        case directions.L:
                            g.DrawImage(imgEnemy2[2], this.X, this.Y);
                            break;
                        case directions.R:
                            g.DrawImage(imgEnemy2[3], this.X, this.Y);
                            break;
                        default:
                            break;
                    }
                    break;
                case 2:
                    switch (dir)
                    {
                        case directions.U:
                            g.DrawImage(imgEnemy3[0], this.X, this.Y);
                            break;
                        case directions.D:
                            g.DrawImage(imgEnemy3[1], this.X, this.Y);
                            break;
                        case directions.L:
                            g.DrawImage(imgEnemy3[2], this.X, this.Y);
                            break;
                        case directions.R:
                            g.DrawImage(imgEnemy3[3], this.X, this.Y);
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    break;
            }
            if (rdm.Next(0,100)<1)
            {
                Fire();
            }
        }
        public override void Fire()
        {
            if (!Enable)
            {
                return;
            }
            Singleton.Instance.AddElement(new EnemyMissile(this,1,15,1));
        }
        public void IsDead()
        {
            if (this.Life == 0)
            {
                //Sounds soundsBlast = new Sounds(Resources.blast);
                //soundsBlast.Play();
                Singleton.Instance.AddElement(new Blast(this.X - 25, this.Y - 25));
                Singleton.Instance.RemoveElement(this);
                Singleton.Instance.AddElement(new Equipment(rdm.Next(0, 640), rdm.Next(0, 640), rdm.Next(0, 5)));
            }
        }
        public override void BeBorn()
        {
            Singleton.Instance.AddElement(new Born(this.X,this.Y ));
        }
    }
}
