using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    public class TableGeneralRepresentation:ICloneable //cl 10 
    {
        public bool ShowColOfLineHeader, ShowLineOfColHeader;
        public bool ShowTableNameInCorner, ShowTableNameInButons, ShowRowsGenNamesInButtons, ShowRowsGenNamesInCorner;
        public int LRecom, Len_NoLim0RecomVal1GenMaxLen2MaxByCol3;
        public int CoLHNumerationStartFromN, LoCHNumerationStartFromN;
        //
        public TableGeneralRepresentation()
        {
            ShowColOfLineHeader = true; ShowLineOfColHeader = true;
            LRecom = 6; Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 0;
            CoLHNumerationStartFromN = 1;
            LoCHNumerationStartFromN = 1;
            ShowTableNameInCorner = false; ShowTableNameInButons = false; ShowRowsGenNamesInButtons = true; ShowRowsGenNamesInCorner = true;
        }
        public object Clone() { return this.MemberwiseClone(); }
        public int GetLength()
        {
            int L = 0;
            if (Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 == 1) L = LRecom;
            return L;
        }
        public void Set_Matrix()
        {
            ShowColOfLineHeader = true; ShowLineOfColHeader = true;
            LRecom = 5;
            //Len_NoLim0RecomVal1GenMaxLen2MaxByCol3=3;
            Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 0;
            ShowTableNameInCorner = true;
            ShowTableNameInButons = false; ShowRowsGenNamesInButtons = false;
            ShowRowsGenNamesInCorner = true; //it hasn't them // id ne hab't em
        }
        public void Set_List()
        {
            ShowColOfLineHeader = true; ShowLineOfColHeader = true;
            LRecom = 5;
            //Len_NoLim0RecomVal1GenMaxLen2MaxByCol3=3;
            Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 0;
            ShowTableNameInCorner = true;
            ShowTableNameInButons = false; ShowRowsGenNamesInButtons = true; ShowRowsGenNamesInCorner = true;
        }
        public void Set_Simple()
        {
            ShowColOfLineHeader = true; ShowLineOfColHeader = true;
            LRecom = 5;
            //Len_NoLim0RecomVal1GenMaxLen2MaxByCol3=3;
            Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 0;
            ShowTableNameInCorner = false;
            ShowTableNameInButons = false; ShowRowsGenNamesInButtons = false; ShowRowsGenNamesInCorner = true;
        }
        public void Set_2ArgsFn()
        {
            ShowColOfLineHeader=true;//auto
            ShowLineOfColHeader = true; //auto
            ShowTableNameInCorner = true;

        }
        public TTable GetAsTable()
        {
            TTable tbl;
            bool LC_not_CL=true, CoLHExists=true, LoCHExists=true;
            int QLines=10, CountLines=0, QColumns=1;
            string TableName="Table general Representation",
                   LinesGeneralName="Params", 
                   ColsGenName="",
                   SingleColName="Values";
            DataCellRowCoHeader CurLineWithHeader;
            DataCellRowCoHeader[] rows;
            //
            DataCellRow LoCH;
            DataCell CurCell;
            TableHeaders Headers;
            //
            DataCell ACell;
            string []Items;
            //
            LoCH = new DataCellRow("Values");
            Headers = new TableHeaders(new DataCell(TableName), new DataCell(LinesGeneralName), new DataCell(ColsGenName)); 
            //
            CountLines=1;
            CurLineWithHeader=new DataCellRowCoHeader(new DataCell("Show CoLH"), new DataCellRow(ShowColOfLineHeader));
            rows=new DataCellRowCoHeader[1];
            rows[1-1]=CurLineWithHeader;
            //tbl=new TTable(
            //    new TableInfo(LC_not_CL, true, true, CountLines, QColumns),
            //    false,
            //    rows,
            //    new DataCellRow("Values"),
            //    new TableHeaders(new DataCell(TableName), new DataCell(LinesGeneralName), new DataCell(ColsGenName)),
            //    true
            //);
            //public TTable(TableInfo TblInfNewExt, bool ByColumnsNotLines, DataCellRowCoHeader[] rows, DataCellRow HeaderRow, TableHeaders Headers, bool WriteInfo)
            tbl = new TTable(
                new TableInfo(LC_not_CL, true, true, CountLines, QColumns),
                false,
                rows,
                LoCH,//new DataCellRow("Values", 1),
                Headers,//new TableHeaders(new DataCell(TableName), new DataCell(LinesGeneralName), new DataCell(ColsGenName)),
                true
            );
            //
            CurLineWithHeader = new DataCellRowCoHeader(new DataCell("Show LoCH"), new DataCellRow(ShowLineOfColHeader));
            tbl.AddLine(CurLineWithHeader); //2
            Items = new string[] { "No", "Yes" };
            ACell = new DataCell(Items, 2);
            CurLineWithHeader = new DataCellRowCoHeader(new DataCell("Show TName in Corner"), new DataCellRow(ACell));
            tbl.AddLine(CurLineWithHeader); //3
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("Show TName in Buttons"), new DataCellRow(ShowTableNameInButons)));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("Show GenNames in Buttons"), new DataCellRow(ShowRowsGenNamesInButtons)));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("Show GenNames in Corner"), new DataCellRow(ShowRowsGenNamesInCorner)));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("LRecom"), new DataCellRow(LRecom)));
            Items=new string[]{"No", "RecomVal", "GenMaxLen", "MaxByCol"};
            ACell=new DataCell(Items,4);
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("Length as"), new DataCellRow(ACell, 1)));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("CN from"), new DataCellRow(CoLHNumerationStartFromN)));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("LN from"), new DataCellRow(LoCHNumerationStartFromN)));
            //
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetTableUssagePolicy(UsePol);
            //
            return tbl;
        }//fn
        public void SetFromTable(TTable tbl)
        {
            //TTable tbl;
            //bool LC_not_CL = true, CoLHExists = true, LoCHExists = true;
            //int QLines = 10, CountLines = 0, QColumns = 1;
            //string TableName = "Table general Representation",
            //       LinesGeneralName = "Params",
            //       ColsGenName = "",
            //       SingleColName = "Values";
            //DataCellRowCoHeader CurLineWithHeader;
            //DataCellRowCoHeader[] rows;
            ////
            //DataCellRow LoCH;
            //DataCell CurCell;
            //TableHeaders Headers;
            ////
            //DataCell ACell;
            //string[] Items;
            ////
            //LoCH = new DataCellRow("Values");
            //Headers = new TableHeaders(new DataCell(TableName), new DataCell(LinesGeneralName), new DataCell(ColsGenName));
            ////
            //CountLines = 1;
            //CurLineWithHeader = new DataCellRowCoHeader(new DataCell("Show CoLH"), new DataCellRow(ShowColOfLineHeader));
            ShowColOfLineHeader = tbl.GetBoolVal(1, 1);
            //rows = new DataCellRowCoHeader[1];
            //rows[1 - 1] = CurLineWithHeader;
            //tbl=new TTable(
            //    new TableInfo(LC_not_CL, true, true, CountLines, QColumns),
            //    false,
            //    rows,
            //    new DataCellRow("Values"),
            //    new TableHeaders(new DataCell(TableName), new DataCell(LinesGeneralName), new DataCell(ColsGenName)),
            //    true
            //);
            //public TTable(TableInfo TblInfNewExt, bool ByColumnsNotLines, DataCellRowCoHeader[] rows, DataCellRow HeaderRow, TableHeaders Headers, bool WriteInfo)
            //tbl = new TTable(
            //    new TableInfo(LC_not_CL, true, true, CountLines, QColumns),
            //    false,
            //    rows,
            //    LoCH,//new DataCellRow("Values", 1),
            //    Headers,//new TableHeaders(new DataCell(TableName), new DataCell(LinesGeneralName), new DataCell(ColsGenName)),
            //    true
            //);
            //
            //CurLineWithHeader = new DataCellRowCoHeader(new DataCell("Show LoCH"), new DataCellRow(ShowLineOfColHeader));
            //tbl.AddLine(CurLineWithHeader); //2
            ShowLineOfColHeader = tbl.GetBoolVal(2, 1);
            //Items = new string[] { "No", "Yes" };
            //ACell = new DataCell(Items, 2);
            //CurLineWithHeader = new DataCellRowCoHeader(new DataCell("Show TName in Corner"), new DataCellRow(ACell));
            //tbl.AddLine(CurLineWithHeader); //3
            ShowTableNameInCorner = tbl.GetBoolVal(3, 1);
            //tbl.AddLine(new DataCellRowCoHeader(new DataCell("Show TName in Buttons"), new DataCellRow(ShowTableNameInButons)));
            ShowTableNameInButons = tbl.GetBoolVal(4, 1);
            //tbl.AddLine(new DataCellRowCoHeader(new DataCell("Show GenNames in Buttons"), new DataCellRow(ShowRowsGenNamesInButtons)));
            ShowRowsGenNamesInButtons = tbl.GetBoolVal(5, 1);
            //tbl.AddLine(new DataCellRowCoHeader(new DataCell("Show GenNames in Corner"), new DataCellRow(ShowRowsGenNamesInCorner)));
            ShowRowsGenNamesInCorner = tbl.GetBoolVal(6, 1);
            //tbl.AddLine(new DataCellRowCoHeader(new DataCell("LRecom"), new DataCellRow(LRecom)));
            LRecom = tbl.GetIntVal(7, 1);
            //Items = new string[] { "No", "RecomVal", "GenMaxLen", "MaxByCol" };
            //ACell = new DataCell(Items, 4);
            //tbl.AddLine(new DataCellRowCoHeader(new DataCell("Length as"), new DataCellRow(ACell, 1)));
            if (tbl.GetTypeN(8, 1) == TableConsts.StringArrayTypeN)
            {
                Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = tbl.GetActiveN(8, 1);
            }
            else
            {
                Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = tbl.GetIntVal(8, 1);
            }
            //tbl.AddLine(new DataCellRowCoHeader(new DataCell("CN from"), new DataCellRow(CoLHNumerationStartFromN)));
            CoLHNumerationStartFromN = tbl.GetIntVal(9, 1);
            //tbl.AddLine(new DataCellRowCoHeader(new DataCell("LN from"), new DataCellRow(LoCHNumerationStartFromN)));
            LoCHNumerationStartFromN = tbl.GetIntVal(10, 1);
            //return tbl;
        }//fn
    } //cl 10 TableGeneralRepresentation
    public class TableHeaderCellRepresentation:ICloneable //cl 11
    {
        public bool RowName;
        public bool InBrackets;
        public int Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7;
        public int BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8;
        public bool GenRowNameBef, RowNBef;//, RowNameBef;
        public bool GenRowNameAft, RowNAft;//, RowNameAft;
        public int AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8;
        public int Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8;
        //
        public int BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7,
                   AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7;
        //
        public int Align_L1CL2CR3R4Excel5, CountHidden;
        //public int NumerationStartFromN;
        public TableHeaderCellRepresentation()
        {
            RowName = true;
            GenRowNameBef = true; RowNBef = true; //RowNameBef=true;
            GenRowNameAft = false; RowNAft = false; //RowNameAft=false;
            BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8 = 0;
            AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8 = 0;
            InBrackets = false;
            Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = 0;
            Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 0;
            BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;
            AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7=0;
            //
            Align_L1CL2CR3R4Excel5 = 1;
            CountHidden = 0;
        }
        public object Clone() { return this.MemberwiseClone(); }
        //public void Set_Matrix()
        //{
        //    RowName = false;
        //    GenRowNameBef = false;
        //    RowNBef = true; //RowNameBef=true;
        //    GenRowNameAft = false; RowNAft = false; //RowNameAft=false;
        //    BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8 = 0;
        //    AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8 = 0;
        //    InBrackets = false;
        //    Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = 0;
        //    Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 0;
        //    //
        //    BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;
        //    AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;
        //    //NumerationStartFromN = 1;
        //    //
        //    Align_L1CL2CR3R4Excel5 = 1;
        //    CountHidden = 0;
        //}
        public void Set_Matrix()
        {
            BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8 = 0;
            AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8 = 0;
            //
            BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;
            AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;// 5;
            //
            Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = 0;
            InBrackets = false; //for content=true
            GenRowNameBef = false; //by 2Arg|Fn it is true
            RowNBef = true;//true;
            //
            RowName = false; //or true - S'leer
            //
            GenRowNameAft = false;
            RowNAft = false;
            Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 0;
        }
        public void Set_List()
        {
            RowName = true;
            GenRowNameBef = false;
            RowNBef = true; //RowNameBef=true;
            GenRowNameAft = false; RowNAft = false; //RowNameAft=false;
            BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8 = 0;
            AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8 = 0;
            InBrackets = false;
            Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = 0;
            Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 0;
            //
            BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;
            AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;
            //NumerationStartFromN = 1;
            //
            Align_L1CL2CR3R4Excel5 = 1;
            CountHidden = 0;
        }
        public void Set_Simple()
        {
            RowName = true;
            GenRowNameBef = false;
            RowNBef = false; //RowNameBef=true;
            GenRowNameAft = false; RowNAft = false; //RowNameAft=false;
            BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8 = 0;
            AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8 = 0;
            InBrackets = false;
            Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = 0;
            Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 0;
            //
            BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;
            AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;
            //NumerationStartFromN = 1;
            //
            Align_L1CL2CR3R4Excel5 = 1;
            CountHidden = 0;
        }
        public void Set_SimpleNumerated()
        {
            RowName = true; //or false. It isBefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8 = 8;
            AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8 = 8;
            //
            BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;
            AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 5;
            //
            Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = 0;
            InBrackets = false; //for content=true
            GenRowNameBef = true;
            RowNBef = false;//true;//, RowNameBef;
            //
            RowName = true;
            //
            GenRowNameAft = false;
            RowNAft = false;//, RowNameAft;
            Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 0;
            GenRowNameBef = false;
            RowNBef = true;//RowNameBef=true;
            GenRowNameAft = false; RowNAft = false; //RowNameAft=false;
            BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8 = 0;
            AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8 = 1;
            InBrackets = false;
            Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = 0;
            Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 0;
            //
            BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;
            AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;
            //NumerationStartFromN = 1;
            //
            Align_L1CL2CR3R4Excel5 = 1;
            CountHidden = 0;
        }
        public void Set_2ArgsFn()
        {
            BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8 = 8;
            AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8 = 8;
            //
            BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;
            AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 5;
            //
            Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = 0;
            InBrackets=false; //for content=true
            GenRowNameBef=true;
            RowNBef=false;//true;//, RowNameBef;
            //
            RowName = true;
            //
            GenRowNameAft = false;
            RowNAft=false;//, RowNameAft;
            Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 0;
            //
            //RowName = true;
            //GenRowNameBef = true;
            //RowNAft = true;
            //Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 0;
        }
        public TTable GetAsTable(string TableName="Header Cell Representation")
        {
            string[] ss=null;
            TableInfo TblInf = new TableInfo(true, true, true, 12, 1);
            DataCellRow ColHeader = new DataCellRow("Values", 1);
            DataCellRowCoHeader[] lines=new DataCellRowCoHeader[12];
            TableHeaders Headers = new TableHeaders(new DataCell(TableName), new DataCell("Params"), new DataCell("")); 
            ss=new string[]{"None", "N", "NCol", "ColN", "Col", "NLine", "LineN", "Line", "="};
            lines[1 - 1] = new DataCellRowCoHeader(new DataCell("Before Nr"), new DataCellRow(new DataCell(ss,9),1));
            ss = new string[] { ")", "th", "th Line", "th Col", ":", "-", ",", "="};
            lines[2 - 1] = new DataCellRowCoHeader(new DataCell("After Nr"), new DataCellRow(new DataCell(ss, 8), 1));
            ss = new string[] { "None", "Space", ",", ":", ";", "=", "-", "," };
            lines[3 - 1] = new DataCellRowCoHeader(new DataCell("Before GenRowName"), new DataCellRow(new DataCell(ss, 8), 1));
            //ss = new string[] { "No", "Space", ",", ":", ";", "=", "-", "," };
            lines[4 - 1] = new DataCellRowCoHeader(new DataCell("After GenRowName"), new DataCellRow(new DataCell(ss, 8), 1));
            ss = new string[] { "None", "-", ":", ",", "=", "Row", "Line", "Col" };
            lines[5 - 1] = new DataCellRowCoHeader(new DataCell("Before"), new DataCellRow(new DataCell(ss, 8), 1));
            //ss = new string[] { "No", "-", ":", ",", "=", "Row", "Line", "Col" };
            lines[6 - 1] = new DataCellRowCoHeader(new DataCell("InBrackets"), new DataCellRow(InBrackets, 1));
            //ss = new string[] { "No", "-", ":", ",", "=", "Row", "Line", "Col" };
            lines[7 - 1] = new DataCellRowCoHeader(new DataCell("GenRowNameBef"), new DataCellRow(GenRowNameBef, 1));
            lines[8 - 1] = new DataCellRowCoHeader(new DataCell("RowNBef"), new DataCellRow(RowNBef, 1));
            lines[9 - 1] = new DataCellRowCoHeader(new DataCell("RowName"), new DataCellRow(RowName, 1));
            lines[10 - 1] = new DataCellRowCoHeader(new DataCell("GenRowNameAft"), new DataCellRow(GenRowNameAft, 1));
            lines[11 - 1] = new DataCellRowCoHeader(new DataCell("RowNAft"), new DataCellRow(RowNAft, 1));
            ss = new string[] { "None", "-", ":", ",", "=", ")", "Row", "Line", "Col" };
            lines[12 - 1] = new DataCellRowCoHeader(new DataCell("After"), new DataCellRow(new DataCell(ss, 9), 1));
            TTable tbl = new TTable(TblInf, false, lines, ColHeader, Headers, true);
            //
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetTableUssagePolicy(UsePol);
            //
            return tbl;
        }
        public void SetFromTable(TTable tbl)
        {
            //string[] ss = null;
            //TableInfo TblInf = new TableInfo(true, true, true, 12, 1);
            //DataCellRow ColHeader = new DataCellRow("Values", 1);
            //DataCellRowCoHeader[] lines = new DataCellRowCoHeader[12];
            //TableHeaders Headers = new TableHeaders(new DataCell(TableName), new DataCell("Params"), new DataCell(""));
            //ss = new string[] { "No", "N", "NCol", "ColN", "Col", "NLine", "LineN", "Line", "=" };
            //lines[1 - 1] = new DataCellRowCoHeader(new DataCell("Before Nr"), new DataCellRow(new DataCell(ss, 9), 1));
            if (tbl.GetTypeN(1, 1) == TableConsts.StringArrayTypeN) Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = tbl.GetActiveN(1, 1);
            else  Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = tbl.GetIntVal(1, 1);
            //ss = new string[] { ")", "th", "th Line", "th Col", ":", "-", ",", "=" };
            //lines[2 - 1] = new DataCellRowCoHeader(new DataCell("After Nr"), new DataCellRow(new DataCell(ss, 8), 1));
            if (tbl.GetTypeN(2, 1) == TableConsts.StringArrayTypeN) AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8 = tbl.GetActiveN(2, 1);
            else AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8 = tbl.GetIntVal(2, 1);
            //ss = new string[] { "No", "Space", ",", ":", ";", "=", "-", "," };
            //lines[3 - 1] = new DataCellRowCoHeader(new DataCell("Before GenRowName"), new DataCellRow(new DataCell(ss, 8), 1));
            if (tbl.GetTypeN(1, 1) == TableConsts.StringArrayTypeN) BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = tbl.GetActiveN(3, 1);
            else BefGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = tbl.GetIntVal(3, 1);
            //ss = new string[] { "No", "Space", ",", ":", ";", "=", "-", "," };
            //lines[4 - 1] = new DataCellRowCoHeader(new DataCell("After GenRowName"), new DataCellRow(new DataCell(ss, 8), 1));
            if (tbl.GetTypeN(1, 1) == TableConsts.StringArrayTypeN) AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = tbl.GetActiveN(4, 1);
            else AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = tbl.GetIntVal(4, 1);
            //ss = new string[] { "No", "-", ":", ",", "=", "Row", "Line", "Col" };
            //lines[5 - 1] = new DataCellRowCoHeader(new DataCell("Before"), new DataCellRow(new DataCell(ss, 8), 1));
            if (tbl.GetTypeN(1, 1) == TableConsts.StringArrayTypeN) Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = tbl.GetActiveN(5, 1);
            else Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = tbl.GetIntVal(5, 1);
            //ss = new string[] { "No", "-", ":", ",", "=", "Row", "Line", "Col" };
            //lines[6 - 1] = new DataCellRowCoHeader(new DataCell("InBrackets"), new DataCellRow(InBrackets, 1));
            InBrackets = tbl.GetBoolVal(6, 1);
            //ss = new string[] { "No", "-", ":", ",", "=", "Row", "Line", "Col" };
            //lines[7 - 1] = new DataCellRowCoHeader(new DataCell("GenRowNameBef"), new DataCellRow(GenRowNameBef, 1));
            GenRowNameBef = tbl.GetBoolVal(7, 1);
            //lines[8 - 1] = new DataCellRowCoHeader(new DataCell("RowNBef"), new DataCellRow(RowNBef, 1));
            RowNBef = tbl.GetBoolVal(8, 1);
            //lines[9 - 1] = new DataCellRowCoHeader(new DataCell("RowName"), new DataCellRow(RowName, 1));
            RowName = tbl.GetBoolVal(9, 1);
            //lines[10 - 1] = new DataCellRowCoHeader(new DataCell("GenRowNameAft"), new DataCellRow(GenRowNameAft, 1));
            GenRowNameAft = tbl.GetBoolVal(10, 1);
            //lines[11 - 1] = new DataCellRowCoHeader(new DataCell("RowNAft"), new DataCellRow(RowNAft, 1));
            RowNAft = tbl.GetBoolVal(11, 1);
            //ss = new string[] { "No", "-", ":", ",", "=", ")", "Row", "Line", "Col" };
            //lines[12 - 1] = new DataCellRowCoHeader(new DataCell("After"), new DataCellRow(new DataCell(ss, 9), 1));
            if (tbl.GetTypeN(12, 1) == TableConsts.StringArrayTypeN) Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = tbl.GetActiveN(12, 1);
            else Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = tbl.GetIntVal(12, 1);
            //TTable tbl = new TTable(TblInf, false, lines, ColHeader, Headers, true);
            //return tbl;
        }
    } //cl 11  TableHeaderCellRepresentation
    public class TableContentCellRepresentation:ICloneable //cl 12 
    {
        //THeaderCellRepresentation LineHeaderBef, ColHeaderBef, LineHeaderAft, ColHeaderAft;
        public TableHeaderCellRepresentation LineHeader, ColHeader;
        public bool /*LineHeaderExists, ColHeaderExists,*/ LineHeaderExists, ColHeaderExists, TableHeaderExists, HeadersAreBefNotAft, LH_IsBefNotAft_CH;
        //public bool LineHeaderBefExists, ColHeaderBefExists, LineHeaderAftExists, ColHeaderAftExists;
        //public bool Bef_LH_IsBef_CH, Aft_LH_IsBef_CH; 
        public bool HeadersInBrackets;
        public int HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6;
        //
        public int Align_L1CL2CR3R4Excel5, CountHidden;
        //
        public TableContentCellRepresentation()
        {
            LineHeader = new TableHeaderCellRepresentation();
            ColHeader = new TableHeaderCellRepresentation();
            LineHeaderExists = true;
            ColHeaderExists = true;
            TableHeaderExists = false;
            HeadersAreBefNotAft = true;
            LH_IsBefNotAft_CH = true;
            HeadersInBrackets = false;
            HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6 = 1;
            //
            Align_L1CL2CR3R4Excel5 = 1;
            CountHidden = 0;
        }
        public object Clone()
        {
            TableHeaderCellRepresentation LineHeader=null;// = new TableHeaderCellRepresentation();
            TableHeaderCellRepresentation ColHeader;// = new TableHeaderCellRepresentation();
            TableContentCellRepresentation newObj = new TableContentCellRepresentation();
            if (this.ColHeader != null) ColHeader = (TableHeaderCellRepresentation)this.ColHeader.Clone();
            if (this.LineHeader != null) LineHeader = (TableHeaderCellRepresentation)this.LineHeader.Clone();
            newObj.Align_L1CL2CR3R4Excel5 = this.Align_L1CL2CR3R4Excel5;
            newObj.CountHidden = this.CountHidden;
            newObj.HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6 = this.HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6;
            newObj.HeadersAreBefNotAft = this.HeadersAreBefNotAft;
            newObj.HeadersInBrackets = this.HeadersInBrackets;
            newObj.LH_IsBefNotAft_CH = this.LH_IsBefNotAft_CH;
            newObj.LineHeaderExists = this.LineHeaderExists;
            newObj.TableHeaderExists = this.TableHeaderExists;
            newObj.ColHeaderExists = this.ColHeaderExists;
            newObj.ColHeader = this.ColHeader;
            newObj.LineHeader = this.LineHeader;
            return newObj;
        }
        public bool GetIfHeaderExists()
        {
            return (LineHeaderExists || ColHeaderExists || TableHeaderExists);
        }
        //public void Set_Matrix()
        //{
        //    LineHeader.Set_Matrix();
        //    ColHeader.Set_Matrix();
        //    HeadersInBrackets = true;
        //    HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6 = 6;
        //    LineHeaderExists = true;
        //    ColHeaderExists = true;
        //    TableHeaderExists = true;
        //    HeadersAreBefNotAft = true;
        //    LH_IsBefNotAft_CH = true;
        //    HeadersInBrackets = true;
        //    //
        //    Align_L1CL2CR3R4Excel5 = 1;
        //    CountHidden = 0;
        //}
        public void Set_Matrix()
        {
            if (LineHeader == null) LineHeader = new TableHeaderCellRepresentation();
            LineHeader.Set_Matrix();
            //
            if (ColHeader == null) ColHeader = new TableHeaderCellRepresentation();
            ColHeader.Set_Matrix();
            //
            this.HeadersInBrackets = true;
            //this.;
            HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6 = 6;//not 2 as wa
            HeadersAreBefNotAft = true;
            LH_IsBefNotAft_CH = true; //or can b vv;
            TableHeaderExists = true; //ob ce s'fn
            LineHeaderExists = true;
            ColHeaderExists = true; 
        }
        public void Set_List()
        {
            //
            //LineHeader
            LineHeader.InBrackets = false;
            LineHeader.RowName = true;
            LineHeader.GenRowNameBef = true;
            LineHeader.RowNBef = true;
            LineHeader.RowNAft = false;
            LineHeader.GenRowNameAft = false;
            LineHeader.Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = 0;
            LineHeader.BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8 = 0;
            LineHeader.AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8 = 1;
            LineHeader.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 2;
            //
            //ColHeader
            LineHeader.InBrackets = false;
            LineHeader.RowName = true;
            LineHeader.GenRowNameBef = false;
            LineHeader.RowNBef = true;
            LineHeader.RowNAft = false;
            LineHeader.GenRowNameAft = false;
            LineHeader.Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = 0;
            LineHeader.BefNr_Nil0_NBef1_NColBef2_ColNBef3_ColBef4_NLineBef5_LineNBef6_LineBef7_EqSgn8 = 0;
            LineHeader.AftNr_Nil0_Brkt1_th2_thLine3_thCol4_Colon5_Minus6_Comma7_EqSgn8 = 1;
            LineHeader.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 2;
            //
            HeadersInBrackets = false;
            HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6 = 3;
            LineHeaderExists = true;
            ColHeaderExists = true;
            TableHeaderExists = false;
            HeadersAreBefNotAft = true;
            LH_IsBefNotAft_CH = true;
            HeadersInBrackets = false;
            //
            Align_L1CL2CR3R4Excel5 = 1;
            CountHidden = 0;
        }
        public void Set_Simple()
        {
            LineHeader.Set_Simple();
            ColHeader.Set_Simple();
            //Len_NoLim0RecomVal1GenMaxLen2MaxByCol3=3;
            HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6 = 0;
            LineHeaderExists = false;
            ColHeaderExists = false;
            TableHeaderExists = false;
            HeadersAreBefNotAft = true;
            LH_IsBefNotAft_CH = true;
            HeadersInBrackets = false;
            //
            Align_L1CL2CR3R4Excel5 = 1;
            CountHidden = 0;
        }
        public void Set_SimpleNumerated()
        {
            Set_Simple(); //for content cell it is so, numeratuion is for header rows only
        }
        public void Set_2ArgsFn()
        {
            if (LineHeader == null) LineHeader = new TableHeaderCellRepresentation();
            LineHeader.Set_2ArgsFn();
            //
            if (ColHeader == null) ColHeader = new TableHeaderCellRepresentation();
            ColHeader.Set_2ArgsFn();
            //
            this.HeadersInBrackets = true;
            //this.;
            HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6 = 6;//not 2 as wa
            HeadersAreBefNotAft = true;
            LH_IsBefNotAft_CH = true; //or can b vv;
            TableHeaderExists = true; //ob ce s'fn
            LineHeaderExists = true;
            ColHeaderExists = true; 
        }
        public TTable GetMainAsTable()
        {
            string[] ss = new string[] { "Left","LeftCenter","RightCenter", "Right","AsInExcel"};
            DataCellRowCoHeader[] row = new DataCellRowCoHeader[1];
            row[1 - 1] = new DataCellRowCoHeader(new DataCell("LineHeaderExists"), new DataCellRow(new DataCell(LineHeaderExists)));
            TTable tbl = new TTable(
                new TableInfo(true, true, true, 1, 1),
                false,
                row,
                new DataCellRow(new DataCell("Values")),
                new TableHeaders(new DataCell("ContentRepr"), new DataCell("Params"), new DataCell("")),
                true
            );
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("ColHeaderExists"), new DataCellRow(new DataCell(ColHeaderExists))));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("TableHeaderExists"), new DataCellRow(new DataCell(TableHeaderExists))));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("HeadersAreBefNotAft"), new DataCellRow(new DataCell(HeadersAreBefNotAft))));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("LH_IsBefNotAft_CH"), new DataCellRow(new DataCell(LH_IsBefNotAft_CH))));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("HeadersInBrackets"), new DataCellRow(new DataCell(HeadersInBrackets))));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("HeadersInBrackets"), new DataCellRow(new DataCell(HeadersInBrackets))));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("Align"), new DataCellRow(new DataCell(ss, 5))));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("CountHidden"), new DataCellRow(new DataCell(CountHidden))));
            //
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetTableUssagePolicy(UsePol);
            //   
            return tbl;
        }
        public TTable GetColHeaderReprAsTable()
        {
            TTable tbl=null;
            if (this.ColHeader != null) tbl = this.ColHeader.GetAsTable();
            return tbl;
        }
        public TTable GetLineHeaderReprAsTable()
        {
            TTable tbl = null;
            if (this.LineHeader != null) tbl = this.LineHeader.GetAsTable();
            return tbl;
        }
        public void SetMainPartFromTable(TTable tbl)
        {
            LineHeader = new TableHeaderCellRepresentation();
            ColHeader = new TableHeaderCellRepresentation();
            LineHeaderExists = tbl.GetBoolVal(1,1);
            ColHeaderExists = tbl.GetBoolVal(2, 1);
            TableHeaderExists = false;
            HeadersAreBefNotAft = true;
            LH_IsBefNotAft_CH = true;
            HeadersInBrackets = false;
            HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6 = 1;
            //
            Align_L1CL2CR3R4Excel5 = 1;
            CountHidden = 0;
        }
        public void SetLineHeaderFromTable(TTable tbl)
        {
            if (tbl != null) this.LineHeader = new TableHeaderCellRepresentation();
            this.LineHeader.SetFromTable(tbl);
        }
        public void SetColHeaderFromTable(TTable tbl)
        {
            if (tbl != null) this.ColHeader = new TableHeaderCellRepresentation();
            this.ColHeader.SetFromTable(tbl);
        }
        public void SetCo_ColHdr(){
            //LineHeader = new TableHeaderCellRepresentation();
            //ColHeader = new TableHeaderCellRepresentation();
            LineHeaderExists = false;
            ColHeaderExists = true;
            TableHeaderExists = false;
            HeadersAreBefNotAft = true;
            LH_IsBefNotAft_CH = true;
            HeadersInBrackets = false;
            HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6 = 3;
            //
            //Align_L1CL2CR3R4Excel5 = 1;
            //CountHidden = 0;
        }
        public void SetCo_LineHdr(){
            //LineHeader = new TableHeaderCellRepresentation();
            //ColHeader = new TableHeaderCellRepresentation();
            LineHeaderExists = true;
            ColHeaderExists = false;
            TableHeaderExists = false;
            HeadersAreBefNotAft = true;
            LH_IsBefNotAft_CH = true;
            HeadersInBrackets = false;
            HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6 = 3;
            //
            //Align_L1CL2CR3R4Excel5 = 1;
            //CountHidden = 0;
        }
        public void SetCo_ColHdrAndItsN(){
            SetCo_ColHdr();
        }
        public void SetCo_LineHdrAndItsN(){
            SetCo_LineHdr();
        }
        public void SetCo_BothHdrsLEtH_EtNs_As2ArgFn() {
            Set_2ArgsFn();
        }
    } //cl 12 TableContentCellRepresentation
    public class TableRepresentation : ICloneable //cl 13 
    {
        public TableGeneralRepresentation GenRepr;
        public TableHeaderCellRepresentation LineHeaderRepr, ColHeaderRepr;
        public TableContentCellRepresentation ContentRepr;
        //
        public TableRepresentation()
        {
            ContentRepr = new TableContentCellRepresentation(); ;
            LineHeaderRepr = new TableHeaderCellRepresentation();
            ColHeaderRepr = new TableHeaderCellRepresentation();
            GenRepr = new TableGeneralRepresentation();
        }
        public TableRepresentation(int Content_Null0Default1)
        {
            if (Content_Null0Default1 == 0)
            {
                ContentRepr = null;
                LineHeaderRepr = null;
                ColHeaderRepr = null;
                GenRepr = null;
            }
            if (Content_Null0Default1 == 1)
            {
                ContentRepr = new TableContentCellRepresentation(); ;
                LineHeaderRepr = new TableHeaderCellRepresentation();
                ColHeaderRepr = new TableHeaderCellRepresentation();
                GenRepr = new TableGeneralRepresentation();
            }
        }
        public TableRepresentation(TableGeneralRepresentation GenRepr, TableHeaderCellRepresentation LineHeaderRepr, TableHeaderCellRepresentation ColHeaderRepr, TableContentCellRepresentation ContentRepr)
        {
            this.GenRepr = GenRepr;
            this.LineHeaderRepr = LineHeaderRepr;
            this.ColHeaderRepr = ColHeaderRepr;
            this.ContentRepr = ContentRepr;
        }
        public object Clone()
        {
            return new TableRepresentation(this.GenRepr, this.LineHeaderRepr, this.ColHeaderRepr, this.ContentRepr);
        }
        //
        public void SetGenReprNull()
        {
            GenRepr = null;
        }
        public void SetContentReprNull()
        {
            ContentRepr = null;
        }
        public void SetColHeaderReprNull()
        {
            ColHeaderRepr = null;
        }
        public void SetLineHeaderReprNull()
        {
            LineHeaderRepr = null;
        }
        public void SetNull()
        {
            ContentRepr = null;
            LineHeaderRepr = null;
            ColHeaderRepr = null;
            GenRepr = null;
        }
        //
        public void SetGenReprDefault()
        {
            this.GenRepr = new TableGeneralRepresentation();
        }
        public void SetLineHeaderReprDefault()
        {
            this.LineHeaderRepr = new TableHeaderCellRepresentation();
        }
        public void SetColumnHeaderReprDefault()
        {
            this.ColHeaderRepr = new TableHeaderCellRepresentation();
        }
        public void CreateContentByDefault()
        {
            ContentRepr = new TableContentCellRepresentation();
        }
        //
        public void SetColHeaderByExistanceByDefault(int ColHeaderExists_No0Yes1)
        {
            if (ColHeaderExists_No0Yes1 != 0)
            {
                ColHeaderRepr = new TableHeaderCellRepresentation();
                if (ContentRepr.ColHeader != null) ContentRepr.ColHeader = new TableHeaderCellRepresentation();
            }
            else
            {
                ColHeaderRepr = null;
                ContentRepr.ColHeader = null;
            }
        }
        public void SetLineHeaderByExistanceByDefault(int LineHeaderExists_No0Yes1)
        {
            if (LineHeaderExists_No0Yes1 != 0)
            {
                LineHeaderRepr = new TableHeaderCellRepresentation();
                if (ContentRepr.LineHeader != null) ContentRepr.LineHeader = new TableHeaderCellRepresentation();
            }
            else
            {
                LineHeaderRepr = null;
                ContentRepr.LineHeader = null;
            }
        }
        //
        public void Set_Matrix()
        {
            this.ColHeaderRepr.Set_Matrix();
            this.LineHeaderRepr.Set_Matrix();
            this.ContentRepr.Set_Matrix();
            this.GenRepr.Set_Matrix();
        }
        public void Set_List()
        {
            this.ColHeaderRepr.Set_List();
            this.LineHeaderRepr.Set_List();
            this.ContentRepr.Set_List();
            this.GenRepr.Set_List();
        }
        public void Set_Simple()
        {
            this.ColHeaderRepr.Set_Simple();
            this.LineHeaderRepr.Set_Simple();
            this.ContentRepr.Set_Simple();
            this.GenRepr.Set_Simple();
        }
        public void Set_SimpleNumerated(int N_No0Col1Line2Both3)
        {
            if (N_No0Col1Line2Both3 == 1 || N_No0Col1Line2Both3 == 3) this.ColHeaderRepr.Set_SimpleNumerated();
            else this.ColHeaderRepr.Set_Simple();
            if (N_No0Col1Line2Both3 == 2 || N_No0Col1Line2Both3 == 3) this.LineHeaderRepr.Set_SimpleNumerated();
            else this.LineHeaderRepr.Set_Simple();
            this.ContentRepr.Set_Simple();
            this.GenRepr.Set_Simple();
        }
        public void Set_2ArgsFn()
        {
            if (ColHeaderRepr == null) ColHeaderRepr = new TableHeaderCellRepresentation();
            ColHeaderRepr.Set_2ArgsFn();
            //ColHeaderRepr.RowName = true;
            //ColHeaderRepr.GenRowNameBef = true;
            //ColHeaderRepr.RowNAft = true;
            //ColHeaderRepr.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 4;
            //
            if (LineHeaderRepr == null) LineHeaderRepr = new TableHeaderCellRepresentation();
            LineHeaderRepr.Set_2ArgsFn();
            //LineHeaderRepr.RowName = true;
            //LineHeaderRepr.GenRowNameBef = true;
            //LineHeaderRepr.RowNAft = true;
            //LineHeaderRepr.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 4;
            //
            if (ContentRepr == null) ContentRepr = new TableContentCellRepresentation();
            ContentRepr.Set_2ArgsFn();
            //
            //if (ContentRepr.ColHeader == null) ContentRepr.ColHeader = new TableHeaderCellRepresentation();
            //ContentRepr.ColHeader.Set_2ArgsFn();
            //ContentRepr.ColHeader.RowName = true;
            //ContentRepr.ColHeader.GenRowNameBef = true;
            //ContentRepr.ColHeader.RowNAft = true;
            //ContentRepr.ColHeader.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 4;
            //
            //if (ContentRepr.LineHeader == null) ContentRepr.LineHeader = new TableHeaderCellRepresentation();
            //ContentRepr.LineHeader.Set_2ArgsFn();
            //ContentRepr.LineHeader.RowName = true;
            //ContentRepr.LineHeader.GenRowNameBef = true;
            //ContentRepr.LineHeader.RowNAft = true;
            //ContentRepr.LineHeader.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 4;
            //
            //ContentRepr.HdrAndCntDividedBy_Nil0Space1Comma2Colon3Semicolon4Minus5EqSgn6 = 2;
            //ContentRepr.HeadersAreBefNotAft = true;
            //ContentRepr.LH_IsBefNotAft_CH = true; //or can b vv;
            //ContentRepr.TableHeaderExists = true; //ob ce s'fn
        }
    }//cl 13 TableRepresentation
    //
    /*
    public struct TableHeaderFullRepresentation //cl 14 
    {
        public TableHeaderCellRepresentation Hdr;
        public TableGeneralRepresentation Gen;
    } //cl 14 TableHeaderFullRepresentation
    public struct TableContentFullRepresentation //cl 15 
    {
        public TableContentCellRepresentation Cnt;
        public TableGeneralRepresentation Gen;
    } //TableContentFullRepresentation
    */
    public class GridRepresentationSuppl
    {
        public bool LoCHGridCellsUsed, CoLHGridCellsUsed;
        public int QColHeaderNames, QLineHeaderNames;
        //public int QColHeaderNamesFixed0ByMax1ByMin2, QLineHeaderNamesFixed0ByMax1ByMin2;
        public GridRepresentationSuppl()
        {
            LoCHGridCellsUsed=true; CoLHGridCellsUsed=true;
            QColHeaderNames=3; QLineHeaderNames=3;
            //QColHeaderNamesFixed0ByMax1ByMin2=0; QLineHeaderNamesFixed0ByMax1ByMin2=0;
        }
    }
}//ns   //2020-08-12
