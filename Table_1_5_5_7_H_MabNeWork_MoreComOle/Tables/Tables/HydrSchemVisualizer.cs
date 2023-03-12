using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tables
{
    public partial class HydrSchemVisualizer : Form_TableCalling//Form
    {
        public HydroPipelineElement PTR;
        public HydroPipelineElement TopR;
        public HydroPipelineElement curNew;
        HydroResistanceIniData HydroIniData;
        public Form1 f1;
        Vector2DInt CoordsSelected, CoordsOfCurR;
        public HydrSchemVisualizer()
        {
            InitializeComponent();
            //
            HydroIniData = new HydroResistanceIniData();
            //
            this.dataGridView1.RowCount = 1;
            this.dataGridView1.ColumnCount = 1;
                //int h=this.dataGridView1.Rows[0].Height;// = 50;//22
                //int w=this.dataGridView1.Columns[0].Width;// = 50;//100
                ////Font fnt = new Font("Courier New", 12, FontStyle.Bold);
                Font fnt = new Font("Courier New", 9, FontStyle.Bold);
                //dataGridView1.Columns[0].DefaultCellStyle.Font = fnt;
                dataGridView1.DefaultCellStyle.Font = fnt;
                ////MessageBox.Show("H=" + h.ToString() + " W=" + w.ToString());
                ////this.dataGridView1.Rows[0].Height=78;
                //this.dataGridView1.Columns[0].Width = 79;
                //
                CoordsSelected = new Vector2DInt(1,1);
                CoordsOfCurR = new Vector2DInt();
                //PTR = null;
                //TopR = null;
                curNew=null;
                TopR = new HydroPipelineElement(HydroIniData);
                PTR = TopR;
            }

        public DataGridView GetTableCanvas()
        {
            return this.dataGridView1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            /*
            TValsShowHide vsh = f1.vsh;
            MyLib.writeln(vsh, "Click! dataGridView1_CellContentClick starts working");
            HydroPipelineElement newPtR=null;
            int gLN, gCN; ;// tLN, tCN;//lebe global, belonging to form class, 
            //this.dataGridView1.Rows[this.CoordsSelected.d2 - 1].Cells[this.CoordsSelected.d1 - 1].Selected = false;
            gLN = this.dataGridView1.CurrentCell.RowIndex;
            gCN = this.dataGridView1.CurrentCell.ColumnIndex;
            this.CoordsSelected.d1 = gCN + 1;//x
            this.CoordsSelected.d2 = gLN + 1;//y
            //this.dataGridView1.Rows[this.CoordsSelected.d2 - 1].Cells[this.CoordsSelected.d1 - 1].Selected = false;
            int cR_xL, cR_xR, cR_yL, cR_yU;
            MessageBox.Show("[L=" + CoordsSelected.d2.ToString() + "; C=" + CoordsSelected.d1.ToString() + "]");
            MyLib.writeln(vsh, "[L=" + CoordsSelected.d2.ToString() + "; C=" + CoordsSelected.d1.ToString() + "]");
            if(TopR!=null){
                //newPtR = TopR.SeekElementByDelegate(1, this.CoordsSelected.d1+1, this.CoordsSelected.d2+1, null);
                newPtR = TopR.SeekElementByCoordsBelongingPrimitive(this.CoordsSelected.d1, this.CoordsSelected.d2, vsh);
            }
            if (newPtR != null)
            {
                //this.dataGridView1.Rows[this.CoordsSelected.d2 - 1].Cells[this.CoordsSelected.d1 - 1].Selected = false;
                this.PTR = newPtR;
                cR_xL = newPtR.vis_x_cornerLeft(null);
                cR_xR = newPtR.vis_x_cornerRight(null);
                cR_yL = newPtR.vis_y_cornerLower(null);
                cR_yU = newPtR.vis_y_cornerUpper(null);
                //MessageBox.Show("Selected: " + this.PTR.ToString());
                //msg = "Selected: R" + (newPtR.GetN()).ToString() + ": L=" + CoordsSelected.d2.ToString() + " E [" + cR_xL.ToString() + "; " + cR_xR.ToString() + "], C=" + CoordsSelected.d1.ToString() + " E [" + cR_yU.ToString() + "; " + cR_yL.ToString() + "]";
                MessageBox.Show("Selected: R" + (newPtR.GetN()).ToString() + ": L=" + CoordsSelected.d2.ToString() + " E [" + cR_xL.ToString() + "; " + cR_xR.ToString() + "], C=" + CoordsSelected.d1.ToString() + " E [" + cR_yU.ToString() + "; " + cR_yL.ToString() + "]");
                MyLib.writeln(vsh, "Selected: R" + (newPtR.GetN()).ToString() + ": L=" + CoordsSelected.d2.ToString() + " E [" + cR_xL.ToString() + "; " + cR_xR.ToString() + "], C=" + CoordsSelected.d1.ToString() + " E [" + cR_yU.ToString() + "; " + cR_yL.ToString() + "]");
                this.CoordsOfCurR.d1 = this.PTR.vis_x_Caption(null);
                this.CoordsOfCurR.d2 = this.PTR.vis_y_Caption(null);
                //this.ToShowSelectedCap();
                //this.dataGridView1.Rows[this.CoordsOfCurR.d2 - 1].Cells[this.CoordsOfCurR.d1 - 1].Selected = true;
                //this.CoordsSelected.d1 = this.CoordsOfCurR.d1;
                //this.CoordsSelected.d2 = this.CoordsOfCurR.d2;
                MyLib.writeln(vsh, "dataGridView1_CellContentClick finishes working");
            }
            else
            {
                MessageBox.Show("Selected: nil");
            }
            this.dataGridView1.Rows[this.CoordsSelected.d2 - 1].Cells[this.CoordsSelected.d1 - 1].Selected = false;
            this.dataGridView1.Rows[this.CoordsOfCurR.d2 - 1].Cells[this.CoordsOfCurR.d1 - 1].Selected = true;
            this.CoordsSelected.d1 = this.CoordsOfCurR.d1;
            this.CoordsSelected.d2 = this.CoordsOfCurR.d2;
            */
        }
        private void ToShowSelectedCap()
        {
            if (TopR != null)
            {
                //PTR = TopR.SeekElementByDelegate(2, this.CoordsSelected.d1, this.CoordsSelected.d2, null);
                //this.PTR = this.TopR;
                //this.CoordsOfCurR.d1 = this.TopR.vis_x_Caption(null);
                //this.CoordsOfCurR.d2 = this.TopR.vis_y_Caption(null);
                if (this.dataGridView1.RowCount >= this.CoordsSelected.d2 && this.dataGridView1.ColumnCount >= this.CoordsSelected.d1)
                {
                    this.dataGridView1.Rows[this.CoordsSelected.d2 - 1].Cells[this.CoordsSelected.d1 - 1].Selected = false;
                }
                this.CoordsOfCurR.d1 = this.PTR.vis_x_Caption(null);
                this.CoordsOfCurR.d2 = this.PTR.vis_y_Caption(null);
                this.CoordsSelected.d1 = this.CoordsOfCurR.d1;
                CoordsSelected.d2 = this.CoordsOfCurR.d2;
                //MessageBox.Show("[" + CoordsSelected.d2.ToString() + "; " + CoordsSelected.d1.ToString() + "]");
                //
                //this.dataGridView1.Se//no
                this.dataGridView1.Rows[this.CoordsSelected.d2 - 1].Cells[this.CoordsSelected.d1 - 1].Selected = true;
                this.dataGridView1.Rows[0].Cells[0].Selected = false;
                //
                //this.dataGridView1.CurrentCell.ColumnIndex = this.CoordsSelected.d1 - 1;//read only
            }
        }
        private void HydrSchemVisualizer_Shown(object sender, EventArgs e)
        {
            this.PTR = this.TopR;
            this.ToShowSelectedCap();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TValsShowHide vsh = f1.vsh;
            MyLib.writeln(vsh, "Click! dataGridView1_CellContentClick starts working");
            HydroPipelineElement newPtR = null;
            int gLN, gCN; ;// tLN, tCN;//lebe global, belonging to form class, 
            //this.dataGridView1.Rows[this.CoordsSelected.d2 - 1].Cells[this.CoordsSelected.d1 - 1].Selected = false;
            gLN = this.dataGridView1.CurrentCell.RowIndex;
            gCN = this.dataGridView1.CurrentCell.ColumnIndex;
            this.CoordsSelected.d1 = gCN + 1;//x
            this.CoordsSelected.d2 = gLN + 1;//y
            //this.dataGridView1.Rows[this.CoordsSelected.d2 - 1].Cells[this.CoordsSelected.d1 - 1].Selected = false;
            int cR_xL, cR_xR, cR_yL, cR_yU;
            MessageBox.Show("[L=" + CoordsSelected.d2.ToString() + "; C=" + CoordsSelected.d1.ToString() + "]");
            MyLib.writeln(vsh, "[L=" + CoordsSelected.d2.ToString() + "; C=" + CoordsSelected.d1.ToString() + "]");
            if (TopR != null)
            {
                //newPtR = TopR.SeekElementByDelegate(1, this.CoordsSelected.d1+1, this.CoordsSelected.d2+1, null);
                newPtR = TopR.SeekElementByCoordsBelongingPrimitive(this.CoordsSelected.d1, this.CoordsSelected.d2, vsh);
            }
            if (newPtR != null)
            {
                //this.dataGridView1.Rows[this.CoordsSelected.d2 - 1].Cells[this.CoordsSelected.d1 - 1].Selected = false;
                this.PTR = newPtR;
                cR_xL = newPtR.vis_x_cornerLeft(null);
                cR_xR = newPtR.vis_x_cornerRight(null);
                cR_yL = newPtR.vis_y_cornerLower(null);
                cR_yU = newPtR.vis_y_cornerUpper(null);
                //MessageBox.Show("Selected: " + this.PTR.ToString());
                //msg = "Selected: R" + (newPtR.GetN()).ToString() + ": L=" + CoordsSelected.d2.ToString() + " E [" + cR_xL.ToString() + "; " + cR_xR.ToString() + "], C=" + CoordsSelected.d1.ToString() + " E [" + cR_yU.ToString() + "; " + cR_yL.ToString() + "]";
                MessageBox.Show("Selected: R" + (newPtR.GetN()).ToString() + ": L=" + CoordsSelected.d2.ToString() + " E [" + cR_xL.ToString() + "; " + cR_xR.ToString() + "], C=" + CoordsSelected.d1.ToString() + " E [" + cR_yU.ToString() + "; " + cR_yL.ToString() + "]");
                MyLib.writeln(vsh, "Selected: R" + (newPtR.GetN()).ToString() + ": L=" + CoordsSelected.d2.ToString() + " E [" + cR_xL.ToString() + "; " + cR_xR.ToString() + "], C=" + CoordsSelected.d1.ToString() + " E [" + cR_yU.ToString() + "; " + cR_yL.ToString() + "]");
                this.CoordsOfCurR.d1 = this.PTR.vis_x_Caption(null);
                this.CoordsOfCurR.d2 = this.PTR.vis_y_Caption(null);
                //this.ToShowSelectedCap();
                //this.dataGridView1.Rows[this.CoordsOfCurR.d2 - 1].Cells[this.CoordsOfCurR.d1 - 1].Selected = true;
                //this.CoordsSelected.d1 = this.CoordsOfCurR.d1;
                //this.CoordsSelected.d2 = this.CoordsOfCurR.d2;
                MyLib.writeln(vsh, "dataGridView1_CellContentClick finishes working");
            }
            else
            {
                MessageBox.Show("Selected: nil");
            }
            this.dataGridView1.Rows[this.CoordsSelected.d2 - 1].Cells[this.CoordsSelected.d1 - 1].Selected = false;
            this.dataGridView1.Rows[this.CoordsOfCurR.d2 - 1].Cells[this.CoordsOfCurR.d1 - 1].Selected = true;
            this.CoordsSelected.d1 = this.CoordsOfCurR.d1;
            this.CoordsSelected.d2 = this.CoordsOfCurR.d2;
        }

        private void button_Top_Click(object sender, EventArgs e)
        {
            string was = this.PTR.ToString(), cur;
            this.PTR = this.PTR.nav_GoToTop();
            cur = this.PTR.ToString();
            MessageBox.Show("was: " + was + " now is: " + cur);
            this.ToShowSelectedCap();
        }

       
        private void button_LevelUp_Click(object sender, EventArgs e)
        {
            string was = this.PTR.ToString(), cur;
            this.PTR = this.PTR.nav_GoToUpper();
            cur = this.PTR.ToString();
            MessageBox.Show("was: " + was + " now is: " + cur);
            this.ToShowSelectedCap();
        }

        private void button_FirstMate_Click(object sender, EventArgs e)
        {
            string was = this.PTR.ToString(), cur;
            this.PTR = this.PTR.nav_First();
            cur = this.PTR.ToString();
            MessageBox.Show("was: " + was + " now is: " + cur);
            this.ToShowSelectedCap();
        }

        private void button_LastMate_Click(object sender, EventArgs e)
        {
            string was = this.PTR.ToString(), cur;
            this.PTR = this.PTR.nav_Last();
            cur = this.PTR.ToString();
            MessageBox.Show("was: " + was + " now is: " + cur);
            this.ToShowSelectedCap();
        }

        private void button_PrevMate_Click(object sender, EventArgs e)
        {
            string was = this.PTR.ToString(), cur;
            this.PTR = this.PTR.nav_Prev();
            cur = this.PTR.ToString();
            MessageBox.Show("was: " + was + " now is: " + cur);
            this.ToShowSelectedCap();
        }

        private void button_Next_Mate_Click(object sender, EventArgs e)
        {
            string was = this.PTR.ToString(), cur;
            this.PTR = this.PTR.nav_Next();
            cur = this.PTR.ToString();
            MessageBox.Show("was: " + was + " now is: " + cur);
            this.ToShowSelectedCap();
        }

        private void button_Enter_Click(object sender, EventArgs e)
        {
            string was = this.PTR.ToString(), cur;
            this.PTR=this.PTR.nav_Enter();
            cur=this.PTR.ToString();
            MessageBox.Show("was: "+was+" now is: "+cur);
            this.ToShowSelectedCap();
        }

        

        private void button_AddParToSmart_Click(object sender, EventArgs e)
        {
            //this.curNew = new HydroPipelineElement();
            //MyLib.writeln(this.f1.vsh, "");
            //MyLib.writeln(this.f1.vsh, "button_AddParToSmart_Click starts working");
            //this.PTR.AddParSmart(this.curNew, 0, 0, this.f1.vsh);
            //HydroSchemCanvas hssh = new HydroSchemCanvas();
            //hssh.dg = this.GetTableCanvas();
            //this.TopR.vis_Display_WithSubElts(hssh, this.f1.vsh);
            //this.ToShowSelectedCap();
            ////
            //MyLib.writeln(this.f1.vsh, "Now pipeline is:");
            //this.TopR.Show(this.f1.vsh);
            //MyLib.writeln(this.f1.vsh, "Geom:");
            //this.TopR.ShowCoords_IpseAndSub(this.f1.vsh);
            //MyLib.writeln(this.f1.vsh, "yLower of R0:");
            //int yl = this.TopR.vis_yLower(this.f1.vsh);
            //MyLib.writeln(this.f1.vsh, "button_AddParToSmart_Click finishes working");
            //MyLib.writeln(this.f1.vsh, "");
            //
            HydroResistanceIniData HRIniData = new HydroResistanceIniData();
            //
            this.curNew = new HydroPipelineElement(HRIniData);
            MyLib.writeln(this.f1.vsh, "");
            MyLib.writeln(this.f1.vsh, "button_AddParToSmart_Click starts working");
            MyLib.writeln(this.f1.vsh, "Pipeline before adding:");
            this.TopR.Show(this.f1.vsh);
            this.PTR.AddParSmart(this.curNew, 0, 0, this.f1.vsh);
            HydroSchemCanvas hssh = new HydroSchemCanvas();
            hssh.dg = this.GetTableCanvas();
            MyLib.writeln(this.f1.vsh, "Drawing schema:");
            this.TopR.vis_Display_WithSubElts(hssh, null);//this.f1.vsh
            this.ToShowSelectedCap();
            MyLib.writeln(this.f1.vsh, "Now pipeline is:");
            this.TopR.Show(this.f1.vsh);
            MyLib.writeln(this.f1.vsh, "button_AddParToSmart_Click finishes working");
            MyLib.writeln(this.f1.vsh, "");
        }

        private void button_AddSucToSmart_Click(object sender, EventArgs e)
        {
            //this.curNew=new HydroPipelineElement();
            //MyLib.writeln(this.f1.vsh, "");
            //MyLib.writeln(this.f1.vsh, "button_AddSucToSmart_Click starts working");
            //this.PTR.AddSucSmart(this.curNew, 0, 0, this.f1.vsh);
            //HydroSchemCanvas hssh = new HydroSchemCanvas();
            //hssh.dg = this.GetTableCanvas();
            ////hssh.SetSize(this.TopR.vis_L_WithConnectors(null), this.TopR.vis_H(null));//f1.vsh
            //this.TopR.vis_Display_WithSubElts(hssh, null);
            ////this.PTR.DisplaySchem(hssh, null);
            //this.ToShowSelectedCap();
            ////
            //MyLib.writeln(this.f1.vsh, "Now pipeline is:");
            //this.TopR.Show(this.f1.vsh);
            //MyLib.writeln(this.f1.vsh, "Geom:");
            //this.TopR.ShowCoords_IpseAndSub(this.f1.vsh);
            //MyLib.writeln(this.f1.vsh, "yLower of R0:");
            //int yl = this.TopR.vis_yLower(this.f1.vsh);
            //MyLib.writeln(this.f1.vsh, "button_AddSucToSmart_Click finishes working");
            //MyLib.writeln(this.f1.vsh, "");
            //
            HydroResistanceIniData HRIniData = new HydroResistanceIniData();
            //
            this.curNew = new HydroPipelineElement(HRIniData);
            MyLib.writeln(this.f1.vsh, "");
            MyLib.writeln(this.f1.vsh, "button_AddSucToSmart_Click starts working");
            MyLib.writeln(this.f1.vsh, "Pipeline before adding:");
            this.TopR.Show(this.f1.vsh);
            //
            this.PTR.AddSucSmart(this.curNew, 0, this.f1.vsh);
            //this.PTR.AddSucSmart(this.curNew, 0, 0, this.f1.vsh);
            //
            HydroSchemCanvas hssh = new HydroSchemCanvas();
            hssh.dg = this.GetTableCanvas();
            MyLib.writeln(this.f1.vsh, "Drawing schema:");
            this.TopR.vis_Display_WithSubElts(hssh, null);
            this.ToShowSelectedCap();
            MyLib.writeln(this.f1.vsh, "Now pipeline is:");
            this.TopR.Show(this.f1.vsh);
            MyLib.writeln(this.f1.vsh, "button_AddSucToSmart_Click finishes working");
            MyLib.writeln(this.f1.vsh, "");
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            int N = this.PTR.GetNinUpper();
            HydroSchemCanvas hssh = new HydroSchemCanvas();
            MyLib.writeln(this.f1.vsh, "");
            MyLib.writeln(this.f1.vsh, "button_Del starts working");
            MyLib.writeln(this.f1.vsh, "Pipeline before adding:");
            this.TopR.Show(this.f1.vsh);
            if (this.PTR.GetUpper() != null)
            {
                this.PTR = this.PTR.GetUpper();
                //
                this.PTR.DelInner(N, this.f1.vsh);
                //
                if (this.PTR.GetQSubElts() > 0)
                {
                    if (N < this.PTR.GetQSubElts() || N == 1)
                    {
                        this.PTR = this.PTR.elems[N - 1];
                    }
                    else
                    {
                        this.PTR = this.PTR.elems[N - 1 - 1];
                    }
                }
            }
            else
            {
                MessageBox.Show("You are tying to del whole Pipeline. Forbidden");
            }
            hssh.dg = this.GetTableCanvas();
            MyLib.writeln(this.f1.vsh, "Now pipeline is:");
            this.TopR.Show(this.f1.vsh);
            //
            hssh.dg = this.GetTableCanvas();
            MyLib.writeln(this.f1.vsh, "Drawing schem:");
            this.TopR.vis_Display_WithSubElts(hssh, null);//this.f1.vsh
            this.ToShowSelectedCap();
            //
            MyLib.writeln(this.f1.vsh, "button_Del finishes working");
            MyLib.writeln(this.f1.vsh, "");
        }

        private void button_Edit_Click(object sender, EventArgs e)
        {
            TableDataChange DataTopic = new TableDataChange();
            DataTopic.DataTypeIni1Fin2Medium3Cfg4 = 1; //ini data 
            DataTopic.DataTopicN = 1; //ini data of R, its ini geom
            DataTopic.DataN = this.PTR.GetN();//Mab exnot: PTR. Or ne exnot, if PTR wa alt'd af table wa cal'd

            //TTable tbl = this.PTR.hydroResistance_IniData_GetAsTable();
            TTable tbl = this.PTR.hydroResistance_IniDataAdvanced_GetAsTable();

            TableForm HRIniDataForm = new TableForm(this, tbl, DataTopic);
            HRIniDataForm.Show();
        }

        private void buttonSwapWithPrev_Click(object sender, EventArgs e)
        {
            HydroPipelineElement upper;
            HydroSchemCanvas hssh = new HydroSchemCanvas();
            upper = this.PTR.GetUpper();
            int N = this.PTR.GetNinUpper();
            if (upper != null && N > 1)
            {
                this.PTR=null;
                upper.SwapInner(N - 1, N);
                this.PTR = upper.elems[N - 1-1];
            }
            hssh.dg = this.GetTableCanvas();
            //MyLib.writeln(this.f1.vsh, "Drawing schem:");
            this.TopR.vis_Display_WithSubElts(hssh, null);//this.f1.vsh
            this.ToShowSelectedCap();
        }

        private void buttonSwapWithNext_Click(object sender, EventArgs e)
        {
            HydroPipelineElement upper;
            HydroSchemCanvas hssh = new HydroSchemCanvas();
            upper = this.PTR.GetUpper();
            int N = this.PTR.GetNinUpper();
            if (upper != null && N < upper.GetQSubElts())
            {
                this.PTR = null;
                upper.SwapInner(N, N+1);
                this.PTR = upper.elems[N + 1-1];
            }
            hssh.dg = this.GetTableCanvas();
            //MyLib.writeln(this.f1.vsh, "Drawing schem:");
            this.TopR.vis_Display_WithSubElts(hssh, null);//this.f1.vsh
            this.ToShowSelectedCap();
        }

        
    }//cl
}//ns
