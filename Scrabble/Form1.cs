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
    public partial class Scrabble : Form
    {
        bool game_over = false;
        public Scrabble()
        {
            InitializeComponent();
            CreatePlayers();
        }

        public string letters_pool = "AAAAAAAAAĄBBCCCĆDDDEEEEEEEĘFGGHHIIIIIIIIJJKKKLLLŁŁMMMNNNNNŃOOOOOOÓPPPRRRRSSSSŚTTTUUWWWWYYYYZZZZZŹŻ";

        public void CreatePlayers()
        {
            Player player1 = new Player(letters_pool);
            Player player2 = new Player(letters_pool);
            //Board board = new Board();

            WhoStarts(player1 , player2);
            Literki(player1, player2);
            CreateBoard();
            createTilesFromLetters(player1);
        }

        public void WhoStarts(Player player1, Player player2)
        {
            Random rnd = new Random();

            int start = rnd.Next(1);

            if (start == 1) //kto zaczyna
            {
                player1.first_move = true;
                player2.first_move = false;
            }

            else
            {
                player1.first_move = false;
                player2.first_move = true;
            }
        }

        public void Literki(Player player1, Player player2)
        {
            string text = "";
            for(int i = 0; i < player1.letters.Length; i++)
            {
                text = text + player1.letters[i].ToString();
            }
        }

        public void CreateBoard()
        {
            List<Label> BoardLabels = new List<Label>();
            for(int i = 0; i < 15; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    BoardLabels.Add(new Label()
                    {
                        Location = new System.Drawing.Point(112 + i * 50, 52 + j * 50),
                        Name = i.ToString() + "x" + j.ToString(),
                        Size = new System.Drawing.Size(42, 42),
                        BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                        TabIndex = int.Parse(i.ToString() + j.ToString()),
                        Text = ""//i.ToString() + "x" + j.ToString()
                    }) ;
                }
            }

            placeTiles(BoardLabels);
        }
        
        public void placeTiles(List<Label> BoardLabels)
        {
            foreach (Label item in BoardLabels)
            {
                this.Controls.Add(item);
                item.BringToFront();
            }

            ColorTiles(BoardLabels);
        }

        public void ColorTiles(List<Label> BoardLabels)
        {
            var condRed = new string[] { "0x0", "14x0", "0x14", "14x14", "0x7", "1x6", "1x8", "7x0", "6x1", "8x1", "14x7", "13x6", "13x8", "7x14", "6x13", "8x13", "7x7" };
            var condGreen = new string[] { "5x0", "4x1", "3x2", "2x3", "1x4", "0x5", "9x0", "10x1", "11x2", "12x3", "13x4", "14x5", "0x9", "1x10", "2x11", "3x12", "4x13", 
                "5x14", "9x14", "10x13", "11x12", "12x11", "13x10", "14x9", "0x9", "1x10", "2x11", "3x12", "4x13", "5x14" };
            var condYellow = new string[] { "2x7", "3x6", "4x5", "5x4", "6x3", "7x2", "8x3", "9x4", "10x5", "11x6", "12x7", "11x8", "10x9", "9x10", "8x11", "7x12", "6x11",
                "5x10", "4x9", "3x8" };
            var condBlue = new string[] { "5x7", "6x6", "7x5", "8x6", "9x7", "8x8", "7x9", "6x8" };
            var condDouble = new string[] { "2x5", "3x4", "4x3", "5x2", "9x2", "10x3", "11x4", "12x5", "12x9", "11x10", "10x11", "9x12", "5x12", "4x11", "3x10", "2x9" };
            var condTriple = new string[] { "0x2", "2x0", "0x12", "2x14", "12x14", "14x12", "12x0", "14x2" };

            foreach (Label item in BoardLabels)
            {
                if (condRed.Contains(item.Name))
                {
                    item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
                }

                else if (condGreen.Contains(item.Name))
                {
                    item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(255)))), ((int)(((byte)(77)))));
                }

                else if (condYellow.Contains(item.Name))
                {
                    item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(77)))));
                }

                else if (condBlue.Contains(item.Name))
                {
                    item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                }

                else if (condDouble.Contains(item.Name))
                {
                    item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    item.Font = new System.Drawing.Font("Calibri", 10);
                    item.Text = " x2";
                    item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                }

                else if (condTriple.Contains(item.Name))
                {
                    item.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
                    item.Font = new System.Drawing.Font("Calibri", 10);
                    item.Text = " x3";
                    item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                }

                else
                {
                    item.BackColor = System.Drawing.Color.White;
                }
            }
        }

        public void createTilesFromLetters(Player player)
        {
            var YellowLetters = new string[] { "A", "E", "I", "N", "O", "R", "S", "W", "Z" };
            var GreenLetters = new string[] { "C", "D", "K", "L", "M", "P", "T", "Y" };
            var BlueLetters = new string[] { "B", "G", "H", "J", "Ł", "U" };
            var RedLetters = new string[] { "Ą", "Ć", "Ę", "F", "Ń", "Ó", "Ś", "Ź", "Ż" };

            List<Label> list = new List<Label>();
            for (int i = 0; i < 7; i++)
            {
                list.Add(new Label()
                {
                    Location = new System.Drawing.Point(112 + 200 + i * 50, 850),
                    Name = "tile" + i.ToString(),
                    Size = new System.Drawing.Size(42, 42),
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                    //TabIndex = int.Parse(i.ToString() + j.ToString()),\
                    Font = new System.Drawing.Font("Calibri", 20F),
                    Text = player.letters[i].ToString(),
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                });
            }

        
            foreach(Label label in list)
            {
                if (YellowLetters.Contains(label.Text))
                {
                    label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(77)))));
                }

                else if (GreenLetters.Contains(label.Text))
                {
                    label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(255)))), ((int)(((byte)(77)))));
                }

                else if (BlueLetters.Contains(label.Text))
                {
                    label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
                }

                else
                {
                    label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(77)))));
                }
            }

            placeTilesFromLetters(list);
        }

        public void placeTilesFromLetters(List<Label> list)
        {
            foreach (Label item in list)
            {
                this.Controls.Add(item);
                item.BringToFront();
            }
        }

         public void tile_Click(object sender, EventArgs e)
         {
            var tile = (Label)sender;
        }
    }
}