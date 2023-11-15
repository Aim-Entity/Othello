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
            label2 = new Label();
            textBox1 = new TextBox();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            button6 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 192, 192);
            panel1.Controls.Add(button6);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(123, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(283, 402);
            panel1.TabIndex = 0;
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
            // button5
            // 
            button5.Location = new Point(13, 244);
            button5.Name = "button5";
            button5.Size = new Size(239, 29);
            button5.TabIndex = 5;
            button5.Text = "(un-named)";
            button5.TextAlign = ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(13, 200);
            button4.Name = "button4";
            button4.Size = new Size(239, 29);
            button4.TabIndex = 4;
            button4.Text = "(un-named)";
            button4.TextAlign = ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(13, 156);
            button3.Name = "button3";
            button3.Size = new Size(239, 29);
            button3.TabIndex = 3;
            button3.Text = "(un-named)";
            button3.TextAlign = ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(13, 112);
            button2.Name = "button2";
            button2.Size = new Size(239, 29);
            button2.TabIndex = 2;
            button2.Text = "(un-named)";
            button2.TextAlign = ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(13, 65);
            button1.Name = "button1";
            button1.Size = new Size(239, 31);
            button1.TabIndex = 1;
            button1.Text = "(un-named)";
            button1.TextAlign = ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
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
            // button6
            // 
            button6.Location = new Point(88, 355);
            button6.Name = "button6";
            button6.Size = new Size(84, 31);
            button6.TabIndex = 8;
            button6.Text = "Save";
            button6.UseVisualStyleBackColor = true;
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
        private Button button1;
        private TextBox textBox1;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Label label2;
        private Button button6;
    }
}