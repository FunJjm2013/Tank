using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Tank.Properties;

namespace Tank
{
    class Symbol : Module
    {
        private static Image imgSymbol = Resources.symbol;
        private static Image imgDestory = Resources.destory;
        private static Image imgOver = Resources.over;
        private OverLogo overLogo = new OverLogo(290,615);
        private bool isDistory = false;

        public bool IsDistory
        {
            get { return isDistory; }
            set { isDistory = value; }
        }

        public Symbol(int x, int y)
            : base(x, y, imgSymbol.Width, imgSymbol.Height)
        { }
        public override void Draw(Graphics g)
        {
            if (isDistory)
            {
                g.DrawImage(imgDestory, this.X, this.Y);
                Singleton.Instance.P1Tank.Enable = false;
                Singleton.Instance.P2Tank.Enable = false;
                overLogo.Draw(g);
                return;
            }
            g.DrawImage(imgSymbol, this.X, this.Y);
        }
    }
}
