using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Tables
{
    public class Form_TableCalling:Form
    {
        public TTable CurrentTable;
        public TableDataChange DataTopic;
        //
        public TValsShowHide vsh;
        public TableReadingTypesParams GridReadParams;
        public TableFormAndGridConfigurationMain FormCfgAll;
        //
        public void SetDataFromCurrentTable(TableDataChange dataId)
        {

        }
        public TableDataChange GetTableDataChange() { return this.DataTopic; }
        public TableFormAndGridConfigurationMain GetTableFormAndGridConfigurationMain() { return this.FormCfgAll; }
    }
}
