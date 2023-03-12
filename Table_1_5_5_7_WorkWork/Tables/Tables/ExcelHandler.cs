using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
//Project-Add reference-COM-
//Project-Add reference-NET-Microsoft.Office.Interop.Excel //vikt!
using Excel = Microsoft.Office.Interop.Excel;

namespace Tables
{
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
            this.CurCellTypeN=TableConsts.StringTypeN;
            this.CurCellActiveN=1;
            this.CurCellDataPresent=false;
            this.CurCellActiveValNotDefault=false;
            this.CurCellActiveValExcelCell=false;
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
        public int CurCell_First_LineN, CurCell_First_ColN, CurCell_Last_LineN, CurCell_Last_ColN, CurCellActiveVal_LineN, CurCellActiveVal_ColN, QItems, QLines, QColumns;
        //
        public TExcelCellFitData()
        {
            this.SetDefault();
        }
        public void SetDefault()
        {
            this.CurCellFirst="";
            this.CurCellLast="";
            this.CurCellActiveVal="";
            this.CurCellSheet="";
            //public string CurCellType;
            this.CurCellTypeN=TableConsts.StringTypeN;
            this.CurCellActiveN=1;
            this.CurCellActiveValNotDefault=false;
            this.CurCellActiveValExcelCell=false;
            //
            this.CurCell_First_LineN=0;
            this.CurCell_First_ColN=0;
            this.CurCell_Last_LineN=0;
            this.CurCell_Last_ColN=0;
            this.CurCellActiveVal_LineN=0;
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
            this.CurCellTypeN=FormData.CurCellTypeN;
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
            DataCell cell=new DataCell();
            cell.SetTypeN(this.CurCellTypeN, null);
            string[] items = null;
            string[] names = null;
            string SnglVal="";
            double dblVal=0;
            float fltVal=0;
            int intVal=0;
            bool boolVal=MyLib.BoolValByDefault;
            int count=0, CurLineN, CurColN;
            if (this.QItems > 1){
                for (int i = 1; i <= this.QLines; i++){
                    for (int j = 1; j <= this.QColumns; j++){
                        SnglVal=excel.ReadFormulaFromExcelCell(this.CurCellSheet, this.CurCell_First_ColN+j-1, this.CurCell_First_LineN+i-1);
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
                }else {
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
        public TExcelTableFitFormData(){
            ContentFirst="";
            ContentLast="";
            CoLHFirst="";
            CoLHLast="";
            LoCHFirst="";
            LoCHLast="";
            HdrCrnr="";
            TblHdrFirst="";
            TblHdrLast = "";
            ColGenHdrFirst="";
            ColGenHdrLast="";
            LinGenHdrFirst="";
            LinGenHdrLast="";
            CurCellFirst="";
            CurCellLast="";
            CurCellActiveVal="";
            ContentSheet="";
            CoLHSheet="";
            LoCHSheet="";
            HdrCrnrSheet="";
            TblHdrSheet="";
            ColGenHdrSheet="";
            LinGenHdrSheet = "";
            CurCellSheet="";
            //
            CurCellType = "";
            CurCellTypeN = 0;
            //
            HdrsInCornerPresent= false;
            TblHdrDataPresent= false;
            LinGenHdrDataPresent= false;
            ColGenHdrDataPresent= false;
            LoCHDataPresent= false;
            CoLHDataPresent = false;
            CurCellDataPresent = false;
            //
            ContentExportDBData = false;
            //ContentDBType = false;
            CoLHExportDBData=false;
            CoLHDBType=false;
            CoLH1stOnly=false;
            CoLHEachLineDataVertical=false;
            LoCHExportDBData=false;
            LoCHDBType=false;
            LoCH1stOnly=false;
            LoCHEachColumnDataHorisontal=false;
            HdrCrnrExportDBData=false;
            HdrCrnrDBType=false;
            TblHdrExportDBData=false;
            TblHdrDBType=false;
            ColGenHdrExportDBData=false;
            ColGenHdrDBType=false;
            LinGenHdrExportDBData=false;
            LinGenHdrDBType=false;
            CurCellExportDBData = false; 
            //CurCellDBType = false;
            CurCellActiveValNotDefault = false;
            CurCellActiveValExcelCell = false;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
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
        public string ContentSheet, CoLHSheet, LoCHSheet, HdrCrnrSheet, TblHdrSheet,
               ColGenHdrSheet, LinGenHdrSheet, CurCellSheet;
        //
        public TExcelTableFitInfo()
        {
            FirstContentLineN=0;
            LastContentLineN=0;
            FirstContentColumnN=0;
            LastContentColumnN=0;
            QLines=0;
            QColumns=0;
            //
            FirstLoCHLineN=0;
            LastLoCHLineN=0;
            FirstLoCHColumnN=0;
            LastLoCHColumnN=0;
            QLoCHLines=0;
            QLoCHColumns=0;
            QLoCHColsDefined=0;
            QLoCHData=0;
            //
            FirstCoLHLineN=0;
            LastCoLHLineN=0;
            FirstCoLHColumnN=0;
            LastCoLHColumnN=0;
            QCoLHLines=0;
            QCoLHColumns=0;
            QCoLHLinesDefined=0;
            QCoLHData=0;
            //
            CornerLineN=0;
            CornerColN=0;
            //
            FirstTblHdrLineN=0;
            LastTblHdrLineN=0;
            FirstTblHdrColumnN=0;
            LastTblHdrColumnN=0;
            QTblHdrData=0;
            //
            FirstLinGenHdrLineN=0;
            LastLinGenHdrLineN=0;
            FirstLinGenHdrColumnN=0;
            LastLinGenHdrColumnN=0;
            QLinGenHdrData=0;
            //
            FirstColGenHdrLineN=0;
            LastColGenHdrLineN=0;
            FirstColGenHdrColumnN=0;
            LastColGenHdrColumnN = 0;
            QColGenHdrData=0;
            //
            FirstCurCellLineN=0;
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
            QTHLines=0;
            QTHCols=0;
            QLGHLines=0;
            QLGHCols=0;
            QCGHLines=0;
            QCGHCols=0;
            QCurCellLines = 0;
            QCurCellCols=0;
            //
            HdrsInCornerPresent=false;
            TblHdrDataPresent=false;
            LinGenHdrDataPresent=false;
            ColGenHdrDataPresent=false;
            LoCHDataPresent = false;
            CoLHDataPresent = false;
            CurCellDataPresent = false;
            //
            CoLHExportDBData=false;CoLHDBType=false;
            LoCHExportDBData=false; LoCHDBType=false;
            HdrCrnrExportDBData=false; HdrCrnrDBType=false;
            TblHdrExportDBData=false; TblHdrDBType=false;
            ColGenHdrExportDBData=false; ColGenHdrDBType=false;
            LinGenHdrExportDBData = false; LinGenHdrDBType = false;
            CurCellExportDBData = false;
            //
            //LoCH_EachColDataVertical = true;
            //CoLH_EachLineDataHorisontal = false;
            LoCH_EachColDataHorisontal = false;
            CoLH_EachLineDataVertical = false;
            //
            ContentSheet="";
            CoLHSheet="";
            LoCHSheet="";
            HdrCrnrSheet="";
            TblHdrSheet="";
            ColGenHdrSheet="";
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
            this.HdrsInCornerPresent= data.HdrsInCornerPresent;
            this.TblHdrDataPresent= data.TblHdrDataPresent;
            this.LinGenHdrDataPresent= data.LinGenHdrDataPresent;
            this.ColGenHdrDataPresent= data.ColGenHdrDataPresent;
            this.LoCHDataPresent= data.LoCHDataPresent;
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
                this.QLoCHLines = this.LastLoCHLineN - this.FirstLoCHLineN+1;
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
                this.QTHLines = this.LastTblHdrLineN - this.FirstTblHdrLineN+1;
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
        public TTable GetAsTable(ExcelHandler excel)
        {
            TTable tbl = null;
            DataCell cell;
            int count=0;
            string CurContentCellContent="", CurLoCHCellContent="", CurCoLHCellContent="", THCellContent="", LGHCellContent="", CGHCellContent="", curStr="";
            string[]curArr=null;
            if (this.TblHdrDataPresent)
            {
                THCellContent = excel.ReadFormulaFromExcelCell(this.TblHdrSheet, this.FirstTblHdrColumnN, FirstTblHdrLineN);
                if(this.QLinGenHdrData>1){
                    curArr=new string[this.QLinGenHdrData];
                    count=0;
                    curArr=null;
                    for(int i=1; i<=this.QTHLines; i++){
                        for(int j=1; j<=this.QTHCols; j++){
                            curStr=excel.ReadFormulaFromExcelCell(this.CurCellSheet, this.FirstCurCellColumnN+j-1, this.FirstCurCellLineN+i-1);
                            MyLib.AddToVector(ref curArr, ref count, curStr);
                        }
                    }
                    //if(this.DB
                }
            }
            if (this.ColGenHdrDataPresent)
            {
                CurCoLHCellContent = excel.ReadFormulaFromExcelCell(this.ColGenHdrSheet, this.FirstColGenHdrColumnN, this.FirstColGenHdrLineN);
            }
            if (this.LinGenHdrDataPresent)
            {
                //LGHCellContent=excel.ReadFormulaFromExcelCell(this.LinGenHdrSheet, this.
            }
            return tbl;
        }
    }//cl
    public class TRangeSelectedNs
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
        }
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
    }
    public class ExcelHandler
    {
        private Excel.Application excelApp;
        private Excel.Window excelWindow;
        private Excel.Workbook workBook;
        private Excel.Worksheet workSheet;
        private Excel.Range excelCells;
        private int Etappe_NotConnected0_Connected1_Closed2;
        private int SysBase;//MinDigit, MaxDigit,
        public TRangeSelectedNs RangeSelectedNs;
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
            RangeSelectedNs = new TRangeSelectedNs();
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
        public void CreateNewExcelDoc()//5 sheets //3 sheets
        {
            RunExcelApplication();
            Etappe_NotConnected0_Connected1_Closed2 =1;
            //
            excelApp.SheetsInNewWorkbook = 3;
            excelApp.Workbooks.Add(Type.Missing);
            excelApp.SheetsInNewWorkbook = 5;
            excelApp.Workbooks.Add(Type.Missing);
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
        public void ToDataCellArray(bool LoCHExists, bool CoLHExists, ref DataCell[][] cellsArr)
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
        }
        public TTable ToTable(bool LoCHExists, bool CoLHExists, bool SeparateHeaderExists, string[]SeparateHeaders=null)//, int QLoCHs = 0, int QCoLHs = 0)
        {
            TTable tbl = null;
            DataCell[] cells = null;
            DataCellRow[] content;
            DataCellRow LoCH = null, CoLH = null;
            string corner, HeaderBef, HeaderAft;
            TableHeaders hdrs=null;
            int FirstSelectedColumnN = 0, FirstSelectedLineN = 0, LastSelectedColumnN = 0, LastSelectedLineN = 0;
            int curLineN, curColN;
            int QLoCHs = MyLib.BoolToInt(LoCHExists), QCoLHs = MyLib.BoolToInt(CoLHExists);
            this.GetActiveRangeNsByLeftAdr(ref FirstSelectedColumnN, ref FirstSelectedLineN, ref LastSelectedColumnN, ref LastSelectedLineN, null);
            this.RangeSelectedNs.Set(FirstSelectedColumnN, FirstSelectedLineN, LastSelectedColumnN, LastSelectedLineN, QLoCHs, QCoLHs);
            //cells = new DataCell[this.RangeSelectedNs.QLinesContent][];
            content = new DataCellRow[this.RangeSelectedNs.QLinesContent];
            for (int i = 1; i <= this.RangeSelectedNs.QLinesContent; i++)
            {
                cells = new DataCell[this.RangeSelectedNs.QColumnsContent];
                for (int j = 1; j <= this.RangeSelectedNs.QColumnsContent; j++)
                {
                    curLineN = this.RangeSelectedNs.FirstContentLineN + i - 1;
                    curColN = this.RangeSelectedNs.FirstContentColN + j - 1;
                    cells[j - 1] = new DataCell(this.excelApp.ActiveSheet.Range("A1").offset(curColN - 1, curLineN - 1).Value);
                }
                content[i - 1] = new DataCellRow(cells, this.RangeSelectedNs.QColumnsContent);
            }
            //cellsArr = new DataCell[this.RangeSelectedNs.QLinesContent][];
            for (int i = 1; i <= this.RangeSelectedNs.QLinesContent; i++)
            {
                //cellsArr[i - 1] = new DataCell[this.RangeSelectedNs.QColumnsContent];
                for (int j = 1; j <= this.RangeSelectedNs.QColumnsContent; j++)
                {
                    curLineN = this.RangeSelectedNs.FirstContentLineN + i - 1;
                    curColN = this.RangeSelectedNs.FirstContentColN + j - 1;
                    //cellsArr[i - 1][j - 1] = new DataCell(this.excelApp.ActiveSheet.Range("A1").offset(curColN - 1, curLineN - 1).Value);
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
                for (int i = 1; i <= this.RangeSelectedNs.QLinesContent; i++)
                {
                    curLineN = this.RangeSelectedNs.FirstContentLineN + i - 1;//this.RangeSelectedNs.FirstSelectedLineN + QLoCHs - 1;
                    curColN = this.RangeSelectedNs.FirstContentColN + QCoLHs - 1;
                    cells[i - 1] = new DataCell(this.excelApp.ActiveSheet.Range("A1").offset(curColN - 1, curLineN - 1).Value);
                }
                CoLH = new DataCellRow(cells, this.RangeSelectedNs.QLinesContent);
            }
            if (LoCHExists && CoLHExists  /*||this.checkBox.checked */ && SeparateHeaderExists==false)
            {
                corner=(this.excelCells.get_Value()).ToString(); 
                hdrs=new TableHeaders(corner);
            }
            else if (SeparateHeaderExists)
            {

            }
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

