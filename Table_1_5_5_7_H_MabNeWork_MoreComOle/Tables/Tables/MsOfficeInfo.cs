using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    //class MsOfficeInfo
    //{
    //}
    public class TExcelCellFitFormData : ICloneable
    {
        public string CurCellFirst, CurCellLast, CurCellActiveVal, CurCellSheet;
        //public string CurCellType;
        public int CurCellTypeN, CurCellActiveN;
        public bool CurCellDataPresent, CurCellActiveValNotDefault, CurCellActiveValExcelCell;
        //
        public TExcelCellFitFormData()
        {
            this.SetDefault();
        }
        public void SetDefault()
        {
            this.CurCellFirst = "";
            this.CurCellLast = "";
            this.CurCellActiveVal = "";
            this.CurCellSheet = "";
            //this.CurCellType = "";
            this.CurCellTypeN = TableConsts.StringTypeN;
            this.CurCellActiveN = 1;
            this.CurCellDataPresent = false;
            this.CurCellActiveValNotDefault = false;
            this.CurCellActiveValExcelCell = false;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public class TExcelCellFitData : ICloneable
    {
        public string CurCellFirst, CurCellLast, CurCellActiveVal, CurCellSheet;
        //public string CurCellType;
        public int CurCellTypeN, CurCellActiveN;
        public bool CurCellActiveValNotDefault, CurCellActiveValExcelCell;
        //
        public bool ImportToVerticalRows;
        //
        public int CurCell_First_LineN, CurCell_First_ColN, CurCell_Last_LineN, CurCell_Last_ColN, CurCellActiveVal_LineN, CurCellActiveVal_ColN, QItems, QLines, QColumns;
        //
        public TExcelCellFitData()
        {
            this.SetDefault();
        }
        public void SetDefault()
        {
            this.CurCellFirst = "";
            this.CurCellLast = "";
            this.CurCellActiveVal = "";
            this.CurCellSheet = "";
            //public string CurCellType;
            this.CurCellTypeN = TableConsts.StringTypeN;
            this.CurCellActiveN = 1;
            this.CurCellActiveValNotDefault = false;
            this.CurCellActiveValExcelCell = false;
            //
            this.ImportToVerticalRows = MyLib.BoolValByDefault;
            //
            this.CurCell_First_LineN = 0;
            this.CurCell_First_ColN = 0;
            this.CurCell_Last_LineN = 0;
            this.CurCell_Last_ColN = 0;
            this.CurCellActiveVal_LineN = 0;
            this.CurCellActiveVal_ColN = 0;
            this.QItems = 1;
            this.QLines = 0;
            this.QColumns = 0;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        public void SetFromFormData(TExcelCellFitFormData FormData, ExcelHandler excel)
        {
            this.CurCellFirst = FormData.CurCellFirst;
            this.CurCellLast = FormData.CurCellLast;
            this.CurCellActiveVal = FormData.CurCellActiveVal;
            this.CurCellSheet = FormData.CurCellSheet;
            this.CurCellTypeN = FormData.CurCellTypeN;

            //
            excel.ParseCellName(this.CurCellFirst, ref this.CurCell_First_ColN, ref this.CurCell_First_LineN);
            excel.ParseCellName(this.CurCellLast, ref this.CurCell_Last_ColN, ref this.CurCell_Last_LineN);
            this.QLines = this.CurCell_Last_LineN - this.CurCell_First_LineN + 1;
            this.QColumns = this.CurCell_Last_ColN - this.CurCell_First_ColN + 1;
            this.QItems = this.QLines * this.QColumns;
            if (this.CurCellActiveVal != null && !this.CurCellActiveVal.Equals(""))
            {
                excel.ParseCellName(this.CurCellActiveVal, ref this.CurCellActiveVal_ColN, ref this.CurCellActiveVal_LineN);
            }
            //
            if (!this.CurCellActiveValNotDefault)
            {
                this.CurCellActiveN = 1;
            }
            else
            {
                if (this.CurCellActiveValExcelCell)
                {

                }
                else
                {

                }
            }
        }
        public DataCell SetCellFromExcel(ExcelHandler excel)
        {
            DataCell cell = new DataCell();
            cell.SetTypeN(this.CurCellTypeN, null);
            string[] items = null;
            string[] names = null;
            string SnglVal = "";
            double dblVal = 0;
            float fltVal = 0;
            int intVal = 0;
            bool boolVal = MyLib.BoolValByDefault;
            int count = 0, CurLineN, CurColN;
            if (this.QItems > 1)
            {
                for (int i = 1; i <= this.QLines; i++)
                {
                    for (int j = 1; j <= this.QColumns; j++)
                    {
                        SnglVal = excel.ReadFormulaFromExcelCell(this.CurCellSheet, this.CurCell_First_ColN + j - 1, this.CurCell_First_LineN + i - 1);
                        MyLib.AddToVector(ref names, ref count, SnglVal);
                    }
                }
                //
                if (this.CurCellActiveValNotDefault == false)
                {
                    if (this.CurCellActiveVal_ColN > 0 && this.CurCellActiveVal_LineN > 0)
                    {
                        if (this.CurCellActiveVal_ColN >= this.CurCell_First_ColN && this.CurCellActiveVal_ColN <= this.CurCell_Last_ColN && this.CurCell_First_ColN != this.CurCell_Last_ColN)
                        {
                            this.CurCellActiveN = this.CurCellActiveVal_ColN - this.CurCell_First_ColN + 1;
                        }
                        else if (this.CurCellActiveVal_LineN >= this.CurCell_First_LineN && this.CurCellActiveVal_LineN <= this.CurCell_Last_ColN && this.CurCell_First_LineN != this.CurCell_Last_LineN)
                        {
                            this.CurCellActiveN = this.CurCellActiveVal_LineN - this.CurCell_First_LineN + 1;
                        }
                        else
                        {
                            SnglVal = excel.ReadFormulaFromExcelCell(this.CurCellSheet, this.CurCellActiveVal_ColN, this.CurCellActiveVal_LineN);
                            this.CurCellActiveN = MyLib.FirstValInVectorPosN(names, this.QItems, SnglVal);
                        }
                    }
                }
                else
                {
                    this.CurCellActiveN = 1;
                }
            }
            else
            {
                names = new string[1];
                names[1 - 1] = SnglVal;
                //cell = new DataCell(this.CurCellTypeN, names, this.QItems);
            }
            cell = new DataCell(this.CurCellTypeN, names, this.QItems);
            return cell;
        }
    }//cl
    /*
    public class TExcelTableFitFormData:ICloneable
    {
        public string ContentFirst, ContentLast, CoLHFirst, CoLHLast, LoCHFirst, LoCHLast, HdrCrnr, TblHdrFirst, TblHdrLast,
                      ColGenHdrFirst, ColGenHdrLast, LinGenHdrFirst, LinGenHdrLast, CurCellFirst, CurCellLast, CurCellActiveVal;
        public string ContentSheet, CoLHSheet, LoCHSheet, HdrCrnrSheet, TblHdrSheet,
                ColGenHdrSheet, LinGenHdrSheet, CurCellSheet;
        public string CurCellType;
        public int CurCellTypeN;
        public int CurCellActiveN;
        public bool HdrsInCornerPresent, TblHdrDataPresent, LinGenHdrDataPresent, ColGenHdrDataPresent, LoCHDataPresent, CoLHDataPresent, CurCellDataPresent;
        public bool ContentExportDBData, //ContentDBType,
             CoLHExportDBData, CoLHDBType, CoLH1stOnly, CoLHEachLineDataVertical,
             LoCHExportDBData, LoCHDBType, LoCH1stOnly, LoCHEachColumnDataHorisontal,
             HdrCrnrExportDBData, HdrCrnrDBType,
             TblHdrExportDBData, TblHdrDBType,
             ColGenHdrExportDBData, ColGenHdrDBType,
             LinGenHdrExportDBData, LinGenHdrDBType,
             CurCellExportDBData, //CurCellDBType, 
             CurCellActiveValNotDefault, CurCellActiveValExcelCell;
        public bool ImportToVerticalRows;// = MyLib.BoolValByDefault;
        
        public TExcelTableFitFormData(){
            this.ContentFirst="";
            this.ContentLast = "";
            this.CoLHFirst = "";
            this.CoLHLast = "";
            this.LoCHFirst = "";
            this.LoCHLast = "";
            this.HdrCrnr = "";
            this.TblHdrFirst = "";
            this.TblHdrLast = "";
            this.ColGenHdrFirst = "";
            this.ColGenHdrLast = "";
            this.LinGenHdrFirst = "";
            this.LinGenHdrLast = "";
            this.CurCellFirst = "";
            this.CurCellLast = "";
            this.CurCellActiveVal = "";
            this.ContentSheet = "";
            this.CoLHSheet = "";
            this.LoCHSheet = "";
            this.HdrCrnrSheet = "";
            this.TblHdrSheet = "";
            this.ColGenHdrSheet = "";
            this.LinGenHdrSheet = "";
            this.CurCellSheet = "";
            //
            this.CurCellType = "";
            this.CurCellTypeN = 0;
            //
            this.HdrsInCornerPresent = false;
            this.TblHdrDataPresent = false;
            this.LinGenHdrDataPresent = false;
            this.ColGenHdrDataPresent = false;
            this.LoCHDataPresent = false;
            this.CoLHDataPresent = false;
            this.CurCellDataPresent = false;
            //
            this.ContentExportDBData = false;
            //ContentDBType = false;
            this.CoLHExportDBData = false;
            this.CoLHDBType = false;
            this.CoLH1stOnly = false;
            this.CoLHEachLineDataVertical = false;
            this.LoCHExportDBData = false;
            this.LoCHDBType = false;
            this.LoCH1stOnly = false;
            this.LoCHEachColumnDataHorisontal = false;
            this.HdrCrnrExportDBData = false;
            this.HdrCrnrDBType = false;
            this.TblHdrExportDBData = false;
            this.TblHdrDBType = false;
            this.ColGenHdrExportDBData = false;
            this.ColGenHdrDBType = false;
            this.LinGenHdrExportDBData = false;
            this.LinGenHdrDBType = false;
            this.CurCellExportDBData = false; 
            //CurCellDBType = false;
            this.CurCellActiveValNotDefault = false;
            this.CurCellActiveValExcelCell = false;
            //
            this.ImportToVerticalRows = MyLib.BoolValByDefault;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    */
    public class TExcelTableFitInfo
    {
        public int FirstContentLineN, LastContentLineN, FirstContentColumnN, LastContentColumnN, QLines, QColumns,
                   FirstLoCHLineN, LastLoCHLineN, FirstLoCHColumnN, LastLoCHColumnN, QLoCHLines, QLoCHColumns, QLoCHColsDefined, QLoCHData,
                   FirstCoLHLineN, LastCoLHLineN, FirstCoLHColumnN, LastCoLHColumnN, QCoLHLines, QCoLHColumns, QCoLHLinesDefined, QCoLHData,
                   CornerLineN, CornerColN,
                   FirstTblHdrLineN, LastTblHdrLineN, FirstTblHdrColumnN, LastTblHdrColumnN, QTblHdrData,
                   FirstLinGenHdrLineN, LastLinGenHdrLineN, FirstLinGenHdrColumnN, LastLinGenHdrColumnN, QLinGenHdrData,
                   FirstColGenHdrLineN, LastColGenHdrLineN, FirstColGenHdrColumnN, LastColGenHdrColumnN, QColGenHdrData,
                   FirstCurCellLineN, LastCurCellLineN, FirstCurCellColumnN, LastCurCellColumnN, QCurCellData,
                   CurCellActiveValLineN, CurCellActiveValColumnN, CurCellActiveN;
        public int QTHLines, QTHCols, QLGHLines, QLGHCols, QCGHLines, QCGHCols, QCurCellLines, QCurCellCols;
        public bool HdrsInCornerPresent, TblHdrDataPresent, LinGenHdrDataPresent, ColGenHdrDataPresent, LoCHDataPresent, CoLHDataPresent, CurCellDataPresent;
        //public bool LoCH_EachColDataVertical, CoLH_EachLineDataHorisontal;
        public bool CoLHExportDBData, CoLHDBType,
                    LoCHExportDBData, LoCHDBType,
                    HdrCrnrExportDBData, HdrCrnrDBType,
                    TblHdrExportDBData, TblHdrDBType,
                    ColGenHdrExportDBData, ColGenHdrDBType,
                    LinGenHdrExportDBData, LinGenHdrDBType,
                    CurCellExportDBData;
        public bool LoCH_EachColDataHorisontal, CoLH_EachLineDataVertical;
        public bool ImportToVerticalRows;// = MyLib.BoolValByDefault;
        public string ContentSheet, CoLHSheet, LoCHSheet, HdrCrnrSheet, TblHdrSheet,
               ColGenHdrSheet, LinGenHdrSheet, CurCellSheet;
        //
        public TExcelTableFitInfo()
        {
            FirstContentLineN = 0;
            LastContentLineN = 0;
            FirstContentColumnN = 0;
            LastContentColumnN = 0;
            QLines = 0;
            QColumns = 0;
            //
            FirstLoCHLineN = 0;
            LastLoCHLineN = 0;
            FirstLoCHColumnN = 0;
            LastLoCHColumnN = 0;
            QLoCHLines = 0;
            QLoCHColumns = 0;
            QLoCHColsDefined = 0;
            QLoCHData = 0;
            //
            FirstCoLHLineN = 0;
            LastCoLHLineN = 0;
            FirstCoLHColumnN = 0;
            LastCoLHColumnN = 0;
            QCoLHLines = 0;
            QCoLHColumns = 0;
            QCoLHLinesDefined = 0;
            QCoLHData = 0;
            //
            CornerLineN = 0;
            CornerColN = 0;
            //
            FirstTblHdrLineN = 0;
            LastTblHdrLineN = 0;
            FirstTblHdrColumnN = 0;
            LastTblHdrColumnN = 0;
            QTblHdrData = 0;
            //
            FirstLinGenHdrLineN = 0;
            LastLinGenHdrLineN = 0;
            FirstLinGenHdrColumnN = 0;
            LastLinGenHdrColumnN = 0;
            QLinGenHdrData = 0;
            //
            FirstColGenHdrLineN = 0;
            LastColGenHdrLineN = 0;
            FirstColGenHdrColumnN = 0;
            LastColGenHdrColumnN = 0;
            QColGenHdrData = 0;
            //
            FirstCurCellLineN = 0;
            LastCurCellLineN = 0;
            FirstCurCellColumnN = 0;
            LastCurCellColumnN = 0;
            CurCellActiveN = 0;
            QCurCellData = 0;
            //
            CurCellActiveValLineN = 0;
            CurCellActiveValColumnN = 0;
            CurCellActiveN = 0;
            //
            QTHLines = 0;
            QTHCols = 0;
            QLGHLines = 0;
            QLGHCols = 0;
            QCGHLines = 0;
            QCGHCols = 0;
            QCurCellLines = 0;
            QCurCellCols = 0;
            //
            HdrsInCornerPresent = false;
            TblHdrDataPresent = false;
            LinGenHdrDataPresent = false;
            ColGenHdrDataPresent = false;
            LoCHDataPresent = false;
            CoLHDataPresent = false;
            CurCellDataPresent = false;
            //
            CoLHExportDBData = false; CoLHDBType = false;
            LoCHExportDBData = false; LoCHDBType = false;
            HdrCrnrExportDBData = false; HdrCrnrDBType = false;
            TblHdrExportDBData = false; TblHdrDBType = false;
            ColGenHdrExportDBData = false; ColGenHdrDBType = false;
            LinGenHdrExportDBData = false; LinGenHdrDBType = false;
            CurCellExportDBData = false;
            //
            //LoCH_EachColDataVertical = true;
            //CoLH_EachLineDataHorisontal = false;
            LoCH_EachColDataHorisontal = false;
            CoLH_EachLineDataVertical = false;
            //
            this.ImportToVerticalRows = MyLib.BoolValByDefault;
            //
            ContentSheet = "";
            CoLHSheet = "";
            LoCHSheet = "";
            HdrCrnrSheet = "";
            TblHdrSheet = "";
            ColGenHdrSheet = "";
            LinGenHdrSheet = "";
            CurCellSheet = "";
        }//constr
        public void SetFromFormData(TExcelTableFitFormData dataExt, ExcelHandler excel)//dataExt)
        {
            TExcelTableFitFormData data = (TExcelTableFitFormData)dataExt.Clone();
            //
            this.ContentSheet = data.ContentSheet;
            this.CoLHSheet = data.CoLHSheet;
            this.LoCHSheet = data.LoCHSheet;
            this.HdrCrnrSheet = data.HdrCrnrSheet;
            this.TblHdrSheet = data.TblHdrSheet;
            this.ColGenHdrSheet = data.ColGenHdrSheet;
            this.LinGenHdrSheet = data.LinGenHdrSheet;
            this.CurCellSheet = data.CurCellSheet;
            //
            this.HdrsInCornerPresent = data.HdrsInCornerPresent;
            this.TblHdrDataPresent = data.TblHdrDataPresent;
            this.LinGenHdrDataPresent = data.LinGenHdrDataPresent;
            this.ColGenHdrDataPresent = data.ColGenHdrDataPresent;
            this.LoCHDataPresent = data.LoCHDataPresent;
            this.CoLHDataPresent = data.CoLHDataPresent;
            this.CurCellDataPresent = data.CurCellDataPresent;
            //
            this.CoLHExportDBData = data.CoLHExportDBData;
            this.CoLHDBType = data.CoLHDBType;
            this.LoCHExportDBData = data.LoCHExportDBData;
            this.CoLHDBType = data.CoLHDBType;
            this.HdrCrnrExportDBData = data.HdrCrnrExportDBData;
            this.HdrCrnrDBType = data.HdrCrnrDBType;
            this.TblHdrExportDBData = data.TblHdrExportDBData;
            this.TblHdrDBType = data.TblHdrDBType;
            this.ColGenHdrExportDBData = data.ColGenHdrExportDBData;
            this.ColGenHdrDBType = data.ColGenHdrDBType;
            this.LinGenHdrExportDBData = data.LinGenHdrExportDBData;
            this.LinGenHdrDBType = data.LinGenHdrDBType;
            this.CurCellExportDBData = data.CurCellExportDBData;
            //
            this.ImportToVerticalRows = data.ImportToVerticalRows;
            //
            if (!data.ContentFirst.Equals("") && data.ContentLast.Equals("")) data.ContentLast = data.ContentFirst;
            else if (data.ContentFirst.Equals("") && !data.ContentLast.Equals("")) data.ContentFirst = data.ContentLast;
            if (!data.CoLHFirst.Equals("") && data.CoLHLast.Equals("")) data.CoLHLast = data.CoLHFirst;
            else if (data.CoLHFirst.Equals("") && !data.CoLHLast.Equals("")) data.CoLHFirst = data.CoLHLast;
            if (!data.LoCHFirst.Equals("") && data.LoCHLast.Equals("")) data.LoCHLast = data.LoCHFirst;
            else if (data.LoCHFirst.Equals("") && !data.LoCHLast.Equals("")) data.LoCHFirst = data.LoCHLast;
            if (!data.TblHdrFirst.Equals("") && data.TblHdrLast.Equals("")) data.TblHdrLast = data.TblHdrFirst;
            else if (data.TblHdrFirst.Equals("") && !data.TblHdrLast.Equals("")) data.TblHdrFirst = data.TblHdrLast;
            if (!data.ColGenHdrFirst.Equals("") && data.ColGenHdrLast.Equals("")) data.ColGenHdrLast = data.ColGenHdrFirst;
            else if (data.ColGenHdrFirst.Equals("") && !data.ColGenHdrLast.Equals("")) data.ColGenHdrFirst = data.ColGenHdrLast;
            if (!data.LinGenHdrFirst.Equals("") && data.LinGenHdrLast.Equals("")) data.LinGenHdrLast = data.LinGenHdrFirst;
            else if (data.LinGenHdrFirst.Equals("") && !data.LinGenHdrLast.Equals("")) data.LinGenHdrFirst = data.LinGenHdrLast;
            if (!data.CurCellFirst.Equals("") && data.CurCellLast.Equals("")) data.CurCellLast = data.CurCellFirst;
            else if (data.CurCellFirst.Equals("") && !data.CurCellLast.Equals("")) data.CurCellFirst = data.CurCellLast;
            //
            excel.ParseCellName(data.ContentFirst, ref this.FirstContentColumnN, ref this.FirstContentLineN);
            excel.ParseCellName(data.ContentLast, ref this.LastContentColumnN, ref this.LastContentLineN);
            this.QLines = this.LastContentLineN - this.FirstContentLineN + 1;
            this.QColumns = this.LastContentColumnN - this.FirstContentColumnN + 1;
            if (this.CoLHDataPresent)
            {
                excel.ParseCellName(data.CoLHFirst, ref this.FirstCoLHColumnN, ref this.FirstCoLHLineN);
                excel.ParseCellName(data.CoLHLast, ref this.LastCoLHColumnN, ref this.LastCoLHLineN);
                this.QCoLHLines = this.LastCoLHLineN - this.FirstCoLHLineN + 1;
                this.QCoLHColumns = this.LastCoLHColumnN - this.FirstCoLHColumnN + 1;
                this.CoLH_EachLineDataVertical = data.CoLHEachLineDataVertical;
                if (this.CoLH_EachLineDataVertical)
                {
                    this.QCoLHLinesDefined = this.QCoLHColumns;
                    this.QCoLHData = this.QCoLHLines;
                }
                else
                {
                    this.QCoLHLinesDefined = this.QCoLHLines;
                    this.QCoLHData = this.QCoLHColumns;
                }
            }
            if (this.LoCHDataPresent)
            {
                excel.ParseCellName(data.LoCHFirst, ref this.FirstLoCHColumnN, ref this.FirstLoCHLineN);
                excel.ParseCellName(data.LoCHLast, ref this.LastLoCHColumnN, ref this.LastLoCHLineN);
                this.QLoCHLines = this.LastLoCHLineN - this.FirstLoCHLineN + 1;
                this.QLoCHColumns = this.LastLoCHColumnN - this.FirstLoCHColumnN + 1;
                this.LoCH_EachColDataHorisontal = data.LoCHEachColumnDataHorisontal;
                if (this.LoCH_EachColDataHorisontal)
                {
                    this.QLoCHColsDefined = this.QLoCHLines;
                    this.QLoCHData = this.QLoCHColumns;
                }
                else
                {
                    this.QLoCHColsDefined = this.QLoCHColumns;
                    this.QLoCHData = this.QLoCHLines;
                }
            }
            if (this.HdrsInCornerPresent)
            {
                excel.ParseCellName(data.HdrCrnr, ref this.CornerColN, ref this.CornerLineN);
            }
            if (this.TblHdrDataPresent)
            {
                excel.ParseCellName(data.TblHdrFirst, ref this.FirstTblHdrColumnN, ref this.FirstTblHdrLineN);
                excel.ParseCellName(data.TblHdrLast, ref this.LastTblHdrColumnN, ref this.LastTblHdrLineN);
                this.QTHLines = this.LastTblHdrLineN - this.FirstTblHdrLineN + 1;
                this.QTHCols = this.LastTblHdrColumnN - this.FirstTblHdrColumnN;
                this.QTblHdrData = this.QTHLines * this.QTHCols;

            }
            if (this.ColGenHdrDataPresent)
            {
                excel.ParseCellName(data.ColGenHdrFirst, ref this.FirstColGenHdrColumnN, ref this.FirstColGenHdrLineN);
                excel.ParseCellName(data.ColGenHdrLast, ref this.LastColGenHdrColumnN, ref this.LastColGenHdrLineN);
                this.QCGHLines = this.LastColGenHdrLineN - this.FirstColGenHdrLineN + 1;
                this.QCGHCols = this.LastColGenHdrColumnN - this.FirstColGenHdrColumnN + 1;
                this.QColGenHdrData = this.QCGHLines * this.QCGHCols;
            }
            if (this.LinGenHdrDataPresent)
            {
                excel.ParseCellName(data.LinGenHdrFirst, ref this.FirstLinGenHdrColumnN, ref this.FirstLinGenHdrLineN);
                excel.ParseCellName(data.LinGenHdrLast, ref this.LastLinGenHdrColumnN, ref this.LastLinGenHdrLineN);
                this.QLGHLines = this.LastLinGenHdrLineN - this.FirstLinGenHdrLineN + 1;
                this.QLGHCols = this.LastLinGenHdrColumnN - this.FirstLinGenHdrColumnN + 1;
                this.QLinGenHdrData = this.QLGHLines * this.QLGHCols;
            }
            if (this.CurCellDataPresent)
            {
                excel.ParseCellName(data.CurCellFirst, ref this.FirstCurCellColumnN, ref this.FirstCurCellLineN);
                excel.ParseCellName(data.CurCellLast, ref this.LastCurCellColumnN, ref this.LastCurCellLineN);
                this.QCurCellLines = this.LastCurCellLineN - this.FirstCurCellLineN;
                this.QCurCellCols = this.LastCurCellColumnN - this.FirstCurCellColumnN;
                this.QCurCellData = this.QCurCellLines * this.QCurCellCols;
                if (data.CurCellActiveValExcelCell)
                {
                    excel.ParseCellName(data.CurCellActiveVal, ref this.CurCellActiveValColumnN, ref this.CurCellActiveValLineN);
                }
                else
                {
                    this.CurCellActiveN = data.CurCellActiveN;//qu ver?
                }
            }
        }
        public TTable ToTable(ExcelHandler excel)
        {
            TTable tbl = null;
            DataCell[] cells = null;
            //DataCell TH = null, LGH = null, CGH = null;
            DataCellRow[] content;
            DataCellRow LoCH = null, CoLH = null;
            string corner;//, HeaderBef, HeaderAft;
            string TNm = "", LGNm = "", CGNm = "";
            TableHeaders hdrs = null;
            bool ColumnsNotLines;
            bool CornerCorrect = MyLib.BoolValByDefault;
            int QExtRows, QIneRows;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            int curLineN, curColN;
            int QLoCHs = MyLib.BoolToInt(this.LoCHDataPresent), QCoLHs = MyLib.BoolToInt(this.CoLHDataPresent);
            excel.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            int QLinesSelected = LastSelectedLineN - FirstSelectedLineN + 1,
                QColsSelected = LastSelectedColumnN - FirstSelectedColumnN + 1,
                ErstContentLineN, ErstContentColN, QLines, QColumns;
            string curS;
            if (this.LoCHDataPresent)
            {
                QLines = QLinesSelected - 1;
                ErstContentLineN = FirstSelectedLineN + 1;
            }
            else
            {
                QLines = QLinesSelected;
                ErstContentLineN = FirstSelectedLineN;
            }
            if (this.CoLHDataPresent)
            {
                QColumns = QColsSelected - 1;
                ErstContentColN = FirstSelectedColumnN + 1;
            }
            else
            {
                QColumns = QColsSelected;
                ErstContentColN = FirstSelectedColumnN;
            }
            ColumnsNotLines = this.ImportToVerticalRows;
            if (this.ImportToVerticalRows == false)
            {
                QExtRows = QLines;
                QIneRows = QColumns;
            }
            else
            {
                QExtRows = QColumns;
                QIneRows = QLines;
            }
            cells = new DataCell[QIneRows];
            if (this.ImportToVerticalRows == false)
            {
                QExtRows = QLines;
                QIneRows = QColumns;
            }
            else
            {
                QExtRows = QColumns;
                QIneRows = QLines;
            }
            //Reading content
            if (!this.ImportToVerticalRows)
            {
                content = new DataCellRow[QLines];
                for (int i = 1; i <= QLines; i++)
                {
                    cells = new DataCell[QColumns];
                    curLineN = ErstContentLineN + i - 1;
                    for (int j = 1; j <= QColumns; j++)
                    {
                        curColN = ErstContentColN + j - 1;
                        curS = excel.ReadContentFromExcelCell(this.ContentSheet, curColN, curLineN);
                        cells[j - 1] = new DataCell(curS);
                    }
                    content[i - 1] = new DataCellRow(cells, QColumns);
                }
            }
            else
            {
                content = new DataCellRow[QColumns];
                for (int i = 1; i <= QColumns; i++)
                {
                    cells = new DataCell[QLines];
                    curColN = ErstContentColN + i - 1;
                    for (int j = 1; j <= QColumns; j++)
                    {
                        curLineN = ErstContentLineN + j - 1;
                        curS = excel.ReadContentFromExcelCell(this.ContentSheet, curColN, curLineN);
                        cells[j - 1] = new DataCell(curS);
                    }
                    content[i - 1] = new DataCellRow(cells, QLines);
                }
            }
            //Line of Col Header
            if (this.LoCHDataPresent)
            {
                curLineN = this.FirstLoCHLineN;
                cells = new DataCell[QColumns];
                for (int j = 1; j <= QColumns; j++)
                {
                    curColN = ErstContentColN + j - 1;
                    curS = excel.ReadContentFromExcelCell(this.ContentSheet, curColN, curLineN);
                    cells[j - 1] = new DataCell(curS);
                }
                LoCH = new DataCellRow(cells, QColumns);
            }
            //Col of Line Header
            if (this.CoLHDataPresent)
            {
                if (!this.CoLH_EachLineDataVertical)//so each line data hor, so diff lunes data s' vertical col
                {
                    curColN = FirstCoLHColumnN;
                    cells = new DataCell[QLines];
                    for (int i = 1; i <= QLines; i++)
                    {
                        curLineN = FirstCoLHLineN + i - 1;
                        curS = excel.ReadContentFromExcelCell(this.ContentSheet, curColN, curLineN);
                        cells[i - 1] = new DataCell(curS);
                    }
                    CoLH = new DataCellRow(cells, QLines);
                }
                else //so each line data vert, so diff lines data s'hor line
                {
                    curLineN = FirstCoLHColumnN;
                    cells = new DataCell[QColumns];
                    for (int j = 1; j <= QColumns; j++)
                    {
                        curColN = FirstCoLHColumnN + j - 1;
                        curS = excel.ReadContentFromExcelCell(this.ContentSheet, curColN, curLineN);
                        cells[j - 1] = new DataCell(curS);
                    }
                    CoLH = new DataCellRow(cells, QColumns);
                }
            }
            //Corner
            if (this.HdrsInCornerPresent)
            {
                corner = excel.ReadContentFromExcelCell(this.ContentSheet, FirstSelectedColumnN, FirstSelectedLineN);
                MyLib.ParseNamesOfTableCorner(corner, ref CornerCorrect, ref LGNm, ref CGNm, ref TNm);
                if (TNm != "" || LGNm != "" || CGNm != "")
                {
                    //hdrs=new TableHeaders(new DataCell(TNm), new DataCell(LGNm), new DataCell(CGNm));
                    hdrs = new TableHeaders(TNm, "", LGNm, "", CGNm, "");
                }
            }
            //
            tbl = new TTable
                (
                new TableInfo(true, this.CoLHDataPresent, this.LoCHDataPresent, QLines, QColumns),
                ColumnsNotLines,
                content,
                LoCH,
                CoLH,
                hdrs,
                true
                );
            return tbl;
        }//fn
        /*
        public TTable GetAsTable(ExcelHandler excel)
        {
            TTable tbl = null;
            DataCell cell, TH_Cell=null, CGH_Cell=null, LGH_Cell=null, LoCH_Cell=null, CoLH_Cell=null, Cnt_Cell;
            DataCell[]cells;
            DataCellRow LoCHRow = null, CoLHRow = null;
            DataCellRow CurContentRow;
            DataCellRow[] ContRows = null;
            DataCellRowCoHeader rowHdrd;
            DataCellRowCoHeader[]rowsHeadered;
            TableHeaders tHdr=null;
            bool CornerValCorrect=false;
            int count=0, countTableRows=0;
            string CurContentCellContent="", CurLoCHCellContent="", CurCoLHCellContent="", THCellContent="", LGHCellContent="", CGHCellContent="", curStr="";
            //string cornerVal, crn_TN = "", crn_CGN = "", crn_LGN = "";
            string[]curArr=null;
            string curStr;
            //
            if (!this.ImportToVerticalRows)
            {
                this.R
            }
            else
            {

            }
            if (this.TblHdrDataPresent)
            {
                THCellContent = excel.ReadFormulaFromExcelCell(this.TblHdrSheet, this.FirstTblHdrColumnN, FirstTblHdrLineN);
                if(this.QLinGenHdrData>1){
                    curArr=new string[this.QLinGenHdrData];
                    count=0;
                    curArr=null;
                    if (this.ImportToVerticalRows == false)
                    {
                        for (int i = 1; i <= this.QTHLines; i++)
                        {
                            for (int j = 1; j <= this.QTHCols; j++)
                            {
                                curStr = excel.ReadFormulaFromExcelCell(this.CurCellSheet, this.FirstCurCellColumnN + j - 1, this.FirstCurCellLineN + i - 1);
                                MyLib.AddToVector(ref curArr, ref count, curStr);
                                //
                                //cell=new DataCell
                            }
                            //
                            CurContentRow = new DataCellRow(curArr, curArr.Length);
                            MyLib.AddToVector(ref ContRows, ref countTableRows, CurContentRow);
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= this.QTHCols; i++)
                        {
                            for (int j = 1; j <= this.QTHLines; j++)
                            {
                                curStr = excel.ReadFormulaFromExcelCell(this.CurCellSheet, this.FirstCurCellColumnN + i - 1, this.FirstCurCellLineN + j - 1);
                                MyLib.AddToVector(ref curArr, ref count, curStr);
                            }
                            //
                            CurContentRow = new DataCellRow(curArr, curArr.Length);
                            MyLib.AddToVector(ref ContRows, ref countTableRows, CurContentRow);
                        }
                    }
                    //
                    if(this.TblHdrDBType){
                        TH_Cell=new DataCell(TableConsts.DBTableHeaderTypeN, curArr, count);
                    }else if(count>1){
                        TH_Cell=new DataCell(curArr, count);
                    }
                }else{
                    TH_Cell=new DataCell(THCellContent);
                }
            }
            //
            if (this.ColGenHdrDataPresent)
            {
                //
                CGHCellContent = excel.ReadFormulaFromExcelCell(this.ColGenHdrSheet, this.FirstColGenHdrColumnN, this.FirstColGenHdrLineN);
                if(this.QLinGenHdrData>1){
                    curArr=new string[this.QColGenHdrData];
                    count=0;
                    curArr=null;
                    //cells = null;
                    //cells=new DataCell[]
                    for(int i=1; i<=this.QCGHLines; i++){
                        for(int j=1; j<=this.QCGHCols; j++){
                            curStr = excel.ReadFormulaFromExcelCell(this.ColGenHdrSheet, this.FirstColGenHdrColumnN + j - 1, this.FirstColGenHdrLineN + i - 1);
                            MyLib.AddToVector(ref curArr, ref count, curStr);
                        }
                        //if (this.ColGenHdrDBType)
                        //{
                        //    CGH_Cell = new DataCell(TableConsts.ColHeaderDBFieldOrItemsTypeN, curArr, count);
                        //}
                        //else
                        //{
                        //    if (count > 1)
                        //    {
                        //        CGH_Cell = new DataCell(curArr, count);
                        //    }
                        //    else
                        //    {
                        //        CGH_Cell = new DataCell(curArr[1 - 1]);
                        //    }
                        //}
                        //
                    }
                    if(this.ColGenHdrDBType){
                        CGH_Cell=new DataCell(TableConsts.ColHeaderDBFieldOrItemsTypeN, curArr, count);
                    }else if(count>1){
                        CGH_Cell=new DataCell(curArr, count);
                    }
                }else{
                    CGH_Cell=new DataCell(CGHCellContent);
                }
                //
            }
            // 
            if (this.LinGenHdrDataPresent) {
                //
                LGHCellContent = excel.ReadFormulaFromExcelCell(this.LinGenHdrSheet, this.FirstLinGenHdrColumnN, this.FirstLinGenHdrLineN);
                if (this.QLinGenHdrData > 1)
                {
                    curArr = new string[this.QLinGenHdrData];
                    count = 0;
                    curArr = null;
                    //cells = null;
                    //cells=new DataCell[]
                    for (int i = 1; i <= this.QLGHLines; i++)
                    {
                        for (int j = 1; j <= this.QLGHCols; j++)
                        {
                            curStr = excel.ReadFormulaFromExcelCell(this.LinGenHdrSheet, this.FirstLinGenHdrColumnN + j - 1, this.FirstLinGenHdrLineN + i - 1);
                            MyLib.AddToVector(ref curArr, ref count, curStr);
                        }
                        //if (this.ColGenHdrDBType)
                        //{
                        //    CGH_Cell = new DataCell(TableConsts.ColHeaderDBFieldOrItemsTypeN, curArr, count);
                        //}
                        //else
                        //{
                        //    if (count > 1)
                        //    {
                        //        CGH_Cell = new DataCell(curArr, count);
                        //    }
                        //    else
                        //    {
                        //        CGH_Cell = new DataCell(curArr[1 - 1]);
                        //    }
                        //}
                        //
                    }
                    if (this.ColGenHdrDBType)
                    {
                        LGH_Cell = new DataCell(TableConsts.ColHeaderDBFieldOrItemsTypeN, curArr, count);
                    }
                    else if (count > 1)
                    {
                        LGH_Cell = new DataCell(curArr, count);
                    }
                }
                else
                {
                    LGH_Cell = new DataCell(LGHCellContent);
                }
                //
            }
            //
            if (this.CoLHDataPresent)
            {
                //
                //CGHCellContent = excel.ReadFormulaFromExcelCell(this.ColGenHdrSheet, this.FirstColGenHdrColumnN, this.FirstColGenHdrLineN);
                //if (this.QCoLHData > 1)
                //{
                CoLHRow = new DataCellRow(false);    
                curArr = new string[this.QCoLHData];
                    count = 0;
                    curArr = null;
                    //cells = null;
                    //cells=new DataCell[]
                    if (this.CoLH_EachLineDataVertical == false)//ma hor
                    {
                        for (int i = 1; i <= this.QCoLHLinesDefined; i++)
                        {
                            curArr = null;//new string[this.QCoLHData];
                            for (int j = 1; j <= this.QCoLHData; j++)
                            {
                                //curArr[j - 1] = excel.ReadFormulaFromExcelCell(this.CoLHSheet, this.FirstCoLHColumnN + j - 1, this.FirstCoLHLineN + i - 1);
                                curStr = excel.ReadFormulaFromExcelCell(this.CoLHSheet, this.FirstCoLHColumnN + j - 1, this.FirstCoLHLineN + i - 1);
                                MyLib.AddToVector(ref curArr, ref count, curStr);
                            }
                            if (this.CoLHDBType)
                            {
                                cell = new DataCell(TableConsts.ColHeaderDBFieldOrItemsTypeN, curArr, count);
                            }
                            else
                            {
                                if (count > 1)
                                {
                                    cell = new DataCell(TableConsts.StringArrayTypeN, curArr, count);
                                }
                                else
                                {
                                    cell = new DataCell(curStr);
                                }
                            }
                            CoLHRow.Add(cell);
                        }
                    }
                    else
                    {//so if this.CoLH_EachLineDataVertical==true
                        for (int i = 1; i <= this.QCoLHLinesDefined; i++)
                        {
                            curArr = null;//new string[this.QCoLHData];
                            for (int j = 1; j <= this.QCoLHData; j++)
                            {
                                //curArr[j - 1] = excel.ReadFormulaFromExcelCell(this.CoLHSheet, this.FirstCoLHColumnN + j - 1, this.FirstCoLHLineN + i - 1);
                                curStr = excel.ReadFormulaFromExcelCell(this.CoLHSheet, this.FirstCoLHColumnN + i - 1, this.FirstCoLHLineN + j - 1);
                                MyLib.AddToVector(ref curArr, ref count, curStr);
                            }
                            if (this.CoLHDBType)
                            {
                                cell = new DataCell(TableConsts.ColHeaderDBFieldOrItemsTypeN, curArr, count);
                            }
                            else
                            {
                                if (count > 1)
                                {
                                    cell = new DataCell(TableConsts.StringArrayTypeN, curArr, count);
                                }
                                else
                                {
                                    cell = new DataCell(curStr);
                                }
                            }
                            CoLHRow.Add(cell);
                        }
                    }
                //}
                //else //if QCoLHData=1
                //{
                //    if (this.CoLH_EachLineDataVertical==false)
                //    {

                //    }
                //    else
                //    {

                //    }
                //}
            }
            //
            if (this.LoCHDataPresent)
            {
                curArr = new string[this.QLoCHData];
                count = 0;
                curArr = null;
                LoCHRow = new DataCellRow(false);
                if (this.LoCH_EachColDataHorisontal == false)//ma hor
                {
                    for (int i = 1; i <= this.QLoCHColsDefined; i++)
                    {
                        curArr = null;//new string[this.QCoLHData];
                        for (int j = 1; j <= this.QLoCHData; j++)
                        {
                            //curArr[j - 1] = excel.ReadFormulaFromExcelCell(this.CoLHSheet, this.FirstCoLHColumnN + j - 1, this.FirstCoLHLineN + i - 1);
                            curStr = excel.ReadFormulaFromExcelCell(this.LoCHSheet, this.FirstLoCHColumnN + i - 1, this.FirstLoCHLineN + j - 1);
                            MyLib.AddToVector(ref curArr, ref count, curStr);
                        }
                        if (this.LoCHDBType)
                        {
                            cell = new DataCell(TableConsts.ColHeaderDBFieldOrItemsTypeN, curArr, count);
                        }
                        else
                        {
                            if (count > 1)
                            {
                                cell = new DataCell(TableConsts.StringArrayTypeN, curArr, count);
                            }
                            else
                            {
                                cell = new DataCell(curStr);
                            }
                        }
                        LoCHRow.Add(cell);
                    }
                }
                else
                {//so if this.CoLH_EachColsDataHorisontal==true
                    for (int i = 1; i <= this.QLoCHColsDefined; i++)
                    {
                        curArr = null;//new string[this.QCoLHData];
                        for (int j = 1; j <= this.QLoCHData; j++)
                        {
                            //curArr[j - 1] = excel.ReadFormulaFromExcelCell(this.CoLHSheet, this.FirstCoLHColumnN + j - 1, this.FirstCoLHLineN + i - 1);
                            curStr = excel.ReadFormulaFromExcelCell(this.LoCHSheet, this.FirstLoCHColumnN + j - 1, this.FirstLoCHLineN + i - 1);
                            MyLib.AddToVector(ref curArr, ref count, curStr);
                        }
                        if (this.CoLHDBType)
                        {
                            cell = new DataCell(TableConsts.ColHeaderDBFieldOrItemsTypeN, curArr, count);
                        }
                        else
                        {
                            if (count > 1)
                            {
                                cell = new DataCell(TableConsts.StringArrayTypeN, curArr, count);
                            }
                            else
                            {
                                cell = new DataCell(curStr);
                            }
                        }
                        LoCHRow.Add(cell);
                    }
                }//how dsata s'oriented in Excel
            }//if LoCH
            //
            if (this.HdrsInCornerPresent)
            {
                cornerVal = excel.ReadFormulaFromExcelCell(this.HdrCrnrSheet, this.CornerColN, this.CornerLineN);
                MyLib.ParseNamesOfTableCorner(cornerVal, ref CornerValCorrect, ref crn_LGN, ref crn_CGN, ref crn_TN);
                if (crn_TN != "" && THCellContent== "") {
                    THCellContent = crn_TN;
                }
                if (crn_CGN != "" && CGHCellContent == "")
                {
                    CGHCellContent = crn_CGN;
                }
                if (crn_LGN != "" && LGHCellContent == "")
                {
                    LGHCellContent = crn_LGN;
                }
            }//HdrsInCornerPresent
            //
            if (this.ImportToVerticalRows==false)
            {
                ContRows = new DataCellRow[QLines];
                for (int i = 1; i <= this.QLines; i++)
                {
                    ContRows[i - 1] = new DataCellRow(false);
                    for (int j = 1; j <= this.QColumns; j++)
                    {
                        curStr = excel.ReadFormulaFromExcelCell(this.ContentSheet, this.FirstContentColumnN + j - 1, this.FirstContentLineN + i - 1);
                        cell = new DataCell(curStr);
                        ContRows[i - 1].Add(cell);
                    }
                }
            }
            else
            {
                ContRows = new DataCellRow[QColumns];
                for (int i = 1; i <= this.QColumns; i++)
                {
                    for (int j = 1; j <= this.QLines; j++)
                    {
                        curStr = excel.ReadFormulaFromExcelCell(this.ContentSheet, this.FirstContentColumnN + j - 1, this.FirstContentLineN + i - 1);
                        cell = new DataCell(curStr);
                        ContRows[i - 1].Add(cell);
                    }
                }
            }
            //
            if(TH_Cell!=null || CGH_Cell!=null || LGH_Cell!=null){
                tHdr=new TableHeaders(TH_Cell, LGH_Cell, CGH_Cell);  
            }
            tbl = new TTable(
                new TableInfo(!this.ImportToVerticalRows, this.CoLHDataPresent, this.LoCHDataPresent, this.QLines, this.QColumns),
                this.ImportToVerticalRows,
                ContRows,
                LoCHRow,
                CoLHRow,
                tHdr,
                true
                ); 
            //
            return tbl;
        }//fn get as table
        */
        public void ToExcelFromTable(TTable tbl, ExcelHandler excel)
        {

        }
        //public DataTable GetContentAsDataTable(ExcelHandler excel)
        //{
        //    DataTable tbl = new DataTable();
        //    DataColumn aCol = new DataColumn();
        //    DataColumn[] cols = null;
        //    string CurColName, CurLineName, CurContentCell, tblName = "ExcelTable", corn = "Headers", crnr, crnr_LGN = "", crnr_CGN = "", crnr_TN = "";
        //    DataRow row;
        //    bool CornerCorrect = false;
        //    string[] ColNames = null;
        //    //
        //    if (this.CoLHDataPresent == false)
        //    {
        //        cols = new DataColumn[this.QColumns];
        //        ColNames = new string[this.QColumns];
        //        for (int i = 1; i <= this.QColumns; i++)
        //        {
        //            if (i > this.QLoCHColumns || !this.CoLHDataPresent)
        //            {
        //                CurColName = "Col" + i.ToString();
        //                ColNames[i - 1] = CurColName;
        //            }
        //            else
        //            {
        //                CurColName = excel.ReadFormulaFromExcelCell(this.LoCHSheet, this.FirstLoCHColumnN + i - 1, this.FirstLoCHLineN);
        //                ColNames[i - 1] = CurColName;
        //            }
        //            cols[i - 1] = new DataColumn(CurColName);
        //        }
        //        //
        //        for (int i = 1; i <= this.QLines; i++)
        //        {
        //            row = tbl.NewRow();
        //            for (int j = 1; j <= this.QColumns; j++)
        //            {
        //                CurContentCell = excel.ReadFormulaFromExcelCell(this.ContentSheet, this.FirstContentColumnN + j - 1, this.FirstContentLineN + i - 1);
        //                row[ColNames[j - 1]] = CurContentCell;
        //            }
        //            tbl.Rows.Add(row);
        //        }
        //    }
        //    else
        //    {
        //        //corner:LGN\CGN, Col(corner) of CoLH, ^
        //        if (this.HdrsInCornerPresent)
        //        {
        //            crnr = excel.ReadFormulaFromExcelCell(this.HdrCrnrSheet, this.FirstTblHdrColumnN, this.FirstTblHdrLineN);
        //            MyLib.ParseNamesOfTableCorner(crnr, ref CornerCorrect, ref crnr_LGN, ref crnr_CGN, ref crnr_TN);
        //            if (CornerCorrect)
        //            {
        //                //tblName = crnr_TN;
        //                corn = crnr;
        //                if (crnr_TN != null && crnr_TN != "")
        //                {
        //                    tblName = crnr_TN;
        //                }
        //            }
        //        }//corn
        //        //
        //        cols = new DataColumn[this.QColumns + 1];
        //        ColNames = new string[this.QColumns + 1];
        //        ColNames[0] = corn;
        //        cols[0] = new DataColumn(corn);
        //        for (int i = 1; i <= this.QColumns; i++)
        //        {
        //            if (i > this.QLoCHColumns || !this.CoLHDataPresent)
        //            {
        //                CurColName = "Col" + i.ToString();
        //                ColNames[i] = CurColName;
        //            }
        //            else
        //            {
        //                CurColName = excel.ReadFormulaFromExcelCell(this.LoCHSheet, this.FirstLoCHColumnN + i - 1, this.FirstLoCHLineN);
        //                ColNames[i] = CurColName;
        //            }
        //            cols[i] = new DataColumn(CurColName);
        //        }
        //        //
        //        for (int i = 1; i <= this.QLines; i++)
        //        {
        //            row = tbl.NewRow();
        //            CurLineName = excel.ReadFormulaFromExcelCell(this.CoLHSheet, this.FirstCoLHColumnN, this.FirstCoLHLineN + i - 1);
        //            row[corn] = CurLineName;
        //            for (int j = 1; j <= this.QColumns; j++)
        //            {
        //                CurContentCell = excel.ReadFormulaFromExcelCell(this.ContentSheet, this.FirstContentColumnN + j - 1, this.FirstContentLineN + i - 1);
        //                row[ColNames[j - 1]] = CurContentCell;
        //            }
        //            tbl.Rows.Add(row);
        //        }
        //    }
        //    //
        //    if (this.TblHdrDataPresent)
        //    {
        //        tblName = excel.ReadFormulaFromExcelCell(this.TblHdrSheet, this.FirstTblHdrColumnN, this.FirstTblHdrLineN);
        //    }
        //    else if (this.HdrsInCornerPresent)
        //    {
        //        crnr = excel.ReadFormulaFromExcelCell(this.HdrCrnrSheet, this.FirstTblHdrColumnN, this.FirstTblHdrLineN);
        //        MyLib.ParseNamesOfTableCorner(crnr, ref CornerCorrect, ref crnr_LGN, ref crnr_CGN, ref crnr_TN);
        //        if (CornerCorrect && crnr_TN != null && crnr_TN != "")
        //        {
        //            tblName = crnr_TN;
        //        }
        //    }
        //    tbl.TableName = tblName;
        //    return tbl;
        //}//fn get vas dataTable
        //public TTable ToTable(bool LoCHExists, bool CoLHExists, bool SeparateHeaderExists, string[] SeparateHeaders = null)//, int QLoCHs = 0, int QCoLHs = 0)


    }//cl

    /*public class TRangeSelectedNs
    {
        public int FirstSelectedColN, FirstSelectedLineN, LastSelectedColN, LastSelectedLineN,
                   FirstContentColN, FirstContentLineN, LastContentColN, LastContentLineN,
                   FirstLoCHColN, FirstLoCHLineN, LastLoCHColN, LastLoCHLineN,
                   FirstCoLHColN, FirstCoLHLineN, LastCoLHColN, LastCoLHLineN,
                   QLinesSelected, QColumnsSelected, QLinesContent, QColumnsContent,
                   QLoCHs, QCoLHs;
        public int FirstHdrColN, FirstHdrLineN, LastHdrColN, LastHdrLineN,
                   HdrCGHColN, HdrCGHLineN,
                   //
                   HdrCGHLastColN, HdrCGHLastLineN,
                   HdrLGHColN, HdrLGHLineN,
                   HdrLGHLastColN, HdrLGHLastLineN,
                   //
                   QHdrLines, QHdrCols,
                   //
                   QLGHCols, QLGHLines, QCGHCols, QCGHLines;
        public TRangeSelectedNs()
        {
            this.FirstSelectedColN=0; this.FirstSelectedLineN=0; this.LastSelectedColN=0; this.LastSelectedLineN=0; 
            this.FirstContentColN=0; this.FirstContentLineN=0; this.LastContentColN=0; this.LastContentLineN=0; 
            this.FirstLoCHColN=0; this.FirstLoCHLineN=0; this.LastLoCHColN=0; this.LastLoCHLineN=0; 
            this. FirstCoLHColN=0; this.FirstCoLHLineN=0; this.LastCoLHColN=0; this.LastCoLHLineN=0; 
            this.QLinesSelected=0; this.QColumnsSelected=0; this.QLinesContent=0; this.QColumnsContent=0;
            this.QLoCHs = 0; this.QCoLHs = 0; 
            //---
            this.FirstHdrColN = 0; this.FirstHdrLineN = 0; this.LastHdrColN = 0; this.LastHdrLineN = 0;
            this.HdrCGHColN=0; this.HdrCGHLineN=0;
            //
            this.HdrCGHLastColN=0; this.HdrCGHLastLineN=0;
            this.HdrLGHColN=0; this.HdrLGHLineN=0;
            this.HdrLGHLastColN=0; this.HdrLGHLastLineN=0;
            //
            this.QHdrLines=0; this.QHdrCols=0;
            //
            this.QLGHCols=0; this.QLGHLines=0; this.QCGHCols=0; this.QCGHLines=0;
        }_2 
        public void Set(int FirstSelectedColN, int FirstSelectedLineN, int LastSelectedColN, int LastSelectedLineN, int QLoCHs, int QCoLHs)
        {
            this.FirstSelectedColN = FirstSelectedColN; this.FirstSelectedLineN = FirstSelectedLineN;
            this.LastSelectedColN = LastSelectedColN; this.LastSelectedLineN = LastSelectedLineN;
            this.QLoCHs = QLoCHs; this.QCoLHs = QCoLHs;
            //
            this.QLinesSelected = LastSelectedLineN-FirstSelectedLineN+1;
            this.QColumnsSelected = LastSelectedColN - FirstSelectedColN + 1;
            //
            this.QLoCHs = QLoCHs; this.QCoLHs = QCoLHs;
            this.QLinesContent = QLinesSelected - QLoCHs; this.QColumnsContent = QColumnsSelected - QCoLHs;
            //
            this.FirstContentColN=this.FirstSelectedColN+QCoLHs; 
            this.FirstContentLineN=this.FirstSelectedLineN+QLoCHs;
            this.LastContentColN = this.LastSelectedColN; this.LastContentLineN = this.LastSelectedLineN;
            //
            if (QLoCHs != 0)
            {
                this.FirstLoCHColN = this.FirstContentColN;
                this.FirstLoCHLineN = this.FirstSelectedLineN;
                this.LastLoCHColN = this.LastContentColN;//=LastContentColN
                this.LastLoCHLineN = this.FirstLoCHLineN + this.QLoCHs-1;
            }
            if (QCoLHs != 0)
            {
                this.FirstCoLHColN = this.FirstSelectedColN;
                this.FirstCoLHLineN = this.FirstContentLineN;
                this.LastCoLHColN = this.FirstSelectedColN+this.QCoLHs-1;
                this.LastCoLHLineN = this.LastSelectedLineN;//=LastContentLineN
            }
        }
    }*/
}
