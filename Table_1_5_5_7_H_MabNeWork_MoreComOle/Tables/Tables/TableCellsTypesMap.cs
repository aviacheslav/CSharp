using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    public class DataCellTypeInfo
    {
        DataCell Data;
        public DataCellTypeInfo()
        {
            Data = new DataCell(TableConsts.IntArrayTypeN, 2);
            SetTypeN(1, 0);
            SetLength(1);
        }
        public DataCellTypeInfo(DataCell data)
        {
            SetTypeN(data.GetIntVal(), 0);
            SetLength(1);
        }
        public DataCellTypeInfo(int TypeN)
        {
            SetTypeN(TypeN, 0);
            SetLength(1);
        }
        public DataCellTypeInfo(int TypeN, int Length)
        {
            SetTypeN(TypeN, 0);
            SetLength(Length);
        }
        public DataCellTypeInfo(int TypeN, int Length, int CellTypeAny0Content1LoCH2CoLH3)
        {
            SetTypeN(TypeN, 0);
            SetLength(Length);
        }
        public DataCellTypeInfo(DataCell data, int CellTypeAny0Content1LoCH2CoLH3)
        {
            SetTypeN(data.GetIntVal(), CellTypeAny0Content1LoCH2CoLH3);
            SetLength(data.GetIntValN(2));
        }
        public void SetCellTypeInfo(int TypeN)
        {
            SetTypeN(TypeN);
            SetLength(1);
        }
        public void SetCellTypeInfo(int TypeN, int Length)
        {
            SetTypeN(TypeN);
            SetLength(Length);
        }
        public void SetCellTypeInfo(int TypeN, int Length, int CellTypeAny0Content1LoCH2CoLH3)
        {
            SetTypeN(TypeN, CellTypeAny0Content1LoCH2CoLH3);
            SetLength(Length);
        }
        //
        public void SetTypeN(int TypeN, int CellTypeAny0Content1LoCH2CoLH3)
        {
            if (Data == null) Data = new DataCell();
            if (!TableConsts.TypeNIsCorrect(TypeN))
            {
                switch (CellTypeAny0Content1LoCH2CoLH3)
                {
                    case 1:
                        TypeN = TableConsts.DefaultContentCellTypeN;
                        break;
                    case 2:
                        TypeN = TableConsts.DefaultLineOfColHeaderCellTypeN;
                        break;
                    case 3:
                        TypeN = TableConsts.DefaultColOfLineHeaderCellTypeN;
                        break;
                    default:
                        TypeN = TableConsts.DefaultAnyCellTypeN;
                        break;
                }
            }
            Data.SetByValIntN(TypeN, 1);
        }//fn
        public void SetTypeN(int TypeN)
        {
            SetTypeN(TypeN, 0);
        }
        public void SetLength(int L)
        {
            if (L < 1 && L > MyLib.MaxInt)
            {
                if (TableConsts.TypeNIsCorrectArray(Data.GetIntValN(1))) L = 2;
                else L = 1;
            }
            Data.SetByValIntN(L, 2);
        }
        //
        //
        public int GetTypeN()
        {
            return Data.GetIntValN(1);
        }
        public int GetLength()
        {
            return Data.GetIntValN(2);
        }
        public void Get(ref int TypeN, ref int Length)
        {
            TypeN = GetTypeN(); Length = GetLength();
        }
        //
        public DataCell GetData() { return this.Data; }
    }//cl
    //
    public class DataTypeRow
    {
        public DataCellTypeInfo[] row;
        public DataTypeRow(int quantity, DataCellTypeInfo[] row)
        {
            if (quantity > 1 && quantity < MyLib.MaxInt)
            {
                this.row = new DataCellTypeInfo[quantity];
                if (row != null)
                {
                    for (int i = 1; i <= quantity; i++)
                    {
                        this.row[i - 1] = row[i - 1];
                    }
                }
            }
        }
        public DataTypeRow(int quantity, int[] Types, int[] Lengths)
        {
            int TypeN=TableConsts.DefaultAnyCellTypeN, Length=2;
            if (quantity > 1 && quantity < MyLib.MaxInt)
            {
                this.row = new DataCellTypeInfo[quantity];
                for (int i = 1; i <= quantity; i++)
                {
                    if(Types!=null && TableConsts.TypeNIsCorrect(Types[i-1])) TypeN=Types[i-1]; else TypeN=TableConsts.DefaultAnyCellTypeN;
                    if(Lengths!=null && Lengths[i-1]>0 && Lengths[i-1]<MyLib.MaxInt) Length=Lengths[i-1]; else Length=2;
                    this.row[i - 1] =new DataCellTypeInfo(TypeN, Length);
                }
            }
        }
        public DataTypeRow(int quantity, int TypeN, int Length = 2)
        {
            if(!TableConsts.TypeNIsCorrect(TypeN))  TypeN=TableConsts.DefaultAnyCellTypeN;
            if(!(Length>0 && Length<MyLib.MaxInt)) Length=2;
            if (quantity > 1 && quantity < MyLib.MaxInt)
            {
                this.row = new DataCellTypeInfo[quantity];
                for (int i = 1; i <= quantity; i++)
                {
                    
                    this.row[i - 1] =new DataCellTypeInfo(TypeN, Length);
                }
            }
        }
        public void Set(int quantity, DataCellTypeInfo[] row)
        {
            if (quantity > 1 && quantity < MyLib.MaxInt)
            {
                this.row = new DataCellTypeInfo[quantity];
                if (row != null)
                {
                    for (int i = 1; i <= quantity; i++)
                    {
                        this.row[i - 1] = row[i - 1];
                    }
                }
            }
        }
        public void Set(int quantity, int[] Types, int[] Lengths)
        {
            int TypeN, Length;
            row = new DataCellTypeInfo[quantity];
            for (int i = 1; i <= quantity; i++)
            {
                if(Types!=null && TableConsts.TypeNIsCorrect(Types[i-1])) TypeN=Types[i-1]; else TypeN=TableConsts.DefaultAnyCellTypeN;
                if(Lengths!=null && Lengths[i-1]>0 && Lengths[i-1]<MyLib.MaxInt) Length= Lengths[i-1]; else Length=2;
                this.row[i - 1] = new DataCellTypeInfo(TypeN, Length);
            }
        }
        public void Set(int quantity, int typeN, int length = 2)
        {
            row = new DataCellTypeInfo[quantity];
            for (int i = 1; i <= quantity; i++)
            {
                this.row[i - 1] = new DataCellTypeInfo(typeN, length);
            }
        }
    }//cl _TypesRow
    public class DataTypeTable
    {
        public DataCellTypeInfo[][] cells;
        public DataTypeTable(int QLines, int QColumns, DataCellTypeInfo[][] cells)
        {
            this.cells = new DataCellTypeInfo[QLines][];
            for (int i = 1; i <= QLines; i++)
            {
                this.cells[i - 1] = new DataCellTypeInfo[QColumns];
                if (cells != null)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        this.cells[i - 1][j - 1] = cells[i - 1][j - 1];
                    }
                }
            }
        }
        public DataTypeTable(int QLines, int QColumns, bool LinesNotColumnsGiven, DataTypeRow[] rows)
        {
            this.cells = new DataCellTypeInfo[QLines][];
            for (int i = 1; i <= QLines; i++)
            {
                this.cells[i - 1] = new DataCellTypeInfo[QColumns];
            }
            if (LinesNotColumnsGiven)
            {
                if (rows != null)
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            this.cells[i - 1][j - 1] = rows[i - 1].row[j - 1];
                        }
                    }
                }
            }
            else
            {
                if (rows != null)
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            this.cells[i - 1][j - 1] = rows[j - 1].row[i - 1];
                        }
                    }
                }
            }
        }
        public DataTypeTable(int QLines, int QColumns, bool LinesNotColumnsHaveSameTypes, DataTypeRow rows)
        {
            this.cells = new DataCellTypeInfo[QLines][];
            for (int i = 1; i <= QLines; i++)
            {
                this.cells[i - 1] = new DataCellTypeInfo[QColumns];
            }
            if (LinesNotColumnsHaveSameTypes)
            {
                if (rows != null)
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            this.cells[i - 1][j - 1] = rows.row[i - 1];
                        }
                    }
                }
            }
            else
            {
                if (rows != null)
                {
                    for (int i = 1; i <= QLines; i++)
                    {
                        for (int j = 1; j <= QColumns; j++)
                        {
                            this.cells[i - 1][j - 1] = rows.row[j - 1];
                        }
                    }
                }
            }
        }
        public DataTypeTable(int QLines, int QColumns, bool LinesNotColumnsHaveSameTypes, int[][] types, int[][] lengths = null)
        {
            int TypeN = 0, Length = 2;
            if (lengths == null) Length = 2;
            if (types == null) TypeN = TableConsts.DefaultContentCellTypeN;
            this.cells = new DataCellTypeInfo[QLines][];
            for (int i = 1; i <= QLines; i++)
            {
                this.cells[i - 1] = new DataCellTypeInfo[QColumns];
            }
            for (int i = 1; i <= QLines; i++)
            {
                for (int j = 1; j <= QColumns; j++)
                {
                    if (types != null && TableConsts.TypeNIsCorrect(types[i-1][j-1])) TypeN = types[i - 1][j - 1];
                    if (lengths != null && lengths[i-1][j-1]>0 && lengths[i-1][j-1]<MyLib.MaxInt) Length = lengths[i - 1][j - 1];
                    this.cells[i - 1][j - 1] = new DataCellTypeInfo(TypeN, Length);
                }
            }
        }
        public DataTypeTable(int QLines, int QColumns, bool LinesNotColumnsHaveSameTypes, int[] types, int[] lengths = null)
        {
            int TypeN=TableConsts.DefaultContentCellTypeN;
            int length=2;
            this.cells = new DataCellTypeInfo[QLines][];
            for (int i = 1; i <= QLines; i++)
            {
                this.cells[i - 1] = new DataCellTypeInfo[QColumns];
                for (int j = 1; j <= QColumns; j++){
                    if(LinesNotColumnsHaveSameTypes){
                        if(types!=null && TableConsts.TypeNIsCorrect(types[i-1])) TypeN=types[i-1];
                        if(lengths!=null && lengths[i-1]>0 && lengths[i-1]<MyLib.MaxInt) length=lengths[i-1];
                    }else{
                        if(types!=null && TableConsts.TypeNIsCorrect(types[i-1])) TypeN=types[j-1];
                        if(lengths!=null && lengths[i-1]>0 && lengths[i-1]<MyLib.MaxInt) length=lengths[j-1];
                    }
                    this.cells[i - 1][j-1]=new DataCellTypeInfo(TypeN, length);
                }
            }
        }
        public DataTypeTable(int QLines, int QColumns, bool LinesNotColumnsHaveSameTypes, int[] types, int length)
        {
            int TypeN = TableConsts.DefaultContentCellTypeN;
            //int length = 2;
            this.cells = new DataCellTypeInfo[QLines][];
            for (int i = 1; i <= QLines; i++)
            {
                this.cells[i - 1] = new DataCellTypeInfo[QColumns];
                for (int j = 1; j <= QColumns; j++)
                {
                    if (LinesNotColumnsHaveSameTypes)
                    {
                        if (types != null && TableConsts.TypeNIsCorrect(types[i - 1])) TypeN = types[i - 1];
                        //if (lengths != null && lengths[i - 1] > 0 && lengths[i - 1] < MyLib.MaxInt) length = lengths[i - 1];
                    }
                    else
                    {
                        if (types != null && TableConsts.TypeNIsCorrect(types[i - 1])) TypeN = types[j - 1];
                        //if (lengths != null && lengths[i - 1] > 0 && lengths[i - 1] < MyLib.MaxInt) length = lengths[j - 1];
                    }
                    this.cells[i - 1][j - 1] = new DataCellTypeInfo(TypeN, length);
                }
            }
        }
        public DataTypeTable(int QLines, int QColumns, int TypeN, int length = 2)
        {
            this.cells = new DataCellTypeInfo[QLines][];
            for (int i = 1; i <= QLines; i++)
            {
                this.cells[i - 1] = new DataCellTypeInfo[QColumns];
                for (int j = 1; j <= QColumns; j++)
                {
                    this.cells[i - 1][j - 1] = new DataCellTypeInfo(TypeN, length);
                }
            }
        }
    }
    //
    //
    public class TableCellsTypeMap
    {
        //hic class es ne nur f' 1 var f' muc types et lengths, ma ut alum check vals hin, ut ne denk om ce in class Table, ut class Table hat alum ver'l vals
        DataCellTypeInfo[][] Content;
        DataCellTypeInfo[] LineOfColHeader, ColOfLineHeader;
        //Z s'privat ob I vol ne do vrns LC & CL, in hic class wi nur 1 vrn - LC
        //Et use l'hic class in class table, qam LC and CL problem s', wu do no missverstaendis, if Z wu privat et ir vals wu return'd by methods
        //Z s' DataCell[], ne int[], ob so 1 var can epas(give) ad(to) 1 cell l'2 params: type et length, et f'futur, s'abl add('t') anid(etw) else 
        public TableCellsTypeMap()
        {
            TableInfo TblInf = new TableInfo();
            if (TblInf.Str == null) TblInf.Str = new TableStructure();
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            //
            SetNullIni();
            //
            Set(TblInf, null, null, null);
        }
        public TableCellsTypeMap(TableInfo TblInfExt)
        {
            SetNullIni();
            //
            Set(TblInfExt, null, null, null);
        }
        public TableCellsTypeMap(TableInfo TblInfExt, DataTypeTable Content, DataTypeRow LineOfColHeader, DataTypeRow ColOfLineHeader)
        {
            SetNullIni();//ob constr
            Set_3Params(TblInfExt, Content, LineOfColHeader, ColOfLineHeader);
        }
        public TableCellsTypeMap(TableInfo TblInfExt, DataCellTypeInfo[][] Content, DataCellTypeInfo[] LineOfColHeader, DataCellTypeInfo[] ColOfLineHeader)
        {
            SetNullIni();//ob constr
            Set(TblInfExt, Content, LineOfColHeader, ColOfLineHeader);
        }
        //constrs for 1 row or 1 type
        public TableCellsTypeMap(bool ColNotLine, TableInfo TblInfExt, DataCellTypeInfo[] RowContent, DataCellTypeInfo RowHeader, DataCellTypeInfo[] HeaderRow)
        {
            SetNullIni();
            if (ColNotLine)
            {
                SetSnglColumn(TblInfExt, RowContent, RowHeader, HeaderRow);
            }
            else
            {
                SetSnglLine(TblInfExt, RowContent, RowHeader, HeaderRow);
            }
        }
        public TableCellsTypeMap(TableInfo TblInfExt, int[][] ContentTypes, int[][] ContentLengths, int[] LoCHTypes, int[] LoCHLengths, int[] CoLHTypes, int[] CoLHLengths)
        {
            SetNullIni();
            Set(TblInfExt, ContentTypes, ContentLengths, LoCHTypes, LoCHLengths, CoLHTypes, CoLHLengths);
        }
        //
        public void SetNullIni()
        {
            Content = null;
            LineOfColHeader = null;
            ColOfLineHeader = null;
        }
        //
        public void Set_3Params(TableInfo TblInfExt, DataTypeTable Content, DataTypeRow LineOfColHeader, DataTypeRow ColOfLineHeader)
        {
            DataCellTypeInfo[][] ContentCells;
            DataCellTypeInfo[] LineOfColHeaderCells;
            DataCellTypeInfo[] ColOfLineHeaderCells;
            TableInfo TblInf;
            int QLines=1, QColumns=1;
            //
            if(TblInfExt==null)TblInf = new TableInfo(); else TblInf=TblInfExt;
            if (TblInf.Str == null) TblInf.Str = new TableStructure();
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            //
            QLines=TblInf.RowsQuantities.QLines; QColumns=TblInf.RowsQuantities.QColumns;
            //
            ContentCells = new DataCellTypeInfo[QLines][];
            for (int i = 1; i <= QLines; i++) ContentCells[i - 1] = new DataCellTypeInfo[QColumns];
            LineOfColHeaderCells = new DataCellTypeInfo[QColumns];
            ColOfLineHeaderCells = new DataCellTypeInfo[QLines];
            //Content
            if (Content != null)
            {
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        ContentCells[i - 1][j - 1] = Content.cells[i - 1][j - 1];
                    }
                }
            }
            else
            {
                for (int i = 1; i <= QLines; i++)
                {
                    for (int j = 1; j <= QColumns; j++)
                    {
                        ContentCells[i - 1][j - 1] = new DataCellTypeInfo(TableConsts.DefaultContentCellTypeN, 2);
                    }
                }
            }
            //
            if (LineOfColHeader != null)
            {
                for (int i = 1; i <= QColumns; i++)
                {
                    LineOfColHeaderCells[i - 1] = LineOfColHeader.row[i-1];
                }
            }
            else
            {
                for (int i = 1; i <= QColumns; i++)
                {
                    LineOfColHeaderCells[i - 1] = new DataCellTypeInfo(TableConsts.DefaultLineOfColHeaderCellTypeN, 2);
                }
            }
            //
            if (ColOfLineHeader != null)
            {
                for (int i = 1; i <= QLines; i++)
                {
                    ColOfLineHeaderCells[i - 1] = ColOfLineHeader.row[i - 1];
                }
            }
            else
            {
                for (int i = 1; i <= QLines; i++)
                {
                    ColOfLineHeaderCells[i - 1] = new DataCellTypeInfo(TableConsts.DefaultLineOfColHeaderCellTypeN, 2);
                }
            }
            //
            Set(TblInf, ContentCells, LineOfColHeaderCells, ColOfLineHeaderCells);
        }
        //
        public void Set(TableInfo TblInfExt, int[][] ContentTypes, int[][] ContentLengths, int[] LoCHTypes, int[] LoCHLengths, int[] CoLHTypes, int[] CoLHLengths)
        {
            int TypeN, Length, CellPurpose;
            TableInfo TblInf = new TableInfo();
            if (TblInf.Str == null) TblInf.Str = new TableStructure();
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            //
            SetNullIni();
            //
            this.Content = new DataCellTypeInfo[TblInf.RowsQuantities.QLines][];
            for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
            {
                Content[i - 1] = new DataCellTypeInfo[TblInf.RowsQuantities.QColumns];
            }
            for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
            {
                for (int j = 1; j <= TblInf.RowsQuantities.QColumns; j++)
                {
                    this.Content[i - 1][j - 1] = new DataCellTypeInfo(TableConsts.IntArrayTypeN, 2);
                }
            }
            for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
            {
                for (int j = 1; j <= TblInf.RowsQuantities.QColumns; j++)
                {
                    if (ContentTypes != null) TypeN = ContentTypes[i - 1][j - 1]; else TypeN = TableConsts.DefaultContentCellTypeN;
                    if (ContentLengths != null) Length = ContentLengths[i - 1][j - 1]; else Length = 2;
                    CellPurpose = 1;
                    this.Content[i - 1][j - 1].SetCellTypeInfo(TypeN, Length, CellPurpose);
                }
            }
            //
            if (TblInf.Str.LineOfColHeaderExists)
            {
                this.LineOfColHeader = new DataCellTypeInfo[TblInf.RowsQuantities.QColumns];
                for (int i = 1; i <= TblInf.RowsQuantities.QColumns; i++)
                {
                    this.LineOfColHeader[i - 1] = new DataCellTypeInfo(TableConsts.IntArrayTypeN, 2);
                }
                for (int i = 1; i <= TblInf.RowsQuantities.QColumns; i++)
                {
                    if (LoCHTypes != null) TypeN = LoCHTypes[i - 1]; else TypeN = TableConsts.DefaultLineOfColHeaderCellTypeN;
                    if (LoCHLengths != null) Length = LoCHLengths[i - 1]; else Length = 2;
                    CellPurpose = 2;
                    this.LineOfColHeader[i - 1].SetCellTypeInfo(TypeN, Length, CellPurpose);
                }
            }
            //
            if (TblInf.Str.ColOfLineHeaderExists)
            {
                this.ColOfLineHeader = new DataCellTypeInfo[TblInf.RowsQuantities.QLines];
                for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
                {
                    this.ColOfLineHeader[i - 1] = new DataCellTypeInfo(TableConsts.IntArrayTypeN, 2);
                }
                for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
                {
                    if (CoLHTypes != null) TypeN = CoLHTypes[i - 1]; else TypeN = TableConsts.DefaultColOfLineHeaderCellTypeN;
                    if (CoLHLengths != null) Length = CoLHLengths[i - 1]; else Length = 2;
                    CellPurpose = 3;
                    this.ColOfLineHeader[i - 1].SetCellTypeInfo(TypeN, Length, CellPurpose);
                }
            }
        }
        //
        public void Set(TableInfo TblInfExt, DataCellTypeInfo[][] Content, DataCellTypeInfo[] LineOfColHeader, DataCellTypeInfo[] ColOfLineHeader)
        {
            TableInfo TblInf;
            int TypeN, Length, CellPuppose;
            if (TblInfExt != null) TblInf = TblInfExt; else TblInf = new TableInfo();
            if (TblInf.Str == null) TblInf.Str = new TableStructure();
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            //
            //in C++ here ms'b del[]
            SetNullIni(); //ob C# ne s'C++
            //
            this.Content = new DataCellTypeInfo[TblInf.RowsQuantities.QLines][];
            for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
            {
                this.Content[i - 1] = new DataCellTypeInfo[TblInf.RowsQuantities.QColumns];
            }
            for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
            {
                for (int j = 1; j <= TblInf.RowsQuantities.QColumns; j++)
                {
                    this.Content[i - 1][j - 1] = new DataCellTypeInfo(TableConsts.IntArrayTypeN, 2);
                }
            }
            for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
            {
                for (int j = 1; j <= TblInf.RowsQuantities.QColumns; j++)
                {
                    if (Content != null) this.Content[i - 1][j - 1] = Content[i - 1][j - 1];
                    else
                    {
                        this.Content[i - 1][j - 1].SetCellTypeInfo(TableConsts.DefaultContentCellTypeN, 1, 1);
                    }
                }
            }
            //
            if (TblInf.Str.LineOfColHeaderExists)
            {
                this.LineOfColHeader = new DataCellTypeInfo[TblInf.RowsQuantities.QColumns];
                for (int i = 1; i <= TblInf.RowsQuantities.QColumns; i++)
                {
                    this.LineOfColHeader[i - 1] = new DataCellTypeInfo(TableConsts.IntArrayTypeN, 2);
                }
                for (int i = 1; i <= TblInf.RowsQuantities.QColumns; i++)
                {
                    this.LineOfColHeader[i - 1].SetCellTypeInfo(TableConsts.DefaultLineOfColHeaderCellTypeN, 1, 2);
                }
            }
            //
            if (TblInf.Str.ColOfLineHeaderExists)
            {
                this.ColOfLineHeader = new DataCellTypeInfo[TblInf.RowsQuantities.QLines];
                for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
                {
                    this.ColOfLineHeader[i - 1] = new DataCellTypeInfo(TableConsts.IntArrayTypeN, 2);
                }
                for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
                {
                    this.ColOfLineHeader[i - 1].SetCellTypeInfo(TableConsts.DefaultColOfLineHeaderCellTypeN, 1, 3);
                }
            }
        }
        //
        public void SetColumn(int N, TableInfo TblInfExt, DataCellTypeInfo[] Content, DataCellTypeInfo ColHeader)
        {
            TableInfo TblInf;
            int TypeN = 0, Length = 0, CellPuppose = 0;
            if (TblInfExt != null) TblInf = TblInfExt; else TblInf = new TableInfo();
            if (TblInf.Str == null) TblInf.Str = new TableStructure();
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            //
            if (this.Content == null || (TblInf.Str.LineOfColHeaderExists && this.LineOfColHeader == null) || (TblInf.Str.ColOfLineHeaderExists && this.ColOfLineHeader == null))
            {
                Set(TblInf, null, null, null);
            }
            if (N >= 1 && N < MyLib.MaxInt)
            {
                CellPuppose = 1;
                for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
                {
                    if (Content != null)
                    {
                        Content[i - 1].Get(ref TypeN, ref Length);
                    }
                    else
                    {
                        TypeN = TableConsts.DefaultContentCellTypeN;
                        Length = 2;

                    }
                    this.Content[i - 1][N - 1].SetCellTypeInfo(TypeN, Length, CellPuppose);
                }
                //
                CellPuppose = 2;
                if (TblInf.Str.LineOfColHeaderExists)
                {
                    if (ColHeader != null)
                    {
                        ColHeader.Get(ref TypeN, ref Length);
                    }
                    else
                    {
                        TypeN = TableConsts.DefaultContentCellTypeN;
                        Length = 2;
                        CellPuppose = 1;
                    }
                    this.LineOfColHeader[N - 1].SetCellTypeInfo(TypeN, Length, CellPuppose);
                }
            }//if N
        }
        public void SetColumn_SnglType(int N, TableInfo TblInfExt, DataCellTypeInfo Content, DataCellTypeInfo ColHeader)
        {
            TableInfo TblInf;
            int TypeN = 0, Length = 0, CellPuppose = 0;
            if (TblInfExt != null) TblInf = TblInfExt; else TblInf = new TableInfo();
            if (TblInf.Str == null) TblInf.Str = new TableStructure();
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            //
            if (this.Content == null || (TblInf.Str.LineOfColHeaderExists && this.LineOfColHeader == null) || (TblInf.Str.ColOfLineHeaderExists && this.ColOfLineHeader == null))
            {
                Set(TblInf, null, null, null);
            }
            if (N >= 1 && N < MyLib.MaxInt)
            {
                CellPuppose = 1;
                for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++)
                {
                    if (Content != null)
                    {
                        Content.Get(ref TypeN, ref Length);
                    }
                    else
                    {
                        TypeN = TableConsts.DefaultContentCellTypeN;
                        Length = 2;

                    }
                    this.Content[i - 1][N - 1].SetCellTypeInfo(TypeN, Length, CellPuppose);
                }
                //
                CellPuppose = 2;
                if (TblInf.Str.LineOfColHeaderExists)
                {
                    if (ColHeader != null)
                    {
                        ColHeader.Get(ref TypeN, ref Length);
                    }
                    else
                    {
                        TypeN = TableConsts.DefaultContentCellTypeN;
                        Length = 2;
                        CellPuppose = 1;
                    }
                    this.LineOfColHeader[N - 1].SetCellTypeInfo(TypeN, Length, CellPuppose);
                }
            }//if N
        }
        //
        public void SetLine(int N, TableInfo TblInfExt, DataCellTypeInfo[] Content, DataCellTypeInfo LineHeader)
        {
            TableInfo TblInf;
            int TypeN = 0, Length = 0, CellPuppose = 0;
            if (TblInfExt != null) TblInf = TblInfExt; else TblInf = new TableInfo();
            if (TblInf.Str == null) TblInf.Str = new TableStructure();
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            //
            if (this.Content == null || (TblInf.Str.LineOfColHeaderExists && this.LineOfColHeader == null) || (TblInf.Str.ColOfLineHeaderExists && this.ColOfLineHeader == null))
            {
                Set(TblInf, null, null, null);
            }
            if (N >= 1 && N < MyLib.MaxInt)
            {
                CellPuppose = 1;
                for (int i = 1; i <= TblInf.RowsQuantities.QColumns; i++)
                {
                    if (Content != null)
                    {
                        Content[i - 1].Get(ref TypeN, ref Length);
                    }
                    else
                    {
                        TypeN = TableConsts.DefaultContentCellTypeN;
                        Length = 2;

                    }
                    this.Content[N - 1][i - 1].SetCellTypeInfo(TypeN, Length, CellPuppose);
                }
                //
                CellPuppose = 2;
                if (TblInf.Str.ColOfLineHeaderExists)
                {
                    if (LineHeader != null)
                    {
                        LineHeader.Get(ref TypeN, ref Length);
                    }
                    else
                    {
                        TypeN = TableConsts.DefaultContentCellTypeN;
                        Length = 2;
                        CellPuppose = 1;
                    }
                    this.ColOfLineHeader[N - 1].SetCellTypeInfo(TypeN, Length, CellPuppose);
                }
            }//if N
        }
        public void SetSnglColumn(TableInfo TblInfExt, DataCellTypeInfo[] ColContent, DataCellTypeInfo ColHeader, DataCellTypeInfo[] LineHeaders)
        {
            TableInfo TblInf;
            int TypeN = 0, Length = 0, CellPuppose = 0;
            if (TblInfExt != null) TblInf = TblInfExt; else TblInf = new TableInfo();
            if (TblInf.Str == null) TblInf.Str = new TableStructure();
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            //
            TblInf.RowsQuantities.QColumns = 1;
            //
            Set(TblInf, null, null, LineHeaders);
            SetColumn(1, TblInf, ColContent, ColHeader);
        }
        public void SetSnglColumnSnglType(TableInfo TblInfExt, DataCellTypeInfo ColContent, DataCellTypeInfo ColHeader, DataCellTypeInfo[] LineHeaders)
        {
            TableInfo TblInf;
            int TypeN = 0, Length = 0, CellPuppose = 0;
            if (TblInfExt != null) TblInf = TblInfExt; else TblInf = new TableInfo();
            if (TblInf.Str == null) TblInf.Str = new TableStructure();
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            TblInf.RowsQuantities.QColumns = 1;
            //
            DataCellTypeInfo[] ColContents = new DataCellTypeInfo[TblInf.RowsQuantities.QLines];
            CellPuppose = 1;
            if (ColContent != null) ColContent.Get(ref TypeN, ref Length);
            else
            {
                TypeN = TableConsts.DefaultContentCellTypeN;
                Length = 2;
            }
            for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++) ColContents[i - 1].SetCellTypeInfo(TypeN, Length, CellPuppose);
            //
            Set(TblInf, null, null, LineHeaders);
            SetColumn(1, TblInf, ColContents, ColHeader);
        }
        public void SetSnglLine(TableInfo TblInfExt, DataCellTypeInfo[] LineContent, DataCellTypeInfo LineHeader, DataCellTypeInfo[] ColHeaders)
        {
            TableInfo TblInf;
            int TypeN = 0, Length = 0, CellPuppose = 0;
            if (TblInfExt != null) TblInf = TblInfExt; else TblInf = new TableInfo();
            if (TblInf.Str == null) TblInf.Str = new TableStructure();
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            //
            TblInf.RowsQuantities.QLines = 1;
            //
            Set(TblInf, null, ColHeaders, null);
            SetLine(1, TblInf, LineContent, LineHeader);
        }
        public void SetSnglLineSnglType(TableInfo TblInfExt, DataCellTypeInfo LineContent, DataCellTypeInfo LineHeader, DataCellTypeInfo[] LineHeaders)
        {
            TableInfo TblInf;
            int TypeN = 0, Length = 0, CellPuppose = 0;
            if (TblInfExt != null) TblInf = TblInfExt; else TblInf = new TableInfo();
            if (TblInf.Str == null) TblInf.Str = new TableStructure();
            if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            TblInf.RowsQuantities.QLines = 1;
            //
            DataCellTypeInfo[] LineContents = new DataCellTypeInfo[TblInf.RowsQuantities.QColumns];
            CellPuppose = 1;
            if (LineContent != null) LineContent.Get(ref TypeN, ref Length);
            else
            {
                TypeN = TableConsts.DefaultContentCellTypeN;
                Length = 2;
            }
            for (int i = 1; i <= TblInf.RowsQuantities.QLines; i++) LineContents[i - 1].SetCellTypeInfo(TypeN, Length, CellPuppose);
            //
            Set(TblInf, null, null, LineHeaders);
            SetLine(1, TblInf, LineContents, LineHeader);
        }
        //
        public int GetCellTypeN(int LineN, int ColN)
        {
            int R = 0;
            if (LineN > 0 && ColN > 0)
            {
                if (Content != null) R = Content[LineN - 1][ColN - 1].GetTypeN();
            }
            else if (LineN == 0 && ColN > 0)
            {
                if (LineOfColHeader != null) R = LineOfColHeader[ColN - 1].GetTypeN();
            }
            else if (LineN == 0 && ColN > 0)
            {
                if (LineOfColHeader != null) R = LineOfColHeader[ColN - 1].GetTypeN();
            }
            return R;
        }
        public int GetCellTypeN_LineOfColHeader(int ColN)
        {
            int R = 0;
            R = LineOfColHeader[ColN - 1].GetTypeN();
            return R;
        }
        public int GetCellTypeN_ColOfLineHeader(int LineN)
        {
            int R = 0;
            R = LineOfColHeader[LineN - 1].GetTypeN();
            return R;
        }
        public int GetCellLength(int LineN, int ColN)
        {
            int R = 1;
            if (LineN > 0 && ColN > 0)
            {
                if (Content != null) R = Content[LineN - 1][ColN - 1].GetLength();
            }
            else if (LineN == 0 && ColN > 0)
            {
                if (LineOfColHeader != null) R = LineOfColHeader[ColN - 1].GetLength();
            }
            else if (LineN == 0 && ColN > 0)
            {
                if (LineOfColHeader != null) R = LineOfColHeader[ColN - 1].GetLength();
            }
            return R;
        }
        public int GetCellLength_LineOfColHeader(int ColN)
        {
            int R = 1;
            if (Content != null) R = LineOfColHeader[ColN - 1].GetLength();
            return R;
        }
        public int GetCellLength_ColOfLineHeader(int LineN)
        {
            int R = 1;
            if (Content != null) R = ColOfLineHeader[LineN - 1].GetLength();
            return R;
        }
        public DataCell GetCellTypeAndLength(int LineN, int ColN)
        {
            DataCell R = null;
            int TypeN = 0, Length = 1;
            if (Content != null) R = Content[LineN - 1][ColN - 1].GetData();
            return R;
        }
    }//cl
}//ns
