namespace SearchVisual
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
            panel1 = new Panel();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            button1 = new Button();
            textBox3 = new TextBox();
            label3 = new Label();
            button2 = new Button();
            label4 = new Label();
            textBox4 = new TextBox();
            comboBox1 = new ComboBox();
            button3 = new Button();
            textBox5 = new TextBox();
            end = new Label();
            label5 = new Label();
            button4 = new Button();
            label6 = new Label();
            textBox6 = new TextBox();
            label7 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(1, 157);
            panel1.Name = "panel1";
            panel1.Size = new Size(1082, 652);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 1;
            label1.Text = "Vertex 1";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(66, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            textBox1.KeyPress += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(66, 54);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 3;
            textBox2.KeyPress += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 57);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 4;
            label2.Text = "Vertex 2";
            // 
            // button1
            // 
            button1.Location = new Point(79, 128);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "add Edge";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(294, 12);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(243, 17);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 7;
            label3.Text = "Start:";
            // 
            // button2
            // 
            button2.Location = new Point(307, 41);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 9;
            button2.Text = "run";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 96);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 10;
            label4.Text = "Weight";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(66, 93);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(100, 23);
            textBox4.TabIndex = 11;
            textBox4.KeyPress += textBox4_TextChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(693, 9);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 12;
            // 
            // button3
            // 
            button3.Location = new Point(307, 70);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 13;
            button3.Text = "reset";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(465, 12);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(100, 23);
            textBox5.TabIndex = 14;
            // 
            // end
            // 
            end.AutoSize = true;
            end.Location = new Point(413, 15);
            end.Name = "end";
            end.Size = new Size(30, 15);
            end.TabIndex = 15;
            end.Text = "End:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(604, 15);
            label5.Name = "label5";
            label5.Size = new Size(73, 15);
            label5.TabIndex = 16;
            label5.Text = "Search Algo:";
            // 
            // button4
            // 
            button4.Location = new Point(307, 99);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 17;
            button4.Text = "pause";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(410, 73);
            label6.Name = "label6";
            label6.Size = new Size(37, 15);
            label6.TabIndex = 18;
            label6.Text = "width";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(465, 70);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(100, 23);
            textBox6.TabIndex = 19;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(413, 128);
            label7.Name = "label7";
            label7.Size = new Size(62, 15);
            label7.TabIndex = 20;
            label7.Text = "queue size";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(514, 128);
            label8.Name = "label8";
            label8.Size = new Size(38, 15);
            label8.TabIndex = 21;
            label8.Text = "label8";
            label8.Click += label8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 811);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(textBox6);
            Controls.Add(label6);
            Controls.Add(button4);
            Controls.Add(label5);
            Controls.Add(end);
            Controls.Add(textBox5);
            Controls.Add(button3);
            Controls.Add(comboBox1);
            Controls.Add(textBox4);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private Button button1;
        private TextBox textBox3;
        private Label label3;
        private Button button2;
        private Label label4;
        private TextBox textBox4;
        private ComboBox comboBox1;
        private Button button3;
        private TextBox textBox5;
        private Label end;
        private Label label5;
        private Button button4;
        private Label label6;
        private TextBox textBox6;
        private Label label7;
        private Label label8;
    }
}