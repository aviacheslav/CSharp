namespace Tables
{
    partial class CharRecognForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_ask = new System.Windows.Forms.Button();
            this.button_answer = new System.Windows.Forms.Button();
            this.button_SetSize = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_agree = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_agree);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button_SetSize);
            this.panel1.Controls.Add(this.button_answer);
            this.panel1.Controls.Add(this.button_ask);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(237, 115);
            this.panel1.TabIndex = 0;
            // 
            // button_ask
            // 
            this.button_ask.Location = new System.Drawing.Point(12, 12);
            this.button_ask.Name = "button_ask";
            this.button_ask.Size = new System.Drawing.Size(75, 23);
            this.button_ask.TabIndex = 0;
            this.button_ask.Text = "Ask";
            this.button_ask.UseVisualStyleBackColor = true;
            // 
            // button_answer
            // 
            this.button_answer.Location = new System.Drawing.Point(12, 41);
            this.button_answer.Name = "button_answer";
            this.button_answer.Size = new System.Drawing.Size(75, 23);
            this.button_answer.TabIndex = 1;
            this.button_answer.Text = "Answer";
            this.button_answer.UseVisualStyleBackColor = true;
            // 
            // button_SetSize
            // 
            this.button_SetSize.Location = new System.Drawing.Point(12, 70);
            this.button_SetSize.Name = "button_SetSize";
            this.button_SetSize.Size = new System.Drawing.Size(75, 23);
            this.button_SetSize.TabIndex = 2;
            this.button_SetSize.Text = "SetSize";
            this.button_SetSize.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "X";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(93, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(167, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(93, 41);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(48, 20);
            this.textBox3.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(93, 15);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(48, 20);
            this.textBox4.TabIndex = 7;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(237, 238);
            this.dataGridView1.TabIndex = 1;
            // 
            // button_agree
            // 
            this.button_agree.Location = new System.Drawing.Point(151, 15);
            this.button_agree.Name = "button_agree";
            this.button_agree.Size = new System.Drawing.Size(75, 23);
            this.button_agree.TabIndex = 8;
            this.button_agree.Text = "Agree";
            this.button_agree.UseVisualStyleBackColor = true;
            // 
            // CharRecognForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 353);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "CharRecognForm";
            this.Text = "CharRecognForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_SetSize;
        private System.Windows.Forms.Button button_answer;
        private System.Windows.Forms.Button button_ask;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_agree;
    }
}