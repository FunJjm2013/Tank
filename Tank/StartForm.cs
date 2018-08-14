/*
 * 时间：2012-10-11 19：44
 * 创建人:杨卫
 * 说明：游戏开始窗体
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;
using Tank.Properties;


namespace Tank
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);

            #region 皮肤设置
            //this.skinEngine1.SkinFile = "../theme/WaveColor1.ssk";
            //if (string.IsNullOrEmpty(this.skinEngine1.SkinFile) || !System.IO.File.Exists(skinEngine1.SkinFile))
            //{
            //    this.skinEngine1.Active = false; // 设置不加载皮肤
            //    this.skinEngine1.SkinAllForm = true; // 设置皮肤只在主窗体显示，不加载于其他所有的窗体
            //}
            #endregion

        }
        private static Image imgTitle = Resources.title;
        private static Image imgSelect = Resources.select;
        private static Image imgTank = Resources.selecttank;
        public static bool isMultiplayer;
        public static bool isEdit = false;
        public static bool editing = false;
        public bool[,] arr = new bool[43, 43];
        private Graphics g = null;
        private int xPos = 220, yPos = 290;
        private int roll = 500;

        private static volatile StartForm instance;

        public static StartForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StartForm();
                }
                return instance;
            }
        }
        private void RollThread()
        {
            if (roll > 0)
            {
                roll -= 3;
                Thread.Sleep(10);
            }
            else
            {
                return;
            }
            Invalidate();
        }

        private void StartForm_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(imgTitle, 80, 50 + roll);
            g.DrawImage(imgSelect, 320, 305 + roll);
            g.DrawImage(imgTank, xPos, yPos + roll);
            if (roll < 0)
            {
                g.DrawString("快刀杨浪 @ 2012", new Font("Tahoma", 15, FontStyle.Bold), new SolidBrush(Color.White), 385, 500);
                btnState.Visible = true;
                btnPoint.Visible = true;
            }
            RollThread();
        }

        private void StartForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.X > 320 && e.X < 320 + imgSelect.Width && e.Y > 300 && e.Y < 330)
            {
                yPos = 290;
                Invalidate();
            }
            if (e.X > 320 && e.X < 320 + imgSelect.Width && e.Y > 370 && e.Y < 400)
            {
                yPos = 360;
                Invalidate();
            }
            if (e.X > 320 && e.X < 320 + imgSelect.Width && e.Y > 430 && e.Y < 460)
            {
                yPos = 430;
                Invalidate();
            }
        }

        private void StartForm_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.X > 320 && e.X < 320 + imgSelect.Width && e.Y > 300 && e.Y < 330) || (e.X > 320 && e.X < 320 + imgSelect.Width && e.Y > 370 && e.Y < 400) || (e.X > 320 && e.X < 320 + imgSelect.Width && e.Y > 430 && e.Y < 460))
            {
                Start();
            }
        }

        private void Start()
        {
            if (yPos == 290)
            {
                isMultiplayer = false;
            }
            else if (yPos == 360)
            {
                isMultiplayer = true;
            }
            else if (yPos == 430)
            {
                EditFrom editFrm = new EditFrom(this);
                StartForm.editing = true;
                this.Hide();
                editFrm.ShowDialog();
                return;
            }
            this.Hide();
            //Sounds soundStart = new Sounds(Resources.start);
            //soundStart.Play();
            MainForm frm = new MainForm();
            frm.ShowDialog();
        }

        private void btnState_Click(object sender, EventArgs e)
        {
            MessageBox.Show("游戏说明:\r    玩家1:WASD上左下右,K键发子弹.\r    玩家2:方向键上下左右,小键盘2发子弹.\r\t  游戏快乐!  \r\t\t\t 快刀杨浪");
        }

        private void StartForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnBug_Click(object sender, EventArgs e)
        {
            MessageBox.Show("温馨提示：\r请勿沉迷于游戏！！\r\t 快刀杨浪");
        }

        private void StartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.W | e.KeyCode == Keys.Up) && yPos > 290)
            {
                yPos -= 70;
            }
            if ((e.KeyCode == Keys.S | e.KeyCode == Keys.Down) && yPos < 430)
            {
                yPos += 70;
            }

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                Start();
            }
            Invalidate();
        }

    }
}
