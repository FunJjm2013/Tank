namespace Tank
{
    partial class EditFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditFrom));
            this.PanlMap = new Tank.GamePanl();
            this.radbtnWall = new System.Windows.Forms.RadioButton();
            this.btnFinish = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.radbtnGrass = new System.Windows.Forms.RadioButton();
            this.radbtnWater = new System.Windows.Forms.RadioButton();
            this.radbtnSteel = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // PanlMap
            // 
            this.PanlMap.BackColor = System.Drawing.Color.Black;
            this.PanlMap.Location = new System.Drawing.Point(0, 0);
            this.PanlMap.Name = "PanlMap";
            this.PanlMap.Size = new System.Drawing.Size(660, 660);
            this.PanlMap.TabIndex = 0;
            this.PanlMap.Paint += new System.Windows.Forms.PaintEventHandler(this.PanlMap_Paint);
            this.PanlMap.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PanlMap_MouseClick);
            this.PanlMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PanlMap_MouseMove);
            // 
            // radbtnWall
            // 
            this.radbtnWall.Image = global::Tank.Properties.Resources.walls;
            this.radbtnWall.Location = new System.Drawing.Point(666, 12);
            this.radbtnWall.Name = "radbtnWall";
            this.radbtnWall.Size = new System.Drawing.Size(95, 88);
            this.radbtnWall.TabIndex = 1;
            this.radbtnWall.TabStop = true;
            this.radbtnWall.Text = "43*43";
            this.radbtnWall.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.radbtnWall.UseVisualStyleBackColor = true;
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(677, 561);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 5;
            this.btnFinish.Text = "完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(677, 612);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // radbtnGrass
            // 
            this.radbtnGrass.Image = global::Tank.Properties.Resources.grass;
            this.radbtnGrass.Location = new System.Drawing.Point(666, 106);
            this.radbtnGrass.Name = "radbtnGrass";
            this.radbtnGrass.Size = new System.Drawing.Size(95, 88);
            this.radbtnGrass.TabIndex = 7;
            this.radbtnGrass.TabStop = true;
            this.radbtnGrass.Text = "10*10";
            this.radbtnGrass.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.radbtnGrass.UseVisualStyleBackColor = true;
            // 
            // radbtnWater
            // 
            this.radbtnWater.Image = global::Tank.Properties.Resources.water;
            this.radbtnWater.Location = new System.Drawing.Point(666, 200);
            this.radbtnWater.Name = "radbtnWater";
            this.radbtnWater.Size = new System.Drawing.Size(95, 88);
            this.radbtnWater.TabIndex = 8;
            this.radbtnWater.TabStop = true;
            this.radbtnWater.Text = "10*10";
            this.radbtnWater.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.radbtnWater.UseVisualStyleBackColor = true;
            // 
            // radbtnSteel
            // 
            this.radbtnSteel.Image = global::Tank.Properties.Resources.steels;
            this.radbtnSteel.Location = new System.Drawing.Point(666, 294);
            this.radbtnSteel.Name = "radbtnSteel";
            this.radbtnSteel.Size = new System.Drawing.Size(95, 88);
            this.radbtnSteel.TabIndex = 9;
            this.radbtnSteel.TabStop = true;
            this.radbtnSteel.Text = "21*21";
            this.radbtnSteel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.radbtnSteel.UseVisualStyleBackColor = true;
            // 
            // EditFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 661);
            this.Controls.Add(this.radbtnSteel);
            this.Controls.Add(this.radbtnWater);
            this.Controls.Add(this.radbtnGrass);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.radbtnWall);
            this.Controls.Add(this.PanlMap);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(780, 700);
            this.MinimumSize = new System.Drawing.Size(780, 700);
            this.Name = "EditFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地图编辑器";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditFrom_FormClosed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EditFrom_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private GamePanl PanlMap;
        private System.Windows.Forms.RadioButton radbtnWall;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton radbtnGrass;
        private System.Windows.Forms.RadioButton radbtnWater;
        private System.Windows.Forms.RadioButton radbtnSteel;
    }
}