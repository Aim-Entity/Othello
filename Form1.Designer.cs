namespace othello
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            button1 = new Button();
            textBox2 = new TextBox();
            pictureBox2 = new PictureBox();
            label2 = new Label();
            textBox1 = new TextBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            dToolStripMenuItem = new ToolStripMenuItem();
            sToolStripMenuItem = new ToolStripMenuItem();
            saveGameToolStripMenuItem = new ToolStripMenuItem();
            loadGameToolStripMenuItem = new ToolStripMenuItem();
            exitGameToolStripMenuItem = new ToolStripMenuItem();
            fToolStripMenuItem = new ToolStripMenuItem();
            speakToolStripMenuItem = new ToolStripMenuItem();
            informationPanelToolStripMenuItem = new ToolStripMenuItem();
            sToolStripMenuItem1 = new ToolStripMenuItem();
            panel2 = new Panel();
            label7 = new Label();
            checkedListBox1 = new CheckedListBox();
            button6 = new Button();
            label5 = new Label();
            textBox3 = new TextBox();
            label6 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 192, 192);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(30, 495);
            panel1.Name = "panel1";
            panel1.Size = new Size(640, 165);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Black;
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(469, 56);
            label4.Name = "label4";
            label4.Padding = new Padding(30, 3, 30, 3);
            label4.Size = new Size(116, 26);
            label4.TabIndex = 8;
            label4.Text = "To Play";
            label4.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Black;
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(147, 56);
            label3.Name = "label3";
            label3.Padding = new Padding(30, 3, 30, 3);
            label3.Size = new Size(116, 26);
            label3.TabIndex = 7;
            label3.Text = "To Play";
            label3.Visible = false;
            // 
            // button1
            // 
            button1.Location = new Point(11, 13);
            button1.Name = "button1";
            button1.Size = new Size(123, 41);
            button1.TabIndex = 6;
            button1.Text = "Start Game";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(442, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(165, 27);
            textBox2.TabIndex = 5;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(386, 75);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 51);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(331, 75);
            label2.Name = "label2";
            label2.Size = new Size(48, 37);
            label2.TabIndex = 3;
            label2.Text = "2X";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(122, 85);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(165, 27);
            textBox1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(66, 75);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 51);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(11, 75);
            label1.Name = "label1";
            label1.Size = new Size(48, 37);
            label1.TabIndex = 0;
            label1.Text = "2X";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { dToolStripMenuItem, fToolStripMenuItem, sToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(6, 3, 0, 3);
            menuStrip1.Size = new Size(702, 30);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // dToolStripMenuItem
            // 
            dToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);
            dToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sToolStripMenuItem, saveGameToolStripMenuItem, loadGameToolStripMenuItem, exitGameToolStripMenuItem });
            dToolStripMenuItem.Name = "dToolStripMenuItem";
            dToolStripMenuItem.Size = new Size(62, 24);
            dToolStripMenuItem.Text = "Game";
            // 
            // sToolStripMenuItem
            // 
            sToolStripMenuItem.Name = "sToolStripMenuItem";
            sToolStripMenuItem.Size = new Size(224, 26);
            sToolStripMenuItem.Text = "New Game";
            sToolStripMenuItem.Visible = false;
            sToolStripMenuItem.Click += sToolStripMenuItem_Click;
            // 
            // saveGameToolStripMenuItem
            // 
            saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            saveGameToolStripMenuItem.Size = new Size(224, 26);
            saveGameToolStripMenuItem.Text = "Save Game";
            saveGameToolStripMenuItem.Visible = false;
            saveGameToolStripMenuItem.Click += saveGameToolStripMenuItem_Click;
            // 
            // loadGameToolStripMenuItem
            // 
            loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            loadGameToolStripMenuItem.Size = new Size(224, 26);
            loadGameToolStripMenuItem.Text = "Restore Game";
            loadGameToolStripMenuItem.Click += loadGameToolStripMenuItem_Click;
            // 
            // exitGameToolStripMenuItem
            // 
            exitGameToolStripMenuItem.Name = "exitGameToolStripMenuItem";
            exitGameToolStripMenuItem.Size = new Size(224, 26);
            exitGameToolStripMenuItem.Text = "Exit Game";
            exitGameToolStripMenuItem.Click += exitGameToolStripMenuItem_Click;
            // 
            // fToolStripMenuItem
            // 
            fToolStripMenuItem.BackColor = Color.FromArgb(224, 224, 224);
            fToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { speakToolStripMenuItem, informationPanelToolStripMenuItem });
            fToolStripMenuItem.Name = "fToolStripMenuItem";
            fToolStripMenuItem.Size = new Size(76, 24);
            fToolStripMenuItem.Text = "Settings";
            // 
            // speakToolStripMenuItem
            // 
            speakToolStripMenuItem.CheckOnClick = true;
            speakToolStripMenuItem.Name = "speakToolStripMenuItem";
            speakToolStripMenuItem.Size = new Size(209, 26);
            speakToolStripMenuItem.Text = "Speak";
            // 
            // informationPanelToolStripMenuItem
            // 
            informationPanelToolStripMenuItem.Checked = true;
            informationPanelToolStripMenuItem.CheckOnClick = true;
            informationPanelToolStripMenuItem.CheckState = CheckState.Checked;
            informationPanelToolStripMenuItem.Name = "informationPanelToolStripMenuItem";
            informationPanelToolStripMenuItem.Size = new Size(209, 26);
            informationPanelToolStripMenuItem.Text = "Information Panel";
            informationPanelToolStripMenuItem.Click += informationPanelToolStripMenuItem_Click;
            // 
            // sToolStripMenuItem1
            // 
            sToolStripMenuItem1.BackColor = Color.FromArgb(224, 224, 224);
            sToolStripMenuItem1.Name = "sToolStripMenuItem1";
            sToolStripMenuItem1.Size = new Size(55, 24);
            sToolStripMenuItem1.Text = "Help";
            sToolStripMenuItem1.Click += sToolStripMenuItem1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 192, 192);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(checkedListBox1);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(193, 62);
            panel2.Name = "panel2";
            panel2.Size = new Size(332, 403);
            panel2.TabIndex = 2;
            panel2.Visible = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BorderStyle = BorderStyle.FixedSingle;
            label7.Cursor = Cursors.Hand;
            label7.ForeColor = Color.Red;
            label7.Location = new Point(13, 9);
            label7.Name = "label7";
            label7.Size = new Size(42, 22);
            label7.TabIndex = 10;
            label7.Text = "Back";
            label7.Click += label7_Click;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Blank", "Blank", "Blank", "Blank", "Blank" });
            checkedListBox1.Location = new Point(24, 72);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(284, 180);
            checkedListBox1.TabIndex = 9;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // button6
            // 
            button6.Location = new Point(131, 351);
            button6.Name = "button6";
            button6.Size = new Size(85, 31);
            button6.TabIndex = 8;
            button6.Text = "Save";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 283);
            label5.Name = "label5";
            label5.Size = new Size(144, 20);
            label5.TabIndex = 7;
            label5.Text = "Name Your Save File";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(24, 307);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(284, 27);
            textBox3.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(102, 39);
            label6.Name = "label6";
            label6.Size = new Size(125, 20);
            label6.TabIndex = 0;
            label6.Text = "Select A Save File";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(702, 673);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "O'Neillo Game";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label1;
        private Button button1;
        private TextBox textBox2;
        private PictureBox pictureBox2;
        private Label label2;
        private TextBox textBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem dToolStripMenuItem;
        private ToolStripMenuItem sToolStripMenuItem;
        private ToolStripMenuItem fToolStripMenuItem;
        private ToolStripMenuItem sToolStripMenuItem1;
        private ToolStripMenuItem speakToolStripMenuItem;
        private ToolStripMenuItem informationPanelToolStripMenuItem;
        private ToolStripMenuItem saveGameToolStripMenuItem;
        private Label label4;
        private Label label3;
        private ToolStripMenuItem loadGameToolStripMenuItem;
        private Panel panel2;
        private CheckedListBox checkedListBox1;
        private Button button6;
        private Label label5;
        private TextBox textBox3;
        private Label label6;
        private Label label7;
        private ToolStripMenuItem exitGameToolStripMenuItem;
    }
}