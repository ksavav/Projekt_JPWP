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
        int pass = 0;
        
        //public string letters_pool = "AAAAAAAAAĄBBCCCĆDDDEEEEEEEĘFGGHHIIIIIIIIJJKKKLLLŁŁMMMNNNNNŃOOOOOOÓPPPRRRRSSSSŚTTTUUWWWWYYYYZZZZZŹŻ";
        public bool current_turn;              //czy pierwszy ruch?
        public char[] letters = new char[7]; //maksymalna ilosc liter na rece
        public int score;                    //punkty uzyskane za slowa

        public Player(char[] letters_pool)
        {
            //fill_hand(letters_pool);
        }

        public char[] fill_hand(char[] letters_pool)
        {
            Random rnd = new Random();
            int temp = 0;
            int c = 0;
            for (int i = 0; i < max_letters; )
            {
                temp = rnd.Next(letters_pool.Length);

                while (letters_pool[temp] == '\0') temp = rnd.Next(letters_pool.Length);

                letters[i] = letters_pool[temp];
                //letters_pool = letters_pool.Remove(temp, temp);

                if (letters_pool[temp] != '\0')
                {
                    letters_pool[temp] = '\0';
                    i++;
                }
            }

            foreach (char x in letters_pool)
            {
                if (x != '\0') c++;
            }

            return letters_pool;
        }
        

        public char[] refill_hand(List<Label> playerRack, char[] letters_pool)
        {

            Random rnd = new Random();
            int temp;
            int i = 0;

            try
            {
                foreach (Label label in playerRack)
                {
                    if (label.Text == "used")
                    {
                        temp = rnd.Next(letters_pool.Length);

                        while (letters_pool[temp] == '\0') temp = rnd.Next(letters_pool.Length);

                        letters[i] = letters_pool[temp];
                        letters_pool[temp] = '\0';


                        //letters_pool = letters_pool.Remove(temp);
                        //letters_pool.Remove(letters_pool[temp]);
                        label.Text = letters[i].ToString();
                    }

                    i++;
                }
            }

            catch
            {

            }
            

            return letters_pool;
        }

        public int passCounter()
        {
            return pass++;
        }

        public bool isGameOver()
        {
            if(pass >= 3) return true;
            return false;
        }
    }
}