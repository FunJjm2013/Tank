/*
 * 时间：2012-10-06
 * 创建人：杨卫
 * 说明：元素基类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Tank
{
    public abstract class Element
    {
        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
        private int y;

        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public Element(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public abstract void Draw(Graphics g);
    }
}
