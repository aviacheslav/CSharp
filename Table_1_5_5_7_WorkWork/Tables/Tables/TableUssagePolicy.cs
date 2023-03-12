using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    public class TableUssagePolicy:ICloneable //cl 16 
    {
        //public int Rows, Columns, Content, Both;
        public bool LinesCanAdd, LinesCanDel, LinesCanIns, LinesCanReplace;
        public bool ColumnsCanAdd, ColumnsCanDel, ColumnsCanIns, ColumnsCanReplace;
        public bool BothCanAdd, BothCanDel, BothCanIns, BothCanReplace;
        public bool LH_Can_Edit, CH_Can_Edit, ContentsCanEdit;
        //public bool ContentLinesSepCanAdd, ContentLinesSepCanDel, ContentLinesSepCanIns, ContentLinesSepCanReplace;
        bool ContentLinesSeparatelyCanEdit; //means also all 4 commented
        public bool ContentCellsCanReplace;
        public bool SettingsBrowsingIsAllowed;
        public bool SettingsEditingIsAllowed;
        public TableUssagePolicy()
        {
            AllowAll();
            SettingsBrowsingIsAllowed=true;
            SettingsEditingIsAllowed=false;
        }
        public object Clone() { return this.MemberwiseClone(); }
        public void AllowAll()
        {
            LinesCanAdd = true; LinesCanDel = true; LinesCanIns = true; LinesCanReplace = true;
            ColumnsCanAdd = true; ColumnsCanDel = true; ColumnsCanIns = true; ColumnsCanReplace = true;
            BothCanAdd = true; BothCanDel = true; BothCanIns = true; BothCanReplace = true;
            ContentCellsCanReplace = true;
            LH_Can_Edit = true; CH_Can_Edit = true; ContentsCanEdit = true;
        }
        public void ForbidAll()
        {
            LinesCanAdd = false; LinesCanDel = false; LinesCanIns = false; LinesCanReplace = false;
            ColumnsCanAdd = false; ColumnsCanDel = false; ColumnsCanIns = false; ColumnsCanReplace = false;
            BothCanAdd = false; BothCanDel = false; BothCanIns = false; BothCanReplace = false;
            ContentCellsCanReplace = false;
            LH_Can_Edit = false; CH_Can_Edit = false; ContentsCanEdit = false;
        }
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
        }
        //
        public void ForbidToShowAndEditSettings()
        {
            SettingsBrowsingIsAllowed = false;
            SettingsEditingIsAllowed = false;
        }
        //
        public TTable GetAsTable()
        {
            DataCellRowCoHeader[] rows=new DataCellRowCoHeader[18];
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
            rows[16 - 1] = new DataCellRowCoHeader(new DataCell("ContentCellsCanReplace"), new DataCellRow(new DataCell(ContentCellsCanReplace)));
            //
            rows[17 - 1] = new DataCellRowCoHeader(new DataCell("SettingsBrowsingIsAllowed"), new DataCellRow(new DataCell(SettingsBrowsingIsAllowed)));
            rows[18 - 1] = new DataCellRowCoHeader(new DataCell("SettingsEditingIsAllowed"), new DataCellRow(new DataCell(SettingsEditingIsAllowed)));
            TTable tbl=new TTable(
                new TableInfo(true, true, true, 18, 1),
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
            ContentCellsCanReplace = tbl.GetBoolVal(16, 1);
            //
            //rows[17 - 1] = new DataCellRowCoHeader(new DataCell("SettingsBrowsingIsAllowed"), new DataCellRow(new DataCell(SettingsBrowsingIsAllowed)));
            SettingsBrowsingIsAllowed = tbl.GetBoolVal(17, 1);
            //rows[18 - 1] = new DataCellRowCoHeader(new DataCell("SettingsEditingIsAllowed"), new DataCellRow(new DataCell(SettingsEditingIsAllowed)));
            SettingsEditingIsAllowed = tbl.GetBoolVal(18, 1);
            //TTable tbl = new TTable(
            //    new TableInfo(true, true, true, 16, 1),
            //    false,
            //    rows,
            //    new DataCellRow(new DataCell("Values")),
            //    new TableHeaders(new DataCell("Table Ussage Policy"), new DataCell("Params"), new DataCell("")),
            //    true
            //);
            ////tbl
            //return tbl;
        }
    }//cl 16 TableUssagePolicy
}//ns   //2020-08-12
