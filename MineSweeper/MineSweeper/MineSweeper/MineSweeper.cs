using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class MineSweeper : Form
    {
        private const int NumOfRows = 10;
        private const int NumOfColumns = 15;
        private const double possible = 0.2;
        enum ColorRange
        {
            REDMAX = 183, REDMIN = 80, GREENMAX = 228, GREENMIN = 110, BLUEMAX = 249, BLUEMIN = 220
        };

        private List<List<Mine>> mines = new List<List<Mine>>();
        private int total_mines_num = 0;
        private int last_mines_num = 0;
        private int ticktick = 0;
        private int last_safe_num = 0;

        private int game_state = 0;//0:continue 1:succeeded -1:failed

        public MineSweeper()
        {
            InitializeComponent();

            timer.Interval = 1000;//1000ms
            timer.Tick += Timer_Tick;
            InitializeGame();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tbTime.Text = (++ticktick).ToString();
        }

        private void ShowAll()
        {
            for (int i = 0; i < NumOfRows; i++)
            {
                for (int j = 0; j < NumOfColumns; j++)
                {
                    mines[i][j].Open();
                }
            }
        }

        public void InitializeGame()
        {
            //clear mines
            if(mines.Count > 0)
            {
                foreach(var item in mines)
                {
                    foreach (var subItem in item)
                        subItem.Dispose();
                    item.Clear();
                }
                mines.Clear();
            }

            //get size of each mine
            int width = this.plGame.Width / NumOfColumns;
            int height = this.plGame.Height / NumOfRows;
            int num_mines = NumOfRows * NumOfColumns;
            double disREDMAX_MIN = (double)(ColorRange.REDMAX - ColorRange.REDMIN) / num_mines;
            double disGREENMAX_MIN = (double)(ColorRange.GREENMAX - ColorRange.GREENMIN) / num_mines;
            double disBLUEMAX_MIN = (double)(ColorRange.BLUEMAX - ColorRange.BLUEMIN) / num_mines;
            //position of each mine
            int x_position = 0;
            int y_position = 0;
            total_mines_num = 0;
            ticktick = 0;
            Random rd = new Random(Guid.NewGuid().GetHashCode());
            
            for (int i = 0; i < NumOfRows; i++)
            {
                x_position = 0;
                y_position = height * i;
                mines.Add(new List<Mine>());
                for (int j = 0; j < NumOfColumns; j++)
                {
                    x_position = width * j;
                    Color c = Color.FromArgb((int)((int)ColorRange.REDMAX - (j * NumOfColumns + i) * disREDMAX_MIN),
                                             (int)((int)ColorRange.GREENMAX - (j * NumOfColumns + i) * disGREENMAX_MIN), 
                                             (int)((int)ColorRange.BLUEMAX - (j * NumOfColumns + i) * disBLUEMAX_MIN));
                    double p = rd.NextDouble();
                    bool is_mine = p < possible;
                    mines[i].Add(new Mine(this.plGame, x_position, y_position, i, j, c, width, height, is_mine));
                    if (is_mine)
                        total_mines_num++;

                    mines[i][j].OnClickMine += MineSweeper_OnClickMine;
                    mines[i][j].OnClickNull += MineSweeper_OnClickNull;
                    mines[i][j].OnClickNumber += MineSweeper_OnClickNumber;
                    mines[i][j].OnFlag += MineSweeper_OnFlag;
                }
            }

            SetSurroundingMinesNum();
            last_mines_num = total_mines_num;
            last_safe_num = NumOfRows * NumOfColumns - total_mines_num;
            tbMines.Text = last_mines_num.ToString();
            tbTime.Text = ticktick.ToString();
            game_state = 0;
            timer.Start();
        }


        private void MineSweeper_OnFlag(object sender, EventArgs e)
        {
            if (last_mines_num == 0)
                return;
            Mine mine = sender as Mine;
            if (mine.IsShowFlag == 1)
                tbMines.Text = (--last_mines_num).ToString();
            else
                tbMines.Text = (++last_mines_num).ToString();
            if (last_safe_num == 0 && last_mines_num == 0 && game_state == 0)
            {
                timer.Stop();
                game_state = 1;
                MessageBox.Show(this, "You Succeeded!");
            }
        }

        private void MineSweeper_OnClickNumber(object sender, EventArgs e)
        {
            int num = 0;
            Mine mine = sender as Mine;
            int i = mine.RowNum, j = mine.ColumnNum;
            if (i != 0)
            {
                if (j != 0)
                    num += mines[i - 1][j - 1].IsShowFlag;
                num += mines[i - 1][j].IsShowFlag;
                if (j != NumOfColumns - 1)
                    num += mines[i - 1][j + 1].IsShowFlag;
            }
            if (j != 0)
                num += mines[i][j - 1].IsShowFlag;
            if (j != NumOfColumns - 1)
                num += mines[i][j + 1].IsShowFlag;
            if (i != NumOfRows - 1)
            {
                if (j != 0)
                    num += mines[i + 1][j - 1].IsShowFlag;
                num += mines[i + 1][j].IsShowFlag;
                if (j != NumOfColumns - 1)
                    num += mines[i + 1][j + 1].IsShowFlag;
            }
            
            if(mines[i][j].NumMinesAround == num)
            {
                ShowSurroundingMines(i, j);
            }
        }

        private void MineSweeper_OnClickNull(object sender, EventArgs e)
        {
            Mine mine = sender as Mine;
            if(mine.NumMinesAround == 0)
                ShowSurroundingMines(mine.RowNum, mine.ColumnNum);
            if(--last_safe_num == 0 && last_mines_num == 0 && game_state == 0)
            {
                timer.Stop();
                game_state = 1;
                MessageBox.Show(this, "You Succeeded!");
            }
        }

        private void ShowSurroundingMines(int row_num,int column_num)
        {
            if(row_num != 0)
            {
                if(column_num != 0)
                    mines[row_num - 1][column_num - 1].Open();
                mines[row_num - 1][column_num].Open();
                if(column_num != NumOfColumns-1)
                    mines[row_num - 1][column_num + 1].Open();
            }
            if (column_num != 0)
                mines[row_num][column_num - 1].Open();
            if (column_num != NumOfColumns - 1)
                mines[row_num][column_num + 1].Open();
            if(row_num != NumOfRows - 1)
            {
                if (column_num != 0)
                    mines[row_num + 1][column_num - 1].Open();
                mines[row_num + 1][column_num].Open();
                if (column_num != NumOfColumns - 1)
                    mines[row_num + 1][column_num + 1].Open();
            }
        }

        
        private void MineSweeper_OnClickMine(object sender, EventArgs e)
        {
            timer.Stop();
            game_state = -1;
            ShowAll();
            if (game_state == -1)
            {
                MessageBox.Show(this,"You Failed!");
                game_state = 0;
            } 
        }

        private void SetSurroundingMinesNum()
        {
            int num = 0;
            for(int i = 0; i < NumOfRows; i++)
            {
                for(int j = 0; j < NumOfColumns; j++)
                {
                    num = 0;
                    if(i != 0)
                    {
                        if (j != 0)
                            num += mines[i - 1][j - 1].IsMine;
                        num += mines[i - 1][j].IsMine;
                        if (j != NumOfColumns - 1)
                            num += mines[i - 1][j + 1].IsMine;
                    }
                    if (j != 0)
                        num += mines[i][j - 1].IsMine;
                    if (j != NumOfColumns - 1)
                        num += mines[i][j + 1].IsMine;
                    if(i != NumOfRows - 1)
                    {
                        if (j != 0)
                            num += mines[i + 1][j - 1].IsMine;
                        num += mines[i + 1][j].IsMine;
                        if (j != NumOfColumns - 1)
                            num += mines[i + 1][j + 1].IsMine;
                    }
                    mines[i][j].NumMinesAround = num;
                }
            }
        }

        private void btNewGame_Click(object sender, EventArgs e)
        {
            InitializeGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
