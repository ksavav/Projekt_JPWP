namespace Scrabble
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.PictureBox();
            this.btnRules = new System.Windows.Forms.PictureBox();
            this.btnBackToMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackToMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackgroundImage = global::Scrabble.Properties.Resources.start;
            this.btnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStart.Location = new System.Drawing.Point(237, 107);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(175, 75);
            this.btnStart.TabIndex = 0;
            this.btnStart.TabStop = false;
            this.btnStart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnStart_MouseClick);
            this.btnStart.MouseLeave += new System.EventHandler(this.btnStart_MouseLeave);
            this.btnStart.MouseHover += new System.EventHandler(this.btnStart_MouseHover);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = global::Scrabble.Properties.Resources.wyjscie;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Location = new System.Drawing.Point(237, 310);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(175, 75);
            this.btnExit.TabIndex = 1;
            this.btnExit.TabStop = false;
            this.btnExit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnExit_MouseClick);
            this.btnExit.MouseLeave += new System.EventHandler(this.btnExit_MouseLeave);
            this.btnExit.MouseHover += new System.EventHandler(this.btnExit_MouseHover);
            // 
            // btnRules
            // 
            this.btnRules.BackgroundImage = global::Scrabble.Properties.Resources.zasady;
            this.btnRules.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRules.Location = new System.Drawing.Point(237, 207);
            this.btnRules.Name = "btnRules";
            this.btnRules.Size = new System.Drawing.Size(175, 75);
            this.btnRules.TabIndex = 2;
            this.btnRules.TabStop = false;
            this.btnRules.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnRules_MouseClick);
            this.btnRules.MouseLeave += new System.EventHandler(this.btnRules_MouseLeave);
            this.btnRules.MouseHover += new System.EventHandler(this.btnRules_MouseHover);
            // 
            // btnBackToMenu
            // 
            this.btnBackToMenu.BackgroundImage = global::Scrabble.Properties.Resources.back_to_menu;
            this.btnBackToMenu.Location = new System.Drawing.Point(12, 12);
            this.btnBackToMenu.Name = "btnBackToMenu";
            this.btnBackToMenu.Size = new System.Drawing.Size(89, 30);
            this.btnBackToMenu.TabIndex = 3;
            this.btnBackToMenu.TabStop = false;
            this.btnBackToMenu.Visible = false;
            this.btnBackToMenu.Click += new System.EventHandler(this.btnBackToMenu_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Scrabble.Properties.Resources.menu_border_new;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(684, 461);
            this.Controls.Add(this.btnBackToMenu);
            this.Controls.Add(this.btnRules);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnStart);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.btnStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBackToMenu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox btnStart;
        private System.Windows.Forms.PictureBox btnExit;
        private System.Windows.Forms.PictureBox btnRules;
        private System.Windows.Forms.PictureBox btnBackToMenu;
    }
}