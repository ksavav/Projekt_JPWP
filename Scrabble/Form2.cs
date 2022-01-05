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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnStart_MouseHover(object sender, EventArgs e)
        {
            btnStart.Image = Properties.Resources.start_hover;
        }

        private void btnStart_MouseLeave(object sender, EventArgs e)
        {
            btnStart.Image = Properties.Resources.start;
        }

        private void btnRules_MouseHover(object sender, EventArgs e)
        {
            btnRules.Image = Properties.Resources.zasady_hover;
        }

        private void btnRules_MouseLeave(object sender, EventArgs e)
        {
            btnRules.Image = Properties.Resources.zasady;
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            btnExit.Image = Properties.Resources.wyjscie_hover;
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.Image = Properties.Resources.wyjscie;
        }

        private void btnStart_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            Scrabble scrabble = new Scrabble();
            scrabble.ShowDialog();
            this.Close();
        }

        private void btnRules_MouseClick(object sender, MouseEventArgs e)
        {
            btnStart.Visible = false;
            btnExit.Visible = false;
            btnRules.Visible = false;
            btnBackToMenu.Visible = true;
            BackgroundImage = Properties.Resources.rules;
        }

        private void btnExit_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void btnBackToMenu_Click(object sender, EventArgs e)
        {
            btnStart.Visible = true;
            btnExit.Visible = true;
            btnRules.Visible = true;
            btnBackToMenu.Visible = false;
            BackgroundImage = Properties.Resources.menu_border_new;
        }
    }
}
