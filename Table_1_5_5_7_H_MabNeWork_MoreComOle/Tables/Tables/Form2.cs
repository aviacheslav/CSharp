using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
//mark1 - 884
//mark2 - 1191
//mark3 - reserved
//fin - 3009
//
namespace Tables
{
    public partial class TableForm : Form
    {
        //int Mode_
        //public TTable TablUsePol, TablGenRepr, TableCntCellRepr, TablLinHdrCellRepr, TablColHdrCellRepr, TablColHdrOfCntCellRepr, TablLinHdrOfCntCellRepr;
        public TTable TargetTable, TableOfSettings;
        TTable CurrentTable, BufferTable;
        public TableFormAndGridConfigurationMain FormCfgMain;
        public TableReadingTypesParams GridReadParams;//new
        public CellsNsToDisplay NsToDisplay;
        public TableRepresentation Repr;
        public TableInfo TblInf;
        GridParamsCalculated GridParamsCalcd;
        int ActiveN, TypeN, Length;
        int tLineN, tColN, gLineN, gColN;
        bool WriteInfoToCopy = false;//
        //DataGridViewCell[][] CellVirtualCopy;
        //string[] LoCH, CoLH;
        bool CoLHHasContent, LoCHHasContent;
        //
        int ArrowsPurposeN;
        //
        Form_TableCalling f1;
        //Form f1;
        TableForm f2;
        public TableDataChange DataTopic;
        //
        public TableForm()
        {
            Constructor();
            f1 = null;
        }
        public TableForm(Form1 f1)
        {
            Constructor();
            this.f1 = f1;
        }
        public TableForm(/*Form1*/Form_TableCalling f1, TTable tblExt, TableDataChange data, TableFormAndGridConfigurationMain FormAndGridCellCfgMainExt = null, TableReadingTypesParams GridReadParams = null, CellsNsToDisplay NsToDisplayExt = null, TableInfo TblInfExt = null)
        {
            Constructor();
            this.f1 = f1;
            AcceptTable(tblExt, data, FormAndGridCellCfgMainExt, GridReadParams, NsToDisplayExt, TblInfExt);
        }
        public TableForm(TableForm f2)
        {
            Constructor();
            this.f2 = f2;
        }
        public void Constructor()
        {
            TargetTable = null;
            BufferTable = null;
            CurrentTable = new TTable();
            GridParamsCalcd = null;
            //
            //TablGenRepr = null; TableCntCellRepr = null; TablLinHdrCellRepr = null; TablColHdrCellRepr = null; TablColHdrOfCntCellRepr = null; TablLinHdrOfCntCellRepr = null;
            //
            TblInf = null;
            FormCfgMain = null;
            NsToDisplay = null;
            Repr = null;
            ActiveN = 1;
            //cfg = null;
            //
            //CellVirtualCopy = null;
            //LoCH = null; CoLH = null;
            //
            //this.comboBox_ContentItem = new ComboBox();
            //this.comboBox_ContentItem.Items.Clear();
            //this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_ContentCell);
            //this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_LineOfColHeaderCell);
            //this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_ColOfLineHeaderCell);
            //this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_LinesGenName);
            //this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_ColsGenName);
            //this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_TableName);
            //
            InitializeComponent();
            //
            this.comboBox_ContentItem.Items.Clear();
            this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_ContentCell);
            this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_LineOfColHeaderCell);
            this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_ColOfLineHeaderCell);
            this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_LinesGenName);
            this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_ColsGenName);
            this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_TableName);
            //
            this.comboBox_ContentItem.SelectedItem = this.comboBox_ContentItem.Items[0];
            //
            ArrowsPurposeN = 1;
            //
            this.comboBox_ArrowsFns.Items.Clear();
            this.comboBox_ArrowsFns.Items.Add(TableConsts.GuiArrows_StringLine_MoveFocus);
            this.comboBox_ArrowsFns.Items.Add(TableConsts.GuiArrows_StringLine_CompressShownAreaHideRows);
            this.comboBox_ArrowsFns.Items.Add(TableConsts.GuiArrows_StringLine_ExpandShownAreaShowRows);
            this.comboBox_ArrowsFns.Items.Add(TableConsts.GuiArrows_StringLine_ShiftShowRows);
            this.comboBox_ArrowsFns.Items.Add(TableConsts.GuiArrows_StringLine_MoveExchangingRows);
            this.comboBox_ArrowsFns.Items.Add(TableConsts.GuiArrows_StringLine_MoveExchangingCells);
            this.comboBox_ArrowsFns.Items.Add(TableConsts.GuiArrows_StringLine_InsOrAddRows);
            this.comboBox_ArrowsFns.Items.Add(TableConsts.GuiArrows_StringLine_DelRow);
            this.comboBox_ArrowsFns.Items.Add(TableConsts.GuiArrows_StringLine_MoveText);
            this.comboBox_ArrowsFns.Items.Add(TableConsts.GuiArrows_StringLine_CompressText);
            this.comboBox_ArrowsFns.Items.Add(TableConsts.GuiArrow_StringLines_ExpandText);
            this.comboBox_ArrowsFns.Items.Add(TableConsts.GuiArrows_StringLine_MoveTextCursor);
            
            this.comboBox_ArrowsFns.SelectedIndex = ArrowsPurposeN - 1;
            this.ArrowsPurposeN = this.comboBox_ArrowsFns.SelectedIndex + 1;
            //if (ArrowsPurposeN == 5 || ArrowsPurposeN == 8)
            if (ArrowsPurposeN == TableConsts.GuiArrows_PurposeN_CompressShownAreaHideRows)
            {
                button_ArrowDown.Text = "^";
                button_ArrowUp.Text = "v";
                button_ArrowLeft.Text = ">";
                button_ArrowRight.Text = "<";
            }
            else
            {
                button_ArrowDown.Text = "v";
                button_ArrowUp.Text = "^";
                button_ArrowLeft.Text = "<";
                button_ArrowRight.Text = ">";
            }
            //if(ArrowsPurposeN == 1 || ArrowsPurposeN == 9)
            if (ArrowsPurposeN == TableConsts.GuiArrows_PurposeN_MoveFocus || ArrowsPurposeN == TableConsts.GuiArrows_PurposeN_MoveTextCursor || ArrowsPurposeN == TableConsts.GuiArrows_PurposeN_InsOrAddRows)
            {
                button_ArrowHome.Enabled = true;
                button_ArrowEnd.Enabled = true;
                button_ArrowToTheTop.Enabled = true;
                button_ArrowToBottom.Enabled = true;
            }
            else
            {
                button_ArrowHome.Enabled = false;
                button_ArrowEnd.Enabled = false;
                button_ArrowToTheTop.Enabled = false;
                button_ArrowToBottom.Enabled = false;
            }
            //switch (ArrowFor_ChangeCurCell1MoveRow2MoveCell3ExpandRows4CompressRows5MoveText6ExpandText7CompressText8MoveCursor9)
            //{
            //    case 1:
            //        this.comboBox_ArrowsFns.SelectedIndex = ArrowFor_ChangeCurCell1MoveRow2MoveCell3ExpandRows4CompressRows5MoveText6ExpandText7CompressText8MoveCursor9 - 1;
            //        break;
            //    case 2:

            //        break;
            //    case 3:

            //        break;
            //    case 4:

            //        break;
            //    case 5:

            //        break;
            //    case 6:

            //        break;
            //    case 7:

            //        break;
            //    case 8:

            //        break;
            //    case 9:
                    
            //        break;
            //}
            //
            //ChangesMade = false; //if exists, here is needed
        }
        /*public void AcceptTable(TTable tblExt, int ArrOrBool_Simple0CentralLbox1CBoxJaLBoxNo2CboxNoLBoxJa3CBoxJaLBoxJa4 = 1, TableInfo TblInfExt = null)
        {
            CurrentTable = tblExt;
        }*/
        public void SetSettingsDataByTable(int SettingsN)
        {
            //f2.TableOfSettings = this.CurrentTable.ReturnCopyOrPart();
            //
            if (TblInf == null) TblInf = new TableInfo();
            switch (SettingsN)
            {
                //case TableConsts.SettingsTable_Repr_TableGen_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.GenRepr == null) TblInf.Repr.GenRepr = new TableGeneralRepresentation();
                //    //
                //    TblInf.Repr.GenRepr.SetFromTable(this.TableOfSettings);
                //    //
                //    break;
                case TableConsts.SettingsTable_Repr_TableGen_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    TblInf.Repr_Text.SetGeneralRepresentationFromTable(this.TableOfSettings);
                break;
                case TableConsts.SettingsTable_Repr_TableGen_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    TblInf.Repr_Grid.SetGeneralRepresentationFromTable(this.TableOfSettings);
                break;
                //case TableConsts.SettingsTable_Repr_TableGen_Text_DataN:
                //    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                //    if (TblInf.Repr_Text.GenRepr == null) TblInf.Repr_Text.GenRepr = new TableGeneralRepresentation();
                //    //
                //    TblInf.Repr_Text.GenRepr.SetFromTable(this.TableOfSettings);
                //    //
                //    break;
                case TableConsts.SettingsTable_Repr_ColOfLineHeader_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    TblInf.Repr_Text.SetLineHeaderReprFromTable(this.TableOfSettings);
                break;
                case TableConsts.SettingsTable_Repr_ColOfLineHeader_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    TblInf.Repr_Grid.SetLineHeaderReprFromTable(this.TableOfSettings);
                break;
                //case TableConsts.SettingsTable_Repr_ColOfLinelHeader_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.ColHeaderRepr == null) TblInf.Repr.ColHeaderRepr = new TableHeaderCellRepresentation();
                //    //
                //    TblInf.Repr.ColHeaderRepr.SetFromTable(this.TableOfSettings);
                //    //
                //    break;
                case TableConsts.SettingsTable_Repr_LineOfColHeader_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    TblInf.Repr_Text.SetColHeaderReprFromTable(this.TableOfSettings);
                break;
                case TableConsts.SettingsTable_Repr_LineOfColHeader_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    TblInf.Repr_Grid.SetColHeaderReprFromTable(this.TableOfSettings);
                break;
                //case TableConsts.SettingsTable_Repr_LineOfColHeader_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.LineHeaderRepr == null) TblInf.Repr.LineHeaderRepr = new TableHeaderCellRepresentation();
                //    //
                //    TblInf.Repr.LineHeaderRepr.SetFromTable(this.TableOfSettings);
                //    //
                //    break;
                case TableConsts.SettingsTable_Repr_ContentCell_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    TblInf.Repr_Text.SetContentReprMainPartFromTable(this.TableOfSettings);
                break;
                case TableConsts.SettingsTable_Repr_ContentCell_Grid_DataN://TableConsts.SettingsTable_Repr_ContentCellHeader_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    TblInf.Repr_Grid.SetContentReprMainPartFromTable(this.TableOfSettings);
                break;
                //case TableConsts.SettingsTable_Repr_ContentCellHeader_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.ContentRepr == null) TblInf.Repr.ContentRepr = new TableContentCellRepresentation();
                //    //
                //    TblInf.Repr.ContentRepr.SetMainPartFromTable(this.TableOfSettings);
                //    //
                //    break;
                case TableConsts.SettingsTable_Repr_LineOfColHeader_OfContentCell_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    TblInf.Repr_Grid.SetColHeaderReprOfContentCellFromTable(this.TableOfSettings);
                break;
                case TableConsts.SettingsTable_Repr_LineOfColHeader_OfContentCell_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    TblInf.Repr_Grid.SetColHeaderReprOfContentCellFromTable(this.TableOfSettings);
                break;
                //case TableConsts.SettingsTable_Repr_LineOfColHeader_OfContentCell_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.ContentRepr == null) TblInf.Repr.ContentRepr = new TableContentCellRepresentation();
                //    if (TblInf.Repr.ContentRepr.ColHeader == null) TblInf.Repr.ContentRepr.ColHeader = new TableHeaderCellRepresentation();
                //    //
                //    this.TableOfSettings = TblInf.Repr.ContentRepr.ColHeader.GetAsTable();
                //    break;
                case TableConsts.SettingsTable_Repr_ColOfLineHeader_OfContentCell_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    TblInf.Repr_Grid.SetLineHeaderReprOfContentCellFromTable(this.TableOfSettings);
                break;
                case TableConsts.SettingsTable_Repr_ColOfLineHeader_OfContentCell_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    TblInf.Repr_Grid.SetLineHeaderReprOfContentCellFromTable(this.TableOfSettings);
                break;
                //case TableConsts.SettingsTable_Repr_ColOfLinelHeader_OfContentCell_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.ContentRepr == null) TblInf.Repr.ContentRepr = new TableContentCellRepresentation();
                //    if (TblInf.Repr.ContentRepr.LineHeader == null) TblInf.Repr.ContentRepr.LineHeader = new TableHeaderCellRepresentation();
                //    //
                //    this.TableOfSettings = TblInf.Repr.ContentRepr.LineHeader.GetAsTable();
                //    //this.TableOfSettings.Set
                //    //
                //    //TableForm UniTbl=new TableForm();
                //    break;
                case TableConsts.SettingsTable_GridConfig_DataN://SettingsTable_Repr_TableForm_DataN:
                    if (this.FormCfgMain == null) this.FormCfgMain = new TableFormAndGridConfigurationMain();//impossible, ma le be
                    this.FormCfgMain.SetFromTable(this.TableOfSettings);
                break;
                //case TableConsts.SettingsTable_Repr_Grid_DataN:
                //    this.TableOfSettings = (TTable)f1.Tbl_FormAndGridConfig.Clone();
                //    break;
                case TableConsts.SettingsTable_UssagePolicy_DataN:
                    if (TblInf.UssagePolicy == null) TblInf.UssagePolicy = new TableUssagePolicy();
                    TblInf.UssagePolicy.SetFromTable(this.TableOfSettings);
                break;
            }
            //return tbl;
        }
        public void FillSettingsTable(int SettingsN)
        {   
            //TTable tbl=null;
            if(TblInf==null)TblInf=new TableInfo();
            switch(SettingsN){
                case TableConsts.SettingsTable_Repr_TableGen_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    this.TableOfSettings = TblInf.Repr_Text.GetGeneralRepresentationAsTable();
                    break;
                case TableConsts.SettingsTable_Repr_TableGen_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    this.TableOfSettings = TblInf.Repr_Grid.GetGeneralRepresentationAsTable();
                    break;
                //case TableConsts.SettingsTable_Repr_TableGen_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.GenRepr == null) TblInf.Repr.GenRepr = new TableGeneralRepresentation();
                //    //
                //    this.TableOfSettings = TblInf.Repr.GenRepr.GetAsTable();
                //    break;
                case TableConsts.SettingsTable_Repr_ColOfLineHeader_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    this.TableOfSettings = TblInf.Repr_Text.GetLineHeaderReprAsTable();
                    break;
                case TableConsts.SettingsTable_Repr_ColOfLineHeader_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    this.TableOfSettings = TblInf.Repr_Grid.GetLineHeaderReprAsTable();
                    break;
                //case TableConsts.SettingsTable_Repr_ColOfLinelHeader_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.ColHeaderRepr == null) TblInf.Repr.ColHeaderRepr = new TableHeaderCellRepresentation();
                //    //
                //    this.TableOfSettings = TblInf.Repr.ColHeaderRepr.GetAsTable();
                //    break;
                case TableConsts.SettingsTable_Repr_LineOfColHeader_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    this.TableOfSettings = TblInf.Repr_Text.GetColumnHeaderReprAsTable();
                    break;
                case TableConsts.SettingsTable_Repr_LineOfColHeader_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    this.TableOfSettings = TblInf.Repr_Grid.GetColumnHeaderReprAsTable();
                    break;
                //case TableConsts.SettingsTable_Repr_LineOfColHeader_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.LineHeaderRepr == null) TblInf.Repr.LineHeaderRepr = new TableHeaderCellRepresentation();
                //    //
                //    this.TableOfSettings = TblInf.Repr.LineHeaderRepr.GetAsTable();
                //    break;
                case TableConsts.SettingsTable_Repr_ContentCell_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    this.TableOfSettings = TblInf.Repr_Text.GetContentReprMainPartAsTable();
                    break;
                case TableConsts.SettingsTable_Repr_ContentCell_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    this.TableOfSettings = TblInf.Repr_Grid.GetContentReprMainPartAsTable();
                    break;
                case TableConsts.SettingsTable_Repr_LineOfColHeader_OfContentCell_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    this.TableOfSettings = TblInf.Repr_Text.GetColumnHeaderReprOfContentCellAsTable();
                    break;
                case TableConsts.SettingsTable_Repr_LineOfColHeader_OfContentCell_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    this.TableOfSettings = TblInf.Repr_Grid.GetColumnHeaderReprOfContentCellAsTable();
                    break;
                //case TableConsts.SettingsTable_Repr_LineOfColHeader_OfContentCell_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.ContentRepr == null) TblInf.Repr.ContentRepr = new TableContentCellRepresentation();
                //    if (TblInf.Repr.ContentRepr.ColHeader == null) TblInf.Repr.ContentRepr.ColHeader = new TableHeaderCellRepresentation();
                //    //
                //    this.TableOfSettings = TblInf.Repr.ContentRepr.ColHeader.GetAsTable();
                //    break;
                case TableConsts.SettingsTable_Repr_ColOfLineHeader_OfContentCell_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    this.TableOfSettings = TblInf.Repr_Text.GetLineHeaderReprOfContentCellAsTable();
                    break;
                case TableConsts.SettingsTable_Repr_ColOfLineHeader_OfContentCell_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    this.TableOfSettings = TblInf.Repr_Grid.GetLineHeaderReprOfContentCellAsTable();
                    break;
                //case TableConsts.SettingsTable_Repr_ColOfLinelHeader_OfContentCell_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.ContentRepr == null) TblInf.Repr.ContentRepr = new TableContentCellRepresentation();
                //    if (TblInf.Repr.ContentRepr.LineHeader == null) TblInf.Repr.ContentRepr.LineHeader = new TableHeaderCellRepresentation();
                //    //
                //    this.TableOfSettings = TblInf.Repr.ContentRepr.LineHeader.GetAsTable();
                //    break;
                case TableConsts.SettingsTable_UssagePolicy_DataN:
                    if(TblInf.UssagePolicy==null)TblInf.UssagePolicy=new TableUssagePolicy();
                    this.TableOfSettings=TblInf.UssagePolicy.GetAsTable();
                    break;
                case TableConsts.SettingsTable_GridConfig_DataN://SettingsTable_Repr_TableForm_DataN:
                    if(this.FormCfgMain==null) this.FormCfgMain=new TableFormAndGridConfigurationMain();//impossible, ma le be
                    this.TableOfSettings = this.FormCfgMain.GetAsTable();
                    break;
                //case TableConsts.SettingsTable_Repr_Grid_DataN:
                //    this.TableOfSettings=(TTable)f1.Tbl_FormAndGridConfig.Clone();
                //    break;
            }
            //return tbl;
        }
        /*
        public void SetSettingsFromTable(TTable tbl, int SettingsN)
        {
            //TTable tbl=null;
            if (TblInf == null) TblInf = new TableInfo();
            switch (SettingsN)
            {
                case TableConsts.SettingsTable_Repr_TableGen_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    TblInf.Repr_Text.GenRepr.SetFromTable(tbl);
                    break;
                case TableConsts.SettingsTable_Repr_TableGen_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    TblInf.Repr_Grid.GenRepr.SetFromTable(tbl);
                    break;
                //case TableConsts.SettingsTable_Repr_TableGen_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.GenRepr == null) TblInf.Repr.GenRepr = new TableGeneralRepresentation();
                //    //
                //    TblInf.Repr.GenRepr.SetFromTable(tbl);
                //    break;
                ////case TableConsts.SettingsTable_Repr_TableGen_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.GenRepr == null) TblInf.Repr.GenRepr = new TableGeneralRepresentation();
                //    //
                //    TblInf.Repr.GenRepr.SetFromTable(tbl);
                //    break;
                case TableConsts.SettingsTable_Repr_ColOfLineHeader_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    TblInf.Repr_Text.ColHeaderRepr.SetFromTable(tbl);
                    break;
                case TableConsts.SettingsTable_Repr_ColOfLineHeader_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    TblInf.Repr_Grid.ColHeaderRepr.SetFromTable(tbl);
                    break;
                //case TableConsts.SettingsTable_Repr_ColOfLinelHeader_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.ColHeaderRepr == null) TblInf.Repr.ColHeaderRepr = new TableHeaderCellRepresentation();
                //    //
                //    TblInf.Repr.ColHeaderRepr.SetFromTable(tbl);
                //    break;
                case TableConsts.SettingsTable_Repr_LineOfColHeader_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    TblInf.Repr_Text.LineHeaderRepr.SetFromTable(tbl);
                    break;
                case TableConsts.SettingsTable_Repr_LineOfColHeader_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    TblInf.Repr_Grid.LineHeaderRepr.SetFromTable(tbl);
                    break;
                case TableConsts.SettingsTable_Repr_ContentCell_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    TblInf.Repr_Text.ContentRepr.SetMainPartFromTable(tbl);
                    break;
                case TableConsts.SettingsTable_Repr_ContentCell_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    TblInf.Repr_Grid.ContentRepr.SetMainPartFromTable(tbl);
                    break;
                case TableConsts.SettingsTable_Repr_LineOfColHeader_OfContentCell_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    if (TblInf.Repr_Text.ContentRepr.ColHeader == null) TblInf.Repr_Text.ContentRepr.ColHeader = new TableHeaderCellRepresentation();
                    break;
                case TableConsts.SettingsTable_Repr_LineOfColHeader_OfContentCell_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    if (TblInf.Repr_Grid.ContentRepr == null) TblInf.Repr_Grid.ContentRepr = new TableContentCellRepresentation();
                    if (TblInf.Repr_Grid.ContentRepr.ColHeader == null) TblInf.Repr_Grid.ContentRepr.ColHeader = new TableHeaderCellRepresentation();
                    TblInf.Repr_Grid.ContentRepr.ColHeader.SetFromTable(tbl);
                    break;
                //case TableConsts.SettingsTable_Repr_LineOfColHeader_OfContentCell_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.ContentRepr == null) TblInf.Repr.ContentRepr = new TableContentCellRepresentation();
                //    if (TblInf.Repr.ContentRepr.ColHeader == null) TblInf.Repr.ContentRepr.ColHeader = new TableHeaderCellRepresentation();
                //    TblInf.Repr.ContentRepr.ColHeader.SetFromTable(tbl);
                //    break;
                case TableConsts.SettingsTable_Repr_ColOfLineHeader_OfContentCell_Text_DataN:
                    if (TblInf.Repr_Text == null) TblInf.Repr_Text = new TableRepresentation();
                    if (TblInf.Repr_Text.ContentRepr == null) TblInf.Repr_Text.ContentRepr = new TableContentCellRepresentation();
                    if (TblInf.Repr_Text.ContentRepr.LineHeader == null) TblInf.Repr_Text.ContentRepr.LineHeader = new TableHeaderCellRepresentation();
                    TblInf.Repr_Text.ContentRepr.LineHeader.SetFromTable(tbl);
                    break;
                case TableConsts.SettingsTable_Repr_ColOfLineHeader_OfContentCell_Grid_DataN:
                    if (TblInf.Repr_Grid == null) TblInf.Repr_Grid = new TableRepresentation();
                    if (TblInf.Repr_Grid.ContentRepr == null) TblInf.Repr_Grid.ContentRepr = new TableContentCellRepresentation();
                    if (TblInf.Repr_Grid.ContentRepr.LineHeader == null) TblInf.Repr_Grid.ContentRepr.LineHeader = new TableHeaderCellRepresentation();
                    TblInf.Repr_Grid.ContentRepr.LineHeader.SetFromTable(tbl);
                    break;
                //case TableConsts.SettingsTable_Repr_ColOfLinelHeader_OfContentCell_DataN:
                //    if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                //    if (TblInf.Repr.ContentRepr == null) TblInf.Repr.ContentRepr = new TableContentCellRepresentation();
                //    if (TblInf.Repr.ContentRepr.LineHeader == null) TblInf.Repr.ContentRepr.LineHeader = new TableHeaderCellRepresentation();
                //    TblInf.Repr.ContentRepr.LineHeader.SetFromTable(tbl);
                //    break;
                case TableConsts.SettingsTable_UssagePolicy_DataN:
                    //if (TblInf.Repr == null) TblInf.Repr = new TableRepresentation();
                    if (TblInf.UssagePolicy == null) TblInf.UssagePolicy = new TableUssagePolicy();
                    TblInf.UssagePolicy.SetFromTable(tbl);
                    break;
                case TableConsts.SettingsTable_GridConfig_DataN:
                    if (this.FormCfgMain == null) this.FormCfgMain = new TableFormAndGridConfigurationMain();//impossible, ma le be
                    this.FormCfgMain.SetFromTable(tbl);
                    break;
                //case TableConsts.SettingsTable_Repr_Grid_DataN:
                //    this.FormCfgMain.SetFromTable(tbl);
                //    break;
            }
            //return tbl;
        }
        */
        public void SaveTableToMemory()
        {
            this.WriteInfoToCopy = TargetTable.GetIfInfoBlockExists();
            //TargetTable=CurrentTable;
            switch (FormCfgMain.ModeTbl_Gui0Inner1Target2)
            {
                case 0:
                    //TargetTable.SetFromGrid(dataGridView1);
                    //public TTable ReadFromGrid(DataGridView grid, TableHeaderRowsExistance GridHdrRowsUsedExt, TableStructure TblStr, TableSize QRowsNamesToDisplayExt, TableReadingTypesParams ContentTypesParamsExt, TableReadingTypesParams CoLHTypesParamsExt = null, TableReadingTypesParams LoCHTypesParamsExt = null, bool ToWrite = true)
                    //TargetTable.ReadFromGrid(dataGridView1, new TableHeaderRowsExistance(this.FormCfgMain.CoLHGridRowUsed, this.FormCfgMain.LoCHGridRowUsed), this.TblInf.Str, new TableSize(this.NsToDisplay.QRowsNamesToDisplay.QLines, this.NsToDisplay.QRowsNamesToDisplay.QColumns), this.f1.GridReadParams, null, null, TargetTable.GetIfInfoBlockExists());
                    //if(f1!=null){
                    TargetTable = TargetTable.ReadFromGrid(dataGridView1, new TableHeaderRowsExistance(this.FormCfgMain.CoLHGridRowUsed, this.FormCfgMain.LoCHGridRowUsed), this.TblInf.Str, new TableSize(this.NsToDisplay.QRowsNamesToDisplay.QLines, this.NsToDisplay.QRowsNamesToDisplay.QColumns), this.f1.GridReadParams, null, null, TargetTable.GetIfInfoBlockExists());
                    //}else if(f2!=null){
                    //
                    //}
                    break;
                case 1:
                    TargetTable = CurrentTable.ReturnCopyOrPart(NsToDisplay.GetCellsNsToDisplayShort(), TblInf, WriteInfoToCopy);//new
                    break;
                case 2:
                    //NOp; //qso?
                    break;
            }
            //ChangesMade = true; //if exists, here is needed
            if (f1 != null)
            {
                f1.CurrentTable = TargetTable.ReturnCopyOrPart(null, this.TblInf, CurrentTable.GetIfInfoBlockExists());
                f1.SetDataFromCurrentTable(DataTopic/*, ActiveRowsNs*/);
            }
            else if (f2 != null)
            {
                //f2.SetSettingsFromTable(this.TargetTable, this.DataTopic.DataN);
                f2.TableOfSettings = this.CurrentTable.ReturnCopyOrPart();
                f2.SetSettingsDataByTable(this.DataTopic.DataN);
                //f2.FillSettingsTable(this.DataTopic.DataN);
            }
        }
        public void SaveTableToMemory(ref TTable tblExt)
        {
            tblExt = CurrentTable;
        }
        //public void ShowTable(TableFormAndGridConfigurationMain FormGridCfgMainExt = null, CellsNsToDisplay CellNsToDisplExt = null, TableInfo TblInfExt = null)
        //{
        //    CurrentTable.ToGrid(dataGridView1, FormGridCfgMainExt, CellNsToDisplExt, TblInfExt, null);
        //    DataCell NameCell = null;
        //    string TableName = "";
        //    NameCell = CurrentTable.GetTableNameCell();
        //    if (NameCell != null) TableName = NameCell.ToString();
        //    this.Text = TableName;
        //}
        public void ShowTable(/*TableFormAndGridConfigurationAll FormCfgMainExt = null*/TableFormAndGridConfigurationMain FormGridCfgMainExt = null, CellsNsToDisplay CellNsToDisplExt = null,  TableInfo TblInfExt = null)
        //
        {
            //hic fn = ToGrid + must be fn ShowControlsAccordingToUssagePolicy.
            //hic fn s' nur uz 1 et 2. Uz 0 (GUI) - it is alw in grid, fn Show s'ne not'd
            //If 0 tif NOp, (table is already present in grid). If 2 tif link is also CurrentTable
            //
            //CurrentTable.ToGrid(dataGridView1, FormGridCfgMainExt, CellNsToDisplExt, TblInfExt, null);
            //
            //TableFormAndGridConfigurationAll FormCfgIne = null;
            DataCell NameCell = null;
            TableFormAndGridConfigurationMain FormGridCfgMainIne = null;
            CellsNsToDisplay CellNsToDisplIne = null;
            TableInfo TblInfIne=null;
            //TableRepresentation ReprIne=null;
            string TableName="";
            ////
            //
            NameCell = CurrentTable.GetTableNameCell();
            if (NameCell != null) TableName = NameCell.ToString();
            this.Text = TableName;
            ////
            TblInfIne = CurrentTable.Choose_TableInfo_StrSizeReprUse_ByExtAndInner(TblInfExt);
            TblInfIne = CurrentTable.Choose_TableInfo_StrSizeReprUse_ByExtAndInner(this.TblInf);
            ////
            if (FormGridCfgMainExt != null) FormGridCfgMainIne = FormGridCfgMainExt;
            else FormGridCfgMainIne = this.FormCfgMain;
            if (FormGridCfgMainIne == null) FormGridCfgMainIne = new TableFormAndGridConfigurationMain();
            //
            if (CellNsToDisplExt != null) CellNsToDisplIne = CellNsToDisplExt;
            else CellNsToDisplIne = this.NsToDisplay;
            if (CellNsToDisplIne == null) CellNsToDisplIne = new CellsNsToDisplay();
            CellNsToDisplIne.Correct(TblInfIne.GetSize());
            //
            //it is nesessary to change it. This fn ne needs params
            // must be choice between params of form and of inner table info
            // and must be fn to write info to table - or user ms abl ne write to table, ma experimentieren in form, and write nur what liked
            //
            //
            CurrentTable.ToGrid(dataGridView1, FormGridCfgMainIne, CellNsToDisplIne, TblInfIne, null);
            //
            //if (FormCfgMainIne.ModeTbl_Gui0Inner1Target2 == 1 || FormCfgMainIne.ModeTbl_Gui0Inner1Target2 == 2)
            //{
                //
                //NameCell = CurrentTable.GetTableNameCell();
                //if (NameCell != null) TableName = NameCell.ToString();
                //this.Text=TableName;
                ////
                //TblInfIne = CurrentTable.Choose_TableInfo_StrSizeReprUse_ByExtAndInner(TblInfExt);
                ////
                //if (FormGridfgExt != null) FormCfgMainIne = FormGridfgExt;
                //else FormCfgMainIne = this.FormCfgMain;
                //if (FormCfgMainIne == null) FormCfgMainIne = new TableFormAndGridConfigurationMain();
                ////
                //if (CellNsToDisplExt != null) CellNsToDisplIne = CellNsToDisplExt;
                //else CellNsToDisplIne = this.NsToDisplay;
                //if (CellNsToDisplIne == null) CellNsToDisplIne = new CellsNsToDisplay();
                //CellNsToDisplIne.Correct(TblInfIne.GetSize());
                //
                //CurrentTable.ToGrid(dataGridView1, FormCfgMainIne, CellNsToDisplIne, null, null);
            //}//If 0 tif NOp, (table is already present in grid). If 2 tif link is also CurrentTable
            //
            int GLN, GCN;
            //
            if(this.Visible)ShowTableControlsAccordingToUssagePolicy();
            //ac if ne work't. Ob items o'Comvobox s'null. So it eium s'call'd  ef Shown event. Ma ef Shown event Visinle=false. So hic if s'solut o'hic probl
        }
        public void ShowTable()
        //
        {
            //hic fn = ToGrid + must be fn ShowControlsAccordingToUssagePolicy.
            //hic fn s' nur uz 1 et 2. Uz 0 (GUI) - it is alw in grid, fn Show s'ne not'd
            //If 0 tif NOp, (table is already present in grid). If 2 tif link is also CurrentTable
            //
            DataCell NameCell = null;
            //CellsNsToDisplay CellNsToDisplIne = null; //2021-06-17
            TableInfo TblInfIne = null;
            string TableName = "";
            ////
            //
            NameCell = CurrentTable.GetTableNameCell();
            if (NameCell != null) TableName = NameCell.ToString();
            this.Text = TableName;
            ////
            TblInfIne = CurrentTable.Choose_TableInfo_StrSizeReprUse_ByExtAndInner(this.TblInf);
            //
            // CellNsToDisplIne.Correct(TblInfIne.GetSize()); //2021-06-17
            this.NsToDisplay.Correct(TblInfIne.GetSize()); //2021-06-17
            //
            //it is nesessary to change it. This fn ne needs params
            // must be choice between params of form and of inner table info
            // and must be fn to write info to table - or user ms abl ne write to table, ma experimentieren in form, and write nur what liked
            //
            //
            CurrentTable.ToGrid(dataGridView1, this.FormCfgMain, this.NsToDisplay, TblInfIne, null);
            //
            int GLN, GCN;
            //
            if (this.Visible) ShowTableControlsAccordingToUssagePolicy();
            //ac if ne work't. Ob items o'Comvobox s'null. So it eium s'call'd  ef Shown event. Ma ef Shown event Visinle=false. So hic if s'solut o'hic probl
        }
        //public void AcceptTable(TTable tblExt, TableDataChange data, /*TableFormAndGridConfigurationGeneral cfgExt = null,*/ CellsNsToDisplay NsToDisplayExt=null, TableFormAndGridRepresentation FormCfgMainExt = null, TableInfo TblInfExt = null)
        public void AcceptTable(TTable tblExt, TableDataChange data, TableFormAndGridConfigurationMain FormAndGridCellCfgMainExt = null, TableReadingTypesParams GridReadParams=null, CellsNsToDisplay NsToDisplayExt = null, TableInfo TblInfExt = null)
        //public void AcceptTable(TTable tblExt, TableDataChange data, TableFormAndGridConfigurationAll cfgExt = null, TableInfo TblInfExt = null)
        {
            //bool WriteInfoToCopy = false;
            bool CreateInfoDefaultIfNull = true;
            //
            TblInf = tblExt.Choose_TableInfo_StrSizeReprUse_ByExtAndInner(TblInfExt, CreateInfoDefaultIfNull);
            //
            //if (cfgExt != null){
                //if (cfgExt.FormAndGridCellCfgMain != null)
            if (FormAndGridCellCfgMainExt != null)
                {
                    //this.FormCfgMain = cfgExt.FormAndGridCellCfgMain;
                    this.FormCfgMain = FormAndGridCellCfgMainExt;
                }
                else
                {
                    if (f1 != null)
                    {
                        if (f1.GetTableFormAndGridConfigurationMain() != null) this.FormCfgMain = f1.GetTableFormAndGridConfigurationMain();
                    }
                    else if (f2 != null)
                    {
                        if (f2.FormCfgMain != null)
                        {
                            this.FormCfgMain = f2.FormCfgMain;
                        }
                        else this.FormCfgMain = new TableFormAndGridConfigurationMain();
                    }
                    else this.FormCfgMain = new TableFormAndGridConfigurationMain();
                    if (this.FormCfgMain == null) this.FormCfgMain = new TableFormAndGridConfigurationMain(); //if ob s'assign'd in constr
                }
                //
                //if (cfgExt.CellNsToShow != null)
                if (NsToDisplayExt != null)
                {
                    //this.NsToDisplay = cfgExt.CellNsToShow;
                    this.NsToDisplay = NsToDisplayExt;
                }
                else
                {
                    if (this.NsToDisplay == null) this.NsToDisplay = new CellsNsToDisplay(TblInf.RowsQuantities);
                }
            //}
            //
                if (GridReadParams != null) this.GridReadParams = GridReadParams;
                else
                {
                    if (this.GridReadParams == null) this.GridReadParams = new TableReadingTypesParams();
                }
            //
            this.DataTopic = data;
            if (data == null) this.DataTopic = f1.GetTableDataChange();
            //vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
            TargetTable = tblExt;
            //^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
            if (GridParamsCalcd == null) GridParamsCalcd = new GridParamsCalculated(this.FormCfgMain, this.NsToDisplay, this.TblInf);
            switch (FormCfgMain.ModeTbl_Gui0Inner1Target2)
            {
                case 0:
                    CurrentTable = TargetTable;
                    //CurrentTable.ToGrid(dataGridView1, FormCfgMain, null/*NsToDisplay*/);
                    CurrentTable.ToGrid(dataGridView1, FormCfgMain, NsToDisplay);
                break;
                case 1:
                    //CurrentTable = TargetTable.ReturnCopyOrPart(NsToDisplay, TblInf, WriteInfoToCopy);//HERE - ERROR!
                    CurrentTable = TargetTable;
                    //
                    ShowTable(FormCfgMain, NsToDisplay, TblInf);
                break;
                case 2:
                    //CurrentTable = tblExt; //new
                    CurrentTable = TargetTable; //new
                    //tblExt.ToGrid(dataGridView1, NsToDisplay, FormCfgMain, GridReprSuppl/*.ArrOrBool_Simple0CentralLbox1CBoxJaLBoxNo2CboxNoLBoxJa3CBoxJaLBoxJa4*/);
                    CurrentTable.ToGrid(dataGridView1, FormCfgMain, NsToDisplay); //new
                    //cfg=cfgIne;
                break;
            }
            //ChangesMade = false; //if exists, here is needed
        }//fn
        public TableRepresentation GetTableRepresentationFromForm()
        {
            return this.TblInf.GetRepresentation_Grid();
        }
        public TableUssagePolicy GetTableUssagePolicyFromForm()
        {
            return this.TblInf.GetUssagePolicy();
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        /*private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }*/

        private void contentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /* string s="", sCH="", sLH="";
            int gLN, gCN;
            int ErstCntLineN, ErstCntColN, CntLineN, CntColN;
            gLN = dataGridView1.CurrentCell.RowIndex;
            gCN = dataGridView1.CurrentCell.ColumnIndex;
            s = dataGridView1.CurrentCell.Value.ToString();
            if (this.CurrentTable.GetIfLineOfColHeaderExists())
            {
                //sLH = this.CurrentTable.ToString_OfColOfLineHeader(LN);
            }
            if (this.CurrentTable.GetIfColOfLineHeaderExists())
            {
                //sCH= this.CurrentTable.ToString_OfLineOfColHeader(CN);
            }*/
            int gLN, gCN; ;// tLN, tCN;//lebe global, belonging to form class, 
            gLN = this.dataGridView1.CurrentCell.RowIndex;
            gCN = this.dataGridView1.CurrentCell.ColumnIndex;
            //tLineN = GridParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(gLN);
            //tColN = GridParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(gCN);
            tLineN = GridParamsCalcd.Calc_LineOrderNatNToDisplay_ByGridLineIndex(gLN);
            tColN = GridParamsCalcd.Calc_ColOrderNatNToDisplay_ByGridColIndex(gCN); 
            CurrentCellToCmdLineComboBox();
            //
            this.DataTopic.SelectedTableLineNatN = tLineN;
            this.DataTopic.SelectedTableColumnNatN = tColN;
            //
            //DataGridViewComboBoxCell CellComboBox;
            //string cur, sel;
            //int SN=0;
            //if (this.dataGridView1.CurrentCell is DataGridViewComboBoxCell)
            //{
            //    CellComboBox = (DataGridViewComboBoxCell)this.dataGridView1.CurrentCell;
            //    sel=CellComboBox.Value.ToString();
            //    for (int i = 1; i <= CellComboBox.Items.Count; i++)
            //    {
            //        cur = CellComboBox.Items[i - 1].ToString();
            //        if (cur.Equals(sel)) SN = i;
            //    }
            //    MessageBox.Show("ItemsQuantiry: " + CellComboBox.Items.Count + " CurText: " + sel+" CurN= "+SN.ToString());
            //}
        }

        /*private void button_Table_DiscardChanges_Click(object sender, EventArgs e)
        {
            ShowTable();
        }*/

        private void button_Table_Set_Click(object sender, EventArgs e)
        {
            SaveTableToMemory();
        }
        //
        public int fCurCntLineN()
        {
            int CurCntLineN = 0;
            int CurGridLineN = this.dataGridView1.CurrentCell.RowIndex;
            int CurGridLineNatN = CurGridLineN+1;
            int ErstCntLineN = this.NsToDisplay.NsToDispl.ErstLineN;
            CurCntLineN = CurGridLineNatN + ErstCntLineN - 1;
            return CurCntLineN;
        }
        public int fCurCntColumnN()
        {
            int CurCntColumnN = 0;
            int CurGridColumnN = this.dataGridView1.CurrentCell.RowIndex;
            int CurGridColumnNatN = CurGridColumnN + 1;
            int ErstCntColumnN = this.NsToDisplay.NsToDispl.ErstColumnN;
            CurCntColumnN = CurGridColumnNatN + ErstCntColumnN - 1;
            return CurCntColumnN;
        }
        //
        
        //public int GetCurGridLineN()
        //{
        //    return this.dataGridView1.CurrentCell.RowIndex;
        //}
        //public int GetCurGridColumnN()
        //{
        //    return this.dataGridView1.CurrentCell.ColumnIndex;
        //}
        public int GetCurTableContentLineN(){ //not finished
            int GridLineN = dataGridView1.CurrentCell.RowIndex;// GetCurGridLineN();
            int TableContentLineN = NsToDisplay.NsToDispl.ErstLineN + GridLineN;
            return TableContentLineN;
        }
        public int GetCurTableContentColumnN(){ //not finished
            int GridColumnN = dataGridView1.CurrentCell.ColumnIndex; //GetCurGridColumnN();
            int TableContentColumnN = NsToDisplay.NsToDispl.ErstColumnN + GridColumnN;
            return TableContentColumnN;
        }
        //
        public void ShowSettings(int SettingN)
        {
            FillSettingsTable(SettingN); 
            TableForm UniTblForm;
            TableDataChange data = null;
            //TableInfo TblInf;
            TableUssagePolicy UssagePolForSettingsTable=new TableUssagePolicy();
            UssagePolForSettingsTable.ForbidAll();
            UssagePolForSettingsTable.ForbidToShowAndEditSettings();
            if (this.TableOfSettings == null) this.TableOfSettings = new TTable();
            this.TableOfSettings.SetTableUssagePolicy(UssagePolForSettingsTable);
            //TableForm UsePolTabl=null;
            //CellsNsToDisplay NsToDisplay = null;
            //TableFormAndGridRepresentation cfg;
            if (this.TblInf.UssagePolicy.SettingsBrowsingIsAllowed)
            {
                FillSettingsTable(SettingN);
                UniTblForm = new TableForm(this);
                data = new TableDataChange();
                data.DataTopicN = 0; data.DataTypeIni1Fin2Medium3Cfg4 = 4; data.DataN = SettingN;
                //UniTblForm.AcceptTable(this.TableOfSettings, data, null, this.FormCfgMain, null);
                UniTblForm.AcceptTable(this.TableOfSettings, data, this.FormCfgMain, null, null, null);
                //                                                                   ReadGrid Ns Inf
                UniTblForm.Show();
            }
        }
        //
        /*void SetDataFromCurrentTable(int SettingsN){
            switch (SettingsN)
            {
                case 1: 
                    UsePolTabl.AcceptTable(this.TablUsePol, NsToDisplay, this.FormCfgMain, TblInf);
                break;
                case 2:
                    UsePolTabl.AcceptTable(this.TablGenRepr, NsToDisplay, this.FormCfgMain, TblInf);
                break;
                case 3:
                    UsePolTabl.AcceptTable(this.TablLinHdrCellRepr, NsToDisplay, this.FormCfgMain,TblInf);
                break;
                case 4:
                    UsePolTabl.AcceptTable(this.TablColHdrCellRepr, NsToDisplay, this.FormCfgMain, TblInf);
                break;
                case 5:
                    UsePolTabl.AcceptTable(this.TableCntCellRepr, NsToDisplay, this.FormCfgMain, TblInf);
                break;
                case 6:
                    UsePolTabl.AcceptTable(this.TablLinHdrOfCntCellRepr, NsToDisplay, this.FormCfgMain, TblInf);
                break;
                case 7:
                    UsePolTabl.AcceptTable(this.TablColHdrOfCntCellRepr, NsToDisplay, this.FormCfgMain, TblInf);
                break;
            }
        }*/
        //
        public void ShowCurrentCell()
        {
            switch (FormCfgMain.ModeTbl_Gui0Inner1Target2)
            {
                case 0:
                    //NOp;
                    break;
                case 1:
                    if (this.comboBox_ContentItem.Text == TableConsts.TableDataComponent_ContentCell)
                    {
                        //if(Cells usual )
                        this.dataGridView1.Rows[gLineN].Cells[gColN].Value = this.CurrentTable.ToString(tLineN, tColN);
                    }
                    if (this.comboBox_ContentItem.Text == TableConsts.TableDataComponent_LineOfColHeaderCell)
                    {
                        //this.dataGridView1.Columns.He
                    }
                    if (this.comboBox_ContentItem.Text == TableConsts.TableDataComponent_LineOfColHeaderCell)
                    {

                    }
                    break;
                case 2:

                    break;
            }
        }
        //mark1
        public void CurrentCellToCmdLineComboBox()
        //must be 3 vars: written, 
        {
            string txt="";
            //DataGridViewComboBoxCell combobox=null;
            string[] items = null;
            //int 
            TypeN = 0; 
            Length = 2;
            //, ActiveN; - //global
            //int tLineN, tColN, gLineN, gColN;//global
            DataCell cell = null;
            gLineN=this.dataGridView1.CurrentCell.RowIndex;
            gColN = this.dataGridView1.CurrentCell.ColumnIndex;
            //tLineN=NsToDisplay.NsToDispl.ErstLineN+gLineN;
            //tColN = NsToDisplay.NsToDispl.ErstColumnN+gColN;
            tLineN = this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineN);
            tColN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColN);
            //
            //tColN = NsToDisplay.NsToDispl.ErstColumnN + gColN; //ma b, ce s' spflu ob tLineN, tColN s' def'd both by click in GridClick fn
            //
            //if (this.dataGridView1.CurrentCell is System.Windows.Forms.DataGridViewComboBoxCell)
            //{
            //    MessageBox.Show("ComboBox");
            //}
            //else if (this.dataGridView1.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell)
            //{
            //    MessageBox.Show("CheckBox");
            //}
            //else
            //{
            //    MessageBox.Show("Usual cell");
            //}//works gut
            if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ContentCell)){
                if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1){
                    cell = this.CurrentTable.GetCell(tLineN, tColN, this.TblInf.GetTableInfo_ConcrRepr());
                }
                else if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2)
                {
                    cell = this.TargetTable.GetCell(tLineN, tColN, this.TblInf.GetTableInfo_ConcrRepr());
                }else{
                    cell=null;
                }
            }else if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_LineOfColHeaderCell)) {
                if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1)
                {
                    cell = this.CurrentTable.GetCell_LineOfColHeader(tColN);
                    if (cell == null) txt = "";
                    else txt = cell.ToString();
                }
                else if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2)
                {
                    cell = this.TargetTable.GetCell_LineOfColHeader(tColN);
                    if (cell == null) txt = "";
                    else txt = cell.ToString();
                }else{
                    cell=null;
                }
            }else if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ColOfLineHeaderCell)) {
                if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1)
                {
                    cell = this.CurrentTable.GetCell_ColOfLineHeader(tLineN);
                    if (cell == null) txt = "";
                    else txt = cell.ToString();
                }
                else if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2)
                {
                    cell = this.TargetTable.GetCell_ColOfLineHeader(tLineN);
                    if (cell == null) txt = "";
                    else txt = cell.ToString();
                }else{
                    cell=null;
                }
            }else if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_LinesGenName)){
                if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1)
                {
                    cell = CurrentTable.GetLinesGeneralNameCell();
                    if (cell == null) txt = "";
                    else txt = cell.ToString();
                }
                else if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2)
                {
                    cell = this.TargetTable.GetLinesGeneralNameCell();
                    if (cell == null) txt = "";
                    else txt = cell.ToString();
                 }else{
                    cell=null;
                 }
            }else if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ColsGenName)){
                if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1)
                {
                    cell = CurrentTable.GetColumnsGeneralNameCell();
                    if (cell == null) txt = "";
                    else txt = cell.ToString();
                }
                else if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2)
                {
                    cell = this.TargetTable.GetLinesGeneralNameCell();
                    if (cell == null) txt = "";
                    else txt = cell.ToString();
                 }else{
                    cell=null;
                 }
            }else if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_TableName)){
                if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1)
                {
                    cell = this.CurrentTable.GetTableHeader();
                    if (cell == null) txt = "";
                    else txt = cell.ToString();
                }
                else if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2)
                {
                    cell = this.TargetTable.GetTableHeader();
                    if (cell == null) txt = "";
                    else txt = cell.ToString();
                }else{
                    cell=null;
                }
            }else if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_LinesGenName_Scnd)){
                if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1)
                {
                    cell = CurrentTable.GetLinesGeneralHeader();
                    if (cell == null) txt = "";
                    else txt = cell.ToStringN(2);
                }
                else if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2)
                {
                    cell = this.TargetTable.GetLinesGeneralNameCell();
                    if (cell == null) txt = "";
                    else txt = cell.ToStringN(2);
                 }else{
                    cell=null;
                 }
            }else if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ColsGenName_Scnd)){
                if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1)
                {
                    cell = CurrentTable.GetColumnsGeneralNameCell();
                    if (cell == null) txt = "";
                    else txt = cell.ToStringN(2);
                }
                else if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2)
                {
                    cell = this.TargetTable.GetLinesGeneralNameCell();
                    if (cell == null) txt = "";
                    else txt = cell.ToStringN(2);
                 }else{
                    cell=null;
                 }
            }else if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_TableName_Scnd)){
                if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1)
                {
                    cell = this.CurrentTable.GetTableHeader();
                    if (cell == null) txt = "";
                    else txt = cell.ToString();
                }
                else if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2)
                {
                    cell = this.TargetTable.GetTableHeader();
                    if (cell == null) txt = "";
                    else txt = cell.ToString();
                }else{
                    cell=null;
                }
            }else if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_LineOfColHeaderCell_Scnd)) {
                if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1){
                    cell = this.CurrentTable.GetCell_LineOfColHeader(tColN);
                    if (cell == null) txt = "";
                    else txt = cell.ToStringN(2);
                } else if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2){
                    cell = this.TargetTable.GetCell_LineOfColHeader(tColN);
                    if (cell == null) txt = "";
                    else txt = cell.ToStringN(2);
                }else{
                    cell=null;
                }
            }else if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ColOfLineHeaderCell_Scnd)){
                if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1){
                    cell = this.CurrentTable.GetCell_ColOfLineHeader(tLineN);
                    if (cell == null) txt = "";
                    else txt = cell.ToStringN(2);
                } else if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2){
                    cell = this.TargetTable.GetCell_ColOfLineHeader(tLineN);
                    if (cell == null) txt = "";
                    else txt = cell.ToStringN(2);
                }else{
                    cell=null;
                }
            }
            //
            //if(FormCfgMain.UseCmdLineComboBox){}
            //
            if(FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1 || FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2 /*cell!=null*/){
                txt=cell.ToString();
                items=null;
                Length=1;
                TypeN=cell.GetTypeN();
                if(TableConsts.TypeNIsCorrectArray(TypeN)){
                    cell.GetStringArr(ref items, ref Length);
                }else if (TypeN == TableConsts.BoolTypeN){
                    if (FormCfgMain.BoolToCmdLine_ItemsNotSimple)
                    {
                        if (cell.GetBoolVal() == true) txt = TableConsts.TrueWord;
                        else txt = TableConsts.FalseWord;
                        items = new string[2];
                        if (MyLib.BoolValByDefault == true){
                            items[1 - 1] = TableConsts.TrueWord; items[2 - 1] = TableConsts.FalseWord;
                        }else{
                            items[1 - 1] = TableConsts.FalseWord; items[2 - 1] = TableConsts.TrueWord;
                        }
                    }//else NOp;
                }//else NOp;
            }else if(FormCfgMain.ModeTbl_Gui0Inner1Target2 == 0/*|| cell==null*/){
                if (this.dataGridView1.CurrentCell is System.Windows.Forms.DataGridViewComboBoxCell){
                    //MessageBox.Show("ComboBox");
                    Length = 0;
                    foreach(string item in ((DataGridViewComboBoxCell)this.dataGridView1.CurrentCell).Items){
                        Length++;
                        //items[Length - 1] = item;
                    }
                    items = new string[Length];
                    Length = 0;
                    foreach (string item in ((DataGridViewComboBoxCell)this.dataGridView1.CurrentCell).Items)
                    {
                        Length++;
                        items[Length - 1] = item;
                    }
                    txt = this.dataGridView1.CurrentCell.Value.ToString();
                }else if(this.dataGridView1.CurrentCell is System.Windows.Forms.DataGridViewCheckBoxCell){
                    //MessageBox.Show("CheckBox");
                    items = new string[2];
                    if (MyLib.BoolValByDefault == true)
                    {
                        items[1 - 1] = TableConsts.TrueWord ;  items[2 - 1] = TableConsts.FalseWord;
                        //if(((DataGridViewCheckBoxCell)this.dataGridView1.CurrentCell).)
                        if(((bool)this.dataGridView1.CurrentCell.Value)==true){
                            txt=TableConsts.TrueWord ;
                        }else if(((bool)this.dataGridView1.CurrentCell.Value)==false){
                            txt=TableConsts.FalseWord ;
                        }
                        //Length = 2;
                    }
                    else //(MyLib.BoolValByDefault == false)
                    {
                        items[1 - 1] = TableConsts.FalseWord ;  items[2 - 1] = TableConsts.TrueWord;
                        //if(((DataGridViewCheckBoxCell)this.dataGridView1.CurrentCell).)
                        if(((bool)this.dataGridView1.CurrentCell.Value)==true){
                            txt=TableConsts.TrueWord ;
                        }else if(((bool)this.dataGridView1.CurrentCell.Value)==false){
                            txt=TableConsts.FalseWord ;
                        }
                    }
                }else{ //usual type, non-array, non-bool
                    items=null;
                    txt=this.dataGridView1.CurrentCell.Value.ToString();
                }
            }//GUI or Table
            //
            this.textBox_Items.Text = "";
            //this.comboBox_CurContent.Items.Clear();
            this.comboBox_CurContent.Text=txt;
            if(FormCfgMain.UseCmdLineComboBox){
                if(FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1 || FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2 /*cell!=null*/){
                    if(TableConsts.TypeNIsCorrectArray(TypeN)){
                        //this.comboBox_CurContent.Text=txt;
                        if(FormCfgMain.ArrToCmdLine_ItemsNotSimple ){
                            if(items!=null){
                                for(int i=1; i<=Length; i++){
                                    //this.comboBox_CurContent.Items.Add(items[i-1]);
                                    if (i < Length)
                                    {
                                        this.textBox_Items.Text = this.textBox_Items.Text + items[i - 1] + "\n";
                                    }
                                    else
                                    {
                                        this.textBox_Items.Text = this.textBox_Items.Text + items[i - 1];
                                    }
                                    //this.comboBox_CurContent.Items.Add(items[i - 1]);
                                }
                            }
                        }
                    }else if(TypeN==TableConsts.BoolTypeN){
                        if(FormCfgMain.BoolToCmdLine_ItemsNotSimple){
                            if(items!=null){
                                ////for(int i=1; i<=Length; i++){
                                //for(int i=1; i<=2; i++){
                                //    this.comboBox_CurContent.Items.Add(items[i-1]);
                                //}
                                Length = 2;//why here?
                                for (int i = 1; i <= Length; i++)
                                {
                                    if (i < Length)
                                    {
                                        this.textBox_Items.Text = this.textBox_Items.Text + items[i - 1] + '\n';
                                    }
                                    else
                                    {
                                        this.textBox_Items.Text = this.textBox_Items.Text + items[i - 1];
                                    }
                                }
                            }
                        }//else
                    }//else  NOP
                }//which of Table Sources
            }//if(FormCfgMain.UseCmdLineComboBox)
        }//fn
        //mark1
        //
        public void SetCellValFromCmdLine()
        {
            int CurActiveN=0;
            string txt="";
            string[] items=null;
            string Corner1="", LinesGenName1="", ColumnsGenName1="", TableName1="";
            bool CorrectCorner=false;
            //int 
            Length = 0;
            //int tLineN, tColN, gLineN, gColN;
            //DataCell cell = null;
            gLineN = this.dataGridView1.CurrentCell.RowIndex;
            gColN = this.dataGridView1.CurrentCell.ColumnIndex;
            tLineN = this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineN); //NsToDisplay.NsToDispl.ErstLineN + gLineN;
            tColN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColN);//NsToDisplay.NsToDispl.ErstColumnN + gColN;
            txt = this.comboBox_CurContent.Text;
            if (this.comboBox_CurContent.Items != null)
            {
                //if()
                //foreach (string item in this.comboBox_CurContent.Items)
                //{
                //    Length++;
                //}
                Length = this.comboBox_CurContent.Items.Count;
                if (Length > 0)
                {
                    items = new string[Length];
                    Length = 0;
                    foreach (string item in this.comboBox_CurContent.Items)
                    {
                        Length++;
                        items[Length - 1] = item;
                        if (txt.Equals(items[Length - 1])) CurActiveN = Length;
                    }
                    if (CurActiveN == 0)
                    {
                        txt = items[ActiveN - 1];
                        this.comboBox_CurContent.Text = txt;
                    }
                    else ActiveN = CurActiveN;
                }else{ //Length=0;
                    txt = this.comboBox_CurContent.Text;
                    ActiveN = 1;
                }
            }
            //
            if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 1) {
                //
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ContentCell)){
                    if (TableConsts.TypeNIsCorrectArray(TypeN)){
                        this.CurrentTable.SetActiveN(tLineN, tColN, ActiveN);
                    }else if(TypeN==TableConsts.BoolTypeN){ //or may be this is superflu, 3rd vrn sat. LeBe uz hic vrn nur, uz rest LeBe ac spec bool
                        if (txt.Equals(TableConsts.TrueWord)) this.CurrentTable.SetByValBool(tLineN, tColN, true);
                        else if (txt.Equals(TableConsts.FalseWord)) this.CurrentTable.SetByValBool(tLineN, tColN, false);
                        else this.CurrentTable.SetByValBool(tLineN, tColN, MyLib.BoolValByDefault);
                    }else{
                        this.CurrentTable.SetByValString(tLineN, tColN, txt);
                    }
                    //ShowCurrentCell();
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_LineOfColHeaderCell)) {
                    if (TableConsts.TypeNIsCorrectArray(TypeN)){
                        //this.CurrentTable.SetActiveN(0, tColN, ActiveN);
                        this.CurrentTable.SetActiveN(0, tColN, ActiveN);
                    }else{
                        //this.CurrentTable.SetByValString_LineOfColHeader(tColN, txt);
                        this.CurrentTable.SetValN_LineOfColHeader(tColN, txt, 1);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ColOfLineHeaderCell))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN)){
                        //this.CurrentTable.SetActiveN(tLineN, 0, ActiveN);
                        this.CurrentTable.SetActiveN(tLineN, 0, ActiveN);
                    }else{
                        //this.CurrentTable.SetByValString_ColOfLineHeader(tLineN, txt);
                        this.CurrentTable.SetValN_ColOfLineHeader(tLineN, txt, 1);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_LinesGenName))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN)){
                        this.CurrentTable.SetLinesGeneralName1(this.comboBox_ContentItem.Text);
                    }else{
                        this.CurrentTable.SetLinesGeneralName1(this.comboBox_ContentItem.Text);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ColsGenName))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN)){
                        this.CurrentTable.SetColumnsGeneralName1(this.comboBox_ContentItem.Text);
                    }else{
                        this.CurrentTable.SetColumnsGeneralName1(this.comboBox_ContentItem.Text);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_TableName))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN)){
                        this.CurrentTable.SetTableName1(this.comboBox_ContentItem.Text);
                    }else{
                        this.CurrentTable.SetTableName1(this.comboBox_ContentItem.Text);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_LinesGenName_Scnd))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN)){
                        this.CurrentTable.SetLinesGeneralName2(this.comboBox_ContentItem.Text);
                    }else{
                        this.CurrentTable.SetLinesGeneralName2(this.comboBox_ContentItem.Text);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ColsGenName_Scnd))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN)){
                        this.CurrentTable.SetColumnsGeneralName2(this.comboBox_ContentItem.Text);
                    }else{
                        this.CurrentTable.SetColumnsGeneralName2(this.comboBox_ContentItem.Text);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_TableName_Scnd))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN)) {
                        this.CurrentTable.SetTableName2(this.comboBox_ContentItem.Text);
                    }else{
                        this.CurrentTable.SetTableName2(this.comboBox_ContentItem.Text);
                    }
                }
                
                //
                //ShowCurrentCell();
            }else if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 2) {
                //
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ContentCell))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN))
                    {
                        this.TargetTable.SetActiveN(tLineN, tColN, ActiveN);
                    }
                    else if (TypeN == TableConsts.BoolTypeN)
                    { //or may be this is superflu, 3rd vrn sat. LeBe uz hic vrn nur, uz rest LeBe ac spec bool
                        if (txt.Equals(TableConsts.TrueWord)) this.TargetTable.SetByValBool(tLineN, tColN, true);
                        else if (txt.Equals(TableConsts.FalseWord)) this.TargetTable.SetByValBool(tLineN, tColN, false);
                        else this.TargetTable.SetByValBool(tLineN, tColN, MyLib.BoolValByDefault);
                    }
                    else
                    {
                        this.TargetTable.SetByValString(tLineN, tColN, txt);
                    }
                    CurrentCellToCmdLineComboBox();
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_LineOfColHeaderCell))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN))
                    {
                        //this.TargetTable.SetActiveN(0, tColN, ActiveN);
                        this.TargetTable.SetActiveN(0, tColN, ActiveN);
                    }
                    else
                    {
                        //this.TargetTable.SetByValString_LineOfColHeader(tColN, txt);
                        this.TargetTable.SetValN_LineOfColHeader(tColN, txt, 1);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ColOfLineHeaderCell))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN))
                    {
                        //this.TargetTable.SetActiveN(tLineN, 0, ActiveN);
                        this.TargetTable.SetActiveN(tLineN, 0, ActiveN);
                    }
                    else
                    {
                        //this.TargetTable.SetByValString_ColOfLineHeader(tLineN, txt);
                        this.TargetTable.SetValN_ColOfLineHeader(tLineN, txt, 1);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_LinesGenName))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN))
                    {
                        this.TargetTable.SetLinesGeneralName1(this.comboBox_ContentItem.Text);
                    }
                    else
                    {
                        this.TargetTable.SetLinesGeneralName1(this.comboBox_ContentItem.Text);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ColsGenName))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN))
                    {
                        this.TargetTable.SetColumnsGeneralName1(this.comboBox_ContentItem.Text);
                    }
                    else
                    {
                        this.TargetTable.SetColumnsGeneralName1(this.comboBox_ContentItem.Text);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_TableName))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN))
                    {
                        this.TargetTable.SetTableName1(this.comboBox_ContentItem.Text);
                    }
                    else
                    {
                        this.TargetTable.SetTableName1(this.comboBox_ContentItem.Text);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_LinesGenName_Scnd))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN))
                    {
                        this.TargetTable.SetLinesGeneralName2(this.comboBox_ContentItem.Text);
                    }
                    else
                    {
                        this.TargetTable.SetLinesGeneralName2(this.comboBox_ContentItem.Text);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ColsGenName_Scnd))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN))
                    {
                        this.TargetTable.SetColumnsGeneralName2(this.comboBox_ContentItem.Text);
                    }
                    else
                    {
                        this.TargetTable.SetColumnsGeneralName2(this.comboBox_ContentItem.Text);
                    }
                }
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_TableName_Scnd))
                {
                    if (TableConsts.TypeNIsCorrectArray(TypeN))
                    {
                        this.TargetTable.SetTableName2(this.comboBox_ContentItem.Text);
                    }
                    else
                    {
                        this.TargetTable.SetTableName2(this.comboBox_ContentItem.Text);
                    }
                }
                //
                //ShowCurrentCell();
            }else if (FormCfgMain.ModeTbl_Gui0Inner1Target2 == 0) {
                //
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ContentCell)) {
                    if (this.dataGridView1.CurrentCell is DataGridViewComboBoxCell) {
                        ((DataGridViewComboBoxCell)this.dataGridView1.CurrentCell).Items.Clear();
                        for (int i = 1; i <= Length; i++){
                            ((DataGridViewComboBoxCell)this.dataGridView1.CurrentCell).Items.Add(items[i - 1]);
                        }
                        ((DataGridViewComboBoxCell)this.dataGridView1.CurrentCell).Value = txt;
                        //
                    }
                    else if (this.dataGridView1.CurrentCell is DataGridViewCheckBoxCell)
                    {
                        //
                        if ((this.comboBox_CurContent.Text).Equals(TableConsts.TrueWord)) {
                            this.dataGridView1.CurrentCell.Value = true;
                        }
                        else if ((this.comboBox_CurContent.Text).Equals(TableConsts.FalseWord))  {
                            this.dataGridView1.CurrentCell.Value = false;
                        }
                        else this.dataGridView1.CurrentCell.Value = MyLib.BoolValByDefault;
                        //
                    }
                    else
                    {
                        this.dataGridView1.CurrentCell.Value = txt;
                    }
                }//ContentCell
                //
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_LineOfColHeaderCell))
                {
                    this.dataGridView1.Columns[gColN - 1].HeaderCell.Value = txt;
                }//LineOfColHeader
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ColOfLineHeaderCell))
                {
                    this.dataGridView1.Rows[gLineN - 1].HeaderCell.Value = txt;
                }//ColOfLineHeader
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_LinesGenName))
                {
                    Corner1 = this.dataGridView1.TopLeftHeaderCell.Value.ToString();
                    MyLib.ParseNamesOfTableCorner(Corner1, ref CorrectCorner, ref LinesGenName1, ref ColumnsGenName1, ref TableName1);
                    LinesGenName1 = txt;
                    Corner1 = MyLib.ComposeTableCorner(LinesGenName1, ColumnsGenName1, TableName1);
                    this.dataGridView1.Rows[gLineN - 1].HeaderCell.Value = Corner1;
                }//LinesGenHeader
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_ColsGenName))
                {
                    Corner1 = this.dataGridView1.TopLeftHeaderCell.Value.ToString();
                    MyLib.ParseNamesOfTableCorner(Corner1, ref CorrectCorner, ref LinesGenName1, ref ColumnsGenName1, ref TableName1);
                    ColumnsGenName1 = txt;
                    Corner1 = MyLib.ComposeTableCorner(LinesGenName1, ColumnsGenName1, TableName1);
                    this.dataGridView1.Rows[gLineN - 1].HeaderCell.Value = Corner1;
                }//ColsGenHeader
                if (this.comboBox_ContentItem.Text.Equals(TableConsts.TableDataComponent_TableName))
                {
                    Corner1 = this.dataGridView1.TopLeftHeaderCell.Value.ToString();
                    MyLib.ParseNamesOfTableCorner(Corner1, ref CorrectCorner, ref LinesGenName1, ref ColumnsGenName1, ref TableName1);
                    TableName1 = txt;
                    Corner1 = MyLib.ComposeTableCorner(LinesGenName1, ColumnsGenName1, TableName1);
                    this.dataGridView1.Rows[gLineN - 1].HeaderCell.Value = Corner1;
                }//ColsGenHeader
            }
            CurrentCellToCmdLineComboBox();
        }//fn
        //
        //private void ussagePolicyToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ShowSettings(TableConsts.SettingsTable_UssagePolicy_DataN);
        //    //ShowSettings(1);
        //}
        //private void RepresentationGeneral_ToolStripMenuItem_Click_1(object sender, EventArgs e)
        //{
        //    ShowSettings(TableConsts.SettingsTable_Repr_TableGen_Grid_DataN);
        //}
        //private void contentCellReprToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ShowSettings(TableConsts.SettingsTable_Repr_ContentCell_Grid_DataN);
        //}
        //private void lineHeaderReprToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ShowSettings(TableConsts.SettingsTable_Repr_ColOfLineHeader_Grid_DataN);
        //}
        //private void colHeaderReprToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ShowSettings(TableConsts.SettingsTable_Repr_LineOfColHeader_Grid_DataN);
        //}
        //private void lHOfCntCellReprToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    ShowSettings(TableConsts.SettingsTable_Repr_ColOfLineHeader_OfContentCell_Grid_DataN);
        //}
        //private void cHOfCntCellReprToolStripMenuItem1_Click(object sender, EventArgs e)
        //{
        //    ShowSettings(TableConsts.SettingsTable_Repr_LineOfColHeader_OfContentCell_Grid_DataN);
        //}
        //
        
        //
        private void TableForm_Shown(object sender, EventArgs e)
        {
            this.comboBox_ContentItem.Text = TableConsts.TableDataComponent_ContentCell;
            /*this.comboBox_ContentItem.Items.Clear();
            //this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_ContentCell);
            //this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_LineOfColHeaderCell);
            //this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_ColOfLineHeaderCell);
            //this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_LinesGenName);
            //this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_ColsGenName);
           this.comboBox_ContentItem.Items.Add(TableConsts.TableDataComponent_TableName); */
            //
            //CurrentCellToCmdLineComboBox();//it works co ini data of polyEq, ma ne def't l'cur cell co solution - qob?
            ShowTableControlsAccordingToUssagePolicy();
        }
        private void button_GetValue_Click(object sender, EventArgs e)
        {
            CurrentCellToCmdLineComboBox();
        }
        private void button_SetValue_Click(object sender, EventArgs e)
        {
            SetCellValFromCmdLine();
            ShowTable();
        }
        
        private void button_Table_DiscardChanges_Click_1(object sender, EventArgs e)
        {
            switch (FormCfgMain.ModeTbl_Gui0Inner1Target2)
            {
                case 0:
                    //Nop;
                    break;
                case 1:
                    CurrentTable = TargetTable.ReturnCopyOrPart();
                    ShowTable(FormCfgMain, NsToDisplay, TblInf);
                    break;
                case 2:
                    //Nop;
                    break;
            }
            //ChangesMade = false;
        }//fn
        //
        //private void button_Table_Set_Click_1(object sender, EventArgs e)
        //{
        //    SaveTableToMemory();
        //}//fn
        //
        //
        private void SaveToCSV()
        {
            string FullName = "C:\\temp\\2.csv";
            string[][] ss = null;
            TableSize ArrSize = null, QRowsForHeaders = null;
            bool TableNotGridOnly, LoCHExists, CoLHExists;
            int ReprN_Grid0Text1 = 1;
            TableNotGridOnly = true;
            if (this.FormCfgMain.ModeTbl_Gui0Inner1Target2 == 0) TableNotGridOnly = false;
            if (!TableNotGridOnly)
            {
                //if (LoCHExists)
                //{
                //    if (CoLHExists)
                //    {

                //    }
                //    else
                //    {

                //    }
                //}
                //else
                //{
                //if (CoLHExists)
                //{

                //}
                //else
                //{

                //}
                //}//if LoCHExists
            }
            else
            {
                QRowsForHeaders = new TableSize();
                QRowsForHeaders.QLines = this.NsToDisplay.GetQLineHeaderNamesToShow();
                QRowsForHeaders.QColumns = this.NsToDisplay.GetQColumnHeaderNamesToShow();
                //this.CurrentTable.ToStringArray(ref ss, ref ArrSize, this.TblInf, QRowsForHeaders);
                TableInfo_ConcrRepr TblInf=new TableInfo_ConcrRepr();
                TblInf.Assign(this.TblInf.GetTableInfo_ConcrRepr(ReprN_Grid0Text1));
                this.CurrentTable.ToStringArray(ref ss, ref ArrSize, TblInf, QRowsForHeaders);
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                //// получаем выбранный файл
                FullName = saveFileDialog1.FileName;
                //MessageBox.Show(FullName);
                MyLib.StringArrToCSV(FullName, ss, ArrSize, ";");
            }//if table or Grid
        }

        private void MenuItem_Sources_SaveToCSV_Click(object sender, EventArgs e)
        {
            SaveToCSV();
        }

        
        private int GetArrowsPurposeN()
        {
            int N=0;

            return N;
        }
        private void ShowTableControlsAccordingToUssagePolicy()
        {
            int QLines, QColumns;
            string ItemText;
            string InputText;
            //
            if (this.Visible)
            {
                QLines = this.TblInf.GetQLines(); QColumns = this.TblInf.GetQColumns();
                ItemText = this.comboBox_ContentItem.SelectedItem.ToString();
                InputText = this.comboBox_ContentItem.Text;
                //Add Line
                //this.button_AddLine.Enabled = this.TblInf.UssagePolicy.LinesCanAdd;
                this.button_AddLine.Enabled = this.TblInf.UssagePolicy.GetIf_LinesCanAdd(QLines);
                //Ins Line
                //this.button_InsLine.Enabled = this.TblInf.UssagePolicy.LinesCanIns;
                this.button_InsLine.Enabled = this.TblInf.UssagePolicy.GetIf_LinesCanIns(QLines);
                //Del Line
                //this.button_DelLine.Enabled = this.TblInf.UssagePolicy.LinesCanDel;
                this.button_DelLine.Enabled = this.TblInf.UssagePolicy.GetIf_LinesCanDel(QLines);
                //Add Col
                //this.button_AddColumn.Enabled = this.TblInf.UssagePolicy.ColumnsCanAdd;
                this.button_AddColumn.Enabled = this.TblInf.UssagePolicy.GetIf_ColumnsCanAdd(QColumns);
                //Ins Col
                //this.button_InsCol.Enabled = this.TblInf.UssagePolicy.ColumnsCanIns;
                this.button_InsCol.Enabled = this.TblInf.UssagePolicy.GetIf_ColumnsCanIns(QColumns);
                //Del Col
                //this.button_DelCol.Enabled = this.TblInf.UssagePolicy.ColumnsCanDel;
                this.button_DelCol.Enabled = this.TblInf.UssagePolicy.GetIf_ColumnsCanDel(QColumns);
                //Add Both
                //this.button_AddBoth.Enabled = this.TblInf.UssagePolicy.BothCanAdd;
                this.button_AddBoth.Enabled = this.TblInf.UssagePolicy.GetIf_BothLinesAndColumnsCanAdd(QLines, QColumns);
                //Ins Both
                //this.button_InsBoth.Enabled = this.TblInf.UssagePolicy.BothCanIns;
                this.button_InsBoth.Enabled = this.TblInf.UssagePolicy.GetIf_BothLinesAndColumnsCanIns(QLines, QColumns);
                //Del Both
                //this.button_DelBoth.Enabled = this.TblInf.UssagePolicy.BothCanDel;
                this.button_DelBoth.Enabled = this.TblInf.UssagePolicy.GetIf_BothLinesAndColumnsCanDel(QLines, QColumns);
                //Set cell value
                if ((ItemText.Equals("Content cell") || InputText.Equals("Content cell")) && this.TblInf.UssagePolicy.ContentsCanEdit == false) this.button_SetValue.Enabled = false;
                else if ((ItemText.Equals("Col of Line Hdr") || InputText.Equals("Col of Line Hdr")) && this.TblInf.UssagePolicy.LH_Can_Edit == false) this.button_SetValue.Enabled = false;
                else if ((ItemText.Equals("Line of Col Hdr") || InputText.Equals("Line of Col Hdr")) && this.TblInf.UssagePolicy.CH_Can_Edit == false) this.button_SetValue.Enabled = false;
                else if ((ItemText.Equals("Table Name") || InputText.Equals("Table Name")) && this.TblInf.UssagePolicy.TableName_Can_Edit == false) this.button_SetValue.Enabled = false;
                else if ((ItemText.Equals("Lines Gen Name") || InputText.Equals("Lines Gen Name")) && this.TblInf.UssagePolicy.LinesGenName_Can_Edit == false) this.button_SetValue.Enabled = false;
                else if ((ItemText.Equals("Columns Gen Name") || InputText.Equals("Columns Gen Name")) && this.TblInf.UssagePolicy.ColumnsGenName_Can_Edit == false) this.button_SetValue.Enabled = false;
                else this.button_SetValue.Enabled = true;
                this.button_Table_Set.Enabled = this.TblInf.UssagePolicy.ContentsCanEdit;
                //Set Table
            }
        }
        private void AddLine()
        {
            //this.FormCfgMain.
            int QLines = this.TblInf.GetQLines();//, QColumns = this.TblInf.GetQColumns(); ;
            int gLineIndex = this.dataGridView1.CurrentCell.RowIndex, tLineN = this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);//,
                //gColumnIndex = this.dataGridView1.CurrentCell.RowIndex, tColumnN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColumnIndex); 
            if (this.TblInf.UssagePolicy.GetIf_LinesCanAdd(QLines))
            {
                switch (this.FormCfgMain.ModeTbl_Gui0Inner1Target2)
                {
                    case 0:
                        //this.dataGridView1.Rows.Add();
                        this.dataGridView1.RowCount++;
                        this.TblInf.SetSize(this.TblInf.GetQLines() + 1, this.TblInf.GetQColumns()); //works well
                        //this.TblInf.AddLine(); //works well
                        this.NsToDisplay.AddLine();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        this.ExchangeLinesLastAndPreLast();
                    break;
                    case 1:
                        this.CurrentTable.AddEmptyLine_TypesByExisting(this.TblInf); //seems so
                        if (this.CurrentTable.GetTableInfo() != null) this.TblInf.RowsQuantities = (this.CurrentTable.GetTableInfo()).GetSize();
                        else this.TblInf.AddLine();    
                        //else this.TblInf.SetSize(this.TblInf.GetQLines() + 1, this.TblInf.GetQColumns());
                        this.NsToDisplay.AddLine();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        ShowTable();
                    break;
                    case 2:
                        this.CurrentTable.AddEmptyLine_TypesByExisting(this.TblInf); //seems so
                        if (this.CurrentTable.GetTableInfo() != null) this.TblInf.RowsQuantities = (this.CurrentTable.GetTableInfo()).GetSize();
                        else this.TblInf.SetSize(this.TblInf.GetQLines() + 1, this.TblInf.GetQColumns());
                        //this.NsToDisplay.SetQShownContentLines(this.NsToDisplay.NsToDispl.QLines + 1);
                        this.NsToDisplay.AddLine();
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        ShowTable();
                    break;
                }
            }
        }//fn AddLine_ToCurPos()
        private void AddColumn()
        {
            //this.FormCfgMain.
            int //QLines = this.TblInf.GetQLines();//, 
                QColumns = this.TblInf.GetQColumns(); ;
            int //gLineIndex = this.dataGridView1.CurrentCell.RowIndex, tLineN = this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);//,
                  gColumnIndex = this.dataGridView1.CurrentCell.RowIndex, tColumnN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColumnIndex);
            if (this.TblInf.UssagePolicy.GetIf_ColumnsCanAdd(QColumns))
            {
                switch (this.FormCfgMain.ModeTbl_Gui0Inner1Target2)
                {
                    case 0:
                        //this.dataGridView1.Rows.Add();
                        this.dataGridView1.ColumnCount++;
                        //this.TblInf.SetSize(this.TblInf.GetQLines(), this.TblInf.GetQColumns() + 1);//work't gut
                        this.TblInf.AddColumn();
                        this.NsToDisplay.AddColumn();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        break;
                    case 1:
                        this.CurrentTable.AddEmptyColumn_TypesByExisting(this.TblInf); //seems so
                        if (this.CurrentTable.GetTableInfo() != null) this.TblInf.RowsQuantities = (this.CurrentTable.GetTableInfo()).GetSize();
                        else this.TblInf.AddColumn();
                        //else this.TblInf.SetSize(this.TblInf.GetQLines(), this.TblInf.GetQColumns() + 1);//work't gut
                        this.NsToDisplay.AddColumn();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        ShowTable();
                        break;
                    case 2:
                        this.CurrentTable.AddEmptyColumn_TypesByExisting(this.TblInf); //seems so
                        if (this.CurrentTable.GetTableInfo() != null) this.TblInf.RowsQuantities = (this.CurrentTable.GetTableInfo()).GetSize();
                        else this.TblInf.SetSize(this.TblInf.GetQLines(), this.TblInf.GetQColumns() + 1);
                        this.NsToDisplay.AddColumn();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        ShowTable();
                        break;
                }
            }
        }
        private void AddBothLineAndColumn()
        {
            int QLines = this.TblInf.GetQLines();
            int gLineIndex = this.dataGridView1.CurrentCell.RowIndex, tLineN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gLineIndex);
            int QColumns = this.TblInf.GetQColumns();
            int gColumnIndex = this.dataGridView1.CurrentCell.RowIndex, tColumnN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColumnIndex);
            if (this.TblInf.UssagePolicy.GetIf_BothLinesAndColumnsCanAdd(QLines, QColumns))
            {
                AddLine();
                AddColumn();
            }
        }
        private void InsLine_ToCurPos()
        {
            int QLines = this.TblInf.GetQLines();
            int gLineIndexSelected = this.dataGridView1.CurrentCell.RowIndex, tLineN = this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndexSelected);
            if (this.TblInf.UssagePolicy.GetIf_LinesCanIns(QLines) && tLineN >= 1)
            {
                switch (this.FormCfgMain.ModeTbl_Gui0Inner1Target2)
                {
                    case 0:
                        //this.dataGridView1.Rows.Count--;
                        //this.dataGridView1.RowCount++;
                        this.AddLine(); //ob need Excjhange last and prelast lines - spec for c#
                        for (int i = this.dataGridView1.Rows.Count - 1; i >= gLineIndexSelected + 1; i--)
                        {
                            this.dataGridView1.Rows[i].HeaderCell.Value = this.dataGridView1.Rows[i - 1].HeaderCell.Value;
                            for (int j = 0; j <= this.dataGridView1.Columns.Count - 1; j++)
                            {
                               // this.dataGridView1.Rows[i].Cells[j] = this.dataGridView1.Rows[i - 1].Cells[j];
                                this.dataGridView1.Rows[i].Cells[j].Value = this.dataGridView1.Rows[i - 1].Cells[j].Value;
                            }
                        }
                        for (int j = 0; j <= this.dataGridView1.Columns.Count - 1; j++) this.dataGridView1.Rows[gLineIndexSelected].Cells[j].Value = "";
                        this.dataGridView1.Rows[gLineIndexSelected].HeaderCell.Value = "";
                        this.TblInf.SetSize(this.TblInf.GetQLines() + 1, this.TblInf.GetQColumns());
                        this.NsToDisplay.AddLine();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        break;
                    case 1:
                        this.CurrentTable.InsEmptyLine_TypesByExisting(tLineN, this.TblInf, (CurrentTable.GetTableInfo()!=null));//(this.TblInf); //seems so
                        if (this.CurrentTable.GetTableInfo() != null) this.TblInf.RowsQuantities = (this.CurrentTable.GetTableInfo()).GetSize();
                        else this.TblInf.SetSize(this.TblInf.GetQLines(), this.TblInf.GetQColumns() + 1);
                        this.NsToDisplay.AddLine();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        ShowTable();
                        break;
                    case 2:
                        this.CurrentTable.AddEmptyColumn_TypesByExisting(this.TblInf); //seems so
                        if (this.CurrentTable.GetTableInfo() != null) this.TblInf.RowsQuantities = (this.CurrentTable.GetTableInfo()).GetSize();
                        else this.TblInf.SetSize(this.TblInf.GetQLines(), this.TblInf.GetQColumns() + 1);
                        this.NsToDisplay.AddColumn();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        ShowTable();
                        break;
                }
            }
        }
        private void InsColumn_ToCurPos()
        {
            int QLines = this.TblInf.GetQLines(), QColumns = this.TblInf.GetQColumns();
            int gColumnIndexSelected = this.dataGridView1.CurrentCell.ColumnIndex, tColN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColumnIndexSelected);
            if (this.TblInf.UssagePolicy.GetIf_ColumnsCanIns(QColumns) && tColN >= 1)
            {
                switch (this.FormCfgMain.ModeTbl_Gui0Inner1Target2)
                {
                    case 0:
                        this.dataGridView1.ColumnCount++;
                        //for (int i = 0; i <= this.dataGridView1.Rows.Count - 1; i++)
                        //{
                        //    for (int j = this.dataGridView1.Columns.Count - 1; j >= gColumnIndexSelected + 1; j--)
                        //    {
                        //        //this.dataGridView1.Rows[i].Cells[j] = this.dataGridView1.Rows[i - 1].Cells[j];
                        //        this.dataGridView1.Rows[i].Cells[j].Value = this.dataGridView1.Rows[i - 1].Cells[j].Value;
                        //    }
                        //}
                        for (int j = this.dataGridView1.Columns.Count - 1; j >= gColumnIndexSelected + 1; j--)
                        {
                            this.dataGridView1.Columns[j].HeaderCell.Value = this.dataGridView1.Columns[j-1].HeaderCell.Value;
                            for (int i = 0; i <= this.dataGridView1.Rows.Count - 1; i++)
                            {
                                //this.dataGridView1.Rows[i].Cells[j] = this.dataGridView1.Rows[i - 1].Cells[j];
                                this.dataGridView1.Rows[i].Cells[j].Value = this.dataGridView1.Rows[i].Cells[j-1].Value;
                            }
                        }
                        for (int i = 0; i <= this.dataGridView1.Rows.Count - 1; i++) this.dataGridView1.Rows[i].Cells[gColumnIndexSelected].Value = "";
                        this.dataGridView1.Columns[gColumnIndexSelected].HeaderCell.Value = "";
                        break;
                    case 1:
                        this.CurrentTable.InsEmptyColumn_TypesByExisting(tColN, this.TblInf);
                        if (this.CurrentTable.GetTableInfo() != null) this.TblInf.RowsQuantities = (this.CurrentTable.GetTableInfo()).GetSize();
                        else this.TblInf.AddColumn();
                        //else this.TblInf.SetSize(this.TblInf.GetQLines(), this.TblInf.GetQColumns() + 1);//work't gut
                        this.NsToDisplay.AddColumn();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        ShowTable();
                        break;
                    case 2:
                        this.CurrentTable.InsEmptyColumn_TypesByExisting(tColN, this.TblInf);
                        if (this.CurrentTable.GetTableInfo() != null) this.TblInf.RowsQuantities = (this.CurrentTable.GetTableInfo()).GetSize();
                        else this.TblInf.AddColumn();
                        //else this.TblInf.SetSize(this.TblInf.GetQLines(), this.TblInf.GetQColumns() + 1);//work't gut
                        this.NsToDisplay.AddColumn();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        ShowTable();
                        break;
                }
            }
        }
        private void InsBothLineAndColumn_ToCurPos()
        {
            int QLines = this.TblInf.GetQLines(), QColumns = this.TblInf.GetQColumns(),
                gColumnIndexSelected = this.dataGridView1.CurrentCell.ColumnIndex, tColumnN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColumnIndexSelected),
                gLineIndexSelected = this.dataGridView1.CurrentCell.RowIndex, tLineN = this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndexSelected);
            if (this.TblInf.UssagePolicy.GetIf_BothLinesAndColumnsCanIns(QLines, QColumns) && tLineN >= 1 && tColumnN >= 1)
            {
                InsLine_ToCurPos();
                InsColumn_ToCurPos();
            }
        }
        private void DelLine_AtCurPos()
        {
            int QLines = this.TblInf.GetQLines(), QColumns = this.TblInf.GetQColumns();
            int gLineIndexSelected = this.dataGridView1.CurrentCell.RowIndex, tLineN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gLineIndexSelected);
            if (this.TblInf.UssagePolicy.GetIf_LinesCanDel(QLines) && tLineN >= 1 && QLines>1)
            {
                switch (this.FormCfgMain.ModeTbl_Gui0Inner1Target2)
                {
                    case 0:
                        if (QLines > 1 && this.TblInf.UssagePolicy.LinesCanDel)
                        {
                            for (int i = gLineIndexSelected; i <= this.dataGridView1.Rows.Count - 1 - 1; i++)
                            {
                                for (int j = 0; j <= this.dataGridView1.Columns.Count - 1; j++)
                                {
                                    //this.dataGridView1.Rows[i].Cells[j] = this.dataGridView1.Rows[i + 1].Cells[j];
                                    this.dataGridView1.Rows[i].Cells[j].Value = this.dataGridView1.Rows[i + 1].Cells[j].Value;
                                }
                                this.dataGridView1.Rows[i].HeaderCell.Value = this.dataGridView1.Rows[i + 1].HeaderCell.Value;
                            }
                            //this.dataGridView1.Rows.Count--;
                            this.ExchangeLinesLastAndPreLast();
                            this.dataGridView1.RowCount--;
                            //
                            this.TblInf.DelLine();
                        }
                        break;
                    case 1:
                        this.CurrentTable.DelLineN(tLineN, this.TblInf);
                        if (this.CurrentTable.GetTableInfo() != null) this.TblInf.RowsQuantities = (this.CurrentTable.GetTableInfo()).GetSize();
                        else this.TblInf.DelLine();    
                        //else this.TblInf.SetSize(this.TblInf.GetQLines() + 1, this.TblInf.GetQColumns());
                        this.NsToDisplay.DelLine();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        ShowTable();
                        break;
                    case 2:
                        this.CurrentTable.DelLineN(tLineN, this.TblInf);//seems so
                        if (this.CurrentTable.GetTableInfo() != null) this.TblInf.RowsQuantities = (this.CurrentTable.GetTableInfo()).GetSize();
                        else this.TblInf.DelLine();    
                        //else this.TblInf.SetSize(this.TblInf.GetQLines() + 1, this.TblInf.GetQColumns());
                        this.NsToDisplay.DelLine();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        ShowTable();
                        break;
                }
            }
        }//mark2
        private void DelColumn_AtCurPos()
        {
            int QLines = this.TblInf.GetQLines(), QColumns = this.TblInf.GetQColumns();
            int gColumnIndexSelected = this.dataGridView1.CurrentCell.ColumnIndex, tColN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColumnIndexSelected);
            if (this.TblInf.UssagePolicy.GetIf_ColumnsCanDel(QColumns) && tColN >= 1 && QColumns>1)
            {
                switch (this.FormCfgMain.ModeTbl_Gui0Inner1Target2)
                {
                    case 0:
                        if (QColumns > 1 && this.TblInf.UssagePolicy.ColumnsCanDel)
                        {
                            //for (int i = 0; i <= this.dataGridView1.Rows.Count - 1; i++)
                            //{
                            //    for (int j = gColumnIndexSelected; j <= this.dataGridView1.Columns.Count - 1 - 1; j++)
                            //    {
                            //        //this.dataGridView1.Rows[i].Cells[j] = this.dataGridView1.Rows[i].Cells[j + 1];
                            //        this.dataGridView1.Rows[i].Cells[j].Value = this.dataGridView1.Rows[i].Cells[j + 1].Value;
                            //    }
                            //}
                            //for (int j = gColumnIndexSelected; j <= this.dataGridView1.Columns.Count - 1 - 1; j++)
                            //{
                            //    this.dataGridView1.Columns[j].HeaderCell.Value = this.dataGridView1.Columns[j + 1].HeaderCell.Value;
                            //}
                            for (int i = gColumnIndexSelected; i <= this.dataGridView1.Columns.Count - 1 - 1; i++)
                            {
                                this.dataGridView1.Columns[i].HeaderCell.Value = this.dataGridView1.Columns[i + 1].HeaderCell.Value;
                                for (int j = 0; j <= this.dataGridView1.Rows.Count - 1; j++)
                                {
                                    //this.dataGridView1.Rows[i].Cells[j] = this.dataGridView1.Rows[i].Cells[j + 1];
                                    this.dataGridView1.Rows[j].Cells[i].Value = this.dataGridView1.Rows[j].Cells[i + 1].Value;
                                }
                            }
                            //this.dataGridView1.Columns.Count--;
                            this.dataGridView1.ColumnCount--;
                            //
                            this.TblInf.DelColumn();
                        }
                        break;
                    case 1:
                        this.CurrentTable.DelColumnN(tLineN, this.TblInf);
                        if (this.CurrentTable.GetTableInfo() != null) this.TblInf.RowsQuantities = (this.CurrentTable.GetTableInfo()).GetSize();
                        else this.TblInf.DelColumn();    
                        //else this.TblInf.SetSize(this.TblInf.GetQLines() + 1, this.TblInf.GetQColumns());
                        this.NsToDisplay.DelColumn();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        ShowTable();
                        break;
                    case 2:
                        this.CurrentTable.DelColumnN(tLineN, this.TblInf);//seems so
                        if (this.CurrentTable.GetTableInfo() != null) this.TblInf.RowsQuantities = (this.CurrentTable.GetTableInfo()).GetSize();
                        else this.TblInf.DelColumn();    
                        //else this.TblInf.SetSize(this.TblInf.GetQLines() + 1, this.TblInf.GetQColumns());
                        this.NsToDisplay.DelColumn();//ut ne hide l'new
                        this.GridParamsCalcd.Set(this.FormCfgMain, this.NsToDisplay, this.TblInf);
                        ShowTable();
                        break;
                }
            }
        }
        private void DelBothLineAndColumn_AtCurPos()
        {
            int QLines = this.TblInf.GetQLines(), QColumns = this.TblInf.GetQColumns(),
                gColumnIndexSelected = this.dataGridView1.CurrentCell.ColumnIndex, tColumnN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColumnIndexSelected),
                gLineIndexSelected = this.dataGridView1.CurrentCell.RowIndex, tLineN = this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndexSelected);
            if (this.TblInf.UssagePolicy.GetIf_BothLinesAndColumnsCanDel(QLines, QColumns) && tLineN >= 1 && tColumnN >= 1)
            {
                DelLine_AtCurPos();
                DelColumn_AtCurPos();
            }
        }
        //
        void SwapCells(ref DataGridViewCell cell1, ref DataGridViewCell cell2)
        {
            DataGridViewCell cellBuf;
            //1->buf
            if (cell1 is DataGridViewComboBoxCell)
            {
                cellBuf = new DataGridViewComboBoxCell();
                cellBuf = (DataGridViewComboBoxCell)cell1.Clone();
            }
            else if (cell1 is DataGridViewCheckBoxCell)
            {
                cellBuf = new DataGridViewCheckBoxCell();
                cellBuf = (DataGridViewCheckBoxCell)cell1.Clone();
            }
            else
            {
                cellBuf = new DataGridViewTextBoxCell();
                cellBuf = (DataGridViewTextBoxCell)cell1.Clone();
            }
            //2->1
            if (cell2 is DataGridViewComboBoxCell)
            {
                cell1 = new DataGridViewComboBoxCell();
                cell1 = (DataGridViewComboBoxCell)cell2.Clone();
            }
            else if (cell2 is DataGridViewCheckBoxCell)
            {
                cell1 = new DataGridViewCheckBoxCell();
                cell1 = (DataGridViewCheckBoxCell)cell2.Clone();
            }
            else
            {
                cell1 = new DataGridViewTextBoxCell();
                cell1 = (DataGridViewTextBoxCell)cell2.Clone();
            }
            //buf->2
            if (cellBuf is DataGridViewComboBoxCell)
            {
                cell2 = new DataGridViewComboBoxCell();
                cell2 = (DataGridViewComboBoxCell)cellBuf.Clone();
            }
            else if (cellBuf is DataGridViewCheckBoxCell)
            {
                cell2 = new DataGridViewCheckBoxCell();
                cell2 = (DataGridViewCheckBoxCell)cellBuf.Clone();
            }
            else
            {
                cell2 = new DataGridViewTextBoxCell();
                cell2 = (DataGridViewTextBoxCell)cellBuf.Clone();
            }
        }
        void SwapCells(int LineNatN1, int ColNatN1, int LineNatN2, int ColNatN2)
        {
            DataGridViewCell cell1, cell2;
            //
            if (LineNatN1 == 0 && ColNatN1 == 0) cell1 = this.dataGridView1.TopLeftHeaderCell;
            else if (LineNatN1 > 0 && ColNatN1 == 0) cell1 = this.dataGridView1.Rows[LineNatN1 - 1].HeaderCell;
            else if (LineNatN1 == 0 && ColNatN1 > 0) cell1 = this.dataGridView1.Columns[ColNatN1 - 1].HeaderCell;
            else cell1 = this.dataGridView1.Rows[LineNatN1 - 1].Cells[ColNatN1 - 1];
            //
            if (LineNatN2 == 0 && ColNatN2 == 0) cell2 = this.dataGridView1.TopLeftHeaderCell;
            else if (LineNatN2 > 0 && ColNatN2 == 0) cell2 = this.dataGridView1.Rows[LineNatN2 - 1].HeaderCell;
            else if (LineNatN2 == 0 && ColNatN2 > 0) cell2 = this.dataGridView1.Columns[ColNatN2 - 1].HeaderCell;
            else cell2 = this.dataGridView1.Rows[LineNatN2 - 1].Cells[ColNatN2 - 1];
            //
            SwapCells(ref cell1, ref cell2);
            //
        }
        void TransposeGrid()
        {
            int QLines1, QLines2, QColumns1, QColumns2, QLinesMin, QLinesMax, QColumnsMin, QColumnsMax;
            DataGridViewCell cell1, cell2;
            //
            QLines1 = dataGridView1.Rows.Count;
            QColumns1 = dataGridView1.Columns.Count;
            QLines2 = QColumns1;
            QColumns2 = QLines1;
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
            //
            dataGridView1.RowCount = QLinesMax;
            dataGridView1.ColumnCount = QColumnsMax;
            //
            for (int i = 1; i <= QLines1; i++)
            {
                for (int j = 1; j <= QColumns1; j++)
                {
                    cell1 = this.dataGridView1.Rows[i - 1].Cells[j - 1];
                    cell2 = this.dataGridView1.Rows[j - 1].Cells[i - 1];
                    SwapCells(ref cell1, ref cell2);
                }
            }
            //
            for (int i = 1; i <= QLines1; i++)
            {
                cell1 = this.dataGridView1.Rows[i - 1].HeaderCell;
                cell2 = this.dataGridView1.Columns[i - 1].HeaderCell;
                SwapCells(ref cell1, ref cell2);
            }
            //
            for (int i = 1; i <= QColumns1; i++)
            {
                cell1 = this.dataGridView1.Columns[i - 1].HeaderCell;
                cell2 = this.dataGridView1.Rows[i - 1].HeaderCell;
                SwapCells(ref cell1, ref cell2);
            }
            //
            this.dataGridView1.RowCount = QLines2;
            this.dataGridView1.ColumnCount = QColumns2;
        }
        void SortLinesVisaVersa()
        {
            DataGridViewCell cell1, cell2;
            int QLines = this.dataGridView1.Rows.Count, QColumns = this.dataGridView1.Columns.Count, boundVal, N;
            bool EvenNotOdd = (QLines % 2 == 0);
            if (EvenNotOdd) boundVal = QLines / 2;
            else boundVal = (QLines - 1) / 2;
            for (int i = 1; i <= boundVal; i++)
            {
                N = QLines - i + 1;//1->5-1=4, 2->5-2=3, //1->6-1+1=6, 2->6-2+1=5
                //
                cell1 = this.dataGridView1.Rows[i - 1].HeaderCell;
                cell2 = this.dataGridView1.Rows[N - 1].HeaderCell;
                SwapCells(ref cell1, ref cell2);
                //
                for (int j = 1; j <= QColumns; j++)
                {
                    cell1 = this.dataGridView1.Rows[i - 1].Cells[j - 1];
                    cell2 = this.dataGridView1.Rows[N - 1].Cells[j - 1];
                    SwapCells(ref cell1, ref cell2);
                }
            }
        }//fn
        void SortColumnsVisaVersa()
        {
            DataGridViewCell cell1, cell2;
            int QLines = this.dataGridView1.Rows.Count, QColumns = this.dataGridView1.Columns.Count, boundVal, N;
            bool EvenNotOdd = (QColumns % 2 == 0);
            if (EvenNotOdd) boundVal = QLines / 2;
            else boundVal = (QColumns - 1) / 2;
            for (int i = 1; i <= boundVal; i++)
            {
                N = QColumns - i + 1;//1->5-1=4, 2->5-2=3, //1->6-1+1=6, 2->6-2+1=5
                //
                cell1 = this.dataGridView1.Columns[i - 1].HeaderCell;
                cell2 = this.dataGridView1.Columns[N - 1].HeaderCell;
                SwapCells(ref cell1, ref cell2);
                //
                for (int j = 1; j <= QLines; j++)
                {
                    cell1 = this.dataGridView1.Rows[j - 1].Cells[i - 1];
                    cell2 = this.dataGridView1.Rows[j - 1].Cells[N - 1];
                    SwapCells(ref cell1, ref cell2);
                }
            }
        }//fn
        //
        public bool CellIsSelected()
        {
            if (this.dataGridView1.CurrentCell == null) MessageBox.Show("No cell selected");
            return (this.dataGridView1.CurrentCell == null);
        }
        TableSize GetCelectedCellIndexes()
        {
            TableSize indexes=new TableSize(0, 0);
            if (CellIsSelected())
            {
                indexes.QLines = this.dataGridView1.CurrentCell.RowIndex;
                indexes.QColumns = this.dataGridView1.CurrentCell.ColumnIndex;
            }
            return indexes;
        }
        public int QCellsSelected() { return this.dataGridView1.SelectedCells.Count; }
        private void CellMoveSwappingWithUpper()
        {
            TableSize active, target;

            string s1, s2;
            int TargetLineIndex, TargetColIndex, ActiveLineIndex, ActiveColIndex;
            //int TargetLineIndex, TargetColIndex, ActiveLineIndex, ActiveColIndex;
            if (CellIsSelected())
            {
                active=GetCelectedCellIndexes();
                ActiveLineIndex=active.QLines;
                ActiveColIndex = active.QColumns;
                TargetColIndex = ActiveColIndex;
                //we can also exchange caption cells,using non-caption ones as supplementary.
                if(ActiveLineIndex==0){
                    TargetLineIndex=-1;
                    s1 = this.dataGridView1.Columns[ActiveColIndex].HeaderCell.Value.ToString();
                    if (this.dataGridView1.Rows[0].Cells[ActiveColIndex] is DataGridViewComboBoxCell)
                    {
                        this.dataGridView1.Columns[ActiveColIndex].HeaderCell.Value = this.dataGridView1.Rows[0].Cells[ActiveColIndex].Value;
                    }
                }else TargetLineIndex=ActiveLineIndex-1;
               
            }
        }
        private void CellMoveSwappingWithLower()
        {

        }
        private void CellMoveSwappingWithLeft()
        {

        }
        private void CellMoveSwappingWithRight()
        {

        }
        private void LineMoveSwappingWithUpper()
        {

        }
        private void LineMoveSwappingWithLower()
        {

        }
        private void ColMoveSwappingWithLeft()
        {

        }
        private void ColMoveSwappingWithRight()
        {

        }
        //hab TrGrid
        //private void Transpose()
        //{

        //}
        private void SortTableByCurrentColumn(bool AccendingNotDescending = true)
        {

        }
        private void SortTableByHeaderColumn(bool AccendingNotDescending = true)
        {

        }
        //
        private void comboBox_ContentItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowTableControlsAccordingToUssagePolicy();
        }
        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FocusDown();
        }
        //
        private void FocusDown()
        {
            int gLineIndex = this.dataGridView1.CurrentCell.RowIndex;
            int gColIndex = this.dataGridView1.CurrentCell.ColumnIndex;
            if (gLineIndex < this.dataGridView1.Rows.Count-1) this.dataGridView1.CurrentCell = this.dataGridView1.Rows[gLineIndex + 1].Cells[gColIndex];
            CurrentCellToCmdLineComboBox();
            //
            int tLineN, tColN;
            tLineN = GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);
            tColN = GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColIndex);
            this.DataTopic.SelectedTableLineNatN = tLineN;
            this.DataTopic.SelectedTableColumnNatN = tColN;
        }
        private void FocusUp()
        {
            int gLineIndex = this.dataGridView1.CurrentCell.RowIndex;
            int gColIndex = this.dataGridView1.CurrentCell.ColumnIndex;
            if (gLineIndex > 0) this.dataGridView1.CurrentCell = this.dataGridView1.Rows[gLineIndex - 1].Cells[gColIndex];
            CurrentCellToCmdLineComboBox();
            //
            int tLineN, tColN;
            tLineN = GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);
            tColN = GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColIndex);
            this.DataTopic.SelectedTableLineNatN = tLineN;
            this.DataTopic.SelectedTableColumnNatN = tColN;
        }
        private void FocusToTheRight()
        {
            int gLineIndex = this.dataGridView1.CurrentCell.RowIndex;
            int gColIndex = this.dataGridView1.CurrentCell.ColumnIndex;
            if (gColIndex < this.dataGridView1.Columns.Count - 1) this.dataGridView1.CurrentCell = this.dataGridView1.Rows[gLineIndex].Cells[gColIndex+1];
            CurrentCellToCmdLineComboBox();
            //
            int tLineN, tColN;
            tLineN = GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);
            tColN = GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColIndex);
            this.DataTopic.SelectedTableLineNatN = tLineN;
            this.DataTopic.SelectedTableColumnNatN = tColN;
        }
        private void FocusToTheLeft()
        {
            int gLineIndex = this.dataGridView1.CurrentCell.RowIndex;
            int gColIndex = this.dataGridView1.CurrentCell.ColumnIndex;
            if (gColIndex > 0) this.dataGridView1.CurrentCell = this.dataGridView1.Rows[gLineIndex].Cells[gColIndex - 1];
            CurrentCellToCmdLineComboBox();
            //
            int tLineN, tColN;
            tLineN = GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);
            tColN = GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColIndex);
            this.DataTopic.SelectedTableLineNatN = tLineN;
            this.DataTopic.SelectedTableColumnNatN = tColN;
        }
        private void FocusToTheFinalCell()
        {
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.Rows.Count - 1].Cells[this.dataGridView1.Columns.Count - 1];
            CurrentCellToCmdLineComboBox();
            //
            int gLineIndex, gColIndex, tLineN, tColN, QLines = this.TblInf.GetQLines(), QColumns = this.TblInf.GetQColumns();
            tLineN = QLines; tColN = QColumns;
            gLineIndex = GridParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(tLineN);
            gColIndex = GridParamsCalcd.Calc_GridColIndex_ByTableColNatN(tColN);
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[gLineIndex].Cells[gColIndex];
            CurrentCellToCmdLineComboBox();
            this.DataTopic.SelectedTableLineNatN = tLineN;
            this.DataTopic.SelectedTableColumnNatN = tColN;
        }
        private void FocusToStart()
        {
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[1 - 1].Cells[1 - 1];
            CurrentCellToCmdLineComboBox();
            //
            int gLineIndex, gColIndex, tLineN, tColN, QLines = this.TblInf.GetQLines(), QColumns = this.TblInf.GetQColumns();
            tLineN = 1; tColN = 1;
            gLineIndex = GridParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(tLineN);
            gColIndex = GridParamsCalcd.Calc_GridColIndex_ByTableColNatN(tColN);
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[gLineIndex].Cells[gColIndex];
            CurrentCellToCmdLineComboBox();
            this.DataTopic.SelectedTableLineNatN = tLineN;
            this.DataTopic.SelectedTableColumnNatN = tColN;
        }
        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FocusUp();
        }
        //
        private void toTheLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FocusToTheLeft();
        }

        private void toTheRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FocusToTheRight();
        }
        //
        private void button_AddLine_Click(object sender, EventArgs e)
        {
            AddLine();
            // ShowTable();
        }
        private void button_AddColumn_Click(object sender, EventArgs e)
        {
            AddColumn();
            // ShowTable();
        }

        private void button_DelLine_Click(object sender, EventArgs e)
        {
            DelLine_AtCurPos();
        }

        private void button_DelCol_Click(object sender, EventArgs e)
        {
            DelColumn_AtCurPos();
        }

        private void button_AddBoth_Click(object sender, EventArgs e)
        {
            AddBothLineAndColumn();
        }

        private void button_DelBoth_Click(object sender, EventArgs e)
        {
            DelBothLineAndColumn_AtCurPos();
        }

        private void button_InsLine_Click(object sender, EventArgs e)
        {
            InsLine_ToCurPos();
        }

        private void button_InsCol_Click(object sender, EventArgs e)
        {
            InsColumn_ToCurPos();
        }

        private void button_InsBoth_Click(object sender, EventArgs e)
        {
            InsLine_ToCurPos();
            InsColumn_ToCurPos();
        }
        //
        private void toFinalCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FocusToTheEnd();
        }

        private void button_ArrowLeft_Click(object sender, EventArgs e){
            //int ArrowPurpose_ItemNatN=this.comboBox_ArrowsFns.SelectedIndex+1;
            switch (this.comboBox_ArrowsFns.SelectedIndex)
            {
                case TableConsts.GuiArrows_PurposeN_MoveFocus-1:
                    FocusToTheLeft();
                break;
                case TableConsts.GuiArrows_PurposeN_CompressShownAreaHideRows - 1:
                    this.CompressVisibleRowsFromTheRightToTheLeft();
                break;
                case TableConsts.GuiArrows_PurposeN_ExpandShownAreaShowRows - 1:
                    this.ExpandVisibleRowsToTheLeft();
                break;
                case TableConsts.GuiArrows_PurposeN_ShiftShowRows - 1:
                    this.ShiftVisibleRowsToTheLeft();
                break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingRows - 1:

                break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingCells - 1:

                break;
                case TableConsts.GuiArrows_PurposeN_InsOrAddRows - 1:

                break;
                case TableConsts.GuiArrows_PurposeN_DelRows - 1:

                break;
                case TableConsts.GuiArrows_PurposeN_MoveText - 1:

                break;
                case TableConsts.GuiArrows_PurposeN_CompressText - 1:

                break;
                case TableConsts.GuiArrows_PurposeN_ExpandText - 1:

                break;
                case TableConsts.GuiArrows_PurposeN_MoveTextCursor - 1:

                break;
            }
            
        }
        private void ExchangeLinesLastAndPreLast(){
            string buf="";
            for (int i = 1; i <= this.dataGridView1.ColumnCount; i++)
            {
                buf = "";
                if (this.dataGridView1.Rows[this.dataGridView1.RowCount - 1].Cells[i - 1].Value!=null) buf = this.dataGridView1.Rows[this.dataGridView1.RowCount - 1].Cells[i - 1].Value.ToString();
                this.dataGridView1.Rows[this.dataGridView1.RowCount - 1].Cells[i - 1].Value = this.dataGridView1.Rows[this.dataGridView1.RowCount - 1-1].Cells[i - 1].Value;
                this.dataGridView1.Rows[this.dataGridView1.RowCount - 1-1].Cells[i - 1].Value = buf;
            }
            if (this.dataGridView1.Rows[this.dataGridView1.RowCount - 1].HeaderCell.Value!=null) buf = this.dataGridView1.Rows[this.dataGridView1.RowCount - 1].HeaderCell.Value.ToString();
            this.dataGridView1.Rows[this.dataGridView1.RowCount - 1].HeaderCell.Value = this.dataGridView1.Rows[this.dataGridView1.RowCount - 1 - 1].HeaderCell.Value;
            this.dataGridView1.Rows[this.dataGridView1.RowCount - 1 - 1].HeaderCell.Value = buf;
        }
        public void FocusHome()
        {
            //int gLineIndex = this.dataGridView1.CurrentCell.RowIndex;
            //int gColIndex = this.dataGridView1.CurrentCell.ColumnIndex;
            //int tLineN = this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);
            //int tColN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColIndex);
            //int gColIndexNew = this.GridParamsCalcd.Calc_GridColIndex_ByTableColNatN(1);
            //this.dataGridView1.CurrentCell = this.dataGridView1.Rows[gLineIndex].Cells[gColIndexNew];
            //CurrentCellToCmdLineComboBox();
            //
            int gLineIndex = this.dataGridView1.CurrentCell.RowIndex;
            int gColIndex ;//= 1;// this.dataGridView1.CurrentCell.ColumnIndex;
            int tLineN = this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);
            int tColN = 1;// this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColIndex);
            gColIndex = GridParamsCalcd.Calc_GridColIndex_ByTableColNatN(tColN);
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[gLineIndex].Cells[gColIndex];
            CurrentCellToCmdLineComboBox();
            this.DataTopic.SelectedTableColumnNatN = tColN;
            this.DataTopic.SelectedTableLineNatN = tLineN;
        }
        public void FocusToTheEnd()
        {
            //int gLineIndex = this.dataGridView1.CurrentCell.RowIndex;
            //int gColIndex = this.dataGridView1.CurrentCell.ColumnIndex;
            //int tLineN = this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);
            //int tColN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColIndex);
            //this.dataGridView1.CurrentCell = this.dataGridView1.Rows[gLineIndex].Cells[this.dataGridView1.ColumnCount - 1];
            //CurrentCellToCmdLineComboBox();
            //
            int QColumns = this.TblInf.GetQColumns();
            int gLineIndex = this.dataGridView1.CurrentCell.RowIndex;
            int gColIndex;// = ;// this.dataGridView1.CurrentCell.ColumnIndex;
            int tLineN = this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);
            int tColN = QColumns;// this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColIndex);
            gColIndex = GridParamsCalcd.Calc_GridColIndex_ByTableColNatN(tColN);
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[gLineIndex].Cells[gColIndex];
            CurrentCellToCmdLineComboBox();
            this.DataTopic.SelectedTableColumnNatN = tColN;
            this.DataTopic.SelectedTableLineNatN = tLineN;
        }
        public void FocusToTheTop()
        {
            //int gLineIndex = this.dataGridView1.CurrentCell.RowIndex;
            //int gColIndex = this.dataGridView1.CurrentCell.ColumnIndex;
            //int tLineN = this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);
            //int tColN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColIndex);
            //int gLineIndexNew = this.GridParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(1);
            //this.dataGridView1.CurrentCell = this.dataGridView1.Rows[gLineIndexNew].Cells[gColIndex];
            //CurrentCellToCmdLineComboBox();
            //
            int gLineIndex;// = this.dataGridView1.CurrentCell.RowIndex;
            int gColIndex = this.dataGridView1.CurrentCell.ColumnIndex;
            int tLineN = 1;// this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);
            int tColN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColIndex);
            gLineIndex = GridParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(tLineN);
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[gLineIndex].Cells[gColIndex];
            CurrentCellToCmdLineComboBox();
            this.DataTopic.SelectedTableColumnNatN = tColN;
            this.DataTopic.SelectedTableLineNatN = tLineN;
        }
        public void FocusToBottom()
        {
            //int gLineIndex = this.dataGridView1.CurrentCell.RowIndex;
            //int gColIndex = this.dataGridView1.CurrentCell.ColumnIndex;
            //int tLineN = this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);
            //int tColN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColIndex);
            //this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.dataGridView1.RowCount - 1].Cells[gColIndex];
            //CurrentCellToCmdLineComboBox();
            //
            int QLines = this.TblInf.GetQLines();
            int gLineIndex;// = this.dataGridView1.CurrentCell.RowIndex;
            int gColIndex = this.dataGridView1.CurrentCell.ColumnIndex;
            int tLineN = QLines;// this.GridParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(gLineIndex);
            int tColN = this.GridParamsCalcd.Calc_TableColNatN_ByGridColIndex(gColIndex);
            gLineIndex = GridParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(tLineN);
            this.dataGridView1.CurrentCell = this.dataGridView1.Rows[gLineIndex].Cells[gColIndex];
            CurrentCellToCmdLineComboBox();
            this.DataTopic.SelectedTableColumnNatN = tColN;
            this.DataTopic.SelectedTableLineNatN = tLineN;
        }
        private void button_ArrowHome_Click(object sender, EventArgs e)
        {
            
            switch (this.comboBox_ArrowsFns.SelectedIndex)
            {
                case TableConsts.GuiArrows_PurposeN_MoveFocus - 1:
                    FocusHome();
                    break;
                case TableConsts.GuiArrows_PurposeN_CompressShownAreaHideRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandShownAreaShowRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ShiftShowRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingCells - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_InsOrAddRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_DelRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_CompressText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveTextCursor - 1:

                    break;
            }

        }
        private void button_ArrowToTheTop_Click(object sender, EventArgs e)
        {
            
            switch (this.comboBox_ArrowsFns.SelectedIndex)
            {
                case TableConsts.GuiArrows_PurposeN_MoveFocus - 1:
                    FocusToTheTop();
                    break;
                case TableConsts.GuiArrows_PurposeN_CompressShownAreaHideRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandShownAreaShowRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ShiftShowRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingCells - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_InsOrAddRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_DelRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_CompressText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveTextCursor - 1:

                    break;
            }
        }
        private void button_ArrowToBottom_Click(object sender, EventArgs e)
        {
            
            switch (this.comboBox_ArrowsFns.SelectedIndex)
            {
                case TableConsts.GuiArrows_PurposeN_MoveFocus - 1:
                    FocusToBottom();
                    break;
                case TableConsts.GuiArrows_PurposeN_CompressShownAreaHideRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandShownAreaShowRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ShiftShowRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingCells - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_InsOrAddRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_DelRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_CompressText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveTextCursor - 1:

                    break;
            }
        }

        private void button_ArrowEnd_Click(object sender, EventArgs e)
        {
            
            switch (this.comboBox_ArrowsFns.SelectedIndex)
            {
                case TableConsts.GuiArrows_PurposeN_MoveFocus - 1:
                    FocusToTheEnd();
                    break;
                case TableConsts.GuiArrows_PurposeN_CompressShownAreaHideRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandShownAreaShowRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ShiftShowRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingCells - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_InsOrAddRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_DelRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_CompressText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveTextCursor - 1:

                    break;
            }
        }

        private void button_ArrowRight_Click(object sender, EventArgs e)
        {
            
            switch (this.comboBox_ArrowsFns.SelectedIndex)
            {
                case TableConsts.GuiArrows_PurposeN_MoveFocus - 1:
                    FocusToTheRight();
                    break;
                case TableConsts.GuiArrows_PurposeN_CompressShownAreaHideRows - 1:
                    this.CompressVisibleRowsFromTheLeftToTheRight();
                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandShownAreaShowRows - 1:
                    this.ExpandVisibleRowsToTheRight();
                    break;
                case TableConsts.GuiArrows_PurposeN_ShiftShowRows - 1:
                    this.ShiftVisibleRowsToTheRight();
                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingCells - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_InsOrAddRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_DelRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_CompressText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveTextCursor - 1:

                    break;
            }
        }

        private void button_ArrowUp_Click(object sender, EventArgs e)
        {
            
            switch (this.comboBox_ArrowsFns.SelectedIndex)
            {
                case TableConsts.GuiArrows_PurposeN_MoveFocus - 1:
                    FocusUp();
                    break;
                case TableConsts.GuiArrows_PurposeN_CompressShownAreaHideRows - 1:
                    this.CompressVisibleRowsFromUpToDown();
                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandShownAreaShowRows - 1:
                    this.ExpandVisibleRowsUp();
                    break;
                case TableConsts.GuiArrows_PurposeN_ShiftShowRows - 1:
                    this.ShiftVisibleRowsUp();
                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingCells - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_InsOrAddRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_DelRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_CompressText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveTextCursor - 1:

                    break;
            }

        }

        private void button_ArrowDown_Click(object sender, EventArgs e)
        {
            
            switch (this.comboBox_ArrowsFns.SelectedIndex)
            {
                case TableConsts.GuiArrows_PurposeN_MoveFocus - 1:
                    FocusDown();
                    break;
                case TableConsts.GuiArrows_PurposeN_CompressShownAreaHideRows - 1:
                    this.CompressVisibleRowsFromDownToUp();
                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandShownAreaShowRows - 1:
                    this.ExpandVisibleRowsDown();
                    break;
                case TableConsts.GuiArrows_PurposeN_ShiftShowRows - 1:
                    this.ShiftVisibleRowsDown();
                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveExchangingCells - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_InsOrAddRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_DelRows - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_CompressText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_ExpandText - 1:

                    break;
                case TableConsts.GuiArrows_PurposeN_MoveTextCursor - 1:

                    break;
            }
        }

        private void comboBox_ArrowsFns_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ArrowsPurposeN = this.comboBox_ArrowsFns.SelectedIndex + 1;
            if (
                //ArrowFor_ChangeCurCell1MoveRow2MoveCell3ExpandRows4CompressRows5MoveText6ExpandText7CompressText8MoveCursor9 == TableConsts.GuiArrows_PurposeN_DelRows
                //||
                ArrowsPurposeN == TableConsts.GuiArrows_PurposeN_CompressShownAreaHideRows)
            {
                button_ArrowDown.Text = "^";
                button_ArrowUp.Text = "v";
                button_ArrowLeft.Text = ">";
                button_ArrowRight.Text = "<";
            }
            else
            {
                button_ArrowDown.Text = "v";
                button_ArrowUp.Text = "^";
                button_ArrowLeft.Text = "<";
                button_ArrowRight.Text = ">";
            }
            if (
                ArrowsPurposeN == TableConsts.GuiArrows_PurposeN_MoveFocus
                ||
                ArrowsPurposeN == TableConsts.GuiArrows_PurposeN_MoveTextCursor
                ||
                ArrowsPurposeN == TableConsts.GuiArrows_PurposeN_InsOrAddRows
                //ArrowsPurposeN != 0//seems alum
                //ArrowsPurposeN != TableConsts.GuiArrows_PurposeN_CompressShownAreaHideRows
                //&&
                //ArrowsPurposeN != TableConsts.GuiArrows_PurposeN_ExpandShownAreaShowRows
                )
            {
                button_ArrowHome.Enabled = true;
                button_ArrowEnd.Enabled = true;
                button_ArrowToTheTop.Enabled = true;
                button_ArrowToBottom.Enabled = true;
            }
            else
            {
                button_ArrowHome.Enabled = false;
                button_ArrowEnd.Enabled = false;
                button_ArrowToTheTop.Enabled = false;
                button_ArrowToBottom.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ItemsChanged();
        }
        private void textBox_Items_MultilineChanged(object sender, EventArgs e)
        {
            ItemsChanged();
        } 
        private int fGetActiveN()
        {
            int N=0;
            string text;
            text=this.comboBox_CurContent.Text;
            if(this.comboBox_CurContent.Items!=null){
                if(this.comboBox_CurContent.SelectedItem!=null){
                    N=this.comboBox_CurContent.SelectedIndex+1;
                }else{
                    for (int i = 1; i <= this.comboBox_CurContent.Items.Count; i++)
                    {
                        if(text.Equals(this.comboBox_CurContent.Items[i-1].ToString())){
                            N=i;
                        }
                    }
                }
            }
            return N;
        }
        private void ItemsChanged(){
            string[] items;
            //int N = fGetActiveN();
            items = this.textBox_Items.Text.Split('\n');
            this.comboBox_CurContent.Items.Clear();
            foreach (string item in items)
            {
                this.comboBox_CurContent.Items.Add(item);
            }
        }
        //
        //public void SetVirtualCopyNull()
        //{
        //    //in C++ need to check if NULL and del
        //    this.CellVirtualCopy=null;
        //    this.LoCH = null; this.CoLH = null;
        //}
        /*
        public void FillVirtualCopy()
        {
            //bool CoLHHasContent = false, LoCHHasContent = false;
            this.CoLHHasContent = false; this.LoCHHasContent = false;
            int QLinesBef = this.dataGridView1.Rows.Count, QColumnsBef = this.dataGridView1.Columns.Count;//, QLinesAft=QColumnsBef, QColumnsAft=QLinesBef;
            for (int i = 1; i <= QLinesBef; i++)
            {
                if (this.dataGridView1.Rows[i - 1].HeaderCell != null && this.dataGridView1.Rows[i - 1].HeaderCell.Value != null && this.dataGridView1.Rows[i - 1].HeaderCell.Value.ToString() != "") CoLHHasContent = true;
            }
            for (int j = 1; j <= QColumnsBef; j++)
            {
                if (this.dataGridView1.Columns[j - 1].HeaderCell != null && this.dataGridView1.Columns[j - 1].HeaderCell.Value != null && this.dataGridView1.Columns[j - 1].HeaderCell.Value.ToString() != "") LoCHHasContent = true;
            }
            //
            if (CoLHHasContent)
            {
                CoLH = new string[QLinesBef];
                for (int i = 1; i <= QLinesBef; i++)
                {
                    CoLH[i - 1] = this.dataGridView1.Rows[i - 1].HeaderCell.Value.ToString();
                }
            }
            else
            {
                CoLH = null;
            }
            if (LoCHHasContent)
            {
                LoCH = new string[QColumnsBef];
                for (int i = 1; i <= QColumnsBef; i++)
                {
                    LoCH[i - 1] = this.dataGridView1.Columns[i - 1].HeaderCell.Value.ToString();
                }
            }
            else
            {
                LoCH = null;
            }
            //
            CellVirtualCopy = new DataGridViewCell[QLinesBef][];
            for (int i = 1; i <= QLinesBef; i++)
            {
                CellVirtualCopy[i - 1] = new DataGridViewCell[QColumnsBef];
            }
            //
            for (int i = 1; i <= QLinesBef; i++)
            {
                for (int j = 1; j <= QColumnsBef; j++)
                {
                    if (dataGridView1.Rows[i - 1].Cells[j - 1] is DataGridViewComboBoxCell)
                    {
                        CellVirtualCopy[i - 1][j - 1] = new DataGridViewComboBoxCell();
                        CellVirtualCopy[i - 1][j - 1] = (DataGridViewComboBoxCell)dataGridView1.Rows[i - 1].Cells[j - 1];
                    }
                    else if (dataGridView1.Rows[i - 1].Cells[j - 1] is DataGridViewCheckBoxCell)
                    {
                        CellVirtualCopy[i - 1][j - 1] = new DataGridViewCheckBoxCell();
                        CellVirtualCopy[i - 1][j - 1] = (DataGridViewCheckBoxCell)dataGridView1.Rows[i - 1].Cells[j - 1];
                    }
                    else
                    {
                        CellVirtualCopy[i - 1][j - 1] = new DataGridViewTextBoxCell();
                        CellVirtualCopy[i - 1][j - 1].Value = dataGridView1.Rows[i - 1].Cells[j - 1].Value;
                    }//if Type
                }//for j
            }//for i
        }//fn
        */
        //public void TransposeGrid()
        //{
        //    int QLinesBef = this.dataGridView1.Rows.Count, QColumnsBef = this.dataGridView1.Columns.Count, QLinesAft = QColumnsBef, QColumnsAft = QLinesBef;
        //    FillVirtualCopy();
        //    this.dataGridView1.RowCount = QLinesAft;
        //    this.dataGridView1.ColumnCount = QColumnsAft;
        //    for (int i = 1; i <= QLinesAft; i++)
        //    {
        //        for (int j = 1; j <= QColumnsAft; j++)
        //        {
        //            if (CellVirtualCopy[i - 1][j - 1] is DataGridViewComboBoxCell)
        //            {
        //                dataGridView1.Rows[i - 1].Cells[j - 1] = new DataGridViewComboBoxCell();
        //                dataGridView1.Rows[i - 1].Cells[j - 1] = (DataGridViewComboBoxCell)CellVirtualCopy[j - 1][i - 1];
        //            }
        //            else if (CellVirtualCopy[i - 1][j - 1] is DataGridViewCheckBoxCell)
        //            {
        //                dataGridView1.Rows[i - 1].Cells[j - 1] = new DataGridViewCheckBoxCell();
        //                dataGridView1.Rows[i - 1].Cells[j - 1] = (DataGridViewCheckBoxCell)CellVirtualCopy[j - 1][i - 1];
        //            }
        //            else
        //            {
        //                dataGridView1.Rows[i - 1].Cells[j - 1] = new DataGridViewTextBoxCell();
        //                dataGridView1.Rows[i - 1].Cells[j - 1].Value = CellVirtualCopy[j - 1][i - 1].Value;
        //            }//if Type
        //        }//for j
        //    }//for i
        //    //CellVirtualCopy=null;
        //    if (CoLH != null)
        //    {//ef transposing ce wa CoLH, af transposing ce wi LoCH
        //        for (int j = 1; j <= QColumnsAft; j++)
        //        {
        //            this.dataGridView1.Columns[j - 1].HeaderCell.Value = CoLH[j - 1];
        //        }
        //    }
        //    if (LoCH != null)
        //    {
        //        for (int j = 1; j <= QLinesAft; j++)
        //        {
        //            this.dataGridView1.Rows[j - 1].HeaderCell.Value = LoCH[j - 1];
        //        }
        //    }
        //    //FillVirtualCopy();
        //}//fn
        //public void LinesVisaVersa(){
        //    FillVirtualCopy();
        //    MyLib.SortTableLinesUpsideDown(ref CellVirtualCopy, dataGridView1.Rows.Count, dataGridView1.Columns.Count);
        //    for (int i = 1; i <= this.dataGridView1.Rows.Count; i++)
        //    {
        //        for (int j = 1; j <= this.dataGridView1.Columns.Count; j++)
        //        {
        //            SetCellFromCopy(i - 1, j - 1);
        //        }
        //    }
        //    if (CoLHHasContent)
        //    {
        //        for (int i = 1; i <= this.dataGridView1.Rows.Count; i++)
        //        {
        //            this.dataGridView1.Rows[i - 1].HeaderCell.Value = CoLH[this.dataGridView1.Rows.Count-i-1];
        //        }
        //    }
        //}
        //public void ColumnsVisaVersa(){
        //    FillVirtualCopy();
        //    MyLib.SortTableColumnsUpsideDown(ref CellVirtualCopy, dataGridView1.Rows.Count, dataGridView1.Columns.Count);
        //    for (int i = 1; i <= this.dataGridView1.Rows.Count; i++)
        //    {
        //        for (int j = 1; j <= this.dataGridView1.Columns.Count; j++)
        //        {
        //            SetCellFromCopy(i - 1, j - 1);
        //        }
        //    }
        //    if (LoCHHasContent)
        //    {
        //        for (int i = 1; i <= this.dataGridView1.Columns.Count; i++)
        //        {
        //            this.dataGridView1.Rows[i - 1].HeaderCell.Value = LoCH[this.dataGridView1.Columns.Count-i-1];
        //        }
        //    }
        //}
        //public bool GetIf_CoLHFilled()
        //{
        //    bool CoLHHasContent = false;
        //    for (int i = 1; i <= this.dataGridView1.Rows.Count; i++)
        //    {
        //        if (this.dataGridView1.Rows[i - 1].HeaderCell != null && this.dataGridView1.Rows[i - 1].HeaderCell.Value != null && this.dataGridView1.Rows[i - 1].HeaderCell.Value.ToString() != "") CoLHHasContent = true;
        //    }
        //    return CoLHHasContent;
        //}
        //public bool GetIf_LoCHFilled()
        //{
        //    bool LoCHHasContent = false;
        //    for (int i = 1; i <= dataGridView1.Columns.Count; i++)
        //    {
        //        if (this.dataGridView1.Columns[i - 1].HeaderCell != null && this.dataGridView1.Columns[i - 1].HeaderCell.Value != null && this.dataGridView1.Columns[i - 1].HeaderCell.Value.ToString() != "") LoCHHasContent = true;
        //    }
        //    return LoCHHasContent;
        //}
        
        //
        //
        //void SetCellFromCopy(int LineIndex, int ColumnIndex)
        //{
        //    if (CellVirtualCopy[LineIndex][ColumnIndex] is DataGridViewComboBoxCell)
        //    {
        //        dataGridView1.Rows[LineIndex].Cells[ColumnIndex] = new DataGridViewComboBoxCell();
        //        dataGridView1.Rows[LineIndex].Cells[ColumnIndex] = (DataGridViewComboBoxCell)CellVirtualCopy[ColumnIndex][LineIndex];
        //    }
        //    else if (CellVirtualCopy[LineIndex][ColumnIndex] is DataGridViewCheckBoxCell)
        //    {
        //        dataGridView1.Rows[LineIndex].Cells[ColumnIndex] = new DataGridViewCheckBoxCell();
        //        dataGridView1.Rows[LineIndex].Cells[ColumnIndex] = (DataGridViewCheckBoxCell)CellVirtualCopy[ColumnIndex][LineIndex];
        //    }
        //    else
        //    {
        //        dataGridView1.Rows[LineIndex].Cells[ColumnIndex] = new DataGridViewTextBoxCell();
        //        dataGridView1.Rows[LineIndex].Cells[ColumnIndex].Value = CellVirtualCopy[ColumnIndex][LineIndex].Value;
        //    }
        //}
        //void SetCellToCopy(int LineIndex, int ColumnIndex)
        //{
        //    if (dataGridView1.Rows[LineIndex].Cells[ColumnIndex] is DataGridViewComboBoxCell)
        //    {
        //        CellVirtualCopy[ColumnIndex][LineIndex] = new DataGridViewComboBoxCell();
        //        CellVirtualCopy[ColumnIndex][LineIndex] = (DataGridViewComboBoxCell)dataGridView1.Rows[LineIndex].Cells[ColumnIndex];
        //    }
        //    else if (CellVirtualCopy[LineIndex][ColumnIndex] is DataGridViewCheckBoxCell)
        //    {
        //        CellVirtualCopy[ColumnIndex][LineIndex] = new DataGridViewCheckBoxCell();
        //        CellVirtualCopy[ColumnIndex][LineIndex] = (DataGridViewCheckBoxCell)dataGridView1.Rows[LineIndex].Cells[ColumnIndex];
        //    }
        //    else
        //    {
        //        CellVirtualCopy[ColumnIndex][LineIndex] = new DataGridViewTextBoxCell();
        //        CellVirtualCopy[ColumnIndex][LineIndex].Value = dataGridView1.Rows[LineIndex].Cells[ColumnIndex].Value;
        //    }
        //}
        
        //public void TransposeGridByLib()
        //{
        //    FillVirtualCopy();
        //    int QLines = this.dataGridView1.Rows.Count, QColumns = this.dataGridView1.Columns.Count;
        //    MyLib.TransposeTable(ref CellVirtualCopy, ref QLines, ref QColumns);
        //    this.dataGridView1.RowCount = QLines;
        //    this.dataGridView1.ColumnCount = QColumns;
        //    for (int i = 1; i <= QLines; i++)
        //    {
        //        for (int j = 1; j <= QColumns; j++)
        //        {
        //            SetCellFromCopy(i-1, j-1);
        //            //SetCellFromCopy(j - 1, i- 1);//need leave, ob MyLib.Transpose hasn't  fns for cell and can work irr
        //        }
        //    }
        //    if (CoLHHasContent)
        //    {
        //        for (int i = 1; i <= this.dataGridView1.Columns.Count; i++)
        //        {
        //            this.dataGridView1.Rows[i - 1].HeaderCell.Value = CoLH[i - 1];//ob visa versa
        //        }
        //    }
        //    if(LoCHHasContent)
        //    {
        //        for (int i = 1; i <= this.dataGridView1.Rows.Count; i++)
        //        {
        //            this.dataGridView1.Rows[i - 1].HeaderCell.Value = CoLH[i - 1];//ob visa versa
        //        }
        //    }
        //}
        
        private void TransposeGridSeparately()
        {
            //string[][] CntNew;
            string[] LoCHNew = null, CoLHNew = null;
            bool LoCHHasContent = false, CoLHHasContent = false;//, ContentCellsHaveContent;
            int QLinesBef = this.dataGridView1.Rows.Count, QColumnsBef = this.dataGridView1.Columns.Count, QLinesAft = QColumnsBef, QColumnsAft = QLinesBef;
            DataGridViewCell CurGridCell;
            DataGridViewComboBoxCell ComboBoxCell;
            DataGridViewCheckBoxCell CheckBoxCell;
            DataGridViewCell[][] cell = new DataGridViewCell[QLinesAft][];
            //Real to virtual
            for (int i = 1; i <= QLinesBef; i++)
            {
                if (this.dataGridView1.Rows[i - 1].HeaderCell != null && this.dataGridView1.Rows[i - 1].HeaderCell.Value != null && this.dataGridView1.Rows[i - 1].HeaderCell.Value.ToString() != "") CoLHHasContent = true;
            }
            for (int j = 1; j <= QColumnsBef; j++)
            {
                if (this.dataGridView1.Columns[j - 1].HeaderCell != null && this.dataGridView1.Columns[j - 1].HeaderCell.Value != null && this.dataGridView1.Columns[j - 1].HeaderCell.Value.ToString() != "") LoCHHasContent = true;
            }
            if (CoLHHasContent)
            {
                LoCHNew = new string[QColumnsAft];
                for (int i = 1; i <= QLinesBef; i++)
                {
                    LoCHNew[i - 1] = this.dataGridView1.Rows[i - 1].HeaderCell.Value.ToString();
                }
            }
            if (LoCHHasContent)
            {
                CoLHNew = new string[QLinesAft];
                for (int i = 1; i <= QColumnsBef; i++)
                {
                    CoLHNew[i - 1] = this.dataGridView1.Columns[i - 1].HeaderCell.Value.ToString();
                }
            }
            //
            for (int i = 1; i <= QLinesAft; i++)
            {
                cell[i - 1] = new DataGridViewCell[QColumnsAft];
            }
            for (int i = 1; i <= QLinesAft; i++)
            {
                for (int j = 1; j <= QColumnsAft; j++)
                {
                    CurGridCell = this.dataGridView1.Rows[j - 1].Cells[i - 1];
                    if (CurGridCell is DataGridViewComboBoxCell)
                    {
                        ComboBoxCell = new DataGridViewComboBoxCell();
                        ComboBoxCell = (DataGridViewComboBoxCell)CurGridCell;
                        cell[i - 1][j - 1] = new DataGridViewComboBoxCell();
                        cell[i - 1][j - 1] = ComboBoxCell;
                    }
                    else if (CurGridCell is DataGridViewCheckBoxCell)
                    {
                        CheckBoxCell = new DataGridViewCheckBoxCell();
                        CheckBoxCell = (DataGridViewCheckBoxCell)CurGridCell;
                        cell[i - 1][j - 1] = new DataGridViewCheckBoxCell();
                        cell[i - 1][j - 1] = CheckBoxCell;
                    }
                    else
                    {
                        cell[i - 1][j - 1] = new DataGridViewTextBoxCell();
                        cell[i - 1][j - 1].Value = this.dataGridView1.Rows[j - 1].Cells[i - 1].Value;
                    }//if
                }//for j
            }//for i
            //Virtual to Real;
            this.dataGridView1.RowCount = QLinesAft;
            this.dataGridView1.RowCount = QColumnsAft;
            for (int i = 1; i <= QLinesAft; i++)
            {
                for (int j = 1; j <= QColumnsAft; j++)
                {
                    if (cell[i - 1][j - 1] is DataGridViewComboBoxCell)
                    {
                        this.dataGridView1.Rows[i - 1].Cells[j - 1] = new DataGridViewComboBoxCell();
                        this.dataGridView1.Rows[i - 1].Cells[j - 1] = (DataGridViewComboBoxCell)cell[i - 1][j - 1];
                    }
                    else if (cell[i - 1][j - 1] is DataGridViewCheckBoxCell)
                    {
                        this.dataGridView1.Rows[i - 1].Cells[j - 1] = new DataGridViewCheckBoxCell();
                        this.dataGridView1.Rows[i - 1].Cells[j - 1] = (DataGridViewCheckBoxCell)cell[i - 1][j - 1];
                    }
                    else
                    {
                        this.dataGridView1.Rows[i - 1].Cells[j - 1].Value = cell[i - 1][j - 1].Value;//.ToString();
                    }//if
                }//for j
            }//for i
            //
            if (CoLHHasContent)
            {
                for (int i = 1; i <= QColumnsAft; i++)
                {
                    this.dataGridView1.Columns[i - 1].HeaderCell.Value = LoCHNew[i - 1];
                }
            }
            if (LoCHHasContent)
            {
                CoLHNew = new string[QLinesAft];
                for (int i = 1; i <= QLinesAft; i++)
                {
                    this.dataGridView1.Rows[i - 1].HeaderCell.Value = CoLHNew[i - 1];
                }
            }
        }//fn TransposeGridSeparately
        private void transposeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch(this.FormCfgMain.ModeTbl_Gui0Inner1Target2){
                case 0:

                    break;
                case 1:

                    break;
                case 2:

                    break;
            }
        }

        private void button_Table_DiscardChanges_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Lines_Add_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Lines_Ins_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Lines_Del_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Lines_MoveSwappingWithUpper_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Lines_MoveSwappingWithLower_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Lines_SortVisaVersa_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Cols_Add_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Cols_Insert_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Cols_Delete_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Cols_MoveSwappingWithLeft_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Cols_MoveSwappingWithRight_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Cols_SortVisaVersa_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Lines_Add_MoveSwappingWithUpper_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Lines_Add_MoveSwappingWithLower_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Lines_Add_MoveSwappingWithLeft_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Lines_Add_MoveSwappingWithRight_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Str_Transpose_Click(object sender, EventArgs e)
        {

        }

        //private void MenuItem_Control_Focus_End_Click(object sender, EventArgs e)
        //{
        //    FocusUp();
        //}

        private void MenuItem_Control_Focus_Up_Click(object sender, EventArgs e)
        {
            FocusUp();
        }
        private void MenuItem_Control_Focus_Down_Click(object sender, EventArgs e)
        {
            FocusDown();
        }
        private void MenuItem_Control_Focus_ToTheLeft_Click(object sender, EventArgs e)
        {
            FocusToTheLeft();
        }
        private void MenuItem_Control_Focus_ToTheRight_Click(object sender, EventArgs e)
        {
            FocusToTheRight();
        }

        private void MenuItem_Control_Focus_ToTheTop_Click(object sender, EventArgs e)
        {
            FocusToTheTop();
        }

        private void MenuItem_Control_Focus_ToBottom_Click(object sender, EventArgs e)
        {
            FocusToBottom();
        }
        private void MenuItem_Control_Focus_Home_Click(object sender, EventArgs e)
        {
            FocusHome();
        }
        private void MenuItem_Control_Focus_End_Click(object sender, EventArgs e)
        {
            FocusToTheEnd();
        }

        private void MenuItem_Control_Focus_ToStart_Click(object sender, EventArgs e)
        {
            FocusToStart();
        }

        private void MenuItem_Control_Focus_ToFinalCell_Click(object sender, EventArgs e)
        {
            FocusToTheFinalCell();
        }

        private void MenuItem_Control_InfoVolume_Expand_FromUp_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Control_InfoVolume_Expand_FromDown_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Control_InfoVolume_Expand_FromTheLeft_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Control_InfoVolume_Expand_FromTheRight_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Control_InfoVolume_Compress_FromUp_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Control_InfoVolume_Compress_FromDown_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Control_InfoVolume_Compress_FromTheLeft_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Control_InfoVolume_Compress_FromTheRight_Click(object sender, EventArgs e)
        {

        }

        

        private void MenuItem_Settings_UssagePolicy_Click(object sender, EventArgs e)
        {
            TTable tbl = this.TblInf.UssagePolicy.GetAsTable();
            this.DataTopic.DataTopicN = 0;
            this.DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            this.DataTopic.DataN = TableConsts.SettingsTable_UssagePolicy_DataN;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetUssagePolicy(UsePol);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(tbl, this.DataTopic);
            TF.Show();
        }
        public void ToShow()
        {
            this.comboBox_ContentItem.Text = TableConsts.TableDataComponent_ContentCell;
            //ShowTableControlsAccordingToUssagePolicy(); //is in ShowTable
            ShowTable();
        }
        public void Refresh()
        {
            ToShow();
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void MenuItem_Settings_SetReprText_SimpleTable_Click(object sender, EventArgs e)
        {
            this.TblInf.Repr_Text.Set_Simple();
        }

        private void MenuItem_Settings_SetReprText_SimpleNumerated_Click(object sender, EventArgs e)
        {
            this.TblInf.Repr_Text.Set_SimpleNumerated();
        }

        private void MenuItem_Settings_SetReprText_Matrix_Click(object sender, EventArgs e)
        {
            this.TblInf.Repr_Text.Set_Matrix();
        }

        private void MenuItem_Settings_SetReprText_2ArgsFn_Click(object sender, EventArgs e)
        {
            this.TblInf.Repr_Text.Set_2ArgsFn();
        }

        private void MenuItem_Settings_ReprText_ReprGeneral_Click(object sender, EventArgs e)
        {
            TTable tbl = this.TblInf.Repr_Text.dets.GenRepr.GetAsTable();
            this.DataTopic.DataTopicN = 0;
            this.DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            this.DataTopic.DataN = TableConsts.SettingsTable_Repr_TableGen_Text_DataN;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetUssagePolicy(UsePol);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(tbl, this.DataTopic);
            TF.Show();
        }

        private void MenuItem_Settings_ReprText_LineHeaderRepr_Click(object sender, EventArgs e)
        {
            TTable tbl = this.TblInf.Repr_Text.dets.LineHeaderRepr.GetAsTable();
            this.DataTopic.DataTopicN = 0;
            this.DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            this.DataTopic.DataN = TableConsts.SettingsTable_Repr_ColOfLineHeader_Text_DataN;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetUssagePolicy(UsePol);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(tbl, this.DataTopic);
            TF.Show();
        }

        private void MenuItem_Settings_ReprText_ColHeaderRepr_Click(object sender, EventArgs e)
        {
            TTable tbl = this.TblInf.Repr_Text.dets.ColHeaderRepr.GetAsTable();
            this.DataTopic.DataTopicN = 0;
            this.DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            this.DataTopic.DataN = TableConsts.SettingsTable_Repr_LineOfColHeader_Text_DataN;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetUssagePolicy(UsePol);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(tbl, this.DataTopic);
            TF.Show();
        }

        private void MenuItem_Settings_ReprText_ContentCellRepr_Click(object sender, EventArgs e)
        {
            TTable tbl = this.TblInf.Repr_Text.dets.ContentRepr.GetMainAsTable();
            this.DataTopic.DataTopicN = 0;
            this.DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            this.DataTopic.DataN = TableConsts.SettingsTable_Repr_ContentCell_Text_DataN;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetUssagePolicy(UsePol);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(tbl, this.DataTopic);
            TF.Show();
        }

        private void MenuItem_Settings_ReprText_LHOfCntCellRepr_Click(object sender, EventArgs e)
        {
            TTable tbl = this.TblInf.Repr_Text.dets.ContentRepr.GetLineHeaderReprAsTable();
            this.DataTopic.DataTopicN = 0;
            this.DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            this.DataTopic.DataN = TableConsts.SettingsTable_Repr_ColOfLineHeader_OfContentCell_Text_DataN;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetUssagePolicy(UsePol);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(tbl, this.DataTopic);
            TF.Show();
        }

        private void MenuItem_Srttings_ReprText_CHOfCntCellRepr_Click(object sender, EventArgs e)
        {
            TTable tbl = this.TblInf.Repr_Text.dets.ContentRepr.GetColHeaderReprAsTable();
            this.DataTopic.DataTopicN = 0;
            this.DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            this.DataTopic.DataN = TableConsts.SettingsTable_Repr_LineOfColHeader_OfContentCell_Text_DataN;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetUssagePolicy(UsePol);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(tbl, this.DataTopic);
            TF.Show();
        }

        private void MenuItem_Settings_SetReprGrid_SimpleTable_Click(object sender, EventArgs e)
        {
            this.TblInf.Repr_Grid.Set_Simple();
        }

        private void MenuItem_Settings_SetReprGrid_SimpleNumerated_Click(object sender, EventArgs e)
        {
            this.TblInf.Repr_Grid.Set_SimpleNumerated();
        }

        private void MenuItem_Settings_SetReprGrid_Matrix_Click(object sender, EventArgs e)
        {
            this.TblInf.Repr_Grid.Set_Matrix();
        }

        private void MenuItem_Settings_SetReprGrid_2ArgsFn_Click(object sender, EventArgs e)
        {
            this.TblInf.Repr_Grid.Set_2ArgsFn();
        }

        private void MenuItem_Settings_ReprGrid_ReprGeneral_Click(object sender, EventArgs e)
        {
            TTable tbl = this.TblInf.Repr_Grid.dets.GenRepr.GetAsTable();
            this.DataTopic.DataTopicN = 0;
            this.DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            this.DataTopic.DataN = TableConsts.SettingsTable_Repr_TableGen_Grid_DataN;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetUssagePolicy(UsePol);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(tbl, this.DataTopic);
            TF.Show();
        }

        private void MenuItem_Settings_ReprGrid_LineHeaderRepr_Click(object sender, EventArgs e)
        {
            TTable tbl = this.TblInf.Repr_Grid.dets.LineHeaderRepr.GetAsTable();
            this.DataTopic.DataTopicN = 0;
            this.DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            this.DataTopic.DataN = TableConsts.SettingsTable_Repr_ColOfLineHeader_Grid_DataN;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetUssagePolicy(UsePol);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(tbl, this.DataTopic);
            TF.Show();
        }

        private void MenuItem_Settings_ReprGrid_ColHeaderRepr_Click(object sender, EventArgs e)
        {
            TTable tbl = this.TblInf.Repr_Grid.dets.ColHeaderRepr.GetAsTable();
            this.DataTopic.DataTopicN = 0;
            this.DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            this.DataTopic.DataN = TableConsts.SettingsTable_Repr_LineOfColHeader_Grid_DataN;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetUssagePolicy(UsePol);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(tbl, this.DataTopic);
            TF.Show();
        }

        private void MenuItem_Settings_ReprGrid_ContentCellRepr_Click(object sender, EventArgs e)
        {
            TTable tbl = this.TblInf.Repr_Grid.dets.ContentRepr.GetMainAsTable();
            this.DataTopic.DataTopicN = 0;
            this.DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            this.DataTopic.DataN = TableConsts.SettingsTable_Repr_ContentCell_Grid_DataN;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetUssagePolicy(UsePol);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(tbl, this.DataTopic);
            TF.Show();
        }

        private void MenuItem_Settings_ReprGrid_LHOfCntCellRepr_Click(object sender, EventArgs e)
        {
            TTable tbl = this.TblInf.Repr_Grid.dets.ContentRepr.GetLineHeaderReprAsTable();
            this.DataTopic.DataTopicN = 0;
            this.DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            this.DataTopic.DataN = TableConsts.SettingsTable_Repr_ColOfLineHeader_OfContentCell_Grid_DataN;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetUssagePolicy(UsePol);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(tbl, this.DataTopic);
            TF.Show();
        }

        private void MenuItem_Settings_ReprGrid_CHOfCntCellRepr_Click(object sender, EventArgs e)
        {
            TTable tbl = this.TblInf.Repr_Grid.dets.ContentRepr.GetColHeaderReprAsTable();
            this.DataTopic.DataTopicN = 0;
            this.DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            this.DataTopic.DataN = TableConsts.SettingsTable_Repr_LineOfColHeader_OfContentCell_Grid_DataN;
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.ForbidToShowAndEditSettings();
            tbl.SetUssagePolicy(UsePol);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(tbl, this.DataTopic);
            TF.Show();
        }


        private void MenuItem_Settings_ReprText_WriteToTable_UssagePolicy_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1=1;
            TableInfo_ConcrRepr TblInf=TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null) CurrentTable.SetUssagePolicy(this.TblInf.UssagePolicy);
        }

        private void MenuItem_Settings_ReprText_WriteToTable_Whole_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null) CurrentTable.SetRepresentation_Text(this.TblInf.GetRepresentation_Text());
        }

        private void MenuItem_Settings_ReprText_WriteToTable_General_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null){
                //CurrentTable.SetReprTextGen(this.TblInf.GetGeneralRepr());
                CurrentTable.SetRepresentationGeneral_Text(this.TblInf.GetGeneralRepresentation_Text());
            }
        }

        private void MenuItem_Settings_ReprText_WriteToTable_LineHeader_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                CurrentTable.SetLineHeaderCellRepresentation_Text(this.TblInf.GetLineHeaderCellRepresentation_Text());
            }
        }

        private void MenuItem_Settings_ReprText_WriteToTable_ColHeader_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                CurrentTable.SetColHeaderCellRepresentation_Text(this.TblInf.GetColHeaderCellRepresentation_Text());
            }
        }

        private void MenuItem_Settings_ReprText_WriteToTable_ContentCell_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                CurrentTable.SetContentCellRepresentation_Text(this.TblInf.GetContentCellRepresentation_Text());
            }
        }

        private void MenuItem_Settings_ReprText_WriteToTable_LHOfCntCell_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                CurrentTable.SetContentCellLineHeaderRepresentation_Text(this.TblInf.GetContentCellLineHeaderRepresentation_Text());
            }
        }

        private void MenuItem_Settings_ReprText_WriteToTable_СHOfCntC_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                CurrentTable.SetContentCellColumnHeaderRepresentation_Text(this.TblInf.GetContentCellColumnHeaderRepresentation_Text());
            }
        }
        //
        private void MenuItem_Settings_ReprGrid_WriteToTable_UssagePolicy_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 =0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null) CurrentTable.SetUssagePolicy(this.TblInf.UssagePolicy);
        }

        private void MenuItem_Settings_ReprGrid_WriteToTable_Whole_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null) CurrentTable.SetRepresentation_Grid(this.TblInf.GetRepresentation_Grid());
        }

        private void MenuItem_Settings_ReprGrid_WriteToTable_General_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                //CurrentTable.SetReprGridGen(this.TblInf.GetGeneralRepr());
                CurrentTable.SetRepresentationGeneral_Grid(this.TblInf.GetGeneralRepresentation_Grid());
            }
        }

        private void MenuItem_Settings_ReprGrid_WriteToTable_LineHeader_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                CurrentTable.SetLineHeaderCellRepresentation_Grid(this.TblInf.GetLineHeaderCellRepresentation_Grid());
            }
        }

        private void MenuItem_Settings_ReprGrid_WriteToTable_ColHeader_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                CurrentTable.SetColHeaderCellRepresentation_Grid(this.TblInf.GetColHeaderCellRepresentation_Grid());
            }
        }

        private void MenuItem_Settings_ReprGrid_WriteToTable_ContentCell_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                CurrentTable.SetContentCellRepresentation_Grid(this.TblInf.GetContentCellRepresentation_Grid());
            }
        }

        private void MenuItem_Settings_ReprGrid_WriteToTable_LHOfCntCell_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                CurrentTable.SetContentCellLineHeaderRepresentation_Grid(this.TblInf.GetContentCellLineHeaderRepresentation_Grid());
            }
        }

        private void MenuItem_Settings_ReprGrid_WriteToTable_СHOfCntC_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                CurrentTable.SetContentCellColumnHeaderRepresentation_Grid(this.TblInf.GetContentCellColumnHeaderRepresentation_Grid());
            }
        }

        private void MenuItem_Settings_ReprText_SetFromTable_UssagePolicy_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                CurrentTable.SetContentCellColumnHeaderRepresentation_Grid(this.TblInf.GetContentCellColumnHeaderRepresentation_Grid());
            }
        }

        private void MenuItem_Settings_ReprText_SetFromTable_Whole_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                //this.TblInf.Repr_Text = (TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1)).GetRepresentation();
                this.TblInf.Repr_Text = TblInf.GetRepresentation();
            }
        }

        private void MenuItem_Settings_ReprText_SetFromTable_General_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                //this.TblInf.Repr_Text = (TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1)).GetRepresentation();
                this.TblInf.Repr_Text.dets.GenRepr = TblInf.GetGeneralRepresentation();
            }
        }

        private void MenuItem_Settings_ReprText_SetFromTable_LineHeader_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                this.TblInf.Repr_Text.dets.LineHeaderRepr= TblInf.GetLineHeaderCellRepresentation();
            }
        }

        private void MenuItem_Settings_ReprText_SetFromTable_ColHeader_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                this.TblInf.Repr_Text.dets.LineHeaderRepr = TblInf.GetColHeaderCellRepresentation();
            }
        }

        private void MenuItem_Settings_ReprText_SetFromTable_ContentCell_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                this.TblInf.Repr_Text.dets.ContentRepr= TblInf.GetContentCellRepresentation();
            }
        }

        private void MenuItem_Settings_ReprText_SetFromTable_LHOfCntCell_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                this.TblInf.Repr_Text.dets.ContentRepr.LineHeader = TblInf.GetContentCellLineHeaderRepresentation();
            }
        }

        private void MenuItem_Settings_ReprText_SetFromTable_CHOfCntCell_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 1;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                this.TblInf.Repr_Text.dets.ContentRepr.LineHeader = TblInf.GetContentCellColumnHeaderRepresentation();
            }
        }

        private void MenuItem_Settings_ReprGrid_SetFromTable_Whole_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                //this.TblInf.Repr_Text = (TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1)).GetRepresentation();
                this.TblInf.Repr_Grid = TblInf.GetRepresentation();
            }
        }

        private void MenuItem_Settings_ReprGrid_SetFromTable_General_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                //this.TblInf.Repr_Text = (TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1)).GetRepresentation();
                this.TblInf.Repr_Grid.dets.GenRepr = TblInf.GetGeneralRepresentation();
            }
        }

        private void MenuItem_Settings_ReprGrid_SetFromTable_LineHeader_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                this.TblInf.Repr_Text.dets.LineHeaderRepr = TblInf.GetLineHeaderCellRepresentation();
            }
        }

        private void MenuItem_Settings_ReprGrid_SetFromTable_ColHeader_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                this.TblInf.Repr_Text.dets.ColHeaderRepr = TblInf.GetColHeaderCellRepresentation();
            }
        }

        private void MenuItem_Settings_ReprGrid_SetFromTable_ContentCell_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                this.TblInf.Repr_Grid.dets.ContentRepr = TblInf.GetContentCellRepresentation();
            }
        }

        private void MenuItem_Settings_ReprGrid_SetFromTable_LHOfCntCell_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                this.TblInf.Repr_Grid.dets.ContentRepr.LineHeader = TblInf.GetContentCellLineHeaderRepresentation();
            }
        }

        private void MenuItem_Settings_ReprGrid_SetFromTable_CHOfCntCell_Click(object sender, EventArgs e)
        {
            int Repr_Grid0Text1 = 0;
            TableInfo_ConcrRepr TblInf = TargetTable.GetTableInfo_ConcrRepr(Repr_Grid0Text1);
            if (TblInf != null)
            {
                this.TblInf.Repr_Grid.dets.ContentRepr.ColHeader = TblInf.GetContentCellColumnHeaderRepresentation();
            }
        }

        private void MenuItem_Settings_ReprExchng_Swap_General_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Settings_ReprExchng_Swap_LineHeader_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Settings_ReprExchng_Swap_ColHeader_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Settings_ReprExchng_Swap_ContentCell_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Settings_ReprExchng_Swap_LHOfCntCell_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Settings_ReprExchng_Swap_CHOfCntCell_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Settings_ReprExchng_AssignTextByGrid_General_Click(object sender, EventArgs e)
        {
            if (this.TblInf != null)
            {
                if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
                if(this.TblInf.Repr_Text.dets.GenRepr==null) this.TblInf.Repr_Text.dets.GenRepr=new TableGeneralRepresentation();
                if (this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets.GenRepr != null) TblInf.Repr_Text.dets.GenRepr = (TableGeneralRepresentation)TblInf.Repr_Grid.dets.GenRepr.Clone();
            }
        }

        private void MenuItem_Settings_ReprExchng_AssignTextByGrid_LineHeader_Click(object sender, EventArgs e)
        {
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            if (this.TblInf.Repr_Text.dets.LineHeaderRepr == null) this.TblInf.Repr_Text.dets.LineHeaderRepr = new TableHeaderCellRepresentation();
            if (this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets.LineHeaderRepr != null) TblInf.Repr_Text.dets.LineHeaderRepr = (TableHeaderCellRepresentation)TblInf.Repr_Grid.dets.LineHeaderRepr.Clone();
        }

        private void MenuItem_Settings_ReprExchng_AssignTextByGrid_ColHeader_Click(object sender, EventArgs e)
        {
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            if (this.TblInf.Repr_Text.dets.ColHeaderRepr == null) this.TblInf.Repr_Text.dets.ColHeaderRepr = new TableHeaderCellRepresentation();
            if (this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets.ColHeaderRepr != null) TblInf.Repr_Text.dets.ColHeaderRepr = (TableHeaderCellRepresentation)TblInf.Repr_Grid.dets.ColHeaderRepr.Clone();
        }

        private void MenuItem_Settings_ReprExchng_AssignTextByGrid_ContentCell_Click(object sender, EventArgs e)
        {
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            if (this.TblInf.Repr_Text.dets.ContentRepr == null) this.TblInf.Repr_Text.dets.ContentRepr = new TableContentCellRepresentation();
            if (this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets.ContentRepr != null) TblInf.Repr_Text.dets.ContentRepr = (TableContentCellRepresentation)TblInf.Repr_Grid.dets.ContentRepr.Clone();
        }

        private void MenuItem_Settings_ReprExchng_AssignTextByGrid_LHOfCntCell_Click(object sender, EventArgs e)
        {
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            if (this.TblInf.Repr_Text.dets.ContentRepr == null) this.TblInf.Repr_Text.dets.ContentRepr = new TableContentCellRepresentation();
            if (this.TblInf.Repr_Text.dets.ContentRepr.LineHeader == null) this.TblInf.Repr_Text.dets.ContentRepr.LineHeader = new TableHeaderCellRepresentation();
            if (this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets.ContentRepr.LineHeader != null) TblInf.Repr_Text.dets.ContentRepr.LineHeader = (TableHeaderCellRepresentation)TblInf.Repr_Grid.dets.ContentRepr.LineHeader.Clone();
        }

        private void MenuItem_Settings_ReprExchng_AssignTextByGrid_CHOfCntCell_Click(object sender, EventArgs e)
        {
            if (this.TblInf.Repr_Text == null) this.TblInf.Repr_Text = new TableRepresentation();
            if (this.TblInf.Repr_Text.dets.ContentRepr == null) this.TblInf.Repr_Text.dets.ContentRepr = new TableContentCellRepresentation();
            if (this.TblInf.Repr_Text.dets.ContentRepr.ColHeader == null) this.TblInf.Repr_Text.dets.ContentRepr.ColHeader = new TableHeaderCellRepresentation();
            if (this.TblInf.Repr_Grid != null && this.TblInf.Repr_Grid.dets.ContentRepr.ColHeader != null) TblInf.Repr_Text.dets.ContentRepr.ColHeader = (TableHeaderCellRepresentation)TblInf.Repr_Grid.dets.ContentRepr.ColHeader.Clone();
        }

        private void MenuItem_Settings_ReprExchng_AssignGridByText_General_Click(object sender, EventArgs e)
        {
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            if (this.TblInf.Repr_Grid.dets.GenRepr == null) this.TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            if (this.TblInf.Repr_Text != null) TblInf.Repr_Grid.dets.GenRepr = (TableGeneralRepresentation)TblInf.Repr_Text.dets.GenRepr.Clone();
        }

        private void MenuItem_Settings_ReprExchng_AssignGridByText_LineHeader_Click(object sender, EventArgs e)
        {
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            if (this.TblInf.Repr_Grid.dets.ContentRepr == null) this.TblInf.Repr_Grid.dets.LineHeaderRepr = new TableHeaderCellRepresentation();
            if (this.TblInf.Repr_Text != null) TblInf.Repr_Grid.dets.LineHeaderRepr = (TableHeaderCellRepresentation)TblInf.Repr_Text.dets.LineHeaderRepr.Clone();
        }

        private void MenuItem_Settings_ReprExchng_AssignGridByText_ColHeader_Click(object sender, EventArgs e)
        {
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            if (this.TblInf.Repr_Grid.dets.ContentRepr == null) this.TblInf.Repr_Grid.dets.ColHeaderRepr = new TableHeaderCellRepresentation();
            if (this.TblInf.Repr_Text != null) TblInf.Repr_Grid.dets.ColHeaderRepr = (TableHeaderCellRepresentation)TblInf.Repr_Text.dets.ColHeaderRepr.Clone();
        }

        private void MenuItem_Settings_ReprExchng_AssignGridByText_ContentCell_Click(object sender, EventArgs e)
        {
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            if (this.TblInf.Repr_Grid.dets.ContentRepr == null) this.TblInf.Repr_Grid.dets.ContentRepr = new TableContentCellRepresentation();
            if (this.TblInf.Repr_Text != null) TblInf.Repr_Grid.dets.ContentRepr = (TableContentCellRepresentation)TblInf.Repr_Text.dets.ContentRepr.Clone();
        }

        private void MenuItem_Settings_ReprExchng_AssignGridByText_LHOfCntCell_Click(object sender, EventArgs e)
        {
            if (this.TblInf.Repr_Grid == null) this.TblInf.Repr_Grid = new TableRepresentation();
            if (this.TblInf.Repr_Grid.dets.ContentRepr == null) this.TblInf.Repr_Grid.dets.ContentRepr = new TableContentCellRepresentation();
            if (this.TblInf.Repr_Grid.dets.ContentRepr.LineHeader == null) this.TblInf.Repr_Grid.dets.ContentRepr.LineHeader = new TableHeaderCellRepresentation();
            if (this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.dets.ContentRepr.LineHeader != null) TblInf.Repr_Grid.dets.ContentRepr.LineHeader = (TableHeaderCellRepresentation)TblInf.Repr_Text.dets.ContentRepr.LineHeader.Clone();
        }

        private void MenuItem_Settings_ReprExchng_AssignGridByText_CHOfCntCell_Click(object sender, EventArgs e)
        {
            if (this.TblInf.Repr_Grid== null) this.TblInf.Repr_Grid = new TableRepresentation();
            if (this.TblInf.Repr_Grid.dets.ContentRepr == null) this.TblInf.Repr_Grid.dets.ContentRepr = new TableContentCellRepresentation();
            if (this.TblInf.Repr_Grid.dets.ContentRepr.ColHeader == null) this.TblInf.Repr_Grid.dets.ContentRepr.ColHeader = new TableHeaderCellRepresentation();
            if (this.TblInf.Repr_Text != null && this.TblInf.Repr_Text.dets.ContentRepr.ColHeader != null) TblInf.Repr_Grid.dets.ContentRepr.ColHeader = (TableHeaderCellRepresentation)TblInf.Repr_Text.dets.ContentRepr.ColHeader.Clone();
        }

        private void MenuItem_Content_ShowText_Click(object sender, EventArgs e)
        {
            this.CurrentTable.Show(this.f1.vsh);
        }
        //
        public void ExpandVisibleRowsUp()
        {
            this.NsToDisplay.AddPrevLineToShow(this.TblInf.RowsQuantities);
            this.ShowTable(null, this.NsToDisplay, this.TblInf);
        }
        public void ExpandVisibleRowsDown()
        {
            this.NsToDisplay.AddNextLineToShow(this.TblInf.RowsQuantities);
            this.ShowTable(null, this.NsToDisplay, this.TblInf);
        }
        public void ExpandVisibleRowsToTheLeft()
        {
            this.NsToDisplay.AddPrevColumnToShow(this.TblInf.RowsQuantities);
            this.ShowTable(null, this.NsToDisplay, this.TblInf);
        }
        public void ExpandVisibleRowsToTheRight()
        {
            this.NsToDisplay.AddNextColumnToShow(this.TblInf.RowsQuantities);
            this.ShowTable(null, this.NsToDisplay, this.TblInf);
        }
        //
        public void CompressVisibleRowsFromUpToDown()
        {
            this.NsToDisplay.ExcludeLineFromForwardFromShown(this.TblInf.RowsQuantities);
            this.ShowTable(null, this.NsToDisplay, this.TblInf);
        }
        public void CompressVisibleRowsFromDownToUp()
        {
            this.NsToDisplay.ExcludeLineFromBackwardFromShown(this.TblInf.RowsQuantities);
            this.ShowTable(null, this.NsToDisplay, this.TblInf);
        }
        public void CompressVisibleRowsFromTheLeftToTheRight()
        {
            this.NsToDisplay.ExcludeColumnFromBackwardFromShown(this.TblInf.RowsQuantities);
            this.ShowTable(null, this.NsToDisplay, this.TblInf);
        }
        public void CompressVisibleRowsFromTheRightToTheLeft()
        {
            this.NsToDisplay.ExcludeColumnFromForwardFromShown(this.TblInf.RowsQuantities);
            this.ShowTable(null, this.NsToDisplay, this.TblInf);
        }
        //
        public void MoveCellExchangingWithUpper()
        {

        }
        public void MoveCellExchangingWithLower()
        {

        }
        public void MoveCellExchangingWithLeft()
        {

        }
        public void MoveCellExchangingWithRight()
        {

        }
        //
        public void MoveRowExchangingWithUpper()
        {

        }
        public void MoveRowExchangingWithLower()
        {

        }
        public void MoveRowExchangingWithLeft()
        {

        }
        public void MoveRowExchangingWithRight()
        {

        }
        //
        public void ExpandInsOrAddRowAbove()
        {

        }
        public void ExpandInsOrAddRowBelow()
        {

        }
        public void ExpandInsOrAddRowToTheLeft()
        {

        }
        public void ExpandInsOrAddRowToTheRight()
        {

        }
        //
        public void CompressDelRowAbove()
        {

        }
        public void CompressDelRowBelow()
        {

        }
        public void CompressDelRowAtTheLeft()
        {

        }
        public void CompressDelRowAtTheRight()
        {

        }
        //
        public void ShiftVisibleRowsUp()
        {
            this.NsToDisplay.ShiftLinesBackward(this.TblInf.RowsQuantities);
            this.ShowTable(null, this.NsToDisplay, this.TblInf);
        }
        public void ShiftVisibleRowsDown()
        {
            this.NsToDisplay.ShiftLinesForward(this.TblInf.RowsQuantities);
            this.ShowTable(null, this.NsToDisplay, this.TblInf);
        }
        public void ShiftVisibleRowsToTheLeft()
        {
            this.NsToDisplay.ShiftColumnsBackward(this.TblInf.RowsQuantities);
            this.ShowTable(null, this.NsToDisplay, this.TblInf);
        }
        public void ShiftVisibleRowsToTheRight()
        {
            this.NsToDisplay.ShiftColumnsForward(this.TblInf.RowsQuantities);
            this.ShowTable(null, this.NsToDisplay, this.TblInf);
        }
        //

        

        
       

        
       

       

        
        
        
    }//cl
}//ns   //2021-05-18