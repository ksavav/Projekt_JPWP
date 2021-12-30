using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble
{
    public class Board : Form
    {
        char[,] board_tabel = new char[15, 15];

        public Board()
        {
            int max_columns = 14;
            int max_rows = 14;
        }

        public void boardFill(char letter, string loc)
        {
            int[] pos_x_y = new int[2];

            //[0] - x, [1] - y
            pos_x_y = stringToChar(loc);

            board_tabel[pos_x_y[0], pos_x_y[1]] = letter;
         }

        public int[] stringToChar(string loc)
        {
            bool flag = false;
            string tmp_pos_x = "", tmp_pos_y = "";
            int[] pos_x_y = new int[2];

            for (int i = 0; i < loc.Length; i++)
            {
                if (loc[i] != 'x' & flag == false)
                {
                    tmp_pos_x = tmp_pos_x + loc[i];
                }

                else if (loc[i] != 'x' & flag == true)
                {
                    tmp_pos_y = tmp_pos_y + loc[i];
                }

                else flag = true;
            }
            
            pos_x_y[0] = Int32.Parse(tmp_pos_x);
            pos_x_y[1] = Int32.Parse(tmp_pos_y);

            return pos_x_y;
        }
    }
}
