namespace MineSweeper
{
    partial class MineSweeper
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btNewGame = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.plGame = new System.Windows.Forms.Panel();
            this.lbTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTime = new System.Windows.Forms.TextBox();
            this.tbMines = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btNewGame
            // 
            this.btNewGame.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btNewGame.Location = new System.Drawing.Point(12, 17);
            this.btNewGame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btNewGame.Name = "btNewGame";
            this.btNewGame.Size = new System.Drawing.Size(80, 25);
            this.btNewGame.TabIndex = 0;
            this.btNewGame.Tag = "1";
            this.btNewGame.Text = "New Game";
            this.btNewGame.UseVisualStyleBackColor = true;
            this.btNewGame.Click += new System.EventHandler(this.btNewGame_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(98, 17);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // plGame
            // 
            this.plGame.Location = new System.Drawing.Point(12, 50);
            this.plGame.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.plGame.Name = "plGame";
            this.plGame.Size = new System.Drawing.Size(375, 250);
            this.plGame.TabIndex = 1;
            // 
            // lbTime
            // 
            this.lbTime.AutoSize = true;
            this.lbTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbTime.Location = new System.Drawing.Point(289, 21);
            this.lbTime.Name = "lbTime";
            this.lbTime.Size = new System.Drawing.Size(39, 17);
            this.lbTime.TabIndex = 2;
            this.lbTime.Text = "Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(181, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mines:";
            // 
            // tbTime
            // 
            this.tbTime.Enabled = false;
            this.tbTime.Location = new System.Drawing.Point(334, 18);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(50, 23);
            this.tbTime.TabIndex = 3;
            // 
            // tbMines
            // 
            this.tbMines.Enabled = false;
            this.tbMines.Location = new System.Drawing.Point(233, 18);
            this.tbMines.Name = "tbMines";
            this.tbMines.Size = new System.Drawing.Size(50, 23);
            this.tbMines.TabIndex = 3;
            // 
            // MineSweeper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 307);
            this.Controls.Add(this.tbMines);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTime);
            this.Controls.Add(this.plGame);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btNewGame);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MineSweeper";
            this.Text = "MineSweeper--Luming Peng(lup18002)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btNewGame;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel plGame;
        private System.Windows.Forms.Label lbTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.TextBox tbMines;
        private System.Windows.Forms.Timer timer;
    }
}

