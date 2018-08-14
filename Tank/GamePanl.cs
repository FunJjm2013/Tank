using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Tank
{
    class GamePanl:Panel
    {
        public GamePanl()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw| ControlStyles.AllPaintingInWmPaint,true  );
        }
    }
}
