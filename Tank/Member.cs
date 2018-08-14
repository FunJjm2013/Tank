/*
 * 时间：2012-10-06
 * 创建人：杨卫
 * 说明：游戏成员的基类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tank
{
    public abstract  class Member:Element 
    {
        public directions dir;

        public directions Dir
        {
            get { return dir; }
            set { dir = value; }
        }
        private int life;

        public int Life
        {
            get { return life; }
            set { life = value; }
        }
        private int speed;

        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private int width;

        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        private int height;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x">对象的x座标</param>
        /// <param name="y">对象的y座标</param>
        /// <param name="life">对象的生命</param>
        /// <param name="speed">对象的速度</param>
        /// <param name="width">对象的长</param>
        /// <param name="height">对象的宽</param>
        /// <param name="dir">对象的方向</param>
        public Member(int x,int y,int life,int speed,int width,int height,directions dir):base(x,y )
        {
            this.dir = dir;
            this.life = life;
            this.speed = speed;
            this.width = width;
            this.height = height;
        }

        public abstract void Move();
        /// <summary>
        /// 获取对象的大小
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X,this.Y,Width,Height );
        }
        /// <summary>
        /// 调整对象的方向
        /// </summary>
        public virtual void AdjustDirection()
        {
            switch (dir)
            {
                case directions.U:
                    this.Y -= speed;
                    break;
                case directions.D:
                    this.Y += speed;
                    break;
                case directions.L:
                    this.X -= speed;
                    break;
                case directions.R:
                    this.X += speed;
                    break;
                default:
                    break;
            }
        }
    }
}
