using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tables
{
    public partial class ExcelConnecting1 : Form
    {
        public ExcelHandler excel;
        public Form1 f1;
        int CurRange_LastLineN, CurRange_FirstLineN, CurRange_LastColumnN, CurRange_FirstColumnN;
        public ExcelConnecting1()
        {
            InitializeComponent();
            //
            //excel = new ExcelHandler();
            //this.excel =f1.excel;
            this.excel = null;
            //
            //
            checkBox_SupplData.Checked=false;
            //
            checkBox_TblHdr_range.Checked = false;
            checkBox_TblHdr_range.Checked = false;
            checkBox_TblHdr_range.Checked = false;
            checkBox_TblHdr_range.Checked = false;
            //
            checkBox_ColGenHdr_range.Checked = false;
            checkBox_ColGenHdr_range.Checked = false;
            checkBox_ColGenHdr_range.Checked = false;
            checkBox_ColGenHdr_range.Checked = false;
            //
            checkBox_LinGenHdr_range.Checked = false;
            checkBox_LinGenHdr_range.Checked = false;
           checkBox_LinGenHdr_range.Checked = false;
            checkBox_LinGenHdr_range.Checked = false;
            //
            checkBox_TblHdr.Checked = false;
            checkBox_CGH.Checked = false;
             checkBox_LGH.Checked = false;
            checkBox_CurCell_ToWorkWith.Checked = false;
            //
            checkBox_CoLH.Checked = true;
            checkBox_LoCH.Checked = true;
            checkBox_HdrsCrnr.Checked = true;
            //
            comboBox_ActiveN.Items.Clear();
            comboBox_ActiveN.Items.Add("1");
            comboBox_ActiveN.Text = comboBox_ActiveN.Items[1 - 1].ToString();
            //
            comboBox_CurCellType.Text = comboBox_CurCellType.Items[1 - 1].ToString();
            //
            CurRange_LastLineN = 0;
            CurRange_FirstLineN = 0;
            CurRange_LastColumnN=0;
            CurRange_FirstColumnN=0;
            //
            this.radioButton_Whole.Checked = true;
        }

       

        private void button_Range_General_Click(object sender, EventArgs e)
        {
            TValsShowHide vsh = f1.vsh;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            int QColumnsSelected = 0, QLinesSelected = 0;
            int FirstContentColumnN = 0, FirstContentLineN = 0, LastContentColumnN = 0, LastContentLineN = 0;
            string erst, last, adrs, crnr;
            adrs = this.excel.GetSelectedAddress();
            MyLib.writeln(vsh, "selected: " + adrs);
            this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, vsh);
            TRangeSelectedNs RangeSelectedNs = new TRangeSelectedNs();
            RangeSelectedNs.Set(FirstSelectedColumnN, FirstSelectedLineN, LastSelectedColumnN, LastSelectedLineN, MyLib.BoolToInt(this.checkBox_LoCH.Checked), MyLib.BoolToInt(this.checkBox_CoLH.Checked));
            //
            //this.textBox_Hdr2.Text = "";
            //this.textBox_CGH.Text = "";
            //
            if (this.checkBox_LoCH.Checked == true)
            {
                erst = this.excel.CellNameOfNs(RangeSelectedNs.FirstLoCHColN, RangeSelectedNs.FirstLoCHLineN);
                last = this.excel.CellNameOfNs(RangeSelectedNs.LastLoCHColN, RangeSelectedNs.LastLoCHLineN);
                this.textBox_LoCH_erst.Text = erst;
                this.textBox_LoCH_last.Text = last;
            }
            else
            {
                this.textBox_LoCH_erst.Text = "";
                this.textBox_LoCH_last.Text = "";
            }
            //
            if (this.checkBox_CoLH.Checked == true)
            {
                erst = this.excel.CellNameOfNs(RangeSelectedNs.FirstCoLHColN, RangeSelectedNs.FirstCoLHLineN);
                last = this.excel.CellNameOfNs(RangeSelectedNs.LastCoLHColN, RangeSelectedNs.LastCoLHLineN);
                this.textBox_CoLH_erst.Text = erst;
                this.textBox_CoLH_last.Text = last;
            }
            else
            {
                this.textBox_CoLH_erst.Text = "";
                this.textBox_CoLH_last.Text = "";
            }
            //
            if (this.checkBox_LoCH.Checked == true && this.checkBox_CoLH.Checked == true)
            {
                crnr = this.excel.CellNameOfNs(RangeSelectedNs.FirstSelectedColN, RangeSelectedNs.FirstSelectedLineN);
                this.textBox_HdrCorner.Text = crnr;
            }
            else
            {
                this.textBox_HdrCorner.Text = "";
            }
            //
            erst = this.excel.CellNameOfNs(RangeSelectedNs.FirstContentColN, RangeSelectedNs.FirstContentLineN);
            last = this.excel.CellNameOfNs(RangeSelectedNs.LastContentColN, RangeSelectedNs.LastContentLineN);
            this.textBox_content_erst.Text = erst;
            this.textBox_content_last.Text = last;
            //
            //this.comboBox_Hdr1.SelectedIndex = 0;//corner
            //this.comboBox_Hdr2.SelectedIndex = 0; //nil
            this.checkBox_CGH.Checked = false;
            //
            //this.comboBox_Content_Sheet.Items.Clear();
            //this.comboBox_CoLH_Sheet.Items.Clear();
            //this.comboBox_LoCH_Sheet.Items.Clear();
            //this.comboBox_HdrCrnr_Sheet.Items.Clear();
            //for (int i = 1; i <= this.excel.GetQSheets(); i++)
            //{
            //    this.comboBox_Content_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
            //    this.comboBox_CoLH_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
            //    this.comboBox_LoCH_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
            //    this.comboBox_HdrCrnr_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
            //}
            this.comboBox_Content_Sheet.Text = this.excel.GetActiveSheetName();
            this.comboBox_CoLH_Sheet.Text = this.excel.GetActiveSheetName();
            this.comboBox_LoCH_Sheet.Text = this.excel.GetActiveSheetName();
            this.comboBox_HdrCrnr_Sheet.Text = this.excel.GetActiveSheetName();
        }

        private void button_ActiveCell_Content_begin_Click(object sender, EventArgs e)
        {
            int L, C;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_content_erst.Text = name;
                //
                //this.comboBox_Content_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_Content_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_Content_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_ActiveCell_Content_end_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_content_last.Text = name;
                //
                //this.comboBox_Content_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_Content_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_Content_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_Cnt_1_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_content_erst.Text = "";
        }

        private void button_Cnt_2_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_content_last.Text = "";
        }

        private void button_Range_Content_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string erst, last;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                erst = this.excel.GetTopLeftSelection();
                last = this.excel.GetBottomRightSelection();
                this.textBox_content_erst.Text = erst;
                this.textBox_content_last.Text = last;
                //
                //this.comboBox_Content_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_Content_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_Content_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_CoLH_1_Clear_Click(object sender, EventArgs e)
        {
            textBox_CoLH_erst.Text = "";
        }

        private void button_CoLH_2_Clear_Click(object sender, EventArgs e)
        {
            textBox_CoLH_last.Text = "";
        }

        private void button_ActiveCell_CoLH_begin_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_CoLH_erst.Text = name;
                //
                //this.comboBox_CoLH_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_CoLH_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_CoLH_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_ActiveCell_CoLH_end_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_CoLH_last.Text = name;
                //
                //this.comboBox_CoLH_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_CoLH_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_CoLH_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_Range_ColOfLineHeader_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string erst, last;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                erst = this.excel.GetTopLeftSelection();
                last = this.excel.GetBottomRightSelection();
                this.textBox_CoLH_erst.Text = erst;
                this.textBox_CoLH_last.Text = last;
                //
                //this.comboBox_CoLH_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_CoLH_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_CoLH_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_ActiveCell_LoCH_begin_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_LoCH_erst.Text = name;
                //
                //this.comboBox_LoCH_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_LoCH_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_LoCH_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_ActiveCell_LoCH_end_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_LoCH_last.Text = name;
                //
                //this.comboBox_LoCH_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_LoCH_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_LoCH_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_Range_LineOfColHeader_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string erst, last;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                erst = this.excel.GetTopLeftSelection();
                last = this.excel.GetBottomRightSelection();
                this.textBox_LoCH_erst.Text = erst;
                this.textBox_LoCH_last.Text = last;
                //
                //this.comboBox_LoCH_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_LoCH_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_LoCH_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_Headers_ActiveCell_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_HdrCorner.Text = name;
                //comboBox_HdrCrnr_Sheet
                //this.comboBox_HdrCrnr_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_HdrCrnr_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_HdrCrnr_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void ExcelConnecting1_Shown(object sender, EventArgs e)
        {
            this.excel = f1.excel;
            string itemname;
            //
            if(this.excel.GetEtappe()==1){
                this.comboBox_Content_Sheet.Items.Clear();
                this.comboBox_CoLH_Sheet.Items.Clear();
                this.comboBox_LoCH_Sheet.Items.Clear();
                this.comboBox_HdrCrnr_Sheet.Items.Clear();
                //
                this.comboBox_TableHeader_Sheet.Items.Clear();
                this.comboBox_ColsGenHdr_Sheet.Items.Clear();
                this.comboBox_LinesGenHeader_Sheet.Items.Clear();
                this.comboBox_CurCell_Sheet.Items.Clear();
                for (int i = 1; i <= this.excel.GetQSheets(); i++)
                {
                    itemname = this.excel.GetNameOfSheetN(i);
                    //
                    this.comboBox_Content_Sheet.Items.Add(itemname);
                    this.comboBox_CoLH_Sheet.Items.Add(itemname);
                    this.comboBox_LoCH_Sheet.Items.Add(itemname);
                    this.comboBox_HdrCrnr_Sheet.Items.Add(itemname);
                    //
                    this.comboBox_TableHeader_Sheet.Items.Add(itemname);
                    this.comboBox_ColsGenHdr_Sheet.Items.Add(itemname);
                    this.comboBox_LinesGenHeader_Sheet.Items.Add(itemname);
                    this.comboBox_CurCell_Sheet.Items.Add(itemname);
                }
                //this.comboBox_Content_Sheet.Text = this.excel.GetActiveSheetName();
                //this.comboBox_CoLH_Sheet.Text = this.excel.GetActiveSheetName();
                //this.comboBox_LoCH_Sheet.Text = this.excel.GetActiveSheetName();
                //this.comboBox_HdrCrnr_Sheet.Text = this.excel.GetActiveSheetName();
            }
            //
            ToShow();
        }
               

        private void button_LoCH_1_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_LoCH_erst.Text = "";
        }

        private void button_LoCH_2_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_LoCH_last.Text = "";
        }

        private void button_Hdrs_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_HdrCorner.Text = "";
        }

        private void ToShow()
        {
            //
            //checkBox_TblHdr.Visible = checkBox_SupplData.Checked;
            groupBox_SupplInf.Visible = checkBox_SupplData.Checked;
            //
            //
            textBox_TblHdr_2 .Visible= checkBox_TblHdr_range.Checked;
            button_TH_2_Clear.Visible = checkBox_TblHdr_range.Checked;
            button_ActiveCell_TblHdr_end.Visible = checkBox_TblHdr_range.Checked;
            button_Range_TblHdr.Visible = checkBox_TblHdr_range.Checked;
            //
            textBox_ColGenHdr_2.Visible = checkBox_ColGenHdr_range.Checked;
            button_CGH_2_Clear.Visible = checkBox_ColGenHdr_range.Checked;
            button_ActiveCell_ColsGenHdr_end.Visible = checkBox_ColGenHdr_range.Checked;
            button_Range_ColsGenHdr.Visible = checkBox_ColGenHdr_range.Checked;
            //
            textBox_LinGenHdr_2.Visible = checkBox_LinGenHdr_range.Checked;
            button_LGH_2_Clear.Visible = checkBox_LinGenHdr_range.Checked;
            button_ActiveCell_LinesGenHdr_end.Visible = checkBox_LinGenHdr_range.Checked;
            button_Range_LinesGenHdr.Visible = checkBox_LinGenHdr_range.Checked;
            //
            textBox_CurCell_2.Visible=checkBox_CurCell_Range.Checked;
            button_Clear_CurCell_2.Visible = checkBox_CurCell_Range.Checked;
            button_ActiveCell_CurCell_2.Visible = checkBox_CurCell_Range.Checked;
            button_Range_CurCell.Visible = checkBox_CurCell_Range.Checked;
            //
            groupBox_TableHeader.Visible = checkBox_TblHdr.Checked;
            groupBox_CGH.Visible = checkBox_CGH.Checked;
            groupBox_LGH.Visible = checkBox_LGH.Checked;
            groupBox_CurCell.Visible = checkBox_CurCell_ToWorkWith.Checked;
            //
            comboBox_ActiveN.Visible = checkBox_CurCellActiveValNotDefault.Checked && checkBox_CurCell_Range.Checked;// && checkBox_ActiveValFromExcel.Checked == false;//
            checkBox_CurCellActiveValFromExcel.Visible = checkBox_CurCellActiveValNotDefault.Checked && checkBox_CurCell_Range.Checked; ;
            //
            checkBox_CurCellActiveValNotDefault.Visible = checkBox_CurCell_Range.Checked;
            textBox_ActiveVal.Visible = checkBox_CurCellActiveValNotDefault.Checked && checkBox_CurCellActiveValFromExcel.Checked && checkBox_CurCell_Range.Checked;
            button_Clear_ActiveCellActiveVal.Visible = checkBox_CurCellActiveValNotDefault.Checked && checkBox_CurCellActiveValFromExcel.Checked && checkBox_CurCell_Range.Checked;
            button_ActiveCell_ActiveCell.Visible = checkBox_CurCellActiveValNotDefault.Checked && checkBox_CurCellActiveValFromExcel.Checked && checkBox_CurCell_Range.Checked;;
            //
            groupBox_CoLH.Visible=checkBox_CoLH.Checked;
            groupBox_LoCH.Visible = checkBox_LoCH.Checked;
            groupBox_HdrCrnr.Visible = checkBox_HdrsCrnr.Checked;
        }

        private void checkBox_SupplData_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_TblHdr_range_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_CGH_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_CoLH_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_TblHdr_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_ColGenHdr_range_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_LGH_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_LinGenHdr_range_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_CurCell_ToWorkWith_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_CurCell_Range_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_CoLH_CheckedChanged_1(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_LoCH_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_HdrsCrnr_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_TblHdr_CheckedChanged_1(object sender, EventArgs e)
        {
            ToShow();
        }

        private void button_ActiveCell_TblHdr_begin_Click(object sender, EventArgs e)
        {
            int L, C;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_TblHdr_1.Text = name;
                //
                //this.comboBox_TableHeader_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_TableHeader_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_TableHeader_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_ActiveCell_TblHdr_end_Click(object sender, EventArgs e)
        {
            int L, C;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_TblHdr_2.Text = name;
                //
                //this.comboBox_TableHeader_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_TableHeader_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_TableHeader_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_Range_TblHdr_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string erst, last;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                erst = this.excel.GetTopLeftSelection();
                last = this.excel.GetBottomRightSelection();
                this.textBox_TblHdr_1.Text = erst;
                this.textBox_TblHdr_2.Text = last;
                //
                //this.comboBox_TableHeader_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_TableHeader_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_TableHeader_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_TH_1_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_TblHdr_1.Text = "";
        }

        private void button_TH_2_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_TblHdr_2.Text = "";
        }

        private void checkBox_ActiveValNotDefault_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void checkBox_ActiveValFromExcel_CheckedChanged(object sender, EventArgs e)
        {
            ToShow();
        }

        private void button_ActiveCell_CurCell_1_Click(object sender, EventArgs e)
        {
            int L, C;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_CurCell_1.Text = name;
                //
                //this.comboBox_CurCell_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_CurCell_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_CurCell_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_ActiveCell_ColsGenHdr_begin_Click(object sender, EventArgs e)
        {
            int L, C;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_ColGenHdr_1.Text = name;
                //
                //this.comboBox_ColsGenHdr_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_ColsGenHdr_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_ColsGenHdr_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_ActiveCell_ColsGenHdr_end_Click(object sender, EventArgs e)
        {
            int L, C;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_ColGenHdr_2.Text = name;
                //
                //this.comboBox_ColsGenHdr_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_ColsGenHdr_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_ColsGenHdr_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_Range_ColsGenHdr_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string erst, last;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                erst = this.excel.GetTopLeftSelection();
                last = this.excel.GetBottomRightSelection();
                this.textBox_ColGenHdr_1.Text = erst;
                this.textBox_ColGenHdr_2.Text = last;
                //
                //this.comboBox_ColsGenHdr_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_ColsGenHdr_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_ColsGenHdr_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_Range_LinesGenHdr_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string erst, last;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                erst = this.excel.GetTopLeftSelection();
                last = this.excel.GetBottomRightSelection();
                this.textBox_LinGenHdr_1.Text = erst;
                this.textBox_LinGenHdr_2.Text = last;
                //
                //this.comboBox_LinesGenHeader_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_LinesGenHeader_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_LinesGenHeader_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_ActiveCell_LinesGenHdr_begin_Click(object sender, EventArgs e)
        {
            int L, C;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_LinGenHdr_1.Text = name;
                //
                //this.comboBox_LinesGenHeader_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_LinesGenHeader_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_LinesGenHeader_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_ActiveCell_LinesGenHdr_end_Click(object sender, EventArgs e)
        {
            int L, C;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_LinGenHdr_2.Text = name;
                //
                //this.comboBox_LinesGenHeader_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_LinesGenHeader_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_LinesGenHeader_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_ActiveCell_CurCell_2_Click(object sender, EventArgs e)
        {
            int L, C;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_CurCell_2.Text = name;
                //
                //this.comboBox_CurCell_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_CurCell_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_CurCell_Sheet.Text = this.excel.GetActiveSheetName();
            }
        }

        private void button_Range_CurCell_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            int QLines=0, QColumns=0, QCells = 0;
            string erst="", last="";
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                erst = this.excel.GetTopLeftSelection();
                last = this.excel.GetBottomRightSelection();
                this.textBox_CurCell_1.Text = erst;
                this.textBox_CurCell_2.Text = last;
                //
                //this.comboBox_CurCell_Sheet.Items.Clear();
                //for (int i = 1; i <= this.excel.GetQSheets(); i++)
                //{
                //    this.comboBox_CurCell_Sheet.Items.Add(this.excel.GetNameOfSheetN(i));
                //}
                this.comboBox_CurCell_Sheet.Text = this.excel.GetActiveSheetName();
                //
                //public void ParseCellName(string CellName, ref int ColN, ref int LineN)
                if (erst.Equals("")==false && last.Equals("")==false){
                    this.excel.ParseCellName(erst, ref FirstSelectedColumnN, ref FirstSelectedLineN);
                    this.excel.ParseCellName(last, ref LastSelectedColumnN, ref LastSelectedLineN);
                }else if (erst.Equals("")==false && last.Equals("")){
                    this.excel.ParseCellName(erst, ref FirstSelectedColumnN, ref FirstSelectedLineN);
                    //this.excel.ParseCellName(last, ref LastSelectedColumnN, ref LastSelectedLineN);
                    LastSelectedColumnN = FirstSelectedColumnN;
                    LastSelectedLineN = FirstSelectedLineN;
                }else if (erst.Equals("") && last.Equals("")==false){
                    //this.excel.ParseCellName(erst, ref FirstSelectedColumnN, ref FirstSelectedLineN);
                    this.excel.ParseCellName(last, ref LastSelectedColumnN, ref LastSelectedLineN);
                    FirstSelectedColumnN = LastSelectedColumnN;
                    FirstSelectedLineN = LastSelectedLineN;
                }else {//tbi==""
                    //this.excel.ParseCellName(erst, ref FirstSelectedColumnN, ref FirstSelectedLineN);
                    //this.excel.ParseCellName(erst, ref FirstSelectedColumnN, ref FirstSelectedLineN);
                }
                QLines = LastSelectedLineN - FirstSelectedLineN + 1;
                QColumns = LastSelectedColumnN - FirstSelectedColumnN + 1;
                QCells=QLines>=QColumns?QLines:QColumns;
                QCells = QLines * QColumns;
                //
                if(QCells>0){
                    this.comboBox_ActiveN.Items.Clear();
                    for(int i=1; i<=QCells; i++){
                        this.comboBox_ActiveN.Items.Add(i.ToString());
                    }
                }
                CurRange_LastLineN = LastSelectedLineN;
                CurRange_FirstLineN = FirstSelectedLineN;
                CurRange_LastColumnN = LastSelectedColumnN;
                CurRange_FirstColumnN = FirstSelectedColumnN;
            }
        }

        private void button_ActiveCell_ActiveCell_Click(object sender, EventArgs e)
        {
            int L, C;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            int SelectedColumnN = 0, SelectedLineN = 0;
            int ActiveN=0, QItems=0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_ActiveVal.Text = name;
                //no act on combobox
                SelectedColumnN=FirstSelectedColumnN;
                SelectedLineN=FirstSelectedLineN;
                this.excel.ParseCellName(name, ref SelectedLineN, ref SelectedLineN);
                ActiveN=1;
                if (SelectedColumnN <= this.CurRange_FirstColumnN || SelectedColumnN >= this.CurRange_LastColumnN || SelectedLineN <= CurRange_FirstLineN || SelectedLineN >= CurRange_LastLineN)
                {
                    MessageBox.Show("Error: this cell can't be active: it doesn't belong to selected range");
                }
                else
                {
                    if (CurRange_LastLineN < CurRange_FirstLineN)
                    {
                        ActiveN = SelectedLineN - CurRange_FirstLineN+1;
                        QItems = CurRange_LastLineN - CurRange_FirstLineN + 1;
                    }
                    else if (CurRange_LastColumnN < CurRange_FirstColumnN)
                    {
                        ActiveN = SelectedLineN - CurRange_FirstColumnN + 1;
                        QItems = CurRange_LastColumnN - CurRange_FirstColumnN + 1;
                    }
                    if (QItems > 0)
                    {
                        this.comboBox_ActiveN.Items.Clear();
                        for (int i = 1; i <= QItems; i++)
                        {
                            this.comboBox_ActiveN.Items.Add(i.ToString());
                        }
                    }
                    this.comboBox_ActiveN.Text = ActiveN.ToString();
                }
            }
        }

        private void button_CGH_1_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_ColGenHdr_1.Text = "";
        }

        private void button_CGH_2_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_ColGenHdr_2.Text = "";
        }

        private void button_LGH_1_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_LinGenHdr_1.Text = "";
        }

        private void button_LGH_2_Clear_Click(object sender, EventArgs e)
        {
            this.textBox_LinGenHdr_2.Text = "";
        }

        private void button_Clear_CurCell_1_Click(object sender, EventArgs e)
        {
            this.textBox_CurCell_1.Text = "";
        }

        private void button_Clear_CurCell_2_Click(object sender, EventArgs e)
        {
            this.textBox_CurCell_2.Text = "";
        }

        private void button_Clear_ActiveCellActiveVal_Click(object sender, EventArgs e)
        {
            this.textBox_ActiveVal.Text = "";
        }

        private void button_Import_Click(object sender, EventArgs e)
        {
            TRangeSelectedNs RangeSelectedNs = new TRangeSelectedNs();
            //
            TExcelTableFitFormData FormData=null;
            TExcelTableFitInfo TableData = null;
            string ContentFirst, ContentLast, LoCHFirst, LoCHLast, CoLHFirst, CoLHLast, 
                   HeaderCorner, CurCellFirst, CurCellLast, CurCellActiveVal,
                   TblHdrFirst, TblHdrLast, ColGenHdrFirst, LinGenHdrFirst, LinGenHdrLast;
            string val;
            //int CCAV_FirstLineN, CCAV_LastLineN, CCAV_FirstColN, CCAV_LastColN;
            int CCAV_LineN=0, CCAV_ColN=0;
            //int ContentFirst_LineN, ContentFirst_ColN, ContentLast,
            //    LoCHFirst, LoCHFirst,
            //    LoCHLast, LoCHLast,
            //    CoLHFirst, CoLHFirst,
            //    CoLHLast, CoLHLast,
            //    HeaderCorner, HeaderCorner, 
            //    CurCellFirst, CurCellFirst,
            //    CurCellLast, CurCellLast,
            //    CurCellActiveVal, CurCellActiveVal,
            //    TblHdrFirst, 
            //    TblHdrLast, 
            //    ColGenHdrFirst, 
            //    LinGenHdrFirst, 
            //    LinGenHdrLast;
            if (this.radioButton_CurCell.Checked)
            {
                CurCellFirst = this.textBox_CurCell_1.Text;
                if (this.checkBox_CurCell_Range.Checked)
                {
                    CurCellLast = this.textBox_CurCell_2.Text;
                }else{
                    CurCellLast = CurCellFirst;
                }
                CurCellActiveVal = this.textBox_ActiveVal.Text;
                this.excel.ParseCellName(CurCellActiveVal, ref CCAV_ColN, ref CCAV_LineN);
                val = this.excel.ReadFormulaFromExcelCell(this.excel.GetActiveSheetName(), CCAV_ColN, CCAV_LineN);
                MessageBox.Show(val);
            }else{
                //ContentFirst = this.textBox_content_erst.Text;
                //this.excel.ParseCellName(ContentFirst, ref ContentFirst, ref CCAV_LineN);
                //
                //TExcelTableFitFormData FormData=null;//above
                //TExcelTableFitInfo TableData = null;//above
                FormData = new TExcelTableFitFormData();
                FormData = this.ReadTableDataFromForm();
                TableData = new TExcelTableFitInfo();
                TableData.SetFromFormData(FormData, this.excel);
            }
        }

        public TExcelTableFitFormData ReadTableDataFromForm()
        {
            //TExcelTableFitInfo data = new TExcelTableFitInfo();
            TExcelTableFitFormData data=new TExcelTableFitFormData();
            //string ContentFirst, ContentLast, CoLHFirst, CoLHLast, LoCHFirst, LoCHLast, HdrCrnr, TblHdrFirst, TblHdrLast,
            //       ColGenHdrFirst, ColGenHdrLast, LinGenHdrFirst, LinGenHdrLast, CurCellFirst, CurCellLast, CurCellActiveVal;
            //string  ContentSheet,  CoLHSheet,  LoCHSheet, HdrCrnrSheet,  TblHdrSheet,
            //        ColGenHdrSheet,  LinGenHdrSheet,  CurCellSheet;
            //int ContentFirstLineN, ContentLastLineN, CoLHFirstLineN, CoLHLastLineN, LoCHFirstLineN, LoCHLastLineN, HdrCrnrLineN, TblHdrFirstLineN, TblHdrLastLineN,
            //    ColGenHdrFirstLineN, ColGenHdrLastLineN, LinGenHdrFirstLineN, LinGenHdrLastLineN, CurCellFirstLineN, CurCellLastLineN, CurCellActiveValLineN,
            //    ContentFirstColN, ContentLastColN, CoLHFirstColN, CoLHLastColN, LoCHFirstColN, LoCHLastColN, HdrCrnrColN, TblHdrFirstColN, TblHdrLastColN,
            //    ColGenHdrFirstColN, ColGenHdrLastColN, LinGenHdrFirstColN, LinGenHdrLastColN, CurCellFirstColN, CurCellLastColN, CurCellActiveValColN;
            data.ContentFirst = this.textBox_content_erst.Text;
            data.ContentLast = this.textBox_content_last.Text;
            data.CoLHFirst = this.textBox_CoLH_erst.Text;
            data.CoLHLast = this.textBox_CoLH_last.Text;
            data.LoCHFirst = this.textBox_LoCH_erst.Text;
            data.LoCHLast = this.textBox_LoCH_last.Text;
            data.HdrCrnr = this.textBox_HdrCorner.Text;
            data.TblHdrFirst = this.textBox_TblHdr_1.Text;
            data.TblHdrLast = this.textBox_TblHdr_2.Text;
            data.ColGenHdrFirst = this.textBox_ColGenHdr_1.Text;
            data.ColGenHdrLast = this.textBox_ColGenHdr_2.Text;
            data.LinGenHdrFirst = this.textBox_LinGenHdr_1.Text;
            data.LinGenHdrLast = this.textBox_LinGenHdr_2.Text;
            data.CurCellFirst = this.textBox_CurCell_1.Text;
            data.CurCellLast = this.textBox_CurCell_2.Text;
            if (data.CurCellLast.Equals(""))
            {
                data.CurCellLast = data.CurCellFirst;
            }
            data.CurCellActiveVal = this.textBox_ActiveVal.Text;
            //
            data.ContentSheet = this.comboBox_Content_Sheet.Text;
            data.CoLHSheet = this.comboBox_CoLH_Sheet.Text;
            data.LoCHSheet = this.comboBox_LoCH_Sheet.Text;
            data.HdrCrnrSheet = this.comboBox_HdrCrnr_Sheet.Text;
            data.TblHdrSheet = this.comboBox_TableHeader_Sheet.Text;
            data.ColGenHdrSheet = this.comboBox_ColsGenHdr_Sheet.Text;
            data.LinGenHdrSheet = this.comboBox_LinesGenHeader_Sheet.Text;
            data.CurCellSheet = this.comboBox_CurCell_Sheet.Text;
            //
            data.CurCellType=this.comboBox_CurCellType.Text;
            data.CurCellTypeN=this.comboBox_CurCellType.SelectedIndex;
            //
            data.CoLHEachLineDataVertical = this.checkBox_CoLH_EachLineData_Vert.Checked;
            data.LoCHEachColumnDataHorisontal = this.checkBox_LoCH_EachColData_Hor.Checked;
            //
            data.CoLHDataPresent = this.checkBox_CoLH.Checked;
            data.LoCHDataPresent = this.checkBox_LoCH.Checked;
            data.TblHdrDataPresent = this.checkBox_TblHdr.Checked;//added
            data.ColGenHdrDataPresent = this.checkBox_CGH.Checked;//added
            data.LinGenHdrDataPresent = this.checkBox_LGH.Checked;//added
            data.CurCellDataPresent = this.checkBox_CurCell_ToWorkWith.Checked;//added
            //
            data.ContentExportDBData=this.checkBox_Content_ExportDBData.Checked;
            //data.ContentDBType=this.
            data.CoLHExportDBData=this.checkBox_CoLH_ExportDBData.Checked;
            data.CoLHDBType=this.checkBox_CoLH_DBType.Checked;
            data.CoLH1stOnly=this.checkBox_CoLH_1stOnly.Checked;
            data.CoLHEachLineDataVertical=this.checkBox_CoLH_EachLineData_Vert.Checked;
            data.LoCHExportDBData=this.checkBox_LoCH_ExportDBData.Checked;
            data.LoCHDBType=this.checkBox_LoCH_DBType.Checked;
            data.LoCH1stOnly=this.checkBox_LoCH_1stOnly.Checked;
            data.LoCHEachColumnDataHorisontal=this.checkBox_LoCH_EachColData_Hor.Checked;
            data.HdrCrnrExportDBData=this.checkBox_CrnrHdrs_ExportDBData.Checked;
            data.HdrCrnrDBType=this.checkBox_CrnrHdrs_DBType.Checked;
            data.TblHdrExportDBData=this.checkBox_TblHdr_ExportDBData.Checked;
            data.TblHdrDBType=this.checkBox_TblHdr_DBType.Checked;
            data.ColGenHdrExportDBData=this.checkBox_CGH_ExportDBData.Checked;
            data.ColGenHdrDBType=this.checkBox_CGH_DBType.Checked;
            data.LinGenHdrExportDBData=this.checkBox_LGH_ExportDBData.Checked;
            data.LinGenHdrDBType=this.checkBox_LGH_DBType.Checked;
            data.CurCellExportDBData=this.checkBox_CurCell_ExportDBData.Checked;
            //data.CurCellDBType=this
            data.CurCellActiveValNotDefault=this.checkBox_CurCellActiveValNotDefault.Checked;
            data.CurCellActiveValExcelCell = this.checkBox_CurCellActiveValFromExcel.Checked;
            //data.
            if (!data.ContentFirst.Equals(data.ContentLast))
            {
                if (!data.CurCellActiveValNotDefault)
                {
                    data.CurCellActiveN = 1;
                    //data.CurCellActiveVal
                }
                else
                {
                    //if(!data.CurCellActiveValExcelCell)
                }
            }
            //
            
            //
            return data;
        }

        private void ExcelConnecting1_Load(object sender, EventArgs e)
        {

        }

        private void button_Export_Click(object sender, EventArgs e)
        {

        }

    }//cl
}//ns