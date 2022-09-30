using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace MineSweeper
{
    public class Mine : Button
    {
        private int row_Num;
        public int RowNum { get { return row_Num; } }

        private int column_Num;
        public int ColumnNum { get { return column_Num; } }

        private bool is_Mine = false;
        public int IsMine
        {
            get
            {
                if (is_Mine)
                    return 1;
                else
                    return 0;
            }
        }
        private int num_Mines_Around = 0;
        public int NumMinesAround
        {
            get { return num_Mines_Around; }
            set { num_Mines_Around = value; }
        }

        private bool is_Open = false;
        private bool is_ShowFlag = false;

        public int IsShowFlag
        {
            get
            {
                if (is_ShowFlag)
                    return 1;
                else
                    return 0;
            }
        }

        public delegate void ClickMineHandler(object sender,EventArgs e);
        public delegate void ClickNullHandler(object sender, EventArgs e);
        public delegate void ClickNumberHandler(object sender, EventArgs e);
        public delegate void FlagHandler(object sender, EventArgs e);

        public event ClickMineHandler OnClickMine;
        public event ClickNullHandler OnClickNull;
        public event ClickNumberHandler OnClickNumber;
        public event FlagHandler OnFlag;

        public Mine(Panel parent, int x_position, int y_position, 
                    int row_num,int column_num,
                    Color color, 
                    int width, int height,
                    bool is_mine)
        {
            this.Parent = parent;
            this.Location = new Point(x_position, y_position);
            this.row_Num = row_num;
            this.column_Num = column_num;
            this.Width = width;
            this.Height = height;
            this.BackColor = color;
            this.is_Mine = is_mine;

            this.FlatAppearance.BorderSize = 1;
            this.FlatAppearance.BorderColor = Color.FromArgb(31, 44, 101);
            this.FlatStyle = FlatStyle.Flat;
            this.Font = new Font("Microsoft YaHei UI", 9);

            this.MouseDown += Mine_MouseDown;
            this.MouseUp += Mine_MouseUp;
        }

        bool is_LeftDown = false, is_RightDown = false;
        private void Mine_MouseUp(object sender, MouseEventArgs e)
        {
            if(is_LeftDown && is_RightDown && is_Open && !is_Mine)
            {
                this.OnClickNumber.Invoke(this, null);
            }
            else if (is_RightDown && !is_Open)
            {
                ShowFlag();
            }
            else if (is_LeftDown && !is_ShowFlag && !is_Open)
            {
                if (is_Mine)
                    ShowMine();
                else
                    ShowNumber();

            }

            is_LeftDown = false;
            is_RightDown = false;
        }

        public void Mine_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                is_LeftDown = true;
            else if (e.Button == MouseButtons.Right)
                is_RightDown = true;
            
        }

        public void Open()
        {
            if (is_Open)
                return;
            if (is_ShowFlag)
            {
                if(is_Mine)
                    return;
                ShowErrFlag();
            }  
            else if (is_Mine)
                ShowMine();
            else
                ShowNumber();
        }

        public void ShowFlag()
        {
            if (!is_ShowFlag)
            {
                Image img = Properties.Resources.Flag;
                this.Image = new Bitmap(img, this.Size);
                is_ShowFlag = true;
            }
            else
            {
                this.Image = null;
                is_ShowFlag = false;
            }
            this.OnFlag.Invoke(this, null);
        }

        public void ShowErrFlag()
        {
            Image img = Properties.Resources.errFlag;
            this.Image = new Bitmap(img, this.Size);
        }

        public void ShowMine()
        {
            Image img = Properties.Resources.Mine;
            this.Image = new Bitmap(img, this.Size);
            is_Open = true;
            this.OnClickMine.Invoke(this, null);   
        }

        public void ShowNumber()
        {
            this.BackColor = Color.White;
            this.FlatAppearance.BorderColor = Color.White;
            if(num_Mines_Around > 0)
                this.Text = num_Mines_Around.ToString();
            is_Open = true;
            this.OnClickNull.Invoke(this, null);
            if (num_Mines_Around == 0) 
                this.Enabled = false;
        }
    }
}
