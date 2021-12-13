using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble
{
    public partial class Player : Form
    {
        int max_letters = 7;

        public bool first_move;              //czy pierwszy ruch?
        public char[] letters = new char[7]; //maksymalna ilosc liter na rece
        public int score;                    //punkty uzyskane za slowa
        

        public Player(string letters_pool)
        {
            Random rnd = new Random();
            for (int i = 0; i < max_letters; i++)
            {
                letters[i] = letters_pool[rnd.Next(letters_pool.Length)];
            }
        }
    }
}