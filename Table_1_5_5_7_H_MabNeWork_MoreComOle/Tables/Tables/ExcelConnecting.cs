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
    public partial class ExcelConnecting : Form
    {
        public ExcelHandler excel;
        public Form1 f1;
        public ExcelConnecting()
        {
            InitializeComponent();
            //
            excel=new ExcelHandler();
        }

        private void ToShow()
        {
            this.comboBox_Hdr1.Visible = false;
            this.checkBox_Hdrs.Visible = false;
            this.checkBox_Hdrs.Checked = true;
            //this
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            excel.CreateNewExcelDoc();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int L, C;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            if (excel.GetEtappe() == 1)
            {
                this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
                name = this.excel.GetTopLeftSelection();
                this.textBox_content_erst.Text = name;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TValsShowHide vsh=f1.vsh;
            int FirstSelectedColumnN=0, FirstSelectedLineN=0, LastSelectedColumnN=0, LastSelectedLineN=0;
            int QColumnsSelected=0, QLinesSelected=0;
            int FirstContentColumnN = 0, FirstContentLineN = 0, LastContentColumnN = 0, LastContentLineN = 0;
            string erst, last, adrs, crnr;
            adrs = this.excel.GetSelectedAddress();
            MyLib.writeln(vsh, "selected: " + adrs);
            this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, vsh);
            TRangeSelectedNs RangeSelectedNs=new TRangeSelectedNs();
            RangeSelectedNs.Set(FirstSelectedColumnN, FirstSelectedLineN, LastSelectedColumnN, LastSelectedLineN, MyLib.BoolToInt(this.checkBox_LoCH.Checked), MyLib.BoolToInt(this.checkBox_CoLH.Checked));
            //
            this.textBox_Hdr2.Text = "";
            this.textBox_CGH.Text = "";
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
            this.comboBox_Hdr1.SelectedIndex = 0;//corner
            this.comboBox_Hdr2.SelectedIndex = 0; //nil
            this.checkBox_CGH.Checked = false;
        }//fn

        private void button_Range_Content_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN=0,  FirstSelectedLineN=0,  LastSelectedColumnN=0,  LastSelectedLineN=0;
            string erst, last;
            this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            erst = this.excel.GetTopLeftSelection();
            last = this.excel.GetBottomRightSelection();
            this.textBox_content_erst.Text = erst;
            this.textBox_content_last.Text = last;
        }

        private void button_Headers_ActiveCell_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            name = this.excel.GetTopLeftSelection();
            this.textBox_HdrCorner.Text = name;
        }

        private void button_ActiveCell_Content_enв_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            name = this.excel.GetTopLeftSelection();
            this.textBox_content_last.Text = name;
        }

        private void button_ActiveCell_LoCH_begin_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            name = this.excel.GetTopLeftSelection();
            this.textBox_LoCH_erst.Text = name;
        }

        private void button_ActiveCell_LoCH_end_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            name = this.excel.GetTopLeftSelection();
            this.textBox_LoCH_last.Text = name;
        }

        private void button_ActiveCell_CoLH_begin_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            name = this.excel.GetTopLeftSelection();
            this.textBox_CoLH_erst.Text = name;
        }

        private void button_ActiveCell_CoLH_end_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            name = this.excel.GetTopLeftSelection();
            this.textBox_CoLH_last.Text = name;
        }

        private void button_Import_Click(object sender, EventArgs e)
        {
            /*
            TRangeSelectedNs RangeSelectedNs = new TRangeSelectedNs();
            //int FirstColN, FirstLineN, LastColN, LastLineN, ColN, LineN;
            //int contentFirstColN, contentFirstLineN, contentLastColN, contentLastLineN, 
            //    LoCHFirstColN, LoCHFirstLineN, LoCHLastColN, LoCHLastLineN, 
            //    CoLHFirstColN, CoLHFirstLineN, CoLHLastColN, CoLHLastLineN, 
            //    HeaderCornerColN, HeaderCornerLineN;
            string ContentFirst, ContentLast, LoCHFirst, LoCHLast, CoLHFirst, CoLHLast, HeaderCorner, HeaderLast, HeaderCGH;
            string[] HdrParams = null;
            //RangeSelectedNs;
            ContentFirst = this.textBox_content_erst.Text;
            ContentLast = this.textBox_content_last.Text;
            LoCHFirst = this.textBox_LoCH_erst.Text;
            LoCHLast = this.textBox_LoCH_last.Text;
            CoLHFirst = this.textBox_CoLH_erst.Text;
            CoLHLast = this.textBox_CoLH_last.Text;
            HeaderCorner = this.textBox_HdrCorner.Text;
            //
            RangeSelectedNs.FirstContentColN = this.excel.ColNOfCellNameParsing(ContentFirst);
            RangeSelectedNs.FirstContentLineN = this.excel.LineNOfCellNameParsing(ContentFirst);
            RangeSelectedNs.LastContentColN = this.excel.ColNOfCellNameParsing(ContentLast);
            RangeSelectedNs.LastContentLineN = this.excel.LineNOfCellNameParsing(ContentLast);
            RangeSelectedNs.FirstLoCHColN= this.excel.ColNOfCellNameParsing(LoCHFirst);
            RangeSelectedNs.FirstLoCHLineN = this.excel.LineNOfCellNameParsing(LoCHFirst);
            RangeSelectedNs.LastLoCHColN = this.excel.ColNOfCellNameParsing(LoCHLast);
            RangeSelectedNs.LastLoCHLineN = this.excel.LineNOfCellNameParsing(LoCHLast);
            //
            RangeSelectedNs.FirstCoLHColN = this.excel.ColNOfCellNameParsing(CoLHFirst);
            RangeSelectedNs.FirstCoLHLineN = this.excel.LineNOfCellNameParsing(CoLHFirst);
            RangeSelectedNs.LastCoLHColN = this.excel.ColNOfCellNameParsing(CoLHLast);
            RangeSelectedNs.LastCoLHLineN = this.excel.LineNOfCellNameParsing(CoLHLast);
            //
            RangeSelectedNs.QLoCHs = RangeSelectedNs.LastLoCHLineN - RangeSelectedNs.FirstLoCHLineN;
            //
            if (this.textBox_CGH.Text != "")
            {
                HeaderCGH=this.textBox_CGH.Text;
                HeaderLast=this.textBox_Hdr2.Text;
                HeaderCorner=this.textBox_HdrCorner.Text;
                //
                RangeSelectedNs.HdrCGHColN = this.excel.ColNOfCellNameParsing(HeaderCGH);
                RangeSelectedNs.HdrCGHLineN = this.excel.LineNOfCellNameParsing(HeaderCGH);
                //
                RangeSelectedNs.LastHdrColN = this.excel.ColNOfCellNameParsing(HeaderLast);
                RangeSelectedNs.LastHdrLineN = this.excel.LineNOfCellNameParsing(HeaderLast);
                //
                RangeSelectedNs.FirstHdrColN = this.excel.ColNOfCellNameParsing(HeaderCorner);
                RangeSelectedNs.FirstHdrLineN = this.excel.LineNOfCellNameParsing(HeaderCorner);
                //
                RangeSelectedNs.HdrCGHLastColN=0;
                RangeSelectedNs.HdrCGHLastLineN=0;
                RangeSelectedNs.HdrLGHColN=0;
                RangeSelectedNs.HdrLGHLineN=0;
                RangeSelectedNs.HdrLGHLastColN=0;
                RangeSelectedNs.HdrLGHLastLineN = 0;
                //
            else//this.textBox_CGH.Text == ""
            {
                if (this.textBox_Hdr2.Text != "")
                {
                    if (this.textBox_HdrCorner.Text != "")
                    {
                        //first...last
                        HeaderCGH = "";
                        HeaderLast = this.textBox_Hdr2.Text;
                        HeaderCorner = this.textBox_HdrCorner.Text;
                        //
                        RangeSelectedNs.HdrCGHColN = 0;
                        RangeSelectedNs.HdrCGHLineN = 0;
                        //
                        RangeSelectedNs.LastHdrColN = this.excel.ColNOfCellNameParsing(HeaderLast);
                        RangeSelectedNs.LastHdrLineN = this.excel.LineNOfCellNameParsing(HeaderLast);
                        //
                        RangeSelectedNs.FirstHdrColN = this.excel.ColNOfCellNameParsing(HeaderCorner);
                        RangeSelectedNs.FirstHdrLineN = this.excel.LineNOfCellNameParsing(HeaderCorner);
                        //
                        RangeSelectedNs.HdrCGHLastColN = 0;
                        RangeSelectedNs.HdrCGHLastLineN = 0;
                        RangeSelectedNs.HdrLGHColN = 0;
                        RangeSelectedNs.HdrLGHLineN = 0;
                        RangeSelectedNs.HdrLGHLastColN = 0;
                        RangeSelectedNs.HdrLGHLastLineN = 0;
                        //

                    }
                    //else impossible
                }
                else//this.textBox_Hdr2.Text == ""
                {
                    if (this.textBox_HdrCorner.Text != "")
                    {
                        //corner only
                        HeaderCGH = "";
                        HeaderLast = "";
                        HeaderCorner = this.textBox_HdrCorner.Text;
                        //
                        RangeSelectedNs.HdrCGHColN = 0;
                        RangeSelectedNs.HdrCGHLineN = 0;
                        //
                        RangeSelectedNs.LastHdrColN = 0;
                        RangeSelectedNs.LastHdrLineN = 0;
                        //
                        RangeSelectedNs.FirstHdrColN = this.excel.ColNOfCellNameParsing(HeaderCorner);
                        RangeSelectedNs.FirstHdrLineN = this.excel.LineNOfCellNameParsing(HeaderCorner);
                        //
                        RangeSelectedNs.HdrCGHLastColN = 0;
                        RangeSelectedNs.HdrCGHLastLineN = 0;
                        RangeSelectedNs.HdrLGHColN = 0;
                        RangeSelectedNs.HdrLGHLineN = 0;
                        RangeSelectedNs.HdrLGHLastColN = 0;
                        RangeSelectedNs.HdrLGHLastLineN = 0;
                        //
                        RangeSelectedNs.QHdrCols = RangeSelectedNs.LastHdrColN - RangeSelectedNs.FirstHdrColN;
                        RangeSelectedNs.QHdrLines = RangeSelectedNs.LastHdrLineN - RangeSelectedNs.FirstHdrLineN;
                        //
                        RangeSelectedNs.QLGHCols = 0;
                        RangeSelectedNs.QLGHLines = 0;
                        RangeSelectedNs.QCGHCols = 0;
                        RangeSelectedNs.QCGHLines = 0;
                    }
                    else//this.textBox_HdrCorner.Text == ""
                    {
                        //no corner even, no headers
                        HeaderCGH = "";
                        HeaderLast = "";
                        HeaderCorner = "";
                        //
                        RangeSelectedNs.HdrCGHColN = 0;
                        RangeSelectedNs.HdrCGHLineN = 0;
                        //
                        RangeSelectedNs.LastHdrColN = 0;
                        RangeSelectedNs.LastHdrLineN = 0;
                        //
                        RangeSelectedNs.FirstHdrColN = 0;
                        RangeSelectedNs.FirstHdrLineN = 0;
                        //
                        RangeSelectedNs.HdrCGHLastColN = 0;
                        RangeSelectedNs.HdrCGHLastLineN = 0;
                        RangeSelectedNs.HdrLGHColN = 0;
                        RangeSelectedNs.HdrLGHLineN = 0;
                        RangeSelectedNs.HdrLGHLastColN = 0;
                        RangeSelectedNs.HdrLGHLastLineN = 0;
                        //
                        
                    }
                }
            }
            this.excel.RangeSelectedNs = RangeSelectedNs;
            //
            */

        }//fn

        private void button_Open_Click(object sender, EventArgs e)
        {

            string fName = "";
            OpenFileDialog openDialog = new OpenFileDialog();
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                fName = openDialog.FileName;
                this.excel. OpenExistingExcelDoc(fName);
            }
        }

        private void button_HdrRng_Click(object sender, EventArgs e)
        {
            //
            int zero = 0;
            string firstCellName, lastCellName, secondCellName="";
            int FirstSelectedColumnN=0, FirstSelectedLineN=0, LastSelectedColumnN=0, LastSelectedLineN=0;
            this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            TRangeSelectedNs RangeSelectedNs = new TRangeSelectedNs();
            RangeSelectedNs.Set(FirstSelectedColumnN, FirstSelectedLineN, LastSelectedColumnN, LastSelectedLineN, MyLib.BoolToInt(this.checkBox_LoCH.Checked), MyLib.BoolToInt(this.checkBox_CoLH.Checked));
            RangeSelectedNs.FirstHdrColN = FirstSelectedColumnN;
            RangeSelectedNs.FirstHdrLineN = FirstSelectedLineN;
            RangeSelectedNs.LastHdrColN = LastSelectedColumnN;
            RangeSelectedNs.LastHdrLineN = LastSelectedLineN;
            RangeSelectedNs.QHdrCols = LastSelectedColumnN - FirstSelectedColumnN;// + 1;
            RangeSelectedNs.QHdrLines = LastSelectedLineN - FirstSelectedLineN ;//+ 1;
            //one cell selected - corner
            if ((RangeSelectedNs.QHdrCols == 0 && RangeSelectedNs.QHdrLines == 1) || (RangeSelectedNs.QHdrCols == 1 && RangeSelectedNs.QHdrLines == 0))
            {
                this.comboBox_Hdr1.SelectedIndex = 0;//corner
                this.comboBox_Hdr2.SelectedIndex = 0; //nil;
                this.checkBox_CGH.Checked = false;
                //
                firstCellName = this.excel.CellNameOfNs(FirstSelectedColumnN, FirstSelectedLineN);
                this.textBox_HdrCorner.Text = firstCellName;
                //
                lastCellName = firstCellName;
                this.textBox_Hdr2.Text = lastCellName;
                this.textBox_CGH.Text = "";
            }
            //three cells selected, horisontally and vertically
            else if ((RangeSelectedNs.QHdrCols == 2 && RangeSelectedNs.QHdrLines == 0) || (RangeSelectedNs.QHdrCols == 0 && RangeSelectedNs.QHdrLines == 2))
            {
                firstCellName = this.excel.CellNameOfNs(FirstSelectedColumnN, FirstSelectedLineN);
                if (RangeSelectedNs.QHdrCols == 2 && RangeSelectedNs.QHdrLines == 0)
                {
                    secondCellName = this.excel.CellNameOfNs(FirstSelectedColumnN+1, FirstSelectedLineN);
                }
                else if (RangeSelectedNs.QHdrCols == 0 && RangeSelectedNs.QHdrLines == 2)
                {
                    secondCellName = this.excel.CellNameOfNs(FirstSelectedColumnN, FirstSelectedLineN + 1);
                }
                lastCellName = this.excel.CellNameOfNs(LastSelectedColumnN, LastSelectedLineN);
                //
                this.textBox_HdrCorner.Text = firstCellName;
                this.textBox_Hdr2.Text = secondCellName;
                this.textBox_CGH.Text = lastCellName;
                //
                this.comboBox_Hdr1.SelectedIndex = 1;//TableName
                this.comboBox_Hdr2.SelectedIndex = 1;//LGH
                this.checkBox_CGH.Checked = true;
            }
            //two or more than three cells selected
            else if (RangeSelectedNs.QHdrCols > 3 || RangeSelectedNs.QHdrLines > 3)
            {
                firstCellName = this.excel.CellNameOfNs(FirstSelectedColumnN, FirstSelectedLineN);
                lastCellName = this.excel.CellNameOfNs(LastSelectedColumnN, LastSelectedLineN);
                //
                this.comboBox_Hdr1.SelectedIndex = 2;//first
                this.comboBox_Hdr2.SelectedIndex = 2;//last
                this.checkBox_CGH.Checked = false;
                //
                this.textBox_HdrCorner.Text = firstCellName;
                this.textBox_Hdr2.Text = lastCellName;
                this.textBox_CGH.Text = "";
            }
        }

        private void button_Hdr2_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            name = this.excel.GetTopLeftSelection();
            this.textBox_Hdr2.Text = name;
        }

        private void button_Hdr3_Click(object sender, EventArgs e)
        {
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            string name;
            this.excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            name = this.excel.GetTopLeftSelection();
            this.textBox_CGH.Text = name;
        }

        private void button_Range_ColOfLineHeader_Click(object sender, EventArgs e)
        {

        }

        private void button_Range_LineOfColHeader_Click(object sender, EventArgs e)
        {

        }//fn
    }//cl
}//ns
