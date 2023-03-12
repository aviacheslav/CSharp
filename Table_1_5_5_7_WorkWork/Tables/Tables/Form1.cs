using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using System.Data.SQLite; // SQLite s' ne member of System.Data; are you missing an assembly reference?
using System.Data.OleDb;
//using System.Drawing;
using System.Diagnostics;
using System.IO;
//using System.Collections.Generic;
//
//mark1 - 944
//mark2 - 1574
//mark3 - 2729
//fin- 3474
//
namespace Tables
{
    public partial class Form1 : Form_TableCalling//Form
    {
        //TableForm UniTbl;
        //PolynomialEquation PolyEq;//older  //2021.08.09 - commented
        public  PolynomialEqSolver PolyEqSlvr;
        //TableFormAndGridConfigurationGeneral TblFormAndGridConfig=null;
        public TTable T1, T2, T3;
        public TTable Tbl_FormAndGridConfig = null;
        public TTable CurrentTable = null; //so wu > gut, ma I ne abl img'tr, qy fa so.
        //public TTable PolyEqSolverIniDataTbl, PolyEqSolverSolutionTbl, M1Tbl, M2Tbl, M3Tbl, M4Tbl, AnyTbl;
        //Form2 form2 = new Form2();
        //TableFormAndGridConfigurationMain FormCfgMain;
        //CellsNsToDisplay CellsNsToDispl;
        TableFormAndGridConfigurationMain FormCfgAll;
        public TableReadingTypesParams GridReadParams;
        public TableDataChange DataTopic;//
        //
        public MatrixCalculator MatrCalc;
        //public PrimitivePipeLine PipeLinePrimitive;//
        public ExcelHandler excel;
        //
        public TValsShowHide vsh; //2021.08.09 - made public
        public TTablesConcatRules TableConcatRules;
        //
        SQLiteConnection dbc;
        //
        public Form1()
        {
            InitializeComponent();
            //
            //UniTbl = new TableForm();
            //PolyEq = new PolynomialEquation();  //2021.08.09 - commented
            PolyEqSlvr = new PolynomialEqSolver();
            MatrCalc = new MatrixCalculator();
           // PipeLinePrimitive = new PrimitivePipeLine();
            //
            //TableFormAndGridConfigurationAll TblFormAndGridConfig = new TableFormAndGridConfigurationAll();
            //Tbl_FormAndGridConfig = TblFormAndGridConfig.GetAsTable();
            //
            //FormCfgMain = new TableFormAndGridConfigurationMain();
            //CellsNsToDispl = new CellsNsToDisplay();
            FormCfgAll = new TableFormAndGridConfigurationMain();
            GridReadParams = new TableReadingTypesParams();
            DataTopic = new TableDataChange();
            //
            //PolyEqSolverIniDataTbl = PolyEqSlvr.GetEquationAsTable();
            //PolyEqSolverSolutionTbl = PolyEqSlvr.GetSolutionAsTable();
            //
            vsh = new TValsShowHide();
            vsh.box = this.listBox1;
            //
            T1 = new TTable();
            T2 = new TTable();
            //
            TableConcatRules = new TTablesConcatRules();
            //
            //excel = new ExcelHandler();
            excel = null;
        }
        //
        public TableDataChange GetTableDataChange() { return this.DataTopic; }
        public void SetTableDataChange(TableDataChange DataTopic) { if (DataTopic != null) this.DataTopic = DataTopic; }
        public TableFormAndGridConfigurationMain GetTableFormAndGridConfigurationMain() { return this.FormCfgAll; }
        public void SetTableFormAndGridConfigurationMain(TableFormAndGridConfigurationMain FormCfgAll) { if (FormCfgAll != null) this.FormCfgAll = FormCfgAll; }
        //
        private void MenuItem_Test_MatrixCalculator_Click(object sender, EventArgs e)
        {

        }
        private void MenuItem_PolyEqSlv_InitialData_Click(object sender, EventArgs e)
        {
            /*TableForm UniTbl = new TableForm(); //ce new
            //
            UniTbl.TargetTable = PolyEq.IniDataToTable();
            TValsShowHide vsh = new TValsShowHide(1, 0, null, listBox1);
            UniTbl.TargetTable.Show(vsh);*/
            //
            //TableDataChange DataTopic = new TableDataChange();
            //
            DataTopic.DataTopicN = 1;
            DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 1;
            DataTopic.DataN = 1;
            TableForm UniTbl = new TableForm(this);
            CurrentTable = PolyEqSlvr.GetEquationAsTable();
            //UniTbl.AcceptTable(PolyEqSlvr.GetEquationAsTable());
            UniTbl.AcceptTable(CurrentTable, DataTopic); //GridCfg=null, ReadGrid=null, Ns=null, Inf=null
            UniTbl.Show();
            //if(UniTbl.ChangesMade)PolyEqSlvr.SetFromTable(CurrentTable);
        }
        //
        private void quadraticPolynomialEqNoTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TValsShowHide vsh;
            PolynomialEquation polyeq;
            double[] c;
            c = new double[3];
            c[0] = 1;
            c[1] = 4;
            c[2] = 4;
            vsh = new TValsShowHide();
            vsh.box = listBox1;
            vsh.EnableWriting();
            polyeq = new PolynomialEquation();
            polyeq.Set(2, c);
            MyLib.writeln(vsh,"Equation coefs:");
            polyeq.ShowIniData(vsh);
            polyeq.ShowResults(vsh);
            polyeq.Solve();
            MyLib.writeln(vsh,"Equation coefs:");
            polyeq.ShowResults(vsh);
        }
       
        private void MenuItem_PolyEqSlv_Solution_Click(object sender, EventArgs e)
        {
            TableForm UniTbl = new TableForm(this); 
            //
            PolyEqSlvr.Solve(); // PolyEq.Solve();
            //UniTbl.TargetTable = PolyEq.ResultsToTable(); //ce gut! Ma umda work't aic vrn! Ne del hic vrn, let's try it later!
            CurrentTable = PolyEqSlvr.GetSolutionAsTable(); //CurrentTable = PolyEq.ResultsToTable();
            TValsShowHide vsh = new TValsShowHide(1, 0, null, listBox1);
            UniTbl.AcceptTable(CurrentTable, null); // null ob noam save
            //hin: data=null, GridCfg=null, readGrid=null, Ns=null, Inf=null
            UniTbl.Show();
            //UniTbl.TargetTable.Show(vsh);//ce also gutn et mus be, let's decomment it later
        }

        private void matrixToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Matrix M=new Matrix();
            TTable tbl = new TTable();
            int QLines=4, QColumns=5;
            double[][]x;
            x=new double[QLines][];
            for(int i=1; i<=QLines; i++){
                x[i-1]=new double[QColumns];
                for(int j=1; j<=QColumns; j++){
                    x[i-1][j-1]=10*i+j;
                }
            }
            M.Set(x, QLines, QColumns);
            tbl.SetTableAs_Matrix(M);
            tbl.SetTableHeader(new DataCell("M"));
            TValsShowHide vsh = new TValsShowHide(1, 0, null, listBox1);
            //
            MyLib.writeln(vsh, "M Table Simple");
            //tbl.ReprSet_Simple();
            tbl.Repr_Text_Set_Simple();
            tbl.Show(vsh);
            MyLib.writeln(vsh, "M Table Simply Numerated");
            //tbl.ReprSet_SimpleNumerated(3);
            tbl.Repr_Text_Set_SimpleNumerated(3);
            tbl.Show(vsh);
            //tbl.ReprSet_Matrix();
            tbl.Repr_Text_Set_Matrix();
            MyLib.writeln(vsh, "M Table as Matrix");
            tbl.Show(vsh);
            //tbl.ReprSet_Matrix();
            tbl.Repr_Text_Set_Matrix();
            //MessageBox.Show("Now Be Attentive!");
            MyLib.writeln(vsh, "M Table as 2-args function");
            //tbl.ReprSet_2ArgsFn();
            tbl.Repr_Text_Set_2ArgsFn();
            tbl.Show(vsh); 
            //
            tbl.Show(vsh);
        }

        private void aeroDynTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TableForm UniTbl = new TableForm(); //ce new
            TableForm UniTbl = new TableForm(this); //ce newest
            //
            //string NameToShow="Coef of lifting force";
            string NameToShow = "Cy";
            string NameToRequest="Cy";
            string[]arr={NameToShow, NameToRequest};
            string CGName="alfa";
            string LGName="M";
            double[] M = { 0.1, 0.2, 0.8, 0.9 };
            double[] alfa = { -2, 0, 1, 2, 15 };
            int QLines = M.Length;
            int QColumns = alfa.Length;
            double[][] Cy = new double[QLines][];
            for (int i = 1; i <= QLines; i++)
            {
                Cy[i - 1] = new double[QColumns];
            }
            for (int i = 1; i <= QLines; i++)
            {
                for (int j = 1; j <= QColumns; j++)
                {
                    Cy[i - 1][j-1] = (i*10+j)/100.0;
                }
            }
            TTable tbl = new TTable();
            DataCellRow curRow;
            DataCellRow[] content=new DataCellRow[1];
            curRow = new DataCellRow(Cy[1-1], QColumns);
            content[1 - 1] = curRow;
            int QL=1;
            for (int i = 2; i <= QLines; i++)
            {
                curRow = new DataCellRow(Cy[i-1], QColumns);
                MyLib.AddToVector(ref content, ref QL, curRow);
            }
            tbl.SetTableAs_2ArgsFunction(
                QLines,
                QColumns,
                true,
                new DataCellRow(M, QLines),
                new DataCellRow(alfa, QColumns),
                content,
                new DataCell(LGName),
                new DataCell(CGName),
                new DataCell(arr, 2)
            );
            //tbl.AddLine(new DataCellRowCoHeader(new DataCell(0.08), new DataCellRow(new double[] { 10, 20, 30, 40, 50 }, tbl.GetQColumns())));
            //tbl.InsLine(1,new DataCellRowCoHeader(new DataCell(0.98), new DataCellRow(new double[]{1, 2, 3, 4, 5}, tbl.GetQColumns())));
            //tbl.InsLine(2,new DataCellRowCoHeader(new DataCell(0.98), new DataCellRow(new double[]{1, 2, 3, 4, 5}, tbl.GetQColumns())));
            //tbl.InsLine(6, new DataCellRowCoHeader(new DataCell(0.98), new DataCellRow(new double[] { 1, 2, 3, 4, 5 }, tbl.GetQColumns())));
            //
            //tbl.AddColumn(new DataCellRowCoHeader(new DataCell(0.08), new DataCellRow(new double[] { 10, 20, 30, 40, 50 }, tbl.GetQColumns())));
            //tbl.InsColumn(1, new DataCellRowCoHeader(new DataCell(0.98), new DataCellRow(new double[] { 1, 2, 3, 4, 5 }, tbl.GetQLines())));
            //tbl.InsColumn(2, new DataCellRowCoHeader(new DataCell(0.98), new DataCellRow(new double[] { 1, 2, 3, 4, 5 }, tbl.GetQLines())));
            //tbl.InsColumn(8, new DataCellRowCoHeader(new DataCell(0.98), new DataCellRow(new double[] { 1, 2, 3, 4, 5 }, tbl.GetQLines())));
            //
            //all these adds and inss work well
            //
            TValsShowHide vsh = new TValsShowHide(1, 0, null, listBox1);
            MyLib.writeln(vsh, "Cy Table as created");
            tbl.Show(vsh);
            MyLib.writeln(vsh, "Cy Table Simple");
            //tbl.ReprSet_Simple();
            tbl.Repr_Text_Set_Simple();
            tbl.Show(vsh);
            //tbl.ReprSet_SimpleNumerated(3);
            tbl.Repr_Text_Set_SimpleNumerated(3);
            tbl.Show(vsh);
            //tbl.ReprSet_Matrix();
            tbl.Repr_Text_Set_Matrix();
            MyLib.writeln(vsh, "Cy Table as Matrix");
            tbl.Show(vsh);
            //tbl.ReprSet_Matrix();
            tbl.Repr_Text_Set_Matrix();
            //MessageBox.Show("Now Be Attentive!");
            MyLib.writeln(vsh, "Cy Table as 2-args function");
            //tbl.ReprSet_2ArgsFn();
            tbl.Repr_Text_Set_2ArgsFn();
            tbl.Show(vsh);
            //
            UniTbl.Show();
            //UniTbl.AcceptTable(tbl);
            //UniTbl.AcceptTable(tbl,/**/null, /**/null,new TableFormAndGridConfigurationAll(this.Tbl_FormAndGridConfig), null);
            UniTbl.AcceptTable(tbl, null, null, null);
            //                      data=null, GridCfg-null, RaadGrid=null, Ns=null, Inf=null
        }
        //
        private void goodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int QGoodsNames = 4, QParamsNames = 3;
            string[] GoodsNames = new string[QGoodsNames];
            string[] CathegoryNames = new string[QParamsNames];
            GoodsNames[1 - 1] = "Smartphone";
            GoodsNames[2 - 1] = "TV-set";
            GoodsNames[3 - 1] = "Refrigerator";
            GoodsNames[4 - 1] = "Notebook";
            CathegoryNames[1 - 1] = "Price";
            CathegoryNames[2 - 1] = "Quantity";
            CathegoryNames[3 - 1] = "Cost";
            string GeneralCathegory = "Values";
            string GeneralNamey = "Names";
            string TableName = "Price List";
            double[] prices = { 2000, 8000, 25000, 20000};
            int[] quantities = { 5, 3, 2, 4 };
            double[] cost = new double[4];
            TableInfo TblInf = new TableInfo(true, true, true, QGoodsNames, QParamsNames);
            int[] Types = new int[3];
            for (int i = 1; i <= 4; i++) cost[i - 1] = prices[i - 1] * quantities[i - 1];
            Types[1 - 1] = TableConsts.DoubleTypeN;
            Types[2 - 1] = TableConsts.IntTypeN;
            Types[3 - 1] = TableConsts.DoubleTypeN;
            TValsShowHide vsh = new TValsShowHide(1, 0, null, listBox1);
            TTable tbl = new TTable();
            //public void Set(TableInfo TblInfNewExt, TableInfo TblInfOldExt, bool ByColumnsNotLines, DataCellRow[] Content, DataCellRow LineOfColHeader, DataCellRow ColOfLineHeader, TableHeaders Headers, bool WriteInfo, bool PreserveVals)
            //public void SetMain(TableInfo TblInfNewExt, TableInfo TblInfOldExt, TableCellsTypeMap TypesMap, TableHeaders Headers, bool WriteInfo, bool PreserveVals)
            string[] ss;
            ss = new string[3];
            //
            tbl.SetMain(
                TblInf,
                null,
                new TableCellsTypeMap(
                    TblInf,
                    new DataTypeTable(QGoodsNames, QParamsNames, false, Types, 1),
                    new DataTypeRow(QParamsNames, TableConsts.StringTypeN),
                    new DataTypeRow(QGoodsNames, TableConsts.StringTypeN)
                    ),
                null
            );
            tbl.SetColOfLineHeader(new DataCellRow(GoodsNames, 4), TblInf);
            tbl.SetLineOfColHeader(new DataCellRow(CathegoryNames, 3), TblInf);
            for (int i = 1; i <= 3; i++)
            {
                ss[i - 1] = tbl.GetColumnHeaderCellAsString(i, TblInf);
            }
            tbl.SetColumn(
                1,
                new DataCellRowCoHeader(
                    new DataCell(tbl.GetColumnHeaderCellAsString(1, TblInf)),
                    new DataCellRow(prices, 4)
                ),
                TblInf
            );
            tbl.SetColumn(
                2,
                new DataCellRowCoHeader(
                    new DataCell(tbl.GetColumnHeaderCellAsString(2, TblInf)),
                    new DataCellRow(quantities, 4)
                ),
                TblInf
            );
            tbl.SetColumn(
                3,
                new DataCellRowCoHeader(
                    new DataCell(tbl.GetColumnHeaderCellAsString(3, TblInf)),
                    new DataCellRow(cost, 4)
                ),
                TblInf
            );
            //tbl.CreateInfo(TblInf);
            //tbl.Show(vsh);
            //tbl.ReprSet_2ArgsFn();
            //tbl.SetTableName(new DataCell("Price-list"));
            tbl.SetTableHeader(new DataCell("Price-list"));
            tbl.SetLinesGeneralHeader(new DataCell("Goods"));
            tbl.SetColumnsGeneralName(new DataCell("Params"));
            //tbl.ReprSet_Simple();
            tbl.Repr_Text_Set_Simple();
            MyLib.writeln(vsh, "Table ini, Simple");
            tbl.Show(vsh, null, TblInf);
            //tbl.ReprSet_2ArgsFn();
            tbl.Repr_Text_Set_2ArgsFn();
            //MyLib.writeln(vsh); 
            //MyLib.writeln(vsh, "Table ini, FnOf2Args");
            //tbl.Show(vsh, null, TblInf);
            //
            //tbl.ReprSet_Simple();
            tbl.Repr_Text_Set_Simple();
            tbl.CreateInfo(TblInf);
            //
            TTable tblLink, tblClone, tblMyCopyFull, tblMyCopyPartial;
            //CellsNsToDisplay Ns = new CellsNsToDisplay(2, 1, 2, 2, TblInf.RowsQuantities);
            CellsNsToDisplay Ns = new CellsNsToDisplay(new CellsNsToDisplayShort(2, 1, 2, 2, TblInf.RowsQuantities), new TableSize(1, 1));
            //
            tblLink = tbl;
            MyLib.writeln(vsh);
            MyLib.writeln(vsh, "Table Linked");
            //tblLink.ReprSet_Simple();
            tblLink.Repr_Text_Set_Simple();
            tblLink.Show(vsh, null, TblInf);
            //
            //
            tblClone = (TTable)tbl.Clone();
            MyLib.writeln(vsh);
            MyLib.writeln(vsh, "Table Clone");
            tblClone.Show(vsh, null, TblInf);
            MyLib.writeln(vsh);
            //
            //
            tblMyCopyFull = tbl.ReturnCopyOrPart(null, TblInf);
            MyLib.writeln(vsh);
            MyLib.writeln(vsh, "Table MyCopy Partial");
            tblMyCopyFull.Show(vsh, null, null);
            MyLib.writeln(vsh);
            //
            tblMyCopyPartial = tbl.ReturnCopyOrPart(Ns.GetCellsNsToDisplayShort(), TblInf);
            MyLib.writeln(vsh);
            MyLib.writeln(vsh, "Table MyCopy Partial");
            tblMyCopyPartial.Show(vsh, null, null);
            MyLib.writeln(vsh);
            //
            //
            MyLib.writeln(vsh, "Changing params");
            tbl.SetVal(tbl.GetLineHeaderNByName("Refrigerator", 1, TblInf), tbl.GetColumnHeaderNByName("Quantity"), 200, TblInf);
            MyLib.writeln(vsh);
            MyLib.writeln(vsh, "Table ini, af param change");
            tbl.Show(vsh, null, TblInf);
            MyLib.writeln(vsh);
            MyLib.writeln(vsh, "Table Linked");
            tblLink.Show(vsh, null, TblInf);
            //
            MyLib.writeln(vsh);
            MyLib.writeln(vsh, "Table Clone");
            tblClone.Show(vsh, null, TblInf);
            //
            MyLib.writeln(vsh);
            MyLib.writeln(vsh, "Table MyCopy");
            tblMyCopyFull.Show(vsh, null, null);
            //
            MyLib.writeln(vsh);
            MyLib.writeln(vsh, "Table MyCopy");
            tblMyCopyPartial.Show(vsh, null, null);
           //
        }
        
        private void tRepresentationAsTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableGeneralRepresentation aGRepr = new TableGeneralRepresentation();
            TTable Tbl = aGRepr.GetAsTable();
            TableForm UniTbl = new TableForm();

            //
            UniTbl.Show();
            UniTbl.AcceptTable(Tbl,null);
            //tbl; data=null; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
        }

        private void tHeaderCellRepresentationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableHeaderCellRepresentation aTHCRepr = new TableHeaderCellRepresentation();
            TTable Tbl = aTHCRepr.GetAsTable();
            TableForm UniTbl = new TableForm();
            UniTbl.Show();
            UniTbl.AcceptTable(Tbl,null);
            //tbl; data=null; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
        }

        private void tCntCellReprToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableContentCellRepresentation cRepr = new TableContentCellRepresentation();
            TTable tbl = cRepr.GetMainAsTable();
            TableForm UniTbl = new TableForm();
            UniTbl.Show();
            UniTbl.AcceptTable(tbl,null);
            //tbl; data=null; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
        }

        private void tUssagePolicyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableUssagePolicy usPol = new TableUssagePolicy();
            TTable tbl = usPol.GetAsTable();
            TableForm UniTbl = new TableForm();
            UniTbl.Show();
            UniTbl.AcceptTable(tbl,null);
            //tbl; data=null; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //TableForm tblFrm = new TableForm();
            //TableFormAndGridRepresentation tblFormRepr=new TableFormAndGridRepresentation();
            ////tblFormRepr.SetFromTable(Tbl_FormAndGridConfig);
            //Tbl_FormAndGridConfig = tblFormRepr.GetAsTable();
            //tblFrm.AcceptTable(Tbl_FormAndGridConfig);
            //tblFrm.Show();
        }

        /*read TableToGrid
         * private void tablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTopic.DataTopicN = 0;
            DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            DataTopic.DataN = 1;
            //TableForm tblFrm = new TableForm();
            TableForm tblFrm = new TableForm(this);
            //TableFormAndGridConfigurationMain tblFormRepr = new TableFormAndGridConfigurationMain();
            //tblFormRepr.SetFromTable(Tbl_FormAndGridConfig);
            //Tbl_FormAndGridConfig = tblFormRepr.GetAsTable();
            TableUssagePolicy UsePol = new TableUssagePolicy();
            TableInfo TblInf = new TableInfo(true, true, true, 11, 1);
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            Tbl_FormAndGridConfig = FormCfgAll.GetAsTable();
            TblInf.SetUssagePolicy(UsePol);
            tblFrm.AcceptTable(Tbl_FormAndGridConfig, DataTopic, null, null, TblInf);
            tblFrm.Show();
        }//fn
         * */
        //
        public void SetDataFromCurrentTable(TableDataChange dataId)
        {
            int zero = 0;
            switch(dataId.DataTopicN){
                case 0:
                    switch (dataId.DataTypeIni1Fin2Medium3Cfg4)
                    {
                        case 4:
                            switch (dataId.DataN)
                            {
                                case 1: //Grid repr
                                    FormCfgAll.SetFromTable(CurrentTable);
                                break;
                                case 2: //Ussage policy
                                    
                                break;
                                case 3: //Repr Tbl Gen

                                break;
                                case 4: //Repr Tbl Numeration

                                break;
                                case 5: //Repr Tbl Content ipse

                                break;
                                case 6: //Repr LoCH Ipse

                                break;
                                case 7: //Repr CoLH Ipse

                                break;
                                case 8: //Repr LoCH for content

                                break;
                                case 9: //Repr CoLH  for content

                                break;
                            }
                            break;
                    }
                    break;
                case 1: //Poly Eq Solve
                    if (dataId.DataTypeIni1Fin2Medium3Cfg4==1) PolyEqSlvr.SetEquationFromTable(this.CurrentTable);
                break;
                case 2: //.MatrCalc
                   this.MatrCalc.SetFromTable(this.CurrentTable, dataId.DataN);//ok, no reason to write separate cses for 3 matrices
                    //and actions - from menu
                break;
                case 3: //Tables
                    switch (dataId.DataN)
                    {
                        case 1:
                            T1 = this.CurrentTable.ReturnCopyOrPart();
                        break;
                        case 2:
                            T2 = this.CurrentTable.ReturnCopyOrPart();
                        break;
                        case 3:
                            T3 = this.CurrentTable.ReturnCopyOrPart();
                        break;
                    }    
                break;
                case 4: //Primitive Pipeline Resistances List
                switch (dataId.DataN)
                {
                    case 1:
                        //PipeLinePrimitive.Tmp.SetElementsFromTable(this.CurrentTable.ReturnCopyOrPart());
                        break;
                    case 2:
                       
                        break;
                    case 3:
                        
                        break;
                }
                break;   
            } 
        }

        private void matrix1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TValsShowHide vsh = new TValsShowHide();
            string name="M";
            TableForm tf;
            TableDataChange data = new TableDataChange();
            Matrix M=new Matrix();
            TTable TblRslt;
            int QLines=3, QColumns=3;
            DataCellRow []rows;
            double[] lines;
            //
            lines=new double[QColumns];
            rows=new DataCellRow[QLines];
            for(int i=1; i<=QLines; i++){
                for(int j=1; j<=QColumns; j++){
                    lines[j-1]=10*i+j;
                }
                rows[i-1]=new DataCellRow(lines, QColumns);
            }
            TableHeaders Hdr = null;
            if(name!=null && name!="") Hdr = new TableHeaders(new DataCell(name), null, null);
            TTable tblSource = new TTable(
                //new TableInfo(true, false, false, 2, 2),
                new TableInfo(true, false, false, QLines, QColumns),
                false,
                rows,
                null, null, Hdr,
                true
            );
            M.SetFromTable(tblSource);
            //TblRslt = M.GetAsTable();
            TblRslt = M.GetAsTable(name, true);
            vsh.box = this.listBox1;
            TblRslt.Show(vsh);
            data.DataTopicN = 0;
            data.DataN = 1;
            tf = new TableForm(this);
            tf.AcceptTable(TblRslt, data);
            //tbl; data; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
            tf.Show();
        }

        private void MenuItem_Matrices_M1_Click(object sender, EventArgs e)
        {
            TValsShowHide vsh = new TValsShowHide();
            vsh.box = this.listBox1;
            TableDataChange data=new TableDataChange();
            data.DataTopicN = 2;
            data.DataN = 1;
            MatrCalc.SetActiveN(data.DataN);
            //this.CurrentTable = (MatrCalc.GetCurrentMatrix()).GetAsTable();
            this.CurrentTable = (MatrCalc.GetCurrentMatrix()).GetAsTable("M1", true);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(this.CurrentTable, data);
            //tbl; data; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
            TF.Show();
            MyLib.writeln(vsh, "M1");
            //((this.MatrCalc.GetM1()).GetAsTable()).Show(vsh);
            ((this.MatrCalc.GetM1()).GetAsTable("M1", true)).Show(vsh);
        }
        private void MenuItem_Matrices_M2_Click(object sender, EventArgs e)
        {
            TValsShowHide vsh = new TValsShowHide();
            vsh.box = this.listBox1;
            TableDataChange data = new TableDataChange();
            data.DataTopicN = 2;
            data.DataN = 2;
            MatrCalc.SetActiveN(data.DataN);
            //this.CurrentTable = (MatrCalc.GetCurrentMatrix()).GetAsTable();
            this.CurrentTable = (MatrCalc.GetCurrentMatrix()).GetAsTable("M2", true);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(this.CurrentTable, data);
            //tbl; datal; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
            TF.Show();
            MyLib.writeln(vsh, "M2");
            //((this.MatrCalc.GetM1()).GetAsTable()).Show(vsh);
            ((this.MatrCalc.GetM1()).GetAsTable("M2", true)).Show(vsh);
        }
        private void MenuItem_Matrices_M3_Click(object sender, EventArgs e)
        {
            TValsShowHide vsh = new TValsShowHide();
            vsh.box = this.listBox1;
            TableDataChange data = new TableDataChange();
            data.DataTopicN = 2;
            data.DataN = 3;
            MatrCalc.SetActiveN(data.DataN);
            //this.CurrentTable = (MatrCalc.GetCurrentMatrix()).GetAsTable();
            this.CurrentTable = (MatrCalc.GetCurrentMatrix()).GetAsTable("M3", true);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(this.CurrentTable, data);
            //tbl; data; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
            TF.Show();
            MyLib.writeln(vsh, "M3");
            //((this.MatrCalc.GetM1()).GetAsTable()).Show(vsh);
            ((this.MatrCalc.GetM1()).GetAsTable("M3", true)).Show(vsh);
        }

        private void MenuItem_Matrices_M4_Click(object sender, EventArgs e)
        {
            TValsShowHide vsh = new TValsShowHide();
            vsh.box = this.listBox1;
            TableDataChange data = new TableDataChange();
            data.DataTopicN = 2;
            data.DataN = 4;
            MatrCalc.SetActiveN(data.DataN);
            //this.CurrentTable = (MatrCalc.GetCurrentMatrix()).GetAsTable();
            this.CurrentTable = (MatrCalc.GetCurrentMatrix()).GetAsTable("M4", true);
            TableForm TF = new TableForm(this);
            TF.AcceptTable(this.CurrentTable, data);
            //tbl; data; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
            TF.Show();
            MyLib.writeln(vsh, "M4");
            //((this.MatrCalc.GetM1()).GetAsTable()).Show(vsh);
            ((this.MatrCalc.GetM1()).GetAsTable("M4", true)).Show(vsh);
        }

        private void MemuItem_Matrices_Addition_Click(object sender, EventArgs e)
        {
            this.MatrCalc.Addition();
            MyLib.writeln(vsh, "M3=M1+M2");
            ((this.MatrCalc.GetM3()).GetAsTable()).Show(vsh);
        }

        private void MenuItem_Matrices_Subtraction_Click(object sender, EventArgs e)
        {
            this.MatrCalc.Subtraction();
            MyLib.writeln(vsh, "M3=M1-M2");
            ((this.MatrCalc.GetM3()).GetAsTable()).Show(vsh);
        }

        private void MenuItem_Matrices_Multiplication_Click(object sender, EventArgs e)
        {
            this.MatrCalc.Multiplicaction();
            MyLib.writeln(vsh, "M3=M1*M2");
            ((this.MatrCalc.GetM3()).GetAsTable()).Show(vsh);
        }

        private void MenuItem_Test_SetFromCSV_C_Temp_1_CSV_Click(object sender, EventArgs e)
        {
            string FullName = "C:\\temp\\1.csv";
            //FullName = "C:\\temp\\2.csv";
            TTable Tbl = new TTable();
            Tbl.SetFromCSV(FullName);
            TableForm TF = new TableForm(this);
            TableDataChange DataId=null;
            TF.AcceptTable(Tbl, DataId);
            //tbl; data; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
            TF.Show();
        }

        private void MenuItem_Test_TryMMinorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TValsShowHide vsh = new TValsShowHide();
            string name = "M";
            TableForm tf;
            TableDataChange data = new TableDataChange();
            Matrix M = new Matrix(), M1;// = new Matrix(); ;
            TTable TblRslt;
            int QLines = 3, QColumns = 3;
            DataCellRow[] rows;
            double[] lines;
            //
            lines = new double[QColumns];
            rows = new DataCellRow[QLines];
            for (int i = 1; i <= QLines; i++)
            {
                for (int j = 1; j <= QColumns; j++)
                {
                    lines[j - 1] = 10 * i + j;
                }
                rows[i - 1] = new DataCellRow(lines, QColumns);
            }
            TableHeaders Hdr = null;
            if (name != null && name != "") Hdr = new TableHeaders(new DataCell(name), null, null);
            TTable tblSource = new TTable(
                //new TableInfo(true, false, false, 2, 2),
                new TableInfo(true, false, false, QLines, QColumns),
                false,
                rows,
                null, null, Hdr,
                true
            );
            M.SetFromTable(tblSource);
            M1 = M.MinorTo(2, 2);
            //TblRslt = M.GetAsTable();
            TblRslt = M1.GetAsTable(name, true);
            vsh.box = this.listBox1;
            TblRslt.Show(vsh);
            data.DataTopicN = 0;
            data.DataN = 1;
            tf = new TableForm(this);
            tf.AcceptTable(TblRslt, data);
            //tbl; data; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
            tf.Show();
        }

      

        private void MenuItem_Test_TryHydroResSimpleListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Excluded");
            /*MyListElement R1, R2, R3;
            R1 = new MyListElement(1);
            R2 = new MyListElement(R1, 2);
            R3 = new MyListElement(R2, 3);
            MyLib.writeln(vsh, "R1: x=" + (R1.getX()).ToString());
            MyLib.writeln(vsh, "R2: x=" + (R2.getX()).ToString() + " parent x=" + (R2.getParentX()).ToString());
            MyLib.writeln(vsh, "R3: x=" + (R3.getX()).ToString() + " parent x=" + (R3.getParentX()).ToString());
            R1.setX(10);
            R2.setX(20);
            MyLib.writeln(vsh, "Now: R1.x=" + (R1.getX()).ToString()+" R2.x=" + (R2.getX()).ToString());
            MyLib.writeln(vsh, "R1: x=" + (R1.getX()).ToString());
            MyLib.writeln(vsh, "R2: x=" + (R2.getX()).ToString() + " parent x=" + (R2.getParentX()).ToString());
            MyLib.writeln(vsh, "R3: x=" + (R3.getX()).ToString() + " parent x=" + (R3.getParentX()).ToString());*/
        }

        private void MenuItem_Test_MatrixMinorDet_Click(object sender, EventArgs e)
        {
            double det = 0, algSuppl;
            //TValsShowHide vsh = new TValsShowHide();
            string name = "Transposed Minor (2, 2)";
            TableForm tf;
            TableDataChange data = new TableDataChange();
            Matrix M = new Matrix(), MM11, MM12, MM13, MM14, M1, M6;// = new Matrix(); ;
            Matrix MU, MI, ME;
            TTable TblRslt, T;
            int QLines = 4, QColumns = 4;
            DataCellRow[] rows;
            double[] lines;
            //
            lines = new double[QColumns];
            rows = new DataCellRow[QLines];
            for (int i = 1; i <= QLines; i++)
            {
                for (int j = 1; j <= QColumns; j++)
                {
                    if (i != j) lines[j - 1] = 10 * i + j;
                    else lines[j - 1] = 50 + j;
                }
                rows[i - 1] = new DataCellRow(lines, QColumns);
            }
            TableHeaders Hdr = null;
            if (name != null && name != "") Hdr = new TableHeaders(new DataCell(name), null, null);
            TTable tblSource = new TTable(
                //new TableInfo(true, false, false, 2, 2),
                new TableInfo(true, false, false, QLines, QColumns),
                false,
                rows,
                null, null, Hdr,
                true
            );
            M.SetFromTable(tblSource);
            T = M.GetAsTable("M");
            MyLib.writeln(vsh, "M");
            T.Show(vsh);
            det = M.Determinant();
            MyLib.writeln(vsh, "det=" + det.ToString());
            MyLib.writeln(vsh, "");
            MU = M.UnionMatrix();
            T = MU.GetAsTable("MU");
            MyLib.writeln(vsh, "MU");
            T.Show(vsh);
            MI = M.InverseMatrix();
            T = MI.GetAsTable("MI");
            MyLib.writeln(vsh, "MI");
            T.Show(vsh);
            ME = M * MI;
            T = ME.GetAsTable("ME");
            MyLib.writeln(vsh, "ME");
            T.Show(vsh);
            //
            //MyLib.writeln(vsh, "M");
            //tblSource.Show(vsh);
            /*
            tblSource.ReprSet_Matrix();
            MyLib.writeln(vsh, "M");
            tblSource.Show(vsh);
            */
            M1 = M.MinorTo(2, 2);
            MM11 = M.MinorTo(1, 1);
            T = MM11.GetAsTable("MM11");
            T.Show(vsh);
            det = MM11.Determinant();
            MyLib.writeln(vsh, "det=" + det.ToString());
            MyLib.writeln(vsh, "MM12");
            MM12 = M.MinorTo(1, 2);
            T = MM12.GetAsTable("MM12");
            T.Show(vsh);
            det = MM12.Determinant();
            MyLib.writeln(vsh, "det=" + det.ToString());
            MyLib.writeln(vsh, "MM13");
            MM13 = M.MinorTo(1, 3);
            T = MM13.GetAsTable("MM13");
            T.Show(vsh);
            det = MM13.Determinant();
            MyLib.writeln(vsh, "det=" + det.ToString());
            MyLib.writeln(vsh, "MM14");
            MM14 = M.MinorTo(1, 4);
            T = MM14.GetAsTable("MM14");
            T.Show(vsh);
            det = MM14.Determinant();
            MyLib.writeln(vsh, "det=" + det.ToString());
            M1 = M1.TransposeTo();
            TblRslt = M1.GetAsTable(name, true);
            vsh.box = this.listBox1;
            TblRslt.Show(vsh);
            //
            data.DataTopicN = 0;
            data.DataN = 1;
            tf = new TableForm(this);
            tf.AcceptTable(TblRslt, data);
            //tbl; data; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
            tf.Show();
            det = M.Determinant();
            MyLib.writeln(vsh, "det(M)=" + det.ToString());//1.827E+6
            //
            QLines = 6; QColumns = 6;
            MyLib.writeln(vsh, "M6");
            lines = new double[QColumns];
            rows = new DataCellRow[QLines];
            for (int i = 1; i <= QLines; i++)
            {
                for (int j = 1; j <= QColumns; j++)
                {
                    lines[j - 1] = 10 * i + j;
                    if (lines[j - 1] == 11 || lines[j - 1] == 22 || lines[j - 1] == 33 || lines[j - 1] == 44 || lines[j - 1] == 61 || lines[j - 1] == 52 || lines[j - 1] == 43 || lines[j - 1] == 34)
                        lines[j - 1] *= 10;
                }
                rows[i - 1] = new DataCellRow(lines, QColumns);
            }
            Hdr = null;
            if (name != null && name != "") Hdr = new TableHeaders(new DataCell(name), null, null);
            tblSource = new TTable(
                //new TableInfo(true, false, false, 2, 2),
                new TableInfo(true, false, false, QLines, QColumns),
                false,
                rows,
                null, null, Hdr,
                true
            );
            //M6 = M.SetFromTable(tblSource);
            M6 = new Matrix();
            M6.SetFromTable(tblSource);
            T = M6.GetAsTable("M6");
            T.Show(vsh);
            det = M6.Determinant();
            MyLib.writeln(vsh, "det(M6)=" + det.ToString());
            
        }
        
        private void MenuItem_Test_Read_From_CSV_file_C_Temp_Click(object sender, EventArgs e)
        {
            string FullName = "C:\\temp\\1.csv";
            FullName = "C:\\temp\\2.csv";
            TTable Tbl = new TTable();
            Tbl.SetFromCSV(FullName);
            TableForm TF = new TableForm(this);
            TableDataChange DataId = null;
            TF.AcceptTable(Tbl, DataId);
            //tbl; data; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
            TF.Show();
        }

        

        
        //mark1
        private void MenuItem_Test_GridParamsFns_Click(object sender, EventArgs e)
        {
            TableInfo TblInf;
            TTable TblGridParamsGiven;
            CellsNsToDisplay CellsNsToDispl = new CellsNsToDisplay();
            GridParamsGiven ParamsGiven = new GridParamsGiven();
            GridParamsCalculated ParamsCalcd = new GridParamsCalculated();
            //TableFormAndGridConfigurationMain FormGridCfg = new TableFormAndGridConfigurationMain();
            TableHeaderRowsExistance GridHeaderRowsExistance;
            int CurTLineN, CurTColN, CurGridLineIndex, CurGridColIndex, LineToDisplOrderNatN, ColToDisplOrderNatN;
            //
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = true;
            GridHeaderRowsExistance.LineOfColHeaderExists = true;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 6;
            CellsNsToDispl.NsToDispl.ErstColumnN = 6;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 4;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 4;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            //vrn 1.1
            MyLib.writeln(this.vsh, "Vrn 1.1");
            //GridHeaderRowsExistance by default - 1, 1;
            LineToDisplOrderNatN=2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh," LineToDisplOrderNatN="+LineToDisplOrderNatN.ToString()+" CurTLineN="+CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh," LineToDisplOrderNatN="+LineToDisplOrderNatN.ToString()+" CurGridLineIndex="+CurGridLineIndex.ToString());
            CurTLineN=7;
            LineToDisplOrderNatN=ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh," LineToDisplOrderNatN="+LineToDisplOrderNatN.ToString()+" CurTLineN="+CurTLineN.ToString());
            CurGridLineIndex=ParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh," CurTLineN="+CurTLineN.ToString()+" CurGridLineIndex="+CurGridLineIndex.ToString());
            LineToDisplOrderNatN=ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh," CurTLineN="+CurTLineN.ToString()+" LineToDisplOrderNatN="+LineToDisplOrderNatN.ToString());
            CurGridLineIndex=4;
            CurTLineN=ParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh," CurGridLineIndex="+CurGridLineIndex.ToString()+" CurTLineN="+CurTLineN.ToString());
            LineToDisplOrderNatN=ParamsCalcd.Calc_LineOrderNatNToDisplay_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh," CurGridLineIndex="+CurGridLineIndex.ToString()+" LineToDisplOrderNatN="+LineToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 1.1 for lines");
            //
            //vrn 1.1
            MyLib.writeln(this.vsh, "Vrn 1.1");
            //GridHeaderRowsExistance by default - 1, 1;
            ColToDisplOrderNatN = 2;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            CurTColN = 7;
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            CurGridColIndex = 4;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " CurTColN=" + CurTColN.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 1.1 for cols");
            //
            // vrn 1.2
            MyLib.writeln(this.vsh, "Vrn 1.2");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = false;
            GridHeaderRowsExistance.LineOfColHeaderExists = false;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 6;
            CellsNsToDispl.NsToDispl.ErstColumnN = 6;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 3;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 3;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            LineToDisplOrderNatN = 2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            CurTLineN = 7;
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            CurGridLineIndex = 4;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " CurTLineN=" + CurTLineN.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 1.2 for lines");
            //
            //
            // vrn 1.2
            MyLib.writeln(this.vsh, "Vrn 1.2");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = false;
            GridHeaderRowsExistance.LineOfColHeaderExists = false;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 6;
            CellsNsToDispl.NsToDispl.ErstColumnN = 6;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 3;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 3;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            ColToDisplOrderNatN = 2;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            CurTColN = 7;
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            CurGridColIndex = 4;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " CurTColN=" + CurTColN.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 1.2 for cols");
            //
            // vrn 2.1
            MyLib.writeln(this.vsh, "Vrn 2.1");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = false;
            GridHeaderRowsExistance.LineOfColHeaderExists = false;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 4;
            CellsNsToDispl.NsToDispl.ErstColumnN = 4;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 1;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 1;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            LineToDisplOrderNatN = 2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            CurTLineN = 5;
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            CurGridLineIndex = 2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " CurTLineN=" + CurTLineN.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 2.1 for lines");
            //
            // vrn 2.1
            MyLib.writeln(this.vsh, "Vrn 2.1");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = false;
            GridHeaderRowsExistance.LineOfColHeaderExists = false;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 4;
            CellsNsToDispl.NsToDispl.ErstColumnN = 4;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 1;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 1;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            ColToDisplOrderNatN = 2;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            CurTColN = 5;
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            CurGridColIndex = 2;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " CurTColN=" + CurTColN.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 2.1 for cols");
            //
            // vrn 2.2
            MyLib.writeln(this.vsh, "Vrn 2.2");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = true;
            GridHeaderRowsExistance.LineOfColHeaderExists = true;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 4;
            CellsNsToDispl.NsToDispl.ErstColumnN = 4;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 2;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 2;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            LineToDisplOrderNatN = 2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            CurTLineN = 5;
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            CurGridLineIndex = 2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " CurTLineN=" + CurTLineN.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 2.1 for lines");
            //
            //
            // vrn 2.2
            MyLib.writeln(this.vsh, "Vrn 2.2");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = true;
            GridHeaderRowsExistance.LineOfColHeaderExists = true;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 4;
            CellsNsToDispl.NsToDispl.ErstColumnN = 4;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 2;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 2;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            LineToDisplOrderNatN = 2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            CurTLineN = 5;
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            CurGridLineIndex = 2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " CurTLineN=" + CurTLineN.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 2.2 for lines");
            //
            // vrn 2.2
            MyLib.writeln(this.vsh, "Vrn 2.2");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = true;
            GridHeaderRowsExistance.LineOfColHeaderExists = true;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 4;
            CellsNsToDispl.NsToDispl.ErstColumnN = 4;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 2;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 2;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            ColToDisplOrderNatN = 2;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            CurTColN = 5;
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            CurGridColIndex = 2;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " CurTColN=" + CurTColN.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 2.2 for cols");
            //
            // vrn 3.1
            MyLib.writeln(this.vsh, "Vrn 3.1");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = true;
            GridHeaderRowsExistance.LineOfColHeaderExists = true;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 3;
            CellsNsToDispl.NsToDispl.ErstColumnN = 3;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 1;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 1;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            LineToDisplOrderNatN = 2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            CurTLineN = 4;
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            CurGridLineIndex = 1;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " CurTLineN=" + CurTLineN.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 3.1 for lines");
            //
            // vrn 3.1
            MyLib.writeln(this.vsh, "Vrn 3.1");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = true;
            GridHeaderRowsExistance.LineOfColHeaderExists = true;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 3;
            CellsNsToDispl.NsToDispl.ErstColumnN = 3;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 1;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 1;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            ColToDisplOrderNatN = 2;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            CurTColN = 4;
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            CurGridColIndex = 1;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " CurTColN=" + CurTColN.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 3.1 for cols");
            //
            // vrn 3.2
            MyLib.writeln(this.vsh, "Vrn 3.2");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = false;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = false;
            GridHeaderRowsExistance.ColOfLineHeaderExists = false;
            GridHeaderRowsExistance.LineOfColHeaderExists = false;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 3;
            CellsNsToDispl.NsToDispl.ErstColumnN = 3;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 1;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 1;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            LineToDisplOrderNatN = 2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            CurTLineN = 4;
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            CurGridLineIndex = 1;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " CurTLineN=" + CurTLineN.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 3.2 for lines");
            //mark2
            //mark2
            // vrn 3.2
            MyLib.writeln(this.vsh, "Vrn 3.2");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = false;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = false;
            GridHeaderRowsExistance.ColOfLineHeaderExists = false;
            GridHeaderRowsExistance.LineOfColHeaderExists = false;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 3;
            CellsNsToDispl.NsToDispl.ErstColumnN = 3;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 1;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 1;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            ColToDisplOrderNatN = 2;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            CurTColN = 4;
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            CurGridColIndex = 1;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " CurTColN=" + CurTColN.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 3.2 for сols");
            //
            // vrn 4.1
            MyLib.writeln(this.vsh, "Vrn 4.1");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = false;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = false;
            GridHeaderRowsExistance.ColOfLineHeaderExists = false;
            GridHeaderRowsExistance.LineOfColHeaderExists = false;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 2;
            CellsNsToDispl.NsToDispl.ErstColumnN = 2;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 1;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 1;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            LineToDisplOrderNatN = 2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            CurTLineN = 3;
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            CurGridLineIndex = 0;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " CurTLineN=" + CurTLineN.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 4.1 for lines");
            //
            //
            // vrn 4.1
            MyLib.writeln(this.vsh, "Vrn 4.1");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = false;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = false;
            GridHeaderRowsExistance.ColOfLineHeaderExists = false;
            GridHeaderRowsExistance.LineOfColHeaderExists = false;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 2;
            CellsNsToDispl.NsToDispl.ErstColumnN = 2;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 1;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 1;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            ColToDisplOrderNatN = 2;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            CurTColN = 3;
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            CurGridColIndex = 0;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " CurTColN=" + CurTColN.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 4.1 for cols");
            //
            // vrn 4.2
            MyLib.writeln(this.vsh, "Vrn 4.2");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = true;
            GridHeaderRowsExistance.LineOfColHeaderExists = true;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 2;
            CellsNsToDispl.NsToDispl.ErstColumnN = 2;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 1;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 1;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            LineToDisplOrderNatN = 2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            CurTLineN = 3;
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            CurGridLineIndex = 0;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " CurTLineN=" + CurTLineN.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 4.2 for lines");
            //
            //
            // vrn 4.2
            MyLib.writeln(this.vsh, "Vrn 4.2");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = true;
            GridHeaderRowsExistance.LineOfColHeaderExists = true;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 2;
            CellsNsToDispl.NsToDispl.ErstColumnN = 2;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 1;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 1;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            ColToDisplOrderNatN = 2;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            CurTColN = 3;
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            CurGridColIndex = 0;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " CurTColN=" + CurTColN.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 4.2 for cols");
            //
            // vrn 5.1
            MyLib.writeln(this.vsh, "Vrn 5.1");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = true;
            GridHeaderRowsExistance.LineOfColHeaderExists = true;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 5;
            CellsNsToDispl.NsToDispl.ErstColumnN = 5;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 3;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 3;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            LineToDisplOrderNatN = 2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            CurTLineN = 6;
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            CurGridLineIndex = 3;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " CurTLineN=" + CurTLineN.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 5.1 for lines");
            //
            // vrn 5.1
            MyLib.writeln(this.vsh, "Vrn 5.1");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = true;
            GridHeaderRowsExistance.LineOfColHeaderExists = true;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 5;
            CellsNsToDispl.NsToDispl.ErstColumnN = 5;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 3;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 3;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            ColToDisplOrderNatN = 2;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            CurTColN = 6;
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            CurGridColIndex = 3;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " CurTColN=" + CurTColN.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 5.1 for cols");
            //
            // vrn 5.2            MyLib.writeln(this.vsh, "Vrn 5.2");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = false;
            GridHeaderRowsExistance.LineOfColHeaderExists = false;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 5;
            CellsNsToDispl.NsToDispl.ErstColumnN = 5;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 3;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 3;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            LineToDisplOrderNatN = 2;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByLineOrderNatNToDisplay(LineToDisplOrderNatN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            CurTLineN = 6;
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString() + " CurTLineN=" + CurTLineN.ToString());
            CurGridLineIndex = ParamsCalcd.Calc_GridLineIndex_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " CurGridLineIndex=" + CurGridLineIndex.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByTableLineNatN(CurTLineN);
            MyLib.writeln(this.vsh, " CurTLineN=" + CurTLineN.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            CurGridLineIndex = 3;
            CurTLineN = ParamsCalcd.Calc_TableLineNatN_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " CurTLineN=" + CurTLineN.ToString());
            LineToDisplOrderNatN = ParamsCalcd.Calc_LineOrderNatNToDisplay_ByGridLineIndex(CurGridLineIndex);
            MyLib.writeln(this.vsh, " CurGridLineIndex=" + CurGridLineIndex.ToString() + " LineToDisplOrderNatN=" + LineToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 5.2 for lines");
            //
            // vrn 5.2 
            MyLib.writeln(this.vsh, "Vrn 5.2");
            TblInf = new TableInfo(true, true, true, 9, 9);
            //TblInf.SetSize(9, 9);
            //TblInf.SetStr(new TableStructure(1, 1, 1));
            TblInf.Repr_Grid = new TableRepresentation();
            TblInf.Repr_Grid.num = new TRowsNumeration();
            TblInf.Repr_Grid.num.SetErstLineN(10);
            TblInf.Repr_Grid.num.SetLinesNsStep(10);
            TblInf.Repr_Grid.dets = new TableRepresentationDetails();
            TblInf.Repr_Grid.dets.GenRepr = new TableGeneralRepresentation();
            GridHeaderRowsExistance = new TableHeaderRowsExistance();
            //TblInf.Repr_Grid.dets.GenRepr.Len_NoLim0RecomVal1GenMaxLen2MaxByCol3 = 10;
            //TblInf.Repr_Grid.dets.GenRepr.LRecom = 10;
            TblInf.Repr_Grid.dets.GenRepr.ShowColOfLineHeader = true;
            TblInf.Repr_Grid.dets.GenRepr.ShowLineOfColHeader = true;
            GridHeaderRowsExistance.ColOfLineHeaderExists = false;
            GridHeaderRowsExistance.LineOfColHeaderExists = false;
            //
            CellsNsToDispl.NsToDispl.ErstLineN = 5;
            CellsNsToDispl.NsToDispl.ErstColumnN = 5;
            CellsNsToDispl.NsToDispl.QLines = 10;
            CellsNsToDispl.NsToDispl.QColumns = 10;
            //
            CellsNsToDispl.QRowsNamesToDisplay.QLines = 3;
            CellsNsToDispl.QRowsNamesToDisplay.QColumns = 3;
            //
            ParamsCalcd.Set(GridHeaderRowsExistance, CellsNsToDispl, TblInf);
            //
            TblGridParamsGiven = ParamsCalcd.GetIniParamsAsTable();
            MyLib.writeln(this.vsh, "Grid params given:");
            TblGridParamsGiven.Repr_Text_Set_Simple();
            TblGridParamsGiven.Show(this.vsh);
            MyLib.writeln(this.vsh, "Now checking calculation");
            //
            ColToDisplOrderNatN = 2;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByColOrderNatNToDisplay(ColToDisplOrderNatN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            CurTColN = 6;
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString() + " CurTColN=" + CurTColN.ToString());
            CurGridColIndex = ParamsCalcd.Calc_GridColIndex_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " CurGridColIndex=" + CurGridColIndex.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByTableColNatN(CurTColN);
            MyLib.writeln(this.vsh, " CurTColN=" + CurTColN.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            CurGridColIndex = 3;
            CurTColN = ParamsCalcd.Calc_TableColNatN_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " CurTColN=" + CurTColN.ToString());
            ColToDisplOrderNatN = ParamsCalcd.Calc_ColOrderNatNToDisplay_ByGridColIndex(CurGridColIndex);
            MyLib.writeln(this.vsh, " CurGridColIndex=" + CurGridColIndex.ToString() + " ColToDisplOrderNatN=" + ColToDisplOrderNatN.ToString());
            MyLib.writeln(this.vsh, "This was Vrn 5.2 for cols");
            //
        }

        private void aeroDynTable1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableForm tblAD;
            //public TTable(DataCellRowCoHeader FirstRow, TableHeaders Headers, bool DBStartNotList = true, DataCellRow HeadersRow = null, bool WriteInfo = true, bool LC_not_CL = true)
            //DataCellRowCoHeader ContentRow; //TableHeaders Headers, bool DBStartNotList = true, DataCellRow HeadersRow = null, bool WriteInfo = true, bool LC_not_CL = true
            //DataCellRow HeadersRow;
            //ContentRow=new DataCellRowCoHeader(new DataCell(0.1), new DataCellRow(new double[]{0.11, 0.12, 0.13, 0.14, 0.15}, 5));
            //HeadersRow=new DataCellRow(new double[]{-2, 0, 1, 2, 13}, 5);
            TTable tbl;
            tbl = new TTable(new DataCellRowCoHeader(new DataCell(0.1), new DataCellRow(new double[] { 0.11, 0.12, 0.13, 0.14, 0.15 }, 5)), new TableHeaders(new DataCell("Cy"), new DataCell("M"), new DataCell("Alfa")), true, new DataCellRow(new double[] { -2, 0, 1, 2, 13 }, 5));
            tblAD = new TableForm(this, tbl, null/*this.DataTopic*/);
            tblAD.Show();
            MessageBox.Show("Such is Single-line table");
            tbl.AddLine(new DataCellRowCoHeader(new DataCell(0.2), new DataCellRow(new double[] { 0.21, 0.22, 0.23, 0.24, 0.25 }, 5)));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell(0.8), new DataCellRow(new double[] { 0.31, 0.32, 0.33, 0.34, 0.35 }, 5)));
            tbl.AddLine(new DataCellRowCoHeader(new DataCell(0.9), new DataCellRow(new double[] { 0.41, 0.42, 0.43, 0.44, 0.45 }, 5)));
            this.DataTopic.DataTopicN = 1; this.DataTopic.DataN = 1;
            tblAD = new TableForm(this, tbl, null/*this.DataTopic*/);
            tblAD.Show();
            MessageBox.Show("Such is multy-line table");
            tbl = new TTable(new DataCellRowCoHeader(new DataCell(-2), new DataCellRow(new double[] { 0.11, 0.21, 0.31, 0.41 }, 4)), new TableHeaders(new DataCell("Cy"), new DataCell("M"), new DataCell("Alfa")), false, new DataCellRow(new double[] { 0.1, 0.2, 0.8, 0.9 }, 4));
            tblAD = new TableForm(this, tbl, null/*this.DataTopic*/);
            tblAD.Show();
            MessageBox.Show("Such is Single-Column table");
            tbl.AddColumn(new DataCellRowCoHeader(new DataCell(0), new DataCellRow(new double[] { 0.12, 0.22, 0.32, 0.42 }, 4)));
            tbl.AddColumn(new DataCellRowCoHeader(new DataCell(1), new DataCellRow(new double[] { 0.13, 0.23, 0.33, 0.43 }, 4)));
            tbl.AddColumn(new DataCellRowCoHeader(new DataCell(2), new DataCellRow(new double[] { 0.14, 0.24, 0.34, 0.44 }, 4)));
            tbl.AddColumn(new DataCellRowCoHeader(new DataCell(15), new DataCellRow(new double[] { 0.15, 0.25, 0.35, 0.45 }, 4)));
            this.DataTopic.DataTopicN = 1; this.DataTopic.DataN = 1;
            tblAD = new TableForm(this, tbl, null/*this.DataTopic*/);
            tblAD.Show();
            MessageBox.Show("Such is multy-column table");
        }
        private void MenuItem_Test_CoordTransform_Click(object sender, EventArgs e)
        {
            TableForm tblF;
            DataTopic.DataN = 2;
            MatrCalc.SetIniCoordsAsTestExample();
            CurrentTable = MatrCalc.GetCoordTransformIniDataTableOfIniCoords();
            DataTopic.DataN = 1;
            tblF = new TableForm(this, CurrentTable, DataTopic);
            tblF.Show();
            MessageBox.Show("Such is Matrix of ini coords");
            MatrCalc.SetEulerAnglesAsTestExample();
            CurrentTable = MatrCalc.GetCoordTransformIniDataTableOfEulerAngles();
            DataTopic.DataN = 5;
            tblF = new TableForm(this, CurrentTable, DataTopic);
            tblF.Show();
            MessageBox.Show("Such is Matrix of Euler's angles");
            MatrCalc.SetDistancesAsTestExample();
            DataTopic.DataN = 3;
            CurrentTable = MatrCalc.GetCoordTransformIniDataTableOfDistances();
            tblF = new TableForm(this, CurrentTable, DataTopic);
            tblF.Show();
            MessageBox.Show("Such is Matrix of Distances");
            //MatrCalc.SetDirectionalCosinesAsTestExample();
            MatrCalc.CalcMatrixOfDirCossByEulersAngles();
            DataTopic.DataN = 2;
            CurrentTable = MatrCalc.GetCoordTransformIniDataTableOfDirectionalCosines();
            tblF = new TableForm(this, CurrentTable, DataTopic);
            tblF.Show();
            MessageBox.Show("Such is Matrix of Directional Cosines");
            //
            MatrCalc.CalcCoordsTransformCoordsFromOldCSToNew();
            DataTopic.DataN = 4;
            CurrentTable = MatrCalc.GetCoordTransformResultTable();
            tblF = new TableForm(this, CurrentTable, DataTopic);
            tblF.Show();
            MessageBox.Show("Such is Vector of results of Coords Transformation");
        }

        private void aeroDynTableGridVrnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableFormAndGridConfigurationMain cfg = new TableFormAndGridConfigurationMain();
            cfg.ModeTbl_Gui0Inner1Target2 = 0;
            TTable tbl = fADTable1();
            CurrentTable = tbl;
            TableForm tF = new TableForm(this, CurrentTable, DataTopic, cfg);
            tF.Show();

        }

        private void MenuItem_MatrCalc_Show_M1_Click(object sender, EventArgs e)
        {
            TableFormAndGridConfigurationMain cfg = new TableFormAndGridConfigurationMain();
            cfg.ModeTbl_Gui0Inner1Target2 = 0;
            TTable tbl = fADTable2();
            CurrentTable = tbl;
            TableForm tF = new TableForm(this, CurrentTable, DataTopic, cfg);
            tF.Show();
        }

        private void MenuItem_MatrCalc_Show_M2_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Show_M3_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Show_M4_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Show_M5_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M1_ET_M1_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M1_ET_M2_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M1_ET_M3_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M1_ET_M4_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M1_ET_M5_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M2_ET_M1_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M2_ET_M2_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M2_ET_M3_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M2_ET_M4_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M2_ET_M5_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M3_ET_M1_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M3_ET_M2_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M3_ET_M3_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M3_ET_M4_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M3_ET_M5_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M4_ET_M1_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M4_ET_M2_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M4_ET_M3_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M4_ET_M4_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M4_ET_M5_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M5_ET_M1_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M5_ET_M2_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M5_ET_M3_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M5_ET_M4_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Assign_M5_ET_M5_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Actions_M3ETM1PlusM2_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Actions_M3ETM1MinusM2_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Actions_M3ETM1MultiplyToM2_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Actions_M3ETM1DivideByM2_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Actions_M2ETM1MultiplyToKET10_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_Actions_M2ETKET10MultiplyToM1_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_CoordTrfm_IniData_IniCoords_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_CoordTrfm_IniData_EulerAngles_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_CoordTrfm_IniData_AnglesBetweenAxesInDegrees_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_CoordTrfm_IniData_Distances_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_CoordTrfm_Results_Coords_OldiCS_EulerAngles_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_CoordTrfm_Results_Coords_OldiCS_DirCoss_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_CoordTrfm_Results_Coords_NewCS_EulerAngles_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_CoordTrfm_Results_Coords_NewCS_DirCoss_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_CoordTrfm_Results_CalcDirCossByEulerAngles_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_CoordTrfm_Results_CalcDirCossByAnglesBtwAxes_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_LinearEqsSys_IniData_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_MatrCalc_LinearEqsSys_Results_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tables_SetT1FromCSV_Click(object sender, EventArgs e)
        {
            //T1.SetFromCSV(
        }

        private void MenuItem_Tables_SetT2FromCSV_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tables_AssignT1ByT2_Click(object sender, EventArgs e)
        {
            T1 = T2;
            MessageBox.Show("T1 = T2; done");
        }

        private void MenuItem_Tables_AssignT2ByT1_Click(object sender, EventArgs e)
        {
            T2 = T1;
            MessageBox.Show("T2 = T1; done");
        }

        private void MenuItem_Tables_AppendT1ByT2Vertically_Click(object sender, EventArgs e)
        {
            T1.AddVerticallyFrom(T2);
        }

        private void MenuItem_Tables_AppendT1ByT2Horisontally_Click(object sender, EventArgs e)
        {
            T1.AddHorisontallyFrom(T2);
        }

        private void MenuItem_Tables_AppendT1ByT2VerticallyTransposing_Click(object sender, EventArgs e)
        {
            T2.Transpose();
        }

        private void MenuItem_Tables_AppendT2ByT1Vertically_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tables_AppendT2ByT1Horisontally_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tables_AppendT2ByT1VerticallyTransposing_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_PolynomialEqGenerator_IniData_Click(object sender, EventArgs e)
        {
            TableUssagePolicy UsePol = new TableUssagePolicy();
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            UsePol.AllowLines();
            UsePol.QLinesMinDefined = true;
            UsePol.QLinesMaxDefined=true;
            UsePol.QLinesMax = 5;
            //PolyEqSlvr.SetDefaultTrivialLinEquation();
            CurrentTable = PolyEqSlvr.GetGeneratorAsTable();
        }

        private void MenuItem_PolynomialEqGenerator_Result_Click(object sender, EventArgs e)
        {

        }

        private TTable fADTable1()
        {
            TTable T= new TTable(
                new TableInfo(true, true, true, 4, 5),
                false,
                new DataCellRow[]{ 
                    new DataCellRow( new DataCell[]{new DataCell(0.11), new DataCell(0.12), new DataCell(0.13), new DataCell(0.14), new DataCell(0.15) }, 5),
                    new DataCellRow( new DataCell[]{new DataCell(0.21), new DataCell(0.22), new DataCell(0.23), new DataCell(0.24), new DataCell(0.25) }, 5),
                    new DataCellRow( new DataCell[]{new DataCell(0.31), new DataCell(0.32), new DataCell(0.33), new DataCell(0.34), new DataCell(0.35) }, 5),
                    new DataCellRow( new DataCell[]{new DataCell(0.41), new DataCell(0.42), new DataCell(0.43), new DataCell(0.44), new DataCell(0.45) }, 5)
                },

                new DataCellRow(new DataCell[] { new DataCell(-2), new DataCell(0), new DataCell(1), new DataCell(2), new DataCell(15) }, 5),
                new DataCellRow(new DataCell[] { new DataCell(0.1), new DataCell(0.2), new DataCell(0.8), new DataCell(0.9) }, 4),
                new TableHeaders(new DataCell("Cy"), new DataCell("M"), new DataCell("Alfa")),
                true
             );
            return T;
        }
        private TTable fADTable2()
        {
            TTable T = new TTable(
                new TableInfo(true, true, true, 4, 5),
                true,
                new DataCellRow[] 
                {
                    new DataCellRow( new DataCell[]{new DataCell(0.11), new DataCell(0.21), new DataCell(0.31), new DataCell(0.41) }, 4),
                    new DataCellRow( new DataCell[]{new DataCell(0.12), new DataCell(0.22), new DataCell(0.32), new DataCell(0.42) }, 4),
                    new DataCellRow( new DataCell[]{new DataCell(0.13), new DataCell(0.23), new DataCell(0.33), new DataCell(0.43) }, 4),
                    new DataCellRow( new DataCell[]{new DataCell(0.14), new DataCell(0.24), new DataCell(0.34), new DataCell(0.44) }, 4),
                    new DataCellRow( new DataCell[]{new DataCell(0.15), new DataCell(0.25), new DataCell(0.35), new DataCell(0.45) }, 4)
                },
                new DataCellRow(new DataCell[] { new DataCell(-2), new DataCell(0), new DataCell(1), new DataCell(2), new DataCell(15) }, 5),
                new DataCellRow(new DataCell[] { new DataCell(1.0), new DataCell(2.0), new DataCell(8.0), new DataCell(9.0) }, 4),
                new TableHeaders(new DataCell("Cy"), new DataCell("Alfa"), new DataCell("M")),
                true
             );
            return T;
        }
        private TTable fADTable3()
        {
            TTable T = new TTable(
                new TableInfo(true, true, true, 5, 4),
                false,//true,
                new DataCellRow[] 
                {
                    new DataCellRow( new DataCell[]{new DataCell(11), new DataCell(12), new DataCell(31), new DataCell(41) }, 4),
                    new DataCellRow( new DataCell[]{new DataCell(12), new DataCell(22), new DataCell(32), new DataCell(42) }, 4),
                    new DataCellRow( new DataCell[]{new DataCell(13), new DataCell(23), new DataCell(33), new DataCell(43) }, 4),
                    new DataCellRow( new DataCell[]{new DataCell(14), new DataCell(24), new DataCell(34), new DataCell(44) }, 4),
                    new DataCellRow( new DataCell[]{new DataCell(15), new DataCell(25), new DataCell(35), new DataCell(45) }, 4)
                },
                new DataCellRow(new DataCell[] { new DataCell(-3),  new DataCell(1.5), new DataCell(2), new DataCell(16.5) }, 4),
                new DataCellRow(new DataCell[] { new DataCell(0.5), new DataCell(1.0), new DataCell(2.0), new DataCell(6.5), new DataCell(9.0) }, 5),
                new TableHeaders(new DataCell("Cy"), new DataCell("M"), new DataCell("Alfa")),
                true
             );
            return T;
        }

       
        private void MenuItem_Tables_AssignT1ByADTable_Click(object sender, EventArgs e)
        {
            T1 = fADTable1();
        }

        private void MenuItem_Tables_AssignT2ByADTable_Click(object sender, EventArgs e)
        {
            T2 = fADTable2();
        }

        private void form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }

        

        private void MenuItem_Settings_ReadTableToGrid_Click(object sender, EventArgs e)
        {
            DataTopic.DataTopicN = 0;
            DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            DataTopic.DataN = 1;
            //TableForm tblFrm = new TableForm();
            TableForm tblFrm = new TableForm(this);
            //TableFormAndGridConfigurationMain tblFormRepr = new TableFormAndGridConfigurationMain();
            //tblFormRepr.SetFromTable(Tbl_FormAndGridConfig);
            //Tbl_FormAndGridConfig = tblFormRepr.GetAsTable();
            TableUssagePolicy UsePol = new TableUssagePolicy();
            TableInfo TblInf = new TableInfo(true, true, true, 11, 1);
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            Tbl_FormAndGridConfig = FormCfgAll.GetAsTable();
            TblInf.SetUssagePolicy(UsePol);
            tblFrm.AcceptTable(Tbl_FormAndGridConfig, DataTopic, null, null, null, TblInf);
            //                                    tbl; data ; GridCfg=null; ReadGrid=null; Ns=null; Inf
            tblFrm.Show();
        }

        private void MenuItem_Settings_ReadGridToTable_Click(object sender, EventArgs e)
        {
            DataTopic.DataTopicN = 0;
            DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 4;
            DataTopic.DataN = 1;
            //TableForm tblFrm = new TableForm();
            TableForm tblFrm = new TableForm(this);
            //TableFormAndGridConfigurationMain tblFormRepr = new TableFormAndGridConfigurationMain();
            //tblFormRepr.SetFromTable(Tbl_FormAndGridConfig);
            //Tbl_FormAndGridConfig = tblFormRepr.GetAsTable();
            TableUssagePolicy UsePol = new TableUssagePolicy();
            TableInfo TblInf = new TableInfo(true, true, true, 6, 1);
            UsePol.ForbidAll();
            UsePol.AllowEditContents();
            //Tbl_FormAndGridConfig = FormCfgAll.GetAsTable();
            Tbl_FormAndGridConfig = GridReadParams.GetAsTable();
            TblInf.SetUssagePolicy(UsePol);
            tblFrm.AcceptTable(Tbl_FormAndGridConfig, DataTopic, null, null, null, TblInf);
            //                                  tbl; data; GridCfg=null; ReadGrid=null; Ns=null; Inf
            tblFrm.Show();
        }

        private void MenuItem_Tables_AssignT1ByADTableF3_Click(object sender, EventArgs e)
        {
            T1 = fADTable3();
            MessageBox.Show("T1 = fADTable3(); done");
        }

        private void MenuItem_Tables_AssignT2ByADTableF3_Click(object sender, EventArgs e)
        {
            T2 = fADTable3();
            MessageBox.Show("T2 = fADTable3(); done");
        }

        private void MenuItem_Tables_AssignT1ByADTableF1_Click(object sender, EventArgs e)
        {
            T1 = fADTable1();
            MessageBox.Show("T1 = fADTable1(); done");
        }

        private void MenuItem_Tables_AssignT2ByADTableF2_Click(object sender, EventArgs e)
        {
            T2 = fADTable2();
            MessageBox.Show("T2 = fADTable2(); done");
        }

        private void MenuItem_Tables_AppendT1ByT2Smart_Click(object sender, EventArgs e)
        {
            //T1.AddTableSmart(T2);
        }

        private void MenuItem_Tables_AppendT2ByT1Smart_Click(object sender, EventArgs e)
        {
            //T2.AddTableSmart(T1);
        }

        private void MenuItem_Tables_ShowGridFormOf_T1_Click(object sender, EventArgs e)
        {
            TableForm tf = new TableForm(this);
            TableDataChange data = new TableDataChange();
            data.DataTopicN = 3;
            data.DataN = 1;
            tf.AcceptTable(T1, data);
            //tbl; data; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
            tf.Show();
        }

        private void MenuItem_Tables_ShowGridFormOf_T2_Click(object sender, EventArgs e)
        {
            TableForm tf = new TableForm(this);
            TableDataChange data = new TableDataChange();
            data.DataTopicN = 3;
            data.DataN = 2;
            tf.AcceptTable(T2, data);
            //tbl; data; GridCfg=null; ReadGrid=null; Ns=null; Inf=null
            tf.Show();
        }

        private void MenuItem_Tables_ShowText_T1_Click(object sender, EventArgs e)
        {
            MyLib.writeln(this.vsh,"T1:");
            T1.Show(this.vsh);
        }

        private void MenuItem_Tables_ShowText_T2_Click(object sender, EventArgs e)
        {
            MyLib.writeln(this.vsh, "T2:"); 
            T2.Show(this.vsh);
        }

        private void MenuItem_Tasks_HydroResistances_MainResistance_AllResistance_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tasks_HydroResistances_MainResistance_LocalResistance_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tasks_HydroResistances_MainResistance_WayResistances_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tasks_HydroResistances_ShowCurrentLevel_AllResistance_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tasks_HydroResistances_ShowCurrentLevel_LocalResistance_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tasks_HydroResistances_ShowCurrentLevel_WayResistance_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tasks_HydroResistances_EnterCurrent_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tasks_HydroResistances_LevelUp_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tasks_HydroResistances_AddResistance_LocalResistance_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tasks_HydroResistances_AddResistanceWayResistance_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tasks_HydroResistances_AddResistance_AnyResistance_Click(object sender, EventArgs e)
        {

        }

        private void MenuItem_Tasks_HydroResistances_DeleteCurrent_Click(object sender, EventArgs e)
        {

        }

        

        private void MenuItem_Tasks_Tables_Set_СoncatRules_SetOptions_Click(object sender, EventArgs e)
        {
            DataTopic.DataN = 4;
            CurrentTable = this.TableConcatRules.GetAsTable();
            TableForm tblF = new TableForm(this, CurrentTable, DataTopic);
            tblF.Show();
        }

        private void MenuItem_Task_Tables_Add_ByComplexRulesCellByCellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //public TTable AddTableWithRulesCellByCellTo(TTable Tbl1, TTable Tbl2, TableInfo_ConcrRepr TblInfExt2, ref TableInfo_ConcrRepr TblInfIni, ref TableInfo_ConcrRepr TblInfActual, bool ToWriteInfo = true, TTablesConcatRules TablesConcatRulesExt = null, int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1, TValsShowHide vsh = null)
            TableInfo_ConcrRepr TblInf2 = T2.GetTableInfo_ConcrRepr(), TblInf1Ini = T1.GetTableInfo_ConcrRepr(), TblInf3Actual = (TableInfo_ConcrRepr)TblInf1Ini.Clone();
            bool ToWriteInfo=true;
            int AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13 = 1;
            T3=T1.AddTableWithRulesCellByCellTo(T1, T2, TblInf2, TblInf1Ini, ref TblInf3Actual, ToWriteInfo, TableConcatRules, AreEqualBy_N0_Names_1_2_3_21_32_31_123_ActiveN4_ValAsDbl5Int6Bool7Str8_Full9_AllNames10_Items11_NamesAndItems12_ItemsAndActiveN13, vsh);
        }
//mark3
        private void MenuItem_Test_SQLite_Test1_Click(object sender, EventArgs e)
        {
            string[] ColNames, CurLineStr;
            int countRecs = 0, QCols=0;
            //
            string commandText;
            SQLiteCommand Command;
            SQLiteDataReader reader;
            //DataColumn Column;//ce exist!
            //DataRow Row;//ce exist!
            //DataTable TblStd; //ce exist!
            //
            DataCellRow LineOfColHeader = new DataCellRow(new DataCell[] { new DataCell(new string[] { "Название", "Name" }, 2), new DataCell(new string[] { "Автор", "Author" }, 2), new DataCell(new string[] { "Издательство", "Publisher" }, 2), new DataCell("Year"), new DataCell(new string[] { "Цена", "Price" }, 2), new DataCell(new string[] { "Новинка", "IsNew" }, 2) }, 6);
            DataCellRowCoHeader[] rows = new DataCellRowCoHeader[3];
            rows[1 - 1] = new DataCellRowCoHeader(new DataCell(1), new DataCellRow(new DataCell[] { new DataCell("Иванов И. И."), new DataCell("Питон для начинающих"), new DataCell("o'Reylly"), new DataCell(2001), new DataCell(5.1), new DataCell(1) }, 6));
            rows[2 - 1] = new DataCellRowCoHeader(new DataCell(2), new DataCellRow(new DataCell[] { new DataCell("Петров П. П."), new DataCell("Питон для BackEnd"), new DataCell("Бином"), new DataCell(2002), new DataCell(5.2), new DataCell(0) }, 6));
            rows[3 - 1] = new DataCellRowCoHeader(new DataCell(2), new DataCellRow(new DataCell[] { new DataCell("Петров П. П."), new DataCell("Питон для DataScience & Machine Learning"), new DataCell("Бином"), new DataCell(2003), new DataCell(5.3), new DataCell(0) }, 6));
            //SQLiteAuthorizerActionCode'lite
            //SQLiteConnection db = new SQLiteConnection();
            //DataTable dt = new DataTable();
            DataCellRow LineOfColHeader_Read=null,//temporally
                        CurLineRow,
                        ColOfLineHeader=null;
            DataCellRow[]content;
            DataCellRowCoHeader RowHeadered;
            DataCell CurCell;
            DataCell[] Cells;
            TTable tbl=null;
            string dbSPath = @"C:\TestDB.db", dbSCnct = "Data Source=" + dbSPath + "; Version=3;", cs;
            if (!File.Exists(dbSPath))
            { // если базы данных нету, то...
                SQLiteConnection.CreateFile(dbSPath);
            }
            using (SQLiteConnection Connect = new SQLiteConnection(dbSCnct)) // в строке указывается к какой базе подключаемся
            {
                Connect.Open();
                //commandText = "CREATE TABLE IF NOT EXISTS [dbTableName] ( [id] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, [Name] VARCHAR(90), [Author] VARCHAR(40), [Publisher] VARCHAR(90), [Year] Integer, [Price] Real)";
                commandText = "CREATE TABLE IF NOT EXISTS 'Books' ( id INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, Name VARCHAR(90), Author VARCHAR(40), Publisher VARCHAR(90), Year Integer, Price Real, IsNew Integer)";
                Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();
                //commandText = "INSERT INTO [dbTableName] ([Name], [Author], [Publisher], [Year], [Price],[IsNew]) Values ('Иванов И. И.', 'Питон для начинающих', 'o'Reylly', 2001, 5.1, 1)";
                commandText = "INSERT INTO Books (Name, Author, Publisher, Year, Price, IsNew) Values ('Иванов И. И.', 'Питон для начинающих', 'o`Reylly', 2001, 5.1, 1)";
                Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();
                MessageBox.Show("DB Table Created");
                commandText = "SELECT * from 'Books'";
                Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();
                //
                reader = Command.ExecuteReader();
                //
                ColNames = new string[reader.FieldCount];
                CurLineStr = new string[reader.FieldCount];
                QCols = reader.FieldCount;
                Cells = new DataCell[QCols];
                for (int i = 1; i <= QCols; i++){
                    ColNames[i - 1] = reader.GetName(i - 1);
                    cs = ColNames[i - 1];
                }
                while (reader.Read()){
                    countRecs++;
                    for (int i = 1; i <= QCols; i++){
                        CurLineStr[i - 1] = reader.GetValue(i - 1).ToString();
                        //Cells[i-1]=new DataCell(reader.GetValue(i - 1));//so ne works, types nefit mismatch
                        Cells[i - 1] = new DataCell(CurLineStr[i - 1]);
                    }
                    LineOfColHeader_Read = new DataCellRow(ColNames, QCols);
                    CurLineRow = new DataCellRow(Cells, QCols);
                    content=new DataCellRow[1];
                    content[1-1]=CurLineRow;
                    if (countRecs == 1){
                        tbl = new TTable(
                            new TableInfo(true, false, true, 1, QCols),
                            false, content, LineOfColHeader_Read, ColOfLineHeader,
                            new TableHeaders(new DataCell("SQLite test table reading"), new DataCell("N"), new DataCell("Data")),
                            true);

                    }else if (countRecs > 1){
                        RowHeadered=new DataCellRowCoHeader(null, CurLineRow);
                        tbl.AddLine(RowHeadered);
                    }
                }
                DataTopic.DataN = 0;
                TableForm tblF = new TableForm(this, tbl, DataTopic);
                tblF.Show();
                //--------------------------------------------------------------------------------------------------------------
                DataTable TableSchema = reader.GetSchemaTable();
                TTable tblS=null;
                int QColumnDataItems = TableSchema.Columns.Count;
                int QColsDisplayed = TableSchema.Rows.Count;
                string[]ColDataItemsNames = new string[QColumnDataItems];
                Cells = new DataCell[QColumnDataItems];
                CurLineStr = new string[QColumnDataItems];
                for (int i = 1; i <= QColumnDataItems; i++)
                {
                    ColDataItemsNames[i - 1]=TableSchema.Columns[i - 1].Caption;
                    cs  = TableSchema.Columns[i - 1].Caption;
                }
                //cs = TableSchema.Rows[1-1][ColDataItemsNames[1 - 1]].ToString();//works
                for (int i = 1; i <= QColsDisplayed; i++)
                {
                    for (int j = 1; j <= QColumnDataItems; j++)
                    {
                        //CurLineStr[i - 1] = TableSchema.Rows[i - 1][ColDataItemsNames[j - 1]].ToString(); ;
                        cs = TableSchema.Rows[i - 1][ColDataItemsNames[j - 1]].ToString(); ;
                        CurLineStr[j - 1] = cs;
                        //Cells[i-1]=new DataCell(reader.GetValue(i - 1));//so ne works, types nefit mismatch
                        Cells[j - 1] = new DataCell(CurLineStr[j - 1]);
                    }
                    LineOfColHeader_Read = new DataCellRow(ColDataItemsNames, QColumnDataItems);
                    CurLineRow = new DataCellRow(Cells, QColumnDataItems);
                    content = new DataCellRow[1];
                    content[1 - 1] = CurLineRow;
                    if (i == 1)
                    {
                        tblS = new TTable(
                            new TableInfo(true, false, true, 1, QColumnDataItems),
                            false, content, LineOfColHeader_Read, ColOfLineHeader,
                            new TableHeaders(new DataCell("SQLite table STRUCTURE"), new DataCell("N"), new DataCell("Data")),
                            true);

                    }
                    else if (i > 1)
                    {
                        RowHeadered = new DataCellRowCoHeader(null, CurLineRow);
                        tblS.AddLine(RowHeadered);
                    }
                }
                DataTopic.DataN = 0;
                TableForm tblFS = new TableForm(this, tblS, DataTopic);
                tblFS.Show();
                //---------------------------------------------------------------------------------------------------------------
                //commandText="Create Table sqlite_schema (type Text, name Text, tbl_name TEXT, rootpage INTEGER, sql TEXT)";
                /*CreateAccessibilityInstance TableCellAccessConfiguration sqlite_schema (
                  typeof Text,
                  namespace Text,
                  tbl_name TEXT,
                        rootpage INTEGER,
                          sql TEXT);
                     * */
                //string[] TableNames;
                string TablesAll="All tables names of this DB: ";
                List<string> TableNamesList = new List<string>();
                string[] TableNamesArr;
                int CountTables;
                commandText = "SELECT name FROM sqlite_schema WHERE type='table' ORDER BY name;";
                Command = new SQLiteCommand(commandText, Connect);
                Command.ExecuteNonQuery();
                reader = Command.ExecuteReader();
                while (reader.Read()){
                    TableNamesList.Add(reader.GetValue(1 - 1).ToString());
                    TablesAll=TablesAll+" "+reader.GetValue(1 - 1).ToString();
                }
                TableNamesArr=TableNamesList.ToArray();
                for (int i = 1; i <= TableNamesList.Count; i++)
                {
                    TablesAll = TablesAll + " " + TableNamesArr[i-1];
                }
                MyLib.writeln(this.vsh, TablesAll);
                MessageBox.Show(TablesAll);
                
            }//using (SQLiteConnection Connect
        }//fn

        

        private void MenuItem_Tasks_PipeLinePrimitive_ShowCur_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Excluded");
            /*this.PipeLinePrimitive.Tmp = this.PipeLinePrimitive.Cur;
            TTable tbl = this.PipeLinePrimitive.Components_GetAsTable();
            //
            DataTopic.DataTopicN = 4;
            DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 1;
            DataTopic.DataN = 2;
            DataTopic.SelectedTableLineNatN = 1;
            DataTopic.SelectedTableColumnNatN = 1;
            TableForm UniTbl = new TableForm(this);
            UniTbl.AcceptTable(tbl, DataTopic); 
            UniTbl.Show();*/
        }

        private void MenuItem_Tasks_PipeLinePrimitive_Set_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Excluded");
            /*
            //this.PipeLinePrimitive.Tmp = this.PipeLinePrimitive.Cur;
            this.PipeLinePrimitive.GotoFirst();
            TTable tbl = this.PipeLinePrimitive.Components_GetAsTable();
            //
            DataTopic.DataTopicN = 4;
            DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 1;
            DataTopic.DataN = 1;
            DataTopic.SelectedTableLineNatN = 1;
            DataTopic.SelectedTableColumnNatN = 1;
            TableForm UniTbl = new TableForm(this);
            UniTbl.AcceptTable(tbl, DataTopic);
            UniTbl.Show();
            */
        }

        private void MenuItem_Tasks_PipeLinePrimitive_Enter_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Excluded");
            /*
            this.PipeLinePrimitive.SetN(this.DataTopic.SelectedTableLineNatN);
            this.PipeLinePrimitive.Enter();
            //
            TTable tbl = this.PipeLinePrimitive.Components_GetAsTable();
            DataTopic.DataTopicN = 4;
            //DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 1;
            DataTopic.DataN = 1;
            DataTopic.SelectedTableLineNatN = 1;
            DataTopic.SelectedTableColumnNatN = 1;
            TableForm UniTbl = new TableForm(this);
            UniTbl.AcceptTable(tbl, DataTopic);
            UniTbl.Show();
            */
        }

        private void MenuItem_Tasks_PipeLinePrimitive_Up_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Excluded");
            /*
            this.PipeLinePrimitive.GotoLevelUp();
            //
            TTable tbl = this.PipeLinePrimitive.Components_GetAsTable();
            DataTopic.DataTopicN = 4;
            //DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 1;
            DataTopic.DataN = 1;
            DataTopic.SelectedTableLineNatN = 1;
            DataTopic.SelectedTableColumnNatN = 1;
            TableForm UniTbl = new TableForm(this);
            UniTbl.AcceptTable(tbl, DataTopic);
            UniTbl.Show();
             * */
        }

        private void MenuItem_Tasks_PipeLinePrimitive_Next_Click(object sender, EventArgs e)
        {
             MessageBox.Show("Excluded");
            /*
            int N = this.DataTopic.SelectedTableLineNatN;
            this.PipeLinePrimitive.GotoNext();
            */
        }

        private void MenuItem_Tasks_PipeLinePrimitive_Add_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Excluded");
            /*
            //this.PipeLinePrimitive.Add();
            this.PipeLinePrimitive.AddCopy();
            DataTopic.DataTopicN = 4;
            //DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 1;
            DataTopic.DataN = 1;
            DataTopic.SelectedTableLineNatN = 1;
            DataTopic.SelectedTableColumnNatN = 1;
            TTable tbl = this.PipeLinePrimitive.Components_GetAsTable();
            TableForm UniTbl = new TableForm(this);
            UniTbl.AcceptTable(tbl, DataTopic);
            UniTbl.Show();
            */
        }

        private void tryRefClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Prob a = new Prob(), b = new Prob(), c = new Prob();
            a.s = "a";
            b.s = "b";
            c.s = "c";
            MyLib.writeln(this.vsh, "initially: a=" + a.s + " b=" + b.s + " c=" + c.s);
            c = ToTry.GetIt(b);
            MyLib.writeln(this.vsh, "after return b to assign c: a=" + a.s + " b=" + b.s + " c=" + c.s);
            b.s = "b_new";
            MyLib.writeln(this.vsh, "after new assignment of b: a=" + a.s + " b=" + b.s + " c=" + c.s);
            MyLib.writeln(this.vsh, "this means rthat return creates a usual ref, like = sign");
            int zero = 0;
        }

        private void accessTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] ColNames, CurLineStr;
            int countRecs = 0, QCols = 0;
            DataCell[] Cells = null;
            DataCellRow LineOfColHeader_Read, CurLineRow, ColOfLineHeader=null;
            DataCellRow[] content = null;
            DataCellRowCoHeader RowHeadered;
            TTable tbl=null;
            //DataColumn Column;//ce exist!
            //DataRow Row;//ce exist!
            //DataTable TblStd; //ce exist!
            //
            //
            string commandText;
            OleDbCommand Command;
            OleDbDataReader reader;
            //string connectionString_Example ="provider=Microsoft.Jet.OLEDB.4.0;" +"data source=C:\data\dbase.mdb";"
            string dbSPath = @"C:\Temp\kyn.mdb", dbSCnct = "provider=Microsoft.Jet.OLEDB.4.0; data source=" + dbSPath+";", cs;
            if (!File.Exists(dbSPath))
            { // если базы данных нету, то...
                //SQLiteConnection.CreateFile(dbSPath);//for analogy
                //OleDbConnection.CreateFile(dbSPath);//OleDbConnection ne ha CreateFile!
            }
            using (OleDbConnection Connect = new OleDbConnection(dbSCnct)) // в строке указывается к какой базе подключаемся
            {
                Connect.Open();
                //commandText = "SELECT * from 'IniDataTable'";//query syntax error
                commandText = "SELECT * from IniDataTable";
                Command = new OleDbCommand(commandText, Connect);
                Command.ExecuteNonQuery();
                reader = Command.ExecuteReader();
                //
                ColNames = new string[reader.FieldCount];
                CurLineStr = new string[reader.FieldCount];
                QCols = reader.FieldCount;
                Cells = new DataCell[QCols];
                for (int i = 1; i <= QCols; i++)
                {
                    ColNames[i - 1] = reader.GetName(i - 1);
                    cs = ColNames[i - 1];
                }
                while (reader.Read())
                {
                    countRecs++;
                    for (int i = 1; i <= QCols; i++)
                    {
                        CurLineStr[i - 1] = reader.GetValue(i - 1).ToString();
                        //Cells[i-1]=new DataCell(reader.GetValue(i - 1));//so ne works, types nefit mismatch
                        Cells[i - 1] = new DataCell(CurLineStr[i - 1]);
                    }
                    LineOfColHeader_Read = new DataCellRow(ColNames, QCols);
                    CurLineRow = new DataCellRow(Cells, QCols);
                    content = new DataCellRow[1];
                    content[1 - 1] = CurLineRow;
                    if (countRecs == 1)
                    {
                        tbl = new TTable(
                            new TableInfo(true, false, true, 1, QCols),
                            false, content, LineOfColHeader_Read, ColOfLineHeader,
                            new TableHeaders(new DataCell("Access test table reading"), new DataCell("N"), new DataCell("Data")),
                            true);

                    }
                    else if (countRecs > 1)
                    {
                        RowHeadered = new DataCellRowCoHeader(null, CurLineRow);
                        tbl.AddLine(RowHeadered);
                    }
                }
                DataTopic.DataN = 0;
                TableForm tblF = new TableForm(this, tbl, DataTopic);
                tblF.Show();
            }
            
        }

        private void __jTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TValsShowHide vsh = new TValsShowHide();
            vsh.box = this.listBox1;
            //int[] digits={10, 1,1,1};
            //int[] digits = {  100, 10, 50, 1, 10 };//149 //CXLIX
            //int[] digits = {  100, 100, 10, 50, 1, 10 };//249 //CCXLIX
            //int[] digits = {  100, 100, 50, 10, 10, 1, 10 };//279 //CCLXXIX
            int[] digits = { 100, 100, 10,  100, 1, 10 };//299 //CCXCIX
            int N = RomanNumCalc(digits, vsh);
            MyLib.writeln(vsh, "N=" + N.ToString());

        }//fn

        public int RomanNumCalc(int[] digits, TValsShowHide vsh)
        {
            int R = 0;
            int i = 0;
            //ArrayList<int[]> BigDigits=new ArrayList<int[]>();
            int Y = 0, CurDigit = 0, NextDigit=0, PrevDigit=0;// CurDigitN = 0;
            MyLib.writeln(vsh,"RomanNumCalc starts working");
            int L = digits.Length;
            MyLib.writeln(vsh,"Given quantity of digits: " + digits.Length.ToString() + "=" + L.ToString());
            //for(int i=1; i<=digits.size(); i++){
            if (L == 1) R = digits[L - 1];
            else
            {
                PrevDigit=0;
                i=1;
                while(i<=L)
                {
                    
                    CurDigit = digits[i - 1];
                    NextDigit = digits[i +1- 1];
                    if (NextDigit == CurDigit){
                        R += CurDigit;
                        R += NextDigit;
                        MyLib.writeln(vsh, "ND=CD N " + i.ToString() + " (of " + L.ToString() + ") CurDigit" + " = " + digits[i - 1].ToString() + " NextDigit= " + NextDigit.ToString() + " num= " + R.ToString());
                        i+=2;
                    }
                    else if (NextDigit > CurDigit)
                    {
                        R += (NextDigit - CurDigit);
                        MyLib.writeln(vsh, "ND>CDN " + i.ToString() + " (of " + L.ToString() + ") CurDigit" + " = " + digits[i - 1].ToString() + " NextDigit= " + NextDigit.ToString() + " num= " + R.ToString());
                        i += 2;
                    }
                    else//(NextDigit < CurDigit => waiting
                    {
                        R += CurDigit;
                        MyLib.writeln(vsh, "ND<CD. N " + i.ToString() + " (of " + L.ToString() + ") CurDigit" + " = " + digits[i - 1].ToString() + " NextDigit= " + NextDigit.ToString() + " num= " + R.ToString());
                        i++;
                    }
                    
                    
                }//for
            }
            return R;
        }
        private void MenuItem_Test1_HydroRsstncPinciple_Click(object sender, EventArgs e)
        {
            int L, H;
            int zero = 0;
            //public PrimitiveElement(int k = 0, int Succ0Parallel1 = 0, PrimitiveElement[] elems = null, int QElements = 0, int CurN = 0, int NInUpper = 0)
            //
            double k;
            HydroResistanceIniData HRIniData = new HydroResistanceIniData();
            HRIniData.kG = 1;
            //
            HRIniData.kG = 1;
            HydroPipelineElement elem1 = new HydroPipelineElement(/*1*/HRIniData, 0, null, null, 0, 0, 0, this.vsh);//PrimitiveElement elem1 = new PrimitiveElement(1, 0, null, 0);
            HRIniData.kG = 11;
            HydroPipelineElement subElem1 = new HydroPipelineElement(/*11*/HRIniData, 0, null, null, 0, 1, 1, this.vsh);// new PrimitiveElement(11);
            //PrimitiveElement subElem2 = new PrimitiveElement(12);
            HRIniData.kG = 12;
            HydroPipelineElement subElem2 = new HydroPipelineElement(/*12*/HRIniData, 1, null, null, 0, 2, 2, this.vsh);// new PrimitiveElement(12,1);
            //
            //PrimitiveElement subElem21 = new PrimitiveElement(121);
            //PrimitiveElement subElem22 = new PrimitiveElement(122);
            HRIniData.kG = 2;
            HydroPipelineElement subElem21 = new HydroPipelineElement(/*2*/HRIniData, 0, null, null, 0, 21, 1, this.vsh);//new PrimitiveElement(2);
            HRIniData.kG = 5;
            HydroPipelineElement subElem22 = new HydroPipelineElement(/*5*/HRIniData, 0, null, null, 0, 22, 2, this.vsh);// new PrimitiveElement(5);
            //
            subElem2.AddInner(subElem21);
            subElem2.AddInner(subElem22);
            //
            elem1.AddInner(subElem1);
            elem1.AddInner(subElem2);
            //
            MyLib.writeln(vsh, "");
            MyLib.writeln(vsh, "Whole Pipeline: ");
            elem1.Show(vsh);
            MyLib.writeln(vsh, "");
            //
            TTable tblMain = elem1.Main_GetAsTable();
            TTable tblCnt = elem1.Components_GetAsTable();
            //
            TableForm tblF;
            DataTopic.DataTopicN = 3;
            DataTopic.DataN = 1;
            CurrentTable = tblMain;
            tblF = new TableForm(this, CurrentTable, DataTopic);
            //tblF.Show();
            DataTopic.DataTopicN = 3;
            DataTopic.DataN = 2;
            CurrentTable = tblCnt;
            DataTopic.DataN = 5;
            //tblF = new TableForm(this, CurrentTable, DataTopic);
            //tblF.Show();
            //
            //
            MyLib.writeln(this.vsh, "");
            double R = elem1.CoutKSum(this.vsh);
            MyLib.writeln(this.vsh, "Result of calc: k=" + R.ToString());
            MyLib.writeln(this.vsh, "");
            //
            //---------------------------------------------------------
            int curN, outerN;
            //double k;
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Idem pipeline, alt method");
            HRIniData.kG = 11;
            HydroPipelineElement R1 = new HydroPipelineElement(/*11*/HRIniData, 0, null, null, 0, 1, 0, vsh);
            HRIniData.kG = 12;
            HydroPipelineElement R12 = new HydroPipelineElement(/*12*/HRIniData, 0, null, null, 0, 12, 0, vsh);
            HRIniData.kG = 2;
            HydroPipelineElement R121 = new HydroPipelineElement(/*2*/HRIniData, 0, null, null, 0, 121, 0, vsh);
            HRIniData.kG = 5;
            HydroPipelineElement R122 = new HydroPipelineElement(/*5*/HRIniData, 0, null, null, 0, 122, 0, vsh);
            MyLib.writeln(this.vsh, "trying to add R12 to R1 suc");
            R1.AddSucSmart(R121);
            R1.Set_k(1);
            MyLib.writeln(this.vsh,"must be added R12 to R1 suc");
            //MyLib.writeln(this.vsh, "Idem pipeline, now is:");
            R1.Show(this.vsh);
            MyLib.writeln(this.vsh, "");
            R = elem1.CoutKSum(this.vsh);
            MyLib.writeln(this.vsh, "Result of calc: k=" + R.ToString());
            MyLib.writeln(this.vsh, "");
            R1.Set_k_SubEltN(11, 1);
            R1.SetN_SubEltN(11, 1);
            MyLib.writeln(this.vsh,"same, changed params (R[1])=R11, k=11)");
            R1.Show(this.vsh);
            MyLib.writeln(this.vsh, "trying to add R122 to R121 par");
            R1.elems[2-1].AddParSmart(R122,0,0,this.vsh);
            MyLib.writeln(this.vsh,"must be added R122 to R121 par");
            R1.Show(this.vsh);
            R1.elems[2-1].Set_k(12);//R11.k=11
            R1.elems[2-1].SetN(12);
            (R1.elems[2-1]).elems[1-1].Set_k(2);//R11.k=11
            (R1.elems[2-1]).elems[1-1].SetN(121);
            MyLib.writeln(this.vsh, "same, changed params (R[2])=R12, k=12, R[2][1])=R121, k=121)");
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Idem pipeline, alt method,  is:");
            R1.Show(this.vsh);
            MyLib.writeln(this.vsh, "");
            //--------------------------------------------------------------------------------------
            MyLib.writeln(this.vsh,"More complex'd pipeline: R121+suc, Now ic s'alt R121 s'complex");
            (R1.elems[2-1]).elems[1-1].AddSucSmart(R122,/*0,*/0,this.vsh);
            (R1.elems[2-1]).elems[1-1].SetN(13);
            ((R1.elems[2-1]).elems[1-1]).elems[1-1].SetN(121);
            ((R1.elems[2-1]).elems[1-1]).elems[2-1].SetN(123);
            MyLib.writeln(this.vsh, "More complex'd pipeline, is:");
            R1.Show(this.vsh);
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Coords:");
            R1.ShowCoords_IpseAndSub(this.vsh);
            MyLib.writeln(this.vsh, "");
            //----------------------------------------------------------
            //works well
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Try Recursive search.");
            HydroPipelineElement RToSeekIn = null;
            //
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Search of N=1 in: "+R1.ToString());
            RToSeekIn = R1.SeekElementByNPrimitive(1, this.vsh);
            if (RToSeekIn == null)
            {
                MyLib.writeln(this.vsh, "Search of N=1: Not found");
            }
            else
            {
                MyLib.writeln(this.vsh, "Search of N=1: Found at: " + RToSeekIn.ToString());
            }
            //
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Search of N=1 in: " + R1.elems[1-1].ToString());
            RToSeekIn = R1.elems[1 - 1].SeekElementByNPrimitive(1, this.vsh);
            if (RToSeekIn == null)
            {
                MyLib.writeln(this.vsh, "Search of N=1: Not found");
            }
            else
            {
                MyLib.writeln(this.vsh, "Search of N=1: Found at: " + RToSeekIn.ToString());
            }
            //
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Search of N=122 in: " + R1.ToString());
            RToSeekIn = R1.SeekElementByNPrimitive(122, this.vsh);
            if (RToSeekIn == null)
            {
                MyLib.writeln(this.vsh, "Search of N=122: Not found");
            }
            else
            {
                MyLib.writeln(this.vsh, "Search of N=122: Found at: " + RToSeekIn.ToString());
            }
            //
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Search of N=122 in: " + (R1.elems[2 - 1]).elems[2 - 1].ToString());
            RToSeekIn = (R1.elems[2 - 1]).elems[2 - 1].SeekElementByNPrimitive(122, this.vsh);
            if (RToSeekIn == null)
            {
                MyLib.writeln(this.vsh, "Search of N=122: Not found");
            }
            else
            {
                MyLib.writeln(this.vsh, "Search of N=122: Found at: " + RToSeekIn.ToString());
            }
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "");
            //--------------------------------------------------------------------------------------
            
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Try Recursive search.");
            /*HydroPipelineElement*/ RToSeekIn = null;
            //
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Search of x=7, y=7 in: " + R1.ToString());
            RToSeekIn = R1.SeekElementByDelegate(2, 7, 7, this.vsh);
            if (RToSeekIn == null)
            {
                MyLib.writeln(this.vsh, "Search of x=7, y=7: Not found");
            }
            else
            {
                MyLib.writeln(this.vsh, "Search of x=7, y=7: Found at: " + RToSeekIn.ToString());
            }
            //
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Search of x=7, y=7 in: " + R1.elems[1 - 1].ToString());
            RToSeekIn = R1.elems[1 - 1].SeekElementByDelegate(2, 7, 7, this.vsh);
            if (RToSeekIn == null)
            {
                MyLib.writeln(this.vsh, "Search of x=7, y=7: Not found");
            }
            else
            {
                MyLib.writeln(this.vsh, "Search of x=7, y=7: Found at: " + RToSeekIn.ToString());
            }
            //
            //MyLib.writeln(this.vsh, "");
            //MyLib.writeln(this.vsh, "Search of x=7, y=7 in: " + R1.ToString());
            //RToSeekIn = R1.SeekElementByDelegate(2, 7, 7, this.vsh);
            //if (RToSeekIn == null)
            //{
            //    MyLib.writeln(this.vsh, "Search of N=122: Not found");
            //}
            //else
            //{
            //    MyLib.writeln(this.vsh, "Search of N=122: Found at: " + RToSeekIn.ToString());
            //}
            //
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Search of x=7, y=7 in: " + (R1.elems[2 - 1]).elems[2 - 1].ToString());
            RToSeekIn = (R1.elems[2 - 1]).elems[2 - 1].SeekElementByDelegate(2, 7, 7, this.vsh);
            if (RToSeekIn == null)
            {
                MyLib.writeln(this.vsh, "Search of x=7, y=7: Not found");
            }
            else
            {
                MyLib.writeln(this.vsh, "Search of x=7, y=7: Found at: " + RToSeekIn.ToString());
            }
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "");
            
            //----------------------------------------------------------
            //MyLib.writeln(this.vsh, "L");
            //int Len = R1.vis_L(this.vsh);
            //MyLib.writeln(this.vsh, "L=" + Len.ToString());
            //MyLib.writeln(this.vsh, "");
            //MyLib.writeln(this.vsh, "yUpper");
            //int yUpper = R1.vis_yUpper(this.vsh);
            //MyLib.writeln(this.vsh, "yUpper=" + yUpper.ToString());
            //MyLib.writeln(this.vsh, "");
            //MyLib.writeln(this.vsh, "yUpper");
            //int yLower = R1.vis_yLower(this.vsh);
            //MyLib.writeln(this.vsh, "yLower=" + yLower.ToString());
            //MyLib.writeln(this.vsh, "");
            //------------------------------------------------------------
            //--------------------------------------------------------------------------------------

            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Try Recursive \"deep\" search.");
            /*HydroPipelineElement*/
            RToSeekIn = null;
            //
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Search of x=7, y=7 in: " + R1.ToString());
            RToSeekIn = R1.SeekElementByCoordsBelongingPrimitive(7, 7, this.vsh);
            if (RToSeekIn == null)
            {
                MyLib.writeln(this.vsh, "Search of x=7, y=7: Not found");
            }
            else
            {
                MyLib.writeln(this.vsh, "Search of x=7, y=7: Found at: " + RToSeekIn.ToString());
            }
            //
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Search of x=7, y=7 in: " + R1.elems[1 - 1].ToString());
            RToSeekIn = R1.elems[1 - 1].SeekElementByCoordsBelongingPrimitive(7, 7, this.vsh);
            if (RToSeekIn == null)
            {
                MyLib.writeln(this.vsh, "Search of x=7, y=7: Not found");
            }
            else
            {
                MyLib.writeln(this.vsh, "Search of x=7, y=7: Found at: " + RToSeekIn.ToString());
            }
            //
            //MyLib.writeln(this.vsh, "");
            //MyLib.writeln(this.vsh, "Search of x=7, y=7 in: " + R1.ToString());
            //RToSeekIn = R1.SeekElementByDelegate(2, 7, 7, this.vsh);
            //if (RToSeekIn == null)
            //{
            //    MyLib.writeln(this.vsh, "Search of N=122: Not found");
            //}
            //else
            //{
            //    MyLib.writeln(this.vsh, "Search of N=122: Found at: " + RToSeekIn.ToString());
            //}
            //
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Search of x=7, y=7 in: " + (R1.elems[2 - 1]).elems[2 - 1].ToString());
            RToSeekIn = (R1.elems[2 - 1]).elems[2 - 1].SeekElementByCoordsBelongingPrimitive(7, 7, this.vsh);
            if (RToSeekIn == null)
            {
                MyLib.writeln(this.vsh, "Search of x=7, y=7: Not found");
            }
            else
            {
                MyLib.writeln(this.vsh, "Search of x=7, y=7: Found at: " + RToSeekIn.ToString());
            }
            MyLib.writeln(this.vsh, "");
            //
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Search of x=2, y=2 in: " + R1.ToString());
            RToSeekIn = R1.SeekElementByCoordsBelongingPrimitive(2, 2, this.vsh);
            if (RToSeekIn == null)
            {
                MyLib.writeln(this.vsh, "Search of x=2, y=2: Not found");
            }
            else
            {
                MyLib.writeln(this.vsh, "Search of x=2, y=2: Found at: " + RToSeekIn.ToString());
            }
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "");

            //----------------------------------------------------------
            //MyLib.writeln(this.vsh, "L");
            //int Len = R1.vis_L(this.vsh);
            //MyLib.writeln(this.vsh, "L=" + Len.ToString());
            //MyLib.writeln(this.vsh, "");
            //MyLib.writeln(this.vsh, "yUpper");
            //int yUpper = R1.vis_yUpper(this.vsh);
            //MyLib.writeln(this.vsh, "yUpper=" + yUpper.ToString());
            //MyLib.writeln(this.vsh, "");
            //MyLib.writeln(this.vsh, "yUpper");
            //int yLower = R1.vis_yLower(this.vsh);
            //MyLib.writeln(this.vsh, "yLower=" + yLower.ToString());
            //MyLib.writeln(this.vsh, "");
            //------------------------------------------------------------

            //MessageBox.Show("Wa calcs, nu vis");
            HydrSchemVisualizer SchemForm = new HydrSchemVisualizer();
            //SchemForm.Show();
            //
            HydroSchemCanvas hssh = new HydroSchemCanvas();
            hssh.dg = SchemForm.GetTableCanvas();
            //L = elem1.vis_L(this.vsh);
            //H = elem1.vis_H(this.vsh);
            L = R1.vis_L(null);//this.vsh
            H = R1.vis_H(null);//this.vsh
            //hssh.SetSize(elem1.vis_L(this.vsh), elem1.vis_H(this.vsh));
            //hssh.SetSize(elem1.vis_L_WithConnectors(this.vsh), elem1.vis_H(this.vsh));
            hssh.SetSize(R1.vis_L_WithConnectors(null), R1.vis_H(null));//this.vsh
            //elem1.vis_DisplayAll(hssh, this.vsh);
            R1.vis_Display_WithSubElts(hssh, this.vsh);
            SchemForm.TopR = R1;
            SchemForm.f1 = this;
            SchemForm.Show();
            MyLib.writeln(vsh, "");
            MyLib.writeln(vsh, "");
           //
        }

        private void MenuItem_Test1_RecursiveComb_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is incorrect!");
            int QVals = 3;
            int QNumerats = 3;
            //int denom = QVals * QNumerats;
            //int[] pCur = new int[denom];
            //List<int[]>lst;
            RecursionPartsStruct data=new RecursionPartsStruct(QVals, QNumerats);
            int N=1, countAll=0, countSuitable=0;
            CalcParts(ref N, ref countAll, ref countSuitable, ref data, this.vsh);
            MyLib.writeln(this.vsh, "finish. Incorrect");

        }
        void CalcParts(ref int N, ref int countAll, ref int countSuitable, ref RecursionPartsStruct data, TValsShowHide vsh = null){
            string inf="";
            countAll++;
            inf = countAll.ToString() + " : ";
            if (vsh != null)MyLib.writeln(vsh, "var N " + countAll.ToString() + " val N " + N.ToString());
            for (int i = 1; i <= data.denom; i++){
                data.pCur[N - 1] = i;
                if (N == data.denom){
                    data.CurSum = 0;
                    for (int j = 1; j <= data.denom; j++){
                        data.CurSum += data.pCur[j - 1];
                        inf = inf + data.pCur[j - 1].ToString();
                        if (j < data.denom) inf = inf + " + ";
                    }
                    inf = inf + " = " + data.CurSum.ToString()+"  ";
                    if (data.CurSum == data.denom)
                    {
                        countSuitable++;
                        data.lst.Add(data.pCur);
                        inf = inf + " = " + data.denom.ToString() +" => "+ countSuitable.ToString()+"  ";
                    }
                    if (vsh != null) MyLib.writeln(vsh, inf);
                    //N = 1;
                }else{
                    N++;
                    CalcParts(ref N, ref countAll, ref countSuitable, ref data, vsh);
                }//if
            }//for
        }//fn
        //
       
        private void MenuItem_Test1_RecursiveCombJv_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wait a little...");
            //int QVals = 4, QNumerats = 4;
            //DataRecStr data = new DataRecStr(QVals, QNumerats);
            //data.N = 1;
            //data = CalcRecJv(data, this.vsh);
            //
            int QVals = 4, QNumerats = 20;// 4;
            DataRecStr1 data = new DataRecStr1(QVals, QNumerats);
            data.N = 1;
            data.Denom =QNumerats;//data.Denom = 10;
            data = CalcRecJv1(data, this.vsh);
            //
            ListOfIntArrays[] DataArr;
            DataArr = data.lst.ToArray<ListOfIntArrays>();
            //
            int[] p;
            string st;
            int sum;
            //
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "Answer: " + DataArr.Length.ToString() + " cases of sum, equal to " + data.Denom.ToString() + ", found");
            MyLib.writeln(this.vsh, "");
            //
            for (int i = 1; i <= DataArr.Length; i++)
            {
                st = i.ToString() + " " + (DataArr[i - 1].param).ToString()+ " ";
                p = DataArr[i - 1].arr;
                sum = 0;
                for (int j = 1; j <= p.Length; j++)
                {
                    st = st + p[j - 1].ToString();
                    sum = sum + p[j - 1];
                    if (j < p.Length) st = st + " + ";
                }
                st = st + " = " + sum.ToString();
                MyLib.writeln(vsh, st);
            }
            //
            //MyLib.writeln(this.vsh, "");
            //MyLib.writeln(this.vsh, "Answer: " + DataArr.Length.ToString() + " cases of sum, equal to " + data.Denom.ToString() + ", found");
            //MyLib.writeln(this.vsh, "");
        }//fn menu item
        //
        public DataRecStr CalcRecJv(DataRecStr data, TValsShowHide vsh)
        {
        string st="";
        data.countCall++;
        int N=data.N, countCall=data.countCall;//ne data.countCall ob uz return ab recursio
        int sum;
        MyLib.writeln(vsh,"Start. N="+data.N.ToString()+" countCall="+countCall.ToString());
        for(int i=1; i<=data.QNumerats; i++){
            data.countAll++;
            //data.p[data.N-1]=i;
            data.p[N-1]=i; //ne data.N ob uz return ab recursio
            //st=" i="+Integer.toString(i)+" N="+Integer.toString(data.N)+" ";
            //System.out.println("i="+Integer.toString(i));
            st=" countCall="+countCall.ToString()+" countAll="+data.countAll.ToString()+" i="+i.ToString()+" ";
            //if(data.N==data.QVals){
            if(N==data.QVals){ //ne data.N ob uz return ab recursio
                sum=0;
                for(int j=1; j<=data.QVals; j++){
                    sum=sum+data.p[j-1];
                    st=st+data.p[j-1].ToString();
                    if(j<data.QVals) st=st+" + ";
                }
                st=st+" = "+sum.ToString()+" ";
                MyLib.writeln(vsh,st);
                //if(data.countAll<Math.pow(data.QVals, data.QNumerats) && i==data.QNumerats)data.N=1;
                if(data.countAll<Math.Pow(data.QNumerats, data.QVals)){
                    data.N=1;
                }
            }else{
                for(int j=1; j<=N; j++){
                    st=st+data.p[j-1].ToString();
                    if(j<N) st=st+" + ";
                }
                //data.N=data.N+1;
                MyLib.writeln(vsh,"("+st+")");
                data.N=N+1;
                MyLib.writeln(vsh,"next. N="+data.N.ToString());
                data = CalcRecJv(data, vsh);
            }
        }
        //data.p[data.N-1]
        //System.out.println("exit. N="+Integer.toString(data.N)+" countAll="+Integer.toString(data.countAll));
        MyLib.writeln(vsh, "exit. N=" + N.ToString() + " countCall=" + countCall.ToString());
        return data;
        }//fn CalcRecJv
        public DataRecStr1 CalcRecJv1(DataRecStr1 data, TValsShowHide vsh)
        {
            string st = "";
            ListOfIntArrays larr=new ListOfIntArrays();
            larr.arr=new int[data.QVals];
            data.countCall++;
            int N = data.N, countCall = data.countCall;//ne data.countCall ob uz return ab recursio
            int sum;
            MyLib.writeln(vsh, "Start. N=" + data.N.ToString() + " countCall=" + countCall.ToString());
            for (int i = 1; i <= data.QNumerats; i++)
            {
                data.countAll++;
                //data.p[data.N-1]=i;
                data.p[N - 1] = i; //ne data.N ob uz return ab recursio
                //st=" i="+Integer.toString(i)+" N="+Integer.toString(data.N)+" ";
                //System.out.println("i="+Integer.toString(i));
                st = " countCall=" + countCall.ToString() + " countAll=" + data.countAll.ToString() + " i=" + i.ToString() + " ";
                //if(data.N==data.QVals){
                if (N == data.QVals)
                { //ne data.N ob uz return ab recursio
                    sum = 0;
                    for (int j = 1; j <= data.QVals; j++)
                    {
                        sum = sum + data.p[j - 1];
                        st = st + data.p[j - 1].ToString();
                        if (j < data.QVals) st = st + " + ";
                    }
                    st = st + " = " + sum.ToString() + " ";
                    MyLib.writeln(vsh, st);
                    //if(data.countAll<Math.pow(data.QVals, data.QNumerats) && i==data.QNumerats)data.N=1;
                    //if (data.countAll < Math.Pow(data.QNumerats, data.QVals))
                    //{
                    data.N = 1;
                    //}
                    //
                    if (sum == data.Denom)
                    {
                        MyLib.writeln(vsh, "It is reqired value : sum=" + data.Denom.ToString() + "=" + sum.ToString());
                        //larr = new ListOfIntArrays(data.p, data.countAll);
                        for (int k = 1; k <= data.p.Length; k++) larr.arr[k - 1] = data.p[k - 1];
                        larr.param = data.countAll;
                        data.lst.Add(larr);
                    }
                }
                else
                {
                    for (int j = 1; j <= N; j++)
                    {
                        st = st + data.p[j - 1].ToString();
                        if (j < N) st = st + " + ";
                    }
                    //data.N=data.N+1;
                    MyLib.writeln(vsh, "(" + st + ")");
                    data.N = N + 1;
                    MyLib.writeln(vsh, "next. N=" + data.N.ToString());
                    data = CalcRecJv1(data, vsh);
                }
            }
            //data.p[data.N-1]
            //System.out.println("exit. N="+Integer.toString(data.N)+" countAll="+Integer.toString(data.countAll));
            MyLib.writeln(vsh, "exit. N=" + N.ToString() + " countCall=" + countCall.ToString());
            return data;
        }

        private void MenuItem_Test1_StringFormat_Click(object sender, EventArgs e)
        {
            //public static string ReturnByShaublin(string data, int inLength, int QHidden, int AlignL1R2CL3CR4, string FillAft=".", string FillBef=" ", string BefCut="<", string AftCut=">", string BefNonCut=" ", string AftNonCut=" ", string BefMark="+", string AftMark=" ", TValsShowHide vsh=null)
            string s="MyString";
            int Lmal=6;
            int Lbig=15;
            int AlignL1R2CL3CR4;
            int inLength=Lmal;
            //string bef="1";
            //string aft="2";
            string FillAft=".";
            string FillBef=" ";
            string BefCut="<";
            string AftCut=">";
            string BefNonCut=" ";
            string AftNonCut=" ";
            string BefMark="+";
            string AftMark=" ";
            string data=s;
            int QHidden;
            //
            AlignL1R2CL3CR4 = 1;
            for(int i=0; i<=s.Length-(s.Length-inLength)+1; i++){
                QHidden=i;
                s=MyLib.StringFormat(data, inLength, QHidden, AlignL1R2CL3CR4, FillAft, FillBef, BefCut, AftCut, BefNonCut, AftNonCut, BefMark, AftMark, null)+"|";
                MyLib.writeln(vsh, s);
            }
            MyLib.writeln(vsh,"");
            AlignL1R2CL3CR4 = 2;
            for (int i = 0; i <= s.Length - (s.Length - inLength) + 1; i++)
            {
                QHidden = i;
                s = MyLib.StringFormat(data, inLength, QHidden, AlignL1R2CL3CR4, FillAft, FillBef, BefCut, AftCut, BefNonCut, AftNonCut, BefMark, AftMark, null) + "|";
                MyLib.writeln(vsh, s);
            }
            MyLib.writeln(vsh, "");
            AlignL1R2CL3CR4 = 3;
            for (int i = 0; i <= s.Length - (s.Length - inLength) + 1; i++)
            {
                QHidden = i;
                s = MyLib.StringFormat(data, inLength, QHidden, AlignL1R2CL3CR4, FillAft, FillBef, BefCut, AftCut, BefNonCut, AftNonCut, BefMark, AftMark, null) + "|";
                MyLib.writeln(vsh, s);
            }
            MyLib.writeln(vsh, "");
            AlignL1R2CL3CR4 = 4;
            for (int i = 0; i <= s.Length - (s.Length - inLength) + 1; i++)
            {
                QHidden = i;
                s = MyLib.StringFormat(data, inLength, QHidden, AlignL1R2CL3CR4, FillAft, FillBef, BefCut, AftCut, BefNonCut, AftNonCut, BefMark, AftMark, null) + "|";
                MyLib.writeln(vsh, s);
            }
            MyLib.writeln(vsh, "");
            for(int i=0; i<=s.Length-(s.Length-inLength)+1; i++){
                QHidden=i;
                s=MyLib.StringFormat(data, inLength, QHidden, AlignL1R2CL3CR4, FillAft, FillBef, BefCut, AftCut, BefNonCut, AftNonCut, BefMark, AftMark, vsh)+"|";
                MyLib.writeln(vsh, "");
            }
            s = "Str";
            data = s;
            AlignL1R2CL3CR4 = 1;
            for (int i = 0; i <= s.Length; i++)
            {
                QHidden = i;
                s = MyLib.StringFormat(data, inLength, QHidden, AlignL1R2CL3CR4, FillAft, FillBef, BefCut, AftCut, BefNonCut, AftNonCut, BefMark, AftMark, null) + "|";
                MyLib.writeln(vsh, s);
            }
            MyLib.writeln(vsh, "");
            AlignL1R2CL3CR4 = 2;
            for (int i = 0; i <= s.Length; i++)
            {
                QHidden = i;
                s = MyLib.StringFormat(data, inLength, QHidden, AlignL1R2CL3CR4, FillAft, FillBef, BefCut, AftCut, BefNonCut, AftNonCut, BefMark, AftMark, null) + "|";
                MyLib.writeln(vsh, s);
            }
            MyLib.writeln(vsh, "");
            AlignL1R2CL3CR4 = 3;
            for (int i = 0; i <= s.Length; i++)
            {
                QHidden = i;
                s = MyLib.StringFormat(data, inLength, QHidden, AlignL1R2CL3CR4, FillAft, FillBef, BefCut, AftCut, BefNonCut, AftNonCut, BefMark, AftMark, null) + "|";
                MyLib.writeln(vsh, s);
            }
            MyLib.writeln(vsh, "");
            AlignL1R2CL3CR4 = 4;
            for (int i = 0; i <= s.Length; i++)
            {
                QHidden = i;
                s = MyLib.StringFormat(data, inLength, QHidden, AlignL1R2CL3CR4, FillAft, FillBef, BefCut, AftCut, BefNonCut, AftNonCut, BefMark, AftMark, null) + "|";
                MyLib.writeln(vsh, s);
            }
            MyLib.writeln(vsh, "");
            for (int i = 0; i <= s.Length ; i++)
            {
                QHidden = i;
                s = MyLib.StringFormat(data, inLength, QHidden, AlignL1R2CL3CR4, FillAft, FillBef, BefCut, AftCut, BefNonCut, AftNonCut, BefMark, AftMark, vsh) + "|";
                MyLib.writeln(vsh, "");
            }
        }//fn test str fmt

        

        private void MenuItem_Test1_StringUniqueItem_Click(object sender, EventArgs e)
        {
            string[] sa = { "green", "yellow", "red", "red_R_4", "brown" };
            string val1 = "red", val2;
            string aft = "_R_" + 4.ToString(), bef = "";
            MyLib.writeln(this.vsh, "unique val for array");
            string s = "";
            for (int i = 1; i <= sa.Length; i++)
            {
                s = sa[i - 1] + " ";
            }
            MyLib.writeln(this.vsh, " array");
            MyLib.writeln(this.vsh, s);
            MyLib.writeln(this.vsh, " first val");
            MyLib.writeln(this.vsh, val1);
            val2 = MyLib.CorrectStringValToBeUniqueForStringArray(sa, val1, bef, aft, this.vsh);
            MyLib.writeln(this.vsh, "unique val=" + val2);
        }

        private void MenuItem_Test1_StringArray2DToTable_Click(object sender, EventArgs e)
        {
            string[] Arr1 = { "Shop:Goods\\Params", "Prise", "Quantity" };
            string[] Arr2 = { "Smartphone", "2000", "200" };
            string[] Arr3 = { "Notebook", "15000", "150" };
            string[][]IniArr={Arr1, Arr2, Arr3};
            //{{"Shop:Goods\\Params", "Prise", "Quantity"},
            // {"Smartphone", "2000", "200"},
            // {"Notebook", "15000", "150"}
            //};
            TTable tbl= new TTable();
            tbl.SetFrom2DArray(tbl.FormCellsRowsFrom2DArrayString(IniArr), 1, 1);
            //
            TableDataChange DataTopic = new TableDataChange();
            DataTopic.DataN = 0;
            TableForm tblF = new TableForm(this, tbl, DataTopic);
            tblF.Show();
        }

        private void MenuItem_Test_ExcelHandler_Click(object sender, EventArgs e)
        {
            int a = 230230;
            int[] digs = null;
            int ord = 0;
            string s;
            ExcelHandler excel = new ExcelHandler();
            NumberParse.IntToDigits(a, 10, ref digs, ref ord);
            MyLib.writeln(vsh, MyLib.ArraySimpleString(digs));
            //
            ExcelConnecting excelForm = new ExcelConnecting();
            excelForm.f1 = this;
            excelForm.Show();
            //
            a = 702 - 1;
            MyLib.writeln(vsh, a.ToString() + " (ZY)");
            s = excel.ShifrColN(a, vsh);
            //MyLib.writeln(vsh, MyLib.ArraySimpleString(digs));
            MyLib.writeln(vsh, s);
            a = 702;
            MyLib.writeln(vsh, a.ToString() + " (ZZ)");
            s = excel.ShifrColN(a, vsh);
            //MyLib.writeln(vsh, MyLib.ArraySimpleString(digs));
            MyLib.writeln(vsh, s);
            a = 702 + 1;
            MyLib.writeln(vsh, a.ToString() + " (AAA)");
            s = excel.ShifrColN(a, vsh);
            //MyLib.writeln(vsh, MyLib.ArraySimpleString(digs));
            MyLib.writeln(vsh, s);
            //
            a = 678;
            MyLib.writeln(vsh, a.ToString() + " (ZB)");
            s = excel.ShifrColN(a, vsh);
            //MyLib.writeln(vsh, MyLib.ArraySimpleString(digs));
            MyLib.writeln(vsh, s);
            a = 676;
            MyLib.writeln(vsh, a.ToString() + " (YZ)");
            s = excel.ShifrColN(a, vsh);
            //MyLib.writeln(vsh, MyLib.ArraySimpleString(digs));
            MyLib.writeln(vsh, s);
            a = 1354;
            MyLib.writeln(vsh, a.ToString() + " (AZB)");
            s = excel.ShifrColN(a, vsh);
            //MyLib.writeln(vsh, MyLib.ArraySimpleString(digs));
            MyLib.writeln(vsh, s);
            a = 1352;
            MyLib.writeln(vsh, a.ToString() + " (AYZ)");
            s = excel.ShifrColN(a, vsh);
            //MyLib.writeln(vsh, MyLib.ArraySimpleString(digs));
            MyLib.writeln(vsh, s);
            a = 2054;
            MyLib.writeln(vsh, a.ToString() + " (BZZ)");
            s = excel.ShifrColN(a, vsh);
            //MyLib.writeln(vsh, MyLib.ArraySimpleString(digs));
            MyLib.writeln(vsh, s);
            a = 16384;
            MyLib.writeln(vsh, a.ToString() + " (XFD)");
            s = excel.ShifrColN(a, vsh);
            //MyLib.writeln(vsh, MyLib.ArraySimpleString(digs));
            MyLib.writeln(vsh, s);
            //

        }

        private void MenuItem_Task_PipelineHydroR_NewSchem_Click(object sender, EventArgs e)
        {
            //
            HydroResistanceIniData HRIniData = new HydroResistanceIniData();
            //
            HydroPipelineElement pipelineR = new HydroPipelineElement(HRIniData);
            pipelineR.Set_k(0);
            pipelineR.SetElementsConnectionSucc();
            //
            HydrSchemVisualizer SchemForm = new HydrSchemVisualizer();
            //
            HydroSchemCanvas hssh = new HydroSchemCanvas();
            hssh.dg = SchemForm.GetTableCanvas();
            int L = pipelineR.vis_L(null);//this.vsh
            int H = pipelineR.vis_H(null);//this.vsh
            hssh.SetSize(pipelineR.vis_L_WithConnectors(null), pipelineR.vis_H(null));//this.vsh
            pipelineR.vis_Display_WithSubElts(hssh, this.vsh);
            SchemForm.TopR = pipelineR;
            SchemForm.f1 = this;
            SchemForm.Show();
        }

        private void MenuItem_Tasks_ExcelHandler_CreateCtrldExcelDoc_Click(object sender, EventArgs e)
        {
            this.excel = new ExcelHandler();
            //
            this.excel.CreateNewExcelDoc();
            if (this.excel == null)
            {
                MessageBox.Show("excel is null");
            }
        }

        private void MenuItem_Tasks_ExcelHandler_OpenCtrldExcelDoc_Click(object sender, EventArgs e)
        {
            string fName = "";
            OpenFileDialog openDialog = new OpenFileDialog();
            this.excel = new ExcelHandler();
            //
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                fName = openDialog.FileName;
                this.excel.OpenExistingExcelDoc(fName);
            }
            if (this.excel == null)
            {
                MessageBox.Show("excel is null");
            }
            string[] ss;
            //ss = this.excel.GetSheetsNames(this.vsh);
            ss = this.excel.GetSheetsNames();
        }

        private void MenuItem_Tasks_ExcelHandler_DataExchange_Click(object sender, EventArgs e)
        {
            //if (this.excel == null)
            //{
            //    MessageBox.Show("excel is null");
            //}
            //if(this.excel.GetEtappe()==1){
                ExcelConnecting1 excelForm = new ExcelConnecting1();
                excelForm.f1 = this;
                excelForm.Show();
            //}
        }

        private void MenuItem_Test1_FileReadWrite_Click(object sender, EventArgs e)
        {
            string fName1=@"D:\Temp\TextFile.txt", fName2=@"D:\Temp\CopyFile.txt";
            StreamReader sr = null;
            StreamWriter sw = null;
            sr = new StreamReader(fName1);
            sw = new StreamWriter(fName2);
            string CurString="start reading";
            while (CurString != null)
            {
                CurString = sr.ReadLine();
                sw.WriteLine(CurString);
            }
            sw.Close();
            sw.Dispose();
            sr.Close();
            sr.Dispose();
        }

        private void MenuItem_SaveInfoToFile_Click(object sender, EventArgs e)
        {
            string fName = "";
            OpenFileDialog openDialog = new OpenFileDialog();
            SaveFileDialog saveWnd = new SaveFileDialog();
            StreamWriter sw;
            //
            //openDialog.Filter = "TextFiles|.txt";//ne works!
            // saveWnd.Filter = "TextFiles|.txt";//ne works!
            //
            //if (openDialog.ShowDialog() == DialogResult.OK)
            if (saveWnd.ShowDialog() == DialogResult.OK)
            {
                fName = saveWnd.FileName;
                //
                sw = new StreamWriter(fName);
                foreach (string line in this.listBox1.Items)
                {
                    sw.WriteLine(line);
                    //sw.
                }
                sw.Close();
                sw.Dispose();
            }
           
        }

        private void MenuItem_Test1_ColHeaderCellReadWriteTool_Click(object sender, EventArgs e)
        {
            string[] BigArray = new string[100], SmallArray = new string[12];
            int QItems = 4;
            string[] items = new string[4];
            bool DBFieldHeaderData_1 = true, DBFieldHeaderDataSupplSpecial_2 = true, ItemsTableData_3 = true, DBFieldCreationData_3 = true;
            TCellDBFieldOrItemsHeader CellColIniFrom = new TCellDBFieldOrItemsHeader(), CellColIniTo = new TCellDBFieldOrItemsHeader();
            //
            CellColIniFrom.ColNameToDisplay = "Col for Test";
            if (DBFieldHeaderData_1)
            {
                CellColIniFrom.DBFieldHeaderData = new TDBFieldHeaderData();
                CellColIniFrom.DBFieldHeaderData.DBFieldNameToDBTable = "TestCol";
                if (DBFieldHeaderDataSupplSpecial_2)
                {
                    CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial = new TDBFieldCreationDataWithItemsTable();
                    if (ItemsTableData_3)
                    {

                        CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData = new TDBFieldHeaderCreationData();
                        //
                        CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.DBFieldCharacteristicsNumber = 0;
                        CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength = 10;
                        CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeN = 1;//
                        CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeName = "varchar";//
                        CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isAutoIncrement = true;
                        CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter = true;
                        CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField = true;
                        CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull = true;
                        //CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.
                        //
                        CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData = new TDBItemsTableData();
                        //
                        CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableName = "JoinedTable";
                        CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName = "ContentField";
                        CellColIniFrom.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableKeyFieldName = "N";
                    }
                }
            }
            //
            for (int i = 1; i <= QItems; i++)
            {
                items[i - 1] = "item" + i.ToString();
            }
            CellColIniFrom.SetItems(items, QItems);
            //CellColIniFrom is defined
            CellColIniFrom.ToStringArray(ref BigArray, ref QItems, false);
            for (int i = 1; i <= QItems; i++)
            {
                MyLib.writeln(this.vsh, BigArray[i - 1]);
            }
            //
            //throw new NotImplementedException();
            int CurN, LastN;
            /*
            BigArray[1 - 1] = "Cell type:";
            BigArray[2 - 1] = "Test Column";//TableConsts.ColHeaderDBFieldOrItemsTypeN.ToString();
            BigArray[3 - 1] = "Col Name:";
            BigArray[4 - 1] = "TestCol";//this.ColNameToDisplay;
            BigArray[5 - 1] = "DB data exist:";
            if (DBFieldHeaderData_1 == null)
            {
                BigArray[6 - 1] = "0";
            }
            else
            {
                BigArray[6 - 1] = "1";
            }
            BigArray[7 - 1] = "DB data exist:";
            if (DBFieldHeaderData_1 == null || DBFieldHeaderDataSupplSpecial_2 == null)
            {
                BigArray[8 - 1] = "0";
            }
            else
            {
                BigArray[8 - 1] = "1";
            }
            BigArray[9 - 1] = "DB Items Table Data exists:";
            if (DBFieldHeaderData_1 == null || DBFieldHeaderDataSupplSpecial_2 == null || ItemsTableData_3 == null)
            {
                BigArray[10 - 1] = "0";
            }
            else
            {
                BigArray[10 - 1] = "1";
            }
            BigArray[11 - 1] = "Items Quantity (and existance):";
            if (items == null)
            {
                BigArray[12 - 1] = "0";
            }
            else
            {
                BigArray[12 - 1] = QItems.ToString();
            }
            LastN = 12;
            //
            if (DBFieldHeaderData_1 == null)
            {
                BigArray[6 - 1] = "0";
            }
            if (DBFieldHeaderData_1 != null)//2022-09-26
            {
                //Arr[6 - 1] = "1";
                BigArray[13 - 1] = "DB data content:";
                BigArray[14 - 1] = "DB field Name:";
                BigArray[15 - 1] = DBFieldNameToDBTable_2;
                //if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial == null)
                // {
                //    Arr[17 - 1] = "0";
                //}
                //else
                //{
                if (DBFieldHeaderDataSupplSpecial_2 != null)
                {
                    if (DBFieldCreationData_3 != null)
                    {
                        //Arr[17 - 1] = "1";
                        BigArray[16 - 1] = "DB field Creation data:";
                        BigArray[17 - 1] = "Field Type N:";
                        BigArray[18 - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeN.ToString();
                        BigArray[19 - 1] = "Field Type Name:";
                        BigArray[20 - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldTypeName;
                        BigArray[21 - 1] = "Field Length:";
                        BigArray[22 - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.FieldLength.ToString();
                        BigArray[23 - 1] = "DB Field Characteristics Number:";
                        BigArray[24 - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.DBFieldCharacteristicsNumber.ToString();
                        BigArray[25 - 1] = "is Key Field:";
                        BigArray[26 - 1] = MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isKeyField).ToString();
                        BigArray[27 - 1] = "is Counter:";
                        BigArray[28 - 1] = MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isCounter).ToString();
                        BigArray[29 - 1] = "is Not Null:";
                        BigArray[30 - 1] = MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isNotNull).ToString();
                        BigArray[31 - 1] = "is Auto-Increment:";
                        BigArray[32 - 1] = MyLib.BoolToInt(this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData.isAutoIncrement).ToString();
                    }
                }
                //
                if (this.DBFieldHeaderData != null)
                {
                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
                    {
                        LastN = 32;
                    }
                    else
                    {
                        LastN = 17;
                    }
                }
                else
                {
                    LastN = 12;
                }
                //
                if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null && this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData != null)
                {
                    CurN = LastN + 1;
                    BigArray[CurN - 1] = "Items Table Name:";
                    CurN = LastN + 2;
                    BigArray[CurN - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableName;
                    CurN = LastN + 3;
                    BigArray[CurN - 1] = "Items Table Items Field Name";
                    CurN = LastN + 4;
                    BigArray[CurN - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName;
                    CurN = LastN + 5;
                    BigArray[CurN - 1] = "Items Table Items Field Name";
                    CurN = LastN + 6;
                    BigArray[CurN - 1] = this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.ItemsTableData.ItemsTableItemsFieldName;
                    LastN = CurN;
                }
            }//if DB
            //
            if (this.DBFieldHeaderData != null)
            {
                if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial != null)
                {
                    if (this.DBFieldHeaderData.DBFieldHeaderDataSupplSpecial.DBFieldCreationData != null)
                    {
                        LastN = 38;
                    }
                    else
                    {
                        LastN = 32;
                    }
                }
                else
                {
                    LastN = 17;
                }
            }
            else
            {
                LastN = 12;
            }
            //
            if (this.items != null)
            {
                CurN = LastN + 1;
                BigArray[CurN - 1] = "Items:";
                LastN = LastN + 1;
                CurN = LastN;
                for (int i = 1; i <= this.QItems; i++)
                {
                    CurN = CurN + 1;
                    BigArray[CurN - 1] = "Item N";
                    CurN = CurN + 1;
                    BigArray[CurN - 1] = i.ToString();
                    CurN = CurN + 1;
                    BigArray[CurN - 1] = "Item content:";
                    CurN = CurN + 1;
                    BigArray[CurN - 1] = this.items[i - 1];
                }
                LastN = CurN;
            }
            QItems = LastN;
            //
        }
        */
            CellColIniTo.SetFromStringArray(BigArray, QItems);
            BigArray = null;
            BigArray = new string[100];
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "New Array:");
            MyLib.writeln(this.vsh, "");
            CellColIniTo.ToStringArray(ref BigArray, ref QItems);
            MyLib.writeln(this.vsh, "");
            MyLib.writeln(this.vsh, "QItems=" + QItems.ToString());
            MyLib.writeln(this.vsh, "");
            for (int i = 1; i <= QItems; i++)
            {
                MyLib.writeln(this.vsh, BigArray[i - 1]);
            }
            //
            //
            //BigArray = null;
            //BigArray = new string[100];
            ////
            //MyLib.writeln(this.vsh, "");
            //MyLib.writeln(this.vsh, "");
            //MyLib.writeln(this.vsh, "Old Array, New form:");
            //MyLib.writeln(this.vsh, "");
            //CellColIniFrom.ToStringArray1(ref BigArray, ref QItems);
            //for (int i = 1; i <= QItems; i++)
            //{
            //    MyLib.writeln(this.vsh, BigArray[i - 1]);
            //}
            ////
            //CellColIniTo.SetFromStringArray1(BigArray, QItems);
            //BigArray = null;
            //BigArray = new string[100];
            //MyLib.writeln(this.vsh, "");
            //MyLib.writeln(this.vsh, "");
            //MyLib.writeln(this.vsh, "New Array, New form:");
            //MyLib.writeln(this.vsh, "");
            //CellColIniTo.ToStringArray1(ref BigArray, ref QItems);
            //MyLib.writeln(this.vsh, "");
            //MyLib.writeln(this.vsh, "QItems=" + QItems.ToString());
            //MyLib.writeln(this.vsh, "");
            //for (int i = 1; i <= QItems; i++)
            //{
            //    MyLib.writeln(this.vsh, BigArray[i - 1]);
            //}
        }//fn

        private void stringTestDelSubstringsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string was = "uequeue_and_5ue", ss="ue", willbe="";
            willbe = MyLib.DelAllSubstringSamples(was, ss);
            MyLib.writeln(this.vsh, was + " - " + ss + " = " + willbe);
            was = "uequeue_"; ss = "ue"; willbe = "";
            willbe = MyLib.DelAllSubstringSamples(was, ss);
            MyLib.writeln(this.vsh, was + " - " + ss + " = " + willbe);
        }

        private void hydroResistancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int QL = 0, QC = 0;
            HydroPipelineElement R1 = new HydroPipelineElement(null);
            HydroPipelineElement R2 = new HydroPipelineElement(null);
            R1.AddSucSmart(R2);//----------------------------------------------- +
            R2 = new HydroPipelineElement(null);
            R1.elems[R1.curSubElementN - 1].AddParSmart(R2);//------------------ +
            //R1.ShowCoords_IpseAndSub(this.vsh);
            MyLib.writeln(this.vsh, "");
            R1.Show(this.vsh);
            MyLib.writeln(this.vsh, "");
            //
            HydrSchemVisualizer SchemForm = new HydrSchemVisualizer();
            //SchemForm.Show();
            //
            HydroSchemCanvas hssh = new HydroSchemCanvas();
            hssh.dg = SchemForm.GetTableCanvas();
            //
            QC = R1.vis_L_WithConnectors(null);
            QL = R1.vis_H(null);
            hssh.SetSize(QC, QL);//this.vsh
            //
            //hssh.SetSize(R1.vis_L_WithConnectors(null), R1.vis_H(null));//this.vsh
            //
            R1.vis_Display_WithSubElts(hssh, this.vsh);
            SchemForm.TopR = R1;
            SchemForm.f1 = this;
            SchemForm.Show();
            //
            MyLib.writeln(this.vsh, "");
            R1.ShowCoords_IpseAndSub(this.vsh, this.vsh);
            MyLib.writeln(this.vsh, "");
            R1.ShowCoords_IpseAndSub(this.vsh);
            MyLib.writeln(this.vsh, "");
            //

        }//fn CalcRecJv1
}//cl
    class RecursionPartsStruct{
        public int N;
        public int QVals;// = 5;
        public int QNumerats;// = 10;
        public int denom;// = QVals * QNumerats;
        public int[] pCur ;//= new int[denom];
        //public List<int[]>lst;
        public List<int[]> lst;
        public int CurSum;
        public RecursionPartsStruct(){
            QVals=0;
            QNumerats=0;
            denom=0;
            pCur=null;//= new int[denom];
            //lst=new List<int[]>();
            lst = new List<int[]>();
            CurSum=0;
        }
        public RecursionPartsStruct(int QVals, int QNumerats){
            this.lst=new List<int[]>();
            this.CurSum=0;
            this.SetForCalc(QVals, QNumerats);
        }
        void SetForCalc(int QVals, int QNumerats){
            this.QVals=QVals;
            this.QNumerats=QNumerats;
            this.denom=QVals*QNumerats;
            this.pCur= new int[this.denom];
        }
    }//cl
    public class DataRecStr {
        public int N;
        public int QVals, QNumerats;
        public int[] p;
        public int countAll;
        public int countCall;
        //int sum;
        //public DataRecStr(){
        //    this.QVals=0;
        //    this.QNumerats=0;
        //    //this.sum=0;
        //    this.p=null;
        //    this.countAll=0;
        //    this.countCall=0;
        //}
        public DataRecStr(int QVals = 0, int QNumerats = 0)
        {
            this.p = null;
            this.countAll = 0;
            this.countCall = 0;
            //
            this.QVals=QVals;
            this.QNumerats=QNumerats;
            //this.sum=0;
            if(this.QNumerats>0){
                this.p=new int[this.QNumerats];
                for(int i=1; i<=this.QNumerats; i++){
                    this.p[i-1]=0;
                }
            }
        }
        public override string ToString(){
            string st;
            st=" N="+this.N.ToString()+" QVals="+this.QVals.ToString()+" QNumerats="+this.QNumerats.ToString();
            return st;
        }
    }//cl  DataRecStr
    public class DataRecStr1
    {
        public int N;
        public int QVals, QNumerats;
        public int[] p;
        public int countAll;
        public int countCall;
        public int Denom;
        public List<ListOfIntArrays> lst;
        //
        public DataRecStr1(int QVals = 0, int QNumerats = 0)
        {
            this.p = null;
            this.countAll = 0;
            this.countCall = 0;
            //
            this.QVals = QVals;
            this.QNumerats = QNumerats;
            //this.sum=0;
            if (this.QNumerats > 0)
            {
                this.p = new int[this.QVals];
                for (int i = 1; i <= this.QVals; i++)
                {
                    this.p[i - 1] = 0;
                }
            }
            lst = new List<ListOfIntArrays>();
        }
        public override string ToString()
        {
            string st;
            st = " N=" + this.N.ToString() + " QVals=" + this.QVals.ToString() + " QNumerats=" + this.QNumerats.ToString();
            return st;
        }
    }//cl
    public class ListOfIntArrays
    {
        public int[] arr;
        public int param;
        public ListOfIntArrays(int[] arr=null, int param=0)
        {
            this.param = param;
            this.arr = arr;
        }
        
    }
}//ns   //2020-08-12