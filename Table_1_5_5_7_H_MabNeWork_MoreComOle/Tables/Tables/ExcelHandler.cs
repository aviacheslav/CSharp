using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Data;//for DataTable
//
//Project-Add reference-COM-
//Project-Add reference-NET-Microsoft.Office.Interop.Excel //vikt!
using Excel = Microsoft.Office.Interop.Excel;

namespace Tables
{
    
    
    public class ExcelHandler
    {
        private Excel.Application excelApp;
        private Excel.Window excelWindow;
        private Excel.Workbook workBook;
        private Excel.Worksheet workSheet;
        private Excel.Range excelCells;
        private int Etappe_NotConnected0_Connected1_Closed2;
        private int SysBase;//MinDigit, MaxDigit,
        //public TRangeSelectedNs RangeSelectedNs;
        //
        public ExcelHandler()
        {
            Excel.Application excelApp = new Excel.Application();
            // Создаём экземпляр рабочий книги Excel
            Excel.Workbook workBook;
            // Создаём экземпляр листа Excel
            Excel.Worksheet workSheet;
            //MinDigit=1;
            //MaxDigit=26;
            SysBase = 26;
            Etappe_NotConnected0_Connected1_Closed2 = 0;
            //RangeSelectedNs = new TRangeSelectedNs();
            //
        }
        public int GetEtappe() { return this.Etappe_NotConnected0_Connected1_Closed2; }
        public string GetSelectedAddress()
        {
            string adrs;
            workSheet = this.excelApp.ActiveWorkbook.ActiveSheet;
            excelCells = excelApp.Selection;
            adrs = excelCells.get_Address();
            return adrs;
        }
        public void GetActiveRangeByNs(ref int FirstSelectedColumnN, ref int FirstSelectedLineN, ref int QColumnsSelected, ref int QLinesSelected)
        {
            workSheet = this.excelApp.ActiveWorkbook.ActiveSheet;
            excelCells = excelApp.Selection;
            excelCells = excelApp.ActiveWindow.RangeSelection;
            excelCells = excelApp.ActiveCell;
            QColumnsSelected = excelCells.Columns.Count;
            QLinesSelected = excelCells.Rows.Count;
            //int FirstSelectedColumnN = excelCells.Columns.Top;
            FirstSelectedColumnN = excelCells.Column;
            FirstSelectedLineN = excelCells.Row;
        }
        public void GetActiveRangeNsByLeftAdr(ref int FirstSelectedColumnN, ref int FirstSelectedLineN, ref int LastSelectedColumnN, ref int LastSelectedLineN, TValsShowHide vsh=null)
        {
            MyLib.writeln(vsh, "GetActiveRangeNsByLeftAdr starts working");
            workSheet = this.excelApp.ActiveWorkbook.ActiveSheet;
            excelCells = excelApp.Selection;
            string adr="", rangesStr="", s, leftRange;
            string[] ranges=null, curBnds=null, firstBnds=null, lastBnds=null, curCellColAndLine;
            adr = this.GetSelectedAddress();
            ranges = adr.Split(',');
            rangesStr = MyLib.ArraySimpleString(ranges, " ; ");
            int n=0;
            if (ranges != null) n = ranges.Length;
            MyLib.writeln(vsh,n.ToString()+" ranges: "+rangesStr);
            leftRange = ranges[1 - 1];
            MyLib.writeln(vsh, "Left range: " + leftRange);
            curBnds = leftRange.Split(':');
            if (curBnds == null) n = 0;
            else n = curBnds.Length;
            s = MyLib.ArraySimpleString(curBnds, " ; ");
            MyLib.writeln(vsh, n.ToString()+" range bounds: " + s);

            MyLib.writeln(vsh, " Now - for all bounds: " );
            for (int i = 1; i <= ranges.Length; i++)
            {
                curBnds = ranges[i - 1].Split(':');
                if(firstBnds==null){
                    n=0;
                }else{
                    n=firstBnds.Length;
                }
                MyLib.AddToVector(ref firstBnds, ref n, curBnds[1 - 1]);
                if (curBnds.Length == 2)
                {
                    if (lastBnds == null)
                    {
                        n = 0;
                    }
                    else
                    {
                        n = lastBnds.Length;
                    }
                    MyLib.AddToVector(ref lastBnds, ref n, curBnds[2 - 1]);
                }
                else
                {
                    MyLib.AddToVector(ref lastBnds, ref n, curBnds[1 - 1]);
                }
                MyLib.writeln(vsh, "Range " + i.ToString() + " : " + firstBnds[i - 1] + " :: " + lastBnds[i - 1]);
            }
            //now bounds are def'd
            curCellColAndLine=firstBnds[1-1].Split('$');
            s = MyLib.ArraySimpleString(curCellColAndLine, " ; ");
            MyLib.writeln(vsh, "cells col and line: " + s + " length: " + (curCellColAndLine.Length).ToString());
            //s = curCellColAndLine[2 - 1];
           // FirstSelectedColumnN = ParseColLetters(s);
            FirstSelectedColumnN = ParseColLetters(curCellColAndLine[2 - 1]);
            //s=curCellColAndLine[3 - 1];
            //FirstSelectedLineN=Int32.Parse(s);
            FirstSelectedLineN = Int32.Parse(curCellColAndLine[3 - 1]);
            curCellColAndLine = lastBnds[1 - 1].Split('$');
            s = MyLib.ArraySimpleString(curCellColAndLine, " ; ");
            MyLib.writeln(vsh, "cells col and line: " + s + " length: " + (curCellColAndLine.Length).ToString());
            LastSelectedColumnN = ParseColLetters(curCellColAndLine[2 - 1]);
            //s = curCellColAndLine[2 - 1];
            //LastSelectedColumnN = ParseColLetters(s);
            LastSelectedLineN = Int32.Parse(curCellColAndLine[3 - 1]);
            //s = curCellColAndLine[3 - 1];
            //FirstSelectedLineN = Int32.Parse(s);
            //FirstSelectedLineN = Int32.Parse(curCellColAndLine[3 - 1]);
            s = "[" + FirstSelectedColumnN.ToString() + ", " + FirstSelectedLineN.ToString() + "] : [" + LastSelectedColumnN.ToString() + ", " + LastSelectedLineN.ToString() + "]";
            MyLib.writeln(vsh, s);
            MyLib.writeln(vsh, "GetActiveRangeNsByLeftAdr finishes working");
        }
        public void GetActiveRangeNs(ref int FirstSelectedColumnN, ref int FirstSelectedLineN, ref int LastSelectedColumnN, ref int LastSelectedLineN)
        {
            workSheet=this.excelApp.ActiveWorkbook.ActiveSheet;
           //excelApp.Selection.//exists
            //workSheet.Se
           //excelCells= workSheet.Sel
            excelCells = excelApp.Selection;
            excelCells=excelApp.ActiveWindow.RangeSelection;
            excelCells=excelApp.ActiveCell;
            int QColumnsSelected = excelCells.Columns.Count;
            int QLinesSelected = excelCells.Rows.Count;
            
            //int FirstSelectedLineN = excelCells.EntireRow.Top;
            //int FirstSelectedColumnN = excelCells.Columns.Top;
            FirstSelectedColumnN = excelCells.Column;
            FirstSelectedLineN = excelCells.Row;
            LastSelectedColumnN = FirstSelectedColumnN + QColumnsSelected - 1;
            LastSelectedLineN = FirstSelectedLineN + QLinesSelected - 1;
            //int top=excelCells.Columns.
        }
        public string GetTopLeftSelection()
        {
            string cellName;
            int FirstSelectedColumnN=0, FirstSelectedLineN=0, LastSelectedColumnN=0, LastSelectedLineN=0 ;
            //GetActiveRangeNs(ref  FirstSelectedColumnN, ref  FirstSelectedLineN, ref  LastSelectedColumnN, ref  LastSelectedLineN);
            //public void GetActiveRangeNsByLeftAdr(ref int FirstSelectedColumnN, ref int FirstSelectedLineN, ref int LastSelectedColumnN, ref int LastSelectedLineN, TValsShowHide vsh=null)
            this.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN,  null);
            cellName=this.CellNameOfNs( FirstSelectedColumnN,  FirstSelectedLineN);
            return cellName;
        }
        public string GetBottomRightSelection()
        {
            string cellName;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            //GetActiveRangeNs(ref  FirstSelectedColumnN, ref  FirstSelectedLineN, ref  LastSelectedColumnN, ref  LastSelectedLineN);
            this.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            cellName = this.CellNameOfNs(LastSelectedColumnN, LastSelectedLineN);
            return cellName;
        }
        public void RunExcelApplication(){
            excelApp = new Excel.Application();
            excelApp.Visible = true;
        }
        public void CreateNewExcelDoc()
        {
            RunExcelApplication();
            Etappe_NotConnected0_Connected1_Closed2 =1;
            //
            excelApp.SheetsInNewWorkbook = 3;
            excelApp.Workbooks.Add(Type.Missing);
            //excelApp.SheetsInNewWorkbook = 5; //works
            //excelApp.Workbooks.Add(Type.Missing); //works, adds second workbook
        }
        public void OpenExistingExcelDoc(string fName)
        {
            RunExcelApplication();
            Etappe_NotConnected0_Connected1_Closed2 = 1;
            //
            //excelApp.Workbooks.Open(@"C:\a.xls",
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing
            //);
            excelApp.Workbooks.Open(fName,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Type.Missing, Type.Missing
            );
        }
        //
        public string GetActiveSheetName()
        {
            string s = "";
            if (this.GetEtappe() == 1)
            {
                s = this.excelApp.ActiveWorkbook.ActiveSheet.Name;
            }
            return s;
        }
        public int GetQSheets()
        {
            int n=0;
            if (this.GetEtappe() == 1)
            {
                n = this.excelApp.ActiveWorkbook.Sheets.Count;
            }
            return n;
        }
        public string GetNameOfSheetN(int SheetN)
        {
            string curSheetName="";
            int count = 0;
            int QSheets = this.GetQSheets();
            if (this.GetEtappe() == 1 && SheetN >= 1 && SheetN <= QSheets)
            {
                curSheetName = this.excelApp.ActiveWorkbook.Sheets[SheetN].Name;
            }
            return curSheetName;
        }
        public string[] GetSheetsNames()
        {
            string[] sheets = null;
            string curSheet;
            int count=0;
            int QSheets = this.GetQSheets();
            if (this.GetEtappe() == 1)
            {
                for(int i=1; i<=QSheets; i++){
                    curSheet=this.excelApp.ActiveWorkbook.Sheets[i].Name;
                    MyLib.AddToVector(ref sheets, ref count, curSheet);
                }
            }
            return sheets;
        }
        //
        public string ReadFormulaFromExcelCell(string SheetName, int ColN, int LineN)
        {
            string s;
            s = this.excelApp.ActiveWorkbook.Sheets[SheetName].Cells[LineN, ColN].Formula;
            return s;
        }
        public string ReadContentFromExcelCell(string SheetName, int ColN, int LineN)
        {
            string s;
            s = this.excelApp.ActiveWorkbook.Sheets[SheetName].Cells[LineN, ColN].Text;
            return s;
        }
        //
        string LetterOfDigit(int x)
        {
            string s="";
            switch(x){
                case 1:
                    s="A";
                break;
                case 2:
                    s="B";
                break;
                case 3:
                    s="C";
                break;
                case 4:
                    s="D";
                break;
                case 5:
                    s="E";
                break;
                case 6:
                    s="F";
                break;
                case 7:
                    s="G";
                break;
                case 8:
                    s="H";
                break;
                case 9:
                    s="I";
                break;
                case 10:
                    s="J";
                break;
                case 11:
                    s="K";
                break;
                case 12:
                    s="L";
                break;
                case 13:
                    s="M";
                break;
                case 14:
                    s="N";
                break;
                case 15:
                    s="O";
                break;
                case 16:
                    s="P";
                break;
                case 17:
                    s="Q";
                break;
                case 18:
                    s="R";
                break;
                case 19:
                    s="S";
                break;
                case 20:
                    s="T";
                break;
                case 21:
                    s="U";
                break;
                case 22:
                    s="V";
                break;
                case 23:
                    s="W";
                break;
                case 24:
                    s="X";
                break;
                case 25:
                    s="Y";
                break;
                case 26:
                    s="Z";
                break;
            }
            return s;
        }
        int DigitOfLetter(string s){
            int x=-1;
            if(s.Equals("A")){
                x= 1;
            }else if(s.Equals("B")){
                x= 2;
            }else if(s.Equals("C")){
                x= 3;
            }else if(s.Equals("D")){
                x= 4;
            }else if(s.Equals("E")){
                x= 5;
            }else if(s.Equals("F")){
                x= 6;
            }else if(s.Equals("G")){
                x= 7;
            }else if(s.Equals("H")){
                x= 8;
            }else if(s.Equals("I")){
                x= 9;
            }else if(s.Equals("J")){
                x= 10;
            }else if(s.Equals("K")){
                x= 11;
            }else if(s.Equals("L")){
                x= 12;
            }else if(s.Equals("M")){
                x= 13;
            }else if(s.Equals("N")){
                x= 14;
            }else if(s.Equals("O")){
                x= 15;
            }else if(s.Equals("P")){
                x= 16;
            }else if(s.Equals("Q")){
                x= 17;
            }else if(s.Equals("R")){
                x= 18;
            }else if(s.Equals("S")){
                x= 19;
            }else if(s.Equals("T")){
                x= 20;
            }else if(s.Equals("U")){
                x= 21;
            }else if(s.Equals("V")){
                x= 22;
            }else if(s.Equals("W")){
                x= 23;
            }else if(s.Equals("X")){
                x= 24;
            }else if(s.Equals("Y")){
                x= 25;
            }else if(s.Equals("Z")){
                x= 26;
            }else{
                x=-1;
            }
            return x;
        }//fn
        public int DigitOf(string s)
        {
            int y = 0;
            if(s.Equals("1")){
                y=1;
            }else if(s.Equals("2")){
                y=2;
            }else if(s.Equals("3")){
                y=3;
            }else if(s.Equals("4")){
                y=4;
            }else if(s.Equals("5")){
                y=5;
            }else  if(s.Equals("6")){
                y=6;
            }else  if(s.Equals("7")){
                y=7;
            }else  if(s.Equals("8")){
                y=8;
            }else  if(s.Equals("9")){
                y=9;
            }else{
                y=0;
            }
            return y;
        }
        public int PowIntPositive(int x, int p)
        {
            int y = 0;
            if (p == 0)
            {
                y = 1;
            }
            else
            {
                for (int i = 1; i <= p; i++)
                {
                    y *= x;
                }
            }
            return y;
        }
        public string ShifrColN(int x, TValsShowHide vsh=null)
        {
            //A=1
            //Z=26=26*1+0=0*26+26
            //AA=27=1*26+1
            //AZ=26*1+26=52=26*2+0=1*26+26
            //BA=53=26*2+1
            //BZ=78=26*2+26
            //CA=79=26*3+1
            //CZ=104=26*3+26
            //ZZ=26*26+26=702
            //AAA=703=702+1=1*26^2+1*26+1
            //AFJ=842=1*26^2+6*26+10=
            //CZZ=2730=3*26^2+26+26
            //CZY=2729=3*26^2+26*26+26
            //DAA=2731=4*26^2+1*26^2+1
            //
            int[] dig = null;
            //int[]ZeroArr=null, ZeroPassedArr = null;
            string s = "", CurDigExcel;//, CurDigUsual, bufS;
            int order = 0, FirstZeroN = 0;//, countZeroNs=0, countZeroPassed=0, ;
            MyLib.writeln(vsh, "ShifrColN starts working");
            NumberParse.IntToDigits(x, this.SysBase, ref dig, ref order);
            MyLib.writeln(vsh, "Array: " + MyLib.ArraySimpleString(dig));
            bool ZeroAbsent = true;
            for (int i = 1; i <= order + 1; i++)
            {
                MyLib.writeln(vsh, i.ToString() + "th digit=" + dig[i - 1].ToString());
                if (dig[i - 1] == 0)
                {
                    //MyLib.AddToVector(ref ZeroArr, ref countZeroNs, i);
                    if (ZeroAbsent)
                    {
                        FirstZeroN = i;
                        CurDigExcel = "Z";
                        s = CurDigExcel + s;
                        //bufS= s;
                        //s = CurDigExcel + bufS;
                        MyLib.writeln(vsh, "digit=zero=" + dig[i - 1].ToString() + ": zero before is absent => letter is Z=" + CurDigExcel + " in all: " + s+" .");
                    }
                    else
                    {
                        CurDigExcel = "Y";
                        s = CurDigExcel + s;
                        //bufS = s;
                        //s = CurDigExcel + bufS;
                        MyLib.writeln(vsh, "digit=zero=" + dig[i - 1].ToString() + ": zero before was present => letter is Y=" + CurDigExcel + " in all: " + s + " .");
                    }
                    ZeroAbsent = false;
                }
                else
                {
                    if (ZeroAbsent)
                    {
                        //
                        CurDigExcel = this.LetterOfDigit(dig[i - 1]);
                        s = CurDigExcel + s;
                        //bufS = s;
                        //s = CurDigExcel + bufS;
                        MyLib.writeln(vsh, "digit is NOT zero=" + dig[i - 1].ToString() + ": zero before is absent => letter is simply as it is =" + CurDigExcel + " in all: " + s + " .");
                    }
                    else//ZeroPresent
                    {
                        if (dig[i - 1] == 1)
                        {
                            if (i < order + 1)
                            {
                                CurDigExcel = "Z";
                                s = CurDigExcel + s;
                                //bufS = s;
                                //s = CurDigExcel + bufS;
                                MyLib.writeln(vsh, "digit is 1=" + dig[i - 1].ToString() + ": zero before was present, it is not last digit => letter is simply Z=" + CurDigExcel + " in all: " + s + " .");
                            }
                            else
                            {
                                MyLib.writeln(vsh, "digit is 1=" + dig[i - 1].ToString() + ": zero before was present, it is not last digit => previous letter is simply Z" );
                            }
                        }
                        else
                        {
                            CurDigExcel = this.LetterOfDigit(dig[i - 1]-1);
                            s = CurDigExcel + s;
                            //bufS = s;
                            //s = CurDigExcel + bufS;
                            MyLib.writeln(vsh, "digit is neither 0 nor 1=" + dig[i - 1].ToString() + ": zero before was present, it is not last digit => letter corresponds to value: (digit-1)=" + CurDigExcel + " in all: " + s + " .");
                        }
                    }
                }
                
            }
            MyLib.writeln(vsh, "answer: "+s);
            MyLib.writeln(vsh, "ShifrColN finishes working");
            return s;
        }
        public int ParseColLetters(string str)
        {
            int y = 0, L = str.Length, curDig=0, Cur;
            //string[] arrs = new string[str.Length];
            //int[] arri = new string[str.Length];
            string curS;
            //for (int i = 1; i <= str.Length; i++)
            //{
            //    arrs[i - 1] = str.Substring(i, 1);
            //    arri[i - 1] = this.DigitOf(arrs[i - 1]);
            //}
            //for (int i = str.Length; i >= 1; i--)
            for (int i = 1; i <= str.Length; i++)
            {
                curS = str.Substring(i-1, 1);
                curDig = this.DigitOfLetter(curS);
                Cur=MyMathLib.fIntNonNegativePower(this.SysBase, i - 1);
                y = y + Cur * curDig;
            }
            return y;
        }
        public void ParseCellName(string CellName, ref int ColN, ref int LineN)
        {
            string s, ColLetterPart="", LineNumPart="";
            for (int i = 1; i <= CellName.Length; i++)
            {
                s = CellName.Substring(i-1, 1);
                if (DigitOf(s) > 0)
                {
                    LineNumPart = LineNumPart + s;
                }
                else
                {
                    ColLetterPart = ColLetterPart + s;
                }
            }
            LineN=Int32.Parse(LineNumPart);
            ColN = ParseColLetters(ColLetterPart);
        }
        public int LineNOfCellNameParsing(string CellName)
        {
            int LineN=0, ColN=0;
            this.ParseCellName(CellName, ref ColN, ref LineN);
            return LineN;
        }
        public int ColNOfCellNameParsing(string CellName)
        {
            int LineN = 0, ColN=0;
            this.ParseCellName(CellName, ref ColN, ref LineN);
            return ColN;
        }
        public string CellNameOfNs(int ColN, int LineN)
        {
            string CellName = "";
            CellName = this.ShifrColN(ColN);
            CellName = CellName + LineN.ToString();
            return CellName;
        }
        /*public void ToDataCellArray(bool LoCHExists, bool CoLHExists, ref DataCell[][] cellsArr)
        {
            //DataCell[][] cells=null;
            DataCell[] cells = null;
            DataCellRow[] content;
            DataCellRow LoCH=null, CoLH=null;
            int FirstSelectedColumnN=0, FirstSelectedLineN=0, LastSelectedColumnN=0, LastSelectedLineN=0;
            int curLineN, curColN;
            int QLoCHs = MyLib.BoolToInt(LoCHExists), QCoLHs = MyLib.BoolToInt(CoLHExists);
            this.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN,null);
            this.RangeSelectedNs.Set(FirstSelectedColumnN, FirstSelectedLineN, LastSelectedColumnN, LastSelectedLineN, QLoCHs, QCoLHs);
            //cells = new DataCell[this.RangeSelectedNs.QLinesContent][];
            content = new DataCellRow[this.RangeSelectedNs.QLinesContent];
            for (int i = 1; i <= this.RangeSelectedNs.QLinesContent; i++)
            {
                cells = new DataCell[this.RangeSelectedNs.QColumnsContent];
                for (int j = 1; j <= this.RangeSelectedNs.QColumnsContent; j++)
                {
                    curLineN = this.RangeSelectedNs.FirstContentLineN + i - 1;
                    curColN = this.RangeSelectedNs.FirstContentColN +j - 1;
                    cells[j - 1] = new DataCell(this.excelApp.ActiveSheet.Range("A1").offset(curColN-1, curLineN - 1).Value);
                }
                content[i - 1] = new DataCellRow(cells, this.RangeSelectedNs.QColumnsContent);
            }
            cellsArr = new DataCell[this.RangeSelectedNs.QLinesContent][];
            for (int i = 1; i <= this.RangeSelectedNs.QLinesContent; i++)
            {
                cellsArr[i - 1] = new DataCell[this.RangeSelectedNs.QColumnsContent];
                for (int j = 1; j <= this.RangeSelectedNs.QColumnsContent; j++)
                {
                    curLineN = this.RangeSelectedNs.FirstContentLineN + i - 1;
                    curColN = this.RangeSelectedNs.FirstContentColN +j - 1;
                    cellsArr[i - 1][j - 1] = new DataCell(this.excelApp.ActiveSheet.Range("A1").offset( curColN-1, curLineN - 1).Value);
                }
            }
            if (LoCHExists)
            {
                cells = new DataCell[this.RangeSelectedNs.QColumnsContent];
                for (int j = 1; j <= this.RangeSelectedNs.QColumnsContent; j++)
                {
                    curLineN = this.RangeSelectedNs.FirstSelectedLineN + QLoCHs - 1;
                    curColN = this.RangeSelectedNs.FirstContentColN + j - 1;
                    cells[j - 1] = new DataCell(this.excelApp.ActiveSheet.Range("A1").offset(curColN - 1, curLineN - 1).Value);
                }
                LoCH = new DataCellRow(cells, this.RangeSelectedNs.QColumnsContent);
            }
            if (CoLHExists)
            {
                cells = new DataCell[this.RangeSelectedNs.QLinesContent];
                for (int i = 1; i<= this.RangeSelectedNs.QLinesContent; i++)
                {
                    curLineN = this.RangeSelectedNs.FirstContentLineN + i - 1;//this.RangeSelectedNs.FirstSelectedLineN + QLoCHs - 1;
                    curColN = this.RangeSelectedNs.FirstContentColN + QCoLHs - 1;
                    cells[i - 1] = new DataCell(this.excelApp.ActiveSheet.Range("A1").offset(curColN - 1, curLineN - 1).Value);
                }
                CoLH = new DataCellRow(cells, this.RangeSelectedNs.QLinesContent);
            }
            //return cells;
        }*/
        public string[] RangeNsToStringArray1D(string SheetName, Vector2DInt Lines, Vector2DInt Cols, bool LinesFirst = true)
        {
            string[] str=null;
            int QLinesSelected = Lines.d2 - Lines.d1+1, QColumnsSelected = Cols.d2 - Cols.d1+1, CurLinN, CurColN, count=0;
            if( QLinesSelected*QColumnsSelected>0){
                str = new string[QLinesSelected * QColumnsSelected];
                if (LinesFirst)
                {
                    for (int i = 1; i <= QLinesSelected; i++)
                    {
                        CurLinN = Lines.d1 + i - 1;
                        for (int j = 1; j <= QColumnsSelected; j++)
                        {
                            CurColN = Cols.d1 + j - 1;
                            count++;
                            str[count - 1] = this.ReadContentFromExcelCell(SheetName, CurColN, CurLinN);
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= QColumnsSelected; i++)
                    {
                        CurColN = Cols.d1 + i - 1;
                        for (int j = 1; j <= QLinesSelected; j++)
                        {
                            CurLinN = Lines.d1 + j - 1;
                            count++;
                            str[count - 1] = this.ReadContentFromExcelCell(SheetName, CurColN, CurLinN);
                        }
                    }
                }
            }
            return str;
        }
        public string[][] RangeNsToStringArray2D(string SheetName, Vector2DInt Lines, Vector2DInt Cols, bool LinesFirst = true)
        {
            string[][] str = null;
            int QLinesSelected = Lines.d2 - Lines.d1 + 1, QColumnsSelected = Cols.d2 - Cols.d1 + 1, CurLinN, CurColN, count = 0;
            if (QLinesSelected * QColumnsSelected > 0)
            {
                //str = new string[QLinesSelected * QColumnsSelected];
                if (LinesFirst)
                {
                    str = new string[QLinesSelected][];
                    for (int i = 1; i <= QLinesSelected; i++)
                    {
                        str[i-1]=new string[QColumnsSelected];
                        CurLinN = Lines.d1 + i - 1;
                        for (int j = 1; j <= QColumnsSelected; j++)
                        {
                            CurColN = Cols.d1 + j - 1;
                            count++;
                            str[i - 1][j - 1] = this.ReadContentFromExcelCell(SheetName, CurColN, CurLinN);
                        }
                    }
                }
                else
                {
                    str = new string[QColumnsSelected][];
                    for (int i = 1; i <= QColumnsSelected; i++)
                    {
                        str[i - 1] = new string[QLinesSelected];
                        CurColN = Cols.d1 + i - 1;
                        for (int j = 1; j <= QLinesSelected; j++)
                        {
                            CurLinN = Lines.d1 + j - 1;
                            count++;
                            str[i - 1][j-1] = this.ReadContentFromExcelCell(SheetName, CurColN, CurLinN);
                        }
                    }
                }
            }
            return str;
        }
        public TTable ExcelToTable(TExcelTableFitInfo data)
        {
            TTable tbl = null;
            DataCell THdr, LGHdr, CGHdr, cell;
            DataCell[] cells = null;
            DataCellRow[] content;
            DataCellRow LoCH = null, CoLH = null;
            string corner, LGNm, CGNm, TNm;//, HeaderBef, HeaderAft;
            string[] StrArr = null;
            TableHeaders hdrs=null;
            DataCell THCell, LGHCell, CGHCell;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            int curLineN, curColN;
            int QLoCHs = MyLib.BoolToInt(data.LoCHDataPresent), QCoLHs = MyLib.BoolToInt(data.CoLHDataPresent);
            string curS;
            bool CornerCorrect;
            //
            this.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            //
            int QLinesSelected=LastSelectedLineN-FirstSelectedLineN+1,
                QColsSelected=LastSelectedColumnN-FirstSelectedColumnN+1,
                ErstContentLineN, ErstContentColN, QLines, QColumns;
            if(data.LoCHDataPresent){
                QLines=QLinesSelected-1;
                ErstContentLineN=FirstSelectedLineN+1;
            }else{
                QLines=QLinesSelected;
                ErstContentLineN=FirstSelectedLineN;
            }
            if(data.CoLHDataPresent){
                QColumns=QColsSelected-1;
                ErstContentColN=FirstSelectedColumnN+1;
            }else{
                QColumns=QColsSelected;
                ErstContentColN=FirstSelectedColumnN;
            }
            //
            if(data.ImportToVerticalRows==false){
                cells = new DataCell[QColumns];
                content = new DataCellRow[QLines];
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        curLineN = ErstContentLineN + i - 1;
                        curColN = ErstContentColN + j - 1;
                        curS = this.ReadContentFromExcelCell(data.ContentSheet, curColN, curLineN);
                        cells[j - 1] = new DataCell(curS);
                    }
                    content[i - 1] = new DataCellRow(cells, QColumns);
                }
            }else{ //data.ImportToVerticalRows==true
                cells = new DataCell[QLines];
                content = new DataCellRow[QColumns];
                for (int i = 1; i <= QColumns; i++)
                {
                    for (int j = 1; j <= QLines; j++)
                    {
                        curLineN = ErstContentLineN + j - 1;
                        curColN = ErstContentColN + i - 1;
                        curS = this.ReadContentFromExcelCell(data.ContentSheet, curColN, curLineN);
                        cells[j - 1] = new DataCell(curS);
                    }
                    content[i - 1] = new DataCellRow(cells, QLines);
                }
            }
            //^-content v-LoCH
            if(data.LoCHDataPresent){
                //LoCH = new DataCellRow();
                cells = new DataCell[QColumns];
                curLineN = FirstSelectedLineN;
                if (data.LoCH_EachColDataHorisontal) //vertical row of col headers. each col data horisontal
                {
                    if (data.LoCHDBType==false)
                    {
                        for (int i = 1; i <= QColumns; i++)
                        {
                            curLineN = data.FirstLoCHLineN + i - 1;
                            StrArr = this.RangeNsToStringArray1D(data.TblHdrSheet, new Vector2DInt(curLineN, curLineN), new Vector2DInt(data.FirstLoCHColumnN, data.LastLoCHColumnN));
                            if (StrArr.Length == 1)
                            {
                                cells[i - 1] = new DataCell(StrArr[1 - 1]);
                            }
                            else
                            {
                                cells[i - 1] = new DataCell(StrArr, StrArr.Length);
                            }
                        }
                    }
                    else //data.LoCHDBType==true
                    {
                        for (int i = 1; i <= QColumns; i++)
                        {
                            curLineN = data.FirstLoCHLineN + i - 1;
                            StrArr = this.RangeNsToStringArray1D(data.TblHdrSheet, new Vector2DInt(curLineN, curLineN), new Vector2DInt(data.FirstLoCHColumnN, data.LastLoCHColumnN));
                            if (StrArr.Length == 1)
                            {

                                cells[i-1] = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(), null, 0);
                            }
                            else if (StrArr.Length == 2)
                            {

                                cells[i - 1] = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(StrArr[2 - 1], new TDBFieldCreationDataWithItemsTable(null, 0, 1)), null, 0);
                                // public TDBFieldHeaderData(string DBFieldNameToDBTable, TDBFieldCreationDataWithItemsTable DBTableHeaderDataSupplSpecial)
                                // public TDBFieldCreationDataWithItemsTable(string[] arr, int L=0, int FromN=1)
                                // public TDBFieldHeaderData(string DBFieldNameToDBTable, TDBFieldCreationDataWithItemsTable DBTableHeaderDataSupplSpecial)
                                // public DataCell(string Name, TDBFieldHeaderData data, string[]items, int QItems)
                            }
                            else
                            {
                                cells[i - 1] = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(StrArr[2 - 1], new TDBFieldCreationDataWithItemsTable(StrArr, 0, 3)), null, 0);
                            }
                        }
                    }
                }
                else // data.LoCH_EachColDataHorisontal==false => 
                {
                    if (data.LoCHDBType == false)
                    {
                        for (int i = 1; i <= QColumns; i++)
                        {
                            curLineN = data.FirstLoCHLineN + i - 1;
                            StrArr = this.RangeNsToStringArray1D(data.TblHdrSheet, new Vector2DInt(curLineN, curLineN), new Vector2DInt(data.FirstLoCHColumnN, data.LastLoCHColumnN));
                            if (StrArr.Length == 1)
                            {
                                cells[i - 1] = new DataCell(StrArr[1 - 1]);
                            }
                            else
                            {
                                cells[i - 1] = new DataCell(StrArr, StrArr.Length);
                            }
                        }
                    }
                    else //data.LoCHDBType==true
                    {
                        for (int i = 1; i <= QColumns; i++)
                        {
                            //curLineN = data.FirstLoCHLineN + i - 1;
                            curColN = data.FirstLoCHColumnN + i - 1;
                            StrArr = this.RangeNsToStringArray1D(data.TblHdrSheet, new Vector2DInt(curLineN, curLineN), new Vector2DInt(data.FirstLoCHColumnN, data.LastLoCHColumnN));
                            if (StrArr.Length == 1)
                            {
                                cells[i - 1] = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(), null, 0);
                            }
                            else if (StrArr.Length == 2)
                            {
                                cells[i - 1] = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(StrArr[2 - 1], new TDBFieldCreationDataWithItemsTable(null, 0, 1)), null, 0);
                                // public TDBFieldHeaderData(string DBFieldNameToDBTable, TDBFieldCreationDataWithItemsTable DBTableHeaderDataSupplSpecial)
                                // public TDBFieldCreationDataWithItemsTable(string[] arr, int L=0, int FromN=1)
                                // public TDBFieldHeaderData(string DBFieldNameToDBTable, TDBFieldCreationDataWithItemsTable DBTableHeaderDataSupplSpecial)
                                // public DataCell(string Name, TDBFieldHeaderData data, string[]items, int QItems)
                            }
                            else
                            {
                                cells[i - 1] = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(StrArr[2 - 1], new TDBFieldCreationDataWithItemsTable(StrArr, 0, 3)), null, 0);
                            }
                        }
                    }
                }
                LoCH = new DataCellRow(cells, QColumns);
            }
            // ^ LoCH v CoLH
            if (data.CoLHDataPresent)
            {
                //CoLH = new DataCellRow();
                cells = new DataCell[QLines];
                //curLineN = FirstSelectedLineN;
                curColN = ErstContentColN;
                if (!data.CoLH_EachLineDataVertical)
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        curLineN = ErstContentLineN + j - 1;
                        curS = this.ReadContentFromExcelCell(data.ContentSheet, curColN, curLineN);
                        cells[i - 1] = new DataCell(curS);
                    }
                }
                CoLH = new DataCellRow(cells, QLines);
            }
            //
            if (data.HdrsInCornerPresent)
            {
                corner = this.ReadContentFromExcelCell(data.ContentSheet, data.CornerColN, data.CornerLineN);
                MyLib.ParseNamesOfTableCorner(corner, ref CornerCorrect, ref LGNm, ref CGNm, ref TNm);
                if (TNm != "" || LGNm != "" || CGNm != "")
                {
                    //hdrs=new TableHeaders(new DataCell(TNm), new DataCell(LGNm), new DataCell(CGNm));
                    //hdrs = new TableHeaders(TNm, "", LGNm, "", CGNm, "");
                    hdrs = new TableHeaders(TNm, LGNm, CGNm);
                }
            }
            else
            {//
                if(data.TblHdrDataPresent){
                    StrArr = this.RangeNsToStringArray1D(data.TblHdrSheet, new Vector2DInt(data.FirstTblHdrLineN, data.LastTblHdrLineN), new Vector2DInt(data.FirstTblHdrColumnN, data.LastTblHdrColumnN));
                    if(StrArr!=null){
                        if (data.TblHdrDBType)
                        {
                            THdr=new DataCell(StrArr[1-1], new TDBTableHeaderData(StrArr,0, 2));//, LGHdr, CGHdr
                        }
                        else
                        {
                            if (StrArr.Length == 1)
                            {

                                THdr = new DataCell(StrArr[1 - 1]);
                            }
                            else
                            {
                                THdr = new DataCell(StrArr, StrArr.Length);
                            }
                        }
                    }
                }
                if(data.LinGenHdrDataPresent){
                    if (data.LinGenHdrDBType)
                    {
                        LGHdr = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(), null, 0);//, LGHdr, CGHdr
                    }
                    else
                    {
                        if (StrArr.Length == 1)
                        {
                            LGHdr = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(), null, 0);
                        }
                        else if (StrArr.Length == 2)
                        {

                            LGHdr = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(StrArr[2 - 1], new TDBFieldCreationDataWithItemsTable(null, 0, 1)), null, 0);
                            // public TDBFieldHeaderData(string DBFieldNameToDBTable, TDBFieldCreationDataWithItemsTable DBTableHeaderDataSupplSpecial)
                            // public TDBFieldCreationDataWithItemsTable(string[] arr, int L=0, int FromN=1)
                            // public TDBFieldHeaderData(string DBFieldNameToDBTable, TDBFieldCreationDataWithItemsTable DBTableHeaderDataSupplSpecial)
                            // public DataCell(string Name, TDBFieldHeaderData data, string[]items, int QItems)
                        }
                        else
                        {
                            LGHdr = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(StrArr[2 - 1], new TDBFieldCreationDataWithItemsTable(StrArr, 0, 3)), null, 0);
                        }
                    }
                }
                if(data.ColGenHdrDataPresent){
                    if (data.LinGenHdrDBType)
                    {
                        CGHdr = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(), null, 0);//, LGHdr, CGHdr
                    }
                    else
                    {
                        if (StrArr.Length == 1)
                        {

                            CGHdr = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(), null, 0);
                        }
                        else if (StrArr.Length == 2)
                        {

                            CGHdr = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(StrArr[2 - 1], new TDBFieldCreationDataWithItemsTable(null, 0, 1)), null, 0);
                            // public TDBFieldHeaderData(string DBFieldNameToDBTable, TDBFieldCreationDataWithItemsTable DBTableHeaderDataSupplSpecial)
                            // public TDBFieldCreationDataWithItemsTable(string[] arr, int L=0, int FromN=1)
                            // public TDBFieldHeaderData(string DBFieldNameToDBTable, TDBFieldCreationDataWithItemsTable DBTableHeaderDataSupplSpecial)
                            // public DataCell(string Name, TDBFieldHeaderData data, string[]items, int QItems)
                        }
                        else
                        {
                            CGHdr = new DataCell(StrArr[1 - 1], new TDBFieldHeaderData(StrArr[2 - 1], new TDBFieldCreationDataWithItemsTable(StrArr, 0, 3)), null, 0);
                        }
                    }
                }
                if(data.TblHdrDataPresent || data.LinGenHdrDataPresent || data.ColGenHdrDataPresent){
                    hdrs = new TableHeaders(THdr, LGHdr, CGHdr);
                }
            }
            //
            tbl = new TTable
                (
                new TableInfo(true, CoLHExists, LoCHExists, this.RangeSelectedNs.QLinesContent, this.RangeSelectedNs.QColumnsContent),
                false,
                content,
                LoCH,
                CoLH,
                hdrs,
                true
                );
            return tbl;
        }//fn
        //
        //public TExcelTableFitInfo ReadFormExcelData()
        //{
        //    TExcelTableFitInfo R=null;

        //    return R;
        //}
        public TTable ToTable(TExcelTableFitInfo data){
            TTable tbl=null;
            string CellContent;
            
            int ErstLineN, LastLineN, ErstColN, LastColN, CurLineN, CurColN; 
            DataCellRow[] rows = new DataCellRow[data.QLines];
            DataCell[] cells = new DataCell[data.QColumns];
            //content
            ErstLineN=data.FirstContentLineN;
            LastLineN=data.LastContentLineN;
            ErstColN=data.FirstContentLineN;
            LastColN=data.LastContentColumnN;
            for (int i = 1; i <= data.QLines; i++)
            {
                CurLineN=ErstLineN+i-1;
                cells = new DataCell[data.QColumns];
                for (int j = 1; j <= data.QColumns; j++)
                {
                    CurColN=ErstColN+i-1;
                    //CellContent=ActiveWo
                }
            }
            return tbl;
        }//fn
    }//cl
}//ns

