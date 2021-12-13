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
        int max_columns = 14;
        int max_rows = 14;
        char[,] board_tabel = new char[14, 14];
    }
}
