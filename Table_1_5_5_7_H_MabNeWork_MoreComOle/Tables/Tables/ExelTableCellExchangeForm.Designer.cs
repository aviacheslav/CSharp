namespace Tables
{
    partial class ExelTableCellExchangeForm
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
            this.groupBox_CurCell = new System.Windows.Forms.GroupBox();
            this.checkBox_CurCell_ExportDBData = new System.Windows.Forms.CheckBox();
            this.comboBox_CurCellType = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox_CurCellActiveValFromExcel = new System.Windows.Forms.CheckBox();
            this.comboBox_ActiveN = new System.Windows.Forms.ComboBox();
            this.button_Clear_ActiveCellActiveVal = new System.Windows.Forms.Button();
            this.button_ActiveCell_ActiveCell = new System.Windows.Forms.Button();
            this.textBox_ActiveVal = new System.Windows.Forms.TextBox();
            this.checkBox_CurCellActiveValNotDefault = new System.Windows.Forms.CheckBox();
            this.comboBox_CurCell_Sheet = new System.Windows.Forms.ComboBox();
            this.checkBox_CurCell_Range = new System.Windows.Forms.CheckBox();
            this.button_Clear_CurCell_2 = new System.Windows.Forms.Button();
            this.button_Clear_CurCell_1 = new System.Windows.Forms.Button();
            this.button_Range_CurCell = new System.Windows.Forms.Button();
            this.button_ActiveCell_CurCell_2 = new System.Windows.Forms.Button();
            this.button_ActiveCell_CurCell_1 = new System.Windows.Forms.Button();
            this.textBox_CurCell_2 = new System.Windows.Forms.TextBox();
            this.textBox_CurCell_1 = new System.Windows.Forms.TextBox();
            this.button_Import = new System.Windows.Forms.Button();
            this.button_Export = new System.Windows.Forms.Button();
            this.groupBox_CurCell.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_CurCell
            // 
            this.groupBox_CurCell.Controls.Add(this.checkBox_CurCell_ExportDBData);
            this.groupBox_CurCell.Controls.Add(this.comboBox_CurCellType);
            this.groupBox_CurCell.Controls.Add(this.label10);
            this.groupBox_CurCell.Controls.Add(this.label8);
            this.groupBox_CurCell.Controls.Add(this.checkBox_CurCellActiveValFromExcel);
            this.groupBox_CurCell.Controls.Add(this.comboBox_ActiveN);
            this.groupBox_CurCell.Controls.Add(this.button_Clear_ActiveCellActiveVal);
            this.groupBox_CurCell.Controls.Add(this.button_ActiveCell_ActiveCell);
            this.groupBox_CurCell.Controls.Add(this.textBox_ActiveVal);
            this.groupBox_CurCell.Controls.Add(this.checkBox_CurCellActiveValNotDefault);
            this.groupBox_CurCell.Controls.Add(this.comboBox_CurCell_Sheet);
            this.groupBox_CurCell.Controls.Add(this.checkBox_CurCell_Range);
            this.groupBox_CurCell.Controls.Add(this.button_Clear_CurCell_2);
            this.groupBox_CurCell.Controls.Add(this.button_Clear_CurCell_1);
            this.groupBox_CurCell.Controls.Add(this.button_Range_CurCell);
            this.groupBox_CurCell.Controls.Add(this.button_ActiveCell_CurCell_2);
            this.groupBox_CurCell.Controls.Add(this.button_ActiveCell_CurCell_1);
            this.groupBox_CurCell.Controls.Add(this.textBox_CurCell_2);
            this.groupBox_CurCell.Controls.Add(this.textBox_CurCell_1);
            this.groupBox_CurCell.Location = new System.Drawing.Point(4, 3);
            this.groupBox_CurCell.Name = "groupBox_CurCell";
            this.groupBox_CurCell.Size = new System.Drawing.Size(326, 160);
            this.groupBox_CurCell.TabIndex = 130;
            this.groupBox_CurCell.TabStop = false;
            // 
            // checkBox_CurCell_ExportDBData
            // 
            this.checkBox_CurCell_ExportDBData.AutoSize = true;
            this.checkBox_CurCell_ExportDBData.Location = new System.Drawing.Point(169, 141);
            this.checkBox_CurCell_ExportDBData.Name = "checkBox_CurCell_ExportDBData";
            this.checkBox_CurCell_ExportDBData.Size = new System.Drawing.Size(100, 17);
            this.checkBox_CurCell_ExportDBData.TabIndex = 136;
            this.checkBox_CurCell_ExportDBData.Text = "Export DB Data";
            this.checkBox_CurCell_ExportDBData.UseVisualStyleBackColor = true;
            // 
            // comboBox_CurCellType
            // 
            this.comboBox_CurCellType.FormattingEnabled = true;
            this.comboBox_CurCellType.Items.AddRange(new object[] {
            "SimpleString",
            "SimpleDouble",
            "SimpleFloat",
            "SimpleInt",
            "SimpleBool",
            "ItemsString",
            "DBFieldHeader",
            "DBTableHeader"});
            this.comboBox_CurCellType.Location = new System.Drawing.Point(217, 117);
            this.comboBox_CurCellType.Name = "comboBox_CurCellType";
            this.comboBox_CurCellType.Size = new System.Drawing.Size(102, 21);
            this.comboBox_CurCellType.TabIndex = 135;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(182, 123);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 134;
            this.label10.Text = "Type:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(38, 13);
            this.label8.TabIndex = 133;
            this.label8.Text = "Sheet:";
            // 
            // checkBox_CurCellActiveValFromExcel
            // 
            this.checkBox_CurCellActiveValFromExcel.AutoSize = true;
            this.checkBox_CurCellActiveValFromExcel.Location = new System.Drawing.Point(153, 66);
            this.checkBox_CurCellActiveValFromExcel.Name = "checkBox_CurCellActiveValFromExcel";
            this.checkBox_CurCellActiveValFromExcel.Size = new System.Drawing.Size(129, 17);
            this.checkBox_CurCellActiveValFromExcel.TabIndex = 132;
            this.checkBox_CurCellActiveValFromExcel.Text = "Active Val From Excel";
            this.checkBox_CurCellActiveValFromExcel.UseVisualStyleBackColor = true;
            // 
            // comboBox_ActiveN
            // 
            this.comboBox_ActiveN.FormattingEnabled = true;
            this.comboBox_ActiveN.Location = new System.Drawing.Point(18, 86);
            this.comboBox_ActiveN.Name = "comboBox_ActiveN";
            this.comboBox_ActiveN.Size = new System.Drawing.Size(90, 21);
            this.comboBox_ActiveN.TabIndex = 131;
            // 
            // button_Clear_ActiveCellActiveVal
            // 
            this.button_Clear_ActiveCellActiveVal.Location = new System.Drawing.Point(189, 88);
            this.button_Clear_ActiveCellActiveVal.Name = "button_Clear_ActiveCellActiveVal";
            this.button_Clear_ActiveCellActiveVal.Size = new System.Drawing.Size(47, 23);
            this.button_Clear_ActiveCellActiveVal.TabIndex = 130;
            this.button_Clear_ActiveCellActiveVal.Text = "Clear";
            this.button_Clear_ActiveCellActiveVal.UseVisualStyleBackColor = true;
            // 
            // button_ActiveCell_ActiveCell
            // 
            this.button_ActiveCell_ActiveCell.Location = new System.Drawing.Point(242, 88);
            this.button_ActiveCell_ActiveCell.Name = "button_ActiveCell_ActiveCell";
            this.button_ActiveCell_ActiveCell.Size = new System.Drawing.Size(75, 23);
            this.button_ActiveCell_ActiveCell.TabIndex = 129;
            this.button_ActiveCell_ActiveCell.Text = "ActiveCell";
            this.button_ActiveCell_ActiveCell.UseVisualStyleBackColor = true;
            // 
            // textBox_ActiveVal
            // 
            this.textBox_ActiveVal.Location = new System.Drawing.Point(142, 91);
            this.textBox_ActiveVal.Name = "textBox_ActiveVal";
            this.textBox_ActiveVal.Size = new System.Drawing.Size(41, 20);
            this.textBox_ActiveVal.TabIndex = 128;
            // 
            // checkBox_CurCellActiveValNotDefault
            // 
            this.checkBox_CurCellActiveValNotDefault.AutoSize = true;
            this.checkBox_CurCellActiveValNotDefault.Location = new System.Drawing.Point(16, 63);
            this.checkBox_CurCellActiveValNotDefault.Name = "checkBox_CurCellActiveValNotDefault";
            this.checkBox_CurCellActiveValNotDefault.Size = new System.Drawing.Size(131, 17);
            this.checkBox_CurCellActiveValNotDefault.TabIndex = 127;
            this.checkBox_CurCellActiveValNotDefault.Text = "Active Val Not Default";
            this.checkBox_CurCellActiveValNotDefault.UseVisualStyleBackColor = true;
            // 
            // comboBox_CurCell_Sheet
            // 
            this.comboBox_CurCell_Sheet.FormattingEnabled = true;
            this.comboBox_CurCell_Sheet.Location = new System.Drawing.Point(55, 117);
            this.comboBox_CurCell_Sheet.Name = "comboBox_CurCell_Sheet";
            this.comboBox_CurCell_Sheet.Size = new System.Drawing.Size(121, 21);
            this.comboBox_CurCell_Sheet.TabIndex = 126;
            // 
            // checkBox_CurCell_Range
            // 
            this.checkBox_CurCell_Range.AutoSize = true;
            this.checkBox_CurCell_Range.Location = new System.Drawing.Point(18, 39);
            this.checkBox_CurCell_Range.Name = "checkBox_CurCell_Range";
            this.checkBox_CurCell_Range.Size = new System.Drawing.Size(53, 17);
            this.checkBox_CurCell_Range.TabIndex = 125;
            this.checkBox_CurCell_Range.Text = "range";
            this.checkBox_CurCell_Range.UseVisualStyleBackColor = true;
            // 
            // button_Clear_CurCell_2
            // 
            this.button_Clear_CurCell_2.Location = new System.Drawing.Point(125, 38);
            this.button_Clear_CurCell_2.Name = "button_Clear_CurCell_2";
            this.button_Clear_CurCell_2.Size = new System.Drawing.Size(47, 23);
            this.button_Clear_CurCell_2.TabIndex = 124;
            this.button_Clear_CurCell_2.Text = "Clear";
            this.button_Clear_CurCell_2.UseVisualStyleBackColor = true;
            // 
            // button_Clear_CurCell_1
            // 
            this.button_Clear_CurCell_1.Location = new System.Drawing.Point(125, 9);
            this.button_Clear_CurCell_1.Name = "button_Clear_CurCell_1";
            this.button_Clear_CurCell_1.Size = new System.Drawing.Size(47, 23);
            this.button_Clear_CurCell_1.TabIndex = 123;
            this.button_Clear_CurCell_1.Text = "Clear";
            this.button_Clear_CurCell_1.UseVisualStyleBackColor = true;
            // 
            // button_Range_CurCell
            // 
            this.button_Range_CurCell.Location = new System.Drawing.Point(259, 8);
            this.button_Range_CurCell.Name = "button_Range_CurCell";
            this.button_Range_CurCell.Size = new System.Drawing.Size(64, 52);
            this.button_Range_CurCell.TabIndex = 121;
            this.button_Range_CurCell.Text = "Range";
            this.button_Range_CurCell.UseVisualStyleBackColor = true;
            // 
            // button_ActiveCell_CurCell_2
            // 
            this.button_ActiveCell_CurCell_2.Location = new System.Drawing.Point(178, 37);
            this.button_ActiveCell_CurCell_2.Name = "button_ActiveCell_CurCell_2";
            this.button_ActiveCell_CurCell_2.Size = new System.Drawing.Size(75, 23);
            this.button_ActiveCell_CurCell_2.TabIndex = 120;
            this.button_ActiveCell_CurCell_2.Text = "ActiveCell";
            this.button_ActiveCell_CurCell_2.UseVisualStyleBackColor = true;
            // 
            // button_ActiveCell_CurCell_1
            // 
            this.button_ActiveCell_CurCell_1.Location = new System.Drawing.Point(178, 8);
            this.button_ActiveCell_CurCell_1.Name = "button_ActiveCell_CurCell_1";
            this.button_ActiveCell_CurCell_1.Size = new System.Drawing.Size(75, 23);
            this.button_ActiveCell_CurCell_1.TabIndex = 119;
            this.button_ActiveCell_CurCell_1.Text = "ActiveCell";
            this.button_ActiveCell_CurCell_1.UseVisualStyleBackColor = true;
            // 
            // textBox_CurCell_2
            // 
            this.textBox_CurCell_2.Location = new System.Drawing.Point(78, 37);
            this.textBox_CurCell_2.Name = "textBox_CurCell_2";
            this.textBox_CurCell_2.Size = new System.Drawing.Size(41, 20);
            this.textBox_CurCell_2.TabIndex = 118;
            // 
            // textBox_CurCell_1
            // 
            this.textBox_CurCell_1.Location = new System.Drawing.Point(78, 11);
            this.textBox_CurCell_1.Name = "textBox_CurCell_1";
            this.textBox_CurCell_1.Size = new System.Drawing.Size(41, 20);
            this.textBox_CurCell_1.TabIndex = 117;
            // 
            // button_Import
            // 
            this.button_Import.Location = new System.Drawing.Point(12, 178);
            this.button_Import.Name = "button_Import";
            this.button_Import.Size = new System.Drawing.Size(75, 23);
            this.button_Import.TabIndex = 131;
            this.button_Import.Text = "Import";
            this.button_Import.UseVisualStyleBackColor = true;
            // 
            // button_Export
            // 
            this.button_Export.Location = new System.Drawing.Point(252, 177);
            this.button_Export.Name = "button_Export";
            this.button_Export.Size = new System.Drawing.Size(75, 23);
            this.button_Export.TabIndex = 132;
            this.button_Export.Text = "Export";
            this.button_Export.UseVisualStyleBackColor = true;
            // 
            // ExelTableCellExchangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 212);
            this.Controls.Add(this.button_Export);
            this.Controls.Add(this.button_Import);
            this.Controls.Add(this.groupBox_CurCell);
            this.Name = "ExelTableCellExchangeForm";
            this.Text = "ExelTableCellExchangeForm";
            this.groupBox_CurCell.ResumeLayout(false);
            this.groupBox_CurCell.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_CurCell;
        private System.Windows.Forms.CheckBox checkBox_CurCell_ExportDBData;
        private System.Windows.Forms.ComboBox comboBox_CurCellType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox_CurCellActiveValFromExcel;
        private System.Windows.Forms.ComboBox comboBox_ActiveN;
        private System.Windows.Forms.Button button_Clear_ActiveCellActiveVal;
        private System.Windows.Forms.Button button_ActiveCell_ActiveCell;
        private System.Windows.Forms.TextBox textBox_ActiveVal;
        private System.Windows.Forms.CheckBox checkBox_CurCellActiveValNotDefault;
        private System.Windows.Forms.ComboBox comboBox_CurCell_Sheet;
        private System.Windows.Forms.CheckBox checkBox_CurCell_Range;
        private System.Windows.Forms.Button button_Clear_CurCell_2;
        private System.Windows.Forms.Button button_Clear_CurCell_1;
        private System.Windows.Forms.Button button_Range_CurCell;
        private System.Windows.Forms.Button button_ActiveCell_CurCell_2;
        private System.Windows.Forms.Button button_ActiveCell_CurCell_1;
        private System.Windows.Forms.TextBox textBox_CurCell_2;
        private System.Windows.Forms.TextBox textBox_CurCell_1;
        private System.Windows.Forms.Button button_Import;
        private System.Windows.Forms.Button button_Export;
    }
}