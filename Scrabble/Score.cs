using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scrabble
{
    public class Score
    {
        public Score()
        {

        }

        string[] condYellow = new string[] { "2x7", "3x6", "4x5", "5x4", "6x3", "7x2", "8x3", "9x4", "10x5", "11x6", "12x7", "11x8", "10x9", "9x10", "8x11", "7x12", "6x11",
                "5x10", "4x9", "3x8" };
        string[] condGreen = new string[] { "5x0", "4x1", "3x2", "2x3", "1x4", "0x5", "9x0", "10x1", "11x2", "12x3", "13x4", "14x5", "0x9", "1x10", "2x11", "3x12", "4x13",
                "5x14", "9x14", "10x13", "11x12", "12x11", "13x10", "14x9", "0x9", "1x10", "2x11", "3x12", "4x13", "5x14" };
        string[] condBlue = new string[] { "5x7", "6x6", "7x5", "8x6", "9x7", "8x8", "7x9", "6x8" };
        string[] condRed = new string[] { "0x0", "14x0", "0x14", "14x14", "0x7", "1x6", "1x8", "7x0", "6x1", "8x1", "14x7", "13x6", "13x8", "7x14", "6x13", "8x13", "7x7" };

        string[] condDouble = new string[] { "2x5", "3x4", "4x3", "5x2", "9x2", "10x3", "11x4", "12x5", "12x9", "11x10", "10x11", "9x12", "5x12", "4x11", "3x10", "2x9" };
        string[] condTriple = new string[] { "0x2", "2x0", "0x12", "2x14", "12x14", "14x12", "12x0", "14x2" };

        string[] YellowLetters = new string[] { "a", "e", "i", "n", "o", "r", "s", "w", "z" };
        string[] GreenLetters = new string[] { "c", "d", "k", "l", "m", "p", "t", "y" };
        string[] BlueLetters = new string[] { "b", "g", "h", "j", "ł", "u" };
        string[] RedLetters = new string[] { "ą", "ć", "ę", "f", "ń", "ó", "ś", "ż", "ź" };

        /// <summary>
        /// Podliczanie punkow za ruch
        /// </summary>
        /// <param name="newWord"></param>
        /// <param name="board"></param>
        /// <param name="previousWordList"></param>
        /// <param name="wordList"></param>
        /// <returns>Uzyskane punkty za ruch</returns>
        public int countScorForPlayer(List<Label> newWord, List<Label> board, List<string> previousWordList, List<string> wordList)
        {
            int player_score = 0;

            List<string> new_words = new List<string>();
            /*foreach (Label item in newWord)
            {
                if (YellowLetters.Contains(item.Text)) player_score += 1;
                else if (GreenLetters.Contains(item.Text)) player_score += 2;
                else if (BlueLetters.Contains(item.Text)) player_score += 3;
                else player_score += 5;
            }*/

            foreach(string word in wordList)
            {
                if(!previousWordList.Contains(word)) new_words.Add(word);
            }

            //zliczenie punkow za podstawione literki
            foreach(string word in new_words)
            {
                for(int i = 0; i < word.Length; i++)
                {
                    if (YellowLetters.Contains(word[i].ToString())) player_score += 1;
                    else if (GreenLetters.Contains(word[i].ToString())) player_score += 2;
                    else if (BlueLetters.Contains(word[i].ToString())) player_score += 3;
                    else player_score += 5;
                }
            }

            //zliczenie punkow za bonusy na plansze
            foreach (Label item in newWord)
            {
                if (condYellow.Contains(item.Name) & YellowLetters.Contains(item.Text.ToLower())) player_score += 1;
                if (condGreen.Contains(item.Name) & GreenLetters.Contains(item.Text.ToLower())) player_score += 2;
                if (condBlue.Contains(item.Name) & BlueLetters.Contains(item.Text.ToLower())) player_score += 3;
                if (RedLetters.Contains(item.Name) & RedLetters.Contains(item.Text.ToLower())) player_score += 5;
            }

            //zliczenie punkow za bonusy x2 i x3
            foreach (Label item in newWord)
            {
                if (condDouble.Contains(item.Name)) player_score = player_score * 2;
                if (condTriple.Contains(item.Name)) player_score = player_score * 3;
            }

            return player_score;
        }
    }
}
