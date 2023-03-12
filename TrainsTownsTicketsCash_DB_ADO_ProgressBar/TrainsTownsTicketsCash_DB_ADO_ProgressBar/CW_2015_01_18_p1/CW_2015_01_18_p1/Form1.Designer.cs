namespace CW_2015_01_18_p1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textTrainN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textWhereFrom = new System.Windows.Forms.TextBox();
            this.checkBoxTea = new System.Windows.Forms.CheckBox();
            this.checkBoxBedLingerie = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textWhereTo = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ButtonDemand = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textCardN = new System.Windows.Forms.TextBox();
            this.ButtonPay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер поезда";
            // 
            // textTrainN
            // 
            this.textTrainN.Location = new System.Drawing.Point(112, 10);
            this.textTrainN.Name = "textTrainN";
            this.textTrainN.Size = new System.Drawing.Size(100, 20);
            this.textTrainN.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Откуда";
            // 
            // textWhereFrom
            // 
            this.textWhereFrom.Location = new System.Drawing.Point(61, 41);
            this.textWhereFrom.Name = "textWhereFrom";
            this.textWhereFrom.Size = new System.Drawing.Size(100, 20);
            this.textWhereFrom.TabIndex = 3;
            // 
            // checkBoxTea
            // 
            this.checkBoxTea.AutoSize = true;
            this.checkBoxTea.Location = new System.Drawing.Point(12, 83);
            this.checkBoxTea.Name = "checkBoxTea";
            this.checkBoxTea.Size = new System.Drawing.Size(46, 17);
            this.checkBoxTea.TabIndex = 4;
            this.checkBoxTea.Text = "Чай";
            this.checkBoxTea.UseVisualStyleBackColor = true;
            // 
            // checkBoxBedLingerie
            // 
            this.checkBoxBedLingerie.AutoSize = true;
            this.checkBoxBedLingerie.Location = new System.Drawing.Point(64, 83);
            this.checkBoxBedLingerie.Name = "checkBoxBedLingerie";
            this.checkBoxBedLingerie.Size = new System.Drawing.Size(69, 17);
            this.checkBoxBedLingerie.TabIndex = 5;
            this.checkBoxBedLingerie.Text = "Постель";
            this.checkBoxBedLingerie.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Куда";
            // 
            // textWhereTo
            // 
            this.textWhereTo.Location = new System.Drawing.Point(218, 38);
            this.textWhereTo.Name = "textWhereTo";
            this.textWhereTo.Size = new System.Drawing.Size(100, 20);
            this.textWhereTo.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 107);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(760, 199);
            this.dataGridView1.TabIndex = 12;
            // 
            // ButtonDemand
            // 
            this.ButtonDemand.AutoSize = true;
            this.ButtonDemand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ButtonDemand.Location = new System.Drawing.Point(15, 3);
            this.ButtonDemand.Name = "ButtonDemand";
            this.ButtonDemand.Size = new System.Drawing.Size(75, 23);
            this.ButtonDemand.TabIndex = 13;
            this.ButtonDemand.Text = "Заказать";
            this.ButtonDemand.UseVisualStyleBackColor = true;
            this.ButtonDemand.Click += new System.EventHandler(this.ButtonDemand_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(96, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(256, 23);
            this.progressBar1.TabIndex = 14;
            this.progressBar1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(204, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(188, 45);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Тип вагона";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(141, 20);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(39, 17);
            this.radioButton3.TabIndex = 12;
            this.radioButton3.Text = "СВ";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(86, 20);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(49, 17);
            this.radioButton2.TabIndex = 11;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Купе";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(74, 17);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.Text = "Плацкарт";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Реквизиты карты";
            this.label3.Visible = false;
            // 
            // textCardN
            // 
            this.textCardN.Location = new System.Drawing.Point(106, 31);
            this.textCardN.Name = "textCardN";
            this.textCardN.Size = new System.Drawing.Size(160, 20);
            this.textCardN.TabIndex = 17;
            this.textCardN.Visible = false;
            // 
            // ButtonPay
            // 
            this.ButtonPay.Location = new System.Drawing.Point(272, 33);
            this.ButtonPay.Name = "ButtonPay";
            this.ButtonPay.Size = new System.Drawing.Size(75, 23);
            this.ButtonPay.TabIndex = 18;
            this.ButtonPay.Text = "Оплатить";
            this.ButtonPay.UseVisualStyleBackColor = true;
            this.ButtonPay.Visible = false;
            this.ButtonPay.Click += new System.EventHandler(this.ButtonPay_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ButtonPay);
            this.panel1.Controls.Add(this.progressBar1);
            this.panel1.Controls.Add(this.textCardN);
            this.panel1.Controls.Add(this.ButtonDemand);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 300);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 64);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textTrainN);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textWhereFrom);
            this.panel2.Controls.Add(this.checkBoxBedLingerie);
            this.panel2.Controls.Add(this.textWhereTo);
            this.panel2.Controls.Add(this.checkBoxTea);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 110);
            this.panel2.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 364);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textTrainN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textWhereFrom;
        private System.Windows.Forms.CheckBox checkBoxTea;
        private System.Windows.Forms.CheckBox checkBoxBedLingerie;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textWhereTo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button ButtonDemand;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textCardN;
        private System.Windows.Forms.Button ButtonPay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;

    }
}

