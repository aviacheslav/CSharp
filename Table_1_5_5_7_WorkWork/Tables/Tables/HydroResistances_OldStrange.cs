using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Windows.Forms;
//
namespace Tables
{
    
    
    public class PrimitiveElement : ICloneable
    {
        public int Conn_Suc0Par1;
        PrimitiveElement[]elems;
        //public PrimitiveElement upper, cur;
        PrimitiveElement upper;
        int curN;
        public int QElements;
        public double k;
        //
        public int NinUpper;
        //public PrimitiveElement() {
        //    SetNull();
        //}
        public PrimitiveElement(int k = 0, int Succ0Parallel1 = 0, PrimitiveElement[] elems = null, PrimitiveElement upper = null, int QElements = 0, int CurN = 0, int NInUpper = 0, TValsShowHide vsh = null)
        {
            //void Set(int k = 0, int Succ0Parallel1 = 0, PrimitiveElement[] elems = null, int QElements = 0, int CurN=0, int NInUpper=0)
            this.SetNull();
            this.Set(k, Succ0Parallel1, elems, upper, QElements, CurN, NInUpper);
            //MyLib.writeln(vsh,"Created R"+this.CurN.ToString()+"("+CurN.ToString()+")"+" k="+this.k.ToString()+"("+k.ToString()+"). SubElts: Q="+this.QElements.ToString()+" Order --0, ||1: "+this.Succ0Parallel1.ToString());
            //MyLib.writeln(vsh,this.ToString());
            MyLib.writeln(vsh, "Created R: " + this.ToString());
        }
        public void SetNull()
        {
            this.Conn_Suc0Par1 = 0;
            this.QElements = 0;
            this.k = 0;
            this.elems = null;
            this.upper = null;
            this.curN = 0;
            this.NinUpper = 0;
        }
        public void Set(int k = 0, int Succ0Parallel1 = 0, PrimitiveElement[] elems = null, PrimitiveElement upper=null, int QElements = 0, int CurN = 0, int NInUpper = 0)
        {
            SetNull();
            this.Conn_Suc0Par1 = Succ0Parallel1;
            this.curN = CurN;
            this.NinUpper = NInUpper;
            if (k <= 0) this.k = 0; else this.k = k;
            if (elems == null) this.elems = null;
            else
            {
                if (QElements <= 0 || QElements > elems.Length) QElements = elems.Length;
                //else QElts norm
                for (int i = 1; i <= this.QElements; i++)
                {
                    this.AddInner(elems[i - 1]);
                }
            }
        }
        public void SetElementsConnectionSucc(){this.Conn_Suc0Par1=0;}
        public void SetElementsConnectionPrl() { this.Conn_Suc0Par1 = 1; }
        public int GetConnectionType() { return Conn_Suc0Par1; }
        public bool GetIfConnectionTypeIsSucc() { return (Conn_Suc0Par1==0); }
        public bool GetIfConnectionTypeIsPrl() { return (Conn_Suc0Par1 == 1); }
        //
        public void SetN(int N) { this.NinUpper = N; }
        public int GetNinUpper() { return this.NinUpper; }
        //
        public void AddInner(PrimitiveElement elem)
        {
            /*
            PrimitiveElement[] elems=new PrimitiveElement[this.QElements+1];
            for (int i = 1; i <= this.QElements; i++)
            {
                elems[i - 1] = (PrimitiveElement)this.elems[i - 1].Clone();
            }
            elems[this.QElements + 1 - 1] = (PrimitiveElement)elem.Clone();
            this.elems = elems;
            this.QElements++;
            */
            //
            //if (this.QElements == 1)
            //{
            //    CurN = this.QElements;
            //}
            PrimitiveElement NewElem=new PrimitiveElement();
            if(elem!=null){
                NewElem=(PrimitiveElement)elem.Clone();
                //NewElem.CurN//find it in ext elem
                //NewElem.k//find it in ext elem
                NewElem.NinUpper=this.QElements+1;
                NewElem.upper=this;
            }
            MyLib.AddToVector(ref this.elems, ref this.QElements, NewElem);
            //
            /*
            PrimitiveElement[] elems = new PrimitiveElement[this.QElements + 1];
            for (int i = 1; i <= this.QElements; i++)
            {
                elems[i - 1] = (PrimitiveElement)this.elems[i - 1].Clone();
            }
            elems[this.QElements + 1 - 1] = (PrimitiveElement)NewElem.Clone(); ;
            this.elems = elems;
            this.QElements++;
            */
        }
        public void DelInner(int N = 0)
        {
            if (N < 1) N = this.QElements;
            if(N>=1 && N<=this.QElements){
                PrimitiveElement[] elems = new PrimitiveElement[this.QElements - 1];
                for (int i = 1; i <= N-1; i++)
                {
                    elems[i - 1] = (PrimitiveElement)this.elems[i - 1].Clone();;
                }
                //for (int i = this.QElements; i >= N; i--)
                for (int i = N+1; i<=this.QElements; i++)
                {
                    elems[i - 1-1] = (PrimitiveElement)this.elems[i - 1].Clone();;
                }
                this.elems = elems;
                //cur = this.elems[N - 1];
            }
        }
        public void InsInner(PrimitiveElement elem, int N)
        {
            if (N >= 1 && N <= this.QElements)
            {
                PrimitiveElement[] elems = new PrimitiveElement[this.QElements + 1];
                for (int i = 1; i <= N - 1; i++)
                {
                    elems[i - 1] = (PrimitiveElement)this.elems[i - 1].Clone();
                }
                //for (int i = this.QElements; i >= N; i--)
                for (int i = N; i <= this.QElements; i++)
                {
                    elems[i + 1 - 1] = (PrimitiveElement)this.elems[i - 1].Clone();
                }
                elems[N - 1] = (PrimitiveElement)elem.Clone();
                elems[N - 1].upper = this;
                this.elems = elems;
                //cur = this.elems[N - 1];
            }
        }
        public void SetFirst() {
            //if (this.elems != null) this.cur = this.elems[1 - 1];
            curN = 1;
        }
        public void SetLast() {
            //if (this.elems != null)this.cur = this.elems[this.QElements - 1];
            curN = this.QElements;
        }
        public void SetNext()
        {
            if (this.elems != null && curN < this.QElements) curN += 1;
        }
        public void SetNInUpper(int N)
        {
            if (this.elems != null && N>=1 && N <= this.QElements) curN =N;
        }
        public void SetPrevious()
        {
            if (this.elems != null && curN > 1) curN -= 1;
        }
        public PrimitiveElement GetCurrent() {
            PrimitiveElement R = null;
            if (this.elems != null) R = this.elems[curN - 1];
            return R;
        }
        public PrimitiveElement GetUpper(){ return this.upper; }
        public void SetUpper(PrimitiveElement elem) { this.upper = elem; }
        private delegate double ResistanceByType(PrimitiveElement[] elems);
        private double ResistanceSucc(PrimitiveElement[] elems)
        {
            double S = 0;
            for (int i = 1; i <= /*this.QElements*/elems.Length; i++)
            {
                S = S + /*this.*/elems[i - 1].Resistance();
            }
            return S;
        }
        private double ResistancePrl(PrimitiveElement[] elems)
        {
            double S = 0;
            for (int i = 1; i <= /*this.QElements*/elems.Length; i++)
            {
                S = S + /*this.*/elems[i - 1].Resistance();
            }
            if (S != 0) S = 1 / S;
            return S;
        }
        public double Resistance()
        {
            double R=this.k, S=0;
            if (this.QElements > 0) S = R;
            {
                if (Conn_Suc0Par1 == 0) S = this.ResistanceSucc(this.elems);
                else S = this.ResistancePrl(this.elems);
            }
            return R;
        }
        public double ResistanceByDlgt()
        {
            ResistanceByType dlgt;
            double S=0;
            if (this.QElements > 0){
                if(this.Conn_Suc0Par1==0){
                    dlgt = this.ResistanceSucc;
                }else{
                    dlgt = this.ResistancePrl;
                }
                S = dlgt(this.elems); 
            }else{
                S=k;
            }
            return S;
        }
        public override string ToString()
        {
            string s = "";
            //s = "R" + this.CurN.ToString() + " k=" + this.k.ToString() + " SubElts: Q=" + this.QElements.ToString() + " Order --0, ||1: " + this.Succ0Parallel1.ToString();
            if (this.upper == null)
            {
                //s = "R" + this.CurN.ToString() + " k=" + this.k.ToString() + " SubElts: --"+this.QElements.ToString()+" ;
                if (this.Conn_Suc0Par1 == 0)
                {
                    s = "R" + this.curN.ToString() + " k=" + this.k.ToString() + " SubElts: [--] " + this.QElements.ToString() + " (Ext) ";
                }
                else if (this.Conn_Suc0Par1 == 1)
                {
                    s = "R" + this.curN.ToString() + " k=" + this.k.ToString() + " SubElts: [||] " + this.QElements.ToString() + " (Ext) ";
                }
            }
            else {
                if (this.Conn_Suc0Par1 == 0)
                {
                    s = "R" + this.curN.ToString() + " k=" + this.k.ToString() + " SubElts: [--] " + this.QElements.ToString() + " Of: R"+this.upper.curN.ToString()+ "["+this.NinUpper.ToString()+"]";
                }
                else if (this.Conn_Suc0Par1 == 1)
                {
                    s = "R" + this.curN.ToString() + " k=" + this.k.ToString() + " SubElts: [||] " + this.QElements.ToString() + " Of: R" + this.upper.curN.ToString() + "[" + this.NinUpper.ToString() + "]";
                }
            }
                //return base.ToString();
            return s;
        }
        public void Show(TValsShowHide vsh)
        {
            MyLib.writeln(vsh, this.ToString());
            for (int i = 1; i <= this.QElements; i++)
            {
                //MyLib.writeln(vsh, i.ToString()+") "+this.elems[i-1].ToString());
                this.elems[i - 1].Show(vsh);
            }
        }
        public object Clone()
        {
            PrimitiveElement data=new PrimitiveElement();
            data.Conn_Suc0Par1 = this.Conn_Suc0Par1;
            data.QElements = this.QElements;
            data.k = this.k;
            //
            data.curN = this.curN;
            data.NinUpper = this.NinUpper;
            data.upper = this.upper;
            //
            data.elems = new PrimitiveElement[this.QElements];
            for (int i = 1; i <= this.QElements; i++)
            {
                data.elems[i - 1] = (PrimitiveElement)this.elems[i - 1].Clone();
            }
            return data;
        }
        public TTable Main_GetAsTable()
        {
            TTable tbl=null;
            DataCell TblHdr = new DataCell("HResElem - Main Info");
            DataCell LinesGeneralName = new DataCell("Params");
            DataCell ColumnsGeneralName = null;
            DataCellRow ColOfLineHeader = new DataCellRow(new DataCell[] { new DataCell("k"), new DataCell("QElements"), new DataCell("Suc0Par1") }, 3);
            DataCellRow LineOfColHeader = new DataCellRow(new DataCell[] { new DataCell("Value") }, 1);
            DataCellRow[] Content = new DataCellRow[1];
            string[] sa = /*new string[]*/ { "--", "//" };
            //Content[1 - 1] = new DataCellRow(new DataCell[] { new DataCell(this.QElements), new DataCell(this.Succ0Parallel1), new DataCell(this.k) }, 3);
            //tbl = new TTable(new TableInfo(true, true, true, 3, 1), true, Content, LineOfColHeader, ColOfLineHeader, new TableHeaders(TblHdr, LinesGeneralName, ColumnsGeneralName), true);
            //
            //if (this.Succ0Parallel1 == 0)
            //{
            //    Content[1 - 1] = new DataCellRow(new DataCell[] { new DataCell(this.QElements), new DataCell("--"), new DataCell(this.k) }, 3);
            //    //tbl = new TTable(new TableInfo(true, true, true, 3, 1), true, Content, LineOfColHeader, ColOfLineHeader, new TableHeaders(TblHdr, LinesGeneralName, ColumnsGeneralName), true);
            //}
            //else
            //{
            //    Content[1 - 1] = new DataCellRow(new DataCell[] { new DataCell(this.QElements), new DataCell("//"), new DataCell(this.k) }, 3);
            //    //tbl = new TTable(new TableInfo(true, true, true, 3, 1), true, Content, LineOfColHeader, ColOfLineHeader, new TableHeaders(TblHdr, LinesGeneralName, ColumnsGeneralName), true);
            //}
            Content[1 - 1] = new DataCellRow(new DataCell[] {  new DataCell(this.k), new DataCell(this.QElements), new DataCell(sa, 2) }, 3);
            Content[1 - 1].SetActiveN(this.Conn_Suc0Par1 + 1, 2);
            tbl = new TTable(new TableInfo(true, true, true, 3, 1), true, Content, LineOfColHeader, ColOfLineHeader, new TableHeaders(TblHdr, LinesGeneralName, ColumnsGeneralName), true);
            return tbl;
        }
        public TTable Components_GetAsTable()
        {
            int zero = 0;
            int SNP;
            TTable tbl;
            DataCell TblHdr;//content  laf
            DataCell LinesGeneralName = new DataCell("N");
            DataCell ColumnsGeneralName = null;
            //DataCell ColumnsGeneralName = new DataCell("HResElem");
            DataCellRow LineOfColHeader = new DataCellRow(new DataCell[] { new DataCell("k"), new DataCell("QElements"), new DataCell("Con.Type") }, 3);
            DataCellRow ColOfLineHeader = null;
            DataCellRow[] Content;
            string []sa = /*new string[]*/ { "--", "//"};
            if(this.Conn_Suc0Par1==0) TblHdr = new DataCell("HydroResistance - " + this.QElements.ToString() + " Elements, Connection: "+sa[1-1]);
            else   TblHdr = new DataCell("HydroResistance - " + this.QElements.ToString() + " Elements, Connection: " + sa[2 - 1]);
            if (this.QElements == 0)
            {
                Content = new DataCellRow[1];
                //Content[1 - 1] = new DataCellRow(new DataCell[] { new DataCell(0), new DataCell(0), new DataCell(sa, 2) }, 3);
                Content[1 - 1] = new DataCellRow(new DataCell[] { new DataCell("-"), new DataCell(0), new DataCell("-") }, 3);
                //Content[1 - 1].SetActiveN(1, 2);
                tbl = new TTable(new TableInfo(true, true, true, 1, 3), false, Content, LineOfColHeader, ColOfLineHeader, new TableHeaders(TblHdr, LinesGeneralName, ColumnsGeneralName), true);
            }
            else
            {
                Content = new DataCellRow[this.QElements];
                for (int i = 1; i <= this.QElements; i++)
                {
                    //Content[i - 1] = new DataCellRow(new DataCell[] { new DataCell(elems[i - 1].QElements), new DataCell(elems[i - 1].Succ0Parallel1), new DataCell(elems[i - 1].k) }, 3);
                    Content[i - 1] = new DataCellRow(new DataCell[] { new DataCell(elems[i - 1].k), new DataCell(elems[i - 1].QElements), new DataCell(sa, 2) }, 3);
                    SNP = this.elems[i - 1].Conn_Suc0Par1;
                    Content[i - 1].SetActiveN(SNP + 1, 3);
                    SNP = Content[i - 1].GetActiveN(3);
                    //Content[i - 1].SetActiveN(this.elems[i - 1].Succ0Parallel1 + 1, 2);
                }
                tbl = new TTable(new TableInfo(true, true, true, this.QElements, 3), false, Content, LineOfColHeader, ColOfLineHeader, new TableHeaders(TblHdr, LinesGeneralName, ColumnsGeneralName), true);
            }
            //tbl = new TTable(new TableInfo(true, true, true, this.QElements, 3), true, Content, LineOfColHeader, ColOfLineHeader, new TableHeaders(TblHdr, LinesGeneralName, ColumnsGeneralName), true);
            
            return tbl;
        }
        public void SetMainInfoFromTable(TTable tbl)
        {
            this.k = tbl.GetDoubleVal(3, 1);
            this.QElements = tbl.GetIntVal(1, 1);
            this.Conn_Suc0Par1 = 1 + tbl.GetActiveN(2, 1);
        }
        public void SetElementsFromTable(TTable tbl)
        {
            int Q = tbl.GetQLines();
            this.elems=new PrimitiveElement[Q];
        }
        public double CoutKSum(TValsShowHide vsh=null)
        {
            double R = 0, c=0, s;
            //if(this.QElements==0)R=this.k;
            // if (vsh != null) MyLib.writeln(vsh, "Resistance: QElements=" + this.QElements.ToString() + ", k=" + this.k.ToString()+" Connection type: "+this.Succ0Parallel1.ToString());
            //MyLib.writeln(vsh, "Resistance: R"+CurN.ToString()+" QElements=" + this.QElements.ToString() + ", k=" + this.k.ToString() + " Connection type: " + this.Succ0Parallel1.ToString());
            MyLib.writeln(vsh, this.ToString());
            s=0;
            R = this.k;
            if (vsh != null) MyLib.writeln(vsh, "k=" + this.k.ToString() + ", R=" + R.ToString());
            for (int i = 1; i <= this.QElements; i++)
            {
                //if (vsh != null) MyLib.writeln(vsh, "Sub-Element N " + i.ToString());
                MyLib.writeln(vsh, "Sub-Element N " + i.ToString() + " R" + this.elems[i - 1].curN.ToString());
                MyLib.writeln(vsh, "Elt[" + i.ToString() + "]=" + this.elems[i - 1].ToString());
                c = this.elems[i - 1].CoutKSum(vsh);
                if (this.Conn_Suc0Par1 == 0)
                {
                    //s = s + c;
                    s = s + c*c;
                }
                else
                {
                    if(c!=0) s += 1/c;
                    //else s+=0;
                }
                if (vsh != null) MyLib.writeln(vsh, "C=" + c.ToString() + ", s=" + s.ToString());
                
            }
            if (this.Conn_Suc0Par1 == 0)
            {
                 //R+= s;
                 R = R + Math.Sqrt(s);
            }
            else
            {
                if (s != 0) R =R+ 1 / s;//R+ = 1 / s;
                //else R+=0;
            }
            if (vsh != null) MyLib.writeln(vsh, "s=" + s.ToString() + ", R=" + R.ToString());
            return R;
        }
        //
        //vis
        //
        public int vis_L(TValsShowHide vsh)
        {
            MyLib.writeln(vsh, "vis_L starts working. R: " + this.ToString());
            int L = 1, Lmax=0, Lcur=0;//simple or left wall
            MyLib.writeln(vsh, " L=1="+L.ToString()+" If it's simple, so it is, if it's complex - left wall");
            if (this.upper == null)
            {
                L = L+1;//L2=
                MyLib.writeln(vsh, "Ext: now L=2=" + L.ToString() + " it's most external - left connector + left wall");
            }
            if (this.QElements > 0)
            {
                if (this.Conn_Suc0Par1 == 0)
                {
                    MyLib.writeln(vsh, "It's complex. First-level sub-elements s'united in succession");
                    for (int i = 1; i <= this.QElements-1; i++)
                    {
                        Lcur = this.elems[i - 1].vis_L(vsh);
                        L = L + Lcur;
                        L = L + 1;//connector
                        MyLib.writeln(vsh, "( returning to R" + this.curN.ToString() + ")");
                        MyLib.writeln(vsh, i.ToString()+") Lcur="+Lcur.ToString()+"+1 connector. now L="+L.ToString());
                    }
                    Lcur = this.elems[this.QElements - 1].vis_L(vsh);
                    L = L + Lcur;
                    MyLib.writeln(vsh, "( returning to R" + this.curN.ToString() + ")");
                    MyLib.writeln(vsh, this.QElements.ToString() + ") Lcur=" + Lcur.ToString() + " L=" + L.ToString());
                }
                else //parallel
                {
                    MyLib.writeln(vsh, "It's complex. First-level sub-elements s'united parallelly. Finding max");
                    L = L + 1;//connector left
                    MyLib.writeln(vsh, "Connector left: L=" + L.ToString());
                    for (int i = 1; i <= this.QElements; i++)
                    {
                        Lcur = this.elems[i - 1].vis_L(vsh);
                        if (i == 1 || (i > 1 && Lmax < Lcur))
                        {
                            Lmax = Lcur;
                            //MyLib.writeln(vsh, "( returning to R) " + i.ToString() + ") Lcur=" + Lcur.ToString() + " Lmax=" + Lmax.ToString() );
                        }
                        MyLib.writeln(vsh, "( returning to R" + this.curN.ToString()+")");
                        MyLib.writeln(vsh, i.ToString() + ") Lcur=" + Lcur.ToString() + " Lmax=" + Lmax.ToString());
                    }
                    //Lmax=this.vis_
                    L = L + Lmax;
                    L = L + 1;//connector right
                    MyLib.writeln(vsh, " Lmax=" + Lmax.ToString() + "+2 connectors. so L=" + L.ToString());
                }
                L = L + 1;//right wall
                MyLib.writeln(vsh, "+1 right wall. so L=" + L.ToString());
            }
            else
            {
                MyLib.writeln(vsh, "Simple: nil to add. L=" + L.ToString());
            }
            if (this.upper == null)
            {
                L = L + 1;//L2=
                MyLib.writeln(vsh, "Ext: L=L+1= " + L.ToString() + " - right connector + right wall");
            }
            MyLib.writeln(vsh, "vis_L finishes working. R" + this.curN.ToString()+" L="+L.ToString());
            return L;
        }
        public int vis_SE_maxL(TValsShowHide vsh)
        {
            int Lcur, Lmax = 0;
            for (int i = 1; i <= this.QElements; i++)
            {
                Lcur = this.elems[i - 1].vis_L(vsh);
                if (i == 1 || (i > 1 && Lmax < Lcur)) Lmax = Lcur;
            }
            return Lmax;
        }
        public int vis_SE_maxH()
        {
            int hcur, hmax = 0;
            for (int i = 1; i <= this.QElements; i++)
            {
                hcur = this.elems[i - 1].vis_H(vsh);
                if (i == 1 || (i > 1 && hmax < hcur)) hmax = hcur;
            }
            return hmax;
        }
        public int vis_maxLUpper(TValsShowHide vsh)
        {
            int Lcur, Lmax = 0;
            for (int i = 1; i <= this.QElements; i++)
            {
                Lcur = this.upper.elems[i - 1].vis_L(vsh);
                if (i == 1 || (i > 1 && Lmax < Lcur)) Lmax = Lcur;
            }
            return Lmax;
        }
        public int vis_SE_maxYUpper(TValsShowHide vsh=null)
        {
            int ycur, ymax = 0;
            for (int i = 1; i <= this.QElements; i++)
            {
                ycur = this.elems[i - 1].vis_yUpper(vsh);
                if (i == 1 || (i > 1 && ymax < ycur)) ymax = ycur;
            }
            return ymax;
        }
        public int vis_SE_maxYLower()
        {
            int ycur, ymax = 0;
            for (int i = 1; i <= this.QElements; i++)
            {
                ycur = this.elems[i - 1].vis_yLower(vsh);
                if (i == 1 || (i > 1 && ymax < ycur)) ymax = ycur;
            }
            return ymax;
        }
        public int vis_yUpper(TValsShowHide vsh)
        {
            int yUpper=0, yUpperMax, yUpperCur;
            MyLib.writeln(vsh,"vis_yUpper starts working. "+this.ToString()+" yUpper="+yUpper.ToString());
            if (this.elems!=null && this.QElements>0){
                yUpper=yUpper+1;
                MyLib.writeln(vsh,"complex: 1 upper wall. yUpper="+yUpper.ToString());
                if(this.Conn_Suc0Par1==0){
                    MyLib.writeln(vsh,"[--] finding max");
                    yUpperMax=0;
                    for(int i=1; i<=this.QElements; i++){
                        yUpperCur=this.elems[i-1].vis_yUpper(vsh);
                        if(i==1 || (i>1 && yUpperMax<yUpperCur)){
                            yUpperMax=yUpperCur;
                        }
                        MyLib.writeln(vsh,"-element"+i.ToString()+" R"+(this.elems[i-1].curN).ToString()+": yUpperCur="+yUpper.ToString()+" yUpperMax="+yUpperMax.ToString());
                    }
                    yUpper=yUpper+yUpperMax;
                    MyLib.writeln(vsh,"yUpper = yUpper+ yUpperMax: ="+yUpper.ToString()+" (yUpperMax = "+yUpper.ToString());
                }else{
                    MyLib.writeln(vsh,"[||] yUpper = first");
                    yUpperCur=this.elems[1-1].vis_yUpper(vsh);
                    yUpper=yUpper+yUpperCur;
                    MyLib.writeln(vsh,"Return to prev. yUpper=yUpperCur+1="+yUpperCur.ToString());
                }
            }else{
                MyLib.writeln(vsh,"simple - nil to add");
                MyLib.writeln(vsh,"vis_yUpper finishes working. "+this.ToString()+" yUpper="+yUpper.ToString());
            }
            return yUpper;
        }
        public int vis_yLower(TValsShowHide vsh)
        {
           int yLower=0, yLowerCur, yUpperCur, yLowerMax;
            MyLib.writeln(vsh,"vis_yLower starts working. "+this.ToString()+" yLower="+yLower.ToString());
            if(this.elems!=null && this.QElements>0){
                yLower=yLower+1;
                MyLib.writeln(vsh,"complex: 1 upper wall. yLower="+yLower.ToString());
                if(this.Conn_Suc0Par1==0){
                    MyLib.writeln(vsh,"[--] finding max");
                    yLowerMax=0;
                    for(int i=1; i<=this.QElements; i++){
                        yLowerCur=this.elems[i-1].vis_yLower(vsh);
                        if(i==1 || (i>1 && yLowerMax<yLowerCur)){
                            yLowerMax=yLowerCur;
                        }
                        MyLib.writeln(vsh, "-element" + i.ToString() + " R" + (this.elems[i - 1].curN).ToString() + ": yLowerCur=" + (yLowerCur).ToString() + " yLowerMax=" + (yLowerMax).ToString());
                    }
                    yLower=yLower+yLowerMax;
                MyLib.writeln(vsh,"yLower = yLower+ yLowerMax: ="+yLower.ToString()+" (yLowerMax = "+yLower.ToString()+")");
                }else{
                    yLowerCur=yLower+this.elems[1-1].vis_yLower(vsh);
                    yLower=yLower+yLowerCur;
                    MyLib.writeln(vsh,"yLower = yLower+ yLowerCur[1]: ="+yLower.ToString()+" (yLowerCur[1] = "+(yLowerCur).ToString()+")");
                    for(int i=2; i<=this.QElements-1; i++){
                        yUpperCur=this.elems[i-1].vis_yLower(vsh);
                        yLowerCur=this.elems[i-1].vis_yLower(vsh);
                        yLower=yLower+yUpperCur+yLowerCur+1;
                        MyLib.writeln(vsh,"yLower = yLower+ yUpperCur+ yLowerCur: ="+yLower.ToString()+" (yUpperCur = "+(yUpperCur).ToString()+" yLowerCur = "+(yLowerCur).ToString()+")");
                    }
                    yUpperCur=this.elems[this.QElements-1].vis_yLower(vsh);
                    yLowerCur=this.elems[this.QElements-1].vis_yLower(vsh);
                    yLower=yLower+yUpperCur+yLowerCur+1;
                    MyLib.writeln(vsh,"Return to prev. yLower="+yLower.ToString());
                }
            }else{
                MyLib.writeln(vsh,"simple - nil to add");
            }
            MyLib.writeln(vsh,"vis_yLower finishes working. "+this.ToString()+" yLower="+yLower.ToString());
            return yLower;
        }
        public int vis_H(TValsShowHide vsh)
        {
            return this.vis_yUpper(vsh) + this.vis_yLower(vsh);
        }
        
        public int vis_LFromRightWallToRightContact(TValsShowHide vsh)
        {
            int L = 1, xmax;
            int myL = this.vis_L(vsh);
            MyLib.writeln(vsh, "");
            L = L + myL;
            if (this.upper != null)
            {
                if (this.upper.Conn_Suc0Par1 == 0)
                {
                    for (int i = 1; i <= this.QElements-1; i++)
                    {
                        L = L + this.elems[i - 1].vis_L(vsh);
                    }
                }
                else
                {
                    xmax = this.vis_maxLUpper(vsh);
                    L = L + xmax;
                }
            }
            MyLib.writeln(vsh, "");
            return L;
        }
        public int vis_x_of_SE_N_RelativeInner(int N, TValsShowHide vsh)
        {
            int x = 0, leftContactX, curL;
            if (N >= 1 && N <= this.QElements)
            {
                if (this.Conn_Suc0Par1 == 0)
                {
                    leftContactX = 0;
                    x=leftContactX+1;
                    for (int i = 1; i <= N - 1; i++)
                    {
                        curL=this.elems[i - 1].vis_L(vsh);
                        x = x + curL;
                        x = x + 1;
                    }
                }
                else
                {
                    leftContactX = 1;
                    x=leftContactX+1;
                }
            }
            return x;
        }
        public int vis_y_of_SE_N_RelativeInner(int N)
        {
            int y = 0, curH;
            if (N >= 1 && N <= this.QElements)
            {
                if(this.Conn_Suc0Par1==1){
                    if (N > 1)
                    {
                        y = y + this.elems[1 - 1].vis_yLower(vsh)+1;
                        for (int i = 2; i <= N - 1; i++)
                        {
                            curH = this.elems[1 - 1].vis_H(vsh);
                            y = y + curH;
                            y=y+1;
                        }
                        y=y+this.elems[N-1].vis_yUpper(vsh);
                    }
                }
            }
            return y;
        }
        public int vis_x(TValsShowHide vsh)
        {
            int x=0, xUp=2, xRel=0;
            if (this.upper != null)
            {
                xUp = this.upper.vis_x(vsh);
                xRel = this.upper.vis_x_of_SE_N_RelativeInner(this.NinUpper, vsh);
            }
            x = xUp + xRel;
            return x;
        }
        public int vis_y()
        {
            int y = 0, yUp = 2, yRel=0;
            if (this.upper != null)
            {
                yUp = this.upper.vis_y();
                yRel = this.upper.vis_y_of_SE_N_RelativeInner(this.NinUpper);
            }
            y = yUp + yRel;
            return y;
        }
        int vis_RightCnctLineL(TValsShowHide vsh)
        {
            int myL, Ly=0;
            int mateMaxL=0;
            myL = this.vis_L(vsh);
            if (this.upper != null && this.upper.Conn_Suc0Par1 == 1)
            {
                mateMaxL = this.upper.vis_SE_maxL(vsh);
                Ly = mateMaxL - myL;
            }
            return Ly;
        }
        int vis_LeftContactXRel() { return -1; }
        int vis_RightContactXRel(TValsShowHide vsh) { return this.vis_RightCnctLineL(vsh) + 1; }
        int vis_LeftContactYRel() { return 0; }
        int vis_RightContactYRel() { return 0; }
        int vis_LeftUpperCornerXRel() { return 0; }
        int vis_LeftUpperCornerYRel() { return this.vis_yUpper(vsh); }
        int vis_RightUpperCornerXRel(TValsShowHide vsh) { return this.vis_L(vsh); }
        int vis_RightUpperCornerYRel() { return this.vis_yUpper(vsh); }
        int vis_LeftLowerCornerXRel() { return 0; }
        int vis_LeftLowerCornerYRel() { return this.vis_yLower(vsh); }
        int vis_RightLowerCornerXRel(TValsShowHide vsh) { return this.vis_L(vsh); }
        int vis_RightLowerCornerYRel() { return this.vis_yLower(vsh); }
        int vis_RHeaderXRel()
        {
            int x = 0;
            if (this.QElements > 0) x = 1;
            return x;
        }
        int vis_RHeaderYRel()
        {
            int y = 0;
            if (this.QElements > 0) y = -1;
            return y;
        }
        
        public void vis_DisplayAll(HydroSchemCanvas canvas, TValsShowHide vsh=null)
        {
            int x, y, L, H, yUpper, yLower, RightConnectorX, RightConnectorXRel;
            int x1, y1;
            MyLib.writeln(vsh, "");
            MyLib.writeln(vsh, "vis_DisplayAll starts working. R"+this.curN.ToString());
            x = this.vis_x(vsh);
            y = this.vis_y();
            L = this.vis_L(vsh);
            H = this.vis_H(vsh);
            yUpper = this.vis_yUpper(vsh);
            yLower = this.vis_yLower(vsh);
            RightConnectorXRel=this.vis_RightLowerCornerXRel(vsh);
            RightConnectorX=x+RightConnectorXRel;
            MyLib.writeln(vsh, " x=" + x.ToString() + " y=" + y.ToString() + " L=" + L.ToString() + " H=" + H.ToString() + " yUpper=" + yUpper.ToString());
            MyLib.writeln(vsh, " RightConnectorXRel=" + RightConnectorXRel.ToString() + " RightConnectorX=" + RightConnectorX.ToString());
            //connectors
            if (this.upper == null)
            {
                canvas.Draw_ConnectorCentral(x - 1, y);
                canvas.Draw_ConnectorCentral(RightConnectorX, y);
                MyLib.writeln(vsh, " this.upper == null. Connectors central at: Left: [" + (x-1).ToString()+", "+y.ToString()+"], Right: ["+RightConnectorX.ToString()+", "+y.ToString()+"]");
            }
            else if (this.upper.Conn_Suc0Par1 == 1 && this.NinUpper < this.upper.QElements)
            {
                canvas.Draw_ConnectorLeft(x - 1, y);
                canvas.Draw_ConnectorRight(RightConnectorX, y);
                MyLib.writeln(vsh, " this is R - 1 of //, not last. Connectors central at: Left: [" + (x - 1).ToString() + ", " + y.ToString() + "], Right: [" + RightConnectorX.ToString() + ", " + y.ToString() + "]");
            }
            else if (this.upper.Conn_Suc0Par1 == 1 && this.NinUpper == this.upper.QElements)
            {
                canvas.Draw_ConnectorLeft(x - 1, y);
                canvas.Draw_ConnectorRight(RightConnectorX, y);
                MyLib.writeln(vsh, " this is R - 1 of //, ja last. Connectors central at: Left: [" + (x - 1).ToString() + ", " + y.ToString() + "], Right: [" + RightConnectorX.ToString() + ", " + y.ToString() + "]");
            }
            else if (this.upper.Conn_Suc0Par1 == 0)
            {
                if(this.NinUpper >1){
                    canvas.Draw_ConnectorLeft(x - 1, y);
                }
                if (this.NinUpper < this.upper.QElements)
                {
                    canvas.Draw_ConnectorRight(RightConnectorX, y);
                }
            }
            //horisontal lines
            for (int i = 1; i <= RightConnectorXRel; i++)
            {
                canvas.Draw_LineHorisontal(x + L + i - 1, y);
            }
            //vertical lines
            if (this.upper == null && this.upper.Conn_Suc0Par1 == 1 && this.NinUpper > 1)
            {
                x1 = this.upper.elems[NinUpper - 1 - 1].vis_x(vsh);
                y1 = this.upper.elems[NinUpper - 1 - 1].vis_y();
                for (int i = y1 + 1; i <= y - 1; i++)
                {
                    canvas.Draw_LineVertical(x -  1, i);
                    canvas.Draw_LineVertical(RightConnectorX - 1, i);
                }
            }

            if (this.upper == null && (!(this.upper.Conn_Suc0Par1 == 0 && this.NinUpper == this.upper.QElements)))
            {
                 canvas.Draw_ConnectorLeft(x+L - 1, y);
            }
            if (this.QElements > 0)
            {
                if (this.upper == null)
                {
                    
                }
                else
                {

                }
            }
            else
            {
                if (this.upper == null)
                {

                }
                else
                {

                }
            }
            MyLib.writeln(vsh, "vis_DisplayAll finishes working. R" + this.curN.ToString());
        }//fn
        
        public bool CoordsBelongToThisElement(int x, int y, PrimitiveElement elt){
            bool b=false;
            b=(x==elt.vis_x(null) && y==elt.vis_y());
            return b;
        }
        public PrimitiveElement SeekElementByDelegate(int x, int y)
        {
            PrimitiveElement cur = nav_GoToTop(), ptr = null;
            int Cur_SE_N;
            bool found = (cur.CoordsBelongToThisElement(x, y, cur) == true), contin=!found;
            if (found)
            {
                ptr = cur;
            }
            else
            {
                contin = (cur.QElements > 0);
                Cur_SE_N = 0;
                while (contin)
                {
                    Cur_SE_N = Cur_SE_N + 1;
                    cur = cur.elems[Cur_SE_N - 1];
                    found = (cur.CoordsBelongToThisElement(x, y, cur) == true);
                    contin = !found;
                    if (found)
                    {
                        ptr = cur;
                    }
                }
            }
            return ptr;
        }
        //
        public PrimitiveElement nav_GoToTop()
        {
            PrimitiveElement ptr = this;
            if (ptr.upper != null)
            {
                ptr = ptr.upper;
            }
            return ptr;
        }
        public PrimitiveElement nav_GoToUpper()
        {
            return this.upper;
        }
        public PrimitiveElement nav_Enter()
        {
            PrimitiveElement subElt = null;
            if (this.elems != null)
            {
                subElt = this.elems[1 - 1];
            }
            return subElt;
        }
        public PrimitiveElement nav_SubEltN(int N)
        {
            PrimitiveElement subElt = null;
            if (this.elems != null && N>=1 && N<=this.QElements)
            {
                subElt = this.elems[N - 1];
            }
            return subElt;
        }
        public PrimitiveElement nav_Prev()
        {
            PrimitiveElement subElt = null;

            if (this.upper != null && this.NinUpper > 1 && this.NinUpper <= this.upper.QElements)
            {
                subElt = this.upper.elems[this.NinUpper - 1-1];
            }
            return subElt;
        }
        public PrimitiveElement nav_Next()
        {
            PrimitiveElement subElt = null;

            if (this.upper != null && this.NinUpper >= 1 && this.NinUpper < this.upper.QElements)
            {
                subElt = this.upper.elems[this.NinUpper+1 - 1];
            }
            return subElt;
        }
        public PrimitiveElement nav_First()
        {
            PrimitiveElement subElt = null;
            if (this.upper != null)
            {
                subElt = this.elems[1 - 1];
            }
            return subElt;
        }
        public PrimitiveElement nav_Last()
        {
            PrimitiveElement subElt = null;
            if (this.upper != null)
            {
                subElt = this.elems[this.upper.QElements - 1];
            }
            return subElt;
        }
    
public  TValsShowHide vsh { get; set; }}//cl
    //
    public class PrimitivePipeLine
    {
        public PrimitiveElement First, Cur, Tmp;
        //
        public PrimitivePipeLine()
        {
            this.Cur = new PrimitiveElement();
            this.First = this.Cur;
            this.Tmp = (PrimitiveElement)this.First.Clone();
        }
        //
        //public void SetOne(){
        //    this.Tmp = new PrimitiveElement();
        //    this.
        //}
        //
        public void Enter()
        {
            if (this.Cur.QElements > 0)
            {
                this.Cur.SetFirst();
                this.Cur = this.Cur.GetCurrent();
            }
            this.Tmp = (PrimitiveElement)Cur.Clone();
        }
        public void GotoFirst()
        {
            if (this.Cur.GetUpper() != null)
            {
                this.Cur = this.Cur.GetUpper();
                this.Cur.SetFirst();
                //this.Cur.GetCurrent();
            }
        }
        public void GotoLast()
        {
            if (this.Cur.GetUpper() != null)
            {
                this.Cur = this.Cur.GetUpper();
                this.Cur.SetLast();
                this.Cur.GetCurrent();
            }
        }
        public void GotoNext()
        {
            if (this.Cur.GetUpper() != null)
            {
                this.Cur = this.Cur.GetUpper();
                this.Cur.SetNext();
                this.Cur.GetCurrent();
            }
        }
        public void GotoPrevious()
        {
            if (this.Cur.GetUpper() != null)
            {
                this.Cur = this.Cur.GetUpper();
                this.Cur.SetPrevious();
                this.Cur = this.Cur.GetCurrent();
            }
        }
        public void GotoLevelUp()
        {
            if (this.Cur.GetUpper() != null) this.Cur = this.Cur.GetUpper();
        }
        public void GoToRoot()
        {
            this.Cur = this.First;
        }
        public void SetN(int N)
        {
            this.Cur.SetN(N);
        }
        //
        public void Add(PrimitiveElement elem=null)
        {
            //if(elem!=null) this.Cur.Add(elem);
            //else if (this.Tmp != null) this.Cur.Add(this.Tmp);
            //
            PrimitiveElement addon;
            if (elem != null) addon = (PrimitiveElement)elem.Clone();
            else addon = (PrimitiveElement)this.Tmp.Clone();
            this.Cur.AddInner(addon);
        }
        public void AddCopy()
        {
            this.Tmp = this.Cur.GetCurrent();
            this.Cur.AddInner(this.Tmp);
        }

        public void Ins(int N, PrimitiveElement elem=null)
        {
            //if (elem != null) this.Cur.Ins(elem, N);
            //else if (this.Tmp != null) this.Cur.Ins(this.Tmp, N);
            PrimitiveElement addon;
            if (elem != null) addon = (PrimitiveElement)elem.Clone();
            else addon = (PrimitiveElement)this.Tmp.Clone();
            this.Cur.InsInner(addon, N);
        }
        public void Del(int N)
        {
            this.Cur.DelInner(N);
        }
        //
        public void CopyCurElement()
        {
            this.Tmp = (PrimitiveElement)this.Cur.Clone();
        }
        //
        public void SetElementsTable(TTable tbl)
        {
            //this.Cur.SetElementsFromTable(tbl);
            this.Tmp.SetElementsFromTable(tbl);
        }
        public void SetMainInfoFromTable(TTable tbl)
        {
            //this.Cur.SetMainInfoFromTable(tbl);
            this.Tmp.SetMainInfoFromTable(tbl);
        }
        //
        public TTable Components_GetAsTable()
        {
            TTable tbl;
            tbl = this.Tmp.Components_GetAsTable();
            return tbl;
        }
        public TTable Main_GetAsTable()
        {
            TTable tbl;
            tbl = this.Tmp.Main_GetAsTable();
            return tbl;
        }
        //
        public void vis_SetCanvasSizeForSchem(HydroSchemCanvas canvas, TValsShowHide vsh=null)
        {
            int L = this.First.vis_L(vsh) + 2;
            int H = this.First.vis_H(vsh);
            canvas.SetSize(L, H);
        }
        public void vis_DisplaySchem(HydroSchemCanvas canvas)
        {
            this.vis_SetCanvasSizeForSchem(canvas);
            this.First.vis_DisplayAll(canvas);//method s'public
        }
    }
    //=======================================================================================================
    public class MyListElement:ICloneable
    {
        public MyListElement[] parallel, succ;
        MyListElement upper;
        int NParallel, NSucc;
        //static int count;
        public HydroResistanceIniData data;
        public HydroResistanceCalcdData cd;
        public TResistanceSectionParams sp;
        int n;
        public MyListElement()
        {
            setNull();
        }
        public MyListElement(MyListElement upper)
        {
            setNull();
            setUpper(upper);
        }
        public MyListElement(int x)
        {
            setNull();
            setX(x);
        }
        public MyListElement(MyListElement upper, int x)
        {
            setNull();
            setUpper(upper);
            setX(x);
        }
        public MyListElement GetUpper()
        {
            return upper;
        }
        public void setNull()
        {
            succ = null;
            parallel = null;
            upper = null;
            n = 0;
            data = null;
            cd = null;
            sp = null;
            n = 0;
        }
        public void setUpper(MyListElement upper)
        {
            this.upper = upper;
        }
        public void setX(int x)
        {
            this.n = x;
        }
        public void setParallel(MyListElement[] parallel)
        {
            this.parallel = parallel;
        }
        public void setSucc(MyListElement[] succ)
        {
            this.succ = succ;
        }
        public int getX()
        {
            return this.n;
        }
        public int getParentX()
        {
            int px = 0;
            if (upper != null) px = upper.getX();
            return px;
        }
        public double CalcLambdaByNikuradze(double Re, double delta, int MethodN = 6, int Nearest1InterpBetweenTwoNearest2 = 1)
        {
            double lambda = 0;
            //lambda = LambdaNikuradzeDiagram.CalcLambda(Re, delta, Nearest1InterpBetweenTwoNearest2);
            lambda = HydroResistanceConsts.CalcLambda(Re, delta, Nearest1InterpBetweenTwoNearest2);
            return lambda;
        }
        public double fRe(double V, TWorkLiquidOrGas WorkLqvdOrGas)
        {
            //double ro, nu;
            double Re = 0;
            Re = Re;
            return Re;
        }
        public HydroResistanceCalcdData Calc(double Gv, TWorkLiquidOrGas WorkLqvdOrGas)
        {
            HydroResistanceCalcdData res=null;//!=null ob struct

            return res;
        }
        public double CalcSingleResistance(double Gv, TWorkLiquidOrGas WorkLqvdOrGas, int MethodN = 6)
        {
            double dzeta = 0;
            HydroResistanceCalcdData res = this.Calc(Gv, WorkLqvdOrGas);
            dzeta = res.dzeta;
            return dzeta;
        }
        public double CalcParallelK(double Q)
        {
            double KSum = 0;

            return KSum;
        }
        public double CalcSuccK(double Q)
        {
            double KSum = 0;

            return KSum;
        }
        public double CalcQForParallelRN(double Q, int N)
        {
            double KSum = 0, numerator = 1, denominator = 0;
            double[] k = null;
            if (parallel != null)
            {
                NParallel = parallel.Length;
                for (int i = 1; i <= NSucc; i++)
                {

                }
            }
            return KSum;
        }
        public double CalcQForSuccRN(int N)
        {
            double KSum = 0, numerator = 1, denominator = 0;
            double[] k = null;
            if (succ != null)
            {
                NSucc = succ.Length;
                for (int i = 1; i <= NSucc; i++)
                {

                }
            }
            return KSum;
        }
        //
        public void Reverse()
        {
            //MyListElement[]elts=null;
            MyListElement elt=null;
            //int NBound;
            if (this.NSucc != 0)
            {
                //elts = new MyListElement[this.NSucc];
                //if (this.NSucc % 2 == 0) NBound = this.NSucc / 2;
                //else NBound = (this.NSucc-1) / 2;
                //for (int i = 1; i <= NBound; i++)
                //{
                //    MyLib.Swap<MyListElement>(ref succ[i - 1], ref succ[this.NSucc - i+1-1]);
                //}
                for (int i = 1; i <= this.NSucc; i++)
                {
                    elt = (MyListElement)this.succ[i - 1].MemberwiseClone();
                    this.succ[i - 1] = (MyListElement)this.succ[this.NSucc - i + 1 - 1].MemberwiseClone();
                    this.succ[this.NSucc - i + 1 - 1] = (MyListElement)elt.MemberwiseClone();
                }
                for (int i = 1; i <= this.NSucc; i++)
                {
                    this.succ[i - 1].Reverse();
                }
            }
            else if (this.NParallel != 0)
            {
                //is this recursion?
                for (int i = 1; i <= this.NParallel; i++)
                {
                    this.parallel[i - 1].Reverse();
                }
            }
            else
            {
                this.data.Reverse();
            }
            
        }
        //
        public TTable IniDataAllRessToTable()
        {
            DataCellRow[]rows;
            DataCellRow ColHdr;
            //DataCellRowCoHeader[]rows;
            int Q;
            int QColumns=11;
            if (NSucc != 0) Q = NSucc;
            else Q = NParallel;
            ColHdr=new DataCellRow(new DataCell[]
                                    {       new DataCell("GroupN"), 
                                            new DataCell("TypeN"), 
                                            new DataCell("TypeName"), 
                                            new DataCell("Name"), 
                                            new DataCell("D/S"), 
                                            new DataCell("D1/S1"), 
                                            new DataCell("alfa"), 
                                            new DataCell("R"), 
                                            new DataCell("L")//, 
                                            //new DataCell("S") 
                                    },QColumns
            );
            rows=new DataCellRow[Q];//CoHeader[Q];
            if(NSucc != 0){
                for(int i=1; i<=Q; i++){
                    rows[i-1]=new DataCellRow(new DataCell[]
                                    {       new DataCell(succ[i-1].data.GroupN), // new DataCell("GroupN"), 
                                            new DataCell(succ[i-1].data.TypeN),  //new DataCell("TypeN"),
                                            new DataCell(succ[i-1].data.TypeName), //new DataCell("TypeName"), 
                                            new DataCell(succ[i-1].data.PartName), //new DataCell("Name"),
                                            new DataCell(succ[i-1].data.De), // new DataCell("D"), 
                                            new DataCell(succ[i-1].data.Param), //new DataCell("D1"),
                                            new DataCell(succ[i-1].data.alfa), // new DataCell("alfa"), 
                                            new DataCell(succ[i-1].data.R), // new DataCell("R"), 
                                            new DataCell(succ[i-1].data.L)//, // new DataCell("L"),
                                            //new DataCell(succ[i-1].data.S) // new DataCell("S") 
                                    },QColumns
                    );
                }
            }
            TTable tbl = null;
            /* tbl = new TTable(
                new TableInfo(true, true, true, Q, QColumns),
                false,

            );*/
            return tbl;
            
        }
        public void SetFromTable(TTable tbl)
        {

        }
        public object Clone()
        {
            MyListElement acopy;
            acopy = new MyListElement();
            acopy.upper = this.upper;
            acopy.n = this.n;
            if (this.NSucc != 0)
            {
                acopy.NSucc = this.NSucc;
                acopy.NParallel = 0;
                //acopy.data = null; //constr
                //acopy.cd = null; //constr
                acopy.succ = new MyListElement[NSucc];
                for (int i = 1; i <= NSucc; i++)
                {
                    acopy.succ[i - 1] = (MyListElement)this.succ[i - 1].Clone();//ce recursion!
                }
            }
            else if (this.NParallel != 0)
            {
                acopy.NParallel = this.NParallel;
                acopy.NSucc = 0;
                //acopy.data = null; //constr
                //acopy.cd = null; //constr
                acopy.succ = new MyListElement[NSucc];
                for (int i = 1; i <= NSucc; i++)
                {
                    acopy.parallel[i - 1] = (MyListElement)this.parallel[i - 1].Clone();//ce recursion!
                }
            }
            else
            {
                acopy.NSucc = 0;
                acopy.NParallel = 0;
                acopy.succ = null;
                acopy.parallel = null;
                acopy.data = new HydroResistanceIniData();
                //acopy.data.GroupN = this.data.GroupN;
                //acopy.data.GroupN = this.data.GroupN;
                //acopy.data.TypeN = this.data.TypeN;
                //acopy.data.TypeName = this.data.TypeName;
                //acopy.data.PartName = this.data.PartName;
                //acopy.data.D = this.data.D;
                //acopy.data.D1 = this.data.D1;
                //acopy.data.alfa = this.data.alfa;
                //acopy.data.R = this.data.R;
                //acopy.data.L = this.data.L;
                //acopy.data.S = this.data.S;
                acopy.data = (HydroResistanceIniData)this.data.Clone();
                //acopy.kG = this.kG;
                //acopy.Gv = this.Gv;0.
                if (this.cd != null)
                {
                    acopy.cd = new HydroResistanceCalcdData();
                    acopy.cd = (HydroResistanceCalcdData)this.cd.Clone();
                }
                acopy.cd = null;

            }
            return acopy;
        }
    }//cl
    public class HydroResistance
    {
        HydroResistance[] parallel, succ;
        HydroResistance upper;
        int NParallel, NSucc;
        double k_parallel_sum, k_succ_sum, k_loc_own, k_way_own, k_sum_own, k_sum_included, k;
        //static int count;
        public HydroResistance()
        {
            setNull();
        }
        public HydroResistance(HydroResistance upper)
        {
            setNull();
            setUpper(upper);
        }
        public HydroResistance(double x)
        {
            setNull();
            setX(x);
        }
        public HydroResistance(HydroResistance upper, double x)
        {
            setNull();
            setUpper(upper);
            setX(x);
        }
        public HydroResistance GetUpper()
        {
            return upper;
        }
        public void setNull()
        {
            succ = null;
            parallel = null;
            upper = null;
            k = 0;
        }
        public void setUpper(HydroResistance upper)
        {
            this.upper = upper;
        }
        public void setX(double x)
        {
            this.k = x;
        }
        public void setParallel(HydroResistance[] parallel)
        {
            this.parallel = parallel;
        }
        public void setSucc(HydroResistance[] succ)
        {
            this.succ = succ;
        }
        public double getX()
        {
            return this.k;
        }
        public double getParentX()
        {
            double px = 0;
            if (upper != null) px = upper.getX();
            return px;
        }

        public double CalcParallelK(double Q)
        {
            double KSum = 0;

            return KSum;
        }
        public double CalcSuccK(double Q)
        {
            double KSum = 0;

            return KSum;
        }
        public double CalcGvForParallelRN(double Q, int N)
        {
            double KSum = 0, numerator = 1, denominator = 0;
            double[] k = null;
            if (parallel != null)
            {
                NParallel = parallel.Length;
                for (int i = 1; i <= NSucc; i++)
                {
                    //if (N != i) //numerator *= parallel[i - 1].;
                }
            }
            return KSum;
        }
        public double CalcGvForSuccRN(int N)
        {
            double KSum = 0, numerator = 1, denominator = 0;
            double[] k = null;
            if (succ != null)
            {
                NSucc = succ.Length;
                for (int i = 1; i <= NSucc; i++)
                {

                }
            }
            return KSum;
        }
        public void SetGebrauchDistrAmongParRess(int QResistances, int QParts, ref int CountGutCombs, ref int[][] r)
        {
            int[][] c;
            int QCombsAll = MyMathLib.fIntNonNegativePower(QParts, QResistances), order = 0, CurSum, CountAllCombs = 0;//, CountGutCombs=0;
            c = new int[QCombsAll][];
            for (int i = 1; i <= QCombsAll; i++) c[i - 1] = new int[QResistances];
            r = new int[1][];
            for (int i = 1; i <= 1; i++) r[i - 1] = new int[QResistances];
            int[] cl = new int[QResistances];
            int n;
            CountGutCombs = 0;
            for (int i = 0; i <= QCombsAll; i++)
            {
                NumberParse.IntToDigits(i, QResistances, ref cl, ref order);
                CountAllCombs++;
                CurSum = 0;
                for (int j = 1; j <= QResistances; j++) CurSum += cl[i - 1];
                if (CurSum == QParts)
                {
                    CountGutCombs++;
                    if (CountGutCombs == 1)
                    {
                        for (int k = 1; k <= QResistances; k++) r[1 - 1][k - 1] = cl[k - 1];
                    }
                    else
                    {
                        n = CountGutCombs;
                        MyLib.AddLineToTable<int>(ref r, cl, ref n, ref  QResistances);
                    }
                }
            }
        }//fn
    }//cl
    //
    public class HydroPipeline
    {
        public double GvSum;
        public TWorkLiquidOrGas WorkLiquidOrGas;
        public MyListElement HydroResistance, Initial, Current;

    }
    //public static class LambdaNikuradzeDiagram
    //{
    //    public static int[] Length = { 12, 12, 14, 16, 13, 11 };
    //    public static double[] delta = { 4E-4, 2E-3, 4E-3, 8.3E-3, 0.016, 0.033 };
    //    //
    //    public static double[] x_lg_Re_1 = { 2.655, 3.325, 3.502, 3.625, 4.891, 4.994, 5.307, 5.393, 5.767, 5.8, 5.87, 6.046 };
    //    public static double[] y_lg_1000_lambda_1 = { 1.107, 0.452, 0.584, 0.593, 0.276, 0.261, 0.25, 0.261, 0.291, 0.287, 0.294, 0.294 };
    //    public static double[] x_lg_Re_2 = { 2.655, 3.325, 3.502, 3.625, 4.527, 4.823, 5, 5.236, 5.393, 5.642, 5.8, 6.046 };
    //    public static double[] y_lg_1000_lambda_2 = { 1.107, 0.452, 0.584, 0.593, 0.369, 0.328, 0.321, 0.357, 0.358, 0.373, 0.373, 0.381 };
    //    public static double[] x_lg_Re_3 = { 2.655, 3.325, 3.502, 3.625, 4.2, 4.481, 4.6, 4.74, 5, 5.22, 5.4, 5.594, 5.8, 6.046 };
    //    public static double[] y_lg_1000_lambda_3 = { 1.107, 0.452, 0.584, 0.593, 0.454, 0.402, 0.401, 0.398, 0.428, 0.446, 0.451, 0.448, 0.446, 0.459 };
    //    public static double[] x_lg_Re_4 = { 2.655, 3.325, 3.502, 3.625, 4.038, 4.2, 4.364, 4.6, 4.895, 5, 5.12, 5.4, 5.431, 5.587, 5.8, 6.046 };
    //    public static double[] y_lg_1000_lambda_4 = { 1.107, 0.452, 0.584, 0.593, 0.493, 0.481, 0.481, 0.501, 0.536, 0.539, 0.552, 0.562, 0.564, 0.549, 0.553, 0.558 };
    //    public static double[] x_lg_Re_5 = { 2.655, 3.325, 3.502, 3.625, 3.8, 3.876, 4.155, 4.2, 4.372, 4.6, 4.787, 5, 6.046 };
    //    public static double[] y_lg_1000_lambda_5 = { 1.107, 0.452, 0.584, 0.593, 0.585, 0.582, 0.599, 0.605, 0.639, 0.653, 0.662, 0.657, 0.657 };
    //    public static double[] x_lg_Re_6 = { 2.655, 3.325, 3.502, 3.518, 3.651, 3.8, 3.976, 4.2, 4.402, 4.6, 6.046 };
    //    public static double[] y_lg_1000_lambda_6 = { 1.107, 0.452, 0.584, 0.617, 0.659, 0.701, 0.737, 0.763, 0.781, 0.78, 0.78 };
    //    //
    //    public static PositionInSuccession fDeltaAmongN(double delta)
    //    {
    //        return MyMathLib.DefPosInSucc(delta, LambdaNikuradzeDiagram.delta, 6);
    //    }
    //    public static int fNearestDeltaStN(double delta)
    //    {
    //        int N = 0;
    //        PositionInSuccession loc = fDeltaAmongN(delta);
    //        if (loc.EqualN != 0) N = loc.EqualN;
    //        else if (delta < LambdaNikuradzeDiagram.delta[1 - 1]) delta = LambdaNikuradzeDiagram.delta[1 - 1];
    //        else if (delta > LambdaNikuradzeDiagram.delta[6 - 1]) delta = LambdaNikuradzeDiagram.delta[6 - 1];
    //        else
    //        {
    //            if (Math.Abs(delta - LambdaNikuradzeDiagram.delta[loc.LessN - 1]) <= Math.Abs(delta - LambdaNikuradzeDiagram.delta[loc.LessN + 1 - 1]))
    //            {
    //                N = loc.LessN;
    //            }
    //            else N = loc.LessN + 1;
    //        }
    //        return N;
    //    }
    //    //
    //    public static double CalcLambda(double Re, double delta, int Nearest1InterpBetweenTwoNearest2 = 1)
    //    {
    //        double lambda = 0, lg_Re = Math.Log10(Re);
    //        double[] lmbd = new double[6];
    //        int NearestDeltaN;//, N1, N2;
    //        //PositionInSuccession loc = null;
    //        NearestDeltaN = fNearestDeltaStN(delta);
    //        for (int N = 1; N <= 6; N++)
    //        {
    //            switch (N)
    //            {
    //                case 1:
    //                    lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_1, y_lg_1000_lambda_1, LambdaNikuradzeDiagram.Length[N - 1]);
    //                    break;
    //                case 2:
    //                    lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_2, y_lg_1000_lambda_2, LambdaNikuradzeDiagram.Length[N - 1]);
    //                    break;
    //                case 3:
    //                    lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_3, y_lg_1000_lambda_3, LambdaNikuradzeDiagram.Length[N - 1]);
    //                    break;
    //                case 4:
    //                    lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_4, y_lg_1000_lambda_4, LambdaNikuradzeDiagram.Length[N - 1]);
    //                    break;
    //                case 5:
    //                    lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_5, y_lg_1000_lambda_5, LambdaNikuradzeDiagram.Length[N - 1]);
    //                    break;
    //                case 6:
    //                    lmbd[N - 1] = MyMathLib.LInterp(lg_Re, x_lg_Re_6, y_lg_1000_lambda_6, LambdaNikuradzeDiagram.Length[N - 1]);
    //                    break;
    //            }//sw
    //        }//for
    //        if (Nearest1InterpBetweenTwoNearest2 == 1) lambda = lmbd[NearestDeltaN - 1];
    //        else lambda = MyMathLib.LInterp(delta, LambdaNikuradzeDiagram.delta, lmbd, 6);
    //        return lambda;
    //    }//fn
    //}//cl
    //
    //public struct HydroResComb
    //{
    //    public int[][] c;
    //    public int[] CurHResPartN;
    //    public int QResistances;
    //    public int QParts;
    //    //public int[] lims;
    //    public int CurSum;
    //    public int CurResistanceN, CurPartN;
    //}

    //public class TParHydrResDistrCoefs
    //{
    //    //float[][] Ki, Kr;
    //    int[][] kr;
    //    //
    //    public TParHydrResDistrCoefs(int QResistances, int QParts)
    //    {
    //        bool CombFits;
    //        int CountFittingCombs = 0;
    //        MathApprox appr=new MathApprox();
    //        float s=0;
    //        int[] lims = new int[HydroResistanceConsts.QParallelHydroResistancesMax];
    //        //Kr = new float[HydroResistanceConsts.QParallelHydroResistancesMax][];
    //        //Ki = new float[HydroResistanceConsts.QParallelHydroResistancesMax][];
    //        kr = new int[1][];
    //        for(int i=1; i<=1; i++){
    //            kr[i - 1] = new int[HydroResistanceConsts.QParallelHydroResistancesMax];
    //        }
    //        for (int i = 1; i <= HydroResistanceConsts.QParallelHydroResistancesMax; i++)
    //        {
    //            //Ki[i-1] = new float[QParts + 1];
    //            //Kr[i - 1] = new float[1];
    //            if (i <= QResistances) lims[i - 1] = QParts + 1;
    //            else lims[i - 1] = 1;
    //        }
    //        //for (int i = 1; i <= QResistances; i++)
    //        //{
    //            for (int i1 = 1; i1 <= lims[i1]; i1++)
   //            {
    //                for (int i2 = 1; i2 <= lims[i2]; i2++)
    //                {
    //                    for (int i3 = 1; i3 <= lims[i3]; i3++)
    //                    {
    //                        for (int i4 = 1; i4 <= lims[i4]; i4++)
    //                        {
    //                            for (int i5 = 1; i5 <= lims[i5]; i5++)
    //                            {
    //                                for (int i6 = 1; i6 <= lims[i6]; i6++)
    //                                {
    //                                    for (int i7 = 1; i7 <= lims[i7]; i7++)
    //                                    {
    //                                        for (int i8 = 1; i8 <= lims[i8]; i8++)
    //                                        {
    //                                            for (int i9 = 1; i9 <= lims[i9]; i9++)
    //                                            {
    //                                                for (int i10 = 1; i10 <= lims[i10]; i10++)
    //                                                {
    //                                                    for (int i11 = 1; i11 <= lims[i11]; i11++)
    //                                                    {
    //                                                        for (int i12 = 1; i12 <= lims[i12]; i12++)
    //                                                        {
    //                                                            for (int i13 = 1; i13 <= lims[i13]; i13++)
    //                                                            {
    //                                                                for (int i14 = 1; i14 <= lims[i14]; i14++)
    //                                                                {
    //                                                                    for (int i15 = 1; i15 <= lims[i15]; i15++)
    //                                                                    {
    //                                                                        for (int i16 = 1; i16 <= lims[i16]; i16++)
    //                                                                        {
    //                                                                            //
    //                                                                            s=0;
    //                                                                            //
    //                                                                            //Ki[i - 1][i1 - 1] = i1-1 / QParts;
    //                                                                            //Ki[i - 1][i2 - 1] = i2-1 / QParts;
    //                                                                            //Ki[i - 1][i3 - 1] = i3 -1/ QParts;
    //                                                                            //Ki[i - 1][i4 - 1] = i4 -1/ QParts;
    //                                                                            //Ki[i - 1][i5 - 1] = i5 -1/ QParts;
    //                                                                            //Ki[i - 1][i6 - 1] = i6-1 / QParts;
    //                                                                            //Ki[i - 1][i7 - 1] = i7-1 / QParts;
    //                                                                            //Ki[i - 1][i8 - 1] = i8-1 / QParts;
    //                                                                            //Ki[i - 1][i9 - 1] = i9-1 / QParts;
    //                                                                            //Ki[i - 1][10 - 1] = i10-1 / QParts;
    //                                                                            //Ki[i - 1][i11 - 1] = i11-1 / QParts;
    //                                                                            //Ki[i - 1][i12 - 1] = i12-1 / QParts;
    //                                                                            //Ki[i - 1][i13 - 1] = i13-1 / QParts;
    //                                                                            //Ki[i - 1][i14 - 1] = i14-1 / QParts;
    //                                                                            //Ki[i - 1][i15 - 1] = i15-1 / QParts;
    //                                                                            //Ki[i - 1][i16 - 1] = i16-1 / QParts;
    //                                                                            ////
    //                                                                            //s+=Ki[i - 1][i1 - 1];
    //                                                                            //s+=Ki[i - 1][i2 - 1];
    //                                                                            //s+=Ki[i - 1][i3 - 1];
    //                                                                            //s+=Ki[i - 1][i4 - 1];
    //                                                                            //s+=Ki[i - 1][i5 - 1];
    //                                                                            //s+=Ki[i - 1][i6 - 1];
    //                                                                            //s+=Ki[i - 1][i7 - 1];
    //                                                                            //s+=Ki[i - 1][i8- 1];
    //                                                                            //s+=Ki[i - 1][i9- 1];
    //                                                                            //s+=Ki[i - 1][i10- 1];
    //                                                                            //s+=Ki[i - 1][i11- 1];
    //                                                                            //s+=Ki[i - 1][i12- 1];
    //                                                                            //s+=Ki[i - 1][i13- 1];
    //                                                                            //s+=Ki[i - 1][i14- 1];
    //                                                                            //s+=Ki[i - 1][i15- 1];
    //                                                                            //s+=Ki[i - 1][i16- 1];
    //                                                                            //
    //                                                                            CombFits=(MyMathLib.ET(s,1,appr));
    //                                                                            CombFits=(i1+i2+i3+i4+i5+i6+i7+i8+i9+i10+i11+i12+i13+i14+i15+i16==QParts);
    //                                                                            if(CombFits){
    //                                                                                CountFittingCombs++;
    //                                                                                if (CountFittingCombs == 1)
    //                                                                                {
    //                                                                                    //for (int j = 1; j <= QResistances; j++)
    //                                                                                    //{
    //                                                                                    //Kr[1 - 1][1 - 1] = Ki[i-1][i1 - 1];
    //                                                                                    //Kr[1 - 1][2 - 1] = Ki[i-1][i2 - 1];
    //                                                                                    //Kr[1 - 1][3 - 1] = Ki[i - 1][i3 - 1];
    //                                                                                    //Kr[1 - 1][4 - 1] = Ki[i - 1][i4 - 1];
    //                                                                                    //Kr[1 - 1][5 - 1] = Ki[i - 1][i5 - 1];
    //                                                                                    //Kr[1 - 1][6 - 1] = Ki[i - 1][i6 - 1];
    //                                                                                    //Kr[1 - 1][7 - 1] = Ki[i - 1][i7 - 1];
    //                                                                                    //Kr[1 - 1][8 - 1] = Ki[i - 1][i8- 1];
    //                                                                                    //Kr[1 - 1][9 - 1] = Ki[i - 1][i9 - 1];
    //                                                                                    //Kr[1 - 1][10 - 1] = Ki[i - 1][i10 - 1];
    //                                                                                    //Kr[1 - 1][11 - 1] = Ki[i - 1][i11 - 1];
    //                                                                                    //Kr[1 - 1][12 - 1] = Ki[i - 1][i12 - 1];
    //                                                                                    //Kr[1 - 1][13 - 1] = Ki[i - 1][i13 - 1];
    //                                                                                    //Kr[1 - 1][14 - 1] = Ki[i - 1][i14 - 1];
    //                                                                                    //Kr[1 - 1][15 - 1] = Ki[i - 1][i15 - 1];
    //                                                                                    //Kr[1 - 1][16 - 1] = Ki[i - 1][i16 - 1];
    //                                                                                    //}
    //                                                                                    kr[1 - 1][1 - 1] = i1;
    //                                                                                    kr[1 - 1][2 - 1] = i2;
    //                                                                                    kr[1 - 1][3 - 1] = i3;
    //                                                                                    kr[1 - 1][4 - 1] = i4;
    //                                                                                    kr[1 - 1][5 - 1] = i5;
    //                                                                                    kr[1 - 1][6 - 1] = i6;
    //                                                                                    kr[1 - 1][7 - 1] = i7;
    //                                                                                    kr[1 - 1][8 - 1] = i8;
    //                                                                                    kr[1 - 1][9 - 1] = i9;
    //                                                                                    kr[1 - 1][10 - 1] = i10;
    //                                                                                    kr[1 - 1][11 - 1] = i11;
    //                                                                                    kr[1 - 1][12 - 1] = i12;
    //                                                                                    kr[1 - 1][13 - 1] = i13;
    //                                                                                    kr[1 - 1][14 - 1] = i14;
    //                                                                                    kr[1 - 1][15 - 1] = i15;
    //                                                                                    kr[1 - 1][16 - 1] = i16;
    //                                                                                }
    //                                                                                else
    //                                                                                {

    //                                                                                }
    //                                                                            }
    //                                                                        }
    //                                                                    }
    //                                                                }
    //                                                            }
    //                                                        }
    //                                                    }
    //                                                }
    //                                            }
    //                                        }
    //                                    }
    //                                }
    //                            }
    //                        }
    //                    }
    //                }
    //            }
    //        //}//i
    //        //int[] Ki = new int[QResistances];
    //        //int[] Kr = new int[QResistances];
    //    }
    //}//fn
    //
}//ns
