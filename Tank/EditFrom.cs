using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tank
{
    public partial class EditFrom : Form
    {
        StartForm startFrm;
        public EditFrom(StartForm frm)
        {
            InitializeComponent();
            this.startFrm = frm;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw | ControlStyles.OptimizedDoubleBuffer, true);
            MessageBox.Show("欢迎使用地图编辑器！\r\t 选择相应的地形，在地图上画出相应的地形，单击右键取消画出的地形元素。", "快刀杨浪");
        }

        private int xPos, yPos;
        public static bool[,] arrWall = new bool[44, 44];
        public static bool[,] strArr = new bool[11, 11];
        public static bool[,] arrSteel = new bool[22, 22];
        private Font font = new Font("Tahoma", 9);
        private SolidBrush sBrush = new SolidBrush(Color.Black);

        private void PanlMap_Paint(object sender, PaintEventArgs e)
        {
            Singleton.Instance.Draw(e.Graphics);
            Singleton.Instance.RemoveImg();
            PanlMap.Invalidate();
            Invalidate();
        }

        private void EditFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            StartForm.editing = false;
            startFrm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            StartForm.isEdit = true;
            startFrm.arr = arrWall;
            this.Close();
        }

        private void EditFrom_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            string str = "X坐标:" + xPos.ToString() + "\n" + "Y坐标:" + yPos.ToString();
            string info = "使用说明：\n 拖拉鼠标画图，\n 右击鼠标删除";
            g.DrawString(info, font, sBrush, 668, 400);
            g.DrawString(str, font, sBrush, 680, 500);
        }

        private void PanlMap_MouseMove(object sender, MouseEventArgs e)
        {
            if (radbtnWall.Checked)
            {
                try
                {
                    xPos = e.X / 15;
                    yPos = e.Y / 15;
                    if (e.Button != MouseButtons.Left)
                    {
                        return;
                    }
                    arrWall[xPos, yPos] = true;
                    Singleton.Instance.AddElement(new Wall(xPos * 15, yPos * 15));
                }
                catch (Exception)
                { }
            }
            if (radbtnGrass.Checked)
            {
                try
                {
                    xPos = e.X / 60;
                    yPos = e.Y / 60;
                    if (e.Button != MouseButtons.Left)
                    {
                        return;
                    }
                    strArr[xPos, yPos] = true;
                    Singleton.Instance.AddElement(new Grass(xPos * 60, yPos * 60));
                }
                catch (Exception)
                { }
            }
            if (radbtnWater.Checked)
            {
                try
                {
                    xPos = e.X / 60;
                    yPos = e.Y / 60;
                    if (e.Button != MouseButtons.Left)
                    {
                        return;
                    }
                    strArr[xPos, yPos] = true;
                    Singleton.Instance.AddElement(new Water(xPos * 60, yPos * 60));
                }
                catch (Exception)
                { }
            }
            if (radbtnSteel.Checked)
            {
                try
                {
                    xPos = e.X / 30;
                    yPos = e.Y / 30;
                    if (e.Button != MouseButtons.Left)
                    {
                        return;
                    }
                    arrSteel[xPos, yPos] = true;
                    Singleton.Instance.AddElement(new Steel(xPos * 30, yPos * 30));
                }
                catch (Exception)
                { }
            }
        }

        private void PanlMap_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            if (radbtnWall.Checked)
            {
                xPos = e.X / 15;
                yPos = e.Y / 15;
                arrWall[xPos, yPos] = !arrWall[xPos, yPos];
            }
            if (radbtnGrass.Checked || radbtnWater.Checked)
            {
                xPos = e.X / 60;
                yPos = e.Y / 60;
                strArr[xPos, yPos] = !strArr[xPos, yPos];
            }
            if (radbtnSteel.Checked)
            {
                xPos = e.X / 30;
                yPos = e.Y / 30;
                arrSteel[xPos, yPos] = !arrSteel[xPos, yPos];
            }
        }

    }
}
