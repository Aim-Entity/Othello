namespace othello
{
    partial class Form2
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
            panel1 = new Panel();
            checkedListBox1 = new CheckedListBox();
            button6 = new Button();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 192, 192);
            panel1.Controls.Add(checkedListBox1);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(123, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(283, 402);
            panel1.TabIndex = 0;
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Blank", "Blank", "Blank", "Blank", "Blank" });
            checkedListBox1.Location = new Point(38, 71);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(190, 202);
            checkedListBox1.TabIndex = 9;
            checkedListBox1.SelectedIndexChanged += checkedListBox1_SelectedIndexChanged;
            // 
            // button6
            // 
            button6.Location = new Point(88, 355);
            button6.Name = "button6";
            button6.Size = new Size(84, 31);
            button6.TabIndex = 8;
            button6.Text = "Save";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 299);
            label2.Name = "label2";
            label2.Size = new Size(144, 20);
            label2.TabIndex = 7;
            label2.Text = "Name Your Save File";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(13, 322);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(239, 27);
            textBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(71, 25);
            label1.Name = "label1";
            label1.Size = new Size(125, 20);
            label1.TabIndex = 0;
            label1.Text = "Select A Save File";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(552, 450);
            Controls.Add(panel1);
            Name = "Form2";
            Text = "Form2";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Button button6;
        private CheckedListBox checkedListBox1;
    }
}