using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Scrabble
{
    public class ValidWords
    {
        public List<string> Words { get; set; }

        public ValidWords()
        {
            this.LoadWords();
        }

        private void LoadWords()
        {
            Words = new List<string>();

            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"slowa.txt");
            foreach (var w in File.ReadAllLines(path))
            {
                Words.Add(w);
            }
        }

        public bool CheckValidation(List<string> words_on_board)
        {
            foreach(var word in words_on_board)
            {
                if (!Words.Contains(word))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
