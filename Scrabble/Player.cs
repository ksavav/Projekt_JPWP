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
    public class Player
    {
        int max_letters = 7;

        public bool current_turn;              //czy pierwszy ruch?
        public char[] letters = new char[7]; //maksymalna ilosc liter na rece
        public int score;                    //punkty uzyskane za slowa
        

        public Player(string letters_pool)
        {
            fill_hand(letters_pool);
        }

        public void fill_hand(string letters_pool)
        {
            Random rnd = new Random();
            int temp;
            for (int i = 0; i < max_letters; i++)
            {
                temp = rnd.Next(letters_pool.Length);
                letters[i] = letters_pool[temp];
                letters_pool.Remove(temp);
            }
        }
    }
}