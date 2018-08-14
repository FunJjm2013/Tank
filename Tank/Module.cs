/*
 * 时间：2012-10-09 *：45
 * 创建人：杨卫
 * 说明：坦克装备的模型类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tank
{
    public abstract  class Module:Element 
    {
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
        public Module(int x,int y,int width,int height)
            : base(x,y)
        {
            this.width = width;
            this.height = height;
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X,this.Y,this.width,this.height );
        }
    }
}
