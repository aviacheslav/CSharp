using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Windows.Forms;//for  DataGridView
using System.IO;//sTREAMwRITER
using System.Data;//DataTable
//
//
//mark 1 - 1189,
//mark 2 - 2288,
//mark 3 - 3305,
//mark 4 - 4400,
//mark 5 - 5533,
//mark 6 - 6702,
//mark 7 - 7808,
//mark 8 - 8871,
//mark 9 - 9968,
//mark10 - 10876,
//mark11 - 12200,
//mark12 - 13368
//mark13 - 14730
//reserved
//fin - 15330
//
namespace Tables
{
    //
    public class TTable:ICloneable
    {
        TableInfo TblInf;
        int id;
        DataCell /*TableName,*/ SpecCell;
        //DataCell LinesGeneralName, ColumnsGeneralName;
        TableHeaders Headers;
        DataCell[] LineOfColHeader, ColOfLineHeader;
        DataCell[][] ContentCell;
        //string LinesGeneralName, ColsGeneralName;
        //int QLines, QColumns;
        public TTable()
        {
            ConstructTableSimpleMax();
        }
        public TTable(bool CoLHExists, int QColumns, TableHeaders Headers, DataCellRow ColHeaders = null, DataCellTypeInfo[] ColsTypeInf = null, bool WriteInfo = true, bool LC_not_CL=true)
        {
            DataCellTypeInfo TypeInf=null;
            int QLines=1;
            bool LoCHExists = (ColHeaders != null);
            TableInfo TblInf=new TableInfo(LC_not_CL, CoLHExists, LoCHExists, QLines, QColumns);
            //TypeInf=new DataCellTypeInfo(TableConsts.DefaultContentCellTypeN, 1); //ob 
            if(ColsTypeInf==null){
                TypeInf=new DataCellTypeInfo(TableConsts.DefaultContentCellTypeN, 1);
                if (LC_not_CL)
                {
                    this.ContentCell = new DataCell[QLines][];
                    for(int i=1; i<=QLines; i++){
                        this.ContentCell[i - 1] = new DataCell[QColumns];
                    }
                    for (int i = 1; i <= QLines; i++)
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            this.ContentCell[i - 1][j - 1] = new DataCell(TypeInf);
                        }
                    }
                }
                else
                {
                    this.ContentCell = new DataCell[QColumns][];
                    for (int i = 1; i <= QColumns; i++)
                    {
                        this.ContentCell[i - 1] = new DataCell[QLines];
                    }
                    for (int i = 1; i <= QColumns; i++)
                    {
                        for (int j = 1; j <= QLines; j++)
                        {
                            this.ContentCell[i - 1][j - 1] = new DataCell(TypeInf);
                        }
                    }
                }
            }else{
                if (LC_not_CL)
                {
                    this.ContentCell = new DataCell[QLines][];
                    for (int i = 1; i <= QLines; i++)
                    {
                        this.ContentCell[i - 1] = new DataCell[QColumns];
                    }
                    for (int i = 1; i <= QLines; i++)
                    {
                        
                        for (int j = 1; j <= QColumns; j++)
                        {
                            TypeInf = ColsTypeInf[j - 1];
                            this.ContentCell[i - 1][j - 1] = new DataCell(TypeInf);
                        }
                    }
                }
                else
                {
                    this.ContentCell = new DataCell[QColumns][];
                    for (int i = 1; i <= QColumns; i++)
                    {
                        this.ContentCell[i - 1] = new DataCell[QLines];
                    }
                    for (int i = 1; i <= QColumns; i++)
                    {
                        TypeInf = ColsTypeInf[i - 1];
                        for (int j = 1; j <= QLines; j++)
                        {
                            this.ContentCell[i - 1][j - 1] = new DataCell(TypeInf);
                        }
                    }
                }
            }
            //
            if (ColHeaders != null){
                ColOfLineHeader = new DataCell[QColumns];
                for (int i = 1; i <= QColumns; i++)
                {
                    this.ColOfLineHeader[i - 1] = ColHeaders.GetCellN(i);
                }
            }
            if (CoLHExists)
            {
                LineOfColHeader = new DataCell[QLines];
                TypeInf = new DataCellTypeInfo(TableConsts.DefaultColOfLineHeaderCellTypeN, 1);
                LineOfColHeader[1 - 1] = new DataCell(TypeInf);
            }
            if (Headers != null) this.Headers = Headers;
            if (WriteInfo) this.TblInf = TblInf;
        }
        //
        public TTable(DataCellRowCoHeader FirstRow, TableHeaders Headers, bool DBStartNotList = true, DataCellRow HeadersRow = null, bool WriteInfo = true, bool LC_not_CL = true)
        {//second best - new
            DataCellTypeInfo TypeInf = null;
            DataCell cell = null;
            TableInfo TblInf = null;
            bool LoCHExists, CoLHExists;
            int QLines = 1, QColumns = 1;
            //TableInf, ColOfLineHeader, LineOfColHeader
            if (DBStartNotList)
            {
                LoCHExists = (HeadersRow != null);
                if (FirstRow != null)
                {
                    CoLHExists = (FirstRow.GetHeader() != null);
                    QColumns = FirstRow.GetQContentCells();
                    //this.LineOfColHeader = new DataCell[QColumns];
                    if (CoLHExists) this.ColOfLineHeader = new DataCell[1];
                }
                else //FirstRow==null
                {
                    CoLHExists = false;
                    QColumns = 1;
                }
                QLines = 1;
                //
                if (HeadersRow != null)
                {
                    this.LineOfColHeader = new DataCell[QColumns];
                    //
                    for (int i = 1; i <= QColumns; i++)
                    {
                        this.LineOfColHeader[i - 1] = HeadersRow.GetCellN(i);
                    }
                }
                else //HeadersRow==null
                {
                //TypeInf = new DataCellTypeInfo(TableConsts.DefaultLineOfColHeaderCellTypeN, 1);
                //for (int i = 1; i <= QColumns; i++)
                //{
                //    this.LineOfColHeader[i - 1] = new DataCell(TypeInf);
                //}
                }
                //
                if (CoLHExists)
                {
                    ColOfLineHeader = new DataCell[1];
                    ColOfLineHeader[1 - 1] = FirstRow.GetHeader();
                }
            }
            else //DBStartNotList  is List
            {
                CoLHExists = (HeadersRow != null);
                if (FirstRow != null)
                {
                    LoCHExists = (FirstRow.GetHeader() != null);
                    QLines = FirstRow.GetQContentCells();
                    if (LoCHExists) this.LineOfColHeader = new DataCell[1];
                }
                else //FirstRow==null
                {
                    LoCHExists = false;
                    QLines = 1;
                }
                QColumns = 1;
                //
                if (HeadersRow != null)
                {
                    this.ColOfLineHeader = new DataCell[QLines];
                    for (int i = 1; i <= QLines; i++)
                    {
                        this.ColOfLineHeader[i - 1] = HeadersRow.GetCellN(i);
                    }
                }
                else //HeadersRow==null
                {
                    //TypeInf = new DataCellTypeInfo(TableConsts.DefaultLineOfColHeaderCellTypeN, 1);
                    //for (int i = 1; i <= QLines; i++)
                    //{
                    //    this.ColOfLineHeader[i - 1] = new DataCell(TypeInf);
                    //}
                }
                if (LoCHExists)
                {
                    LineOfColHeader = new DataCell[1];
                    LineOfColHeader[1 - 1] = FirstRow.GetHeader();
                }
            }
            //
            TblInf = new TableInfo(LC_not_CL, CoLHExists, LoCHExists, QLines, QColumns);
            //
            //Content
            if (FirstRow == null)
            {
                TypeInf = new DataCellTypeInfo(TableConsts.DefaultContentCellTypeN, 1);
                if (LC_not_CL)
                {
                    this.ContentCell = new DataCell[QLines][];
                    for (int i = 1; i <= QLines; i++)
                    {
                        this.ContentCell[i - 1] = new DataCell[QColumns];
                    }
                    for (int i = 1; i <= QLines; i++)
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            this.ContentCell[i - 1][j - 1] = new DataCell(TypeInf);
                        }
                    }
                }
                else //LC not CL ==false
                {
                    this.ContentCell = new DataCell[QColumns][];
                    for (int i = 1; i <= QColumns; i++)
                    {
                        this.ContentCell[i - 1] = new DataCell[QLines];
                    }
                    for (int i = 1; i <= QColumns; i++)
                    {
                        for (int j = 1; j <= QLines; j++)
                        {
                            this.ContentCell[i - 1][j - 1] = new DataCell(TypeInf);
                        }
                    }
                }
            }
            else //FirstRow != null
            {
                if (DBStartNotList)
                { //QLines=1, QColumns>=1
                    if (LC_not_CL)
                    {
                        this.ContentCell = new DataCell[QLines][];
                        for (int i = 1; i <= QLines; i++)
                        {
                            this.ContentCell[i - 1] = new DataCell[QColumns];
                        }
                        for (int i = 1; i <= QLines; i++)
                        {
                            for (int j = 1; j <= QColumns; j++)
                            {
                                cell = FirstRow.GetContentCellN(j);
                                //TypeInf = new DataCellTypeInfo(cell.GetTypeN(), cell.GetLength());
                                //this.ContentCell[i - 1][j - 1] = new DataCell(TypeInf);
                                this.ContentCell[i - 1][j - 1] = cell;
                            }
                        }
                    }
                    else // LC_not_CL==false
                    {
                        this.ContentCell = new DataCell[QColumns][];
                        for (int i = 1; i <= QColumns; i++)
                        {
                            this.ContentCell[i - 1] = new DataCell[QLines];
                        }
                        for (int i = 1; i <= QColumns; i++)
                        {
                            cell = FirstRow.GetContentCellN(i);
                            //TypeInf = new DataCellTypeInfo(cell.GetTypeN(), cell.GetLength());
                            for (int j = 1; j <= QLines; j++)
                            {
                                //this.ContentCell[i - 1][j - 1] = new DataCell(TypeInf);
                                this.ContentCell[i - 1][j - 1] = cell;
                            }
                        }
                    }
                }
                else //DBStartNotList==false // => list
                {   //QLines>=1, QColumns=1
                    if (LC_not_CL)
                    {
                        this.ContentCell = new DataCell[QLines][];
                        for (int i = 1; i <= QLines; i++)
                        {
                            this.ContentCell[i - 1] = new DataCell[QColumns];
                        }
                        for (int i = 1; i <= QLines; i++)
                        {
                            cell = FirstRow.GetContentCellN(i);
                            for (int j = 1; j <= QColumns; j++)
                            {
                                this.ContentCell[i - 1][j - 1] = cell;
                            }
                        }
                    }
                    else // LC_not_CL==false
                    {
                        this.ContentCell = new DataCell[QColumns][];
                        for (int i = 1; i <= QColumns; i++)
                        {
                            this.ContentCell[i - 1] = new DataCell[QLines];
                        }
                        for (int i = 1; i <= QColumns; i++)
                        {
                            for (int j = 1; j <= QLines; j++)
                            {
                                cell = FirstRow.GetContentCellN(j);
                                this.ContentCell[i - 1][j - 1] = cell;
                            }
                        }
                    }////LC not CL
                }//DBStartNotList
            }//FirstRow , in general - Content
            if (Headers != null) this.Headers = Headers;
            if (WriteInfo) this.TblInf = TblInf;
        }//
        public TTable(TableInfo TblInfExt, DataCell[][] Content, DataCell[] LineOfColHeader, DataCell[] ColOfLineHeader, TableHeaders Headers, DataCell SpecCell, bool WriteInfo)
        {
            TableInfo TblInf;
            if (TblInfExt != null) TblInf = TblInfExt; else TblInf = new TableInfo();
            if (TblInf.Str == null) TblInf.Str = new TableStructure();
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            //
            this.ContentCell = Content;
            this.LineOfColHeader = LineOfColHeader;
            this.ColOfLineHeader = ColOfLineHeader;
            this.Headers = Headers;
            this.SpecCell = SpecCell;
            if (WriteInfo) this.TblInf = TblInf;
        }
        public TTable(TableInfo TblInfNewExt, bool ByColumnsNotLines, DataCellRow[] Content, DataCellRow LineOfColHeader, DataCellRow ColOfLineHeader, TableHeaders Headers, bool WriteInfo)
        {//third best
            ConstructTableSimpleMax();
            Set(TblInfNewExt, null, ByColumnsNotLines, Content, LineOfColHeader, ColOfLineHeader, Headers, WriteInfo, false);
        }
        public TTable(TableInfo TblInfNewExt, bool ByColumnsNotLines, DataCellRowCoHeader[] rows, DataCellRow HeaderRow, TableHeaders Headers, bool WriteInfo)
        {
            ConstructTableSimpleMax();
            Set(TblInfNewExt, null, ByColumnsNotLines, rows, HeaderRow, Headers, WriteInfo, false);
        }
        public TTable(TableInfo TblInfExt, TableCellsTypeMap TypeMapExt, int WriteMainInfo_No0Yes1){
            TableInfo TblInf, TableInfOld;
            TableCellsTypeMap TypeMap;
            TableSettingConfiguration cfg;
            int QLines, QColumns;
            SetNullAbsolute();
            cfg=new TableSettingConfiguration();
            cfg.SetValsPreserve_No();
            if (TblInfExt != null) TblInf = TblInfExt;
            else TblInf = new TableInfo();
            if(TblInf.Str==null) TblInf.Str=new TableStructure();
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            
            if(TypeMapExt!=null)TypeMap=TypeMapExt; else TypeMap=new TableCellsTypeMap(TblInf);
            QLines=TblInf.GetQLines(); QColumns=TblInf.GetQColumns();
            SetMain(TblInfExt, TblInfExt, TypeMapExt, cfg);
            if (WriteMainInfo_No0Yes1 == 1) this.TblInf = TblInf;
        }
        public TTable(int ContentTypeN, int LineOfColHeaderTypeN, int ColOfLineHeaderTypeN, int WriteMainInfo_No0Yes1)
        {
            //TableCellAccessConfiguration CellCfg = null;
            TableCellAccessConfiguration CellCfg = new TableCellAccessConfiguration();
            CellCfg.PreserveVal = false;
            SetNullAbsolute();
            ContentCell = new DataCell[1][];
            for (int i = 1; i <= 1; i++) ContentCell[i - 1] = new DataCell[1];
            for (int i = 1; i <= 1; i++) {
                for (int j = 1; j <= 1; j++) {
                    ContentCell[i - 1][j - 1] = new DataCell(ContentTypeN, 1);
                    //SetCellTypeN(1, 1, ContentTypeN, null, CellCfg); 
                }
            }
            if(LineOfColHeaderTypeN!=0){
                LineOfColHeader = new DataCell[1];
            }
            for (int i = 1; i <= 1; i++) LineOfColHeader[i - 1] = new DataCell(LineOfColHeaderTypeN, 1);
            if (ColOfLineHeaderTypeN != 0)
            {
                ColOfLineHeader = new DataCell[1];
                if(this.TypeNIsCorrect(ColOfLineHeaderTypeN)){
                    for (int i = 1; i <= 1; i++) ColOfLineHeader[i - 1] = new DataCell(ColOfLineHeaderTypeN, 1);
                }else{
                    for (int i = 1; i <= 1; i++) ColOfLineHeader[i - 1] = new DataCell(TableConsts.DefaultColOfLineHeaderCellTypeN, 1);
                }
            }
            if (WriteMainInfo_No0Yes1 == 1)
            {
                TblInf=new TableInfo();
                TblInf.SetStr(1, 1, 1);
                TblInf.SetSize(1, 1);
            }
        }
        public TTable(bool LC_not_CL, bool CoLHExists, bool LoCHExists, int QLines, int QColumns, int[][] CntTypeN, int[] LoCHTypeN, int[] CoLHTypeN, bool AddInfoStruct)
        {
            TableSettingConfiguration cfg=new TableSettingConfiguration();
            cfg.WriteParamsInfo=AddInfoStruct;
            SetNullAbsolute();
            SetMain(LC_not_CL, CoLHExists, LoCHExists, QLines, QColumns, CntTypeN, LoCHTypeN, CoLHTypeN, cfg); 
            //SetMainFirst(LC_not_CL, CoLHExists, LoCHExists, QLines, QColumns, CntTypeN, LoCHTypeN, CoLHTypeN);
        }
        //
        //
        //TTable ReturnCopy()
        //{
        //    return this;
        //}
        public object Clone(){
            DataCell[][] ContentCell; 
            DataCell[] LineOfColHeader = null, ColOfLineHeader = null;
            DataCell SpecCell=null;
            TableHeaders Hdrs = null;
            TableInfo TblInfParam = null; //ob exist fn, ic s'below, co 2 params, et compil'z ne ved't, qic fn s'called, ob null abl b both params
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfParam);//ob Clone n e abl't get args
            DataCellRow[] rows;
            DataCellRow HdrRow;
            int QLines=TblInf.GetQLines();
            int QColumns = TblInf.GetQColumns();
            bool LC_not_CL = TblInf.GetIf_LC_Not_CL();
            bool LoCHExists=this.GetIfLineOfColHeaderExists();
            bool CoLHExists = this.GetIfColOfLineHeaderExists();
            if (LC_not_CL)
            {
                ContentCell = new DataCell[QLines][];
                for (int i = 1; i <= QLines; i++) ContentCell[i - 1] = new DataCell[QColumns];
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        ContentCell[i - 1][j - 1] = (DataCell)this.ContentCell[i - 1][j - 1].Clone();
                    }
                }
            }
            else
            {
                ContentCell = new DataCell[QColumns][];
                for (int i = 1; i <= QColumns; i++) ContentCell[i - 1] = new DataCell[QLines];
                for (int i = 1; i <= QColumns; i++)
                {
                    for (int j = 1; j <= QLines; j++)
                    {
                        ContentCell[i - 1][j - 1] = (DataCell)this.ContentCell[i - 1][j - 1].Clone();
                    }
                }
            }
            //
            if (LoCHExists)
            {
                LineOfColHeader = new DataCell[QColumns];
                for (int i = 1; i <= QColumns; i++)
                {
                    LineOfColHeader[i - 1] = (DataCell)this.LineOfColHeader[i - 1].Clone();
                }
            }
            //
            if (CoLHExists)
            {
                ColOfLineHeader = new DataCell[QLines];
                for (int i = 1; i <= QLines; i++)
                {
                    ColOfLineHeader[i - 1] = (DataCell)this.ColOfLineHeader[i - 1].Clone();
                }
            }
            //
            if (this.Headers != null) Hdrs = (TableHeaders)this.Headers.Clone();
            //
            if (this.SpecCell != null) SpecCell = (DataCell)this.SpecCell.Clone();
            //
            return new TTable(TblInf, ContentCell, LineOfColHeader, ColOfLineHeader, Headers, SpecCell, true);
        }
        //
        //public void SetContent(DataCellRow[] cnt, int QL, int QC, bool ColumnsNotLines, TableInfo TblInfExt = null)
        //{
        //    TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt, true, 2);
        //    int MinQL = QL, MinQC=QC;
        //    if (ColumnsNotLines)
        //    {
        //        if (MinQC > TblInf.GetQLines()) MinQ = TblInf.GetQLines();
        //        for(int 
        //    }
        //    else
        //    {

        //    }
        //}
        //
        public TTable ReturnCopyOrPart(CellsNsToDisplayShort CellsNs = null, TableInfo TblInfIniExt = null, bool WriteInfoToCopy=true)
        {
            TTable Copy = null;
            DataCell OldCurCell;
            DataCell[][] ContentCell;
            DataCell[] LineOfColHeader = null, ColOfLineHeader = null;
            DataCell SpecCell = null;
            TableHeaders Hdrs = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfIniExt);//ob Clone n e abl't get args
            TableInfo TblInfOfCopy = null;
            DataCellRow[] rows;
            DataCellRow HdrRow;
            int QLinesAll = TblInf.GetQLines();
            int QColumnsAll = TblInf.GetQColumns();
            int QLinesToReturn = QLinesAll, QColumnsToReturn = QColumnsAll, ErstLineN=1, ErstColN=1;
            int CurOldLineN, CurOldColN;
            if (CellsNs != null)
            {
                CellsNs.Correct(TblInf.RowsQuantities);
                QLinesToReturn = CellsNs.GetQShownContentLines(); QColumnsToReturn = CellsNs.GetQShownContentColumns();
                ErstLineN = CellsNs.ErstLineN; ErstColN=CellsNs.ErstColumnN;
            }
            bool LC_not_CL = TblInf.GetIf_LC_Not_CL();
            bool LoCHExists = this.GetIfLineOfColHeaderExists();
            bool CoLHExists = this.GetIfColOfLineHeaderExists();
            if (LC_not_CL)
            {
                ContentCell = new DataCell[QLinesToReturn][];
                for (int i = 1; i <= QLinesToReturn; i++) ContentCell[i - 1] = new DataCell[QColumnsToReturn];
                for (int i = 1; i <= QLinesToReturn; i++)
                {
                    CurOldLineN = ErstLineN + i - 1;
                    for (int j = 1; j <= QColumnsToReturn; j++)
                    {
                        CurOldColN = ErstColN + j - 1;
                        //OldCurCell = GetCell(CurOldLineN, CurOldColN, TblInf);
                        ContentCell[i - 1][j - 1] = (DataCell)this.ContentCell[CurOldLineN - 1][CurOldColN - 1].Clone();
                        //ContentCell[i - 1][j - 1] = (DataCell)OldCurCell.Clone();
                    }
                }
            }
            else
            {
                ContentCell = new DataCell[QColumnsToReturn][];
                for (int i = 1; i <= QColumnsToReturn; i++) ContentCell[i - 1] = new DataCell[QLinesToReturn];
                for (int i = 1; i <= QColumnsToReturn; i++)
                {
                    CurOldColN = ErstColN + i - 1;
                    for (int j = 1; j <= QLinesToReturn; j++)
                    {
                        CurOldLineN = ErstLineN + j - 1;
                        ContentCell[i - 1][j - 1] = (DataCell)this.ContentCell[CurOldColN - 1][CurOldLineN - 1].Clone();
                    }
                }
            }
            //
            if (LoCHExists)
            {
                LineOfColHeader = new DataCell[QColumnsToReturn];
                for (int i = 1; i <= QColumnsToReturn; i++)
                {
                    CurOldColN = ErstColN + i - 1;
                    LineOfColHeader[i - 1] = (DataCell)this.LineOfColHeader[CurOldColN - 1].Clone();
                }
            }
            //
            if (CoLHExists)
            {
                ColOfLineHeader = new DataCell[QLinesToReturn];
                for (int i = 1; i <= QLinesToReturn; i++)
                {
                    CurOldLineN = ErstLineN + i - 1;
                    ColOfLineHeader[i - 1] = (DataCell)this.ColOfLineHeader[CurOldLineN - 1].Clone();
                }
            }
            //
            if (this.Headers != null) Hdrs = (TableHeaders)this.Headers.Clone();
            //
            if (this.SpecCell != null) SpecCell = (DataCell)this.SpecCell.Clone();
            //
            //if (WriteInfoToCopy)
            //{
            //public TableInfo(bool LC_not_CL, bool CoLHExists, bool LoCHExists, int QLines, int QColumns)
            TblInfOfCopy = new TableInfo(LC_not_CL, CoLHExists, LoCHExists, QLinesToReturn, QColumnsToReturn);
            //    //CreateInfo(TblInfOfCopy);
            //}
            //
            return new TTable(TblInfOfCopy, ContentCell, LineOfColHeader, ColOfLineHeader, Headers, SpecCell, true);
            //Copy=
        }
        //
        //
        public TableInfo_ConcrRepr GetTableInfo_ConcrRepr(int ReprN_Grid0Text1 = 1/*, TableInfo_ConcrRepr TblInfExt = null*/)
        {
            TableInfo_ConcrRepr TblInfR = null;
            //if (TblInfExt != null) TblInfR = TblInfExt;
            //else{
            if (this.TblInf != null) TblInfR = TblInf.GetTableInfo_ConcrRepr(ReprN_Grid0Text1);
            //}
            return TblInfR;
        }
        public TableInfo GetTableInfo(){return this.TblInf;}
        //
        //void AssignPreserving(TTable tbl, TableInfo TblInfNewExt=null, TableInfo TblInfOldExt=null); //ne fin'd
        public void Set(TableInfo TblInfNewExt, TableInfo TblInfOldExt, bool ByColumnsNotLines, DataCellRow[] Content, DataCellRow LineOfColHeader, DataCellRow ColOfLineHeader, TableHeaders Headers, bool WriteInfo, bool PreserveVals)
        {
            //int zero = 0;
            //TTable TCopy = null;
            TableInfo TblInfNew, TblInfOld;
            int QLinesMin, QColumnsMin, QLinesOld, QColumnsOld, QLinesNew, QColumnsNew;
            bool LC_not_CL_new, CoLHExists_new, LoCHExists_new, LC_not_CL_old, CoLHExists_old, LoCHExists_old;
            if (TblInfNewExt != null) TblInfNew = TblInfNewExt;
            //else if (this.TblInf != null) TblInfNew = this.TblInf;
            else TblInfNew = new TableInfo();
            if (TblInfNew.Str == null) TblInfNew.Str = new TableStructure();
            if (TblInfNew.RowsQuantities == null) TblInfNew.RowsQuantities = new TableSize();
            //
            QLinesNew=TblInfNew.RowsQuantities.QLines;
            QColumnsNew=TblInfNew.RowsQuantities.QColumns;
            LC_not_CL_new=TblInfNew.Str.LC_Matrix_Not_CL_DB; CoLHExists_new=TblInfNew.Str.ColOfLineHeaderExists; LoCHExists_new=TblInfNew.Str.LineOfColHeaderExists;
            //
            if (TblInfOldExt != null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = this.TblInf;
            else TblInfOld = new TableInfo();
            if (TblInfOld.Str == null) TblInfOld.Str = new TableStructure();
            if (TblInfOld.RowsQuantities == null) TblInfOld.RowsQuantities = new TableSize();
             //
            QLinesOld=TblInfOld.RowsQuantities.QLines; QColumnsOld=TblInfOld.RowsQuantities.QColumns;
            LC_not_CL_old=TblInfOld.Str.LC_Matrix_Not_CL_DB; CoLHExists_old=TblInfOld.Str.ColOfLineHeaderExists; LoCHExists_old=TblInfOld.Str.LineOfColHeaderExists;
            //
            if(QLinesNew<=QLinesOld) QLinesMin=QLinesNew; else QLinesMin=QLinesOld;
            if (QColumnsNew <= QColumnsOld) QColumnsMin = QColumnsNew; else QColumnsMin = QColumnsOld;
            //
            //if (PreserveVals)
            //{
            //    TCopy = ReturnCopy();
            //}
            //Content
            if (LC_not_CL_new)
            {
                this.ContentCell=new DataCell[QLinesNew][];
                for (int i = 1; i <= QLinesNew; i++)
                {
                    this.ContentCell[i - 1] = new DataCell[QColumnsNew];
                }
                if (Content != null)
                {
                    if (ByColumnsNotLines)
                    {
                        for (int i = 1; i <= QLinesNew; i++)
                        {
                            for (int j = 1; j <= QColumnsNew; j++)
                            {
                                this.ContentCell[i - 1][j-1]= Content[j-1].GetCellN(i);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= QLinesNew; i++)
                        {
                            for (int j = 1; j <= QColumnsNew; j++)
                            {
                                this.ContentCell[i - 1][j-1]= Content[i-1].GetCellN(j);
                            }
                        }
                    }
                }
            }
            else //CL, not LC
            {
                this.ContentCell = new DataCell[QColumnsNew][];
                for (int i = 1; i <= QColumnsNew; i++)
                {
                    this.ContentCell[i - 1] = new DataCell[QLinesNew];
                }
                if (Content != null)
                {
                    if (ByColumnsNotLines)
                    {
                        for (int i = 1; i <= QColumnsNew; i++)
                        {
                            for (int j = 1; j <= QLinesNew; j++)
                            {
                                this.ContentCell[i - 1][j - 1] = Content[i - 1].GetCellN(j);
                            }
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= QColumnsNew; i++)
                        {
                            for (int j = 1; j <= QLinesNew; j++)
                            {
                                this.ContentCell[i - 1][j - 1] = Content[j - 1].GetCellN(i);
                            }
                        }
                    }
                }
            }
            //LineOfColHeader
            if (LoCHExists_new)
            {
                this.LineOfColHeader = new DataCell[QColumnsNew];
                if (LineOfColHeader != null)
                {
                    for (int i = 1; i <= QColumnsNew; i++)
                    {
                        this.LineOfColHeader[i - 1] = LineOfColHeader.GetCellN(i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QColumnsNew; i++)
                    {
                        this.LineOfColHeader[i - 1] = new DataCell(TableConsts.DefaultLineOfColHeaderCellTypeN, 2);
                    }
                }
            }
            else
            {
                if (this.LineOfColHeader != null) this.LineOfColHeader = null;
            }
            //ColOfLineHeader
            if (CoLHExists_new)
            {
                this.ColOfLineHeader = new DataCell[QLinesNew];
                if (ColOfLineHeader != null)
                {
                    for (int i = 1; i <= QLinesNew; i++)
                    {
                        this.ColOfLineHeader[i - 1] = ColOfLineHeader.GetCellN(i);
                    }
                }
                else
                {
                    for (int i = 1; i <= QLinesNew; i++)
                    {
                        this.ColOfLineHeader[i - 1] = new DataCell(TableConsts.DefaultColOfLineHeaderCellTypeN, 2);
                    }
                }
            }
            else
            {
                if (this.ColOfLineHeader != null) this.ColOfLineHeader = null;
            }
            //
            this.Headers = Headers;
            //
            if (WriteInfo)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                this.TblInf = TblInfNew;
            }
            //
            //if (PreserveVals)
            //{
            //    //Content
            //    if (LC_not_CL_new)
            //    {
            //        for (int i = 1; i <= QLinesMin; i++)
            //        {
            //            for (int j = 1; j <= QColumnsMin; j++)
            //            {
            //                this.ContentCell[i - 1][j - 1].AssignBy(TCopy.GetCell(i, j));
            //            }
            //        }
            //    }
            //    else//new CL not LC
            //    {
            //        for (int i = 1; i <= QColumnsMin; i++)
            //        {
            //            for (int j = 1; j <= QLinesMin; j++)
            //            {
            //                this.ContentCell[i - 1][j - 1].AssignBy(TCopy.GetCell(i, j));
            //            }
            //        }
            //    }
            //    //ColOfLineHeader
            //    if (CoLHExists_new && CoLHExists_old)
            //    {
            //        for (int i= 1; i <= QLinesMin; i++){
            //            this.ColOfLineHeader[i - 1] = TCopy.GetCell_ColOfLineHeader(i);
            //        }
            //    }
            //    //LineOfColHeader
            //    if (LoCHExists_new && LoCHExists_old)
            //    {QLinesMin
            //        for (int i = 1; i <= QColumnsMin; i++)
            //        {
            //            this.LineOfColHeader[i - 1] = TCopy.GetCell_LineOfColHeader(i);
            //        }
            //    }
            //    //Headers
            //    if (TCopy.GetIfTableNameExists() == true && this.GetIfTableNameExists() == true)
            //    {
            //        this.SetTableHeader(TCopy.GetTableHeader());
            //    }
            //}//if preserve
        }// fn Set
        //
        public void SetMain(TableInfo TblInfNewExt, TableInfo TblInfOldExt, TableCellsTypeMap TypesMap, TableHeaders Headers, bool WriteInfo, bool PreserveVals)
        {
            TTable TCopy = null;
            TableInfo TblInfNew, TblInfOld;
            /*TableInfo*/
            TableInfo_ConcrRepr TblInfShort = null;
            int QLinesMin, QColumnsMin, QLinesOld, QColumnsOld, QLinesNew, QColumnsNew;
            bool LC_not_CL_new, CoLHExists_new, LoCHExists_new, LC_not_CL_old, CoLHExists_old, LoCHExists_old;
            if (TblInfNewExt != null) TblInfNew = TblInfNewExt;
            //else if (this.TblInf != null) TblInfNew = this.TblInf;
            else TblInfNew = new TableInfo();
            if (TblInfNew.Str == null) TblInfNew.Str = new TableStructure();
            if (TblInfNew.RowsQuantities == null) TblInfNew.RowsQuantities = new TableSize();
            TblInfShort = TblInfNew.GetTableInfo_ConcrRepr();
            //
            QLinesNew = TblInfNew.RowsQuantities.QLines; QColumnsNew = TblInfNew.RowsQuantities.QColumns;
            LC_not_CL_new = TblInfNew.Str.LC_Matrix_Not_CL_DB; CoLHExists_new = TblInfNew.Str.ColOfLineHeaderExists; LoCHExists_new = TblInfNew.Str.LineOfColHeaderExists;
            //
            //if (TblInfOldExt != null) TblInfOld = TblInfOldExt;
            //else if (this.TblInf != null) TblInfOld = this.TblInf;
            //else TblInfOld = new TableInfo();
            TblInfOld = Choose_TableInfo_StrSize_ByExtAndInner(TblInfOldExt);
            if (TblInfOld.Str == null) TblInfOld.Str = new TableStructure();
            if (TblInfOld.RowsQuantities == null) TblInfOld.RowsQuantities = new TableSize();
            //
            QLinesOld = TblInfOld.RowsQuantities.QLines; QColumnsOld = TblInfOld.RowsQuantities.QColumns;
            LC_not_CL_old = TblInfOld.Str.LC_Matrix_Not_CL_DB; CoLHExists_old = TblInfOld.Str.ColOfLineHeaderExists; LoCHExists_old = TblInfOld.Str.LineOfColHeaderExists;
            //
            if (QLinesNew <= QLinesOld) QLinesMin = QLinesNew; else QLinesMin = QLinesOld;
            if (QColumnsNew <= QColumnsOld) QColumnsMin = QColumnsNew; else QColumnsMin = QColumnsOld;
            //
            if (PreserveVals)
            {
                TCopy = (TTable)this.Clone();
            }
            //Content
            if (LC_not_CL_new)
            {
                this.ContentCell = new DataCell[QLinesNew][];
                for (int i = 1; i <= QLinesNew; i++)
                {
                    this.ContentCell[i - 1] = new DataCell[QColumnsNew];
                }
                if (TypesMap != null)
                {
                    for (int i = 1; i <= QLinesNew; i++)
                    {
                        for (int j = 1; j <= QColumnsNew; j++)
                        {
                            this.ContentCell[i - 1][j - 1] = new DataCell(TypesMap.GetCellTypeN(i, j), TypesMap.GetCellLength(i, j));
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= QLinesNew; i++)
                    {
                        for (int j = 1; j <= QColumnsNew; j++)
                        {
                            this.ContentCell[i - 1][j - 1] = new DataCell(TableConsts.DefaultContentCellTypeN, 2);
                        }
                    }
                }
            }
            else //CL, not LC
            {
                this.ContentCell = new DataCell[QColumnsNew][];
                for (int i = 1; i <= QColumnsNew; i++)
                {
                    this.ContentCell[i - 1] = new DataCell[QLinesNew];
                }
                if (TypesMap != null)
                {
                    for (int i = 1; i <= QColumnsNew; i++)
                    {
                        for (int j = 1; j <= QLinesNew; j++)
                        {
                            this.ContentCell[i - 1][j - 1] = new DataCell(TypesMap.GetCellTypeN(i, j), TypesMap.GetCellLength(i, j));
                        }
                    }
                }
                else
                {
                    for (int i = 1; i <= QColumnsNew; i++)
                    {
                        for (int j = 1; j <= QLinesNew; j++)
                        {
                            this.ContentCell[i - 1][j - 1] = new DataCell(TableConsts.DefaultContentCellTypeN, 2);
                        }
                    }
                }
            }
            //LineOfColHeader
            if (LoCHExists_new)
            {
                this.LineOfColHeader = new DataCell[QColumnsNew];
                if (TypesMap != null)
                {
                    for (int i = 1; i <= QColumnsNew; i++)
                    {
                        this.LineOfColHeader[i - 1] = new DataCell(TypesMap.GetCellTypeN_LineOfColHeader(i), TypesMap.GetCellLength_LineOfColHeader(i));
                    }
                }
                else
                {
                    for (int i = 1; i <= QLinesNew; i++)
                    {
                        this.LineOfColHeader[i - 1] = new DataCell(TableConsts.DefaultLineOfColHeaderCellTypeN, 2);
                    }
                }
            }
            //ColOfLineHeader
            if (CoLHExists_new)
            {
                this.ColOfLineHeader = new DataCell[QLinesNew];
                if (TypesMap != null)
                {
                    for (int i = 1; i <= QLinesNew; i++)
                    {
                        this.ColOfLineHeader[i - 1] = new DataCell(TypesMap.GetCellTypeN_ColOfLineHeader(i), TypesMap.GetCellLength_ColOfLineHeader(i));
                    }
                }
                else
                {
                    for (int i = 1; i <= QLinesNew; i++)
                    {
                        this.ColOfLineHeader[i - 1] = new DataCell(TableConsts.DefaultColOfLineHeaderCellTypeN, 2);
                    }
                }
            }
            //
            if (WriteInfo)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                this.TblInf = TblInfNew;
            }
            //
            if (PreserveVals)
            {
                //Content
                if (LC_not_CL_new)
                {
                    for (int i = 1; i <= QLinesMin; i++)
                    {
                        for (int j = 1; j <= QColumnsMin; j++)
                        {
                            this.ContentCell[i - 1][j - 1].AssignBy(TCopy.GetCell(i, j, /*TblInf*/TblInfShort));
                        }
                    }
                }
                else//new CL not LC
                {
                    for (int i = 1; i <= QColumnsMin; i++)
                    {
                        for (int j = 1; j <= QLinesMin; j++)
                        {
                            this.ContentCell[i - 1][j - 1].AssignBy(TCopy.GetCell(i, j, /*TblInf*/TblInfShort));
                        }
                    }
                }
                //ColOfLineHeader
                if (CoLHExists_new && CoLHExists_old)
                {
                    for (int i = 1; i <= QLinesMin; i++)
                    {
                        this.ColOfLineHeader[i - 1] = TCopy.GetCell_ColOfLineHeader(i, TblInfOld.GetTableInfo_ConcrRepr());
                    }
                }
                //LineOfColHeader
                if (LoCHExists_new && LoCHExists_old)
                {
                    for (int i = 1; i <= QLinesMin; i++)
                    {
                        this.LineOfColHeader[i - 1] = TCopy.GetCell_LineOfColHeader(i, TblInfOld.GetTableInfo_ConcrRepr());
                    }
                }
                //Headers
                if (TCopy.GetIfTableNameExists() == true && this.GetIfTableNameExists() == true)
                {
                    this.SetTableHeader(TCopy.GetTableHeader());
                }
            }//if preserve
        }//fn SetMain
        //
        public void Set(TableInfo TblInfNewExt, TableInfo TblInfOldExt, bool ByColumnsNotLines, DataCellRowCoHeader[] rows, DataCellRow HeaderRow, TableHeaders Headers, bool WriteInfo, bool PreserveVals)
        {
            DataCellRow ColOfLineHeader=null, LineOfColHeader=null;
            DataCellRow[] Content;
            DataCell[] CellsArr;
            TableInfo TblInfNew, TblInfOld;
            TblInfNew = Choose_TableInfo_StrSizeReprUse_ByExtAndInner(TblInfNewExt);
            TblInfOld = Choose_TableInfo_StrSizeReprUse_ByExtAndInner(TblInfOldExt);
            int QLinesNew, QColumnsNew;
            QLinesNew = TblInfNew.GetQLines();
            QColumnsNew = TblInfNew.GetQColumns();
            int QLinesOld, QColumnsOld;
            QLinesOld = TblInfOld.GetQLines();
            QColumnsOld = TblInfOld.GetQColumns();
            if (ByColumnsNotLines)
            {
                Content = new DataCellRow[QColumnsNew];
                for (int i = 1; i <= QColumnsNew; i++)
                {
                    Content[i - 1] = new DataCellRow();
                    if (rows != null && rows[i - 1] != null && rows[i - 1].GetContent() != null)
                    {
                        Content[i - 1] = rows[i - 1].GetContent();
                    }
                    else
                    {
                        Content[i - 1] = new DataCellRow(TableConsts.DefaultContentCellTypeN, 2, QColumnsNew, null);
                    }
                }
                //LineOfColHeader
                CellsArr = new DataCell[QColumnsNew];
                for (int i = 1; i <= QColumnsNew; i++)
                {
                    /*if (rows[i - 1].GetContent() != null && rows[i - 1].GetContent().GetCellN(i) != null)
                    {
                        CellsArr[i - 1] = rows[i - 1].GetContent().GetCellN(i);
                    }
                    else
                    {
                        CellsArr[i - 1] = new DataCell();
                    }*/
                    if (rows[i - 1].GetHeader() != null) CellsArr[i - 1] = rows[i - 1].GetHeader();
                    else CellsArr[i - 1] = new DataCell();
                }
                if (TblInfNew.GetIf_LoCHExists())
                {
                    LineOfColHeader = new DataCellRow(CellsArr, QColumnsNew);
                }
                //ColOfLineHeader
                if (TblInfNew.GetIf_CoLHExists())
                {
                    if (HeaderRow != null)
                    {
                        ColOfLineHeader = HeaderRow;
                    }
                    else
                    {
                        ColOfLineHeader = new DataCellRow(TableConsts.DefaultColOfLineHeaderCellTypeN, 2, QLinesNew, null);
                    }
                }
            }
            else //By Lines, not Columns
            {
                //content
                Content = new DataCellRow[QLinesNew];
                for (int i = 1; i <= QLinesNew; i++)
                {
                    Content[i - 1] = new DataCellRow();
                    if (rows != null && rows[i - 1] != null && rows[i - 1].GetContent() != null)
                    {
                        Content[i - 1] = rows[i - 1].GetContent();
                    }
                    else
                    {
                        Content[i - 1] = new DataCellRow(TableConsts.DefaultContentCellTypeN, 2, QColumnsNew, null);
                    }
                }
                //ColOfLineHeader
                CellsArr = new DataCell[QLinesNew];
                for (int i = 1; i <= QLinesNew; i++)
                {
                    //if (rows[i - 1].GetContent() != null && rows[i - 1].GetContent().GetCellN(i) != null)
                    if (rows[i - 1] != null && rows[i - 1].GetHeader() != null)
                    {
                       // CellsArr[i - 1] = rows[i - 1].GetContent().GetCellN(i);
                        CellsArr[i - 1] = rows[i - 1].GetHeader();
                    }
                    else
                    {
                        CellsArr[i - 1] = new DataCell();
                    }
                }
                if (TblInfNew.GetIf_CoLHExists())
                {
                    ColOfLineHeader = new DataCellRow(CellsArr, QLinesNew);
                }
                //LineOfColHeader
                if (TblInfNew.GetIf_LoCHExists())
                {
                    if (HeaderRow != null)
                    {
                        LineOfColHeader = HeaderRow;
                    }
                    else
                    {
                        LineOfColHeader = new DataCellRow(TableConsts.DefaultLineOfColHeaderCellTypeN, 2, QColumnsNew, null);
                    }
                }
            }//case of rows
            //Finally
            Set(TblInfNew, TblInfOld, ByColumnsNotLines, Content, LineOfColHeader, ColOfLineHeader, Headers, WriteInfo, PreserveVals);
        }//fn
        //
        //
        //
        public void SetNullAbsolute()
        {
            ContentCell = null;
            LineOfColHeader = null;
            ColOfLineHeader = null;
            //TableName = null;
            Headers = null;
            SpecCell = null;
            TblInf = null;
        }
        public void ConstructTablePrimitiveMax()
        {
            TableCellAccessConfiguration CellCfg = new TableCellAccessConfiguration();
            CellCfg.CheckCellExistance = false;
            CellCfg.LengthOfArrCellTypes = 1;
            CellCfg.PreserveVal = false;
            SetNullAbsolute();
            ContentCell = new DataCell[1][];
            for (int i = 1; i <= 1; i++) ContentCell[i - 1] = new DataCell[1];
            for (int i = 1; i <= 1; i++) { for (int j = 1; j <= 1; j++) { ContentCell[i - 1][j - 1] = new DataCell(); } }
            for (int i = 1; i <= 1; i++) { for (int j = 1; j <= 1; j++) { ContentCell[i - 1][j - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, null); } }
            //TblInf = new TableInfo();
            //LineOfColHeader = new DataCell[1];
            //for (int i = 1; i <= 1; i++) LineOfColHeader[i - 1] = new DataCell();
            //SetCellTypeN_LineOfColHeader(1, TableConsts.DefaultLineOfColHeaderCellTypeN, null, CellCfg);
            //ColOfLineHeader = new DataCell[1];
            //for (int i = 1; i <= 1; i++) ColOfLineHeader[i - 1] = new DataCell();
            //SetCellTypeN_ColOfLineHeader(1, TableConsts.DefaultColOfLineHeaderCellTypeN, null, CellCfg);
        }
        public void ConstructTableSimpleMax()
        {
            //int QLines=1, QColumns=1;
            TableCellAccessConfiguration CellCfg = new TableCellAccessConfiguration();
            CellCfg.CheckCellExistance = false;
            CellCfg.LengthOfArrCellTypes = 1;
            CellCfg.PreserveVal = false;
            SetNullAbsolute();
            //ContentCell = new DataCell[1][];
            //for (int i = 1; i <= 1; i++) ContentCell[i - 1] = new DataCell[1];
            //for (int i = 1; i <= 1; i++) { for (int j = 1; j <= 1; j++) { ContentCell[i - 1][j - 1] = new DataCell(); } }
            //for (int i = 1; i <= 1; i++) { for (int j = 1; j <= 1; j++) { ContentCell[i - 1][j - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, null); } }
            ConstructTablePrimitiveMax();
            TblInf = new TableInfo();
            LineOfColHeader = new DataCell[1];
            for (int i = 1; i <= 1; i++) LineOfColHeader[i - 1] = new DataCell();
            SetCellTypeN_LineOfColHeader(1, TableConsts.DefaultLineOfColHeaderCellTypeN, null, CellCfg);
            ColOfLineHeader = new DataCell[1];
            for (int i = 1; i <= 1; i++) ColOfLineHeader[i - 1] = new DataCell();
            SetCellTypeN_ColOfLineHeader(1, TableConsts.DefaultColOfLineHeaderCellTypeN, null, CellCfg);
        }
        //
        // Table Info (2)
        //
        public bool GetIfInfoBlockExists()
        {
            return (TblInf != null);
        }
        public void CreateInfo()
        {
            TblInf = new TableInfo();
        }
        public void CreateInfo(bool LC_not_CL, bool ColOfLineHeaderExists, bool LineOfColHeaderExists, int QLines, int QColumns, bool CreateRepr, bool CreateUssagePolicy)
        {
            TblInf = new TableInfo(LC_not_CL, ColOfLineHeaderExists, LineOfColHeaderExists, QLines, QColumns);
            if (CreateRepr)
            {
                CreateTableTextRepresentationSettingsInfoByDefault();
                CreateTableGridRepresentationSettingsInfoByDefault();
                //CreateTableRepresentationSettingsInfoByDefault();
            }
            if (CreateUssagePolicy) TblInf.UssagePolicy = new TableUssagePolicy();
        }
        public void CreateInfo(int iLC_not_CL, int iColOfLineHeaderExists, int iLineOfColHeaderExists, int QLines, int QColumns, int iCreateRepr, int iCreateUssagePolicy)
        {
            CreateInfo(MyLib.IntToBool(iLC_not_CL), MyLib.IntToBool(iColOfLineHeaderExists), MyLib.IntToBool(iLineOfColHeaderExists), QLines, QColumns, MyLib.IntToBool(iCreateRepr), MyLib.IntToBool(iCreateUssagePolicy));
        }
        public void CreateInfo(TableInfo TblInf=null) {
            if (TblInf != null) this.TblInf = TblInf;
            else this.TblInf = new TableInfo();
        }
        public void DeleteInfo() { TblInf = null; }
        ////mark1
        bool GetIf_RepresentationExists_Text() {
            return (TblInf != null && TblInf.Repr_Text != null);
        }
        bool GetIf_RepresentationExists_Grid(){
            return (TblInf != null && TblInf.Repr_Grid != null);
        }
        void CreateRepresentation_Text() {
            if (TblInf == null) TblInf = new TableInfo();
            if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
        }
        void CreateRepresentation_Grid()
        {
            if (TblInf == null) TblInf = new TableInfo();
            if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
        }
        public void CreateFullRepresentation_Text()
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            this.TblInf.Repr_Text.CreateWhatIsNull();
        }
        public void CreateFullRepresentation_Grid()
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            this.TblInf.Repr_Grid.CreateWhatIsNull();
        }
        void DeleteRepresentation_Text() {
            if (TblInf != null && TblInf.Repr_Text != null) TblInf.Repr_Text = null;
        }
        void DeleteRepresentation_Grid()
        {
            if (TblInf != null && TblInf.Repr_Grid != null) TblInf.Repr_Grid = null;
        }
        //
        //public TableSize GetTableSizeByVrn4(TableInfo TblInfExt, int SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2=1)
        //{
        //    TableSize size = null;
        //    if (TblInfExt != null && TblInfExt.RowsQuantities != null) size = TblInfExt.RowsQuantities;
        //    else if (TblInfExt == null && this.TblInf != null && this.TblInf.RowsQuantities != null) size = this.TblInf.RowsQuantities;
        //    else if (TblInfExt != null && TblInfExt.RowsQuantities == null && this.TblInf != null && this.TblInf.RowsQuantities != null)
        //    {
        //        switch (SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2)
        //        {
        //            case 1:
        //                size = new TableSize();
        //                break;
        //            case 2:
        //                size = this.TblInf.RowsQuantities;
        //                break;
        //            //default or 0 - NOp - null
        //        }
        //    }
        //    else size = new TableSize();
        //    return size;
        //}
        public TableSize GetTableSizeByVrn5(TableInfo TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableSize Size = null;
            if (this.TblInf != null && this.TblInf.RowsQuantities != null) Size = this.TblInf.RowsQuantities;
            switch (Mode_Repl_Simply0_Null1_ByNonNull2)
            {
                case 0:
                    if (TblInfExt == null) Size = null;
                    if (TblInfExt != null) Size = TblInfExt.RowsQuantities;
                    break;
                case 1:
                    if (Size == null && TblInfExt != null) Size = Size = TblInfExt.RowsQuantities;
                    Size = new TableSize();
                    break;
                case 2:
                    if (TblInfExt != null && TblInfExt.Str != null) Size = TblInfExt.RowsQuantities;
                    break;
                //default or 0 - NOp - null
            }//sw
            if (Size == null && CreatedDfltIfNull == true) Size = new TableSize();
            return Size;
        }//fn
        public TableSize GetTableSizeByVrn5(TableInfo_ConcrRepr TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableSize Size = null;
            if (this.TblInf != null && this.TblInf.RowsQuantities != null) Size = this.TblInf.RowsQuantities;
            switch (Mode_Repl_Simply0_Null1_ByNonNull2)
            {
                case 0:
                    if (TblInfExt == null) Size = null;
                    if (TblInfExt != null) Size = TblInfExt.RowsQuantities;
                    break;
                case 1:
                    if (Size == null && TblInfExt != null) Size = Size = TblInfExt.RowsQuantities;
                    Size = new TableSize();
                    break;
                case 2:
                    if (TblInfExt != null && TblInfExt.Str != null) Size = TblInfExt.RowsQuantities;
                    break;
                //default or 0 - NOp - null
            }//sw
            if (Size == null && CreatedDfltIfNull == true) Size = new TableSize();
            return Size;
        }//fn
        //public TableStructure GetTableStructureByVrn4(TableInfo TblInfExt, int SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2=1)
        //{
        //    TableStructure str=null;
        //    if (TblInfExt != null && TblInfExt.Str != null) str = TblInfExt.Str;
        //    else if (TblInfExt == null && this.TblInf!= null && this.TblInf.Str != null) str = this.TblInf.Str;
        //    else if (TblInfExt != null && TblInfExt.Str == null && this.TblInf != null && this.TblInf.Str != null)
        //    {
        //        switch (SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2)
        //        {
        //            case 1:
        //                str = new TableStructure();
        //                break;
        //            case 2:
        //                str = this.TblInf.Str;
        //                break;
        //            //default or 0 - NOp - null
        //        }
        //    }
        //    else str = new TableStructure();
        //    //else if (TblInfExt != null && this.TblInf != null && TblInfExt.Str == null && this.TblInf.RowsQuantities != null) str = this.TblInf.Str;
        //    //else str = new TableStructure();
        //    return str;
        //}
        public TableStructure GetTableStructureByVrn5(TableInfo TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableStructure Structure = null;
            if (this.TblInf != null && this.TblInf.Str != null) Structure = this.TblInf.Str;
            switch (Mode_Repl_Simply0_Null1_ByNonNull2)
            {
                case 0:
                    if (TblInfExt == null) Structure = null;
                    if (TblInfExt != null) Structure = TblInfExt.Str;
                    break;
                case 1:
                    if (Structure == null && TblInfExt != null) Structure = Structure = TblInfExt.Str;
                    Structure = new TableStructure();
                    break;
                case 2:
                    if (TblInfExt != null && TblInfExt.Str != null) Structure = TblInfExt.Str;
                    break;
                //default or 0 - NOp - null
            }//sw
            if (Structure == null && CreatedDfltIfNull == true) Structure = new TableStructure();
            return Structure;
        }//fn
        public TableStructure GetTableStructureByVrn5(TableInfo_ConcrRepr TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableStructure Structure = null;
            if (this.TblInf != null && this.TblInf.Str != null) Structure = this.TblInf.Str;
            switch (Mode_Repl_Simply0_Null1_ByNonNull2)
            {
                case 0:
                    if (TblInfExt == null) Structure = null;
                    if (TblInfExt != null) Structure = TblInfExt.Str;
                    break;
                case 1:
                    if (Structure == null && TblInfExt != null) Structure = Structure = TblInfExt.Str;
                    Structure = new TableStructure();
                    break;
                case 2:
                    if (TblInfExt != null && TblInfExt.Str != null) Structure = TblInfExt.Str;
                    break;
                //default or 0 - NOp - null
            }//sw
            if (Structure == null && CreatedDfltIfNull == true) Structure = new TableStructure();
            return Structure;
        }//fn
        //public TableUssagePolicy GetTableUssagePolicyByVrn4(TableInfo TblInfExt, int SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2 = 1)
        //{
        //    TableUssagePolicy UssagePolicy = null;
        //    if (TblInfExt != null && TblInfExt.UssagePolicy != null) UssagePolicy = TblInfExt.UssagePolicy;
        //    else if (TblInfExt == null && this.TblInf != null && this.TblInf.UssagePolicy != null) UssagePolicy = this.TblInf.UssagePolicy;
        //    else if (TblInfExt != null && TblInfExt.UssagePolicy == null && this.TblInf != null && this.TblInf.UssagePolicy != null)
        //    {
        //        switch (SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2)
        //        {
        //            case 1:
        //                UssagePolicy = new TableUssagePolicy();
        //            break;
        //            case 2:
        //                UssagePolicy = this.TblInf.UssagePolicy;
        //            break;
        //            //default or 0 - NOp - null
        //        }
        //    }
        //    else UssagePolicy = new TableUssagePolicy();
        //    return UssagePolicy;
        //}
        public TableUssagePolicy GetTableUssagePolicyByVrn5(TableInfo TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableUssagePolicy UssagePolicy=null;
            if(this.TblInf!=null && this.TblInf.UssagePolicy!=null) UssagePolicy=this.TblInf.UssagePolicy;
            switch (Mode_Repl_Simply0_Null1_ByNonNull2)
            {
                case 0:
                    if (TblInfExt == null) UssagePolicy = null;
                    if(TblInfExt!=null) UssagePolicy=TblInfExt.UssagePolicy;
                break;
                case 1:
                    if(UssagePolicy==null && TblInfExt!=null) UssagePolicy=UssagePolicy=TblInfExt.UssagePolicy;
                    UssagePolicy = new TableUssagePolicy();
                break;
                case 2:
                    if(TblInfExt!=null && TblInfExt.UssagePolicy!=null )UssagePolicy = TblInfExt.UssagePolicy;
                break;
                //default or 0 - NOp - null
            }//sw
            if (UssagePolicy == null && CreatedDfltIfNull == true) UssagePolicy = new TableUssagePolicy();
            return UssagePolicy;
        }//fn
        public TableUssagePolicy GetTableUssagePolicyByVrn5(TableInfo_ConcrRepr TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableUssagePolicy UssagePolicy = null;
            if (this.TblInf != null && this.TblInf.UssagePolicy != null) UssagePolicy = this.TblInf.UssagePolicy;
            switch (Mode_Repl_Simply0_Null1_ByNonNull2)
            {
                case 0:
                    if (TblInfExt == null) UssagePolicy = null;
                    if (TblInfExt != null) UssagePolicy = TblInfExt.UssagePolicy;
                    break;
                case 1:
                    if (UssagePolicy == null && TblInfExt != null) UssagePolicy = UssagePolicy = TblInfExt.UssagePolicy;
                    UssagePolicy = new TableUssagePolicy();
                    break;
                case 2:
                    if (TblInfExt != null && TblInfExt.UssagePolicy != null) UssagePolicy = TblInfExt.UssagePolicy;
                    break;
                //default or 0 - NOp - null
            }//sw
            if (UssagePolicy == null && CreatedDfltIfNull == true) UssagePolicy = new TableUssagePolicy();
            return UssagePolicy;
        }//fn
        //
        //public TableRepresentation GetTableTextRepresentationByVrn4(TableInfo TblInfExt, int SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2 = 1, int SubClasses_IfExtNull_LeaveNull0CreateDefault1AllowInner2 = 1)
        //{
        //    //TableRepresentation Repr = null;
        //    //TRowsNumeration num;
        //    //TableContentCellRepresentation ContentRepr;
        //    //TableGeneralRepresentation GenRepr;
        //    //TableHeaderCellRepresentation ColHeaderRepr, LineHeaderRepr;
        //    //TableHeaderCellRepresentation ColHeaderRepr_OfContentCell, LineHeaderRepr_OfContentCell;
        //    int  Mode_Rplc_Simply0_Null1ByNonNull2=2;
        //    bool CreateDefaultIfNull=true;
        //    TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
        //    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
        //    TableRepresentation Repr = new TableRepresentation();
        //    Repr.Assign(TblInf.Repr_Text, Mode_Rplc_Simply0_Null1ByNonNull2, CreateDefaultIfNull);
        //    //Repr = TblInf.GetRepresentation_Text();
        //    //if (TblInfExt != null && TblInfExt.Repr_Text != null) Repr = TblInfExt.Repr_Text;
        //    //else if (TblInfExt == null && this.TblInf != null && this.TblInf.Repr_Text != null) Repr = this.TblInf.Repr_Text;
        //    //else if (TblInfExt != null && TblInfExt.Repr_Text == null && this.TblInf != null && this.TblInf.Repr_Text != null)
        //    //{
        //    //    switch (SubClasses_IfExtNull_LeaveNull0CreateDefault1AllowInner2)
        //    //    {
        //    //        case 1:
        //    //            Repr = new TableRepresentation();
        //    //            break;
        //    //        case 2:
        //    //            Repr = this.TblInf.Repr_Text;
        //    //            break;
        //    //        //default or 0 - NOp - null
        //    //    }
        //    //}
        //    //else Repr = new TableRepresentation();
        //    ////
        //    //if (Repr.GetGeneralRepresentation() == null || Repr.GetContentCellRepresentation() == null || Repr.ColHeaderRepresentation() == null || Repr.LineHeaderRepr == null || Repr_Text.ContentRepr.ColHeader == null || Repr_Text.ContentRepr.LineHeader == null)
        //    //{
        //    //    switch (SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2)
        //    //    {
        //    //        case 1:
        //    //            if (Repr.GenRepr == null) Repr.GenRepr = new TableGeneralRepresentation();
        //    //            if (Repr.ContentRepr == null) Repr.ContentRepr = new TableContentCellRepresentation();
        //    //            if (Repr.ColHeaderRepr == null) Repr.ColHeaderRepr = new TableHeaderCellRepresentation();
        //    //            if (Repr.LineHeaderRepr == null) Repr.LineHeaderRepr = new TableHeaderCellRepresentation();
        //    //            if (Repr.ContentRepr.ColHeader == null) Repr.ContentRepr.ColHeader = new TableHeaderCellRepresentation();
        //    //            if (Repr.ContentRepr.LineHeader == null) Repr.ContentRepr.LineHeader = new TableHeaderCellRepresentation();
        //    //            break;
        //    //        case 2:
        //    //            if (Repr.GenRepr == null)
        //    //            {
        //    //                if (TblInfExt != null && (TblInfExt.Repr_Text == null || (TblInfExt.Repr_Text != null && TblInfExt.Repr_Text.GenRepr == null)) && this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.GenRepr != null)
        //    //                {
        //    //                    Repr.GenRepr = this.TblInf.Repr_Text.GenRepr;
        //    //                }else{
        //    //                    Repr.GenRepr = new TableGeneralRepresentation();
        //    //                }
        //    //            }
        //    //            if (Repr.ContentRepr == null)
        //    //            {
        //    //                if (TblInfExt != null && (TblInfExt.Repr_Text == null || (TblInfExt.Repr_Text != null && TblInfExt.Repr_Text.ContentRepr == null)) && this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.ContentRepr != null)
        //    //                {
        //    //                    Repr.ContentRepr = this.TblInf.Repr_Text.ContentRepr;
        //    //                }else{
        //    //                    Repr.ContentRepr = new TableContentCellRepresentation();
        //    //                }
        //    //            }
        //    //            if (Repr.ColHeaderRepr == null)
        //    //            {
        //    //                if (TblInfExt != null && (TblInfExt.Repr_Text == null || (TblInfExt.Repr_Text != null && TblInfExt.Repr_Text.ColHeaderRepr == null)) && this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.ColHeaderRepr != null)
        //    //                {
        //    //                    Repr.ColHeaderRepr = this.TblInf.Repr_Text.ColHeaderRepr;
        //    //                }else{
        //    //                    Repr.ColHeaderRepr = new TableHeaderCellRepresentation();
        //    //                }
        //    //            }
        //    //            if (Repr.LineHeaderRepr == null)
        //    //            {
        //    //                if (TblInfExt != null && (TblInfExt.Repr_Text == null || (TblInfExt.Repr_Text != null && TblInfExt.Repr_Text.LineHeaderRepr == null)) && this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.LineHeaderRepr != null)
        //    //                {
        //    //                    Repr.LineHeaderRepr = this.TblInf.Repr_Text.LineHeaderRepr;
        //    //                }else{
        //    //                    Repr.LineHeaderRepr = new TableHeaderCellRepresentation();
        //    //                }
        //    //            }
        //    //            if (Repr.ContentRepr.ColHeader == null)
        //    //            {
        //    //                if (TblInfExt != null && (TblInfExt.Repr_Text == null || (TblInfExt.Repr_Text != null && TblInfExt.Repr_Text.ContentRepr == null) || (TblInfExt.Repr_Text != null && TblInfExt.Repr_Text.ContentRepr != null && TblInfExt.Repr_Text.ContentRepr.ColHeader == null)) && this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.ContentRepr != null && this.TblInf.Repr_Text.ContentRepr.ColHeader != null)
        //    //                {
        //    //                    Repr.ContentRepr.ColHeader = this.TblInf.Repr_Text.ContentRepr.ColHeader;
        //    //                }else{
        //    //                    Repr.ContentRepr.ColHeader = new TableHeaderCellRepresentation();
        //    //                }
        //    //            }
        //    //            if (Repr.ContentRepr.LineHeader == null)
        //    //            {
        //    //                if (TblInfExt != null && (TblInfExt.Repr_Text == null || (TblInfExt.Repr_Text != null && TblInfExt.Repr_Text.ContentRepr == null) || (TblInfExt.Repr_Text != null && TblInfExt.Repr_Text.ContentRepr != null && TblInfExt.Repr_Text.ContentRepr.LineHeader == null)) && this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.ContentRepr != null && this.TblInf.Repr_Text.ContentRepr.LineHeader != null)
        //    //                {
        //    //                    Repr.ContentRepr.LineHeader = this.TblInf.Repr_Text.ContentRepr.LineHeader;
        //    //                }
        //    //                else
        //    //                {
        //    //                    Repr.ContentRepr.LineHeader = new TableHeaderCellRepresentation();
        //    //                }
        //    //            }
        //    //            break;
        //    //        //default or 0 - NOp - null
        //    //    }
        //    //}
        //    //
        //    return Repr;
        //}
        public TableRepresentation GetTableRepresentationByVrn5(TableInfo_ConcrRepr TblInfExt, bool CreatedDfltIfNull = true, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            //int Mode_Repl_Simply0_Null1_ByNonNull2=2;
            //bool CreatedDfltIfNull=true;
            TableRepresentation Repr = null, ReprExt = null;
            TRowsNumeration num;
            if (TblInfExt != null) ReprExt = TblInfExt.Repr;
            if (this.TblInf != null) Repr = this.TblInf.GetRepresentation_Text();
            if (Repr == null) Repr = new TableRepresentation();
            Repr.Assign(ReprExt, Mode_Repl_Simply0_Null1_ByNonNull2, CreatedDfltIfNull);
            return Repr;
        }
        public TableRepresentation GetTableTextRepresentationByVrn5(TableInfo TblInfExt, bool CreatedDfltIfNull=true, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            //int Mode_Repl_Simply0_Null1_ByNonNull2=2;
            //bool CreatedDfltIfNull=true;
            TableRepresentation Repr = null, ReprExt=null;
            TRowsNumeration num;
            if (TblInfExt != null) ReprExt = TblInfExt.Repr_Text;
            if (this.TblInf != null) Repr = this.TblInf.GetRepresentation_Text();
            if (Repr == null) Repr = new TableRepresentation();
            Repr.Assign(ReprExt, Mode_Repl_Simply0_Null1_ByNonNull2, CreatedDfltIfNull);
            return Repr;
        }
        //public TableRepresentation GetTableTextRepresentationByVrn4(TableInfo TblInfExt, bool CreatedDfltIfNull = true, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        //{
        //    //int Mode_Repl_Simply0_Null1_ByNonNull2=2;
        //    //bool CreatedDfltIfNull=true;
        //    TableRepresentation Repr = null;
        //    TRowsNumeration num;
        //    if (this.TblInf != null) Repr = this.TblInf.GetRepresentation_Text();
        //    if (Repr == null) Repr = new TableRepresentation();
        //    Repr.Assign(TblInfExt.GetRepresentation_Text(), Mode_Repl_Simply0_Null1_ByNonNull2, CreatedDfltIfNull);
        //    return Repr;
        //}
        //public TableRepresentation GetTableGridRepresentationByVrn4(TableInfo TblInfExt, int Mode_Rplc_Simply0_Null1_ByNonNull2 = 2, bool CreateDefaultIfNull = true)
        //{
        //    //TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
        //    //int Mode_Rplc_Simply0_Null1_ByNonNull2 = 2;
        //    //bool CreateDefaultIfNull = true;
        //    //if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
        //    //TblInf.Repr_Text.Assign(TblInfExt.GetRepresentation_Text(), Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
        //    //return TblInf.GetRepresentation_Text();
        //    //
        //    //int Mode_Rplc_Simply0_Null1_ByNonNull2 = 2;
        //    //bool CreateDefaultIfNull = true;
        //    TableRepresentation ReprTblInner, ReprExt=null, ReprR;
        //    TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
        //    ReprTblInner = TblInf.GetRepresentation_Text();
        //    if (TblInfExt != null) ReprExt = TblInfExt.GetRepresentation_Text();
        //    ReprR = ReprTblInner;
        //    if (ReprR == null) ReprR = new TableRepresentation();
        //    ReprR.Assign(ReprExt, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
        //    return ReprR;
        //}
        public TableRepresentation GetTableGridRepresentationByVrn5(TableInfo TblInfExt, bool CreatedDfltIfNull = true, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            //int Mode_Repl_Simply0_Null1_ByNonNull2=2;
            //bool CreatedDfltIfNull=true;
            TableRepresentation Repr = null, ReprExt = null;
            TRowsNumeration num;
            if (TblInfExt != null) ReprExt = TblInfExt.Repr_Grid;
            if (this.TblInf != null) Repr = this.TblInf.GetRepresentation_Grid();
            if (Repr == null) Repr = new TableRepresentation();
            Repr.Assign(ReprExt, Mode_Repl_Simply0_Null1_ByNonNull2, CreatedDfltIfNull);
            return Repr;
        }
        public TableRepresentation GetTableGridRepresentationByVrn5(TableInfo_ConcrRepr TblInfExt, bool CreatedDfltIfNull = true, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            //int Mode_Repl_Simply0_Null1_ByNonNull2=2;
            //bool CreatedDfltIfNull=true;
            TableRepresentation Repr = null, ReprExt = null;
            TRowsNumeration num;
            if (TblInfExt != null) ReprExt = TblInfExt.Repr;
            if (this.TblInf != null) Repr = this.TblInf.GetRepresentation_Grid();
            if (Repr == null) Repr = new TableRepresentation();
            Repr.Assign(ReprExt, Mode_Repl_Simply0_Null1_ByNonNull2, CreatedDfltIfNull);
            return Repr;
        }
        //
        //public TableInfo Choose_TableInfo_StrSize_ByExtAndInner(TableInfo TblInfExt, int SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2 = 1, int SubClasses_IfExtNull_LeaveNull0CreateDefault1AllowInner2 = 1)
        //{
        //    TableInfo TblInf;
        //    TableStructure str;
        //    TableSize size;
        //    //TableRepresentation repr;
        //    str = GetTableStructureByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2);
        //    size = GetTableSizeByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2);
        //    //repr = GetRepresentationByVrn3(TblInfExt);
        //    TblInf = new TableInfo();
        //    TblInf.Str = str;
        //    TblInf.RowsQuantities = size;
        //    //TblInf.Repr = repr;
        //    return TblInf;
        //}
        //public TableInfo Choose_TableInfo_StrSize_ByExtAndInner(TableInfo TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        //{
        //    TableInfo TblInf;
        //    TableStructure str;
        //    TableSize size;
        //    //TableRepresentation repr;
        //    //str = GetTableStructureByVrn5(TblInfExt, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
        //    //size = GetTableSizeByVrn5(TblInfExt, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
        //    str = GetTableStructureByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
        //    size = GetTableSizeByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
        //    //repr = GetRepresentationByVrn3(TblInfExt);
        //    TblInf = new TableInfo();
        //    TblInf.Str = str;
        //    TblInf.RowsQuantities = size;
        //    //TblInf.Repr = repr;
        //    return TblInf;
        //}
        public TableInfo Choose_TableInfo_StrSize_ByExtAndInner(TableInfo TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableInfo TblInf = new TableInfo();
            TblInf.Str = this.GetTableStructureByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.RowsQuantities = this.GetTableSizeByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            //TblInf.Repr_Text = this.GetTableTextRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            //TblInf.Repr_Grid = this.GetTableGridRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            return TblInf;
        }
        public TableInfo_ConcrRepr Choose_TableInfo_StrSize_ByExtAndInner(TableInfo_ConcrRepr TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableInfo_ConcrRepr TblInf = new TableInfo_ConcrRepr();
            TblInf.Str = this.GetTableStructureByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.RowsQuantities = this.GetTableSizeByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            //TblInf.Repr_Text = this.GetTableTextRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            //TblInf.Repr_Grid = this.GetTableGridRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            return TblInf;
        }
        //public TableInfo Choose_TableInfo_StrSizeRepr_ByExtAndInner(TableInfo TblInfExt, int SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2 = 1, int SubClasses_IfExtNull_LeaveNull0CreateDefault1AllowInner2 = 1)
        //public TableInfo Choose_TableInfo_StrSizeRepr_ByExtAndInner(TableInfo TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        //{
        //    TableInfo TblInf;
        //    TableStructure str;
        //    TableSize size;
        //    TableRepresentation repr_Text=null;
        //    TableRepresentation repr_Grid = null;
        //    //str = GetTableStructureByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2=1);
        //    //size = GetTableSizeByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2=1);
        //    //public TableRepresentation GetTableTextRepresentationByVrn4(TableInfo TblInfExt, bool CreatedDfltIfNull=false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        //    //repr_Text = GetTableTextRepresentationByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2, SubClasses_IfExtNull_LeaveNull0CreateDefault1AllowInner2);
        //    //repr_Grid = GetTableGridRepresentationByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2, SubClasses_IfExtNull_LeaveNull0CreateDefault1AllowInner2);
        //    repr_Text = GetTableTextRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
        //    repr_Grid = GetTableGridRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
        //    TblInf = new TableInfo();
        //    TblInf.Str = str;
        //    TblInf.RowsQuantities = size;
        //    TblInf.Repr_Text = repr_Text;
        //    TblInf.Repr_Grid = repr_Grid;
        //    return TblInf;
        //}
        public TableInfo Choose_TableInfo_StrSizeRepr_ByExtAndInner(TableInfo TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableInfo TblInf=new TableInfo();
            TblInf.Str = this.GetTableStructureByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.RowsQuantities = this.GetTableSizeByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.Repr_Text = this.GetTableTextRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.Repr_Grid = this.GetTableGridRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            return TblInf;
        }
        public TableInfo_ConcrRepr Choose_TableInfo_StrSizeRepr_ByExtAndInner(TableInfo_ConcrRepr TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableInfo_ConcrRepr TblInf = new TableInfo_ConcrRepr();
            TblInf.Str = this.GetTableStructureByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.RowsQuantities = this.GetTableSizeByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.Repr = this.GetTableRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            //TblInf.Repr_Grid = this.GetTableGridRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            return TblInf;
        }
        //public TableInfo Choose_TableInfo_StrSizeUse_ByExtAndInner(TableInfo TblInfExt, int SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2=1, int ReprSubCllasses_IfNull_Nil0CreateDefault1FromInner2=1)
        //{
        //    TableInfo TblInf;
        //    TableStructure str;
        //    TableSize size;
        //    //TableRepresentation repr = null;
        //    TableUssagePolicy UssagePolicy = null;
        //    str = GetTableStructureByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2);
        //    size = GetTableSizeByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2);
        //    //repr = GetTableRepresentationByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2, ReprSubCllasses_IfNull_Nil0CreateDefault1FromInner2);
        //    UssagePolicy = GetTableUssagePolicyByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2);
        //    TblInf = new TableInfo();
        //    TblInf.Str = str;
        //    TblInf.RowsQuantities = size;
        //    //TblInf.Repr = repr;
        //    TblInf.UssagePolicy = UssagePolicy;
        //    return TblInf;
        //}
        public TableInfo Choose_TableInfo_StrSizeUse_ByExtAndInner(TableInfo TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableInfo TblInf = new TableInfo();
            TblInf.Str = this.GetTableStructureByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.RowsQuantities = this.GetTableSizeByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            //TblInf.Repr = this.GetTableTextRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            //TblInf.Repr_Text = this.GetTableTextRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            //TblInf.Repr_Grid = this.GetTableGridRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.UssagePolicy = this.GetTableUssagePolicyByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            return TblInf;
        }
        public TableInfo_ConcrRepr Choose_TableInfo_StrSizeUse_ByExtAndInner(TableInfo_ConcrRepr TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableInfo_ConcrRepr TblInf = new TableInfo_ConcrRepr();
            TblInf.Str = this.GetTableStructureByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.RowsQuantities = this.GetTableSizeByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            //TblInf.Repr = this.GetTableTextRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            //TblInf.Repr_Text = this.GetTableTextRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            //TblInf.Repr_Grid = this.GetTableGridRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.UssagePolicy = this.GetTableUssagePolicyByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            return TblInf;
        }
        //public TableInfo Choose_TableInfo_StrSizeReprUse_ByExtAndInner(TableInfo TblInfExt, int SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2 = 1, int ReprSubCllasses_IfNull_Nil0CreateDefault1FromInner2 = 1)
        //{
        //    TableInfo TblInf;
        //    TableStructure str;
        //    TableSize size;
        //    TableRepresentation repr_Text;
        //    TableRepresentation repr_Grid;
        //    TableUssagePolicy UssagePolicy;
        //    str = GetTableStructureByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2);
        //    size = GetTableSizeByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2);
        //    repr_Text = GetTableTextRepresentationByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2, ReprSubCllasses_IfNull_Nil0CreateDefault1FromInner2);
        //    repr_Grid = GetTableGridRepresentationByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2, ReprSubCllasses_IfNull_Nil0CreateDefault1FromInner2);
        //    UssagePolicy = GetTableUssagePolicyByVrn4(TblInfExt, SubClass_IfExtNull_LeaveNull0CreateDefault1AllowInner2);
        //    TblInf = new TableInfo();
        //    TblInf.Str = str;
        //    TblInf.RowsQuantities = size;
        //    TblInf.Repr_Text = repr_Text;
        //    TblInf.Repr_Grid = repr_Grid;
        //    TblInf.UssagePolicy = UssagePolicy;
        //    return TblInf;
        //}
        public TableInfo Choose_TableInfo_StrSizeReprUse_ByExtAndInner(TableInfo TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableInfo TblInf = new TableInfo();
            TblInf.Str = this.GetTableStructureByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.RowsQuantities = this.GetTableSizeByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.Repr_Text = this.GetTableTextRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.Repr_Grid = this.GetTableGridRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.UssagePolicy = this.GetTableUssagePolicyByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            return TblInf;
        }
        public TableInfo_ConcrRepr Choose_TableInfo_StrSizeReprUse_ByExtAndInner(TableInfo_ConcrRepr TblInfExt, bool CreatedDfltIfNull = false, int Mode_Repl_Simply0_Null1_ByNonNull2 = 2)
        {
            TableInfo_ConcrRepr TblInf = new TableInfo_ConcrRepr();
            TblInf.Str = this.GetTableStructureByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.RowsQuantities = this.GetTableSizeByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.Repr = this.GetTableRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            //TblInf.Repr_Text = this.GetTableTextRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            //TblInf.Repr_Grid = this.GetTableGridRepresentationByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            TblInf.UssagePolicy = this.GetTableUssagePolicyByVrn5(TblInfExt, CreatedDfltIfNull, Mode_Repl_Simply0_Null1_ByNonNull2);
            return TblInf;
        }
        //
        public void CreateContentByDefault()
        {
            if (this.TblInf == null) TblInf = new TableInfo();
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            this.TblInf.Repr_Text.CreateContentByDefault();
            this.TblInf.Repr_Grid.CreateContentByDefault();
        }
        //
        //
        public void Repr_Text_Set_GenReprNull()
        {
            if (TblInf != null && TblInf.Repr_Text != null && TblInf.Repr_Text.GetGeneralRepresentation() != null) TblInf.Repr_Text.SetGenReprNull();
        }
        public void Repr_Text_Set_ContentReprNull()
        {
            if (TblInf != null && TblInf.Repr_Text != null && TblInf.Repr_Text.GetContentRepr() != null) TblInf.Repr_Text.SetContentReprNull();
        }
        public void Repr_Text_Set_ColHeaderReprNull()
        {
            if (TblInf != null && TblInf.Repr_Text != null && TblInf.Repr_Text.GetColHeaderRepr() != null) TblInf.Repr_Text.SetColHeaderReprNull();
        }
        public void Repr_Text_Set_LineHeaderReprNull()
        {
            if (TblInf != null && TblInf.Repr_Text != null && TblInf.Repr_Text.GetLineHeaderRepr() != null) TblInf.Repr_Text.SetLineHeaderReprNull();
        }
        public void Repr_Text_Set_Null()
        {
            if (TblInf != null && TblInf.Repr_Text != null) TblInf.Repr_Text.SetNull();
        }
        //
        public void Repr_Text_Set_GenReprDefault_Text()
        {
            if(this.TblInf==null)TblInf=new TableInfo();
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            this.TblInf.Repr_Text.SetGenReprDefault();
        }
        public void Repr_Text_Set_LineHeaderReprDefault_Text()
        {
            if(this.TblInf==null)TblInf=new TableInfo();
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            this.TblInf.Repr_Text.SetLineHeaderReprDefault();
        }
        public void Repr_Text_Set_ColumnHeaderReprDefault()
        {
            if(this.TblInf==null)TblInf=new TableInfo();
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            this.TblInf.Repr_Text.SetColumnHeaderReprDefault();
        }
        //
        public void Repr_Text_Set_ColHeaderByExistanceByDefault(int ColHeaderExists_No0Yes1)
        {
            if(this.TblInf==null)TblInf=new TableInfo();
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            this.TblInf.Repr_Text.SetColHeaderByExistanceByDefault(ColHeaderExists_No0Yes1);
        }
        public void Repr_Text_Set_LineHeaderByExistanceByDefault(int LineHeaderExists_No0Yes1)
        {
            if(this.TblInf==null)TblInf=new TableInfo();
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            this.TblInf.Repr_Text.SetLineHeaderByExistanceByDefault(LineHeaderExists_No0Yes1);
        }
        //
        public void Repr_Text_Set_Matrix()
        {
            if(this.TblInf==null)TblInf=new TableInfo();
            //if(this.TblInf.Repr==null) this.TblInf.Repr=new TableRepresentation();
            CreateFullRepresentation_Text();
            this.TblInf.Repr_Text.Set_Matrix();
        }
        public void Repr_Text_Set_List()
        {
            if(this.TblInf==null)TblInf=new TableInfo();
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            this.TblInf.Repr_Text.Set_List();
        }
        public void Repr_Text_Set_Simple()
        {
            if(this.TblInf==null)TblInf=new TableInfo();
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            this.TblInf.Repr_Text.Set_Simple();
        }
        public void Repr_Text_Set_SimpleNumerated(int N_No0Col1Line2Both3=3)
        {
            if(this.TblInf==null)TblInf=new TableInfo();
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            this.TblInf.Repr_Text.Set_SimpleNumerated(N_No0Col1Line2Both3);
        }
        public void Repr_Text_Set_2ArgsFn()
        {
            if(this.TblInf==null)TblInf=new TableInfo();
            //if(this.TblInf.Repr==null) this.TblInf.Repr=new TableRepresentation();
            CreateFullRepresentation_Text();
            this.TblInf.Repr_Text.Set_2ArgsFn();
        }
        //
        //
        public void Repr_Grid_Set_GenReprNull()
        {
            if (TblInf != null && TblInf.Repr_Grid != null && TblInf.Repr_Grid.GetGeneralRepresentation() != null) TblInf.Repr_Grid.SetGenReprNull();
        }
        public void Repr_Grid_Set_ContentReprNull()
        {
            if (TblInf != null && TblInf.Repr_Grid != null && TblInf.Repr_Grid.GetContentRepr() != null) TblInf.Repr_Grid.SetContentReprNull();
        }
        public void Repr_Grid_Set_ColHeaderReprNull()
        {
            if (TblInf != null && TblInf.Repr_Grid != null && TblInf.Repr_Grid.GetColHeaderRepr() != null) TblInf.Repr_Grid.SetColHeaderReprNull();
        }
        public void Repr_Grid_Set_LineHeaderReprNull()
        {
            if (TblInf != null && TblInf.Repr_Grid != null && TblInf.Repr_Grid.GetLineHeaderRepr() != null) TblInf.Repr_Grid.SetLineHeaderReprNull();
        }
        public void Repr_Grid_Set_Null()
        {
            if (TblInf != null && TblInf.Repr_Grid != null) TblInf.Repr_Grid.SetNull();
        }
        //
        public void Repr_Grid_Set_GenReprDefault_Grid()
        {
            if (this.TblInf == null) TblInf = new TableInfo();
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            this.TblInf.Repr_Grid.SetGenReprDefault();
        }
        public void Repr_Grid_Set_LineHeaderReprDefault_Grid()
        {
            if (this.TblInf == null) TblInf = new TableInfo();
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            this.TblInf.Repr_Grid.SetLineHeaderReprDefault();
        }
        public void Repr_Grid_Set_ColumnHeaderReprDefault()
        {
            if (this.TblInf == null) TblInf = new TableInfo();
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            this.TblInf.Repr_Grid.SetColumnHeaderReprDefault();
        }
        //
        public void Repr_Grid_Set_ColHeaderByExistanceByDefault(int ColHeaderExists_No0Yes1)
        {
            if (this.TblInf == null) TblInf = new TableInfo();
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            this.TblInf.Repr_Grid.SetColHeaderByExistanceByDefault(ColHeaderExists_No0Yes1);
        }
        public void Repr_Grid_Set_LineHeaderByExistanceByDefault(int LineHeaderExists_No0Yes1)
        {
            if (this.TblInf == null) TblInf = new TableInfo();
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            this.TblInf.Repr_Grid.SetLineHeaderByExistanceByDefault(LineHeaderExists_No0Yes1);
        }
        //
        public void Repr_Grid_Set_Matrix()
        {
            if (this.TblInf == null) TblInf = new TableInfo();
            //if(this.TblInf.Repr==null) this.TblInf.Repr=new TableRepresentation();
            CreateFullRepresentation_Grid();
            this.TblInf.Repr_Grid.Set_Matrix();
        }
        public void Repr_Grid_Set_List()
        {
            if (this.TblInf == null) TblInf = new TableInfo();
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            this.TblInf.Repr_Grid.Set_List();
        }
        public void Repr_Grid_Set_Simple()
        {
            if (this.TblInf == null) TblInf = new TableInfo();
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            this.TblInf.Repr_Grid.Set_Simple();
        }
        public void Repr_Grid_Set_SimpleNumerated(int N_No0Col1Line2Both3=3)
        {
            if (this.TblInf == null) TblInf = new TableInfo();
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            this.TblInf.Repr_Grid.Set_SimpleNumerated(N_No0Col1Line2Both3);
        }
        public void Repr_Grid_Set_2ArgsFn()
        {
            if (this.TblInf == null) TblInf = new TableInfo();
            //if(this.TblInf.Repr==null) this.TblInf.Repr=new TableRepresentation();
            CreateFullRepresentation_Grid();
            this.TblInf.Repr_Grid.Set_2ArgsFn();
        }
        //
        //
        //public void ReprSet_GenReprNull()
        //{
        //    if (TblInf != null && TblInf.Repr != null && TblInf.Repr.GenRepr != null) TblInf.Repr.SetGenReprNull();
        //}
        //public void ReprSet_ContentReprNull()
        //{
        //    if (TblInf != null && TblInf.Repr != null && TblInf.Repr.ContentRepr != null) TblInf.Repr.SetContentReprNull();
        //}
        //public void ReprSet_ColHeaderReprNull()
        //{
        //    if (TblInf != null && TblInf.Repr != null && TblInf.Repr.ColHeaderRepr != null) TblInf.Repr.SetColHeaderReprNull();
        //}
        //public void ReprSet_LineHeaderReprNull()
        //{
        //    if (TblInf != null && TblInf.Repr != null && TblInf.Repr.LineHeaderRepr != null) TblInf.Repr.SetLineHeaderReprNull();
        //}
        //public void ReprSet_Null()
        //{
        //    if (TblInf != null && TblInf.Repr != null) TblInf.Repr.SetNull();
        //}
        ////
        //public void ReprSet_GenReprDefault()
        //{
        //    if (this.TblInf == null) TblInf = new TableInfo();
        //    if (this.TblInf.Repr == null) this.TblInf.Repr = new TableRepresentation();
        //    this.TblInf.Repr.SetGenReprDefault();
        //}
        //public void ReprSet_LineHeaderReprDefault()
        //{
        //    if (this.TblInf == null) TblInf = new TableInfo();
        //    if (this.TblInf.Repr == null) this.TblInf.Repr = new TableRepresentation();
        //    this.TblInf.Repr.SetLineHeaderReprDefault();
        //}
        //public void ReprSet_ColumnHeaderReprDefault()
        //{
        //    if (this.TblInf == null) TblInf = new TableInfo();
        //    if (this.TblInf.Repr == null) this.TblInf.Repr = new TableRepresentation();
        //    this.TblInf.Repr.SetColumnHeaderReprDefault();
        //}
        //public void CreateContentByDefault()
        //{
        //    if (this.TblInf == null) TblInf = new TableInfo();
        //    if (this.TblInf.Repr == null) this.TblInf.Repr = new TableRepresentation();
        //    this.TblInf.Repr.CreateContentByDefault();
        //}
        ////
        //public void ReprSet_ColHeaderByExistanceByDefault(int ColHeaderExists_No0Yes1)
        //{
        //    if (this.TblInf == null) TblInf = new TableInfo();
        //    if (this.TblInf.Repr == null) this.TblInf.Repr = new TableRepresentation();
        //    this.TblInf.Repr.SetColHeaderByExistanceByDefault(ColHeaderExists_No0Yes1);
        //}
        //public void ReprSet_LineHeaderByExistanceByDefault(int LineHeaderExists_No0Yes1)
        //{
        //    if (this.TblInf == null) TblInf = new TableInfo();
        //    if (this.TblInf.Repr == null) this.TblInf.Repr = new TableRepresentation();
        //    this.TblInf.Repr.SetLineHeaderByExistanceByDefault(LineHeaderExists_No0Yes1);
        //}
        ////
        //public void ReprSet_Matrix()
        //{
        //    if (this.TblInf == null) TblInf = new TableInfo();
        //    //if(this.TblInf.Repr==null) this.TblInf.Repr=new TableRepresentation();
        //    CreateFullRepresentation();
        //    this.TblInf.Repr.Set_Matrix();
        //}
        //public void ReprSet_List()
        //{
        //    if (this.TblInf == null) TblInf = new TableInfo();
        //    if (this.TblInf.Repr == null) this.TblInf.Repr = new TableRepresentation();
        //    this.TblInf.Repr.Set_List();
        //}
        //public void ReprSet_Simple()
        //{
        //    if (this.TblInf == null) TblInf = new TableInfo();
        //    if (this.TblInf.Repr == null) this.TblInf.Repr = new TableRepresentation();
        //    this.TblInf.Repr.Set_Simple();
        //}
        //public void ReprSet_SimpleNumerated(int N_No0Col1Line2Both3)
        //{
        //    if (this.TblInf == null) TblInf = new TableInfo();
        //    if (this.TblInf.Repr == null) this.TblInf.Repr = new TableRepresentation();
        //    this.TblInf.Repr.Set_SimpleNumerated(N_No0Col1Line2Both3);
        //}
        //public void ReprSet_2ArgsFn()
        //{
        //    if (this.TblInf == null) TblInf = new TableInfo();
        //    //if(this.TblInf.Repr==null) this.TblInf.Repr=new TableRepresentation();
        //    CreateFullRepresentation();
        //    this.TblInf.Repr.Set_2ArgsFn();
        //}
        //
        // Header Rows
        //
        public void DelExistingColOfLineHeader()
        {
            bool LC_Not_CL, LoCHExists;
            //
            ColOfLineHeader = null;
            //
            if (TblInf != null)
            {
                LoCHExists = GetIfLineOfColHeaderExists();
                LC_Not_CL = GetIf_LC_Matrix_Not_CL_DB();
                TblInf.SetStr(LC_Not_CL, false, LoCHExists);
            }
        }
        public void DelExistingLineOfColHeader()
        {
            bool LC_Not_CL, CoLHExists;
            //
            ColOfLineHeader = null;
            //
            if (TblInf != null)
            {
                CoLHExists = GetIfColOfLineHeaderExists();
                LC_Not_CL = GetIf_LC_Matrix_Not_CL_DB();
                TblInf.SetStr(LC_Not_CL, CoLHExists, false);
            }
        }
        public void CreateColOfLineHeader(int[]types)
        {
            bool LC_Not_CL = GetIf_LC_Matrix_Not_CL_DB(), LoCHExists = GetIfLineOfColHeaderExists();
            int QLines = GetQLines();
            TableCellAccessConfiguration cfg = new TableCellAccessConfiguration();
            cfg.PreserveVal = true;
            ColOfLineHeader = new DataCell[QLines];
            if (types != null)
            {
                for (int i = 1; i <= QLines; i++) SetCellTypeN_ColOfLineHeader(i, types[i - 1], null, cfg);
            }
            else
            {
                for (int i = 1; i <= QLines; i++) SetCellTypeN_ColOfLineHeader(i, TableConsts.DefaultColOfLineHeaderCellTypeN, null, cfg);
            }
            if (TblInf != null)
            {
                TblInf.SetStr(LC_Not_CL, true, LoCHExists);
            }
        }
        public void CreateLineOfColHeader(int[] types)
        {
            TableCellAccessConfiguration CellCfg = new TableCellAccessConfiguration();
            CellCfg.PreserveVal = true;
            bool LC_Not_CL=GetIf_LC_Matrix_Not_CL_DB(), CoLHExists=GetIfColOfLineHeaderExists();
            int QColumns = GetQColumns();
            ColOfLineHeader = new DataCell[QColumns];
            if (types != null)
            {
                for (int i = 1; i <= QColumns; i++) SetCellTypeN_LineOfColHeader(i, types[i - 1], null, CellCfg);
            }
            else
            {
                for (int i = 1; i <= QColumns; i++) SetCellTypeN_LineOfColHeader(i, TableConsts.DefaultLineOfColHeaderCellTypeN, null, CellCfg);
            }
            if (TblInf != null)
            {
                TblInf.SetStr(LC_Not_CL, CoLHExists, true);
            }
        }
        public void CreateFirstColOfLineHeader(int[] types)
        {
            CreateColOfLineHeader(types);
        }
        public void CreateFirstLineOfColHeader(int[] types)
        {
            CreateLineOfColHeader(types);
        }
        //
        //wa constrs and for it; wi Headers 
        //
        bool GetIf_HeadersExist()
        {
            //return (TblInf != null && TblInf.Headers != null);
            return (TblInf != null && Headers != null);
        }
        void CreateHeaders()
        {
            if (TblInf == null)
            {
                TblInf = new TableInfo();
                //if(TblInf.Headers==null) TblInf.Headers=new TableHeaders();
                if (Headers == null) Headers = new TableHeaders();
            }
            else
            {
                //TblInf.Headers = new TableHeaders();
                Headers = new TableHeaders();
            }
        }
        void DeleteHeaders()
        {
            //if (TblInf!=null && TblInf.Headers != null) TblInf.Headers = null;
            if (Headers != null) Headers = null;
        }
        bool GetIf_LinesGeneralHeaderExists()
        {
            //return (TblInf != null && TblInf.Headers != null && TblInf.Headers.LinesGeneralName != null && TblInf.Headers.LinesGeneralName.ToString()!="");
            //return (TblInf != null && TblInf.Headers != null && TblInf.Headers.LinesGeneralName != null);
            return (Headers != null && Headers.LinesGeneralHeader != null);
        }
        bool GetIf_LinesGeneralHeaderIsNotEmpty()
        {
            //return (TblInf != null && TblInf.Headers != null && TblInf.Headers.LinesGeneralName != null);
            //return (TblInf != null && TblInf.Headers != null && TblInf.Headers.LinesGeneralName != null && TblInf.Headers.LinesGeneralName.ToString() != "");
            return (Headers != null && Headers.LinesGeneralHeader != null && Headers.LinesGeneralHeader.ToString() != "");
        }
        void CreateLinesGeneralHeader()
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //if (TblInf.Headers == null) TblInf.Headers = new TableHeaders();
            if (Headers == null) Headers = new TableHeaders();
            //if (TblInf.Headers.LinesGeneralName == null) TblInf.Headers.LinesGeneralName = new DataCell(TableConsts.StringArrayTypeN, 2);
            if (Headers.LinesGeneralHeader == null) Headers.LinesGeneralHeader = new DataCell(TableConsts.StringArrayTypeN, 2);
        }
        void DeleteLinesGeneralHeader()
        {
            //if (TblInf != null && TblInf.Headers != null && TblInf.Headers.LinesGeneralName != null) TblInf.Headers.LinesGeneralName = null;
            if (Headers != null && Headers.LinesGeneralHeader != null) Headers.LinesGeneralHeader = null;
        }
        bool GetIf_ColumnsGeneralHeaderExists()
        {
            //return (TblInf != null && TblInf.Headers != null && TblInf.Headers.ColumnsGeneralName != null && TblInf.Headers.ColumnsGeneralName.ToString() != "");
            //return (TblInf != null && TblInf.Headers != null && TblInf.Headers.ColumnsGeneralName != null);
            return (Headers != null && Headers.ColumnsGeneralHeader != null);
        }
        bool GetIf_ColumnsGeneralHeaderIsNotEmpty()
        {
            //return (TblInf != null && TblInf.Headers != null && TblInf.Headers.ColumnsGeneralName != null);
            //return (TblInf != null && TblInf.Headers != null && TblInf.Headers.ColumnsGeneralName != null && TblInf.Headers.ColumnsGeneralName.ToString() != "");
            return (Headers != null && Headers.ColumnsGeneralHeader != null && Headers.ColumnsGeneralHeader.ToString() != "");
        }
        void CreateColumnsGeneralHeader()
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //if (TblInf.Headers == null) TblInf.Headers = new TableHeaders();
            if (Headers == null) Headers = new TableHeaders();
            //if (TblInf.Headers.ColumnsGeneralName == null) TblInf.Headers.ColumnsGeneralName = new DataCell(TableConsts.StringArrayTypeN, 2);
            if (Headers.ColumnsGeneralHeader == null) Headers.ColumnsGeneralHeader = new DataCell(TableConsts.StringArrayTypeN, 2);
        }
        void DeleteColumnsGeneralHeader()
        {
            //*if (TblInf != null && TblInf.Headers != null && TblInf.Headers.ColumnsGeneralName != null) TblInf.Headers.ColumnsGeneralName = null;
            if (Headers != null && Headers.ColumnsGeneralHeader != null) Headers.ColumnsGeneralHeader = null;
        }
        //
        // Table Headers (2) 
        //
        public void SetTableHeadersNull()
        {
            //if (TblInf!=null) TblInf.SetTableHeadersNull();
            //if (Headers != null) Headers.SetTableHeadersNull();
            if (Headers != null) Headers=null;
        }
        //
        public void CreateTableHeader()
        {
            //if (TblInf == null) TblInf = new TableInfo();
           //TblInf.CreateTableHeader();
            if (Headers == null) Headers = new TableHeaders();
            Headers.CreateTableHeader();
        }
        public void DeleteTableHeader()
        {
            //if (TblInf != null) TblInf.DeleteTableHeader();
            if (Headers != null) Headers.DeleteTableHeader();
        }
        public void CreateLinesGeneralName()
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.CreateLinesGeneralName();
            if (Headers == null) Headers = new TableHeaders();
            Headers.CreateLinesGeneralName();
        }
        public void DeleteLinesGeneralName()
        {
            //if (TblInf != null) TblInf.DeleteLinesGeneralName();
            if (Headers != null) Headers.DeleteLinesGeneralName();
        }
        public void CreateColumnsGeneralName()
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.CreateColumnsGeneralName();
            if (Headers == null) Headers = new TableHeaders(); 
            Headers.CreateColumnsGeneralName();
        }
        public void DeleteColumnsGeneralName()
        {
            //if (TblInf != null) TblInf.DeleteColumnsGeneralName();
            if (Headers != null) Headers.DeleteColumnsGeneralName();
        }
        //
        public void SetTableHeaders(DataCell TableHeader, DataCell LinesGeneralName, DataCell ColumnsGeneralName)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetTableHeaders(TableHeader, LinesGeneralName, ColumnsGeneralName);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetTableHeaders(TableHeader, LinesGeneralName, ColumnsGeneralName);
        }
        public void SetTableHeader(DataCell TableHeader)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetTableHeader(TableHeader);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetTableHeader(TableHeader);
        }
        public void SetLinesGeneralHeader(DataCell LinesGeneralName)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetLinesGeneralHeader(LinesGeneralName);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetLinesGeneralHeader(LinesGeneralName);
        }
        public void SetColumnsGeneralHeader(DataCell ColumnsGeneralName)
        {
            //if (TblInf == null ) TblInf = new TableInfo();
            //TblInf.SetColumnsGeneralHeader(ColumnsGeneralName);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetColumnsGeneralHeader(ColumnsGeneralName);
        }
        //mark2
        public DataCell GetTableHeader()
        {
            DataCell R = null;
            //if (TblInf != null) R = TblInf.GetTableHeader();
            if (Headers != null) R = Headers.GetTableHeader();
            return R;
        }
        public TDataCell GetTableHeaderInner()
        {
            TDataCell R = null;
            //if (TblInf != null) R = TblInf.GetTableHeaderInner();
            if (Headers != null) R = Headers.GetTableHeaderInner();
            return R;
        }
        public string GetTableHeaderName()
        {
            string R = null;
            //if (TblInf != null) R = TblInf.GetTableHeaderName();
            if (Headers != null) R = Headers.GetTableHeaderName();
            return R;
        }
        string GetTableHeaderName1()
        {
            string R = null;
            //if (TblInf != null) R = TblInf.GetTableHeaderName1();
            if (Headers != null) R = Headers.GetTableHeaderName1();
            return R;
        }
        string GetTableHeaderName2()
        {
            string R = null;
            //if (TblInf != null) R = TblInf.GetTableHeaderName2();
            if (Headers != null) R = Headers.GetTableHeaderName2();
            return R;
        }
        //
        public void SetTableHeaderNames(string name1, string name2)
        {
            //if (TblInf == null)
            //{
            //    TblInf = new TableInfo();
            //    TblInf.SetTableHeaderNames(name1, name2);
            //}
            //else
            //{
            //    TblInf.SetTableHeaderNames(name1, name2);
            //}
            if (Headers == null)
            {
                Headers = new TableHeaders();
                Headers.SetTableHeaderNames(name1, name2);
            }
            else
            {
                Headers.SetTableHeaderNames(name1, name2);
            }
        }//fn
        //
        public void SetTableHeaderName(string name)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetTableHeaderNames(name, null);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetTableHeaderNames(name, null);
        }
        public void SetTableHeaderName1(string name)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetTableHeaderName1(name);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetTableHeaderName1(name);
        }
        public void SetTableHeaderName2(string name)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetTableHeaderName2(name);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetTableHeaderName2(name);
        }
        public void SetTableHeaderNameN(string name, int N)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetTableHeaderNameN(name, N);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetTableHeaderNameN(name, N);
        }
        //
        public void SetLinesGeneralNames(string name1, string name2)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetLinesGeneralNames(name1, name2);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetLinesGeneralNames(name1, name2);
        }//fn
        public void SetLinesGeneralName(string name)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetLinesGeneralName(name);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetLinesGeneralName(name);
        }
        public void SetLinesGeneralName1(string name)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetLinesGeneralName1(name);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetLinesGeneralName1(name);
        }
        public void SetLinesGeneralName2(string name)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetLinesGeneralName2(name);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetLinesGeneralName2(name);
        }
        public void SetLinesGeneralNameN(string name, int N)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetLinesGeneralNameN(name, N);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetLinesGeneralNameN(name, N);
        }
        //
        public void SetColumnsGeneralNames(string name1, string name2)
        {
           // if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetColumnsGeneralNames(name1, name2);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetColumnsGeneralNames(name1, name2);
        }//fn
        public void SetColumnsGeneralName(string name)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetColumnsGeneralName(name);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetColumnsGeneralName(name);
        }
        public void SetColumnsGeneralName1(string name)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetColumnsGeneralName1(name);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetColumnsGeneralName1(name);
        }
        public void SetColumnsGeneralName2(string name)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetColumnsGeneralName2(name);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetColumnsGeneralName2(name);
        }
        public void SetColumnsGeneralNameN(string name, int N)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetColumnsGeneralNameN(name, N);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetColumnsGeneralNameN(name, N);
        }
        //
        public DataCell GetLinesGeneralHeader()
        {
            DataCell R = null;
            //if (TblInf != null) R = TblInf.GetLinesGeneralHeader();
            if (Headers != null) R = Headers.GetLinesGeneralHeader();
            return R;
        }
        public TDataCell GetLinesGeneralHeaderInner()
        {
            TDataCell R = null;
            //if (TblInf != null) R = TblInf.GetLinesGeneralHeaderInner();
            if (Headers != null) R = Headers.GetLinesGeneralHeaderInner();
            return R;
        }
        string GetLinesGeneralName()
        {
            string sr = null;
            //if (TblInf != null && TblInf.Headers!=null && TblInf.Headers.GetLinesGeneralHeader()!=null) sr = TblInf.GetLinesGeneralName();
            //if (Headers != null && Headers.GetLinesGeneralHeader() != null) sr = TblInf.GetLinesGeneralName();
            if (Headers != null && Headers.GetLinesGeneralHeader() != null) sr = Headers.GetLinesGeneralName();
            return sr;
        }
        string GetLinesGeneralName1()
        {
            string sr = null;
            //if (TblInf != null && TblInf.Headers != null && TblInf.Headers.GetLinesGeneralHeader() != null) sr = TblInf.GetLinesGeneralName1();
            //if (Headers != null && Headers.GetLinesGeneralHeader() != null) sr = TblInf.GetLinesGeneralName1();
            if (Headers != null && Headers.GetLinesGeneralHeader() != null) sr = Headers.GetLinesGeneralName1();
            return sr;
        }
        string GetLinesGeneralName2()
        {
            string sr = null;
            //if (TblInf != null && TblInf.Headers != null && TblInf.Headers.GetLinesGeneralHeader() != null) sr = TblInf.GetLinesGeneralName2();
            if (Headers != null && Headers.GetLinesGeneralHeader() != null) sr = Headers.GetLinesGeneralName2();
            return sr;
        }
        //
        public DataCell GetColumnsGeneralHeader()
        {
            DataCell R = null;
            //if (TblInf != null) R = TblInf.GetColumnsGeneralHeader();
            if (Headers != null) R = Headers.GetColumnsGeneralHeader();
            return R;
        }
        public TDataCell GetColumnsGeneralHeaderInner()
        {
            TDataCell R = null;
            //if (TblInf != null) R = TblInf.GetColumnsGeneralHeaderInner();
            if (Headers != null) R = Headers.GetColumnsGeneralHeaderInner();
            return R;
        }
        string GetColumnsGeneralName()
        {
            string sr = null;
            //if (TblInf != null && TblInf.Headers!=null && TblInf.Headers.GetColumnsGeneralHeader()!=null) sr = TblInf.GetColumnsGeneralName();
            if (Headers != null && Headers.GetColumnsGeneralHeader() != null) sr = Headers.GetColumnsGeneralName();
            return sr;
        }
        string GetColumnsGeneralName1()
        {
            string sr = null;
            //if (TblInf != null && TblInf.Headers != null && TblInf.Headers.GetColumnsGeneralHeader() != null) sr = TblInf.GetColumnsGeneralName1();
            if (Headers != null && Headers.GetColumnsGeneralHeader() != null) sr = Headers.GetColumnsGeneralName1();
            return sr;
        }
        string GetColumnsGeneralName2()
        {
            string sr = null;
            //if (TblInf != null && TblInf.Headers != null && TblInf.Headers.GetColumnsGeneralHeader() != null) sr = TblInf.GetColumnsGeneralName2();
            if (Headers != null && Headers.GetColumnsGeneralHeader() != null) sr = Headers.GetColumnsGeneralName2();
            return sr;
        }
        //
        public void SetTableHeaderSize(int TableHeaderSize)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetTableHeaderSize(TableHeaderSize);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetTableHeaderSize(TableHeaderSize);
        }
        public void SetLinesGeneralNameSize(int LinesGeneralNameSize)
        {
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetTableHeaderSize(LinesGeneralNameSize);
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetTableHeaderSize(LinesGeneralNameSize);
        }
        public void SetColumnsGeneralNameSize(int ColumnsGeneralNameSize)
        {
            if (Headers == null) Headers = new TableHeaders();
            Headers.SetColumnsGeneralNameSize(ColumnsGeneralNameSize);
        }
        //
        //
        //
        void SetReprTextWhole(TableInfo_ConcrRepr Repr)
        {
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.dets != null)
            {
                this.TblInf.Repr_Text.dets.GenRepr = Repr.Repr.dets.GenRepr;
                this.TblInf.Repr_Text.dets.ColHeaderRepr =Repr.Repr.dets.ColHeaderRepr;
                this.TblInf.Repr_Text.dets.LineHeaderRepr = Repr.Repr.dets.LineHeaderRepr;
                this.TblInf.Repr_Text.dets.ContentRepr = Repr.Repr.dets.ContentRepr;
                this.TblInf.Repr_Text.dets.ContentRepr.LineHeader = Repr.Repr.dets.ContentRepr.LineHeader;
                this.TblInf.Repr_Text.dets.ContentRepr.ColHeader = Repr.Repr.dets.ContentRepr.ColHeader;
            }

        }
        void SetReprTextGen(TableGeneralRepresentation GenRepr)
        {
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.dets != null)
            {
                this.TblInf.Repr_Text.dets.GenRepr = GenRepr;
                //this.TblInf.Repr_Text.dets.ColHeaderRepr = Repr.Repr.dets.ColHeaderRepr;
                //this.TblInf.Repr_Text.dets.LineHeaderRepr = Repr.Repr.dets.LineHeaderRepr;
                //this.TblInf.Repr_Text.dets.ContentRepr = Repr.Repr.dets.ContentRepr;
                //this.TblInf.Repr_Text.dets.ContentRepr.LineHeader = Repr.Repr.dets.ContentRepr.LineHeader;
                //this.TblInf.Repr_Text.dets.ContentRepr.ColHeader = Repr.Repr.dets.ContentRepr.ColHeader;
            }
        }
        void SetReprTextGen(TableGeneralRepresentation GenRepr, bool CreateIfNull)
        {
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.dets != null)
            {
                this.TblInf.Repr_Text.dets.GenRepr = (TableGeneralRepresentation)GenRepr.Clone();
            }
            if(CreateIfNull){
                if(this.TblInf==null)this.TblInf=new TableInfo();
                if(this.TblInf.Repr_Text==null)this.TblInf.Repr_Text=new TableRepresentation();
                if(this.TblInf.Repr_Text.dets==null)this.TblInf.Repr_Text.dets=new TableRepresentationDetails();
                if(this.TblInf.Repr_Text.dets.GenRepr==null) this.TblInf.Repr_Text.dets.GenRepr=new TableGeneralRepresentation();
                this.TblInf.Repr_Text.dets.GenRepr=(TableGeneralRepresentation)GenRepr.Clone();
            }
        }
        void SetReprTextLineHdr(TableHeaderCellRepresentation LineHdrCellRepr, bool CreateIfNull)
        {
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.dets != null)
            {
                this.TblInf.Repr_Text.dets.LineHeaderRepr = (TableHeaderCellRepresentation)LineHdrCellRepr.Clone();
            }
            if(CreateIfNull){
                if(this.TblInf==null)this.TblInf=new TableInfo();
                if(this.TblInf.Repr_Text==null)this.TblInf.Repr_Text=new TableRepresentation();
                if(this.TblInf.Repr_Text.dets==null)this.TblInf.Repr_Text.dets=new TableRepresentationDetails();
                if(this.TblInf.Repr_Text.dets.LineHeaderRepr==null) this.TblInf.Repr_Text.dets.LineHeaderRepr=new TableHeaderCellRepresentation();
                 this.TblInf.Repr_Text.dets.LineHeaderRepr=(TableHeaderCellRepresentation)LineHdrCellRepr.Clone();
            }
        }
        void SetReprTextColHdr(TableHeaderCellRepresentation ColHdrCellRepr, bool CreateIfNull)
        {
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.dets != null)
            {
                this.TblInf.Repr_Text.dets.LineHeaderRepr = (TableHeaderCellRepresentation)ColHdrCellRepr.Clone(); ;
            }
            if (CreateIfNull)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
                if (this.TblInf.Repr_Text.dets == null) this.TblInf.Repr_Text.dets = new TableRepresentationDetails();
                if (this.TblInf.Repr_Text.dets.LineHeaderRepr == null) this.TblInf.Repr_Text.dets.LineHeaderRepr = new TableHeaderCellRepresentation();
                this.TblInf.Repr_Text.dets.ColHeaderRepr = (TableHeaderCellRepresentation)ColHdrCellRepr.Clone();
            }
        }
        void SetReprTextCntCell(TableContentCellRepresentation CntRepr, bool CreateIfNull)
        {
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.dets != null)
            {
                this.TblInf.Repr_Text.dets.ContentRepr = (TableContentCellRepresentation)CntRepr.Clone();
            }
            if (CreateIfNull)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
                if (this.TblInf.Repr_Text.dets == null) this.TblInf.Repr_Text.dets = new TableRepresentationDetails();
                if (this.TblInf.Repr_Text.dets.ContentRepr == null) this.TblInf.Repr_Text.dets.ContentRepr = new TableContentCellRepresentation();
                this.TblInf.Repr_Text.dets.ContentRepr = (TableContentCellRepresentation)CntRepr.Clone();
            }
        }
        void SetReprTextLineHdrOfCntCell(TableHeaderCellRepresentation LHOfCntRepr, bool CreateIfNull)
        {
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.dets != null)
            {
                this.TblInf.Repr_Text.dets.ContentRepr.LineHeader = (TableHeaderCellRepresentation)LHOfCntRepr.Clone();
            }
            if (CreateIfNull)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
                if (this.TblInf.Repr_Text.dets == null) this.TblInf.Repr_Text.dets = new TableRepresentationDetails();
                if (this.TblInf.Repr_Text.dets.ContentRepr == null) this.TblInf.Repr_Text.dets.ContentRepr = new TableContentCellRepresentation();
                if (this.TblInf.Repr_Text.dets.ContentRepr.LineHeader == null) this.TblInf.Repr_Text.dets.ContentRepr.LineHeader = new TableHeaderCellRepresentation();
                this.TblInf.Repr_Text.dets.ContentRepr.LineHeader = (TableHeaderCellRepresentation)LHOfCntRepr.Clone();
            }
        }
        void SetReprTextColHdrOfCntCell(TableHeaderCellRepresentation CHOfCntRepr, bool CreateIfNull)
        {
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.dets != null)
            {
                this.TblInf.Repr_Text.dets.ContentRepr.ColHeader = (TableHeaderCellRepresentation)CHOfCntRepr.Clone();
            }
            if (CreateIfNull)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
                if (this.TblInf.Repr_Text.dets == null) this.TblInf.Repr_Text.dets = new TableRepresentationDetails();
                if (this.TblInf.Repr_Text.dets.ContentRepr == null) this.TblInf.Repr_Text.dets.ContentRepr = new TableContentCellRepresentation();
                if (this.TblInf.Repr_Text.dets.ContentRepr.ColHeader == null) this.TblInf.Repr_Text.dets.ContentRepr.ColHeader = new TableHeaderCellRepresentation();
                this.TblInf.Repr_Text.dets.ContentRepr.ColHeader = (TableHeaderCellRepresentation)CHOfCntRepr.Clone();
            }
        }
        //
        //
        void SetReprGridWhole(TableInfo_ConcrRepr Repr)
        {
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets != null)
            {
                this.TblInf.Repr_Grid.dets.GenRepr = Repr.Repr.dets.GenRepr;
                this.TblInf.Repr_Grid.dets.ColHeaderRepr = Repr.Repr.dets.ColHeaderRepr;
                this.TblInf.Repr_Grid.dets.LineHeaderRepr = Repr.Repr.dets.LineHeaderRepr;
                this.TblInf.Repr_Grid.dets.ContentRepr = Repr.Repr.dets.ContentRepr;
                this.TblInf.Repr_Grid.dets.ContentRepr.LineHeader = Repr.Repr.dets.ContentRepr.LineHeader;
                this.TblInf.Repr_Grid.dets.ContentRepr.ColHeader = Repr.Repr.dets.ContentRepr.ColHeader;
            }

        }
        void SetReprGridGen(TableGeneralRepresentation GenRepr)
        {
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets != null)
            {
                this.TblInf.Repr_Grid.dets.GenRepr = GenRepr;
                //this.TblInf.Repr_Grid.dets.ColHeaderRepr = Repr.Repr.dets.ColHeaderRepr;
                //this.TblInf.Repr_Grid.dets.LineHeaderRepr = Repr.Repr.dets.LineHeaderRepr;
                //this.TblInf.Repr_Grid.dets.ContentRepr = Repr.Repr.dets.ContentRepr;
                //this.TblInf.Repr_Grid.dets.ContentRepr.LineHeader = Repr.Repr.dets.ContentRepr.LineHeader;
                //this.TblInf.Repr_Grid.dets.ContentRepr.ColHeader = Repr.Repr.dets.ContentRepr.ColHeader;
            }
        }
        void SetReprGridGen(TableGeneralRepresentation GenRepr, bool CreateIfNull)
        {
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets != null)
            {
                this.TblInf.Repr_Grid.dets.GenRepr = (TableGeneralRepresentation)GenRepr.Clone();
            }
            if (CreateIfNull)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
                if (this.TblInf.Repr_Grid.dets == null) this.TblInf.Repr_Grid.dets = new TableRepresentationDetails();
                if (this.TblInf.Repr_Grid.dets.GenRepr == null) this.TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
                this.TblInf.Repr_Grid.dets.GenRepr = (TableGeneralRepresentation)GenRepr.Clone();
            }
        }
        void SetReprGridLineHdr(TableHeaderCellRepresentation LineHdrCellRepr, bool CreateIfNull)
        {
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets != null)
            {
                this.TblInf.Repr_Grid.dets.LineHeaderRepr = (TableHeaderCellRepresentation)LineHdrCellRepr.Clone();
            }
            if (CreateIfNull)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
                if (this.TblInf.Repr_Grid.dets == null) this.TblInf.Repr_Grid.dets = new TableRepresentationDetails();
                if (this.TblInf.Repr_Grid.dets.LineHeaderRepr == null) this.TblInf.Repr_Grid.dets.LineHeaderRepr = new TableHeaderCellRepresentation();
                this.TblInf.Repr_Grid.dets.LineHeaderRepr = (TableHeaderCellRepresentation)LineHdrCellRepr.Clone();
            }
        }
        void SetReprGridColHdr(TableHeaderCellRepresentation ColHdrCellRepr, bool CreateIfNull)
        {
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets != null)
            {
                this.TblInf.Repr_Grid.dets.LineHeaderRepr = (TableHeaderCellRepresentation)ColHdrCellRepr.Clone(); ;
            }
            if (CreateIfNull)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
                if (this.TblInf.Repr_Grid.dets == null) this.TblInf.Repr_Grid.dets = new TableRepresentationDetails();
                if (this.TblInf.Repr_Grid.dets.LineHeaderRepr == null) this.TblInf.Repr_Grid.dets.LineHeaderRepr = new TableHeaderCellRepresentation();
                this.TblInf.Repr_Grid.dets.ColHeaderRepr = (TableHeaderCellRepresentation)ColHdrCellRepr.Clone();
            }
        }
        void SetReprGridCntCell(TableContentCellRepresentation CntRepr, bool CreateIfNull)
        {
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets != null)
            {
                this.TblInf.Repr_Grid.dets.ContentRepr = (TableContentCellRepresentation)CntRepr.Clone();
            }
            if (CreateIfNull)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
                if (this.TblInf.Repr_Grid.dets == null) this.TblInf.Repr_Grid.dets = new TableRepresentationDetails();
                if (this.TblInf.Repr_Grid.dets.ContentRepr == null) this.TblInf.Repr_Grid.dets.ContentRepr = new TableContentCellRepresentation();
                this.TblInf.Repr_Grid.dets.ContentRepr = (TableContentCellRepresentation)CntRepr.Clone();
            }
        }
        void SetReprGridLineHdrOfCntCell(TableHeaderCellRepresentation LHOfCntRepr, bool CreateIfNull)
        {
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets != null)
            {
                this.TblInf.Repr_Grid.dets.ContentRepr.LineHeader = (TableHeaderCellRepresentation)LHOfCntRepr.Clone();
            }
            if (CreateIfNull)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
                if (this.TblInf.Repr_Grid.dets == null) this.TblInf.Repr_Grid.dets = new TableRepresentationDetails();
                if (this.TblInf.Repr_Grid.dets.ContentRepr == null) this.TblInf.Repr_Grid.dets.ContentRepr = new TableContentCellRepresentation();
                if (this.TblInf.Repr_Grid.dets.ContentRepr.LineHeader == null) this.TblInf.Repr_Grid.dets.ContentRepr.LineHeader = new TableHeaderCellRepresentation();
                this.TblInf.Repr_Grid.dets.ContentRepr.LineHeader = (TableHeaderCellRepresentation)LHOfCntRepr.Clone();
            }
        }
        void SetReprGridColHdrOfCntCell(TableHeaderCellRepresentation CHOfCntRepr, bool CreateIfNull)
        {
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets != null)
            {
                this.TblInf.Repr_Grid.dets.ContentRepr.ColHeader = (TableHeaderCellRepresentation)CHOfCntRepr.Clone();
            }
            if (CreateIfNull)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
                if (this.TblInf.Repr_Grid.dets == null) this.TblInf.Repr_Grid.dets = new TableRepresentationDetails();
                if (this.TblInf.Repr_Grid.dets.ContentRepr == null) this.TblInf.Repr_Grid.dets.ContentRepr = new TableContentCellRepresentation();
                if (this.TblInf.Repr_Grid.dets.ContentRepr.ColHeader == null) this.TblInf.Repr_Grid.dets.ContentRepr.ColHeader = new TableHeaderCellRepresentation();
                this.TblInf.Repr_Grid.dets.ContentRepr.ColHeader = (TableHeaderCellRepresentation)CHOfCntRepr.Clone();
            }
        }
        //
        //
        //Getters 1 
        //
        public bool GetIfCellExists(int LineN, int ColN, TableInfo TblInfExt)
        {
            bool verdict;
            bool LoCHExists, CoLHExists;
            int QLines, QColumns, ErstLineN, ErstColN;
            TableInfo TblInf=Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //if (TblInfExt != null && TblInfExt.RowsQuantities!=null) TblInf = TblInfExt;
            //else if (this.TblInf != null && this.TblInf.RowsQuantities!=null) TblInf = this.TblInf;
            //else TblInf = new TableInfo();
            //if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            LoCHExists = GetIfLineOfColHeaderExists();
            CoLHExists = GetIfColOfLineHeaderExists();
            QLines = TblInf.GetQLines();
            QColumns = TblInf.GetQColumns();
            verdict = false;
            if (LineN <= QLines && ColN <= QColumns && LineN >=0 && ColN >=0)
            {
                //if(LineN==0 && ColN==0) verdict=true; //corner is not an existing cell
                //else 
                if (LineN == 0 && ColN != 0)
                {
                    if(LoCHExists) verdict = true;
                }
                else if (ColN == 0 && LineN != 0)
                {
                    if (CoLHExists) verdict = true;
                }
                else //LN>0 && CN>0=> 
                {
                    verdict = true;
                }
            }
            return verdict;
        }
        public bool GetIfCellExists_LineOfColHeader(int ColN, TableInfo TblInfExt)
        {
            bool verdict;
            bool LoCHExists, CoLHExists;
            int QLines, QColumns, ErstLineN, ErstColN;
            TableInfo TblInf;
            if (TblInfExt != null && TblInfExt.RowsQuantities != null) TblInf = TblInfExt;
            else if (this.TblInf != null && this.TblInf.RowsQuantities != null) TblInf = this.TblInf;
            else TblInf = new TableInfo();
            LoCHExists = GetIfLineOfColHeaderExists();
            CoLHExists = GetIfColOfLineHeaderExists();
            QLines = TblInf.GetQLines();
            QColumns = TblInf.GetQColumns();
            if (LoCHExists) ErstColN = 0; else ErstColN = 1;
            if (CoLHExists) ErstLineN = 0; else ErstLineN = 1;
            verdict = (ColN >= ErstColN && ColN <= QColumns && LoCHExists && LoCHExists);
            return verdict;
        }
        public bool GetIfCellExists_ColOfLineHeader(int LineN, TableInfo TblInfExt)
        {
            bool verdict;
            bool LoCHExists, CoLHExists;
            int QLines, QColumns, ErstLineN, ErstColN;
            TableInfo TblInf;
            if (TblInfExt != null && TblInfExt.RowsQuantities != null) TblInf = TblInfExt;
            else if (this.TblInf != null && this.TblInf.RowsQuantities != null) TblInf = this.TblInf;
            else TblInf = new TableInfo();
            LoCHExists = GetIfLineOfColHeaderExists();
            CoLHExists = GetIfColOfLineHeaderExists();
            QLines = TblInf.GetQLines();
            QColumns = TblInf.GetQColumns();
            if (LoCHExists) ErstColN = 0; else ErstColN = 1;
            if (CoLHExists) ErstLineN = 0; else ErstLineN = 1;
            verdict = (LineN >= ErstLineN && LineN <= QLines && CoLHExists);
            return verdict;
        }
        //public bool GetIfColNExists(int ColN)
        //{
        //    bool verdict;
        //    bool LoCHExists, CoLHExists;
        //    int QLines, QColumns, ErstLineN, ErstColN;
        //    LoCHExists = GetIfLineOfColHeaderExists();
        //    CoLHExists = GetIfColOfLineHeaderExists();
        //    QLines = GetQLines();
        //    QColumns = GetQColumns();
        //    if (LoCHExists) ErstColN = 0; else ErstColN = 1;
        //    if (CoLHExists) ErstLineN = 0; else ErstLineN = 1;
        //    verdict = (ColN >= ErstColN && ColN <= QColumns);
        //    return verdict;
        //}
        //public bool GetIfLineNExists(int LineN)
        //{
        //    bool verdict;
        //    bool LoCHExists, CoLHExists;
        //    int QLines, QColumns, ErstLineN, ErstColN;
        //    LoCHExists = GetIfLineOfColHeaderExists();
        //    CoLHExists = GetIfColOfLineHeaderExists();
        //    QLines = GetQLines();
        //    QColumns = GetQColumns();
        //    if (LoCHExists) ErstColN = 0; else ErstColN = 1;
        //    if (CoLHExists) ErstLineN = 0; else ErstLineN = 1;
        //    verdict = (LineN >= ErstLineN && LineN <= QLines);
        //    return verdict;
        //}
        public bool GetIfSuchColHeaderExists(int ColN)
        {
            return  GetIfColumnNExists(ColN);
        }
        public bool GetIfSuchColHeaderExists(string name)
        {
            bool verdict;
            bool LoCHExists, CoLHExists;
            string s;
            int QLines, QColumns, ErstLineN, ErstColN;
            LoCHExists = GetIfLineOfColHeaderExists();
            CoLHExists = GetIfColOfLineHeaderExists();
            QLines = GetQLines();
            QColumns = GetQColumns();
            if (LoCHExists) ErstColN = 0; else ErstColN = 1;
            if (CoLHExists) ErstLineN = 0; else ErstLineN = 1;
            verdict=false;
            if(LoCHExists)
            {
                for(int i=1; i<=QColumns; i++){
                    s=ToString_LineOfColHeader(i);
                    if (name.Equals(s)) verdict = true;
                }
            }
            return verdict;
        }
        public bool GetIfSuchColHeaderExists_byNameToShow(string name)
        {
            bool verdict, NExists, TypeFits, NameSame;
            bool LoCHExists, CoLHExists;
            string s;
            int QLines, QColumns, ErstLineN, ErstColN;
            LoCHExists = GetIfLineOfColHeaderExists();
            CoLHExists = GetIfColOfLineHeaderExists();
            QLines = GetQLines();
            QColumns = GetQColumns();
            if (LoCHExists) ErstColN = 0; else ErstColN = 1;
            if (CoLHExists) ErstLineN = 0; else ErstLineN = 1;
            verdict = false;
            if (LoCHExists)
            {
                for (int i = 1; i <= QColumns; i++)
                {
                    s = ToString_LineOfColHeader(i);
                    if (name.Equals(s)) verdict = true;
                }
            }
            return verdict;
        }
        public bool GetIfSuchColHeaderExists_byNameToConnect(string name)
        {
            bool verdict, NExists, TypeFits, NameSame;
            bool LoCHExists, CoLHExists;
            string s;
            int QLines, QColumns, ErstLineN, ErstColN;
            LoCHExists = GetIfLineOfColHeaderExists();
            CoLHExists = GetIfColOfLineHeaderExists();
            QLines = GetQLines();
            QColumns = GetQColumns();
            if (LoCHExists) ErstColN = 0; else ErstColN = 1;
            if (CoLHExists) ErstLineN = 0; else ErstLineN = 1;
            verdict = false;
            if (LoCHExists)
            {
                for (int i = 1; i <= QColumns; i++)
                {
                    s = ToString_LineOfColHeader(i);
                    if (name.Equals(s)) verdict = true;
                }
            }
            return verdict;
        }
        //
        //
        public bool TypeNIsCorrect(int N)
        {
            bool verdict;
            verdict=(N==TableConsts.DoubleTypeN || N==TableConsts.FloatTypeN || N==TableConsts.IntTypeN || N==TableConsts.BoolTypeN || N==TableConsts.StringTypeN || N==TableConsts.UniqueIntValKeeperTypeN || N==TableConsts.DoubleArrayTypeN || N==TableConsts.FloatArrayTypeN || N==TableConsts.IntArrayTypeN || N==TableConsts.BoolArrayTypeN || N==TableConsts.StringArrayTypeN);
            return verdict;
        }
        //
        //Setters
        //
        public void SetLine(int LineN, DataCellRowCoHeader row, TableInfo TblInfExt)
        {
            int ErstLineN;
            TableInfo TblInf=Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            if(TblInf.GetIf_LoCHExists())ErstLineN=0; else ErstLineN=1;
            if (LineN >= ErstLineN && LineN <= TblInf.GetQLines())
            {
                if (LineN > 0)
                {
                    for (int i = 1; i <= TblInf.GetQColumns(); i++)
                    {
                        if (TblInf.GetIf_LC_Not_CL())
                        {
                            this.ContentCell[LineN - 1][i - 1] = row.GetContentCellN(i);
                        }
                        else
                        {
                            this.ContentCell[i - 1][LineN - 1] = row.GetContentCellN(i);
                        }
                    }
                    if (TblInf.GetIf_CoLHExists()) ColOfLineHeader[LineN - 1] = row.GetHeader();
                }
                else
                {
                    if (TblInf.GetIf_LoCHExists())
                    {
                        for (int i = 1; i <= GetQColumns(); i++)
                        {
                            LineOfColHeader[i - 1] = row.GetContentCellN(i);
                        }
                    }
                }
            }
        }//fn
        public void SetEmptyLine(int LineN, DataTypeRow RowTypes, DataCellTypeInfo HeaderType, TableInfo TblInfExt)
        {
            int ErstLineN,TypeN, length;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            if (TblInf.GetIf_LoCHExists()) ErstLineN = 0; else ErstLineN = 1;
            if (LineN >= ErstLineN && LineN <= TblInf.GetQLines())
            {
                if (LineN > 0)
                {
                    for (int i = 1; i <= TblInf.GetQColumns(); i++)
                    {
                        TypeN=RowTypes.GetTypeN(i);
                        length=RowTypes.GetLength(i);
                        if (TblInf.GetIf_LC_Not_CL())
                        {
                            this.ContentCell[LineN - 1][i - 1].SetTypeN(TypeN, null);
                            this.ContentCell[LineN - 1][i - 1].SetLength(length);
                        }
                        else
                        {
                            this.ContentCell[i - 1][LineN - 1].SetTypeN(TypeN, null);
                            this.ContentCell[i - 1][LineN - 1].SetLength(length);
                        }
                    }
                    if (TblInf.GetIf_CoLHExists())
                    {
                        TypeN = HeaderType.GetTypeN();
                        length = HeaderType.GetLength();
                        ColOfLineHeader[LineN - 1].SetTypeN(TypeN, null);
                        ColOfLineHeader[LineN - 1].SetLength(length);
                    }
                }
                else
                {
                    if (TblInf.GetIf_LoCHExists())
                    {
                        for (int i = 1; i <= TblInf.GetQColumns(); i++)
                        {
                            TypeN = HeaderType.GetTypeN();
                            length = HeaderType.GetLength();
                            LineOfColHeader[i - 1]. SetTypeN(TypeN, null);
                            LineOfColHeader[i - 1].SetLength(length);
                        }
                    }
                }
            }
        }//fn
        //
        public void SetColumn(int ColumnN, DataCellRowCoHeader row, TableInfo TblInfExt)
        {
            int ErstColumnN;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            if (TblInf.GetIf_CoLHExists()) ErstColumnN = 0; else ErstColumnN = 1;
            if (ColumnN >= ErstColumnN && ColumnN <= TblInf.GetQColumns())
            {
                if (ColumnN > 0)
                {
                    for (int i = 1; i <= TblInf.GetQLines(); i++)
                    {
                        if (TblInf.GetIf_LC_Not_CL())
                        {
                            this.ContentCell[i - 1][ColumnN - 1] = row.GetContentCellN(i);
                        }
                        else
                        {
                            this.ContentCell[ColumnN - 1][i - 1] = row.GetContentCellN(i);
                        }
                    }
                    if (TblInf.GetIf_LoCHExists()) LineOfColHeader[ColumnN - 1] = row.GetHeader();
                }
                else
                {
                    if (TblInf.GetIf_CoLHExists())
                    {
                        for (int i = 1; i <= GetQLines(); i++)
                        {
                            ColOfLineHeader[i - 1] = row.GetContentCellN(i);
                        }
                    }
                }
            }
        }//fn
        public void SetEmptyColumn(int ColumnN, DataTypeRow RowTypes, DataCellTypeInfo HeaderType, TableInfo TblInfExt)
        {
            int ErstColumnN, TypeN, length;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            if (TblInf.GetIf_CoLHExists()) ErstColumnN = 0; else ErstColumnN = 1;
            if (ColumnN >= ErstColumnN && ColumnN <= TblInf.GetQColumns())
            {
                if (ColumnN > 0)
                {
                    for (int i = 1; i <= TblInf.GetQLines(); i++)
                    {
                        TypeN = RowTypes.GetTypeN(i);
                        length = RowTypes.GetLength(i);
                        if (TblInf.GetIf_LC_Not_CL())
                        {
                            this.ContentCell[i - 1][ColumnN - 1].SetTypeN(TypeN, null);
                            this.ContentCell[i - 1][ColumnN - 1].SetLength(length);
                        }
                        else
                        {
                            this.ContentCell[ColumnN - 1][i - 1].SetTypeN(TypeN, null);
                            this.ContentCell[ColumnN - 1][i - 1].SetLength(length);
                        }
                    }
                    if (TblInf.GetIf_LoCHExists())
                    {
                        TypeN = HeaderType.GetTypeN();
                        length = HeaderType.GetLength();
                        LineOfColHeader[ColumnN - 1].SetTypeN(TypeN, null);
                        LineOfColHeader[ColumnN - 1].SetLength(length);
                    }
                }
                else
                {
                    if (TblInf.GetIf_CoLHExists())
                    {
                        for (int i = 1; i <= GetQLines(); i++)
                        {
                            TypeN = HeaderType.GetTypeN();
                            length = HeaderType.GetLength();
                            ColOfLineHeader[i - 1].SetTypeN(TypeN, null);
                            ColOfLineHeader[i - 1].SetLength(length);
                        }
                    }
                }
            }
        }//fn
        //
        //
        public void AddEmptyLine(DataTypeRow RowTypes, DataCellTypeInfo HeaderTypeExt, TableInfo TblInfExt=null/*, bool ToWrite=true*/)
        {
            TableCellAccessConfiguration cfg=new TableCellAccessConfiguration();
            cfg.PreserveVal=false;
            DataCell[][] NewContent;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCellTypeInfo HeaderType;
            int QLines = TblInf.GetQLines(), QColumns = TblInf.GetQColumns();
            if(HeaderTypeExt!=null) HeaderType=HeaderTypeExt; else HeaderType=new DataCellTypeInfo();
            if (TblInf.GetIf_LC_Not_CL())
            {
                NewContent = new DataCell[QLines + 1][];
                for (int i = 1; i <= QLines+1; i++)
                {
                    NewContent[i - 1] = new DataCell[QColumns];
                }
                for (int i = 1; i <= QLines+1; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        NewContent[i - 1][j - 1] = new DataCell();
                    }
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        NewContent[i - 1][j - 1] = ContentCell[i - 1][j - 1];
                    }
                }
                if (RowTypes != null)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        cfg.LengthOfArrCellTypes = RowTypes.GetLength(j);
                        NewContent[QLines + 1 - 1][j - 1].SetTypeN(RowTypes.GetTypeN(j), cfg);
                    }
                }
                else
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        cfg.LengthOfArrCellTypes = RowTypes.GetLength(j);
                        NewContent[QLines + 1 - 1][j - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, cfg);
                    }
                }
            }
            else
            {
                NewContent = new DataCell[QColumns][];
                for (int i = 1; i <= QColumns; i++)
                {
                    NewContent[i - 1] = new DataCell[QLines+1];
                }
                for (int i = 1; i <= QColumns + 1; i++)
                {
                    for (int j = 1; j <= QLines + 1; j++)
                    {
                        NewContent[i - 1][j - 1] = new DataCell();
                    }
                }
                for (int i = 1; i <= QColumns; i++)
                {
                    for (int j = 1; j <= QLines; j++)
                    {
                        NewContent[i - 1][j - 1] = ContentCell[i - 1][j - 1];
                    }
                }
                if (RowTypes != null)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        cfg.LengthOfArrCellTypes = RowTypes.GetLength(j);
                        NewContent[j - 1][QLines + 1 - 1].SetTypeN(RowTypes.GetTypeN(j), cfg);
                    }
                }
                else
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        cfg.LengthOfArrCellTypes = RowTypes.GetLength(j);
                        NewContent[j - 1][QLines + 1 - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, cfg);
                    }
                }
            }
            if (TblInf.GetIf_CoLHExists())
            {
                MyLib.AddToVector(ref ColOfLineHeader, ref QLines, new DataCell());
                if (HeaderType != null)
                {
                    cfg.LengthOfArrCellTypes = HeaderType.GetLength();
                    ColOfLineHeader[QLines-1].SetTypeN(HeaderType.GetTypeN(), cfg);
                }
                else
                {
                    cfg.LengthOfArrCellTypes = 2;
                    ColOfLineHeader[QLines - 1].SetTypeN(TableConsts.DefaultColOfLineHeaderCellTypeN, cfg);
                }
                QLines--;//ob hic chapter abl adab, ma ac hic chapter QLines ne increases - so s'done ut QLines increase anyhow - alif/alas
            }
            ContentCell = NewContent;
            /*if (ToWrite)
            {
                TblInf.SetSize(QLines + 1, QColumns);
                if (this.TblInf == null) this.TblInf = TblInf;
            }*/
            if (this.TblInf!=null) TblInf.SetSize(QLines + 1, QColumns);
        }
        public void AddEmptyLine_TypesByExisting(TableInfo TblInfExt = null, bool ToWrite = true)
        {
            DataCellTypeInfo HeaderType=null;
            DataCellTypeInfo[] CellTypes;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int QLines=TblInf.GetQLines(), QColumns=TblInf.GetQColumns();
            CellTypes = new DataCellTypeInfo[QColumns];
            for (int i = 1; i <= QColumns; i++) CellTypes[i - 1] = new DataCellTypeInfo(GetCell(QLines, i, TblInf.GetTableInfo_ConcrRepr()).GetTypeN(), GetCell(QLines, i, TblInf.GetTableInfo_ConcrRepr()).GetLength());
            if (TblInf.GetIf_CoLHExists()) HeaderType = new DataCellTypeInfo(ColOfLineHeader[QLines - 1].GetTypeN(), ColOfLineHeader[QLines - 1].GetLength());
            //
            this.AddEmptyLine(new DataTypeRow(QColumns, CellTypes), HeaderType, TblInfExt);
        }
        public void AddLine(DataCellRowCoHeader row, TableInfo TblInfExt = null, bool ToWrite = true) 
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int QColumns=TblInf.GetQColumns(), QLines=TblInf.GetQLines();
            AddEmptyLine_TypesByExisting(TblInf);
            SetLine(QLines+1, new DataCellRowCoHeader(row.GetHeader(), row.GetContent()), TblInf);
        }
        //
        public void InsEmptyLine(int LineN, DataTypeRow RowTypes, DataCellTypeInfo HeaderTypeExt, TableInfo TblInfExt = null, bool ToWrite = true)   //not finished yet
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int QLines = TblInf.GetQLines(), QColumns = TblInf.GetQColumns();
            int ErstLineN;
            int TypeN, Length;
            if (TblInf.GetIf_LoCHExists()) ErstLineN = 0; else ErstLineN = 1;
            TableCellAccessConfiguration cfg = new TableCellAccessConfiguration();
            if (LineN >= ErstLineN && LineN <= QLines)
            {
                cfg.PreserveVal = false;
                DataCell[][] NewContent;
                DataCellTypeInfo HeaderType;
                if (HeaderTypeExt != null) HeaderType = HeaderTypeExt; else HeaderType = new DataCellTypeInfo();
                if (TblInf.GetIf_LC_Not_CL())
                {
                    NewContent = new DataCell[QLines + 1][];
                    for (int i = 1; i <= QLines + 1; i++)
                    {
                        NewContent[i - 1] = new DataCell[QColumns];
                    }
                    for (int i = 1; i <= QLines+1; i++)
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            NewContent[i - 1][j - 1]=new DataCell();
                        }
                    }
                    for (int i = 1; i <= LineN; i++)
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            //NewContent[i - 1][j - 1] = ContentCell[i - 1][j - 1];
                            NewContent[i - 1][j - 1].Assign(ContentCell[i - 1][j - 1]);
                        }
                    }
                    for (int i = LineN + 1; i <= QLines + 1; i++)
                    //for (int i = QLines + 1; i>=LineN + 1; i--)
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            //NewContent[i - 1][j - 1] = ContentCell[i - 1 - 1][j - 1];
                            NewContent[i - 1][j - 1].Assign(ContentCell[i - 1 - 1][j - 1]);
                        }
                    }
                    if (RowTypes != null)
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            cfg.LengthOfArrCellTypes = RowTypes.GetLength(j);
                            TypeN = RowTypes.GetTypeN(j);
                            NewContent[LineN - 1][j - 1].SetTypeN(TypeN, cfg);
                        }
                    }
                    else
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            cfg.LengthOfArrCellTypes = RowTypes.GetLength(j);
                            NewContent[LineN - 1][j - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, cfg);
                        }
                    }
                }
                else
                {
                    NewContent = new DataCell[QColumns][];
                    for (int i = 1; i <= QColumns; i++)
                    {
                        NewContent[i - 1] = new DataCell[QLines + 1];
                    }
                    for (int i = 1; i <= QColumns; i++)
                    {
                        for (int j = 1; j <= QLines+1; j++)
                        {
                            NewContent[i - 1][j - 1] = new DataCell();
                        }
                    }
                    for (int i = 1; i <= QColumns; i++)
                    {
                        for (int j = 1; j <= LineN; j++)
                        {
                            //NewContent[i - 1][j - 1] = ContentCell[i - 1][j - 1];
                            NewContent[i - 1][j - 1].Assign(ContentCell[i - 1][j - 1]);
                        }
                    }
                    for (int i = 1; i <= QColumns; i++)
                    {
                        for (int j = LineN + 1; j <= QLines + 1; j++)
                        //for (int j = QLines + 1; j >= LineN + 1; j--)
                        {
                            //NewContent[i - 1][j - 1] = ContentCell[i - 1][j - 1 - 1];
                            NewContent[i - 1][j - 1].Assign(ContentCell[i - 1][j - 1 - 1]);
                        }
                    }
                    if (RowTypes != null)
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            cfg.LengthOfArrCellTypes = RowTypes.GetLength(j);
                            NewContent[j - 1][LineN - 1].SetTypeN(RowTypes.GetTypeN(j), cfg);
                        }
                    }
                    else
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            cfg.LengthOfArrCellTypes = RowTypes.GetLength(j);
                            NewContent[j - 1][LineN - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, cfg);
                        }
                    }
                }
                if (TblInf.GetIf_CoLHExists())
                {
                    MyLib.AddToVector(ref ColOfLineHeader, ref QLines, new DataCell());
                    for (int i = QLines; i >= LineN + 1; i--)
                    {
                        //ColOfLineHeader[i - 1] = ColOfLineHeader[i - 1 - 1];
                        ColOfLineHeader[i - 1] .Assign( ColOfLineHeader[i - 1 - 1]);
                    }
                    if (HeaderType != null)
                    {
                        cfg.LengthOfArrCellTypes = HeaderType.GetLength();
                        ColOfLineHeader[LineN - 1].SetTypeN(HeaderType.GetTypeN(), cfg);
                    }
                    else
                    {
                        cfg.LengthOfArrCellTypes = 2;
                        ColOfLineHeader[LineN - 1].SetTypeN(TableConsts.DefaultColOfLineHeaderCellTypeN, cfg);
                    }
                    QLines--;//
                }
                ContentCell = NewContent;
                if (ToWrite)
                {
                    TblInf.SetSize(QLines + 1, QColumns);
                    if (this.TblInf == null) this.TblInf = TblInf;
                }
            }
        }
        public void InsEmptyLine_TypesByExisting(int LineN, TableInfo TblInfExt = null, bool ToWrite = true)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int QLines=TblInf.GetQLines(), QColumns=TblInf.GetQColumns();
            int ErstLineN;
            if (TblInf.GetIf_LoCHExists()) ErstLineN = 0; else ErstLineN = 1;
            //DataTypeRow RowTypes;
            DataCellTypeInfo HeaderType = null;
            if (TblInf.GetIf_CoLHExists()) HeaderType = ColOfLineHeader[LineN - 1].GetTypeInfo();
            DataCellTypeInfo[] RowTypes=new DataCellTypeInfo[QColumns];
            if (LineN >= ErstLineN && LineN <= QLines)
            {
                for (int i = 1; i <= QColumns; i++) RowTypes[i - 1] = new DataCellTypeInfo(this.GetCell(LineN, i, TblInf.GetTableInfo_ConcrRepr()).GetTypeN(), this.GetCell(LineN, i, TblInf.GetTableInfo_ConcrRepr()).GetLength());
                if (TblInf.GetIf_CoLHExists()) HeaderType = new DataCellTypeInfo(GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr()).GetTypeN(), GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr()).GetLength());
                DataTypeRow CellTypes = new DataTypeRow(QColumns, RowTypes);
                InsEmptyLine(LineN, new DataTypeRow(QColumns, RowTypes), HeaderType, TblInf, ToWrite);
            }
        }
        public void InsLine(int LineN, DataCellRowCoHeader row, TableInfo TblInfExt = null, bool ToWrite = true)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int QLines = TblInf.GetQLines(), QColumns = TblInf.GetQColumns();
            int ErstLineN;
            if (TblInf.GetIf_LoCHExists()) ErstLineN = 0; else ErstLineN = 1;
            if (LineN >= ErstLineN && LineN <= QLines)
            {
                InsEmptyLine_TypesByExisting(LineN, TblInfExt, ToWrite);
                this.SetLine(LineN, row, TblInf);
            }
        }
        //
        public void AddEmptyColumn(DataTypeRow RowTypes, DataCellTypeInfo HeaderTypeExt, TableInfo TblInfExt = null, bool ToWrite = true)
        {
            TableCellAccessConfiguration cfg = new TableCellAccessConfiguration();
            cfg.PreserveVal = false;
            DataCell[][] NewContent;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCellTypeInfo HeaderType;
            int QLines = TblInf.GetQLines(), QColumns = TblInf.GetQColumns();
            if (HeaderTypeExt != null) HeaderType = HeaderTypeExt; else HeaderType = new DataCellTypeInfo();
            if (TblInf.GetIf_LC_Not_CL())
            {
                NewContent = new DataCell[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    NewContent[i - 1] = new DataCell[QColumns+1];
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns+1; j++)
                    {
                        NewContent[i - 1][j - 1] = new DataCell();
                    }
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        NewContent[i - 1][j - 1] = ContentCell[i - 1][j - 1];
                    }
                }
                if (RowTypes != null)
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        cfg.LengthOfArrCellTypes = RowTypes.GetLength(i);
                        NewContent[i - 1][QColumns+1 - 1].SetTypeN(RowTypes.GetTypeN(i), cfg);
                    }
                }
                else
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        cfg.LengthOfArrCellTypes = RowTypes.GetLength(i);
                        NewContent[i - 1][QColumns+1 - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, cfg);
                    }
                }
            }
            else
            {
                NewContent = new DataCell[QColumns+1][];
                for (int i = 1; i <= QColumns+1; i++)
                {
                    NewContent[i - 1] = new DataCell[QLines];
                }
                for (int i = 1; i <= QColumns; i++)
                {
                    for (int j = 1; j <= QLines; j++)
                    {
                        NewContent[i - 1][j - 1] = ContentCell[i - 1][j - 1];
                    }
                }
                for (int i = 1; i <= QColumns+1; i++)
                {
                    for (int j = 1; j <= QLines; j++)
                    {
                        NewContent[i - 1][j - 1] = new DataCell();
                    }
                }
                if (RowTypes != null)
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        cfg.LengthOfArrCellTypes = RowTypes.GetLength(i);
                        NewContent[QColumns+1 - 1][i - 1].SetTypeN(RowTypes.GetTypeN(i), cfg);
                    }
                }
                else
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        cfg.LengthOfArrCellTypes = RowTypes.GetLength(i);
                        NewContent[QColumns+1- 1][i - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, cfg);
                    }
                }
            }
            if (TblInf.GetIf_LoCHExists())
            {
                MyLib.AddToVector(ref LineOfColHeader, ref QColumns, new DataCell());
                if (HeaderType != null)
                {
                    cfg.LengthOfArrCellTypes = HeaderType.GetLength();
                    LineOfColHeader[QColumns - 1].SetTypeN(HeaderType.GetTypeN(), cfg);
                }
                else
                {
                    cfg.LengthOfArrCellTypes = 2;
                    LineOfColHeader[QColumns - 1].SetTypeN(TableConsts.DefaultColOfLineHeaderCellTypeN, cfg);
                }
                QColumns--;
            }
            ContentCell = NewContent;
            if (ToWrite)
            {
                TblInf.SetSize(QLines, QColumns + 1);
                if (this.TblInf == null) this.TblInf = TblInf;
            }
        }
        public void AddEmptyColumn_TypesByExisting(TableInfo TblInfExt = null, bool ToWrite = true)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCellTypeInfo HeaderType=null;
            int QLines=TblInf.GetQLines(), QColumns=TblInf.GetQColumns();
            DataCellTypeInfo[] ContentTypes=new DataCellTypeInfo[QLines];
            for (int i = 1; i <= QLines; i++) ContentTypes[i - 1] = new DataCellTypeInfo(GetCell(i, QColumns, TblInf.GetTableInfo_ConcrRepr()).GetTypeN(), GetCell(i, QColumns, TblInf.GetTableInfo_ConcrRepr()).GetLength());
            if (TblInf.GetIf_LoCHExists()) HeaderType = new DataCellTypeInfo(LineOfColHeader[QColumns - 1].GetTypeN(), LineOfColHeader[QColumns - 1].GetLength());
            AddEmptyColumn(new DataTypeRow(QLines, ContentTypes), HeaderType, TblInf, ToWrite);
        }
        //mark3
        public void AddColumn(DataCellRowCoHeader row, TableInfo TblInfExt = null, bool ToWrite = true){
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int QLines=TblInf.GetQLines(), QColumns=TblInf.GetQColumns();
            AddEmptyColumn_TypesByExisting(TblInfExt, ToWrite);
            QColumns++;
            SetColumn(QColumns, row, TblInf);
        }
        public void InsEmptyColumn(int ColumnN, DataTypeRow RowTypes, DataCellTypeInfo HeaderTypeExt, TableInfo TblInfExt = null, bool ToWrite = true)
        {
            TableCellAccessConfiguration cfg = new TableCellAccessConfiguration();
            cfg.PreserveVal = false;
            DataCell[][] NewContent;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCellTypeInfo HeaderType;
            int QLines = TblInf.GetQLines(), QColumns = TblInf.GetQColumns();
            if (HeaderTypeExt != null) HeaderType = HeaderTypeExt; else HeaderType = new DataCellTypeInfo();
            if (TblInf.GetIf_LC_Not_CL())
            {
                NewContent = new DataCell[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    NewContent[i - 1] = new DataCell[QColumns + 1];
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns + 1; j++)
                    {
                        NewContent[i - 1][j - 1] = new DataCell();
                    }
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= ColumnN; j++)
                    {
                        //NewContent[i - 1][j - 1] = ContentCell[i - 1][j - 1];
                        NewContent[i - 1][j - 1].Assign(ContentCell[i - 1][j - 1]);
                    }
                }
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = ColumnN + 1; j <= QColumns+1; j++)
                    {
                        //NewContent[i - 1][j - 1] = ContentCell[i - 1][j - 1 - 1];
                        NewContent[i - 1][j - 1].Assign(ContentCell[i - 1][j - 1 - 1]);
                    }
                }
                if (RowTypes != null)
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        cfg.LengthOfArrCellTypes = RowTypes.GetLength(i);
                        NewContent[i - 1][ColumnN - 1].SetTypeN(RowTypes.GetTypeN(i), cfg);
                    }
                }
                else
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        cfg.LengthOfArrCellTypes = RowTypes.GetLength(i);
                        NewContent[i - 1][ColumnN - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, cfg);
                    }
                }
            }
            else
            {
                NewContent = new DataCell[QColumns + 1][];
                for (int i = 1; i <= QColumns + 1; i++)
                {
                    NewContent[i - 1] = new DataCell[QLines];
                }
                for (int i = 1; i <=  QColumns + 1; i++)
                {
                    for (int j = 1; j <= QLines; j++)
                    {
                        NewContent[i - 1][j - 1] = new DataCell();
                    }
                }
                for (int i = 1; i <= ColumnN; i++)
                {
                    for (int j = 1; j <= QLines; j++)
                    {
                        //NewContent[i - 1][j - 1] = ContentCell[i - 1][j - 1];
                        NewContent[i - 1][j - 1].Assign( ContentCell[i - 1][j - 1]);
                    }
                }
                for (int i = ColumnN+1; i <= QColumns+1; i++)
                {
                    for (int j = 1; j <= QLines; j++)
                    {
                        //NewContent[i - 1][j - 1] = ContentCell[i - 1 - 1][j - 1];
                        NewContent[i - 1][j - 1].Assign(ContentCell[i - 1 - 1][j - 1]);
                    }
                }
                if (RowTypes != null)
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        cfg.LengthOfArrCellTypes = RowTypes.GetLength(i);
                        NewContent[ColumnN - 1][i - 1].SetTypeN(RowTypes.GetTypeN(i), cfg);
                    }
                }
                else
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        cfg.LengthOfArrCellTypes = RowTypes.GetLength(i);
                        NewContent[ColumnN - 1][i - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, cfg);
                    }
                }
            }
            if (TblInf.GetIf_LoCHExists())
            {
                MyLib.AddToVector(ref LineOfColHeader, ref QColumns, new DataCell());
                for (int i = QColumns; i >= ColumnN+1; i--)
                {
                    //LineOfColHeader[i - 1] = LineOfColHeader[i - 1 - 1];
                    LineOfColHeader[i - 1].Assign(LineOfColHeader[i - 1 - 1]);
                }
                if (HeaderType != null)
                {
                    cfg.LengthOfArrCellTypes = HeaderType.GetLength();
                    LineOfColHeader[ColumnN - 1].SetTypeN(HeaderType.GetTypeN(), cfg);
                }
                else
                {
                    cfg.LengthOfArrCellTypes = 2;
                    LineOfColHeader[ColumnN - 1].SetTypeN(TableConsts.DefaultColOfLineHeaderCellTypeN, cfg);
                }
                QColumns--;
            }
            ContentCell = NewContent;
            if (ToWrite)
            {
                TblInf.SetSize(QLines, QColumns + 1);
                if (this.TblInf == null) this.TblInf = TblInf;
            }
        }
        public void InsEmptyColumn_TypesByExisting(int ColumnN, TableInfo TblInfExt = null, bool ToWrite = true)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCellTypeInfo HeaderType = null;
            int QLines = TblInf.GetQLines(), QColumns = TblInf.GetQColumns();
            DataCellTypeInfo[] ContentTypes = new DataCellTypeInfo[QLines];
            for (int i = 1; i <= QLines; i++) ContentTypes[i - 1] = new DataCellTypeInfo(GetCell(i, QColumns, TblInf.GetTableInfo_ConcrRepr()).GetTypeN(), GetCell(i, QColumns, TblInf.GetTableInfo_ConcrRepr()).GetLength());
            if (TblInf.GetIf_LoCHExists()) HeaderType = new DataCellTypeInfo(LineOfColHeader[QColumns - 1].GetTypeN(), LineOfColHeader[QColumns - 1].GetLength());
            InsEmptyColumn(ColumnN, new DataTypeRow(QLines, ContentTypes), HeaderType, TblInf, ToWrite);
        }
        public void InsColumn(int ColumnN, DataCellRowCoHeader row, TableInfo TblInfExt = null, bool ToWrite = true)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int QLines = TblInf.GetQLines(), QColumns = TblInf.GetQColumns();
            InsEmptyColumn_TypesByExisting(ColumnN, TblInfExt, ToWrite);
            QColumns++;
            SetColumn(ColumnN, row, TblInf);
        }
        //
        //
        public void SetCellTypeN(int LineN, int ColN, DataCellTypeInfo TypeInfo, bool PreserveVal=false, TableInfo TblInfExt=null)
        {
            int ErstLineN, ErstColumnN;
            TableCellAccessConfiguration cfg=new TableCellAccessConfiguration();
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            if (TblInf.GetIf_LoCHExists()) ErstLineN = 0; else ErstLineN = 1;
            if (TblInf.GetIf_CoLHExists()) ErstColumnN = 0; else ErstColumnN = 1;
            if (LineN >= ErstLineN && LineN <= TblInf.GetQLines() && ColN >= ErstColumnN && ColN <= TblInf.GetQColumns())
            {
                cfg.PreserveVal=PreserveVal;
                cfg.LengthOfArrCellTypes=TypeInfo.GetLength();
                if (LineN > 0 && ColN > 0)
                {
                    if (TblInf.GetIf_LC_Not_CL())
                    {
                        ContentCell[LineN-1][ColN-1].SetTypeN(TypeInfo.GetTypeN(), cfg);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetTypeN(TypeInfo.GetTypeN(), cfg);
                    }
                }
                else if (LineN > 0 && ColN == 0)
                {
                    if (TblInf.GetIf_CoLHExists()) ColOfLineHeader[LineN - 1].SetTypeN(TypeInfo.GetTypeN(), cfg);
                }
                else if (LineN == 0 && ColN > 0)
                {
                    if (TblInf.GetIf_LoCHExists()) LineOfColHeader[LineN - 1].SetTypeN(TypeInfo.GetTypeN(), cfg);
                }//else corner - nil to set
            }//else not correct Ns
        }//fn
        //
        //
        public void SetLineN(int N, DataCellRow row, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt, true, 2);
            int QColumns = TblInf.GetQColumns();
            int MinQ = row.GetSize();
            if (MinQ > QColumns) MinQ = QColumns;
            if (GetIfLineNExists(N))
            {
                for (int i = 1; i <= MinQ; i++)
                {
                    this.ContentCell[N - 1][i - 1] = row.GetCellN(i);
                }
            }
        }
        public void SetLineN(int N, DataCellRowCoHeader row, TableInfo TblInfExt)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt, true, 2);
            int QColumns = TblInf.GetQColumns();
            int MinQ = row.GetQContentCells();
            if (MinQ> QColumns) MinQ = QColumns;
            if (GetIfLineNExists(N))
            {
                SetLineN(N, row.GetContent());
                if (this.GetIf_HeadersExist()) ColOfLineHeader[N - 1] = row.GetHeader();
            }
        }
        public void SetColumnN(int N, DataCellRow row, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt, true, 2);
            int QLines = TblInf.GetQLines();
            int MinQ = row.GetSize();
            if (MinQ > QLines) MinQ = QLines;
            if (GetIfColumnNExists(N))
            {
                for (int i = 1; i <= MinQ; i++)
                {
                    this.ContentCell[i - 1][N - 1] = row.GetCellN(i);
                }
            }
        }
        public void SetColumnN(int N, DataCellRowCoHeader row, TableInfo TblInfExt)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt, true, 2);
            int QLines = TblInf.GetQLines();
            int MinQ = row.GetQContentCells();
            if (MinQ > QLines) MinQ = QLines;
            if (GetIfColumnNExists(N))
            {
                SetColumnN(N, row.GetContent());
                if (this.GetIf_HeadersExist()) LineOfColHeader[N - 1] = row.GetHeader();
            }
        }
        public void AddItemToList_NameAndValue(string name, DataCell Value, TableInfo TblInfExt=null)
        {
            bool ToWrite=(this.TblInf!=null);
            DataCellRowCoHeader row;
            row = new DataCellRowCoHeader(new DataCell(name), new DataCellRow(Value, 1));
            this.AddLine(row, TblInfExt, ToWrite);
        }
        public void SetListItemN_NameAndValue(int N, string name, DataCell Value, TableInfo TblInfExt=null)
        {
            bool ToWrite=(this.TblInf!=null);
            DataCellRowCoHeader row;
            row = new DataCellRowCoHeader(new DataCell(name), new DataCellRow(Value, 1));
            this.SetLine(N, row, TblInfExt);
        }
        //
        //
        public void SetCellTypeN(int LineN, int ColN, int TypeN, TableInfo TblInfOldExt, TableCellAccessConfiguration cfgExt)
        {
            TableCellAccessConfiguration cfg;
            TableInfo TblInfOld=null;
            bool CellExists;
            if(cfgExt!=null) cfg=cfgExt; else cfg=new TableCellAccessConfiguration();
            if(TblInfOldExt!=null) TblInfOld=TblInfOldExt;
            else if(this.TblInf!=null) TblInfOldExt=this.TblInf;
            else TblInfOld=new TableInfo();
            CellExists = GetIfCellExists(LineN, ColN, TblInfOld);
            if (CellExists)
            {
                if (LineN == 0 && ColN != 0)
                {
                    SetCellTypeN_LineOfColHeader(ColN, TypeN, TblInfOld, cfg);
                }
                else if (ColN == 0 && LineN != 0)
                {
                     SetCellTypeN_ColOfLineHeader(LineN, TypeN, TblInfOld, cfg);
                }
                else
                {
                    if (TblInfOld.GetIf_LC_Not_CL() == true)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetTypeN(TypeN, cfg);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetTypeN(TypeN, cfg);
                    }
                }
            }
        }//fn
        public void SetCellTypeN_LineOfColHeader(int ColN, int TypeN, TableInfo TblInfOldExt, TableCellAccessConfiguration cfgExt)
        {
            TableCellAccessConfiguration cfg;
            TableInfo TblInfOld=null;
            bool CellExists;
            if (cfgExt != null) cfg = cfgExt; else cfg = new TableCellAccessConfiguration();
            if (TblInfOldExt != null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOldExt = this.TblInf;
            else TblInfOld = new TableInfo();
            CellExists = GetIfCellExists(0, ColN, TblInfOld);
            if (CellExists)
            {
                if (ColN != 0)
                {
                    LineOfColHeader[ColN-1].SetTypeN(TypeN, cfg);
                }
            }
        }//fn
        public void SetCellTypeN_ColOfLineHeader(int LineN, int TypeN, TableInfo TblInfOldExt, TableCellAccessConfiguration cfgExt)
        {
            TableCellAccessConfiguration cfg;
            TableInfo TblInfOld=null;
            bool CellExists;
            if (cfgExt != null) cfg = cfgExt; else cfg = new TableCellAccessConfiguration();
            if (TblInfOldExt != null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOldExt = this.TblInf;
            else TblInfOld = new TableInfo();
            CellExists = GetIfCellExists(LineN, 0, TblInfOld);
            if (CellExists)
            {
                if (LineN != 0)
                {
                    ColOfLineHeader[LineN - 1].SetTypeN(TypeN, cfg);
                }
            }
        }//fn
        //staret new SetLine
        public void SetLine(int N, DataCell[] LineCell, DataCell Header, TableInfo TblInfOldExt, TableSettingConfiguration cfgExt)
        {
            TableInfo TblInfOld;
            TableSettingConfiguration cfg;
            int QLines=1, QColumns=1;
            bool LC_Not_CL = true, CoLHExists = true, LoCHExists = true;
            //
            if (TblInfOldExt != null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = this.TblInf;
            else TblInfOld = new TableInfo();
            if (cfgExt != null) cfg = cfgExt; else cfg = new TableSettingConfiguration();
            //
            TblInfOld.GetMainInf(ref LC_Not_CL, ref CoLHExists, ref LoCHExists, ref QLines, ref QColumns);
            //
            if (LC_Not_CL)
            {
                for(int i=1; i<=QColumns; i++){
                    if(LineCell!=null) ContentCell[N-1][i-1]=LineCell[i-1];
                }
            }
            else
            {
                for(int i=1; i<=QColumns; i++){
                    if(LineCell!=null) ContentCell[i-1][N-1]=LineCell[i-1];
                }
            }
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                if(Header!=null) ColOfLineHeader[N - 1] = Header;
            }
        }//fn
        public void SetColumn(int N, DataCell[] ColCell, DataCell Header, TableInfo TblInfOldExt, TableSettingConfiguration cfgExt)
        {
            TableInfo TblInfOld;
            TableSettingConfiguration cfg;
            int QLines = 1, QColumns = 1;
            bool LC_Not_CL = true, CoLHExists = true, LoCHExists = true;
            //
            if (TblInfOldExt != null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = this.TblInf;
            else TblInfOld = new TableInfo();
            if (cfgExt != null) cfg = cfgExt; else cfg = new TableSettingConfiguration();
            //
            TblInfOld.GetMainInf(ref LC_Not_CL, ref CoLHExists, ref LoCHExists, ref QLines, ref QColumns);
            //
            if (LC_Not_CL)
            {
                for (int i = 1; i <= QLines; i++)
                {
                    if (ColCell != null) ContentCell[i - 1][N - 1] = ColCell[i - 1];
                }
            }
            else
            {
                for (int i = 1; i <= QColumns; i++)
                {
                    if (ColCell != null) ContentCell[N - 1][i - 1] = ColCell[i - 1];
                }
            }
            if (TblInfOld.GetIf_LoCHExists() == true)
            {
                if (Header != null) LineOfColHeader[N - 1] = Header;
            }
        }//fn
        //end new SetLine and SetColumn
        public void SetLine(int N, int[] TypesNewExt, int LHtypeN, string LineHeaderName, string[] Content, int PreserveVals_No0Yes1)
        {
            TableCellAccessConfiguration CellCfg = new TableCellAccessConfiguration();
            int QLines = GetQLines(), QColumns = GetQColumns(), HeaderTypeN, ContentPrevTypeN;
            int[] OldTypes, TypesNew = new int[QColumns];
            OldTypes = new int[QColumns];
            TypesNew = new int[QColumns];
            HeaderTypeN = GetTypeN(QLines, 0);
            CellCfg.PreserveVal = MyLib.IntToBool(PreserveVals_No0Yes1);
            for (int i = 1; i <= QColumns; i++) { OldTypes[i - 1] = GetTypeN(N, i); }
            if (TypesNewExt == null)
            {
                for (int i = 1; i <= QColumns; i++) { TypesNew[i - 1] = TableConsts.DefaultAnyCellTypeN; }
            }
            else
            {
                for (int i = 1; i <= QColumns; i++) { TypesNew[i - 1] = TypesNewExt[i - 1]; }
            }
            for (int i = 1; i <= QColumns; i++)
            {
                SetCellTypeN(N, i, TypesNew[i - 1], null, CellCfg);
            }
            if (GetIfColOfLineHeaderExists() == true)
            {

                SetCellTypeN_ColOfLineHeader(N, LHtypeN, null, CellCfg);
                SetByValString_ColOfLineHeader(N, LineHeaderName);
                //SetValAndTypeString_ColOfLineHeader(N, LineHeaderName);
            }
            for (int i = 1; i <= QColumns; i++)
            {
                SetCellTypeN(LHtypeN, i, TypesNew[i - 1], null, CellCfg);
                SetByValString(N, i, Content[i - 1]);
                //SetValAndTypeString(N, i, Content[i - 1]);
            }
        }
        //
        public void SetLine(int N, DataCell[] LineContent, DataCell LineHeader, int[] typs, int HTyp, int[] lens, int hlen, int Prsrv)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            TableCellAccessConfiguration CaptionCellCfg = null, cfg=new TableCellAccessConfiguration();
            if(GetIfColOfLineHeaderExists()==true){
                CaptionCellCfg = new TableCellAccessConfiguration();
                CaptionCellCfg.PreserveVal = MyLib.IntToBool(Prsrv);
                CaptionCellCfg.LengthOfArrCellTypes = hlen;
            }
            TableCellAccessConfiguration[] ContentCellCfg = new TableCellAccessConfiguration[QColumns];
            for(int i=1; i<=QColumns; i++){
                ContentCellCfg[i-1]=new TableCellAccessConfiguration();
                ContentCellCfg[i-1].PreserveVal=MyLib.IntToBool(Prsrv);
                if(lens!=null)ContentCellCfg[i-1].SetLength(lens[i-1]);
            }
            if (N >= 1 && N <= QLines)
            {
                if (LineContent == null)
                {
                    SetLine(N, typs, HTyp, "", null, Prsrv);
                }
                else
                {
                    if (this.GetIf_LC_Matrix_Not_CL_DB() == true)
                    {
                        for (int i = 1; i <= QColumns; i++)
                        {
                            ContentCell[N - 1][i - 1] = LineContent[i];
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= QColumns; i++)
                        {
                            ContentCell[i - 1][N - 1] = LineContent[i];
                        }
                    }
                }//if LC == null or not
                if (this.GetIfColOfLineHeaderExists() == true)
                {
                    if (LineHeader != null)
                    {
                        this.ColOfLineHeader[N - 1] = LineHeader;
                    }
                    else
                    {
                        SetCellTypeN_ColOfLineHeader(N - 1, HTyp, null, CaptionCellCfg);
                    }
                }
            }
        }
        public void SetLine(int N, DataCell[] LineContent, DataCell LineHeader)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            int[] typs = null;
            TableCellAccessConfiguration CaptionCellCfg = null, cfg=new TableCellAccessConfiguration();
            if(GetIfColOfLineHeaderExists()==true){
                CaptionCellCfg = new TableCellAccessConfiguration();
                //CaptionCellCfg.PreserveVal = MyLib.IntToBool(Prsrv);
                //CaptionCellCfg.LengthOfArrCellTypes = hlen;
            }
            TableCellAccessConfiguration[] ContentCellCfg = new TableCellAccessConfiguration[QColumns];
            for(int i=1; i<=QColumns; i++){
                ContentCellCfg[i-1]=new TableCellAccessConfiguration();
                //ContentCellCfg[i-1].PreserveVal=MyLib.IntToBool(Prsrv);
                //if(lens!=null)ContentCellCfg[i-1].SetLength(lens[i-1]);
            }
            if (N >= 1 && N <= QLines)
            {
                if (LineContent == null)
                {
                    typs = new int[QColumns];
                    for (int i = 1; i <= QColumns; i++) typs[i - 1] = TableConsts.DefaultContentCellTypeN;
                    SetLine(N, typs, TableConsts.DefaultColOfLineHeaderCellTypeN, "", null, 1);
                }
                else
                {
                    if (this.GetIf_LC_Matrix_Not_CL_DB() == true)
                    {
                        for (int i = 1; i <= QColumns; i++)
                        {
                            ContentCell[N - 1][i - 1] = LineContent[i];
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= QColumns; i++)
                        {
                            ContentCell[i - 1][N - 1] = LineContent[i];
                        }
                    }
                }//if LC == null or not
                if (this.GetIfColOfLineHeaderExists() == true)
                {
                    if (LineHeader != null)
                    {
                        this.ColOfLineHeader[N - 1] = LineHeader;
                    }
                    else
                    {
                        SetCellTypeN_ColOfLineHeader(N - 1, TableConsts.DefaultColOfLineHeaderCellTypeN, null, CaptionCellCfg);
                    }
                }
            }
        }
        public void SetLine(int N, int[] typs, int HTyp, int[] lens, int hlen, int Prsrv)
        {
            TableCellAccessConfiguration CaptionCellCfg=null;
            TableCellAccessConfiguration[] ContentCellCfg = null;
            int QLines = GetQLines(), QColumns = GetQColumns();
            if(this.GetIfColOfLineHeaderExists()==true) CaptionCellCfg= new TableCellAccessConfiguration();
            ContentCellCfg = new TableCellAccessConfiguration[QColumns];
            for (int i = 1; i <= QColumns; i++)
            {
                ContentCellCfg[i - 1] = new TableCellAccessConfiguration();
                if (lens != null)  ContentCellCfg[i - 1].SetLength(lens[i - 1]);
                ContentCellCfg[i - 1].PreserveVal=MyLib.IntToBool(Prsrv);
            }
            if (N >= 1 && N <= QLines)
            {
                if (typs == null)
                {
                    typs = new int[QColumns];
                    for (int i = 1; i <= QColumns; i++) typs[i - 1] = TableConsts.DefaultContentCellTypeN;
                }
                if (lens == null)
                {
                    lens = new int[QColumns];
                    for (int i = 1; i <= QColumns; i++) lens[i - 1] = 1;
                }
                CaptionCellCfg.LengthOfArrCellTypes = hlen;
                for (int i = 1; i <= QColumns; i++) SetCellTypeN(N, i, typs[i - 1], null, ContentCellCfg[i - 1]);
                //
                if (this.GetIfLineOfColHeaderExists() == true)
                {
                    SetCellTypeN_ColOfLineHeader(N - 1, HTyp, null, CaptionCellCfg);
                }
            }
        }
        //
        public void SetColumn(int N, DataCell[] ColumnContent, DataCell ColumnHeader, int[] typs, int HTyp, int[] lens, int hlen, int Prsrv)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            TableCellAccessConfiguration CaptionCellCfg = null;
            if (GetIfLineOfColHeaderExists() == true)
            {
                CaptionCellCfg = new TableCellAccessConfiguration();
                CaptionCellCfg.PreserveVal = MyLib.IntToBool(Prsrv);
                CaptionCellCfg.LengthOfArrCellTypes = hlen;
            }
            TableCellAccessConfiguration[] ContentCellCfg = new TableCellAccessConfiguration[QLines];
            for (int i = 1; i <= QLines; i++)
            {
                ContentCellCfg[i-1] = new TableCellAccessConfiguration();
                ContentCellCfg[i - 1].PreserveVal = MyLib.IntToBool(Prsrv);
                if (lens != null) ContentCellCfg[i - 1].LengthOfArrCellTypes = lens[i - 1];
            }
            if (N >= 1 && N <= QLines)
            {
                if (ColumnContent == null)
                {
                    SetLine(N, typs, HTyp, "", null, Prsrv);
                }
                else
                {
                    if (this.GetIf_LC_Matrix_Not_CL_DB() == true)
                    {
                        for (int i = 1; i <= QColumns; i++)
                        {
                            ContentCell[N - 1][i - 1] = ColumnContent[i];
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= QColumns; i++)
                        {
                            ContentCell[i - 1][N - 1] = ColumnContent[i];
                        }
                    }
                }//if LC == null or not
                if (this.GetIfLineOfColHeaderExists() == true)
                {
                    if (ColumnHeader != null)
                    {
                        this.LineOfColHeader[N - 1] = ColumnHeader;
                    }
                    else
                    {
                        SetCellTypeN_LineOfColHeader(N - 1, HTyp, null, CaptionCellCfg);
                    }
                }
            }
        }
        public void SetColumn(int N, DataCell[] ColumnContent, DataCell ColumnHeader)
        {
            int[] typs = null, lens = null;
            int HTyp = TableConsts.DefaultContentCellTypeN, hlen = 1, Prsrv = 1;
            TableCellAccessConfiguration CaptionCellCfg = new TableCellAccessConfiguration();
            CaptionCellCfg.LengthOfArrCellTypes = hlen;
            CaptionCellCfg.PreserveVal = MyLib.IntToBool(Prsrv);
            int QLines = GetQLines(), QColumns = GetQColumns();
            if (N >= 1 && N <= QColumns)
            {
                if (ColumnContent == null)
                {
                    SetColumn(N, typs, HTyp, lens, hlen, Prsrv);
                }
                else
                {
                    if (this.GetIf_LC_Matrix_Not_CL_DB() == true)
                    {
                        for (int i = 1; i <= QColumns; i++)
                        {
                            ContentCell[N - 1][i - 1] = ColumnContent[i];
                        }
                    }
                    else
                    {
                        for (int i = 1; i <= QColumns; i++)
                        {
                            ContentCell[i - 1][N - 1] = ColumnContent[i];
                        }
                    }
                }//if LC == null or not
                if (this.GetIfLineOfColHeaderExists() == true)
                {
                    if (ColumnHeader != null)
                    {
                        this.LineOfColHeader[N - 1] = ColumnHeader;
                    }
                    else
                    {
                        SetCellTypeN_LineOfColHeader(N - 1, HTyp, null, CaptionCellCfg);
                    }
                }
            }
        }
        public void SetColumn(int N, int[] typs, int HTyp, int[] lens, int hlen, int Prsrv)
        {
            TableCellAccessConfiguration CaptionCellCfg = new TableCellAccessConfiguration();
            TableCellAccessConfiguration[] ContentCellCfg;
            int QLines = GetQLines(), QColumns = GetQColumns();
            CaptionCellCfg.LengthOfArrCellTypes = hlen;
            CaptionCellCfg.PreserveVal = MyLib.IntToBool(Prsrv);
            ContentCellCfg = new TableCellAccessConfiguration[QLines];
            for (int i = 1; i <= QLines; i++)
            {
                ContentCellCfg[i - 1] = new TableCellAccessConfiguration();
                if (lens != null) ContentCellCfg[i - 1].LengthOfArrCellTypes = lens[i - 1];
                ContentCellCfg[i - 1].PreserveVal = MyLib.IntToBool(Prsrv);
            }
            if (N >= 1 && N <= QLines)
            {
                if (typs == null)
                {
                    typs = new int[QLines];
                    for (int i = 1; i <= QLines; i++) typs[i - 1] = TableConsts.DefaultContentCellTypeN;
                }
                if (lens == null)
                {
                    lens = new int[QLines];
                    for (int i = 1; i <= QLines; i++) lens[i - 1] = 1;
                }
                for (int i = 1; i <= QLines; i++) SetCellTypeN(i, N, typs[i - 1], null, ContentCellCfg[i - 1]);
                //
                if (this.GetIfLineOfColHeaderExists() == true)
                {
                    SetCellTypeN_LineOfColHeader(N - 1, HTyp, null, CaptionCellCfg);
                }
            }
        }
        //
        public void SetLine_SnglType(int N, string LineHeaderName, string[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeString_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeString(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, double LineHeaderName, string[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeDouble_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeString(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, float LineHeaderName, string[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeFloat_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeString(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, int LineHeaderName, string[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeInt_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeString(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, bool LineHeaderName, string[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeBool_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeString(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, string LineHeaderName, double[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            if (this.GetIfColOfLineHeaderExists() == true && LineHeaderName != null)
            {
                SetValAndTypeString_ColOfLineHeader(N, LineHeaderName);
            }
            for (int i = 1; i <= QColumns; i++) {
                SetValAndTypeDouble(N, i, Content[i - 1]);
            }
        }
        public void SetLine_SnglType(int N, double LineHeaderName, double[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeDouble_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeDouble(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, float LineHeaderName, double[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeFloat_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeDouble(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, int LineHeaderName, double[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeInt_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeDouble(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, bool LineHeaderName, double[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeBool_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeDouble(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, string LineHeaderName, float[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeString_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeFloat(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, double LineHeaderName, float[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeDouble_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeFloat(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, float LineHeaderName, float[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeFloat_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeFloat(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, int LineHeaderName, float[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeInt_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeFloat(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, bool LineHeaderName, float[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeBool_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeFloat(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, string LineHeaderName, int[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeString_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeInt(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, double LineHeaderName, int[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeDouble_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeInt(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, float LineHeaderName, int[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeFloat_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeInt(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, int LineHeaderName, int[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeInt_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeInt(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, bool LineHeaderName, int[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeBool_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeInt(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, string LineHeaderName, bool[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeString_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeBool(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, double LineHeaderName, bool[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeDouble_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeBool(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, float LineHeaderName, bool[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeFloat_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeBool(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, int LineHeaderName, bool[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeInt_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeBool(N, i, Content[i - 1]); }
        }
        public void SetLine_SnglType(int N, bool LineHeaderName, bool[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeBool_ColOfLineHeader(N, LineHeaderName);
            for (int i = 1; i <= QColumns; i++) { SetValAndTypeBool(N, i, Content[i - 1]); }
        }
        //
        public void SetColumn_SnglType(int N, string ColHeaderName, string[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeString_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeString(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, double ColHeaderName, string[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeDouble_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeString(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, float ColHeaderName, string[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeFloat_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeString(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, int ColHeaderName, string[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeInt_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeString(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, bool ColHeaderName, string[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeBool_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeString(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, string ColHeaderName, double[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeString_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeDouble(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, double ColHeaderName, double[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeDouble_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeDouble(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, float ColHeaderName, double[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeFloat_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeDouble(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, int ColHeaderName, double[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeInt_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeDouble(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, bool ColHeaderName, double[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeBool_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeDouble(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, string ColHeaderName, float[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeString_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeFloat(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, double ColHeaderName, float[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeDouble_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeFloat(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, float ColHeaderName, float[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeFloat_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeFloat(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, int ColHeaderName, float[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeInt_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeFloat(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, bool ColHeaderName, float[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeBool_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeFloat(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, string ColHeaderName, int[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeString_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeInt(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, double ColHeaderName, int[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeDouble_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeInt(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, float ColHeaderName, int[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeFloat_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeInt(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, int ColHeaderName, int[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeInt_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeInt(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, bool ColHeaderName, int[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeBool_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeInt(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, string ColHeaderName, bool[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeString_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeBool(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, double ColHeaderName, bool[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeDouble_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeBool(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, float ColHeaderName, bool[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeFloat_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeBool(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, int ColHeaderName, bool[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeInt_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeBool(i, N, Content[i - 1]); }
        }
        public void SetColumn_SnglType(int N, bool ColHeaderName, bool[] Content)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            SetValAndTypeBool_LineOfColHeader(N, ColHeaderName);
            for (int i = 1; i <= QLines; i++) { SetValAndTypeBool(i, N, Content[i - 1]); }
        }
        //
        public void SetLineN_TypesAsOfN(int NWhichToSet, int NFromToSet)
        {
            int QLines, QColumns, LHTypeN;
            int[] types;
            QColumns = GetQColumns(); QLines = GetQLines();
            if (NWhichToSet >= 1 && NWhichToSet <= QLines)
            {
                types = new int[QColumns];
                if (NFromToSet >= 1 && NFromToSet <= QLines)
                {
                    LHTypeN = GetTypeN_ColOfLineHeader(NFromToSet);
                    for (int i = 1; i <= QColumns; i++)
                    {
                        types[i - 1] = GetTypeN(NFromToSet, i);
                    }
                }
                else
                {
                    LHTypeN = TableConsts.DefaultColOfLineHeaderCellTypeN;
                    for (int i = 1; i <= QColumns; i++)
                    {
                        types[i - 1] = TableConsts.DefaultContentCellTypeN;
                    }
                }
                SetLine(NWhichToSet, types, LHTypeN, "", null, 1);
            }
        }//fn
        public void SetColumnN_TypesAsOfN(int NWhichToSet, int NFromToSet)
        {
            int QLines, QColumns, CHTypeN, hlen = 1, PrsrvVals = 1;
            int[] types, lens = null;
            QColumns = GetQColumns(); QLines = GetQLines();
            if (NWhichToSet >= 1 && NWhichToSet <= QColumns)
            {
                types = new int[QColumns];
                if (NFromToSet >= 1 && NFromToSet <= QColumns)
                {
                    CHTypeN = GetTypeN_LineOfColHeader(NFromToSet);
                    for (int i = 1; i <= QColumns; i++)
                    {
                        types[i - 1] = GetTypeN(NFromToSet, i);
                    }
                }
                else
                {
                    CHTypeN = TableConsts.DefaultLineOfColHeaderCellTypeN;
                    for (int i = 1; i <= QColumns; i++)
                    {
                        types[i - 1] = TableConsts.DefaultContentCellTypeN;
                    }
                }
                SetColumn(NWhichToSet, types, CHTypeN, lens, hlen, PrsrvVals);
            }
        }//fn
        //
        public void AssignBy(int LineNTo, int ColNTo, TDataCell CellFrom, TableInfo TblInfExt)
        {
            TableInfo TblInf;
            if (TblInfExt != null) TblInf = TblInfExt;
            else if (this.TblInf != null) TblInf = this.TblInf;
            else TblInf = new TableInfo();
            if(GetIfCellExists(LineNTo, ColNTo, TblInf)){
               if (LineNTo == 0 && ColNTo != 0)
               {
                   LineOfColHeader[ColNTo-1].AssignBy(CellFrom);
               }
               else if (ColNTo == 0 && LineNTo != 0)
               {
                   ColOfLineHeader[LineNTo - 1].AssignBy(CellFrom);
               }
               else
               {
                   if (GetIf_LC_Matrix_Not_CL_DB() == true)
                   {
                       ContentCell[LineNTo - 1][ColNTo - 1].AssignBy(CellFrom);
                   }
                   else
                   {
                       ContentCell[ColNTo - 1][LineNTo - 1].AssignBy(CellFrom);
                   }
               }
           }
        }
        //
        //mark4
        public void GetMain(ref int QLines, ref int QColumns, ref DataCell[][] Content, ref DataCell[] LoCH, ref DataCell[] CoLH, ref int LC1CL0)
        {
            QLines = GetQLines();
            QColumns = GetQColumns();
            Content = ContentCell;
            LoCH = LineOfColHeader;
            CoLH = ColOfLineHeader;
            LC1CL0 = MyLib.BoolToInt(GetIf_LC_Matrix_Not_CL_DB());
        }
        public void SetMain(TableInfo TblInfNewExt, TableInfo TblInfOldExt, TableCellsTypeMap TypeMapExt, TableSettingConfiguration CfgExt)
        {
            TableCellsTypeMap TypeMap;
            //int[][] CntTypesNExt, int[]LoCHTypesNExt, int[] CoLHTypesNExt,
            int QLines=1, QColumns=1, QLines_Old=1, QColumns_Old=1, QLinesMin, QColumnsMin;
            bool LC_not_CL = true, LoCHExists = true, CoLHExists = true;
            bool LC_not_CL_Old = true, LoCHExists_Old = true, CoLHExists_Old = true;
            int TypeN;
            DataCell[][] ContentOld=null;
            DataCell[] ColOfLineHeaderOld=null, LineOfColHeaderOld = null;
            TableInfo TblInfNew, TblInfOld;
            TableSettingConfiguration Cfg;
            if (TblInfOldExt != null) TblInfOld = TblInfOldExt;
            else if (TblInf != null) TblInfOld = TblInf;
            else TblInfOld = new TableInfo();
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            if (TblInfNewExt != null) TblInfNew = TblInfNewExt;
            else TblInfNew = new TableInfo();
            if(TypeMapExt!=null)TypeMap=TypeMapExt; else TypeMap=new TableCellsTypeMap(TblInfNew);
            TblInfNew.GetMainInf(ref LC_not_CL, ref CoLHExists, ref LoCHExists, ref QLines, ref QColumns);
            TblInfOld.GetMainInf(ref LC_not_CL_Old, ref CoLHExists_Old, ref LoCHExists_Old, ref QLines_Old, ref QColumns_Old);
            if (TypeMapExt != null) TypeMap = TypeMapExt; else TypeMap = new TableCellsTypeMap(TblInfNew);
            if(QLines<=QLines_Old) QLinesMin=QLines; else QLinesMin=QLines_Old;
            if(QColumns<=QColumns_Old) QColumnsMin=QColumns; else QColumnsMin=QColumns_Old;
            //save content
            if (Cfg.CellCfg.PreserveVal)
            {
                if (LC_not_CL_Old)
                {
                    ContentOld = new DataCell[QLines_Old][];
                    for(int i=1; i<=QLines_Old; i++){
                        ContentOld[i-1]=new DataCell[QColumns_Old];
                    }
                    for (int i = 1; i <= QLines_Old; i++)
                    {
                        for (int j = 1; j <= QColumns_Old; j++)
                        {
                            ContentOld[i - 1][j - 1]=ContentCell[i - 1][j - 1];
                        }
                    }
                }
                else
                {
                    ContentOld = new DataCell[QColumns_Old][];
                    for (int i = 1; i <= QColumns_Old; i++)
                    {
                        ContentOld[i - 1] = new DataCell[QLines_Old];
                    }
                    for (int i = 1; i <= QColumns_Old; i++)
                    {
                        for (int j = 1; j <= QLines_Old; j++)
                        {
                            ContentOld[i - 1][j - 1] = ContentCell[i - 1][j - 1];
                        }
                    }
                }
            }//if preserve
            //re-create content
            if (LC_not_CL)
            {
                ContentCell = new DataCell[QLines][];
                for (int i = 1; i <= QLines; i++)
                {
                    ContentCell[i - 1] = new DataCell[QColumns];
                    for (int j = 1; j <= QColumns; j++)
                    {
                        //if (CntTypesNExt != null) TypeN = CntTypesNExt[i - 1][j - 1];
                        //else TypeN = TableConsts.DefaultContentCellTypeN;
                        //ContentCell[i - 1][j - 1] = new DataCell(TypeN, Cfg.CellCfg.LengthOfArrCellTypes);
                        ContentCell[i - 1][j - 1] = new DataCell(TypeMap.GetCellTypeN(i, j), TypeMap.GetCellLength(i,j));
                    }
                }
            }
            else //!LC_not_CL
            {
                ContentCell = new DataCell[QColumns][];
                for (int i = 1; i <= QColumns; i++)
                {
                    ContentCell[i - 1] = new DataCell[QLines];
                    for (int j = 1; j <= QLines; j++)
                    {
                        //if (CntTypesNExt != null) TypeN = CntTypesNExt[i - 1][j - 1];
                        //else TypeN = TableConsts.DefaultContentCellTypeN;
                        //ContentCell[i - 1][j - 1]=new DataCell(TypeN, Cfg.CellCfg.LengthOfArrCellTypes);
                        ContentCell[i - 1][j - 1] = new DataCell(TypeMap.GetCellTypeN(j, i), TypeMap.GetCellLength(j,i));
                    }
                }
            }
            //re-assign content
            if (Cfg.CellCfg.PreserveVal)
            {
                if (LC_not_CL)
                {
                    if (LC_not_CL_Old)
                    {
                        for (int i = 1; i <= QLinesMin; i++)
                        {
                            for (int j = 1; j <= QColumnsMin; j++)
                            {
                                ContentCell[i - 1][j - 1].AssignBy(ContentOld[i - 1][j - 1]);
                            }
                        }
                    }
                    else //!LC_not_CL_Old
                    {
                        for (int i = 1; i <= QLinesMin; i++)
                        {
                            for (int j = 1; j <= QColumnsMin; j++)
                            {
                                ContentCell[i - 1][j - 1].AssignBy(ContentOld[j - 1][i - 1]);
                            }
                        }
                    }
                } // ! LC_not_CL
                else
                {
                    if (LC_not_CL_Old)
                    {
                        for (int i = 1; i <= QColumnsMin; i++)
                        {
                            for (int j = 1; j <= QLinesMin; j++)
                            {
                                ContentCell[i - 1][j - 1].AssignBy(ContentOld[i - 1][j - 1]);
                            }
                        }
                    }
                    else //!LC_not_CL_Old
                    {
                        for (int i = 1; i <= QColumnsMin; i++)
                        {
                            for (int j = 1; j <= QLinesMin; j++)
                            {
                                ContentCell[i - 1][j - 1].AssignBy(ContentOld[j - 1][i - 1]);
                            }
                        }
                    }
                }
            }
            //content - end
            //ColH
            //save ColH
            if (Cfg.CellCfg.PreserveVal && CoLHExists_Old && CoLHExists)
            {
                ColOfLineHeaderOld = new DataCell[QLines_Old];
                for (int i = 1; i < QLines_Old; i++) ColOfLineHeaderOld[i - 1]=ColOfLineHeader[i - 1];
            }
            //create ColH
            //if (CoLHExists && (!CoLHExists_Old || QLines!=QLines_Old))
            if (CoLHExists){ //mayb other quantity or other types
                this.ColOfLineHeader=new DataCell[QLines];
                for(int i=1; i<=QLines;i++) this.ColOfLineHeader[i - 1] = new DataCell(TypeMap.GetCellTypeN_ColOfLineHeader(i), TypeMap.GetCellLength_ColOfLineHeader(i));
            }
            /*else
            {
                for(int i=1; i<=QLines;i++){
                    this.ColOfLineHeader[i - 1].SetTypeN(TypeMap.CoLHLengths[i - 1], 
                }
            }*/
            //re-assign content
            if (CoLHExists_Old && Cfg.CellCfg.PreserveVal) //if need to preserve et exists qid to preserve
            {
                for(int i=1; i<=QLinesMin; i++){
                    this.ColOfLineHeader[i - 1] = new DataCell(TypeMap.GetCellTypeN_ColOfLineHeader(i), TypeMap.GetCellLength_ColOfLineHeader(i));
                }
            }
            //CoLH end
            //LoCH
            //save LoCH
            if (Cfg.CellCfg.PreserveVal && LoCHExists_Old && LoCHExists)
            {
                LineOfColHeaderOld = new DataCell[QLines_Old];
                for (int i = 1; i < QColumns_Old; i++) LineOfColHeaderOld[i - 1] = LineOfColHeader[i - 1];
            }
            //re-create LoCH
            if(LoCHExists){
                //in C++ hin ms'b if NULL del[]
                LineOfColHeader = new DataCell[QColumns];
                for(int i=1; i<=QColumns; i++) LineOfColHeader[i-1]=new DataCell(TypeMap.GetCellTypeN_LineOfColHeader(i), TypeMap.GetCellLength_LineOfColHeader(i));
            }
            //re-assign LoCH
            if(LoCHExists && LoCHExists_Old && Cfg.CellCfg.PreserveVal){
                //in C++ hin ms'b if NULL del[]
                LineOfColHeader = new DataCell[QColumns];
                for(int i=1; i<=QColumns; i++) LineOfColHeader[i-1]=new DataCell(TypeMap.GetCellTypeN_LineOfColHeader(i), TypeMap.GetCellLength_LineOfColHeader(i));
            }
        }
        /*
       //parts of SetMain refused    
       //LoCH end
           
           if (LoCHExists)
           {
               if (LoCHExists_Old)
               {
                   //In C++ there should be: delete[] old CoLH, hin - NOp;
                   if (QLines != QLines_Old) this.LineOfColHeader = new DataCell[QLines];
                   for (int i = 1; i <= QLines; i++)
                   {
                       if (LoCHTypesNExt != null) TypeN = LoCHTypesNExt[i - 1]; else TypeN = TableConsts.DefaultLineOfColHeaderCellTypeN;
                       //his.ColOfLineHeader[i - 1].SetTypeN(TypeN, Cfg.CellCfg);
                       this.LineOfColHeader[i - 1] = new DataCell(TypeN, Cfg.CellCfg.LengthOfArrCellTypes);
                   }
               }
               else
               {
                   if (QLines != QLines_Old) this.LineOfColHeader = new DataCell[QLines];
                   for (int i = 1; i <= QLines; i++)
                   {
                       if (LoCHTypesNExt != null) TypeN = LoCHTypesNExt[i - 1]; else TypeN = TableConsts.DefaultLineOfColHeaderCellTypeN;
                       //this.ColOfLineHeader[i - 1].SetTypeN(TypeN, Cfg.CellCfg);
                       this.LineOfColHeader[i - 1] = new DataCell(TypeN, Cfg.CellCfg.LengthOfArrCellTypes);
                   }
               }
           }
           else
           {
               if (LoCHExists_Old)
               {
                   //In C++ there should be: delete[] old CoLH, hin - NOp;
               }
               else
               {
                   //NOp;
               }
           }
           //re-assign LoCH
           if (Cfg.CellCfg.PreserveVal && LoCHExists_Old && LoCHExists)
           {
               for (int i = 1; i < QLinesMin; i++) LineOfColHeader[i - 1].AssignBy(LineOfColHeaderOld[i - 1]);
           }
           //LoCH end
         //}//fn
        */
       public void SetMain(bool LC_not_CL, bool CoLHExists, bool LoCHExists, int QLines, int QColumns, int[][] CntTypeNExt, int[] LoCHTypeNExt, int[] CoLHTypeNExt, TableSettingConfiguration CfgExt)
        {
            TableInfo TblInf=new TableInfo(LC_not_CL, CoLHExists, LoCHExists, QLines, QColumns);
            TableSettingConfiguration cfg=new TableSettingConfiguration();
            TableCellsTypeMap TypeMap = new TableCellsTypeMap();
            DataCellTypeInfo[] TypeCntRow, TypeCoLHRow, TypeLoCHRow;
            TypeCntRow=new DataCellTypeInfo[QLines];
            TypeCoLHRow=new DataCellTypeInfo[QLines];
            TypeLoCHRow=new DataCellTypeInfo[QColumns];
            cfg.SetValsPreserve_No();
            for (int i = 1; i <= QLines; i++){
                for (int j = 1; j <= QColumns; j++){
                    //TypeMap.SetLine(i, TblInf, 
                }
            }
            SetMain(TblInf, null, TypeMap, cfg);
        }
        //
        public void SetColOfLineHeader(DataCell[]ColOfLineHeader, TableInfo TblInfNowExt=null, int Q=0)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfNowExt);
            int QExistingLines = TblInf.GetQLines(), MinQ=0;
            if (Q == 0 || Q <= 0 || Q >= MyLib.MaxInt) Q = QExistingLines;
            else
            {
                if (Q < QExistingLines) MinQ = Q; else MinQ = QExistingLines;
            }
            if (this.ColOfLineHeader == null)
            {
                this.ColOfLineHeader = new DataCell[QExistingLines];
                if (this.TblInf != null && this.TblInf.Str != null) this.TblInf.Str.ColOfLineHeaderExists = true;
            }
            for (int i = 1; i <= MinQ; i++)
            {
                this.ColOfLineHeader[i - 1] = ColOfLineHeader[i - 1];
            }
        }
        public void SetLineOfColHeader(DataCell[] LineOfColHeader, TableInfo TblInfNowExt = null, int Q = 0)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfNowExt);
            int QExistingColumns = TblInf.GetQColumns(), MinQ = 0;
            if (Q == 0 || Q <= 0 || Q >= MyLib.MaxInt) Q = QExistingColumns;
            else
            {
                if (Q < QExistingColumns) MinQ = Q; else MinQ = QExistingColumns;
            }
            if (this.LineOfColHeader == null)
            {
                this.LineOfColHeader = new DataCell[QExistingColumns];
                if (this.TblInf != null && this.TblInf.Str != null) this.TblInf.Str.LineOfColHeaderExists = true;
            }
            for (int i = 1; i <= MinQ; i++)
            {
                this.LineOfColHeader[i - 1] = LineOfColHeader[i - 1];
            }
        }
        public void SetColOfLineHeader(DataCellRow ColOfLineHeader, TableInfo TblInfNowExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfNowExt);
            int QExistingLines = TblInf.GetQLines(), MinQ = 0, Q = ColOfLineHeader.GetSize();
            if (Q == 0 || Q <= 0 || Q >= MyLib.MaxInt) Q = QExistingLines;
            else
            {
                if (Q < QExistingLines) MinQ = Q; else MinQ = QExistingLines;
            }
            if (this.ColOfLineHeader == null)
            {
                this.ColOfLineHeader = new DataCell[QExistingLines];
                if (this.TblInf != null && this.TblInf.Str != null) this.TblInf.Str.ColOfLineHeaderExists = true;
            }
            for (int i = 1; i <= MinQ; i++)
            {
                this.ColOfLineHeader[i - 1] = ColOfLineHeader.GetCellN(i);
            }
        }
        public void SetLineOfColHeader(DataCellRow LineOfColHeader, TableInfo TblInfNowExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfNowExt);
            int QExistingColumns = TblInf.GetQColumns(), MinQ = 0, Q = LineOfColHeader.GetSize();
            if (Q == 0 || Q <= 0 || Q >= MyLib.MaxInt) Q = QExistingColumns;
            else
            {
                if (Q < QExistingColumns) MinQ = Q; else MinQ = QExistingColumns;
            }
            if (this.LineOfColHeader == null)
            {
                this.LineOfColHeader = new DataCell[QExistingColumns];
                if (this.TblInf != null && this.TblInf.Str != null) this.TblInf.Str.LineOfColHeaderExists = true;
            }
            for (int i = 1; i <= MinQ; i++)
            {
                this.LineOfColHeader[i - 1] = LineOfColHeader.GetCellN(i);
            }
        }
        //
        //Adding inserting deleting rows
        //
        //start new add line/col
        public void AddLine(DataCell[] LineExt, DataCell HeaderExt, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] LineCell;
            DataCell Header=null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg=null;
            int QLines, QColumns;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            if(CfgExt!=null) Cfg=CfgExt;
            else Cfg=new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            if(LineExt!=null){
                LineCell = new DataCell[QColumns];
                for (int i = 1; i <= QColumns; i++)
                {
                    LineCell[i - 1] = new DataCell();
                    LineCell[i - 1] = LineExt[i - 1];
                }
            }else{
                LineCell = new DataCell[QColumns];
                for (int i = 1; i <= QColumns; i++) LineCell[i - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, Cfg.CellCfg);
            }
            //
            MyLib.AddLineToTable(ref ContentCell, LineCell, ref QLines, ref QColumns);
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                QLines = QLines - 1;
                if (HeaderExt != null) Header = HeaderExt;
                else
                {
                    Header = new DataCell();
                    Header.SetTypeN(TableConsts.DefaultColOfLineHeaderCellTypeN, Cfg.CellCfg);
                }
                MyLib.AddToVector(ref ColOfLineHeader, ref QLines, Header);
            }
            if (Cfg.WriteParamsInfo)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                if (this.TblInf.RowsQuantities == null) this.TblInf.RowsQuantities = new TableSize();
                this.TblInf.SetSize(QLines, QColumns);
            }
        }
        public void AddLine_TypesByExisting(TableInfo TblInfOldExt)
        {
            DataCell[] LineCell;
            DataCell Header = null;
            TableInfo TblInfOld;
            TableSettingConfiguration Cfg = new TableSettingConfiguration();
            int QLines, QColumns, TypeN;
            if (TblInfOldExt != null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = this.TblInf;
            else TblInfOld = new TableInfo();
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            LineCell = new DataCell[QColumns];
            for (int i = 1; i <= QColumns; i++)
            {
                LineCell[i-1] = new DataCell();
                TypeN = GetTypeN(QLines, i);
                LineCell[i - 1].SetTypeN(TypeN, Cfg.CellCfg);
            }
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                Header = new DataCell();
                TypeN = GetTypeN_ColOfLineHeader(QLines);
                Header.SetTypeN(TypeN, Cfg.CellCfg);
            }
            AddLine(LineCell, Header, TblInfOld, Cfg);
        }
        public void AddLine(int[] TypesExt, int HeaderType, string HeaderName, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] LineCell;
            DataCell Header = null;
            TableInfo TblInfOld;
            TableSettingConfiguration Cfg;
            int QLines, QColumns, TypeN;
            //
            if(TblInfOldExt!=null) TblInfOld=TblInfOldExt;
            else if(this.TblInf!=null) TblInfOld=this.TblInf;
            else TblInfOld=new TableInfo();
            if(CfgExt!=null) Cfg=CfgExt;
            else Cfg = new TableSettingConfiguration();
            QLines=TblInfOld.GetQLines(); QColumns=TblInfOld.GetQColumns();
            LineCell = new DataCell[QColumns];
            for (int i = 1; i <= QColumns; i++)
            {
                LineCell[i-1] = new DataCell();
                if (TypesExt != null) TypeN = TypesExt[i - 1]; else TypeN = TableConsts.DefaultContentCellTypeN;
                LineCell[i - 1].SetTypeN(TypeN, Cfg.CellCfg);
            }
            if (TblInfOldExt.GetIf_CoLHExists() == true)
            {
                Header = new DataCell();
                Header.SetTypeN(HeaderType, Cfg.CellCfg);
                if(HeaderName!=null && HeaderName!="") Header.SetByValString(HeaderName);
            }
            AddLine(LineCell, Header, TblInfOld, Cfg);
        }
        /*public void AddLine(int[] TypesExt, int HeaderType, string HeaderName)
        {
            //string HeaderName=null;
            TableInfo TblInfOld;
            TableSettingConfiguration Cfg = new TableSettingConfiguration();
            //
            if (this.TblInf != null) TblInfOld = this.TblInf; else TblInfOld = new TableInfo();
            //
            AddLine(TypesExt, HeaderType, HeaderName, TblInfOld, Cfg);
        }*/
        public void AddLine_SnglType(double[] cnt, string HeaderName, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] LineCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns;
            //
            if (TblInfOldExt != null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            else TblInfOld = new TableInfo();
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            LineCell = new DataCell[QColumns];
            for (int i = 1; i <= QColumns; i++)
            {
                LineCell[i - 1] = new DataCell();
                if(cnt!=null) LineCell[i - 1].SetValAndTypeDouble(cnt[i - 1]);
                else  LineCell[i - 1].SetTypeN(TableConsts.DoubleTypeN, Cfg.CellCfg);
            }
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                Header = new DataCell();
                if(HeaderName!=null) Header.SetValAndTypeString(HeaderName);
                else Header.SetTypeN(TableConsts.StringTypeN, Cfg.CellCfg);
            }
            AddLine(LineCell, Header, TblInfOld, Cfg);
        }
        public void AddLine_SnglType(float[] cnt, string HeaderName, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] LineCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            LineCell = new DataCell[QColumns];
            for (int i = 1; i <= QColumns; i++)
            {
                LineCell[i - 1] = new DataCell();
                if (cnt != null) LineCell[i - 1].SetValAndTypeFloat(cnt[i - 1]);
                else LineCell[i - 1].SetTypeN(TableConsts.FloatTypeN, Cfg.CellCfg);
            }
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                Header = new DataCell();
                if (HeaderName != null) Header.SetValAndTypeString(HeaderName);
                else Header.SetTypeN(TableConsts.StringTypeN, Cfg.CellCfg);
            }
            AddLine(LineCell, Header, TblInfOld, Cfg);
        }
        public void AddLine_SnglType(int[] cnt, string HeaderName, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] LineCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            LineCell = new DataCell[QColumns];
            for (int i = 1; i <= QColumns; i++)
            {
                LineCell[i - 1] = new DataCell();
                if (cnt != null) LineCell[i - 1].SetValAndTypeInt(cnt[i - 1]);
                else LineCell[i - 1].SetTypeN(TableConsts.IntTypeN, Cfg.CellCfg);
            }
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                Header = new DataCell();
                if (HeaderName != null) Header.SetValAndTypeString(HeaderName);
                else Header.SetTypeN(TableConsts.StringTypeN, Cfg.CellCfg);
            }
            AddLine(LineCell, Header, TblInfOld, Cfg);
        }
        public void AddLine_SnglType(bool[] cnt, string HeaderName, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] LineCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            LineCell = new DataCell[QColumns];
            for (int i = 1; i <= QColumns; i++)
            {
                LineCell[i - 1] = new DataCell();
                if (cnt != null) LineCell[i - 1].SetValAndTypeBool(cnt[i - 1]);
                else LineCell[i - 1].SetTypeN(TableConsts.BoolTypeN, Cfg.CellCfg);
            }
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                Header = new DataCell();
                if (HeaderName != null) Header.SetValAndTypeString(HeaderName);
                else Header.SetTypeN(TableConsts.StringTypeN, Cfg.CellCfg);
            }
            AddLine(LineCell, Header, TblInfOld, Cfg);
        }
        public void AddLine_SnglType(string[] cnt, string HeaderName, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] LineCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            LineCell = new DataCell[QColumns];
            for (int i = 1; i <= QColumns; i++)
            {
                LineCell[i - 1] = new DataCell();
                if (cnt != null) LineCell[i - 1].SetValAndTypeString(cnt[i - 1]);
                else LineCell[i - 1].SetTypeN(TableConsts.StringTypeN, Cfg.CellCfg);
            }
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                Header = new DataCell();
                if (HeaderName != null) Header.SetValAndTypeString(HeaderName);
                else Header.SetTypeN(TableConsts.StringTypeN, Cfg.CellCfg);
            }
            AddLine(LineCell, Header, TblInfOld, Cfg);
        }
        public void AddLine_SnglType(double[] cnt)
        {
            AddLine_SnglType(cnt, null, null, null);
        }
        //fin new add line
        // start new ins line
        public void InsLine(int N, DataCell[] LineExt, DataCell HeaderExt, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] LineCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            else TblInfOld = new TableInfo();
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            if (N >= 1 && N <= QLines)
            {
                if (LineExt != null)
                {
                    LineCell = new DataCell[QColumns];
                    for (int i = 1; i <= QColumns; i++)
                    {
                        LineCell[i - 1] = LineExt[i - 1];
                    }
                }
                else
                {
                    LineCell = new DataCell[QColumns];
                    for (int i = 1; i <= QColumns; i++)
                    {
                        LineCell[i - 1] = new DataCell();
                        LineCell[i - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, Cfg.CellCfg);
                    }
                }
                //
                MyLib.InsLineToTable(ref ContentCell, LineCell, N, ref QLines, ref QColumns);
                if (TblInfOld.GetIf_CoLHExists() == true)
                {
                    QLines = QLines - 1;
                    if (HeaderExt != null) Header = HeaderExt;
                    else
                    {
                        Header = new DataCell();
                        Header.SetTypeN(TableConsts.DefaultColOfLineHeaderCellTypeN, Cfg.CellCfg);
                    }
                    MyLib.InsToVector(ref ColOfLineHeader, ref QLines, Header, N);
                }
                if (Cfg.WriteParamsInfo)
                {
                    if (this.TblInf == null) this.TblInf = new TableInfo();
                    if (this.TblInf.RowsQuantities == null) this.TblInf.RowsQuantities = new TableSize();
                    this.TblInf.SetSize(QLines, QColumns);
                }
            }
        }
        public void InsLine_TypesByExisting(int N, string LineHeaderName, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] LineCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg;
            int QLines, QColumns, TypeN;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            else TblInfOld = new TableInfo();
            if(CfgExt!=null) Cfg=CfgExt;
            Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            if (N >= 1 && N <= QLines)
            {
                LineCell = new DataCell[QColumns];
                for (int i = 1; i <= QColumns; i++)
                {
                    LineCell[i - 1] = new DataCell();
                    TypeN = GetTypeN(N, i);
                    LineCell[i - 1].SetTypeN(TypeN, Cfg.CellCfg);
                }
                //
                if (TblInfOld.GetIf_CoLHExists() == true)
                {
                    Header = new DataCell();
                    TypeN = GetTypeN_ColOfLineHeader(N);
                    Header.SetTypeN(TypeN, Cfg.CellCfg);
                }
                InsLine(N, LineCell, Header, TblInfOld, Cfg);
            }
        }
        public void InsLine_TypesByExisting(int N, TableInfo TblInfOldExt)
        {
            DataCell[] LineCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns, TypeN;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            else TblInfOld = new TableInfo();
            Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            if (N >= 1 && N <= QLines)
            {
                LineCell = new DataCell[QColumns];
                for (int i = 1; i <= QColumns; i++)
                {
                    LineCell[i - 1] = new DataCell();
                    TypeN = GetTypeN(N, i);
                    LineCell[i - 1].SetTypeN(TypeN, Cfg.CellCfg);
                }
                MyLib.InsLineToTable(ref ContentCell, LineCell, N, ref QLines, ref QColumns);
                if (TblInfOld.GetIf_CoLHExists() == true)
                {
                    Header = new DataCell();
                    Header.SetTypeN(TableConsts.DefaultColOfLineHeaderCellTypeN, Cfg.CellCfg);
                    QLines = QLines - 1;
                    MyLib.InsToVector(ref ColOfLineHeader, ref QLines, Header, N);
                }
                if (Cfg.WriteParamsInfo)
                {
                    if (this.TblInf == null) this.TblInf = new TableInfo();
                    if (this.TblInf.RowsQuantities == null) this.TblInf.RowsQuantities = new TableSize();
                    this.TblInf.SetSize(QLines, QColumns);
                }
            }
        }
        public void InsLine(int N, int[] TypesExt, int HeaderType, string HeaderName, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] LineCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns, TypeN;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            else TblInfOld = new TableInfo();
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            if (N >= 1 && N <= QLines)
            {
                LineCell = new DataCell[QColumns];
                for (int i = 1; i <= QColumns; i++)
                {
                    LineCell[i - 1] = new DataCell();
                    if (TypesExt != null) TypeN = TypesExt[i - 1]; else TypeN = TableConsts.DefaultContentCellTypeN;
                    LineCell[i - 1].SetTypeN(TypeN, Cfg.CellCfg);
                }
                if (TblInfOld.GetIf_CoLHExists() == true)
                {
                    //QLines = QLines - 1;
                    Header = new DataCell();
                    Header.SetTypeN(HeaderType, Cfg.CellCfg);
                    MyLib.InsToVector(ref ColOfLineHeader, ref QLines, Header, N);
                }
                //InsLine(N, LineCell, Header);
                InsLine(N, LineCell, Header,null,null);
            }
        }
        public void InsLine_SnglType(int N, double[] cnt, string HeaderName, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] LineCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            else TblInfOld = new TableInfo();
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            if (N >= 1 && N <= QLines)
            {
                LineCell = new DataCell[QColumns];
                for (int i = 1; i <= QColumns; i++)
                {
                    LineCell[i - 1] = new DataCell();
                    if (cnt == null){
                        LineCell[i - 1].SetValAndTypeDouble(cnt[i - 1]);
                    }else{
                        LineCell[i - 1].SetTypeN(TableConsts.DoubleTypeN, Cfg.CellCfg);
                    }
                }
                if (TblInfOld.GetIf_CoLHExists() == true)
                {
                    //QLines = QLines - 1;
                    Header = new DataCell();
                    if (HeaderName != null)
                    {
                        Header.SetValAndTypeString(HeaderName);
                    }
                    else
                    {
                        Header.SetTypeN(TableConsts.StringTypeN, Cfg.CellCfg);
                    }
                }
                InsLine(N, LineCell, Header, TblInfOld, Cfg);
            }
        }
        // fin new ins line
        //start new add ins col
        public void AddColumn(DataCell[] ColumnExt, DataCell HeaderExt, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] ColumnCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            if (ColumnExt != null)
            {
                ColumnCell = new DataCell[QLines];
                for (int i = 1; i <= QLines; i++)
                {
                    ColumnCell[i - 1] = new DataCell();
                    ColumnCell[i - 1] = ColumnExt[i - 1];
                }
            }
            else
            {
                ColumnCell = new DataCell[QLines];
                for (int i = 1; i <= QLines; i++) ColumnCell[i - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, Cfg.CellCfg);
            }
            //
            MyLib.AddColumnToTable(ref ContentCell, ColumnCell, ref QLines, ref QColumns);
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                QColumns = QColumns - 1;
                if (HeaderExt != null) Header = HeaderExt;
                else
                {
                    Header = new DataCell();
                    Header.SetTypeN(TableConsts.DefaultLineOfColHeaderCellTypeN, Cfg.CellCfg);
                }
                MyLib.AddToVector(ref LineOfColHeader, ref QLines, Header);
            }
            if (Cfg.WriteParamsInfo)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                if (this.TblInf.RowsQuantities == null) this.TblInf.RowsQuantities = new TableSize();
                this.TblInf.SetSize(QLines, QColumns);
            }
        }
        public void AddColumn(int[] CntTypes, int HeaderType, string ColHeaderName, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] ColumnCell;
            DataCell ColumnHeader=null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            ColumnCell = new DataCell[QLines];
            for (int i = 1; i <= QLines; i++)
            {
                ColumnCell[i - 1] = new DataCell();
                if (CntTypes != null && TypeNIsCorrect(CntTypes[i - 1]) == true)
                {
                    ColumnCell[i - 1].SetTypeN(CntTypes[i - 1], Cfg.CellCfg);
                }
                else
                {
                    ColumnCell[i - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, Cfg.CellCfg);
                }
                ColumnCell[i - 1].SetByValString(ColHeaderName);
            }
            if (TblInfOld.GetIf_LoCHExists() == true)
            {
                ColumnHeader = new DataCell();
                if (TypeNIsCorrect(HeaderType)) ColumnHeader.SetTypeN(HeaderType, Cfg.CellCfg);
                else ColumnHeader.SetTypeN(TableConsts.DefaultLineOfColHeaderCellTypeN, Cfg.CellCfg);
                ColumnHeader.SetByValString(ColHeaderName);
            }
            AddColumn(ColumnCell, ColumnHeader, TblInfOld, Cfg);
        }
        public void AddColumn_TypesByPrev(TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] ColumnCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns, TypeN;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            ColumnCell = new DataCell[QLines];
            for (int i = 1; i <= QLines; i++)
            {
                ColumnCell[i - 1] = new DataCell();
                TypeN = GetTypeN(i, QColumns);
                ColumnCell[i - 1].SetTypeN(TypeN, Cfg.CellCfg);
            }
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                Header = new DataCell();
                TypeN = GetTypeN_LineOfColHeader(QColumns);
                Header.SetTypeN(TypeN, Cfg.CellCfg);
            }
            AddColumn(ColumnCell, Header, TblInfOld, Cfg);
        }
        public void AddColumn_SnglType(double[] cnt, string HeaderName, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] ColumnCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            ColumnCell = new DataCell[QLines];
            for (int i = 1; i <= QLines; i++)
            {
                ColumnCell[i - 1] = new DataCell();
                if (cnt != null) ColumnCell[i - 1].SetValAndTypeDouble(cnt[i - 1]);
                else ColumnCell[i - 1].SetTypeN(TableConsts.DoubleTypeN, Cfg.CellCfg);
            }
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                Header = new DataCell();
                if (HeaderName != null) Header.SetValAndTypeString(HeaderName);
                else Header.SetTypeN(TableConsts.StringTypeN, Cfg.CellCfg);
            }
            AddColumn(ColumnCell, Header, TblInfOld, Cfg);
        }
        public void AddColumn_TypesByExisting()
        {
            int QLines = GetQLines(), QColumns = GetQColumns(), HeaderType;
            int[] types = new int[QColumns];
            HeaderType = GetTypeN_LineOfColHeader(QColumns);
            for (int i = 1; i <= QColumns; i++)
            {
                types[i - 1] = GetTypeN(QLines, i);

            }
            AddColumn(types, HeaderType, null, null, null);
        }
        public void AddColumn_TypesByExisting(string ColHeaderName)
        {
            int QLines = GetQLines(), QColumns = GetQColumns(), HeaderType;
            int[] types = new int[QColumns];
            HeaderType = GetTypeN_LineOfColHeader(QColumns);
            for (int i = 1; i <= QColumns; i++)
            {
                types[i - 1] = GetTypeN(QLines, i);

            }
            AddColumn(types, HeaderType, ColHeaderName, null, null);
        }
        //
        public void InsColumn(int N, DataCell[] ColumnExt, DataCell HeaderExt, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] ColumnCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            else TblInfOld = new TableInfo();
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            if (ColumnExt != null)
            {
                ColumnCell = new DataCell[QLines];
                for (int i = 1; i <= QLines; i++)
                {
                    ColumnCell[i - 1] = new DataCell();
                    ColumnCell[i - 1] = ColumnExt[i - 1];
                }
            }
            else
            {
                ColumnCell = new DataCell[QLines];
                for (int i = 1; i <= QLines; i++) ColumnCell[i - 1].SetTypeN(TableConsts.DefaultContentCellTypeN, Cfg.CellCfg);
            }
            //
            MyLib.InsColumnToTable(ref ContentCell, ColumnCell, N, ref QLines, ref QColumns);
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                QColumns = QColumns - 1;
                if (HeaderExt != null) Header = HeaderExt;
                else
                {
                    Header = new DataCell();
                    Header.SetTypeN(TableConsts.DefaultLineOfColHeaderCellTypeN, Cfg.CellCfg);
                }
                MyLib.InsToVector(ref LineOfColHeader, ref QLines, Header, N);
            }
            if (Cfg.WriteParamsInfo)
            {
                if (this.TblInf == null) this.TblInf = new TableInfo();
                if (this.TblInf.RowsQuantities == null) this.TblInf.RowsQuantities = new TableSize();
                this.TblInf.SetSize(QLines, QColumns);
            }
        }
        public void InsColumn_TypesByExisting(int N, DataCell[] ColumnExt, DataCell HeaderExt, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] ColumnCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns, TypeN;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            ColumnCell = new DataCell[QLines];
            for (int i = 1; i <= QLines; i++)
            {
                ColumnCell[i - 1] = new DataCell();
                TypeN=GetTypeN(i, N);
                ColumnCell[i - 1] .SetTypeN(TypeN, Cfg.CellCfg);
            }
            //
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                QLines = QLines - 1;
                if (HeaderExt != null) Header = HeaderExt;
                else
                {
                    Header = new DataCell();
                    Header.SetTypeN(TableConsts.DefaultLineOfColHeaderCellTypeN, Cfg.CellCfg);
                }
            }
            InsColumn(N, ColumnCell, Header, TblInfOld, Cfg);
        }
        public void InsColumn_TypesByExisting(int N, string ColumnHeaderName, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            InsColumn_TypesByExisting(N, ColumnHeaderName, null, null);
        }
        /*public void InsColumn_TypesByExisting(int N, TableInfo TblInfOldExt)
        {
            TableInfo TblInfOld;
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            else TblInfOld = new TableInfo();
            InsColumn_TypesByExisting(N, null, TblInfOld, null);
        }*/
        public void InsColumn_TypesByExisting(int N, TableSettingConfiguration CfgExt)
        {
            TableSettingConfiguration Cfg;
            if (CfgExt != null) Cfg = CfgExt; else Cfg = new TableSettingConfiguration();
            InsColumn_TypesByExisting(N, null, null, Cfg);
        }
        public void InsColumn_TypesByExisting(int N)
        {
            InsColumn_TypesByExisting(N, null, null, null);
        }
        public void InsColumn_SnglType(int N, double[] cnt, string HeaderName, TableInfo TblInfOldExt, TableSettingConfiguration CfgExt)
        {
            DataCell[] ColumnCell;
            DataCell Header = null;
            TableInfo TblInfOld = null;
            TableSettingConfiguration Cfg = null;
            int QLines, QColumns;
            //
            if (TblInfOldExt == null) TblInfOld = TblInfOldExt;
            else if (this.TblInf != null) TblInfOld = TblInf;
            if (CfgExt != null) Cfg = CfgExt;
            else Cfg = new TableSettingConfiguration();
            //
            QLines = TblInfOld.GetQLines(); QColumns = TblInfOld.GetQColumns();
            //
            ColumnCell = new DataCell[QLines];
            for (int i = 1; i <= QLines; i++)
            {
                ColumnCell[i - 1] = new DataCell();
                if (cnt != null) ColumnCell[i - 1].SetValAndTypeDouble(cnt[i - 1]);
                else ColumnCell[i - 1].SetTypeN(TableConsts.DoubleTypeN, Cfg.CellCfg);
            }
            if (TblInfOld.GetIf_CoLHExists() == true)
            {
                Header = new DataCell();
                if (HeaderName != null) Header.SetValAndTypeString(HeaderName);
                else Header.SetTypeN(TableConsts.StringTypeN, Cfg.CellCfg);
            }
            InsColumn(N, ColumnCell, Header, TblInfOld, Cfg);
        }
       //end new AddInsCol
        //mark5
        public void DelLineN(int N, TableInfo TblInfExt=null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //int QLines=GetQLines(), QColumns=GetQColumns();
            int QLines = TblInf.GetQLines(), QColumns = TblInf.GetQColumns();
            if (N >= 1 && N <= QLines)
            {
                MyLib.DelLineFromTable(ref ContentCell, N, ref QLines, ref QColumns);
                QLines = QLines + 1;
                if (this.GetIfColOfLineHeaderExists() == true)
                {
                    MyLib.DelInVector(ref ColOfLineHeader, ref  QLines, N);
                }
            }
            if (this.TblInf != null) this.TblInf.DelLine();
        }
        public void DelColumnN(int N, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //int QLines=GetQLines(), QColumns=GetQColumns();
            int QLines = TblInf.GetQLines(), QColumns = TblInf.GetQColumns();
            if (N >= 1 && N <= QColumns)
            {
                MyLib.DelColumnFromTable(ref ContentCell, N, ref QLines, ref QColumns);
                QColumns = QColumns + 1;
                if (this.GetIfLineOfColHeaderExists() == true)
                {
                    MyLib.DelInVector(ref LineOfColHeader, ref  QColumns, N);
                }
            }
            if (this.TblInf != null) this.TblInf.DelColumn();
        }
        //
        public void AddLine_TypesByExisting()
        {
            int QLines = GetQLines(), QColumns = GetQColumns(), HeaderType;
            int[] types = new int[QColumns];
            HeaderType = GetTypeN(QLines, 0);
            for (int i = 1; i <= QColumns; i++)
            {
                types[i - 1] = GetTypeN(QLines, i);

            }
            AddLine(types, HeaderType, null, null, null);
        }
        public void AddLine_TypesByExisting(string HeaderName)
        {
            int QLines = GetQLines(), QColumns = GetQColumns(), HeaderType;
            int[] types = new int[QColumns];
            HeaderType = GetTypeN(QLines, 0);
            for (int i = 1; i <= QColumns; i++)
            {
                types[i - 1] = GetTypeN(QLines, i);

            }
            AddLine(types, HeaderType, HeaderName, null, null);
        }
        //
        public void AddBoth_TypesByLast(int LineN, int ColN)
        {
            AddLine_TypesByExisting();
            AddColumn_TypesByExisting();
        }
        public void AddBoth_TypesByLast(string LoCHeaderName, string CoLHeaderName)
        {
            AddLine_TypesByExisting(CoLHeaderName);
            AddColumn_TypesByExisting(LoCHeaderName);
        }
        public void InsBoth_TypesByNext(int LineN, int ColN)
        {
            if ( LineN >= 1 && ColN >= 1 && LineN <= GetQLines() && ColN <= GetQColumns() )
            {
                InsLine_TypesByExisting(LineN, null);
                InsColumn_TypesByExisting(ColN, null);
            }
        }
        public void InsBoth_TypesByNext(int LineN, int ColN, string LoCHeaderName, string CoLHeaderName)
        {
            if (LineN >= 1 && ColN >= 1 && LineN <= GetQLines() && ColN <= GetQColumns())
            {
                InsLine_TypesByExisting(LineN, CoLHeaderName, null, null);
                InsColumn_TypesByExisting(ColN, LoCHeaderName, null, null);
            }
        }
        public void DelBoth(int LineN, int ColN) {
            DelLineN(LineN);
            DelColumnN(ColN);
        }
        //
        //List Items
        //
        public void SetOneParamListItem(int ItemN, string ItemName, double ItemVal)
        {
            double []vals=new double[1];
            vals[1-1]=ItemVal;
            SetLine_SnglType(ItemN, ItemName, vals);
        }
        public void SetOneParamListItem(int ItemN, string ItemName, float ItemVal)
        {
            float[] vals = new float[1];
            vals[1 - 1] = ItemVal;
            SetLine_SnglType(ItemN, ItemName, vals);
        }
        public void SetOneParamListItem(int ItemN, string ItemName, int ItemVal)
        {
            int[] vals = new int[1];
            vals[1 - 1] = ItemVal;
            SetLine_SnglType(ItemN, ItemName, vals);
        }
        public void SetOneParamListItem(int ItemN, string ItemName, bool ItemVal)
        {
            bool[] vals = new bool[1];
            vals[1 - 1] = ItemVal;
            SetLine_SnglType(ItemN, ItemName, vals);
        }
        public void SetOneParamListItem(int ItemN, string ItemName, string ItemVal)
        {
            string[] vals = new string[1];
            vals[1 - 1] = ItemVal;
            SetLine_SnglType(ItemN, ItemName, vals);
        }
        //
        public void SetSeveralParamListItem(int ItemN, string ItemName, double[] ItemVals)
        {
            SetLine_SnglType(ItemN, ItemName, ItemVals);
        }
        public void SetSeveralParamListItem(int ItemN, string ItemName, float[] ItemVals)
        {
            SetLine_SnglType(ItemN, ItemName, ItemVals);
        }
        public void SetSeveralParamListItem(int ItemN, string ItemName, int[] ItemVals)
        {
            SetLine_SnglType(ItemN, ItemName, ItemVals);
        }
        public void SetSeveralParamListItem(int ItemN, string ItemName, bool[] ItemVals)
        {
            SetLine_SnglType(ItemN, ItemName, ItemVals);
        }
        public void SetSeveralParamListItem(int ItemN, string ItemName, string[] ItemVals)
        {
            SetLine_SnglType(ItemN, ItemName, ItemVals);
        }
        //
        public void AddOneParamListItem(string ItemName, double ItemVal)
        {
            int QColumns=GetQColumns();
            int[] types=new int[QColumns];
            for(int i=1; i<=QColumns; i++){ types[i-1]=TableConsts.DoubleTypeN; }
            double[] vals = new double[1];
            vals[1 - 1] = ItemVal;
            //AddLine(types, TableConsts.StringTypeN, ItemName);
            AddLine(types, TableConsts.StringTypeN, ItemName, null, null);
        }
        public void AddOneParamListItem(string ItemName, float ItemVal)
        {
            int QColumns = GetQColumns();
            int[] types = new int[QColumns];
            for (int i = 1; i <= QColumns; i++) { types[i - 1] = TableConsts.FloatTypeN; }
            float[] vals = new float[1];
            vals[1 - 1] = ItemVal;
            //AddLine(types, TableConsts.StringTypeN, ItemName);
            AddLine(types, TableConsts.StringTypeN, ItemName, null, null);
        }
        public void AddOneParamListItem(string ItemName, int ItemVal)
        {
            int QColumns = GetQColumns();
            int[] types = new int[QColumns];
            for (int i = 1; i <= QColumns; i++) { types[i - 1] = TableConsts.IntTypeN; }
            int[] vals = new int[1];
            vals[1 - 1] = ItemVal;
            //AddLine(types, TableConsts.StringTypeN, ItemName);
            AddLine(types, TableConsts.StringTypeN, ItemName, null, null);
        }
        public void AddOneParamListItem(string ItemName, bool ItemVal)
        {
            int QColumns = GetQColumns();
            int[] types = new int[QColumns];
            for (int i = 1; i <= QColumns; i++) { types[i - 1] = TableConsts.BoolTypeN; }
            bool[] vals = new bool[1];
            vals[1 - 1] = ItemVal;
            //AddLine(types, TableConsts.StringTypeN, ItemName);
            AddLine(types, TableConsts.StringTypeN, ItemName, null, null);
        }
        public void AddOneParamListItem(string ItemName, string ItemVal)
        {
            int QColumns = GetQColumns();
            int[] types = new int[QColumns];
            for (int i = 1; i <= QColumns; i++) { types[i - 1] = TableConsts.StringTypeN; }
            string[] vals = new string[1];
            vals[1 - 1] = ItemVal;
            //AddLine(types, TableConsts.StringTypeN, ItemName);
            AddLine(types, TableConsts.StringTypeN, ItemName, null, null); ;
        }
        //
        public void AddSeveralParamListItem(string ItemName, double []ItemVals)
        {
            int QColumns = GetQColumns();
            int[] types = new int[QColumns];
            for (int i = 1; i <= QColumns; i++) { types[i - 1] = TableConsts.DoubleTypeN; }
            AddLine_SnglType(ItemVals, ItemName, null, null);
        }
        public void AddSeveralParamListItem(string ItemName, float[] ItemVals)
        {
            int QColumns = GetQColumns();
            int[] types = new int[QColumns];
            for (int i = 1; i <= QColumns; i++) { types[i - 1] = TableConsts.DoubleTypeN; }
            //AddLine_SingleType(ItemName, TableConsts.StringTypeN, ItemVals);
            AddLine_SnglType(ItemVals, ItemName, null, null);
        }
        public void AddSeveralParamListItem(string ItemName, int []ItemVals)
        {
            int QColumns = GetQColumns();
            int[] types = new int[QColumns];
            for (int i = 1; i <= QColumns; i++) { types[i - 1] = TableConsts.DoubleTypeN; }
            AddLine_SnglType(ItemVals, ItemName, null, null);
        }
        public void AddSeveralParamListItem(string ItemName, bool[] ItemVals)
        {
            int QColumns = GetQColumns();
            int[] types = new int[QColumns];
            for (int i = 1; i <= QColumns; i++) { types[i - 1] = TableConsts.DoubleTypeN; }
            AddLine_SnglType(ItemVals, ItemName, null, null);
        }
        public void AddSeveralParamListItem(string ItemName, string[] ItemVals)
        {
            int QColumns = GetQColumns();
            int[] types = new int[QColumns];
            for (int i = 1; i <= QColumns; i++) { types[i - 1] = TableConsts.DoubleTypeN; }
            AddLine_SnglType(ItemVals, ItemName, null, null);
        }
        //
        //
        //
        public void SwapLines(int N1, int N2)
        {
            int QLines=GetQLines(), QColumns=GetQColumns();
            if (N1 >= 1 && N1 <= QLines && N2 >= 1 && N2 <= QLines)
            {
                MyLib.SwapLinesInTable(ref ContentCell, QLines, QColumns, N1, N2);
            }
            if (this.GetIfColOfLineHeaderExists() == true)
            {
                MyLib.SwapInVector(ref ColOfLineHeader, QLines, N1, N2);
            }
        }
        public void SwapColumns(int N1, int N2)
        {
            int QLines = GetQLines(), QColumns = GetQColumns();
            if (N1 >= 1 && N1 <= QColumns && N2 >= 1 && N2 <= QColumns)
            {
                MyLib.SwapColumnsInTable(ref ContentCell, QLines, QColumns, N1, N2);
            }
            if (this.GetIfLineOfColHeaderExists() == true)
            {
                MyLib.SwapInVector(ref LineOfColHeader, QColumns, N1, N2);
            }
        }
        //public void SwapCells(ref DataCell cell1, ref DataCell cell2)
        //{
        //    DataCell cellBuf;
        //    cellBuf = (DataCell)cell1.Clone();
        //    cell1 = (DataCell)cell2.Clone();
        //    cell2 = (DataCell)cellBuf.Clone();
        //}
        public void SwapCells(ref DataCell cell1, ref DataCell cell2)
        {
            MyLib.Swap<DataCell>(ref cell1, ref cell2);
        }
        public void SwapCells(int LineN1, int ColN1, int LineN2, int ColN2, TableInfo TblInfExt=null)
        {
            DataCell cell1 = null, cell2 = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            bool LC_not_CL=TblInf.GetIf_LC_Not_CL();
            int MinLineN=-1, MinColN=-1;
            int QLines=TblInf.GetQLines(), QColumns=TblInf.GetQColumns();
            if (this.LineOfColHeader != null) MinColN = 0; else MinColN = 1;
            if (this.ColOfLineHeader != null) MinLineN = 0; else MinLineN = 1;
            if (LineN1 >= MinLineN && LineN2 >= MinLineN && ColN1 >= MinColN && ColN2 >= MinColN && LineN1 <= QLines && LineN2 <= QLines && ColN1 <= QColumns && ColN2 <= QColumns && !(LineN1 == 0 && ColN1 == 0) && !(LineN2 == 0 && ColN2 == 0))
            {
                if (LineN1 == 0 && ColN1 > 0){
                    cell1 = LineOfColHeader[ColN1-1];
                }else if(ColN1 == 0 && LineN1 > 0){
                    cell1 = ColOfLineHeader[LineN1-1];
                }
                else if (ColN1 > 0 && LineN1 > 0)
                {
                    if (LC_not_CL) cell1 = ContentCell[LineN1 - 1][ColN1 - 1];
                    else cell1 = ContentCell[ColN1 - 1][LineN1 - 1];
                }
                //
                if (LineN2 == 0 && ColN2 > 0)
                {
                    cell2 = LineOfColHeader[ColN2 - 1];
                }
                else if (ColN2 == 0 && LineN2 > 0)
                {
                    cell2 = ColOfLineHeader[LineN2 - 1];
                }
                else if (ColN2 > 0 && LineN2 > 0)
                {
                    if (LC_not_CL) cell2 = ContentCell[LineN2 - 1][ColN2 - 1];
                    else cell2 = ContentCell[ColN2 - 1][LineN2 - 1];
                }
                //
                SwapCells(ref cell1, ref cell2);
            }//if
        }//fn swap
        //public void SwapCells(int LineN1, int ColN1, int LineN2, int ColN2)
        //{
        //    int QLines=GetQLines(), QColumns=GetQColumns();
        //    DataCell Buf;
        //    if (LineN1 >= 1 && LineN1 <= QLines && ColN1 >= 1 && ColN1 <= QColumns && LineN1 >= 1 && LineN1 <= QLines && ColN1 >= 1 && ColN1 <= QColumns)
        //    {
        //        if (this.GetIf_LC_Matrix_Not_CL_DB() == true)
        //        {
        //            Buf = ContentCell[LineN1 - 1][ColN1 - 1];
        //            ContentCell[LineN1 - 1][ColN1 - 1]=ContentCell[LineN2 - 1][ColN2 - 1];
        //            ContentCell[LineN2 - 1][ColN2 - 1]=Buf;
        //        }
        //        else
        //        {
        //            Buf = ContentCell[ColN1 - 1][LineN1 - 1];
        //            ContentCell[ColN1 - 1][LineN1 - 1] = ContentCell[ColN2 - 1][LineN2 - 1];
        //            ContentCell[ColN2 - 1][LineN2 - 1] = Buf;
        //        }
        //    }
        //}
        //
        //Setting tablles by types 
        //
        /*public void SetTableAs_Matrix(Matrix M) {
            //TableSettingConfiguration cfg = new TableSettingConfiguration();
            //int[][] type;
            //int[] LoCHTypeN = null, CoLHTypeN = null;
            double CurVal;
            int QLines, QColumns;
            QLines=M.GetQLines();
            QColumns=M.GetQColumns();
            //cfg.CellCfg.PreserveVal = true;
            ////cfg.CellCfg.LengthOfArrCellTypes = 1;
            //type = new int[QLines][];
            //for (int i = 1; i <= QLines; i++)
            //{
            //    type[i - 1] = new int[QColumns];
            //}
            //for (int i = 1; i <= QLines; i++)
            //{
            //    for (int j = 1; j <= QColumns; j++)
            //    {
            //        type[i - 1][j - 1] = 1;
            //    }
            //}
            //SetMain(true, false, false, QLines, QColumns, type, LoCHTypeN, CoLHTypeN, cfg);
            //public void Set(TableInfo TblInfNewExt, TableInfo TblInfOldExt, bool ByColumnsNotLines, DataCellRow[] Content, DataCellRow LineOfColHeader, DataCellRow ColOfLineHeader, TableHeaders Headers, bool WriteInfo, bool PreserveVals)
            
            for (int i = 1; i <= QLines; i++)
            {
                line[i - 1] = new DataCellRow(TableConsts.DoubleTypeN, 1, QColumns, null);
                for (int j = 1; j <= QColumns; j++)
                {
                    CurVal = M.GetComponent(i, j);
                    line[i - 1].SetByValDouble(CurVal, j);
                    SetValAndTypeDouble(i, j, CurVal);
                }
            }
            TblInf = new TableInfo();
            TblInf.Repr = new TableRepresentation();
            TblInf.Repr.Set_Matrix();
            //TblInf.Repr.Set_SimpleNumerated(3);
        }*/
        public void SetTableAs_Matrix(Matrix M)
        {
            double CurVal;
            int QLines, QColumns;
            QLines = M.GetQLines();
            QColumns = M.GetQColumns();
            //public void Set(TableInfo TblInfNewExt, TableInfo TblInfOldExt, bool ByColumnsNotLines, DataCellRow[] Content, DataCellRow LineOfColHeader, DataCellRow ColOfLineHeader, TableHeaders Headers, bool WriteInfo, bool PreserveVals)
            DataCellRow[] lines = new DataCellRow[QLines];
            TableCellAccessConfiguration cfg = null;
            for (int i = 1; i <= QLines; i++)
            {
                lines[i - 1] = new DataCellRow(TableConsts.DoubleTypeN, 1, QColumns, null);
                for (int j = 1; j <= QColumns; j++)
                {
                    CurVal = M.GetComponent(i, j);
                    lines[i - 1].SetByValDouble(CurVal, j);
                    //this.SetValAndTypeDouble(i, j, CurVal);
                }
            }
            Set(new TableInfo(true, false, false, QLines, QColumns),
                null,
                false,
                lines,
                null,
                null,
                null
                ,
                true,
                false
               );
            //
            //TblInf.Repr = new TableRepresentation();
            //TblInf.Repr.Set_Matrix();
            Repr_Text_Set_Matrix();
            Repr_Grid_Set_SimpleNumerated();
            //TblInf.Repr.Set_SimpleNumerated(3);
        }
        //public void SetTableAs_2ArgsFunction(Matrix LoCA, Matrix CoLA, Matrix Cnt);
        public void SetTableAs_2ArgsFunction(int QLines, int QColumns, bool LinesNotColumns, DataCellRow ColOfLineHeader, DataCellRow LineOfColHeader, DataCellRow[]Content, DataCell LinesGeneralName, DataCell ColumnsGeneralName, DataCell TableName)
        {
            int zero = 0;
            //int[][] type;
            //int[] LoCHTypeN, CoLHTypeN;
            //double CurVal;
            //TableSettingConfiguration cfg = new TableSettingConfiguration();
            //cfg.CellCfg.PreserveVal = true;
            //type = new int[QLines][];
            //for (int i = 1; i <= QLines; i++)
            //{
            //    type[i - 1] = new int[QColumns];
            //}
            //for (int i = 1; i <= QLines; i++)
            //{
            //    for (int j = 1; j <= QColumns; j++)
            //    {
            //        type[i - 1][j - 1] = 1;
            //    }
            //}
            //LoCHTypeN = new int[QColumns];
            //for (int i = 1; i <= QColumns; i++)
            //{
            //    LoCHTypeN[i - 1] = 1;
            //}
            //CoLHTypeN = new int[QLines];
            //for (int i = 1; i <= QLines; i++)
            //{
            //    CoLHTypeN[i - 1] = 1;
            //}
            //SetMain(true, false, false, QLines, QColumns, type, LoCHTypeN, CoLHTypeN, cfg);
            //if(CoLA!=null){
            //    for (int i = 1; i <= QLines; i++)
            //    {
            //        CurVal=CoLA[i-1];
            //        SetValAndTypeDouble(i,0,CurVal);
            //    }
            //}else{
            //    for (int i = 1; i <= QLines; i++)
            //    {
            //        CurVal=0;
            //        SetValAndTypeDouble(i,0,CurVal);
            //    }
            //}
            //if(LoCA!=null){
            //    for (int i = 1; i <= QColumns; i++)
            //    {
            //        CurVal=LoCA[i-1];
            //        SetValAndTypeDouble(0,i,CurVal);
            //    }
            //}else{
            //    for (int i = 1; i <= QColumns; i++)
            //    {
            //        CurVal=0;
            //        SetValAndTypeDouble(0,i,CurVal);
            //    }
            //}
            //if(Cnt!=null){
            //    for (int i = 1; i <= QLines; i++)
            //    {
            //        for (int j = 1; j <= QColumns; j++)
            //        {
            //            CurVal = Cnt[i-1][j-1];
            //            SetValAndTypeDouble(i, j, CurVal);
            //        }
            //    }
            //}else{
            //    for (int i = 1; i <= QLines; i++)
            //    {
            //        for (int j = 1; j <= QColumns; j++)
            //        {
            //            CurVal = 0;
            //            SetValAndTypeDouble(i, j, CurVal);
            //        }
            //    }
            //}
            //TblInf = new TableInfo();
            //TblInf.Repr = new TableRepresentation();
            //TblInf.Repr.Set_Simple();
            Set(new TableInfo(true, true, true, QLines, QColumns),
                null,//TblInfOldExt
                (!LinesNotColumns),
                Content,
                LineOfColHeader,
                ColOfLineHeader,
                new TableHeaders(TableName, LinesGeneralName, ColumnsGeneralName),
                true,//WrInf
                false//preserve vals
            );
            //this.TblInf.Repr.GenRepr.//nil to set
            //this.TblInf.Repr.GenRepr.ShowTableNameInCorner;
            //
            //CreateFullRepresentation();
            //this.TblInf.Repr.Set_2ArgsFn();
            Repr_Text_Set_2ArgsFn();
            Repr_Grid_Set_Simple();
            //
            //this.TblInf.Repr.ColHeaderRepr.RowName = true;
            //this.TblInf.Repr.ColHeaderRepr.GenRowNameBef = true;
            //this.TblInf.Repr.ColHeaderRepr.RowNAft = true;
            //this.TblInf.Repr.ColHeaderRepr.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 4;
            ////
            //this.TblInf.Repr.LineHeaderRepr.RowName = true;
            //this.TblInf.Repr.LineHeaderRepr.GenRowNameBef = true;
            //this.TblInf.Repr.LineHeaderRepr.RowNAft = true;
            //this.TblInf.Repr.LineHeaderRepr.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 4;
            ////
            //this.TblInf.Repr.ContentRepr.ColHeader.RowName = true;
            //this.TblInf.Repr.ContentRepr.ColHeader.GenRowNameBef = true;
            //this.TblInf.Repr.ContentRepr.ColHeader.RowNAft = true;
            //this.TblInf.Repr.ContentRepr.ColHeader.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 4;
            ////
            //this.TblInf.Repr.ContentRepr.LineHeader.RowName = true;
            //this.TblInf.Repr.ContentRepr.LineHeader.GenRowNameBef = true;
            //this.TblInf.Repr.ContentRepr.LineHeader.RowNAft = true;
            //this.TblInf.Repr.ContentRepr.LineHeader.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 4;
            ////
            //this.TblInf.Repr.ContentRepr.HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6 = 2;
            //this.TblInf.Repr.ContentRepr.HeadersAreBefNotAft = true;
            //this.TblInf.Repr.ContentRepr.LH_IsBefNotAft_CH = true; //or can b vv;
            //this.TblInf.Repr.ContentRepr.TableHeaderExists = true; //ob ce s'fn
        }
        /*public void SetTableAs_1ParamList(string ListName, string ItemsGenName, bool ItemNamesExist, string[] ItemName, int QItems) {
            if (ItemsGenName == null || ItemsGenName.Equals("")) SetColsGeneralName("Value");
            else  SetColsGeneralName(ItemsGenName);
            if (ItemsGenName == null || ItemsGenName.Equals("")) SetLinesGeneralName("Param");
            else SetLinesGeneralName(ItemsGenName);
            //if(
        }*/
        //
        //void SetStructure_LC_MAtrix_Not_CL_DB(bool LC_MAtrix_Not_CL_DB, bool write, bool preserve)
        //{
        //    TDataCell [][]BufCell=null;
        //    if
        //    if()
        //}
        //
        public void SetTable_SingleType(string TableName, string TableName1, string LineOfColHeaderName, string LineOfColHeaderName1, string ColOfLineHeaderName, string ColOfLineHeaderName1, int QLines, int QColumns, int ContentType, int LineOfColHeaderType, int ColOfLineHeaderType, TableSettingConfiguration cfgExt)
        {
            //TableStructure str=new TableStructure();
            TableInfo TblInf;
            bool LC_Not_CL, CoLHExists, LoCHExists;
            if (this.TblInf == null || this.TblInf.Str == null || this.TblInf.RowsQuantities == null) TblInf = new TableInfo();
            else TblInf = this.TblInf;
            TblInf.SetSize(QLines, QColumns);
            TblInf.Str.LC_Matrix_Not_CL_DB = true;
            if (this.TypeNIsCorrect(LineOfColHeaderType)) TblInf.Str.LineOfColHeaderExists = true; else TblInf.Str.LineOfColHeaderExists = false;
            if (this.TypeNIsCorrect(ColOfLineHeaderType)) TblInf.Str.ColOfLineHeaderExists = true; else TblInf.Str.ColOfLineHeaderExists = false;
            TableSettingConfiguration cfg;
            if (cfgExt != null) cfg = cfgExt; else cfg = new TableSettingConfiguration();
            if (TableName1 != null) SetTableNames(TableName, TableName1);
            else SetTableNames(TableName, TableName1);
            if (LineOfColHeaderName != null) SetLinesGeneralName(ColOfLineHeaderName);
            if (ColOfLineHeaderName != null) SetColumnsGeneralName(LineOfColHeaderName);
            //TableCellsTypeMap TypeMap=new TableCellsTypeMap();
            int [][] CntTypesMap;
            int[] LoCHtypeN, CoLHTypeN;
            LoCHtypeN=new int[QColumns];
            for(int j=1; j<=QColumns; j++) LoCHtypeN[j-1]=LineOfColHeaderType;
            CoLHTypeN=new int [QLines];
            for(int i=1; i<=QLines; i++) CoLHTypeN[i-1]=ColOfLineHeaderType;
            if(TblInf.GetIf_LC_Not_CL()==true){
                CntTypesMap=new int[QLines][];
                for(int i=1; i<=QLines; i++) CntTypesMap[i-1]=new int[QColumns];
                for(int i=1; i<=QLines; i++){
                    for(int j=1; j<=QColumns; j++){
                        CntTypesMap[i-1][j-1]=ContentType;
                    }
                }
            }else{
                CntTypesMap=new int[QColumns][];
                for(int i=1; i<=QColumns; i++) CntTypesMap[i-1]=new int[QLines];
                for(int i=1; i<=QColumns; i++){
                    for(int j=1; j<=QLines; j++){
                        CntTypesMap[i-1][j-1]=ContentType;
                    }
                }
            }
            // public void SetMain/*ChangingPrev*/(bool LC_not_CL, bool CoLHExists, bool LoCHExists, int QLines, int QColumns, int[][] CntTypeN, int[] LoCHTypeN, int[] CoLHTypeN, TableSettingConfiguration cfgExt)
            //public void SetMain(TableStructure str, TableSize size, int[][] CntTypeN, int[] LoCHTypeN, int[] CoLHTypeN, TableSettingConfiguration cfg)
            //SetMain(TblInf, null, );  
            SetMain(TblInf.Str.LC_Matrix_Not_CL_DB, TblInf.Str.ColOfLineHeaderExists, TblInf.Str.LineOfColHeaderExists,TblInf.GetQLines(), TblInf.GetQColumns(), CntTypesMap,  LoCHtypeN, CoLHTypeN, cfg);  
            //SetMain(str, size, CntTypesMap, LoCHtypeN, CoLHTypeN, cfg);  
        }
        public void SetTable_SingleType(string TableName, string TableName1, string LineOfColHeaderName, string LineOfColHeaderName1, string ColOfLineHeaderName, string ColOfLineHeaderName1, int QLines, int QColumns, double[][] Content, double[] LineOfColHeader, double[] ColOfLineHeader)
        {
            bool LC_Not_CL, LoCHExists, CoLHExists;
            TableSettingConfiguration cfg=new TableSettingConfiguration();
            SetTable_SingleType(TableName, TableName1, LineOfColHeaderName, LineOfColHeaderName1, ColOfLineHeaderName, ColOfLineHeaderName1, QLines, QColumns, TableConsts.DoubleTypeN, TableConsts.DoubleTypeN, TableConsts.DoubleTypeN, cfg);
            LC_Not_CL = GetIf_LC_Matrix_Not_CL_DB();
            if(LC_Not_CL){
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        SetValAndTypeDouble(i, j, Content[i-1][j-1]);
                    }
                }
            }else{
                for (int i = 1; i <= QColumns; i++)
                {
                    for (int j = 1; j <= QLines; j++)
                    {
                        SetValAndTypeDouble(i, j, Content[i - 1][j - 1]);
                    }
                }
            }
            //
            LoCHExists=GetIfLineOfColHeaderExists();
            if (LoCHExists)
            {
                for (int i = 1; i <= QColumns; i++) SetValAndTypeDouble_LineOfColHeader(i, LineOfColHeader[i - 1]);
            }
            CoLHExists=GetIfColOfLineHeaderExists();
            if (CoLHExists)
            {
                for (int i = 1; i <= QLines; i++) SetValAndTypeDouble_ColOfLineHeader(i, ColOfLineHeader[i - 1]);
            }
        }
        /*
        public void SetTable_SingleType(string TableName, string TableName1, string LineOfColHeaderName, string LineOfColHeaderName1, string ColOfLineHeaderName, string ColOfLineHeaderName1, int QLines, int QColumns, double[][]Content, double[]LineOfColHeader)
        {
            
        }
        public void SetTable_SingleType(string TableName, string TableName1, string LineOfColHeadername, string LineOfColHeaderName1, string ColOfLineHeaderName, string ColOfLineHeaderName1, int QLines, int QColumns, double[][] Content, string[] LineOfColHeader, double[] ColOfLineHeader)
        {

        }
        public void SetTable_SingleType(string TableName, string TableName1, string LineOfColHeaderName, string LineOfColHeaderName1, string ColOfLineHeaderName, string ColOfLineHeaderName1, int QLines, int QColumns, double[][] Content, string[] LineOfColHeader)
        {
            
        }
        public void SetTable_SingleType(string TableName, string TableName1, string LineOfColHeadername, string LineOfColHeaderName1, string ColOfLineHeaderName, string ColOfLineHeaderName1, int QLines, int QColumns, string[][] Content, string[] LineOfColHeader, string[] ColOfLineHeader)
        {

        }
        public void SetTable_SingleType(string TableName, string TableName1, string LineOfColHeadername, string LineOfColHeaderName1, string ColOfLineheaderName, string ColOfLineHeaderName1, int QLines, int QColumns, string[][] Content, string[] LineOfColHeader)
        {

        }
        */
        //
        /*public void SetTableAs_SeveralParamList(string ListName, bool ItemNamesExist, string[] ItemName, string[] ParamName, int QParams, int QItems, int[] ItemTypeN) {
            int zero = 0;
            SetLinesGeneralName("Item");
            SetColumnsGeneralName("Param");
            SetTableName(ListName);
            //int QItems = 1;
            TableSettingConfiguration cfg=new TableSettingConfiguration(); 
            int[][] CntTypeN;
            int[] LoCHTypeN, CoLHTypeN;
            cfg.CellCfg.PreserveVal = true;
            CntTypeN = new int[QItems][];
            for (int i = 1; i <= QItems; i++)
            {
                CntTypeN[i - 1] = new int[QParams];
            }
            if (ItemTypeN != null)
            {
                for (int i = 1; i <= QItems; i++)
                {
                    for (int j = 1; j <= QParams; j++)
                    {
                        CntTypeN[i - 1][j - 1] = ItemTypeN[i - 1];
                    }
                }
            }
            else
            {
                for (int i = 1; i <= QItems; i++)
                {
                    for (int j = 1; j <= QParams; j++)
                    {
                        CntTypeN[i - 1][j - 1] = TableConsts.DoubleTypeN;
                        //type[i - 1][j - 1] = 5;
                    }
                }
            }
            if (ItemNamesExist)
            {
                CoLHTypeN = new int[QItems];
                for (int i = 1; i <= QItems; i++)
                {
                    CoLHTypeN[i - 1] = 5;
                }
            }
            else
            {
                CoLHTypeN = null;
            }
            LoCHTypeN = new int[QParams];
            for (int i = 1; i <= QParams; i++)
            {
                LoCHTypeN[i - 1] = TableConsts.StringTypeN;
            }
            //public void SetMain(bool LC_not_CL, bool CoLHExists, bool LoCHExists, int QLines, int QColumns, int[][] CntTypeN, int[] LoCHTypeN, int[] CoLHTypeN, int Constr0DelExisting1PreserveExisting2)
            SetMain(true, ItemNamesExist, true, QItems, QParams, CntTypeN, LoCHTypeN, CoLHTypeN, cfg);
            //
        }//fn*/
        //
        public void SetTableAs_MultyParamList(string[] ItemNames, int QItems, int QParams, bool ParamsNotItems, DataCell ListName, DataCellRow[] ItemsOrParams, DataCellRow ParamsNames, string ItemsGeneralName="", bool PreserveVals=false, bool WriteInfo=true, TableInfo TblInfOldExt = null)
        {
            TTable TblBuf = null;
            //public void Set(TableInfo TblInfNewExt, TableInfo TblInfOldExt, bool ByColumnsNotLines, DataCellRow[] Content, DataCellRow LineOfColHeader, DataCellRow ColOfLineHeader, TableHeaders Headers, bool WriteInfo, bool PreserveVals)
            //public void SetMain(TableInfo TblInfNewExt, TableInfo TblInfOldExt, TableCellsTypeMap TypeMapExt, TableSettingConfiguration CfgExt)
            bool LC_not_CL = true, LoCHExists = true, CoLHExists = (ItemNames != null), ByColsNotLines = true;
            TableInfo TblInfNew = new TableInfo(LC_not_CL, CoLHExists, LoCHExists, QItems, QParams);
            //
            TableHeaders headers = new TableHeaders();
            headers.CreateTableHeader();
            headers.TableHeader = ListName;
            headers.CreateColumnsGeneralName();
            headers.ColumnsGeneralHeader = new DataCell("Params");
            headers.CreateLinesGeneralName();
            if (ItemNames != null)
            {
                if (ItemsGeneralName == null || ItemsGeneralName=="") headers.LinesGeneralHeader = new DataCell("Items");
                else headers.LinesGeneralHeader = new DataCell(ItemsGeneralName);
            }
            else headers.LinesGeneralHeader = new DataCell("N");
            //
            if (WriteInfo) // tif V abl set representation - N'g
            {
                TblInfNew.Repr_Text = new TableRepresentation();
                TblInfNew.Repr_Grid = new TableRepresentation();
            }
            //
            if (PreserveVals) TblBuf = this;
            if (ItemNames != null)
            {
                Set(TblInfNew,
                    TblInfOldExt,
                    ParamsNotItems,
                    ItemsOrParams,
                    ParamsNames,
                    new DataCellRow(ItemNames, QItems),
                    headers,
                    WriteInfo,
                    PreserveVals
                );
            }
            else
            {
                Set(TblInfNew,
                    TblInfOldExt,
                    ParamsNotItems,
                    ItemsOrParams,
                    ParamsNames,
                    null,
                    headers,
                    WriteInfo,
                    PreserveVals
                );
            }
        }
        //
        public void SetTableAs_1ParamList(int QItems, DataCellRow Items, DataCell ListName)
        {
            SetTableAs_1ParamList(null, QItems, Items, ListName);
        }
        public void SetTableAs_1ParamList(string[] ItemNames, int QItems, DataCellRow Items, DataCell ListName, string ItemsGenNameExt="", bool PreserveVals = false, bool WriteInfo = true, TableInfo TblInfOldExt = null)
        {
            TTable TblBuf = null;
            //public void SetMain(TableInfo TblInfNewExt, TableInfo TblInfOldExt, TableCellsTypeMap TypeMapExt, TableSettingConfiguration CfgExt)
            bool LC_not_CL = true, LoCHExists = true, CoLHExists = (ItemNames != null), ByColsNotLines = true;
            TableInfo TblInfNew = new TableInfo(LC_not_CL, CoLHExists, LoCHExists, QItems, 1);
            //
            TableHeaders headers=new TableHeaders();
            headers.CreateTableHeader();
            headers.TableHeader=ListName;
            headers.DeleteColumnsGeneralName();
            headers.CreateLinesGeneralName();
            //if (ItemNames != null)
            //{
            if(ItemsGenNameExt==null || ItemsGenNameExt==""){
                if (ItemNames != null) headers.LinesGeneralHeader = new DataCell("Name");
                else headers.LinesGeneralHeader = new DataCell("N");
            }
            else headers.LinesGeneralHeader = new DataCell(ItemsGenNameExt);
            //}
            //else headers.LinesGeneralName = new DataCell("N");
            //
            DataCellRow LoCH = new DataCellRow("Value", 1);
            DataCellRow[]cnt=new DataCellRow[1];
            if(Items!=null){
                for(int i=1; i<=1; i++) cnt[i-1]=Items;
            }else{
                for(int i=1; i<=1; i++) cnt[i-1]=new DataCellRow();
            }
            //
            if (WriteInfo) // tif V abl set representation - N'g
            {
                TblInfNew.Repr_Text = new TableRepresentation();
                TblInfNew.Repr_Grid = new TableRepresentation();
            }
            //
            if (PreserveVals) TblBuf = this;
            if (ItemNames != null)
            {
                Set(TblInfNew,
                    TblInfOldExt,
                    ByColsNotLines,
                    cnt,
                    LoCH,
                    new DataCellRow(ItemNames, QItems),
                    headers,
                    WriteInfo,
                    PreserveVals
                );
            }else{
                Set(TblInfNew,
                    TblInfOldExt,
                    ByColsNotLines,
                    cnt,
                    LoCH,
                    null,
                    headers,
                    WriteInfo,
                    PreserveVals
                );
            }
        }
        //
        /*
        public void SetTableAs_1ParamList_NumeratedOnly(DataCell ListName, DataCell ItemsGenName, DataCell[] Items, int QItems, bool PreserveVals)
        {
            TTable TblBuf=null;
            //public void SetMain(TableInfo TblInfNewExt, TableInfo TblInfOldExt, TableCellsTypeMap TypeMapExt, TableSettingConfiguration CfgExt)
            bool LC_not_CL = true, LoCHExists = true, CoLHExists = false;
            TableInfo TblInfNew = new TableInfo(LC_not_CL, CoLHExists, LoCHExists, QItems, 2);
            if (PreserveVals) TblBuf = this;  
        
        }
        public void SetTableAs_1ParamList_NumeratedOnly(DataCell ListName, DataCell ItemsGenName, DataTypeRow Types, int QItems)
        {
            TTable TblBuf = null;
            //public void SetMain(TableInfo TblInfNewExt, TableInfo TblInfOldExt, TableCellsTypeMap TypeMapExt, TableSettingConfiguration CfgExt)
            bool LC_not_CL = true, LoCHExists = true, CoLHExists = false;
            TableInfo TblInfNew = new TableInfo(LC_not_CL, CoLHExists, LoCHExists, QItems, 2);

        }
        public void SetTableAs_1ParamList_Named(DataCell ListName, DataCell ItemsGenName, DataCell[] Items, DataCell[] ItemHeaders, int QItems)
        {
            TTable TblBuf = null;
            //public void SetMain(TableInfo TblInfNewExt, TableInfo TblInfOldExt, TableCellsTypeMap TypeMapExt, TableSettingConfiguration CfgExt)
            bool LC_not_CL = true, LoCHExists = true, CoLHExists = false;
            TableInfo TblInfNew = new TableInfo(LC_not_CL, CoLHExists, LoCHExists, QItems, 2);

        }
        public void SetTableAs_1ParamList_Named(DataCell ListName, DataCell ItemsGenName, DataTypeRow Types, DataCell[] ItemHeaders, int QItems)
        {
            TTable TblBuf = null;
            //public void SetMain(TableInfo TblInfNewExt, TableInfo TblInfOldExt, TableCellsTypeMap TypeMapExt, TableSettingConfiguration CfgExt)
            bool LC_not_CL = true, LoCHExists = true, CoLHExists = false;
            TableInfo TblInfNew = new TableInfo(LC_not_CL, CoLHExists, LoCHExists, QItems, 2);

        }
        public void SetTableAs_1ParamList(string ListName, string ItemsGenName, bool ItemNamesExist, int[]ItemTypeN, string[] ItemName, int QItems)
        {
            //string[] ParamName=new string[1];
            //ParamName[1-1]="Value";
            //SetTableAs_SeveralParamList(ListName, ItemNamesExist, ItemName, ParamName, 1, QItems, ItemTypeN);
            //public void SetMain(bool LC_not_CL, bool CoLHExists, bool LoCHExists, int QLines, int QColumns, int[][] CntTypeN, int[] LoCHTypeN, int[] CoLHTypeN, int Constr0DelExisting1PreserveExisting2)
            //SetMain(true, ItemNamesExist, true, QItems, 1, ItemTypeN, LoCHTypeN, CoLHTypeN, 1);
            //bool LC_Not_CL = true, LoCHExits=true, CoLHExists;
            //ContentCell = new TDataCell[QItems][];
            //for(int i=1; i<=QItems; i++) ContentCell[i-1]=new TDataCell[1];
            //if (ItemTypeN == null)
            //{
            //    for (int i = 1; i <= QItems; i++)
            //    {
            //        SetCellTypeN(i, 1, TableConsts.DoubleTypeN, 1, 0);
            //    }
            //}
            //else
            //{
            //    for (int i = 1; i <= QItems; i++)
            //    {
            //        SetCellTypeN(i, 1, ItemTypeN[i - 1], 1, 0);
            //    }
            //}
            
            //LineOfColHeader=new TDataCell[1];
            //LineOfColHeader[1-1]=new TCellString("Value");
            ////SetLinesGeneralName(
            //if (ItemNamesExist == false)
            //{
            //    ColOfLineHeader = null;
            //    CoLHExists = false;
            //}
            //else
            //{
            //    ColOfLineHeader = new TDataCell[QItems];
            //    if (ItemName == null)
            //    {
            //        for (int i = 1; i <= QItems; i++) SetValAndTypeString_ColOfLineHeader(i, "");
            //    }
            //    else
            //    {
            //        for (int i = 1; i <= QItems; i++) SetValAndTypeString_ColOfLineHeader(i, ItemName[i - 1]);
            //    }
            //    CoLHExists = true;
            //}
            int QParams=1;
            int[] LoCHTypeN;
            TableSettingConfiguration cfg = new TableSettingConfiguration();
            cfg.CellCfg.PreserveVal = true;
            if (ItemNamesExist) {
                LoCHTypeN = new int[QItems];
                for(int i=1; i<=QItems; i++) LoCHTypeN[i-1] = TableConsts.StringTypeN;
            } else LoCHTypeN = null;
            int[] CoLHTypeN;
            CoLHTypeN = new int[QParams];
            for(int i=1; i<=QParams; i++) CoLHTypeN[i-1] = TableConsts.StringTypeN;
            int[][] ItemTypeN2;
            ItemTypeN2 = new int[QItems][];
            for(int i=1; i<=QItems; i++) ItemTypeN2[i-1] = new int[QParams];
            if(ItemTypeN!=null){
                for(int i=1; i<=QItems; i++) ItemTypeN2[i-1][QParams-1] =ItemTypeN[i-1];
            }else{
                for (int i = 1; i <= QItems; i++) ItemTypeN2[i - 1][QParams - 1] = TableConsts.DoubleTypeN;
            }
            //public void SetMain(TableInfo TblInfNewExt, TableInfo TblInfOldExt, TableCellsTypeMap TypeMapExt, TableSettingConfiguration CfgExt)
            //this.SetMain();
            //public void SetMain(bool LC_not_CL, bool CoLHExists, bool LoCHExists, int QLines, int QColumns, int[][] CntTypeN, int[] LoCHTypeN, int[] CoLHTypeN, int Constr0DelExisting1PreserveExisting2)
            this.SetMain(true, ItemNamesExist, true, QItems, 1, ItemTypeN2, LoCHTypeN, CoLHTypeN, cfg);
            this.SetLinesGeneralName(ItemsGenName);
            this.SetValAndTypeString_LineOfColHeader(1, "Value"); 
            //if (TblInf == null) TblInf = new TableInfo();
            //TblInf.SetStr(LC_Not_CL, CoLHExists, LoCHExits);
            //TblInf.SetSize(QItems, 1);
        }
        */
        public void SetTableAs_DB_StrByFields(int QFields, string[] Names, string[] NamesToDisplay, int[] FieldTypeN, int StructMaxSimple_Yes0No1)
        {
            if(QFields<1 || QFields>MyLib.MaxInt) QFields=1;
            int QRecs=1;
            int [][]CntTypeN;
            int[] HdrTypesN;
            string[]Captions;
            int QTableNames, QFieldNames, HeadersTypeN;
            TableSettingConfiguration cfg = new TableSettingConfiguration();
            cfg.CellCfg.PreserveVal = true;
            SetLinesGeneralName("");
            SetColumnsGeneralName("");
            HdrTypesN=new int[QFields];
            Captions=new string[2];
            if(StructMaxSimple_Yes0No1==0){
                for(int i=1; i<=QFields; i++){
                    HdrTypesN[i-1]=TableConsts.StringTypeN;
                }
            }else if(StructMaxSimple_Yes0No1==0){
                for(int i=1; i<=QFields; i++){
                    HdrTypesN[i-1]=TableConsts.StringArrayTypeN;
                }
            }
            CntTypeN=new int[QFields][];
            for(int i=1; i<=QFields; i++){
                CntTypeN[i-1]=new int[QRecs];
            }
            for(int i=1; i<=QFields; i++){
                for(int j=1; j<=QRecs; j++){
                    CntTypeN[i-1][j-1]=FieldTypeN[i-1];
                }
            }
            //
            SetMain(false, false, true, 1, QFields, CntTypeN, HdrTypesN, null, cfg);
            //
            if (StructMaxSimple_Yes0No1 == 0)
            {
                for (int i = 1; i <= QFields; i++)
                {
                    if (StructMaxSimple_Yes0No1 == 0)
                    {
                        if (Names == null)
                        {
                            Captions[2 - 1] = "";
                        }
                        if (NamesToDisplay == null)
                        {
                            Captions[1 - 1] = "";
                        }
                        //SetStringA
                    }
                    else if (StructMaxSimple_Yes0No1 == 1)
                    {
                        if (Names == null)
                        {
                            Captions[2 - 1] = "";
                        }
                        if (NamesToDisplay == null)
                        {
                            Captions[1 - 1] = "";
                        }
                        //SetStringA
                    }
                }
            }
            else if (StructMaxSimple_Yes0No1 == 0)
            {
                for (int i = 1; i <= QFields; i++)
                {
                    HdrTypesN[i - 1] = TableConsts.StringArrayTypeN;
                }
            }
        }
        public void SetTableAs_DB_StrByRecs(int QFields, string[] Names, string[] NamesToDisplay, int[] FieldTypeN, int StructMaxSimple_Yes0No1)
        {
            if (QFields < 1 || QFields > MyLib.MaxInt) QFields = 1;
            int QRecs = 1;
            int[][] CntTypeN;
            int[] HdrTypesN;
            string[] Captions;
            TableSettingConfiguration cfg = new TableSettingConfiguration();
            cfg.CellCfg.PreserveVal = true;
            //int QTableNames, QFieldNames, HeadersTypeN;
            SetLinesGeneralName("");
            SetColumnsGeneralName("");
            HdrTypesN = new int[QFields];
            Captions = new string[2];
            if (StructMaxSimple_Yes0No1 == 0)
            {
                for (int i = 1; i <= QFields; i++)
                {
                    HdrTypesN[i - 1] = TableConsts.StringTypeN;
                }
            }
            else if (StructMaxSimple_Yes0No1 == 0)
            {
                for (int i = 1; i <= QFields; i++)
                {
                    HdrTypesN[i - 1] = TableConsts.StringArrayTypeN;
                }
            }
            CntTypeN = new int[QRecs][];
            for (int i = 1; i <= QRecs; i++)
            {
                CntTypeN[i - 1] = new int[QFields];
            }
            for (int i = 1; i <= QRecs; i++){
                for (int j = 1; j <= QFields; j++)
                {
                
                    CntTypeN[i - 1][j - 1] = FieldTypeN[j - 1];
                }
            }
            //
            SetMain(true, false, true, 1, QFields, CntTypeN, HdrTypesN, null, cfg);
            //
            if (StructMaxSimple_Yes0No1 == 0)
            {
                for (int i = 1; i <= QFields; i++)
                {
                    if (StructMaxSimple_Yes0No1 == 0)
                    {
                        if (Names == null)
                        {
                            Captions[2 - 1] = "";
                        }
                        if (NamesToDisplay == null)
                        {
                            Captions[1 - 1] = "";
                        }
                        //SetStringA
                    }
                    else if (StructMaxSimple_Yes0No1 == 1)
                    {
                        if (Names == null)
                        {
                            Captions[2 - 1] = "";
                        }
                        if (NamesToDisplay == null)
                        {
                            Captions[1 - 1] = "";
                        }
                        //SetStringA
                    }
                }
            }
            else if (StructMaxSimple_Yes0No1 == 0)
            {
                for (int i = 1; i <= QFields; i++)
                {
                    HdrTypesN[i - 1] = TableConsts.StringArrayTypeN;
                }
            }
        }
        /*public void SetTableAs_2ArgsFn(string FnName, string FnName2, string HorArgName, string VertArgName, string HorArgName2, string VertArgName2, int QHorArgVals, int QVertArgVals, double[][] FnVals, double[] HorArgvals, double[] VertArgVals)
        {
            if (FnName2 != null)
            {
                SetTableNames(FnName, FnName2);
            }else{
                SetTableName(FnName);
            }
            SetLinesGeneralName(VertArgName);
            SetColumnsGeneralName(HorArgName);
            this.SetSize(QVertArgVals, QHorArgVals);

        }*/
        //
        //Getters 2
        //
        public int GetQLines(TableInfo TblInfExt=null) { 
            //int Q=0;
            //if (this.TblInf != null && this.TblInf.RowsQuantities != null) Q=this.TblInf.RowsQuantities.GetQLines();
            //return Q;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            return TblInf.GetQLines();
        }
        public int GetQColumns(TableInfo TblInfExt = null)
        {
            //int Q = 0;
            //if (this.TblInf != null && this.TblInf.RowsQuantities != null) Q=this.TblInf.RowsQuantities.GetQColumns();
            //return Q;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            return TblInf.GetQColumns();
        }
        //
        //public string GetTableName(int N) { return TableName.ToStringN(N); }
        //public string GetLinesGeneralName() { return this.TblInf.RowsGeneralNames.LinesGeneralName; }
        //public string GetColsGeneralName() { return this.TblInf.RowsGeneralNames.ColsGeneralName; }
        //
        //public int GetTableNameSize() { return TableName.GetLength(); }
        public int GetTableNameSize() { return this.Headers.TableHeader.GetLength(); }
        public bool GetIfLineOfColHeaderExists() { return (LineOfColHeader != null); }
        public bool GetIfColOfLineHeaderExists() { return (ColOfLineHeader != null); }
        public bool GetIfTableNameExists()
        {
            bool b;
            //b = (this.TableName != null);
            //b = (this.TableName != null && this.TableName.ToString() != "");
            b = (this.Headers!=null && this.Headers.TableHeader != null && this.Headers.TableHeader.ToString() != "");
            return b;
        }
        public bool GetIf_LC_Matrix_Not_CL_DB()
        {
            bool R = true;
            if(this.TblInf!=null && this.TblInf.Str!=null) R=this.TblInf.Str.LC_Matrix_Not_CL_DB;
            return R;
        }
        public void Set_LC_Matrix_Not_CL_DB(bool LC_Matrix_Not_CL_DB)
        {
            if (LC_Matrix_Not_CL_DB != this.TblInf.Str.LC_Matrix_Not_CL_DB)
            {
                MyLib.TransposeTable(ref this.ContentCell, ref this.TblInf.RowsQuantities.QLines, ref this.TblInf.RowsQuantities.QColumns);
            }
        }
        public bool GetIfLineNExists(int N)
        {
            bool b;
            b = (N >= 1 && N <= GetQLines());
            return b;
        }
        public bool GetIfColumnNExists(int N)
        {
            bool b;
            b = (N >= 1 && N <= GetQColumns());
            return b;
        }
        //mark6
        public DataCell GetCell(int LineN, int ColumnN, /*TableInfo*/TableInfo_ConcrRepr TblInfExt = null)
        {
            DataCell cell;
            /*TableInfo*/ TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            cell = null;
            if (LineN == 0)
            {
                cell = GetCell_LineOfColHeader(ColumnN, TblInf);
            }
            else if (ColumnN == 0)
            {
                cell = GetCell_ColOfLineHeader(LineN, TblInf);
            }
            else
            {
                if(TblInf.GetIf_LC_Not_CL()){
                    if(LineN >= 1 && LineN <= TblInf.GetQLines() && ColumnN >= 1 && ColumnN <= TblInf.GetQColumns())
                    {
                        cell = ContentCell[LineN - 1][ColumnN - 1];
                    }
                }else{
                    if(LineN >= 1 && LineN <= TblInf.GetQLines() && ColumnN >= 1 && ColumnN <= TblInf.GetQColumns())
                    {
                        cell = ContentCell[ColumnN - 1][LineN - 1];
                    }
                }
            }
            return cell;
        }
        public DataCell GetCell_ColOfLineHeader(int LineN, /*TableInfo*/TableInfo_ConcrRepr TblInfExt = null)
        {
            DataCell cell;
            /*TableInfo*/  TableInfo_ConcrRepr TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            cell = null;
            bool CoLHExists = GetIfColOfLineHeaderExists();
            if (CoLHExists == true && LineN >= 1 && LineN <=TblInf.GetQLines())
            {
                cell = ColOfLineHeader[LineN - 1];
            }
            return cell;
        }
        public DataCell GetCell_LineOfColHeader(int ColumnN, /*TableInfo*/TableInfo_ConcrRepr TblInfExt = null)
        {
            DataCell cell;
            /*TableInfo*/ TableInfo_ConcrRepr TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            cell = null;
            bool LoCHExists = GetIfLineOfColHeaderExists();
            if (LoCHExists == true && ColumnN >= 1 && ColumnN <= TblInf.GetQColumns())
            {
                cell = LineOfColHeader[ColumnN - 1];
            }
            return cell;
        }
        public DataCell GetTableNameCell()
        {
            DataCell cell = null;
            if (this.GetIfTableNameExists() == true)
            {
                cell = Headers.TableHeader;
            }
            return cell;
        }
        public DataCell GetLinesGeneralNameCell()
        {
            DataCell cell = null;
            if (this.GetIf_LinesGeneralHeaderExists() == true)
            {
                cell = Headers.LinesGeneralHeader;
            }
            return cell;
        }
        public DataCell GetColumnsGeneralNameCell()
        {
            DataCell cell = null;
            if (this.GetIf_ColumnsGeneralHeaderExists() == true)
            {
                cell = Headers.ColumnsGeneralHeader;
            }
            return cell;
        }
        //
        //Set Headers
        //
        public void SetTableName(string name)
        {
            if (this.Headers == null) this.Headers = new TableHeaders();
            if (this.Headers.TableHeader == null) this.Headers.TableHeader = new DataCell();
            this.Headers.TableHeader.SetValAndTypeString(name);
        }
        public void SetLinesGeneralName(DataCell data)
        {
            if (Headers == null) Headers = new TableHeaders();
            if (Headers.LinesGeneralHeader == null) Headers.LinesGeneralHeader = new DataCell();
            if (data != null) Headers.LinesGeneralHeader = data;
        }
        public void SetColumnsGeneralName(DataCell data)
        {
            if (Headers == null) Headers = new TableHeaders();
            if (Headers.ColumnsGeneralHeader == null) Headers.ColumnsGeneralHeader = new DataCell();
            if (data != null) Headers.ColumnsGeneralHeader = data;
        }
        //
        //Table Info
        //
        public TableRepresentation GetRepresentation_Text()
        {
            TableRepresentation R = null;
            if (this.TblInf != null && this.TblInf.Repr_Text != null) R = this.TblInf.Repr_Text;
            return R;
        }
        public TableContentCellRepresentation GetRepresentation_ContentCell_Text()
        {
            TableContentCellRepresentation R=null;
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.GetContentRepr() != null) R = this.TblInf.Repr_Text.GetContentRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetRepresentation_ColOfLineHeader_Text()
        {
            TableHeaderCellRepresentation R = null;
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.GetLineHeaderRepr() != null) R = this.TblInf.Repr_Text.GetLineHeaderRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetRepresentation_LineOfColHeader_Text()
        {
            TableHeaderCellRepresentation R = null;
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.GetColHeaderRepr() != null) R = this.TblInf.Repr_Text.GetColHeaderRepr();
            return R;
        }
        public TableGeneralRepresentation GetRepresentation_TableGeneral_Text()
        {
            TableGeneralRepresentation R = null;
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.GetColHeaderRepr() != null) R = this.TblInf.Repr_Text.GetGeneralRepresentation();
            return this.TblInf.Repr_Text.GetGeneralRepresentation();
        }
        public TableHeaderCellRepresentation GetRepresentation_ColOfLineHeader_OfContentCell_Text()
        {
            TableHeaderCellRepresentation R = null;
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.GetContentRepr() != null) R = this.TblInf.Repr_Text.dets.ContentRepr.LineHeader;
            return R;
        }
        public TableHeaderCellRepresentation GetRepresentation_LineOfColHeader_OfContentCell_Text()
        {
            TableHeaderCellRepresentation R = null;
            if (this.TblInf != null && this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.GetContentRepr() != null) R = this.TblInf.Repr_Text.dets.ContentRepr.ColHeader;
            return R;
        }
        //
        //
        public TableRepresentation GetRepresentation_Grid()
        {
            TableRepresentation R = null;
            if (this.TblInf != null && this.TblInf.Repr_Grid != null) R = this.TblInf.Repr_Grid;
            return R;
        }
        public TableContentCellRepresentation GetRepresentation_ContentCell_Grid()
        {
            TableContentCellRepresentation R = null;
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.GetContentRepr() != null) R = this.TblInf.Repr_Grid.GetContentRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetRepresentation_ColOfLineHeader_Grid()
        {
            TableHeaderCellRepresentation R = null;
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.GetLineHeaderRepr() != null) R = this.TblInf.Repr_Grid.GetLineHeaderRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetRepresentation_LineOfColHeader_Grid()
        {
            TableHeaderCellRepresentation R = null;
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.GetColHeaderRepr() != null) R = this.TblInf.Repr_Grid.GetColHeaderRepr();
            return R;
        }
        public TableGeneralRepresentation GetRepresentation_TableGeneral_Grid()
        {
            TableGeneralRepresentation R = null;
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets.ColHeaderRepr != null) R = this.TblInf.Repr_Grid.GetGeneralRepresentation();
            return this.TblInf.Repr_Grid.GetGeneralRepresentation();
        }
        public TableHeaderCellRepresentation GetRepresentation_ColOfLineHeader_OfContentCell_Grid()
        {
            TableHeaderCellRepresentation R = null;
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.GetContentRepr() != null) R = this.TblInf.Repr_Grid.dets.ContentRepr.LineHeader;
            return R;
        }
        public TableHeaderCellRepresentation GetRepresentation_LineOfColHeader_OfContentCell_Grid()
        {
            TableHeaderCellRepresentation R = null;
            if (this.TblInf != null && this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.GetContentRepr() != null) R = this.TblInf.Repr_Grid.dets.ContentRepr.ColHeader;
            return R;
        }
        //
        //
        /*
        public TableContentFullRepresentation GetRepresentation_ContentFull()
        {
            TableContentFullRepresentation str;
            str.Gen = GetRepresentation_TableGeneral();
            str.Cnt = GetRepresentation_ContentCell();
            return str;
        }
        public TableHeaderFullRepresentation GetColOfLineHeaderFullRepresentation()
        {
            TableHeaderFullRepresentation str;
            str.Gen = GetRepresentation_TableGeneral();
            str.Hdr = GetRepresentation_ColOfLineHeader();
            return str;
        }
        public TableHeaderFullRepresentation GetLineOfColHeaderFullRepresentation()
        {
            TableHeaderFullRepresentation str;
            str.Gen = GetRepresentation_TableGeneral();
            str.Hdr = GetRepresentation_LineOfColHeader();
            return str;
        }
        */
        //
        public void SetTableTextRepresentationSettingsInfoNull()
        {
            //this.TblInf.Repr_Text.dets.ColHeaderRepr = null;
            //this.TblInf.Repr_Text.dets.LineHeaderRepr = null;
            //this.TblInf.Repr_Text.dets.ContentRepr.ColHeader = null;
            //this.TblInf.Repr_Text.dets.ContentRepr.LineHeader = null;
            //this.TblInf.Repr_Text.dets.ContentRepr = null;
            //this.TblInf.Repr_Text.dets.GenRepr = null;
            //this.TblInf.Repr_Text = null;
            this.TblInf.Repr_Text.SetNull();
        }
        public void SetTableGridRepresentationSettingsInfoNull()
        {
            //this.TblInf.Repr_Grid.dets.ColHeaderRepr = null;
            //this.TblInf.Repr_Grid.dets.LineHeaderRepr = null;
            //this.TblInf.Repr_Grid.dets.ContentRepr.ColHeader = null;
            //this.TblInf.Repr_Grid.dets.ContentRepr.LineHeader = null;
            //this.TblInf.Repr_Grid.dets.ContentRepr = null;
            //this.TblInf.Repr_Grid.dets.GenRepr = null;
            //this.TblInf.Repr_Grid = null;
            this.TblInf.Repr_Grid.SetNull();
        }
        public void SetTableUssagePolicyNull()
        {
            this.TblInf.UssagePolicy = null;
        }
        public void SetTableStructureInfoNull()
        {
            this.TblInf.Str = null;
        }
        public void SetTableRowsQuantitiesNull()
        {
            this.TblInf.RowsQuantities = null;
        }
        /*public void RowsGeneralNamesNull()
        {
            this.TblInf.RowsGeneralNames = null;
        }*/
        public void SetTableInfNull()
        {
            //RowsGeneralNamesNull();
            SetTableRowsQuantitiesNull();
            SetTableStructureInfoNull();
            SetTableUssagePolicyNull();
            SetTableTextRepresentationSettingsInfoNull();
            SetTableGridRepresentationSettingsInfoNull();
        }
        public void SetTableNameNull()
        {
            //this.Headers.TableHeader
            //this.TableName = null;
            this.Headers.TableHeader = null;
        }
        public void SetSpecCellNull()
        {
            this.SpecCell = null;
        }
        //
        public void CreateTableStructureInfoByDefault()
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.Str = null;
        }
        public void CreateTableRowsQuantitiesByDefault()
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            //this.TblInf.RowsQuantities = new TableRowsQuantities();
            this.TblInf.RowsQuantities = new TableSize();
        }
        /*public void CreateRowsGeneralNamesByDefault()
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            //this.TblInf.RowsGeneralNames = new TableRowsGeneralNames();
            this.TableHea;
        }*/
        public void CreateTableTextRepresentationSettingsInfoByDefault()
        {
            //this.TblInf.Repr.ColHeaderRepr = new TableHeaderCellRepresentation();
            //this.TblInf.Repr.LineHeaderRepr = new TableHeaderCellRepresentation();
            //this.TblInf.Repr.ContentRepr.ColHeader = new TableHeaderCellRepresentation(); ;
            //this.TblInf.Repr.ContentRepr.LineHeader = new TableHeaderCellRepresentation();
            //this.TblInf.Repr.ContentRepr = new TableContentCellRepresentation();
            //this.TblInf.Repr.GenRepr = new TableGeneralRepresentation();
            if(this.TblInf==null) this.TblInf=new TableInfo();
            this.TblInf.Repr_Text = new TableRepresentation();
        }
        public void CreateTableGridRepresentationSettingsInfoByDefault()
        {
            //this.TblInf.Repr.ColHeaderRepr = new TableHeaderCellRepresentation();
            //this.TblInf.Repr.LineHeaderRepr = new TableHeaderCellRepresentation();
            //this.TblInf.Repr.ContentRepr.ColHeader = new TableHeaderCellRepresentation(); ;
            //this.TblInf.Repr.ContentRepr.LineHeader = new TableHeaderCellRepresentation();
            //this.TblInf.Repr.ContentRepr = new TableContentCellRepresentation();
            //this.TblInf.Repr.GenRepr = new TableGeneralRepresentation();
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.Repr_Grid = new TableRepresentation();
        }
        public void CreateTableUssagePolicyByDefault()
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.UssagePolicy = new TableUssagePolicy();
        }
        public void CreateTableInfEmpty()
        {
            this.TblInf = new TableInfo();
            this.TblInf.Str = null;
            this.TblInf.RowsQuantities = null;
            //this.TblInf.RowsGeneralNames = null;
            this.TblInf.Repr_Text = null;
            this.TblInf.Repr_Grid = null;
            this.TblInf.UssagePolicy = null;
        }
        public void CreateTableInfFullByDefault()
        {
            this.TblInf = new TableInfo();
        }
        public void CreateTableNameByDefault()
        {
            //this.TableName = new TCellString();
            //this.TableName = new DataCell();
            //this.TableName.SetTypeN(TableConsts.StringTypeN, null);
            this.Headers.TableHeader = new DataCell();
            this.Headers.TableHeader.SetTypeN(TableConsts.StringTypeN, null);
        }
        public void CreateSpeCellByDefault()
        {
            //this.SpecCell = new TCellDouble();
            this.SpecCell = new DataCell();
            this.SpecCell.SetTypeN(TableConsts.DoubleTypeN, null);
        }
        //
        //
        public void SetTableTextRepresentation(TableRepresentation repr){
            this.TblInf.Repr_Text=repr;//may be if
        }
        //
        public void SetContentCellTextRepresentation(TableContentCellRepresentation repr)
        {
            this.TblInf.Repr_Text.SetContentRepr(repr);
        }
        public void SetColOfLineHeaderTextRepresentation(TableHeaderCellRepresentation repr)
        {
            this.TblInf.Repr_Text.SetLineHeaderRepr(repr);
        }
        public void SetLineOfColHeaderTextRepresentation(TableHeaderCellRepresentation repr)
        {
            this.TblInf.Repr_Text.SetColHeaderRepr(repr);
        }
        public void SetTableGeneralTextRepresentation(TableGeneralRepresentation repr)
        {
            this.TblInf.Repr_Text.SetGeneralRepresentation(repr);
        }
        //
        //
        public void SetTableGridRepresentation(TableRepresentation repr)
        {
            this.TblInf.Repr_Grid = repr;//may be if
        }
        public void SetContentCellGridRepresentation(TableContentCellRepresentation repr)
        {
            this.TblInf.Repr_Grid.SetContentRepr(repr);
        }
        public void GetColOfLineHeaderGridRepresentation(TableHeaderCellRepresentation repr)
        {
            this.TblInf.Repr_Grid.SetLineHeaderRepr(repr);
        }
        public void GetLineOfColHeaderGridRepresentation(TableHeaderCellRepresentation repr)
        {
            this.TblInf.Repr_Grid.SetColHeaderRepr(repr);
        }
        public void GetTableGeneralGridRepresentation(TableGeneralRepresentation repr)
        {
            this.TblInf.Repr_Grid.SetGeneralRepresentation(repr);
        }
        //
        //
        public TableUssagePolicy GetTableUssagePolicy()
        {
            return this.TblInf.UssagePolicy;
        }
        public void SetTableUssagePolicy(TableUssagePolicy policy)
        {
            this.TblInf.UssagePolicy=policy;
        }
        //
        public void SetSize(int QLines, int QColumns)
        {
            int QLinesNew=QLines, QColumnsNew=QColumns;
            if (QLines >= 1 && QLines <= MyLib.MaxInt && QColumns >= 1 && QColumns <= MyLib.MaxInt)
            {
                if(ContentCell!=null)MyLib.ResizeTable(ref ContentCell, GetQLines(), GetQColumns(), QLinesNew, QColumnsNew, 1);
                if (GetIfColOfLineHeaderExists()) MyLib.ResizeVector(ref ColOfLineHeader, GetQLines(), QLinesNew, 1);
                if (GetIfLineOfColHeaderExists()) MyLib.ResizeVector(ref LineOfColHeader, GetQColumns(), QColumnsNew, 1);
            }
        }
        
        public void SetTableName1(string name) {
            int TN;
            string[] arr = null;
            //if (this.TableName == null)
            if (this.Headers.TableHeader == null)
            {
                //TableName = new TCellStringMemo(arr, 2);
                //TableName = new DataCell(arr, 2);
                this.Headers.TableHeader = new DataCell(arr, 2);
            }
            else
            {
                //TN = TableName.GetTypeN();
                TN = this.Headers.TableHeader.GetTypeN();
                if (TN != TableConsts.StringArrayTypeN)
                {
                    //TableName = new TCellStringMemo(arr, 2);
                    //TableName = new DataCell(arr, 2);
                    this.Headers.TableHeader = new DataCell(arr, 2);
                }
            }
            this.Headers.TableHeader.SetByValStringN(name, 1);
        }
        public void SetTableName2(string name)
        {
            int TN;
            string[] arr = null;
            //if (this.TableName == null)
            if (this.Headers.TableHeader == null)
            {
                //TableName = new TCellStringMemo(arr, 2);
                //TableName = new DataCell(arr, 2);
                this.Headers.TableHeader = new DataCell(arr, 2);
            }
            else
            {
                //TN = TableName.GetTypeN();
                TN = this.Headers.TableHeader.GetTypeN();
                if (TN != TableConsts.StringArrayTypeN)
                {
                    //TableName = new TCellStringMemo(arr, 2);
                    //TableName = new DataCell(arr, 2);
                    this.Headers.TableHeader = new DataCell(arr, 2);
                }
            }
            //TableName.SetByValStringN(name, 2);
            this.Headers.TableHeader.SetByValStringN(name, 2);
        }
        public void SetTableNames(string name1ToDisplay, string name2ToConnect) {
            string[] arr = new string[2];
            arr[1 - 1] = name1ToDisplay;
            arr[2 - 1] = name2ToConnect;
            //TableName = new TCellStringMemo(arr, 2);
            //TableName = new DataCell(arr, 2);
            this.Headers.TableHeader = new DataCell(arr, 2);
        }
        public void SetTableNameN(string name, int N) {
            int TN;
            string[] arr = null;
            if (N <= 1 ) N = 1;
            if (N >= 2) N = 2;
            //if (this.TableName == null)
            if (this.Headers.TableHeader == null)
            {
                //TableName = new TCellStringMemo(arr, 2);
                //TableName = new DataCell(arr, 2);
                this.Headers.TableHeader = new DataCell(arr, 2);
            }
            else
            {
                //TN = TableName.GetTypeN();
                TN = this.Headers.TableHeader.GetTypeN();
                if (TN != TableConsts.StringArrayTypeN)
                {
                    //TableName = new TCellStringMemo(arr, N);
                    //TableName = new DataCell(arr, N);
                    this.Headers.TableHeader = new DataCell(arr, N);
                }
            }
            //TableName.SetByValStringN(name, 2);
            this.Headers.TableHeader.SetByValStringN(name, 2);
        }
        public void SetTableNameSize1()
        {
            int TN;
            string name1ToDisplay="";
            //if (TableName == null)
            if (this.Headers.TableHeader == null)
            {
                //this.TableName = new TCellString();
                //this.TableName = new DataCell();
                this.Headers.TableHeader  = new DataCell();
                //this.TableName.SetTypeN(TableConsts.StringTypeN,null);
                this.Headers.TableHeader.SetTypeN(TableConsts.StringTypeN, null);
            }
            else
            {
                //TN = TableName.GetTypeN();
                TN = this.Headers.TableHeader.GetTypeN();
                //name1ToDisplay = this.TableName.ToString();
                name1ToDisplay = this.Headers.TableHeader.ToString();
                if (TN != TableConsts.StringTypeN)
                {
                    //this.TableName = new TCellString();
                    //this.TableName = new DataCell();
                    this.Headers.TableHeader = new DataCell();
                    //this.TableName.SetTypeN(TableConsts.StringTypeN, null);
                    this.Headers.TableHeader.SetTypeN(TableConsts.StringTypeN, null);
                }
            }
            //TableName.SetByValString(name1ToDisplay);
            this.Headers.TableHeader.SetByValString(name1ToDisplay);
        }
        public void SetTableNameSize2()
        {
            int TN;
            string[] arr = null;
            string name1ToDisplay, name2ToConnect;
            //if (TableName == null)
            if (this.Headers.TableHeader == null)
            {
                //this.TableName = new TCellString();
                //this.TableName = new DataCell();
                this.Headers.TableHeader = new DataCell();
                //this.TableName.SetTypeN(TableConsts.StringTypeN, null);
                //this.Headers.TableHeader.SetTypeN(TableConsts.StringTypeN, null);
                //this.TableName.SetTypeN(TableConsts.StringTypeN, null);
                this.Headers.TableHeader.SetTypeN(TableConsts.StringTypeN, null);
            }
            else
            {
                //TN = TableName.GetTypeN();
                TN = this.Headers.TableHeader.GetTypeN();
                if (TN != TableConsts.StringArrayTypeN)
                {
                    //name1ToDisplay = TableName.ToStringN(1);
                    //name2ToConnect = TableName.ToStringN(2);
                    name1ToDisplay = this.Headers.TableHeader.ToStringN(1);
                    name2ToConnect = this.Headers.TableHeader.ToStringN(2);
                    arr = new string[2];
                    arr[1 - 1] = name1ToDisplay;
                    arr[2 - 1] = name2ToConnect;
                    //TableName = new TCellStringMemo(arr, 2);
                    //TableName = new DataCell(arr, 2);
                    this.Headers.TableHeader = new DataCell(arr, 2);
                }
            }
        }
        //
        //Set, Get gen params and cells
        //
        public void SetSpecCellSize(int Q) {
            //to add!
        }
        //public void SetLinesGeneralName(string name) {
        //    if (this.TblInf == null)
        //    {
        //        CreateTableInfEmpty();
        //    }
        //    if(this.TblInf.RowsGeneralNames==null) this.TblInf.RowsGeneralNames = new TableRowsGeneralNames();
        //    this.TblInf.RowsGeneralNames.LinesGeneralName = name;
        //}
        //public void SetColsGeneralName(string name)
        //{
        //    if (this.TblInf == null)
        //    {
        //        CreateTableInfEmpty();
        //    }
        //    if (this.TblInf.RowsGeneralNames == null) this.TblInf.RowsGeneralNames = new TableRowsGeneralNames();
        //    this.TblInf.RowsGeneralNames.ColsGeneralName = name;
        //}
        //
        public void SetColumnName(int N, string name)
        {
            int OldTypeN;//, NewTypeN=TableConsts.DefaultCellTypeN;
            if (GetIfLineOfColHeaderExists() == true && N>=1 && N<=GetQColumns())
            {
                OldTypeN=GetTypeN(0,N);
                if (OldTypeN != TableConsts.StringArrayTypeN && OldTypeN != TableConsts.StringTypeN)
                {
                    //this.LineOfColHeader[N - 1] = new TCellString();
                    this.LineOfColHeader[N - 1] = new DataCell();
                    this.LineOfColHeader[N - 1].SetTypeN(TableConsts.StringTypeN, null);
                }
                this.LineOfColHeader[N - 1].SetByValStringN(name, 1);
            }
        }
        public void SetColumnName1(int N, string name)
        {
            int OldTypeN;//, NewTypeN=TableConsts.DefaultCellTypeN;
            string Name2Prev;
            if (GetIfLineOfColHeaderExists() == true && N >= 1 && N <= GetQColumns())
            {
                OldTypeN = GetTypeN(0, N);
                Name2Prev = this.LineOfColHeader[N - 1].ToStringN(2);
                if (OldTypeN != TableConsts.StringArrayTypeN)
                {
                    //this.LineOfColHeader[N - 1] = new TCellStringMemo();
                    this.LineOfColHeader[N - 1] = new DataCell();
                    this.LineOfColHeader[N - 1].SetTypeN(TableConsts.StringArrayTypeN, null);
                }
                this.LineOfColHeader[N - 1].SetByValStringN(name, 1);
                this.LineOfColHeader[N - 1].SetByValStringN(Name2Prev, 2);
            }
        }
        public void SetColumnName2(int N, string name)
        {
        //    int TN;
        //    string[] arr = null;
        //    if (this.ColumnName == null)
        //    {
        //        ColumnName = new TCellStringMemo(arr, 2);
        //    }
        //    else
        //    {
        //        TN = ColumnName.GetTypeN();
        //        if (TN != ColumnConsts.StringArrayTypeN)
        //        {
        //            ColumnName = new TCellStringMemo(arr, 2);
        //        }
        //    }
        //    ColumnName.SetByValStringN(name, 2);
            int OldTypeN;//, NewTypeN=TableConsts.DefaultCellTypeN;
            string Name2Prev;
            if (GetIfLineOfColHeaderExists() == true && N >= 1 && N <= GetQColumns())
            {
                OldTypeN = GetTypeN(0, N);
                Name2Prev = this.LineOfColHeader[N - 1].ToStringN(2);
                if (OldTypeN != TableConsts.StringArrayTypeN)
                {
                    //this.LineOfColHeader[N - 1] = new TCellStringMemo();
                    this.LineOfColHeader[N - 1] = new DataCell();
                    this.LineOfColHeader[N - 1].SetTypeN(TableConsts.StringArrayTypeN, null);
                }
                this.LineOfColHeader[N - 1].SetByValStringN(name, 1);
                this.LineOfColHeader[N - 1].SetByValStringN(Name2Prev, 2);
            }
        }
        public void SetColumnName(int N, string name1ToDisplay, string name2ToConnect)
        {
            string[] arr = new string[2];
            arr[1 - 1] = name1ToDisplay;
            arr[2 - 1] = name2ToConnect;
            //this.LineOfColHeader[N - 1] = new TCellStringMemo(arr, 2);
            this.LineOfColHeader[N - 1] = new DataCell(arr, 2);
        }
        public void SetColumnName(int ColumnN, int NameN, string name)
        {
            int OldTypeN;//, NewTypeN=TableConsts.DefaultCellTypeN;
            string[] NameArr = new string[2];
            if (GetIfLineOfColHeaderExists() == true && ColumnN >= 1 && ColumnN <= GetQColumns())
            {
                OldTypeN = GetTypeN(0, ColumnN);
                if (OldTypeN != TableConsts.StringArrayTypeN)
                {
                    //this.LineOfColHeader[ColumnN - 1] = new TCellStringMemo();
                    this.LineOfColHeader[ColumnN - 1] = new DataCell();
                    this.LineOfColHeader[ColumnN - 1].SetTypeN(TableConsts.StringArrayTypeN, null);
                }
                NameArr[1 - 1] = ToStringN_LineOfColHeader(ColumnN, 1);
                NameArr[2 - 1] = ToStringN_LineOfColHeader(ColumnN, 1);
                if (NameN == 1)
                {
                    NameArr[1 - 1] = name;
                }
                else if (NameN == 2)
                {
                    NameArr[2 - 1] = name;
                }
                this.LineOfColHeader[ColumnN - 1].SetByArrString(NameArr, 2);
            }
            
        }
        //
        //Any Cell 
        //
        public  int GetTypeN(int LineN, int ColN, TableInfo TblInfExt=null){
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int TypeN;
            TypeN=0;
            DataCell cell;
            cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) TypeN = cell.GetTypeN();
            return TypeN;
        }
        public int GetTypeN_LineOfColHeader(int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int TypeN;
            TypeN = 0;
            DataCell cell;
            cell = GetCell(0, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                TypeN = LineOfColHeader[ColN-1].GetTypeN();
            }
            return TypeN;
        }
        public int GetTypeN_ColOfLineHeader(int LineN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int TypeN;
            TypeN = 0;
            DataCell cell;
            cell = GetCell(LineN, 0, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                TypeN = ColOfLineHeader[LineN - 1].GetTypeN();
            }
            return TypeN;
        }
        public int GetActiveN(int LineN, int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ActiveN;
            ActiveN = 0;
            DataCell cell;
            cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) ActiveN = cell.GetActiveN();
            return ActiveN;
        }
        public int GetActiveN_LineOfColHeader(int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ActiveN;
            ActiveN = 0;
            DataCell cell;
            cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) ActiveN = cell.GetActiveN();
            return ActiveN;
        }
        public int GetActiveN_ColOfLineHeader(int LineN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ActiveN;
            ActiveN = 0;
            DataCell cell;
            cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) ActiveN = cell.GetActiveN();
            return ActiveN;
        }
        //
        public void SetActiveN(int LineN, int ColN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell;
            cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetActiveN(ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetActiveN(ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetActiveN(ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetActiveN(ValN);
                    }
                }
            }
        }
        public int GetLength(int LineN, int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int LR;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            LR=cell.GetLength();
            return LR;
        }
        public int GetLength_ColOfLineHeader(int LineN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int LR;
            DataCell cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
            LR = cell.GetLength();
            return LR;
        }
        public int GetLength_LineOfColHeader(int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int LR;
            DataCell cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
            LR = cell.GetLength();
            return LR;
        }
        public void SetLength(int LineN, int ColN, int L, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell;
            cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetLength(L);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetLength(L);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetLength(L);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetLength(L);
                    }
                }
            }
        }
        //
        public double GetDoubleVal(int LineN, int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            double dr;
            dr = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                dr = cell.GetDoubleVal();
            }
            return dr;
        }
        public float GetFloatVal(int LineN, int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            float fr;
            fr = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                fr = cell.GetFloatVal();
            }
            return fr;
        }
        public int GetIntVal(int LineN, int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ir;
            ir = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                ir = cell.GetIntVal();
            }
            return ir;
        }
        public bool GetBoolVal(int LineN, int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            bool br;
            br = false;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                br = cell.GetBoolVal();
            }
            return br;
        }
        public string ToString(int LineN, int ColN, /*TableInfo*/TableInfo_ConcrRepr TblInfExt = null)
        {
            /*TableInfo*/  TableInfo_ConcrRepr TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            string sr;
            sr = "";
            DataCell cell = GetCell(LineN, ColN, TblInf);
            if (cell != null)
            {
                sr = cell.ToString();
            }
            return sr;
        }
        //
        public double GetDoubleValN(int LineN, int ColN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            double dr;
            dr = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                dr = cell.GetDoubleValN(ValN);
            }
            return dr;
        }
        public float GetFloatValN(int LineN, int ColN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            float fr;
            fr = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                fr = cell.GetFloatValN(ValN);
            }
            return fr;
        }
        public int GetIntValN(int LineN, int ColN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ir;
            ir = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                ir = cell.GetIntValN(ValN);
            }
            return ir;
        }
        public bool GetBoolValN(int LineN, int ColN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            bool br;
            br = false;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                br = cell.GetBoolValN(ValN);
            }
            return br;
        }
        public string ToStringN(int LineN, int ColN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            string sr;
            sr = "";
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                sr = cell.ToString();
            }
            return sr;
        }
        //
        public void GetDoubleArr(int LineN, int ColN, ref double[] arr, ref int QItems, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if(cell!=null){
                QItems=GetLength(LineN, ColN);
                arr = new double[QItems];
                for (int i = 1; i <= QItems; i++)
                {
                    arr[i - 1] = GetDoubleValN(LineN, ColN, i);
                }
            }
        }
        public void GetFloatArr(int LineN, int ColN, ref float[] arr, ref int QItems, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                QItems = GetLength(LineN, ColN, TblInf);
                arr = new float[QItems];
                for (int i = 1; i <= QItems; i++)
                {
                    arr[i - 1] = GetFloatValN(LineN, ColN, i);
                }
            }
        }
        public void GetIntArr(int LineN, int ColN, ref int[] arr, ref int QItems, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                QItems = GetLength(LineN, ColN, TblInf);
                arr = new int[QItems];
                for (int i = 1; i <= QItems; i++)
                {
                    arr[i - 1] = GetIntValN(LineN, ColN, i);
                }
            }
        }
        public void GetBoolArr(int LineN, int ColN, ref bool[] arr, ref int QItems, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                QItems = GetLength(LineN, ColN);
                arr = new bool[QItems];
                for (int i = 1; i <= QItems; i++)
                {
                    arr[i - 1] = GetBoolValN(LineN, ColN, i);
                }
            }
        }
        public void GetStringArr(int LineN, int ColN, ref string[] arr, ref int QItems, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                QItems = GetLength(LineN, ColN);
                arr = new string[QItems];
                for (int i = 1; i <= QItems; i++)
                {
                    arr[i - 1] = ToStringN(LineN, ColN, i);
                }
            }
        }
        //
        public void SetByValDouble(int LineN, int ColN, double val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValDouble(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValDouble(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValDouble(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValDouble(val);
                    }
                }
            }
        }
        public void SetByValFloat(int LineN, int ColN, float val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValFloat(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValFloat(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValFloat(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValFloat(val);
                    }
                }
            }
        }
        //mark7
        public void SetByValInt(int LineN, int ColN, int val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValInt(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValInt(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValInt(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValInt(val);
                    }
                }
            }
        }
        public void SetByValBool(int LineN, int ColN, bool val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValBool(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValBool(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValBool(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValBool(val);
                    }
                }
            }
        }
        public void SetByValString(int LineN, int ColN, string val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValString(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValString(val);
                    }
                }
                else
                {
                    if (/*this.*/TblInf.Str.LC_Matrix_Not_CL_DB)//2021-03-17
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValString(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValString(val);
                    }
                }
            }
        }
        //
        public void SetByValDoubleN(int LineN, int ColN, double val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValDoubleN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValDoubleN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValDoubleN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValDoubleN(val, ValN);
                    }
                }
            }
        }
        public void SetByValFloatN(int LineN, int ColN, float val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValFloatN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValFloatN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValFloatN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValFloatN(val, ValN);
                    }
                }
            }
        }
        public void SetByValIntN(int LineN, int ColN, int val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValIntN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValIntN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValIntN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValIntN(val, ValN);
                    }
                }
            }
        }
        public void SetByValBoolN(int LineN, int ColN, bool val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValBoolN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValBoolN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValBoolN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValBoolN(val, ValN);
                    }
                }
            }
        }
        public void SetByValStringN(int LineN, int ColN, string val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValStringN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValStringN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValStringN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValStringN(val, ValN);
                    }
                }
            }
        }
        //
        public void SetVal(int LineN, int ColN, double val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetVal(val);
                    }
                }
            }
        }
        public void SetVal(int LineN, int ColN, int val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetVal(val);
                    }
                }
            }
        }
        public void SetVal(int LineN, int ColN, bool val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetVal(val);
                    }
                }
            }
        }
        public void SetVal(int LineN, int ColN, string val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetVal(val);
                    }
                }
            }
        }
        //
        public void SetValN(int LineN, int ColN, double val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetValN(val, ValN);
                    }
                }
            }
        }
        public void SetValN(int LineN, int ColN, int val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetValN(val, ValN);
                    }
                }
            }
        }
        public void SetValN(int LineN, int ColN, bool val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetValN(val, ValN);
                    }
                }
            }
        }
        public void SetValN(int LineN, int ColN, string val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetValN(val, ValN);
                    }
                }
            }
        }
        //
        public void SetByArrDouble(int LineN, int ColN, double[] val, int QVals, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByArrDouble(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByArrDouble(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByArrDouble(val, QVals);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByArrDouble(val, QVals);
                    }
                }
            }
        }
        public void SetByArrFloat(int LineN, int ColN, float[] val, int QVals, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByArrFloat(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByArrFloat(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByArrFloat(val, QVals);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByArrFloat(val, QVals);
                    }
                }
            }
        }
        public void SetByArrInt(int LineN, int ColN, int[] val, int QVals, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByArrInt(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByArrInt(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByArrInt(val, QVals);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByArrInt(val, QVals);
                    }
                }
            }
        }
        public void SetByArrBool(int LineN, int ColN, bool[] val, int QVals, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByArrBool(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByArrBool(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByArrBool(val, QVals);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByArrBool(val, QVals);
                    }
                }
            }
        }
        public void SetByArrString(int LineN, int ColN, string[] val, int QVals, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByArrString(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByArrString(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByArrString(val, QVals);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByArrString(val, QVals);
                    }
                }
            }
        }
        public void SetByArr(int LineN, int ColN, double[] val, int QVals, TableInfo TblInfExt = null)
        {
            SetByArrDouble(LineN, ColN, val, QVals, TblInfExt);
        }
        //
        public void SetByArr(int LineN, int ColN, float[] val, int QVals, TableInfo TblInfExt = null)
        {
            SetByArrFloat(LineN, ColN, val, QVals, TblInfExt);
        }
        public void SetByArr(int LineN, int ColN, int[] val, int QVals, TableInfo TblInfExt = null)
        {
            SetByArrInt(LineN, ColN, val, QVals, TblInfExt);
        }
        public void SetByArr(int LineN, int ColN, bool[] val, int QVals, TableInfo TblInfExt = null)
        {
            SetByArrBool(LineN, ColN, val, QVals, TblInfExt);
        }
        public void SetByArr(int LineN, int ColN, string[] val, int QVals, TableInfo TblInfExt = null)
        {
            SetByArrString(LineN, ColN, val, QVals, TblInfExt);
        }
        //
        public void SetValAndTypeDouble(int LineN, int ColN, double val)
        {
            int OldTypeN;
            //bool CellExists=GetIfCellExists(LineN, ColN);
            //TDataCell cell = GetCell(LineN, ColN);
            //if (cell != null)
            //if (CellExists)
            //{
                OldTypeN = GetTypeN(LineN, ColN);
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        if (OldTypeN != TableConsts.DoubleTypeN)
                        {
                            //LineOfColHeader[ColN - 1] = new TCellDouble(val);
                            SetValAndTypeDouble_LineOfColHeader(ColN, val);
                        }
                        else
                        {
                            SetByValDouble_LineOfColHeader(ColN, val);
                        }
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        if (OldTypeN != TableConsts.DoubleTypeN)
                        {
                            //ColOfLineHeader[LineN - 1] = new TCellDouble(val);
                            SetValAndTypeDouble_ColOfLineHeader(LineN, val);
                        }
                        else
                        {
                            SetByValDouble_ColOfLineHeader(ColN, val);
                        }
                    }
                }
                else
                {
                    if (OldTypeN != TableConsts.DoubleTypeN)
                    {
                        if (GetIf_LC_Matrix_Not_CL_DB()==true) 
                        {
                            //ContentCell[LineN - 1][ColN - 1] = new TCellDouble(val);
                            ContentCell[LineN - 1][ColN - 1] = new DataCell(val);
                        }
                        else
                        {
                            //ContentCell[ColN - 1][LineN - 1] = new TCellDouble(val);
                            ContentCell[ColN - 1][LineN - 1] = new DataCell(val);
                        }
                    }
                    else
                    {
                        SetByValDouble(LineN, ColN, val);
                    }
                }
            //}
        }
        public void SetValAndTypeFloat(int LineN, int ColN, float val)
        {
            //bool CellExists=GetIfCellExists(LineN, ColN);
            //TDataCell cell = GetCell(LineN, ColN);
            //if (cell != null)
            //if (CellExists)
            //{
                int OldTypeN = GetTypeN(LineN, ColN);
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        if (OldTypeN != TableConsts.FloatTypeN)
                        {
                            //LineOfColHeader[ColN - 1] = new TCellFloat(val);
                            SetValAndTypeFloat_LineOfColHeader(ColN, val);
                        }
                        else
                        {
                            SetByValFloat_LineOfColHeader(ColN, val);
                        }
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        if (OldTypeN != TableConsts.FloatTypeN)
                        {
                            //ColOfLineHeader[LineN - 1] = new TCellFloat(val);
                            SetValAndTypeFloat_ColOfLineHeader(LineN, val);
                        }
                        else
                        {
                            SetByValFloat_ColOfLineHeader(ColN, val);
                        }
                    }
                }
                else
                {
                    if (OldTypeN != TableConsts.FloatTypeN)
                    {
                        if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                        {
                            //ContentCell[LineN - 1][ColN - 1] = new TCellFloat(val);
                            ContentCell[LineN - 1][ColN - 1] = new DataCell(val);
                        }
                        else
                        {
                            //ContentCell[ColN - 1][LineN - 1] = new TCellFloat(val);
                            ContentCell[ColN - 1][LineN - 1] = new DataCell(val);
                        }
                    }
                    else
                    {
                        SetByValFloat(LineN, ColN, val);
                    }
                }
            //}
        }
        public void SetValAndTypeInt(int LineN, int ColN, int val)
        {
            int OldTypeN;
            //bool CellExists=GetIfCellExists(LineN, ColN);
            //TDataCell cell = GetCell(LineN, ColN);
            //if (cell != null)
            //if (CellExists)
            //{
                OldTypeN = GetTypeN(LineN, ColN);
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        if (OldTypeN != TableConsts.IntTypeN)
                        {
                            //LineOfColHeader[ColN - 1] = new TCellInt(val);
                            SetValAndTypeInt_LineOfColHeader(ColN, val);
                        }
                        else
                        {
                            SetByValInt_LineOfColHeader(ColN, val);
                        }
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        if (OldTypeN != TableConsts.IntTypeN)
                        {
                            //ColOfLineHeader[LineN - 1] = new TCellInt(val);
                            SetValAndTypeInt_ColOfLineHeader(LineN, val);
                        }
                        else
                        {
                            SetByValInt_ColOfLineHeader(ColN, val);
                        }
                    }
                }
                else
                {
                    if (OldTypeN != TableConsts.IntTypeN)
                    {
                        if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                        {
                            //ContentCell[LineN - 1][ColN - 1] = new TCellInt(val);
                            ContentCell[LineN - 1][ColN - 1] = new DataCell(val);
                        }
                        else
                        {
                            //ContentCell[ColN - 1][LineN - 1] = new TCellInt(val);
                            ContentCell[ColN - 1][LineN - 1] = new DataCell(val);
                        }
                    }
                    else
                    {
                        SetByValInt(LineN, ColN, val);
                    }
                }
            //}
        }
        public void SetValAndTypeBool(int LineN, int ColN, bool val)
        {
            int OldTypeN;
            //bool CellExists=GetIfCellExists(LineN, ColN);
            //TDataCell cell = GetCell(LineN, ColN);
            //if (cell != null)
            //if (CellExists)
            //{
                OldTypeN = GetTypeN(LineN, ColN);
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        if (OldTypeN != TableConsts.BoolTypeN)
                        {
                            //LineOfColHeader[ColN - 1] = new TCellBool(val);
                            SetValAndTypeBool_LineOfColHeader(ColN, val);
                        }
                        else
                        {
                            SetByValBool_LineOfColHeader(ColN, val);
                        }
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        if (OldTypeN != TableConsts.BoolTypeN)
                        {
                            //ColOfLineHeader[LineN - 1] = new TCellBool(val);
                            SetValAndTypeBool_ColOfLineHeader(LineN, val);
                        }
                        else
                        {
                            SetByValBool_ColOfLineHeader(ColN, val);
                        }
                    }
                }
                else
                {
                    if (OldTypeN != TableConsts.BoolTypeN)
                    {
                        if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                        {
                            //ContentCell[LineN - 1][ColN - 1] = new TCellBool(val);
                            ContentCell[LineN - 1][ColN - 1] = new DataCell(val);
                        }
                        else
                        {
                            //ContentCell[ColN - 1][LineN - 1] = new TCellBool(val);
                            ContentCell[ColN - 1][LineN - 1] = new DataCell(val);
                        }
                    }
                    else
                    {
                        SetByValBool(LineN, ColN, val);
                    }
                }
            //}
        }
        public void SetValAndTypeString(int LineN, int ColN, string val)
        {
            int OldTypeN;
            //bool CellExists=GetIfCellExists(LineN, ColN);
            //TDataCell cell = GetCell(LineN, ColN);
            //if (cell != null)
            //if (CellExists)
            //{
                OldTypeN = GetTypeN(LineN, ColN);
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        if (OldTypeN != TableConsts.StringTypeN)
                        {
                            //LineOfColHeader[ColN - 1] = new TCellString(val);
                            SetValAndTypeString_LineOfColHeader(ColN, val);
                        }
                        else
                        {
                            SetByValString_LineOfColHeader(ColN, val);
                        }
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        if (OldTypeN != TableConsts.StringTypeN)
                        {
                            //ColOfLineHeader[LineN - 1] = new TCellString(val);
                            SetValAndTypeString_ColOfLineHeader(LineN, val);
                        }
                        else
                        {
                            SetByValString_ColOfLineHeader(ColN, val);
                        }
                    }
                }
                else
                {
                    if (OldTypeN != TableConsts.StringTypeN)
                    {
                        if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                        {
                            //ContentCell[LineN - 1][ColN - 1] = new TCellString(val);
                            ContentCell[LineN - 1][ColN - 1] = new DataCell(val);
                        }
                        else
                        {
                            //ContentCell[ColN - 1][LineN - 1] = new TCellString(val);
                            ContentCell[ColN - 1][LineN - 1] = new DataCell(val);
                        }
                    }
                    else
                    {
                        SetByValString(LineN, ColN, val);
                    }
                }
            //}
        }
        //
        public void SetArrayAndTypeDouble(int LineN, int ColN, int QVals, double[] val)
        {
            //bool CellExists=GetIfCellExists(LineN, ColN);
            //TDataCell cell = GetCell(LineN, ColN);
            //if (cell != null)
            //if (CellExists)
            //{
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellDoubleMemo(val, QVals);
                        LineOfColHeader[ColN - 1] = new DataCell(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellDoubleMemo(val, QVals);
                        ColOfLineHeader[LineN - 1] = new DataCell(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellDoubleMemo(val, QVals);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val, QVals);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellDoubleMemo(val, QVals);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val, QVals);
                    }
                }
            //}
        }
        //mark8
        public void SetArrayAndTypeFloat(int LineN, int ColN, int QVals, float[] val)
        {
            //bool CellExists=GetIfCellExists(LineN, ColN);
            //TDataCell cell = GetCell(LineN, ColN);
            //if (cell != null)
            //if (CellExists)
            //{
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellFloatMemo(val, QVals);
                        LineOfColHeader[ColN - 1] = new DataCell(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellFloatMemo(val, QVals);
                        ColOfLineHeader[LineN - 1] = new DataCell(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellFloatMemo(val, QVals);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val, QVals);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellFloatMemo(val, QVals);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val, QVals);
                    }
                }
            //}
        }
        public void SetArrayAndTypeInt(int LineN, int ColN, int QVals, int[] val)
        {
            //bool CellExists=GetIfCellExists(LineN, ColN);
            //TDataCell cell = GetCell(LineN, ColN);
            //if (cell != null)
            //if (CellExists)
            //{
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellIntMemo(val, QVals);
                        LineOfColHeader[ColN - 1] = new DataCell(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellIntMemo(val, QVals);
                        ColOfLineHeader[LineN - 1] = new DataCell(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellIntMemo(val, QVals);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val, QVals);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellIntMemo(val, QVals);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val, QVals);
                    }
                }
            //}
        }
        public void SetArrayAndTypeBool(int LineN, int ColN, int QVals, bool[] val)
        {
            //bool CellExists=GetIfCellExists(LineN, ColN);
            //TDataCell cell = GetCell(LineN, ColN);
            //if (cell != null)
            //if (CellExists)
            //{
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellBoolMemo(val, QVals);
                        LineOfColHeader[ColN - 1] = new DataCell(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellBoolMemo(val, QVals);
                        ColOfLineHeader[LineN - 1] = new DataCell(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellBoolMemo(val, QVals);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val, QVals);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellBoolMemo(val, QVals);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val, QVals);
                    }
                }
            //}
        }
        public void SetArrayAndTypeString(int LineN, int ColN, int QVals, string[] val)
        {
            //bool CellExists=GetIfCellExists(LineN, ColN);
            //TDataCell cell = GetCell(LineN, ColN);
            //if (cell != null)
            //if (CellExists)
            //{
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellStringMemo(val, QVals);
                        LineOfColHeader[ColN - 1] = new DataCell(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellStringMemo(val, QVals);
                        ColOfLineHeader[LineN - 1] = new DataCell(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellStringMemo(val, QVals);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val, QVals);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellStringMemo(val, QVals);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val, QVals);
                    }
                }
            //}
        }
        //
        public void SetUniqueIntValAndType(int LineN, int ColN, int val)
        {
            //bool CellExists=GetIfCellExists(LineN, ColN);
            //TDataCell cell = GetCell(LineN, ColN);
            //if (cell != null)
            //if (CellExists)
            //{
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new  TCellUniqueNumKeeper(val);
                        LineOfColHeader[ColN - 1] = new DataCell(val, true);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellUniqueNumKeeper(val);
                        ColOfLineHeader[LineN - 1] = new DataCell(val, true);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellUniqueNumKeeper(val);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val, true);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellUniqueNumKeeper(val);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val, true);
                    }
                }
            //}
        }
        //
        //-------------------------------------------------------------------
        public double GetDoubleVal_ColOfLineHeader(int LineN, TableInfo TblInfExt=null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            double dr;
            dr = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                dr = cell.GetDoubleVal();
            }
            return dr;
        }
        public float GetFloatVal_ColOfLineHeader(int LineN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN = 0;
            float fr;
            fr = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                fr = cell.GetFloatVal();
            }
            return fr;
        }
        public int GetIntVal_ColOfLineHeader(int LineN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            int ir;
            ir = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                ir = cell.GetIntVal();
            }
            return ir;
        }
        public bool GetBoolVal_ColOfLineHeader(int LineN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN = 0;
            bool br;
            br = false;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                br = cell.GetBoolVal();
            }
            return br;
        }
        public string ToString_ColOfLineHeader(int LineN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            string sr;
            sr = "";
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                sr = cell.ToString();
            }
            return sr;
        }
        //
        public double GetDoubleValN_ColOfLineHeader(int LineN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN = 0;
            int ValN = 0;
            double dr;
            dr = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                dr = cell.GetDoubleValN(ValN);
            }
            return dr;
        }
        public float GetFloatValN_ColOfLineHeader(int LineN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN = 0;
            float fr;
            fr = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                fr = cell.GetFloatValN(ValN);
            }
            return fr;
        }
        public int GetIntValN_ColOfLineHeader(int LineN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            int ir;
            ir = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                ir = cell.GetIntValN(ValN);
            }
            return ir;
        }
        public bool GetBoolValN_ColOfLineHeader(int LineN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            bool br;
            br = false;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                br = cell.GetBoolValN(ValN);
            }
            return br;
        }
        public string ToStringN_ColOfLineHeader(int LineN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            string sr;
            sr = "";
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                sr = cell.ToString();
            }
            return sr;
        }
        //
        public void SetByValDouble_ColOfLineHeader(int LineN, double val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValDouble(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValDouble(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValDouble(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValDouble(val);
                    }
                }
            }
        }
        public void SetByValFloat_ColOfLineHeader(int LineN, float val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValFloat(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValFloat(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValFloat(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValFloat(val);
                    }
                }
            }
        }
        public void SetByValInt_ColOfLineHeader(int LineN, int val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValInt(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValInt(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValInt(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValInt(val);
                    }
                }
            }
        }
        public void SetByValBool_ColOfLineHeader(int LineN, bool val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValBool(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValBool(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValBool(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValBool(val);
                    }
                }
            }
        }
        public void SetByValString_ColOfLineHeader(int LineN, string val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValString(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValString(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValString(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValString(val);
                    }
                }
            }
        }
        //
        public void SetByValDoubleN_ColOfLineHeader(int LineN, double val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValDoubleN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValDoubleN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValDoubleN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValDoubleN(val, ValN);
                    }
                }
            }
        }
        public void SetByValFloatN_ColOfLineHeader(int LineN, float val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValFloatN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValFloatN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValFloatN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValFloatN(val, ValN);
                    }
                }
            }
        }
        public void SetByValIntN_ColOfLineHeader(int LineN, int val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByValIntN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByValIntN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByValIntN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByValIntN(val, ValN);
                    }
                }
            }
        }
        public void SetByValBoolN_ColOfLineHeader(int LineN, bool val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (ColN >= 1 && ColN <= GetQColumns())
                {
                    LineOfColHeader[ColN - 1].SetByValBoolN(val, ValN);
                }
            }
        }
        public void SetByValStringN_ColOfLineHeader(int LineN, string val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (ColN >=1 && ColN<=GetQColumns())
                {
                    LineOfColHeader[ColN - 1].SetByValStringN(val, ValN);
                }
            }
        }
        //
        public void SetVal_ColOfLineHeader(int LineN, double val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetVal(val);
                    }
                }
            }
        }
        public void SetVal_ColOfLineHeader(int LineN, int val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetVal(val);
                    }
                }
            }
        }
        public void SetVal_ColOfLineHeader(int LineN, bool val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetVal(val);
                    }
                }
            }
        }
        public void SetVal_ColOfLineHeader(int LineN, string val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetVal(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetVal(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetVal(val);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetVal(val);
                    }
                }
            }
        }
        //
        public void SetValN_ColOfLineHeader(int LineN, double val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetValN(val, ValN);
                    }
                }
            }
        }
        public void SetValN_ColOfLineHeader(int LineN, int val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetValN(val, ValN);
                    }
                }
            }
        }
        public void SetValN_ColOfLineHeader(int LineN, bool val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetValN(val, ValN);
                    }
                }
            }
        }
        public void SetValN_ColOfLineHeader(int LineN, string val, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetValN(val, ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetValN(val, ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetValN(val, ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetValN(val, ValN);
                    }
                }
            }
        }
        //
        public void SetByArrDouble_ColOfLineHeader(int LineN, double[] val, int QVals, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByArrDouble(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByArrDouble(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByArrDouble(val, QVals);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByArrDouble(val, QVals);
                    }
                }
            }
        }
        public void SetByArrFloat_ColOfLineHeader(int LineN, float[] val, int QVals, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByArrFloat(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByArrFloat(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByArrFloat(val, QVals);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByArrFloat(val, QVals);
                    }
                }
            }
        }
        public void SetByArrInt_ColOfLineHeader(int LineN, int[] val, int QVals, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByArrInt(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByArrInt(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByArrInt(val, QVals);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByArrInt(val, QVals);
                    }
                }
            }
        }
        public void SetByArrBool_ColOfLineHeader(int LineN, bool[] val, int QVals, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByArrBool(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByArrBool(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByArrBool(val, QVals);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByArrBool(val, QVals);
                    }
                }
            }
        }
        public void SetByArrString_ColOfLineHeader(int LineN, string[] val, int QVals, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].SetByArrString(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].SetByArrString(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].SetByArrString(val, QVals);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].SetByArrString(val, QVals);
                    }
                }
            }
        }
        public void SetByArr_ColOfLineHeader(int LineN, double[] val, int QVals, TableInfo TblInfExt = null)
        {
            int ColN = 0;
            SetByArrDouble(LineN, ColN, val, QVals, TblInfExt);
        }
        //
        public void SetByArr_ColOfLineHeader(int LineN, float[] val, int QVals, TableInfo TblInfExt = null)
        {
            int ColN=0;
            SetByArrFloat(LineN, ColN, val, QVals, TblInfExt);
        }
        public void SetByArr_ColOfLineHeader(int LineN, int[] val, int QVals, TableInfo TblInfExt = null)
        {
            int ColN=0;
            SetByArrInt(LineN, ColN, val, QVals, TblInfExt);
        }
        public void SetByArr_ColOfLineHeader(int LineN, bool[] val, int QVals, TableInfo TblInfExt = null)
        {
            int ColN = 0;
            SetByArrBool(LineN, ColN, val, QVals, TblInfExt);
        }
        public void SetByArr_ColOfLineHeader(int LineN, string[] val, int QVals, TableInfo TblInfExt = null)
        {
            int ColN = 0;
            SetByArrString(LineN, ColN, val, QVals, TblInfExt);
        }
        //mark9
        public void SetValAndTypeDouble_ColOfLineHeader(int LineN, double val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellDouble(val);
                        LineOfColHeader[ColN - 1] = new DataCell(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellDouble(val);
                        ColOfLineHeader[LineN - 1] = new DataCell(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellDouble(val);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellDouble(val);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val);
                    }
                }
            }
        }
        public void SetValAndTypeFloat_ColOfLineHeader(int LineN, float val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellFloat(val);
                        LineOfColHeader[ColN - 1] = new DataCell(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellFloat(val);
                        ColOfLineHeader[LineN - 1] = new DataCell(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellFloat(val);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellFloat(val);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val);
                    }
                }
            }
        }
        public void SetValAndTypeInt_ColOfLineHeader(int LineN, int val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellInt(val);
                        LineOfColHeader[ColN - 1] = new DataCell(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellInt(val);
                        ColOfLineHeader[LineN - 1] = new DataCell(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellInt(val);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellInt(val);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val);
                    }
                }
            }
        }
        public void SetValAndTypeBool_ColOfLineHeader(int LineN, bool val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellBool(val);
                        LineOfColHeader[ColN - 1] = new DataCell(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellBool(val);
                        ColOfLineHeader[LineN - 1] = new DataCell(val);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ontentCell[LineN - 1][ColN - 1] = new TCellBool(val);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellBool(val);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val);
                    }
                }
            }
        }
        public void SetValAndTypeString_ColOfLineHeader(int LineN, string val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellString(val);
                        LineOfColHeader[ColN - 1] = new DataCell(val);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellString(val);
                        ColOfLineHeader[LineN - 1] = new DataCell(val);
                    }
                }
                //else
                //{
                //    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                //    {
                //        ContentCell[LineN - 1][ColN - 1] = new TCellString(val);
                //    }
                //    else
                //    {
                //        ContentCell[ColN - 1][LineN - 1] = new TCellString(val);
                //    }
                //}
            }
        }
        public void SetArrayAndTypeDouble_ColOfLineHeader(int LineN, int QVals, double[] val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellDoubleMemo(val, QVals);
                        LineOfColHeader[ColN - 1] = new DataCell(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellDoubleMemo(val, QVals);
                        ColOfLineHeader[LineN - 1] = new DataCell(val, QVals);
                    }
                }
                //else
                //{
                //    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                //    {
                //        ContentCell[LineN - 1][ColN - 1] = new TCellDoubleMemo(val, QVals);
                //    }
                //    else
                //    {
                //        ContentCell[ColN - 1][LineN - 1] = new TCellDoubleMemo(val, QVals);
                //    }
                //}
            }
        }
        public void SetArrayAndTypeFloat_ColOfLineHeader(int LineN, int QVals, float[] val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellFloatMemo(val, QVals);
                        LineOfColHeader[ColN - 1] = new DataCell(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellFloatMemo(val, QVals);
                        ColOfLineHeader[LineN - 1] = new DataCell(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellFloatMemo(val, QVals);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val, QVals);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellFloatMemo(val, QVals);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val, QVals);
                    }
                }
            }
        }
        public void SetArrayAndTypeInt_ColOfLineHeader(int LineN, int QVals, int[] val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellIntMemo(val, QVals);
                        LineOfColHeader[ColN - 1] = new DataCell(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellIntMemo(val, QVals);
                        ColOfLineHeader[LineN - 1] = new DataCell(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellIntMemo(val, QVals);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val, QVals);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellIntMemo(val, QVals);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val, QVals);
                    }
                }
            }
        }
        public void SetArrayAndTypeBool_ColOfLineHeader(int LineN, int QVals, bool[] val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellBoolMemo(val, QVals);
                        LineOfColHeader[ColN - 1] = new DataCell(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellBoolMemo(val, QVals);
                        ColOfLineHeader[LineN - 1] = new DataCell(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellBoolMemo(val, QVals);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val, QVals);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellBoolMemo(val, QVals);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val, QVals);
                    }
                }
            }
        }
        public void SetArrayAndTypeString_ColOfLineHeader(int LineN, int QVals, string[] val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellStringMemo(val, QVals);
                        LineOfColHeader[ColN - 1] = new DataCell(val, QVals);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellStringMemo(val, QVals);
                        ColOfLineHeader[LineN - 1] = new DataCell(val, QVals);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellStringMemo(val, QVals);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val, QVals);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellStringMemo(val, QVals);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val, QVals);
                    }
                }
            }
        }
        //
        public void SetUniqueIntValAndType_ColOfLineHeader(int LineN, int val, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int ColN=0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        //LineOfColHeader[ColN - 1] = new TCellUniqueNumKeeper(val);
                        LineOfColHeader[ColN - 1] = new DataCell(val, true);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        //ColOfLineHeader[LineN - 1] = new TCellUniqueNumKeeper(val);
                        ColOfLineHeader[LineN - 1] = new DataCell(val, true);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        //ContentCell[LineN - 1][ColN - 1] = new TCellUniqueNumKeeper(val);
                        ContentCell[LineN - 1][ColN - 1] = new DataCell(val, true);
                    }
                    else
                    {
                        //ContentCell[ColN - 1][LineN - 1] = new TCellUniqueNumKeeper(val);
                        ContentCell[ColN - 1][LineN - 1] = new DataCell(val, true);
                    }
                }
            }
        }
        //
        //-------------------------------------------------------------------
        public double GetDoubleVal_LineOfColHeader(int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int LineN=0;
            double dr;
            dr = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                dr = cell.GetDoubleVal();
            }
            return dr;
        }
        public float GetFloatVal_LineOfColHeader(int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int LineN=0;
            float fr;
            fr = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                fr = cell.GetFloatVal();
            }
            return fr;
        }
        public int GetIntVal_LineOfColHeader(int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int LineN=0;
            int ir;
            ir = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                ir = cell.GetIntVal();
            }
            return ir;
        }
        public bool GetBoolVal_LineOfColHeader(int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int LineN=0;
            bool br;
            br = false;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                br = cell.GetBoolVal();
            }
            return br;
        }
        public string ToString_LineOfColHeader(int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int LineN=0;
            string sr;
            sr = "";
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                sr = cell.ToString();
            }
            return sr;
        }
        //
        public double GetDoubleValN_LineOfColHeader(int ColN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int LineN=0;
            int ValN = 0;
            double dr;
            dr = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                dr = cell.GetDoubleValN(ValN);
            }
            return dr;
        }
        public float GetFloatValN_LineOfColHeader(int ColN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int LineN=0;
            float fr;
            fr = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                fr = cell.GetFloatValN(ValN);
            }
            return fr;
        }
        public int GetIntValN_LineOfColHeader(int ColN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int LineN=0;
            int ir;
            ir = 0;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                ir = cell.GetIntValN(ValN);
            }
            return ir;
        }
        public bool GetBoolValN_LineOfColHeader(int ColN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int LineN=0;
            bool br;
            br = false;
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                br = cell.GetBoolValN(ValN);
            }
            return br;
        }
        public string ToStringN_LineOfColHeader(int ColN, int ValN, TableInfo TblInfExt=null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int LineN=0;
            string sr;
            sr = "";
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                sr = cell.ToString();
            }
            return sr;
        }
        //
        public void SetByValDouble_LineOfColHeader(int ColN, double val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetByValDouble(val);
            }
        }
        public void SetByValFloat_LineOfColHeader(int ColN, float val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetByValFloat(val);
            }
        }
        public void SetByValInt_LineOfColHeader(int ColN, int val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetByValInt(val);
            }
        }
        public void SetByValBool_LineOfColHeader(int ColN, bool val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetByValBool(val);
            }
        }
        public void SetByValString_LineOfColHeader(int ColN, string val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetByValString(val);
            }
        }
        //
        public void SetByValDoubleN_LineOfColHeader(int ColN, double val, int ValN)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetByValDoubleN(val, ValN);
            }
        }
        public void SetByValFloatN_LineOfColHeader(int ColN, float val, int ValN)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetByValFloatN(val, ValN);
            }
        }
        public void SetByValIntN_LineOfColHeader(int ColN, int val, int ValN)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetByValIntN(val, ValN);
            }
        }
        public void SetByValBoolN_LineOfColHeader(int ColN, bool val, int ValN)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetByValBoolN(val, ValN);
            }
        }
        public void SetByValStringN_LineOfColHeader(int ColN, string val, int ValN)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetByValStringN(val, ValN);
            }
        }
        //
        public void SetVal_LineOfColHeader(int ColN, double val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetVal(val);
            }
        }
        public void SetVal_LineOfColHeader(int ColN, int val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetVal(val);
            }
        }
        public void SetVal_LineOfColHeader(int ColN, bool val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetVal(val);
            }
        }
        public void SetVal_LineOfColHeader(int ColN, string val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetVal(val);
            }
        }
        //
        public void SetValN_LineOfColHeader(int ColN, double val, int ValN)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetValN(val, ValN);
            }
        }
        public void SetValN_LineOfColHeader(int ColN, int val, int ValN)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetValN(val, ValN);
            }
        }
        public void SetValN_LineOfColHeader(int ColN, bool val, int ValN)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetValN(val, ValN);
            }
        }
        public void SetValN_LineOfColHeader(int ColN, string val, int ValN)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetValN(val, ValN);
            }
        }
        //
        public void SetByArrDouble_LineOfColHeader(int ColN, double[] val, int QVals)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeDouble(val, QVals);
            }
        }
        public void SetByArrFloat_LineOfColHeader(int ColN, float[] val, int QVals)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeFloat(val, QVals);
            }
        }
        public void SetByArrInt_LineOfColHeader(int ColN, int[] val, int QVals)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeInt(val, QVals);
            }
        }
        public void SetByArrBool_LineOfColHeader(int ColN, bool[] val, int QVals)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeBool(val, QVals);
            }
        }
        public void SetByArrString_LineOfColHeader(int ColN, string[] val, int QVals)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeString(val, QVals);
            }
        }
        //
        public void SetByArr_LineOfColHeader(int ColN, double[] val, int QVals)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeDouble(val, QVals);
            }
        }
        public void SetByArr_LineOfColHeader(int ColN, float[] val, int QVals)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeFloat(val, QVals);
            }
        }
        public void SetByArr_LineOfColHeader(int ColN, int[] val, int QVals)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeInt(val, QVals);
            }
        }
        public void SetByArr_LineOfColHeader(int ColN, bool[] val, int QVals)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeBool(val, QVals);
            }
        }
        public void SetByArr_LineOfColHeader(int ColN, string[] val, int QVals)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeString(val, QVals);
            }
        }
        //
        public void SetValAndTypeDouble_LineOfColHeader(int ColN, double val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetValAndTypeDouble(val);
            }
        }
        public void SetValAndTypeFloat_LineOfColHeader(int ColN, float val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetValAndTypeFloat(val);
            }
        }
        public void SetValAndTypeInt_LineOfColHeader(int ColN, int val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetValAndTypeInt(val);
            }
        }
        public void SetValAndTypeBool_LineOfColHeader(int ColN, bool val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetValAndTypeBool(val);
            }
        }
        public void SetValAndTypeString_LineOfColHeader(int ColN, string val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetValAndTypeString(val);
            }
        }
        public void SetArrayAndTypeDouble_LineOfColHeader(int ColN, int QVals, double[] val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeDouble(val, QVals);
            }
        }
        public void SetArrayAndTypeFloat_LineOfColHeader(int ColN, int QVals, float[] val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeFloat(val, QVals);
            }
        }
        public void SetArrayAndTypeInt_LineOfColHeader(int ColN, int QVals, int[] val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeInt(val, QVals);
            }
        }
        public void SetArrayAndTypeBool_LineOfColHeader(int ColN, int QVals, bool[] val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeBool(val, QVals);
            }
        }
        public void SetArrayAndTypeString_LineOfColHeader(int ColN, int QVals, string[] val)
        {
            if (ColN != 0)
            {
                if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
                LineOfColHeader[ColN - 1].SetArrAndTypeString(val, QVals);
            }
        }
        //
        //public void SetUniqueIntValAndType_LineOfColHeader(int ColN, int val)
        //{
        //    if (ColN != 0)
        //    {
        //        if (LineOfColHeader[ColN - 1] != null) LineOfColHeader[ColN - 1] = new DataCell();
        //        LineOfColHeader[ColN - 1].SetValAndTypeUniqueIntNumKeeper(ColN);
        //    }
        //}
        //-------------------------------------------------------------------------------------
        //
        //
        public void DelValN(int LineN, int ColN, int ValN, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0)
                {
                    if (ColN != 0)
                    {
                        LineOfColHeader[ColN - 1].DelValN(ValN);
                    }
                }
                else if (ColN == 0)
                {
                    if (LineN != 0)
                    {
                        ColOfLineHeader[LineN - 1].DelValN(ValN);
                    }
                }
                else
                {
                    if (this.TblInf.Str.LC_Matrix_Not_CL_DB)
                    {
                        ContentCell[LineN - 1][ColN - 1].DelValN(ValN);
                    }
                    else
                    {
                        ContentCell[ColN - 1][LineN - 1].DelValN(ValN);
                    }
                }
            }
        }
        //
        // Get As string And Show---------------------------------------------------------------------------------------------------------
        //mark10
        public int GetMaxLength(TableInfo TblInfExt=null){
            int curL, maxL, QL, QC, ErstLN, ErstCN;
            DataCell cell;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            QL = TblInf.GetQLines(); QC = TblInf.GetQColumns();
            cell = GetCell(1 - 1, 1 - 1, TblInf.GetTableInfo_ConcrRepr());
            maxL=(cell.ToString()).Length;
            if(GetIfLineOfColHeaderExists()==true && GetIfColOfLineHeaderExists()==true){
                ErstLN=0; ErstCN=0;
            }else if(GetIfLineOfColHeaderExists()==true && GetIfColOfLineHeaderExists()==false){
                ErstLN=0; ErstCN=1;
            }else if(GetIfLineOfColHeaderExists()==false && GetIfColOfLineHeaderExists()==true){
                ErstLN=1; ErstCN=0;
            }else{
                 ErstLN=1; ErstCN=1;
            }
            for(int i=ErstLN; i<=QL; i++){
                for(int j=ErstCN; j<=QC; j++){
                    cell = GetCell(i, j, TblInf.GetTableInfo_ConcrRepr());
                    curL=(cell.ToString()).Length;
                    if(curL>maxL) maxL=curL;
                }
            }
            return maxL;
        }
        private void GetMaxColLength(ref int[] ColMaxL, ref int ErstCN, ref int QColumns, TableInfo TblInfExt=null){
            int curL, maxL, QL, ErstLN;//, QC, ErstCN;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell;
            QL=GetQLines(); QColumns=GetQColumns();
            ColMaxL=new int[QColumns+1];
            if(GetIfLineOfColHeaderExists()==true && GetIfColOfLineHeaderExists()==true){
                ErstLN=0; ErstCN=0;
            }else if(GetIfLineOfColHeaderExists()==true && GetIfColOfLineHeaderExists()==false){
                ErstLN=0; ErstCN=1;
                ColMaxL[0]=0;
            }else if(GetIfLineOfColHeaderExists()==false && GetIfColOfLineHeaderExists()==true){
                ErstLN=1; ErstCN=0;
            }else{
                ErstLN=1; ErstCN=1;
                ColMaxL[0]=0;
            }
            for(int j=ErstCN; j<=QColumns; j++){
                cell = GetCell(1 - 1, j, TblInf.GetTableInfo_ConcrRepr());
                maxL=(cell.ToString()).Length;
                for(int i=ErstLN; i<=QL; i++){
                    cell = GetCell(i, j, TblInf.GetTableInfo_ConcrRepr());
                    curL=(cell.ToString()).Length;
                    if(curL>maxL) maxL=curL;
                }
                ColMaxL[j]=maxL;
            }
        }
        public int GetMaxLengthOfColN(int N)
        {
            int[] ColMaxL=null;
            int ErstCN=-1, QColumns=0, R=0;
            GetMaxColLength(ref ColMaxL, ref ErstCN, ref QColumns);
            if (ErstCN == 0)
            {
                R = ColMaxL[0];
            }
            return R;
        }
        //
        //
        public string GetCorner_Only(TableInfo TblInfExt=null)
        {
            TableInfo TblInf=Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            string s, LinesGenerslName = GetLinesGeneralName(), ColsGeneralName = GetColumnsGeneralName();
            s = "";
            bool LineOfColHeaderExists = TblInf.GetIf_LoCHExists();//GetIfLineOfColHeaderExists();
            bool ColOfLineHeaderExists = TblInf.GetIf_CoLHExists();//GetIfColOfLineHeaderExists();
            //bool ColOfLineHeaderExists = //GetIfColOfLineHeaderExists();
            bool LinesGeneralNameExists = GetIfLineOfColHeaderExists();
            bool ColsGeneralNameExists = GetIfColOfLineHeaderExists();
            string LinesGeneralName = GetLinesGeneralName();
            string ColumnsGeneralName = GetColumnsGeneralName();
            //
            if (LineOfColHeaderExists == true || ColOfLineHeaderExists == true)
            {
                if (LinesGeneralName != null && LinesGeneralName != "" && ColsGeneralName != null && ColsGeneralName != "")
                {
                    s = s + GetLinesGeneralName() + "\\" + GetColumnsGeneralName();
                }
                else
                {
                    if (LinesGeneralName != null && LinesGeneralName != "") s = s + GetLinesGeneralName();
                    if (ColsGeneralName != null && ColsGeneralName != "") s = s + GetColumnsGeneralName();
                }
            }
            return s;
        }
        public string GetCorner(/*TableGeneralRepresentation GenReprExt*/TableInfo TblInfExt=null, int ReprPrior_Any0Grid1Text2=2)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            //TableGeneralRepresentation GenRepr;
            string s = GetCorner_Only();
            //if (GenReprExt != null) GenRepr = GenReprExt;
            //else if (TblInf != null && TblInf.Repr != null && TblInf.Repr.GenRepr != null) GenRepr = TblInf.Repr.GenRepr;
            //else GenRepr = new TableGeneralRepresentation();
            if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 2)
            {
                if (GetIfColOfLineHeaderExists() == false && TblInf.Repr_Text.dets.GenRepr.ShowColOfLineHeader == false && GetIfLineOfColHeaderExists() == true)
                {
                    s = s + ": " + ToString_LineOfColHeader(1);
                }
                if (GetIfLineOfColHeaderExists() == false && TblInf.Repr_Text.dets.GenRepr.ShowLineOfColHeader == false && GetIfColOfLineHeaderExists() == true)
                {
                    s = s + ": " + ToString_ColOfLineHeader(1);
                }
                if (GetIfLineOfColHeaderExists() == false && GetIfColOfLineHeaderExists() == false && TblInf.Repr_Text.dets.GenRepr.ShowColOfLineHeader == false && TblInf.Repr_Text.dets.GenRepr.ShowLineOfColHeader == false)
                {
                    s = s + ": ";
                    s = s + ToString(1, 1);
                }
            }
            //
            if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 1){
                if (GetIfColOfLineHeaderExists() == false && TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader == false && GetIfLineOfColHeaderExists() == true)
                {
                    s = s + ": " + ToString_LineOfColHeader(1);
                }
                if (GetIfLineOfColHeaderExists() == false && TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader == false && GetIfColOfLineHeaderExists() == true)
                {
                    s = s + ": " + ToString_ColOfLineHeader(1);
                }
                if (GetIfLineOfColHeaderExists() == false && GetIfColOfLineHeaderExists() == false && TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader == false && TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader == false)
                {
                    s = s + ": ";
                    s = s + ToString(1, 1);
                }
            }
            //
            return s;
        }
        public string GetCornerOnlyCoSupplInf(TableInfo TblInfExt, int ReprPrior_Any0Grid1Text2 = 2)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            string smain, sFullInf = "";
            int L, n;
            smain = GetCorner_Only();
            if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 2)
            {
                if (TblInf.Repr_Text.dets.GenRepr.ShowTableNameInCorner)
                {
                    sFullInf = GetTableHeaderName() + ": " + smain;
                }
                else
                {
                    sFullInf = smain;
                }
            }
            if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 1)
            {
                if (TblInf.Repr_Grid.dets.GenRepr.ShowTableNameInCorner)
                {
                    sFullInf = GetTableHeaderName() + ": " + smain;
                }
                else
                {
                    sFullInf = smain;
                }
            }
            return sFullInf;
        }
        public string GetCornerCoSupplInf(TableInfo TblInfExt, int ReprPrior_Any0Grid1Text2 = 2)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            string smain, sFullInf="";
            int L, n;
            //smain = GetCorner(TblInf.Repr.GenRepr);
            smain = GetCorner(TblInf);
            if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 2)
            {
                if (TblInf.Repr_Text.dets.GenRepr.ShowTableNameInCorner)
                {
                    sFullInf = GetTableHeaderName() + ": " + smain;
                }
                else
                {
                    sFullInf = smain;
                }
            }
            if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 1)
            {
                if (TblInf.Repr_Grid.dets.GenRepr.ShowTableNameInCorner)
                {
                    sFullInf = GetTableHeaderName() + ": " + smain;
                }
                else
                {
                    sFullInf = smain;
                }
            }
            return sFullInf;
        }
        public string GetCornerCoSupplInfAndFmt(TableInfo TblInfExt, StringShaublin StrSampleExt, int ReprPrior_Any0Grid1Text2=2)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            StringShaublin StrSample;
            string smain, sFullInf, s_FmtFin = "";
            int L=0, n;
            if (StrSampleExt != null) StrSample = StrSampleExt; else StrSample = new StringShaublin();
            //smain = GetCorner(TblInf.Repr.GenRepr);
            smain = GetCorner(TblInf);
            sFullInf = GetCornerCoSupplInf(TblInfExt);
            if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 2)
            {
                switch (TblInf.Repr_Text.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3)
                {
                    case 0:
                        L = sFullInf.Length;
                        s_FmtFin = sFullInf;
                        break;
                    case 1:
                        L = TblInf.Repr_Text.dets.GenRepr.LRecom;
                        StrSampleExt.SetLength(L);
                        s_FmtFin = MyLib.ReturnByShaublin(sFullInf, StrSampleExt);
                        break;
                    case 2:
                        StrSampleExt.SetLength(L);
                        s_FmtFin = MyLib.ReturnByShaublin(sFullInf, StrSampleExt);
                        break;
                    case 3:
                        L = GetMaxLength();
                        StrSampleExt.SetLength(L);
                        s_FmtFin = MyLib.ReturnByShaublin(sFullInf, StrSampleExt);
                        break;
                }//switch
            }//if
            if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 1)
            {
                switch (TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3)
                {
                    case 0:
                        L = sFullInf.Length;
                        s_FmtFin = sFullInf;
                        break;
                    case 1:
                        L = TblInf.Repr_Grid.dets.GenRepr.LRecom;
                        StrSampleExt.SetLength(L);
                        s_FmtFin = MyLib.ReturnByShaublin(sFullInf, StrSampleExt);
                        break;
                    case 2:
                        StrSampleExt.SetLength(L);
                        s_FmtFin = MyLib.ReturnByShaublin(sFullInf, StrSampleExt);
                        break;
                    case 3:
                        L = GetMaxLength();
                        StrSampleExt.SetLength(L);
                        s_FmtFin = MyLib.ReturnByShaublin(sFullInf, StrSampleExt);
                        break;
                }//switch
            }//if
            return s_FmtFin;
        }
        //
        //
        public string GetLineHeaderCellAsString(int N, TableInfo TblInfExt=null, int ReprPrior_Any0Grid1Text2=2)
        {
            string s = "";
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            if (GetIfCellExists_ColOfLineHeader(N, TblInf))
            {
                s = ColOfLineHeader[N - 1].ToString();
            }
            return s;
        }
        public string GetLineHeaderCellCoSupplInfAsString(int N, TableInfo TblInfExt=null, int ReprPrior_Any0Grid1Text2=2)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            TRowsNumeration num = TblInf.GetRowsNumeration_OrCreateDefault();
            string s, s_ownVal;
            //s.Split(";");
            //DataCell cell;
            //cell = GetCell_ColOfLineHeader(N);
            s = "";
            //if (cell != null)
            //if (GetIfCellExists_ColOfLineHeader(N, null))
            int NN = TblInf.CalcNumNOfLineNatN(N, num);
            if (N > 0 && N <= TblInf.GetQLines())
            {
                //s_ownVal = cell.ToString();
                s_ownVal = GetLineHeaderCellAsString(N, TblInfExt);
                //
                if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 2){
                    switch (TblInf.Repr_Text.dets.LineHeaderRepr.Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7)
                    {
                        case 1:
                            s = s + " - ";
                        break;
                        case 2:
                            s = s + " : ";
                        break;
                        case 3:
                            s = s + " , ";
                        break;
                        case 4:
                            s = s + " = ";
                        break;
                        case 5:
                            s = s + " Row ";
                        break;
                        case 6:
                            s = s + " Line ";
                        break;
                        case 7:
                            s = s + " Col ";
                        break;
                    }
                    if (TblInf.Repr_Text.dets.LineHeaderRepr.InBrackets) s = s + "(";
                    if (TblInf.Repr_Text.dets.LineHeaderRepr.GenRowNameBef)
                    {
                        switch (TblInf.Repr_Text.dets.LineHeaderRepr.BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7)
                        {
                            case 1:
                                s = s + " ";
                                break;
                            case 2:
                                s = s + ", ";
                                break;
                            case 3:
                                s = s + ": ";
                                break;
                            case 4:
                                s = s + "; ";
                            break;
                            case 5:
                                s = s + "= ";
                            break;
                            case 6:
                                s = s + "- ";
                            break;
                            case 7:
                                s = s + ") ";
                            break;
                        }
                        //
                        s = s + GetLinesGeneralName();
                        //
                        switch (TblInf.Repr_Text.dets.LineHeaderRepr.AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7)
                        {
                            case 1:
                                s = s + " ";
                            break;
                            case 2:
                                s = s + ", ";
                            break;
                            case 3:
                                s = s + ": ";
                            break;
                            case 4:
                                s = s + "; ";
                            break;
                            case 5:
                                s = s + "= ";
                            break;
                            case 6:
                                s = s + "- ";
                            break;
                            case 7:
                                s = s + ") ";
                            break;
                        }
                    }
                    if (TblInf.Repr_Text.dets.LineHeaderRepr.RowNBef)
                    {
                        switch (TblInf.Repr_Text.dets.LineHeaderRepr.BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8)
                        {
                            case 1:
                                s += " N";
                            break;
                            case 2:
                                s += " NCol ";
                            break;
                            case 3:
                                s += " ColN ";
                            break;
                            case 4:
                                s += " Col ";
                            break;
                            case 5:
                                s += " NLine ";
                            break;
                            case 6:
                                s += " LineN ";
                            break;
                            case 7:
                                s += " Line ";
                            break;
                            case 8:
                                s += "= ";
                            break;
                        }
                        //
                        //s = s + (N-1+TblInf.Repr.GenRepr.LoCHNumerationStartFromN).ToString();//////////////////////////!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        s = s + ((N - 1) * TblInf.Repr_Text.dets.GenRepr.LinesNumerationStep + TblInf.Repr_Text.dets.GenRepr.LinesNumerationStartFromN).ToString();
                        //
                        switch (TblInf.Repr_Text.dets.LineHeaderRepr.AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8)
                        {
                            case 1:
                                s += ") ";
                            break;
                            case 2:
                                s += "th ";
                            break;
                            case 3:
                                s += "th Line ";
                            break;
                            case 4:
                                s += "th Col ";
                            break;
                            case 5:
                                s += ": ";
                            break;
                            case 6:
                                s += "- ";
                            break;
                            case 7:
                                s += ", ";
                            break;
                            case 8:
                                s += "= ";
                            break;
                        }
                    }
                    //
                    if (TblInf.Repr_Text.dets.LineHeaderRepr.RowName)
                    {
                        s +=   " ";
                        s = s + s_ownVal;
                        s += " ";
                    }
                    //
                    if (TblInf.Repr_Text.dets.LineHeaderRepr.GenRowNameAft)
                    {
                        switch (TblInf.Repr_Text.dets.LineHeaderRepr.BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7)
                        {
                            case 1:
                                s = s + " ";
                            break;
                            case 2:
                                s = s + ", ";
                            break;
                            case 3:
                                s = s + ": ";
                            break;
                            case 4:
                                s = s + "; ";
                            break;
                            case 5:
                                s = s + "= ";
                            break;
                            case 6:
                                s = s + "- ";
                            break;
                            case 7:
                                s = s + ") ";
                            break;
                        }
                        //
                        s = s + GetLinesGeneralName();
                        //
                        switch (TblInf.Repr_Text.dets.LineHeaderRepr.AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7)
                        {
                            case 1:
                                s = s + " ";
                            break;
                            case 2:
                                s = s + ", ";
                            break;
                            case 3:
                                s = s + ": ";
                            break;
                            case 4:
                                s = s + "; ";
                            break;
                            case 5:
                                s = s + "= ";
                            break;
                            case 6:
                                s = s + "- ";
                            break;
                            case 7:
                                s = s + ") ";
                            break;
                        }
                    }
                    //
                    if (TblInf.Repr_Text.dets.LineHeaderRepr.RowNAft)
                    {
                        switch (TblInf.Repr_Text.dets.LineHeaderRepr.BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8)
                        {
                            case 1:
                                s += "N";
                            break;
                            case 2:
                                s += "NCol ";
                            break;
                            case 3:
                                s += "ColN ";
                            break;
                            case 4:
                                s += "Col ";
                            break;
                            case 5:
                                s += "NLine ";
                            break;
                            case 6:
                                s += "LineN ";
                            break;
                            case 7:
                                s += "Line ";
                            break;
                            case 8:
                                s += "= ";
                            break;
                        }
                        //
                        //s = s + (N - 1 + TblInf.Repr.GenRepr.CoLHNumerationStartFromN).ToString();
                        s = s + (TblInf.Repr_Text.dets.GenRepr.LinesNumerationStartFromN + (N - 1) * TblInf.Repr_Text.dets.GenRepr.LinesNumerationStep).ToString();
                        //
                        switch (TblInf.Repr_Text.dets.LineHeaderRepr.AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8)
                        {
                            case 1:
                                s += ") ";
                            break;
                            case 2:
                                s += "th ";
                            break;
                            case 3:
                                s += "th Line ";
                            break;
                            case 4:
                                s += "th Col ";
                            break;
                            case 5:
                                s += ": ";
                            break;
                            case 6:
                                s += "- ";
                            break;
                            case 7:
                                s += ", ";
                            break;
                            case 8:
                                s += "= ";
                            break;
                        }
                    }
                    //
                    if (TblInf.Repr_Text.dets.LineHeaderRepr.InBrackets) s = s + ")";
                    switch (TblInf.Repr_Text.dets.LineHeaderRepr.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8)
                    {
                        case 1:
                            s = s + "- ";
                        break;
                        case 2:
                            s = s + ": ";
                        break;
                        case 3:
                            s = s + ", ";
                        break;
                        case 4:
                            s = s + "= ";
                        break;
                        case 5:
                            s = s + " row ";
                        break;
                        case 6:
                            s = s + " line ";
                        break;
                        case 7:
                            s = s + " col ";
                        break;
                    case 8:
                        s = s + ") ";
                    break;
                    }
                }
            }//if prior
            return s;
        }
        public string GetLineHeaderCellCoSupplInfAndFmt(int N, TableInfo TblInfExt, StringShaublin StrSampleExt, int ReprPrior_Any0Grid1Text2 = 2)
        {
            string s_OwnVal, s_AllInf, s_FinFormatted;
            int[] ColLen;
            int MaxLen, QColsReal, ErstCN;
            ColLen = null;
            ErstCN = 0;
            s_FinFormatted = "";
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            StringShaublin StrSample;
            DataCell cell;
            if (StrSampleExt != null) StrSample = StrSampleExt; else StrSample = new StringShaublin();
            if (N == 0)
            {
                s_AllInf = GetCornerCoSupplInf(TblInf);//No Need
                s_FinFormatted = GetCornerCoSupplInfAndFmt(TblInf, StrSample);
            }
            else if (N <= TblInf.GetQLines())
            {
                //cell = this.GetCell_ColOfLineHeader(N);
                //s_OwnVal = cell.ToString();
                s_OwnVal = ToString_ColOfLineHeader(N);
                s_AllInf = GetLineHeaderCellCoSupplInfAsString(N, TblInf);
                s_FinFormatted = s_AllInf;
                if (ReprPrior_Any0Grid1Text2 == 0 && ReprPrior_Any0Grid1Text2 == 2)
                {
                    switch (TblInf.Repr_Text.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3)
                    {
                        case 0:
                            s_FinFormatted = s_AllInf;
                        break;
                        case 1:
                            StrSample.SetLength(TblInf.Repr_Text.dets.GenRepr.LRecom);
                            s_FinFormatted = MyLib.ReturnByShaublin(s_AllInf, StrSample);
                        break;
                        case 2:
                            MaxLen = GetMaxLength();
                            StrSample.SetLength(MaxLen);
                            s_FinFormatted = MyLib.ReturnByShaublin(s_AllInf, StrSample);
                        break;
                        case 3:
                            QColsReal = GetQColumns() + 1;
                            ColLen = new int[QColsReal];
                            GetMaxColLength(ref ColLen, ref ErstCN, ref QColsReal);
                            StrSample.SetLength(ColLen[N]);
                            s_FinFormatted = MyLib.ReturnByShaublin(s_AllInf, StrSample);
                         break;
                    }//switch
                }//if ReprPrior_Any0Grid1Text2
            }//if N 
            return s_FinFormatted;
        }
        //
        public string GetColumnHeaderCellAsString(int N, TableInfo TblInfExt, int ReprPrior_Any0Grid1Text2 = 2)
        {
            string s="";
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            if (GetIfCellExists_LineOfColHeader(N, TblInfExt))
            {
                s = LineOfColHeader[N - 1].ToString();
            }
            return s;
        }
        public string GetColumnHeaderCellCoSupplInfAsString(int N, TableInfo TblInfExt=null, int ReprPrior_Any0Grid1Text2 = 2)
        {
            TableInfo TblInf=Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            string s, s_ownVal;
            DataCell cell;
            cell = GetCell_LineOfColHeader(N, TblInf.GetTableInfo_ConcrRepr());
            s=""; 
            //if(cell!=null){
            if (N > 0 && N <= TblInf.GetQColumns())
            {
                //s_ownVal=cell.ToString();
                s_ownVal = ToString_LineOfColHeader(N, TblInf);
                if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 2)
                {
                    switch (TblInf.Repr_Text.dets.LineHeaderRepr.Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7)
                    {
                        case 1:
                            s = s + "- ";
                            break;
                        case 2:
                            s = s + ": ";
                            break;
                        case 3:
                            s = s + ", ";
                            break;
                        case 4:
                            s = s + "= ";
                            break;
                        case 5:
                            s = s + " row ";
                            break;
                        case 6:
                            s = s + " line ";
                            break;
                        case 7:
                            s = s + " col ";
                            break;
                    }
                    //
                    if (TblInf.Repr_Text.dets.ColHeaderRepr.InBrackets) s = s + "(";
                    if (TblInf.Repr_Text.dets.ColHeaderRepr.GenRowNameBef)
                    {
                        //s = s + GetColumnsGeneralName(); //nin corrected
                        switch (TblInf.Repr_Text.dets.ColHeaderRepr.BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7)
                        {
                            case 1:
                                s = s + " ";
                                break;
                            case 2:
                                s = s + ", ";
                                break;
                            case 3:
                                s = s + ": ";
                                break;
                            case 4:
                                s = s + "; ";
                                break;
                            case 5:
                                s = s + "= ";
                                break;
                            case 6:
                                s = s + "- ";
                                break;
                            case 7:
                                s = s + ") ";
                                break;
                        }
                        //
                        s = s + GetColumnsGeneralName();
                        //
                        switch (TblInf.Repr_Text.dets.ColHeaderRepr.AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7)
                        {
                            case 1:
                                s = s + " ";
                                break;
                            case 2:
                                s = s + ", ";
                                break;
                            case 3:
                                s = s + ": ";
                                break;
                            case 4:
                                s = s + "; ";
                                break;
                            case 5:
                                s = s + "= ";
                                break;
                            case 6:
                                s = s + "- ";
                                break;
                            case 7:
                                s = s + ") ";
                                break;
                        }

                    }
                    if (TblInf.Repr_Text.dets.ColHeaderRepr.RowNBef)
                    {
                        switch (TblInf.Repr_Text.dets.ColHeaderRepr.BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8)
                        {
                            case 1:
                                s += " N";
                                break;
                            case 2:
                                s += " NCol ";
                                break;
                            case 3:
                                s += " ColN ";
                                break;
                            case 4:
                                s += " Col ";
                                break;
                            case 5:
                                s += " NLine ";
                                break;
                            case 6:
                                s += " LineN ";
                                break;
                            case 7:
                                s += " Line ";
                                break;
                            case 8:
                                s += "= ";
                                break;
                        }
                        //
                        //s=s+N.ToString();
                        //s = s + (N - 1 + TblInf.Repr_Text.dets.GenRepr.LoCHNumerationStartFromN).ToString();
                        s = s + ((N - 1) * TblInf.Repr_Text.dets.GenRepr.ColumnsNumerationStep + TblInf.Repr_Text.dets.GenRepr.ColumnsNumerationStartFromN).ToString();
                        //
                        switch (TblInf.Repr_Text.dets.ColHeaderRepr.AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8)
                        {
                            case 1:
                                s += ") ";
                                break;
                            case 2:
                                s += "th ";
                                break;
                            case 3:
                                s += "th Line ";
                                break;
                            case 4:
                                s += "th Col ";
                                break;
                            case 5:
                                s += ": ";
                                break;
                            case 6:
                                s += "- ";
                                break;
                            case 7:
                                s += ", ";
                                break;
                            case 8:
                                s += "= ";
                                break;
                        }
                    }
                    //
                    if (TblInf.Repr_Text.dets.ColHeaderRepr.RowName)
                    {
                        s = s + " ";
                        s = s + s_ownVal;
                        s = s + " ";
                    }
                    //
                    if (TblInf.Repr_Text.dets.ColHeaderRepr.GenRowNameAft)
                    {
                        switch (TblInf.Repr_Text.dets.ColHeaderRepr.BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7)
                        {
                            case 1:
                                s = s + " ";
                                break;
                            case 2:
                                s = s + ", ";
                                break;
                            case 3:
                                s = s + ": ";
                                break;
                            case 4:
                                s = s + "; ";
                                break;
                            case 5:
                                s = s + "= ";
                                break;
                            case 6:
                                s = s + "- ";
                                break;
                            case 7:
                                s = s + ") ";
                                break;
                        }
                        //
                        s = s + GetColumnsGeneralName();
                        //
                        switch (TblInf.Repr_Text.dets.ColHeaderRepr.AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7)
                        {
                            case 1:
                                s = s + " ";
                                break;
                            case 2:
                                s = s + ", ";
                                break;
                            case 3:
                                s = s + ": ";
                                break;
                            case 4:
                                s = s + "; ";
                                break;
                            case 5:
                                s = s + "= ";
                                break;
                            case 6:
                                s = s + "- ";
                                break;
                            case 7:
                                s = s + ") ";
                                break;
                        }
                    }
                    //
                    if (TblInf.Repr_Text.dets.ColHeaderRepr.RowNAft)
                    {
                        switch (TblInf.Repr_Text.dets.ColHeaderRepr.BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8)
                        {
                            case 1:
                                s += "N";
                                break;
                            case 2:
                                s += "NCol ";
                                break;
                            case 3:
                                s += "ColN ";
                                break;
                            case 4:
                                s += "Col ";
                                break;
                            case 5:
                                s += "NLine ";
                                break;
                            case 6:
                                s += "LineN ";
                                break;
                            case 7:
                                s += "Line ";
                                break;
                            case 8:
                                s += "Line ";
                                break;
                        }
                        //
                        //s=s+N.ToString();
                        //s = s + (N - 1 + TblInf.Repr_Text.dets.GenRepr.LoCHNumerationStartFromN).ToString();
                        s = s + ((N - 1) * TblInf.Repr_Text.dets.GenRepr.ColumnsNumerationStep + TblInf.Repr_Text.dets.GenRepr.ColumnsNumerationStartFromN).ToString();
                        //
                        switch (TblInf.Repr_Text.dets.ColHeaderRepr.AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8)
                        {
                            case 1:
                                s += ") ";
                                break;
                            case 2:
                                s += "th ";
                                break;
                            case 3:
                                s += "th Line ";
                                break;
                            case 4:
                                s += "th Col ";
                                break;
                            case 5:
                                s += ": ";
                                break;
                            case 6:
                                s += "- ";
                                break;
                            case 7:
                                s += ", ";
                                break;
                            case 8:
                                s += "= ";
                                break;
                        }
                    }
                    //
                    if (TblInf.Repr_Text.dets.ColHeaderRepr.InBrackets) s = s + ")";
                    switch (TblInf.Repr_Text.dets.ColHeaderRepr.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8)
                    {
                        case 1:
                            s = s + "- ";
                            break;
                        case 2:
                            s = s + ": ";
                            break;
                        case 3:
                            s = s + ", ";
                            break;
                        case 4:
                            s = s + "= ";
                            break;
                        case 5:
                            s = s + " row ";
                            break;
                        case 6:
                            s = s + " line ";
                            break;
                        case 7:
                            s = s + " col ";
                            break;
                        case 8:
                            s = s + ") ";
                            break;
                    }//switch
                }
                //if (TblInf.Repr.ColHeaderRepr.Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7
            }//if prior
            return s;
        }
        public string GetColumnHeaderCellCoSupplInfAndFmt(int N, TableInfo TblInfExt, StringShaublin StrSampleExt, int ReprPrior_Any0Grid1Text2 = 2)
        {
            string s_OwnVal, s_AllInf, s_FinFormatted;
            int[] ColLen;
            int MaxLen, QColsReal, ErstCN;
            DataCell cell;
            TableInfo TblInf=Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            StringShaublin StrSample;
            if (StrSampleExt != null) StrSample = StrSampleExt; else StrSample = new StringShaublin();
            ColLen = null;
            ErstCN = 0;
            s_FinFormatted = "";
            cell = GetCell_LineOfColHeader(N, TblInf.GetTableInfo_ConcrRepr());
            if (N == 0)
            {
                //s_OwnVal = GetCorner(TblInf.Repr.GenRepr);
                s_OwnVal = GetCorner(TblInf);
                s_AllInf=GetCornerCoSupplInf(TblInfExt);
                s_FinFormatted=GetCornerCoSupplInfAndFmt(TblInfExt, StrSampleExt);
            }
            else
            {
                //s_OwnVal = cell.ToString();
                s_OwnVal = ToString_LineOfColHeader(N, TblInf);
                s_AllInf = GetColumnHeaderCellCoSupplInfAsString(N, TblInfExt);
                s_FinFormatted = s_AllInf;
                if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 2)
                {
                    switch (TblInf.Repr_Text.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3)
                    {
                        case 0:
                            s_FinFormatted = s_AllInf;
                            break;
                        case 1:
                            StrSample.SetLength(TblInf.Repr_Text.dets.GenRepr.LRecom);
                            s_FinFormatted = MyLib.ReturnByShaublin(s_AllInf, StrSample);
                            break;
                        case 2:
                            MaxLen = GetMaxLength();
                            StrSample.SetLength(MaxLen);
                            s_FinFormatted = MyLib.ReturnByShaublin(s_AllInf, StrSample);
                            break;
                        case 3:
                            QColsReal = GetQColumns() + 1;
                            ColLen = new int[QColsReal];
                            GetMaxColLength(ref ColLen, ref ErstCN, ref QColsReal);
                            StrSample.SetLength(ColLen[N]);
                            s_FinFormatted = MyLib.ReturnByShaublin(s_AllInf, StrSample);
                        break;
                    }//case
                }//if prior
            }
            return s_FinFormatted;
        }
        //
        //
        public string GetContentCellCoSupplInfAsString(int LineN, int ColN, TableInfo TblInfExt = null, int ReprPrior_Any0Grid1Text2 = 2)
        {
            string s_cellOwnVal, s_SupplInf, s, s_wholeInf, LHName, CHName;
            int QColsReal, ErstCN, MaxLen;
            int[] ColLen;
            DataCell cell;
            TableInfo TblInf=Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            ErstCN = 0; QColsReal = 0;
            ColLen = null;
            //LineOfColHeader = null; ColOfLineHeader = null; //how could it be! error!
            s_wholeInf = "";
            cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0 && ColN == 0)
                {
                    //s_cellOwnVal = GetCorner(TblInf.Repr.GenRepr);
                    s_cellOwnVal = GetCorner(TblInf);
                    s_SupplInf = "";
                    s_wholeInf = s_cellOwnVal;
                }
                else
                {
                    if (ColN == 0)
                    {
                        s_wholeInf = GetLineHeaderCellCoSupplInfAsString(LineN, TblInfExt);
                    }
                    else if (LineN == 0)
                    {
                        s_wholeInf = GetColumnHeaderCellCoSupplInfAsString(ColN, TblInfExt);
                    }
                    else
                    {//content
                        //Own Val
                        s_cellOwnVal = cell.ToString();
                        s_SupplInf = "";
                        if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 2)
                        {
                            if (TblInf.Repr_Text.dets.ContentRepr.TableHeaderExists) s_SupplInf = s_SupplInf + GetTableHeaderName() + " ";
                            if (TblInf.Repr_Text.dets.ContentRepr.GetIfHeaderExists())
                            {
                                if (TblInf.Repr_Text.dets.ContentRepr.HeadersInBrackets)
                                {
                                    s_SupplInf = s_SupplInf + "(";
                                }
                                //
                                //if (TblInf.Repr_Text.dets.ContentRepr.LH_IsBefNotAft_CH)
                                if (TblInf.Repr_Text.dets.ContentRepr.LH_IsBefNotAft_CH && TblInf.Repr_Text.dets.ContentRepr.LineHeaderExists)
                                {
                                    s_SupplInf = s_SupplInf + GetLineHeaderCellCoSupplInfAsString(LineN, TblInfExt);
                                }
                                //else
                                else if (TblInf.Repr_Text.dets.ContentRepr.LH_IsBefNotAft_CH == false && TblInf.Repr_Text.dets.ContentRepr.ColHeaderExists)
                                {
                                    s_SupplInf = s_SupplInf + GetColumnHeaderCellCoSupplInfAsString(ColN, TblInfExt);
                                }
                                //
                                if (TblInf.Repr_Text.dets.ContentRepr.LineHeaderExists && TblInf.Repr_Text.dets.ContentRepr.ColHeaderExists) s_SupplInf = s_SupplInf + ", ";
                                //
                                //if (TblInf.Repr_Text.dets.ContentRepr.LH_IsBefNotAft_CH && GetIfColOfLineHeaderExists())
                                if (TblInf.Repr_Text.dets.ContentRepr.LH_IsBefNotAft_CH && TblInf.Repr_Text.dets.ContentRepr.ColHeaderExists)
                                {
                                    //s_SupplInf = s_SupplInf + ToString_ColOfLineHeader(LineN);
                                    s_SupplInf = s_SupplInf + GetColumnHeaderCellCoSupplInfAsString(ColN, TblInf);
                                }
                                //else
                                else if (TblInf.Repr_Text.dets.ContentRepr.LH_IsBefNotAft_CH == false && TblInf.Repr_Text.dets.ContentRepr.LineHeaderExists)
                                {
                                    s_SupplInf = s_SupplInf + GetLineHeaderCellCoSupplInfAsString(LineN, TblInf);
                                }
                                //
                                if (TblInf.Repr_Text.dets.ContentRepr.HeadersInBrackets)
                                {
                                    s_SupplInf = s_SupplInf + ")";
                                }
                            }//if Header Exists
                            //
                            if (TblInf.Repr_Text.dets.ContentRepr.HeadersAreBefNotAft)
                            {
                                s_wholeInf = s_SupplInf;
                                switch (TblInf.Repr_Text.dets.ContentRepr.HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6)
                                {
                                    case 1:
                                        s_wholeInf = s_wholeInf + " ";
                                        break;
                                    case 2:
                                        s_wholeInf = s_wholeInf + ", ";
                                        break;
                                    case 3:
                                        s_wholeInf = s_wholeInf + ": ";
                                        break;
                                    case 4:
                                        s_wholeInf = s_wholeInf + "; ";
                                        break;
                                    case 5:
                                        s_wholeInf = s_wholeInf + "- ";
                                        break;
                                    case 6:
                                        s_wholeInf = s_wholeInf + "= ";
                                        break;
                                }
                                s_wholeInf = s_wholeInf + s_cellOwnVal;
                            }
                            else
                            { //HeadersAreBefNotAft==false
                                s_wholeInf = s_cellOwnVal;
                                switch (TblInf.Repr_Text.dets.ContentRepr.HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6)
                                {
                                    case 1:
                                        s_wholeInf = s_wholeInf + " ";
                                        break;
                                    case 2:
                                        s_wholeInf = s_wholeInf + ", ";
                                        break;
                                    case 3:
                                        s_wholeInf = s_wholeInf + ": ";
                                        break;
                                    case 4:
                                        s_wholeInf = s_wholeInf + "; ";
                                        break;
                                    case 5:
                                        s_wholeInf = s_wholeInf + "- ";
                                        break;
                                    case 6:
                                        s_wholeInf = s_wholeInf + "= ";
                                        break;
                                }
                                s_wholeInf = s_wholeInf + s_SupplInf;
                            }//if HeadersAreBefNotAft
                        }//if prior
                    }//Content
                }//Col/Line/Content
            }//if
            return s_wholeInf;
        }//fn
        public string GetContentCellCoSupplInfAndFmt(int LineN, int ColN, TableInfo TblInfExt, StringShaublin StrSampleExt, int ReprPrior_Any0Grid1Text2 = 2)
        {
            TableInfo TblInf ;
            StringShaublin StrSample;
            string s_Cell, s_FinFormatted;
            DataCell cell;
            int QColsReal, ErstCN, MaxLen;
            int[] ColLen;
            TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            if (StrSampleExt != null) StrSample = StrSampleExt; else StrSample = new StringShaublin();
            ErstCN = 0; QColsReal = 0;
            ColLen = null;
            //LineOfColHeader = null; ColOfLineHeader = null; LoCH_NULL, CoLH_NULL
            s_FinFormatted = "";
            cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null)
            {
                if (LineN == 0 && ColN == 0)
                {
                    s_Cell=GetCornerCoSupplInf(TblInfExt);
                }
                else
                {
                    if (ColN == 0)
                    {
                        s_Cell = GetLineHeaderCellCoSupplInfAsString(LineN, TblInfExt);
                    }
                    else if (LineN == 0)
                    {
                        s_Cell = GetColumnHeaderCellCoSupplInfAsString(ColN, TblInfExt);
                    }
                    else
                    {//content
                        s_Cell =GetContentCellCoSupplInfAsString(LineN, ColN, TblInf);
                    }//Content
                }//Col/Line/Content
                if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 2)
                {
                    switch (TblInf.Repr_Text.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3)
                    {
                        case 0:
                            s_FinFormatted = s_Cell;
                            break;
                        case 1:
                            StrSample.SetLength(TblInf.Repr_Text.dets.GenRepr.LRecom);
                            s_FinFormatted = MyLib.ReturnByShaublin(s_Cell, StrSample);
                            break;
                        case 2:
                            MaxLen = GetMaxLength();
                            StrSample.SetLength(MaxLen);
                            s_FinFormatted = MyLib.ReturnByShaublin(s_Cell, StrSample);
                            break;
                        case 3:
                            QColsReal = GetQColumns() + 1;
                            ColLen = new int[QColsReal];
                            GetMaxColLength(ref ColLen, ref ErstCN, ref QColsReal);
                            StrSample.SetLength(ColLen[ColN]);
                            s_FinFormatted = MyLib.ReturnByShaublin(s_Cell, StrSample);
                            break;
                    }//switch
                }//Prior
            }//cell!=null
            return s_FinFormatted;
        }//fn
        //
        //
        public string GetLineAsStringOfCSV(int LineN, bool WithLineHeader, int ErstColN, int QColumns, TableInfo TblInfExt, string separator)
        {
            string s="";
            bool ToShow;
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            int QColumnsOfTable = TblInf.GetQColumns(), QLinesOfTable=TblInf.GetQLines(), LastColN=ErstColN+QColumns-1;
            ToShow=(((LineN>=0 && ColOfLineHeader!=null)||(LineN>=1 && ColOfLineHeader==null))&& LineN<=QLinesOfTable && ErstColN>=1 && ErstColN<=QColumnsOfTable && (ErstColN+QColumns-1)<=QColumnsOfTable);
            if(ToShow){    
                if(ColOfLineHeader!=null && WithLineHeader && ErstColN>0) s=ColOfLineHeader[LineN-1].ToString()+separator;
                for(int N=ErstColN; N<=LastColN; N++){
                    s+=ToString(LineN, N);
                    if(N<LastColN) s=s+separator;
                }
            }
            return s;
        }
        public string GetLineAsStringCoSupplInfAndFmt(int LineN, bool WithLineHeader, int ErstColN, int QColumns, TableInfo TblInfExt, StringShaublin StrSampleExt, int ReprPrior_Any0Grid1Text2 = 2)
        {
            int QTableColumns, LastColumnN;
            TableInfo TblInf;
            bool ToShow;
            DataCell cell;
            StringShaublin StrSampleCont, StrSampleHdr;
            string s, c;
            TblInf=Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            if(StrSampleExt!=null){
                StrSampleCont=StrSampleExt; StrSampleHdr=StrSampleExt;
            }else{
                StrSampleCont=new StringShaublin(); StrSampleHdr=new StringShaublin();
            }
            QTableColumns = TblInf.GetQColumns();
            s = "";
            if (WithLineHeader || ErstColN < 1)
            {
                c=GetLineHeaderCellCoSupplInfAndFmt(LineN, TblInf, StrSampleHdr) + " ";
                s = s + c;
            }
            if (ErstColN > QTableColumns) ErstColN = QTableColumns;
            ToShow = (ErstColN <= QTableColumns && ErstColN>=0);
            if (ToShow)
            {
                if (ErstColN < 1) ErstColN = 1;
                if (QColumns - ErstColN > QTableColumns) QColumns = QTableColumns - ErstColN;
                LastColumnN = ErstColN + QColumns - 1;
                for (int i = ErstColN; i <= LastColumnN; i++)
                {
                    cell = GetCell(LineN, i, TblInf.GetTableInfo_ConcrRepr());
                    c = GetContentCellCoSupplInfAndFmt(LineN, i, TblInf, StrSampleCont);
                    s = s + c;
                    if (i < LastColumnN) s = s + " ";
                }
            }
            return s;
        }
        public string GetLineOfColHeaderCoSupplInfAndFmt(bool WithCorner, int ErstColN, int QColumns, TableInfo TblInfExt, StringShaublin StrSampleExt, int ReprPrior_Any0Grid1Text2 = 2)
        {
            int QTableColumns, LastColumnN;
            bool ToShow, ErstColNCorrect, LoCHExists=true;
            TableInfo TblInf;
            StringShaublin StrSampleCont, StrSampleHdr;
            TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            if (StrSampleExt != null)
            {
                StrSampleCont = StrSampleExt; StrSampleHdr = StrSampleExt;
            }
            else
            {
                StrSampleCont = new StringShaublin(); StrSampleHdr = new StringShaublin();
            }
            string s, c;
            //if (StrSampleExt != null) StrSample = StrSampleExt; else StrSample = new StringShaublin();
            QTableColumns = TblInf.GetQColumns();
            s = ""; c = "";
            if (WithCorner/*WithLineHeader*/ || ErstColN < 1)
            {
                s = s + GetCornerCoSupplInfAndFmt(TblInf, StrSampleHdr) + " ";
            }
            if (ErstColN > QTableColumns) ErstColN = QTableColumns;
            ErstColNCorrect = ErstColN <= QTableColumns && ErstColN >= 0;
            if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 2)
            {
                LoCHExists = (GetIfLineOfColHeaderExists() == true || TblInf.Repr_Text.dets.GenRepr.ShowLineOfColHeader == true);
            }
            ToShow = ErstColNCorrect && LoCHExists;
            if (ToShow)
            {
                if (ErstColN < 1) ErstColN = 1;
                if (QColumns - ErstColN > QTableColumns) QColumns = QTableColumns - ErstColN;
                LastColumnN = ErstColN + QColumns - 1;
                for (int i = ErstColN; i <= LastColumnN; i++)
                {
                    //cell = GetCell(LineN, i);
                    //public string GetLineHeaderCellCoSupplInfAsString(int N, TableRepresentation ReprExt, int Align_L1R2CL3CR4ByTypeAsExcel5ByTypeAsExcelC6, int ErstIfCut)
                    //s = s + GetLineHeaderCellCoSupplInfAndFmt(i, TblInf, StrSampleCont);
                    c = GetColumnHeaderCellCoSupplInfAndFmt(i, TblInf, StrSampleCont);
                    s = s + c;
                    if (i < LastColumnN) s = s + " ";
                }
            }
            return s;
        }
        //
        //mark11
        public string GetNameN(int N, int LineN, int ColN, TableInfo TblInfExt = null)
        {
            string s = "";
            DataCell cell=null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            if (LineN != 0 && ColN != 0) cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            else if (LineN == 0 && ColN != 0) cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
            else if (LineN != 0 && ColN == 0) cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
            if(cell!=null) s=cell.GetNameN(N);
            return s;
        }
        public string GetName1(int LineN, int ColN, TableInfo TblInfExt = null)
        {
            string s = "";
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            if (LineN != 0 && ColN != 0) cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            else if (LineN == 0 && ColN != 0) cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
            else if (LineN != 0 && ColN == 0) cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) s = cell.GetName1();
            return s;
        }
        public string GetName2(int LineN, int ColN, TableInfo TblInfExt = null)
        {
            string s = "";
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            if (LineN != 0 && ColN != 0) cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            else if (LineN == 0 && ColN != 0) cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
            else if (LineN != 0 && ColN == 0) cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) s = cell.GetName2();
            return s;
        }
        //public string GetName3(int LineN, int ColN, TableInfo TblInfExt = null)
        //{
        //    string s = "";
        //    DataCell cell = null;
        //    TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
        //    if (LineN != 0 && ColN != 0) cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
        //    else if (LineN == 0 && ColN != 0) cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
        //    else if (LineN != 0 && ColN == 0) cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
        //    if (cell != null) s = cell.GetName3();
        //    return s;
        //}
        public void GetNames(ref string[] Arr, ref int QItems, int LineN, int ColN, TableInfo TblInfExt = null)
        {
            Arr = null;
            QItems = 0;
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            if (LineN != 0 && ColN != 0) cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            else if (LineN == 0 && ColN != 0) cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
            else if (LineN != 0 && ColN == 0) cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) cell.GetNames(ref Arr, ref QItems);
        }
        public int GetLengthOfNamesList(int LineN, int ColN, TableInfo TblInfExt = null)
        {
            int R= 0;
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            if (LineN != 0 && ColN != 0) cell = GetCell(LineN, ColN, TblInf.GetTableInfo_ConcrRepr());
            else if (LineN == 0 && ColN != 0) cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
            else if (LineN != 0 && ColN == 0) cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) R = cell.GetLengthOfNamesList();
            return R;
        }
        //
        public string GetNameN_LineOfColHeader(int N, int ColN, TableInfo TblInfExt = null)
        {
            string s = "";
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) s = cell.GetNameN(N);
            return s;
        }
        public string GetName1_LineOfColHeader(int ColN, TableInfo TblInfExt = null) {
            string s = "";
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) s = cell.GetName1();
            return s;
        }
        public string GetName2_LineOfColHeader(int ColN, TableInfo TblInfExt = null) {
            string s = "";
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) s = cell.GetName2();
            return s;
        }
        //public string GetName3_LineOfColHeader(int ColN, TableInfo TblInfExt = null) {
        //    string s = "";
        //    DataCell cell = null;
        //    TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
        //    cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
        //    if (cell != null) s = cell.GetName3();
        //    return s;
        //}
        public void GetNames_LineOfColHeader(ref string[] Arr, ref int QItems, int ColN, TableInfo TblInfExt = null)
        {
            Arr = null;
            QItems = 0;
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) cell.GetNames(ref Arr, ref QItems);
        }
        public int GetLengthOfNamesList_LineOfColHeader(int ColN, TableInfo TblInfExt = null)
        {
            int R = 0;
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            cell = GetCell_LineOfColHeader(ColN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) R = cell.GetLengthOfNamesList();
            return R;
        }
        //
        public string GetNameN_ColOfLineHeader(int N, int LineN, TableInfo TblInfExt = null)
        {
            string s = "";
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) s = cell.GetNameN(N);
            return s;
        }
        public string GetName1_ColOfLineHeader(int LineN, TableInfo TblInfExt = null)
        {
            string s = "";
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) s = cell.GetName1();
            return s;
        }
        public string GetName2_ColOfLineHeader(int LineN, TableInfo TblInfExt = null)
        {
            string s = "";
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) s = cell.GetName2();
            return s;
        }
        //public string GetName3_ColOfLineHeader(int LineN, TableInfo TblInfExt = null)
        //{
        //    string s = "";
        //    DataCell cell = null;
        //    TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
        //    cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
        //    if (cell != null) s = cell.GetName3();
        //    return s;
        //}
        public void GetNames_ColOfLineHeader(ref string[] Arr, ref int QItems, int LineN, TableInfo TblInfExt = null)
        {
            Arr = null;
            QItems = 0;
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) cell.GetNames(ref Arr, ref QItems);
        }
        public int GetLengthOfNamesList_ColOfLineHeader(int LineN, TableInfo TblInfExt = null)
        {
            int R = 0;
            DataCell cell = null;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            cell = GetCell_ColOfLineHeader(LineN, TblInf.GetTableInfo_ConcrRepr());
            if (cell != null) R = cell.GetLengthOfNamesList();
            return R;
        }
        //
        public void ShowCell(int LineN, int ColN, TValsShowHide vsh, TableInfo TblInfExt, StringShaublin StrSampleExt)
        {
            string s;
            s = "";
            bool CellExists = GetIfCellExists(LineN, ColN, TblInfExt);
            if (CellExists)
            {
                s = GetContentCellCoSupplInfAndFmt(LineN, ColN, TblInfExt, StrSampleExt);
                MyLib.writeln(vsh, s);
            }
        }
        //
        public void ShowLine(int LineN, bool WithLineHeader, int ErstColN, int QColumns, TableInfo TblInfExt, StringShaublin StrSampleExt, TValsShowHide vsh)
        {
            string s;
            if (LineN > 0)
            {
                s = GetLineAsStringCoSupplInfAndFmt(LineN, WithLineHeader, ErstColN, QColumns, TblInfExt, StrSampleExt);
            }
            else
            {
                s = GetLineOfColHeaderCoSupplInfAndFmt(WithLineHeader, ErstColN, QColumns, TblInfExt, StrSampleExt);
            }
            if (s != "") MyLib.writeln(vsh, s);
        }
        public void ShowLineOfColHeader(bool WithCorner, int ErstColN, int QColumns, TableInfo TblInfExt, StringShaublin StringSampleExt, TValsShowHide vsh)
        {
            string s = GetLineOfColHeaderCoSupplInfAndFmt(WithCorner, ErstColN, QColumns, TblInfExt, StringSampleExt);
            if (s != "") MyLib.writeln(vsh, s);
            //ShowLine(0, WithCorner, ErstColN, QColumns, TblInfExt, StringSampleExt, vsh); //also possible
        }
        //
        public void Show(bool WithColHeader, bool WithLineHeader, int ErstColN, int QColumns, int ErstLineN, int QLines, TableInfo TblInfExt, StringShaublin StringSampleExt, TValsShowHide vsh)
        {
            bool ToShow;
            TableInfo TblInf=Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            int QLinesInTable=TblInf.GetQLines();
            if(WithColHeader) ShowLineOfColHeader(WithLineHeader, ErstColN, QColumns, TblInfExt, StringSampleExt, vsh);
            ToShow = (ErstLineN >= 0 && ErstLineN <= QLinesInTable && (ErstLineN + QLines - 1) <= QLinesInTable);
            if (ToShow)
            {
                for (int N = ErstLineN; N <= (ErstLineN + QLines - 1); N++)
                {
                    ShowLine(N, WithLineHeader, ErstColN, QColumns, TblInfExt, StringSampleExt, vsh);
                }
            }
        }
        public void Show(TValsShowHide vsh, CellsNsToDisplay CellsToDisplayExt = null, TableInfo TblInfExt = null, int ReprPrior_Any0Grid1Text2 = 2)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            CellsNsToDisplay CellsToDisplay;
            if (CellsToDisplayExt != null) CellsToDisplay = CellsToDisplayExt;
            else
            {
                CellsToDisplay = new CellsNsToDisplay();
                CellsToDisplay.SetAll(TblInf.RowsQuantities);
            }
            CellsToDisplay.Correct(TblInf.RowsQuantities);
            int ErstColN = CellsToDisplay.NsToDispl.ErstColumnN, QColumns = CellsToDisplay.NsToDispl.QColumns, ErstLineN=CellsToDisplay.NsToDispl.ErstLineN, QLines=CellsToDisplay.NsToDispl.QLines;
            bool CoLoCH=true, CoCoLH=true;
            if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 2)
            {
                if (TblInf.Repr_Text.dets != null)
                {
                    CoLoCH = TblInf.Repr_Text.dets.GenRepr.ShowLineOfColHeader;
                    CoCoLH = TblInf.Repr_Text.dets.GenRepr.ShowColOfLineHeader;
                }
                else
                {
                    CoLoCH = true;
                    CoCoLH = true;
                }
            }
            Show(CoLoCH, CoCoLH, ErstColN, QColumns, ErstLineN, QLines, TblInf, null, vsh);
        }
        public void Show(TValsShowHide vsh)
        {
            TableInfo TblInf;
            if(this.TblInf!=null && this.TblInf.RowsQuantities!=null) TblInf=this.TblInf; else TblInf=new TableInfo();
            if(TblInf.RowsQuantities==null )TblInf.RowsQuantities=new TableSize();
            //Show(true, true, 1, TblInf.GetQColumns(), 1, TblInf.GetQLines(), TblInf, null, vsh);
            int QL = TblInf.GetQLines(), QC = TblInf.GetQColumns();
            Show(true, true, 1, QC, 1, QL, TblInf, null, vsh);
        }
        //
        //public void TableCellNToGridCellIndex(int tLineN, int tColN, CellsNsToDisplay CellsToDisplayExt, TableFormAndGridConfigurationMain cfg, TableInfo TblInfExt, ref int gLineIndex, ref int gColIndex, int ReprPrior_Any0Grid1Text2 = 2)
        //{
        //    DataCell cell;
        //    TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
        //    CellsNsToDisplay CellsToDisplay;
        //    bool LineOfColHeaderExists = true;
        //    bool ColOfLineHeaderExists = true;
        //    bool LineOfColHeaderHidden = true;
        //    bool ColOfLineHeaderHidden = true;
        //    if (CellsToDisplayExt != null)
        //    {
        //        CellsToDisplay = CellsToDisplayExt;
        //        CellsToDisplay.Correct(TblInf.RowsQuantities);
        //    }
        //    else CellsToDisplay = new CellsNsToDisplay(TblInf.RowsQuantities);
        //    //
        //    if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 2)
        //    {
        //        LineOfColHeaderExists = TblInf.Repr.GenRepr.ShowLineOfColHeader;
        //        ColOfLineHeaderExists = TblInf.Repr.GenRepr.ShowColOfLineHeader;
        //        LineOfColHeaderHidden = !TblInf.Repr.GenRepr.ShowLineOfColHeader;
        //        ColOfLineHeaderHidden = !TblInf.Repr.GenRepr.ShowColOfLineHeader;
        //    }
        //    LineOfColHeaderPresent = LineOfColHeaderExists && !LineOfColHeaderHidden;
        //    ColOfLineHeaderPresent = ColOfLineHeaderExists && !ColOfLineHeaderHidden;
        //    LineOfColHeaderAbsent = !LineOfColHeaderExists && !LineOfColHeaderHidden;
        //    ColOfLineHeaderAbsent = !ColOfLineHeaderExists && !ColOfLineHeaderHidden;
        //    LineOfColHeaderExistsButHidden = LineOfColHeaderExists && LineOfColHeaderHidden;
        //    ColOfLineHeaderExistsButHidden = ColOfLineHeaderExists && ColOfLineHeaderHidden;
        //    int QTableContentLines = TblInf.GetQLines();
        //    int QTableContentColumns = TblInf.GetQColumns();
        //    int QNamesLoCH=0, MaxQNamesLoCH=0, GenQNamesLoCH,
        //        QNamesCoLH=0, MaxQNamesCoLH=0, GenQNamesCoLH;
        //    //
        //    //Calc max QLines for all vals - for LoCH
        //    for (int i = 1; i <= CellsToDisplay.NsToDispl.QColumns; i++)
        //    {
        //        cell = GetCell_LineOfColHeader(CellsToDisplay.NsToDispl.ErstColumnN + i - 1, TblInf);
        //        QNamesLoCH = cell.GetLengthOfNamesList();
        //        if (i == 1 || (i > 1 && QNamesLoCH > MaxQNamesLoCH)) MaxQNamesLoCH = QNamesLoCH;
        //        if (MaxQNamesLoCH < CellsToDisplay.NsToDispl.QColumns) GenQNamesLoCH = MaxQNamesLoCH;
        //        else GenQNamesLoCH = CellsToDisplay.NsToDispl.QColumns;
        //    }
        //    //Calc max QColumns for all vals - for CoLH
        //    for (int i = 1; i <= CellsToDisplay.NsToDispl.QColumns; i++)
        //    {
        //        cell = GetCell_LineOfColHeader(CellsToDisplay.NsToDispl.ErstColumnN + i - 1, TblInf);
        //        QNamesCoLH = cell.GetLengthOfNamesList();
        //        if (i == 1 || (i > 1 && QNamesCoLH > MaxQNamesCoLH)) MaxQNamesCoLH = QNamesCoLH;
        //        if (MaxQNamesCoLH < CellsToDisplay.NsToDispl.QLines) GenQNamesCoLH = MaxQNamesCoLH;
        //        else GenQNamesCoLH = CellsToDisplay.NsToDispl.QLines;
        //    }

        //}
        public void GridCellIndexToTableCellN(int gLineIndex, int gColIndex, CellsNsToDisplay CellsToDisplayExt, TableFormAndGridConfigurationMain cfg, TableInfo TblInfExt, ref int tLineN, ref int tColN, int ReprPrior_Any0Grid1Text2 = 2)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            CellsNsToDisplay CellsToDisplay;
            bool LineOfColHeaderExists = true;
            bool ColOfLineHeaderExists = true;
            //
            if (CellsToDisplayExt != null)
            {
                CellsToDisplay = CellsToDisplayExt;
                CellsToDisplay.Correct(TblInf.RowsQuantities);
            }
            else CellsToDisplay = new CellsNsToDisplay(TblInf.RowsQuantities);
            //
            if (ReprPrior_Any0Grid1Text2 == 0 || ReprPrior_Any0Grid1Text2 == 2)
            {
                LineOfColHeaderExists = TblInf.Repr_Text.dets.GenRepr.ShowLineOfColHeader;
                ColOfLineHeaderExists = TblInf.Repr_Text.dets.GenRepr.ShowColOfLineHeader;
            }
            int QTableContentLines = TblInf.GetQLines();
            int QTableContentColumns = TblInf.GetQColumns();
            //
        }
        //
        public void DisplayContentTableCellToContentGridCell(DataGridView grid, int tLineN, int tColN, int gLineIndex, int gColIndex, /*TableFormAndGridConfigurationAll cfg,*/TableFormAndGridConfigurationMain cfgExt, CellsNsToDisplay NsToDisplExt, TableInfo TblInfExt = null, int ReprPrior_Any0Grid1Text2=2)
        {
            bool BoolVal;
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            TableFormAndGridConfigurationMain cfg;
            if (cfgExt != null) cfg = cfgExt; else cfg = new TableFormAndGridConfigurationMain();
            //
            string s;
            string[] ss;
            int TypeN, length;
            //
            int GridCellTypeN;
            //
            DataCell cell;
            DataGridViewComboBoxCell TICBox;
            DataGridViewCheckBoxCell TCBCell;
            bool LineOfColHeaderExists, ColOfLineHeaderExists;
            int QTableContentLines, QTableContentColumns;
             //
            int FieldHeaderTypeN, ActiveN;
            DataCell cellH;
            //
            if (ReprPrior_Any0Grid1Text2 == 2 || ReprPrior_Any0Grid1Text2 == 0)
            {
                LineOfColHeaderExists = TblInf.Repr_Text.dets.GenRepr.ShowLineOfColHeader;
                ColOfLineHeaderExists = TblInf.Repr_Text.dets.GenRepr.ShowColOfLineHeader;
            }
            QTableContentLines = TblInf.GetQLines();
            QTableContentColumns = TblInf.GetQColumns();
            //
            TypeN = GetTypeN(tLineN, tColN);
            length = GetLength(tLineN, tColN);
            //
            s = ToString(tLineN, tColN);
            //
            grid.Rows[gLineIndex].Cells[gColIndex].Value = s;
            //
            //if (TableConsts.TypeNIsCorrectArray(TypeN) && cfg.ArrToCell_ItemsNotSimple == true)
            FieldHeaderTypeN = 0;
            if (this.GetIf_LinesGeneralHeaderExists() == true) FieldHeaderTypeN = this.GetTypeN_LineOfColHeader(tColN);
            if (FieldHeaderTypeN == TableConsts.StringItemsFieldHeaderCellTypeN)
            {
                cell = GetCell(tLineN, tColN, TblInf.GetTableInfo_ConcrRepr());
                cellH = this.GetCell_LineOfColHeader(tColN, TblInf.GetTableInfo_ConcrRepr());
                ActiveN = cell.GetIntVal();
                ActiveN = cell.GetActiveN();
                TICBox = new DataGridViewComboBoxCell();
                for (int k = 1; k <= length; k++) TICBox.Items.Add(cellH.ToStringN(k));
                s = cellH.ToStringN(ActiveN);
                TICBox.Value = s;
                grid.Rows[gLineIndex].Cells[gColIndex] = TICBox;
            }
            else
            if (TableConsts.TypeNIsCorrectArray(TypeN) && cfg./*FormAndGridCellCfgMain.*/ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2 == 1)
            {
                cell = GetCell(tLineN, tColN, TblInf.GetTableInfo_ConcrRepr());
                TICBox = new DataGridViewComboBoxCell();
                for (int k = 1; k <= length; k++) TICBox.Items.Add(cell.ToStringN(k));
                s = cell.ToStringN(cell.GetActiveN());
                //TICBox.Value = s;
                TICBox.Value = s;
                //try
                //{
                grid.Rows[gLineIndex].Cells[gColIndex] = TICBox;
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.ToString() + " " + "Error in cell[" + gLineIndex.ToString() + "," + gColIndex.ToString() + "]");
                //    //grid.Rows[gLineIndex].Cells[gColIndex].Value = s;
                //}
            }
            else if (TypeN == TableConsts.BoolTypeN && cfg./*FormAndGridCellCfgMain.*/BoolToCell_Simple0ChkB1Cmb2 == 1)
            {
                TCBCell = new DataGridViewCheckBoxCell();
                TCBCell.Value = GetBoolVal(tLineN, tColN);
                grid.Rows[gLineIndex].Cells[gColIndex] = TCBCell;
            }
            else if (TypeN == TableConsts.BoolTypeN && cfg./*FormAndGridCellCfgMain.*/BoolToCell_Simple0ChkB1Cmb2 == 2)
            {
                BoolVal = GetBoolVal(tLineN, tColN);
                //ss = new string[2];
                //if (MyLib.BoolValByDefault == true)
                //{
                //    ss[1 - 1] = TableConsts.TrueWord; ss[2 - 1] = TableConsts.FalseWord;
                //    if (GetBoolVal(tLineN, tColN) == true) SetActiveN(tLineN, tColN, 1);
                //    else SetActiveN(tLineN, tColN, 2);
                //}
                //else
                //{
                //    ss[1 - 1] = TableConsts.FalseWord; ss[2 - 1] = TableConsts.TrueWord;
                //    if (GetBoolVal(tLineN, tColN) == false) SetActiveN(tLineN, tColN, 1);
                //    else SetActiveN(tLineN, tColN, 2);
                //}
                //
                TICBox = new DataGridViewComboBoxCell();
                if (MyLib.BoolValByDefault == true)
                {
                    TICBox.Items.Add(TableConsts.TrueWord);
                    TICBox.Items.Add(TableConsts.FalseWord);
                }
                else
                {
                    TICBox.Items.Add(TableConsts.FalseWord);
                    TICBox.Items.Add(TableConsts.TrueWord);
                }
                if (BoolVal == true)
                {
                    TICBox.Value = TableConsts.TrueWord;
                }
                else
                {
                    TICBox.Value = TableConsts.FalseWord;
                }
                grid.Rows[gLineIndex].Cells[gColIndex] = TICBox;
                //TCBCell = new DataGridViewCheckBoxCell();
                //TCBCell.Value = GetBoolVal(tLineN, tColN);
                //grid.Rows[gLineIndex].Cells[gColIndex] = TCBCell;
            }
            else //also if bool et BoolToCell_Simple0ChkB1Cmb2==2==0
            {
                grid.Rows[gLineIndex].Cells[gColIndex].Value = s;
            }
        }//fn Content Table Cell to Content grid Cell
        public void DisplayLineOfColHeaderTableCellToContentGridCell(DataGridView grid,  int tColN, int gLineN, int gColN, int NameN, TableFormAndGridConfigurationMain cfg, TableInfo TblInfExt = null)
        {
            bool BoolVal = MyLib.BoolValByDefault;
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            string s;
            s = ToStringN_LineOfColHeader(tColN, NameN);
            grid.Rows[gLineN].Cells[gColN].Value = s;
        }//fn LineOfColHeader Table Cell to Content grid Cell
        public void DisplayColOfLineHeaderTableCellToContentGridCell(DataGridView grid, int tLineN, int gLineN, int gColN, int NameN, TableFormAndGridConfigurationMain cfg, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            string s;
            s = ToStringN_ColOfLineHeader(tLineN, NameN);
            grid.Rows[gLineN].Cells[gColN].Value = s;
        }//fn ColOfLineHeader Table Cell to Content grid Cell
        public void DisplayLineOfColHeaderTableCellToLineOfColHeaderGridCell(DataGridView grid, int tColN, int gColN, int NameN, TableFormAndGridConfigurationMain cfg, TableInfo TblInfExt = null)
        { 
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            string s;
            s = ToStringN_LineOfColHeader(tColN, NameN);
            grid.Columns[gColN].HeaderCell.Value = s;
        }
        public void DisplayColOfLineHeaderTableCellToColOfLineHeaderGridCell(DataGridView grid, int tLineN, int gLineN, int NameN, TableFormAndGridConfigurationMain cfg, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            string s;
            s = ToStringN_ColOfLineHeader(tLineN, NameN);
            grid.Rows[gLineN].HeaderCell.Value = s;
        }
        //public void DisplayLineOfColHeaderTableCellToColOfLineHeaderGridCell
        //public void DisplayColOfLineHeaderTableCellToLineOfColHeaderGridCell
        //public void DisplayContentTableCellToColOfLineHeaderGridCell
        //public void DisplayContentTableCellToLineOfColHeaderGridCell
        public void ContentCellCoSupplInfAndFmtToContentGridCell(DataGridView grid, int tLineN, int tColN, int gLineN, int gColN, /*TableFormAndGridRepresentation cfg,*/ TableInfo TblInfExt = null, StringShaublin StrSampleExt=null,  TValsShowHide vsh = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            string s;
            s = GetContentCellCoSupplInfAndFmt(tLineN, tColN, TblInfExt, StrSampleExt);
            grid.Rows[gLineN].Cells[gColN].Value = s;
        }
        public void ContentCellCoSupplInfAndFmtToLineOfColHeaderGridCell(DataGridView grid, int tLineN, int tColN, int gColN, /*TableFormAndGridRepresentation cfg,*/ TableInfo TblInfExt = null, StringShaublin StrSampleExt = null, TValsShowHide vsh = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            string s;
            s = GetContentCellCoSupplInfAndFmt(tLineN, tColN, TblInfExt, StrSampleExt);
            grid.Columns[gColN].HeaderCell.Value = s;
        }
        public void ContentCellCoSupplInfAndFmtToColOfLineHeaderGridCell(DataGridView grid, int tLineN, int tColN, int gLineN, /*TableFormAndGridRepresentation cfg,*/ TableInfo TblInfExt = null, StringShaublin StrSampleExt = null, TValsShowHide vsh = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            string s;
            s = GetContentCellCoSupplInfAndFmt(tLineN, tColN, TblInfExt, StrSampleExt);
            grid.Rows[gLineN].HeaderCell.Value = s;
        }
        //
        public void ContentCellCoLineOfColHeaderCellToContentGridCell(DataGridView grid, int tLineN, int tColN, int gLineN, int gColN, int NameN=1, /*TableFormAndGridRepresentation cfg,*/ TableInfo TblInfExt = null, TValsShowHide vsh = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            string sH, sC, sS;
            sC = ToString(tLineN, tColN);
            sH=ToStringN_LineOfColHeader(tColN, NameN);
            sS = sH + " : " + sC;
            grid.Rows[gLineN].Cells[gColN].Value = sS;
        }
        public void ContentCellCoColOfLineHeaderCellToContentGridCell(DataGridView grid, int tLineN, int tColN, int gLineN, int gColN, int NameN = 1, /*TableFormAndGridRepresentation cfg,*/ TableInfo TblInfExt = null, TValsShowHide vsh = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
            string sH, sC, sS;
            sC = ToString(tLineN, tColN);
            sH = ToStringN_ColOfLineHeader(tLineN, NameN);
            sS = sH + " : " + sC;
            grid.Rows[gLineN].Cells[gColN].Value = sS;
        }
        //
        //
        //𳪳! newest vrn
        public void ToGrid(DataGridView grid, TableFormAndGridConfigurationMain FormGridCfg_, CellsNsToDisplay CellsToDisplay_=null,  TableInfo TblInf_ = null, TValsShowHide vsh = null)
        {
            //bool BoolVal;
            int QNamesLoCH = 0, MaxQNamesLoCH = 0, GenQNamesLoCH = 0;
            int QNamesCoLH = 0, MaxQNamesCoLH = 0, GenQNamesCoLH = 0;
            string s = "";
            string[] ss;
            int TypeN, length;
            DataCell cell;
            DataGridViewComboBoxCell TICBox;
            DataGridViewCheckBoxCell TCBCell;
            string sCheck;
            //
            //sCheck = CellsToDisplay_.ToString();
            //MessageBox.Show("bef clone\n" + sCheck);
            TableInfo _tblInf=this.Choose_TableInfo_StrSize_ByExtAndInner(TblInf_);
            CellsNsToDisplay _RowsNsToDispl=new CellsNsToDisplay(_tblInf.RowsQuantities);
            //CellsNsToDisplay _RowsNsToDispl = (CellsNsToDisplay)CellsToDisplay_.Clone();
            //sCheck = CellsToDisplay_.ToString();
            //MessageBox.Show("aft clone\n" + sCheck);
            //^ne influ
            if (CellsToDisplay_ != null)
            {
                _RowsNsToDispl = (CellsNsToDisplay)CellsToDisplay_.Clone();//Ns, ic wi displ'd 
            }
            //sCheck = CellsToDisplay_.ToString();
            //MessageBox.Show("aft clone\n" + sCheck);
            //sCheck = _RowsNsToDispl.ToString();
            //MessageBox.Show("cloned\n" + sCheck);
            _RowsNsToDispl.Correct(_tblInf.RowsQuantities);
            //sCheck = (_tblInf.RowsQuantities).ToString();
            //MessageBox.Show("QRowsInf\n" + sCheck);
            //sCheck = _RowsNsToDispl.ToString();
            //MessageBox.Show("corrected\n" + sCheck);
            //
            GridParamsCalculated GridParamsCalcd = new GridParamsCalculated(FormGridCfg_, /*CellsToDisplay_*/_RowsNsToDispl, TblInf_);
            //
            grid.RowCount = GridParamsCalcd.QGridLines;
            grid.ColumnCount = GridParamsCalcd.QGridColumns;
            //
            MyLib.writeln(vsh, "ToGrid starts working");
            this.Show(vsh);
            MyLib.writeln(vsh, "ToGrid itself");
            //
            int tLineN = 0, tColN = 0, gLineIndex = 0, gColIndex = 0;
            //
            MyLib.writeln(vsh, "Some params:");
            MyLib.writeln(vsh, "Grid content cells: " + grid.RowCount.ToString() + "x" + grid.ColumnCount.ToString());
            //MyLib.writeln(vsh, "ErstContentGridColIndex= " + ErstContentGridColIndex.ToString() + "ErstContentGridLineIndex= " + ErstContentGridLineIndex.ToString());
            //
            //ShowCells
            //Corner
            //if (GridParamsCalcd.LineOfColHeaderPresent == true || GridParamsCalcd.LineOfColHeaderPresent == true)
            if (GridParamsCalcd.ParamsGiven.LineOfColHeaderAreToShow == true || GridParamsCalcd.ParamsGiven.ColOfLineHeaderAreToShow == true)
            {
                //if (GridParamsCalcd.LineOfColHeaderPresent == true && GridParamsCalcd.LineOfColHeaderPresent == true)
                if (GridParamsCalcd.ParamsGiven.LineOfColHeaderAreToShow == true && GridParamsCalcd.ParamsGiven.ColOfLineHeaderAreToShow == true)
                {
                    s = GetCorner();
                }
                //else if (GridParamsCalcd.LineOfColHeaderPresent == true || GridParamsCalcd.LineOfColHeaderPresent == false)
                else if (GridParamsCalcd.ParamsGiven.LineOfColHeaderAreToShow == true || GridParamsCalcd.ParamsGiven.ColOfLineHeaderAreToShow == false)
                {
                    s = GetCorner() + ":" + ToString_LineOfColHeader(1);
                }
                //else if (GridParamsCalcd.LineOfColHeaderPresent == false || GridParamsCalcd.LineOfColHeaderPresent == true)
                else if (GridParamsCalcd.ParamsGiven.LineOfColHeaderAreToShow == false || GridParamsCalcd.ParamsGiven.ColOfLineHeaderAreToShow == true)
                {
                    s = GetCorner() + ":" + ToString_ColOfLineHeader(1);
                }//else no Corner
                MyLib.writeln(vsh, "Corner=" + s);
                //
                if (GridParamsCalcd.ParamsGiven.GridLineOfColHeaderIsInUse == true && GridParamsCalcd.ParamsGiven.GridColOfLineHeaderIsInUse == true)
                {
                    grid.TopLeftHeaderCell.Value = s;
                }
                else if (GridParamsCalcd.ParamsGiven.GridLineOfColHeaderIsInUse == true && GridParamsCalcd.ParamsGiven.GridColOfLineHeaderIsInUse == false)
                {
                    grid.Rows[0].HeaderCell.Value =s;
                }
                else if (GridParamsCalcd.ParamsGiven.GridLineOfColHeaderIsInUse == false && GridParamsCalcd.ParamsGiven.GridColOfLineHeaderIsInUse == true)
                {
                    grid.Columns[0].HeaderCell.Value = s;
                }
                else
                {
                    grid.Rows[0].Cells[0].Value = s;
                }
            }//else no Corner
            //
            //Headers
            //
            //LineOfColHeader
            //if (GridParamsCalcd.LineOfColHeaderPresent)
            if (GridParamsCalcd.ParamsGiven.LineOfColHeaderAreToShow)
            {
                for (int ColToDisplayOrderNatN = 1; ColToDisplayOrderNatN <= GridParamsCalcd.ParamsGiven.QTableContentColumnsToDisplay; ColToDisplayOrderNatN++)
                //for (int ColToDisplayOrderNatN = RowsNsToDispl.NsToDispl.ErstColumnN; ColToDisplayOrderNatN <= GridParamsCalcd.ParamsGiven.QTableContentColumnsToDisplay; ColToDisplayOrderNatN++)
                {
                    tColN = GridParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(ColToDisplayOrderNatN);
                    gColIndex = GridParamsCalcd.Calc_GridColIndex_ByColOrderNatNToDisplay(ColToDisplayOrderNatN);
                    //
                    if (GridParamsCalcd.ParamsGiven.GridLineOfColHeaderIsInUse)
                    {
                        //if (TblInf.GetIf_LoCHExists())
                        //{
                            //grid.Columns[gColIndex].HeaderCell.Value = ToString_LineOfColHeader(tColN);
                            //public string GetColumnHeaderCellCoSupplInfAsString(int N, TableInfo TblInfExt, int ReprPrior_Any0Grid1Text2 = 2)
                        grid.Columns[gColIndex].HeaderCell.Value = this.GetColumnHeaderCellCoSupplInfAsString(tColN, TblInf);
                            //if ce wu ne grid, ma text, so hin wu ne ToString_LineOfColHeader(), ma 
                        if(TblInf.GetIf_LoCHExists()){    
                            for (int ColNameNatN = 2; ColNameNatN <= GridParamsCalcd.ParamsGiven.QColsNamesToDisplay; ColNameNatN++)
                            {
                                tLineN = -2;
                                gLineIndex = ColNameNatN - 2;
                                if (ColNameNatN == 2) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName2_LineOfColHeader(tColN);
                                //else if (ColNameNatN == 3) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName3_LineOfColHeader(tColN);//2022-09-26
                            }
                        }
//}
                                                //else
                        //{
                        //    if(TblInf.Repr_Grid.num.
                        //}
                    }
                    else
                    {
                        grid.Rows[0].Cells[gColIndex].Value = ToString_LineOfColHeader(tColN);
                        for (int ColNameNatN = 2; ColNameNatN <= GridParamsCalcd.ParamsGiven.QColsNamesToDisplay; ColNameNatN++)
                        {
                            tLineN = -2;
                            gLineIndex = ColNameNatN - 1;
                            if (ColNameNatN == 2) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName2_LineOfColHeader(tColN);
                            //else if (ColNameNatN == 3) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName3_LineOfColHeader(tColN);//2022-09-26
                        }
                    }
                }
            }//LineOfColHeader
            //ColOfLineHeader
            //if (GridParamsCalcd.ColOfLineHeaderPresent)
            if (GridParamsCalcd.ParamsGiven.ColOfLineHeaderAreToShow)
            {
                //for (int i = 1; i <= CellsToDisplay.NsToDispl.QLines; i++)
                for (int LineToDisplayOrderN = 1; LineToDisplayOrderN <= GridParamsCalcd.ParamsGiven.QTableContentLinesToDisplay; LineToDisplayOrderN++)
                {
                    tLineN = GridParamsCalcd.Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineToDisplayOrderN);
                    if (GridParamsCalcd.ParamsGiven.GridLineOfColHeaderIsInUse == true)
                    {
                        gLineIndex = GridParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineToDisplayOrderN);
                        //grid.Rows[LineToDisplayOrderN - 1].HeaderCell.Value = ToString_ColOfLineHeader(tLineN);
                        grid.Rows[LineToDisplayOrderN - 1].HeaderCell.Value =GetLineHeaderCellCoSupplInfAsString(tLineN);
                        if (TblInf.GetIf_CoLHExists())
                        {
                            for (int LineNameN = 2; LineNameN <= GridParamsCalcd.ParamsGiven.QLinesNamesToDisplay; LineNameN++)
                            {
                                tColN = -2;
                                gColIndex = LineNameN - 2;
                                //
                                if (LineNameN == 2) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName2_ColOfLineHeader(tLineN);
                                //else if (LineNameN == 3) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName3_ColOfLineHeader(tLineN);//2022-09-06
                            }//for
                        }
                    }
                    else
                    {
                        gLineIndex = GridParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineToDisplayOrderN);
                        grid.Rows[gLineIndex].Cells[0].Value = ToString_ColOfLineHeader(tLineN);
                        for (int LineNameN = 2; LineNameN <= GridParamsCalcd.ParamsGiven.QLinesNamesToDisplay; LineNameN++)
                        {
                            tColN = -2;
                            gColIndex = LineNameN - 1;
                            //
                            if (LineNameN == 2) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName2_ColOfLineHeader(LineToDisplayOrderN);
                            //else if (LineNameN== 3) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName3_ColOfLineHeader(LineToDisplayOrderN);//2022-09-06
                        }//for
                    }
                }
            }//ColOfLineHeader
            //Display content cells
            for (int LineDisplayedOrderN = 1; LineDisplayedOrderN <= GridParamsCalcd.ParamsGiven.QTableContentLinesToDisplay; LineDisplayedOrderN++)
            {
                //tLineN = GridParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableNatN(LineDisplayedOrderN);
                tLineN = GridParamsCalcd.Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineDisplayedOrderN);
                gLineIndex = GridParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineDisplayedOrderN);
                for (int ColDisplayedOrderN = 1; ColDisplayedOrderN <= GridParamsCalcd.ParamsGiven.QTableContentColumnsToDisplay; ColDisplayedOrderN++)
                {
                    tColN = GridParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(ColDisplayedOrderN);
                    gColIndex = GridParamsCalcd.Calc_GridColIndex_ByColOrderNatNToDisplay(ColDisplayedOrderN);
                    if (LineDisplayedOrderN == 1)
                    {
                        DisplayContentTableCellToContentGridCell(grid, tLineN, tColN, gLineIndex, gColIndex, FormGridCfg_, CellsToDisplay_, TblInf_);
                    }
                    else if (ColDisplayedOrderN == 1)
                    {
                        DisplayContentTableCellToContentGridCell(grid, tLineN, tColN, gLineIndex, gColIndex, FormGridCfg_, CellsToDisplay_, TblInf_);
                    }
                    else if (LineDisplayedOrderN != 1 && ColDisplayedOrderN != 1)
                    {
                        DisplayContentTableCellToContentGridCell(grid, tLineN, tColN, gLineIndex, gColIndex, FormGridCfg_, CellsToDisplay_, TblInf_);
                    }
                }
            }
            MyLib.writeln(vsh, "ToGrid finishes working");
        }//fn grid unin
        //
        //public void ToGrid(DataGridView grid, TableFormAndGridConfigurationMain FormGridCfg, CellsNsToDisplay CellsToDisplayExt, TableInfo TblInfExt = null, TValsShowHide vsh = null)
        //{
        //    //bool BoolVal;
        //    TableInfo TblInf;
        //    //TableInfo GridStrAndHeadersSizes;
        //    CellsNsToDisplay CellsToDisplay;
        //    TableRepresentation TblRepr;
        //    //
        //    int QNamesLoCH = 0, MaxQNamesLoCH = 0, GenQNamesLoCH = 0;
        //    int QNamesCoLH = 0, MaxQNamesCoLH = 0, GenQNamesCoLH = 0;
        //    string s = "";
        //    string[] ss;
        //    int TypeN, length;
        //    DataCell cell;
        //    DataGridViewComboBoxCell TICBox;
        //    DataGridViewCheckBoxCell TCBCell;
        //    //
        //    //GridParamsCalculated GridParamsCalcd = new GridParamsCalculated();
        //    //
        //    MyLib.writeln(vsh, "ToGrid starts working");
        //    this.Show(vsh);
        //    MyLib.writeln(vsh, "ToGrid itself");
        //    //
        //    TblInf = Choose_TableInfo_StrSizeRepr_ByExtAndInner(TblInfExt);
        //    if (CellsToDisplayExt != null) CellsToDisplay = CellsToDisplayExt; else CellsToDisplay = new CellsNsToDisplay();
        //    //
        //    int tLineN = 0, tColN = 0, gLineIndex = 0, gColIndex = 0;
        //    //
        //    int ErstContentGridColIndex, ErstContentGridLineIndex;
        //    int QLinesNamesToDisplay, QColsNamesToDisplay;
        //    bool LineOfColHeaderExists, ColOfLineHeaderExists,
        //        LineOfColHeaderHidden, ColOfLineHeaderHidden,
        //        LineOfColHeaderPresent, ColOfLineHeaderPresent,
        //        LineOfColHeaderAbsent, ColOfLineHeaderAbsent,
        //        LineOfColHeaderExistsButHidden, ColOfLineHeaderExistsButHidden;
        //    bool GridLineOfColHeaderIsInUse, GridColOfLineHeaderIsInUse;
        //    //
        //    if (CellsToDisplayExt != null)
        //    {
        //        CellsToDisplay = CellsToDisplayExt;
        //        CellsToDisplay.Correct(TblInf.RowsQuantities);
        //    }
        //    else CellsToDisplay = new CellsNsToDisplay(TblInf.RowsQuantities);
        //    //
        //    GridParamsCalculated GridParamsCalcd = new GridParamsCalculated(FormGridCfg, CellsToDisplay, TblInf);
        //
        //    LineOfColHeaderExists = TblInf.Str.LineOfColHeaderExists;
        //    ColOfLineHeaderExists = TblInf.Str.ColOfLineHeaderExists;
        //    LineOfColHeaderHidden = !TblInf.Repr.GenRepr.ShowLineOfColHeader;
        //    ColOfLineHeaderHidden = !TblInf.Repr.GenRepr.ShowColOfLineHeader;
        //    LineOfColHeaderPresent = LineOfColHeaderExists && !LineOfColHeaderHidden;
        //    ColOfLineHeaderPresent = ColOfLineHeaderExists && !ColOfLineHeaderHidden;
        //    LineOfColHeaderAbsent = !LineOfColHeaderExists && !LineOfColHeaderHidden;
        //    ColOfLineHeaderAbsent = !ColOfLineHeaderExists && !ColOfLineHeaderHidden;
        //    LineOfColHeaderExistsButHidden = LineOfColHeaderExists && LineOfColHeaderHidden;
        //    ColOfLineHeaderExistsButHidden = ColOfLineHeaderExists && ColOfLineHeaderHidden;
        //    GridLineOfColHeaderIsInUse = FormGridCfg.LoCHGridRowUsed;//GridStrAndHeadersSizes.Str.LineOfColHeaderExists;
        //    GridColOfLineHeaderIsInUse = FormGridCfg.CoLHGridRowUsed;//GridStrAndHeadersSizes.Str.ColOfLineHeaderExists;
        //    QLinesNamesToDisplay = CellsToDisplay.QRowsNamesToDisplay.QColumns;// GridStrAndHeadersSizes.GetQColumns();
        //    QColsNamesToDisplay = CellsToDisplay.QRowsNamesToDisplay.QLines;//GridStrAndHeadersSizes.GetQLines();
        //
        //    Erst grid rows indexes
        //    if (GridParamsCalcd.LineOfColHeaderPresent == true)
        //    //if (LineOfColHeaderPresent == true)
        //    {
        //        //QColNamesToDisplay!=0=QColNamesToDisplay
        //        //if (GridLineOfColHeaderIsInUse == true)
        //        if (GridParamsCalcd.GridLineOfColHeaderIsInUse)
        //        {
        //            ErstContentGridLineIndex = 0 + QColsNamesToDisplay + 1 - 1 - 1; //+1 ob next, -1 ob from 0, -1 ob GridHeader s'used
        //        }
        //        else
        //        {
        //            ErstContentGridLineIndex = 0 + QColsNamesToDisplay + 1 - 1; //+1 ob next, -1 ob from 0, and  GridHeader ne s'used
        //        }
        //    }
        //    else
        //    {
        //        if (GridLineOfColHeaderIsInUse == true)
        //        {
        //            ErstContentGridLineIndex = -1; // -1 ob GridHeader s'used, et ne uz header, ma uz content - non-natural case
        //        }
        //        else
        //        {
        //            ErstContentGridLineIndex = 0; //simply content grisd cells
        //        }
        //    }//ErstContentGridLineIndex
        //    //ErstContentGridColIndex
        //    if (ColOfLineHeaderPresent == true)
        //    {
        //        if (GridColOfLineHeaderIsInUse == true)
        //        {
        //            ErstContentGridColIndex = 0 + QLinesNamesToDisplay + 1 - 1 - 1; //+1 ob next, -1 ob from 0, -1 ob GridHeader s'used
        //        }
        //        else
        //        {
        //            ErstContentGridColIndex = 0 + QLinesNamesToDisplay + 1 - 1; //+1 ob next, -1 ob from 0,  GridHeader s' ne used
        //        }
        //    }
        //    else
        //    {
        //        if (GridColOfLineHeaderIsInUse == true)
        //        {
        //            ErstContentGridColIndex = -1; //header grid cells for content tabke cells, innatural case
        //        }
        //        else
        //        {
        //            ErstContentGridColIndex = 0; //simply content, 1:1
        //        }
        //    }//ErstContentGridColIndex
        //    //
        //    if (GridLineOfColHeaderIsInUse) grid.RowCount = CellsToDisplay.NsToDispl.QLines + QLinesNamesToDisplay + ErstContentGridLineIndex-1-1;
        //    else grid.RowCount = CellsToDisplay.NsToDispl.QLines + QLinesNamesToDisplay + ErstContentGridLineIndex-1;
        //    if (GridLineOfColHeaderIsInUse) grid.ColumnCount = CellsToDisplay.NsToDispl.QColumns + QColsNamesToDisplay + ErstContentGridColIndex - 1 - 1;
        //    else grid.ColumnCount = CellsToDisplay.NsToDispl.QColumns + QColsNamesToDisplay + ErstContentGridColIndex - 1;
        //    //
        //    MyLib.writeln(vsh, "Some params:");
        //    MyLib.writeln(vsh, "Grid content cells: " + grid.RowCount.ToString() + "x" + grid.ColumnCount.ToString());
        //    MyLib.writeln(vsh, "ErstContentGridColIndex= " + ErstContentGridColIndex.ToString() + "ErstContentGridLineIndex= " + ErstContentGridLineIndex.ToString());
        //    //
        //    //ShowCells
        //    //Corner
        //    if (LineOfColHeaderPresent == true || LineOfColHeaderPresent == true)
        //    {
        //        if (LineOfColHeaderPresent == true && LineOfColHeaderPresent == true)
        //        {
        //            s = GetCorner();
        //        }
        //        else if (LineOfColHeaderPresent == true || LineOfColHeaderPresent == false)
        //        {
        //            s = GetCorner() + ":" + ToString_LineOfColHeader(1);
        //        }
        //        else if (LineOfColHeaderPresent == false || LineOfColHeaderPresent == true)
        //        {
        //            s = GetCorner() + ":" + ToString_ColOfLineHeader(1);
        //        }//else no Corner
        //        MyLib.writeln(vsh, "Corner=" + s);
        //        //
        //        if (GridLineOfColHeaderIsInUse == true && GridColOfLineHeaderIsInUse == true)
        //        {
        //            grid.TopLeftHeaderCell.Value = s;
        //        }
        //        else if (GridLineOfColHeaderIsInUse == true && GridColOfLineHeaderIsInUse == false)
        //        {
        //            grid.Rows[0].HeaderCell.Value = s;
        //        }
        //        else if (GridLineOfColHeaderIsInUse == false && GridColOfLineHeaderIsInUse == true)
        //        {
        //            grid.Columns[0].HeaderCell.Value = s;
        //        }
        //        else
        //        {
        //            grid.Rows[0].Cells[0].Value = s;
        //        }
        //    }//else no Corner
        //    //Content
        //    for (int i = 1; i <= CellsToDisplay.NsToDispl.QLines; i++)
        //    {
        //        gLineIndex = i + ErstContentGridLineIndex - 1;
        //        tLineN = CellsToDisplay.NsToDispl.ErstLineN + i - 1;
        //        for (int j = 1; j <= CellsToDisplay.NsToDispl.QColumns; j++)
        //        {
        //            gColIndex = j + ErstContentGridColIndex - 1;
        //            tColN = CellsToDisplay.NsToDispl.ErstColumnN + j - 1;
        //            //
        //            if (gLineIndex == -1 && gColIndex == -1)
        //            {
        //                grid.TopLeftHeaderCell.Value = ToString(tLineN, tColN);
        //            }
        //            else if (gLineIndex == -1 && gColIndex > -1)
        //            {
        //                grid.Rows[gLineIndex].HeaderCell.Value = ToString(tLineN, tColN);
        //            }
        //            else if (gLineIndex > -1 && gColIndex == -1)
        //            {
        //                grid.Columns[gColIndex].HeaderCell.Value = ToString(tLineN, tColN);
        //            }
        //            else
        //            {
        //                //grid.Rows[gLineIndex].Cells[gColIndex].Value = ToString(tLineN, tColN);
        //                //no, depending of grid cell type
        //                //public void DisplayContentTableCellToContentGridCell(DataGridView grid, int tLineN, int tColN, int gLineIndex, int gColIndex, /*TableFormAndGridConfigurationAll cfg,*/TableFormAndGridConfigurationMain cfgExt, CellsNsToDisplay NsToDisplExt, TableRepresentation ReprExt, TableInfo TblInfExt = null)
        //                DisplayContentTableCellToContentGridCell(grid, tLineN, tColN, gLineIndex, gColIndex, FormGridCfg, CellsToDisplay, TblInf);
        //            }
        //        }//for j
        //    }//for i
        //    //
        //    //Headers
        //    //
        //    //LineOfColHeader
        //    if (LineOfColHeaderPresent)
        //    {
        //        for (int i = 1; i <= CellsToDisplay.NsToDispl.QColumns; i++)
        //        {
        //            tColN = CellsToDisplay.NsToDispl.ErstLineN + i - 1; //-1 ob erst Name =i
        //            if (GridColOfLineHeaderIsInUse == true)
        //            {
        //                gColIndex = QLinesNamesToDisplay - 1 + i - 1;
        //            }
        //            else
        //            {
        //                gColIndex = QLinesNamesToDisplay + i - 1;
        //            }
        //            //
        //            if (GridLineOfColHeaderIsInUse)
        //            {
        //                grid.Columns[i - 1].HeaderCell.Value = ToString_LineOfColHeader(i);
        //                for (int j = 2; j <= QColsNamesToDisplay; j++)
        //                {
        //                    tLineN = CellsToDisplay.NsToDispl.ErstLineN + i - 1; //-1 ob erst Name =i
        //                    gLineIndex = QColsNamesToDisplay - 1 + i - 1;
        //                    if (j == 2) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName2_LineOfColHeader(i);
        //                    else if (j == 3) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName3_LineOfColHeader(i);
        //                }
        //            }
        //            else
        //            {
        //                grid.Rows[0].Cells[i - 1].Value = ToString_LineOfColHeader(i);
        //                for (int j = 2; j <= QColsNamesToDisplay; j++)
        //                {
        //                    tLineN = CellsToDisplay.NsToDispl.ErstLineN + i - 1; //-1 ob erst Name =i
        //                    gLineIndex = QColsNamesToDisplay + i - 1;
        //                    if (j == 2) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName2_LineOfColHeader(i);
        //                    else if (j == 3) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName3_LineOfColHeader(i);
        //                }
        //            }
        //        }
        //    }//LineOfColHeader
        //    //ColOfLineHeader
        //    if (ColOfLineHeaderPresent)
        //    {
        //        for (int i = 1; i <= CellsToDisplay.NsToDispl.QLines; i++)
        //        {
        //            tLineN = CellsToDisplay.NsToDispl.ErstLineN + i - 1; //-1 ob erst Name =i
        //            if (GridLineOfColHeaderIsInUse == true)
        //            {
        //                gLineIndex = QColsNamesToDisplay - 1 + i - 1; //erst -1 ob grid header s'use'd, scnd -1 s' ob Ns start ab 0.
        //                grid.Rows[i - 1].HeaderCell.Value = ToString_ColOfLineHeader(i);
        //                for (int j = 2; j <= QLinesNamesToDisplay; j++)
        //                {
        //                    tColN = CellsToDisplay.NsToDispl.ErstLineN + i - 1; //-1 ob erst Name =i
        //                    gColIndex = QLinesNamesToDisplay - 1 + i - 1; //erst -1 s' 񨠇rid Hdr row s' in use/ Scnd -1 s' ob Ns start ab 0. 
        //                    //
        //                    if (j == 2) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName2_ColOfLineHeader(i);
        //                    else if (j == 3) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName3_ColOfLineHeader(i);
        //                }//for
        //            }
        //            else
        //            {
        //                gLineIndex = QColsNamesToDisplay + i - 1;
        //                grid.Rows[i - 1].Cells[0].Value = ToString_ColOfLineHeader(i);
        //                for (int j = 2; j <= QLinesNamesToDisplay; j++)
        //                {
        //                    tColN = CellsToDisplay.NsToDispl.ErstLineN + i - 1; //-1 ob erst Name =i
        //                    gColIndex = QLinesNamesToDisplay + i - 1; //e-1 s' ob Ns start ab 0. Grid CoLH ne s'us'd, its existance ne influences l'Ns
        //                    //
        //                    if (j == 2) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName2_ColOfLineHeader(i);
        //                    else if (j == 3) grid.Rows[gLineIndex].Cells[gColIndex].Value = GetName3_ColOfLineHeader(i);
        //                }//for
        //            }
        //        }
        //    }//ColOfLineHeader
        //    //Display content cells
        //    for (int i = 1; i <= CellsToDisplay.NsToDispl.QLines; i++)
        //    {
        //        tLineN = CellsToDisplay.NsToDispl.ErstLineN + i - 1;
        //        gLineIndex = ErstContentGridLineIndex + i - 1;
        //        for (int j = 1; j <= CellsToDisplay.NsToDispl.QColumns; j++)
        //        {
        //            tColN = CellsToDisplay.NsToDispl.ErstColumnN + j - 1;
        //            gColIndex = ErstContentGridColIndex + j - 1;
        //            if (i == 1)
        //            {
        //                DisplayContentTableCellToContentGridCell(grid, tLineN, tColN, gLineIndex, gColIndex, FormGridCfg, CellsToDisplay, TblInf);
        //            }
        //            else if (j == 1)
        //            {
        //                DisplayContentTableCellToContentGridCell(grid, tLineN, tColN, gLineIndex, gColIndex, FormGridCfg, CellsToDisplay, TblInf);
        //            }
        //            else if (i != 1 && j != 1)
        //            {
        //                DisplayContentTableCellToContentGridCell(grid, tLineN, tColN, gLineIndex, gColIndex, FormGridCfg, CellsToDisplay, TblInf);
        //            }
        //        }
        //    }
        //    MyLib.writeln(vsh, "ToGrid finishes working");
        //}//fn grid unin
        
        //
        //
        public int ColHeaderHasSameTypeN(TableInfo TblInfExt=null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell;
            int TypeN=0, ErstTypeN=0, QColumns=GetQColumns();
            bool verdict=true;
            //if(GetIfLineOfColHeaderExists()){ //let it be - no
            if (LineOfColHeader!=null)
            {
                cell = GetCell(0, 1, TblInf.GetTableInfo_ConcrRepr());
                ErstTypeN=cell.GetTypeN();
                for(int i=2; i<=QColumns; i++){
                    cell = GetCell(0, i, TblInf.GetTableInfo_ConcrRepr());
                    TypeN=cell.GetTypeN();
                    if(TypeN!=ErstTypeN)verdict=false;
                }
            }else verdict=false;
            if(verdict==false)TypeN=0;//else Erst, so s' auto'y
            return TypeN;
        }
        public int LineHeaderHasSameTypeN(TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell;
            int TypeN=0, ErstTypeN=0, QLines=GetQLines();
            bool verdict=true;
            //if(GetIfLineOfColHeaderExists()){
            if(LineOfColHeader!=null){
                cell = GetCell(1, 0, TblInf.GetTableInfo_ConcrRepr());
                ErstTypeN=cell.GetTypeN();
                for(int i=2; i<=QLines; i++){
                    cell = GetCell(i, 0, TblInf.GetTableInfo_ConcrRepr());
                    TypeN=cell.GetTypeN();
                    if(TypeN!=ErstTypeN)verdict=false;
                }
            }else verdict=false;
            if(verdict==false)TypeN=0;//else Erst, so s' auto'y
            return TypeN;
        }
        public int ContentLineHasSameTypeN(int N, TableInfo TblInfExt=null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell;
            int TypeN=0, ErstTypeN=0, QColumns=GetQColumns();
            bool verdict=true;
            //if(GetIfLineOfColHeaderExists()){
            if(LineOfColHeader!=null){
                cell = GetCell(N, 1, TblInf.GetTableInfo_ConcrRepr());
                ErstTypeN=cell.GetTypeN();
                for(int i=2; i<=QColumns; i++){
                    cell = GetCell(N, i, TblInf.GetTableInfo_ConcrRepr());
                    TypeN=cell.GetTypeN();
                    if(TypeN!=ErstTypeN)verdict=false;
                }
            }else verdict=false;
            if(verdict==false)TypeN=0;//else Erst, so s' auto'y
            return TypeN;
        }
        public int ContentColumnHasSameTypeN(int N, TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell;
            int TypeN=0, ErstTypeN=0, QLines=GetQLines();
            bool verdict=true;
            if(GetIfLineOfColHeaderExists()){
                cell = GetCell(1, N, TblInf.GetTableInfo_ConcrRepr());
                ErstTypeN=cell.GetTypeN();
                for(int i=2; i<=QLines; i++){
                    cell = GetCell(i, N, TblInf.GetTableInfo_ConcrRepr());
                    TypeN=cell.GetTypeN();
                    if(TypeN!=ErstTypeN)verdict=false;
                }
            }else verdict=false;
            if(verdict==false)TypeN=0;//else Erst, so s' auto'y
            return TypeN;
        }
        public int ContentHasSameTypeN(TableInfo TblInfExt = null)
        {
            DataCell cell;
            int TypeN, ErstTypeN, QLines, QColumns;
            bool verdict = true;
            TypeN = 0; ErstTypeN = 0; QLines = GetQLines();  QColumns = GetQColumns();
            if (GetIfLineOfColHeaderExists())
            {
                cell = GetCell(1, 1, TblInf.GetTableInfo_ConcrRepr());
                ErstTypeN = cell.GetTypeN();
                for (int i = 2; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        cell = GetCell(i, j, TblInf.GetTableInfo_ConcrRepr());
                        TypeN = cell.GetTypeN();
                        if (TypeN != ErstTypeN) verdict = false;
                    }
                }
            }
            else verdict = false;
            if (verdict == false) TypeN = 0;//else Erst, so s' auto'y
            return TypeN;
        }
        //
        /*public int GetErstNOfLineHeaderByName(string name)
        {
            int N, count, QLines, QColumns;
            string s;
            N = 0; count = 0;
            if (GetIfColOfLineHeaderExists() == true)
            {
                QLines=GetQLines();
                QColumns=GetQColumns();
                for (int i = QLines; i >= 1; i--)
                {
                    s = ColOfLineHeader[i - 1].ToString();
                    if (s.Equals(name))
                    {
                        count++;
                        N = i;
                    }
                }
            }
            return N;
        }
        public int GetErstNOfColumnHeaderByName(string name)
        {
            int N, count, QLines, QColumns;
            string s;
            N = 0; count = 0;
            if (GetIfColOfLineHeaderExists() == true)
            {
                QLines = GetQLines();
                QColumns = GetQColumns();
                for (int i = QColumns; i >= 1; i--)
                {
                    s = LineOfColHeader[i - 1].ToString();
                    if (s.Equals(name))
                    {
                        count++;
                        N = i;
                    }
                }
            }
            return N;
        }//fn
        */
        //mark12
        public int GetLineHeaderNByName(string name, int NameN=1, TableInfo TblInfExt=null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int N, count, QLines, QColumns;
            string s;
            N = 0; count = 0;
            if (GetIfColOfLineHeaderExists() == true)
            {
                QLines = TblInf.GetQLines();
                QColumns = TblInf.GetQColumns();
                for (int i = QLines; i >= 1; i--)
                {
                    s = ColOfLineHeader[i - 1].ToStringN(NameN);
                    if (s.Equals(name))
                    {
                        count++;
                        N = i;
                    }
                }
            }
            return N;
        }
        public int GetColumnHeaderNByName(string name, int NameN=1, TableInfo TblInfExt=null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int N, count, QLines, QColumns;
            string s;
            N = 0; count = 0;
            if (GetIfColOfLineHeaderExists() == true)
            {
                QLines = TblInf.GetQLines();
                QColumns = TblInf.GetQColumns();
                for (int i = QColumns; i >= 1; i--)
                {
                    s = LineOfColHeader[i - 1].ToStringN(NameN);
                    if (s.Equals(name))
                    {
                        count++;
                        N = i;
                    }
                }
            }
            return N;
        }//fn
        public bool GetIfLineNameExists(string name, int NameN = 1, TableInfo TblInfExt = null)
        {
            return (GetLineHeaderNByName(name, NameN, TblInfExt)!=0);
        }
        public bool GetIfColumnNameExists(string name, int NameN = 1, TableInfo TblInfExt = null)
        {
            return (GetColumnHeaderNByName(name, NameN, TblInfExt) != 0);
        }
        //mark12
        //public string GetCellAsStringCoSupplInf(int LineN, int ColN, 
        public void ReadString2DArrayFromGrid(DataGridView grid, ref string[][]data, ref int QLines, ref int QColumns, bool UseGridLoCH = true, bool UseGridCoLH = true, bool LoCHExists=true, bool CoLHExists=true, CellsNsToDisplay NsExt = null){
            QLines = grid.Rows.Count; QColumns = grid.Columns.Count;
            if (UseGridLoCH) QLines++;
            if (UseGridCoLH) QColumns++;
            data = new string[QLines][];
            for (int i = 1; i <= QLines; i++) data[i - 1] = new string[QColumns];
            if (UseGridLoCH)
            {
                if (UseGridCoLH)
                {
                   
                }
                else
                {

                }

            }
            else
            {
                if (UseGridCoLH)
                {

                }
                else
                {

                }
            }
        }
        public void SetFromGrid(DataGridView grid, TableStructure StrExt = null, CellsNsToDisplay NsExt = null, bool UseGridLoCH = true, bool UseGridCoLH = true, TableReadingTypesParams TypesAllowed = null, bool WriteInfo = false)
        {
            // not finished
            DataCell[][] ContentCell=null;
            DataCell[] LineOfColHeader = null, ColOfLineHeader = null;
            TableInfo TblInf = new TableInfo();
            TableSize GridFacticSize = new TableSize(), ContentSizeMax = new TableSize();
            CellsNsToDisplay Ns;
            //GridParamsGiven GridParams;
            GridParamsCalculated GridParams;
            //
            DataGridViewComboBoxCell gridComboBoxCell;
            DataGridViewCheckBoxCell gridCheckBoxCell;
            DataGridViewTextBoxCell gridTextBoxCell;
            //
            string CurStr, CurItemStr, CurCellTxt;
            int CurN, CurQItems;
            int QGridLines = grid.Rows.Count, QGridColumns = grid.Columns.Count, QContentLinesExisting, QContentColumnsExisting, QContentLinesToWrite, QContentColumnsToWrite, QColsOfLinesNames = 1, QLinesOfColsNames = 1, ErstGridContentLineIndex = 0, ErstGridContentColumnIndex = 0, CurGridContentLineIndex, CurGridContentColumnIndex, CurContentLineN, CurContentColumnN;
            if (StrExt != null) TblInf.Str = StrExt; else TblInf.Str = new TableStructure();
            //if (NsExt != null) Ns = NsExt; else Ns = new CellsNsToDisplay();
            QColsOfLinesNames = 1; QLinesOfColsNames = 1;
            if (UseGridCoLH) GridFacticSize.QLines = grid.Rows.Count + 1; else GridFacticSize.QLines = grid.Rows.Count;
            if (UseGridLoCH) GridFacticSize.QColumns = grid.Columns.Count + 1; else GridFacticSize.QColumns = grid.Columns.Count;
            //Ns.Correct(GridFacticSize);
            //QContentLinesToShow=Ns.QLines;  QContentColumnsToShow=Ns.QColumns;
            if (TblInf.GetIf_CoLHExists())
            {
                if (UseGridCoLH)
                {
                    QContentLinesExisting = (QGridLines + 1) - QLinesOfColsNames;
                    ErstGridContentLineIndex = QLinesOfColsNames+1 - 1-1; //next; N from 0, Header
                }
                else
                {
                    QContentLinesExisting = QGridLines - QLinesOfColsNames;
                    ErstGridContentLineIndex = QLinesOfColsNames + 1 - 1;  //next; N from 0
                }
            }
            else
            {
                QContentLinesExisting = QGridLines;
                ErstGridContentLineIndex = 0;
            }
            //
            if (TblInf.GetIf_LoCHExists())
            {
                if (UseGridLoCH)
                {
                    QContentColumnsExisting = (QGridColumns + 1) - QColsOfLinesNames;
                    ErstGridContentColumnIndex = QColsOfLinesNames+1 - 1 - 1; //-1 ob one is header
                }
                else
                {
                    QContentColumnsExisting = QGridColumns - QColsOfLinesNames;
                    ErstGridContentColumnIndex = QColsOfLinesNames - 1;
                }
            }
            else
            {
                QContentColumnsExisting = QGridColumns;
                ErstGridContentColumnIndex = 0;
            }
            ContentSizeMax.QLines = QContentLinesExisting; ContentSizeMax.QColumns = QContentColumnsExisting;
            if (NsExt != null) Ns = NsExt; else Ns = new CellsNsToDisplay(ContentSizeMax);
            //Ns.Correct(ContentSizeMax);
            QContentLinesToWrite = Ns.NsToDispl.QLines; QContentColumnsToWrite = Ns.NsToDispl.QColumns;
            TblInf.RowsQuantities = new TableSize(QContentLinesToWrite, QContentColumnsToWrite);
            //Ns = new CellsNsToDisplay(TblInf.RowsQuantities);
            MessageBox.Show("QContentLinesExisting=" + QContentLinesToWrite.ToString() + " QContentLinesToWrite=" + QContentLinesToWrite.ToString() + " ErstGridContentLineIndex=" + ErstGridContentLineIndex.ToString()
                +"\n"+
                "QContentColumnsExisting=" + QContentColumnsToWrite.ToString() + " QContentColumnToWrite=" + QContentColumnsToWrite.ToString() + " ErstGridContentColumnIndex=" + ErstGridContentColumnIndex.ToString());
            GridParams = new GridParamsCalculated(new TableHeaderRowsExistance(UseGridCoLH, UseGridLoCH), Ns, TblInf);
            //
            if (TblInf.GetIf_LC_Not_CL())
            {
                if (TblInf.GetIf_CoLHExists())
                {
                    if (UseGridCoLH)
                    {
                        ContentCell = new DataCell[QContentLinesToWrite][];
                        //ContentCell = new DataCell[QContentLinesExisting][];
                        //for (CurGridContentLineIndex = ErstGridContentLineIndex; CurGridContentLineIndex <= (ErstGridContentLineIndex + QContentLinesToWrite); CurGridContentLineIndex++)
                        for (CurContentLineN = 1; CurContentLineN <= QContentLinesToWrite; CurContentLineN++)
                        {
                            CurGridContentLineIndex = GridParams.Calc_GridLineIndex_ByTableLineNatN(CurContentLineN);
                            //CurContentLineN = CurGridContentLineIndex - ErstGridContentLineIndex + 1;
                            //for (CurGridContentColumnIndex = ErstGridContentColumnIndex; CurGridContentColumnIndex <= (ErstGridContentColumnIndex + QContentColumnsToWrite); CurGridContentColumnIndex++)
                            //ContentCell[CurContentLineN - 1] = new DataCell[QContentColumnsExisting];
                            ContentCell[CurContentLineN - 1] = new DataCell[QContentColumnsToWrite];
                            for (CurContentColumnN = 1; CurContentColumnN <= QContentColumnsToWrite; CurContentColumnN++)
                            {
                                CurGridContentColumnIndex = GridParams.Calc_GridColIndex_ByTableColNatN(CurContentColumnN);
                                //CurContentColumnN = CurGridContentColumnIndex - ErstGridContentColumnIndex + 1;
                                //
                                if (CurGridContentLineIndex == -1 && CurGridContentColumnIndex == -1){
                                    CurStr = grid.TopLeftHeaderCell.Value.ToString();
                                }else if(CurGridContentLineIndex == -1 && CurGridContentColumnIndex >=0){
                                    CurStr = grid.Columns[CurGridContentColumnIndex].HeaderCell.Value.ToString();
                                }else if(CurGridContentLineIndex >=0 && CurGridContentColumnIndex ==-1){
                                    CurStr = grid.Rows[CurGridContentLineIndex].HeaderCell.Value.ToString();
                                }else{
                                    if (grid.Rows[CurGridContentLineIndex].Cells[CurGridContentColumnIndex] is DataGridViewComboBoxCell)
                                    {
                                        //
                                        CurCellTxt="";
                                        CurQItems=0;
                                        CurN=0;
                                        gridComboBoxCell=(DataGridViewComboBoxCell)grid.Rows[CurGridContentLineIndex].Cells[CurGridContentColumnIndex];
                                        CurCellTxt=gridComboBoxCell.Value.ToString();
                                        CurQItems=gridComboBoxCell.Items.Count;
                                        for(int i=1; i<=CurQItems; i++){
                                            CurItemStr=gridComboBoxCell.Items[i-1].ToString();
                                            if(CurCellTxt.Equals(CurItemStr)){
                                                CurN=i;
                                                CurStr=CurItemStr;
                                            }
                                        }
                                        //if()CurStr=
                                        //ContentCell[CurContentLineN-1][CurContentColumnN-1]=new DataCell(
                                    }
                                    else if (grid.Rows[CurGridContentLineIndex].Cells[CurGridContentColumnIndex] is DataGridViewCheckBoxCell)
                                    {
                                        gridCheckBoxCell = (DataGridViewCheckBoxCell)grid.Rows[CurGridContentLineIndex].Cells[CurGridContentColumnIndex];
                                        ContentCell[CurContentLineN - 1][CurContentColumnN - 1] = new DataCell((bool)gridCheckBoxCell.Value);
                                    }
                                    else if (grid.Rows[CurGridContentLineIndex].Cells[CurGridContentColumnIndex] is DataGridViewTextBoxCell)
                                    {
                                        gridTextBoxCell = (DataGridViewTextBoxCell)grid.Rows[CurGridContentLineIndex].Cells[CurGridContentColumnIndex];
                                        //ContentCell[CurContentLineN - 1][CurContentColumnN - 1] = new DataCell((string)gridTextBoxCell.Value);
                                        ContentCell[CurContentLineN - 1][CurContentColumnN - 1] = new DataCell(gridTextBoxCell.Value.ToString());
                                    }
                                    else
                                    {
                                        ContentCell[CurContentLineN - 1][CurContentColumnN - 1] = new DataCell(grid.Rows[CurGridContentLineIndex].Cells[CurGridContentColumnIndex].Value.ToString());
                                    }
                                }
                            }
                        }
                    }
                    else //UseGridCoLH=false
                    {

                    }
                }
                else
                {

                }
                if (TblInf.GetIf_LoCHExists())
                {
                    if (UseGridLoCH)
                    {

                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            else//LCnotCL=false
            {
                if (TblInf.GetIf_CoLHExists())
                {
                    if (UseGridCoLH)
                    {

                    }
                    else
                    {

                    }
                }
                else
                {

                }
                if (TblInf.GetIf_LoCHExists())
                {
                    if (UseGridLoCH)
                    {

                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
        }//fn
        /*
        public void FillIntArray(int value, int Quantity, ref int[] Array)
        {
            Array = new int[Quantity];
            for (int i = 1; i <= Quantity; i++)
            {
                Array[i - 1] = value;
            }
        }
        //
        DataCell SetDataCellFromStringValParsing(string val, TableReadingTypesParams rules)
            //exchange conversion to numbers to own from NumberParse!
        {
            DataCell cell = null;
            double xd;
            int xi;
            bool xb;
            int Type_Str1Real2Int3Bool4 = 1;
            int NumberType_No0Real1Int2=NumberParse.IsCorrectNumber_No0Real1Int2(val);
            if (NumberType_No0Real1Int2 > 0)
            {
                if (MyLib.IsCorrectBool(val))
                {
                    if (rules.BoolPriorThanStr)
                    {
                        if (MyLib.IsTrue(val)) cell = new DataCell(true);
                        else if (MyLib.IsFalse(val)) cell = new DataCell(false);
                        else cell = new DataCell(val);
                    }
                    else
                    {
                        if (NumberType_No0Real1Int2 == 2)
                        {
                            if (rules.IntPriorThanReal) cell = new DataCell(Convert.ToInt32(val));
                            else if (rules.RealPriorThanStr) cell = new DataCell(Convert.ToDouble(val));
                            else cell = new DataCell(val);
                        }
                        else
                        {
                            if (rules.RealPriorThanStr) cell = new DataCell(Convert.ToDouble(val));
                            else cell = new DataCell(val);
                        }
                    }
                }
                else
                { //not bool
                    if (NumberType_No0Real1Int2 == 2)
                    {  //int number
                        if (rules.BoolPriorThanInt)
                        {
                            if (Convert.ToInt32(val) == 1) cell = new DataCell(true);
                            else if (Convert.ToInt32(val) == 0) cell = new DataCell(false);
                            else
                            {
                                if (rules.IntPriorThanReal) cell = new DataCell(Convert.ToInt32(val));
                                else if (rules.RealPriorThanStr) cell = new DataCell(Convert.ToDouble(val));
                                else cell = new DataCell(val);
                            }
                        }
                        else
                        {//val is int, ma ne allowed int to bool
                            if (rules.IntPriorThanReal) cell = new DataCell(Convert.ToInt32(val));
                            else if (rules.RealPriorThanStr) cell = new DataCell(Convert.ToDouble(val));
                            else cell = new DataCell(val);
                        }
                    }
                    else if (NumberType_No0Real1Int2 == 1) //real number
                    {
                        if (rules.RealPriorThanStr) cell = new DataCell(Convert.ToDouble(val));
                        else cell = new DataCell(val);
                    }
                    else
                    { //not a number
                        //including val="";
                        cell = new DataCell(val);
                    }
                }
            }
            else cell = new DataCell(val); 
            return cell;
        }
        */
        //ce - to redo! Ne ab 2 to start, ma ab QColumnsForHeaders!
        public void SetFromStringArray2(string[][] arr, TableSize QCellsForHeaderNames, TableReadingTypesParams ReadParamsExt=null, TableInfo TblStrAndArraySizeInfExt=null, int WriteInfoAsWas0No1Yes2=0)
        {
            int zero = 0;
            string s;
            bool WriteInfo;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblStrAndArraySizeInfExt);
            TableReadingTypesParams ReadParams;
            DataCell cell = null;
            if (ReadParamsExt != null) ReadParams = ReadParamsExt; else ReadParams = new TableReadingTypesParams();
            //this.SetSize(TblInf.RowsQuantities.QLines, TblInf.RowsQuantities.QColumns);
            int QContentLines, QContentColumns, ErstLineNOfArrayForContent, LastLineNOfArrayForContent, ErstColumnNOfArrayForContent, LastColumnNOfArrayForContent;
            if (TblInf.Str.LineOfColHeaderExists)
            {
                QContentColumns = TblInf.RowsQuantities.QColumns - QCellsForHeaderNames.QColumns;//-1
                ErstColumnNOfArrayForContent = QCellsForHeaderNames.QColumns+1;// 2;
                LastColumnNOfArrayForContent = TblInf.RowsQuantities.QColumns;
            }
            else
            {
                QContentColumns = TblInf.RowsQuantities.QColumns;
                ErstColumnNOfArrayForContent = 1;
                LastColumnNOfArrayForContent = TblInf.RowsQuantities.QColumns;
            }
            if (TblInf.Str.ColOfLineHeaderExists)
            {
                QContentLines = TblInf.RowsQuantities.QLines - QCellsForHeaderNames.QLines;//1;
                ErstLineNOfArrayForContent = QCellsForHeaderNames.QLines+1;//2;
                LastLineNOfArrayForContent = TblInf.RowsQuantities.QLines;
            }
            else
            {
                QContentLines = TblInf.RowsQuantities.QLines;
                ErstLineNOfArrayForContent = 1;
                LastLineNOfArrayForContent = TblInf.RowsQuantities.QLines;
            }
            if(ReadParamsExt!=null) ReadParams=ReadParamsExt; else ReadParams=new TableReadingTypesParams();
            //
            if(WriteInfoAsWas0No1Yes2==2 || WriteInfoAsWas0No1Yes2==0 && this.TblInf!=null) WriteInfo=true; else WriteInfo=false;
            if (TblInf.Str.LC_Matrix_Not_CL_DB)
            {
                this.ContentCell = new DataCell[QContentLines][];
                for (int i = 1; i <= QContentLines; i++)
                {
                    this.ContentCell[i - 1] = new DataCell[QContentColumns];
                }
                for (int i = ErstLineNOfArrayForContent/*2*/; i<= LastLineNOfArrayForContent/*TblInf.RowsQuantities.QColumns*/; i++){
                    for (int j = ErstColumnNOfArrayForContent/*2*/; j <= LastColumnNOfArrayForContent/*TblInf.RowsQuantities.QColumns*/; j++)
                    {
                        //cell = SetDataCellFromStringVal(arr[i - 1][j - 1], ReadParams);
                        s = arr[i - 1][j - 1];
                        cell = MyLib.SetDataCellFromStringValParsing(s, ReadParams);
                         this.ContentCell[i - ErstLineNOfArrayForContent][j - ErstColumnNOfArrayForContent] = cell;
                    }//for
                }//for   
            }else{ //not Matrix, but DB
                this.ContentCell = new DataCell[QContentColumns][];
                for (int i = 1; i <= QContentColumns; i++)
                {
                    this.ContentCell[i - 1] = new DataCell[QContentLines];
                }
                for (int i = ErstLineNOfArrayForContent/*2*/; i <= LastLineNOfArrayForContent/*TblInf.RowsQuantities.QColumns*/; i++)
                {
                    for (int j = ErstColumnNOfArrayForContent/*2*/; j <= LastColumnNOfArrayForContent/*TblInf.RowsQuantities.QColumns*/; j++)
                    {
                        cell = MyLib.SetDataCellFromStringValParsing(arr[i - 1][j - 1], ReadParams);
                        this.ContentCell[j - ErstColumnNOfArrayForContent][i - ErstLineNOfArrayForContent] = cell;
                    }//for
                }//for 
            }//if DB, ne Matr
            //
            if (TblInf.Str.LineOfColHeaderExists)
            {
                if (TblInf.Str.ColOfLineHeaderExists)
                {
                    this.LineOfColHeader = new DataCell[TblInf.RowsQuantities.QColumns-1];
                    for (int i = QCellsForHeaderNames.QColumns+1; i <= TblInf.RowsQuantities.QColumns; i++)
                    {
                        //cell = SetDataCellFromStringVal(arr[1 - 1][i - 1], ReadParams);
                        s=arr[1 - 1][i - 1];
                        cell = MyLib.SetDataCellFromStringValParsing(s, ReadParams);
                        this.LineOfColHeader[i - QCellsForHeaderNames.QColumns-1] = cell;
                    }
                }
                else
                {
                    this.LineOfColHeader = new DataCell[TblInf.RowsQuantities.QColumns];
                    for (int i = 1; i <= TblInf.RowsQuantities.QColumns; i++)
                    {
                        cell = MyLib.SetDataCellFromStringValParsing(arr[1 - 1][i - 1], ReadParams);
                        this.LineOfColHeader[i - 1] = cell;
                    }
                }
            }
            //
            if (TblInf.Str.ColOfLineHeaderExists)
            {
                if (TblInf.Str.LineOfColHeaderExists)
                {
                    this.ColOfLineHeader = new DataCell[TblInf.RowsQuantities.QLines-1];
                    for (int i = QCellsForHeaderNames.QLines+1; i <= TblInf.RowsQuantities.QLines; i++)
                    {
                        //cell = SetDataCellFromStringVal(arr[i - 1][1 - 1], ReadParams);
                        s=arr[i - 1][1 - 1];
                        cell = MyLib.SetDataCellFromStringValParsing(s, ReadParams);
                        this.ColOfLineHeader[i - QCellsForHeaderNames.QLines-1] = cell;
                    }
                }
                else
                {
                    this.ColOfLineHeader = new DataCell[TblInf.RowsQuantities.QLines];
                    for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
                    {
                        cell = MyLib.SetDataCellFromStringValParsing(arr[i - 1][1 - 1], ReadParams);
                        this.ColOfLineHeader[i - 1] = cell;
                    }
                }
            }
            if (WriteInfo)
            {
                this.TblInf = new TableInfo();
                this.TblInf = TblInf;
                this.TblInf.RowsQuantities.QLines = QContentLines;
                this.TblInf.RowsQuantities.QColumns = QContentColumns;
            }
        }//fn SetFromStringArray2
        public void SetFromStringArray(string[][] arr, TableReadingTypesParams ReadParamsExt = null, /*TableSize ArraySize, TableStructure TStr,*/ TableInfo TblStrAndArraySizeInfExt = null, int WriteInfoAsWas0No1Yes2 = 0)
        {
            int zero = 0;
            bool WriteInfo;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblStrAndArraySizeInfExt);
            TableReadingTypesParams ReadParams;
            DataCell cell = null;
            if (ReadParamsExt != null) ReadParams = ReadParamsExt; else ReadParams = new TableReadingTypesParams();
            //this.SetSize(TblInf.RowsQuantities.QLines, TblInf.RowsQuantities.QColumns);
            int QContentLines, QContentColumns, ErstLineNOfArrayForContent, LastLineNOfArrayForContent, ErstColumnNOfArrayForContent, LastColumnNOfArrayForContent;
            if (TblInf.Str.LineOfColHeaderExists)
            {
                QContentColumns = TblInf.RowsQuantities.QColumns - 1;
                ErstColumnNOfArrayForContent = 2;
                LastColumnNOfArrayForContent = TblInf.RowsQuantities.QColumns;
            }
            else
            {
                QContentColumns = TblInf.RowsQuantities.QColumns;
                ErstColumnNOfArrayForContent = 1;
                LastColumnNOfArrayForContent = TblInf.RowsQuantities.QColumns;
            }
            if (TblInf.Str.ColOfLineHeaderExists)
            {
                QContentLines = TblInf.RowsQuantities.QLines - 1;
                ErstLineNOfArrayForContent = 2;
                LastLineNOfArrayForContent = TblInf.RowsQuantities.QLines;
            }
            else
            {
                QContentLines = TblInf.RowsQuantities.QLines;
                ErstLineNOfArrayForContent = 1;
                LastLineNOfArrayForContent = TblInf.RowsQuantities.QLines;
            }
            if (ReadParamsExt != null) ReadParams = ReadParamsExt; else ReadParams = new TableReadingTypesParams();
            //
            //if(this.TblInf!=null && this.TblInf.Str!=null && this.TblInf.Str.LC_Matrix_Not_CL_DB==TblInf.Str.LC_Matrix_Not_CL_DB && (this.TblInf.GetQLines()==TblInf.GetQLines() || this.TblInf.GetQColumns()==TblInf.GetQColumns() ))|{
            //    //append / what for? Replace!
            //}else{
            if (WriteInfoAsWas0No1Yes2 == 2 || WriteInfoAsWas0No1Yes2 == 0 && this.TblInf != null) WriteInfo = true; else WriteInfo = false;
            //}
            //SetMain(TblInf, this.TblInf, null, null, WriteInfo, false);
            if (TblInf.Str.LC_Matrix_Not_CL_DB)
            {
                this.ContentCell = new DataCell[QContentLines][];
                for (int i = 1; i <= QContentLines; i++)
                {
                    this.ContentCell[i - 1] = new DataCell[QContentColumns];
                }
                if (TblInf.Str.LineOfColHeaderExists)
                {
                    if (TblInf.Str.ColOfLineHeaderExists)
                    {
                        for (int i = 2; i <= TblInf.RowsQuantities.QLines; i++)
                        {
                            for (int j = 2; j <= TblInf.RowsQuantities.QColumns; j++)
                            {
                                cell = MyLib.SetDataCellFromStringValParsing(arr[i - 1][j - 1], ReadParams);
                                this.ContentCell[i - 2][j - 2] = cell;
                            }//for
                        }//for
                    }
                    else //CoLH==null
                    {
                        for (int i = 2; i <= TblInf.RowsQuantities.QLines; i++)
                        {
                            for (int j = 1; j <= TblInf.RowsQuantities.QColumns; j++)
                            {
                                cell = MyLib.SetDataCellFromStringValParsing(arr[i - 1][j - 1], ReadParams);
                                this.ContentCell[i - 2][j - 1] = cell;
                            }//for
                        }//for
                    }//CoLH
                }
                else //LoCH==null
                {
                    if (TblInf.Str.ColOfLineHeaderExists)
                    {
                        for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
                        {
                            for (int j = 2; j <= TblInf.RowsQuantities.QColumns; j++)
                            {
                                cell = MyLib.SetDataCellFromStringValParsing(arr[i - 1][j - 1], ReadParams);
                                this.ContentCell[i - 1][j - 2] = cell;
                            }
                        }
                    }
                    else //CoLH==null
                    {
                        for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
                        {
                            for (int j = 1; j <= TblInf.RowsQuantities.QColumns; j++)
                            {
                                cell = MyLib.SetDataCellFromStringValParsing(arr[i - 1][j - 1], ReadParams);
                                this.ContentCell[i - 1][j - 1] = cell;
                            }//for
                        }//for
                    }//if CoLH
                }//if LoCH   
            }
            else
            { //not Matrix, but DB
                this.ContentCell = new DataCell[QContentColumns][];
                for (int i = 1; i <= QContentColumns; i++)
                {
                    this.ContentCell[i - 1] = new DataCell[QContentLines];
                }
                if (TblInf.Str.LineOfColHeaderExists)
                {
                    if (TblInf.Str.ColOfLineHeaderExists)
                    {
                        for (int i = 2; i <= TblInf.RowsQuantities.QLines; i++)
                        {
                            for (int j = 2; j <= TblInf.RowsQuantities.QColumns; j++)
                            {
                                cell = MyLib.SetDataCellFromStringValParsing(arr[j - 1][i - 1], ReadParams);
                                this.ContentCell[i - 2][j - 2] = cell;
                            }//for
                        }//for
                    }
                    else //CoLH==null
                    {
                        for (int i = 2; i <= TblInf.RowsQuantities.QLines; i++)
                        {
                            for (int j = 1; j <= TblInf.RowsQuantities.QColumns; j++)
                            {
                                cell = MyLib.SetDataCellFromStringValParsing(arr[j - 1][i - 1], ReadParams);
                                this.ContentCell[i - 2][j - 1] = cell;
                            }//for
                        }//for
                    }//if CoLH
                }
                else//LoCH==null
                {
                    if (TblInf.Str.ColOfLineHeaderExists)
                    {
                        for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
                        {
                            for (int j = 2; j <= TblInf.RowsQuantities.QColumns; j++)
                            {
                                cell = MyLib.SetDataCellFromStringValParsing(arr[j - 1][i - 1], ReadParams);
                                this.ContentCell[i - 1][j - 2] = cell;
                            }//for
                        }//for
                    }
                    else //CoLH==null
                    {
                        for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
                        {
                            for (int j = 1; j <= TblInf.RowsQuantities.QColumns; j++)
                            {
                                cell = MyLib.SetDataCellFromStringValParsing(arr[i - 1][j - 1], ReadParams);
                                this.ContentCell[j - 1][i - 1] = cell;
                            }//for
                        }//for
                    }//if CoLH
                }//if LoCH
            }//if DB, ne Matr
            //
            if (TblInf.Str.LineOfColHeaderExists)
            {
                if (TblInf.Str.ColOfLineHeaderExists)
                {
                    this.LineOfColHeader = new DataCell[TblInf.RowsQuantities.QColumns - 1];
                    for (int i = 2; i <= TblInf.RowsQuantities.QColumns; i++)
                    {
                        cell = MyLib.SetDataCellFromStringValParsing(arr[1 - 1][i - 1], ReadParams);
                        this.LineOfColHeader[i - 2] = cell;
                    }
                }
                else
                {
                    this.LineOfColHeader = new DataCell[TblInf.RowsQuantities.QColumns];
                    for (int i = 1; i <= TblInf.RowsQuantities.QColumns; i++)
                    {
                        cell = MyLib.SetDataCellFromStringValParsing(arr[1 - 1][i - 1], ReadParams);
                        this.LineOfColHeader[i - 1] = cell;
                    }
                }
            }
            //
            if (TblInf.Str.ColOfLineHeaderExists)
            {
                if (TblInf.Str.LineOfColHeaderExists)
                {
                    this.ColOfLineHeader = new DataCell[TblInf.RowsQuantities.QLines - 1];
                    for (int i = 2; i <= TblInf.RowsQuantities.QLines; i++)
                    {
                        cell = MyLib.SetDataCellFromStringValParsing(arr[i - 1][1 - 1], ReadParams);
                        this.ColOfLineHeader[i - 2] = cell;
                    }
                }
                else
                {
                    this.ColOfLineHeader = new DataCell[TblInf.RowsQuantities.QLines];
                    for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
                    {
                        cell = MyLib.SetDataCellFromStringValParsing(arr[i - 1][1 - 1], ReadParams);
                        this.ColOfLineHeader[i - 1] = cell;
                    }
                }
            }
            if (WriteInfo)
            {
                this.TblInf = new TableInfo();
                this.TblInf = TblInf;
                this.TblInf.RowsQuantities.QLines = QContentLines;
                this.TblInf.RowsQuantities.QColumns = QContentColumns;
            }
        }//fn SetFromStringArray
        //public void SetFrom
        public void SetFromCSV(string FullName, TableReadingTypesParams ReadParamsExt = null, TableInfo TblStrAndArraySizeInfExt = null, char delimiter=';', int ToAvoid=0, int WriteInfoAsWas0No1Yes2 = 0)
        {
            string[][] ss = null;
            TableSize QCellsForHeaderNames=new TableSize();
            //int[] Lengths = null;
            int QLines = 0, QColumns=0;
            //MyLib.ReadCSV(FullName, ref QLines, ref Lengths, ref ss, delimiter, ToAvoid);
            MyLib.ReadCSV_MakingRectangular(FullName, ref QLines, ref QColumns, ref ss, delimiter, ToAvoid);
            //MyLib.Make2DStringArrayRectangular(ref ss, ref QColumns, QLines, Lengths, 0);//int Max0Min1ConcreteValue2)//, int value = 0)
            TableInfo TblStrAndArraySizeInf = Choose_TableInfo_StrSize_ByExtAndInner(TblStrAndArraySizeInfExt);
            //if(TblStrAndArraySizeInfExt)
            TblStrAndArraySizeInf.RowsQuantities.QLines = QLines;
            TblStrAndArraySizeInf.RowsQuantities.QColumns = QColumns;
            //this.SetFromStringArray(ss, ReadParamsExt, TblStrAndArraySizeInf, WriteInfoAsWas0No1Yes2);
            this.SetFromStringArray2(ss, QCellsForHeaderNames, ReadParamsExt, TblStrAndArraySizeInf, WriteInfoAsWas0No1Yes2); 
        }//fn From CSV
        public void ToStringArray(ref string[][] ss, ref TableSize ArrSize, TableInfo_ConcrRepr TblInfExt, TableSize QCellsForNames)
        {
            TableInfo_ConcrRepr TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int QArrayLines, QArrayColumns;
            int QContentLines=TblInf.GetQLines(), QContentColumns=TblInf.GetQColumns();
            if (TblInf.Str.LineOfColHeaderExists)
            {
                if (TblInf.Str.ColOfLineHeaderExists)
                {
                    QArrayLines = TblInf.RowsQuantities.QLines + QCellsForNames.QLines;
                    QArrayColumns = TblInf.RowsQuantities.QColumns + QCellsForNames.QColumns;
                }
                else
                {
                    QArrayLines = TblInf.RowsQuantities.QLines + QCellsForNames.QLines;
                    QArrayColumns = TblInf.RowsQuantities.QColumns;// +QCellsForNames.QColumns;
                }
            }
            else
            {
                if (TblInf.Str.ColOfLineHeaderExists)
                {
                    QArrayLines = TblInf.RowsQuantities.QLines;// +QCellsForNames.QLines;
                    QArrayColumns = TblInf.RowsQuantities.QColumns + QCellsForNames.QColumns;
                }
                else
                {
                    QArrayLines = TblInf.RowsQuantities.QLines;// +QCellsForNames.QLines;
                    QArrayColumns = TblInf.RowsQuantities.QColumns;// +QCellsForNames.QColumns;
                }
            }
            if (ArrSize == null) ArrSize = new TableSize();
            ArrSize.QLines = QArrayLines; ArrSize.QColumns = QArrayColumns;
            //size defined
            //preparing array
            ss = new string[QArrayLines][];
            for (int i = 1; i <= QArrayLines; i++)
            {
                ss[i - 1] = new string[QArrayColumns];
            }
            for (int i = 1; i <= QArrayLines; i++)
            {
                for (int j = 1; j <= QArrayColumns; j++)
                {
                    ss[i - 1][j-1] = "";
                }
            }
            //array prepared
            //Now content
            for (int i = 1; i <= QContentLines; i++)
            {
                for (int j = 1; j <= QContentColumns; j++)
                {
                    ss[QCellsForNames.QLines + i - 1][QCellsForNames.QColumns + j - 1] = ToString(i, j);
                }
            }
            //Headers
            //ColOfLineHeader
            for (int i = 1; i <= QContentLines; i++)
            {
                for (int j = 1; j <= QCellsForNames.QColumns; j++)
                {
                    switch (j)
                    {
                        case 1:
                            ss[QCellsForNames.QLines + i - 1][j - 1] = ToString_ColOfLineHeader(i);
                            break;
                        case 2:
                            ss[QCellsForNames.QLines + i - 1][j - 1] = GetName2_ColOfLineHeader(i);
                            break;
                        case 3:
                            //ss[QCellsForNames.QLines + i - 1][j - 1] = GetName3_ColOfLineHeader(i);
                            break;
                    }//switch
                }//for j
            }//for i
            //LineOfColHeader
            for (int i = 1; i <= QContentColumns; i++)
            {
                for (int j = 1; j <= QCellsForNames.QLines; j++)
                {
                    switch (j)
                    {
                        case 1:
                            ss[j - 1][QCellsForNames.QColumns + i - 1] = ToString_LineOfColHeader(i);
                            break;
                        case 2:
                            ss[j - 1][QCellsForNames.QColumns + i - 1] = GetName2_LineOfColHeader(i);
                            break;
                        case 3:
                            //ss[j - 1][QCellsForNames.QColumns + i - 1] = GetName3_LineOfColHeader(i);
                            break;
                    }//switch
                }//for j
            }//for i
            //Corner
            if(TblInf.Str.LineOfColHeaderExists || TblInf.Str.ColOfLineHeaderExists){
                //ss[1 - 1][1 - 1] = GetCorner_Only();
                ss[1 - 1][1 - 1] = GetCorner();
            }
        }//fn
        void SaveToCSV(string FullName, string delimiter = ";", TableSize QForHeaderCells = null, TableInfo_ConcrRepr TblInfExt = null)
        {
            string[][] ss=null;
            string CurLine;
            StreamWriter sw;
            TableSize ArrSize=null;
            ToStringArray(ref ss, ref ArrSize, TblInfExt, QForHeaderCells);
            MyLib.StringArrToCSV(FullName, ss, ArrSize, delimiter);
        }//fn
        //
        //
        //
        public TableHeaderRowsExistance GetTableHeaderRowsExistance()
        {
            TableHeaderRowsExistance obj=null;
            if (TblInf != null) obj = TblInf.GetTableHeaderRowsExistance();
            return obj;
        }
        public TableStructure GetStr()
        {
            TableStructure R = null;
            if (TblInf != null) R = TblInf.GetStr();
            return R;
        }
        public TableSize GetSize()
        {
            TableSize R = null;
            if (TblInf != null) R = TblInf.GetSize();
            return R;
        }
        public TableUssagePolicy GetUssagePolicy() {
            TableUssagePolicy R = null;
            if (TblInf != null) R = TblInf.GetUssagePolicy();
            return R;
        }
        //public TableRepresentation GetRepresentation_Text()
        //{
        //    TableRepresentation R = null;
        //    if (TblInf != null) R = TblInf.GetRepresentation_Text();
        //    return R;
        //}
        //public TableRepresentation GetRepresentation_Grid()
        //{
        //    TableRepresentation R = null;
        //    if (TblInf != null) R = TblInf.GetRepresentation_Grid();
        //    return R;
        //}
        //
        public TableContentCellRepresentation GetContentCellRepresentation_Text()
        {
            TableContentCellRepresentation R = null;
            if (TblInf != null) R = TblInf.GetContentCellRepresentation_Text();
            return R;
        }
        public TableContentCellRepresentation GetContentCellRepresentation_Grid()
        {
            TableContentCellRepresentation R = null;
            if (TblInf != null) R = TblInf.GetContentCellRepresentation_Grid();
            return R;
        }
        public TableHeaderCellRepresentation GetLineHeaderCellRepresentation_Text()
        {
            TableHeaderCellRepresentation R = null;
            if (TblInf != null) R = TblInf.GetLineHeaderCellRepresentation_Text();
            return R;
        }
        public TableHeaderCellRepresentation GetLineHeaderCellRepresentation_Grid()
        {
            TableHeaderCellRepresentation R = null;
            if (TblInf != null) R = TblInf.GetLineHeaderCellRepresentation_Grid();
            return R;
        }
        public TableHeaderCellRepresentation GetColHeaderCellRepresentation_Text()
        {
            TableHeaderCellRepresentation R = null;
            if (TblInf != null) R = TblInf.GetColHeaderCellRepresentation_Text();
            return R;
        }
        public TableHeaderCellRepresentation GetColHeaderCellRepresentation_Grid()
        {
            TableHeaderCellRepresentation R = null;
            if (TblInf != null) R = TblInf.GetColHeaderCellRepresentation_Grid();
            return R;
        }
        public TableHeaderCellRepresentation GetContentCellLineHeaderRepresentation_Text()
        {
            TableHeaderCellRepresentation R = null;
            if (TblInf != null) R = TblInf.GetColHeaderCellRepresentation_Grid();
            return R;
        }
        public TableHeaderCellRepresentation GetContentCellLineHeaderRepresentation_Grid()
        {
            TableHeaderCellRepresentation R = null;
            if (TblInf != null) R = TblInf.GetColHeaderCellRepresentation_Grid();
            return R;
        }
        public TableHeaderCellRepresentation GetContentCellColumnHeaderRepresentation_Text()
        {
            TableHeaderCellRepresentation R = null;
            if (TblInf != null) R = TblInf.GetContentCellColumnHeaderRepresentation_Text();
            return R;
        }
        public TableHeaderCellRepresentation GetContentCellColumnHeaderRepresentation_Grid()
        {
            TableHeaderCellRepresentation R = null;
            if (TblInf != null) R = TblInf.GetContentCellColumnHeaderRepresentation_Grid();
            return R;
        }
        //
        public void SetTableHeaderRowsExistance(TableHeaderRowsExistance obj)
        {
            if (this.TblInf == null) this.TblInf =new TableInfo();
            this.TblInf.SetTableHeaderRowsExistance(obj);
        }
        public void SetTableHeaderRowsExistance(bool ColOfLineHeaderExists, bool LineOfColHeaderExists)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetTableHeaderRowsExistance(ColOfLineHeaderExists, LineOfColHeaderExists);
        }
        public void SetStr(TableStructure Str)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetStr(Str);
        }
        public void GetSize(TableSize size)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.GetSize(size);
        }
        //
        public void SetUssagePolicy(TableUssagePolicy UssagePolicy)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetUssagePolicy(UssagePolicy);
        }
        public void SetRepresentation_Text(TableRepresentation Repr)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetRepresentation_Text(Repr);
        }
        public void SetRepresentation_Grid(TableRepresentation Repr)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetRepresentation_Grid(Repr);
        }
        //
        public void SetRepresentationGeneral_Text(TableGeneralRepresentation ReprGen)
        {
            if (this.TblInf!=null){
                if(this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
                this.TblInf.Repr_Text.SetGeneralRepresentation(ReprGen);
            }
        }
        public void SetRepresentationGeneral_Grid(TableGeneralRepresentation ReprGen)
        {
            if (this.TblInf != null)
            {
                if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
                this.TblInf.Repr_Grid.SetGeneralRepresentation(ReprGen);
            }
        }
        public void SetContentCellRepresentation_Text(TableContentCellRepresentation Repr)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetContentCellRepresentation_Text(Repr);
        }
        public void SetContentCellRepresentation_Grid(TableContentCellRepresentation Repr)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetContentCellRepresentation_Grid(Repr);
        }
        public void SetLineHeaderCellRepresentation_Text(TableHeaderCellRepresentation Repr)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetLineHeaderCellRepresentation_Text(Repr);
        }
        public void SetLineHeaderCellRepresentation_Grid(TableHeaderCellRepresentation Repr)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.GetLineHeaderCellRepresentation_Grid(Repr);
        }
        public void SetColHeaderCellRepresentation_Text(TableHeaderCellRepresentation Repr)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetColHeaderCellRepresentation_Text(Repr);
        }
        public void SetColHeaderCellRepresentation_Grid(TableHeaderCellRepresentation Repr)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetColHeaderCellRepresentation_Grid(Repr);
        }
        public void SetContentCellLineHeaderRepresentation_Text(TableHeaderCellRepresentation Repr)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetContentCellLineHeaderRepresentation_Text(Repr);
        }
        public void SetContentCellLineHeaderRepresentation_Grid(TableHeaderCellRepresentation Repr)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetContentCellLineHeaderRepresentation_Grid(Repr);
        }
        public void SetContentCellColumnHeaderRepresentation_Text(TableHeaderCellRepresentation Repr)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetContentCellColumnHeaderRepresentation_Text(Repr);
        }
        public void SetContentCellColumnHeaderRepresentation_Grid(TableHeaderCellRepresentation Repr)
        {
            if (this.TblInf == null) this.TblInf = new TableInfo();
            this.TblInf.SetContentCellColumnHeaderRepresentation_Grid(Repr);
        }
        public int GetMenuItemN(int LineN, int ColN, TableInfo TblInfExt = null, string[]items=null, int QItems=0)
        {
            int R=0, N=0, CellTypeN=0;
            string s;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            CellTypeN = GetTypeN(LineN, ColN, TblInf);
            if (TableConsts.TypeNIsCorrectArray(CellTypeN))
            {
                N = GetActiveN(LineN, ColN, TblInf);
                if (items != null)
                {
                    if(QItems==0 ||QItems>items.Length) QItems=items.Length;
                    s = ToStringN(LineN, ColN, N);
                    for (int i = 1; i <= QItems; i++)
                    {
                        if(s.Equals(items[i-1])) R=i;
                    }
                }
            }
            else
            {
                R=GetIntVal(LineN, ColN, TblInf);
            }
            return R;
        }
        //
        public DataCellRow GetContentLineN(int N, TableInfo TblInfExt = null)
        {
            DataCellRow result_row = null;
            DataCell Cur;
            DataCell[] content_row;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int QLines=TblInf.GetQLines(), QColumns=TblInf.GetQColumns();
             //
            if (N >= 1 && N <= QLines)
            {
                content_row = new DataCell[QColumns];
                for(int i=1; i<=QColumns; i++){
                    content_row[i - 1] = GetCell(N, i, TblInf.GetTableInfo_ConcrRepr());
                }
                result_row = new DataCellRow(content_row, QColumns);
            }
            return result_row;
        }
        public DataCellRow GetContentColumnN(int N, TableInfo TblInfExt = null)
        {
            DataCellRow result_row = null;
            DataCell Cur;
            DataCell[] content_row;
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int QLines = TblInf.GetQLines(), QColumns = TblInf.GetQColumns();
            //
            if (N >= 1 && N <= QColumns)
            {
                content_row = new DataCell[QLines];
                for (int i = 1; i <= QLines; i++)
                {
                    content_row[i - 1] = GetCell(i, N, TblInf.GetTableInfo_ConcrRepr());
                }
                result_row = new DataCellRow(content_row, QLines);
            }
            return result_row;
        }
        public DataCellRowCoHeader GetLineWithHeaderN(int N, TableInfo TblInfExt = null)
        {
            DataCellRowCoHeader RowCoHdr=null;
            DataCellRow Row = GetContentLineN(N, TblInfExt);
            DataCell Hdr = GetCell_ColOfLineHeader(N, TblInfExt.GetTableInfo_ConcrRepr());
            if (Row != null) RowCoHdr = new DataCellRowCoHeader(Hdr, Row);
            return RowCoHdr;
        }
        public DataCellRowCoHeader GetColumnWithHeaderN(int N, TableInfo/*TableInfo_ConcrRepr so must be*/ TblInfExt = null)
        {
            DataCellRowCoHeader RowCoHdr = null;
            DataCellRow Row = GetContentColumnN(N, TblInfExt);
            DataCell Hdr = GetCell_LineOfColHeader(N, TblInfExt.GetTableInfo_ConcrRepr());
            if (Row != null) RowCoHdr = new DataCellRowCoHeader(Hdr, Row);
            return RowCoHdr;
        }
        //
        public void Transpose(TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInfBef = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt), TblInfAft=TblInfBef;
            int QLinesBef=TblInfBef.GetQLines(), QColumnsBef=TblInfBef.GetQColumns(), QLinesAft=TblInfBef.GetQColumns(), QColumnsAft=TblInfBef.GetQLines();
            TblInfAft.SetSize(QLinesAft, QColumnsAft);
            //MyLib.TransposeTable(ref this.ContentCell, ref TblInf.RowsQuantities.QLines, ref TblInf.RowsQuantities.QColumns);
           DataCell[]CoLHNew, LoCHNew;
            DataCell[][]CntNew;
            CoLHNew=new DataCell[QLinesAft];
            LoCHNew=new DataCell[QColumnsAft];
            if(TblInfBef.GetIf_LC_Not_CL()){
                MyLib.TransposeTable(ref this.ContentCell, ref TblInf.RowsQuantities.QLines, ref TblInf.RowsQuantities.QColumns);
                //CntNew=new DataCell[QLinesAft][];
                //for(int i=1; i<=QLinesAft; i++){
                //    CntNew[i-1]=new DataCell[QColumnsAft];
                //}
                //for(int i=1; i<=QLinesAft; i++){
                //    for(int j=1; j<=QColumnsAft; j++){
                //        CntNew[i-1][j-1]=this.GetCell(j, i, TblInfBef);
                //    }
                //}
            }else{
                MyLib.TransposeTable(ref this.ContentCell, ref TblInf.RowsQuantities.QColumns, ref TblInf.RowsQuantities.QLines);
                //CntNew=new DataCell[QColumnsAft][];
                //for(int i=1; i<=QColumnsAft; i++){
                //    CntNew[i-1]=new DataCell[QColumnsAft];
                //}
                //for(int i=1; i<=QColumnsAft; i++){
                //    for(int j=1; j<=QLinesAft; j++){
                //        CntNew[i-1][j-1]=this.GetCell(j, i, TblInfBef);
                //    }
                //}
            }
            for(int i=1; i<=QLinesAft; i++){
                CoLHNew[i-1]=LineOfColHeader[i-1];
            }
            for(int j=1; j<=QColumnsAft; j++){
                LoCHNew[j-1]=ColOfLineHeader[j-1];
            }
            if (this.GetTableInfo() != null)
            {
                this.TblInf.RowsQuantities = TblInfAft.RowsQuantities;
            }
        }
        public TTable TransposeTo(TableInfo_ConcrRepr TblInfExt = null, int WriteInfo_No0Yes1AsInOrig2=2)
        {
            TTable T = null;
            TableInfo_ConcrRepr TblInfBef = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt), TblInfAft = TblInfBef;
            TableInfo TblInfNew=new TableInfo();
            int QLinesBef = TblInfBef.GetQLines(), QColumnsBef = TblInfBef.GetQColumns(), QLinesAft = TblInfBef.GetQColumns(), QColumnsAft = TblInfBef.GetQLines();
            bool WriteInfo;
            TblInfAft.SetSize(QLinesAft, QColumnsAft);
            TblInfNew.SetStr(TblInfAft.GetStr());
            TblInfNew.SetSize(TblInfAft.GetQLines(),TblInfAft.GetQColumns());
            //MyLib.TransposeTable(ref this.ContentCell, ref TblInf.RowsQuantities.QLines, ref TblInf.RowsQuantities.QColumns);
            DataCell[] CoLHNew, LoCHNew;
            DataCell[][] CntNew;
            CoLHNew = new DataCell[QLinesAft];
            LoCHNew = new DataCell[QColumnsAft];
            if (TblInfBef.GetIf_LC_Not_CL())
            {
                CntNew=new DataCell[QLinesAft][];
                for(int i=1; i<=QLinesAft; i++){
                    CntNew[i-1]=new DataCell[QColumnsAft];
                }
                for(int i=1; i<=QLinesAft; i++){
                    for(int j=1; j<=QColumnsAft; j++){
                        CntNew[i-1][j-1]=this.GetCell(j, i, TblInfBef);
                   }
                }
            }
            else
            {
                CntNew=new DataCell[QColumnsAft][];
                for(int i=1; i<=QColumnsAft; i++){
                    CntNew[i-1]=new DataCell[QColumnsAft];
                }
                for(int i=1; i<=QColumnsAft; i++){
                    for(int j=1; j<=QLinesAft; j++){
                        CntNew[i-1][j-1]=this.GetCell(j, i, TblInfBef);
                    }
                }
            }
            for (int i = 1; i <= QLinesAft; i++)
            {
                CoLHNew[i - 1] = LineOfColHeader[i - 1];
            }
            for (int j = 1; j <= QColumnsAft; j++)
            {
                LoCHNew[j - 1] = ColOfLineHeader[j - 1];
            }
            switch(WriteInfo_No0Yes1AsInOrig2){
                case 0:
                    WriteInfo=false;
                    break;
                case 1:
                    WriteInfo=true;
                    break;
                default://case 2
                    WriteInfo=(this.GetTableInfo()!=null);
                    break;
            }
            T = new TTable(TblInfNew, CntNew, LoCHNew, CoLHNew, new TableHeaders(this.GetTableHeader(), this.GetColumnsGeneralHeader(), this.GetLinesGeneralHeader()), this.SpecCell, WriteInfo);
            return T;
        }
        public void LinesVisaVersa(TableInfo TblInfExt=null)
        {
            TableInfo TblInf=Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            MyLib.SortTableLinesUpsideDown(ref ContentCell, TblInf.RowsQuantities.QLines, TblInf.RowsQuantities.QColumns);
            if (TblInf.GetIf_CoLHExists())
            {
                MyLib.SortVectorUpsideDown(ref this.ColOfLineHeader, TblInf.RowsQuantities.QLines);
            }
        }
        public void ColumnsVisaVersa(TableInfo TblInfExt = null)
        {
            TableInfo TblInf = Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            MyLib.SortTableColumnsUpsideDown(ref ContentCell, TblInf.RowsQuantities.QLines, TblInf.RowsQuantities.QColumns);
            if (TblInf.GetIf_LoCHExists())
            {
                MyLib.SortVectorUpsideDown(ref this.LineOfColHeader, TblInf.RowsQuantities.QColumns);
            }
        }
        //
        public void AddHorisontallyFrom(TTable tbl, TableInfo TblInfExtThis = null, TableInfo TblInfExtThat = null)
        {
            int QLinesThis, QColumnsThis, QLinesThat, QColumnsThat, QColumnsMin, QColumnsMax;
            int QLinesMin, QLinesMax;
            bool QLinesSame, QColumnsSame;
            TableInfo TblInfThis = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExtThis), TblInfThat = tbl.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExtThat);
            DataCellRowCoHeader Row;
            DataCellRow ContentRow;
            DataCell Cur, Cur1 = new DataCell();
            //
            QLinesThis = TblInfThis.GetQLines(); QLinesThat = TblInfThat.GetQLines(); QColumnsThis = TblInfThis.GetQColumns(); QColumnsThat = TblInfThat.GetQColumns();
            if (QLinesThis >= QLinesThat)
            {
                QLinesMin = QLinesThat;
                QLinesMax = QLinesThis;
            }
            else
            {
                QLinesMin = QLinesThis;
                QLinesMax = QLinesThat;
            }
            if (QColumnsThis >= QColumnsThat)
            {
                QColumnsMin = QColumnsThat;
                QColumnsMax = QColumnsThis;
            }
            else
            {
                QColumnsMin = QColumnsThis;
                QColumnsMax = QColumnsThat;
            }
            QLinesSame = (QLinesMin == QLinesMax);
            QColumnsSame = (QColumnsMin == QColumnsMax);
            //
            if (QLinesThis <= QLinesThat)
            {
                for (int i = 1; i <= QLinesThat - QLinesThis; i++)
                {
                    this.AddEmptyLine_TypesByExisting();
                }
            }
            Row = new DataCellRowCoHeader(new DataCell(), new DataCellRow(new DataCell[QLinesMax], QLinesMax));
            //
            if (QLinesThat < QLinesThis)
            {
                for (int i = 1; i <= QColumnsThat; i++)
                {
                    Cur = tbl.GetCell_LineOfColHeader(i, TblInfThat.GetTableInfo_ConcrRepr());
                    Row.SetHeader(Cur);
                    ContentRow = tbl.GetContentColumnN(i, TblInfThat);
                    for (int j = 1; j <= QLinesThis - QLinesThat; j++) ContentRow.Add(Cur1);
                    Row.SetContent(ContentRow);
                    this.AddColumn(Row);
                }
            }
            else
            {
                for (int i = 1; i <= QColumnsThat; i++)
                {
                    Cur = tbl.GetCell_LineOfColHeader(i, TblInfThat.GetTableInfo_ConcrRepr());
                    Row.SetHeader(Cur);
                    ContentRow = tbl.GetContentColumnN(i, TblInfThat);
                    //
                    Row.SetContent(ContentRow);
                    this.AddColumn(Row);
                }
            }
        }
        public void AddHorisontallyTo(ref TTable tbl, TableInfo TblInfExtThis = null, TableInfo TblInfExtThat = null)
        {

        }
        public void AddVerticallyFrom(TTable tbl, TableInfo TblInfExtThis = null, TableInfo TblInfExtThat = null/*, int QColsIfDiff_ByMin1ByMax2ByThis3ByThat4 = 2*/)
        {
            int QLinesThis, QColumnsThis, QLinesThat, QColumnsThat, QColumnsMin, QColumnsMax;
            int QLinesMin, QLinesMax;
            bool QLinesSame, QColumnsSame;
            TableInfo TblInfThis = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExtThis), TblInfThat = tbl.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExtThat);
            DataCellRowCoHeader Row;
            DataCellRow ContentRow;
            DataCell Cur, Cur1=new DataCell();
            //
            QLinesThis = TblInfThis.GetQLines(); QLinesThat = TblInfThat.GetQLines(); QColumnsThis = TblInfThis.GetQColumns(); QColumnsThat = TblInfThat.GetQColumns();
            if (QLinesThis >= QLinesThat)
            {
                QLinesMin = QLinesThat;
                QLinesMax = QLinesThis;
            }
            else
            {
                QLinesMin = QLinesThis;
                QLinesMax = QLinesThat;
            }
            if (QColumnsThis >= QColumnsThat)
            {
                QColumnsMin = QColumnsThat;
                QColumnsMax = QColumnsThis;
            }
            else
            {
                QColumnsMin = QColumnsThis;
                QColumnsMax = QColumnsThat;
            }
            QLinesSame = (QLinesMin == QLinesMax);
            QColumnsSame = (QColumnsMin == QColumnsMax);
            //
            if (QColumnsThis <= QColumnsThat)
            {
                for (int i = 1; i <= QColumnsThat - QColumnsThis; i++)
                {
                    this.AddEmptyColumn_TypesByExisting();
                }
            }
            Row = new DataCellRowCoHeader(new DataCell(), new DataCellRow(new DataCell[QColumnsMax], QColumnsMax));
            //
            //Row = new DataCellRowCoHeader();
            if (QColumnsThat < QColumnsThis)
            {
                for (int i = 1; i <= QLinesThat; i++)
                {
                    Cur = tbl.GetCell_ColOfLineHeader(i, TblInfThat.GetTableInfo_ConcrRepr());
                    Row.SetHeader(Cur);
                    ContentRow = tbl.GetContentLineN(i, TblInfThat);
                    for (int j = 1; j <= QColumnsThis - QColumnsThat; j++) ContentRow.Add(Cur1);
                    Row.SetContent(ContentRow);
                    this.AddLine(Row);
                }
            }
            else
            {
                for (int i = 1; i <= QLinesThat; i++)
                {
                    Cur = tbl.GetCell_ColOfLineHeader(i, TblInfThat.GetTableInfo_ConcrRepr());
                    Row.SetHeader(Cur);
                    ContentRow = tbl.GetContentLineN(i, TblInfThat);
                    Row.SetContent(ContentRow);
                    this.AddLine(Row);
                }
            }
        }//Add Vert From
        public void AddVerticallyTo(ref TTable tbl, TableInfo TblInfExtThis = null, TableInfo TblInfExtThat = null)
        {

        }
        //mark13
        public TTable ConcatTablesTo_Simply(TTable tbl1, TTable tbl2, bool VertHorNot = true, TableInfo Tbl1InfExt = null, TableInfo Tbl2InfExt = null, int ColNamesIfNotSame_First1Second2CreateEmpty3 = 1)
        {
            TableInfo Tbl1Inf=tbl1.Choose_TableInfo_StrSize_ByExtAndInner(Tbl1InfExt), Tbl2Inf=tbl2.Choose_TableInfo_StrSize_ByExtAndInner(Tbl2InfExt);
            int QLinesMin, QLinesMax, QColumnsMin, QColumnsMax, QLines1, QLines2, QColumns1, QColumns2;
            bool QLinesSame, QColumnsSame, ColsNamesSame;
            bool ColOfLineHeaders1Exists, ColOfLineHeaders2Exists, LineOfColHeaders1Exists, LineOfColHeaders2Exists;
            TTable TR=null;
            //
            //TR = tbl1;
            TR = tbl1.ReturnCopyOrPart();
            //
            QLines1 = Tbl1Inf.GetQLines(); QLines2 = Tbl2Inf.GetQLines(); QColumns1 = Tbl1Inf.GetQColumns(); QColumns2 = Tbl2Inf.GetQColumns();
            if (QLines1 >= QLines2)
            {
                QLinesMin = QLines2;
                QLinesMax = QLines1;
            }
            else
            {
                QLinesMin = QLines1;
                QLinesMax = QLines2;
            }
            if (QColumns1 >= QColumns2)
            {
                QColumnsMin = QColumns2;
                QColumnsMax = QColumns1;
            }
            else
            {
                QColumnsMin = QColumns1;
                QColumnsMax = QColumns2;
            }
            QLinesSame = (QLinesMin == QLinesMax);
            QColumnsSame = (QColumnsMin == QColumnsMax);
            //
            ColsNamesSame = true;
            if(Tbl1Inf.GetIf_LoCHExists() && Tbl2Inf.GetIf_LoCHExists()){
                for (int i = 1; i <= QColumnsMin; i++)
                {
                    ColsNamesSame=(ColsNamesSame&&((tbl1.ToStringN_LineOfColHeader(1,1,Tbl1Inf)).Equals(tbl2.ToStringN_LineOfColHeader(1,1,Tbl2Inf))));
                }
            }
            //
            if (VertHorNot)
            {
                TR.AddVerticallyFrom(tbl2, Tbl1Inf, Tbl2Inf);
            }
            else
            {
                TR.AddHorisontallyFrom(tbl2, Tbl1Inf, Tbl2Inf);
            }
            return TR;
        }//ConcatTablesTo_Simply
        //DataCellOfGridContentCell
        public DataCell DataCellOfGridContentCell(DataGridViewCell GridCell, TableReadingTypesParams TypesParams)
        {
            string val, CurItem = null;
            string[] CBItems = null;
            int Length, ActiveN = 0;
            double DoubleVal;
            int IntVal;
            bool BoolVal;
            DataCell TableCell = null;
            DataGridViewComboBoxCell CmbBCell = null;
            DataGridViewCheckBoxCell ChkBCell = null;
            DataGridViewTextBoxCell TxtBCell = null;
            if (GridCell is DataGridViewComboBoxCell)
            {
                CmbBCell = new DataGridViewComboBoxCell();
                CmbBCell = (DataGridViewComboBoxCell)GridCell;
                Length = CmbBCell.Items.Count;
                val = CmbBCell.Value.ToString();
                CBItems = new string[Length];
                for (int i = 1; i <= Length; i++)
                {
                    CBItems[i - 1] = CmbBCell.Items[i - 1].ToString();
                    CurItem = CBItems[i - 1];
                    if (val.Equals(CurItem)) ActiveN = i;
                }
                switch (TypesParams.Array_ActiveN0Val1AllLines2)
                {
                    case 2:
                        TableCell = new DataCell(CBItems, Length);
                        TableCell.SetActiveN(ActiveN);
                        break;
                    case 0:
                        TableCell = new DataCell(ActiveN);
                        break;
                    default://1
                        //TableCell = new DataCell(CurItem);
                        TableCell = new DataCell(val);
                        break;
                }
            }
            else if (GridCell is DataGridViewCheckBoxCell)
            {
                ChkBCell = new DataGridViewCheckBoxCell();
                ChkBCell = (DataGridViewCheckBoxCell)GridCell;
                switch (TypesParams.Bool_Bool0Int1Str2IntArr3StrArr4)
                {
                    case 0:
                        TableCell = new DataCell((bool)ChkBCell.Value);
                        break;
                    case 1:
                        TableCell = new DataCell(MyLib.BoolToInt((bool)ChkBCell.Value));
                        break;
                    case 2:
                        if ((bool)ChkBCell.Value)
                        {
                            TableCell = new DataCell(TableConsts.TrueWord);
                        }
                        else
                        {
                            TableCell = new DataCell(TableConsts.FalseWord);
                        }
                        break;
                    case 3:
                        if (MyLib.BoolValByDefault == true)
                        {
                            TableCell = new DataCell(new int[] { 1, 0 }, 2);
                            if ((bool)ChkBCell.Value)
                            {
                                TableCell.SetActiveN(1);
                            }
                            else
                            {
                                TableCell.SetActiveN(2);
                            }
                        }
                        else
                        {
                            TableCell = new DataCell(new int[] { 0, 1 }, 2);
                            if ((bool)ChkBCell.Value)
                            {
                                TableCell.SetActiveN(1);
                            }
                            else
                            {
                                TableCell.SetActiveN(2);
                            }
                        }
                        break;
                    case 4:
                        if (MyLib.BoolValByDefault == true)
                        {
                            TableCell = new DataCell(new string[] { TableConsts.TrueWord, TableConsts.FalseWord }, 2);
                            if ((bool)ChkBCell.Value)
                            {
                                TableCell.SetActiveN(1);
                            }
                            else
                            {
                                TableCell.SetActiveN(2);
                            }
                        }
                        else
                        {
                            TableCell = new DataCell(new string[] { TableConsts.FalseWord, TableConsts.TrueWord }, 2);
                            if ((bool)ChkBCell.Value)
                            {
                                TableCell.SetActiveN(1);
                            }
                            else
                            {
                                TableCell.SetActiveN(2);
                            }
                        }
                        break;
                    default:
                        //TableCell = new DataCell((bool)ChkBCell.Value);
                        TableCell = new DataCell(MyLib.BoolToInt((bool)ChkBCell.Value));
                        break;
                }
            }
            else if (GridCell is DataGridViewTextBoxCell)
            {
                //NOp;
            }
            else
            {
                val = (GridCell.Value.ToString());
                TableCell = MyLib.SetDataCellFromStringValParsing(val,TypesParams);
            }
            return TableCell;
        }
        //
        /*
        public TTable ReadFromGrid(DataGridView grid, TableStructure TblStr, TableHeaderRowsExistance GridHdrRowsUsedExt, TableSize QRowsNamesToDisplayExt, TableReadingTypesParams TypesParams, bool ToWrite = true)
        {
            int QTblCntLines, QTblCntColumns;
            TTable tbl=new TTable();
            CellsNsToDisplay NsToDispl=null;
            GridParamsGiven GridParams = null;
            TableSize QRowsNamesToDisplay=null;
            TableHeaderRowsExistance GridHdrRowsUsed;
            TableInfo TblInf = new TableInfo();
            if(GridHdrRowsUsedExt!=null) GridHdrRowsUsed=GridHdrRowsUsedExt; else GridHdrRowsUsed=new TableHeaderRowsExistance();
            if (QRowsNamesToDisplayExt != null) QRowsNamesToDisplay = QRowsNamesToDisplayExt; else QRowsNamesToDisplay = new TableSize();
            if (TblStr != null) TblInf.Str = TblStr; else TblInf.Str = new TableStructure();
            //if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            QTblCntLines = grid.Rows.Count - (QRowsNamesToDisplay.QColumns - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists));
            QTblCntColumns = grid.Columns.Count - (QRowsNamesToDisplay.QColumns - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists));
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize(QTblCntLines, QTblCntColumns);
            //
            //GridParams=new GridParamsGiven(
            if (TblInf.GetIf_LC_Not_CL())
            {
                tbl.ContentCell = new DataCell[QTblCntLines][];
                for (int i = 1; i <= QTblCntLines; i++)
                {
                    tbl.ContentCell[i - 1] = new DataCell[QTblCntColumns];
                    for (int j = 1; j <= QTblCntColumns; j++)
                    {
                        tbl.ContentCell[i - 1][j - 1] = new DataCell();
                        //tbl.ContentCell[i - 1][j - 1] =DataCellOfGridContentCell(GridCell, TypesParams);
                    }
                }
            }
            else
            {
                tbl.ContentCell = new DataCell[QTblCntColumns][];
                for (int i = 1; i <= QTblCntColumns; i++)
                {
                    tbl.ContentCell[i - 1] = new DataCell[QTblCntLines];
                    for (int j = 1; j <= QTblCntLines; j++)
                    {
                        tbl.ContentCell[i - 1][j - 1] = new DataCell();
                        //tbl.ContentCell[i - 1][j - 1] =DataCellOfGridContentCell(GridCell, TypesParams);
                    }
                }
            }
            //
            return tbl;
        }//fn
        */
        public TTable ReadFromGrid(DataGridView grid, TableHeaderRowsExistance GridHdrRowsUsedExt, TableStructure TblStr, TableSize QRowsNamesToDisplayExt, TableReadingTypesParams ContentTypesParamsExt, TableReadingTypesParams CoLHTypesParamsExt = null, TableReadingTypesParams LoCHTypesParamsExt = null, bool ToWrite = true)
        {
            DataGridViewCell GridCell = null;
            DataCell TableCell = null;
            int QLines, QColumns, gLineN = 0, gColN = 0, ErstGridContentLineN, ErstGridContentColN;
            TTable tbl = new TTable();
            CellsNsToDisplay NsToDispl = null;
            //GridParamsGiven GridParams = null;
            GridParamsCalculated GridParams = null;
            TableSize QRowsNamesToDisplay = null;
            TableHeaderRowsExistance GridHdrRowsUsed;
            TableReadingTypesParams ContentTypesParams = null, CoLHTypesParams = null, LoCHTypesParams = null;
            bool CorrectCorner = true;
            string TableName = "", LinesGeneralName = "", ColumnsGeneralName = "";
            //DataCellRowCoHeader[] rows = null;
            if (ContentTypesParamsExt != null) ContentTypesParams = ContentTypesParamsExt; else ContentTypesParams = new TableReadingTypesParams();
            ContentTypesParams.StrOnly();
            if (LoCHTypesParamsExt != null) LoCHTypesParams = LoCHTypesParamsExt; else LoCHTypesParams = new TableReadingTypesParams();
            LoCHTypesParams.StrOnly();
            if (CoLHTypesParamsExt != null) CoLHTypesParams = CoLHTypesParamsExt; else CoLHTypesParams = new TableReadingTypesParams();
            CoLHTypesParams.StrOnly();
            TableInfo TblInf = new TableInfo();
            if (GridHdrRowsUsedExt != null) GridHdrRowsUsed = GridHdrRowsUsedExt; else GridHdrRowsUsed = new TableHeaderRowsExistance();
            if (QRowsNamesToDisplayExt != null) QRowsNamesToDisplay = QRowsNamesToDisplayExt; else QRowsNamesToDisplay = new TableSize();
            if (TblStr != null) TblInf.Str = TblStr;
            else
            {
                TblInf.Str = new TableStructure(); //LC_not_CL remains as by default
                TblInf.Str.ColOfLineHeaderExists = GridHdrRowsUsedExt.ColOfLineHeaderExists;
                TblInf.Str.LineOfColHeaderExists = GridHdrRowsUsedExt.LineOfColHeaderExists;
            }
            //if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            QLines = grid.Rows.Count - (QRowsNamesToDisplay.QLines - MyLib.BoolToInt(GridHdrRowsUsed.LineOfColHeaderExists));
            QColumns = grid.Columns.Count - (QRowsNamesToDisplay.QColumns - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists));
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize(QLines, QColumns);
            //GridParamsCalculated(TableHeaderRowsExistance GridHdrInUseExt, TableHeaderRowsExistance TblHdrToShowExt, TableSize QTableRowsAllExt, TableSize QTableRowsToShowExt, TableSize ErstTableRowsNsToShowExt, TableSize QRowsNamesToShowExt)
            NsToDispl = new CellsNsToDisplay(TblInf.RowsQuantities);
            //GridHdrInUseExt - param
            GridParams = new GridParamsCalculated(GridHdrRowsUsedExt, NsToDispl, TblInf);
            //Content
            if (TblInf.GetIf_LC_Not_CL())
            {
                tbl.ContentCell = new DataCell[QLines][];
                for (int tLineN = 1; tLineN <= QLines; tLineN++)
                {
                    tbl.ContentCell[tLineN - 1] = new DataCell[QColumns];
                    for (int tColN = 1; tColN <= QColumns; tColN++)
                    {
                        tbl.ContentCell[tLineN - 1][tColN - 1] = new DataCell();
                        //gLineN = QRowsNamesToDisplay.QLines - MyLib.BoolToInt(GridHdrRowsUsed.LineOfColHeaderExists) + i - 1;
                        //gColN = QRowsNamesToDisplay.QColumns - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists) + j - 1;
                        gLineN = GridParams.Calc_GridLineIndex_ByTableLineNatN(tLineN);
                        gColN = GridParams.Calc_GridColIndex_ByTableColNatN(tColN);
                        if (gLineN == -1 && gColN == -1) GridCell = grid.TopLeftHeaderCell;
                        else if (gLineN > -1 && gColN == -1) GridCell = grid.Rows[gLineN].HeaderCell;
                        else if (gLineN == -1 && gColN > -1) GridCell = grid.Columns[gColN].HeaderCell;
                        else GridCell = grid.Rows[gLineN].Cells[gColN];
                        tbl.ContentCell[tLineN - 1][tColN - 1] = DataCellOfGridContentCell(GridCell, ContentTypesParams);
                    }
                }
            }
            else
            {
                tbl.ContentCell = new DataCell[QColumns][];
                for (int tColN = 1; tColN <= QColumns; tColN++)
                {
                    tbl.ContentCell[tColN - 1] = new DataCell[QLines];
                    for (int tLineN = 1; tLineN <= QLines; tLineN++)
                    {
                        tbl.ContentCell[tLineN - 1][tColN - 1] = new DataCell();
                        gLineN = GridParams.Calc_GridLineIndex_ByTableLineNatN(tLineN);
                        gColN = GridParams.Calc_GridColIndex_ByTableColNatN(tColN);
                        if (gLineN == -1 && gColN == -1) GridCell = grid.TopLeftHeaderCell;
                        else if (gLineN > -1 && gColN == -1) GridCell = grid.Rows[gLineN].HeaderCell;
                        else if (gLineN == -1 && gColN > -1) GridCell = grid.Columns[gColN].HeaderCell;
                        else GridCell = grid.Rows[gLineN].Cells[gColN];
                        tbl.ContentCell[tColN - 1][tLineN - 1] = DataCellOfGridContentCell(GridCell, ContentTypesParams);
                    }
                }
            }
            //LineOfColHeader
            if (TblInf.GetIf_LoCHExists())
            {
                //if (this.LineOfColHeader == null) this.LineOfColHeader = new DataCell[QColumns];
                //in C++ if !=NULL delete[]
                tbl.LineOfColHeader = new DataCell[QColumns]; //even if exists, ob mab exist'n table hat atal cuan o'Cols, or Z s'null, or Z hat irr vals
                if (GridHdrRowsUsedExt.LineOfColHeaderExists)
                {
                    for (int tColN = 1; tColN <= QColumns; tColN++)
                    {
                        tbl.LineOfColHeader[tColN - 1] = new DataCell();
                        //gLineN = QRowsNamesToDisplay.QLines - MyLib.BoolToInt(GridHdrRowsUsed.LineOfColHeaderExists) + i - 1;
                        //gColN = QRowsNamesToDisplay.QColumns - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists) + j - 1;
                        //gColN = QRowsNamesToDisplay.QColumns - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists) + i - 1;
                        gColN = GridParams.Calc_GridColIndex_ByTableColNatN(tColN);
                        tbl.LineOfColHeader[tColN - 1].SetByValString(grid.Columns[gColN].HeaderCell.Value.ToString());
                        for (int j = 2; j <= QRowsNamesToDisplay.QLines; j++)
                        {
                            //this.LineOfColHeader[tColN - 1].SetByValStringN((grid.Rows[2 - 2].Cells[gColN].Value.ToString()), j);
                            if (grid.Rows[j - 2].Cells[gColN].Value != null && grid.Rows[j - 2].Cells[gColN].Value.ToString() != "") tbl.LineOfColHeader[tColN - 1].SetByValStringN((grid.Rows[2 - 2].Cells[gColN].Value.ToString()), j);
                        }
                    }
                }
                else
                {
                    for (int tColN = 1; tColN <= QColumns; tColN++)
                    {
                        //gLineN = QRowsNamesToDisplay.QLines - MyLib.BoolToInt(GridHdrRowsUsed.LineOfColHeaderExists) + i - 1;
                        //gColN = QRowsNamesToDisplay.QColumns - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists) + j - 1;
                        //gColN = QRowsNamesToDisplay.QColumns - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists) + i - 1;
                        gColN = GridParams.Calc_GridColIndex_ByTableColNatN(tColN);
                        tbl.LineOfColHeader[tColN - 1].SetByValString(grid.Rows[0].Cells[gColN].Value.ToString());
                        for (int j = 2; j <= QRowsNamesToDisplay.QLines; j++)
                        {
                            //this.LineOfColHeader[tColN - 1].SetByValStringN((grid.Rows[2 - 2].Cells[gColN].Value.ToString()), j);
                            if (grid.Rows[j - 1].Cells[gColN].Value != null && grid.Rows[j - 1].Cells[gColN].Value.ToString() != "") tbl.LineOfColHeader[tColN - 1].SetByValStringN((grid.Rows[2 - 2].Cells[gColN].Value.ToString()), j);
                        }
                    }
                }
            }
            //ColOfLineHeader
            if (TblInf.GetIf_CoLHExists())
            {
                //if (this.LineOfColHeader == null) this.LineOfColHeader = new DataCell[QColumns];
                //in C++ if !=NULL delete[]
                tbl.ColOfLineHeader = new DataCell[QLines]; //even if exists, ob mab exist'n table hat atal cuan o'Cols, or Z s'null, or Z hat irr vals
                if (GridHdrRowsUsedExt.ColOfLineHeaderExists)
                {
                    for (int tLineN = 1; tLineN <= QLines; tLineN++)
                    {
                        tbl.ColOfLineHeader[tLineN - 1] = new DataCell();
                        //gLineN = QRowsNamesToDisplay.QLines - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists) + i - 1;
                        //gColN = QRowsNamesToDisplay.QColumns - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists) + j - 1;
                        //gColN = QRowsNamesToDisplay.QColumns - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists) + i - 1;
                        gLineN = GridParams.Calc_GridLineIndex_ByTableLineNatN(tLineN);
                        tbl.ColOfLineHeader[tLineN - 1].SetByValString(grid.Rows[gLineN].HeaderCell.Value.ToString());
                        for (int j = 2; j <= QRowsNamesToDisplay.QLines; j++)
                        {
                            //this.ColOfLineHeader[tColN - 1].SetByValStringN((grid.Rows[2 - 2].Cells[gColN].Value.ToString()), j);
                            if (grid.Rows[gLineN].Cells[j - 2].Value != null && grid.Rows[gLineN].Cells[j - 2].Value.ToString() != "") tbl.ColOfLineHeader[tLineN - 1].SetByValStringN((grid.Rows[2 - 2].Cells[gColN].Value.ToString()), j);
                        }
                    }
                }
                else
                {
                    for (int tLineN = 1; tLineN <= QLines; tLineN++)
                    {
                        //gLineN = QRowsNamesToDisplay.QLines - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists) + i - 1;
                        //gColN = QRowsNamesToDisplay.QColumns - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists) + j - 1;
                        //gColN = QRowsNamesToDisplay.QColumns - MyLib.BoolToInt(GridHdrRowsUsed.ColOfLineHeaderExists) + i - 1;
                        gLineN = GridParams.Calc_GridLineIndex_ByTableLineNatN(tLineN);
                        tbl.ColOfLineHeader[tLineN - 1].SetByValString(grid.Rows[gLineN].Cells[0].Value.ToString());
                        for (int j = 2; j <= QRowsNamesToDisplay.QLines; j++)
                        {
                            //this.ColOfLineHeader[tColN - 1].SetByValStringN((grid.Rows[2 - 2].Cells[gColN].Value.ToString()), j);
                            if (grid.Rows[gLineN].Cells[j - 2].Value != null && grid.Rows[gLineN].Cells[j - 2].Value.ToString() != "") tbl.ColOfLineHeader[tLineN - 1].SetByValStringN((grid.Rows[2 - 2].Cells[gColN].Value.ToString()), j);
                        }
                    }
                }
            }
            //Corner
            if (TblInf.Str.LineOfColHeaderExists && TblInf.Str.ColOfLineHeaderExists)
            {
                if (GridHdrRowsUsedExt.LineOfColHeaderExists == true && GridHdrRowsUsedExt.ColOfLineHeaderExists == true)
                {
                    GridCell = grid.TopLeftHeaderCell;
                }
                else if (GridHdrRowsUsedExt.LineOfColHeaderExists == false && GridHdrRowsUsedExt.ColOfLineHeaderExists == true)
                {
                    GridCell = grid.Rows[0].HeaderCell;
                }
                else if (GridHdrRowsUsedExt.LineOfColHeaderExists == true && GridHdrRowsUsedExt.ColOfLineHeaderExists == false)
                {
                    GridCell = grid.Columns[0].HeaderCell;
                }
                else
                {
                    GridCell = grid.Rows[0].Cells[0];
                }
                MyLib.ParseNamesOfTableCorner(GridCell.Value.ToString(), ref CorrectCorner, ref LinesGeneralName, ref ColumnsGeneralName, ref TableName);
            }
            //
            if (LinesGeneralName != null && LinesGeneralName != "") tbl.SetLinesGeneralName(LinesGeneralName);//tbl.SetLinesGeneralHeader(new DataCell(LinesGeneralName));
            if (ColumnsGeneralName != null && ColumnsGeneralName != "") tbl.SetColumnsGeneralName(ColumnsGeneralName);//tbl.SetColumnsGeneralHeader(new DataCell(ColumnsGeneralName));
            if (TableName != null && TableName != "") tbl.SetTableName(TableName);// tbl.SetTableHeader(new DataCell(TableName));
            //
            return tbl;
        }//fn read from grid
        bool LineNameExists(string name)
        {
            bool b = false;
            int QLines = 0, count = 0;
            if (ColOfLineHeader != null)
            {
                for (int i = 1; i <= QLines; i++)
                {
                    if (name.Equals(ToString_ColOfLineHeader(i))) count++;
                }
            }
            b = (count > 0);
            return b;
        }
        bool ColumnNameExists(string name, int N = 1, TableInfo_ConcrRepr TblInfExt = null)
        {
            bool b = false;
            int QColumns = 0, count = 0;
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            QColumns = TblInf.GetQColumns();
            if (LineOfColHeader != null)
            {
                for (int i = 1; i <= QColumns; i++)
                {
                    if (name.Equals(ToString_LineOfColHeader(i))) count++;
                }
            }
            b = (count > 0);
            return b;
        }
        /*
        bool ColumnNameExists(DataCell NewHeader,int NameNToCompare=0)
        {
            bool b = false;
            bool QItemsSame, ActiveNSame, ActiveValSame, AllItemsAreSame;
            int QItemsExisting, QItemsNew, TypeNExisting, TypeNNew;//, ActiveNExisting, ActiveNNew;
            int MinLength=1;
            string [] ItemsExisting=null, ItemsNew=null;
            string CurNameExisting, CurNameNew;
            int QColumns = 0, count = 0;
            if (LineOfColHeader != null)
            {
                for (int i = 1; i <= QColumns; i++)
                {
                    QItemsExisting=LineOfColHeader[i-1].GetLength();
                    QItemsNew=NewHeader.GetLength();
                    if(QItemsNew<=QItemsExisting)MinLength=QItemsNew; else MinLength=QItemsExisting;
                    TypeNExisting=LineOfColHeader[i-1].GetTypeN();
                    TypeNNew=NewHeader.GetTypeN();
                    //ActiveNExisting=LineOfColHeader[i-1].GetActiveN();
                    //ActiveNNew=NewHeader.GetActiveN();
                    CurNameExisting=LineOfColHeader[i-1].GetNameN(NameNToCompare);
                    CurNameNew=NewHeader.GetNameN(NameNToCompare);;
                    //
                    for(int j=1; j<=MinLength;j++){
                        
                    }
                    if(NameNToCompare==0){

                        if (TableConsts.TypeNIsCorrectArray(TypeNExisting))
                        {
                            if (TableConsts.TypeNIsCorrectArray(TypeNNew))
                            {
                                //if()
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (TableConsts.TypeNIsCorrectArray(TypeNNew))
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {
                        
                    }
                    //
                    //ActiveNSame=(ActiveNExisting==ActiveNNew);
                    QItemsSame=(QItemsExisting==QItemsNew);
                    
                    
                }
            }
            b = (count > 0);
            return b;
        }
        */
        /*
        public void SetDataCellByDataCell(DataCell data, int LineN, int ColumnN, TableInfo TblInfExt)
        {
            TableInfo TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            if (LineN >= 1 && ColumnN >= 1 && LineN <= TblInf.GetQLines() && ColumnN <= TblInf.GetQColumns())
            {
                if (TblInf.GetIf_LC_Not_CL())
                {
                    this.ContentCell[LineN - 1][ColumnN - 1] = (DataCell)data.Clone();
                }
                else
                {
                    this.ContentCell[ColumnN - 1][LineN - 1] = (DataCell)data.Clone();
                }
            }
        }
        */
        //
        public int CellIsEqualToColHeaderCellN(DataCell Cell, TableInfo_ConcrRepr TblInfExt = null, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1, TableSize ExtCellNs = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int NR = -1;
            bool CurAreEqual;
            if (LineOfColHeader != null)
            {
                for (int i = 1; i <= TblInf.GetQColumns(); i++)
                {
                    CurAreEqual = MyLib.fCellsAreEqual(Cell, LineOfColHeader[i - 1], AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, (new TableSize(0, i)), ExtCellNs);
                    if (CurAreEqual)
                    {
                        NR = i;
                    }
                }
            }
            return NR;
        }//CellIsEqualToColHeaderCellN
        public int CellIsEqualToLineHeaderCellN(DataCell Cell, TableInfo_ConcrRepr TblInfExt = null, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1, TableSize ExtCellNs = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int NR = -1;
            bool CurAreEqual;
            if (ColOfLineHeader != null)
            {
                for (int i = 1; i <= TblInf.GetQLines(); i++)
                {
                    CurAreEqual = MyLib.fCellsAreEqual(Cell, ColOfLineHeader[i - 1], AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, (new TableSize(i, 0)), ExtCellNs);
                    if (CurAreEqual)
                    {
                        NR = i;
                    }
                }
            }
            return NR;
        }//CellIsEqualToLineHeaderCellN
        public TableSize CellIsEqualToContentCellN(DataCell Cell, TableInfo_ConcrRepr TblInfExt = null, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1, TableSize ExtCellNs = null, TableSize SeekFromNs = null, bool StartFrom_LC_not_CL = true)
        {
            DataCell CurTableContentCell;
            bool CurAreEqual, Found;
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            int QLines = TblInf.GetQLines(), QColumns = TblInf.GetQColumns(), count;
            TableSize R = null, LimNs;
            if (SeekFromNs != null) LimNs = SeekFromNs; else LimNs = new TableSize(1, 1);
            count = 0;
            if (StartFrom_LC_not_CL)
            {
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        CurTableContentCell = GetCell(i, j, TblInf);
                        CurAreEqual = MyLib.fCellsAreEqual(Cell, CurTableContentCell, AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, (new TableSize(i, j)), ExtCellNs);
                        //if (CurAreEqual)
                        if (i >= SeekFromNs.GetQLines() && j >= SeekFromNs.GetQColumns())
                        {
                            if (i >= SeekFromNs.GetQLines())
                            {
                                count++;
                                if (count == 1)
                                {
                                    Found = true;
                                    R = new TableSize(i, j);
                                }
                            }//if
                        }//if
                    }//for
                }//for
            }
            else
            {
                for (int i = 1; i <= QColumns; i++)
                {
                    for (int j = 1; j <= QLines; j++)
                    {
                        CurTableContentCell = GetCell(j, i, TblInf);
                        CurAreEqual = MyLib.fCellsAreEqual(Cell, CurTableContentCell, AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, (new TableSize(i, j)), ExtCellNs);
                        if (CurAreEqual)
                        {
                            //if (i >= SeekFromNs.GetQColumns())
                            if (j >= SeekFromNs.GetQLines() && i >= SeekFromNs.GetQColumns())
                            {
                                count++;
                                if (count == 1)
                                {
                                    Found = true;
                                    R = new TableSize(j, i);
                                }
                            }//if
                        }//if
                    }//for
                }//for
            }
            return R;
        }
        //
        /*
        public int ColHeaderCellNIsEqualToCell(DataCell Cell, TableInfo_ConcrRepr TblInfExt = null, int EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9 = 1)
        {
            int N = 0, QLines, QColumns;
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            QLines = TblInf.GetQColumns();
            QColumns = TblInf.GetQColumns();
            for (int i = 1; i <= QColumns; i++)
            {
                if (this.LineOfColHeader[i - 1].HeaderIsEqualTo(Cell, EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9))
                {
                    N = i;
                }
            }
            return N;
        }
        public int LineHeaderCellNIsEqualToCell(DataCell Cell, TableInfo_ConcrRepr TblInfExt = null, int EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9 = 1)
        {
            int N = 0, QLines;
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            QLines = TblInf.GetQLines();
            for (int i = 1; i <= QLines; i++)
            {
                if (this.ColOfLineHeader[i - 1].HeaderIsEqualTo(Cell, EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9))
                {
                    N = i;
                }
            }
            return N;
        }
        */
        //HeadersAreSame = MyLib.fCellsAreEqual(Hdr1, Hdr2, AreEqualBy_N0_Name1_ValAsDbl2Int3Bool4Str5_Full6, new TableSize(j, 0), RowsNs);
        //if (HeadersAreSame)
        //{
        //    CorrespondingLines_NsOfT1ForT2 = j;
        //}
        public void AssignCell(DataCell ccell, int LineN, int ColN, TableInfo TblInfExt=null)
        {
            TableInfo TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            if (LineN <= TblInf.GetQLines() && ColN <= TblInf.GetQColumns())
            {
                if (LineN >= 1 && ColN >= 1)
                {
                    if (TblInf.GetIf_LC_Not_CL())
                    {
                        this.ContentCell[LineN - 1][ColN - 1] = (DataCell)ccell.Clone();
                    }
                    else
                    {
                        this.ContentCell[LineN - 1][ColN - 1] = (DataCell)ccell.Clone();
                    }
                }
                else if (LineN == 0 && ColN >= 1)
                {
                    this.LineOfColHeader[ColN - 1] = (DataCell)ccell.Clone();
                }
                else if (LineN >= 1 && ColN == 0)
                {
                    this.ColOfLineHeader[LineN - 1] = (DataCell)ccell.Clone();
                }
            }
        }
        public void AddTableWithRulesCellByCell(TTable Tbl2, TableInfo_ConcrRepr TblInfExt2, TableInfo_ConcrRepr TblInf1Ini, ref TableInfo_ConcrRepr TblInf1Actual, TTablesConcatRules TablesConcatRulesExt = null, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1, TValsShowHide vsh=null)
        {
            TableInfo_ConcrRepr TblInf2 = Tbl2.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt2),
                               TblInf1 = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInf1Actual); //itr can be ne for 1st, so ne ini
            DataCell LineHeader, ColHeader, ccell;
            TableSize RowsNs = new TableSize();
            int LineN, ColN, QLinesPrev, QColumnsPrev, QLinesActual, QColumnsActual, QLinesToAddMax, QColumnsToAddMax;
            QLinesPrev = TblInf1Ini.GetQLines();
            QColumnsPrev = TblInf1Ini.GetQColumns();
            QLinesActual = TblInf1.GetQLines();
            QColumnsActual = TblInf1.GetQColumns();
            QLinesToAddMax = TblInf2.GetQLines();
            QColumnsToAddMax = TblInf2.GetQColumns();
            for (int i = 1; i <= QLinesToAddMax; i++) {
                for (int j = 1; j <= QColumnsToAddMax; j++){
                    RowsNs.Set(i, j);
                    ccell = Tbl2.GetCell(i, j, TblInf2);
                    LineHeader = Tbl2.GetCell_ColOfLineHeader(i);
                    ColHeader = Tbl2.GetCell_LineOfColHeader(j);
                    //public void AddCellAndAddHeadersByRules(DataCell ccell, DataCell LineOfColHeader, DataCell ColOfLineHeader, TTablesConcatRules TablesConcatRulesExt = null, TableSize RowsNs = null, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1, TableInfo_ConcrRepr TblInf1Ext = null)
                    //public void AddCellToTable_WithHeaders_ByRules_WithSupplIniQRows(DataCell ccell, DataCell ColOfLineHeader, DataCell LineOfColHeader, ref TableInfo_ConcrRepr TblInf1Actual, TableInfo_ConcrRepr TblInf1Ini, TTablesConcatRules TablesConcatRulesExt = null, int AreEqualBy_N0_Name1_ValAsDbl2Int3Bool4Str5_Full6 = 1, TValsShowHide vsh = null)
                    //void AddCellToTable_WithHeaders_ByRules_WithSupplIniQRows(DataCell ccell, DataCell LineHeader, DataCell ColHeader, ref TableInfo_ConcrRepr TblInf1Actual, TableInfo_ConcrRepr TblInf1Ini, TableSize RowsNs, TTablesConcatRules TablesConcatRulesExt = null, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1, TValsShowHide vsh = null) AddCellToTable_WithHeaders_ByRules_WithSupplIniQRows(                       ccell,                LineHeader,         ColHeader, ref TblInf1Actual, TblInf1Ini, TablesConcatRulesExt, AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, vsh);
                    AddCellToTable_WithHeaders_ByRules_WithSupplIniQRows(ccell, LineHeader, ColHeader, ref TblInf1Actual, TblInf1Ini, RowsNs, TablesConcatRulesExt, AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, vsh);
                }
            }
        }//ат add rable cekll by cell
        public TTable AddTableWithRulesCellByCellTo(TTable Tbl1, TTable Tbl2, TableInfo_ConcrRepr TblInfExt2, TableInfo_ConcrRepr TblInfIni, ref TableInfo_ConcrRepr TblInfActual, bool ToWriteInfo = true, TTablesConcatRules TablesConcatRulesExt = null, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1, TValsShowHide vsh = null)
        {
            //TableInfo_ConcrRepr TblInfIni;
            TTable TR = Tbl1;
            //public void AddTableWithRulesCellByCell(TTable Tbl2, TableInfo_ConcrRepr TblInfExt2, TableInfo_ConcrRepr TblInf1Ini, ref TableInfo_ConcrRepr TblInf1Actual, TTablesConcatRules TablesConcatRulesExt = null, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1, TValsShowHide vsh=null)
            TR.AddTableWithRulesCellByCell(Tbl2, TblInfExt2,  TblInfIni, ref TblInfActual, TablesConcatRulesExt, AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, vsh);
            return TR;
        }
        //
        /*
        public void AddCellAndAddHeadersByRules(DataCell ccell, DataCell LineOfColHeader, DataCell ColOfLineHeader, TTablesConcatRules TablesConcatRulesExt = null, TableSize RowsNs = null, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1, TableInfo_ConcrRepr TblInf1Ext = null)
        { //old vrn

            //
            // ha 2 tables: hic et ext
            // assign arrays of fitting Ns et NewNs as -1
            // uz je line of added table assign array of fitting Ns
            // uz je col of added table assign array of fitting Ns
            // if add lines anyway:
            //   add all lines
            //   write ir hdrs, if both orig and new ha em
            //   assign array of fitting New Ns 
            // if add cols anyway:
            //   add all lines
            //   write ir hdrs, if both orig and new ha em
            //   assign array of fitting New Ns 
            // if add nur new lines:
            //   uz je line o'new tbl: compar, et, if S'new:
            //     add
            //     write ir hdrs, if both orig and new ha em
            //     assign array of new Ns
            // if add new cols:
            //   uz je col o'new tbl: compar, et, if S'new:
            //     add
            //     write ir hdrs, if both orig and new ha em
            //     assign array of new Ns
            //   
            // Now write Comntent Cells to ones co default vals.
            //   if lines to add anyway, cols to add anyway:
            //     for(i=1...QLinesToAddMax, j=1...QColsToAddMax) Cell(NewN(i), NewN(j))=CellToAdd(i,j)
            //  if lines to add anyway, 
            //     if cols to add new, to ignore old :
            //       if col s'new:
            //          Cell(NewN(i), NewN(j))=CellToAdd(i,j)
            //        if col s'old:
            //          NOP
            //     if cols to add new, to replace old :
            //       if col s'new:
            //         Cell(NewN(i), NewN(j))=CellToAdd(i,j)
            //       if col s'old:
            //         Cell(NewN(i), N(j))=CellToAdd(i,j)
            //    if cols to ignore new, to ignore old :
            //       if col s'new:
            //          NOP
            //        if col s'old:
            //          Cell(NewN(i), N(j))=CellToAdd(i,j)
            //    if cols to ignore new, to replace old :
            //       if col s'new:
            //          NOP
            //        if col s'old:
            //          Cell(NewN(i), N(j))=CellToAdd(i,j)
            //          
            // so for other vrns uz lines
            //
            //
            TableInfo_ConcrRepr TblInf1;//, TblInf2;
            TTablesConcatRules TablesConcatRules;
            DataCell Hdr1 = null, Hdr2 = null, HdrL1, HdrC1;//, ccell, HdrL2, HdrC2;
            bool NeedAddLines, NeedAddColumns, HeadersAreSame;
            int CorrespondingLines_NsOfT1ForT2 = -1, CorrespondingCols_NsOfT1ForT2 = -1, CorrespondingLines_NsOfT1ForT2_New = -1, CorrespondingCols_NsOfT1ForT2_New = -1;
            int QLinesPrev, QColsPrev;//, QLinesToAddMax, QColsToAddMax;
            int LineN, ColN;
            if (RowsNs != null)
            {
                LineN = RowsNs.QLines;
                ColN = RowsNs.QColumns;
            }
            else
            {
                LineN = 1;
                ColN = 1;
            }
            TblInf1 = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInf1Ext);
            //TblInf2 = tbl2.Choose_TableInfo_StrSize_ByExtAndInner(TblInf2Ext);
            if (TablesConcatRulesExt != null) TablesConcatRules = TablesConcatRulesExt; else TablesConcatRules = new TTablesConcatRules();
            NeedAddLines = (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 1 || TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 0 || (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 1));
            NeedAddColumns = (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0 || (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1));
            QLinesPrev = TblInf1.GetQLines();
            QColsPrev = TblInf1.GetQColumns();
            //QLinesToAddMax = TblInf2.GetQLines();
            //QColsToAddMax = TblInf2.GetQColumns();
            //Fit'n Ns ef add rows
            //CorrespondingLines_NsOfT1ForT2 = new int[QLinesToAddMax];
            //for (int i = 1; i <= QLinesToAddMax; i++) 
            //CorrespondingLines_NsOfT1ForT2[i - 1] = -1;
            //for (int i = 1; i <= QLinesToAddMax; i++)
            //{
            CorrespondingLines_NsOfT1ForT2 = -1;
            Hdr2 = (DataCell)ColOfLineHeader.Clone();
            for (int j = 1; j <= QLinesPrev; j++)
            {
                Hdr1 = (DataCell)this.ColOfLineHeader[j - 1].Clone();
                //Hdr2 = (DataCell)tbl2.GetCell_ColOfLineHeader(i).Clone();
                HeadersAreSame = MyLib.fCellsAreEqual(Hdr1, Hdr2, AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, new TableSize(j, 0), new TableSize(1, 1));
                if (HeadersAreSame)
                {
                    CorrespondingLines_NsOfT1ForT2 = j;
                }
                //}//for
            }//for
            // CorrespondingCols_NsOfT1ForT2 = new int[QColsToAddMax];
            //for (int i = 1; i <= QColsToAddMax; i++) CorrespondingCols_NsOfT1ForT2[i - 1] = -1;
            //for (int i = 1; i <= QColsToAddMax; i++)
            //{
            CorrespondingCols_NsOfT1ForT2 = -1;
            Hdr2 = (DataCell)LineOfColHeader.Clone();
            for (int j = 1; j <= QColsPrev; j++)
            {
                Hdr1 = (DataCell)this.LineOfColHeader[j - 1].Clone();
                //Hdr2 = (DataCell)tbl2.GetCell_LineOfColHeader(i).Clone();
                HeadersAreSame = MyLib.fCellsAreEqual(Hdr1, Hdr2, AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, new TableSize(0, j), new TableSize(1, 1));
                if (HeadersAreSame)
                {
                    CorrespondingCols_NsOfT1ForT2 = j;
                }
                //}//for
            }//for
            //Add rows
            //Lines
            Hdr2 = (DataCell)ColOfLineHeader.Clone();
            if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 1 || TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 0)
            {
                //for (int i = 1; i <= QLinesToAddMax; i++)
                //{
                this.AddLine_TypesByExisting();
                TblInf1.AddLine();
                this.ColOfLineHeader[QLinesPrev - 1] = Hdr2;
                CorrespondingLines_NsOfT1ForT2_New = QLinesPrev + 1;
                //}
            }
            else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 1)
            {
                //CorrespondingLines_NsOfT1ForT2_New = new int[QLinesToAddMax];
                //for (int i = 1; i <= QLinesToAddMax; i++)
                //{
                if (CorrespondingLines_NsOfT1ForT2 == -1)
                {
                    Hdr2 = (DataCell)ColOfLineHeader.Clone();
                    this.AddLine_TypesByExisting();
                    TblInf1.AddLine();
                    this.ColOfLineHeader[QLinesPrev - 1] = Hdr2;
                    CorrespondingLines_NsOfT1ForT2_New = TblInf1.GetQLines();
                }
                else CorrespondingLines_NsOfT1ForT2_New = CorrespondingLines_NsOfT1ForT2;
                //}//for
            }//else no need to add lines, so NOp
            //Cols
            if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
            {
                //for (int i = 1; i <= QColsToAddMax; i++)
                //{
                this.AddColumn_TypesByExisting();
                TblInf1.AddColumn();
                this.LineOfColHeader[QColsPrev - 1] = Hdr2;
                CorrespondingCols_NsOfT1ForT2_New = TblInf1.GetQColumns();
                //}
            }
            else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1)
            {
                //CorrespondingCols_NsOfT1ForT2_New = new int[QColsToAddMax];
                //for (int i = 1; i <= QColsToAddMax; i++)
                //{
                Hdr2 = (DataCell)LineOfColHeader.Clone();
                if (CorrespondingCols_NsOfT1ForT2 == -1)
                {
                    //Hdr2 = (DataCell)tbl2.GetCell_LineOfColHeader(i).Clone();
                    this.AddColumn_TypesByExisting();
                    TblInf1.AddColumn();
                    this.LineOfColHeader[QLinesPrev - 1] = Hdr2;
                    CorrespondingCols_NsOfT1ForT2_New = TblInf1.GetQColumns();
                }
                //else CorrespondingCols_NsOfT1ForT2_New[i - 1] = CorrespondingCols_NsOfT1ForT2[i - 1];
                //}//for
            }//else no need to add col, so NOp
            //CotentCells
            //for (int i = 1; i <= QLinesToAddMax; i++)
            //{
            //    for (int j = 1; j <= QColsToAddMax; j++)
            //    {
            //ccell = tbl2.GetCell(i, j, TblInf2);
            //
            if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 1 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
            {
                if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                {
                    //lines add anyway, cols add anyway
                    //cells to unique rows
                    if (CorrespondingLines_NsOfT1ForT2_New != -1 && CorrespondingCols_NsOfT1ForT2_New != -1)
                    {
                        this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                {
                    //lines add anyway, cols new ignore, old ignore
                    //cols are not added, in new lines - cells s':
                    //- of old cols s'ne old, so ne ignored, 
                    //- of new s'new, so ignored 
                    if (CorrespondingCols_NsOfT1ForT2 != -1)
                    { //old
                        this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                    }//else NOp;
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                {
                    //lines add anyway, cols new ignored, old - replaced
                    //in diff lines old cols s' ne old, so ne replaced, ma S'iid to replace in new lines, so write/
                    //new cols s'ignored=> ne add'd, ne exist
                    if (CorrespondingCols_NsOfT1ForT2 != -1)
                    { //old
                        this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                    }//else NOp;
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                {
                    //lines add anyway, cols new added, old - ignored
                    //in new lines cells of old cols s'ne old==> ne ignored
                    //so new cols to write to N, fit'n to new cols, and old - on Ns, fit'n to old
                    if (CorrespondingCols_NsOfT1ForT2_New != -1)
                    { //new
                        this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                    }
                    else
                    {
                        this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                {
                    //lines add anyway, cols new added, old - ignored
                    //in new lines cells of old cols s'ne old, so - written
                    if (CorrespondingCols_NsOfT1ForT2_New != -1)
                    { //new
                        this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                    }
                    else
                    {
                        this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                    }
                }
            }
            else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 0 && TablesConcatRules.LinesSame_Ignore0Replace1 == 0)
            {
                if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                {
                    //Lines: new - ignored, same - ignored
                    //cols: add anyway
                    //in new cols cells of old lines s'ne old, so  ne ignored. No new cols, ob Z s'ignor'd et ne wa add'd
                    if (CorrespondingLines_NsOfT1ForT2 != -1)
                    { //old lines
                        this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                {
                    //Lines: new - ignored, same - ignored
                    //Cols:  new - ignored, same - ignored
                    //no new rows added. Same rows ignored
                    //
                    //NOp;
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                {
                    //Lines: new - ignored, same - ignored
                    //Cols:  new - ignored, same - replaced
                    //no new rows added. 
                    //uz old rows conds uz lines et cols contradict?- bad cond - ignore
                    //
                    //NOp;
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                {
                    //Lines: new - ignored, same - ignored
                    //Cols:  new - add'd, same - ignored
                    //some cols s'added. uz hic cols same lines s'ne same=> ne ignor'd=>written
                    //so s'written cells of new cols and old lines
                    if (CorrespondingCols_NsOfT1ForT2_New != 1 && CorrespondingLines_NsOfT1ForT2 != 1)
                    {
                        this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                {
                    //Lines: new - ignored, same - ignored
                    //Cols:  new - add'd, same - to replace
                    //so write cells of new cols, if line s' old or new.
                    //if cell s'of old col - Contradict
                    if (CorrespondingCols_NsOfT1ForT2_New != 1)
                    {
                        if (CorrespondingLines_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                        }
                        else if (CorrespondingLines_NsOfT1ForT2_New != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                        }
                    }
                }
            }
            else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 0 && TablesConcatRules.LinesSame_Ignore0Replace1 == 1)
            {
                if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                {
                    //Lines new ignored, old replaced
                    //Cols added anyway
                    //so added cols and write cels of old lines
                    if (CorrespondingCols_NsOfT1ForT2 != 1 && CorrespondingLines_NsOfT1ForT2_New != 1)
                    {
                        this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                {
                    //Lines new ignored, old replaced
                    //Cols new and old ignored
                    //so cells for old lines - conds W-contradict 
                    //NOp;
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                {
                    //Lines new ignored, old replaced
                    //Cols new ignored, old replaced
                    //replace nur old cells
                    if (CorrespondingCols_NsOfT1ForT2 != 1 && CorrespondingLines_NsOfT1ForT2 != 1)
                    {
                        this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2);
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                {
                    //Lines new ignored, old replaced
                    //Cols add new, old ignore
                    if (CorrespondingCols_NsOfT1ForT2_New != 1 && CorrespondingLines_NsOfT1ForT2 != 1)
                    {
                        this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                {
                    //Lines new ignored, old replaced
                    //Cols new add, old replace
                    if (CorrespondingLines_NsOfT1ForT2 != 1)
                    {
                        if (CorrespondingCols_NsOfT1ForT2_New != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                        }
                        else if (CorrespondingCols_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2);
                        }
                    }
                }
            }
            else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 1 && TablesConcatRules.LinesSame_Ignore0Replace1 == 0)
            {
                if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                {
                    //Lines new add, old ignore
                    //Cols add anyway
                    //cells of old lines in new lines ne s'old=>ne ignored
                    //iid to ignore, write, ma correct
                    if (CorrespondingCols_NsOfT1ForT2_New != -1)
                    {
                        if (CorrespondingLines_NsOfT1ForT2_New != -1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                        }
                        else if (CorrespondingLines_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                        }
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                {
                    //Lines new add, old ignore
                    //Cols add anyway
                    //cells of old lines in new lines ne s'old=>ne ignored
                    //iid to ignore, write, ma correct
                    if (CorrespondingCols_NsOfT1ForT2_New != -1)
                    {
                        if (CorrespondingLines_NsOfT1ForT2_New != -1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                        }
                        else if (CorrespondingLines_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                        }
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                {
                    //Lines new add, old ignore
                    //Cols new ignore, old replace
                    // 
                    if (CorrespondingLines_NsOfT1ForT2_New != -1)
                    {
                        if (CorrespondingCols_NsOfT1ForT2_New != -1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                        }
                        else if (CorrespondingCols_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                        }
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                {
                    //Lines new add, old ignore
                    //Cols new add, old ignore
                    //for added lines cells of old cols s'ne old, for added cols cells of old lines s'ne old
                    if (CorrespondingLines_NsOfT1ForT2_New != -1)
                    {
                        if (CorrespondingCols_NsOfT1ForT2_New != -1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                        }
                        else if (CorrespondingCols_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                        }
                    }
                    if (CorrespondingCols_NsOfT1ForT2_New != -1)
                    {
                        if (CorrespondingLines_NsOfT1ForT2_New != -1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                        }
                        else if (CorrespondingLines_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                        }
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                {
                    //Lines new add, old ignore
                    //Cols new add, old replace
                    //uz old both lines and cols conds contadict=> NOp
                    //if one row new, other written
                    if (CorrespondingLines_NsOfT1ForT2_New != -1)
                    {
                        if (CorrespondingCols_NsOfT1ForT2_New != -1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                        }
                        else if (CorrespondingCols_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                        }
                    }
                    if (CorrespondingCols_NsOfT1ForT2_New != -1)
                    {
                        if (CorrespondingLines_NsOfT1ForT2_New != -1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                        }
                        else if (CorrespondingLines_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                        }
                    }
                }
            }
            else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 1 && TablesConcatRules.LinesSame_Ignore0Replace1 == 1)
            {
                if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                {
                    //Lines new add old replace
                    //Cols add anyway
                    if (CorrespondingCols_NsOfT1ForT2_New != -1)
                    {
                        if (CorrespondingLines_NsOfT1ForT2_New != -1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                        }
                        else if (CorrespondingLines_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                        }
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                {
                    //Lines new add old replace
                    //Cols new ignore old ignore
                    //in new lines cells of old cols s'ne old=>write'd
                    if (CorrespondingCols_NsOfT1ForT2 != -1)
                    {
                        if (CorrespondingLines_NsOfT1ForT2_New != -1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                        }
                        else if (CorrespondingLines_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2);
                        }
                    }

                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                {
                    //Lines new add old replace
                    //Cols new ignore old replace
                    if (CorrespondingCols_NsOfT1ForT2 != -1)
                    {
                        if (CorrespondingLines_NsOfT1ForT2_New != -1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                        }
                        else if (CorrespondingLines_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2);
                        }
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                {
                    //Lines new add old replace
                    //Cols new add old ignore
                    //if old both - conds contradict => NOp;
                    //else write
                    if (CorrespondingCols_NsOfT1ForT2_New != -1)
                    {
                        if (CorrespondingLines_NsOfT1ForT2_New != -1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                        }
                        else if (CorrespondingLines_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                        }
                    }
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                {
                    //Lines new add old replace
                    //Cols new add, old replace
                    //write anyway
                    if (CorrespondingCols_NsOfT1ForT2_New != -1)
                    {
                        if (CorrespondingLines_NsOfT1ForT2_New != -1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                        }
                        else if (CorrespondingLines_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                        }
                    }
                    else if (CorrespondingCols_NsOfT1ForT2 != -1)
                    {
                        if (CorrespondingLines_NsOfT1ForT2_New != -1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                        }
                        else if (CorrespondingLines_NsOfT1ForT2 != 1)
                        {
                            this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2);
                        }
                    }
                }
            }
            //}
            //}
        }//fn add cell and add headers by rules - old vrn
        */
        public void AddCellToTable_WithHeaders_ByRules_WithSupplIniQRows(DataCell ccell, DataCell LineHeader, DataCell ColHeader, ref TableInfo_ConcrRepr TblInf1Actual, TableInfo_ConcrRepr TblInf1Ini, TableSize RowsNs, TTablesConcatRules TablesConcatRulesExt = null, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1, TValsShowHide vsh = null)
        {
            //
            // ha 2 tables: hic et ext
            // assign arrays of fitting Ns et NewNs as -1
            // uz je line of added table assign array of fitting Ns
            // uz je col of added table assign array of fitting Ns
            // if add lines anyway:
            //   add all lines
            //   write ir hdrs, if both orig and new ha em
            //   assign array of fitting New Ns 
            // if add cols anyway:
            //   add all lines
            //   write ir hdrs, if both orig and new ha em
            //   assign array of fitting New Ns 
            // if add nur new lines:
            //   uz je line o'new tbl: compar, et, if S'new:
            //     add
            //     write ir hdrs, if both orig and new ha em
            //     assign array of new Ns
            // if add new cols:
            //   uz je col o'new tbl: compar, et, if S'new:
            //     add
            //     write ir hdrs, if both orig and new ha em
            //     assign array of new Ns
            //   
            // Now write Comntent Cells to ones co default vals.
            //   if lines to add anyway, cols to add anyway:
            //     for(i=1...QLinesToAddMax, j=1...QColsToAddMax) Cell(NewN(i), NewN(j))=CellToAdd(i,j)
            //  if lines to add anyway, 
            //     if cols to add new, to ignore old :
            //       if col s'new:
            //          Cell(NewN(i), NewN(j))=CellToAdd(i,j)
            //        if col s'old:
            //          NOP
            //     if cols to add new, to replace old :
            //       if col s'new:
            //         Cell(NewN(i), NewN(j))=CellToAdd(i,j)
            //       if col s'old:
            //         Cell(NewN(i), N(j))=CellToAdd(i,j)
            //    if cols to ignore new, to ignore old :
            //       if col s'new:
            //          NOP
            //        if col s'old:
            //          Cell(NewN(i), N(j))=CellToAdd(i,j)
            //    if cols to ignore new, to replace old :
            //       if col s'new:
            //          NOP
            //        if col s'old:
            //          Cell(NewN(i), N(j))=CellToAdd(i,j)
            //          
            // so for other vrns uz lines
            //
            TableInfo_ConcrRepr TblInf1;//, TblInf2;
            TTablesConcatRules TablesConcatRules;
            //DataCell Hdr1 = null, Hdr2 = null, HdrL1, HdrC1;//, ccell, HdrL2, HdrC2;
            bool NeedAddLines, NeedAddColumns, HeadersAreSame;
            int CorrespondingLines_NsOfT1ForT2 = -1, CorrespondingCols_NsOfT1ForT2 = -1, CorrespondingLines_NsOfT1ForT2_New = -1, CorrespondingCols_NsOfT1ForT2_New = -1;
            int QLinesPrev, QColsPrev, QLines, QColumns;//, QLinesToAddMax, QColsToAddMax;
            TblInf1 = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInf1Actual);
            //TblInf2 = tbl2.Choose_TableInfo_StrSize_ByExtAndInner(TblInf2Ext);
            if (TablesConcatRulesExt != null) TablesConcatRules = TablesConcatRulesExt; else TablesConcatRules = new TTablesConcatRules();
            NeedAddLines = (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 1 || TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 0 || (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 1));
            NeedAddColumns = (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0 || (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1));
            QLinesPrev = TblInf1Ini.GetQLines();
            QColsPrev = TblInf1Ini.GetQColumns();
            QLines = TblInf1.GetQLines();
            QColumns = TblInf1.GetQColumns();
            //
            CorrespondingLines_NsOfT1ForT2 = CellIsEqualToLineHeaderCellN(LineHeader, TblInf1Ini, AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, RowsNs);
            CorrespondingLines_NsOfT1ForT2_New = CellIsEqualToLineHeaderCellN(LineHeader, TblInf1, AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, RowsNs);
            CorrespondingCols_NsOfT1ForT2 = CellIsEqualToColHeaderCellN(ColHeader, TblInf1Ini, AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, RowsNs);
            CorrespondingCols_NsOfT1ForT2_New = CellIsEqualToColHeaderCellN(ColHeader, TblInf1, AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, RowsNs);
            //
            if(CorrespondingLines_NsOfT1ForT2_New==-1){ //if this row is not added before to ini table
                if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 1 || TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 0) 
                {
                    //for (int i = 1; i <= QLinesToAddMax; i++)
                    //{
                    this.AddLine_TypesByExisting();
                    TblInf1.AddLine();
                    //this.ColOfLineHeader[QLinesPrev - 1] = Hdr2;
                    //CorrespondingLines_NsOfT1ForT2_New[i - 1] = QLinesPrev + i;
                    QLines=TblInf1.GetQLines();
                    if(this.ColOfLineHeader!=null)this.ColOfLineHeader[QLines - 1] = LineHeader;
                    CorrespondingLines_NsOfT1ForT2_New = QLines;
                    //}
                }
                else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 1)
                {
                    //CorrespondingLines_NsOfT1ForT2_New = new int[QLinesToAddMax];
                    //for (int i = 1; i <= QLinesToAddMax; i++)
                    //{
                    if (CorrespondingLines_NsOfT1ForT2 == -1)
                    {
                        //Hdr2 = (DataCell)tbl2.GetCell_ColOfLineHeader(i).Clone();
                        this.AddLine_TypesByExisting();
                        TblInf1.AddLine();
                        //this.ColOfLineHeader[QLinesPrev - 1] = Hdr2;
                        //CorrespondingLines_NsOfT1ForT2_New[i - 1] = TblInf1.GetQLines();
                        QLines=TblInf1.GetQLines();
                        if (this.ColOfLineHeader != null) this.ColOfLineHeader[QLines - 1] = LineHeader;
                        CorrespondingLines_NsOfT1ForT2_New = QLines;
                    }
                    //else CorrespondingLines_NsOfT1ForT2_New[i - 1] = CorrespondingLines_NsOfT1ForT2[i - 1];
                    //}//for
                }//else no need to add lines, so NOp
            }//else line is already added - its N is > re 
            //Cols
            if (CorrespondingCols_NsOfT1ForT2_New == -1)
            { //if this row is not added before to ini table
                if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                {
                    //for (int i = 1; i <= QColsToAddMax; i++)
                    //{
                    this.AddColumn_TypesByExisting();
                    TblInf1.AddColumn();
                    QColumns = TblInf1.GetQColumns();
                    //this.LineOfColHeader[QColsPrev - 1] = Hdr2;
                    if (this.LineOfColHeader != null) this.LineOfColHeader[QColumns - 1] = ColHeader;
                    CorrespondingCols_NsOfT1ForT2_New = QColumns;
                    //}
                }
                else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1)
                {
                    //CorrespondingCols_NsOfT1ForT2_New = new int[QColsToAddMax];
                    //for (int i = 1; i <= QColsToAddMax; i++)
                    //{
                    if (CorrespondingCols_NsOfT1ForT2 == -1)
                    {
                        this.AddColumn_TypesByExisting();
                        TblInf1.AddColumn();
                        QColumns = TblInf1.GetQColumns();
                        //this.LineOfColHeader[QColsPrev - 1] = Hdr2;
                        if (this.LineOfColHeader != null) this.LineOfColHeader[QColumns - 1] = ColHeader;
                        CorrespondingCols_NsOfT1ForT2_New = QColumns;
                    }
                        //else CorrespondingCols_NsOfT1ForT2_New[i - 1] = CorrespondingCols_NsOfT1ForT2[i - 1];
                    //}//for
                }//else no need to add col, so NOp
            }
            //CotentCells
            //for (int i = 1; i <= QLinesToAddMax; i++)
            //{
            //for (int j = 1; j <= QColsToAddMax; j++)
            //{
            //ccell = tbl2.GetCell(i, j, TblInf2);
                    //
                    if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 1 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                    {
                        if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                        {
                            //lines add anyway, cols add anyway
                            //cells to unique rows
                            if (CorrespondingLines_NsOfT1ForT2_New != -1 && CorrespondingCols_NsOfT1ForT2_New != -1)
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //lines add anyway, cols new ignore, old ignore
                            //cols are not added, in new lines - cells s':
                            //- of old cols s'ne old, so ne ignored, 
                            //- of new s'new, so ignored 
                            if (CorrespondingCols_NsOfT1ForT2 != -1)
                            { //old
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                            }//else NOp;
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //lines add anyway, cols new ignored, old - replaced
                            //in diff lines old cols s' ne old, so ne replaced, ma S'iid to replace in new lines, so write/
                            //new cols s'ignored=> ne add'd, ne exist
                            if (CorrespondingCols_NsOfT1ForT2 != -1)
                            { //old
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                            }//else NOp;
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //lines add anyway, cols new added, old - ignored
                            //in new lines cells of old cols s'ne old==> ne ignored
                            //so new cols to write to N, fit'n to new cols, and old - on Ns, fit'n to old
                            if (CorrespondingCols_NsOfT1ForT2_New != -1)
                            { //new
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                            }
                            else
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //lines add anyway, cols new added, old - ignored
                            //in new lines cells of old cols s'ne old, so - written
                            if (CorrespondingCols_NsOfT1ForT2_New != -1)
                            { //new
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                            }
                            else
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                            }
                        }
                    }
                    else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 0 && TablesConcatRules.LinesSame_Ignore0Replace1 == 0)
                    {
                        if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                        {
                            //Lines: new - ignored, same - ignored
                            //cols: add anyway
                            //in new cols cells of old lines s'ne old, so  ne ignored. No new cols, ob Z s'ignor'd et ne wa add'd
                            if (CorrespondingLines_NsOfT1ForT2 != -1)
                            { //old lines
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines: new - ignored, same - ignored
                            //Cols:  new - ignored, same - ignored
                            //no new rows added. Same rows ignored
                            //
                            //NOp;
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines: new - ignored, same - ignored
                            //Cols:  new - ignored, same - replaced
                            //no new rows added. 
                            //uz old rows conds uz lines et cols contradict?- bad cond - ignore
                            //
                            //NOp;
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines: new - ignored, same - ignored
                            //Cols:  new - add'd, same - ignored
                            //some cols s'added. uz hic cols same lines s'ne same=> ne ignor'd=>written
                            //so s'written cells of new cols and old lines
                            if (CorrespondingCols_NsOfT1ForT2_New!= 1 && CorrespondingLines_NsOfT1ForT2 != 1)
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines: new - ignored, same - ignored
                            //Cols:  new - add'd, same - to replace
                            //so write cells of new cols, if line s' old or new.
                            //if cell s'of old col - Contradict
                            if (CorrespondingCols_NsOfT1ForT2_New != 1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2_New != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                                }
                            }
                        }
                    }
                    else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 0 && TablesConcatRules.LinesSame_Ignore0Replace1 == 1)
                    {
                        if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                        {
                            //Lines new ignored, old replaced
                            //Cols added anyway
                            //so added cols and write cels of old lines
                            if (CorrespondingCols_NsOfT1ForT2 != 1 && CorrespondingLines_NsOfT1ForT2_New != 1)
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines new ignored, old replaced
                            //Cols new and old ignored
                            //so cells for old lines - conds W-contradict 
                            //NOp;
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines new ignored, old replaced
                            //Cols new ignored, old replaced
                            //replace nur old cells
                            if (CorrespondingCols_NsOfT1ForT2 != 1 && CorrespondingLines_NsOfT1ForT2 != 1)
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines new ignored, old replaced
                            //Cols add new, old ignore
                            if (CorrespondingCols_NsOfT1ForT2_New != 1 && CorrespondingLines_NsOfT1ForT2 != 1)
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines new ignored, old replaced
                            //Cols new add, old replace
                            if (CorrespondingLines_NsOfT1ForT2 != 1)
                            {
                                if (CorrespondingCols_NsOfT1ForT2_New != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                                }
                                else if (CorrespondingCols_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2);
                                }
                            }
                        }
                    }
                    else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 1 && TablesConcatRules.LinesSame_Ignore0Replace1 == 0)
                    {
                        if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                        {
                            //Lines new add, old ignore
                            //Cols add anyway
                            //cells of old lines in new lines ne s'old=>ne ignored
                            //iid to ignore, write, ma correct
                            if (CorrespondingCols_NsOfT1ForT2_New != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines new add, old ignore
                            //Cols add anyway
                            //cells of old lines in new lines ne s'old=>ne ignored
                            //iid to ignore, write, ma correct
                            if (CorrespondingCols_NsOfT1ForT2_New != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines new add, old ignore
                            //Cols new ignore, old replace
                            // 
                            if (CorrespondingLines_NsOfT1ForT2_New != -1)
                            {
                                if (CorrespondingCols_NsOfT1ForT2_New != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                                }
                                else if (CorrespondingCols_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines new add, old ignore
                            //Cols new add, old ignore
                            //for added lines cells of old cols s'ne old, for added cols cells of old lines s'ne old
                            if (CorrespondingLines_NsOfT1ForT2_New != -1)
                            {
                                if (CorrespondingCols_NsOfT1ForT2_New != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                                }
                                else if (CorrespondingCols_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                                }
                            }
                            if (CorrespondingCols_NsOfT1ForT2_New != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines new add, old ignore
                            //Cols new add, old replace
                            //uz old both lines and cols conds contadict=> NOp
                            //if one row new, other written
                            if (CorrespondingLines_NsOfT1ForT2_New != -1)
                            {
                                if (CorrespondingCols_NsOfT1ForT2_New != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                                }
                                else if (CorrespondingCols_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                                }
                            }
                            if (CorrespondingCols_NsOfT1ForT2_New != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                                }
                            }
                        }
                    }
                    else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 1 && TablesConcatRules.LinesSame_Ignore0Replace1 == 1)
                    {
                        if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                        {
                            //Lines new add old replace
                            //Cols add anyway
                            if (CorrespondingCols_NsOfT1ForT2_New != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines new add old replace
                            //Cols new ignore old ignore
                            //in new lines cells of old cols s'ne old=>write'd
                            if (CorrespondingCols_NsOfT1ForT2 != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2);
                                }
                            }

                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines new add old replace
                            //Cols new ignore old replace
                            if (CorrespondingCols_NsOfT1ForT2!= -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines new add old replace
                            //Cols new add old ignore
                            //if old both - conds contradict => NOp;
                            //else write
                            if (CorrespondingCols_NsOfT1ForT2_New != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines new add old replace
                            //Cols new add, old replace
                            //write anyway
                            if (CorrespondingCols_NsOfT1ForT2_New != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2_New);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2_New);
                                }
                            }
                            else if (CorrespondingCols_NsOfT1ForT2 != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New, CorrespondingCols_NsOfT1ForT2);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2 != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2, CorrespondingCols_NsOfT1ForT2);
                                }
                            }
                        }
                    }
               // }//for
            //}//for
        }//fn add cell
        //
        
        
        public void AddTableByRules(TTable tbl2, TableInfo_ConcrRepr TblInf1Ext = null, TableInfo_ConcrRepr TblInf2Ext = null, TTablesConcatRules TablesConcatRulesExt = null, int AreEqualBy_N0_Name1_ValAsDbl2Int3Bool4Str5_Full6 = 1)
        {
            //
            // ha 2 tables: hic et ext
            // assign arrays of fitting Ns et NewNs as -1
            // uz je line of added table assign array of fitting Ns
            // uz je col of added table assign array of fitting Ns
            // if add lines anyway:
            //   add all lines
            //   write ir hdrs, if both orig and new ha em
            //   assign array of fitting New Ns 
            // if add cols anyway:
            //   add all lines
            //   write ir hdrs, if both orig and new ha em
            //   assign array of fitting New Ns 
            // if add nur new lines:
            //   uz je line o'new tbl: compar, et, if S'new:
            //     add
            //     write ir hdrs, if both orig and new ha em
            //     assign array of new Ns
            // if add new cols:
            //   uz je col o'new tbl: compar, et, if S'new:
            //     add
            //     write ir hdrs, if both orig and new ha em
            //     assign array of new Ns
            //   
            // Now write Comntent Cells to ones co default vals.
            //   if lines to add anyway, cols to add anyway:
            //     for(i=1...QLinesToAddMax, j=1...QColsToAddMax) Cell(NewN(i), NewN(j))=CellToAdd(i,j)
            //  if lines to add anyway, 
            //     if cols to add new, to ignore old :
            //       if col s'new:
            //          Cell(NewN(i), NewN(j))=CellToAdd(i,j)
            //        if col s'old:
            //          NOP
            //     if cols to add new, to replace old :
            //       if col s'new:
            //         Cell(NewN(i), NewN(j))=CellToAdd(i,j)
            //       if col s'old:
            //         Cell(NewN(i), N(j))=CellToAdd(i,j)
            //    if cols to ignore new, to ignore old :
            //       if col s'new:
            //          NOP
            //        if col s'old:
            //          Cell(NewN(i), N(j))=CellToAdd(i,j)
            //    if cols to ignore new, to replace old :
            //       if col s'new:
            //          NOP
            //        if col s'old:
            //          Cell(NewN(i), N(j))=CellToAdd(i,j)
            //          
            // so for other vrns uz lines
            //
            TableInfo_ConcrRepr TblInf1, TblInf2;
            TTablesConcatRules TablesConcatRules;
            DataCell Hdr1 = null, Hdr2 = null, ccell, HdrL1, HdrC1, HdrL2, HdrC2;
            bool NeedAddLines, NeedAddColumns, HeadersAreSame;
            int[] CorrespondingLines_NsOfT1ForT2 = null, CorrespondingCols_NsOfT1ForT2 = null, CorrespondingLines_NsOfT1ForT2_New = null, CorrespondingCols_NsOfT1ForT2_New = null;
            int QLinesPrev, QColsPrev, QLinesToAddMax, QColsToAddMax;
            TblInf1 = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInf1Ext);
            TblInf2 = tbl2.Choose_TableInfo_StrSize_ByExtAndInner(TblInf2Ext);
            if (TablesConcatRulesExt != null) TablesConcatRules = TablesConcatRulesExt; else TablesConcatRules = new TTablesConcatRules();
            NeedAddLines = (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 1 || TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 0 || (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 1));
            NeedAddColumns = (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0 || (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1));
            QLinesPrev = TblInf1.GetQLines();
            QColsPrev = TblInf1.GetQColumns();
            QLinesToAddMax = TblInf2.GetQLines();
            QColsToAddMax = TblInf2.GetQColumns();
            //Fit'n Ns ef add rows
            CorrespondingLines_NsOfT1ForT2 = new int[QLinesToAddMax];
            for (int i = 1; i <= QLinesToAddMax; i++) CorrespondingLines_NsOfT1ForT2[i - 1] = -1;
            for (int i = 1; i <= QLinesToAddMax; i++)
            {
                CorrespondingLines_NsOfT1ForT2[i - 1] = -1;
                for (int j = 1; j <= QLinesPrev; j++)
                {
                    Hdr1 = (DataCell)this.ColOfLineHeader[j - 1].Clone();
                    Hdr2 = (DataCell)tbl2.GetCell_ColOfLineHeader(i).Clone();
                    HeadersAreSame = MyLib.fCellsAreEqual(Hdr1, Hdr2, AreEqualBy_N0_Name1_ValAsDbl2Int3Bool4Str5_Full6, new TableSize(QLinesPrev, QColsPrev), new TableSize(QLinesToAddMax, QColsToAddMax));
                    if (HeadersAreSame)
                    {
                        CorrespondingLines_NsOfT1ForT2[i - 1] = j;
                    }
                }//for
            }//for
            CorrespondingCols_NsOfT1ForT2 = new int[QColsToAddMax];
            for (int i = 1; i <= QColsToAddMax; i++) CorrespondingCols_NsOfT1ForT2[i - 1] = -1;
            for (int i = 1; i <= QColsToAddMax; i++)
            {
                CorrespondingCols_NsOfT1ForT2[i - 1] = -1;
                for (int j = 1; j <= QColsPrev; j++)
                {
                    Hdr1 = (DataCell)this.ColOfLineHeader[j - 1].Clone();
                    Hdr2 = (DataCell)tbl2.GetCell_ColOfLineHeader(i).Clone();
                    HeadersAreSame = MyLib.fCellsAreEqual(Hdr1, Hdr2, AreEqualBy_N0_Name1_ValAsDbl2Int3Bool4Str5_Full6, new TableSize(TblInf1.GetQLines(), TblInf1.GetQColumns()), new TableSize(TblInf2.GetQLines(), TblInf2.GetQColumns()));
                    if (HeadersAreSame)
                    {
                        CorrespondingCols_NsOfT1ForT2[i - 1] = j;
                    }
                }//for
            }//for
            //Add rows
            //Lines
            if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 1 || TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 0)
            {
                for (int i = 1; i <= QLinesToAddMax; i++)
                {
                    this.AddLine_TypesByExisting();
                    TblInf1.AddLine();
                    this.ColOfLineHeader[QLinesPrev - 1] = Hdr2;
                    CorrespondingLines_NsOfT1ForT2_New[i - 1] = QLinesPrev + i;
                }
            }
            else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 1)
            {
                //CorrespondingLines_NsOfT1ForT2_New = new int[QLinesToAddMax];
                for (int i = 1; i <= QLinesToAddMax; i++)
                {
                    if (CorrespondingLines_NsOfT1ForT2[i - 1] == -1)
                    {
                        Hdr2 = (DataCell)tbl2.GetCell_ColOfLineHeader(i).Clone();
                        this.AddLine_TypesByExisting();
                        TblInf1.AddLine();
                        this.ColOfLineHeader[QLinesPrev - 1] = Hdr2;
                        CorrespondingLines_NsOfT1ForT2_New[i - 1] = TblInf1.GetQLines();
                    }
                    else CorrespondingLines_NsOfT1ForT2_New[i - 1] = CorrespondingLines_NsOfT1ForT2[i - 1];
                }//for
            }//else no need to add lines, so NOp
            //Cols
            if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
            {
                for (int i = 1; i <= QColsToAddMax; i++)
                {
                    this.AddColumn_TypesByExisting();
                    TblInf1.AddColumn();
                    this.LineOfColHeader[QColsPrev - 1] = Hdr2;
                    CorrespondingCols_NsOfT1ForT2_New[i - 1] = TblInf1.GetQColumns();
                }
            }
            else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1)
            {
                //CorrespondingCols_NsOfT1ForT2_New = new int[QColsToAddMax];
                for (int i = 1; i <= QColsToAddMax; i++)
                {
                    if (CorrespondingCols_NsOfT1ForT2[i - 1] == -1)
                    {
                        Hdr2 = (DataCell)tbl2.GetCell_LineOfColHeader(i).Clone();
                        this.AddColumn_TypesByExisting();
                        TblInf1.AddColumn();
                        this.LineOfColHeader[QLinesPrev - 1] = Hdr2;
                        CorrespondingCols_NsOfT1ForT2_New[i - 1] = TblInf1.GetQColumns();
                    }
                    //else CorrespondingCols_NsOfT1ForT2_New[i - 1] = CorrespondingCols_NsOfT1ForT2[i - 1];
                }//for
            }//else no need to add col, so NOp
            //CotentCells
            for (int i = 1; i <= QLinesToAddMax; i++)
            {
                for (int j = 1; j <= QColsToAddMax; j++)
                {
                    ccell = tbl2.GetCell(i, j, TblInf2);
                    //
                    if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 1 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                    {
                        if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                        {
                            //lines add anyway, cols add anyway
                            //cells to unique rows
                            if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1 && CorrespondingCols_NsOfT1ForT2_New[j - 1] != -1)
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //lines add anyway, cols new ignore, old ignore
                            //cols are not added, in new lines - cells s':
                            //- of old cols s'ne old, so ne ignored, 
                            //- of new s'new, so ignored 
                            if (CorrespondingCols_NsOfT1ForT2[j - 1] != -1)
                            { //old
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                            }//else NOp;
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //lines add anyway, cols new ignored, old - replaced
                            //in diff lines old cols s' ne old, so ne replaced, ma S'iid to replace in new lines, so write/
                            //new cols s'ignored=> ne add'd, ne exist
                            if (CorrespondingCols_NsOfT1ForT2[j - 1] != -1)
                            { //old
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                            }//else NOp;
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //lines add anyway, cols new added, old - ignored
                            //in new lines cells of old cols s'ne old==> ne ignored
                            //so new cols to write to N, fit'n to new cols, and old - on Ns, fit'n to old
                            if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != -1)
                            { //new
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                            }
                            else
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //lines add anyway, cols new added, old - ignored
                            //in new lines cells of old cols s'ne old, so - written
                            if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != -1)
                            { //new
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                            }
                            else
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                            }
                        }
                    }
                    else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 0 && TablesConcatRules.LinesSame_Ignore0Replace1 == 0)
                    {
                        if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                        {
                            //Lines: new - ignored, same - ignored
                            //cols: add anyway
                            //in new cols cells of old lines s'ne old, so  ne ignored. No new cols, ob Z s'ignor'd et ne wa add'd
                            if (CorrespondingLines_NsOfT1ForT2[i - 1] != -1)
                            { //old lines
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines: new - ignored, same - ignored
                            //Cols:  new - ignored, same - ignored
                            //no new rows added. Same rows ignored
                            //
                            //NOp;
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines: new - ignored, same - ignored
                            //Cols:  new - ignored, same - replaced
                            //no new rows added. 
                            //uz old rows conds uz lines et cols contradict?- bad cond - ignore
                            //
                            //NOp;
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines: new - ignored, same - ignored
                            //Cols:  new - add'd, same - ignored
                            //some cols s'added. uz hic cols same lines s'ne same=> ne ignor'd=>written
                            //so s'written cells of new cols and old lines
                            if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != 1 && CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines: new - ignored, same - ignored
                            //Cols:  new - add'd, same - to replace
                            //so write cells of new cols, if line s' old or new.
                            //if cell s'of old col - Contradict
                            if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != 1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                            }
                        }
                    }
                    else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 0 && TablesConcatRules.LinesSame_Ignore0Replace1 == 1)
                    {
                        if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                        {
                            //Lines new ignored, old replaced
                            //Cols added anyway
                            //so added cols and write cels of old lines
                            if (CorrespondingCols_NsOfT1ForT2[j - 1] != 1 && CorrespondingLines_NsOfT1ForT2_New[i - 1] != 1)
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines new ignored, old replaced
                            //Cols new and old ignored
                            //so cells for old lines - conds W-contradict 
                            //NOp;
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines new ignored, old replaced
                            //Cols new ignored, old replaced
                            //replace nur old cells
                            if (CorrespondingCols_NsOfT1ForT2[j - 1] != 1 && CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines new ignored, old replaced
                            //Cols add new, old ignore
                            if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != 1 && CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                            {
                                this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines new ignored, old replaced
                            //Cols new add, old replace
                            if (CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                            {
                                if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                                else if (CorrespondingCols_NsOfT1ForT2[j - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                                }
                            }
                        }
                    }
                    else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 1 && TablesConcatRules.LinesSame_Ignore0Replace1 == 0)
                    {
                        if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                        {
                            //Lines new add, old ignore
                            //Cols add anyway
                            //cells of old lines in new lines ne s'old=>ne ignored
                            //iid to ignore, write, ma correct
                            if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines new add, old ignore
                            //Cols add anyway
                            //cells of old lines in new lines ne s'old=>ne ignored
                            //iid to ignore, write, ma correct
                            if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines new add, old ignore
                            //Cols new ignore, old replace
                            // 
                            if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1)
                            {
                                if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                                else if (CorrespondingCols_NsOfT1ForT2[j - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines new add, old ignore
                            //Cols new add, old ignore
                            //for added lines cells of old cols s'ne old, for added cols cells of old lines s'ne old
                            if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1)
                            {
                                if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                                else if (CorrespondingCols_NsOfT1ForT2[j - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                                }
                            }
                            if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines new add, old ignore
                            //Cols new add, old replace
                            //uz old both lines and cols conds contadict=> NOp
                            //if one row new, other written
                            if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1)
                            {
                                if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                                else if (CorrespondingCols_NsOfT1ForT2[j - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                                }
                            }
                            if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                            }
                        }
                    }
                    else if (TablesConcatRules.LinesElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.LinesDifferent_Ignore0Add1 == 1 && TablesConcatRules.LinesSame_Ignore0Replace1 == 1)
                    {
                        if (TablesConcatRules.DirectAdd_Vert1Hor2VertTransp3Smart4 == 2 || TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 0)
                        {
                            //Lines new add old replace
                            //Cols add anyway
                            if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines new add old replace
                            //Cols new ignore old ignore
                            //in new lines cells of old cols s'ne old=>write'd
                            if (CorrespondingCols_NsOfT1ForT2[j - 1] != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                                }
                            }

                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 0 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines new add old replace
                            //Cols new ignore old replace
                            if (CorrespondingCols_NsOfT1ForT2[j - 1] != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 0)
                        {
                            //Lines new add old replace
                            //Cols new add old ignore
                            //if old both - conds contradict => NOp;
                            //else write
                            if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                            }
                        }
                        else if (TablesConcatRules.ColsElabRules_Add0DependsOnCompar1 == 1 && TablesConcatRules.ColsDifferent_Ignore0Add1 == 1 && TablesConcatRules.ColsSame_Ignore0Replace1 == 1)
                        {
                            //Lines new add old replace
                            //Cols new add, old replace
                            //write anyway
                            if (CorrespondingCols_NsOfT1ForT2_New[j - 1] != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2_New[j - 1]);
                                }
                            }
                            else if (CorrespondingCols_NsOfT1ForT2[j - 1] != -1)
                            {
                                if (CorrespondingLines_NsOfT1ForT2_New[i - 1] != -1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2_New[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                                }
                                else if (CorrespondingLines_NsOfT1ForT2[i - 1] != 1)
                                {
                                    this.AssignCell(ccell, CorrespondingLines_NsOfT1ForT2[i - 1], CorrespondingCols_NsOfT1ForT2[j - 1]);
                                }
                            }
                        }
                    }
                }
            }
        }//fn
        /*public void CellAddSmartFromSingle(DataCell ContentCell, DataCell ColHeader, DataCell LineHeader, TableInfo_ConcrRepr TblInfExt = null, int NeededLinesSort = 0, int NeededColumnsSort = 0, int EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9 = 1)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            bool NeedAddLine, NeedAddColumn;
            int QLines = TblInf.GetQLines(), QColumns = TblInf.GetQColumns();
            int LineN = 0, ColN = 0;
            LineN = LineHeaderCellNIsEqualToCell(LineHeader, TblInf, EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9);
            ColN = ColHeaderCellNIsEqualToCell(ColHeader, TblInf, EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9);
            if (LineN == 0) NeedAddLine = false; else NeedAddLine = true;
            if (ColN == 0) NeedAddColumn = false; else NeedAddColumn = true;
            //QLines = TblInf.GetQLines(); QColumns = TblInf.GetQColumns();
            if (NeedAddLine)
            {
                this.AddLine_TypesByExisting();
                TblInf.AddLine();
                LineN = TblInf.GetQLines();
                if(ColOfLineHeader!=null)ColOfLineHeader[LineN - 1].SetByValString(LineHeader.ToString());
            }//else NOp, LineN s'def'd
            if (NeedAddColumn)
            {
                this.AddColumn_TypesByExisting();
                TblInf.AddColumn();
                ColN = TblInf.GetQColumns();
                if (LineOfColHeader != null) LineOfColHeader[ColN - 1].SetByValString(ColHeader.ToString());
            }//else NOp, ColN s'def'd
            this.ContentCell[LineN - 1][ColN - 1] = ContentCell;
        }*/
        /*
        public void CellAddSmartFromSingle(DataCell ContentCell, DataCell ColHeader, DataCell LineHeader, TableInfo_ConcrRepr TblInfExt = null, int CellsWithNewHeaders_Ignore0Add1 = 1, int CellsWithExistingHeaders_Leave0Replace1 = 1, int NeededLinesSort = 0, int NeededColumnsSort = 0, int EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9 = 1)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            bool NeedAddLine, NeedAddColumn;
            int QLines = TblInf.GetQLines(), QColumns = TblInf.GetQColumns();
            int LineN = 0, ColN = 0;
            LineN = LineHeaderCellNIsEqualToCell(LineHeader, TblInf, EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9);
            ColN = ColHeaderCellNIsEqualToCell(ColHeader, TblInf, EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9);
            if (LineN == 0 && CellsWithNewHeaders_Ignore0Add1 == 1) NeedAddLine = true; else NeedAddLine = false;
            if (ColN == 0 && CellsWithNewHeaders_Ignore0Add1 == 1) NeedAddColumn = true; else NeedAddColumn = false;
            //QLines = TblInf.GetQLines(); QColumns = TblInf.GetQColumns();
            if (NeedAddLine)
            {
                this.AddLine_TypesByExisting();
                TblInf.AddLine();
                //LineN = TblInf.GetQLines();
                //if (ColOfLineHeader != null) ColOfLineHeader[LineN - 1].SetByValString(LineHeader.ToString());
                if (ColOfLineHeader != null) ColOfLineHeader[LineN - 1].Assign(LineHeader);
            }//else NOp, LineN s'def'd
            if (NeedAddColumn)
            {
                this.AddColumn_TypesByExisting();
                TblInf.AddColumn();
                //ColN = TblInf.GetQColumns();
                //if (LineOfColHeader != null) LineOfColHeader[ColN - 1].SetByValString(ColHeader.ToString());
                if (LineOfColHeader != null) LineOfColHeader[ColN - 1].Assign(ColHeader);
            }//else NOp, ColN s'def'd
            if (((LineN == 0 || ColN == 0) && CellsWithNewHeaders_Ignore0Add1 == 1)
                ||
                    (LineN != 0 && ColN != 0 && CellsWithExistingHeaders_Leave0Replace1 == 1)
                )
            {
                if (LineN == 0) LineN = TblInf.GetQLines();
                if (ColN == 0) LineN = TblInf.GetQColumns();
                this.ContentCell[LineN - 1][ColN - 1] = ContentCell;
            }
        }
        */
        /*public void AddTableSmart(TTable TblAdded, TableInfo_ConcrRepr TblInfThisExt = null, TableInfo_ConcrRepr TblInfAddedExt = null, int EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9 = 1)
        {
            DataCell CC_Added, LH_Added, CH_Added;
            TableInfo_ConcrRepr TblInfThis, TblInfAdded=null;
            int QAddedLines, QAddedColumns;
            TblInfThis = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfThisExt);
            TblInfAdded = TblAdded.Choose_TableInfo_StrSize_ByExtAndInner(TblInfAddedExt);
            if (TblAdded != null)
            {
                QAddedLines = TblInfAdded.GetQLines();
                QAddedColumns = TblInfAdded.GetQColumns();
                for (int i = 1; i <= QAddedLines; i++)
                {
                    for (int j = 1; j <= QAddedColumns; j++)
                    {
                        CC_Added=TblAdded.GetCell(i,j,TblInfAdded);
                        LH_Added=TblAdded.GetCell_ColOfLineHeader(i,TblInfAdded);
                        CH_Added=TblAdded.GetCell_LineOfColHeader(j,TblInfAdded);
                        this.CellAddSmartFromSingle(CC_Added, CH_Added, LH_Added, TblInfAdded, EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9);
                    }
                }
            }
        }//fn
         */
        /*
        public void AddTableSmart(TTable TblAdded, TableInfo_ConcrRepr TblInfThisExt = null, TableInfo_ConcrRepr TblInfAddedExt = null, int CellsWithNewHeaders_Ignore0Add1 = 1, int CellsWithExistingHeaders_Leave0Replace1 = 1, int EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9 = 1)
        {
            DataCell CC_Added, LH_Added, CH_Added;
            TableInfo_ConcrRepr TblInfThis, TblInfAdded = null;
            int QAddedLines, QAddedColumns;
            TblInfThis = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfThisExt);
            TblInfAdded = TblAdded.Choose_TableInfo_StrSize_ByExtAndInner(TblInfAddedExt);
            if (TblAdded != null)
            {
                QAddedLines = TblInfAdded.GetQLines();
                QAddedColumns = TblInfAdded.GetQColumns();
                for (int i = 1; i <= QAddedLines; i++)
                {
                    for (int j = 1; j <= QAddedColumns; j++)
                    {
                        CC_Added = TblAdded.GetCell(i, j, TblInfAdded);
                        LH_Added = TblAdded.GetCell_ColOfLineHeader(i, TblInfAdded);
                        CH_Added = TblAdded.GetCell_LineOfColHeader(j, TblInfAdded);
                        this.CellAddSmartFromSingle(CC_Added, CH_Added, LH_Added, TblInfAdded, CellsWithNewHeaders_Ignore0Add1, CellsWithExistingHeaders_Leave0Replace1, EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9);
                    }
                }
            }
        }//fn
        public TTable AddTableSmartTo(TTable TblAdded, TableInfo_ConcrRepr TblInfThisExt = null, TableInfo_ConcrRepr TblInfAddedExt = null, int EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9 = 1)
        {
            TTable TR = (TTable)this.Clone();
            DataCell CC_Added, LH_Added, CH_Added;
            TableInfo_ConcrRepr TblInfThis, TblInfAdded = null;
            int QAddedLines, QAddedColumns;
            TblInfThis = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfThisExt);
            TblInfAdded = TblAdded.Choose_TableInfo_StrSize_ByExtAndInner(TblInfAddedExt);
            if (TblAdded != null)
            {
                QAddedLines = TblInfAdded.GetQLines();
                QAddedColumns = TblInfAdded.GetQColumns();
                for (int i = 1; i <= QAddedLines; i++)
                {
                    for (int j = 1; j <= QAddedColumns; j++)
                    {
                        CC_Added = TblAdded.GetCell(i, j, TblInfAdded);
                        LH_Added = TblAdded.GetCell_ColOfLineHeader(i, TblInfAdded);
                        CH_Added = TblAdded.GetCell_LineOfColHeader(j, TblInfAdded);
                        TR.CellAddSmartFromSingle(CC_Added, CH_Added, LH_Added, TblInfAdded, EqualIfFit_Names_1or2or3_TwoNames4_ThreeNames5_ActiveN6_TypeAndLength7_TypeAndContent8_Fully9);
                    }
                }
            }
            return TR;
        }//fn
        */
        //
        public void AddTableSelectiveByColumnsNames(TTable T2, TableInfo TblInfExt1 = null, TableInfo TblInfExt2 = null, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1)
        {
            DataCell HdrCell;//=null;
            int QColumns, QColumnsInAddedSource, QAddedColumns, QLinesOld, QAddedLines, QLinesNew, IniTblColN, n = 0, CurTypeN1, CurTypeN2;
            int[] ColNAdded = null, ColToAppend = null;
            TableInfo TblInf1 = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt1), TblInf2 = T2.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt2);
            QColumns = TblInf1.GetQColumns();
            QColumnsInAddedSource = TblInf2.GetQColumns();
            QLinesOld = TblInf1.GetQLines();
            QAddedLines = TblInf2.GetQLines();
            QLinesNew = QLinesOld + QAddedLines;
            QAddedColumns = 0;
            for (int i = 1; i <= QColumnsInAddedSource; i++)
            {
                HdrCell = T2.GetCell_LineOfColHeader(i);
                IniTblColN = this.CellIsEqualToColHeaderCellN(HdrCell, TblInf1.GetTableInfo_ConcrRepr(), AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13);
                if (IniTblColN != 0)
                {
                    QAddedColumns++;
                    if (QAddedColumns == 1)
                    {
                        ColToAppend = new int[1];
                        ColToAppend[1 - 1] = IniTblColN;
                        ColNAdded = new int[1];
                        ColNAdded[1 - 1] = i;
                    }
                    else
                    {
                        n = QAddedColumns - 1;
                        n = ColToAppend.Length;
                        MyLib.AddToVector<int>(ref ColToAppend, ref n, IniTblColN);
                        n = QAddedColumns - 1;
                        n = ColNAdded.Length;
                        MyLib.AddToVector<int>(ref ColNAdded, ref n, i);
                    }//if
                }//if
            }//for
            QAddedColumns = n;
            for (int i = 1; i <= QAddedLines; i++)
            {
                this.AddEmptyLine_TypesByExisting(TblInf1);
                for (int j = 1; j <= QAddedColumns; j++)
                {
                    //so was
                    //SetDataCellByDataCell(T2.GetCell(i, ColNAdded[j - 1], TblInf2.GetTableInfo_ConcrRepr()), QLinesOld + i, ColToAppend[j - 1], TblInf1);
                    //SetDataCellByDataCell(T2.GetCell(i, ColNAdded[j - 1], TblInf2.GetTableInfo_ConcrRepr()), QLinesOld + i, ColToAppend[j - 1], TblInf1);
                    //so is
                    this.AssignCell(T2.GetCell(i, ColNAdded[j - 1], TblInf2.GetTableInfo_ConcrRepr()), QLinesOld + i, ColToAppend[j - 1], TblInf1);
                }
            }
        }//fn
        public TTable AddTableSelectiveByColumnsNamesTo(TTable T1, TTable T2, TableInfo TblInfExt1 = null, TableInfo TblInfExt2 = null, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1)
        {
            TTable TR = (TTable)this.Clone();
            DataCell HdrCell;//=null;
            int QColumns, QColumnsInAddedSource, QAddedColumns, QLinesOld, QAddedLines, QLinesNew, IniTblColN, n = 0, CurTypeN1, CurTypeN2;
            int[] ColNAdded = null, ColToAppend = null;
            TableInfo TblInf1 = T1.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt1), TblInf2 = T2.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt2);
            QColumns = TblInf1.GetQColumns();
            QColumnsInAddedSource = TblInf2.GetQColumns();
            QLinesOld = TblInf1.GetQLines();
            QAddedLines = TblInf2.GetQLines();
            QLinesNew = QLinesOld + QAddedLines;
            QAddedColumns = 0;
            for (int i = 1; i <= QColumnsInAddedSource; i++)
            {
                HdrCell = T2.GetCell_LineOfColHeader(i);
                IniTblColN = TR.CellIsEqualToColHeaderCellN(HdrCell, TblInf1.GetTableInfo_ConcrRepr(), AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13);
                if (IniTblColN != 0)
                {
                    QAddedColumns++;
                    if (QAddedColumns == 1)
                    {
                        ColToAppend = new int[1];
                        ColToAppend[1 - 1] = IniTblColN;
                        ColNAdded = new int[1];
                        ColNAdded[1 - 1] = i;
                    }
                    else
                    {
                        n = QAddedColumns - 1;
                        n = ColToAppend.Length;
                        MyLib.AddToVector<int>(ref ColToAppend, ref n, IniTblColN);
                        n = QAddedColumns - 1;
                        n = ColNAdded.Length;
                        MyLib.AddToVector<int>(ref ColNAdded, ref n, i);
                    }//if
                }//if
            }//for
            QAddedColumns = n;
            for (int i = 1; i <= QAddedLines; i++)
            {
                TR.AddEmptyLine_TypesByExisting(TblInf1);
                for (int j = 1; j <= QAddedColumns; j++)
                {
                   //SetDataCellByDataCell(T2.GetCell(i, ColNAdded[j - 1], TblInf2.GetTableInfo_ConcrRepr()), QLinesOld + i, ColToAppend[j - 1], TblInf1);
                    this.AssignCell(T2.GetCell(i, ColNAdded[j - 1], TblInf2.GetTableInfo_ConcrRepr()), QLinesOld + i, ColToAppend[j - 1], TblInf1);
                }
            }
            return TR;
        }//fn
        
        DataTable GetAsSystemDataTable(TableInfo/*TableInfo_ConcrRepr*/ ParamsExt)
        {
            DataTable R=null;
            TableInfo/*_ConcrRepr*/ Inf=this.Choose_TableInfo_StrSize_ByExtAndInner(ParamsExt);
            DataCellRowCoHeader CurTblCol;
            int QLines=Inf.GetQLines(), QColumns=Inf.GetQColumns();
            DataColumn[] DataCol = new DataColumn[QColumns];
            string s;
            //string[] items, names;
            for (int i = 1; i <= QColumns; i++)
            {
                DataCol[i-1]=new DataColumn();
                CurTblCol=this.GetColumnWithHeaderN(i, Inf);
                DataCol[i-1].Caption=(CurTblCol.GetHeader()).ToStringN(2);
                for(int j=1;  j<=QLines; j++){
                //s=CurTblCol
                //DataCol.Container.
                    s = this.ToString(j, i, Inf.GetTableInfo_ConcrRepr());
                    //DataCol.Container.
                    //DataCol.Container.Add(s);
                    //DataCol.Container.Add(this.ToString(j, i, Inf));

                }
                //R.Columns.Add(DataCol);
            }
            return R;
        }//fn
        void SetFromSystemDataTable(DataTable TSrc, int[]FldTypes=null){
            int QLines = TSrc.Rows.Count, QColumns = TSrc.Columns.Count;
            string[] sa = new string[QColumns], ColNames = new string[QColumns];
            for(int i=1; i<=QColumns; i++){
                ColNames[i - 1] = TSrc.Columns[i - 1].Caption;
            }
            //
            this.ContentCell = new DataCell[QLines][];
            for (int i = 1; i <= QLines; i++)
            {
                this.ContentCell[i - 1] = new DataCell[QColumns];
            }
            for (int i = 1; i <= QLines; i++)
            {
                for (int j = 1; j <= QColumns; j++)
                {
                    sa[j - 1] = TSrc.Rows[i - 1][ColNames[j - 1]].ToString();
                    if (FldTypes == null || FldTypes[j - 1] == TableConsts.StringTypeN)
                    {
                        this.ContentCell[i - 1][j - 1] = new DataCell(sa[i - 1]);
                    }
                    else
                    {
                        switch (FldTypes[j - 1])
                        {
                            case TableConsts.DoubleTypeN:
                                this.ContentCell[i - 1][j - 1] = new DataCell(Convert.ToDouble(sa[j - 1]));
                                break;
                            //case TableConsts.FloatTypeN:
                            //    this.ContentCell[i - 1][j - 1] = new DataCell(Convert.ToF(sa[i - 1])); //onvert.ToFloat() ne exists
                            //    break;
                            case TableConsts.IntTypeN:
                                this.ContentCell[i - 1][j - 1] = new DataCell(Convert.ToInt32(sa[j - 1]));
                                break;
                        }//switch
                    }//if TypeN
                }
                //
                
            }
            this.ColOfLineHeader = null;
            this.LineOfColHeader = new DataCell[QColumns];
            for (int i = 1; i <= QColumns; i++)
            {
                this.LineOfColHeader[i - 1] = new DataCell(ColNames[i - 1]);
            }
            this.Headers = new TableHeaders(new DataCell(TSrc.TableName), null, null);
        }//fn
        TTable ReturnFromSystemDataTable(DataTable TSrc, int[] FldTypes = null)
        {
            TTable tbl = null;
            DataCellRowCoHeader RowHeadered;
            //
            int QLines = TSrc.Rows.Count, QColumns = TSrc.Columns.Count;
            string[] sa = new string[QColumns], ColNames = new string[QColumns];
            for (int i = 1; i <= QColumns; i++)
            {
                ColNames[i - 1] = TSrc.Columns[i - 1].Caption;
            }
            DataCellRow ColOfLineHeader = null, LineOfColHeader = new DataCellRow(sa, QColumns);//, CurLineRow;
            DataCell[] contentCells = new DataCell[QColumns];
            DataCellRow[] contentRow = new DataCellRow[1];
            LineOfColHeader = new DataCellRow(ColNames, QColumns);
            for (int i = 1; i <= QLines; i++)
            {
                for (int j = 1; j <= QColumns; j++)
                {
                    sa[j - 1] = TSrc.Rows[i - 1][ColNames[j - 1]].ToString();
                    if (FldTypes == null || FldTypes[j - 1] == TableConsts.StringTypeN)
                    {
                        contentCells[j - 1] = new DataCell(sa[j - 1]);
                    }
                    else
                    {
                        switch (FldTypes[j - 1])
                        {
                            case TableConsts.DoubleTypeN:
                                contentCells[j - 1] = new DataCell(Convert.ToDouble(sa[j - 1]));
                                break;
                            //case TableConsts.FloatTypeN:
                            //    this.ContentCell[i - 1][j - 1] = new DataCell(Convert.ToF(sa[i - 1])); //onvert.ToFloat() ne exists
                            //    break;
                            case TableConsts.IntTypeN:
                                contentCells[j - 1] = new DataCell(Convert.ToInt32(sa[j - 1]));
                                break;
                        }//switch
                    }//if TypeN
                }//for ColN
                contentRow[1 - 1] = new DataCellRow(contentCells, QColumns);
                //CurLineRow = contentRow[1 - 1];
                if (i == 1)
                {
                    tbl = new TTable(
                          new TableInfo(true, false, true, 1, QColumns),
                          false, contentRow, LineOfColHeader, ColOfLineHeader,
                          new TableHeaders(new DataCell("Table"), new DataCell("N"), new DataCell("Data")),
                          true
                          );

                }
                else if (i > 1)
                {
                    RowHeadered = new DataCellRowCoHeader(null, contentRow[1 - 1]);
                    tbl.AddLine(RowHeadered);
                }
            }
            return tbl;
        }//fn
        //
        public void SetDBColHeaders(TableInfo_ConcrRepr InfExt=null)
        {
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSize_ByExtAndInner(InfExt);
            int QColumns = Inf.GetQColumns();
            if (this.LineOfColHeader == null)
            {
                this.LineOfColHeader = new DataCell[QColumns];
            }
            for(int i=1; i<=QColumns; i++){
                if (this.LineOfColHeader[i - 1].GetTypeN() != TableConsts.ColHeaderDBFieldOrItemsTypeN)
                {
                    this.LineOfColHeader[i - 1].SetCellAsDBItemsFieldHeader();
                }
            }
        }
        //
        //Set of DB functions
        //
        // DB Table data
        //
        //1 Имя таблицы отображаемое TableNameToDisplay
        public string GetDBTableNameToDisplay()
        {
            DataCell cell = new DataCell();
            if (this.Headers != null && this.Headers.TableHeader != null)
            {
                cell = this.Headers.TableHeader;
            }
            return cell.GetDBTableNameToDisplay();
        }
        public void SetDBTableNameToDisplay(string name) {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                this.Headers.TableHeader = new DataCell();
            }
            this.Headers.TableHeader.SetCellAsDBTableHeader();
            this.Headers.TableHeader.SetDBTableNameToDisplay(name);
        }
        //2 Тип БД BType
        public int GetDBTypeN() {
            DataCell cell = new DataCell();
            if (this.Headers != null && this.Headers.TableHeader != null)
            {
                cell = this.Headers.TableHeader;
            }
            return cell.GetDBTypeN();
        }
        public void SetDBTypeN(int TypeN) {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                this.Headers.TableHeader = new DataCell();
            }
            this.Headers.TableHeader.SetCellAsDBTableHeader();
            this.Headers.TableHeader.SetDBTypeN(TypeN);
        }
        public string GetDBConnectionString() {
            DataCell cell = new DataCell();
            if (this.Headers != null && this.Headers.TableHeader != null)
            {
                this.Headers = new TableHeaders();
                this.Headers.TableHeader = new DataCell();
            }
            return GetDBConnectionString();
        }
        //public override void SetDBConnectiobString(string ConnStr){}
        //3 Путь к БД DBFileFullName
        public string GetDBFileFullName() {
            DataCell cell = new DataCell();
            if (this.Headers != null && this.Headers.TableHeader != null)
            {
                this.Headers = new TableHeaders();
                this.Headers.TableHeader = new DataCell();
            }
            return cell.GetDBFileFullName();
        }
        public void SetDBFileFullName(string name) {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                this.Headers.TableHeader = new DataCell();
            }
            this.Headers.TableHeader.SetCellAsDBTableHeader();
            this.Headers.TableHeader.SetDBFileFullName(name);
        }
        //4 Имя БД в списке СУБД DBNameInSDBC
        public string GetDBNameInSDBC() {
            DataCell cell = new DataCell();
            if (this.Headers != null && this.Headers.TableHeader != null)
            {
                cell = this.Headers.TableHeader;
            }
            return cell.GetDBNameInSDBC();
        }
        public void SetDBNameInSDBC(string name) {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                this.Headers.TableHeader = new DataCell();
            }
            this.Headers.TableHeader.SetCellAsDBTableHeader();
            this.Headers.TableHeader.SetDBNameInSDBC(name);
        }
        //5 Имя таблицы в БД
        public string GetDBTableNameInDB() {
            DataCell cell = new DataCell();
            if (this.Headers != null && this.Headers.TableHeader != null)
            {
                cell = this.Headers.TableHeader;
            }
            return cell.GetDBTableNameInDB();
        }
        public void SetDBTableNameInDB(string name) {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                this.Headers.TableHeader = new DataCell();
            }
            this.Headers.TableHeader.SetCellAsDBTableHeader();
            this.Headers.TableHeader.SetDBTableNameInDB(name);
        }
        //
        // DB field data
        //
        // for Col Headers (natural)
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public string GetDBFieldNameToDisplay(int ColN, TableInfo_ConcrRepr TblInfExt=null) {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[ColN-1];
            }
            return cell.GetDBFieldNameToDisplay();
        }
        public void SetDBFieldNameToDisplay(string name, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetDBFieldNameToDisplay(name);
        }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public string GetDBFieldNameInTable(int ColN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[ColN - 1];
            }
            return cell.GetDBFieldNameInTable();
        }
        public void SetDBFieldNameInTable(string name, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetDBFieldNameInTable(name);
        }
        //3 Название связанной таблицы пунктов DBTableNa meInDB
        public string GetItemsDBTableNameInDB(int ColN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[ColN - 1];
            }
            return cell.GetItemsDBTableNameInDB();
        }
        public void SetItemsDBTableNameInDB(string name, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetItemsDBTableNameInDB(name);
        }
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public string GetItemsDBTablePrimaryKeyFieldName(int ColN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[ColN - 1];
            }
            return cell.GetItemsDBTablePrimaryKeyFieldName();
        }
        public void SetItemsDBTablePrimaryKeyFieldName(string name, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetItemsDBTablePrimaryKeyFieldName(name);
        }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public string GetItemsDBTableItemsFieldName(int ColN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[ColN-1];
            }
            return cell.GetItemsDBTableItemsFieldName();
        }
        public void SetItemsDBTableItemsFieldName(string name, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetItemsDBTableItemsFieldName(name);
        }
        //6 Тип данных поля DB Field data type 
        public int GetDBFieldTypeN(int ColN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[ColN - 1];
            }
            return cell.GetDBFieldTypeN();
        }
        public void SetDBFieldTypeN(int TypeN, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetDBFieldTypeN(TypeN);
        }
        public string GetDBFieldTypeName(int ColN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[ColN - 1];
            }
            return cell.GetDBFieldTypeName();
        }
        public void SetDBFieldTypeName(string name, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetDBFieldTypeName(name);
        }
        //7 Длина поля Field Length (not the same as Array length)
        public int GetDBFieldLength(int ColN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[ColN - 1];
            }
            return cell.GetDBFieldLength();
        }
        public void SetDBFieldLength(int L, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetDBFieldLength(L);
        }
        //8 Длина списка пунктов и прочее
        public int GetItemsQuantity(int ColN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[ColN - 1];
            }
            return cell.GetItemsQuantity();
        }
        public void SetItems(string[] items, int Q, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetItems(items, Q);
        }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public int GetDBFieldCharacteristicsNumber(int ColN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[ColN - 1];
            }
            return cell.GetDBFieldCharacteristicsNumber();
        }
        public void SetDBFieldCharacteristicsNumber(int num, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetDBFieldCharacteristicsNumber(num);
        }
        public bool IsKeyField(int ColN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[ColN - 1];
            }
            return cell.IsKeyField();
        }
        public void SetIfKeyField(bool KeyField, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetIfKeyField(KeyField);
        }
        public void SetKeyField(int ColN, TableInfo_ConcrRepr TblInfExt = null) {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetKeyField();
        }
        public void SetNotKeyField(int ColN, TableInfo_ConcrRepr TblInfExt = null) {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetNotKeyField();
        }
        public bool IsCounter(int ColN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[ColN - 1];
            }
            return cell.IsCounter();
        }
        public void SetIfCounter(bool isCounter, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetIfCounter(isCounter);
        }
        public void SetCounter(int ColN, TableInfo_ConcrRepr TblInfExt = null) {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetCounter();
        }
        public void SetNotCounter(int ColN, TableInfo_ConcrRepr TblInfExt = null) {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetNotCounter();
        }
        public bool IsAutoIncrement(int ColN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[ColN - 1];
            }
            return cell.IsAutoIncrement();
        }
        public void SetIfAutoIncrement(bool isAutoIncrement, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetIfAutoIncrement(isAutoIncrement);
        }
        public void SetAutoIncrement(int ColN, TableInfo_ConcrRepr TblInfExt = null) {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetAutoIncrement();
        }
        public void SetNotAutoIncrement(int ColN, TableInfo_ConcrRepr TblInfExt = null) {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetNotAutoIncrement();
        }
        public void SetIfIsNotNull(bool isNotNull, int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetIfNotNull(isNotNull);
        }
        public void SetNotNull(int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetNotNull();
        }
        public void SetNotNotNull(int ColN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && ColN >= 1 && ColN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[ColN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[ColN - 1] = new DataCell();
                    this.LineOfColHeader[ColN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[ColN - 1].SetNotNotNull();
        }
        //
        // for Line Headers (for transpose)
        //
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public string GetDBFieldNameToDisplay_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[LineN - 1];
            }
            return cell.GetDBFieldNameToDisplay();
        }
        public void SetDBFieldNameToDisplay_ColOfLineHeader(string name, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetDBFieldNameToDisplay(name);
        }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public string GetDBFieldNameInTable_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[LineN - 1];
            }
            return cell.GetDBFieldNameInTable();
        }
        public void SetDBFieldNameInTable_ColOfLineHeader(string name, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetDBFieldNameInTable(name);
        }
        //3 Название связанной таблицы пунктов DBTableNa meInDB
        public string GetItemsDBTableNameInDB_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[LineN - 1];
            }
            return cell.GetItemsDBTableNameInDB();
        }
        public void SetItemsDBTableNameInDB_ColOfLineHeader(string name, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetItemsDBTableNameInDB(name);
        }
        //4 Имя поля первичного ключа связанной таблицы пунктов PrimaryKeyFieldName
        public string GetItemsDBTablePrimaryKeyFieldName_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[LineN - 1];
            }
            return cell.GetItemsDBTablePrimaryKeyFieldName();
        }
        public void SetItemsDBTablePrimaryKeyFieldName_ColOfLineHeader(string name, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetItemsDBTablePrimaryKeyFieldName(name);
        }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public string GetItemsDBTableItemsFieldName_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[LineN - 1];
            }
            return cell.GetItemsDBTableItemsFieldName();
        }
        public void SetItemsDBTableItemsFieldName_ColOfLineHeader(string name, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetItemsDBTableItemsFieldName(name);
        }
        //6 Тип данных поля DB Field data type 
        public int GetDBFieldTypeN_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[LineN - 1];
            }
            return cell.GetDBFieldTypeN();
        }
        public void SetDBFieldTypeN_ColOfLineHeader(int TypeN, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetDBFieldTypeN(TypeN);
        }
        public string GetDBFieldTypeName_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[LineN - 1];
            }
            return cell.GetDBFieldTypeName();
        }
        public void SetDBFieldTypeName_ColOfLineHeader(string name, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetDBFieldTypeName(name);
        }
        //7 Длина поля Field Length (not the same as Array length)
        public int GetDBFieldLength_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[LineN - 1];
            }
            return cell.GetDBFieldLength();
        }
        public void SetDBFieldLength_ColOfLineHeader(int L, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetDBFieldLength(L);
        }
        //8 Длина списка пунктов и прочее
        public int GetItemsQuantity_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[LineN - 1];
            }
            return cell.GetItemsQuantity();
        }
        public void SetItems_ColOfLineHeader(string[] items, int Q, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetItems(items, Q);
        }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public int GetDBFieldCharacteristicsNumber_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[LineN - 1];
            }
            return cell.GetDBFieldCharacteristicsNumber();
        }
        public void SetDBFieldCharacteristicsNumber_ColOfLineHeader(int num, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetDBFieldCharacteristicsNumber(num);
        }
        public bool IsKeyField_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[LineN - 1];
            }
            return cell.IsKeyField();
        }
        public void SetIfKeyField_ColOfLineHeader(bool KeyField, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetIfKeyField(KeyField);
        }
        public void SetKeyField_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetKeyField();
        }
        public void SetNotKeyField_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetNotKeyField();
        }
        public bool IsCounter_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[LineN - 1];
            }
            return cell.IsCounter();
        }
        public void SetIfCounter_ColOfLineHeader(bool isCounter, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetIfCounter(isCounter);
        }
        public void SetCounter_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetCounter();
        }
        public void SetNotCounter_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetNotCounter();
        }
        public bool IsAutoIncrement_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                cell = this.LineOfColHeader[LineN - 1];
            }
            return cell.IsAutoIncrement();
        }
        public void SetIfAutoIncrement_ColOfLineHeader(bool isAutoIncrement, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetIfAutoIncrement(isAutoIncrement);
        }
        public void SetAutoIncrement_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetAutoIncrement();
        }
        public void SetNotAutoIncrement_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetNotAutoIncrement();
        }
        public void SetIfIsNotNull_ColOfLineHeader(bool isNotNull, int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetIfNotNull(isNotNull);
        }
        public void SetNotNull_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetNotNull();
        }
        public void SetNotNotNull_ColOfLineHeader(int LineN, TableInfo_ConcrRepr TblInfExt = null)
        {
            TableInfo_ConcrRepr TblInf = this.Choose_TableInfo_StrSize_ByExtAndInner(TblInfExt);
            //DataCell cell = new DataCell();
            if (this.LineOfColHeader != null && LineN >= 1 && LineN <= TblInf.GetQColumns())
            {
                if (this.LineOfColHeader[LineN - 1].GetTypeN() != TableConsts.IntItemHeaderDependentTypeN)
                {
                    this.LineOfColHeader[LineN - 1] = new DataCell();
                    this.LineOfColHeader[LineN - 1].SetCellAsDBItemsFieldHeader();
                }
            }
            this.LineOfColHeader[LineN - 1].SetNotNotNull();
        }
        //CoLH
        //
        // for LGH and CGH
        //
        // Field LGH -----------------------------------------------------------------------------------------
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public string GetDBFieldNameToDisplay_LGH()
        {
            string s = "";
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.Headers.GetDBFieldNameToDisplay_LGH();
            }
            return s;
        }
        public void SetDBFieldNameToDisplay_LGH(string name)
        {
            if (this.Headers == null)
            {
                this.Headers = new  TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetDBFieldNameToDisplay_LGH(name);
        }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public string GetDBFieldNameInTable_LGH()
        {
            string s = "";
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.Headers.GetDBFieldNameInTable_LGH();
            }
            return s;
        }
        public void SetDBFieldNameInTable_LGH(string name)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetDBFieldNameInTable_LGH(name);
        }
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public string GetItemsDBTableNameInDB_LGH()
        {
            string s = "";
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.Headers.GetItemsDBTableNameInDB_LGH();
            }
            return s;
        }
        public void SetItemsDBTableNameInDB_LGH(string name)
        {
            if (this.Headers == null)
            {
                this.Headers = new  TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetItemsDBTableNameInDB_LGH(name);
        }
        //4 Имя поля первичного ключа связанной таблицы пунктов Pr return ""; imaryKeyFieldName
        public string GetItemsDBTablePrimaryKeyFieldName_LGH()
        {
            string s = "";
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.Headers.GetItemsDBTablePrimaryKeyFieldName_LGH();
            }
            return s;
        }
        public void SetItemsDBTablePrimaryKeyFieldName_LGH(string name)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetItemsDBTablePrimaryKeyFieldName_LGH(name);
        }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public string GetItemsDBTableItemsFieldName_LGH()
        {
            string s = "";
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.Headers.GetItemsDBTableItemsFieldName_LGH();
            }
            return s;
        }
        public void SetItemsDBTableItemsFieldName_LGH(string name)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetItemsDBTableItemsFieldName_LGH(name);
        }
        //6 Тип данных поля DB Field data type
        public int GetDBFieldTypeN_LGH()
        {
            int n = 0;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                n = this.Headers.GetDBFieldTypeN_LGH();
            }
            return n;
        }
        public void SetDBFieldTypeN_LGH(int TypeN)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetDBFieldTypeN_LGH(TypeN);
        }
        public string GetDBFieldTypeName_LGH()
        {
            string s = "";
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.Headers.GetDBFieldTypeName_LGH();
            }
            return s;
        }
        public void SetDBFieldTypeName_LGH(string name)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetDBFieldTypeName_LGH(name);
        }
        //7 Длина поля Field Length (not the same as Array length)
        public int GetDBFieldLength_LGH()
        {
            int n = 0;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                n = this.Headers.GetDBFieldLength_LGH();
            }
            return n;
        }
        public void SetDBFieldLength_LGH(int L)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetDBFieldLength_LGH(L);
        }
        //8 Длина списка пунктов и прочее
        //public override int GetItemsQuantity_LGH()
        //{
        //    int n = 0;
        //    if (this.LinesGeneralHeader != null)
        //    {
        //        //this.LinesGeneralHeader=new DataCell();
        ////        n = this.LinesGeneralHeader.GetDBFieldLength();
        //    }
        //    return n;
        //    
        //}
        public void SetItems_LGH(string[] items, int Q)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetItems_LGH(items, Q);
        }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public int GetDBFieldCharacteristicsNumber_LGH()
        {
            int n = 0;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                n = this.Headers.GetDBFieldCharacteristicsNumber_LGH();
            }
            return n;
        }
        public void SetDBFieldCharacteristicsNumber_LGH(int number)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetDBFieldCharacteristicsNumber_LGH(number);
        }
        public bool IsKeyField_LGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                b = this.Headers.IsKeyField_LGH();
            }
            return b;
        }
        public void SetIfKeyField_LGH(bool KeyField)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetIfKeyField_LGH(KeyField);
        }
        public void SetKeyField_LGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetKeyField_LGH();
        }
        public void SetNotKeyField_LGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetNotKeyField_LGH();
        }
        public bool IsCounter_LGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                b = this.Headers.IsCounter_LGH();
            }
            return b;
        }
        public void SetIfCounter_LGH(bool isCounter)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetIfCounter_LGH(isCounter);
        }
        public void SetCounter_LGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetCounter_LGH();
        }
        public void SetNotCounter_LGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetNotCounter_LGH();
        }
        public bool IsAutoIncrement_LGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                b = this.Headers.IsCounter_LGH();
            }
            return b;
        }
        public void SetIfAutoIncrement_LGH(bool isAutoIncrement)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetIfAutoIncrement_LGH(isAutoIncrement);
        }
        public void SetAutoIncrement_LGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetAutoIncrement_LGH();
        }
        public void SetNotAutoIncrement_LGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetNotAutoIncrement_LGH();
        }
        //
        public bool IsNotNull_LGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                b = this.Headers.IsNotNull_LGH();
            }
            return b;
        }
        public void SetIfNotNull_LGH(bool NotNull)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetIfNotNull_LGH(NotNull);
        }
        public void SetNotNull_LGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetNotNull_LGH();
        }
        public void SetNotNotNull_LGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetNotNotNull_LGH();
        }
        // Field_CGH -------------------------------------------------------------------------------------------
        //1 Название столбца отображаемое DBFieldNameToDisplay
        public string GetDBFieldNameToDisplay_CGH()
        {
            string s = "";
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.Headers.GetDBFieldNameToDisplay_CGH();
            }
            return s;
        }
        public void SetDBFieldNameToDisplay_CGH(string name)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetDBFieldNameToDisplay_CGH(name);
        }
        //2 Название столбца в БД, (в табл.назв.см.имя табл в БД)
        public string GetDBFieldNameInTable_CGH()
        {
            string s = "";
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.Headers.GetDBFieldNameInTable_CGH();
            }
            return s;
        }
        public void SetDBFieldNameInTable_CGH(string name)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetDBFieldNameInTable_CGH(name);
        }
        //3 Название связанной таблицы пунктов DBTableNameInDB
        public string GetItemsDBTableNameInDB_CGH()
        {
            string s = "";
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.Headers.GetItemsDBTableNameInDB_CGH();
            }
            return s;
        }
        public void SetItemsDBTableNameInDB_CGH(string name)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetItemsDBTableNameInDB_CGH(name);
        }
        //4 Имя поля первичного ключа связанной таблицы пунктов Pr return ""; imaryKeyFieldName
        public string GetItemsDBTablePrimaryKeyFieldName_CGH()
        {
            string s = "";
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.Headers.GetItemsDBTablePrimaryKeyFieldName_CGH();
            }
            return s;
        }
        public void SetItemsDBTablePrimaryKeyFieldName_CGH(string name)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetItemsDBTablePrimaryKeyFieldName_CGH(name);
        }
        //5 Имя поля названий пунктов в связанной таблице пунктов
        public string GetItemsDBTableItemsFieldName_CGH()
        {
            string s = "";
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.Headers.GetItemsDBTableItemsFieldName_CGH();
            }
            return s;
        }
        public void SetItemsDBTableItemsFieldName_CGH(string name)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetItemsDBTableItemsFieldName_CGH(name);
        }
        //6 Тип данных поля DB Field data type
        public int GetDBFieldTypeN_CGH()
        {
            int n = 0;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                n = this.Headers.GetDBFieldTypeN_CGH();
            }
            return n;
        }
        public void SetDBFieldTypeN_CGH(int TypeN)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetDBFieldTypeN_CGH(TypeN);
        }
        public string GetDBFieldTypeName_CGH()
        {
            string s = "";
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                s = this.Headers.GetDBFieldTypeName_CGH();
            }
            return s;
        }
        public void SetDBFieldTypeName_CGH(string name)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetDBFieldTypeName_CGH(name);
        }
        //7 Длина поля Field Length (not the same as Array length)
        public int GetDBFieldLength_CGH()
        {
            int n = 0;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                n = this.Headers.GetDBFieldLength_CGH();
            }
            return n;
        }
        public void SetDBFieldLength_CGH(int L)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetDBFieldLength_CGH(L);
        }
        //8 Длина списка пунктов и прочее
        //public override int GetItemsQuantity_CGH()
        //{
        //    int n = 0;
        //    if (this.LinesGeneralHeader != null)
        //    {
        //        //this.LinesGeneralHeader=new DataCell();
        ////        n = this.LinesGeneralHeader.GetDBFieldLength();
        //    }
        //    return n;
        //    
        //}
        public void SetItems_CGH(string[] items, int Q)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetItems_CGH(items, Q);
        }
        //public override void SetItems(DataCell [] ItemsCells, int Q){}
        //public override SetItemN(string item, int N){}
        //public override InsItemN(string item, int N){}
        //public override AddItem(string item){}
        //public override DelItemN(int N){}
        //public override int GetNamesQuantity(){}
        //public override void SetNames(string [] items, int Q){}
        //public override void SetNames(DataCell [] NamesCells, int Q){}
        //public override SetNameN(string item, int N){}
        //public override InsNameN(string item, int N){}
        //public override AddName(string item){}
        //public override DelNameN(int N){}
        //9 Характеристики поля булевы одним числом
        public int GetDBFieldCharacteristicsNumber_CGH()
        {
            int n = 0;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                n = this.Headers.GetDBFieldCharacteristicsNumber_CGH();
            }
            return n;
        }
        public void SetDBFieldCharacteristicsNumber_CGH(int number)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetDBFieldCharacteristicsNumber_CGH(number);
        }
        public bool IsKeyField_CGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                b = this.Headers.IsKeyField_CGH();
            }
            return b;
        }
        public void SetIfKeyField_CGH(bool KeyField)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetIfKeyField_CGH(KeyField);
        }
        public void SetKeyField_CGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetKeyField_CGH();
        }
        public void SetNotKeyField_CGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetNotKeyField_CGH();
        }
        public bool IsCounter_CGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                b = this.Headers.IsCounter_CGH();
            }
            return b;
        }
        public void SetIfCounter_CGH(bool isCounter)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetIfCounter_CGH(isCounter);
        }
        public void SetCounter_CGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetCounter_CGH();
        }
        public void SetNotCounter_CGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetNotCounter_CGH();
        }
        public bool IsAutoIncrement_CGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                b = this.Headers.IsCounter_CGH();
            }
            return b;
        }
        public void SetIfAutoIncrement_CGH(bool isAutoIncrement)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetIfAutoIncrement_CGH(isAutoIncrement);
        }
        public void SetAutoIncrement_CGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetAutoIncrement_CGH();
        }
        public void SetNotAutoIncrement_CGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetNotAutoIncrement_CGH();
        }
        //
        public bool IsNotNull_CGH()
        {
            bool b = MyLib.BoolValByDefault;
            if (this.Headers != null)
            {
                //this.LinesGeneralHeader=new DataCell();
                b = this.Headers.IsNotNull_CGH();
            }
            return b;
        }
        public void SetIfNotNull_CGH(bool NotNull)
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetIfNotNull_CGH(NotNull);
        }
        public void SetNotNull_CGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetNotNull_CGH();
        }
        public void SetNotNotNull_CGH()
        {
            if (this.Headers == null)
            {
                this.Headers = new TableHeaders();
                //s = this.LinesGeneralHeader.GetDBFieldNameToDisplay();
            }
            //return s;
            this.Headers.SetNotNotNull_CGH();
        }
        //
        //10 Разрешение редактировать значение поля
        //Пункт N
        //Пунктов = длина массива пунктов
        //
        // 
        // Tables settings concerning DB
        //----------------------------------------------------------------------------------------------------------
        public void SetDBTableDataFromTable(TTable tbl, TableInfo tblInfExt = null)
        {

        }
        public void SetDBFieldDataFromTable(TTable tbl, int N=0, TableInfo tblInfExt = null)
        {
            
        }
        public void SetDBFieldItemsTableDataFromTable(TTable tbl, int N = 0, TableInfo tblInfExt = null)
        {

        }
        public void SetItemsFromTable_Content(TTable tbl, int LineN, int ColN, TableInfo tblInfExt = null)
        {

        }
        public void SetItemsFromTable_LineOfColHeader(TTable tbl, int ColN, TableInfo tblInfExt = null)
        {

        }
        public void SetItemsFromTable_ColOfLineHeader(TTable tbl, int LineN, TableInfo tblInfExt = null)
        {

        }
        //
        public TTable GetDBTableDataFromTable()
        {
            TTable tbl = null;

            return tbl;
        }
        public TTable GetDBFieldDataFromTable(int N = 0)
        {
            TTable tbl = null;

            return tbl;
        }
        public TTable GetDBFieldItemsTableDataFromTable(int N = 0)
        {
            TTable tbl = null;

            return tbl;
        }
        public TTable GetItemsFromTable_Content(int LineN, int ColN)
        {
            TTable tbl = null;

            return tbl;
        }
        public TTable GetItemsFromTable_LineOfColHeader(int ColN)
        {
            TTable tbl = null;

            return tbl;
        }
        public TTable GetItemsFromTable_ColOfLineHeader(int LineN)
        {
            TTable tbl = null;

            return tbl;
        }
		//
        //
        DataCellRow GetContentLineAsDataCellRow(int LineN, TableInfo_ConcrRepr InfExt = null)
        {
            DataCellRow R = new DataCellRow(false);
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSizeRepr_ByExtAndInner(InfExt);
            int QLines = Inf.GetQLines();
            int QColumns = Inf.GetQColumns();
            if (LineN >= 1 && LineN <= QLines && QLines > 0)
            {
                for (int i = 1; i <= QColumns; i++)
                {
                    R.Add(this.GetCell(LineN, i, Inf));
                }
            }
            //R.SetHeader(this.GetCell_ColOfLineHeader(LineN, Inf));
            return R;
        }
        DataCellRow GetContentColumnAsDataCellRow(int ColN, TableInfo_ConcrRepr InfExt = null)
        {
            DataCellRow R = new DataCellRow(false);
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSizeRepr_ByExtAndInner(InfExt);
            int QLines = Inf.GetQLines();
            int QColumns = Inf.GetQColumns();
            if (ColN >= 1 && ColN <= QColumns && QColumns > 0)
            {
                for (int i = 1; i <= QLines; i++)
                {
                    R.Add(this.GetCell(i, ColN, InfExt));
                }
            }
            //R.SetHeader(this.GetCell_LineOfColHeader(ColN, Inf));
            return R;
        }
        DataCellRow GetLineOfColHeaderAsDataCellRow(TableInfo_ConcrRepr InfExt = null)
        {
            DataCellRow R = new DataCellRow(false);
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSizeRepr_ByExtAndInner(InfExt);
            int QLines = Inf.GetQLines();
            int QColumns = Inf.GetQColumns();
            if (this.LineOfColHeader != null && QColumns > 0)
            {
                for (int i = 1; i <= QColumns; i++)
                {
                    R.Add(this.GetCell_LineOfColHeader(i, Inf));
                }
            }
            //R.SetHeader(this.GetColumnsGeneralHeader());
            return R;
        }
        DataCellRow GetColOfLineHeaderAsDataCellRow(TableInfo_ConcrRepr InfExt = null)
        {
            DataCellRow R = new DataCellRow(false);
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSizeRepr_ByExtAndInner(InfExt);
            int QLines = Inf.GetQLines();
            int QColumns = Inf.GetQColumns();
            if (this.ColOfLineHeader != null && QLines > 0)
            {
                for (int i = 1; i <= QLines; i++)
                {
                    R.Add(this.GetCell_ColOfLineHeader(i, Inf));
                }
            }
           //SetHeader(this.GetLinesGeneralHeader());
            return R;
        }
        //
		DataCellRowCoHeader GetContentLineAsDataCellRowCoHeader(int LineN, TableInfo_ConcrRepr InfExt = null)
        {
            DataCellRowCoHeader R = new DataCellRowCoHeader(false, false);
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSizeRepr_ByExtAndInner(InfExt);
            int QLines = Inf.GetQLines();
            int QColumns = Inf.GetQColumns();
            if (LineN >= 1 && LineN <= QLines && QLines > 0)
            {
                for (int i = 1; i <= QColumns; i++)
                {
                    R.Add(this.GetCell(LineN, i, Inf));
                }
            }
            R.SetHeader(this.GetCell_ColOfLineHeader(LineN, Inf));
            return R;
        }
        DataCellRowCoHeader GetContentColumnAsDataCellRowCoHeader(int ColN, TableInfo_ConcrRepr InfExt = null)
        {
            DataCellRowCoHeader R = new DataCellRowCoHeader(false, false);
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSizeRepr_ByExtAndInner(InfExt);
            int QLines = Inf.GetQLines();
            int QColumns = Inf.GetQColumns();
            if (ColN >= 1 && ColN <= QColumns && QColumns > 0)
            {
                for (int i = 1; i <= QLines; i++)
                {
                    R.Add(this.GetCell(i, ColN, InfExt));
                }
            }
            R.SetHeader(this.GetCell_LineOfColHeader(ColN, Inf));
            return R;
        }
        DataCellRowCoHeader GetLineOfColHeaderAsDataCellRowCoHeader(TableInfo_ConcrRepr InfExt = null)
        {
            DataCellRowCoHeader R = new DataCellRowCoHeader(false, false);
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSizeRepr_ByExtAndInner(InfExt);
            int QLines = Inf.GetQLines();
            int QColumns = Inf.GetQColumns();
            if (this.LineOfColHeader != null && QColumns > 0)
            {
                for (int i = 1; i <= QColumns; i++)
                {
                    R.Add(this.GetCell_LineOfColHeader(i, Inf));
                }
            }
            R.SetHeader(this.GetColumnsGeneralHeader());
            return R;
        }
        DataCellRowCoHeader GetColOfLineHeaderAsDataCellRowCoHeader(TableInfo_ConcrRepr InfExt = null)
        {
            DataCellRowCoHeader R = new DataCellRowCoHeader(false, false);
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSizeRepr_ByExtAndInner(InfExt);
            int QLines = Inf.GetQLines();
            int QColumns = Inf.GetQColumns();
            if (this.ColOfLineHeader != null && QLines > 0)
            {
                for (int i = 1; i <= QLines; i++)
                {
                    R.Add(this.GetCell_ColOfLineHeader(i, Inf));
                }
            }
            R.SetHeader(this.GetLinesGeneralHeader());
            return R;
        }
        //
        //
        void AddCellTo_LineOfColHeader_CorrectingValToBeUnique(DataCell cell, TableInfo_ConcrRepr InfExt=null)
        {
            DataCell NewCell = null;
            TableInfo_ConcrRepr Inf=this.Choose_TableInfo_StrSize_ByExtAndInner(InfExt);
            DataCellRow row=this.GetLineOfColHeaderAsDataCellRow();
            string[] arr = row.GetAsStringArray();
            string val1 = cell.ToString();
            int QLines = Inf.GetQLines(), QColumns = Inf.GetQColumns();
            int L=QColumns;
            string bef = "";
            string aft = "_C_" + (QColumns + 1).ToString();
            string val2 = row.correctNewValToBeUnique(cell, bef, aft);
            if(!(QColumns>0 && this.LineOfColHeader==null))
            if (val1 == val2)
            {
                if (QColumns > 0)
                {
                    //public static void AddToVector<T>(ref T[] x, ref int L, T x1)
                    MyLib.AddToVector<DataCell>(ref this.LineOfColHeader, ref L, cell);
                }
                else
                {
                    this.LineOfColHeader = new DataCell[1];
                    this.LineOfColHeader[1 - 1] = new DataCell(val2);
                }
            }
            else
            {
                NewCell = new DataCell(val2);
                if (QColumns > 0)
                {
                    MyLib.AddToVector<DataCell>(ref this.LineOfColHeader, ref L, NewCell);
                }
                else
                {
                    this.LineOfColHeader = new DataCell[1];
                    this.LineOfColHeader[1 - 1] = NewCell;
                }
            }
            Inf.AddColumn();
        }
        void InsCellTo_LineOfColHeader_CorrectingValToBeUnique(DataCell cell, int ColN, TableInfo_ConcrRepr InfExt = null)
        {
            DataCell NewCell = null;
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSize_ByExtAndInner(InfExt);
            DataCellRow row = this.GetLineOfColHeaderAsDataCellRow();
            string[] arr = row.GetAsStringArray();
            string val1 = cell.ToString();
            int QLines = Inf.GetQLines(), QColumns = Inf.GetQColumns();
            int L = QColumns;
            string bef = "";
            string aft = "_C_" + ColN.ToString();
            string val2 = row.correctNewValToBeUnique(cell, bef, aft);
            if (ColN >= 1 && ColN <= QColumns && QColumns > 0 && this.LineOfColHeader != null)
            {
                if (val1 == val2)
                {
                    //public static void InsToVector<T>(ref T[] x, ref int L, T x1, int N)
                    MyLib.InsToVector<DataCell>(ref this.LineOfColHeader, ref L, cell, ColN);
                }
                else
                {
                    NewCell = new DataCell(val2);
                    //public static void InsToVector<T>(ref T[] x, ref int L, T x1, int N)
                    MyLib.InsToVector<DataCell>(ref this.LineOfColHeader, ref L, NewCell, ColN);
                }
                Inf.AddColumn();
            }
        }//fn
        void SetCellOf_LineOfColHeader_CorrectingValToBeUnique(DataCell cell, int ColN, TableInfo_ConcrRepr InfExt = null)
        {
            DataCell NewCell = null;
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSize_ByExtAndInner(InfExt);
            DataCellRow row = this.GetLineOfColHeaderAsDataCellRow();
            string[] arr = row.GetAsStringArray();
            string val1 = cell.ToString();
            int QLines = Inf.GetQLines(), QColumns = Inf.GetQColumns();
            int L = QColumns;
            string bef = "";
            string aft = "_C_" + ColN.ToString();
            string val2 = row.correctNewValToBeUnique(cell, bef, aft);
            if (!(QColumns > 0 && this.LineOfColHeader == null))
                if (val1 == val2)
                {
                    this.LineOfColHeader[ColN - 1] = cell;
                }
                else
                {
                    this.LineOfColHeader[ColN - 1] = NewCell;
                }
            //Inf.AddColumn();
        }//fn
        //
        void AddCellTo_ColOfLineHeader_CorrectingValToBeUnique(DataCell cell, TableInfo_ConcrRepr InfExt = null)
        {
            DataCell NewCell = null;
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSize_ByExtAndInner(InfExt);
            DataCellRow row = this.GetColOfLineHeaderAsDataCellRow();
            string[] arr = row.GetAsStringArray();
            string val1 = cell.ToString();
            int QLines = Inf.GetQLines(), QColumns = Inf.GetQColumns();
            int L = QLines;
            string bef = "";
            string aft = "_C_" + (QLines + 1).ToString();
            string val2 = row.correctNewValToBeUnique(cell, bef, aft);
            if (!(QLines > 0 && this.ColOfLineHeader == null))
                if (val1 == val2)
                {
                    if (QLines > 0)
                    {
                        //public static void AddToVector<T>(ref T[] x, ref int L, T x1)
                        MyLib.AddToVector<DataCell>(ref this.ColOfLineHeader, ref L, cell);
                    }
                    else
                    {
                        this.ColOfLineHeader = new DataCell[1];
                        this.ColOfLineHeader[1 - 1] = new DataCell(val2);
                    }
                }
                else
                {
                    NewCell = new DataCell(val2);
                    if (QLines > 0)
                    {
                        MyLib.AddToVector<DataCell>(ref this.ColOfLineHeader, ref L, NewCell);
                    }
                    else
                    {
                        this.ColOfLineHeader = new DataCell[1];
                        this.ColOfLineHeader[1 - 1] = NewCell;
                    }
                }
            Inf.AddLine();
        }
        void InsCellTo_ColOfLineHeader_CorrectingValToBeUnique(DataCell cell, int LineN, TableInfo_ConcrRepr InfExt = null)
        {
            DataCell NewCell = null;
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSize_ByExtAndInner(InfExt);
            DataCellRow row = this.GetColOfLineHeaderAsDataCellRow();
            string[] arr = row.GetAsStringArray();
            string val1 = cell.ToString();
            int QLines = Inf.GetQLines(), QColumns = Inf.GetQColumns();
            int L = QLines;
            string bef = "";
            string aft = "_C_" + LineN.ToString();
            string val2 = row.correctNewValToBeUnique(cell, bef, aft);
            if (LineN >= 1 && LineN <= QLines && QLines > 0 && this.ColOfLineHeader != null)
            {
                if (val1 == val2)
                {
                    //public static void InsToVector<T>(ref T[] x, ref int L, T x1, int N)
                    MyLib.InsToVector<DataCell>(ref this.ColOfLineHeader, ref L, cell, LineN);
                }
                else
                {
                    NewCell = new DataCell(val2);
                    //public static void InsToVector<T>(ref T[] x, ref int L, T x1, int N)
                    MyLib.InsToVector<DataCell>(ref this.ColOfLineHeader, ref L, NewCell, LineN);
                }
                Inf.AddLine();
            }
        }//fn
        void SetCellOf_ColOfLineHeader_CorrectingValToBeUnique(DataCell cell, int LineN, TableInfo_ConcrRepr InfExt = null)
        {
            DataCell NewCell = null;
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSize_ByExtAndInner(InfExt);
            DataCellRow row = this.GetColOfLineHeaderAsDataCellRow();
            string[] arr = row.GetAsStringArray();
            string val1 = cell.ToString();
            int QLines = Inf.GetQLines(), QColumns = Inf.GetQColumns();
            int L = QLines;
            string bef = "";
            string aft = "_C_" + LineN.ToString();
            string val2 = row.correctNewValToBeUnique(cell, bef, aft);
            if (!(QLines > 0 && this.ColOfLineHeader == null))
                if (val1 == val2)
                {
                    this.ColOfLineHeader[LineN - 1] = cell;
                }
                else
                {
                    this.ColOfLineHeader[LineN - 1] = NewCell;
                }
            //Inf.AddColumn();
        }//fn
        //
        public  TTable GetItemsAsTable(int LineN, int ColN, TableInfo_ConcrRepr tblInfExt=null){
            TTable tbl=new TTable();
            string[]items=null;
            DataCell cell=null;
            DataCellRow[]rows=null;
            int count=0;
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSize_ByExtAndInner(tblInfExt);
            if(LineN>=0 && LineN<=Inf.GetQLines() && ColN>=0 && ColN<=Inf.GetQColumns()){
                cell=this.GetCell(LineN, ColN, Inf);
                if(LineN>=1 && ColN>=1){
                    cell = this.GetCell(LineN, ColN, Inf);
                }else if(LineN==0 && ColN>=1){
                    cell = this.GetCell_ColOfLineHeader(ColN, Inf);
                }else if (LineN>=1 && ColN==0){
                    cell = this.GetCell_LineOfColHeader(LineN, Inf);
                }
                cell.GetStringArr(ref items, ref count);
                rows=new DataCellRow[count];
                for(int i=1; i<=count; i++){
                    rows[i-1]=new DataCellRow(new string[]{items[i-1]}, 1);
                }
                tbl.Set(new TableInfo(true, false, false, count, 1),
                null,
                false,
                rows,
                null,
                null,
                null
                ,
                true,
                false
               );
            }
            return tbl;
        }//fn
        public void SetItemsFromTable(int LineN, int ColN, TTable tbl, TableInfo_ConcrRepr tblInfExt = null)
        {
            DataCell cell=null;
            int TypeN = 0, QItemsWere=0, QItemsToSet=0;
            string[] itemsWere=null, itemsToSet=null;
            TableInfo_ConcrRepr Inf = this.Choose_TableInfo_StrSize_ByExtAndInner(tblInfExt);
            if(LineN>=0 && LineN<=Inf.GetQLines() && ColN>=0 && ColN<=Inf.GetQColumns()){
                cell=this.GetCell(LineN, ColN, Inf);
                if(LineN>=1 && ColN>=1){
                    cell = this.GetCell(LineN, ColN, Inf);
                }else if(LineN==0 && ColN>=1){
                    cell = this.GetCell_ColOfLineHeader(ColN, Inf);
                }
                else if (LineN>=1 && ColN==0)
                {
                    cell = this.GetCell_LineOfColHeader(LineN, Inf);
                }
                if (cell != null)
                {
                    TypeN = cell.GetTypeN();
                    cell.GetStringArr(ref itemsWere, ref QItemsWere);
                    if (tbl != null)
                    {
                        QItemsToSet = tbl.GetQLines();
                        if (QItemsToSet > 0)
                        {
                            itemsToSet = new string[QItemsToSet];
                            for (int i = 1; i <= QItemsToSet; i++)
                            {
                                itemsToSet[i - 1] = tbl.ToString(i, 1);
                            }
                        }///if to do 4
                    }//if to do 3
                }//if to do 2
            }//if to do 1
        }//fn
        /*
        private DataCellRow[] FormCellsRowsFromString2DArray(string[][] str)
        {
            DataCellRow[] rows=null;
            DataCell[][] cells = null;
            if (str != null)
            {
                int QE = str.Length;
                if (QE > 0)
                {
                    rows = new DataCellRow[QE];
                    for (int i = 1; i <= QE; i++)
                    {
                        rows[i - 1] = new DataCellRow(str[i - 1], str[i - 1].Length);
                    }
                }
            }
            return rows;
        }//fn
        */
        //private DataCell[][]FormCellsRowsFromSingleType2DArray<T>(T[][] arr)
        //{
        //    DataCell[][] cells = null;
        //    double dv;
        //    float fv;
        //    int iv;
        //    bool bv;
        //    string sv;
        //    int curL, minL = MyLib.Array2DMinLength(arr);
        //    if (arr != null)
        //    {
        //        int QE = arr.Length;
        //        if (QE > 0)
        //        {
        //            //rows = new DataCellRow[QE];
        //            cells=new DataCell[QE][];
        //            for (int i = 1; i <= QE; i++)
        //            {
        //                curL = arr[i - 1].Length;
        //                cells[i - 1] = new DataCell[minL];
        //                for (int j = 1; j <= minL; i++)
        //                {
        //                    if (arr[i - 1][j - 1] is double)
        //                    {
        //                        dv = (double)arr[i - 1][j - 1];
        //                        cells[i - 1][j - 1] = new DataCell(dv);
        //                    }
        //                    if (arr[i - 1][j - 1] is float)
        //                    {
        //                        fv = arr[i - 1][j - 1];
        //                    }
        //                    if (arr[i - 1][j - 1] is int)
        //                    {
        //                        iv = arr[i - 1][j - 1];
        //                    }
        //                    if (arr[i - 1][j - 1] is bool)
        //                    {
        //                        bv = arr[i - 1][j - 1];
        //                    }
        //                    if (arr[i - 1][j - 1] is string)
        //                    {
        //                        sv = arr[i - 1][j - 1];
        //                    }
        //                }  
        //            }
        //        }
        //    }
        //    return cells;
        //}//fn
        private DataCell[][] FormCellsRowsFrom2DArrayDouble(double[][] arr)
        {
            DataCell[][] cells = null;
            double dv;
            float fv;
            int iv;
            bool bv;
            string sv;
            int curL, minL = MyLib.Array2DMinLength(arr);
            if (arr != null)
            {
                int QE = arr.Length;
                if (QE > 0)
                {
                    //rows = new DataCellRow[QE];
                    cells = new DataCell[QE][];
                    for (int i = 1; i <= QE; i++)
                    {
                        curL = arr[i - 1].Length;
                        cells[i - 1] = new DataCell[minL];
                        for (int j = 1; j <= minL; i++)
                        {
                            cells[i - 1][j - 1] = new DataCell(arr[i - 1][j - 1]);
                        }
                    }
                }
            }
            return cells;
        }//fn
        private DataCell[][] FormCellsRowsFrom2DArrayFloat(float[][] arr)
        {
            DataCell[][] cells = null;
            double dv;
            float fv;
            int iv;
            bool bv;
            string sv;
            int curL, minL = MyLib.Array2DMinLength(arr);
            if (arr != null)
            {
                int QE = arr.Length;
                if (QE > 0)
                {
                    //rows = new DataCellRow[QE];
                    cells = new DataCell[QE][];
                    for (int i = 1; i <= QE; i++)
                    {
                        curL = arr[i - 1].Length;
                        cells[i - 1] = new DataCell[minL];
                        for (int j = 1; j <= minL; i++)
                        {
                            cells[i - 1][j - 1] = new DataCell(arr[i - 1][j - 1]);
                        }
                    }
                }
            }
            return cells;
        }//fn
        private DataCell[][] FormCellsRowsFrom2DArrayInt(int[][] arr)
        {
            DataCell[][] cells = null;
            double dv;
            float fv;
            int iv;
            bool bv;
            string sv;
            int curL, minL = MyLib.Array2DMinLength(arr);
            if (arr != null)
            {
                int QE = arr.Length;
                if (QE > 0)
                {
                    //rows = new DataCellRow[QE];
                    cells = new DataCell[QE][];
                    for (int i = 1; i <= QE; i++)
                    {
                        curL = arr[i - 1].Length;
                        cells[i - 1] = new DataCell[minL];
                        for (int j = 1; j <= minL; i++)
                        {
                            cells[i - 1][j - 1] = new DataCell(arr[i - 1][j - 1]);
                        }
                    }
                }
            }
            return cells;
        }//fn
        private DataCell[][] FormCellsRowsFrom2DArrayBool(bool[][] arr)
        {
            DataCell[][] cells = null;
            double dv;
            float fv;
            int iv;
            bool bv;
            string sv;
            int curL, minL = MyLib.Array2DMinLength(arr);
            if (arr != null)
            {
                int QE = arr.Length;
                if (QE > 0)
                {
                    //rows = new DataCellRow[QE];
                    cells = new DataCell[QE][];
                    for (int i = 1; i <= QE; i++)
                    {
                        curL = arr[i - 1].Length;
                        cells[i - 1] = new DataCell[minL];
                        for (int j = 1; j <= minL; i++)
                        {
                            cells[i - 1][j - 1] = new DataCell(arr[i - 1][j - 1]);
                        }
                    }
                }
            }
            return cells;
        }//fn
        public DataCell[][] FormCellsRowsFrom2DArrayString(string[][] arr)
        {
            DataCell[][] cells = null;
            double dv;
            float fv;
            int iv;
            bool bv;
            string sv;
            int curL, minL = MyLib.Array2DMinLength(arr);
            if (arr != null)
            {
                int QE = arr.Length;
                if (QE > 0)
                {
                    //rows = new DataCellRow[QE];
                    cells = new DataCell[QE][];
                    for (int i = 1; i <= QE; i++)
                    {
                        curL = arr[i - 1].Length;
                        cells[i - 1] = new DataCell[minL];
                        for (int j = 1; j <= minL; j++)
                        {
                            sv=arr[i - 1][j - 1];
                            cells[i - 1][j - 1] = new DataCell(sv);
                            //cells[i - 1][j - 1] = new DataCell(arr[i - 1][j - 1]);
                        }
                    }
                }
            }
            return cells;
        }//fn
        public void SetFrom2DArray(DataCell[][] arr, int QExtRowsOfIneRowsHeaders = 0, int QIneRowsOfExtRowsHeaders = 0, bool ArrayOfLinesNotColumnsExt = true, bool ArrayOfLinesNotColumnsInner = true, TableInfo TblInfOldExt=null, bool PreserveVals=true, bool WriteInfo = true, TValsShowHide vsh = null)
        {
            DataCell[][] linesExt = null, columnsExt = null, linesCont = null, columnsCont = null;
            DataCellRow LineOfColHeader = null, ColOfLineHeader = null;
            DataCellRow[] contentRows = null;//, LineOfColHeaderCells = null, ColOfLineHeaderCells = null;
            DataCell[] LineOfColHeaderCells = null, ColOfLineHeaderCells = null;
            int QLinesOfColHeaders=0,  QColsOfLineHeaders = 0;
            int QE, curL, minL;
            int QLines, QColumns;
            int QContentLines, QContentColumns;
            string corner;
            int CornerType_No0String1HeaderDB2;
            if (arr != null)
            {
                QE = arr.Length;
                minL = MyLib.Array2DMinLength(arr);
                if (ArrayOfLinesNotColumnsExt == ArrayOfLinesNotColumnsInner)
                {
                    if (ArrayOfLinesNotColumnsInner)
                    {
                        QLines=QE;
                        QColumns=minL;
                        QLinesOfColHeaders=QExtRowsOfIneRowsHeaders;
                        QColsOfLineHeaders =QIneRowsOfExtRowsHeaders;
                        QContentLines = QLines - QLinesOfColHeaders;
                        QContentColumns = QColumns - QColsOfLineHeaders;
                        //
                        linesExt = new DataCell[QE][];
                        for (int i = 1; i <= QE; i++)
                        {
                            linesExt[i - 1] = new DataCell[minL];
                            for (int j = 1; j <= minL; j++)
                            {
                                //linesExt[i - 1][j - 1] = new DataCell(arr[i - 1][j - 1]);
                                linesExt[i - 1][j - 1] = new DataCell();
                                linesExt[i - 1][j - 1].Assign(arr[i - 1][j - 1]);
                            }
                        }
                    }
                    else
                    {
                        QLines = minL;
                        QColumns = QE;
                        QColsOfLineHeaders=QExtRowsOfIneRowsHeaders;
                        QLinesOfColHeaders=QIneRowsOfExtRowsHeaders;
                        QContentLines = QLines - QLinesOfColHeaders;
                        QContentColumns = QColumns - QColsOfLineHeaders;
                        //
                        columnsExt = new DataCell[QE][];
                        for (int i = 1; i <= QE; i++)
                        {
                            columnsExt[i - 1] = new DataCell[minL];
                            for (int j = 1; j <= minL; j++)
                            {
                                //linesExt[i - 1][j - 1] = new DataCell(arr[i - 1][j - 1]);
                                columnsExt[i - 1][j - 1] = new DataCell();
                                columnsExt[i - 1][j - 1].Assign(arr[i - 1][j - 1]);
                            }
                        }
                    }
                }
                else//!=sdtrs
                {
                    if (ArrayOfLinesNotColumnsInner)
                    {
                        QLines = minL;
                        QColumns = QE;
                        QLinesOfColHeaders=QExtRowsOfIneRowsHeaders;
                        QColsOfLineHeaders=QIneRowsOfExtRowsHeaders;
                        QContentLines = QLines - QLinesOfColHeaders;
                        QContentColumns = QColumns - QColsOfLineHeaders;
                        //
                        linesExt = new DataCell[minL][];
                        for (int i = 1; i <= minL; i++)
                        {
                            linesExt[i - 1] = new DataCell[QE];
                            for (int j = 1; j <= QE; j++)
                            {
                                //linesExt[i - 1][j - 1] = new DataCell(arr[i - 1][j - 1]);
                                linesExt[i - 1][j - 1] = new DataCell();
                                linesExt[i - 1][j - 1].Assign(arr[j - 1][i - 1]);
                            }
                        }
                    }
                    else
                    {
                        QColumns = minL;
                        QLines = QE;
                        QColsOfLineHeaders=QExtRowsOfIneRowsHeaders;
                        QLinesOfColHeaders=QIneRowsOfExtRowsHeaders;
                        QContentLines = QLines - QLinesOfColHeaders;
                        QContentColumns = QColumns - QColsOfLineHeaders;
                        columnsExt = new DataCell[minL][];
                        for (int i = 1; i <= minL; i++)
                        {
                            columnsExt[i - 1] = new DataCell[QE];
                            for (int j = 1; j <= QE; j++)
                            {
                                columnsExt[i - 1][j - 1] = new DataCell();
                                columnsExt[i - 1][j - 1].Assign(arr[j - 1][i - 1]);
                            }
                        }
                    }//
                }//
                //
                if (ArrayOfLinesNotColumnsInner)
                {
                    contentRows = new DataCellRow[QLines - QLinesOfColHeaders];
                    linesCont = new DataCell[QLines - QLinesOfColHeaders][];
                    for (int i = 1; i <= QLines - QLinesOfColHeaders; i++)
                    {
                        linesCont[i - 1] = new DataCell[QColumns - QColsOfLineHeaders];
                        for (int j = 1; j <= QColumns - QColsOfLineHeaders; j++)
                        {
                            linesCont[i - 1][j - 1] = linesExt[i + QLinesOfColHeaders - 1][j + QColsOfLineHeaders - 1];
                        }
                        contentRows[i - 1] = new DataCellRow(linesCont[i - 1], QColumns - QColsOfLineHeaders);
                    }
                    //
                    if (QColsOfLineHeaders > 0)
                    {
                        ColOfLineHeaderCells = new DataCell[QLines - QLinesOfColHeaders];
                        for (int i = 1; i <= QLines - QLinesOfColHeaders; i++)
                        {
                            ColOfLineHeaderCells[i - 1] = linesExt[i + QLinesOfColHeaders - 1][1 + QColsOfLineHeaders - 1 - 1];
                        }
                    }
                    if (QLinesOfColHeaders > 0)
                    {
                        LineOfColHeaderCells = new DataCell[QColumns - QColsOfLineHeaders];
                        for (int i = 1; i <= QColumns - QColsOfLineHeaders; i++)
                        {
                            LineOfColHeaderCells[i - 1] = linesExt[1 + QColsOfLineHeaders - 1 - 1][i + QColsOfLineHeaders - 1 ];
                        }
                    }
                }
                else
                {
                    contentRows = new DataCellRow[QContentColumns];
                    columnsCont = new DataCell[QContentColumns][];
                    for (int i = 1; i <= QContentColumns; i++)
                    {
                        columnsCont[i - 1]=new DataCell[QContentLines];
                        for (int j = 1; j <= QContentLines; j++)
                        {
                            columnsCont[i - 1][j - 1] = columnsExt[i + QColsOfLineHeaders - 1][j + QLinesOfColHeaders - 1];
                        }
                        contentRows[i - 1] = new DataCellRow(columnsCont[i - 1], QContentLines);
                    }
                    //
                    if (QColsOfLineHeaders > 0)
                    {
                        ColOfLineHeaderCells = new DataCell[QContentLines];
                        for (int i = 1; i <= QContentLines; i++)
                        {
                            ColOfLineHeaderCells[i - 1] = columnsExt[1 + QColsOfLineHeaders - 1 - 1][i + QLinesOfColHeaders - 1 /*- 1*/];
                        }
                    }
                    if (QLinesOfColHeaders > 0)
                    {
                        LineOfColHeaderCells = new DataCell[QContentColumns];
                        for (int i = 1; i <= QContentColumns; i++)
                        {
                            LineOfColHeaderCells[i - 1] = columnsExt[i + QColsOfLineHeaders - 1 - 1][1 + QLinesOfColHeaders - 1 /*- 1*/];
                        }
                    }
                }//if LC or CL77 
                //
                if (QLinesOfColHeaders > 0)
                {
                    LineOfColHeader = new DataCellRow(LineOfColHeaderCells, QContentColumns);
                }
                if (QColsOfLineHeaders > 0)
                {
                    ColOfLineHeader = new DataCellRow(ColOfLineHeaderCells, QContentLines);
                }
                //
                if (QLinesOfColHeaders > 0 && QColsOfLineHeaders > 0)
                {
                    //if (arr[1 - 1][1 - 1].GetTypeN() == TableConsts.StringTypeN || arr[1 - 1][1 - 1].GetTypeN() == TableConsts.DBTableHeaderTypeN)
                    //{
                    //
                    //}
                    if (arr[1 - 1][1 - 1].GetTypeN() == TableConsts.StringTypeN)
                    {
                        CornerType_No0String1HeaderDB2 = 1;
                        corner=arr[1 - 1][1 - 1].ToString();
                        this.Set(
                            new TableInfo(ArrayOfLinesNotColumnsInner, (QColsOfLineHeaders > 0), (QLinesOfColHeaders > 0), QContentLines, QContentColumns),
                            null,
                            !ArrayOfLinesNotColumnsInner,
                            contentRows,
                            LineOfColHeader,
                            ColOfLineHeader,
                            new TableHeaders(corner),
                            WriteInfo,
                            PreserveVals
                       );
                    }
                    else if (arr[1 - 1][1 - 1].GetTypeN() == TableConsts.DBTableHeaderTypeN)
                    {
                        CornerType_No0String1HeaderDB2 = 2;
                        this.Set(
                            new TableInfo(ArrayOfLinesNotColumnsInner, (QColsOfLineHeaders > 0), (QLinesOfColHeaders > 0), QContentLines, QContentColumns),
                            null,
                            !ArrayOfLinesNotColumnsInner,
                            contentRows,
                            LineOfColHeader,
                            ColOfLineHeader,
                            new TableHeaders(arr[1 - 1][1 - 1], null, null),
                            WriteInfo,
                            PreserveVals
                       );
                    }
                    else
                    {
                        CornerType_No0String1HeaderDB2 = 0;
                        this.Set(
                            new TableInfo(ArrayOfLinesNotColumnsInner, (QColsOfLineHeaders > 0), (QLinesOfColHeaders > 0), QContentLines, QContentColumns),
                            null,
                            !ArrayOfLinesNotColumnsInner,
                            contentRows,
                            LineOfColHeader,
                            ColOfLineHeader,
                            null,
                            WriteInfo,
                            PreserveVals
                       );
                        //this.Set(
                    }
                }
                else // QLinesOfColHeaders == 0 or QColsOfLineHeaders == 0
                {
                    CornerType_No0String1HeaderDB2 = 0;
                    this.Set(
                            new TableInfo(ArrayOfLinesNotColumnsInner, (QColsOfLineHeaders > 0), (QLinesOfColHeaders > 0), QContentLines, QContentColumns),
                            null,
                            !ArrayOfLinesNotColumnsInner,
                            contentRows,
                            LineOfColHeader,
                            ColOfLineHeader,
                            null,
                            WriteInfo,
                            PreserveVals
                       );
                }
            }//if to do
        }//fn
    }//cl
}//ns  //2021-05-16