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
        char[,] backup_board = new char[15, 15];
        int rows = 15;
        int cols = 15;

        public Board()
        {

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

        public bool gameOver(char[] letters_pool)
        {
            int counter = 0;

            foreach(var item in letters_pool)
            {
                if (item == '\0') counter++;
            }

            if ((letters_pool.Length - counter) <= 4) return true;
            else return false;
        }

        public List<string> createWordsFromTable()
        {
            List<string> words = new List<string>();
            int word_lenght = 0;
            string new_word = "";

            for(int i = 0; i < cols; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    if(board_tabel[j, i] != '\0')
                    {
                        word_lenght++;
                        new_word = new_word + board_tabel[j, i].ToString().ToLowerInvariant();
                    }
                    
                    if(board_tabel[j, i] == '\0' & word_lenght > 1)
                    {
                        words.Add(new_word);
                        new_word = "";
                        word_lenght = 0;
                    }

                    if(board_tabel[j, i] == '\0' & word_lenght <= 1)
                    {
                        new_word = "";
                        word_lenght = 0;
                    }
                }
            }

            for (int i = 0; i < cols; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    if (board_tabel[i, j] != '\0')
                    {
                        word_lenght++;
                        new_word = new_word + board_tabel[i, j].ToString().ToLowerInvariant();
                    }

                    if (board_tabel[i, j] == '\0' & word_lenght > 1)
                    {
                        words.Add(new_word);
                        new_word = "";
                        word_lenght = 0;
                    }

                    if (board_tabel[i, j] == '\0' & word_lenght <= 1)
                    {
                        new_word = "";
                        word_lenght = 0;
                    }
                }
            }

            return words;
        }

        public void reloadBoard()
        {
            for(int i = 0; i < cols; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    board_tabel[i, j] = backup_board[i, j];
                }
            }
        }

        public void overwriteBoard()
        {
            for (int i = 0; i < cols; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    backup_board[i, j] = board_tabel[i, j];
                }
            }
        }
    }
}
