
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
//mark1 - 1282
//mark2 - 2398
//mark3 - 2675
//mark4 - 3604
//fin - 4743
//
namespace Tables
{
    //Group of classes 1 - TableConsts
    public static class TableConsts //cl 1
    {
        public const int DoubleTypeN = 1;
        public const int FloatTypeN = 2;
        public const int IntTypeN = 3;
        public const int BoolTypeN = 4;
        public const int StringTypeN = 5;
        //
        public const int DoubleArrayTypeN = 11;
        public const int FloatArrayTypeN = 12;
        public const int IntArrayTypeN = 13;
        public const int BoolArrayTypeN = 14;
        public const int StringArrayTypeN = 15;
        //
        public const int UniqueIntValKeeperTypeN = 23;
        //
        public const int IntItemHeaderDependentTypeN = 22;
        //
        public const int DoubleItemsFieldHeaderCellTypeN = 31;
        public const int IntItemsFieldHeaderCellTypeN = 33;
        public const int StringItemsFieldHeaderCellTypeN = 35;
        //
        public const int DBTableHeaderTypeN = 40;
        //
        public const int DBTableHeader_TableHeaderOnly_TypeN = 41;
        //public const int DBTableHeader_TableHeadersBoth_TypeN = 42;
        public const int DBTableHeader_HeadersBothForDemoAndDB_TypeN = 42;
        public const int DBTableHeader_DBFullInf_TypeN = 43;
        //
        public const int ColHeaderDBFieldOrItemsTypeN = 50; // DBFieldHeaderTypeN = 41;//
        //
        public const int ColHeaderDBFieldOrItems_colHdrOnly_TypeN = 51; // DBHdr- DBCreoInfo- DBTbl- Items-
        public const int ColHeaderDBFieldOrItems_Items_TypeN = 52; // DBHdr- DBCreoInfo- DBTbl- Items+ //51 +items
        public const int ColHeaderDBFieldOrItems_DBInfo_TypeN = 53; // DBHdr+ DBInfo- DBTbl- Items-
        public const int ColHeaderDBFieldOrItems_DBInfoAndItems_TypeN = 54;// DBHdr+ DBCreoInfo- DBTbl- Items+ //53 + items
        public const int ColHeaderDBFieldOrItems_DBFullInfo_TypeN = 55;// DBHdr+ DBInfo+ DBTbl- Items-
        public const int ColHeaderDBFieldOrItems_DBFullInfoAndItems_TypeN = 56;// DBHdr+ DBCreoInfo+ DBTbl- Items+ //55 + items
        public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN = 57;// DBHdr+ DBCreoInfo+ DBTbl+ Items- //physically possible, practically not needed
        public const int ColHeaderDBFieldOrItems_DBFullInfoAndJoinedTableAndItems_TypeN = 58;//DBHdr+ DBCreoInfo+ DBTbl+Items+ //57 + items
        //
        //public const int DBFieldHeaderWithItemsTypeN = 43;
        //public const int DBTableHeaderSpecialTypeN = 44;
        //
        public const int DefaultAnyCellTypeN = StringTypeN;
        public const int DefaultContentCellTypeN = DoubleTypeN;
        public const int DefaultColOfLineHeaderCellTypeN = IntTypeN;
        public const int DefaultLineOfColHeaderCellTypeN = DefaultAnyCellTypeN;
        //
        public const string TableDataComponent_ContentCell = "Content cell";
        public const string TableDataComponent_LineOfColHeaderCell = "Line of Col Hdr";
        public const string TableDataComponent_ColOfLineHeaderCell = "Col of Line Hdr";
        public const string TableDataComponent_LinesGenName = "Lines Gen Name";
        public const string TableDataComponent_ColsGenName = "Cols Gen Name";
        public const string TableDataComponent_TableName = "Table Name";
        public const string TableDataComponent_LinesGenName_Scnd = "Lines Gen Name Scnd";
        public const string TableDataComponent_ColsGenName_Scnd = "Cols Gen Name Scnd";
        public const string TableDataComponent_TableName_Scnd = "Table Name Scnd";
        public const string TableDataComponent_LineOfColHeaderCell_Scnd = "Line of Col Hdr Scnd";
        public const string TableDataComponent_ColOfLineHeaderCell_Scnd = "Col of Line Hdr Scnd";
        //
        public const string TrueWord = "true";
        public const string FalseWord = "false";
        //
        public const string ColHeaderName_TableColName = "TableColName";
        public const int ColHeaderN_TableColName = 1;
        public const string ColHeaderName_BDReprColName = "BD Representation Col Name";
        public const int ColHeaderN_BDReprColName = 2;
        public const string ColHeaderName_BDColName = "BD Col Name";
        public const int ColHeaderN_BDColName = 3;
        public const string ColHeaderName_ItemsTableName = "ItemsTableName";
        public const string ColHeaderName_ColNameOfItemsTable = "Col Name in Items Table";
        //
        //public const int SettingsTable_Repr_TableGen_DataN = 1;
        //public const int SettingsTable_Repr_LineOfColHeader_DataN = 2;
        //public const int SettingsTable_Repr_ColOfLinelHeader_DataN = 3;
        //public const int SettingsTable_Repr_ContentCellHeader_DataN = 4;
        //public const int SettingsTable_Repr_LineOfColHeader_OfContentCell_DataN = 5;
        //public const int SettingsTable_Repr_ColOfLinelHeader_OfContentCell_DataN = 6;
        //
        public const int SettingsTable_UssagePolicy_DataN = 7;
        //public const int SettingsTable_Repr_Grid_DataN = 11;//supfl exnot
        //public const int SettingsTable_Repr_TableForm_DataN = 12;
        public const int SettingsTable_GridConfig_DataN = 12;
        //
        public const int SettingsTable_Repr_TableGen_Text_DataN = 21;
        public const int SettingsTable_Repr_LineOfColHeader_Text_DataN = 22;
        public const int SettingsTable_Repr_ColOfLineHeader_Text_DataN = 23;
        public const int SettingsTable_Repr_ContentCell_Text_DataN = 24;//SettingsTable_Repr_ContentCellHeader_Text_DataN = 24;
        public const int SettingsTable_Repr_LineOfColHeader_OfContentCell_Text_DataN = 25;
        public const int SettingsTable_Repr_ColOfLineHeader_OfContentCell_Text_DataN = 26;
        //
        public const int SettingsTable_Repr_TableGen_Grid_DataN = 31;
        public const int SettingsTable_Repr_LineOfColHeader_Grid_DataN = 32;
        public const int SettingsTable_Repr_ColOfLineHeader_Grid_DataN = 33;
        public const int SettingsTable_Repr_ContentCell_Grid_DataN = 34;
        public const int SettingsTable_Repr_LineOfColHeader_OfContentCell_Grid_DataN = 35;
        public const int SettingsTable_Repr_ColOfLineHeader_OfContentCell_Grid_DataN = 36;
        //
        public const int GuiArrows_PurposeN_MoveFocus = 1;
        public const int GuiArrows_PurposeN_CompressShownAreaHideRows = 2;
        public const int GuiArrows_PurposeN_ExpandShownAreaShowRows = 3;
        public const int GuiArrows_PurposeN_ShiftShowRows = 4;
        public const int GuiArrows_PurposeN_MoveExchangingRows = 5;
        public const int GuiArrows_PurposeN_MoveExchangingCells = 6;
        public const int GuiArrows_PurposeN_InsOrAddRows = 7;
        public const int GuiArrows_PurposeN_DelRows = 8;
        public const int GuiArrows_PurposeN_MoveText = 9;
        public const int GuiArrows_PurposeN_CompressText = 10;
        public const int GuiArrows_PurposeN_ExpandText = 11;
        public const int GuiArrows_PurposeN_MoveTextCursor = 12;
        //
        public const string GuiArrows_StringLine_En_MoveFocus = "Move Focus";
        public const string GuiArrows_StringLine_En_CompressShownAreaHideRows = "HideRows";
        public const string GuiArrows_StringLine_En_ExpandShownAreaShowRows = "ShowRows";
        public const string GuiArrows_StringLine_En_ShiftShowRows = "ShiftRows";
        public const string GuiArrows_StringLine_En_MoveExchangingRows = "MoveRows";
        public const string GuiArrows_StringLine_En_MoveExchangingCells = "MoveCells";
        public const string GuiArrows_StringLine_En_InsOrAddRows = "InsOrAddRows";
        public const string GuiArrows_StringLine_En_DelRow = "DelRows";
        public const string GuiArrows_StringLine_En_MoveText = "MoveText";
        public const string GuiArrows_StringLine_En_CompressText = "CompressText";
        public const string GuiArrow_StringLines_En_ExpandText = "ExpandText";
        public const string GuiArrows_StringLine_En_MoveTextCursor = "MoveTextCursor";
        //
        public const string GuiArrows_StringLine_Ru_MoveFocus = "Move Focus";
        public const string GuiArrows_StringLine_Ru_CompressShownAreaHideRows = "HideRows";
        public const string GuiArrows_StringLine_Ru_ExpandShownAreaShowRows = "ShowRows";
        public const string GuiArrows_StringLine_Ru_ShiftShowRows = "ShiftRows";
        public const string GuiArrows_StringLine_Ru_MoveExchangingRows = "MoveRows";
        public const string GuiArrows_StringLine_Ru_MoveExchangingCells = "MoveCells";
        public const string GuiArrows_StringLine_Ru_InsOrAddRows = "InsOrAddRows";
        public const string GuiArrows_StringLine_Ru_DelRow = "DelRows";
        public const string GuiArrows_StringLine_Ru_MoveText = "MoveText";
        public const string GuiArrows_StringLine_Ru_CompressText = "CompressText";
        public const string GuiArrow_StringLines_Ru_ExpandText = "ExpandText";
        public const string GuiArrows_StringLine_Ru_MoveTextCursor = "MoveTextCursor";
        //
        public const string GuiArrows_StringLine_MoveFocus = GuiArrows_StringLine_En_MoveFocus;
        public const string GuiArrows_StringLine_CompressShownAreaHideRows = GuiArrows_StringLine_En_CompressShownAreaHideRows;
        public const string GuiArrows_StringLine_ExpandShownAreaShowRows = GuiArrows_StringLine_En_ExpandShownAreaShowRows;
        public const string GuiArrows_StringLine_ShiftShowRows = GuiArrows_StringLine_En_ShiftShowRows;
        public const string GuiArrows_StringLine_MoveExchangingRows = GuiArrows_StringLine_En_MoveExchangingRows;
        public const string GuiArrows_StringLine_MoveExchangingCells = GuiArrows_StringLine_En_MoveExchangingCells;
        public const string GuiArrows_StringLine_InsOrAddRows = GuiArrows_StringLine_En_InsOrAddRows;
        public const string GuiArrows_StringLine_DelRow = GuiArrows_StringLine_En_DelRow;
        public const string GuiArrows_StringLine_MoveText = GuiArrows_StringLine_En_MoveText;
        public const string GuiArrows_StringLine_CompressText = GuiArrows_StringLine_En_CompressText;
        public const string GuiArrow_StringLines_ExpandText = GuiArrow_StringLines_En_ExpandText;
        public const string GuiArrows_StringLine_MoveTextCursor = GuiArrows_StringLine_En_MoveTextCursor;
        //
        public const int SupplInfDisplay_ItemN_UssagePolicy = 1;
        public const int SupplInfDisplay_ItemN_RepresentationText = 2;
        public const int SupplInfDisplay_ItemN_RepresentationGrid = 3;
        public const int SupplInfDisplay_ItemN_GUIControls = 4;
        public const int SupplInfDisplay_ItemN_CellItems = 5;
        public const int SupplInfDisplay_ItemN_DBFieldHeadersParams = 6;
        public const int SupplInfDisplay_ItemN_DBTableParams = 7;
        public const int SupplInfDisplay_ItemN_TableContentTypeMap = 8;
        public const int SupplInfDisplay_ItemN_TableHeadersTypeMap = 9;
        //
        public const string SupplInfDisplay_ItemName_En_UssagePolicy = "Ussage Policy";
        public const string SupplInfDisplay_ItemName_En_RepresentationText = "Representation Text";
        public const string SupplInfDisplay_ItemName_En_RepresentationGrid = "Representation Grid";
        public const string SupplInfDisplay_ItemName_En_GUIControls = "GUI Controls";
        public const string SupplInfDisplay_ItemName_En_CellItems = "Cell Items";
        public const string SupplInfDisplay_ItemName_En_DBFieldHeadersParams = "DB Field Headers Params";
        public const string SupplInfDisplay_ItemName_En_DBTableParams = "DB Table Params";
        public const string SupplInfDisplay_ItemName_En_TableContentTypeMap = "Table Content Type Map";
        public const string SupplInfDisplay_ItemName_En_TableHeadersTypeMap = "Table Headers Type Map";
        //
        public const string SupplInfDisplay_ItemName_Ru_UssagePolicy = "Ussage Policy";
        public const string SupplInfDisplay_ItemName_Ru_RepresentationText = "Representation Text";
        public const string SupplInfDisplay_ItemName_Ru_RepresentationGrid = "Representation Grid";
        public const string SupplInfDisplay_ItemName_Ru_GUIControls = "GUI Controls";
        public const string SupplInfDisplay_ItemName_Ru_CellItems = "Cell Items";
        public const string SupplInfDisplay_ItemName_Ru_DBFieldHeadersParams = "DB Field Headers Params";
        public const string SupplInfDisplay_ItemName_Ru_DBTableParams = "DB Table Params";
        public const string SupplInfDisplay_ItemName_Ru_TableContentTypeMap = "Table Content Type Map";
        public const string SupplInfDisplay_ItemName_Ru_TableHeadersTypeMap = "Table Headers Type Map";
        //
        public const string SupplInfDisplay_ItemName_UssagePolicy = SupplInfDisplay_ItemName_En_UssagePolicy;
        public const string SupplInfDisplay_ItemName_RepresentationText = SupplInfDisplay_ItemName_En_RepresentationText;
        public const string SupplInfDisplay_ItemName_RepresentationGrid = SupplInfDisplay_ItemName_En_RepresentationGrid;
        public const string SupplInfDisplay_ItemName_GUIControls = SupplInfDisplay_ItemName_En_GUIControls;
        public const string SupplInfDisplay_ItemName_CellItems = SupplInfDisplay_ItemName_En_CellItems;
        public const string SupplInfDisplay_ItemName_DBFieldHeadersParams = SupplInfDisplay_ItemName_En_DBFieldHeadersParams;
        public const string SupplInfDisplay_ItemName_DBTableParams = SupplInfDisplay_ItemName_En_DBTableParams;
        public const string SupplInfDisplay_ItemName_TableContentTypeMap = SupplInfDisplay_ItemName_En_TableContentTypeMap;
        public const string SupplInfDisplay_ItemName_TableHeadersTypeMap = SupplInfDisplay_ItemName_En_TableHeadersTypeMap;
        //
        public static bool TypeNIsCorrect(int N)
        {
            bool verdict;
            verdict = (N == DoubleTypeN || N == FloatTypeN || N == IntTypeN || N == BoolTypeN || N == StringTypeN || N == UniqueIntValKeeperTypeN || N == DoubleArrayTypeN || N == FloatArrayTypeN || N == IntArrayTypeN || N == BoolArrayTypeN || N == StringArrayTypeN);
            return verdict;
        }
        public static bool TypeNIsCorrectSingle(int N)
        {
            bool verdict;
            verdict = (N == DoubleTypeN || N == FloatTypeN || N == IntTypeN || N == BoolTypeN || N == StringTypeN);
            return verdict;
        }
        public static bool TypeNIsCorrectArray(int N)
        {
            bool verdict;
            verdict = (N == DoubleArrayTypeN || N == FloatArrayTypeN || N == IntArrayTypeN || N == BoolArrayTypeN || N == StringArrayTypeN);
            return verdict;
        }
        public static bool TypeNIsCorrectSingleNumber(int N)
        {
            bool verdict;
            verdict = (N == DoubleTypeN || N == FloatTypeN || N == IntTypeN);
            return verdict;
        }
        public static bool TypeNIsCorrectNumericArray(int N)
        {
            bool verdict;
            verdict = (N == DoubleArrayTypeN || N == FloatArrayTypeN || N == IntArrayTypeN);
            return verdict;
        }
        public static bool TypeNIsCorrectHeaderWithItems(int N)//public static bool TypeNIsCorrectHeaderOfDBColWithItems(int N)
        {
            bool verdict;
            verdict = (N == DoubleItemsFieldHeaderCellTypeN || N == IntItemsFieldHeaderCellTypeN || N == StringItemsFieldHeaderCellTypeN);
            return verdict;
        }
        public static bool TypeNIsCorrectHeaderOfDBFieldOrItems(int N)
        {
            bool verdict=false;
            //
            //public const int ColHeaderDBFieldOrItems_colHdrOnly_TypeN = 51; // DBHdr- DBCreoInfo- DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_Items_TypeN = 52; // DBHdr- DBCreoInfo- DBTbl- Items+ //51 +items
            //public const int ColHeaderDBFieldOrItems_DBFieldHeader_TypeN = 53; // DBHdr+ DBInfo- DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldHeaderAndItems_TypeN = 54;// DBHdr+ DBCreoInfo- DBTbl- Items+ //53 + items
            //public const int ColHeaderDBFieldOrItems_DBFieldHeaderFullInfo_TypeN = 55;// DBHdr+ DBInfo+ DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndItems_TypeN = 56;// DBHdr+ DBCreoInfo+ DBTbl- Items+ //55 + items
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN = 57;// DBHdr+ DBCreoInfo+ DBTbl+ Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndItemsAndJoinedTable_TypeN = 58;//DBHdr+ DBCreoInfo+ DBTbl+Items+ //57 + items
            //
            verdict = verdict || (N == ColHeaderDBFieldOrItems_colHdrOnly_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_Items_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBInfo_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBInfoAndItems_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfo_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfoAndItems_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN);//no need in it
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfoAndJoinedTableAndItems_TypeN);
            //
            return verdict;
        }
        public static bool TypeNIsCorrectHeaderOfDBFieldOrItems_DBDataExist(int N)
        {
            bool verdict = false;
            //
            //public const int ColHeaderDBFieldOrItems_colHdrOnly_TypeN = 51; // DBHdr- DBCreoInfo- DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_Items_TypeN = 52; // DBHdr- DBCreoInfo- DBTbl- Items+ //51 +items
            //public const int ColHeaderDBFieldOrItems_DBFieldHeader_TypeN = 53; // DBHdr+ DBInfo- DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldHeaderAndItems_TypeN = 54;// DBHdr+ DBCreoInfo- DBTbl- Items+ //53 + items
            //public const int ColHeaderDBFieldOrItems_DBFieldHeaderFullInfo_TypeN = 55;// DBHdr+ DBInfo+ DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndItems_TypeN = 56;// DBHdr+ DBCreoInfo+ DBTbl- Items+ //55 + items
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN = 57;// DBHdr+ DBCreoInfo+ DBTbl+ Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndItemsAndJoinedTable_TypeN = 58;//DBHdr+ DBCreoInfo+ DBTbl+Items+ //57 + items
            //
            //verdict = verdict && !(N == ColHeaderDBFieldOrItems_colHdrOnly_TypeN);
            //verdict = verdict && !(N == ColHeaderDBFieldOrItems_Items_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBInfo_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBInfoAndItems_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfo_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfoAndItems_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN);//no need in it
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfoAndJoinedTableAndItems_TypeN);
            //
            return verdict;
        }
        public static bool TypeNIsCorrectHeaderOfDBFieldOrItems_DBCreationDataExist(int N)
        {
            bool verdict = false;
            //
            //public const int ColHeaderDBFieldOrItems_colHdrOnly_TypeN = 51; // DBHdr- DBCreoInfo- DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_Items_TypeN = 52; // DBHdr- DBCreoInfo- DBTbl- Items+ //51 +items
            //public const int ColHeaderDBFieldOrItems_DBFieldHeader_TypeN = 53; // DBHdr+ DBInfo- DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldHeaderAndItems_TypeN = 54;// DBHdr+ DBCreoInfo- DBTbl- Items+ //53 + items
            //public const int ColHeaderDBFieldOrItems_DBFieldHeaderFullInfo_TypeN = 55;// DBHdr+ DBInfo+ DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndItems_TypeN = 56;// DBHdr+ DBCreoInfo+ DBTbl- Items+ //55 + items
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN = 57;// DBHdr+ DBCreoInfo+ DBTbl+ Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndItemsAndJoinedTable_TypeN = 58;//DBHdr+ DBCreoInfo+ DBTbl+Items+ //57 + items
            //
            //verdict = verdict  && !(N == ColHeaderDBFieldOrItems_colHdrOnly_TypeN);
            //verdict = verdict  && !(N == ColHeaderDBFieldOrItems_Items_TypeN);
            //verdict = verdict  && !(N == ColHeaderDBFieldOrItems_DBInfo_TypeN);
            //verdict = verdict  && !(N == ColHeaderDBFieldOrItems_DBInfoAndItems_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfo_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfoAndItems_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN);//no need in it
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfoAndJoinedTableAndItems_TypeN);
            //
            return verdict;
        }
        public static bool TypeNIsCorrectHeaderOfDBFieldOrItems_DBJoinedItemsTableExists(int N)
        {
            bool verdict = false;
            //
            //public const int ColHeaderDBFieldOrItems_colHdrOnly_TypeN = 51; // DBHdr- DBCreoInfo- DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_Items_TypeN = 52; // DBHdr- DBCreoInfo- DBTbl- Items+ //51 +items
            //public const int ColHeaderDBFieldOrItems_DBFieldHeader_TypeN = 53; // DBHdr+ DBInfo- DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldHeaderAndItems_TypeN = 54;// DBHdr+ DBCreoInfo- DBTbl- Items+ //53 + items
            //public const int ColHeaderDBFieldOrItems_DBFieldHeaderFullInfo_TypeN = 55;// DBHdr+ DBInfo+ DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndItems_TypeN = 56;// DBHdr+ DBCreoInfo+ DBTbl- Items+ //55 + items
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN = 57;// DBHdr+ DBCreoInfo+ DBTbl+ Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndItemsAndJoinedTable_TypeN = 58;//DBHdr+ DBCreoInfo+ DBTbl+Items+ //57 + items
            //
            //verdict = verdict && !(N == ColHeaderDBFieldOrItems_colHdrOnly_TypeN);
           // verdict = verdict && !(N == ColHeaderDBFieldOrItems_Items_TypeN);
            //verdict = verdict && !(N == ColHeaderDBFieldOrItems_DBInfo_TypeN);
            //verdict = verdict && !(N == ColHeaderDBFieldOrItems_DBInfoAndItems_TypeN);
            //verdict = verdict && !(N == ColHeaderDBFieldOrItems_DBFullInfo_TypeN);
            //verdict = verdict && !(N == ColHeaderDBFieldOrItems_DBFullInfoAndItems_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN);//no need in it
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfoAndJoinedTableAndItems_TypeN);
            //
            return verdict;
        }
        public static bool TypeNIsCorrectHeaderOfDBFieldOrItems_ItemsExist(int N)
        {
            bool verdict = false;
            //
            //public const int ColHeaderDBFieldOrItems_colHdrOnly_TypeN = 51; // DBHdr- DBCreoInfo- DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_Items_TypeN = 52; // DBHdr- DBCreoInfo- DBTbl- Items+ //51 +items
            //public const int ColHeaderDBFieldOrItems_DBFieldHeader_TypeN = 53; // DBHdr+ DBInfo- DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldHeaderAndItems_TypeN = 54;// DBHdr+ DBCreoInfo- DBTbl- Items+ //53 + items
            //public const int ColHeaderDBFieldOrItems_DBFieldHeaderFullInfo_TypeN = 55;// DBHdr+ DBInfo+ DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndItems_TypeN = 56;// DBHdr+ DBCreoInfo+ DBTbl- Items+ //55 + items
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN = 57;// DBHdr+ DBCreoInfo+ DBTbl+ Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndItemsAndJoinedTable_TypeN = 58;//DBHdr+ DBCreoInfo+ DBTbl+Items+ //57 + items
            //
            //verdict = verdict || (N == ColHeaderDBFieldOrItems_colHdrOnly_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_Items_TypeN);
            //verdict = verdict && !(N == ColHeaderDBFieldOrItems_DBInfo_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBInfoAndItems_TypeN);
            //verdict = verdict && !(N == ColHeaderDBFieldOrItems_DBFullInfo_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfoAndItems_TypeN);
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN);//no need in it
            verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfoAndJoinedTableAndItems_TypeN);
            //
            return verdict;
        }
        public static bool TypeNIsCorrectHeaderOfDBFieldOrItems_ColNameOnlet(int N)
        {
            bool verdict = false;
            //
            //public const int ColHeaderDBFieldOrItems_colHdrOnly_TypeN = 51; // DBHdr- DBCreoInfo- DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_Items_TypeN = 52; // DBHdr- DBCreoInfo- DBTbl- Items+ //51 +items
            //public const int ColHeaderDBFieldOrItems_DBFieldHeader_TypeN = 53; // DBHdr+ DBInfo- DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldHeaderAndItems_TypeN = 54;// DBHdr+ DBCreoInfo- DBTbl- Items+ //53 + items
            //public const int ColHeaderDBFieldOrItems_DBFieldHeaderFullInfo_TypeN = 55;// DBHdr+ DBInfo+ DBTbl- Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndItems_TypeN = 56;// DBHdr+ DBCreoInfo+ DBTbl- Items+ //55 + items
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN = 57;// DBHdr+ DBCreoInfo+ DBTbl+ Items-
            //public const int ColHeaderDBFieldOrItems_DBFieldFullInfoAndItemsAndJoinedTable_TypeN = 58;//DBHdr+ DBCreoInfo+ DBTbl+Items+ //57 + items
            //
            verdict = verdict && (N == ColHeaderDBFieldOrItems_colHdrOnly_TypeN);
            //verdict = verdict || (N == ColHeaderDBFieldOrItems_Items_TypeN);
            //verdict = verdict || (N == ColHeaderDBFieldOrItems_DBInfo_TypeN);
            //verdict = verdict || (N == ColHeaderDBFieldOrItems_DBInfoAndItems_TypeN);
            //verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfo_TypeN);
            //verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfoAndItems_TypeN);
            //verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFieldFullInfoAndJoinedTable_TypeN);//no need in it
            //verdict = verdict || (N == ColHeaderDBFieldOrItems_DBFullInfoAndJoinedTableAndItems_TypeN);
            //
            return verdict;
        }
        public static bool TypeNIsCorrectHeaderOfDBFieldOrItems_Indefinite(int N)
        {
            return (N == ColHeaderDBFieldOrItemsTypeN);
        }
    }//cl 1 TanbleConsts
    //
    //Group of classes 2 - Cell Access
    public class TableCellAccessConfiguration:ICloneable //cl 5
    {
        public bool CheckCellExistance;
        public bool PreserveVal;
        public int LengthOfArrCellTypes;
        public int UniqueIntVal;
        //
        public TableCellAccessConfiguration()
        {
            SetDefault();
        }
        public object Clone() { return this.MemberwiseClone(); }
        public void SetDefault()
        {
            CheckCellExistance = false;
            PreserveVal = false;
            LengthOfArrCellTypes = 1;
            UniqueIntVal = 1;
        }
        public void SetValsPreserve_Yes() { PreserveVal = true; }
        public void SetValsPreserve_No() { PreserveVal = false; }
        public void SetLength(int L)
        {
            if (L >= 1 && L <= MyLib.MaxInt) LengthOfArrCellTypes = L;
        }
        public override string ToString()
        {
            string s;
            s = "";
            s = s + "CheckCellExistance: " + MyLib.BoolToInt(CheckCellExistance);
            s = s + " PreserveVal: " + MyLib.BoolToInt(PreserveVal);
            s = s + " Length of ArrCellTypes: " + LengthOfArrCellTypes.ToString();
            s = s + " Unique int val: " + UniqueIntVal.ToString();

            return s;
        }
        public bool GetIfNeedToCheckCellExistance() { return CheckCellExistance; }
        public bool GetIfNeedToPreserveVal() { return PreserveVal; }
    } //cl 5 TableCellAccessConfiguration
    public class TableSettingConfiguration:ICloneable //cl 6
    {
        //public bool PreserveVals;
        public TableCellAccessConfiguration CellCfg;
        public bool WriteParamsInfo;
        //
        public TableSettingConfiguration() { SetDefault(); }
        public object Clone(){
            TableSettingConfiguration NewObj;
            NewObj = new TableSettingConfiguration();
            NewObj.CellCfg = this.CellCfg;
            NewObj.WriteParamsInfo = this.WriteParamsInfo;
            return NewObj;
        }
        public void SetDefault()
        {
            CellCfg = new TableCellAccessConfiguration();
            WriteParamsInfo = true;
            //PreserveVals = false;
        }
        public void SetValsPreserve_Yes() { CellCfg.PreserveVal = true; }
        public void SetValsPreserve_No() { CellCfg.PreserveVal = false; }
        public void SetLength(int L) { CellCfg.SetLength(L); }
        public override string ToString()
        {
            string s;
            s = "";
            s = s + "WriteParamsInfo: " + MyLib.BoolToInt(WriteParamsInfo);
            //s = s + " PreserveVal: " + MyLib.BoolToInt(PreserveVals);
            s = s + " Cell Configuration: " + CellCfg.ToString();
            return s;
        }
        public bool GetIfNeedToWriteParamsInfo() { return WriteParamsInfo; }
        public bool GetIfNeedToPreserveVal() { return CellCfg.PreserveVal; }
    } //cl 6 TableSettingConfiguration
    //
    //Group of classes 3 - TableInfo
    public class TableInfo_ConcrRepr:ICloneable //cl 7
    {
        public TableStructure Str;
        //public TableRowsGeneralNames RowsGeneralNames;
        //public TableHeaders Headers;
        //public TableRowsQuantities RowsQuantities;
        public TableSize RowsQuantities,
                         RowsLimitNs; //for unique nums
        public TableUssagePolicy UssagePolicy;
        //public TableRepresentation Repr;
        public TableRepresentation Repr;
        public TableInfo_ConcrRepr()
        {
            Str = new TableStructure();
            //RowsGeneralNames = null;
            //RowsQuantities = new TableRowsQuantities();
            RowsQuantities = new TableSize();
            UssagePolicy = null;
            //Repr = null;
            Repr = null;
            RowsLimitNs = null;
            //Headers = null;
        }
        public TableInfo_ConcrRepr(bool LC_not_CL, bool CoLHExists, bool LoCHExists, int QLines, int QColumns)
        {
            Str = new TableStructure(LC_not_CL, CoLHExists, LoCHExists);
            this.RowsQuantities = new TableSize(QLines, QColumns);
            //RowsGeneralNames = null;
            UssagePolicy = null;
            Repr = null;
            //Repr = null;
            RowsLimitNs = null;
        }
        public TableInfo_ConcrRepr(bool LC_not_CL, bool CoLHExists, bool LoCHExists)
        {
            Str = new TableStructure(LC_not_CL, CoLHExists, LoCHExists);
            this.RowsQuantities = new TableSize(1, 1);
            //RowsGeneralNames = null;
            UssagePolicy = null;
            Repr = null;
            //Repr = null;
            RowsLimitNs = null;
        }
        public TableInfo_ConcrRepr(int QLines, int QColumns)
        {
            Str = new TableStructure(true, true, true);
            this.RowsQuantities = new TableSize(QLines, QColumns);
            //RowsGeneralNames = null;
            UssagePolicy = null;
            Repr = null;
            //Repr = null;
            RowsLimitNs = null;
        }
        public TableInfo_ConcrRepr(TableStructure StrExt = null, TableSize SizeExt = null, TableRepresentation ReprExt = null, TableUssagePolicy UssagePolicyExt = null, TableSize RowsLimitNsExt = null)
        {
            if (StrExt != null) Str = StrExt; else Str = new TableStructure();
            if (SizeExt != null) RowsQuantities = SizeExt; else RowsQuantities = new TableSize();
            //Repr = ReprExt;
            Repr = ReprExt;
            UssagePolicy = UssagePolicyExt;
            //if()RowsLimitNs
        }
        //
        public object Clone()
        {
            TableStructure str = null;
            TableSize size = null;
            TableUssagePolicy UssagePolicy=null;
            TableRepresentation Repr = null;
            if (this.Str != null) str = (TableStructure)this.Str.Clone();
            if (this.RowsQuantities != null) RowsQuantities = (TableSize)this.RowsQuantities.Clone();
            if (this.UssagePolicy != null) UssagePolicy = (TableUssagePolicy)this.UssagePolicy.Clone();
            if (this.Repr != null) Repr = (TableRepresentation)this.Repr.Clone();
            //if (this.Repr != null) Repr = (TableRepresentation)this.Repr.Clone();
            TableInfo_ConcrRepr newObj;
            newObj = new TableInfo_ConcrRepr(str, size, Repr, UssagePolicy);
            return newObj;
        }
        //
        public void Assign(TableInfo_ConcrRepr obj, int Mode_Rplc_Simply0_Null1_ByNonNull2 = 0, bool CreateDefaultIfNull = false)
        {
            //bool CreateDefaultIfNull = (Mode_RplcSimply0_RplcAndCreateDfltIfExtIsNull1_ReplByNonNull2_RplcNullByAnyExt3_RplcNullByExtAndCreateDfltIfExtIsAlsoNull4 == 1 || Mode_RplcSimply0_RplcAndCreateDfltIfExtIsNull1_ReplByNonNull2_RplcNullByAnyExt3_RplcNullByExtAndCreateDfltIfExtIsAlsoNull4 == 4);
            if (obj != null)
            {
                switch (Mode_Rplc_Simply0_Null1_ByNonNull2)
                {
                    case 0:
                        this.Str = obj.Str;
                        this.RowsQuantities = obj.RowsQuantities;
                        this.Repr = obj.Repr;
                        this.UssagePolicy = obj.UssagePolicy;
                    break;
                    case 1:
                        if (this.Str == null) this.Str = obj.Str;
                        if (this.RowsQuantities == null) this.RowsQuantities = obj.RowsQuantities;
                        this.Repr = obj.Repr;
                        //if (this.Repr_Text == null) {
                        //    this.Repr_Text = new TableRepresentation();
                        //    if (obj.Repr_Text!=null) this.Repr_Text.Assign(obj.Repr_Text, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
                        //}
                        //if (this.Repr_Grid == null)
                        //{
                        //    this.Repr_Grid = new TableRepresentation();
                        //    if (obj.Repr_Grid != null) this.Repr_Grid.Assign(obj.Repr_Grid, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
                        //}
                        if (this.UssagePolicy == null) this.UssagePolicy = obj.UssagePolicy;
                    break;
                    case 2:
                        if (obj.Str != null) this.Str = obj.Str;
                        if (obj.RowsQuantities != null) this.RowsQuantities = obj.RowsQuantities;
                        //if (obj.Repr_Text != null) this.Repr_Text = obj.Repr_Text;
                        //if (obj.Repr_Grid != null) this.Repr_Grid = obj.Repr_Grid;
                        if (obj.Repr != null)this.Repr = obj.Repr;
                        if (obj.UssagePolicy != null) this.UssagePolicy = obj.UssagePolicy;
                    break;
                }//sw
            }//if obj!=null
            if (this.Repr != null) this.Repr.Assign(obj.Repr, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
            if (CreateDefaultIfNull)
            {
                if (this.Str == null) this.Str = new TableStructure();
                if (this.RowsQuantities == null) this.RowsQuantities = new TableSize();
                if (this.Repr == null) this.Repr = new TableRepresentation();
                if (this.UssagePolicy == null) this.UssagePolicy =new TableUssagePolicy();
            }//if
        }//fn assign
        //
        public void GetMainInf(ref bool LC_not_CL, ref bool CoLHExists, ref bool LoCHExists, ref int QLines, ref int QColumns)
        {
            if (RowsQuantities == null)
            {
                QLines = 0; QColumns = 0;
            }
            else
            {
                QLines = RowsQuantities.QLines; QColumns = RowsQuantities.QColumns;
            }
            if (Str == null)
            {
                LC_not_CL = true; CoLHExists = false; LoCHExists = false;
            }
            else
            {
                LC_not_CL = Str.LC_Matrix_Not_CL_DB; CoLHExists = Str.ColOfLineHeaderExists; LoCHExists = Str.LineOfColHeaderExists;
            }
        }
       //public void SetLimits()
       // {
       //     RowsLimitNs = new TableSize();
       //     if (RowsQuantities != null) RowsLimitNs = RowsQuantities;
       // }
       // public void SetLimits(int QLines, int QColumns)
       // {
       //     RowsLimitNs = new TableSize();
       //     RowsLimitNs.QColumns = QColumns;
       //     RowsLimitNs.QLines = QLines;
       // }
        public void SetSize(int QLines, int QColumns)
        {
            if (this.RowsQuantities == null) RowsQuantities = new TableSize(QLines, QColumns);
            else this.RowsQuantities.Set(QLines, QColumns);
        }
        public void AddLine()
        {
            if (this.RowsQuantities == null) RowsQuantities = new TableSize();
            int QLines=this.GetQLines(), QColumns=this.GetQColumns();
            QLines++;
            this.RowsQuantities.Set(QLines, QColumns);
        }
        public void AddColumn()
        {
            if (this.RowsQuantities == null) RowsQuantities = new TableSize();
            int QLines = this.GetQLines(), QColumns = this.GetQColumns();
            QColumns++;
            this.RowsQuantities.Set(QLines, QColumns);
        }
        public void DelLine()
        {
            if (this.RowsQuantities == null) RowsQuantities = new TableSize();
            int QLines = this.GetQLines(), QColumns = this.GetQColumns();
            QLines--; //it seems to me, no need to check - ce mus do other part o'prg, ic handl't co content cells
            this.RowsQuantities.Set(QLines, QColumns);
        }
        public void DelColumn()
        {
            if (this.RowsQuantities == null) RowsQuantities = new TableSize();
            int QLines = this.GetQLines(), QColumns = this.GetQColumns();
            QColumns--; //I denk, S' no need to check - ce mus do aic part o'prg, ic handl't co content cells
            this.RowsQuantities.Set(QLines, QColumns);
        }
        public void SetStr(int LC_1_CL_0, int CoLHExists_No0Yes1, int LoCHExists_No0Yes1)
        {
            if (this.Str == null) Str = new TableStructure(LC_1_CL_0, CoLHExists_No0Yes1, LoCHExists_No0Yes1);
            else Str.SetInfo(LC_1_CL_0, CoLHExists_No0Yes1, LoCHExists_No0Yes1);
        }
        public void SetStr(bool LC_Not_CL_0, bool CoLHExists, bool LoCHExists)
        {
            if (this.Str == null) Str = new TableStructure(LC_Not_CL_0, CoLHExists, LoCHExists);
            else Str.SetInfo(LC_Not_CL_0, CoLHExists, LoCHExists);
        }
        //
        //
        public int GetQLines()
        {
            int R = 0;
            if (this.RowsQuantities != null) R = RowsQuantities.GetQLines();
            return R;
        }
        public int GetQColumns()
        {
            int R = 0;
            if (this.RowsQuantities != null) R = RowsQuantities.GetQColumns();
            return R;
        }
        //
        public bool GetIf_LC_Not_CL()
        {
            bool R = true;
            if (this.Str != null) R = Str.LC_Matrix_Not_CL_DB;
            return R;
        }
        public bool GetIf_LoCHExists()
        {
            bool R = true;
            if (this.Str != null) R = Str.LineOfColHeaderExists;
            return R;
        }
        public bool GetIf_CoLHExists()
        {
            bool R = true;
            if (this.Str != null) R = Str.ColOfLineHeaderExists;
            return R;
        }//fn
        //
        public bool GetIf_LineNExists(int LineN)
        {
            bool R;
            R = (LineN >= 1 && LineN <= GetQLines());
            return R;
        }
        public bool GetIf_ColNExists(int ColN)
        {
            bool R;
            R = (ColN >= 1 && ColN <= GetQColumns());
            return R;
        }
        public bool GetIf_LineHeaderCellNExists(int LineN)
        {
            bool R;
            R = (GetIf_LineNExists(LineN) && GetIf_CoLHExists());
            return R;
        }
        public bool GetIf_ColHeaderCellNExists(int ColN)
        {
            bool R;
            R = (GetIf_ColNExists(ColN) && GetIf_LoCHExists());
            return R;
        }
        public bool GetIf_CellExists(int LineN, int ColN)
        {
            bool R=false;
            if (LineN == 0 && ColN != 0)
            {
                R = GetIf_ColHeaderCellNExists(ColN);
            }
            else if (LineN != 0 && ColN == 0)
            {
                R=GetIf_LineHeaderCellNExists(LineN);
            }
            else if (LineN == 0 && ColN == 0)
            {
                R=GetIf_LineNExists(LineN) && GetIf_ColNExists(ColN);
            }
            return R;
        }
        //
        public TableHeaderRowsExistance GetTableHeaderRowsExistance()
        {
            TableHeaderRowsExistance obj;
            obj = new TableHeaderRowsExistance(this.GetIf_CoLHExists(), this.GetIf_LoCHExists());
            return obj;
        }
        public TableStructure GetStr() { return this.Str; }
        public TableSize GetSize() { return this.RowsQuantities; }
        public TableUssagePolicy GetUssagePolicy() { return this.UssagePolicy; }
        public TableRepresentation GetRepresentation() { return this.Repr; }
        //
        public TableGeneralRepresentation GetGeneralRepresentation()
        {
            TableGeneralRepresentation R=null;
            if (this.Repr != null) R = this.Repr.GetGeneralRepresentation();
            return R;
        }
        public TableContentCellRepresentation GetContentCellRepresentation() {
            TableContentCellRepresentation R = null;
            if (this.Repr != null) R = Repr.GetContentRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetLineHeaderCellRepresentation()
        {
            TableHeaderCellRepresentation R=null;
            if (this.Repr != null) R = this.Repr.GetLineHeaderRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetColHeaderCellRepresentation()
        {
            TableHeaderCellRepresentation R=null;
            if (this.Repr != null) R = this.Repr.GetColHeaderRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetContentCellLineHeaderRepresentation()
        {
            TableHeaderCellRepresentation R = null;
            //if (this.Repr_Text != null && this.Repr_Text.ContentRepr != null) R = Repr_Text.ContentRepr.LineHeader;
            if (this.Repr != null) R = Repr.GetLineHeaderReprOfContentCell();
            return R;
        }
        //public TableHeaderCellRepresentation GetContentCellColumnHeaderRepresentation_Text()
        //{
        //    TableHeaderCellRepresentation R = null;
        //    if (this.Repr != null) R = Repr.GetColumnHeaderReprOfContentCell();
        //    return R;
        //}
        public TableHeaderCellRepresentation GetContentCellColumnHeaderRepresentation()
        {
            TableHeaderCellRepresentation R = null;
            if (this.Repr != null) R = Repr.GetColumnHeaderReprOfContentCell();
            return R;
        }
        //
        public void SetTableHeaderRowsExistance(TableHeaderRowsExistance obj)
        {
            if (this.Str == null) this.Str = new TableStructure();
            this.Str.SetIfColOfLineHeaderExists(obj.ColOfLineHeaderExists);
            this.Str.SetIfLineOfColHeaderExists(obj.LineOfColHeaderExists);
        }
        public void SetTableHeaderRowsExistance(bool ColOfLineHeaderExists, bool LineOfColHeaderExists)
        {
            if (this.Str == null) this.Str = new TableStructure();
            this.Str.SetIfColOfLineHeaderExists(ColOfLineHeaderExists);
            this.Str.SetIfLineOfColHeaderExists(LineOfColHeaderExists);
        }
        public void SetStr(TableStructure Str) { this.Str=Str; }
        public void GetSize(TableSize size) { this.RowsQuantities=size; }
        public void SetUssagePolicy(TableUssagePolicy UssagePolicy) { this.UssagePolicy=UssagePolicy; }
        public void SetRepresentation(TableRepresentation Repr) { this.Repr = Repr; }
        //
        public void SetContentCellRepresentation(TableContentCellRepresentation Repr)
        {
            if (this.Repr == null) this.Repr = new TableRepresentation();
            this.Repr.SetContentRepr(Repr);
        }
        public void SetLineHeaderCellRepresentation(TableHeaderCellRepresentation Repr)
        {
            if (this.Repr == null) this.Repr = new TableRepresentation();
            this.Repr.SetLineHeaderRepr(Repr);
        }
        public void SetColHeaderCellRepresentation(TableHeaderCellRepresentation Repr)
        {
            if (this.Repr == null) this.Repr = new TableRepresentation();
            this.Repr.SetColHeaderRepr(Repr);
        }
        public void SetContentCellLineHeaderRepresentation(TableHeaderCellRepresentation Repr)
        {
            if (this.Repr == null) this.Repr = new TableRepresentation();
            this.Repr.SetLineHeaderReprOfContentCell(Repr);
        }
        public void SetContentCellColumnHeaderRepresentation(TableHeaderCellRepresentation Repr)
        {
            if (this.Repr == null) this.Repr = new TableRepresentation();
            this.Repr.SetColHeaderReprOfContentCell(Repr);
        }
        //
        void CreateReprTextIfNull()
        {

        }
        void CreateReprGridIfNull()
        {

        }
        void CreateReprTextDetsIfNull()
        {

        }
        void CreateReprGridDetsIfNull()
        {

        }
        void CreateReprTextNumIfNull()
        {

        }
        void CreateReprGridNumIfNull()
        {

        }
        void CreateReprTextGenReprIfNull()
        {

        }
        void CreateReprGridGenReprIfNull()
        {

        }
        void CreateReprTextContentReprIfNull()
        {

        }
        void CreateReprContentGenReprIfNull()
        {

        }
    }//class 7 TableInfo_ConcrRepr
    public class TableInfo :ICloneable// TableInfo_ConcrRepr, ICloneable //cl 7
    {
        public TableStructure Str;
        //public TableRowsGeneralNames RowsGeneralNames;
        //public TableHeaders Headers;
        //public TableRowsQuantities RowsQuantities;
        public TableSize RowsQuantities,
                         RowsLimitNs; //for unique nums
        public TableUssagePolicy UssagePolicy;
        //public TableRepresentation Repr;
        public TableRepresentation Repr_Text, Repr_Grid;
        public TableInfo()
        {
            //Str = new TableStructure();
            ////RowsGeneralNames = null;
            ////RowsQuantities = new TableRowsQuantities();
            //RowsQuantities = new TableSize();
            //UssagePolicy = null;
            ////Repr = null;
            //Repr_Text = null;
            
            Repr_Grid = null;
            RowsLimitNs = null;
            //Headers = null;
        }
        public TableInfo(bool LC_not_CL, bool CoLHExists, bool LoCHExists, int QLines, int QColumns)
        {
            Str = new TableStructure(LC_not_CL, CoLHExists, LoCHExists);
            this.RowsQuantities = new TableSize(QLines, QColumns);
            //RowsGeneralNames = null;
            UssagePolicy = null;
            Repr_Text = null;
            Repr_Grid = null;
            //Repr = null;
            RowsLimitNs = null;
        }
        public TableInfo(bool LC_not_CL, bool CoLHExists, bool LoCHExists)
        {
            Str = new TableStructure(LC_not_CL, CoLHExists, LoCHExists);
            this.RowsQuantities = new TableSize(1, 1);
            //RowsGeneralNames = null;
            UssagePolicy = null;
            Repr_Text = null;
            Repr_Grid = null;
            //Repr = null;
            RowsLimitNs = null;
        }
        public TableInfo(int QLines, int QColumns)
        {
            Str = new TableStructure(true, true, true);
            this.RowsQuantities = new TableSize(QLines, QColumns);
            //RowsGeneralNames = null;
            UssagePolicy = null;
            Repr_Text = null;
            Repr_Grid = null;
            //Repr = null;
            RowsLimitNs = null;
        }
        //public TableInfo(TableStructure StrExt = null, TableSize SizeExt = null, TableRepresentation ReprExtText = null,  TableUssagePolicy UssagePolicyExt = null, int Repr_Grid0Text1=1, TableSize RowsLimitNsExt = null)
        //{
        //    if (StrExt != null) Str = StrExt; else Str = new TableStructure();
        //    if (SizeExt != null) RowsQuantities = SizeExt; else RowsQuantities = new TableSize();
        //switch(Repr_Grid0Text1==0){
        //    case 0:
        //        Repr_Text=Repr;
        //        Repr_Grid=null;
        //    break;
        //    case 1:
        //        Repr_Text=null;
        //        Repr_Grid=Repr;
        //    break;
        //}
        //    UssagePolicy = UssagePolicyExt;
        //    //if()RowsLimitNs
        //}
        public TableInfo(TableStructure StrExt = null, TableSize SizeExt = null, TableRepresentation ReprExtText = null, TableRepresentation ReprExtGrid = null, TableUssagePolicy UssagePolicyExt = null, TableSize RowsLimitNsExt = null)
        {
            if (StrExt != null) Str = StrExt; else Str = new TableStructure();
            if (SizeExt != null) RowsQuantities = SizeExt; else RowsQuantities = new TableSize();
            //Repr = ReprExt;
            Repr_Text = ReprExtText;
            Repr_Grid = ReprExtGrid;
            UssagePolicy = UssagePolicyExt;
            //if()RowsLimitNs
        }
        //
        public object Clone()
        {
            TableStructure str = null;
            TableSize size = null;
            TableUssagePolicy UssagePolicy = null;
            TableRepresentation Repr_Text=null, Repr_Grid = null;
            if (this.Str != null) str = (TableStructure)this.Str.Clone();
            if (this.RowsQuantities != null) RowsQuantities = (TableSize)this.RowsQuantities.Clone();
            if (this.UssagePolicy != null) UssagePolicy = (TableUssagePolicy)this.UssagePolicy.Clone();
            if (this.Repr_Text != null) Repr_Text = (TableRepresentation)this.Repr_Text.Clone();
            if (this.Repr_Grid != null) Repr_Grid = (TableRepresentation)this.Repr_Grid.Clone();
            //if (this.Repr != null) Repr = (TableRepresentation)this.Repr.Clone();
            TableInfo newObj;
            newObj = new TableInfo(str, size, Repr_Text, Repr_Grid, UssagePolicy);
            return newObj;
        }
        //
        public TableInfo_ConcrRepr GetTableInfo_ConcrRepr(int ReprN_Grid0Text1=1)
        {
            TableStructure str = null;
            TableSize size = null;
            TableUssagePolicy UssagePolicy = null;
            TableRepresentation Repr = null;
            if (this.Str != null) str = (TableStructure)this.Str.Clone();
            if (this.RowsQuantities != null) size = (TableSize)this.RowsQuantities.Clone();
            if (this.UssagePolicy != null) UssagePolicy = (TableUssagePolicy)this.UssagePolicy.Clone();
            if (this.Repr_Text != null && ReprN_Grid0Text1 == 1) Repr = (TableRepresentation)this.Repr_Text.Clone();
            if (this.Repr_Grid != null && ReprN_Grid0Text1 == 0) Repr = (TableRepresentation)this.Repr_Grid.Clone();
            //if (this.Repr != null) Repr = (TableRepresentation)this.Repr.Clone();
            TableInfo_ConcrRepr newObj;
            newObj = new TableInfo_ConcrRepr(str, size, Repr, UssagePolicy);
            return newObj;
        }
        //
        public void Assign(TableInfo obj, int Mode_Rplc_Simply0_Null1_ByNonNull2 = 0, bool CreateDefaultIfNull = false)
        {
            //bool CreateDefaultIfNull = (Mode_RplcSimply0_RplcAndCreateDfltIfExtIsNull1_ReplByNonNull2_RplcNullByAnyExt3_RplcNullByExtAndCreateDfltIfExtIsAlsoNull4 == 1 || Mode_RplcSimply0_RplcAndCreateDfltIfExtIsNull1_ReplByNonNull2_RplcNullByAnyExt3_RplcNullByExtAndCreateDfltIfExtIsAlsoNull4 == 4);
            if (obj != null)
            {
                switch (Mode_Rplc_Simply0_Null1_ByNonNull2)
                {
                    case 0:
                        this.Str = obj.Str;
                        this.RowsQuantities = obj.RowsQuantities;
                        this.Repr_Text = obj.Repr_Text;
                        this.Repr_Grid = obj.Repr_Grid;
                        this.UssagePolicy = obj.UssagePolicy;
                        break;
                    case 1:
                        if (this.Str == null) this.Str = obj.Str;
                        if (this.RowsQuantities == null) this.RowsQuantities = obj.RowsQuantities;
                        this.Repr_Text = obj.Repr_Text;
                        //if (this.Repr_Text == null) {
                        //    this.Repr_Text = new TableRepresentation();
                        //    if (obj.Repr_Text!=null) this.Repr_Text.Assign(obj.Repr_Text, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
                        //}
                        this.Repr_Grid = obj.Repr_Grid;
                        //if (this.Repr_Grid == null)
                        //{
                        //    this.Repr_Grid = new TableRepresentation();
                        //    if (obj.Repr_Grid != null) this.Repr_Grid.Assign(obj.Repr_Grid, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
                        //}
                        if (this.UssagePolicy == null) this.UssagePolicy = obj.UssagePolicy;
                        break;
                    case 2:
                        if (obj.Str != null) this.Str = obj.Str;
                        if (obj.RowsQuantities != null) this.RowsQuantities = obj.RowsQuantities;
                        //if (obj.Repr_Text != null) this.Repr_Text = obj.Repr_Text;
                        //if (obj.Repr_Grid != null) this.Repr_Grid = obj.Repr_Grid;
                        if (obj.Repr_Text != null) this.Repr_Text = obj.Repr_Text;
                        if (obj.Repr_Grid != null) this.Repr_Grid = obj.Repr_Grid;
                        if (obj.UssagePolicy != null) this.UssagePolicy = obj.UssagePolicy;
                        break;
                }//sw
            }//if obj!=null
            if (this.Repr_Text != null) this.Repr_Text.Assign(obj.Repr_Text, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
            if (this.Repr_Grid != null) this.Repr_Grid.Assign(obj.Repr_Grid, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
            if (CreateDefaultIfNull)
            {
                if (this.Str == null) this.Str = new TableStructure();
                if (this.RowsQuantities == null) this.RowsQuantities = new TableSize();
                if (this.Repr_Text == null) this.Repr_Text = new TableRepresentation();
                if (this.Repr_Grid == null) this.Repr_Grid = new TableRepresentation();
                if (this.UssagePolicy == null) this.UssagePolicy = new TableUssagePolicy();
            }//if
        }//fn assign
        //public void Assign(TableInfo_ConcrRepr obj, int Mode_Rplc_Simply0_Null1_ByNonNull2 = 0, bool CreateDefaultIfNull = false)
        //{
        //    TableInfo TblInfFull = new TableInfo();
        //}
        //
        public void GetMainInf(ref bool LC_not_CL, ref bool CoLHExists, ref bool LoCHExists, ref int QLines, ref int QColumns)
        {
            if (RowsQuantities == null)
            {
                QLines = 0; QColumns = 0;
            }
            else
            {
                QLines = RowsQuantities.QLines; QColumns = RowsQuantities.QColumns;
            }
            if (Str == null)
            {
                LC_not_CL = true; CoLHExists = false; LoCHExists = false;
            }
            else
            {
                LC_not_CL = Str.LC_Matrix_Not_CL_DB; CoLHExists = Str.ColOfLineHeaderExists; LoCHExists = Str.LineOfColHeaderExists;
            }
        }
        //public void SetLimits()
        // {
        //     RowsLimitNs = new TableSize();
        //     if (RowsQuantities != null) RowsLimitNs = RowsQuantities;
        // }
        // public void SetLimits(int QLines, int QColumns)
        // {
        //     RowsLimitNs = new TableSize();
        //     RowsLimitNs.QColumns = QColumns;
        //     RowsLimitNs.QLines = QLines;
        // }
        
        public void SetStr(int LC_1_CL_0, int CoLHExists_No0Yes1, int LoCHExists_No0Yes1)
        {
            if (this.Str == null) Str = new TableStructure(LC_1_CL_0, CoLHExists_No0Yes1, LoCHExists_No0Yes1);
            else Str.SetInfo(LC_1_CL_0, CoLHExists_No0Yes1, LoCHExists_No0Yes1);
        }
        public void SetStr(bool LC_Not_CL_0, bool CoLHExists, bool LoCHExists)
        {
            if (this.Str == null) Str = new TableStructure(LC_Not_CL_0, CoLHExists, LoCHExists);
            else Str.SetInfo(LC_Not_CL_0, CoLHExists, LoCHExists);
        }
        //
        public void SetSize(int QLines, int QColumns)
        {
            if (this.RowsQuantities == null) RowsQuantities = new TableSize(QLines, QColumns);
            else this.RowsQuantities.Set(QLines, QColumns);
        }
        //
        public void AddLine()
        {
            if (this.RowsQuantities == null) RowsQuantities = new TableSize();
            int QLines = this.GetQLines(), QColumns = this.GetQColumns();
            QLines++;
            this.RowsQuantities.Set(QLines, QColumns);
        }
        public void AddColumn()
        {
            if (this.RowsQuantities == null) RowsQuantities = new TableSize();
            int QLines = this.GetQLines(), QColumns = this.GetQColumns();
            QColumns++;
            this.RowsQuantities.Set(QLines, QColumns);
        }
        public void DelLine()
        {
            if (this.RowsQuantities == null) RowsQuantities = new TableSize();
            int QLines = this.GetQLines(), QColumns = this.GetQColumns();
            QLines--; //it seems to me, no need to check - ce mus do other part o'prg, ic handl't co content cells
            this.RowsQuantities.Set(QLines, QColumns);
        }
        public void DelColumn()
        {
            if (this.RowsQuantities == null) RowsQuantities = new TableSize();
            int QLines = this.GetQLines(), QColumns = this.GetQColumns();
            QColumns--; //I denk, S' no need to check - ce mus do aic part o'prg, ic handl't co content cells
            this.RowsQuantities.Set(QLines, QColumns);
        }
        //
        //
        public int GetQLines()
        {
            int R = 0;
            if (this.RowsQuantities != null) R = RowsQuantities.GetQLines();
            return R;
        }
        public int GetQColumns()
        {
            int R = 0;
            if (this.RowsQuantities != null) R = RowsQuantities.GetQColumns();
            return R;
        }
        //
        public bool GetIf_LC_Not_CL()
        {
            bool R = true;
            if (this.Str != null) R = Str.LC_Matrix_Not_CL_DB;
            return R;
        }
        public bool GetIf_LoCHExists()
        {
            bool R = true;
            if (this.Str != null) R = Str.LineOfColHeaderExists;
            return R;
        }
        public bool GetIf_CoLHExists()
        {
            bool R = true;
            if (this.Str != null) R = Str.ColOfLineHeaderExists;
            return R;
        }//fn
        //
        public bool GetIf_LineNExists(int LineN)
        {
            bool R;
            R = (LineN >= 1 && LineN <= GetQLines());
            return R;
        }
        public bool GetIf_ColNExists(int ColN)
        {
            bool R;
            R = (ColN >= 1 && ColN <= GetQColumns());
            return R;
        }
        public bool GetIf_LineHeaderCellNExists(int LineN)
        {
            bool R;
            R = (GetIf_LineNExists(LineN) && GetIf_CoLHExists());
            return R;
        }
        public bool GetIf_ColHeaderCellNExists(int ColN)
        {
            bool R;
            R = (GetIf_ColNExists(ColN) && GetIf_LoCHExists());
            return R;
        }
        public bool GetIf_CellExists(int LineN, int ColN)
        {
            bool R = false;
            if (LineN == 0 && ColN != 0)
            {
                R = GetIf_ColHeaderCellNExists(ColN);
            }
            else if (LineN != 0 && ColN == 0)
            {
                R = GetIf_LineHeaderCellNExists(LineN);
            }
            else if (LineN == 0 && ColN == 0)
            {
                R = GetIf_LineNExists(LineN) && GetIf_ColNExists(ColN);
            }
            return R;
        }
        //
        public TableHeaderRowsExistance GetTableHeaderRowsExistance()
        {
            TableHeaderRowsExistance obj;
            obj = new TableHeaderRowsExistance(this.GetIf_CoLHExists(), this.GetIf_LoCHExists());
            return obj;
        }
        public TableStructure GetStr() { return this.Str; }
        public TableSize GetSize() { return this.RowsQuantities; }
        public TableUssagePolicy GetUssagePolicy() { return this.UssagePolicy; }
        public TableRepresentation GetRepresentation_Text() { return this.Repr_Text; }
        public TableRepresentation GetRepresentation_Grid() { return this.Repr_Grid; }
        //
        public TableContentCellRepresentation GetContentCellRepresentation_Text()
        {
            TableContentCellRepresentation R = null;
            if (this.Repr_Text != null) R = Repr_Text.GetContentRepr();
            return R;
        }
        public TableContentCellRepresentation GetContentCellRepresentation_Grid()
        {
            TableContentCellRepresentation R = null;
            if (this.Repr_Grid != null) R = Repr_Grid.GetContentRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetLineHeaderCellRepresentation_Text()
        {
            TableHeaderCellRepresentation R = null;
            if (this.Repr_Text != null) R = this.Repr_Text.GetLineHeaderRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetLineHeaderCellRepresentation_Grid()
        {
            TableHeaderCellRepresentation R = null;
            if (this.Repr_Grid != null) R = this.Repr_Grid.GetLineHeaderRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetColHeaderCellRepresentation_Text()
        {
            TableHeaderCellRepresentation R = null;
            if (this.Repr_Text != null) R = this.Repr_Text.GetColHeaderRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetColHeaderCellRepresentation_Grid()
        {
            TableHeaderCellRepresentation R = null;
            if (this.Repr_Grid != null) R = this.Repr_Grid.GetColHeaderRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetContentCellLineHeaderRepresentation_Text()
        {
            TableHeaderCellRepresentation R = null;
            //if (this.Repr_Text != null && this.Repr_Text.ContentRepr != null) R = Repr_Text.ContentRepr.LineHeader;
            if (this.Repr_Text != null) R = Repr_Text.GetLineHeaderReprOfContentCell();
            return R;
        }
        public TableHeaderCellRepresentation GetContentCellLineHeaderRepresentation_Grid()
        {
            TableHeaderCellRepresentation R = null;
            if (this.Repr_Grid != null) R = Repr_Grid.GetLineHeaderReprOfContentCell();
            return R;
        }
        public TableHeaderCellRepresentation GetContentCellColumnHeaderRepresentation_Text()
        {
            TableHeaderCellRepresentation R = null;
            if (this.Repr_Text != null) R = Repr_Text.GetColumnHeaderReprOfContentCell();
            return R;
        }
        public TableHeaderCellRepresentation GetContentCellColumnHeaderRepresentation_Grid()
        {
            TableHeaderCellRepresentation R = null;
            if (this.Repr_Grid != null) R = Repr_Grid.GetColumnHeaderReprOfContentCell();
            return R;
        }
        public TableGeneralRepresentation GetGeneralRepresentation_Text()
        {
            TableGeneralRepresentation R = null;
            if (this.Repr_Text != null) R = Repr_Text.GetGeneralRepresentation();
            return R;
        }
        public TableGeneralRepresentation GetGeneralRepresentation_Grid()
        {
            TableGeneralRepresentation R = null;
            if (this.Repr_Grid != null) R = Repr_Grid.GetGeneralRepresentation();
            return R;
        }
        //
        public void SetTableHeaderRowsExistance(TableHeaderRowsExistance obj)
        {
            if (this.Str == null) this.Str = new TableStructure();
            this.Str.SetIfColOfLineHeaderExists(obj.ColOfLineHeaderExists);
            this.Str.SetIfLineOfColHeaderExists(obj.LineOfColHeaderExists);
        }
        public void SetTableHeaderRowsExistance(bool ColOfLineHeaderExists, bool LineOfColHeaderExists)
        {
            if (this.Str == null) this.Str = new TableStructure();
            this.Str.SetIfColOfLineHeaderExists(ColOfLineHeaderExists);
            this.Str.SetIfLineOfColHeaderExists(LineOfColHeaderExists);
        }
        public void SetStr(TableStructure Str) { this.Str = Str; }
        public void GetSize(TableSize size) { this.RowsQuantities = size; }
        public void SetUssagePolicy(TableUssagePolicy UssagePolicy) { this.UssagePolicy = UssagePolicy; }
        public void SetRepresentation_Text(TableRepresentation Repr) { this.Repr_Text = Repr; }
        public void SetRepresentation_Grid(TableRepresentation Repr) { this.Repr_Grid = Repr; }
        //
        public void SetRepresentationGeneral_Text(TableGeneralRepresentation ReprGen)
        {
            if (this.Repr_Text == null) this.Repr_Text = new TableRepresentation();
            this.Repr_Text.SetGeneralRepresentation(ReprGen);
        }
        public void SetRepresentationGeneral_Grid(TableGeneralRepresentation ReprGen)
        {
            if (this.Repr_Grid == null) this.Repr_Grid = new TableRepresentation();
            this.Repr_Grid.SetGeneralRepresentation(ReprGen);
        }
        public void SetContentCellRepresentation_Text(TableContentCellRepresentation Repr)
        {
            if (this.Repr_Text == null) this.Repr_Text = new TableRepresentation();
            this.Repr_Text.SetContentRepr(Repr);
        }
        public void SetContentCellRepresentation_Grid(TableContentCellRepresentation Repr)
        {
            if (this.Repr_Grid == null) this.Repr_Grid = new TableRepresentation();
            this.Repr_Grid.SetContentRepr(Repr);
        }
        public void SetLineHeaderCellRepresentation_Text(TableHeaderCellRepresentation Repr)
        {
            if (this.Repr_Text == null) this.Repr_Text = new TableRepresentation();
            this.Repr_Text.SetLineHeaderRepr(Repr);
        }
        public void GetLineHeaderCellRepresentation_Grid(TableHeaderCellRepresentation Repr)
        {
            if (this.Repr_Grid == null) this.Repr_Grid = new TableRepresentation();
            this.Repr_Grid.SetLineHeaderRepr(Repr);
        }
        public void SetColHeaderCellRepresentation_Text(TableHeaderCellRepresentation Repr)
        {
            if (this.Repr_Text == null) this.Repr_Text = new TableRepresentation();
            this.Repr_Text.SetColHeaderRepr(Repr);
        }
        public void SetColHeaderCellRepresentation_Grid(TableHeaderCellRepresentation Repr)
        {
            if (this.Repr_Grid == null) this.Repr_Grid = new TableRepresentation();
            this.Repr_Grid.SetColHeaderRepr(Repr);
        }
        public void SetContentCellLineHeaderRepresentation_Text(TableHeaderCellRepresentation Repr)
        {
            if (this.Repr_Text == null) this.Repr_Text = new TableRepresentation();
            this.Repr_Text.SetLineHeaderReprOfContentCell(Repr);
        }
        public void SetContentCellLineHeaderRepresentation_Grid(TableHeaderCellRepresentation Repr)
        {
            if (this.Repr_Grid == null) this.Repr_Grid = new TableRepresentation();
            this.Repr_Grid.SetLineHeaderReprOfContentCell(Repr);
        }
        public void SetContentCellColumnHeaderRepresentation_Text(TableHeaderCellRepresentation Repr)
        {
            if (this.Repr_Text == null) this.Repr_Text = new TableRepresentation();
            this.Repr_Text.SetColHeaderReprOfContentCell(Repr);
        }
        public void SetContentCellColumnHeaderRepresentation_Grid(TableHeaderCellRepresentation Repr)
        {
            if (this.Repr_Grid == null) this.Repr_Grid = new TableRepresentation();
            this.Repr_Grid.SetColHeaderReprOfContentCell(Repr);
        }
        //
        void CreateReprTextIfNull()
        {

        }
        void CreateReprGridIfNull()
        {

        }
        void CreateReprTextDetsIfNull()
        {

        }
        void CreateReprGridDetsIfNull()
        {

        }
        void CreateReprTextNumIfNull()
        {

        }
        void CreateReprGridNumIfNull()
        {

        }
        void CreateReprTextGenReprIfNull()
        {

        }
        void CreateReprGridGenReprIfNull()
        {

        }
        void CreateReprTextContentReprIfNull()
        {

        }
        void CreateReprContentGenReprIfNull()
        {

        }
        //
        public TRowsNumeration GetRowsNumeration_OrCreateDefault()
        {
            TRowsNumeration num=null;
            if (this.Repr_Grid != null)
            {
                if (this.Repr_Grid.num != null) num = this.Repr_Grid.num;
                else if (this.Repr_Grid.dets != null && this.Repr_Grid.dets.GenRepr != null)
                {
                    num = new TRowsNumeration(this.Repr_Grid.dets.GenRepr.LinesNumerationStartFromN, this.Repr_Grid.dets.GenRepr.ColumnsNumerationStartFromN, this.Repr_Grid.dets.GenRepr.LinesNumerationStep, this.Repr_Grid.dets.GenRepr.ColumnsNumerationStep);
                }
                else num = new TRowsNumeration();
            }
            else num = new TRowsNumeration();
            return num;
        }
        //
        public int CalcNumNOfLineNatN(int Nl, TRowsNumeration numExt)
        {
            int Nr;
            TRowsNumeration num;
            if (numExt != null) num = numExt;
            else num = this.GetRowsNumeration_OrCreateDefault();
            Nr = num.GetErstLineN() + (Nl - 1) * num.GetLinesNsStep();
            return Nr;
        }
        
        public int CalcNumNOfColumnNatN(int Nc, TRowsNumeration numExt)
        {
            int Nr;
            TRowsNumeration num;
            if (numExt != null) num = numExt;
            else num = this.GetRowsNumeration_OrCreateDefault();
            Nr = num.GetErstColumnN() + (Nc - 1) * num.GetColumnsNsStep();
            return Nr;
        }
        public int CalcNumNOfDisplayedLineNatN(int Nd, CellsNsToDisplay displNsExt, TRowsNumeration numExt)
        {
            int NToDisplFin, NTbl;
            CellsNsToDisplay displNs;
            if (displNsExt != null) displNs = displNsExt;
            else displNs = new CellsNsToDisplay(this.GetSize());
            NTbl = displNs.NsToDispl.ErstLineN + Nd - 1;
            NToDisplFin = CalcNumNOfLineNatN(NTbl, numExt);
            return NToDisplFin;
        }
        public int CalcNumNOfDisplayedColNatN(int Nd, CellsNsToDisplay displNsExt, TRowsNumeration numExt)
        {
            int NToDisplFin, NTbl;
            CellsNsToDisplay displNs;
            if (displNsExt != null) displNs = displNsExt;
            else displNs = new CellsNsToDisplay(this.GetSize());
            NTbl = displNs.NsToDispl.ErstColumnN + Nd - 1;
            NToDisplFin = CalcNumNOfColumnNatN(NTbl, numExt);
            return NToDisplFin;
        }
    }//class 7 TableInfo
    public class TableHeaderRowsExistance : ICloneable
    {
        public bool ColOfLineHeaderExists, LineOfColHeaderExists;
        //
        public TableHeaderRowsExistance()
        {
            ColOfLineHeaderExists = true;
            LineOfColHeaderExists = true;
        }
        public TableHeaderRowsExistance(bool ColOfLineHeaderExists, bool LineOfColHeaderExists)
        {
            this.ColOfLineHeaderExists = ColOfLineHeaderExists;
            this.LineOfColHeaderExists = LineOfColHeaderExists;
        }
        public void Set(bool ColOfLineHeaderExists, bool LineOfColHeaderExists)
        {
            this.ColOfLineHeaderExists = ColOfLineHeaderExists;
            this.LineOfColHeaderExists = LineOfColHeaderExists;
        }
        public void Get(ref bool ColOfLineHeaderExists, ref bool LineOfColHeaderExists)
        {
            ColOfLineHeaderExists=this.ColOfLineHeaderExists;
            LineOfColHeaderExists=this.LineOfColHeaderExists;
        }
        public bool GetIfLineOfColHeaderExists()
        {
            return LineOfColHeaderExists;
        }
        public bool GetIfColOfLineHeaderExists()
        {
            return ColOfLineHeaderExists;
        }
        public void SetIfLineOfColHeaderExists(bool LineOfColHeaderExists)
        {
            this.LineOfColHeaderExists = LineOfColHeaderExists;
        }
        public void SetIfColOfLineHeaderExists(bool ColOfLineHeaderExists)
        {
            this.ColOfLineHeaderExists = ColOfLineHeaderExists;
        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
    public class TableStructure:ICloneable //cl 8
    {
        public bool ColOfLineHeaderExists, LineOfColHeaderExists, LC_Matrix_Not_CL_DB;
        public TableStructure()
        {
            ColOfLineHeaderExists = true;
            LineOfColHeaderExists = true;
            LC_Matrix_Not_CL_DB = true;
        }
        public TableStructure(bool LC_Matrix_Not_CL_DB, bool ColOfLineHeaderExists, bool LineOfColHeaderExists)
        {
            SetInfo(LC_Matrix_Not_CL_DB, ColOfLineHeaderExists, LineOfColHeaderExists);
        }
        public TableStructure(int LC_Matrix_1_CL_DB_0, int ColOfLineHeaderExists_No0Yes1, int LineOfColHeaderExists_No0Yes1)
        {
            SetInfo(LC_Matrix_1_CL_DB_0, ColOfLineHeaderExists_No0Yes1, LineOfColHeaderExists_No0Yes1);
        }
        public object Clone()
        {
            //return new TableStructure(this.LC_Matrix_Not_CL_DB, this.ColOfLineHeaderExists, this.LineOfColHeaderExists);
            return this.MemberwiseClone();
        }
        public void SetInfo(bool LC_Matrix_Not_CL_DB, bool ColOfLineHeaderExists, bool LineOfColHeaderExists)
        {
            this.LC_Matrix_Not_CL_DB = LC_Matrix_Not_CL_DB;
            this.ColOfLineHeaderExists = ColOfLineHeaderExists;
            this.LineOfColHeaderExists = LineOfColHeaderExists;
        }
        public void SetInfo(int LC_Matrix_1_CL_DB_0, int ColOfLineHeaderExists_No0Yes1, int LineOfColHeaderExists_No0Yes1)
        {
            this.LC_Matrix_Not_CL_DB = MyLib.IntToBool(LC_Matrix_1_CL_DB_0);
            this.ColOfLineHeaderExists = MyLib.IntToBool(ColOfLineHeaderExists_No0Yes1);
            this.LineOfColHeaderExists = MyLib.IntToBool(LineOfColHeaderExists_No0Yes1);
        }
        public bool GetIf_LC_Not_CL()
        {
            return LC_Matrix_Not_CL_DB;
        }
        public bool GetIfLineOfColHeaderExists()
        {
            return LineOfColHeaderExists;
        }
        public bool GetIfColOfLineHeaderExists()
        {
            return ColOfLineHeaderExists;
        }
        public void SetIf_LC_Not_CL(bool LC_Matrix_Not_CL_DB)
        {
            this.LC_Matrix_Not_CL_DB = LC_Matrix_Not_CL_DB;
        }
        public void SetIfLineOfColHeaderExists(bool LineOfColHeaderExists)
        {
            this.LineOfColHeaderExists = LineOfColHeaderExists;
        }
        public void SetIfColOfLineHeaderExists(bool ColOfLineHeaderExists)
        {
            this.ColOfLineHeaderExists = ColOfLineHeaderExists;
        }
        TableHeaderRowsExistance GetTableHeaderRowsExistance()
        {
            TableHeaderRowsExistance obj;
            obj = new TableHeaderRowsExistance(this.ColOfLineHeaderExists, this.LineOfColHeaderExists);
            return obj;
        }
        void SetTableHeaderRowsExistance(TableHeaderRowsExistance obj)
        {
            this.ColOfLineHeaderExists = obj.ColOfLineHeaderExists;
            this.LineOfColHeaderExists = obj.LineOfColHeaderExists;
        }
        /*public void Get(ref bool LC_Matrix_Not_CL_DB, ref bool LineOfColHeaderExists, ref bool ColOfLineHeaderExists) { }
        public void Get(ref int LC_Matrix_Not_CL_DB, ref int LineOfColHeaderExists, ref int ColOfLineHeaderExists) { }
        public int Get(){}
        public void Set(bool LC_Matrix_Not_CL_DB, bool LineOfColHeaderExists, bool ColOfLineHeaderExists) { }
        public void Set(int LC_Matrix_Not_CL_DB, int LineOfColHeaderExists, int ColOfLineHeaderExists) { }
        public int Set();*/
    } //cl 8 TableStructure
    //mark1
    public class TableSize:ICloneable //cl 9
    {
        public int QColumns, QLines;
        //public TableRowsQuantities()
        //{
        //    QColumns = 1; QLines = 1;
        //}
        //public TableRowsQuantities(int QColumns, int QLines)
        //{
        //    this.QColumns = QColumns; this.QLines = QLines;
        //}
        public TableSize()
        {
            QColumns = 1; QLines = 1;
        }
        public TableSize(int QLines, int QColumns) { Set(QLines, QColumns); }
        public object Clone()
        {
            //return new TableSize(this.QLines, this.QColumns);
            return this.MemberwiseClone();
        }
        public void SetQLines(int QLines) { this.QLines = QLines; }
        public void SetQColumns(int QColumns) { this.QColumns = QColumns; }
        public void Set(int QLines, int QColumns) { this.QLines = QLines; this.QColumns = QColumns; }
        public int GetQLines() { return QLines; }
        public int GetQColumns() { return QColumns; }
        public override string ToString()
        {
            string s = "";
            //return base.ToString();
            s = " TableSize: L=" + this.QLines.ToString() + " C=" + this.QColumns.ToString()+" ";
            return s;
        }
    } //cl 9 TableSize
    //
    //Group of classes - Representation in text public class CellsNsToDisplay:ICloneable //cl 17 or 10
    public class CellsNsToDisplayShort : ICloneable
    {
        //public TableSize ErstShownContentRowsNs, QShownContentRows, QShownRowHeaderNames;
        public int ErstLineN, QLines, ErstColumnN, QColumns;
        //
        //public int QColumnsNamesToDisplay;//, QLinesNamesToDisplay;
        //public int QLinesNamesToDisplay; //for full generalization
        //
        //public int LimOfQNames_Strict0Max1Min2;
        //Strict - klar, Max - by real set, ma no more than hic lim, Min - by real set, ma no less re hic lim
        //
        public CellsNsToDisplayShort()
        {
            SetOne();
        }
        //public CellsNsToDisplayShort(int QLines, int QColumns, int ErstLineN, int ErstColumnN, int QColumnsNamesToDisplay, int QLinesNamesToDisplay, TableSize sizeExt = null)
        //{
        //    this.ErstLineN = ErstLineN;
        //    this.QLines = QLines;
        //    this.ErstColumnN = ErstColumnN;
        //    this.QColumns = QColumns;
        //    //
        //    QColumnsNamesToDisplay = 1;
        //    //
        //    QLinesNamesToDisplay = 1;
        //    //
        //    Correct(sizeExt);
        //}
        public CellsNsToDisplayShort(int QLines, int QColumns, int ErstLineN = 1, int ErstColumnN = 1,  TableSize sizeExt = null)
        {
            //QColumnsNamesToDisplay = 1; QLinesNamesToDisplay = 1;
            this.ErstLineN = ErstLineN;
            this.QLines = QLines;
            this.ErstColumnN = ErstColumnN;
            this.QColumns = QColumns;
            //
            //QColumnsNamesToDisplay = 1;
            //
            //QLinesNamesToDisplay = 1;
            //
            Correct(sizeExt);
        }
        public CellsNsToDisplayShort(TableSize sizeExt)
        {
            //SetAll(sizeExt);
            SetGeneral(sizeExt);
        }
        public object Clone()
        {
            //return new CellsNsToDisplay(this.QLines, this.QColumns, this.ErstLineN, this.ErstColumnN, this.QColumnsNamesToDisplay, this.QLinesNamesToDisplay);
            return this.MemberwiseClone();
        }
        //
        public void AddLine(){
            this.QLines++;
        }
        public void AddColumn(){
            this.QColumns++;
        }
        public void DelLine(){
            if (this.QLines > 1) this.QLines--;
        }
        public void DelColumn(){
            if (this.QColumns > 1) this.QColumns--;
        }
        //
        public int GetQShownContentLines() {
            //return QShownContentRows.QLines;
            return QLines;
        }
        public int GetQShownContentColumns() {
            //return QShownContentRows.QColumns;
            return QColumns;
        }
        public int GetErstShownContentLineN() {
            //return ErstShownContentRowsNs.QLines;
            return ErstLineN;
        }
        public int GetErstShownContentColumnN() {
            //return ErstShownContentRowsNs.QColumns;
            return ErstColumnN;
        }
        //
        public void SetQShownContentLines(int QShownContentLines, TableSize TableSizeExt=null)
        {
            //if (TableSizeExt == null || (TableSizeExt != null && TableSizeExt.QLines <= QShownContentLines))  this.QLines = QShownContentLines; QShownContentRows.QLines;
            if (TableSizeExt == null || (TableSizeExt != null && TableSizeExt.QLines <= QShownContentLines))  this.QLines = QShownContentLines;
        }
        public void SetQShownContentColumns(int QShownContentColumns, TableSize TableSizeExt = null)
        {
            //return QShownContentRows.QColumns;
            if (TableSizeExt == null || (TableSizeExt != null && TableSizeExt.QLines <= QShownContentColumns)) this.QColumns = QShownContentColumns;
        }
        public void SetErstShownContentLineN(int ErstShownContentLineN, TableSize TableSizeExt = null)
        {
            //return ErstShownContentRowsNs.QLines;
            if (TableSizeExt == null || (TableSizeExt != null && TableSizeExt.QLines >= ErstShownContentLineN)) this.ErstLineN = ErstShownContentLineN;
        }
        public void SetErstShownContentColumnN(int ErstShownContentColumnN, TableSize TableSizeExt = null)
        {
            //return ErstShownContentRowsNs.QColumns;
            if (TableSizeExt == null || (TableSizeExt != null && TableSizeExt.QColumns >= ErstShownContentColumnN)) this.ErstColumnN = ErstShownContentColumnN;
        }
        //
        public void SetAll(TableSize sizeExt)
        {
            //TableInfo TblInf;
            //if (TblInfExt != null) TblInf = TblInfExt;
            //else TblInf = new TableInfo();
            //if (TblInf.Str == null) TblInf.Str = new TableStructure();
            //if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            TableSize size;
            if (sizeExt!= null) size=sizeExt; else size = new TableSize();
            //
            ErstLineN = 1; QLines = size.GetQLines(); ErstColumnN = 1; QColumns = size.GetQColumns();
            //
            //QColumnsNamesToDisplay = 3;
            //
            //QLinesNamesToDisplay = 1;
        }
        public void SetGeneral(TableSize sizeExt)
        {
            //TableInfo TblInf;
            //if (TblInfExt != null) TblInf = TblInfExt;
            //else TblInf = new TableInfo();
            //if (TblInf.Str == null) TblInf.Str = new TableStructure();
            //if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            ErstLineN = 1; QLines = size.GetQLines(); ErstColumnN = 1; QColumns = size.GetQColumns();
            //
            //QColumnsNamesToDisplay = 1;
            //
            //QLinesNamesToDisplay = 1;
        }
        public void SetOne()
        {
            ErstLineN = 1; QLines = 1; ErstColumnN = 1; QColumns = 1;
            //
            //QColumnsNamesToDisplay = 1;
            //
            //QLinesNamesToDisplay = 1;
        }
        public void Set(int ErstLineN, int QLines, int ErstColumnN, int QColumns)//, int QColumnsNamesToDisplay = 1, int QLinesNamesToDisplay = 1)
        {
            this.ErstLineN = ErstLineN; this.QLines = QLines; this.ErstColumnN = ErstColumnN; this.QColumns = QColumns;
            //
            //this.QColumnsNamesToDisplay = QColumnsNamesToDisplay;
            //
            //this.QLinesNamesToDisplay = QLinesNamesToDisplay;
        }
        public void Correct(TableSize sizeExt)
        {
            //TableInfo TblInf;
            //if (TblInfExt != null) TblInf = TblInfExt;
            //else TblInf = new TableInfo();
            //if (TblInf.Str == null) TblInf.Str = new TableStructure();
            //if (TblInf.RowsQuantities == null) TblInf.RowsQuantities = new TableSize();
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            //
            int QLinesMax = size.GetQLines();
            int QColumnsMax = size.GetQColumns();
            //
            //
            if (this.QLines < 1) this.QLines = 1;
            if (this.QColumns < 1) this.QColumns = 1;
            if (this.QLines > QLinesMax) this.QLines = QLinesMax;
            if (this.QColumns > QColumnsMax) this.QColumns = QColumnsMax;
            //
            if (this.ErstLineN < 1) this.ErstLineN = 1;
            if (this.ErstColumnN < 1) this.ErstColumnN = 1;
            if (this.ErstLineN > QLinesMax) this.ErstLineN = this.QLines;
            if (this.ErstColumnN > QColumnsMax) this.ErstColumnN = this.QColumns;
            //
            //
            if (this.ErstLineN + this.QLines - 1 > QLinesMax) this.QLines = QLinesMax - this.ErstLineN + 1;
            if (this.ErstColumnN + this.QColumns - 1 > QColumnsMax) this.QColumns = QColumnsMax - this.ErstColumnN + 1;
        }
        //
        public void AddPrevLineToShow(TableSize sizeExt)
        {
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            if (ErstLineN > 1)
            {
                ErstLineN--;
                QLines++;
            }
            //
            Correct(size);
        }
        public void AddNextLineToShow(TableSize sizeExt)
        {
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            if (QLines < size.GetQLines()) QLines++;
            //
            Correct(size);
        }
        public void ExcludeLineFromForwardFromShown(TableSize sizeExt)
        {
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            if (QLines > 1)
            {
                ErstLineN++;
                QLines--;
            }
            //
            Correct(sizeExt);
        }
        public void ExcludeLineFromBackwardFromShown(TableSize sizeExt)
        {
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            if (QLines > 1) QLines--;
            //
            Correct(size);
        }
        public void ShiftLinesForward(TableSize sizeExt)
        {
            int LastShownLineN, LastExistingLineN, QExistingLines;
            TableSize size;
            //
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            QExistingLines=size.GetQLines();
            LastShownLineN = ErstLineN + QLines - 1;
            LastExistingLineN = QExistingLines;
            //
            if (LastShownLineN < LastExistingLineN) ErstLineN++;
            //
            Correct(size);
        }
        public void ShiftLinesBackward(TableSize sizeExt)
        {
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            if (ErstLineN > 1) ErstLineN--;
            //
            Correct(size);
        }
        // L C
        public void AddPrevColumnToShow(TableSize sizeExt)
        {
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            if (ErstColumnN > 1)
            {
                ErstColumnN--;
                QColumns++;
            }
            //
            Correct(size);
        }
        public void AddNextColumnToShow(TableSize sizeExt)
        {
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            if (QColumns < size.GetQColumns()) QColumns++;
            //
            Correct(size);
        }
        public void ExcludeColumnFromForwardFromShown(TableSize sizeExt)
        {
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            if (QColumns > 1)
            {
                ErstColumnN++;
                QColumns--;
            }
            //
            Correct(sizeExt);
        }
        public void ExcludeColumnFromBackwardFromShown(TableSize sizeExt)
        {
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            if (QColumns > 1) QColumns--;
            //
            Correct(size);
        }
        public void ShiftColumnsForward(TableSize sizeExt)
        {
            int LastShownColumnN, LastExistingColumnN, QExistingColumns;
            TableSize size;
            //
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            QExistingColumns = size.GetQColumns();
            LastShownColumnN = ErstColumnN + QColumns - 1;
            LastExistingColumnN = QExistingColumns;
            //
            if (LastShownColumnN < LastExistingColumnN) ErstColumnN++;
            //
            Correct(size);
        }
        public void ShiftColumnsBackward(TableSize sizeExt)
        {
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            //
            if (ErstColumnN > 1) ErstColumnN--;
            //
            Correct(size);
        }
        //
        public bool LastLineIsToShow(TableSize sizeExt)
        {
            bool verdict;
            int QLinesExisting, LastShownLineN, LastExistingLineN;
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            Correct(size);
            QLinesExisting = size.GetQLines();
            LastExistingLineN = QLinesExisting;
            LastShownLineN = ErstLineN + QLines - 1;
            verdict = (LastShownLineN == LastExistingLineN);
            return verdict;
        }
        public bool LastColumnIsToShow(TableSize sizeExt)
        {
            bool verdict;
            int QColumnsExisting, LastShownColumnN, LastExistingColumnN;
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            Correct(size);
            QColumnsExisting = size.GetQColumns();
            LastExistingColumnN = QColumnsExisting;
            LastShownColumnN = ErstColumnN + QColumns - 1;
            verdict = (LastShownColumnN == LastExistingColumnN);
            return verdict;
        }
        public override string ToString()
        {
            //return base.ToString();
            string s = "";
            s = " CellsNsToDisplayShort: Lines: ErstN=" + this.ErstLineN.ToString() + " Q=" + this.QLines.ToString() + " Columns: ErstN=" + this.ErstColumnN.ToString() + " Q=" + this.QColumns.ToString() + " ";
            return s;
        }
    }// CellsNsToDisplayShort //cl 17 or 10 and grid
    public class CellsNsToDisplay : ICloneable
    {
        //public TableSize ErstShownContentRowsNs, QShownContentRows, QShownRowHeaderNames;
        public CellsNsToDisplayShort NsToDispl;
        public TableSize QRowsNamesToDisplay;
        //
        public void Construct(){
            this.NsToDispl=new CellsNsToDisplayShort();
            this.QRowsNamesToDisplay=new TableSize();
        }
        public CellsNsToDisplay()
        {
            SetOne();
        }
        public CellsNsToDisplay(CellsNsToDisplayShort NsToDispl, TableSize QRowsNamesToDisplay, TableSize sizeExt = null)
        {
            this.NsToDispl = NsToDispl;
            this.QRowsNamesToDisplay = QRowsNamesToDisplay;
            NsToDispl.Correct(sizeExt);
        }
        public CellsNsToDisplayShort GetNsToDisplay()
        {
            //return this.NsToDispl;
            return (CellsNsToDisplayShort)this.NsToDispl.Clone();
        }
        public TableSize GetQRowsNamesToDisplay()
        {
            //return this.QRowsNamesToDisplay;
            return (TableSize)this.QRowsNamesToDisplay.Clone();
        }
        public CellsNsToDisplay(TableSize sizeExt)
        {
            //SetAll(sizeExt);
            SetGeneral(sizeExt);
        }
        public object Clone()
        {
            CellsNsToDisplayShort NsToDispl=this.GetNsToDisplay();
            TableSize QRowsNamesToDisplay = this.GetQRowsNamesToDisplay();
            //
            //CellsNsToDisplayShort NsToDispl = (CellsNsToDisplayShort)this.GetNsToDisplay();
            //TableSize QRowsNamesToDisplay = this.GetQRowsNamesToDisplay();
            //CellsNsToDisplay obj = new CellsNsToDisplay(this.GetNsToDisplay(), this.GetQRowsNamesToDisplay());//correctin by tablesize
            CellsNsToDisplay obj = new CellsNsToDisplay();
            obj.NsToDispl =this.GetNsToDisplay();
            obj.QRowsNamesToDisplay=  this.GetQRowsNamesToDisplay();
            return obj;
        }
        //
        public void AddLine(){ this.NsToDispl.AddLine(); }
        public void AddColumn() { this.NsToDispl.AddColumn(); }
        public void DelLine() { this.NsToDispl.DelLine(); }
        public void DelColumn() { this.NsToDispl.DelColumn(); }
        //
        public int GetQShownContentLines()
        {
            //return QShownContentRows.QLines;
            return NsToDispl.GetQShownContentLines();
        }
        public int GetQShownContentColumns()
        {
            //return QShownContentRows.QColumns;
            return NsToDispl.GetQShownContentColumns();
        }
        public int GetErstShownContentLineN()
        {
            //return ErstShownContentRowsNs.QLines;
            return NsToDispl.GetErstShownContentLineN();
        }
        public int GetErstShownContentColumnN()
        {
            //return ErstShownContentRowsNs.QColumns;
            return NsToDispl.GetErstShownContentColumnN();
        }
        public int GetQLineHeaderNamesToShow()
        {
            //return QShownRowHeaderNames.QLines;
            return QRowsNamesToDisplay.GetQLines();
        }
        public int GetQColumnHeaderNamesToShow()
        {
            //return QShownRowHeaderNames.QColumns;
            return QRowsNamesToDisplay.GetQColumns();
        }
        //
        public void Set(CellsNsToDisplayShort NsToDispl, TableSize QRowsNamesToDisplay, TableSize sizeExt = null)
        {
            this.NsToDispl = NsToDispl;
            this.QRowsNamesToDisplay = QRowsNamesToDisplay;
            NsToDispl.Correct(sizeExt);
        }
        //
        public void SetQShownContentLines(int QShownContentLines, TableSize TableSizeExt = null)
        {
            this.NsToDispl.SetQShownContentLines(QShownContentLines, TableSizeExt);
        }
        public void SetQShownContentColumns(int QShownContentColumns, TableSize TableSizeExt = null)
        {
            this.NsToDispl.SetQShownContentColumns(QShownContentColumns, TableSizeExt);
        }
        public void SetErstShownContentLineN(int ErstShownContentLineN, TableSize TableSizeExt = null)
        {
            this.NsToDispl.SetErstShownContentLineN(ErstShownContentLineN, TableSizeExt);
        }
        public void SetErstShownContentColumnN(int ErstShownContentColumnN, TableSize TableSizeExt = null)
        {
            this.NsToDispl.SetErstShownContentColumnN(ErstShownContentColumnN, TableSizeExt);
        }
        //
        public void SetGetQLineHeaderNamesToShow(int QLineHeaderNamesToShow, TableStructure TableStrExt = null)
        {
            if (TableStrExt == null || (TableStrExt != null && TableStrExt.ColOfLineHeaderExists)) this.QRowsNamesToDisplay.SetQLines(QLineHeaderNamesToShow);
        }
        public void SetGetQColumnHeaderNamesToShow(int QColumnHeaderNamesToShow, TableStructure TableStrExt = null)
        {
            if (TableStrExt == null || (TableStrExt != null && TableStrExt.LineOfColHeaderExists)) this.QRowsNamesToDisplay.SetQColumns(QColumnHeaderNamesToShow);
        }
        //
        public void SetAll(TableSize sizeExt)
        {
            TableSize size;
            if (sizeExt != null) size = sizeExt; else size = new TableSize();
            this.NsToDispl = new CellsNsToDisplayShort(size.GetQLines(), size.GetQColumns(), 1, 1, size);
            this.QRowsNamesToDisplay=new TableSize(1, 3);
        }
        public void SetGeneral(TableSize sizeExt)
        {
            SetAll(sizeExt);
            this.QRowsNamesToDisplay.SetQLines(1);
            this.QRowsNamesToDisplay.SetQColumns(1);
        }
        public void SetOne()
        {
            this.NsToDispl = new CellsNsToDisplayShort(1, 1, 1, 1, null);
            this.QRowsNamesToDisplay = new TableSize(1, 1);
        }
        public void Set(int ErstLineN, int QLines, int ErstColumnN, int QColumns, int QColumnsNamesToDisplay = 1, int QLinesNamesToDisplay = 1)
        {
            this.NsToDispl = new CellsNsToDisplayShort(QLines, QColumns, ErstLineN, ErstColumnN, null);
            this.QRowsNamesToDisplay = new TableSize(QLinesNamesToDisplay, QColumnsNamesToDisplay);
        }
        public void Correct(TableSize sizeExt)
        {
            this.NsToDispl.Correct(sizeExt);
        }
        //
        public void AddPrevLineToShow(TableSize sizeExt)
        {
            this.NsToDispl.AddPrevLineToShow(sizeExt);
        }
        public void AddNextLineToShow(TableSize sizeExt)
        {
            this.NsToDispl.AddNextLineToShow(sizeExt);
        }
        public void ExcludeLineFromForwardFromShown(TableSize sizeExt)
        {
            this.NsToDispl.ExcludeLineFromForwardFromShown(sizeExt);
        }
        public void ExcludeLineFromBackwardFromShown(TableSize sizeExt)
        {
            this.NsToDispl.ExcludeLineFromBackwardFromShown(sizeExt);
        }
        public void ShiftLinesForward(TableSize sizeExt)
        {
            this.NsToDispl.ShiftLinesForward(sizeExt);
        }
        public void ShiftLinesBackward(TableSize sizeExt)
        {
            this.NsToDispl.ShiftLinesBackward(sizeExt);
        }
        // L C
        public void AddPrevColumnToShow(TableSize sizeExt)
        {
            this.NsToDispl.AddPrevColumnToShow(sizeExt);
        }
        public void AddNextColumnToShow(TableSize sizeExt)
        {
            this.NsToDispl.AddNextColumnToShow(sizeExt);
        }
        public void ExcludeColumnFromForwardFromShown(TableSize sizeExt)
        {
            this.NsToDispl.ExcludeColumnFromForwardFromShown(sizeExt);
        }
        public void ExcludeColumnFromBackwardFromShown(TableSize sizeExt)
        {
            this.NsToDispl.ExcludeColumnFromBackwardFromShown(sizeExt);
        }
        public void ShiftColumnsForward(TableSize sizeExt)
        {
            this.NsToDispl.ShiftColumnsForward(sizeExt);
        }
        public void ShiftColumnsBackward(TableSize sizeExt)
        {
            this.NsToDispl.ShiftColumnsBackward(sizeExt);
        }
        //
        public bool LastLineIsToShow(TableSize sizeExt)
        {
            return this.NsToDispl.LastLineIsToShow(sizeExt);
        }
        public bool LastColumnIsToShow(TableSize sizeExt)
        {
            return this.NsToDispl.LastColumnIsToShow(sizeExt);
        }
        public CellsNsToDisplayShort GetCellsNsToDisplayShort() { return NsToDispl; }
        public TableSize GetTableHeaderRowsExistance() { return QRowsNamesToDisplay; }
        //
        public override string ToString()
        {
            //return base.ToString();
            string s1="", s2="", s="";
            if (this.NsToDispl != null)
            {
                s1 = this.NsToDispl.ToString();
            }
            if (this.QRowsNamesToDisplay != null)
            {
                s2 = this.QRowsNamesToDisplay.ToString();
            }
            s = " CellsNsToDisplay: " + s1 + s2;
            return s;
        }
    }// CellsNsToDisplayFull
    //Group of classes 4 - TableFormAndGridRepresentation
    //public class Form
    public class TableFormAndGridConfigurationMain : ICloneable
    {
        //public int ArrOrBool_Simple0CentralLbox1CBoxJaLBoxNo2CboxNoLBoxJa3CBoxJaLBoxJa4;// = 1;
        public int BoolToCell_Simple0ChkB1Cmb2;
        public bool BoolToCmdLine_ItemsNotSimple;
        //public bool ArrToCell_ItemsNotSimple;
        public int ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2;
        public bool ArrToCmdLine_ItemsNotSimple;
        //
        public bool UseCmdLineComboBox;
        public bool UseCmdLineListBox;
        public bool AllowEditTableCells;
        //
        public int ModeTbl_Gui0Inner1Target2;
        public int WriteSettings_No0Yes1IfWrittenAlreadyOnly2;
        //
        public bool LoCHGridRowUsed, CoLHGridRowUsed;
        //
        //public bool LoCHGridCellsUsed, CoLHGridCellsUsed;
        //public int QColHeaderNames, QLineHeaderNames;
        //public int QColHeaderNamesFixed0ByMax1ByMin2, QLineHeaderNamesFixed0ByMax1ByMin2;
        //
        public TableFormAndGridConfigurationMain()
        {
            SetMainSettingsForUsualMenu();
            SetReprConvinient();
            SetGridAsMSVSLangsOrQt();
        }
        public TableFormAndGridConfigurationMain(int BoolToCell_Simple0ChkB1Cmb2, bool BoolToCmdLine_ItemsNotSimple, /*bool ArrToCell_ItemsNotSimple*/int ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2, bool ArrToCmdLine_ItemsNotSimple, int ModeTbl_Gui0Inner1Target2, int WriteSettings_No0Yes1IfWrittenAlreadyOnly2, TableHeaderRowsExistance HdrRowsUsedExt = null)
        {
            TableHeaderRowsExistance HdrRowsUsed = HdrRowsUsedExt;
            if (HdrRowsUsed == null) HdrRowsUsed = new TableHeaderRowsExistance();
            //
            this.BoolToCell_Simple0ChkB1Cmb2 = BoolToCell_Simple0ChkB1Cmb2;
            this.BoolToCmdLine_ItemsNotSimple = BoolToCmdLine_ItemsNotSimple;
            //this.ArrToCell_ItemsNotSimple = ArrToCell_ItemsNotSimple;
            this.ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2 = ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2;
            this.ArrToCmdLine_ItemsNotSimple = ArrToCmdLine_ItemsNotSimple;
            this.ModeTbl_Gui0Inner1Target2 = ModeTbl_Gui0Inner1Target2;
            this.WriteSettings_No0Yes1IfWrittenAlreadyOnly2 = WriteSettings_No0Yes1IfWrittenAlreadyOnly2;
            //
            this.CoLHGridRowUsed = HdrRowsUsed.ColOfLineHeaderExists;
            this.LoCHGridRowUsed = HdrRowsUsed.LineOfColHeaderExists;
        }
        public object Clone()
        {
            //return new TableFormAndGridRepresentation(this.BoolToCell_Simple0ChkB1Cmb2, this.BoolToCmdLine_ItemsNotSimple, this.ArrToCell_Simple0Cmb1, this.ArrToCmdLine_ItemsNotSimple, this.ModeTbl_Gui0Inner1Target2, this.WriteSettings_No0Yes1IfWrittenAlreadyOnly2);
            return this.MemberwiseClone();
        }
        public void SetMainSettingsForUsualMenu()
        {
            this.ModeTbl_Gui0Inner1Target2 = 1;
            this.WriteSettings_No0Yes1IfWrittenAlreadyOnly2 = 2;
            this.UseCmdLineComboBox = true;
            this.UseCmdLineListBox = false;
            this.AllowEditTableCells = true;
            //
            //ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2 = 1;
        }
        public void SetMainSettingsForTableConstructor()
        {
            this.ModeTbl_Gui0Inner1Target2 = 1;
            this.WriteSettings_No0Yes1IfWrittenAlreadyOnly2 = 2;
            this.UseCmdLineComboBox = false;
            this.UseCmdLineListBox = true;
            this.AllowEditTableCells = true;
        }
        public void SetGridAsBCppBiuilder()
        {
            this.CoLHGridRowUsed = false;
            this.LoCHGridRowUsed = false;
        }
        public void SetGridAsMSVSLangsOrQt()
        {
            this.CoLHGridRowUsed = true;
            this.LoCHGridRowUsed = true;
        }
        public TableHeaderRowsExistance GetHeaderRowsExistance()
        {
            TableHeaderRowsExistance R = new TableHeaderRowsExistance(CoLHGridRowUsed, LoCHGridRowUsed);
            return R;
        }
        public void GetHeaderRowsExistance(TableHeaderRowsExistance HeaderRowsExistance)
        {
            this.CoLHGridRowUsed = HeaderRowsExistance.ColOfLineHeaderExists;
            this.LoCHGridRowUsed = HeaderRowsExistance.LineOfColHeaderExists;
        }
        public TableFormAndGridConfigurationMain(TTable source)
        {
            SetFromTable(source);
        }
        public void SetReprSimplest()
        {
            this.BoolToCell_Simple0ChkB1Cmb2 = 0;
            this.BoolToCmdLine_ItemsNotSimple = false;
            //this.ArrToCell_ItemsNotSimple = false;
            this.ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2 = 0;
            this.ArrToCmdLine_ItemsNotSimple = false;
            //this.ModeTbl_Gui0Inner1Target2 = ModeTbl_Gui0Inner1Target2 = 1;
            //this.WriteSettings_No0Yes1IfWrittenAlreadyOnly2 = WriteSettings_No0Yes1IfWrittenAlreadyOnly2;
        }
        public void SetReprSimpleAsBuilder()
        {
            this.BoolToCell_Simple0ChkB1Cmb2 = 0;
            this.BoolToCmdLine_ItemsNotSimple = true;
            //this.ArrToCell_ItemsNotSimple = false;
            this.ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2 = 0;
            this.ArrToCmdLine_ItemsNotSimple = true;
        }
        public void SetReprConvinient()
        {
            //ArrOrBool_Simple0CentralLbox1CBoxJaLBoxNo2CboxNoLBoxJa3CBoxJaLBoxJa4 = 4;
            //ModeTbl_Gui0Inner1Target2 = 1;
            //WriteSettings_No0Yes1IfWrittenAlreadyOnly2 = 2;
            this.BoolToCell_Simple0ChkB1Cmb2 = 1;// 2;// 1;
            this.BoolToCmdLine_ItemsNotSimple = true;
            //this.ArrToCell_ItemsNotSimple = true;
            this.ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2 = 1; //2;//1;
            this.ArrToCmdLine_ItemsNotSimple = true;
        }
        public TTable GetAsTable()
        {
            int QLines = 11;// 10;// 8;
            TableInfo TblInf = new TableInfo(true, true, true, QLines, 1);
            TableUssagePolicy UsePol;
            DataCell acell;
            //int rowN = 0;
            string[] sarr = null;
            UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.ForbidToShowAndEditSettings();
            TblInf.UssagePolicy = UsePol;
            DataCellRowCoHeader[] rows = new DataCellRowCoHeader[QLines];
            //sarr=new string[5];
            //sarr=new string[5];
            //sarr[1 - 1] = "Simple";
            //sarr[2 - 1] = "CentralLbox1";
            //sarr[3 - 1] = "CBox-Ja, LBox-No";
            //sarr[4 - 1] = "Cbox-No,LBox-Ja";
            //sarr[5 - 1] = "Cbox-Ja,LBox-Ja";
            //acell = new DataCell(sarr, 5);
            ////acell.SetActiveN(5);
            //acell.SetActiveN(this.ArrOrBool_Simple0CentralLbox1CBoxJaLBoxNo2CboxNoLBoxJa3CBoxJaLBoxJa4+1);
            //rows[1 - 1] = new DataCellRowCoHeader(new DataCell("Choice Interface"), new DataCellRow(acell));
            //rowN++;
            sarr = new string[3];
            sarr[1 - 1] = "Simple";
            sarr[2 - 1] = "CheckBox";
            sarr[3 - 1] = "ComboBox";
            acell = new DataCell(sarr, 3);
            //acell.SetActiveN(5);
            acell.SetActiveN(this.BoolToCell_Simple0ChkB1Cmb2 + 1);
            rows[1 - 1] = new DataCellRowCoHeader(new DataCell("Bool To Cell"), new DataCellRow(acell));
            //
            acell = new DataCell(this.BoolToCmdLine_ItemsNotSimple);
            //acell.SetActiveN(5);
            //acell.SetActiveN(this.BoolToCell_Simple0ChkB1Cmb2 + 1);
            rows[2 - 1] = new DataCellRowCoHeader(new DataCell("Bool To CmdLineComboBox"), new DataCellRow(acell));
            //
            //acell = new DataCell(this.ArrToCell_ItemsNotSimple);
            //acell = new DataCell(this.ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2);
            sarr = new string[4];
            sarr[1 - 1] = "checkbox";
            sarr[2 - 1] = "simpletext";
            sarr[3 - 1] = "combobox";
            sarr[4 - 1] = "multylinetextbox";
            acell = new DataCell(sarr, 4);
            acell.SetActiveN(this.ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2 + 2);
            //sarr = new string[3];
            //sarr[1 - 1] = "simpletext";
            //sarr[2 - 1] = "combobox";
            //sarr[3 - 1] = "multylinetextbox";
            //acell = new DataCell(sarr, 3);
            //acell.SetActiveN(this.ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2 + 1);
            rows[3 - 1] = new DataCellRowCoHeader(new DataCell("Array To Cell"), new DataCellRow(acell));
            //
            acell = new DataCell(this.ArrToCmdLine_ItemsNotSimple);
            //acell.SetActiveN(5);
            //acell.SetActiveN(this.BoolToCell_Simple0ChkB1Cmb2 + 1);
            rows[4 - 1] = new DataCellRowCoHeader(new DataCell("Array To CmdLineComboBox"), new DataCellRow(acell));
            //
            sarr = new string[3];
            sarr[1 - 1] = "GUI";
            sarr[2 - 1] = "InnerBufferTable";
            sarr[3 - 1] = "TargetTable";
            acell = new DataCell(sarr, 3);
            //acell.SetActiveN(2);
            acell.SetActiveN(this.ModeTbl_Gui0Inner1Target2 + 1);
            rows[5 - 1] = new DataCellRowCoHeader(new DataCell("Working table Mode"), new DataCellRow(acell));
            //
            sarr = new string[3];
            sarr[1 - 1] = "No anyhow";
            sarr[2 - 1] = "Yes anyhow";
            sarr[3 - 1] = "If written";
            acell = new DataCell(sarr, 3);
            //acell.SetActiveN(3);
            acell.SetActiveN(this.WriteSettings_No0Yes1IfWrittenAlreadyOnly2 + 1);
            rows[6 - 1] = new DataCellRowCoHeader(new DataCell("Write Settings"), new DataCellRow(acell));
            //
            acell = new DataCell(this.UseCmdLineComboBox);
            rows[7 - 1] = new DataCellRowCoHeader(new DataCell("Use CmdLineComboBox"), new DataCellRow(acell));
            //
            acell = new DataCell(this.UseCmdLineListBox);
            rows[8 - 1] = new DataCellRowCoHeader(new DataCell("Use CmdLineListBox"), new DataCellRow(acell));
            //
            acell = new DataCell(this.AllowEditTableCells);
            rows[9 - 1] = new DataCellRowCoHeader(new DataCell("Allow EditTableCells"), new DataCellRow(acell));
            //
            //
            acell = new DataCell(this.LoCHGridRowUsed);
            rows[10 - 1] = new DataCellRowCoHeader(new DataCell("LoCHGridRowUsed"), new DataCellRow(acell));
            acell = new DataCell(this.CoLHGridRowUsed);
            rows[11 - 1] = new DataCellRowCoHeader(new DataCell("CoLHGridRowUsed"), new DataCellRow(acell));
            //
            TTable tbl;
            tbl = new TTable(
                TblInf,
                false,
                rows,
                new DataCellRow(new DataCell("Values")),
                new TableHeaders(new DataCell("Table Form and Grid Settings"), new DataCell("Values"), new DataCell("")),
                true
                );
            //

            return tbl;
        }
        public void SetFromTable(TTable tbl)
        {
            int zero = 0;
            //this.ArrOrBool_Simple0CentralLbox1CBoxJaLBoxNo2CboxNoLBoxJa3CBoxJaLBoxJa4 = tbl.GetActiveN(1, 1)-1;
            this.BoolToCell_Simple0ChkB1Cmb2 = tbl.GetActiveN(1, 1) - 1;
            //this.BoolToCell_Simple0ChkB1Cmb2 = tbl.GetIntVal(1, 1) - 1;
            this.BoolToCmdLine_ItemsNotSimple = tbl.GetBoolVal(2, 1);
            //this.ArrToCell_ItemsNotSimple = tbl.GetBoolVal(3, 1);
            //this.ArrToCell_ItemsNotSimple = tbl.GetBoolVal(3, 1);
            //this.ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2 = tbl.GetActiveN(3, 1)-1;
            this.ArrToCell_ChkBxMinus1Simple0Cmb1MultyLineTextBox2 = tbl.GetActiveN(3, 1) - 2;
            this.ArrToCmdLine_ItemsNotSimple = tbl.GetBoolVal(4, 1);
            this.ModeTbl_Gui0Inner1Target2 = tbl.GetActiveN(5, 1) - 1;
            this.WriteSettings_No0Yes1IfWrittenAlreadyOnly2 = tbl.GetActiveN(6, 1) - 1;
            this.UseCmdLineComboBox = tbl.GetBoolVal(7, 1);
            this.UseCmdLineListBox = tbl.GetBoolVal(8, 1);
            this.AllowEditTableCells = tbl.GetBoolVal(9, 1);
            //
            this.LoCHGridRowUsed = tbl.GetBoolVal(10, 1);
            this.CoLHGridRowUsed = tbl.GetBoolVal(11, 1);
        }
    }//cl TableFormAndGridRepresentation -> TableFormAndGridConfigurationMain//cl TableFormAndGridRepresentation -> TableFormAndGridConfigurationMain
    //public class GridRepresentationSuppl{
    //    public bool LoCHGridCellsUsed, CoLHGridCellsUsed;
    //    public int QColHeaderNames, QLineHeaderNames;
    //    public GridRepresentationSuppl()
    //    {
    //        LoCHGridCellsUsed = true; CoLHGridCellsUsed = true;
    //        QColHeaderNames = 3; QLineHeaderNames = 3;
    //    }
    //}
	//mark1
    //public class TableFormAndGridConfigurationAll
    //{
    //    public TableFormAndGridConfigurationMain FormAndGridCellCfgMain;
    //    public CellsNsToDisplay CellNsToShow;
    //    public TableRepresentation TableRepr;
    //    //
    //    public TableFormAndGridConfigurationAll(TableSize sizeExt = null)
    //    {
    //        TableSize size;
    //        if (sizeExt != null) size = sizeExt; else size = new TableSize();
    //        CellNsToShow = new CellsNsToDisplay(size); // by silence SetOne() //1 cell to display
    //        FormAndGridCellCfgMain = new TableFormAndGridConfigurationMain();
    //        TableRepr = new TableRepresentation();
    //    }
    //    public TableFormAndGridConfigurationAll(TableFormAndGridConfigurationMain FormAndGridCellCfgMain, CellsNsToDisplay CellNsToShow, TableHeaderRowsExistance GridHeaderRowsUsed, TableRepresentation TableRepr, TableSize sizeExt = null)
    //    {
    //        TableSize size;
    //        if (sizeExt != null) size = sizeExt; else size = new TableSize();
    //        this.FormAndGridCellCfgMain = FormAndGridCellCfgMain;
    //        this.CellNsToShow = CellNsToShow;
    //        this.TableRepr = TableRepr;
    //    }
    //    public void Set(TableFormAndGridConfigurationMain FormAndGridCellCfgMain, CellsNsToDisplay CellNsToShow, TableHeaderRowsExistance GridHeaderRowsUsed, TableRepresentation TableRepr, TableSize sizeExt = null)
    //    {
    //        TableSize size;
    //        if (sizeExt != null) size = sizeExt; else size = new TableSize();
    //        this.FormAndGridCellCfgMain = FormAndGridCellCfgMain;
    //        this.CellNsToShow = CellNsToShow;
    //        this.TableRepr = TableRepr;
    //    }
    //    void SetTableFormAndGridCellConfigurationMain(TableFormAndGridConfigurationMain FormAndGridCellCfgMain)
    //    {
    //        this.FormAndGridCellCfgMain = FormAndGridCellCfgMain;
    //    }
    //    void SetCellsNsToDisplay(CellsNsToDisplay CellNsToShow)
    //    {
    //        this.CellNsToShow = CellNsToShow;
    //    }
    //    void SetTableHeaderRowsExistance(TableHeaderRowsExistance GridHeaderRowsUsedExt)
    //    {
    //        TableHeaderRowsExistance GridHeaderRowsUsed;
    //        if (GridHeaderRowsUsedExt != null) GridHeaderRowsUsed = GridHeaderRowsUsedExt;
    //        else GridHeaderRowsUsed = new TableHeaderRowsExistance();
    //        this.FormAndGridCellCfgMain.LoCHGridRowUsed = GridHeaderRowsUsed.LineOfColHeaderExists;
    //        this.FormAndGridCellCfgMain.CoLHGridRowUsed = GridHeaderRowsUsed.ColOfLineHeaderExists;
    //    }
    //    void SetTableRepresentation(TableRepresentation TableRepr)
    //    {
    //        this.TableRepr = TableRepr;
    //    }
    //    TableFormAndGridConfigurationMain GetTableFormAndGridCellConfigurationMain()
    //    {
    //        return FormAndGridCellCfgMain;
    //    }
    //    CellsNsToDisplay GetCellsNsToDisplay()
    //    {
    //        return CellNsToShow;
    //    }
    //    TableHeaderRowsExistance GetTableHeaderRowsExistance()
    //    {
    //        TableHeaderRowsExistance GridHeaderRowsUsed = new TableHeaderRowsExistance(this.FormAndGridCellCfgMain.CoLHGridRowUsed, this.FormAndGridCellCfgMain.LoCHGridRowUsed);
    //        return GridHeaderRowsUsed;
    //    }
    //    TableRepresentation GetTableRepresentation()
    //    {
    //        return TableRepr;
    //    }
    //    //
    //    public void SetMainSettingsUsual()
    //    {
    //        FormAndGridCellCfgMain.SetMainSettingsUsual();
    //    }
    //    public void SetReprSimplest()
    //    {
    //        FormAndGridCellCfgMain.SetReprSimplest();
    //    }
    //    public void SetReprSimpleAsBuilder()
    //    {
    //        FormAndGridCellCfgMain.SetReprSimpleAsBuilder();
    //    }
    //    public void SetReprConvinient()
    //    {
    //        FormAndGridCellCfgMain.SetReprConvinient();
    //    }
    //    //
    //    public int LineNByNatN(int NatN){
    //        int RN = NatN;
    //        if (TableRepr != null) RN = TableRepr.LineNOfNaturalN(NatN);
    //        return RN;
    //    }
    //     public int ColumnNByNatN(int NatN){
    //         int RN = NatN;
    //         if (TableRepr != null) RN = TableRepr.ColumnNOfNaturalN(NatN);
    //         return RN;
    //    }
    //    //
    //    public object Clone()
    //    {
    //        TableFormAndGridConfigurationAll obj = new TableFormAndGridConfigurationAll(this.GetTableFormAndGridCellConfigurationMain(), this.GetCellsNsToDisplay(), this.GetTableHeaderRowsExistance(), this.GetTableRepresentation());
    //        return obj;
    //    }
    //    //
    //}//cl  TableFormAndGridConfigurationGeneral  8
    class GridParamsGiven
    {
        //public bool LineOfColHeaderExists; // = TblInf.Repr.GenRepr.ShowLineOfColHeader;//1
        //public bool ColOfLineHeaderExists; // = TblInf.Repr.GenRepr.ShowColOfLineHeader;//2
        //public bool LineOfColHeaderHidden; // = !TblInf.Repr.GenRepr.ShowLineOfColHeader;//3
        //public bool ColOfLineHeaderHidden; // = !TblInf.Repr.GenRepr.ShowColOfLineHeader;//4
        public bool LineOfColHeaderAreToShow; // = !TblInf.Repr.GenRepr.ShowLineOfColHeader;//3
        public bool ColOfLineHeaderAreToShow; // = !TblInf.Repr.GenRepr.ShowColOfLineHeader;//4
        public int QTableContentLinesAll, //5
                QTableContentLinesToDisplay; // = TblInf.GetQLines()//6-12
        public int QTableContentColumnsAll, //7-13
            QTableContentColumnsToDisplay; // = TblInf.GetQColumns()//8-14
        public int QColsNamesToDisplay, //9-15
                QLinesNamesToDisplay; //10-18
        public bool GridLineOfColHeaderIsInUse, //11-25
             GridColOfLineHeaderIsInUse;  //12-26
        public int ErstTableLineN,//13
                ErstTableColN; //14
        //
        public GridParamsGiven()
        {
            SetDefaultMin();
        }
        public GridParamsGiven(TableHeaderRowsExistance GridHdrInUseExt, TableHeaderRowsExistance TblHdrToShowExt, TableSize QTableRowsAllExt, TableSize QTableRowsToShowExt, TableSize ErstTableRowsNsToShowExt, TableSize QRowsNamesToShowExt)
        {
            Set(GridHdrInUseExt, TblHdrToShowExt, QTableRowsAllExt, QTableRowsToShowExt, ErstTableRowsNsToShowExt, QRowsNamesToShowExt);
        }
        public GridParamsGiven(TableHeaderRowsExistance HeaderRowsExistance, CellsNsToDisplay CellsToDisplay, TableInfo TblInf)
        {
            Set(HeaderRowsExistance, CellsToDisplay, TblInf);
        }
        public GridParamsGiven(TableFormAndGridConfigurationMain cfg, CellsNsToDisplay CellsToDisplayExt, TableInfo TblInfExt)
        {
            Set(cfg, CellsToDisplayExt, TblInfExt);
        }
        public void SetDefaultMin()
        {
            //LineOfColHeaderExists = true;
            //ColOfLineHeaderExists = true;
            //LineOfColHeaderHidden = false;
            //ColOfLineHeaderHidden = false;
            LineOfColHeaderAreToShow = true;
            ColOfLineHeaderAreToShow = true;
            QTableContentLinesAll = 1;
            QTableContentColumnsAll = 1;
            QTableContentLinesToDisplay = 1;
            QTableContentColumnsToDisplay = 1;
            QColsNamesToDisplay = 1;
            QLinesNamesToDisplay = 1;
            GridLineOfColHeaderIsInUse = true;
            GridColOfLineHeaderIsInUse = true;
            ErstTableLineN = 1;
            ErstTableColN = 1;
        }
        public void Set(TableHeaderRowsExistance GridHdrInUseExt, TableHeaderRowsExistance TblHdrToShowExt, TableSize QTableRowsAllExt, TableSize QTableRowsToShowExt, TableSize ErstTableRowsNsToShowExt, TableSize QRowsNamesToShowExt)
        {
            TableHeaderRowsExistance GridHdrInUse = GridHdrInUseExt;
            TableHeaderRowsExistance TblHdrToShow = TblHdrToShowExt;
            TableSize QTableRowsAll = QTableRowsAllExt;
            TableSize QTableRowsToShow = QTableRowsToShowExt;
            TableSize ErstTableRowsNsToShow = ErstTableRowsNsToShowExt;
            TableSize QRowsNamesToShow = QRowsNamesToShowExt;
            QTableContentLinesAll = QTableRowsAll.QLines;
            QTableContentLinesToDisplay = QTableRowsToShow.QLines;
            QTableContentColumnsAll = QTableRowsAll.QColumns;
            QColsNamesToDisplay = QRowsNamesToShow.QColumns;
            QLinesNamesToDisplay = QRowsNamesToShow.QLines;

            ErstTableLineN = ErstTableRowsNsToShow.QLines;
            ErstTableColN = ErstTableRowsNsToShow.QColumns;
        }
        public void Set(TableHeaderRowsExistance HeaderRowsExistanceExt, CellsNsToDisplay CellsToDisplayExt, TableInfo TblInfExt)
        {
            TableInfo TblInf;
            TableHeaderRowsExistance HdrRows;
            if (HeaderRowsExistanceExt != null) HdrRows = HeaderRowsExistanceExt; else HdrRows = new TableHeaderRowsExistance();
            if (TblInfExt != null) TblInf = TblInfExt; else TblInf = new TableInfo();
            if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
            //TableFormAndGridConfigurationMain cfg;
            //if (cfgExt != null) cfg = cfgExt; else cfg = new TableFormAndGridConfigurationMain();
            CellsNsToDisplay CellsToDisplay;
            if (CellsToDisplayExt != null) CellsToDisplay = CellsToDisplayExt; else CellsToDisplay = new CellsNsToDisplay();
            //
            //LineOfColHeaderExists = TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader;//1
            //ColOfLineHeaderExists = TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader;//2
            //LineOfColHeaderHidden = !TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader;//3
            //ColOfLineHeaderHidden = !TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader;//4
            LineOfColHeaderAreToShow = TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader;
            ColOfLineHeaderAreToShow = TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader;
            QTableContentLinesAll = TblInf.GetQLines();//5
            QTableContentColumnsAll = TblInf.GetQColumns();//6
            QTableContentLinesToDisplay = CellsToDisplay.GetQShownContentLines(); //7
            QTableContentColumnsToDisplay = CellsToDisplay.GetQShownContentColumns();//8
            QColsNamesToDisplay = CellsToDisplay.GetQColumnHeaderNamesToShow();//9
            QLinesNamesToDisplay = CellsToDisplay.GetQLineHeaderNamesToShow();//10
            GridLineOfColHeaderIsInUse = HdrRows.LineOfColHeaderExists;//11
            GridColOfLineHeaderIsInUse = HdrRows.ColOfLineHeaderExists;//12
            ErstTableLineN = CellsToDisplay.GetErstShownContentLineN();// ErstTableLineN = CellsToDisplayExt.GetErstShownContentLineN();
            ErstTableColN = CellsToDisplay.GetErstShownContentColumnN();//ErstTableColN = CellsToDisplayExt.GetErstShownContentColumnN();
        }
        public void Set(TableFormAndGridConfigurationMain cfgExt, CellsNsToDisplay CellsToDisplayExt, TableInfo TblInfExt)
        {
            //TableInfo TblInf;
            //if(TblInfExt!=null) TblInf=TblInfExt; else TblInf=new TableInfo();
            //if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
            //TableFormAndGridConfigurationMain cfg;
            //if(cfgExt!=null) cfg=cfgExt; else cfg=new TableFormAndGridConfigurationMain();
            //CellsNsToDisplay CellsToDisplay;
            //if(CellsToDisplayExt!=null) CellsToDisplay=CellsToDisplayExt; else CellsToDisplay=new CellsNsToDisplay();
            ////
            //LineOfColHeaderExists = TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader;//1
            //ColOfLineHeaderExists = TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader;//2
            //LineOfColHeaderHidden = !TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader;//3
            //ColOfLineHeaderHidden = !TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader;//4
            //QTableContentLinesAll = TblInf.GetQLines();//5
            //QTableContentColumnsAll = TblInf.GetQColumns();//6
            //7
            //QColsNamesToDisplay = CellsToDisplay.GetQColumnHeaderNamesToShow();//9
            //QLinesNamesToDisplay = CellsToDisplay.GetQLineHeaderNamesToShow();//10
            //GridLineOfColHeaderIsInUse = cfg.LoCHGridRowUsed;//11
            //GridColOfLineHeaderIsInUse=cfg.CoLHGridRowUsed;  //12
            //ErstTableColN = CellsToDisplayExt.GetErstShownContentColumnN();
            TableHeaderRowsExistance HdrRows;
            if (cfgExt != null) HdrRows = cfgExt.GetHeaderRowsExistance(); else HdrRows = new TableHeaderRowsExistance();
            Set(HdrRows, CellsToDisplayExt, TblInfExt);
        }
        public void Get(ref TableHeaderRowsExistance GridHdrInUseExt, ref TableHeaderRowsExistance TblHdrToShowExt, ref TableSize QTableRowsAllExt, ref TableSize QTableRowsToShowExt, ref TableSize ErstTableRowsNsToShowExt, ref TableSize QRowsNamesToShowExt)
        {
            TableHeaderRowsExistance GridHdrInUse = new TableHeaderRowsExistance(GridColOfLineHeaderIsInUse, this.GridLineOfColHeaderIsInUse);
            TableHeaderRowsExistance TblHdrToShow = new TableHeaderRowsExistance(this.ColOfLineHeaderAreToShow, this.LineOfColHeaderAreToShow);
            TableSize QTableRowsAll = new TableSize(this.QTableContentLinesAll, this.QTableContentColumnsAll);
            TableSize QTableRowsToShow = new TableSize(this.QTableContentLinesToDisplay, this.QTableContentColumnsToDisplay);
            TableSize ErstTableRowsNsToShow = new TableSize(this.ErstTableLineN, this.ErstTableColN);
            TableSize QRowsNamesToShow = new TableSize(this.QLinesNamesToDisplay, this.QColsNamesToDisplay);
            //
            GridHdrInUseExt = GridHdrInUse;
            TblHdrToShowExt = TblHdrToShow;
            QTableRowsAllExt = QTableRowsAll;
            QTableRowsToShowExt = QTableRowsToShow;
            ErstTableRowsNsToShowExt = ErstTableRowsNsToShow;
            QRowsNamesToShowExt = QRowsNamesToShow;
        }
        public TTable GetAsTable()
        {
            int QItems = 12;// 14;
            int count = 0;
            bool WriteInfo = true;
            TableInfo TblInf = new TableInfo(true, true, true, QItems, 1);
            TTable tbl = null;//=new TTable(TblInf, false,
            DataCellRowCoHeader[] rows = new DataCellRowCoHeader[QItems];
            DataCellRow HdrRow = new DataCellRow(new DataCell("Value"), 1);
            TableHeaders Hdrs = new TableHeaders(new DataCell("GridParamsGiven"), new DataCell("Params"), null);
            //count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("LineOfColHeaderExists"), new DataCellRow(new DataCell(LineOfColHeaderExists), 1));
            //count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("ColOfLineHeaderExists"), new DataCellRow(new DataCell(ColOfLineHeaderExists), 1));
            //count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("LineOfColHeaderHidden"), new DataCellRow(new DataCell(LineOfColHeaderHidden), 1));
            //count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("ColOfLineHeaderHidden"), new DataCellRow(new DataCell(ColOfLineHeaderHidden), 1));
            count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("LineOfColHeaderAreToShow"), new DataCellRow(new DataCell(LineOfColHeaderAreToShow), 1));
            count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("ColOfLineHeaderAreToShow"), new DataCellRow(new DataCell(ColOfLineHeaderAreToShow), 1));
            count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("QTableContentLinesAll"), new DataCellRow(new DataCell(QTableContentLinesAll), 1));
            count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("QTableContentLinesToDisplay"), new DataCellRow(new DataCell(QTableContentLinesToDisplay), 1));
            count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("QTableContentColumnsAll"), new DataCellRow(new DataCell(QTableContentColumnsAll), 1));
            count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("QTableContentColumnsToDisplay"), new DataCellRow(new DataCell(QTableContentColumnsToDisplay), 1));
            count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("QColsNamesToDisplay"), new DataCellRow(new DataCell(QColsNamesToDisplay), 1));
            count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("QLinesNamesToDisplay"), new DataCellRow(new DataCell(QLinesNamesToDisplay), 1));
            count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("GridLineOfColHeaderIsInUse"), new DataCellRow(new DataCell(GridLineOfColHeaderIsInUse), 1));
            count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("GridColOfLineHeaderIsInUse"), new DataCellRow(new DataCell(GridColOfLineHeaderIsInUse), 1));
            count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("ErstTableLineN"), new DataCellRow(new DataCell(ErstTableLineN), 1));
            count++; rows[count - 1] = new DataCellRowCoHeader(new DataCell("ErstTableColN"), new DataCellRow(new DataCell(ErstTableColN), 1));
            tbl = new TTable(
                new TableInfo(true, true, true, QItems, 1),
                false,
                rows,
                HdrRow,
                Hdrs,
                WriteInfo
            );
            return tbl;
        }
    }//}//mark2
    class GridParamsCalculated
    {
        public GridParamsGiven ParamsGiven;
        //public bool LineOfColHeaderPresent; // = LineOfColHeaderExists && !LineOfColHeaderHidden;//1-5
        //public bool ColOfLineHeaderPresent; // = ColOfLineHeaderExists && !ColOfLineHeaderHidden;//2-6
        public int ErstContentGridLineIndex, //3-23
                ErstContentGridColIndex,//4
                QGridLines, //5
                QGridColumns; //6
        //
        public GridParamsCalculated()
        {
            SetDefaultMin();
        }
        public GridParamsCalculated(TableHeaderRowsExistance GridHdrInUseExt, TableHeaderRowsExistance TblHdrToShowExt, TableSize QTableRowsAllExt, TableSize QTableRowsToShowExt, TableSize ErstTableRowsNsToShowExt, TableSize QRowsNamesToShowExt)
        {
            Set(GridHdrInUseExt, TblHdrToShowExt, QTableRowsAllExt, QTableRowsToShowExt, ErstTableRowsNsToShowExt, QRowsNamesToShowExt);
        }
        public GridParamsCalculated(GridParamsGiven ParamsGiven)
        {
            Set(ParamsGiven);
        }
        public GridParamsCalculated(TableHeaderRowsExistance HeaderRowsExistance, CellsNsToDisplay CellsToDisplayExt, TableInfo TblInfExt)
        {
            Set(HeaderRowsExistance, CellsToDisplayExt, TblInfExt);
        }
        public GridParamsCalculated(TableFormAndGridConfigurationMain cfg, CellsNsToDisplay CellsToDisplay, TableInfo TblInf)
        {
            Set(cfg, CellsToDisplay, TblInf);
        }
        public void SetDefaultMin()
        {
            //LineOfColHeaderPresent = ParamsGiven.LineOfColHeaderExists && !ParamsGiven.LineOfColHeaderHidden;//5
            //ColOfLineHeaderPresent = ParamsGiven.ColOfLineHeaderExists && !ParamsGiven.ColOfLineHeaderHidden;//6
            ParamsGiven = new GridParamsGiven();
            //if (LineOfColHeaderPresent == true)
            if (ParamsGiven.LineOfColHeaderAreToShow == true)
            {
                //QColNamesToDisplay!=0=QColNamesToDisplay
                if (ParamsGiven.GridLineOfColHeaderIsInUse == true)
                //if (GridParamsCalcd.LineOfColHeaderPresent)
                {
                    ErstContentGridLineIndex = 0 + ParamsGiven.QColsNamesToDisplay + 1 - 1 - 1; //+1 ob next, -1 ob from 0, -1 ob GridHeader s'used
                }
                else
                {
                    ErstContentGridLineIndex = 0 + ParamsGiven.QColsNamesToDisplay + 1 - 1; //+1 ob next, -1 ob from 0, and  GridHeader ne s'used
                }
            }
            else
            {
                if (ParamsGiven.GridLineOfColHeaderIsInUse == true)
                {
                    ErstContentGridLineIndex = -1; // -1 ob GridHeader s'used, et ne uz header, ma uz content - non-natural case
                }
                else
                {
                    ErstContentGridLineIndex = 0; //simply content grisd cells
                }
            }//ErstContentGridLineIndex
            //ErstContentGridColIndex
            //if (ColOfLineHeaderPresent == true)
            if (ParamsGiven.ColOfLineHeaderAreToShow == true)
            {
                if (ParamsGiven.GridColOfLineHeaderIsInUse == true)
                {
                    ErstContentGridColIndex = 0 + ParamsGiven.QLinesNamesToDisplay + 1 - 1 - 1; //+1 ob next, -1 ob from 0, -1 ob GridHeader s'used
                }
                else
                {
                    ErstContentGridColIndex = 0 + ParamsGiven.QLinesNamesToDisplay + 1 - 1; //+1 ob next, -1 ob from 0,  GridHeader s' ne used
                }
            }
            else
            {
                if (ParamsGiven.GridColOfLineHeaderIsInUse == true)
                {
                    ErstContentGridColIndex = -1; //header grid cells for content tabke cells, innatural case
                }
                else
                {
                    ErstContentGridColIndex = 0; //simply content, 1:1
                }
            }//ErstContentGridColIndex
            if (ParamsGiven.GridLineOfColHeaderIsInUse) QGridLines = ParamsGiven.QTableContentLinesToDisplay + ParamsGiven.QLinesNamesToDisplay + ErstContentGridLineIndex - 1 - 1;
            else QGridLines = ParamsGiven.QTableContentLinesToDisplay + ParamsGiven.QLinesNamesToDisplay + ErstContentGridLineIndex - 1;
            if (ParamsGiven.GridLineOfColHeaderIsInUse) QGridColumns = ParamsGiven.QTableContentColumnsToDisplay + ParamsGiven.QColsNamesToDisplay + ErstContentGridColIndex - 1 - 1;
            else QGridColumns = ParamsGiven.QTableContentColumnsToDisplay + ParamsGiven.QColsNamesToDisplay + ErstContentGridColIndex - 1;
        }
        //
        public void Set(TableFormAndGridConfigurationMain cfg, CellsNsToDisplay CellsToDisplay, TableInfo TblInf)
        {
            ParamsGiven = new GridParamsGiven(cfg, CellsToDisplay, TblInf);
            Set(ParamsGiven);
        }
        public void Set(TableHeaderRowsExistance HeaderRowsExistance, CellsNsToDisplay CellsToDisplay, TableInfo TblInf)
        {
            ParamsGiven = new GridParamsGiven(HeaderRowsExistance, CellsToDisplay, TblInf);
            Set(ParamsGiven);
        }
        public void Set(GridParamsGiven parameters)
        {
            if (parameters != null) this.ParamsGiven = parameters;
            else if (this.ParamsGiven == null) this.ParamsGiven = new GridParamsGiven();
            else ;//NOp: le be as es
            //
            //LineOfColHeaderPresent = ParamsGiven.LineOfColHeaderExists && !ParamsGiven.LineOfColHeaderHidden;//5
            //ColOfLineHeaderPresent = ParamsGiven.ColOfLineHeaderExists && !ParamsGiven.ColOfLineHeaderHidden;//6
            //if (LineOfColHeaderPresent == true)
            if (ParamsGiven.LineOfColHeaderAreToShow == true)
            {
                //QColNamesToDisplay!=0=QColNamesToDisplay
                if (ParamsGiven.GridLineOfColHeaderIsInUse == true)
                //if (GridParamsCalcd.LineOfColHeaderPresent)
                {
                    ErstContentGridLineIndex = 0 + ParamsGiven.QColsNamesToDisplay + 1 - 1 - 1; //+1 ob next, -1 ob from 0, -1 ob GridHeader s'used
                }
                else
                {
                    ErstContentGridLineIndex = 0 + ParamsGiven.QColsNamesToDisplay + 1 - 1; //+1 ob next, -1 ob from 0, and  GridHeader ne s'used
                }
            }
            else
            {
                if (ParamsGiven.GridLineOfColHeaderIsInUse == true)
                {
                    ErstContentGridLineIndex = -1; // -1 ob GridHeader s'used, et ne uz header, ma uz content - non-natural case
                }
                else
                {
                    ErstContentGridLineIndex = 0; //simply content grisd cells
                }
            }//ErstContentGridLineIndex
            //ErstContentGridColIndex
            //if (ColOfLineHeaderPresent == true)//AreToShow
            if (ParamsGiven.ColOfLineHeaderAreToShow == true)
            {
                if (ParamsGiven.GridColOfLineHeaderIsInUse == true)
                {
                    ErstContentGridColIndex = 0 + ParamsGiven.QLinesNamesToDisplay + 1 - 1 - 1; //+1 ob next, -1 ob from 0, -1 ob GridHeader s'used
                }
                else
                {
                    ErstContentGridColIndex = 0 + ParamsGiven.QLinesNamesToDisplay + 1 - 1; //+1 ob next, -1 ob from 0,  GridHeader s' ne used
                }
            }
            else
            {
                if (ParamsGiven.GridColOfLineHeaderIsInUse == true)
                {
                    ErstContentGridColIndex = -1; //header grid cells for content tabke cells, innatural case
                }
                else
                {
                    ErstContentGridColIndex = 0; //simply content, 1:1
                }
            }//ErstContentGridColIndex
            //
            if (ParamsGiven.GridLineOfColHeaderIsInUse) QGridLines = ParamsGiven.QTableContentLinesToDisplay + ParamsGiven.QLinesNamesToDisplay + ErstContentGridLineIndex - 1;//QGridLines = ParamsGiven.QTableContentLinesToDisplay + ParamsGiven.QLinesNamesToDisplay + ErstContentGridLineIndex - 1 - 1;
            else QGridLines = ParamsGiven.QTableContentLinesToDisplay + ParamsGiven.QLinesNamesToDisplay + ErstContentGridLineIndex - 1;
            if (ParamsGiven.GridLineOfColHeaderIsInUse) QGridColumns = ParamsGiven.QTableContentColumnsToDisplay + ParamsGiven.QColsNamesToDisplay + ErstContentGridColIndex - 1; //QGridColumns = ParamsGiven.QTableContentColumnsToDisplay + ParamsGiven.QColsNamesToDisplay + ErstContentGridColIndex - 1 - 1;
            else QGridColumns = ParamsGiven.QTableContentColumnsToDisplay + ParamsGiven.QColsNamesToDisplay + ErstContentGridColIndex - 1;
        }
        //
        public GridParamsGiven GetIniData()
        {
            return this.ParamsGiven;
        }
        //
        public void Set(TableHeaderRowsExistance GridHdrInUseExt, TableHeaderRowsExistance TblHdrToShowExt, TableSize QTableRowsAllExt, TableSize QTableRowsToShowExt, TableSize ErstTableRowsNsToShowExt, TableSize QRowsNamesToShowExt)
        {
            this.ParamsGiven = new GridParamsGiven(GridHdrInUseExt, TblHdrToShowExt, QTableRowsAllExt, QTableRowsToShowExt, ErstTableRowsNsToShowExt, QRowsNamesToShowExt);
        }
        //
        public void GetIniParams(ref TableHeaderRowsExistance GridHdrInUseExt, ref TableHeaderRowsExistance TblHdrToShowExt, ref TableSize QTableRowsAllExt, ref TableSize QTableRowsToShowExt, ref TableSize ErstTableRowsNsToShowExt, ref TableSize QRowsNamesToShowExt)
        {
            this.ParamsGiven.Get(ref GridHdrInUseExt, ref TblHdrToShowExt, ref QTableRowsAllExt, ref QTableRowsToShowExt, ref ErstTableRowsNsToShowExt, ref QRowsNamesToShowExt);
        }
        public TTable GetIniParamsAsTable()
        {
            return this.ParamsGiven.GetAsTable();
        }
        //
        public int Calc_TableLineNatN_ByLineOrderNatNToDisplay(int LineOrderNatNToDisplay)
        {
            int TableLineNatN;
            TableLineNatN = this.ParamsGiven.ErstTableLineN + LineOrderNatNToDisplay - 1;
            return TableLineNatN;
            //4..9 , 5<->2 5=4+2-1  done
        }
        public int Calc_TableColNatN_ByColOrderNatNToDisplay(int ColOrderNatNToDisplay)
        {
            int TableColNatN;
            TableColNatN = this.ParamsGiven.ErstTableColN + ColOrderNatNToDisplay - 1;
            return TableColNatN;
        }
        public int Calc_LineOrderNatNToDisplay_ByTableLineNatN(int TableLineNatN)
        {
            int LineNatOrderNToDisplay;
            LineNatOrderNToDisplay = TableLineNatN - this.ParamsGiven.ErstTableLineN + 1;
            //4..9 , 5<->2 2=5-4+1  done
            return LineNatOrderNToDisplay;
        }
        public int Calc_ColOrderNatNToDisplay_ByTableColNatN(int TableColNatN)
        {
            int ColNatOrderNToDisplay;
            ColNatOrderNToDisplay = TableColNatN - this.ParamsGiven.ErstTableColN + 1;
            return ColNatOrderNToDisplay;
        }
        public int Calc_GridLineIndex_ByLineOrderNatNToDisplay(int LineOrderNatNToDisplay)
        {
            int gLineIndex;
            int QNames = ParamsGiven.QColsNamesToDisplay, GridHdrInUse = MyLib.BoolToInt(ParamsGiven.GridColOfLineHeaderIsInUse), TblHdrToShow = MyLib.BoolToInt(ParamsGiven.ColOfLineHeaderAreToShow);
            //gLineIndex = (QNames - GridHdrInUse))*TblHdrToShow + LineOrderNatNToDisplay-1;
            gLineIndex = (QNames - GridHdrInUse) + LineOrderNatNToDisplay - 1;
            //done
            return gLineIndex;
        }
        public int Calc_GridColIndex_ByColOrderNatNToDisplay(int ColOrderNatNToDisplay)
        {
            int gColIndex;
            int QNames = ParamsGiven.QLinesNamesToDisplay, GridHdrInUse = MyLib.BoolToInt(ParamsGiven.GridLineOfColHeaderIsInUse), TblHdrToShow = MyLib.BoolToInt(ParamsGiven.LineOfColHeaderAreToShow);
            //gColIndex = (QNames - GridHdrInUse)*TblHdrToShow + ColOrderNatNToDisplay-1;
            gColIndex = (QNames - GridHdrInUse) + ColOrderNatNToDisplay - 1;
            return gColIndex;
        }
        public int Calc_LineOrderNatNToDisplay_ByGridLineIndex(int gLineIndex)
        {
            int LineOrderNatNToDisplay;
            int QNames = ParamsGiven.QColsNamesToDisplay, GridHdrInUse = MyLib.BoolToInt(ParamsGiven.GridColOfLineHeaderIsInUse), TblHdrToShow = MyLib.BoolToInt(ParamsGiven.ColOfLineHeaderAreToShow);
            //gLineIndex = (QNames - GridHdrInUse))*TblHdrToShow + LineOrderNatNToDisplay-1;
            //LineOrderNatNToDisplay=gLineIndex-(QNames - GridHdrInUse)*TblHdrToShow+1;
            LineOrderNatNToDisplay = gLineIndex - (QNames - GridHdrInUse) + 1;
            return LineOrderNatNToDisplay;
        }
        public int Calc_ColOrderNatNToDisplay_ByGridColIndex(int gColIndex)
        {
            int ColOrderNatNToDisplay;
            int QNames = ParamsGiven.QLinesNamesToDisplay, GridHdrInUse = MyLib.BoolToInt(ParamsGiven.GridLineOfColHeaderIsInUse), TblHdrToShow = MyLib.BoolToInt(ParamsGiven.LineOfColHeaderAreToShow);
            //gColIndex = (QNames - GridHdrInUse)*TblHdrToShow + ColOrderNatNToDisplay-1;
            //ColOrderNatNToDisplay=gColIndex -(QNames - GridHdrInUse)*TblHdrToShow +1;
            ColOrderNatNToDisplay = gColIndex - (QNames - GridHdrInUse) + 1; ;
            return ColOrderNatNToDisplay;
        }
        //
        public int Calc_GridLineIndex_ByTableLineNatN(int TableLineNatN)
        {
            int gLineIndex, LineOrderNatNToDisplay;
            LineOrderNatNToDisplay = Calc_LineOrderNatNToDisplay_ByTableLineNatN(TableLineNatN);
            gLineIndex = Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineOrderNatNToDisplay);            
            return gLineIndex;
        }
        public int Calc_GridColIndex_ByTableColNatN(int TableColNatN)
        {
            int gColIndex, ColOrderNatNToDisplay;
            ColOrderNatNToDisplay = Calc_ColOrderNatNToDisplay_ByTableColNatN(TableColNatN);
            gColIndex = Calc_GridColIndex_ByColOrderNatNToDisplay(ColOrderNatNToDisplay);           
            return gColIndex;
        }
        public int Calc_TableLineNatN_ByGridLineIndex(int GridLineIndex)
        {
            int TableLineNatN, LineNatOrderNToDisplay;
            LineNatOrderNToDisplay = Calc_LineOrderNatNToDisplay_ByGridLineIndex(GridLineIndex);
            TableLineNatN = Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineNatOrderNToDisplay);           
            return TableLineNatN;
        }
        public int Calc_TableColNatN_ByGridColIndex(int GridColIndex)
        {
            int TableColNatN, ColNatOrderNToDisplay;
            //                Calc_GridColIndex_B1yColOrderNatNToDisplay
            ColNatOrderNToDisplay = Calc_ColOrderNatNToDisplay_ByGridColIndex(GridColIndex);
            TableColNatN = Calc_TableColNatN_ByColOrderNatNToDisplay(ColNatOrderNToDisplay);         
            return TableColNatN;
        }
        //
    }//cl
    //mark3
    public class TableReadingTypesParams
    {
        public bool RealPriorThanStr, IntPriorThanReal, BoolPriorThanInt, BoolPriorThanStr;
        //public bool ArrayWriteValNotActiveN;
        public int Array_ActiveN0Val1AllLines2;
        //
        public int Bool_Bool0Int1Str2IntArr3StrArr4;
        //
        public TableReadingTypesParams()
        {
            AllTypes_BoolByInt();
            //ArrayWriteValNotActiveN = false;
            Array_ActiveN0Val1AllLines2 = 2;//Array_ActiveN0Val1AllLines2 = 0;
            //
            Bool_Bool0Int1Str2IntArr3StrArr4 = 0;
        }
        public void StrOnly()
        {
            RealPriorThanStr = false;
            IntPriorThanReal = false;
            BoolPriorThanInt = false;
            BoolPriorThanStr = false;
        }
        public void AllTypes_BoolByInt()
        {
            RealPriorThanStr = true;
            IntPriorThanReal = true;
            BoolPriorThanInt = true;
            BoolPriorThanStr = false;
        }
        public void AllTypes_BoolByStr()
        {
            RealPriorThanStr = true;
            IntPriorThanReal = true;
            BoolPriorThanInt = false;
            BoolPriorThanStr = true;
        }
        public void AllTypes_BoolBoth()
        {
            RealPriorThanStr = true;
            IntPriorThanReal = true;
            BoolPriorThanInt = true;
            BoolPriorThanStr = true;
        }
        public void StrAndNumsReal()
        {
            RealPriorThanStr = true;
            IntPriorThanReal = false;
            BoolPriorThanInt = false;
            BoolPriorThanStr = false;
        }
        public void StrAndNumsInt()
        {
            RealPriorThanStr = true;
            IntPriorThanReal = true;
            BoolPriorThanInt = false;
            BoolPriorThanStr = false;
        }
        public void StrAndBoolInt()
        {
            RealPriorThanStr = false;
            IntPriorThanReal = false;
            BoolPriorThanInt = true;
            BoolPriorThanStr = false;
        }
        public void StrAndBoolStr()
        {
            RealPriorThanStr = false;
            IntPriorThanReal = false;
            BoolPriorThanInt = false;
            BoolPriorThanStr = true;
        }
        //
        //public void SetSimple()
        //{
        //    Array_ActiveN0Val1AllLines2 = 0;
        //}
        //public void SetMenu()
        //{
        //    Array_ActiveN0Val1AllLines2 = 1;
        //}
        //public void SetMemo()
        //{
        //    Array_ActiveN0Val1AllLines2 = 2;
        //}
        //
        public TTable GetAsTable()
        {
            TTable tbl;
            int QItems = 6;// 5;
            bool WriteInfo = true;
            TableInfo TblInf = new TableInfo(true, true, true, QItems, 1);
            //DataCellRow
            DataCellRowCoHeader[] rows = new DataCellRowCoHeader[QItems];
            DataCellRow HdrRow;
            string[] str, sHdr = new string[1];
            sHdr[1 - 1] = "Value";
            rows[1 - 1] = new DataCellRowCoHeader(new DataCell("RealPriorThanStr"), new DataCellRow(RealPriorThanStr, 1));
            rows[2 - 1] = new DataCellRowCoHeader(new DataCell("IntPriorThanReal"), new DataCellRow(IntPriorThanReal, 1));
            rows[3 - 1] = new DataCellRowCoHeader(new DataCell("BoolPriorThanInt"), new DataCellRow(BoolPriorThanInt, 1));
            rows[4 - 1] = new DataCellRowCoHeader(new DataCell("BoolPriorThanStr"), new DataCellRow(BoolPriorThanStr, 1));
            str = new string[3];
            str[1 - 1] = "ActiveN"; str[2 - 1] = "CurVal"; str[3 - 1] = "AllVals";
            rows[5 - 1] = new DataCellRowCoHeader(new DataCell("Array_ActiveN0Val1AllLines2"), new DataCellRow(str, 3));
            str = new string[5];
            str[1 - 1] = "Bool"; str[2 - 1] = "Int"; str[3 - 1] = "Str"; str[4 - 1] = "IntArr"; str[5 - 1] = "StrArr";
            rows[6 - 1] = new DataCellRowCoHeader(new DataCell("Bool_Bool0Int1Str2IntArr3StrArr4"), new DataCellRow(str, 5));
            HdrRow = new DataCellRow(sHdr, 1);
            tbl = new TTable(
                new TableInfo(true, true, true, QItems, 1),
                false,
                rows,
                HdrRow,
                new TableHeaders(new DataCell("TableReadingTypesParams"), new DataCell("Params"), null),
                WriteInfo
            );
            return tbl;
        }
        public void GetFromTable(TTable tbl)
        {
            RealPriorThanStr = tbl.GetBoolVal(1, 1);
            IntPriorThanReal = tbl.GetBoolVal(2, 1);
            BoolPriorThanInt = tbl.GetBoolVal(3, 1);
            BoolPriorThanStr = tbl.GetBoolVal(4, 1);
            Array_ActiveN0Val1AllLines2 = tbl.GetMenuItemN(5, 1) - 1;
        }
    }//cl
    public class TableDataChange
    {
        public int DataTopicN;//0 - no
        public int DataTypeIni1Fin2Medium3Cfg4;
        public int DataN;
        //new
        public int SelectedTableLineNatN, SelectedTableColumnNatN;
        //
        public TableDataChange() {
            DataTopicN = 0; DataTypeIni1Fin2Medium3Cfg4 = 1; DataN = 1;
            SelectedTableLineNatN = 1; SelectedTableColumnNatN = 1;
        }
        public override string ToString() { return DataTopicN.ToString() + "_Topic_Type_" + DataTopicN.ToString() + "_Type_N_" + DataN.ToString() + "_SelLineN_" + SelectedTableLineNatN.ToString() + "_SelColN_" + SelectedTableColumnNatN.ToString(); }
        public TableDataChange Parse(string s) //not finished!
        {
            TableDataChange obj = new TableDataChange();
            int Div1, Div2, L;
            L = s.Length;
            //Div1=MyLib.FindSubstring(s, "_Topic_Type_",
            return obj;
        }
    }//cl
    /*
     * if ((ItemText.Equals("Content cell") || InputText.Equals("Content cell")) && this.TblInf.UssagePolicy.ContentsCanEdit == false) this.button_SetValue.Enabled = false;
                else if ((ItemText.Equals("Col of Line Hdr") || InputText.Equals("Col of Line Hdr")) && this.TblInf.UssagePolicy.LH_Can_Edit == false) this.button_SetValue.Enabled = false;
                else if ((ItemText.Equals("Line of Col Hdr") || InputText.Equals("Line of Col Hdr")) && this.TblInf.UssagePolicy.CH_Can_Edit == false) this.button_SetValue.Enabled = false;
                else if ((ItemText.Equals("Table Name") || InputText.Equals("Table Name")) && this.TblInf.UssagePolicy.TableName_Can_Edit == false) this.button_SetValue.Enabled = false;
                else if ((ItemText.Equals("Lines Gen Name") || InputText.Equals("Lines Gen Name")) && this.TblInf.UssagePolicy.LinesGenName_Can_Edit == false) this.button_SetValue.Enabled = false;
                else if ((ItemText.Equals("Columns Gen Name") || InputText.Equals("Columns Gen Name")) && this.TblInf.UssagePolicy.ColumnsGenName_Can_Edit == false) this.button_SetValue.Enabled = false;*
     
     "Content cell" 
     "Col of Line Hdr"
     * "Line of Col Hdr"
     * "Table Name"
     *"Lines Gen Name" 
     * "Columns Gen Name"
     * 
     * 
     */
    //
    //Group of classes 5 - ReprText & UssagePolicy
    public class TRowsNumeration
    {
        int ErstLineN, ErstColumnN, LinesNsStep, ColumnsNsStep;
        //
        public TRowsNumeration(int ErstLineN=1, int ErstColumnN=1, int LinesNsStep=1, int ColumnsNsStep = 1) {
            Set(ErstLineN, ErstColumnN, LinesNsStep, ColumnsNsStep);
        }
        public TRowsNumeration(TableGeneralRepresentation ReprGenExt)
        {
            Set(ReprGenExt);
        }
        public void Set(int ErstLineN = 1, int ErstColumnN = 1, int LinesNsStep = 1, int ColumnsNsStep = 1)
        {
            this.ErstLineN = ErstLineN;
            this.ErstColumnN = ErstColumnN;
            this.LinesNsStep = LinesNsStep;
            this.ColumnsNsStep = ColumnsNsStep;
        }
        public void Set(TableGeneralRepresentation ReprGenExt)
        {
            TableGeneralRepresentation ReprGen;
            if (ReprGenExt != null) ReprGen = ReprGenExt; else ReprGen = new TableGeneralRepresentation();
            this.ErstColumnN = ReprGen.ColumnsNumerationStartFromN;
            this.ErstLineN = ReprGen.LinesNumerationStartFromN;
            this.ColumnsNsStep = ReprGen.ColumnsNumerationStep;
            this.LinesNsStep = ReprGen.LinesNumerationStep;
        }
        public void SetErstLineN(int ErstLineN) { this.ErstLineN = ErstLineN; }
        public void SetErstColumnN(int ErstColumnN) { this.ErstColumnN = ErstColumnN; }
        public void SetLinesNsStep(int LinesNsStep) { this.LinesNsStep = LinesNsStep; }
        public void SetColumnsNsStep(int ColumnsNsStep) { this.ColumnsNsStep = ColumnsNsStep; }
        public int GetErstLineN() { return ErstLineN; }
        public int GetErstColumnN() { return ErstColumnN; }
        public int GetLinesNsStep() { return LinesNsStep; }
        public int GetColumnsNsStep() { return ColumnsNsStep; }
        public void LinesNatural() { this.ErstLineN = 1; this.LinesNsStep = 1; }
        public void ColumnsNatural() { this.ErstColumnN = 1; this.ColumnsNsStep = 1; }
        public void BothNatural() { LinesNatural(); ColumnsNatural(); }
        public void LinesPolynomeOrArray() { this.ErstLineN = 0; this.LinesNsStep = 1; }
        public void ColumnsPolynomeOrArray() { this.ErstColumnN = 0; this.ColumnsNsStep = 1; }
        public void BothPolynomeOrArray() { LinesPolynomeOrArray(); ColumnsPolynomeOrArray(); }
        public int LineNOfNaturalN(int N) { return ErstLineN + LinesNsStep * (N - 1); }
        public int ColumnNOfNaturalN(int N) { return ErstColumnN + ColumnsNsStep * (N - 1); }
        public object Clone() { return this.MemberwiseClone(); }
        TTable GetAsTable()
        {
            DataCellRowCoHeader[] rows=new DataCellRowCoHeader[2];
            int []iarr=new int[2];
            string []sarr=new string[2];
            TTable Tbl;
            iarr[1-1]=this.ErstLineN; iarr[2-1]=this.ErstColumnN;
            //rows[1-1]=new DataCellRowCoHeader(new DataCell("Numeration starts From N"), new DataCellRow({this.ErstLineN, this.ErstColumnN}));
            rows[1-1]=new DataCellRowCoHeader(new DataCell("Numeration starts From N"), new DataCellRow(iarr, 2));
            iarr[1-1]=this.LinesNsStep; iarr[2-1]= this.ColumnsNsStep;
            //rows[2-1]=new DataCellRowCoHeader(new DataCell("Numeration Step"), new DataCellRow({this.LinesNsStep, this.ColumnsNsStep}));
            rows[2-1]=new DataCellRowCoHeader(new DataCell("Numeration Step"), new DataCellRow(iarr, 2));
            //sarr={"Lines", "Columns"};
            sarr[1-1]="Lines"; sarr[2-1]="Columns";
            Tbl = new TTable(
                new TableInfo(true, true, true, 2, 2),
                false,
                rows,
                new DataCellRow(sarr, 2),
                new TableHeaders(new DataCell("Rows Numeration"), new DataCell("Parameter"), new DataCell("Row")),
                true);
            return Tbl;
        }
        void SetFromTanle(TTable tbl)
        {
            this.ErstLineN = tbl.GetIntVal(1, 1);
            this.ErstColumnN = tbl.GetIntVal(1, 2);
            this.LinesNsStep = tbl.GetIntVal(2, 1);
            this.ColumnsNsStep = tbl.GetIntVal(2, 2);
        }
    }//class N
    public class TableGeneralRepresentation : ICloneable //cl 10 
    {
        public bool ShowColOfLineHeader, ShowLineOfColHeader;
        public bool ShowTableNameInCorner, ShowTableNameInButons, ShowRowsGenNamesInButtons, ShowRowsGenNamesInCorner;
        public int LRecom, Len_NoLim0RecomVal1GenMaxLen2MaxByCol3;
        public int LinesNumerationStartFromN, ColumnsNumerationStartFromN;
        public int LinesNumerationStep, ColumnsNumerationStep;
        //TRowsNumeration RowsNumeration;
        //
        public TableGeneralRepresentation()
        {
            ShowColOfLineHeader = true; ShowLineOfColHeader = true;
            LRecom = 6; Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 0;
            LinesNumerationStartFromN = 1;
            ColumnsNumerationStartFromN = 1;
            LinesNumerationStep=1;
            ColumnsNumerationStep=1;
            ShowTableNameInCorner = false; ShowTableNameInButons = false; ShowRowsGenNamesInButtons = true; ShowRowsGenNamesInCorner = true;
        }
        //public object Clone() { return this.MemberwiseClone(); }
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
            ShowColOfLineHeader = true;//auto
            ShowLineOfColHeader = true; //auto
            ShowTableNameInCorner = true;

        }
        public TTable GetAsTable()
        {
            TTable tbl;
            bool LC_not_CL = true, CoLHExists = true, LoCHExists = true;
            int QLines = 12;//was 10; 
            int CountLines = 0, QColumns = 1;
            string TableName = "Table general Representation",
                   LinesGeneralName = "Params",
                   ColsGenName = "",
                   SingleColName = "Values";
            DataCellRowCoHeader CurLineWithHeader;
            DataCellRowCoHeader[] rows;
            //
            DataCellRow LoCH;
            DataCell CurCell;
            TableHeaders Headers;
            //
            DataCell ACell;
            string[] Items;
            //
            LoCH = new DataCellRow("Values");
            Headers = new TableHeaders(new DataCell(TableName), new DataCell(LinesGeneralName), new DataCell(ColsGenName));
            //
            CountLines = 1;
            CurLineWithHeader = new DataCellRowCoHeader(new DataCell("Show CoLH"), new DataCellRow(ShowColOfLineHeader));
            rows = new DataCellRowCoHeader[1];
            rows[1 - 1] = CurLineWithHeader;
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
            Items = new string[] { "No", "RecomVal", "GenMaxLen", "MaxByCol" };
            ACell = new DataCell(Items, 4);
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("Length as"), new DataCellRow(ACell, 1)));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("Col N from"), new DataCellRow(ColumnsNumerationStartFromN)));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("Line N from"), new DataCellRow(LinesNumerationStartFromN)));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("Col N step"), new DataCellRow(ColumnsNumerationStep)));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell("Line N step"), new DataCellRow(LinesNumerationStep)));
            //
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetTableUssagePolicy(UsePol);
            //
            return tbl;
        }//fn
        public void SetFromTable(TTable tbl)
        {
            ShowColOfLineHeader = tbl.GetBoolVal(1, 1);
            ShowLineOfColHeader = tbl.GetBoolVal(2, 1);
            ShowTableNameInCorner = tbl.GetBoolVal(3, 1);
            ShowTableNameInButons = tbl.GetBoolVal(4, 1);
            ShowRowsGenNamesInButtons = tbl.GetBoolVal(5, 1);
            ShowRowsGenNamesInCorner = tbl.GetBoolVal(6, 1);
            LRecom = tbl.GetIntVal(7, 1);
            if (tbl.GetTypeN(8, 1) == TableConsts.StringArrayTypeN)
            {
                Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = tbl.GetActiveN(8, 1);
            }
            else
            {
                Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = tbl.GetIntVal(8, 1);
            }
            ColumnsNumerationStartFromN = tbl.GetIntVal(9, 1);
            LinesNumerationStartFromN = tbl.GetIntVal(10, 1);
            ColumnsNumerationStep = tbl.GetIntVal(11, 1);
            LinesNumerationStep = tbl.GetIntVal(12, 1);
        }//fn
        //
        public int LineNOfNaturalN(int N) { return LinesNumerationStartFromN + LinesNumerationStep * (N - 1); }
        public int ColumnNOfNaturalN(int N) { return ColumnsNumerationStartFromN + ColumnsNumerationStep * (N - 1); }
        //
        public object Clone() { return this.MemberwiseClone(); }
    } //cl 10 TableGeneralRepresentation
    public class TableHeaderCellRepresentation : ICloneable //cl 11
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
            AftGenRowName_Nil0_Space1_Comma2_Colon3_SCol4_EqSgn5_Minus6_Brkt7 = 0;
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
            InBrackets = false; //for content=true
            GenRowNameBef = true;
            RowNBef = false;//true;//, RowNameBef;
            //
            RowName = true;
            //
            GenRowNameAft = false;
            RowNAft = false;//, RowNameAft;
            Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 0;
            //
            //RowName = true;
            //GenRowNameBef = true;
            //RowNAft = true;
            //Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 0;
        }
        public TTable GetAsTable(string TableName = "Header Cell Representation")
        {
            string[] ss = null;
            TableInfo TblInf = new TableInfo(true, true, true, 12, 1);
            DataCellRow ColHeader = new DataCellRow("Values", 1);
            DataCellRowCoHeader[] lines = new DataCellRowCoHeader[12];
            TableHeaders Headers = new TableHeaders(new DataCell(TableName), new DataCell("Params"), new DataCell(""));
            ss = new string[] { "None", "N", "NCol", "ColN", "Col", "NLine", "LineN", "Line", "=" };
            lines[1 - 1] = new DataCellRowCoHeader(new DataCell("Before Nr"), new DataCellRow(new DataCell(ss, 9), 1));
            ss = new string[] { ")", "th", "th Line", "th Col", ":", "-", ",", "=" };
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
            else Bef_Nil0_Minus1_Colon2_Comma3_EqSgn4_Row5_Line6_Col7 = tbl.GetIntVal(1, 1);
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
    public class TableContentCellRepresentation : ICloneable //cl 12 
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
            TableHeaderCellRepresentation LineHeader = null;// = new TableHeaderCellRepresentation();
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
        public void Assign(TableContentCellRepresentation obj, int Mode_Rplc_Simply0_Null1_ByNonNull2 = 0, bool CreateDefaultIfNull = false)
        {
            //bool CreateDefaultIfNull = (Mode_RplcSimply0_RplcAndCreateDfltIfExtIsNull1_ReplByNonNull2_RplcNullByAnyExt3_RplcNullByExtAndCreateDfltIfExtIsAlsoNull4 == 1 || Mode_RplcSimply0_RplcAndCreateDfltIfExtIsNull1_ReplByNonNull2_RplcNullByAnyExt3_RplcNullByExtAndCreateDfltIfExtIsAlsoNull4 == 4);
            if (obj != null)
            {
                switch (Mode_Rplc_Simply0_Null1_ByNonNull2)
                {
                    case 0:
                        this.LineHeader = obj.LineHeader;
                        this.ColHeader = obj.ColHeader;
                        break;
                    case 1:
                        if (this.LineHeader == null) this.LineHeader = obj.LineHeader;
                        if (this.ColHeader == null) this.ColHeader = obj.ColHeader;
                        break;
                    case 2:
                        if (obj.LineHeader != null) this.LineHeader = obj.LineHeader;
                        if (obj.ColHeader != null) this.ColHeader = obj.ColHeader;
                        break;
                }//sw
            }//if obj!=null
            //if (this.ContentRepr != null) this.ContentRepr.Assign(obj.ContentRepr, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
            if (CreateDefaultIfNull)
            {
                if (this.LineHeader == null) this.LineHeader = new TableHeaderCellRepresentation();
                if (this.ColHeader == null) this.ColHeader = new TableHeaderCellRepresentation();
            }//if
        }//fn assign
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
        //
        public TTable GetMainAsTable()
        {
            string[] ss = new string[] { "Left", "LeftCenter", "RightCenter", "Right", "AsInExcel" };
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
        //
        public TTable GetColHeaderReprAsTable()
        {
            TTable tbl = null;
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
            LineHeaderExists = tbl.GetBoolVal(1, 1);
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
        public void SetCo_ColHdr()
        {
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
        public void SetCo_LineHdr()
        {
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
        public void SetCo_ColHdrAndItsN()
        {
            SetCo_ColHdr();
        }
        public void SetCo_LineHdrAndItsN()
        {
            SetCo_LineHdr();
        }
        public void SetCo_BothHdrsLEtH_EtNs_As2ArgFn()
        {
            Set_2ArgsFn();
        }
    } //cl 12 TableContentCellRepresentation
    //mark4
	public class TableRepresentationDetails : ICloneable //cl 13 
    {
        public TableGeneralRepresentation GenRepr;
        public TableHeaderCellRepresentation LineHeaderRepr, ColHeaderRepr;
        public TableContentCellRepresentation ContentRepr;
        //
        public TableRepresentationDetails()
        {
            ContentRepr = new TableContentCellRepresentation();
            LineHeaderRepr = new TableHeaderCellRepresentation();
            ColHeaderRepr = new TableHeaderCellRepresentation();
            GenRepr = new TableGeneralRepresentation();
        }
        public TableRepresentationDetails(int Content_Null0Default1Full2=2)
        {
            SetFullOrNullOrDflt(Content_Null0Default1Full2);
        }
        public TableRepresentationDetails(TableGeneralRepresentation GenRepr, TableHeaderCellRepresentation LineHeaderRepr, TableHeaderCellRepresentation ColHeaderRepr, TableContentCellRepresentation ContentRepr)
        {
            this.GenRepr = GenRepr;
            this.LineHeaderRepr = LineHeaderRepr;
            this.ColHeaderRepr = ColHeaderRepr;
            this.ContentRepr = ContentRepr;
        }
        public object Clone()
        {
            return new TableRepresentationDetails(this.GenRepr, this.LineHeaderRepr, this.ColHeaderRepr, this.ContentRepr);
        }
        public void Assign(TableRepresentationDetails obj, int Mode_Rplc_Simply0_Null1_ByNonNull2 = 0, bool CreateDefaultIfNull = false)
        {
            TableContentCellRepresentation ExtContentRepr = null;
            //bool CreateDefaultIfNull = (Mode_RplcSimply0_RplcAndCreateDfltIfExtIsNull1_ReplByNonNull2_RplcNullByAnyExt3_RplcNullByExtAndCreateDfltIfExtIsAlsoNull4 == 1 || Mode_RplcSimply0_RplcAndCreateDfltIfExtIsNull1_ReplByNonNull2_RplcNullByAnyExt3_RplcNullByExtAndCreateDfltIfExtIsAlsoNull4 == 4);
            if (obj != null)
            {
                ExtContentRepr = obj.ContentRepr;
                switch (Mode_Rplc_Simply0_Null1_ByNonNull2)
                {
                    case 0:
                        this.GenRepr = obj.GenRepr;
                        this.LineHeaderRepr = obj.LineHeaderRepr;
                        this.ColHeaderRepr = obj.ColHeaderRepr;
                        this.ContentRepr = obj.ContentRepr;
                    break;
                    case 1:
                        if (this.GenRepr == null) this.GenRepr = obj.GenRepr;
                        if (this.LineHeaderRepr == null) this.LineHeaderRepr = obj.LineHeaderRepr;
                        if (this.ColHeaderRepr == null) this.ColHeaderRepr = obj.ColHeaderRepr;
                        if (this.ContentRepr == null) this.ContentRepr = obj.ContentRepr;
                        //if (this.ContentRepr == null)
                        //{
                        //    this.ContentRepr = new TableContentCellRepresentation();
                        //    if (obj.ContentRepr != null) this.ContentRepr.Assign(obj.ContentRepr, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
                        //}
                        break;
                    case 2:
                        if (obj.GenRepr != null) this.GenRepr = obj.GenRepr;
                        if (obj.LineHeaderRepr != null) this.LineHeaderRepr = obj.LineHeaderRepr;
                        if (obj.ColHeaderRepr != null) this.ColHeaderRepr = obj.ColHeaderRepr;
                        if (obj.ContentRepr != null) this.ContentRepr = obj.ContentRepr;
                        break;
                }//sw
            }//if obj!=null
            if (this.ContentRepr != null) this.ContentRepr.Assign(ExtContentRepr, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
            if (CreateDefaultIfNull)
            {
                if (this.GenRepr == null) this.GenRepr = new TableGeneralRepresentation();
                if (this.LineHeaderRepr == null) this.LineHeaderRepr = new TableHeaderCellRepresentation();
                if (this.ColHeaderRepr == null) this.ColHeaderRepr = new TableHeaderCellRepresentation();
                if (this.ContentRepr == null) this.ContentRepr = new TableContentCellRepresentation();
            }//if
        }//fn assign
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
        //public void SetNull()
        //{
        //    ContentRepr = null;
        //    LineHeaderRepr = null;
        //    ColHeaderRepr = null;
        //    GenRepr = null;
        //}
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
        public void SetFullOrNullOrDflt(int Content_Null0Default1Full2 = 2)
        {
            if (Content_Null0Default1Full2 == 0)
            {
                ContentRepr = null;
                LineHeaderRepr = null;
                ColHeaderRepr = null;
                GenRepr = null;
            }
            if (Content_Null0Default1Full2 == 1)
            {
                ContentRepr = new TableContentCellRepresentation(); ;
                LineHeaderRepr = new TableHeaderCellRepresentation();
                ColHeaderRepr = new TableHeaderCellRepresentation();
                GenRepr = new TableGeneralRepresentation();
            }
            if (Content_Null0Default1Full2 == 2)
            {
                ContentRepr = new TableContentCellRepresentation(); ;
                LineHeaderRepr = new TableHeaderCellRepresentation();
                ColHeaderRepr = new TableHeaderCellRepresentation();
                GenRepr = new TableGeneralRepresentation();
            }
        }
        public void SetNull()
        {
            ContentRepr = null;
            LineHeaderRepr = null;
            ColHeaderRepr = null;
            GenRepr = null;
        }
        public void SetDefault()
        {
            ContentRepr = new TableContentCellRepresentation(); ;
            LineHeaderRepr = new TableHeaderCellRepresentation();
            ColHeaderRepr = new TableHeaderCellRepresentation();
            GenRepr = new TableGeneralRepresentation();
        }
        public void SetFull()
        {
            ContentRepr = new TableContentCellRepresentation(); ;
            LineHeaderRepr = new TableHeaderCellRepresentation();
            ColHeaderRepr = new TableHeaderCellRepresentation();
            GenRepr = new TableGeneralRepresentation();
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
        public void Set_SimpleNumerated(int N_No0Col1Line2Both3=3)
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
        //
        public int LineNOfNaturalN(int N) {
            int RN=N;
            if(this.GenRepr!=null){
                RN=GenRepr.LineNOfNaturalN(N);
            }
            return RN; 
        }
        public int ColumnNOfNaturalN(int N){
            int RN=N;
            if(this.GenRepr!=null){
                RN=GenRepr.ColumnNOfNaturalN(N);
            }
            return RN; 
        }
        //
        public TableGeneralRepresentation GetGeneralRepresentation()
        {
            return GenRepr;
        }
        public  TableHeaderCellRepresentation GetLineHeaderRepr()
        {
            return LineHeaderRepr;
        }
        public TableHeaderCellRepresentation GetColHeaderRepr()
        {
            return ColHeaderRepr;
        }
        public TableContentCellRepresentation GetContentRepr()
        {
            return ContentRepr;
        }
        public TableHeaderCellRepresentation GetColumnHeaderReprOfContentCell()
        {
            TableHeaderCellRepresentation R=null;
            if (this.ContentRepr == null) R = ContentRepr.ColHeader;
            return R;
        }
        public TableHeaderCellRepresentation GetLineHeaderReprOfContentCell()
        {
            TableHeaderCellRepresentation R = null;
            if (this.ContentRepr == null) R = ContentRepr.LineHeader;
            return R;
        }
        //
        public void SetGeneralRepresentation(TableGeneralRepresentation GenRepr)
        {
            this.GenRepr=GenRepr;
        }
        public void SetLineHeaderRepr(TableHeaderCellRepresentation LineHeaderRepr)
        {
            this.LineHeaderRepr=LineHeaderRepr;
        }
        public void SetColHeaderRepr(TableHeaderCellRepresentation ColHeaderRepr)
        {
            this.ColHeaderRepr=ColHeaderRepr;
        }
        public void SetContentRepr(TableContentCellRepresentation ContentRepr)
        {
            this.ContentRepr = ContentRepr;
        }
        public void SetColHeaderReprOfContentCell(TableHeaderCellRepresentation ColHeader)
        {
            if (this.ContentRepr == null) this.ContentRepr = new TableContentCellRepresentation();
            this.ContentRepr.ColHeader=ColHeader;
        }
        public void SetLineHeaderReprOfContentCell(TableHeaderCellRepresentation LineHeader)
        {
            if (this.ContentRepr == null) this.ContentRepr = new TableContentCellRepresentation();
            this.ContentRepr.LineHeader=LineHeader;
        }
        //
        public void CreateWhatIsNull()
        {
            if (this.GenRepr == null) this.GenRepr = new TableGeneralRepresentation();
            if (this.ColHeaderRepr == null) this.ColHeaderRepr = new TableHeaderCellRepresentation();
            if (this.LineHeaderRepr == null) this.LineHeaderRepr = new TableHeaderCellRepresentation();
            if (this.ContentRepr == null) this.ContentRepr = new TableContentCellRepresentation();
        }
        //
        //
        public TTable GetGeneralRepresentationAsTable()
        {
            TTable TR=null;
            if (GenRepr != null) TR = GenRepr.GetAsTable();
            return TR;
        }
        public TTable GetLineHeaderReprAsTable()
        {
            TTable TR = null;
            if (GenRepr != null) TR = LineHeaderRepr.GetAsTable();
            return TR;
        }
        public TTable GetColumnHeaderReprAsTable()
        {
            TTable TR = null;
            if (GenRepr != null) TR = ColHeaderRepr.GetAsTable();
            return TR;
        }
        public TTable GetContentReprMainPartAsTable()
        {
            TTable TR = null;
            if (GenRepr != null) TR = ContentRepr.GetMainAsTable();
            return TR;
        }
        public TTable GetColumnHeaderReprOfContentCellAsTable()
        {
            TTable TR = null;
            if (this.ContentRepr != null && this.ContentRepr.ColHeader!=null) TR = ContentRepr.ColHeader.GetAsTable();
            return TR;
        }
        public TTable GetLineHeaderReprOfContentCellAsTable()
        {
            TTable TR = null;
            if (this.ContentRepr != null && this.ContentRepr.LineHeader != null) TR = ContentRepr.LineHeader.GetAsTable();
            return TR;
        }
        //
        public void SetGeneralRepresentationFromTable(TTable tbl)
        {
            if (this.GenRepr == null) this.GenRepr = new TableGeneralRepresentation();
            this.GenRepr.SetFromTable(tbl);
        }
        public void SetLineHeaderReprFromTable(TTable tbl)
        {
            if (this.LineHeaderRepr == null) this.LineHeaderRepr = new TableHeaderCellRepresentation();
            this.LineHeaderRepr.SetFromTable(tbl);
        }
        public void SetColHeaderReprFromTable(TTable tbl)
        {
            if (this.ColHeaderRepr == null) this.ColHeaderRepr = new TableHeaderCellRepresentation();
            this.ColHeaderRepr.SetFromTable(tbl);
        }
        public void SetContentReprMainPartFromTable(TTable tbl)
        {
            if (this.ContentRepr == null) this.ContentRepr = new TableContentCellRepresentation();
            this.ContentRepr.SetMainPartFromTable(tbl);
        }
        public void SetColHeaderReprOfContentCellFromTable(TTable tbl)
        {
            if (this.ContentRepr == null) this.ContentRepr = new TableContentCellRepresentation();
            this.ContentRepr.ColHeader.SetFromTable(tbl);
        }
        public void SetLineHeaderReprOfContentCellFromTable(TTable tbl)
        {
            if (this.ContentRepr == null) this.ContentRepr = new TableContentCellRepresentation();
            this.ContentRepr.LineHeader.SetFromTable(tbl);
        }
    }//cl 13 TableRepresentation
    public class TableRepresentation : ICloneable //cl 13 
    {
        public TableRepresentationDetails dets;
        public TRowsNumeration num;
        //public TableGeneralRepresentation GenRepr;
        //public TableHeaderCellRepresentation LineHeaderRepr, ColHeaderRepr;
        //public TableContentCellRepresentation ContentRepr;
        //
        public TableRepresentation()
        {
            dets = new TableRepresentationDetails();
            num = new TRowsNumeration();
            //ContentRepr = new TableContentCellRepresentation();
            //LineHeaderRepr = new TableHeaderCellRepresentation();
            //ColHeaderRepr = new TableHeaderCellRepresentation();
            //GenRepr = new TableGeneralRepresentation();
        }
        public TableRepresentation(TableRepresentationDetails dets, TRowsNumeration num)
        {
            this.dets = dets;
            this.num = num;
            //ContentRepr = new TableContentCellRepresentation();
            //LineHeaderRepr = new TableHeaderCellRepresentation();
            //ColHeaderRepr = new TableHeaderCellRepresentation();
            //GenRepr = new TableGeneralRepresentation();
        }
        public TableRepresentation(int Content_Null0Default1)
        {
            dets = new TableRepresentationDetails(Content_Null0Default1);
            if (Content_Null0Default1 == 0) num = null;
            if (Content_Null0Default1 == 0) num = new TRowsNumeration();
            //if (Content_Null0Default1 == 0)
            //{
            //    ContentRepr = null;
            //    LineHeaderRepr = null;
            //    ColHeaderRepr = null;
            //    GenRepr = null;
            //}
            //if (Content_Null0Default1 == 1)
            //{
            //    ContentRepr = new TableContentCellRepresentation(); ;
            //    LineHeaderRepr = new TableHeaderCellRepresentation();
            //    ColHeaderRepr = new TableHeaderCellRepresentation();
            //    GenRepr = new TableGeneralRepresentation();
            //}
        }
        public TableRepresentation(TableGeneralRepresentation GenRepr, TableHeaderCellRepresentation LineHeaderRepr, TableHeaderCellRepresentation ColHeaderRepr, TableContentCellRepresentation ContentRepr)
        {
            this.dets = new TableRepresentationDetails(GenRepr, LineHeaderRepr, ColHeaderRepr, ContentRepr);
            //this.GenRepr = GenRepr;
            //this.LineHeaderRepr = LineHeaderRepr;
            //this.ColHeaderRepr = ColHeaderRepr;
            //this.ContentRepr = ContentRepr;
        }
        public object Clone()
        {
            return new TableRepresentation(this.dets, this.num);
        }
        public void Assign(TableRepresentation obj, int Mode_Rplc_Simply0_Null1_ByNonNull2 = 0, bool CreateDefaultIfNull = false)
        {
            TableRepresentationDetails DetsExt = null;
            if (obj != null) DetsExt = obj.dets;
            //bool CreateDefaultIfNull = (Mode_RplcSimply0_RplcAndCreateDfltIfExtIsNull1_ReplByNonNull2_RplcNullByAnyExt3_RplcNullByExtAndCreateDfltIfExtIsAlsoNull4 == 1 || Mode_RplcSimply0_RplcAndCreateDfltIfExtIsNull1_ReplByNonNull2_RplcNullByAnyExt3_RplcNullByExtAndCreateDfltIfExtIsAlsoNull4 == 4);
            if (obj != null)
            {
                switch (Mode_Rplc_Simply0_Null1_ByNonNull2)
                {
                    case 0:
                        this.dets = obj.dets;
                        this.num = obj.num;
                        break;
                    case 1:
                        if (this.dets == null) this.dets = obj.dets;
                        if (this.num == null) this.num = obj.num;
                        break;
                    case 2:
                        if (obj.dets != null) this.dets = obj.dets;
                        if (obj.num != null) this.num = obj.num;
                        break;
                }//sw
            }//if obj!=null
            if (this.dets != null) this.dets.Assign(DetsExt, Mode_Rplc_Simply0_Null1_ByNonNull2, CreateDefaultIfNull);
            if (CreateDefaultIfNull)
            {
                if (this.dets == null) this.dets = new TableRepresentationDetails();
                if (this.num == null) this.num = new TRowsNumeration();
            }//if
        }//fn assign
        //
        public void CreateDetsIfIsNull()
        {
            if (dets == null) dets = new TableRepresentationDetails();
        }
        public void CreateRowsNumerationIfIsNull()
        {
            if (num == null) num = new TRowsNumeration();
        }
        //
        public void CreateWhatIsNull()
        {
            dets.CreateWhatIsNull();
        }
        //
        public void SetGenReprNull()
        {
            CreateDetsIfIsNull();
            this.dets.SetGenReprNull();
        }
        public void SetContentReprNull()
        {
            CreateDetsIfIsNull();
            this.dets.SetContentReprNull();
        }
        public void SetColHeaderReprNull()
        {
            CreateDetsIfIsNull();
            this.dets.SetColHeaderReprNull();
        }
        public void SetLineHeaderReprNull()
        {
            CreateDetsIfIsNull();
            this.dets.SetLineHeaderReprNull();
        }
        public void SetNull()
        {
            CreateDetsIfIsNull();
            this.dets.SetNull();
        }
        //
        public void SetGenReprDefault()
        {
            CreateDetsIfIsNull();
            this.dets.SetGenReprDefault();
        }
        public void SetLineHeaderReprDefault()
        {
            CreateDetsIfIsNull();
            this.dets.SetLineHeaderReprDefault();
        }
        public void SetColumnHeaderReprDefault()
        {
            CreateDetsIfIsNull();
            this.dets.SetColumnHeaderReprDefault();
        }
        public void CreateContentByDefault()
        {
            CreateDetsIfIsNull();
            this.dets.CreateContentByDefault();
        }
        //
        public void SetColHeaderByExistanceByDefault(int ColHeaderExists_No0Yes1)
        {
            CreateDetsIfIsNull();
            this.dets.SetColHeaderByExistanceByDefault(ColHeaderExists_No0Yes1);
        }
        public void SetLineHeaderByExistanceByDefault(int LineHeaderExists_No0Yes1)
        {
            CreateDetsIfIsNull();
            this.dets.SetLineHeaderByExistanceByDefault(LineHeaderExists_No0Yes1);
        }
        //
        public void CreateFullRepresentation()
        {
            if(dets==null) dets=new TableRepresentationDetails();
            if (dets.GenRepr == null || dets.ColHeaderRepr == null || dets.LineHeaderRepr == null || dets.ContentRepr == null)
                dets.SetFull();
        }
        //
        public void Set_Matrix()
        {
            CreateDetsIfIsNull();
            this.dets.Set_Matrix();
            //this.ColHeaderRepr.Set_Matrix();
            //this.LineHeaderRepr.Set_Matrix();
            //this.ContentRepr.Set_Matrix();
            //this.GenRepr.Set_Matrix();
        }
        public void Set_List()
        {
            CreateDetsIfIsNull();
            this.dets.Set_Matrix();
            //this.ColHeaderRepr.Set_List();
            //this.LineHeaderRepr.Set_List();
            //this.ContentRepr.Set_List();
            //this.GenRepr.Set_List();
        }
        public void Set_Simple()
        {
            CreateDetsIfIsNull();
            this.dets.Set_Simple();
            //this.ColHeaderRepr.Set_Simple();
            //this.LineHeaderRepr.Set_Simple();
            //this.ContentRepr.Set_Simple();
            //this.GenRepr.Set_Simple();
        }
        public void Set_SimpleNumerated(int N_No0Col1Line2Both3 = 3)
        {
            CreateDetsIfIsNull();
            this.dets.Set_SimpleNumerated(N_No0Col1Line2Both3);
            //if (N_No0Col1Line2Both3 == 1 || N_No0Col1Line2Both3 == 3) this.ColHeaderRepr.Set_SimpleNumerated();
            //else this.ColHeaderRepr.Set_Simple();
            //if (N_No0Col1Line2Both3 == 2 || N_No0Col1Line2Both3 == 3) this.LineHeaderRepr.Set_SimpleNumerated();
            //else this.LineHeaderRepr.Set_Simple();
            //this.ContentRepr.Set_Simple();
            //this.GenRepr.Set_Simple();
        }
        public void Set_2ArgsFn()
        {
            CreateDetsIfIsNull();
            this.dets.Set_2ArgsFn();
            //if (ColHeaderRepr == null) ColHeaderRepr = new TableHeaderCellRepresentation();
            //ColHeaderRepr.Set_2ArgsFn();
            //ColHeaderRepr.RowName = true;
            //ColHeaderRepr.GenRowNameBef = true;
            //ColHeaderRepr.RowNAft = true;
            //ColHeaderRepr.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 4;
            //
            //if (LineHeaderRepr == null) LineHeaderRepr = new TableHeaderCellRepresentation();
            //LineHeaderRepr.Set_2ArgsFn();
            //LineHeaderRepr.RowName = true;
            //LineHeaderRepr.GenRowNameBef = true;
            //LineHeaderRepr.RowNAft = true;
            //LineHeaderRepr.Aft_Nil0_Minus1_Colon2_Comma3_EqSgn4_Bracket5_Row6_Line7_Col8 = 4;
            //
            //if (ContentRepr == null) ContentRepr = new TableContentCellRepresentation();
            //ContentRepr.Set_2ArgsFn();
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
        //
        public int LineNOfNaturalN(int N)
        {
            //int RN = N;
            //if (this.GenRepr != null)
            //{
            //    RN = GenRepr.LineNOfNaturalN(N);
            //}
            //return RN;
            CreateRowsNumerationIfIsNull();
            return this.num.LineNOfNaturalN(N);
        }
        public int ColumnNOfNaturalN(int N)
        {
            //int RN = N;
            //if (this.GenRepr != null)
            //{
            //    RN = GenRepr.ColumnNOfNaturalN(N);
            //}
            //return RN;
            CreateRowsNumerationIfIsNull();
            return this.num.ColumnNOfNaturalN(N);
        }
        //
        //
        public TableGeneralRepresentation GetGeneralRepresentation()
        {
            TableGeneralRepresentation R = null;
            if (dets != null) R = dets.GetGeneralRepresentation();
            return R;
        }
        public TableHeaderCellRepresentation GetLineHeaderRepr()
        {
            TableHeaderCellRepresentation R = null;
            if (dets != null) R = dets.GetLineHeaderRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetColHeaderRepr()
        {
            TableHeaderCellRepresentation R = null;
            if (dets != null) R = dets.GetColHeaderRepr();
            return R;
        }
        public TableContentCellRepresentation GetContentRepr()
        {
            TableContentCellRepresentation R = null;
            if (dets != null) R = dets.GetContentRepr();
            return R;
        }
        public TableHeaderCellRepresentation GetColumnHeaderReprOfContentCell()
        {
            TableHeaderCellRepresentation R = null;
            if (dets != null) R = dets.GetColumnHeaderReprOfContentCell();
            return R;
        }
        public TableHeaderCellRepresentation GetLineHeaderReprOfContentCell()
        {
            TableHeaderCellRepresentation R = null;
            if (dets != null) R = dets.GetLineHeaderReprOfContentCell();
            return R;
        }
        //
        public void SetGeneralRepresentation(TableGeneralRepresentation GenRepr)
        {
            if (this.dets == null) dets = new TableRepresentationDetails();
            this.dets.SetGeneralRepresentation(GenRepr);
        }
        public void SetLineHeaderRepr(TableHeaderCellRepresentation LineHeaderRepr)
        {
            if (this.dets == null) dets = new TableRepresentationDetails();
            this.dets.SetLineHeaderRepr(LineHeaderRepr);
        }
        public void SetColHeaderRepr(TableHeaderCellRepresentation ColHeaderRepr)
        {
            if (this.dets == null) dets = new TableRepresentationDetails();
            this.dets.SetColHeaderRepr(ColHeaderRepr);
        }
        public void SetContentRepr(TableContentCellRepresentation ContentRepr)
        {
            if (this.dets == null) dets = new TableRepresentationDetails();
            this.dets.SetContentRepr(ContentRepr);
        }
        public void SetColHeaderReprOfContentCell(TableHeaderCellRepresentation ColHeader)
        {
            if (this.dets == null) dets = new TableRepresentationDetails();
            this.dets.SetColHeaderReprOfContentCell(ColHeader);
        }
        public void SetLineHeaderReprOfContentCell(TableHeaderCellRepresentation LineHeader)
        {
            if (this.dets == null) dets = new TableRepresentationDetails();
            this.dets.SetLineHeaderReprOfContentCell(LineHeader);
        }
        //
        //
        public TTable GetGeneralRepresentationAsTable()
        {
            TTable TR = null;
            if (this.dets != null) TR = this.dets.GetGeneralRepresentationAsTable();
            return TR;
        }
        public TTable GetLineHeaderReprAsTable()
        {
            TTable TR = null;
            if (this.dets != null) TR = this.dets.GetLineHeaderReprAsTable();
            return TR;
        }
        public TTable GetColumnHeaderReprAsTable()
        {
            TTable TR = null;
            if (this.dets != null) TR = this.dets.GetColumnHeaderReprAsTable();
            return TR;
        }
        public TTable GetContentReprMainPartAsTable()
        {
            TTable TR = null;
            if (this.dets != null) TR = this.dets.GetContentReprMainPartAsTable();
            return TR;
        }
        public TTable GetColumnHeaderReprOfContentCellAsTable()
        {
            TTable TR = null;
            if (this.dets != null) TR = this.dets.GetColumnHeaderReprOfContentCellAsTable();
            return TR;
        }
        public TTable GetLineHeaderReprOfContentCellAsTable()
        {
            TTable TR = null;
            if (this.dets != null) TR = this.dets.GetLineHeaderReprOfContentCellAsTable();
            return TR;
        }
        //
        public void SetGeneralRepresentationFromTable(TTable tbl)
        {
            if (this.dets == null) this.dets = new TableRepresentationDetails();
            this.dets.SetGeneralRepresentationFromTable(tbl);
        }
        public void SetLineHeaderReprFromTable(TTable tbl)
        {
            if (this.dets == null) this.dets = new TableRepresentationDetails();
            this.dets.SetLineHeaderReprFromTable(tbl);
        }
        public void SetColHeaderReprFromTable(TTable tbl)
        {
            if (this.dets == null) this.dets = new TableRepresentationDetails();
            this.dets.SetColHeaderReprFromTable(tbl);
        }
        public void SetContentReprMainPartFromTable(TTable tbl)
        {
            if (this.dets == null) this.dets = new TableRepresentationDetails();
            this.dets.SetContentReprMainPartFromTable(tbl);
        }
        public void SetColHeaderReprOfContentCellFromTable(TTable tbl)
        {
            if (this.dets == null) this.dets = new TableRepresentationDetails();
            this.dets.SetColHeaderReprOfContentCellFromTable(tbl);
        }
        public void SetLineHeaderReprOfContentCellFromTable(TTable tbl)
        {
            if (this.dets == null) this.dets = new TableRepresentationDetails();
            this.dets.SetLineHeaderReprOfContentCellFromTable(tbl);
        }
    }//cl 13 TableRepresentation
    //
    public class TableUssagePolicy : ICloneable //cl 16 
    {
        //public int Rows, Columns, Content, Both;
        public bool LinesCanAdd, LinesCanDel, LinesCanIns, LinesCanReplace;
        public bool ColumnsCanAdd, ColumnsCanDel, ColumnsCanIns, ColumnsCanReplace;
        public bool BothCanAdd, BothCanDel, BothCanIns, BothCanReplace;
        public bool LH_Can_Edit, CH_Can_Edit, ContentsCanEdit;
        //
        public bool LinesGenName_Can_Edit, ColumnsGenName_Can_Edit, TableName_Can_Edit,
                    Can_Transpose;
        //public bool ContentLinesSepCanAdd, ContentLinesSepCanDel, ContentLinesSepCanIns, ContentLinesSepCanReplace;
        bool ContentLinesSeparatelyCanEdit; //means also all 4 commented
        public bool ContentCellsCanReplace;
        public bool SettingsBrowsingIsAllowed;
        public bool SettingsEditingIsAllowed;
        //
        public int QLinesMin, QLinesMax, QColumnsMin, QColumnsMax;
        public bool QLinesMinDefined, QLinesMaxDefined, QColumnsMinDefined, QColumnsMaxDefined;
        //
        public TableUssagePolicy()
        {
            QLinesMin = 1; QLinesMax = 1; QColumnsMin = 1; QColumnsMax = 1;
            QLinesMinDefined = false; QLinesMaxDefined = false; QColumnsMinDefined = false; QColumnsMaxDefined = false; 
            //
            AllowAll();
            SettingsBrowsingIsAllowed = true;
            SettingsEditingIsAllowed = false;
        }
        public object Clone() { return this.MemberwiseClone(); }
        public void AllowAll()
        {
            LinesCanAdd = true; LinesCanDel = true; LinesCanIns = true; LinesCanReplace = true;
            ColumnsCanAdd = true; ColumnsCanDel = true; ColumnsCanIns = true; ColumnsCanReplace = true;
            BothCanAdd = true; BothCanDel = true; BothCanIns = true; BothCanReplace = true;
            ContentCellsCanReplace = true;
            LH_Can_Edit = true; CH_Can_Edit = true; ContentsCanEdit = true;
            //
            LinesGenName_Can_Edit = true; ColumnsGenName_Can_Edit = true; TableName_Can_Edit = true;
            Can_Transpose = true;
            //
            QLinesMinDefined = false; QLinesMaxDefined = false; QColumnsMinDefined = false; QColumnsMaxDefined = false; 
        }
        public void ForbidAll()
        {
            LinesCanAdd = false; LinesCanDel = false; LinesCanIns = false; LinesCanReplace = false;
            ColumnsCanAdd = false; ColumnsCanDel = false; ColumnsCanIns = false; ColumnsCanReplace = false;
            BothCanAdd = false; BothCanDel = false; BothCanIns = false; BothCanReplace = false;
            ContentCellsCanReplace = false;
            LH_Can_Edit = false; CH_Can_Edit = false; ContentsCanEdit = false;
            //
            LinesGenName_Can_Edit = false; ColumnsGenName_Can_Edit = false; TableName_Can_Edit = false;
            Can_Transpose = false;
        }
        //
        public void AllowEditContents() { ContentsCanEdit = true; }
        public void ForbidEditContents() { ContentsCanEdit = false; }
        public void SetIfAllowedEditingContents(bool b) { ContentsCanEdit = b; }
        //
        public void AllowColumns()
        {
            ColumnsCanAdd = true; ColumnsCanDel = true; ColumnsCanIns = true; ColumnsCanReplace = true; CH_Can_Edit = true;
        }
        public void AllowLines()
        {
            LinesCanAdd = true; LinesCanDel = true; LinesCanIns = true; LinesCanReplace = true; LH_Can_Edit = true;
        }
        public void AllowBoth()
        {
            BothCanAdd = true; BothCanDel = true; BothCanIns = true; BothCanReplace = true;
        }
        public void ForbidColumns()
        {
            ColumnsCanAdd = false; ColumnsCanDel = false; ColumnsCanIns = false; ColumnsCanReplace = false; CH_Can_Edit = false;
        }
        public void ForbidLines()
        {
            LinesCanAdd = false; LinesCanDel = false; LinesCanIns = false; LinesCanReplace = false; LH_Can_Edit = false;
        }
        public void ForbidBoth()
        {
            BothCanAdd = false; BothCanDel = false; BothCanIns = false; BothCanReplace = false;
        }
        public void FixRowsQuantity()
        {
            LinesCanAdd = false; LinesCanDel = false; LinesCanIns = false;
            ColumnsCanAdd = false; ColumnsCanDel = false; ColumnsCanIns = false;
            BothCanAdd = false; BothCanDel = false; BothCanIns = false;
            Can_Transpose = false;
        }
        //
        public void ForbidToShowAndEditSettings()
        {
            SettingsBrowsingIsAllowed = false;
            SettingsEditingIsAllowed = false;
        }
        //
        public void SetMinQLines(int QLinesMin){
            this.QLinesMin=QLinesMin;
            this.QLinesMinDefined=true;
        }
        public void UnSetMinQLines()
        {
            this.QLinesMinDefined = false;
        }
        public void SetMaxQLines(int QLinesMax){
            this.QLinesMax=QLinesMax;
            this.QLinesMaxDefined=true;
        }
        public void UnSetMaxQLines()
        {
            this.QLinesMaxDefined = false;
        }
        public void SetMinQColumns(int QColumnsMin){
            this.QColumnsMin=QColumnsMin;
            this.QColumnsMinDefined=true;
        }
        public void UnSetMinQColumns()
        {
            this.QColumnsMinDefined = false;
        }
        public void SetMaxQColumns(int QColumnsMax){
            this.QColumnsMax=QColumnsMax;
            this.QColumnsMaxDefined=true;
        }
        public void UnSetMaxQColumns()
        {
            this.QColumnsMaxDefined = false;
        }
        public void SetLinesRange(int QLinesMin, int QLinesMax)
        {
            if (QLinesMin > QLinesMax) MyLib.Swap<int>(ref QLinesMin, ref QLinesMax);
            this.QLinesMin = QLinesMin;
            this.QLinesMax = QLinesMax;
            this.QLinesMinDefined = true;
            this.QLinesMaxDefined = true;
        }
        public void SetFixedQLines(int QLines)
        {
            if (QLines >= 1 && QLines <= MyLib.MaxInt)
            {
                this.QLinesMin = QLines;
                this.QLinesMax = QLines;
                this.QLinesMinDefined = true;
                this.QLinesMaxDefined = true;
            }
        }
        public void SetColumnsRange(int QColumnsMin, int QColumnsMax)
        {
            if (QColumnsMin > QColumnsMax) MyLib.Swap<int>(ref QColumnsMin, ref QColumnsMax);
            this.QColumnsMin = QColumnsMin;
            this.QColumnsMax = QColumnsMax;
            this.QColumnsMinDefined = true;
            this.QColumnsMaxDefined = true;
        }
        public void SetFixedQColumns(int QColumns)
        {
            if (QColumns >= 1 && QColumns <= MyLib.MaxInt)
            {
                this.QColumnsMin = QColumns;
                this.QColumnsMax = QColumns;
                this.QColumnsMinDefined = true;
                this.QColumnsMaxDefined = true;
            }
        }
        //
        public TTable GetAsTable()
        {
            int QItems = 30;// 22;
            DataCellRowCoHeader[] rows = new DataCellRowCoHeader[QItems];
            rows[1 - 1] = new DataCellRowCoHeader(new DataCell("LinesCanAdd"), new DataCellRow(new DataCell(LinesCanAdd)));
            rows[2 - 1] = new DataCellRowCoHeader(new DataCell("LinesCanDel"), new DataCellRow(new DataCell(LinesCanDel)));
            rows[3 - 1] = new DataCellRowCoHeader(new DataCell("LinesCanIns"), new DataCellRow(new DataCell(LinesCanIns)));
            rows[4 - 1] = new DataCellRowCoHeader(new DataCell("LinesCanReplace"), new DataCellRow(new DataCell(LinesCanReplace)));
            //
            rows[5 - 1] = new DataCellRowCoHeader(new DataCell("ColumnsCanAdd"), new DataCellRow(new DataCell(ColumnsCanAdd)));
            rows[6 - 1] = new DataCellRowCoHeader(new DataCell("ColumnsCanDel"), new DataCellRow(new DataCell(ColumnsCanDel)));
            rows[7 - 1] = new DataCellRowCoHeader(new DataCell("ColumnsCanIns"), new DataCellRow(new DataCell(ColumnsCanIns)));
            rows[8 - 1] = new DataCellRowCoHeader(new DataCell("ColumnsCanReplace"), new DataCellRow(new DataCell(ColumnsCanReplace)));
            //
            rows[9 - 1] = new DataCellRowCoHeader(new DataCell("BothCanAdd"), new DataCellRow(new DataCell(BothCanAdd)));
            rows[10 - 1] = new DataCellRowCoHeader(new DataCell("BothCanDel"), new DataCellRow(new DataCell(BothCanDel)));
            rows[11 - 1] = new DataCellRowCoHeader(new DataCell("BothCanIns"), new DataCellRow(new DataCell(BothCanIns)));
            rows[12 - 1] = new DataCellRowCoHeader(new DataCell("BothCanReplace"), new DataCellRow(new DataCell(BothCanReplace)));
            //
            rows[13 - 1] = new DataCellRowCoHeader(new DataCell("LH_Can_Edit"), new DataCellRow(new DataCell(LH_Can_Edit)));
            rows[14 - 1] = new DataCellRowCoHeader(new DataCell("CH_Can_Edit"), new DataCellRow(new DataCell(CH_Can_Edit)));
            rows[15 - 1] = new DataCellRowCoHeader(new DataCell("ContentsCanEdit"), new DataCellRow(new DataCell(ContentsCanEdit)));
            //
            rows[16 - 1] = new DataCellRowCoHeader(new DataCell("LinesGenName_Can_Edit"), new DataCellRow(new DataCell(LinesGenName_Can_Edit)));
            rows[17 - 1] = new DataCellRowCoHeader(new DataCell("ColumnsGenName_Can_Edit"), new DataCellRow(new DataCell(ColumnsGenName_Can_Edit)));
            rows[18 - 1] = new DataCellRowCoHeader(new DataCell("TableName_Can_Edit"), new DataCellRow(new DataCell(TableName_Can_Edit)));
            //
            rows[19 - 1] = new DataCellRowCoHeader(new DataCell("ContentCellsCanReplace"), new DataCellRow(new DataCell(ContentCellsCanReplace)));
            //rows[16 - 1] = new DataCellRowCoHeader(new DataCell("ContentCellsCanReplace"), new DataCellRow(new DataCell(ContentCellsCanReplace)));
            rows[20 - 1] = new DataCellRowCoHeader(new DataCell("CanTranspose"), new DataCellRow(new DataCell(Can_Transpose)));
            //
            rows[21 - 1] = new DataCellRowCoHeader(new DataCell("SettingsBrowsingIsAllowed"), new DataCellRow(new DataCell(SettingsBrowsingIsAllowed)));
            rows[22 - 1] = new DataCellRowCoHeader(new DataCell("SettingsEditingIsAllowed"), new DataCellRow(new DataCell(SettingsEditingIsAllowed)));
            //rows[17 - 1] = new DataCellRowCoHeader(new DataCell("SettingsBrowsingIsAllowed"), new DataCellRow(new DataCell(SettingsBrowsingIsAllowed)));
            //rows[18 - 1] = new DataCellRowCoHeader(new DataCell("SettingsEditingIsAllowed"), new DataCellRow(new DataCell(SettingsEditingIsAllowed)));
            //
            rows[23 - 1] = new DataCellRowCoHeader(new DataCell("MinQLinesDefined"), new DataCellRow(new DataCell(QLinesMinDefined)));
            rows[24 - 1] = new DataCellRowCoHeader(new DataCell("MinQLines"), new DataCellRow(new DataCell(QLinesMin)));
            rows[25 - 1] = new DataCellRowCoHeader(new DataCell("MaxQLinesDefined"), new DataCellRow(new DataCell(QLinesMaxDefined)));
            rows[26 - 1] = new DataCellRowCoHeader(new DataCell("MaxQLines"), new DataCellRow(new DataCell(QLinesMax)));
            rows[27 - 1] = new DataCellRowCoHeader(new DataCell("MinQColumnsDefined"), new DataCellRow(new DataCell(QColumnsMinDefined)));
            rows[28 - 1] = new DataCellRowCoHeader(new DataCell("MinQColumns"), new DataCellRow(new DataCell(QColumnsMin)));
            rows[29 - 1] = new DataCellRowCoHeader(new DataCell("MaxQColumnsDefined"), new DataCellRow(new DataCell(QColumnsMaxDefined)));
            rows[30 - 1] = new DataCellRowCoHeader(new DataCell("MaxQColumns"), new DataCellRow(new DataCell(QColumnsMax)));
            TTable tbl = new TTable(
                new TableInfo(true, true, true, QItems, 1),
                false,
                rows,
                new DataCellRow(new DataCell("Values")),
                new TableHeaders(new DataCell("Table Ussage Policy"), new DataCell("Params"), new DataCell("")),
                true
            );
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetTableUssagePolicy(UsePol);
            //tbl
            return tbl;
        }
        public void SetFromTable(TTable tbl)
        {
            //DataCellRowCoHeader[] rows = new DataCellRowCoHeader[17];
            //rows[1 - 1] = new DataCellRowCoHeader(new DataCell("LinesCanAdd"), new DataCellRow(new DataCell(LinesCanAdd)));
            LinesCanAdd = tbl.GetBoolVal(1, 1);
            //rows[2 - 1] = new DataCellRowCoHeader(new DataCell("LinesCanDel"), new DataCellRow(new DataCell(LinesCanDel)));
            LinesCanDel = tbl.GetBoolVal(2, 1);
            //rows[3 - 1] = new DataCellRowCoHeader(new DataCell("LinesCanIns"), new DataCellRow(new DataCell(LinesCanIns)));
            LinesCanIns = tbl.GetBoolVal(3, 1);
            //rows[4 - 1] = new DataCellRowCoHeader(new DataCell("LinesCanReplace"), new DataCellRow(new DataCell(LinesCanReplace)));
            LinesCanReplace = tbl.GetBoolVal(4, 1);
            //
            //rows[5 - 1] = new DataCellRowCoHeader(new DataCell("ColumnsCanAdd"), new DataCellRow(new DataCell(ColumnsCanAdd)));
            ColumnsCanAdd = tbl.GetBoolVal(5, 1);
            //rows[6 - 1] = new DataCellRowCoHeader(new DataCell("ColumnsCanDel"), new DataCellRow(new DataCell(ColumnsCanDel)));
            ColumnsCanDel = tbl.GetBoolVal(6, 1);
            //rows[7 - 1] = new DataCellRowCoHeader(new DataCell("ColumnsCanIns"), new DataCellRow(new DataCell(ColumnsCanIns)));
            ColumnsCanIns = tbl.GetBoolVal(7, 1);
            //rows[8 - 1] = new DataCellRowCoHeader(new DataCell("ColumnsCanReplace"), new DataCellRow(new DataCell(ColumnsCanReplace)));
            ColumnsCanReplace = tbl.GetBoolVal(8, 1);
            //
            //rows[9 - 1] = new DataCellRowCoHeader(new DataCell("BothCanAdd"), new DataCellRow(new DataCell(BothCanAdd)));
            BothCanAdd = tbl.GetBoolVal(9, 1);
            //rows[10 - 1] = new DataCellRowCoHeader(new DataCell("BothCanDel"), new DataCellRow(new DataCell(BothCanDel)));
            BothCanDel = tbl.GetBoolVal(10, 1);
            //rows[11 - 1] = new DataCellRowCoHeader(new DataCell("BothCanIns"), new DataCellRow(new DataCell(BothCanIns)));
            BothCanIns = tbl.GetBoolVal(11, 1);
            //rows[12 - 1] = new DataCellRowCoHeader(new DataCell("BothCanReplace"), new DataCellRow(new DataCell(BothCanReplace)));
            BothCanReplace = tbl.GetBoolVal(12, 1);
            //
            //rows[13 - 1] = new DataCellRowCoHeader(new DataCell("LH_Can_Edit"), new DataCellRow(new DataCell(LH_Can_Edit)));
            LH_Can_Edit = tbl.GetBoolVal(13, 1);
            //rows[14 - 1] = new DataCellRowCoHeader(new DataCell("CH_Can_Edit"), new DataCellRow(new DataCell(CH_Can_Edit)));
            CH_Can_Edit = tbl.GetBoolVal(14, 1);
            //rows[15 - 1] = new DataCellRowCoHeader(new DataCell("ContentsCanEdit"), new DataCellRow(new DataCell(ContentsCanEdit)));
            ContentsCanEdit = tbl.GetBoolVal(15, 1);
            //rows[16 - 1] = new DataCellRowCoHeader(new DataCell("ContentCellsCanReplace"), new DataCellRow(new DataCell(ContentCellsCanReplace)));
            //ContentCellsCanReplace = tbl.GetBoolVal(16, 1);
            LinesGenName_Can_Edit = tbl.GetBoolVal(16, 1);
            ColumnsGenName_Can_Edit = tbl.GetBoolVal(17, 1);
            TableName_Can_Edit = tbl.GetBoolVal(18, 1);
            //
            ContentCellsCanReplace = tbl.GetBoolVal(19, 1);
            //
            Can_Transpose = tbl.GetBoolVal(20, 1);
            //
            //rows[17 - 1] = new DataCellRowCoHeader(new DataCell("SettingsBrowsingIsAllowed"), new DataCellRow(new DataCell(SettingsBrowsingIsAllowed)));
            //SettingsBrowsingIsAllowed = tbl.GetBoolVal(17, 1);
            SettingsBrowsingIsAllowed = tbl.GetBoolVal(21, 1);
            //rows[18 - 1] = new DataCellRowCoHeader(new DataCell("SettingsEditingIsAllowed"), new DataCellRow(new DataCell(SettingsEditingIsAllowed)));
            //SettingsEditingIsAllowed = tbl.GetBoolVal(18, 1);
            SettingsEditingIsAllowed = tbl.GetBoolVal(22, 1);
            //
            QLinesMinDefined = tbl.GetBoolVal(23, 1); //  rows[23 - 1] = new DataCellRowCoHeader(new DataCell("MinQLinesDefined"), new DataCellRow(new DataCell(QLinesMinDefined)));
            QLinesMin = tbl.GetIntVal(24, 1);
            QLinesMaxDefined = tbl.GetBoolVal(25, 1); 
            QLinesMax = tbl.GetIntVal(26, 1);
            QColumnsMinDefined = tbl.GetBoolVal(27, 1); //  rows[23 - 1] = new DataCellRowCoHeader(new DataCell("MinQColumnsDefined"), new DataCellRow(new DataCell(QColumnsMinDefined)));
            QColumnsMin = tbl.GetIntVal(28, 1);
            QColumnsMaxDefined = tbl.GetBoolVal(29, 1);
            QColumnsMax = tbl.GetIntVal(30, 1); 
        }
        //
        public bool GetIf_LinesCanAdd(int QLines)
        {
            return (this.LinesCanAdd && (QLines < MyLib.MaxInt) && (this.QLinesMaxDefined == false || QLines < this.QLinesMax));
        }
        public bool GetIf_ColumnsCanAdd(int QColumns)
        {
            return (this.ColumnsCanAdd && (QColumns < MyLib.MaxInt) && (this.QColumnsMaxDefined == false || QColumns < this.QColumnsMax));
        }
        public bool GetIf_BothLinesAndColumnsCanAdd(int QLines, int QColumns)
        {
            bool TheLinesCanAdd = GetIf_LinesCanAdd(QLines), TheColumnsCanAdd = GetIf_ColumnsCanAdd(QColumns);
            return (this.BothCanAdd && TheLinesCanAdd && TheColumnsCanAdd);
        }
        public bool GetIf_LinesCanIns(int QLines)
        {
            return (this.LinesCanIns && (QLines < MyLib.MaxInt) && (this.QLinesMaxDefined == false || QLines < this.QLinesMax));
        }
        public bool GetIf_ColumnsCanIns(int QColumns)
        {
            return (this.ColumnsCanIns && (QColumns < MyLib.MaxInt) && (this.QColumnsMaxDefined == false || QColumns < this.QColumnsMax));
        }
        public bool GetIf_BothLinesAndColumnsCanIns(int QLines, int QColumns)
        {
            bool TheLinesCanIns = GetIf_LinesCanIns(QLines), TheColumnsCanIns = GetIf_ColumnsCanIns(QColumns);
            return (this.BothCanIns && TheLinesCanIns && TheColumnsCanIns);
        }
        public bool GetIf_LinesCanDel(int QLines)
        {
            return (this.LinesCanDel && (QLines > 1) && (this.QLinesMinDefined == false || QLines > this.QLinesMin));
        }
        public bool GetIf_ColumnsCanDel(int QColumns)
        {
            return (this.ColumnsCanDel && (QColumns > 1) && (this.QColumnsMinDefined == false || QColumns > this.QColumnsMin));
        }
        public bool GetIf_BothLinesAndColumnsCanDel(int QLines, int QColumns)
        {
            bool TheLinesCanDel = GetIf_LinesCanDel(QLines), TheColumnsCanDel = GetIf_ColumnsCanDel(QColumns);
            return (this.BothCanDel && TheLinesCanDel && TheColumnsCanDel);
        }
    }//cl 16 TableUssagePolicy
    public class TTablesConcatRules
    {
        public int DirectAdd_Vert1Hor2VertTransp3Smart4;
        //If Smart
        //Simple Vrns
        public int SmartSimple_NotSimple0_Max_CellsNamesDiffAddSameIgnore1_Sel_ColsNamesDiffAddLinesAdd2;
        //If not Simple
        public int LinesDefferBy_N0Name1, ColsDifferBy_N0Name1;
        public int LinesElabRules_Add0DependsOnCompar1, ColsElabRules_Add0DependsOnCompar1;
        public int LinesDifferent_Ignore0Add1, LinesSame_Ignore0Replace1, ColsDifferent_Ignore0Add1, ColsSame_Ignore0Replace1;
        //
        public TTablesConcatRules()
        {
            DirectAdd_Vert1Hor2VertTransp3Smart4 = 4;
            //If Smart
            //Simple Vrns
            SmartSimple_NotSimple0_Max_CellsNamesDiffAddSameIgnore1_Sel_ColsNamesDiffAddLinesAdd2 = 2;
            //If not Simple
            LinesDefferBy_N0Name1 = 0;
            ColsDifferBy_N0Name1 = 1;
            //
            LinesElabRules_Add0DependsOnCompar1 = 1;
            ColsElabRules_Add0DependsOnCompar1 = 1;
            //
            LinesDifferent_Ignore0Add1 = 1;
            LinesSame_Ignore0Replace1 = 0;
            ColsDifferent_Ignore0Add1 = 1;
            ColsSame_Ignore0Replace1 = 0;
        }
        //
        void SetDefault()
        {
            SetConcatSmartSimpleSelectiveForDBColsAddNewNamesLinesAddAll();
        }
        //
        void SetConcatSimpleVert()
        {
            DirectAdd_Vert1Hor2VertTransp3Smart4 = 1;
            //If Smart
            //Simple Vrns
            SmartSimple_NotSimple0_Max_CellsNamesDiffAddSameIgnore1_Sel_ColsNamesDiffAddLinesAdd2 = 0; //no matter
            //If not Simple
            LinesDefferBy_N0Name1 = 0;
            ColsDifferBy_N0Name1 =0;
            //
            LinesElabRules_Add0DependsOnCompar1 = 0;
            ColsElabRules_Add0DependsOnCompar1 = 1;
            //
            LinesDifferent_Ignore0Add1 = 1;
            LinesSame_Ignore0Replace1 = 0;
            ColsDifferent_Ignore0Add1 = 0;
            ColsSame_Ignore0Replace1 = 0;
        }
        void SetConcatSimpleHor()
        {
            DirectAdd_Vert1Hor2VertTransp3Smart4 = 2;
            //If Smart
            //Simple Vrns
            SmartSimple_NotSimple0_Max_CellsNamesDiffAddSameIgnore1_Sel_ColsNamesDiffAddLinesAdd2 = 0; //no matter
            //If not Simple
            LinesDefferBy_N0Name1 =0;
            ColsDifferBy_N0Name1 = 0;
            //
            LinesElabRules_Add0DependsOnCompar1 = 0;
            ColsElabRules_Add0DependsOnCompar1 = 1;
            //
            LinesDifferent_Ignore0Add1 = 0;
            LinesSame_Ignore0Replace1 = 0;
            ColsDifferent_Ignore0Add1 = 1;
            ColsSame_Ignore0Replace1 = 0;
        }
        void SetConcatSimpleVertTransposed()
        {
            DirectAdd_Vert1Hor2VertTransp3Smart4 = 3;
            //If Smart
            //Simple Vrns
            SmartSimple_NotSimple0_Max_CellsNamesDiffAddSameIgnore1_Sel_ColsNamesDiffAddLinesAdd2 = 0; //no matter
            //If not Simple
            LinesDefferBy_N0Name1 = 0;
            ColsDifferBy_N0Name1 = 0;
            //
            LinesElabRules_Add0DependsOnCompar1 = 0;
            ColsElabRules_Add0DependsOnCompar1 = 1;
            //
            LinesDifferent_Ignore0Add1 = 0;
            LinesSame_Ignore0Replace1 = 0;
            ColsDifferent_Ignore0Add1 = 1;
            ColsSame_Ignore0Replace1 = 0;
        }
        
        void SetConcatSmartSimpleFullAddByNames()
        {
            DirectAdd_Vert1Hor2VertTransp3Smart4 = 4;
            //If Smart
            //Simple Vrns
            SmartSimple_NotSimple0_Max_CellsNamesDiffAddSameIgnore1_Sel_ColsNamesDiffAddLinesAdd2 = 1;
            //If not Simple
            LinesDefferBy_N0Name1 = 1;
            ColsDifferBy_N0Name1 = 1;
            //
            LinesElabRules_Add0DependsOnCompar1 = 1;
            ColsElabRules_Add0DependsOnCompar1 = 1;
            //
            LinesDifferent_Ignore0Add1 = 1;
            LinesSame_Ignore0Replace1 = 0;
            ColsDifferent_Ignore0Add1 = 1;
            ColsSame_Ignore0Replace1 = 0;
        }
        void SetConcatSmartSimpleSelectiveForDBColsAddNewNamesLinesAddAll()
        {
            DirectAdd_Vert1Hor2VertTransp3Smart4 = 4;
            //If Smart
            //Simple Vrns
            SmartSimple_NotSimple0_Max_CellsNamesDiffAddSameIgnore1_Sel_ColsNamesDiffAddLinesAdd2 = 2;
            //If not Simple
            LinesDefferBy_N0Name1 = 1;
            ColsDifferBy_N0Name1 = 1;
            //
            LinesElabRules_Add0DependsOnCompar1 = 1;
            ColsElabRules_Add0DependsOnCompar1 = 1;
            //
            LinesDifferent_Ignore0Add1 = 1;
            LinesSame_Ignore0Replace1 = 0;
            ColsDifferent_Ignore0Add1 = 0;
            ColsSame_Ignore0Replace1 = 0;
        }
        public TTable GetAsTable()
        {
            //TTable T=null;
            //string[] arrRowsGen, arrRowsNew, arrRowsOld, arrRowNs, arrNames;
            //arrRowsGen = new string[2];
            //arrRowsNew = new string[2];
            //arrRowsOld = new string[2];
            //arrRowNs = new string[2];
            //arrNames = new string[4];
            //arrRowsGen[1 - 1] = "Add"; arrRowsGen[1 - 1] = "Depends on Comparison";
            //arrRowNs[1 - 1] = "By Numbers"; arrRowNs[1 - 1] = "By Names";
            //arrRowsNew[1 - 1] = "Ignore"; arrRowsNew[2 - 1] = "Add";
            //arrRowsOld[1 - 1] = "Ignore"; arrRowsOld[2 - 1] = "Replace";
            TTable T = new TTable(
                new TableInfo(true, true, true, 4, 2),
                false,
                new DataCellRow[]{ 
                    new DataCellRow( new DataCell[]{new DataCell(new string[]{"By Numbers","By Names"},2), new DataCell(new string[]{"By Numbers","By Names"},2) }, 2),
                    new DataCellRow( new DataCell[]{new DataCell(new string[]{"Add","Depends on Comparison"},2), new DataCell(new string[]{"Add","Depends on Comparison"},2) }, 2),
                    new DataCellRow( new DataCell[]{new DataCell(new string[]{"Ignore","Add"},2), new DataCell(new string[]{"Ignore","Add"},2) }, 2),
                    new DataCellRow( new DataCell[]{new DataCell(new string[]{"Ignore","Replace"},2), new DataCell(new string[]{"Ignore","Replace"},2) }, 2)
                },
                new DataCellRow(new DataCell[] { new DataCell("Lines"), new DataCell("Columns") }, 2),
                new DataCellRow(new DataCell[] { new DataCell("Rows Differ By"), new DataCell("Rows Elaboration Rules"), new DataCell("New(absent) Rows"), new DataCell("Old(present) Rows") }, 4),
                new TableHeaders(new DataCell("Tables Concatenation Rules"), new DataCell("Rows"), new DataCell("Params")),
                true
            );
            return T;
        }//fn
    }//cl
}//ns   //2020-08-12
