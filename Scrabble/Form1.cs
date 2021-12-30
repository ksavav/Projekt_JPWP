using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Scrabble;

namespace Scrabble
{
    public partial class Scrabble : Form
    {
        //zmienne globalne
        Label temp = new Label();
        Board b = new Board();
        bool game_over = false;
        bool hand_tile_clicked = false;
        int lenght_of_word = 0;
        int word_counter = 0;

        public Scrabble()
        {
            InitializeComponent();
            createPlayers();
        }

        public string letters_pool = "AAAAAAAAAĄBBCCCĆDDDEEEEEEEĘFGGHHIIIIIIIIJJKKKLLLŁŁMMMNNNNNŃOOOOOOÓPPPRRRRSSSSŚTTTUUWWWWYYYYZZZZZŹŻ";

        //tworzenie graczy
        public void createPlayers()
        {
            Player player1 = new Player(letters_pool);
            Player player2 = new Player(letters_pool);

            game(player1, player2);
        }

        public void game(Player player1, Player player2)
        {
            List<Label> BoardLabels = new List<Label>();
            bool turn_ended = false;

            whoStarts(player1, player2);

            turn(player1, player2, BoardLabels, turn_ended);
        }

        public void turn(Player player1, Player player2, List<Label> BoardLabels, bool turn_ended) // nie wiem czy potrzebny ten bool
        {
            BoardLabels = createBoard(BoardLabels);

            if (player1.current_turn == true)
            {
                createTilesFromLetters(player1);
                player1.current_turn = false;
            }

            else
            {
                createTilesFromLetters(player2);
                player1.current_turn = true;
            }
        }

        //kto startuje?
        public void whoStarts(Player player1, Player player2)
        {
            Random rnd = new Random();

            int start = rnd.Next(1);

            if (start == 1) //kto zaczyna
            {
                player1.current_turn = true;
                player2.current_turn = false;
            }

            else
            {
                player1.current_turn = false;
                player2.current_turn = true;
                //is_player1_turn = false;
            }
        }

        //string posiadajacy literki na rece gracza
        public void literki(Player player)
        {
            string text = "";
            for(int i = 0; i < player.letters.Length; i++)
            {
                text = text + player.letters[i].ToString();
            }
        }

        //tworzenie planszy
        public List<Label> createBoard(List<Label> BoardLabels)
        {
            for(int i = 0; i < 15; i++)
            {
                for(int j = 0; j < 15; j++)
                {
                    /*BoardLabels.Add(new Label()
                    {
                        Location = new System.Drawing.Point(112 + i * 50, 52 + j * 50),
                        Name = i.ToString() + "x" + j.ToString(),
                        Size = new System.Drawing.Size(42, 42),
                        BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                        TabIndex = int.Parse(i.ToString() + j.ToString()),
                        Text = "",//i.ToString() + "x" + j.ToString()
                        
                    }) ;
                    */

                    var label = new Label();
                    label.Location = new System.Drawing.Point(112 + i * 50, 52 + j * 50);
                    label.Name = i.ToString() + "x" + j.ToString();
                    label.Size = new System.Drawing.Size(42, 42);
                    label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    label.TabIndex = int.Parse(i.ToString() + j.ToString());
                    label.Text = "";//i.ToString() + "x" + j.ToString()
                    label.Click += boardTile_Click;
                    label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    label.Font = new System.Drawing.Font("Calibri", 20F);
                    //label.Paint += ClickedLabel_Paint;
                    BoardLabels.Add(label);
                }
            }

            placeTiles(BoardLabels);

            return BoardLabels;
        }
        
        //wyplucie planszy do Formsa
        public void placeTiles(List<Label> BoardLabels)
        {
            foreach (Label item in BoardLabels)
            {
                this.Controls.Add(item);
                item.BringToFront();
            }

            colorTiles(BoardLabels);
        }

        //kolorowanie odpowiednich pol na planszy
        public void colorTiles(List<Label> BoardLabels)
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

        //Tworzenie reki gracza
        public void createTilesFromLetters(Player player)
        {
            var YellowLetters = new string[] { "A", "E", "I", "N", "O", "R", "S", "W", "Z" };
            var GreenLetters = new string[] { "C", "D", "K", "L", "M", "P", "T", "Y" };
            var BlueLetters = new string[] { "B", "G", "H", "J", "Ł", "U" };
            var RedLetters = new string[] { "Ą", "Ć", "Ę", "F", "Ń", "Ó", "Ś", "Ź", "Ż" };

            List<Label> list = new List<Label>();
            for (int i = 0; i < 7; i++)
            {
                /*list.Add(new Label()
                {
                    Location = new System.Drawing.Point(112 + 200 + i * 50, 850),
                    Name = "tile" + i.ToString(),
                    Size = new System.Drawing.Size(42, 42),
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                    //TabIndex = int.Parse(i.ToString() + j.ToString()),\
                    Font = new System.Drawing.Font("Calibri", 20F),
                    Text = player.letters[i].ToString(),
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                });*/

                var label = new Label();
                label.Location = new System.Drawing.Point(112 + 200 + i * 50, 850);
                label.Name = "tile" + i.ToString();
                label.Size = new System.Drawing.Size(42, 42);
                label.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                //TabIndex = int.Parse(i.ToString() + j.ToString());
                label.Font = new System.Drawing.Font("Calibri", 20F);
                label.Text = player.letters[i].ToString();
                label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                label.Click += handTile_Click;
                
                list.Add(label);

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

        //wyplucie reki do formsa
        public void placeTilesFromLetters(List<Label> list)
        {
            foreach (Label item in list)
            {
                this.Controls.Add(item);
                item.BringToFront();
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //eventy

        char consOrient = ' ';
        int[] pos_x_y_1 = new int[2];
        int[] pos_x_y_2 = new int[2];
        public void boardTile_Click(object sender, EventArgs e)
        {
            var clickedLabel = (Label)sender;

            //[0] -> x, [1] -> y
            int[] pos_x_y = new int[2];
            bool valid = false;
            
            if (clickedLabel != null & hand_tile_clicked == true & lenght_of_word == 0)
            {
                //clickedLabel.BorderStyle = BorderStyle.None;
                pos_x_y_1 = b.stringToChar(clickedLabel.Name);
                clickedLabel.BackColor = temp.BackColor;
                clickedLabel.Text = temp.Text;
                clickedLabel.Font = temp.Font;
                clickedLabel.BackColor = temp.BackColor;
                b.boardFill(char.Parse(clickedLabel.Text), clickedLabel.Name);
                hand_tile_clicked = false;
                lenght_of_word++;
            }

            else if (clickedLabel != null & hand_tile_clicked == true & lenght_of_word == 1)
            {
                pos_x_y_2 = b.stringToChar(clickedLabel.Name);
                consOrient = wordOrient(pos_x_y_1, pos_x_y_2);
                valid = validation(pos_x_y_1, pos_x_y_2, consOrient);
                if(valid == true)
                {
                    clickedLabel.Text = temp.Text;
                    clickedLabel.Font = temp.Font;
                    clickedLabel.BackColor = temp.BackColor;
                    if (valid == true) b.boardFill(char.Parse(clickedLabel.Text), clickedLabel.Name);
                    hand_tile_clicked = false;
                    lenght_of_word++;
                }
            }

            else if (clickedLabel != null & hand_tile_clicked == true & lenght_of_word > 1)
            {
                pos_x_y = b.stringToChar(clickedLabel.Name);
                valid = validation(pos_x_y_1, pos_x_y, consOrient);
                if (valid == true)
                {
                    clickedLabel.Text = temp.Text;
                    clickedLabel.Font = temp.Font;
                    clickedLabel.BackColor = temp.BackColor;
                    b.boardFill(char.Parse(clickedLabel.Text), clickedLabel.Name);
                    hand_tile_clicked = false;
                    lenght_of_word++;
                }
            }

            else;
        }


        public void handTile_Click(object sender, EventArgs e)
        {
            var clickedLabel = (Label)sender;

            if (clickedLabel != null & hand_tile_clicked == false)
            {
                //clickedLabel.BorderStyle = BorderStyle.None;
                temp.BackColor = clickedLabel.BackColor;
                temp.Text = clickedLabel.Text;
                temp.Font = clickedLabel.Font;
                clickedLabel.Visible = false;
                hand_tile_clicked = true;
            }
        } 

        //w jakiej plaszczyznie jest slowo
        public char wordOrient(int[] pos_x_y_1, int[] pos_x_y_2)
        {
            if (pos_x_y_1[0] == pos_x_y_2[0]) return 'x';

            else if (pos_x_y_1[1] == pos_x_y_2[1]) return 'y';

            else return 'a';
        }

        //sprawdzenie poprawnosci wpisana slowa
        public bool validation(int[] pos_x_y_1, int[] pos_x_y_2, char consOrient)
        {
            if(pos_x_y_1[0] == pos_x_y_2[0] & consOrient == 'x') return true; // & Math.Abs(pos_x_y_1[1] - pos_x_y_2[1]) == 1

            else if(pos_x_y_1[1] == pos_x_y_2[1] & consOrient == 'y') return true; // & Math.Abs(pos_x_y_1[0] - pos_x_y_2[0]) == 1

            else return false;
            //if(pos_x_y_1[0] == pos_x_y_2[0] & lenghtOfWord == 2)
        }

        private void accept_button_MouseClick(object sender, MouseEventArgs e)
        {
            //turn()
        }
    }
} 