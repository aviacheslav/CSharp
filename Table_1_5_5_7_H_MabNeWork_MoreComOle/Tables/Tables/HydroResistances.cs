using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.Windows.Forms;
//
namespace Tables
{


    public class HydroPipelineElement : ICloneable
    {
        //public
       int Conn_Suc0Par1;
        public HydroPipelineElement[] elems;
        //public PrimitiveElement upper, cur;
        HydroPipelineElement upper;
        //
        HydroResistanceData HydroRData;
        //
        int curN;//, outerN;
        int curSubElementN;
        //public
        int QElements;
        //public
        //double k;
        //
        public int NinUpper;
        //public PrimitiveElement() {
        //    SetNull();
        //}
        public HydroPipelineElement(/*double k = 0,*/HydroResistanceIniData HydroIniData, int Succ0Parallel1 = 0, HydroPipelineElement[] elems = null, HydroPipelineElement upper = null, int QElements = 0, int CurN = 0, int NInUpper = 0, TValsShowHide vsh = null)
        {
            //void Set(int k = 0, int Succ0Parallel1 = 0, PrimitiveElement[] elems = null, int QElements = 0, int CurN=0, int NInUpper=0)
            this.SetNull();
            this.Set(/*k*/HydroIniData, Succ0Parallel1, elems, upper, QElements, CurN, NInUpper);
            //MyLib.writeln(vsh,"Created R"+this.CurN.ToString()+"("+CurN.ToString()+")"+" k="+this.k.ToString()+"("+k.ToString()+"). SubElts: Q="+this.QElements.ToString()+" Order --0, ||1: "+this.Succ0Parallel1.ToString());
            //MyLib.writeln(vsh,this.ToString());
            MyLib.writeln(vsh, "Created R: " + this.ToString());
        }
        public void SetNull()
        {
            this.Conn_Suc0Par1 = 0;
            this.QElements = 0;
            //this.k = 0;
            this.elems = null;
            this.upper = null;
            this.curN = 0;
            this.NinUpper = 0;
            this.curSubElementN = 1;
        }
        public void Set(/*double k = 0,*/HydroResistanceIniData HydroIniDataExt=null, int Succ0Parallel1 = 0, HydroPipelineElement[] elems = null, HydroPipelineElement upper = null, int QElements = 0, int CurN = 0, int NInUpper = 0)
        {
            SetNull();
            this.Conn_Suc0Par1 = Succ0Parallel1;
            this.curN = CurN;
            this.NinUpper = NInUpper;
            //if (k <= 0) this.k = 0; else this.k = k;
            this.HydroRData = new HydroResistanceData();
            this.HydroRData.IniData = new HydroResistanceIniData();
            this.HydroRData.CalcData = new HydroResistanceCalcdData();
            if (HydroIniDataExt != null)
            {
                this.HydroRData.IniData = (HydroResistanceIniData)HydroIniDataExt.Clone();
            }
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
        //
        public void SetIniData(HydroResistanceIniData HRIniData)
        {
            this.HydroRData = new HydroResistanceData();
            this.HydroRData.IniData = new HydroResistanceIniData();
            this.HydroRData.CalcData = new HydroResistanceCalcdData();
            if (HRIniData != null)
            {
                this.HydroRData.IniData=(HydroResistanceIniData)HRIniData.Clone();
            }
        }
        public HydroResistanceIniData GetHResIniData()
        {
            HydroResistanceIniData data = new HydroResistanceIniData();
            data=(HydroResistanceIniData)this.HydroRData.IniData.Clone();
            return data;
        }
        //
        public void SetElementsConnectionSucc() { this.Conn_Suc0Par1 = 0; }
        public void SetElementsConnectionPrl() { this.Conn_Suc0Par1 = 1; }
        public int GetConnectionType() { return Conn_Suc0Par1; }
        public bool GetIfConnectionTypeIsSucc() { return (Conn_Suc0Par1 == 0); }
        public bool GetIfConnectionTypeIsPrl() { return (Conn_Suc0Par1 == 1); }
        //
        public void SetNinUpper(int N) { this.NinUpper = N; }
        public int GetNinUpper() { return this.NinUpper; }
        //
        public void SetN(int N) { this.curN = N; }
        public int GetN() { return this.curN; }
        //
        public int GetQSubElts() { return this.QElements; }
        public bool GetIfIsSimple() { return (this.QElements==0); }
        //
        public void Set_k(double k) {
            //this.k = k;
            this.HydroRData.IniData.kG = k;
        }
        public double Get_k() {
            //return this.k;
            return this.HydroRData.IniData.kG;
        }
        //
        //
        public void SetElementsConnectionSucc_SubEltN(int SubEltN) {
            if(this.elems!=null){
                this.elems[SubEltN-1].SetElementsConnectionSucc();
            }
        }
        public void SetElementsConnectionPrl_SubEltN(int SubEltN) {
            if(this.elems!=null){
                this.elems[SubEltN-1].SetElementsConnectionPrl();
            }
        }
        public int GetConnectionType_SubEltN(int SubEltN) {
            int R=0;
            if(this.elems!=null){
                R=this.elems[SubEltN-1].GetConnectionType();
            }
            return R;
        }
        public bool GetIfConnectionTypeIsSucc_SubEltN(int SubEltN) {
            bool R=true;
            if(this.elems!=null){
                R= (this.elems[SubEltN - 1].GetIfConnectionTypeIsSucc());
            }
            return R;
        }
        public bool GetIfConnectionTypeIsPrl_SubEltN(int SubEltN) {
            bool R=true;
            if(this.elems!=null){
                R=this.elems[SubEltN - 1].GetIfConnectionTypeIsPrl();
            }
            return R;
        }
        //
        public void SetNinUpper_SubEltN(int NToSet, int SubEltN) {
            if(this.elems!=null){
                this.elems[SubEltN - 1].SetNinUpper(NToSet);
            }
        }
        public int GetNinUpper_SubEltN(int SubEltN) {
            int R=0;
            if(this.elems!=null){
                R=this.elems[SubEltN - 1].GetNinUpper();
            }
            return R;
        }
        //
        public void SetN_SubEltN(int NToSet, int SubEltN) {
            if(this.elems!=null){
                this.elems[SubEltN - 1].SetN(NToSet);
            }
        }
        public int GetN_SubEltN(int SubEltN) {
            int R=0;
            if(this.elems!=null){
                R=this.elems[SubEltN - 1].GetN();
            }
            return R;
        }
        //
        public int GetQSubElts_SubEltN(int SubEltN) {
            int R=0;
            if(this.elems!=null){
                R=this.elems[SubEltN - 1].GetQSubElts();
            }
            return R;
        }
        public bool GetIfIsSimple_SubEltN(int SubEltN) {
            bool R=true;
            if(this.elems!=null){
                R=this.elems[SubEltN - 1].GetIfIsSimple();
            }
            return R;
        }
        //
        public void Set_k_SubEltN(double k, int SubEltN) {
            if(this.elems!=null){
                this.elems[SubEltN-1].Set_k(k);
            }
        }
        public double Get_k_SubEltN(int SubEltN) {
            double R=0;
            if(this.elems!=null){
                R= this.elems[SubEltN-1].Get_k();
            }
            return R;
        }
        //
        //
        public HydroPipelineElement FindByN(int N)
        {
            HydroPipelineElement ptr = null;
            bool contin;
            int CurSN;
            if (this.GetN() == N)
            {
                ptr = this;
            }
            else
            {
                if (this.elems != null)
                {
                    CurSN = 0;
                    contin = true;
                    while(contin)
                    {
                        CurSN++;
                        ptr = this.elems[CurSN - 1].FindByN(N);
                        if (ptr != null){
                            contin = false;
                        }
                        if (CurSN == this.QElements)
                        {
                            contin = false;
                        }
                    }
                }
            }
            return ptr;
        }
        //
        //
        public void SetElementsConnectionSucc_MateOuterN(int mateOuterN) { 
            if(this.upper!=null && this.upper.GetIfIsSimple()==false){
                //this.upper.elems[mateOuterN-1].SetElementsConnectionSucc();
                this.upper.SetElementsConnectionSucc_SubEltN(mateOuterN);
            }
        }
        public void SetElementsConnectionPrl_MateOuterN(int mateOuterN) {
            if(this.upper!=null && this.upper.GetIfIsSimple()==false){
                //this.upper.elems[mateOuterN-1].SetElementsConnectionPrl();
                this.upper.SetElementsConnectionPrl_SubEltN(mateOuterN);
            }
        }
        public int GetConnectionType_MateOuterN(int mateOuterN) {
            int R=-1;
            if(this.upper!=null && this.upper.GetIfIsSimple()==false){
                //R=this.upper.elems[mateOuterN-1].GetConnectionType();
                R=this.upper.GetConnectionType_SubEltN(mateOuterN);
            }
            return R;
        }
        public bool GetIfConnectionTypeIsSucc_MateOuterN(int mateOuterN) {
            bool b=true;
            if(this.upper!=null && this.upper.GetIfIsSimple()==false){
                //b=this.upper.elems[mateOuterN - 1].GetIfConnectionTypeIsSucc();
                b=this.upper.GetIfConnectionTypeIsSucc_SubEltN(mateOuterN);
            }
            return b;
        }
        public bool GetIfConnectionTypeIsPrl_MateOuterN(int mateOuterN) {
            bool b=true;
            if(this.upper!=null && this.upper.GetIfIsSimple()==false){
                //this.upper.elems[mateOuterN - 1].GetIfConnectionTypeIsPrl();
                this.upper.GetIfConnectionTypeIsPrl_SubEltN(mateOuterN);
            }
            return b;
        }
        //
        public void SetNinUpper_MateOuterN(int NToSet, int mateOuterN) {
            if(this.upper!=null && this.upper.GetIfIsSimple()==false){
                //this.upper.elems[mateOuterN - 1].SetNinUpper(NToSet);
                //         SetNinUpper_SubEltN
                this.upper.SetNinUpper_SubEltN(NToSet, mateOuterN);
            }
        }
        public int GetNinUpper_MateOuterN(int mateOuterN) {
            int R=0;
            if(this.upper!=null && this.upper.GetIfIsSimple()==false){
                //this.upper.elems[mateOuterN - 1].GetNinUpper();
                this.upper.GetNinUpper_SubEltN(mateOuterN);
            }
            return R;
        }
        //
        public void SetN_MateOuterN(int NToSet, int mateOuterN) {
            if(this.upper!=null && this.upper.GetIfIsSimple()==false){
                //this.upper.elems[mateOuterN - 1].SetN(NToSet);
                this.upper.SetN_SubEltN(NToSet, mateOuterN);
            }
        }
        public int GetN_MateOuterN(int mateOuterN) {
            int R=0;
            if(this.upper!=null && this.upper.GetIfIsSimple()==false){
                //R=this.upper.elems[mateOuterN - 1].GetN();
                R=this.upper.GetN_SubEltN(mateOuterN);
            }
            return R;
        }
        //
        public int GetQSubElts_MateOuterN(int mateOuterN) {
            int R=0;
            if(this.upper!=null && this.upper.GetIfIsSimple()==false){
                //R=this.upper.elems[mateOuterN - 1].GetQSubElts();
                R=this.upper.GetQSubElts_SubEltN(mateOuterN);
            }
            return R;
        }
        public bool GetIfIsSimple_MateOuterN(int mateOuterN) {
            bool b=true;
            if(this.upper!=null && this.upper.GetIfIsSimple()==false){
                //b=this.upper.elems[mateOuterN - 1].GetIfIsSimple();
                b=this.upper.GetIfIsSimple_SubEltN(mateOuterN);
            }
            return  b;
        }
        //
        public void Set_k_MateOuterN(double k, int mateOuterN) {
            if(this.upper!=null && this.upper.GetIfIsSimple()==false){
                //this.upper.elems[mateOuterN-1].Set_k(k);
                this.upper.elems[mateOuterN-1].Set_k_SubEltN(k, mateOuterN);
            }
        }
        public double Get_k_MateOuterN(int mateOuterN) {
            double k=0;
            if(this.upper!=null && this.upper.GetIfIsSimple()==false){
                //k=this.upper.elems[mateOuterN-1].Get_k();
                k=this.upper.elems[mateOuterN-1].Get_k_SubEltN(mateOuterN);
            }
            return k;
        }
        //
        //
        public void SetElementsConnectionSucc_upper() { this.upper.SetElementsConnectionSucc(); }
        public void SetElementsConnectionPrl_upper() { this.upper.SetElementsConnectionPrl(); }
        public int GetConnectionType_upper() { return this.upper.GetConnectionType(); }
        public bool GetIfConnectionTypeIsSucc_upper() { return (this.upper.GetIfConnectionTypeIsSucc()); }
        public bool GetIfConnectionTypeIsPrl_SubEltNint() { return this.upper.GetIfConnectionTypeIsPrl(); }
        //
        public void SetNinUpper_upper(int NToSet) { this.upper.SetNinUpper(NToSet); }
        public int GetNinUppe_upper() { return this.upper.GetNinUpper(); }
        //
        public void SetN_upper(int NToSet) { this.upper.SetN(NToSet); }
        public int GetN_upper() { return this.upper.GetN(); }
        //
        public int GetQSubElts_upper() { return this.upper.GetQSubElts(); }
        public bool GetIfIsSimple_upper() { return this.upper.GetIfIsSimple(); }
        //
        public void Set_k_upper(double k) { this.upper.Set_k(k); }
        public double Get_k_upper() { return this.upper.Get_k(); }
        //
        //
        public void AddInner(HydroPipelineElement elem, TValsShowHide vsh=null)
        {
            MyLib.writeln(vsh, "AddInner starts working");
            MyLib.writeln(vsh, "Add to: " + this.ToString());
            //
            HydroResistanceIniData HRIniData = new HydroResistanceIniData();
            //
            HydroPipelineElement NewElem = new HydroPipelineElement(HRIniData);
            if (elem != null)
            {
                NewElem = (HydroPipelineElement)elem.Clone();
                NewElem.NinUpper = this.QElements + 1;
                NewElem.upper = this;
            }
            //
            MyLib.writeln(vsh, "Add what: " + NewElem.ToString());
            MyLib.writeln(vsh, "R before Adding:");
            this.Show(vsh);
            //
            MyLib.AddToVector(ref this.elems, ref this.QElements, NewElem);
            //
            this.curSubElementN = this.QElements;
            //
            MyLib.writeln(vsh, "R after Adding:");
            this.Show(vsh);
            MyLib.writeln(vsh, "AddInner finishes working");
        }
        public void DelInner(int N = 0, TValsShowHide vsh = null)
        {
            int Q = this.QElements;
            int QI;
            if (N >= 1 && N <= this.QElements)
            {
                MyLib.writeln(vsh, "Deleting:" + this.elems[N - 1].ToString());
                if (Q > 1)
                {
                    HydroPipelineElement[] elems = new HydroPipelineElement[this.QElements - 1];
                    for (int i = 1; i <= N - 1; i++)
                    {
                        elems[i - 1] = (HydroPipelineElement)this.elems[i - 1].Clone(); ;
                    }
                    //for (int i = this.QElements; i >= N; i--)
                    for (int i = N + 1; i <= this.QElements; i++)
                    {
                        elems[i - 1 - 1] = (HydroPipelineElement)this.elems[i - 1].Clone(); ;
                        elems[i - 1 - 1].SetNinUpper(i - 1);
                    }
                    //
                    QI = this.elems[N - 1].GetQSubElts();
                    //for (int i = 1; i <= QI; i++)
                    for (int i = QI; i >= 1; i--)
                    {
                        MyLib.writeln(vsh, "Deleting:" + this.elems[N - 1].elems[i - 1].ToString());
                        this.elems[N - 1].DelInner(i);
                    }
                    //MyLib.writeln(vsh, elems[N - 1].ToString() + " - Deleted");
                    //
                    this.elems = elems;
                    //cur = this.elems[N - 1];
                    //
                    this.curSubElementN = N;
                }
                else
                {
                    this.elems = null;
                    this.curSubElementN = N;
                }
                this.QElements--;
                //
            }
        }//DelInner
        public void InsInner(HydroPipelineElement elem, int N, TValsShowHide vsh=null)
        {
            MyLib.writeln(vsh, "InsInner starts working - for: "+this.ToString());
            MyLib.writeln(vsh, "Ins into: "+this.ToString());
            if (N >= 1 && N <= this.QElements)
            {
                MyLib.writeln(vsh, "Elems before inserting:");
                for (int i = 1; i <= this.QElements; i++)
                {
                    MyLib.writeln(vsh, this.elems[i-1].ToString());
                }
                if (N == 1)
                {
                    MyLib.writeln(vsh, "It'll be first element");
                }
                else
                {
                    MyLib.writeln(vsh, "Ins after N "+(N-1).ToString()+": "+ this.elems[N-1-1].ToString());
                }
                MyLib.writeln(vsh, "Ins instead(before) N " + N.ToString() + ": " + this.elems[N - 1].ToString());
                HydroPipelineElement[] elems = new HydroPipelineElement[this.QElements + 1];
                for (int i = 1; i <= N - 1; i++)
                {
                    elems[i - 1] = (HydroPipelineElement)this.elems[i - 1].Clone();
                }
                //for (int i = this.QElements; i >= N; i--)
                for (int i = N; i <= this.QElements; i++)
                {
                    elems[i + 1 - 1] = (HydroPipelineElement)this.elems[i - 1].Clone();
                    elems[i + 1 - 1].SetNinUpper(i + 1);
                }
                elems[N - 1] = (HydroPipelineElement)elem.Clone();
                elems[N - 1].upper = this;
                elems[N - 1].SetNinUpper(N);
                this.elems = elems;
                MyLib.writeln(vsh, "Elem inserted in all elts: " + this.elems[N - 1].ToString());
                //cur = this.elems[N - 1];
                //
                this.QElements = this.QElements+1; 
                this.curSubElementN = N;
                //
                MyLib.writeln(vsh, "Elems after inserting:");
                for (int i = 1; i <= this.QElements; i++)
                {
                    MyLib.writeln(vsh, this.elems[i - 1].ToString());
                }
                //
                MyLib.writeln(vsh, "InsInner finishes working - for: " + this.ToString());
            }
        }
        //
        public void SwapInner(int N1, int N2)
        {
            HydroResistanceData FullData;
            HydroResistanceIniData IniData1, IniData2;
            if (this.elems != null && this.QElements > 0 && N1 >= 1 && N2 >= 1 && N1 <= this.QElements && N2 <= this.QElements && N1 != N2)
            {
                IniData2 = this.elems[N1 - 1].GetHResIniData();
                IniData1 = this.elems[N2 - 1].GetHResIniData();
                MyLib.SwapInVector(ref this.elems, this.QElements, N1, N2);
                this.elems[N1 - 1].SetNinUpper(N1);
                this.elems[N1 - 1].SetIniData(IniData1);
                this.elems[N2-1].SetNinUpper(N2);
                this.elems[N2 - 1].SetIniData(IniData2);
            }
        }
        //
        public HydroPipelineElement LinkToTopR(TValsShowHide vsh=null){
            HydroPipelineElement ptr=null;
            MyLib.writeln(vsh,"LinkToTopR starts working");
            ptr=this.upper;
            MyLib.writeln(vsh,"At Start: self="+this.ToString());
            if(ptr!=null){
                MyLib.writeln(vsh, "At Start:  upper= R" + this.upper.curN.ToString());
                while(ptr.upper!=null){
                    ptr=ptr.upper;
                    MyLib.writeln(vsh,"now ptr=R"+ptr.curN.ToString());
                }
            }else{
                ptr=this;
                MyLib.writeln(vsh,"This is top: "+this.ToString());
            }
            MyLib.writeln(vsh, "LinkToTopR finishes working. ptr=R"+ptr.curN.ToString());
            return ptr;
        }

        public void CurPresentNsList(ref int [] Ns, TValsShowHide vsh=null){
            int Q=0, count;
            if(Ns!=null){
                Q=Ns.Length;
            }
            MyLib.AddToVector(ref Ns, ref Q, this.curN); 
            //count=0;
            if (this.elems!=null && this.QElements>0){
                for (int i = 1; i <= this.QElements; i++)
                {
                    this.elems[i - 1].CurPresentNsList(ref Ns);
                }
            }
        }

        public int [] FullPresentNsList( TValsShowHide vsh=null){
            int []Ns=null;
            HydroPipelineElement ptr=null;
            ptr = this.LinkToTopR(vsh);
            MyLib.writeln(vsh,"FullPresentNsList starts working. ptr=R"+ptr.curN.ToString());
            ptr.CurPresentNsList(ref Ns, vsh);
            MyLib.writeln(vsh,"FullPresentNsList finishes working. ptr=R"+ptr.curN.ToString());
            return Ns;
        }

        public int FirstAbsentN(TValsShowHide vsh=null){
            //if vsh==1:
            //    print("FirsrAbsentNt starts working. R"+str(ptr.curN))
            int[] Ns = null;// this.FullPresentNsList(vsh);
            //vikt! below s' gut examples for test et debug; in py Z s' verf'd, amda Z s'peresent ut be verf'd
            //Ns=[1, 2, 3, 4, 5]
            //Ns=[2, 3, 4, 5, 6]
            //Ns=[1, 3, 4, 5, 6]
            //Ns=[1, 2, 4, 5, 6]
            //Ns=[1, 2, 3, 4, 7]
            //Ns=[]#ja, N=1
            MyLib.writeln(vsh, "FirstAbsentN starts working");
            MyLib.writeln(vsh, "Call from R: "+this.ToString());
            Ns = this.FullPresentNsList(vsh);
            MyLib.writeln(vsh, "Present Ns: " + MyLib.ArraySimpleString(Ns, ";"));
            //MyLib.writeln(vsh, "Checking:");
            int Q=Ns.Length;
            int contin=1;
            int count=0;
            int N=0;
            int cur;
            int countPrev;
            while(contin==1){
                N=N+1;
                if (N == Q + 1)
                {
                    contin = 0;
                }
                count=0;
                countPrev = 0;
                for(int i=1; i<=Q; i++){
                    cur=Ns[i-1];
                    countPrev = count;
                    if(N==cur){
                        count=count+1;
                    }
                }
                if(count==0){
                    contin=0;
                }
                if (countPrev == count)
                {
                    MyLib.writeln(vsh, N.ToString() + ": already present");
                }
                else
                {
                    MyLib.writeln(vsh, N.ToString() + ": found!");
                }
            }
            return N; 
        }
        //
        public void AddSucSmart(HydroPipelineElement ElementExt, int smartAdd = 0, /*HydroResistanceIniData IniDataNew double k_new = 0,*/ TValsShowHide vsh = null)
        {
            MyLib.writeln(vsh,"AddSucSmart starts working");
            int QUpperSubElts;
            int newN=this.FirstAbsentN(vsh), newNForNew;//;#ne sees tic exnot char!
            HydroPipelineElement ElementToAdd=(HydroPipelineElement)ElementExt.Clone(), ElementInstead;
            MyLib.writeln(vsh,"Adding to: "+this.ToString());
            MyLib.writeln(vsh,"Adding what: "+ElementToAdd.ToString());
            MyLib.writeln(vsh,"new N = "+newN.ToString());
            if(this.upper==null || ( this.upper!=null && this.upper.Conn_Suc0Par1==1)){
                if(vsh!=null){
                    if(this.upper==null){
                        MyLib.writeln(vsh,"No upper Rs. This will be first added, param - second");
                    }
                    if (this.upper!=null && this.upper.Conn_Suc0Par1==1){
                        MyLib.writeln(vsh,"Trying conn -- to || con'd R");
                    }
                    MyLib.writeln(vsh,"R, to which we try to conn, will be container of self's copy and connected R");
                }
                //PrimitivePipelineElement(int k = 0, int Succ0Parallel1 = 0, PrimitivePipelineElement[] elems = null, PrimitivePipelineElement upper = null, int QElements = 0, int CurN = 0, int NInUpper = 0, TValsShowHide vsh = null)
                ElementInstead=new HydroPipelineElement(this.HydroRData.IniData, this.Conn_Suc0Par1,this.elems, this,  this.QElements, newN,  this.NinUpper, vsh);
                MyLib.writeln(vsh,"Copy: "+ElementInstead.ToString());
                //
                //this.k=k_new;
                //
                this.Conn_Suc0Par1=0;
                MyLib.writeln(vsh,"Self ef adding: "+this.ToString());
                MyLib.writeln(vsh,"Adding copy:");
                this.AddInner(ElementInstead);
                MyLib.writeln(vsh,"Self ef adding copy:");
                this.Show(vsh);
                //
                if (ElementToAdd.GetN() == 0)
                {
                    newNForNew = this.FirstAbsentN(null);//vsh
                    MyLib.writeln(vsh, "N for new: " + newNForNew.ToString());
                    ElementToAdd.SetN(newNForNew);
                }
                //
                MyLib.writeln(vsh,"Adding R to Add:");
                this.AddInner(ElementToAdd);
                MyLib.writeln(vsh,"Finally: ");
                this.Show(vsh);
            }
            else
            { 
                //this.upper!=null && this.upper.Conn_Suc0Par1==0
                QUpperSubElts=this.upper.GetQSubElts();
                //
                if (ElementToAdd.GetN() == 0)
                {
                    newNForNew = this.FirstAbsentN(null);//vsh
                    MyLib.writeln(vsh, "N for new: " + newNForNew.ToString());
                    ElementToAdd.SetN(newNForNew);
                }
                //
                if(this.NinUpper==QUpperSubElts){
                    MyLib.writeln(vsh,"This is sub-element, one ("+this.NinUpper.ToString()+") of "+QUpperSubElts.ToString()+", united succ, last, will be added");
                    this.upper.AddInner(ElementToAdd);
                }else{
                    MyLib.writeln(vsh,"This is sub-element, one ("+this.NinUpper.ToString()+") of "+QUpperSubElts.ToString()+", united succ,  not last, will be ins'd");
                    //this.upper.InsInner(ElementToAdd, this.NinUpper+1, vsh);
                    this.upper.InsInner(ElementToAdd, this.NinUpper, vsh);
                }
            }
             MyLib.writeln(vsh,"Finally: ");
             this.Show(vsh);
             MyLib.writeln(vsh,"AddSucSmart finishes working");
        }
        public void AddParSmart(HydroPipelineElement ElementExt, int smartAdd=0, double k_new=0, TValsShowHide vsh=null){
            int QUpperSubElts;
            int newN = this.FirstAbsentN(vsh), newNForNew;//;#ne sees tic exnot char!
            MyLib.writeln(vsh,"AddParSmart starts working");
            HydroPipelineElement ElementInstead, ElementToAdd=(HydroPipelineElement)ElementExt.Clone();
            MyLib.writeln(vsh,"Adding to: "+this.ToString());
            MyLib.writeln(vsh,"Adding what: "+ElementToAdd.ToString());
            MyLib.writeln(vsh,"new N = "+newN.ToString());
            if (this.upper==null || ( this.upper!=null && this.upper.Conn_Suc0Par1==0)){
                if(vsh!=null){
                    if(this.upper==null){
                        MyLib.writeln(vsh,"No upper Rs. This will be first added, param - second");
                    }
                    if(this.upper!=null && this.upper.Conn_Suc0Par1==0){
                        MyLib.writeln(vsh,"Trying conn || to -- con'd R");
                    }
                    MyLib.writeln(vsh,"R, to which we try to conn, will be container of self's copy and connected R");
                }
                //
                //PrimitivePipelineElement(int k = 0, int Succ0Parallel1 = 0, PrimitivePipelineElement[] elems = null, PrimitivePipelineElement upper = null, int QElements = 0, int CurN = 0, int NInUpper = 0, TValsShowHide vsh = null)
                ElementInstead = new HydroPipelineElement(/*this.k*/this.GetHResIniData(), this.Conn_Suc0Par1, this.elems, this, this.QElements, newN, this.NinUpper, vsh);
                MyLib.writeln(vsh,"Copy: "+ElementInstead.ToString());
                //
                //this.k=k_new;
                //
                this.Conn_Suc0Par1=1;
                MyLib.writeln(vsh,"Self ef adding: "+this.ToString());
                MyLib.writeln(vsh,"Adding copy:");
                this.AddInner(ElementInstead);
                MyLib.writeln(vsh,"Self ef adding copy:");
                this.Show(vsh);
                //
                if (ElementToAdd.GetN() == 0)
                {
                    newNForNew = this.FirstAbsentN(null);//vsh
                    MyLib.writeln(vsh, "N for new: " + newNForNew.ToString());
                    ElementToAdd.SetN(newNForNew);
                }
                //
                MyLib.writeln(vsh,"Adding R to Add:");
                this.AddInner(ElementToAdd);
                MyLib.writeln(vsh,"Finally: ");
                this.Show(vsh);
            }
            else
            { 
                //this.upper!=null && this.upper.Conn_Suc0Par1==1
                QUpperSubElts=this.upper.GetQSubElts();
                //
                if (ElementToAdd.GetN() == 0)
                {
                    newNForNew = this.FirstAbsentN(null);//vsh
                    MyLib.writeln(vsh, "N for new: " + newNForNew.ToString());
                    ElementToAdd.SetN(newNForNew);
                }
                //
                if(this.NinUpper==QUpperSubElts){
                    MyLib.writeln(vsh,"This is sub-element, one ("+this.NinUpper.ToString()+") of "+QUpperSubElts.ToString()+", inited par, last, will be added");
                    this.upper.AddInner(ElementToAdd);
                }else{
                    MyLib.writeln(vsh,"This is sub-element, one ("+this.NinUpper.ToString()+") of "+QUpperSubElts.ToString()+", inited par,  not last, will be ins'd");
                    this.upper.InsInner(ElementToAdd, this.NinUpper+1);
                    //
                    MyLib.writeln(vsh,"Finally: ");
                    this.Show(vsh);
                }
            }
            MyLib.writeln(vsh,"AddParSmart finishes working") ;
        }
        //
        //public void SetFirst()
        //{
        //    //if (this.elems != null) this.cur = this.elems[1 - 1];
        //    curSubElementN = 1;
        //}
        //public void SetLast()
        //{
        //    //if (this.elems != null)this.cur = this.elems[this.QElements - 1];
        //    curSubElementN = this.QElements;
        //}
        //public void SetNext()
        //{
        //    if (this.elems != null && curN < this.QElements) curSubElementN += 1;
        //}
        //public void SetNInUpper(int N)
        //{
        //    if (this.elems != null && N >= 1 && N <= this.QElements) curSubElementN = N;
        //}
        //public void SetPrevious()
        //{
        //    if (this.elems != null && curN > 1) curSubElementN -= 1;
        //}
        public HydroPipelineElement GetCurrentSubElement_AsCopy()
        {
            HydroPipelineElement R = null;
            if (this.elems != null) R = (HydroPipelineElement)this.elems[curSubElementN - 1].Clone();
            return R;
        }
        public HydroPipelineElement GetCurrentSubElement_AsLink()
        {
            HydroPipelineElement R = null;
            if (this.elems != null) R = this.elems[curSubElementN - 1];
            return R;
        }
        public HydroPipelineElement GetCurrentSubElement()
        {
            //PrimitiveElement R = null;
            return this.GetCurrentSubElement_AsCopy();
        }
        public HydroPipelineElement GetUpper() { return this.upper; }
        public void SetUpper(HydroPipelineElement elem) { this.upper = elem; }
        private delegate double ResistanceByType(HydroPipelineElement[] elems);
        private double ResistanceSucc(HydroPipelineElement[] elems)
        {
            double S = 0;
            for (int i = 1; i <= /*this.QElements*/elems.Length; i++)
            {
                S = S + /*this.*/elems[i - 1].Resistance();
            }
            return S;
        }
        private double ResistancePrl(HydroPipelineElement[] elems)
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
            double R = this.Get_k(), S = 0;
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
            double S = 0;
            if (this.QElements > 0)
            {
                if (this.Conn_Suc0Par1 == 0)
                {
                    dlgt = this.ResistanceSucc;
                }
                else
                {
                    dlgt = this.ResistancePrl;
                }
                S = dlgt(this.elems);
            }
            else
            {
                S = this.Get_k();
            }
            return S;
        }
        public override string ToString()
        {
            string s = "";
            //int x = this.vis_x(null), y = this.vis_y(null);
            //s = "R" + this.CurN.ToString() + " k=" + this.k.ToString() + " SubElts: Q=" + this.QElements.ToString() + " Order --0, ||1: " + this.Succ0Parallel1.ToString();
            if (this.upper == null)
            {
                //s = "R" + this.CurN.ToString() + " k=" + this.k.ToString() + " SubElts: --"+this.QElements.ToString()+" ;
                if (this.Conn_Suc0Par1 == 0)
                {
                    s = "R" + this.curN.ToString() + " k=" + (this.Get_k()).ToString() + " SubElts: [--] " + this.QElements.ToString() + " (Ext) ";
                }
                else if (this.Conn_Suc0Par1 == 1)
                {
                    s = "R" + this.curN.ToString() + " k=" + (this.Get_k()).ToString() + " SubElts: [||] " + this.QElements.ToString() + " (Ext) ";
                }
            }
            else
            {
                if (this.Conn_Suc0Par1 == 0)
                {
                    s = "R" + this.curN.ToString() + " k=" + (this.Get_k()).ToString() + " SubElts: [--] " + this.QElements.ToString() + " Of: R" + this.upper.curN.ToString() + "[" + this.NinUpper.ToString() + "]";
                }
                else if (this.Conn_Suc0Par1 == 1)
                {
                    s = "R" + this.curN.ToString() + " k=" + (this.Get_k()).ToString() + " SubElts: [||] " + this.QElements.ToString() + " Of: R" + this.upper.curN.ToString() + "[" + this.NinUpper.ToString() + "]";
                }
            }
            //return base.ToString();
            //
            //s = s + " Coords: (";
            //s = s + (this.vis_x(null)).ToString() + "; "+(this.vis_y(null)).ToString() + ") ";
            //s = s + " Coords: (" + x.ToString() + "; " + y.ToString() + ") ";
            //
            return s;
        }
        public void Show(TValsShowHide vsh)
        {
            MyLib.writeln(vsh, this.ToString() + " Coords=(" + (this.vis_x(null)).ToString() + "; " + (this.vis_y(null)).ToString() + "; ");
            for (int i = 1; i <= this.QElements; i++)
            {
                //MyLib.writeln(vsh, i.ToString()+") "+this.elems[i-1].ToString());
                this.elems[i - 1].Show(vsh);
            }
        }
        public object Clone()
        {
            HydroPipelineElement data = new HydroPipelineElement(this.GetHResIniData());
            data.Conn_Suc0Par1 = this.Conn_Suc0Par1;
            data.QElements = this.QElements;
            data.HydroRData = (HydroResistanceData)this.HydroRData.Clone();
            //
            data.curN = this.curN;
            data.NinUpper = this.NinUpper;
            data.upper = this.upper;
            //
            data.elems = new HydroPipelineElement[this.QElements];
            for (int i = 1; i <= this.QElements; i++)
            {
                data.elems[i - 1] = (HydroPipelineElement)this.elems[i - 1].Clone();
            }
            return data;
        }
        public TTable Main_GetAsTable()
        {
            TTable tbl = null;
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
            Content[1 - 1] = new DataCellRow(new DataCell[] { new DataCell(this.Get_k()), new DataCell(this.QElements), new DataCell(sa, 2) }, 3);
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
            string[] sa = /*new string[]*/ { "--", "//" };
            if (this.Conn_Suc0Par1 == 0) TblHdr = new DataCell("HydroResistance - " + this.QElements.ToString() + " Elements, Connection: " + sa[1 - 1]);
            else TblHdr = new DataCell("HydroResistance - " + this.QElements.ToString() + " Elements, Connection: " + sa[2 - 1]);
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
                    Content[i - 1] = new DataCellRow(new DataCell[] { new DataCell(elems[i - 1].Get_k()), new DataCell(elems[i - 1].QElements), new DataCell(sa, 2) }, 3);
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
            //this.k = tbl.GetDoubleVal(3, 1);
            this.QElements = tbl.GetIntVal(1, 1);
            this.Conn_Suc0Par1 = 1 + tbl.GetActiveN(2, 1);
        }
        public void SetElementsFromTable(TTable tbl)
        {
            int Q = tbl.GetQLines();
            this.elems = new HydroPipelineElement[Q];
        }
        public double CoutKSum(TValsShowHide vsh = null)
        {
            double R = 0, c = 0, s;
            //if(this.QElements==0)R=this.k;
            // if (vsh != null) MyLib.writeln(vsh, "Resistance: QElements=" + this.QElements.ToString() + ", k=" + this.k.ToString()+" Connection type: "+this.Succ0Parallel1.ToString());
            //MyLib.writeln(vsh, "Resistance: R"+CurN.ToString()+" QElements=" + this.QElements.ToString() + ", k=" + this.k.ToString() + " Connection type: " + this.Succ0Parallel1.ToString());
            MyLib.writeln(vsh, this.ToString());
            s = 0;
            R = this.Get_k();
            if (vsh != null) MyLib.writeln(vsh, "k=" + (this.Get_k()).ToString() + ", R=" + R.ToString());
            for (int i = 1; i <= this.QElements; i++)
            {
                //if (vsh != null) MyLib.writeln(vsh, "Sub-Element N " + i.ToString());
                MyLib.writeln(vsh, "Sub-Element N " + i.ToString() + " R" + this.elems[i - 1].curN.ToString());
                MyLib.writeln(vsh, "Elt[" + i.ToString() + "]=" + this.elems[i - 1].ToString());
                c = this.elems[i - 1].CoutKSum(vsh);
                if (this.Conn_Suc0Par1 == 0)
                {
                    //s = s + c;
                    s = s + c * c;
                }
                else
                {
                    if (c != 0) s += 1 / c;
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
                if (s != 0) R = R + 1 / s;//R+ = 1 / s;
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
            int L = 1, Lmax = 0, Lcur = 0;//simple or left wall
            MyLib.writeln(vsh, " L=1=" + L.ToString() + " If it's simple, so it is, if it's complex - left wall");
            if (this.upper == null)
            {
                //L = L + 1;//L2=
                //MyLib.writeln(vsh, "Ext: now L=2=" + L.ToString() + " it's most external - left connector + left wall");
                MyLib.writeln(vsh, "Ext: now L=1");
            }
            if (this.QElements > 0)
            {
                if (this.Conn_Suc0Par1 == 0)
                {
                    MyLib.writeln(vsh, "It's complex. First-level sub-elements s'united in succession");
                    for (int i = 1; i <= this.QElements - 1; i++)
                    {
                        Lcur = this.elems[i - 1].vis_L(vsh);
                        L = L + Lcur;
                        L = L + 1;//connector
                        MyLib.writeln(vsh, "( returning to R" + this.curN.ToString() + ")");
                        MyLib.writeln(vsh, i.ToString() + ") Lcur=" + Lcur.ToString() + "+1 connector. now L=" + L.ToString());
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
                        MyLib.writeln(vsh, "( returning to R" + this.curN.ToString() + ")");
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
            //if (this.upper == null)
            //{
            //    L = L + 1;//L2=
            //    MyLib.writeln(vsh, "Ext: L=L+1= " + L.ToString() + " - right connector + right wall");
            //}
            MyLib.writeln(vsh, "vis_L finishes working. R" + this.curN.ToString() + " L=" + L.ToString());
            return L;
        }
        public int vis_L_WithConnectors(TValsShowHide vsh)
        {
            MyLib.writeln(vsh, "vis_L starts working. R: " + this.ToString());
            int L = 1, Lmax = 0, Lcur = 0;//simple or left wall
            MyLib.writeln(vsh, " L=1=" + L.ToString() + " If it's simple, so it is, if it's complex - left wall");
            if (this.upper == null)
            {
                L = L + 1;//L2=
                MyLib.writeln(vsh, "Ext: now L=2=" + L.ToString() + " it's most external - left connector + left wall");
            }
            if (this.QElements > 0)
            {
                if (this.Conn_Suc0Par1 == 0)
                {
                    MyLib.writeln(vsh, "It's complex. First-level sub-elements s'united in succession");
                    for (int i = 1; i <= this.QElements - 1; i++)
                    {
                        Lcur = this.elems[i - 1].vis_L(vsh);
                        L = L + Lcur;
                        L = L + 1;//connector
                        MyLib.writeln(vsh, "( returning to R" + this.curN.ToString() + ")");
                        MyLib.writeln(vsh, i.ToString() + ") Lcur=" + Lcur.ToString() + "+1 connector. now L=" + L.ToString());
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
                        MyLib.writeln(vsh, "( returning to R" + this.curN.ToString() + ")");
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
            MyLib.writeln(vsh, "vis_L finishes working. R" + this.curN.ToString() + " L=" + L.ToString());
            return L;
        }
        public int vis_yUpper(TValsShowHide vsh)
        {
            int yUpper = 0, yUpperMax, yUpperCur;
            MyLib.writeln(vsh, "vis_yUpper starts working. " + this.ToString() + " yUpper=" + yUpper.ToString());
            if (this.elems != null && this.QElements > 0)
            {
                yUpper = yUpper + 1;
                MyLib.writeln(vsh, "complex: 1 upper wall. yUpper=" + yUpper.ToString());
                if (this.Conn_Suc0Par1 == 0)
                {
                    MyLib.writeln(vsh, "[--] finding max");
                    yUpperMax = 0;
                    for (int i = 1; i <= this.QElements; i++)
                    {
                        yUpperCur = this.elems[i - 1].vis_yUpper(vsh);
                        if (i == 1 || (i > 1 && yUpperMax < yUpperCur))
                        {
                            yUpperMax = yUpperCur;
                        }
                        MyLib.writeln(vsh, "-element" + i.ToString() + " R" + (this.elems[i - 1].curN).ToString() + ": yUpperCur=" + yUpper.ToString() + " yUpperMax=" + yUpperMax.ToString());
                    }
                    yUpper = yUpper + yUpperMax;
                    MyLib.writeln(vsh, "yUpper = yUpper+ yUpperMax: =" + yUpper.ToString() + " (yUpperMax = " + yUpper.ToString());
                }
                else
                {
                    MyLib.writeln(vsh, "[||] yUpper = first");
                    yUpperCur = this.elems[1 - 1].vis_yUpper(vsh);
                    yUpper = yUpper + yUpperCur;
                    MyLib.writeln(vsh, "Return to prev. yUpper=yUpperCur+1=" + yUpperCur.ToString());
                }
            }
            else
            {
                MyLib.writeln(vsh, "simple - nil to add");
                MyLib.writeln(vsh, "vis_yUpper finishes working. " + this.ToString() + " yUpper=" + yUpper.ToString());
            }
            return yUpper;
        }
        public int vis_yLower(TValsShowHide vsh)
        {
            int yLower = 0, yLowerCur, yUpperCur, yLowerMax;
            MyLib.writeln(vsh, "vis_yLower starts working. " + this.ToString() + " yLower=" + yLower.ToString());
            if (this.elems != null && this.QElements > 0)
            {
                if (this.Conn_Suc0Par1 == 0)
                {
                    MyLib.writeln(vsh, "[--] finding max");
                    yLowerMax = 0;
                    for (int i = 1; i <= this.QElements; i++)
                    {
                        yLowerCur = this.elems[i - 1].vis_yLower(vsh);
                        if (i == 1 || (i > 1 && yLowerMax < yLowerCur))
                        {
                            yLowerMax = yLowerCur;
                        }
                        MyLib.writeln(vsh, "-element" + i.ToString() + " R" + (this.elems[i - 1].curN).ToString() + ": yLowerCur=" + (yLowerCur).ToString() + " yLowerMax=" + (yLowerMax).ToString());
                    }
                    yLower = yLower + yLowerMax;
                    MyLib.writeln(vsh, "yLower = yLower+ yLowerMax: =" + yLower.ToString() + " (yLowerMax = " + yLowerMax.ToString() + ")");
                }
                else//if (this.Conn_Suc0Par1 == 1)
                {
                    yLowerCur =  this.elems[1 - 1].vis_yLower(vsh);
                    yLower = yLower + yLowerCur;
                    MyLib.writeln(vsh, "yLower = yLower+ yLowerCur[1]: =" + yLower.ToString() + " (yLowerCur[1] = " + (yLowerCur).ToString() + ")");
                    for (int i = 2; i <= this.QElements; i++)
                    {
                        yUpperCur = this.elems[i - 1].vis_yLower(vsh);//yUpperCur = this.elems[i - 1].vis_yLower(vsh);
                        yLowerCur = this.elems[i - 1].vis_yLower(vsh);
                        yLower = yLower + yUpperCur + yLowerCur + 2;
                        MyLib.writeln(vsh, "yLower = yLower+ yUpperCur+ yLowerCur+2: =" + yLower.ToString() + " (yUpperCur = " + (yUpperCur).ToString() + " yLowerCur = " + (yLowerCur).ToString() + "):2=1ipse+1space");
                    }
                }
                yLower = yLower + 1;
                MyLib.writeln(vsh, " yLower=yLower+1wall=" + yLower.ToString());
                MyLib.writeln(vsh, "Return to prev. yLower=" + yLower.ToString());
            }
            else
            {
                MyLib.writeln(vsh, "simple - nil to add");
            }
            MyLib.writeln(vsh, "vis_yLower finishes working. " + this.ToString() + " yLower=" + yLower.ToString());
            return yLower;
        }
        public int vis_H(TValsShowHide vsh)
        {
            return this.vis_yUpper(vsh) + 1+this.vis_yLower(vsh);
        }
        public int vis_x(TValsShowHide vsh)
        {
            MyLib.writeln(vsh, "vis_x starts working. " + this.ToString());
            int x = 2, xUpper, LCur;
            if (this.upper == null)
            {
                MyLib.writeln(vsh, "Ext.: nil to add. x=" + x.ToString());
                //}else if (this.upper is int){
                //    MyLib.writeln(vsh,"Error upper of: "+this.ToString());
            }
            else if (this.upper != null)
            {
                xUpper = this.upper.vis_x(vsh);
                x = xUpper;
                MyLib.writeln(vsh, "Part of: " + this.upper.ToString() + " xUpper=" + xUpper.ToString() + " = x =" + x.ToString());
                if (this.upper.Conn_Suc0Par1 == 0)
                {
                    x = x + 1;
                    MyLib.writeln(vsh, "[--] x=x+1: left wall x =" + x.ToString());
                    LCur = 0;
                    if (this.NinUpper > 1)
                    {
                        for (int i = 1; i <= this.NinUpper - 1; i++)
                        {
                            LCur = this.upper.elems[i - 1].vis_L(vsh);
                            x = x + LCur;
                            x = x + 1;
                            MyLib.writeln(vsh, "Elt" + i.ToString() + " R" + this.upper.elems[i - 1].curN.ToString() + " +1 connector=" + LCur.ToString() + " cur x=" + x.ToString());
                        }
                    }
                    MyLib.writeln(vsh, "x= " + x.ToString());
                }
                else
                {
                    x = xUpper + 2;
                    MyLib.writeln(vsh, " || part of " + this.upper.ToString() + "x=xUpper+2 (wall and connector)=" + x.ToString() + " (xUpper=" + xUpper.ToString() + ")");
                }
            }
            MyLib.writeln(vsh, "vis_x finishes working. " + this.ToString() + " x=" + x.ToString());
            return x;
        }
        public int vis_y(TValsShowHide vsh)
        {
            int y = 0, yMyUpper, yOfUpper, yLower1, yUpperCur, yLowerCur;
            MyLib.writeln(vsh, "vis_y starts working. " + this.ToString());
            if (this.upper == null)
            {
                yMyUpper = this.vis_yUpper(vsh);
                y = yMyUpper + 1;
                if (vsh != null)
                {
                    if (this.upper == null)
                    {
                        MyLib.writeln(vsh, "Ext. y=yUpper+1=" + yMyUpper.ToString() + "+1=" + y.ToString());
                    }
                }
            }
            else if (this.upper != null)
            {
                yOfUpper = this.upper.vis_y(vsh);
                //yUpper1=this.upper.elems[1-1].vis_yUpper(vsh);
                if (this.upper.Conn_Suc0Par1 == 1)
                {
                    //if (this.NinUpper >= 1)
                    //{
                    //    y = yUpper;
                    //    MyLib.writeln(vsh, "Ce part of " + this.upper.ToString() + " [" + this.NinUpper.ToString() + "]>=1 => y=y(upper)=" + yUpper.ToString() + "=" + y.ToString());
                    //}
                    //if (this.NinUpper >= 2)
                    //{
                    //    yLower1 = this.upper.elems[1 - 1].vis_yLower(vsh);
                    //    y = y + yLower1 + 1;
                    //    MyLib.writeln(vsh, "Ce part of " + this.upper.ToString() + " [" + this.NinUpper.ToString() + "]>=2 y=y(upper)+yLower[1]+1= " + y.ToString() + " (y(upper)=" + yUpper.ToString() + " yLower[1]=" + yLower1.ToString() + ")");
                    //}
                    //if (this.NinUpper > 2)
                    //{
                    //    for (int i = 2; i <= this.NinUpper - 1; i++)
                    //    {
                    //        yUpperCur = this.upper.elems[i - 1].vis_yUpper(vsh);
                    //        yLowerCur = this.upper.elems[i - 1].vis_yLower(vsh);
                    //        y = y + yUpperCur + 1 + yLowerCur + 1;
                    //        MyLib.writeln(vsh, i.ToString() + ")  y=y+yUpperCur[i]+yLower[i]+1= " + y.ToString() + " (yUpperCur[i]=" + yUpperCur.ToString() + " yLowerCur[i]" + yUpperCur.ToString() + ")");
                    //    }
                    //    yMyUpper = this.vis_yUpper(vsh);
                    //    y = y + yMyUpper;
                    //    MyLib.writeln(vsh, " y=y+yMyUpper = " + y.ToString() + " (yMyUpper=" + yMyUpper.ToString() + ")");
                    //}
                    //
                    y = yOfUpper;
                    MyLib.writeln(vsh, "Ce part of " + this.upper.ToString() + " [" + this.NinUpper.ToString() + "]>=1 => y=y(upper)=" + yOfUpper.ToString() + "=" + y.ToString());
                    //
                    if (this.NinUpper > 1)
                    {
                        yLower1 = this.upper.elems[1 - 1].vis_yLower(vsh);
                        y = y + yLower1 + 1;
                        MyLib.writeln(vsh, "Ce part of " + this.upper.ToString() + " [" + this.NinUpper.ToString() + "]>1 y=y(upper)+yLower[1]+1(space lower)= " + y.ToString() + " (y(upper)=" + yOfUpper.ToString() + " yLower[1]=" + yLower1.ToString() + ")");
                    }
                    for (int i = 2; i <= this.NinUpper - 1; i++)
                    {
                        yUpperCur = this.upper.elems[i - 1].vis_yUpper(vsh);
                        yLowerCur = this.upper.elems[i - 1].vis_yLower(vsh);
                        y = y + yUpperCur + 1 + yLowerCur + 1;
                        MyLib.writeln(vsh, i.ToString() + ")  y=y+yUpperCur[i]+1(ipse)+yLower[i]+1(space lower)= " + y.ToString() + " (yUpperCur[i]=" + yUpperCur.ToString() + " yLowerCur[i]" + yLowerCur.ToString() + ")");
                    }
                    //
                    if (this.NinUpper > 1)
                    {
                        yMyUpper = this.vis_yUpper(vsh);
                        y = y + yMyUpper;
                        MyLib.writeln(vsh, " y=y+yMyUpper = " + y.ToString() + " (yMyUpper=" + yMyUpper.ToString() + ")");
                        y = y + 1;
                        MyLib.writeln(vsh, " N>1=" + this.NinUpper.ToString()+ " => y=y+1 = " + y.ToString());
                    }
                    MyLib.writeln(vsh, "finally: y=" + y.ToString());
                }
                else
                {
                    y = yOfUpper;
                    MyLib.writeln(vsh, "united [--]. y=y(upper)=" + yOfUpper.ToString() + "=" + y.ToString());
                }
            }
            MyLib.writeln(vsh, "vis_y finishes working. " + this.ToString() + " y=" + y.ToString());
            return y;
        }
        //
        public int vis_x_cornerLeft(TValsShowHide vsh = null)
        {
            int x = 0;
            x = this.vis_x(vsh);
            return x;
        }
        public int vis_x_cornerRight(TValsShowHide vsh = null)
        {
            int x = this.vis_x(vsh)+this.vis_L(vsh)-1;
            return x;
        }
        public int vis_y_cornerUpper(TValsShowHide vsh = null)
        {
            int y = this.vis_y(vsh);
            if (this.QElements > 0)
            {
                y = y - this.vis_yUpper(vsh);
            }
            return y;
        }
        public int vis_y_cornerLower(TValsShowHide vsh = null)
        {
            int y =  this.vis_y(vsh);;
            if (this.QElements > 0)
            {
                y = y + this.vis_yLower(vsh);
            }
            return y;
        }
        public int vis_x_Caption(TValsShowHide vsh = null)
        {
            int x = this.vis_x(vsh);
            if (this.QElements > 0)
            {
                x = x+1;
            }
            return x;
        }
        public int vis_y_Caption(TValsShowHide vsh = null)
        {
            int curN = this.curN;
            int y = this.vis_y(vsh);
            if (this.QElements > 0)
            {
                y = y - this.vis_yUpper(vsh);
            }
            return y;
        }
        public int vis_x_LeftConnection(TValsShowHide vsh = null)
        {
            int x = 0;
            if (this.upper == null || !(this.upper.GetIfConnectionTypeIsSucc() == true && this.NinUpper == 1))
            {
                x = this.vis_x(vsh) - 1;
            }
            return x;
        }
        public int vis_y_LeftConnection(TValsShowHide vsh = null)
        {
            int y = 0;
            if (this.upper == null || !(this.upper.GetIfConnectionTypeIsSucc() == true && this.NinUpper == 1))
            {
                y = this.vis_y(vsh) ;
            }
            return y;
        }
        public int vis_x_RightConnection(TValsShowHide vsh = null)
        {
            int x = 0, xOwnCur, xOwnMax=0, xOwn, dL, QMates,  CurMateN,  CurN=this.curN;
            if (this.upper == null || !(this.upper.GetIfConnectionTypeIsSucc() == true && this.NinUpper == this.upper.GetQSubElts()))
            {
                xOwn = this.vis_x(vsh) + this.vis_L(vsh);
                x = xOwn;
                if (this.upper != null && this.upper.GetIfConnectionTypeIsPrl() == true)
                {
                    QMates=this.upper.GetQSubElts();
                    for (int i = 1; i <= QMates; i++)
                    {
                        CurMateN = this.upper.elems[i - 1].GetN();
                        xOwnCur = this.upper.elems[i - 1].vis_x(vsh) + this.upper.elems[i - 1].vis_L(vsh);
                        if (i == 1 || (i > 1 && xOwnMax<xOwnCur)) xOwnMax=xOwnCur;
                    }
                    x = xOwnMax;
                }
            }
            return x;
        }
        public int vis_y_RightConnection(TValsShowHide vsh = null)
        {
            int y = 0;
            if (this.upper == null || !(this.upper.GetIfConnectionTypeIsSucc() == true && this.NinUpper == this.upper.GetQSubElts()))
            {
                y = this.vis_y(vsh);
            }
            return y;
        }
        //
        //public int vis_x_SE_NInSucc(int SubEltN, TValsShowHide vsh=null)
        //{
        //    int x = 0;
        //    if (SubEltN >= 1 && SubEltN <= this.QElements)
        //    {
        //        x = this.elems[SubEltN - 1].vis_x(vsh);
        //    }
        //    return x;
        //}
        //public int vis_y_SE_NInSucc(int SubEltN, TValsShowHide vsh = null)
        //{
        //    int y = 0;
        //    if (SubEltN >= 1 && SubEltN <= this.QElements)
        //    {
        //        y = this.elems[SubEltN - 1].vis_y(vsh);
        //    }
        //    return y;
        //}
        //public int vis_yLower_SE_NInSucc(int SubEltN, TValsShowHide vsh = null)
        //{
        //    int yLower = 0;
        //    if (SubEltN >= 1 && SubEltN <= this.QElements)
        //    {
        //        yLower = this.elems[SubEltN - 1].vis_yLower(vsh);
        //    }
        //    return yLower;
        //}
        //public int vis_yUpper_SE_NInSucc(int SubEltN, TValsShowHide vsh = null)
        //{
        //    int yUpper = 0;
        //    if (SubEltN >= 1 && SubEltN <= this.QElements)
        //    {
        //        yUpper = this.elems[SubEltN - 1].vis_yUpper(vsh);
        //    }
        //    return yUpper;
        //}
        //public int vis_L_SE_NInSucc(int SubEltN, TValsShowHide vsh = null)
        //{
        //    int L = 0;
        //    if (SubEltN >= 1 && SubEltN <= this.QElements)
        //    {
        //        L = this.elems[SubEltN - 1].vis_L(vsh);
        //    }
        //    return L;
        //}
        //public int vis_H_SE_NInSucc(int SubEltN, TValsShowHide vsh = null)
        //{
        //    int H = 0;
        //    if (SubEltN >= 1 && SubEltN <= this.QElements)
        //    {
        //        H = this.elems[SubEltN - 1].vis_H(vsh);
        //    }
        //    return H;
        //}
        ////
        //public int vis_x_Mate_NInSucc(int SubEltN, TValsShowHide vsh = null)
        //{
        //    int x = 0;
        //    if (this.upper!=null && SubEltN >= 1 && SubEltN <= this.upper.GetQSubElts())
        //    {
        //        x = this.upper.elems[SubEltN - 1].vis_x(vsh);
        //    }
        //    return x;
        //}
        //public int vis_y_Mate_NInSucc(int SubEltN, TValsShowHide vsh = null)
        //{
        //    int y = 0;
        //    if (this.upper != null && SubEltN >= 1 && SubEltN <= this.upper.GetQSubElts())
        //    {
        //        y = this.upper.elems[SubEltN - 1].vis_y(vsh);
        //    }
        //    return y;
        //}
        //public int vis_yLower_Mate_NInSucc(int SubEltN, TValsShowHide vsh = null)
        //{
        //    int yLower = 0;
        //    if (this.upper != null && SubEltN >= 1 && SubEltN <= this.upper.GetQSubElts())
        //    {
        //        yLower = this.upper.elems[SubEltN - 1].vis_yLower(vsh);
        //    }
        //    return yLower;
        //}
        //public int vis_yUpper_Mate_NInSucc(int SubEltN, TValsShowHide vsh = null)
        //{
        //    int yUpper = 0;
        //    if (this.upper != null && SubEltN >= 1 && SubEltN <= this.upper.GetQSubElts())
        //    {
        //        yUpper = this.upper.elems[SubEltN - 1].vis_yUpper(vsh);
        //    }
        //    return yUpper;
        //}
        //public int vis_L_Mate_NInSucc(int SubEltN, TValsShowHide vsh = null)
        //{
        //    int L = 0;
        //    if (this.upper != null && SubEltN >= 1 && SubEltN <= this.upper.GetQSubElts())
        //    {
        //        L = this.upper.elems[SubEltN - 1].vis_L(vsh);
        //    }
        //    return L;
        //}
        //public int vis_H_Mate_NInSucc(int SubEltN, TValsShowHide vsh = null)
        //{
        //    int H = 0;
        //    if (this.upper != null && SubEltN >= 1 && SubEltN <= this.upper.GetQSubElts())
        //    {
        //        H = this.upper.elems[SubEltN - 1].vis_H(vsh);
        //    }
        //    return H;
        //}
        ////
        //public int vis_x_UpperElement( TValsShowHide vsh = null)
        //{
        //    int x = 0;
        //    if (this.upper != null )
        //    {
        //        x = this.upper.vis_x(vsh);
        //    }
        //    return x;
        //}
        //public int vis_y_UpperElement(TValsShowHide vsh = null)
        //{
        //    int y = 0;
        //    if (this.upper != null )
        //    {
        //        y = this.upper.vis_y(vsh);
        //    }
        //    return y;
        //}
        //public int vis_yLower_UpperElement(TValsShowHide vsh = null)
        //{
        //    int yLower = 0;
        //    if (this.upper != null )
        //    {
        //        yLower = this.upper.vis_yLower(vsh);
        //    }
        //    return yLower;
        //}
        //public int vis_yUpper_UpperElement(TValsShowHide vsh = null)
        //{
        //    int yUpper = 0;
        //    if (this.upper != null )
        //    {
        //        yUpper = this.upper.vis_yUpper(vsh);
        //    }
        //    return yUpper;
        //}
        //public int vis_L_UpperElement(TValsShowHide vsh = null)
        //{
        //    int L = 0;
        //    if (this.upper != null )
        //    {
        //        L = this.upper.vis_L(vsh);
        //    }
        //    return L;
        //}
        //public int vis_H_UpperElement(TValsShowHide vsh = null)
        //{
        //    int H = 0;
        //    if (this.upper != null )
        //    {
        //        H = this.upper.vis_H(vsh);
        //    }
        //    return H;
        //}
        //
        public string CoordsToStr(TValsShowHide vsh)
        {
            string s="R"+this.curN.ToString()+": ";
            int x, y;
            x=this.vis_x(vsh);
            y=this.vis_y(vsh);
            s = s + " Coords: ";
            s = s + "(" + x.ToString() + "; " + y.ToString() + ") ";
            x = this.vis_L(vsh);
            y = this.vis_H(vsh);
            s = s + " Size: ";
            s = s + "(" + x.ToString() + " x " + y.ToString() + ") ";
            x = this.vis_x_Caption(vsh);
            y = this.vis_y_Caption(vsh);
            s = s + " Cap: ";
            s = s + "(" + x.ToString() + "; " + y.ToString() + ") ";
            x = this.vis_x_cornerLeft(vsh);
            s = s + " Corners: ";
            x = this.vis_x_cornerLeft(vsh);
            s = s + " xL=" + x.ToString() + "; ";
            x = this.vis_x_cornerRight(vsh);
            s = s + " xR="+x.ToString()+"; ";
            y = this.vis_y_cornerLower(vsh);
            s = s + " yL=" + y.ToString() + "; ";
            y = this.vis_y_cornerUpper(vsh);
            s = s + " yU=" + y.ToString() + "; ";
            s = s + " Connectors: ";
            s = s + " Left: ";
            x = this.vis_x_LeftConnection(vsh);
            y = this.vis_y_LeftConnection(vsh);
            s = s + "(" + x.ToString() + "; " + y.ToString() + ") ";
            s = s + " Right: ";
            x = this.vis_x_RightConnection(vsh);
            y = this.vis_y_RightConnection(vsh);
            s = s + "(" + x.ToString() + "; " + y.ToString() + ") ";
            return s;
        }
        public void ShowCoords_IpseAndSub(TValsShowHide vsh)
        {
            string s = this.CoordsToStr(null);
            MyLib.writeln(vsh, s);
            for (int i = 1; i <= this.QElements; i++)
            {
                this.elems[i - 1].ShowCoords_IpseAndSub(vsh);
            }
        }
       
        
        public void vis_Display_WithSubElts(HydroSchemCanvas canvas, TValsShowHide vsh = null)
        {
            int x, y, x1, y1;
            MyLib.writeln(vsh, "");
            MyLib.writeln(vsh, "vis_Display_WithSubElts starts working. R" + this.curN.ToString());
            //
            HydroPipelineElement top = this.nav_GoToTop();
            //canvas.SetSize(top.vis_L_WithConnectors(null), top.vis_H(null));
            if (this.upper == null)
            {
                canvas.SetSize(top.vis_L_WithConnectors(null), top.vis_H(null));
                canvas.Clear();
            }
            //
            if (this.upper == null)
            {
                //canvas.SetSize(this.vis_L_WithConnectors(null), this.vis_H(null));
                //
                x = this.vis_x_LeftConnection(vsh);
                y = this.vis_y_LeftConnection(vsh);
                canvas.Draw_ConnectorCentral(x, y);
                x = this.vis_x_RightConnection(vsh);
                y = this.vis_y_RightConnection(vsh);
                canvas.Draw_ConnectorCentral(x, y);
            }
            if (this.QElements == 0)
            {
                x = this.vis_x(vsh);
                y = this.vis_y(vsh);
                canvas.Draw_ResistanceElementar(x, y, this.curN);
            }
            else
            {
                //Draw_FrameName
                x = this.vis_x_Caption();
                y = this.vis_y_Caption();
                canvas.Draw_FrameName(x, y, this.curN);
                //LineFrameIntersection left
                x = this.vis_x(vsh);
                y = this.vis_y(vsh);
                canvas.Draw_LineFrameIntersection(x, y);
                //LineFrameIntersection right
                x = this.vis_x_cornerRight(vsh);
                y = this.vis_y(vsh);
                canvas.Draw_LineFrameIntersection(x, y);
                //hor frame
                x1 = this.vis_x_cornerRight(vsh)-1;
                //upper frame
                x = this.vis_x_Caption(vsh)+1;
                y = this.vis_y_cornerUpper(vsh);
                for (int CurX = x; CurX <= x1; CurX++)
                {
                    canvas.Draw_FrameElementHorisontal(CurX, y);
                }
                //lower frame
                x = this.vis_x(vsh)+1;
                y = this.vis_y_cornerLower(vsh);
                for (int CurX = x; CurX <= x1; CurX++)
                {
                    canvas.Draw_FrameElementHorisontal(CurX, y);
                }
                //vert frame
                y = this.vis_y_cornerUpper(vsh)+1;
                y1 = this.vis_y(vsh)-1 ;
                x = this.vis_x_cornerLeft(vsh);
                x1 = this.vis_x_cornerRight(vsh);
                for (int CurY = y; CurY <= y1; CurY++)
                {
                    canvas.Draw_FrameElementVertical(x, CurY);
                    canvas.Draw_FrameElementVertical(x1, CurY);
                }
                y = this.vis_y(vsh) + 1;
                y1 = this.vis_y_cornerLower(vsh) - 1;
                x = this.vis_x_cornerLeft(vsh);
                x1 = this.vis_x_cornerRight(vsh);
                for (int CurY = y; CurY <= y1; CurY++)
                {
                    canvas.Draw_FrameElementVertical(x, CurY);
                    canvas.Draw_FrameElementVertical(x1, CurY);
                }
                //Corners
                //Left 
                x = this.vis_x_cornerLeft(vsh);
                //Left upper
                y = this.vis_y_cornerUpper(vsh);
                //canvas.Draw_ResistanceLeftSide(x, y);//vikt! ecri right corner alt left! qob?
                canvas.Draw_FrameElementLeft(x, y);
                //Left lower
                y = this.vis_y_cornerLower(vsh);
                //canvas.Draw_ResistanceLeftSide(x, y);
                canvas.Draw_FrameElementLeft(x, y);
                //Right
                x = this.vis_x_cornerRight(vsh);//vikt! ecri right corner alt left! qob?
                //Right upper
                y = this.vis_y_cornerUpper(vsh);
                //canvas.Draw_ResistanceRightSide(x, y);
                canvas.Draw_FrameElementRight(x, y);
                //Right lower
                y = this.vis_y_cornerLower(vsh);
                //canvas.Draw_ResistanceRightSide(x, y);//vikt! ecri right corner alt left! qob?
                canvas.Draw_FrameElementRight(x, y);
                //Sub-elements
                for (int i = 1; i <= this.QElements; i++)
                {
                    this.elems[i - 1].vis_Display_WithSubElts(canvas, vsh);
                }
                //this.elems[this.QElements - 1].vis_Display_WithSubElts(canvas, vsh);
                if (this.Conn_Suc0Par1 == 0)
                {
                    //
                    for (int i = 2; i <= this.QElements; i++)
                    {
                        x = this.elems[i - 1].vis_x_LeftConnection(vsh);
                        y = this.elems[i - 1].vis_y_LeftConnection(vsh);
                        canvas.Draw_ConnectorCentral(x, y);
                    }
                }
                else //this.Conn_Suc0Par1 == 1
                {
                    //connectors
                    for (int i = 1; i <= this.QElements; i++)
                    {
                        x = this.elems[i - 1].vis_x_LeftConnection(vsh);
                        y = this.elems[i - 1].vis_y_LeftConnection(vsh);
                        if (i == 1)
                        {
                            canvas.Draw_ConnectorCentral(x, y);
                        }
                        else if (i == this.QElements)
                        {
                            canvas.Draw_ConnectorLeft(x, y);
                        }
                        else
                        {
                            canvas.Draw_ConnectorLeft(x, y);
                        }
                        //
                        x = this.elems[i - 1].vis_x_RightConnection(vsh);
                        y = this.elems[i - 1].vis_y_RightConnection(vsh);
                        if (i == 1)
                        {
                            canvas.Draw_ConnectorCentral(x, y);
                        }
                        else if (i == this.QElements)
                        {
                            canvas.Draw_ConnectorRight(x, y);
                        }
                        else
                        {
                            canvas.Draw_ConnectorRight(x, y);
                        }
                    }//for conectors
                    //Lines
                    //vertical lines
                    for (int i = 2; i <= this.QElements; i++)
                    {
                        x = this.elems[i - 1 - 1].vis_x_LeftConnection(vsh);
                        x1 = this.elems[i - 1 ].vis_x_RightConnection(vsh);
                        y = this.elems[i - 1 - 1].vis_y_LeftConnection(vsh);
                        y1 = this.elems[i - 1].vis_y_LeftConnection(vsh);
                        for (int curY = y + 1; curY <= y1 - 1; curY++)
                        {
                            canvas.Draw_LineVertical(x, curY);
                            canvas.Draw_LineVertical(x1, curY);
                        }
                    }
                    //hor lines
                    for (int i = 1; i <= this.QElements; i++)
                    {
                        x = this.elems[i - 1].vis_x_RightConnection(vsh)-1;
                        x1 = this.elems[i - 1].vis_x(vsh) + this.elems[i - 1].vis_L(vsh);
                        y = this.elems[i - 1].vis_y(vsh);
                        for (int curX = x1; curX <= x; curX++)
                        {
                            canvas.Draw_LineHorisontal(curX, y);
                        }
                    }
                }
            }
            MyLib.writeln(vsh, "vis_Display_WithSubElts finishes working. R" + this.curN.ToString());
        }//fn draw all, ma name'd aso: vis_Display_WithSubElts
        public void DisplaySchem(HydroSchemCanvas canvas, TValsShowHide vsh = null)
        {
            HydroPipelineElement top = this.nav_GoToTop();
            canvas.SetSize(top.vis_L_WithConnectors(vsh), top.vis_H(vsh));
            top.vis_Display_WithSubElts(canvas, vsh);
        }
        //nav
        public HydroPipelineElement nav_GoToTop()
        {
            HydroPipelineElement ptr = this;
            while (ptr.upper != null)
            {
                ptr = ptr.upper;
            }
            return ptr;
        }
        public HydroPipelineElement nav_GoToUpper()
        {
            return this.upper;
        }
        public HydroPipelineElement nav_Enter()
        {
            HydroPipelineElement subElt = null;
            if (this.elems != null)
            {
                subElt = this.elems[1 - 1];
            }
            return subElt;
        }
        public HydroPipelineElement nav_SubEltN(int N)
        {
            HydroPipelineElement subElt = null;
            if (this.elems != null && N >= 1 && N <= this.QElements)
            {
                subElt = this.elems[N - 1];
            }
            return subElt;
        }
        public HydroPipelineElement nav_Prev()
        {
            HydroPipelineElement R = null;// subElt = null;

            if (this.upper != null && this.NinUpper > 1 && this.NinUpper <= this.upper.QElements)
            {
                //subElt 
                R= this.upper.elems[this.NinUpper - 1 - 1];
            }
            return R;// subElt;
        }
        public HydroPipelineElement nav_Next()
        {
            HydroPipelineElement R = null;// subElt = null;

            if (this.upper != null && this.NinUpper >= 1 && this.NinUpper < this.upper.QElements)
            {
                //subElt = this.upper.elems[this.NinUpper + 1 - 1];
                R = this.upper.elems[this.NinUpper + 1 - 1];
            }
            return R;// subElt;
        }
        public HydroPipelineElement nav_First()
        {
            HydroPipelineElement R = null;// subElt = null;
            if (this.upper != null)
            {
                //subElt = this.elems[1 - 1];
                R = this.upper.elems[1 - 1];
            }
            return R;// subElt;
        }
        public HydroPipelineElement nav_Last()
        {
            HydroPipelineElement R = null;// subElt = null;
            if (this.upper != null)
            {
                //subElt = this.elems[this.upper.QElements - 1];
                R = this.upper.elems[this.upper.QElements - 1];
            }
            return R;// subElt;
        }
        //
        //
        public bool CheckRIf_CoordsBelongToThisR(int x, int y, TValsShowHide vsh = null)
        {
            bool b = false;
            int xL, xR, yL, yU;
            MyLib.writeln(vsh, "CheckRIf_CoordsBelongToThisR starts working");
            xL = this.vis_x_cornerLeft();
            xR = this.vis_x_cornerRight();
            yU = this.vis_y_cornerUpper();
            yL = this.vis_y_cornerLower();
            MyLib.writeln(vsh, "Must be: L=" + y.ToString() + " E [" + xL.ToString() + "; " + xR.ToString() + "], C=" + y.ToString() + " E [" + yU.ToString() + "; " + yL.ToString() + "]");
            if (x >= xL && x <= xR && y >= yU && y <= yL)
            {
                b = true;
            }
            MyLib.writeln(vsh, "CheckRIf_CoordsBelongToThisR finishes working. Answer: " + MyLib.BoolToInt(b).ToString());
            return b;
        }
        public bool CheckRIf_CoordsBelongToThisR(int x, int y)
        {
            bool b=false;
            int xL, xR, yL, yU;
            xL=this.vis_x_cornerLeft();
            xR=this.vis_x_cornerRight();
            yU=this.vis_y_cornerUpper();
            yL=this.vis_y_cornerLower();
            if (x >= xL && x <= xR && y >= yU && y <= yL)
            {
                b=true;
            }
            return b;
        }
        public bool CheckRIf_CoordsAreOfThisR(int x, int y)
        {
            return ( x == this.vis_x(null) && y == this.vis_y(null) );
        }
        public bool CheckRIf_CapIsOfThisR(int x, int y)
        {
            return (x == this.vis_x_Caption(null) && y == this.vis_y_Caption(null));
        }
        public bool CheckRIf_NisOfThisElement(int N, int i = 0)
        {
            return (this.curN==N);
        }
        private delegate bool SearchCondition(int p1, int p2);
        public HydroPipelineElement SeekElementByNPrimitive(int N, TValsShowHide vsh = null)
        {
            MyLib.writeln(vsh, "Recursive search fn SeekElementByNPrimitive starts working, for: " + this.ToString());
            HydroPipelineElement cur = this, R = null;// = this.nav_GoToTop();//no: if fn s'recursive, so S ms'abdo ab cur
            bool found = false, contin;
            int SE_N = 0;
            found = (cur.GetN() == N);
            if (found)
            {
                R = cur;
                MyLib.writeln(vsh, "Found at: " + R.ToString());
            }
            else
            {
                MyLib.writeln(vsh, "Not Found at: " + this.ToString());
            }
            contin = !found;
            if (contin)
            {
                contin = (this.QElements > 0);
                if (contin)
                {
                    MyLib.writeln(vsh, "Trying to seek in Sub-Elts");
                }
                else
                {
                    MyLib.writeln(vsh, "Search is over. Not found.");
                }
            }
            while (contin)
            {
                SE_N++;
                cur = this.elems[SE_N - 1];//cur = cur.elems[SE_N - 1];
                MyLib.writeln(vsh, "Sub-elt N " + SE_N.ToString() + " - " + cur.ToString());
                R = cur.SeekElementByNPrimitive(N, vsh);
                found = (R != null);
                contin = !found;
                MyLib.writeln(vsh, "found=" + (MyLib.BoolToInt(found)).ToString() + " contin=" + (MyLib.BoolToInt(contin)).ToString());
                if (contin)
                {
                    contin = (SE_N < this.QElements);

                }
                MyLib.writeln(vsh, "SE_N=" + SE_N.ToString() + " Q=" + this.QElements.ToString() + " contin=" + (MyLib.BoolToInt(contin)).ToString());
            }
            if (found)
            {
                //R = cur;//!
                MyLib.writeln(vsh, "Finally: Found at: " + R.ToString());
            }
            else
            {
                MyLib.writeln(vsh, "Finally: Not found");
            }
            MyLib.writeln(vsh, "Recursive search fn SeekElementByNPrimitive finishes working, for: " + this.ToString());
            return R;
        }
        public HydroPipelineElement SeekElementByCoordsPrimitive(int x, int y, TValsShowHide vsh = null)
        {
            MyLib.writeln(vsh, "Recursive search fn SeekElementByCoordsPrimitive starts working, for: " + this.ToString());
            HydroPipelineElement cur=this, R=null;// = this.nav_GoToTop();//no: if fn s'recursive, so S ms'abdo ab cur
            bool found = false, contin;
            int SE_N = 0;
            found = (cur.vis_x(vsh) == x && y==cur.vis_y(vsh));
            if (found)
            {
                R = cur;
                MyLib.writeln(vsh, "Found at: " + R.ToString());
            }
            else
            {
                MyLib.writeln(vsh, "Not Found at: " + this.ToString());
            }
            contin = !found;
            if (contin)
            {
                contin = (this.QElements > 0);
                if (contin)
                {
                    MyLib.writeln(vsh, "Trying to seek in Sub-Elts");
                }
                else
                {
                    MyLib.writeln(vsh, "Search is over. Not found.");
                }
            }
            while (contin)
            {
                SE_N++;
                cur = this.elems[SE_N - 1];//cur = cur.elems[SE_N - 1];
                MyLib.writeln(vsh, "Sub-elt N " + SE_N.ToString()+" - "+cur.ToString());
                R = cur.SeekElementByCoordsPrimitive(x, y, vsh);
                found = (R != null);
                contin = !found;
                MyLib.writeln(vsh, "found=" + (MyLib.BoolToInt(found)).ToString() + " contin=" + (MyLib.BoolToInt(contin)).ToString());
                if (contin)
                {
                    contin = (SE_N < this.QElements);
                    
                }
                MyLib.writeln(vsh, "SE_N=" + SE_N.ToString() + " Q=" + this.QElements.ToString() + " contin=" + (MyLib.BoolToInt(contin)).ToString());
            }
            if (found)
            {
                //R = cur;//!
                MyLib.writeln(vsh, "Finally: Found at: " + R.ToString());
            }
            else
            {
                MyLib.writeln(vsh, "Finally: Not found");
            }
            MyLib.writeln(vsh, "Recursive search fn SeekElementByCoordsPrimitive finishes working, for: " + this.ToString());
            return R;
        }
        public string GetPathString()
        {
            string R = "R" + this.curN.ToString();
            HydroPipelineElement cur = this;
            while (cur.upper != null)
            {
                R = "/<N[" + this.NinUpper.ToString() + "]>/" + R;
                R = "R" + (cur.upper.GetN()).ToString() + R;
            }
            return R;
        }
        public HydroPipelineElement SeekElementByCoordsBelongingPrimitive(int x, int y, TValsShowHide vsh = null)
        {
            MyLib.writeln(vsh, "Recursive search fn SeekElementByCoordsBelongingPrimitive starts working, for: " + this.ToString());
            HydroPipelineElement cur = this, R = null;// = this.nav_GoToTop();//no: if fn s'recursive, so S ms'abdo ab cur
            bool found = false, contin, caught;
            int SE_N = 0;
            int xL = this.vis_x_cornerLeft(null), xR = this.vis_x_cornerRight(null), yL = this.vis_y_cornerLower(null), yU = this.vis_y_cornerUpper(null);
            caught = CheckRIf_CoordsBelongToThisR(x, y, vsh);
            if (caught)
            {
                MyLib.writeln(vsh, "Caught at: " + this.ToString());
                if (this.QElements == 0 || ((x == xL || x == xR) && (y <= yL && y >= yU)) || ((y == yL || y == yU) && (x <= xR && x >= xL)))
                {
                    found = true;
                    contin = false;
                    R = this;
                    if (this.QElements == 0)
                    {
                        MyLib.writeln(vsh, "Found (Q=0) at: " + R.ToString());
                    }
                    if ((x == xL || x == xR) && (y <= yL && y >= yU))
                    {
                       MyLib.writeln(vsh, "Found (contour vert) at: " + R.ToString());
                    }
                    if ((y == yL || y == yU) && (x <= xR && x >= xL))
                    {
                        MyLib.writeln(vsh, "Found (contour hor) at: " + R.ToString());
                    }
                }else{
                    MyLib.writeln(vsh, "Seek in sub-Elts: ");
                    contin = true;
                    while(contin){
                        SE_N++;
                        cur = this.elems[SE_N - 1];
                        MyLib.writeln(vsh, "Checking element:" + SE_N.ToString() + ") " + cur.ToString());
                        R=cur.SeekElementByCoordsBelongingPrimitive(x, y, vsh);
                        if(R!=null){
                            contin=false;
                            found = true;
                        }
                        if(contin){
                            contin=(SE_N<this.QElements);
                        }
                    }
                }//seek in hin or in Sub-Elts
                if (!found)
                {
                    R = this;
                    found = true;
                }
            }//if caught or not    
            if (found)
            {
                MyLib.writeln(vsh, "Finally: Found at: " + R.ToString());
            }
            else
            {
                MyLib.writeln(vsh, "Finally: Not found");
            }
            MyLib.writeln(vsh, "Recursive search fn SeekElementByCoordsBelongingPrimitive finishes working, for: " + this.ToString());
            return R;
        }
        public HydroPipelineElement SeekElementByDelegate(int typeN_, int p1, int p2, TValsShowHide vsh=null)
        {
            SearchCondition dlgt = this.CheckRIf_NisOfThisElement;
            switch (typeN_)
            {
                case 1:
                    dlgt = this.CheckRIf_CoordsBelongToThisR;
                    break;
                case 2:
                    dlgt = this.CheckRIf_CoordsAreOfThisR;
                    break;
                case 3:
                    dlgt = this.CheckRIf_CapIsOfThisR;
                    break;
                case 4:
                    dlgt = this.CheckRIf_NisOfThisElement;
                    break;
            }
            //copy
            MyLib.writeln(vsh, "Recursive search fn SeekElementByDelegate starts working, for: " + this.ToString());
            HydroPipelineElement cur = this, R = null;// = this.nav_GoToTop();//no: if fn s'recursive, so S ms'abdo ab cur
            bool found = false, contin;
            int SE_N = 0;
            found = dlgt(p1, p2);
            if (found)
            {
                R = cur;
                MyLib.writeln(vsh, "Found at: " + R.ToString());
            }
            else
            {
                MyLib.writeln(vsh, "Not Found at: " + this.ToString());
            }
            contin = !found;
            if (contin)
            {
                contin = (this.QElements > 0);
                if (contin)
                {
                    MyLib.writeln(vsh, "Trying to seek in Sub-Elts");
                }
                else
                {
                    MyLib.writeln(vsh, "Search is over. Not found.");
                }
            }
            while (contin)
            {
                SE_N++;
                cur = this.elems[SE_N - 1];//cur = cur.elems[SE_N - 1];
                MyLib.writeln(vsh, "Sub-elt N " + SE_N.ToString() + " - " + cur.ToString());
                R = cur.SeekElementByDelegate( typeN_,  p1,  p2,  vsh);
                found = (R != null);
                contin = !found;
                MyLib.writeln(vsh, "found=" + (MyLib.BoolToInt(found)).ToString() + " contin=" + (MyLib.BoolToInt(contin)).ToString());
                if (contin)
                {
                    contin = (SE_N < this.QElements);

                }
                MyLib.writeln(vsh, "SE_N=" + SE_N.ToString() + " Q=" + this.QElements.ToString() + " contin=" + (MyLib.BoolToInt(contin)).ToString());
            }
            if (found)
            {
                //R = cur;//!
                MyLib.writeln(vsh, "Finally: Found at: " + R.ToString());
            }
            else
            {
                MyLib.writeln(vsh, "Finally: Not found");
            }
            MyLib.writeln(vsh, "Recursive search fn SeekElementByDelegate finishes working, for: " + this.ToString());
            return R;
        }//fn
        //
        public void GetIniDataAdvancedNames(ref string[] names, ref int count)
        {
            string curStr="";
            string[] OtherNames = null;
            int QOther = 0;
            names = null;
            count=0;
            //
            this.HydroRData.IniData.GetItemNames(ref OtherNames, 1);
            //
            curStr = "RN";
            MyLib.AddToVector(ref names, ref count, curStr);
            curStr = "N In Upper";
            MyLib.AddToVector(ref names, ref count, curStr);
            curStr = "Connection Type";
            MyLib.AddToVector(ref names, ref count, curStr);
            //
            QOther = OtherNames.Length;
            for (int i = 1; i <= QOther; i++)
            {
                curStr = OtherNames[i - 1];
                MyLib.AddToVector(ref names, ref count, curStr);
            }
            //count += QOther;
        }
        public DataCellRow GetAsDataCellRow()
        {
            DataCellRow R=new DataCellRow(false), Sub;
            DataCell cell;
            int LSub;
            Sub = this.HydroRData.IniData.GetAsDataCellRow();
            LSub = Sub.GetSize();
            cell=new DataCell(this.GetN());
            R.Add(cell);
            cell = new DataCell(this.GetNinUpper());
            R.Add(cell);
            //cell = new DataCell(this.Conn_Suc0Par1);
            cell = new DataCell(new string[]{"--","//"},2);
            cell.SetActiveN(this.Conn_Suc0Par1 + 1);
            R.Add(cell);
            for (int i = 1; i <= LSub; i++)
            {
                cell = Sub.GetCellN(i);
                R.Add(cell);
            }
            return R;
        }
        public void SetFromDataCellRow(DataCellRow row)
        {
            this.curN = row.GetIntVal(1);
            this.NinUpper = row.GetIntVal(2);
            this.Conn_Suc0Par1 = row.GetIntVal(3);
            this.HydroRData = new HydroResistanceData();
            this.HydroRData.IniData.SetFromDataCellRow(row, 3);
        }
        public TTable hydroResistance_IniDataAdvanced_GetAsTable()
        {
            TTable tbl=this.HydroRData.IniData.GetAsTable();
            string[]names=null;
            int Q=0;
            this.GetIniDataAdvancedNames(ref names, ref Q);
            DataCellRow Caps = new DataCellRow(names, Q);
            DataCellRow Cont = this.GetAsDataCellRow();
            DataCellRowCoHeader[] OwnRows = new DataCellRowCoHeader[3];
            for (int i = 3; i >= 1; i--)
            {
                OwnRows[i - 1] = new DataCellRowCoHeader
                (
                    new DataCell(names[i - 1]),
                    new DataCellRow
                    (
                        new DataCell[]
                        {
                            //new DataCell(Cont.GetIntVal(i))
                            Cont.GetCellN(i)
                        }
                        ,1
                    )
                );
                tbl.InsLine(1, OwnRows[i - 1]);
            }
            return tbl;
        }
        public void hydroResistance_IniDataAdvanced_SetFromTable(TTable tbl, TValsShowHide vsh=null)
        {
            MyLib.writeln(vsh, "hydroResistance_IniDataAdvanced_SetFromTable starts working");
            MyLib.writeln(vsh, "Before setting from table this R was:");
            this.Show(vsh);
            this.curN = tbl.GetIntVal(1, 1) ;
            this.NinUpper = tbl.GetIntVal(2, 1);
            this.Conn_Suc0Par1 = tbl.GetIntVal(3, 1) - 1;
            this.HydroRData.IniData.SetFromTable(tbl, 3);
            MyLib.writeln(vsh, "Now this R is:");
            this.Show(vsh);
            MyLib.writeln(vsh, "hydroResistance_IniDataAdvanced_SetFromTable finishes working");
        }
        public TTable GetSubElementsIniDataAdvancedAsTable()
        {
            TTable tbl = null;
            string[] names = null;
            int QNames = 0;
            DataCellRow ColCaps = null;
            DataCellRowCoHeader[] rows = new DataCellRowCoHeader[this.QElements];
            DataCell header = new DataCell(this.ToString()), LGH = new DataCell("R"), CGH = new DataCell("Data");
            for (int i = 1; i <= this.QElements; i++)
            {
                rows[i - 1] = new DataCellRowCoHeader(new DataCell("R" + this.elems[i - 1].GetN().ToString()), this.elems[i - 1].GetAsDataCellRow());
            }
            this.GetIniDataAdvancedNames(ref names, ref QNames);
            ColCaps = new DataCellRow(names, QNames);
            tbl = new TTable
                (
                    new TableInfo(true, true, true, this.QElements, QNames),
                    false,
                    rows,
                    ColCaps,
                    new TableHeaders(header, LGH, CGH),
                    true
                );
            return tbl;
        }
        //
        //public TTable hydroResistance_IniData_GetAsTable()
        //{
        //    //return this.HydroRData.IniData.GetAsTable();
        //}
        //public void hydroResistance_IniData_SetFromtTable(TTable tbl)
        //{
        //    this.HydroRData.IniData.SetFromTable(tbl);
        //}
        //
    }//cl
}//ns
