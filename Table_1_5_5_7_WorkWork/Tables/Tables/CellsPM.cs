using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tables
{
    public abstract class TDataCell
    {
        public abstract  int GetTypeN();
        public abstract int GetActiveN();
        public abstract void SetActiveN(int N);
        public abstract int GetLength();
        public abstract void SetLength(int L);
        //
        public abstract double GetDoubleVal();
        public abstract float GetFloatVal();
        public abstract int GetIntVal();
        public abstract bool GetBoolVal();
        abstract public override string ToString();
        //
        public abstract double GetDoubleValN(int N);
        public abstract float GetFloatValN(int N);
        public abstract int GetIntValN(int N);
        public abstract bool GetBoolValN(int N);
        public abstract string ToStringN(int N);
        //
        public abstract void SetByValDouble(double val);
        public abstract void SetByValFloat(float val);
        public abstract void SetByValInt(int val);
        public abstract void SetByValBool(bool val);
        public abstract void SetByValString(string val);
        //
        public abstract void SetByValDoubleN(double val, int N);
        public abstract void SetByValFloatN(float val, int N);
        public abstract void SetByValIntN(int val, int N);
        public abstract void SetByValBoolN(bool val, int N);
        public abstract void SetByValStringN(string val, int N);
        //
        public abstract void SetVal(double val);
        public abstract void SetVal(int val);
        public abstract void SetVal(bool val);
        public abstract void SetVal(string val);
        //
        public abstract void SetValN(double val, int N);
        public abstract void SetValN(int val, int N);
        public abstract void SetValN(bool val, int N);
        public abstract void SetValN(string val, int N);
        //
        public abstract void SetByArrDouble(double[] val, int Q);
        public abstract void SetByArrFloat(float[] val, int Q);
        public abstract void SetByArrInt(int[] val, int Q);
        public abstract void SetByArrBool(bool[] val, int Q);
        public abstract void SetByArrString(string[] val, int Q);
        //
        public abstract void SetByArr(double[] val, int Q);
        public abstract void SetByArr(int[] val, int Q);
        public abstract void SetByArr(bool[] val, int Q);
        public abstract void SetByArr(string[] val, int Q);
        //
        public abstract void AddOrInsDoubleVal(double val, int N);
        public abstract void AddOrInsFloatVal(float val, int N);
        public abstract void AddOrInsIntVal(int val, int N);
        public abstract void AddOrInsBoolVal(bool val, int N);
        public abstract void AddOrInsStringVal(string val, int N);
        //
        //
        public abstract void GetDoubleArr(ref double[] Arr, ref int QItems);
        public abstract void GetFloatArr(ref float[] Arr, ref int QItems);
        public abstract void GetIntArr(ref int[] Arr, ref int QItems);
        public abstract void GetBoolArr(ref bool[] Arr, ref int QItems);
        public abstract void ToStringArr(ref string [] Arr, ref int QItems);
        //
        //
        public abstract void DelValN(int N);
        //
        //public abstract InsDoubleValN(double val, int N);
        //public abstract InsFloatValN(float val, int N);
        //public abstract InsIntValN(int val, int N);
        //public abstract InsBoolValN(bool val, int N);
        //public abstract InsStringValN(string val, int N);
        //
        //public abstract AddDoubleValN(double val, int N);
        //public abstract AddFloatValN(float val, int N);
        //public abstract AddIntValN(int val, int N);
        //public abstract AddBoolValN(bool val, int N);
        //public abstract AddStringValN(string val, int N);
    }//cl
    //
    public class TCellDouble:TDataCell
    {
        double val;
        public TCellDouble() { val = 0; }
        public TCellDouble(double val) { SetByValDouble(val); }
        public TCellDouble(float val) { SetByValFloat(val); }
        public TCellDouble(int val) { SetByValInt(val); }
        public TCellDouble(bool val) { SetByValBool(val); }
        public TCellDouble(string val) { SetByValString(val); }
        //
        public TCellDouble(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellDouble(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellDouble(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellDouble(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellDouble(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override int GetTypeN() { return TableConsts.DoubleTypeN; }
        public override int GetActiveN() { return 1;}
        public override void SetActiveN(int N) { }
        public override int GetLength() { return 1; }
        public override void SetLength(int L){}
        //
        public override double GetDoubleVal() { return val; }
        public override float GetFloatVal() {
            float r;
            r = (float)val;
            return r;
        }
        public override int GetIntVal()
        {
            int r;
            r =(int)Math.Round(val);
            return r;
        }
        public override bool GetBoolVal() {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToString() { return val.ToString(); }
        //
        public override double GetDoubleValN(int N) { return val; }
        public override float GetFloatValN(int N) { return (float)val; }
        public override int GetIntValN(int N)
        {
            int r;
            r = (int)Math.Round(val);
            return r;
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) {return val.ToString(); }
        //
        public override void SetByValDouble(double val) { this.val = (double)val; }
        public override void SetByValFloat(float val) { this.val = (double)val; }
        public override void SetByValInt(int val) { this.val = (double)val; }
        public override void SetByValBool(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val=(double)i;
        }
        public override void SetByValString(string val) { this.val = Convert.ToDouble(val); }
        //
        public override void SetByValDoubleN(double val, int N) { SetByValDouble(val); }
        public override void SetByValFloatN(float val, int N) { SetByValFloat(val); }
        public override void SetByValIntN(int val, int N) { SetByValInt(val); }
        public override void SetByValBoolN(bool val, int N) { SetByValBool(val); }
        public override void SetByValStringN(string val, int N) { SetByValString(val); }
        //
        public override void SetVal(double val) { this.val = (double)val; }
        public override void SetVal(int val) { this.val = (double)val; }
        public override void SetVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val = (double)i;
        }
        public override void SetVal(string val) { this.val = Convert.ToDouble(val); }
        //
        public override void SetValN(double val, int N) { SetVal(val); }
        public override void SetValN(int val, int N) { SetVal(val); }
        public override void SetValN(bool val, int N) { SetVal(val); }
        public override void SetValN(string val, int N) { SetVal(val); }
        //
        public override void SetByArrDouble(double[] val, int Q){
            if(val!=null)SetByValDouble(val[1-1]);
            else SetByValDouble(0);
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            if (val != null) SetByValFloat(val[1 - 1]);
            else SetByValFloat(0);
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArrString(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void SetByArr(double[] val, int Q){
            if(val!=null)SetByValDouble(val[1-1]);
            else SetByValDouble(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            this.val = val;
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            this.val = (double)val;
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            this.val = (double)val;
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            this.val = (double)MyLib.BoolToInt(val);
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            this.val=Convert.ToDouble(val);
        }
        //
        public override void DelValN(int N) { }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems) {
            QItems=1;
            Arr = new double[QItems];
            Arr[1 - 1] = GetDoubleVal();
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems) {
            QItems = 1;
            Arr = new float[QItems];
            Arr[1 - 1] = GetFloatVal();
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems) {
            QItems = 1;
            Arr = new int[QItems];
            Arr[1 - 1] = GetIntVal();
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems) {
            QItems = 1;
            Arr = new bool[QItems];
            Arr[1 - 1] = GetBoolVal();
        }
        public override void ToStringArr(ref string[] Arr, ref int QItems) {
            QItems = 1;
            Arr = new string[QItems];
            Arr[1 - 1] = ToString();
        }
    }//cl
    public class TCellFloat : TDataCell
    {
        float val;
        public TCellFloat() { val = 0; }
        public TCellFloat(double val) { SetByValDouble(val); }
        public TCellFloat(float val) { SetByValFloat(val); }
        public TCellFloat(int val) { SetByValInt(val); }
        public TCellFloat(bool val) { SetByValBool(val); }
        public TCellFloat(string val) { SetByValString(val); }
        //
        public TCellFloat(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellFloat(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellFloat(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellFloat(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellFloat(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override int GetTypeN() { return TableConsts.FloatTypeN; }
        public override int GetActiveN() { return 1; }
        public override void SetActiveN(int N) { }
        public override int GetLength() { return 1; }
        public override void SetLength(int L) { }
        //
        public override double GetDoubleVal() {
            //float r;
            //r = (float)val;
            //return r;
            return (double)val;
        }
        public override float GetFloatVal()
        {
            //float r;
            //r = (float)val;
            //return r;
            return val;
        }
        public override int GetIntVal()
        {
            int r;
            r = (int)Math.Round(val);
            return r;
        }
        public override bool GetBoolVal()
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToString() { return val.ToString(); }
        //
        public override double GetDoubleValN(int N) { return val; }
        public override float GetFloatValN(int N) { return (float)val; }
        public override int GetIntValN(int N)
        {
            int r;
            r = (int)Math.Round(val);
            return r;
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) { return val.ToString(); }
        //
        public override void SetByValDouble(double val) { this.val = (float)val; }
        public override void SetByValFloat(float val) { this.val = (float)val; }
        public override void SetByValInt(int val) { this.val = (float)val; }
        public override void SetByValBool(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val = (float)i;
        }
        public override void SetByValString(string val) {
            double d;
            d = Convert.ToDouble(val);
            this.val = (float)d;
        }
        //
        public override void SetByValDoubleN(double val, int N) { SetByValDouble(val); }
        public override void SetByValFloatN(float val, int N) { SetByValFloat(val); }
        public override void SetByValIntN(int val, int N) { SetByValInt(val); }
        public override void SetByValBoolN(bool val, int N) { SetByValBool(val); }
        public override void SetByValStringN(string val, int N) { SetByValString(val); }
        //
        public override void SetVal(double val) { this.val = (float)val; }
        public override void SetVal(int val) { this.val = (float)val; }
        public override void SetVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val = (float)i;
        }
        public override void SetVal(string val) {
            double d;
            d = Convert.ToDouble(val);
            this.val = (float)d;
        }
        //
        public override void SetValN(double val, int N) { SetVal(val); }
        public override void SetValN(int val, int N) { SetVal(val); }
        public override void SetValN(bool val, int N) { SetVal(val); }
        public override void SetValN(string val, int N) { SetVal(val); }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            if (val != null) SetByValFloat(val[1 - 1]);
            else SetByValFloat(0);
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArrString(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            this.val = (float)val;
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            this.val = val;
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            this.val = (float)val;
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            this.val = (float)MyLib.BoolToInt(val);
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            this.val = (float)Convert.ToDouble(val);
        }
        //
        public override void DelValN(int N) { }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new double[QItems];
            Arr[1 - 1] = GetDoubleVal();
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new float[QItems];
            Arr[1 - 1] = GetFloatVal();
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new int[QItems];
            Arr[1 - 1] = GetIntVal();
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new bool[QItems];
            Arr[1 - 1] = GetBoolVal();
        }
        public override void ToStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new string[QItems];
            Arr[1 - 1] = ToString();
        }
    }//cl
    public class TCellInt : TDataCell
    {
        int val;
        public TCellInt() { val = 0; }
        public TCellInt(double val) { SetByValDouble(val); }
        public TCellInt(float val) { SetByValFloat(val); }
        public TCellInt(int val) { SetByValInt(val); }
        public TCellInt(bool val) { SetByValBool(val); }
        public TCellInt(string val) { SetByValString(val); }
        //
        public TCellInt(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellInt(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellInt(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellInt(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellInt(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override int GetTypeN() { return TableConsts.IntTypeN; }
        public override int GetActiveN() { return 1; }
        public override void SetActiveN(int N) { }
        public override int GetLength() { return 1; }
        public override void SetLength(int L) { }
        //
        public override double GetDoubleVal()
        {
            //float r;
            //r = (float)val;
            //return r;
            return (double)val;
        }
        public override float GetFloatVal()
        {
            //float r;
            //r = (float)val;
            //return r;
            return (float)val;
        }
        public override int GetIntVal()
        {
            return val;
        }
        public override bool GetBoolVal()
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToString() { return val.ToString(); }
        //
        public override double GetDoubleValN(int N) { return (double)val; }
        public override float GetFloatValN(int N) { return (float)val; }
        public override int GetIntValN(int N){ return val; }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) { return val.ToString(); }
        //
        public override void SetByValDouble(double val) { this.val = (int)val; }
        public override void SetByValFloat(float val) { this.val = (int)val; }
        public override void SetByValInt(int val) { this.val = (int)val; }
        public override void SetByValBool(bool val)
        {
            this.val =  MyLib.BoolToInt(val);
        }
        public override void SetByValString(string val)
        {
            this.val = Convert.ToInt32(val);
        }
        //
        public override void SetByValDoubleN(double val, int N) { SetByValDouble(val); }
        public override void SetByValFloatN(float val, int N) { SetByValFloat(val); }
        public override void SetByValIntN(int val, int N) { SetByValInt(val); }
        public override void SetByValBoolN(bool val, int N) { SetByValBool(val); }
        public override void SetByValStringN(string val, int N) { SetByValString(val); }
        //
        public override void SetVal(double val) { this.val = (int)val; }
        public override void SetVal(int val) { this.val = (int)val; }
        public override void SetVal(bool val)
        {
            this.val = MyLib.BoolToInt(val);
        }
        public override void SetVal(string val)
        {
            this.val = Convert.ToInt32(val);
        }
        //
        public override void SetValN(double val, int N) { SetVal(val); }
        public override void SetValN(int val, int N) { SetVal(val); }
        public override void SetValN(bool val, int N) { SetVal(val); }
        public override void SetValN(string val, int N) { SetVal(val); }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            if (val != null) SetByValFloat(val[1 - 1]);
            else SetByValFloat(0);
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArrString(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            this.val = (int)Math.Round(val);
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            this.val = (int)Math.Round(val);
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            this.val = val;
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            this.val = MyLib.BoolToInt(val);
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            this.val = Convert.ToInt32(val);
        }
        //
        public override void DelValN(int N) { }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new double[QItems];
            Arr[1 - 1] = GetDoubleVal();
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new float[QItems];
            Arr[1 - 1] = GetFloatVal();
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new int[QItems];
            Arr[1 - 1] = GetIntVal();
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new bool[QItems];
            Arr[1 - 1] = GetBoolVal();
        }
        public override void ToStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new string[QItems];
            Arr[1 - 1] = ToString();
        }
    }//cl
    public class TCellBool : TDataCell
    {
        bool val;
        public TCellBool() { val = false; }
        public TCellBool(double val) { SetByValDouble(val); }
        public TCellBool(float val) { SetByValFloat(val); }
        public TCellBool(int val) { SetByValInt(val); }
        public TCellBool(bool val) { SetByValBool(val); }
        public TCellBool(string val) { SetByValString(val); }
        //
        public TCellBool(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellBool(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellBool(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellBool(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellBool(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override int GetTypeN() { return TableConsts.BoolTypeN; }
        public override int GetActiveN() { return 1; }
        public override void SetActiveN(int N) { }
        public override int GetLength() { return 1; }
        public override void SetLength(int L) { }
        //
        public override double GetDoubleVal()
        {
            int i;
            i=MyLib.BoolToInt(val);
            return (double)i;
        }
        public override float GetFloatVal()
        {
            int i;
            i = MyLib.BoolToInt(val);
            return (float)i;
        }
        public override int GetIntVal()
        {
            int i;
            i = MyLib.BoolToInt(val);
            return i;
        }
        public override bool GetBoolVal()
        {
            return val;
        }
        public override string ToString() {
            int i;
            i = MyLib.BoolToInt(val);
            return i.ToString();
        }
        //
        public override double GetDoubleValN(int N) {
            double r;
            r = GetDoubleVal();
            return r;
        }
        public override float GetFloatValN(int N)
        {
            float r;
            r = GetFloatVal();
            return r;
        }
        public override int GetIntValN(int N)
        {
            int r;
            r = GetIntVal();
            return r;
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            r = GetBoolVal();
            return r;
        }
        public override string ToStringN(int N) {
            string r;
            r = ToString();
            return r;
        }
        //
        public override void SetByValDouble(double val) {
            int i;
            i = (int)val;
            this.val = MyLib.IntToBool(i);
        }
        public override void SetByValFloat(float val)
        {
            int i;
            i = (int)val;
            this.val = MyLib.IntToBool(i);
        }
        public override void SetByValInt(int val) {
            this.val =  MyLib.IntToBool(val);
        }
        public override void SetByValBool(bool val)
        {
            this.val = val;
        }
        public override void SetByValString(string val)
        {
            int i;
            i=Convert.ToInt32(val);
            this.val = MyLib.IntToBool(i); 
        }
        //
        public override void SetByValDoubleN(double val, int N) { SetByValDouble(val); }
        public override void SetByValFloatN(float val, int N) { SetByValFloat(val); }
        public override void SetByValIntN(int val, int N) { SetByValInt(val); }
        public override void SetByValBoolN(bool val, int N) { SetByValBool(val); }
        public override void SetByValStringN(string val, int N) { SetByValString(val); }
        //
        public override void SetVal(double val)
        {
            int i;
            i = (int)val;
            this.val = MyLib.IntToBool(i);
        }
        public override void SetVal(int val)
        {
            this.val = MyLib.IntToBool(val);
        }
        public override void SetVal(bool val)
        {
            this.val = val;
        }
        public override void SetVal(string val)
        {
            int i;
            i=Convert.ToInt32(val);
            this.val = MyLib.IntToBool(i); 
        }
        //
        public override void SetValN(double val, int N) { SetVal(val); }
        public override void SetValN(int val, int N) { SetVal(val); }
        public override void SetValN(bool val, int N) { SetVal(val); }
        public override void SetValN(string val, int N) { SetVal(val); }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            if (val != null) SetByValFloat(val[1 - 1]);
            else SetByValFloat(0);
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArrString(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            this.val = MyLib.IntToBool((int)Math.Round(val));
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            this.val = MyLib.IntToBool((int)Math.Round(val));
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            this.val = MyLib.IntToBool(val);
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            this.val = val;
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            this.val = MyLib.IntToBool(Convert.ToInt32(val));
        }
        //
        public override void DelValN(int N) { }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new double[QItems];
            Arr[1 - 1] = GetDoubleVal();
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new float[QItems];
            Arr[1 - 1] = GetFloatVal();
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new int[QItems];
            Arr[1 - 1] = GetIntVal();
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new bool[QItems];
            Arr[1 - 1] = GetBoolVal();
        }
        public override void ToStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new string[QItems];
            Arr[1 - 1] = ToString();
        }
    }//cl
    public class TCellString : TDataCell
    {
        string val;
        public TCellString() { val = ""; }
        public TCellString(double val) { SetByValDouble(val); }
        public TCellString(float val) { SetByValFloat(val); }
        public TCellString(int val) { SetByValInt(val); }
        public TCellString(bool val) { SetByValBool(val); }
        public TCellString(string val) { SetByValString(val); }
        //
        public TCellString(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellString(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellString(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellString(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellString(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override int GetTypeN() { return TableConsts.StringTypeN; }
        public override int GetActiveN() { return 1; }
        public override void SetActiveN(int N) { }
        public override int GetLength() { return 1; }
        public override void SetLength(int L) { }
        //
        public override double GetDoubleVal()
        {
            double n;
            n = NumberParse.StrToFloat(val);
            return n;
        }
        public override float GetFloatVal()
        {
            float n;
            n = (float)NumberParse.StrToFloat(val);
            return n;
        }
        public override int GetIntVal()
        {
            int n;
            n = (int)NumberParse.StrToFloat(val);
            return n;
        }
        public override bool GetBoolVal()
        {
            bool b;
            int n;
            n = (int)NumberParse.StrToFloat(val);
            b = MyLib.IntToBool(n);
            return b;
        }
        public override string ToString()
        {
            return val;
        }
        //
        public override double GetDoubleValN(int N)
        {
            double r;
            r = GetDoubleVal();
            return r;
        }
        public override float GetFloatValN(int N)
        {
            float r;
            r = GetFloatVal();
            return r;
        }
        public override int GetIntValN(int N)
        {
            int r;
            r = GetIntVal();
            return r;
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            r = GetBoolVal();
            return r;
        }
        public override string ToStringN(int N)
        {
            string r;
            r = ToString();
            return r;
        }
        //
        public override void SetByValDouble(double val)
        {
             this.val = val.ToString();
        }
        public override void SetByValFloat(float val)
        {
            this.val = val.ToString();
        }
        public override void SetByValInt(int val)
        {
            this.val = val.ToString();
        }
        public override void SetByValBool(bool val)
        {
            int n= MyLib.BoolToInt(val);
            this.val =n.ToString();
        }
        public override void SetByValString(string val)
        {
            this.val = val;
        }
        //
        public override void SetByValDoubleN(double val, int N) { SetByValDouble(val); }
        public override void SetByValFloatN(float val, int N) { SetByValFloat(val); }
        public override void SetByValIntN(int val, int N) { SetByValInt(val); }
        public override void SetByValBoolN(bool val, int N) { SetByValBool(val); }
        public override void SetByValStringN(string val, int N) { SetByValString(val); }
        //
        public override void SetVal(double val)
        {
            this.val = val.ToString();
        }
        public override void SetVal(int val)
        {
            this.val = val.ToString();
        }
        public override void SetVal(bool val)
        {
            int n = MyLib.BoolToInt(val);
            this.val = n.ToString();
        }
        public override void SetVal(string val)
        {
            this.val = val;
        }
        //
        public override void SetValN(double val, int N) { SetVal(val); }
        public override void SetValN(int val, int N) { SetVal(val); }
        public override void SetValN(bool val, int N) { SetVal(val); }
        public override void SetValN(string val, int N) { SetVal(val); }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            if (val != null) SetByValFloat(val[1 - 1]);
            else SetByValFloat(0);
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArrString(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            if (val != null) SetByValDouble(val[1 - 1]);
            else SetByValDouble(0);
        }
        public override void SetByArr(int[] val, int Q)
        {
            if (val != null) SetByValInt(val[1 - 1]);
            else SetByValInt(0);
        }
        public override void SetByArr(bool[] val, int Q)
        {
            if (val != null) SetByValBool(val[1 - 1]);
            else SetByValBool(MyLib.BoolValByDefault);
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            this.val = val.ToString();
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            this.val = val.ToString();
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            this.val = val.ToString();
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            this.val = (MyLib.BoolToInt(val)).ToString();
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            this.val = val;
        }
        //
        public override void DelValN(int N) { }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new double[QItems];
            Arr[1 - 1] = GetDoubleVal();
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new float[QItems];
            Arr[1 - 1] = GetFloatVal();
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new int[QItems];
            Arr[1 - 1] = GetIntVal();
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new bool[QItems];
            Arr[1 - 1] = GetBoolVal();
        }
        public override void ToStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new string[QItems];
            Arr[1 - 1] = ToString();
        }
    }//cl
    //
    public class TCellUniqueNumKeeper : TDataCell
    {
        int val;
        //public TCellUniqueNumKeeper() { val = 0; }
        //public TCellUniqueNumKeeper(double val) { SetByValDouble(val); }
        //public TCellUniqueNumKeeper(float val) { SetByValFloat(val); }
        public TCellUniqueNumKeeper(int val) { this.val=val; }
        //public TCellUniqueNumKeeper(bool val) { SetByValBool(val); }
        //public TCellUniqueNumKeeper(string val) { SetByValString(val); }
        //
        //public TCellUniqueNumKeeper(double[] val, int Q) { SetByArrDouble(val, Q); }
        //public TCellUniqueNumKeeper(float[] val, int Q) { SetByArrFloat(val, Q); }
        //public TCellUniqueNumKeeper(int[] val, int Q) { SetByArrInt(val, Q); }
        //public TCellUniqueNumKeeper(bool[] val, int Q) { SetByArrBool(val, Q); }
        //public TCellUniqueNumKeeper(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override int GetTypeN() { return TableConsts.UniqueIntValKeeperTypeN; }
        public override int GetActiveN() { return 1; }
        public override void SetActiveN(int N) { }
        public override int GetLength() { return 1; }
        public override void SetLength(int L) { }
        //
        public override double GetDoubleVal()
        {
            //float r;
            //r = (float)val;
            //return r;
            return (double)val;
        }
        public override float GetFloatVal()
        {
            //float r;
            //r = (float)val;
            //return r;
            return (float)val;
        }
        public override int GetIntVal()
        {
            return val;
        }
        public override bool GetBoolVal()
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToString() { return val.ToString(); }
        //
        public override double GetDoubleValN(int N) { return (double)val; }
        public override float GetFloatValN(int N) { return (float)val; }
        public override int GetIntValN(int N) { return val; }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) { return val.ToString(); }
        //
        public override void SetByValDouble(double val) { }
        public override void SetByValFloat(float val) {  }
        public override void SetByValInt(int val) {  }
        public override void SetByValBool(bool val){  }
        public override void SetByValString(string val){ }
        //
        public override void SetByValDoubleN(double val, int N) { }
        public override void SetByValFloatN(float val, int N) {  }
        public override void SetByValIntN(int val, int N) { }
        public override void SetByValBoolN(bool val, int N) { }
        public override void SetByValStringN(string val, int N) { }
        //
        public override void SetVal(double val) {  }
        public override void SetVal(int val) { }
        public override void SetVal(bool val){ }
        public override void SetVal(string val){ }
        //
        public override void SetValN(double val, int N) {  }
        public override void SetValN(int val, int N) { }
        public override void SetValN(bool val, int N) { }
        public override void SetValN(string val, int N) {  }
        //
        public override void SetByArrDouble(double[] val, int Q){  }
        public override void SetByArrFloat(float[] val, int Q){ }
        public override void SetByArrInt(int[] val, int Q){ }
        public override void SetByArrBool(bool[] val, int Q){ }
        public override void SetByArrString(string[] val, int Q){ }
        //
        public override void SetByArr(double[] val, int Q){ }
        public override void SetByArr(int[] val, int Q){ }
        public override void SetByArr(bool[] val, int Q){ }
        public override void SetByArr(string[] val, int Q){ }
        //
        public override void AddOrInsDoubleVal(double val, int N){  }
        public override void AddOrInsFloatVal(float val, int N){ }
        public override void AddOrInsIntVal(int val, int N){ }
        public override void AddOrInsBoolVal(bool val, int N){ }
        public override void AddOrInsStringVal(string val, int N) { }
        //
        public override void DelValN(int N) { }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new double[QItems];
            Arr[1 - 1] = GetDoubleVal();
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new float[QItems];
            Arr[1 - 1] = GetFloatVal();
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new int[QItems];
            Arr[1 - 1] = GetIntVal();
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new bool[QItems];
            Arr[1 - 1] = GetBoolVal();
        }
        public override void ToStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = 1;
            Arr = new string[QItems];
            Arr[1 - 1] = ToString();
        }
    }//cl
    //
    public class TCellDoubleMemo : TDataCell
    {
        double[] val;
        int QVals, ActiveValN;
        public TCellDoubleMemo() {
            val = new double[1];
            val[1 - 1] = 0;
            QVals = 1;
            ActiveValN = 1;
        }
        public TCellDoubleMemo(double val) { SetByValDouble(val); }
        public TCellDoubleMemo(float val) { SetByValFloat(val); }
        public TCellDoubleMemo(int val) { SetByValInt(val); }
        public TCellDoubleMemo(bool val) { SetByValBool(val); }
        public TCellDoubleMemo(string val) { SetByValString(val); }
        //
        public TCellDoubleMemo(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellDoubleMemo(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellDoubleMemo(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellDoubleMemo(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellDoubleMemo(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override int GetTypeN() { return TableConsts.DoubleArrayTypeN; }
        public override int GetLength() { return QVals; }
        public override void SetLength(int L)
        {
            MyLib.ResizeVector<double>(ref val, QVals, L, 1);
            if (L > QVals) for (int i = QVals; i <= L; i++) val[i - 1] = 0;
            QVals = L;
        }
        public override int GetActiveN() { return ActiveValN; }
        public override void SetActiveN(int N) { this.ActiveValN = N; }
        //
        public override double GetDoubleVal() {
            //return val[1-1];
            return val[ActiveValN - 1];
        }
        public override float GetFloatVal()
        {
            float r;
            r = (float)val[ActiveValN - 1];
            return r;
        }
        public override int GetIntVal()
        {
            int r;
            r = (int)Math.Round(val[ActiveValN - 1]);
            return r;
        }
        public override bool GetBoolVal()
        {
            bool r;
            if (val[ActiveValN - 1] == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToString() { return val[ActiveValN - 1].ToString(); }
        //
        public override double GetDoubleValN(int N) { return val[N - 1]; }
        public override float GetFloatValN(int N) { return (float)val[N - 1]; }
        public override int GetIntValN(int N)
        {
            int r;
            r = (int)Math.Round(val[N - 1]);
            return r;
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val[N - 1] == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) { return val[N-1].ToString(); }
        //
        public override void SetByValDouble(double val) { this.val[ActiveValN - 1] = (double)val; }
        public override void SetByValFloat(float val) { this.val[ActiveValN - 1] = (double)val; }
        public override void SetByValInt(int val) { this.val[ActiveValN - 1] = (double)val; }
        public override void SetByValBool(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = (double)i;
        }
        public override void SetByValString(string val) { this.val[ActiveValN - 1] = Convert.ToDouble(val); }
        //
        public override void SetByValDoubleN(double val, int N) { this.val[N - 1] = val; }
        public override void SetByValFloatN(float val, int N) { this.val[N - 1] = (double)val; }
        public override void SetByValIntN(int val, int N) { this.val[N - 1] = (double)val; }
        public override void SetByValBoolN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = (double)i;
        }
        public override void SetByValStringN(string val, int N) { this.val[N - 1] = Convert.ToDouble(val); }
        //
        public override void SetVal(double val) { this.val[ActiveValN - 1] = val; }
        public override void SetVal(int val) { this.val[ActiveValN - 1] = (double)val; }
        public override void SetVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = (double)i;
        }
        public override void SetVal(string val) { this.val[ActiveValN - 1] = Convert.ToDouble(val); }
        //
        public override void SetValN(double val, int N) { this.val[N - 1] = val; }
        public override void SetValN(int val, int N) { this.val[N - 1] = (double)val; }
        public override void SetValN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = (double)i;
        }
        public override void SetValN(string val, int N) { this.val[N - 1] = Convert.ToDouble(val); }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            this.val = new double[Q];
            if(val!=null){
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }else{
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(0, i); }
            }
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArrString(string[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new double[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            if (val != null) SetByValString(val[1 - 1]);
            else SetByValString("");
        }
        //
        public override void AddOrInsDoubleVal(double val, int N){
            if(N<1 && N>this.GetLength()){
                MyLib.InsToVector(ref this.val, ref this.QVals, val, N);
            }else{
                MyLib.AddToVector(ref this.val, ref this.QVals, val);
            }
        }
        public override void AddOrInsFloatVal(float val, int N){
            if(N<1 && N>this.GetLength()){
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)val, N);
            }else{
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)val);
            }
        }
        public override void AddOrInsIntVal(int val, int N){
            if(N<1 && N>this.GetLength()){
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)val, N);
            }else{
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)val);
            }
        }
        public override void AddOrInsBoolVal(bool val, int N){
            if(N<1 && N>this.GetLength()){
                MyLib.InsToVector(ref this.val, ref this.QVals, (double)MyLib.BoolToInt(val), N);
            }else{
                MyLib.AddToVector(ref this.val, ref this.QVals, (double)MyLib.BoolToInt(val));
            }
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, Convert.ToDouble(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, Convert.ToDouble(val));
            }
        }
        //
        public override void DelValN(int N) {
            MyLib.DelInVector(ref val, ref QVals, N);       
        }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new double[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetDoubleVal();
            }
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = GetTypeN(); 
            Arr = new float[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetFloatVal();
            }
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new int[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetIntVal();
            }
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new bool[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetBoolVal();
            }
        }
        public override void ToStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = GetTypeN(); 
            Arr = new string[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = ToString();
            }
        }
    }//cl
    public class TCellFloatMemo : TDataCell
    {
        float[] val;
        int QVals, ActiveValN;
        public TCellFloatMemo()
        {
            val = new float[1];
            val[1 - 1] = 0;
            QVals = 1;
            ActiveValN = 1;
        }
        public TCellFloatMemo(double val) { SetByValDouble(val); }
        public TCellFloatMemo(float val) { SetByValFloat(val); }
        public TCellFloatMemo(int val) { SetByValInt(val); }
        public TCellFloatMemo(bool val) { SetByValBool(val); }
        public TCellFloatMemo(string val) { SetByValString(val); }
        //
        public TCellFloatMemo(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellFloatMemo(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellFloatMemo(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellFloatMemo(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellFloatMemo(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override int GetTypeN() { return TableConsts.FloatArrayTypeN; }
        public override int GetLength() { return QVals; }
        public override void SetLength(int L)
        {
            MyLib.ResizeVector<float>(ref val, QVals, L, 1);
            if (L > QVals) for (int i = QVals; i <= L; i++) val[i - 1] = 0;
            QVals = L;
        }
        public override int GetActiveN() { return ActiveValN; }
        public override void SetActiveN(int N) { this.ActiveValN = N; }
        //
        public override double GetDoubleVal()
        {
            return (double)val[ActiveValN - 1];
        }
        public override float GetFloatVal()
        {
            return val[ActiveValN - 1]; ;
        }
        public override int GetIntVal()
        {
            int r;
            r = (int)Math.Round(val[ActiveValN - 1]);
            return r;
        }
        public override bool GetBoolVal()
        {
            bool r;
            if (val[ActiveValN - 1] == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToString() { return val[ActiveValN - 1].ToString(); }
        //
        public override double GetDoubleValN(int N) { return (double)val[N - 1]; }
        public override float GetFloatValN(int N) { return val[N - 1]; }
        public override int GetIntValN(int N)
        {
            int r;
            r = (int)Math.Round(val[N - 1]);
            return r;
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val[N - 1] == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) { return val[N-1].ToString(); }
        //
        public override void SetByValDouble(double val) { this.val[ActiveValN - 1] = (float)val; }
        public override void SetByValFloat(float val) { this.val[ActiveValN - 1] = val; }
        public override void SetByValInt(int val) { this.val[ActiveValN - 1] = (float)val; }
        public override void SetByValBool(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = (float)i;
        }
        public override void SetByValString(string val) {
            double d;
            d = Convert.ToDouble(val);
            this.val[ActiveValN - 1] = (float)d;
        }
        //
        public override void SetByValDoubleN(double val, int N) { this.val[N - 1] = (float)val; }
        public override void SetByValFloatN(float val, int N) { this.val[N - 1] = val; }
        public override void SetByValIntN(int val, int N) { this.val[N - 1] = (float)val; }
        public override void SetByValBoolN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = (float)i;
        }
        public override void SetByValStringN(string val, int N) {
            double d;
            d = Convert.ToDouble(val);
            this.val[N - 1] = (float)d;
        }
        //
        public override void SetVal(double val) { this.val[ActiveValN - 1] = (float)val; }
        public override void SetVal(int val) { this.val[ActiveValN - 1] = val; }
        public override void SetVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = (float)i;
        }
        public override void SetVal(string val) {
            double d;
            d = Convert.ToDouble(val);
            this.val[ActiveValN - 1] = (float)d;
        }
        //
        public override void SetValN(double val, int N) { this.val[N - 1] = (float)val; }
        public override void SetValN(int val, int N) { this.val[N - 1] = val; }
        public override void SetValN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = (float)i;
        }
        public override void SetValN(string val, int N) {
            double d;
            d = Convert.ToDouble(val);
            this.val[N - 1] = (float)d;
        }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(0, i); }
            }
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArrString(string[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new float[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (float)val, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (float)val);
            }
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (float)val, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (float)val);
            }
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (float)val, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (float)val);
            }
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (float)MyLib.BoolToInt(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (float)MyLib.BoolToInt(val));
            }
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (float)Convert.ToDouble(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (float)Convert.ToDouble(val));
            }
        }
        //
        public override void DelValN(int N)
        {
            MyLib.DelInVector(ref val, ref QVals, N);
        }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new double[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetDoubleVal();
            }
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new float[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetFloatVal();
            }
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new int[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetIntVal();
            }
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new bool[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetBoolVal();
            }
        }
        public override void ToStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new string[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = ToString();
            }
        }
    }//cl
    public class TCellIntMemo : TDataCell
    {
        int[] val;
        int QVals, ActiveValN;
        public TCellIntMemo()
        {
            val = new int[1];
            val[1 - 1] = 0;
            QVals = 1;
            ActiveValN = 1;
        }
        public TCellIntMemo(double val) { SetByValDouble(val); }
        public TCellIntMemo(float val) { SetByValFloat(val); }
        public TCellIntMemo(int val) { SetByValInt(val); }
        public TCellIntMemo(bool val) { SetByValBool(val); }
        public TCellIntMemo(string val) { SetByValString(val); }
        //
        public TCellIntMemo(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellIntMemo(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellIntMemo(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellIntMemo(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellIntMemo(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override int GetTypeN() { return TableConsts.IntArrayTypeN; }
        public override int GetLength() { return QVals; }
        public override void SetLength(int L)
        {
            MyLib.ResizeVector<int>(ref val, QVals, L, 1);
            if (L > QVals) for (int i = QVals; i <= L; i++) val[i - 1] = 0;
            QVals = L;
        }
        public override int GetActiveN() { return ActiveValN; }
        public override void SetActiveN(int N) { this.ActiveValN = N; }
        //
        public override double GetDoubleVal()
        {
            //return val[1-1];
            return val[ActiveValN - 1];
        }
        public override float GetFloatVal()
        {
            float r;
            r = (float)val[ActiveValN - 1];
            return r;
        }
        public override int GetIntVal()
        {
            //int r;
            //r = (int)Math.Round(val[ActiveValN - 1]);
            return (int)val[ActiveValN - 1]; ;
        }
        public override bool GetBoolVal()
        {
            bool r;
            if (val[ActiveValN - 1] == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToString() { return val[ActiveValN - 1].ToString(); }
        //
        public override double GetDoubleValN(int N) { return (double)val[N - 1]; }
        public override float GetFloatValN(int N) { return (float)val[N - 1]; }
        public override int GetIntValN(int N)
        {
            return val[N - 1];
        }
        public override bool GetBoolValN(int N)
        {
            bool r;
            if (val[N - 1] == 1) r = true;
            else r = false;
            return r;
        }
        public override string ToStringN(int N) { return val[N-1].ToString(); }
        //
        public override void SetByValDouble(double val) { this.val[ActiveValN - 1] = (int)val; }
        public override void SetByValFloat(float val) { this.val[ActiveValN - 1] = (int)val; }
        public override void SetByValInt(int val) { this.val[ActiveValN - 1] = (int)val; }
        public override void SetByValBool(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = i;
        }
        public override void SetByValString(string val)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[ActiveValN - 1] = d;
        }
        //
        public override void SetByValDoubleN(double val, int N) { this.val[N - 1] = (int)val; }
        public override void SetByValFloatN(float val, int N) { this.val[N - 1] = (int)val; }
        public override void SetByValIntN(int val, int N) { this.val[N - 1] = val; }
        public override void SetByValBoolN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = i;
        }
        public override void SetByValStringN(string val, int N)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[N - 1] = d;
        }
        //
        public override void SetVal(double val) { this.val[ActiveValN - 1] = (int)val; }
        public override void SetVal(int val) { this.val[ActiveValN - 1] = val; }
        public override void SetVal(bool val)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = i;
        }
        public override void SetVal(string val)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[ActiveValN - 1] = d;
        }
        //
        public override void SetValN(double val, int N) { this.val[N - 1] = (int)val; }
        public override void SetValN(int val, int N) { this.val[N - 1] = val; }
        public override void SetValN(bool val, int N)
        {
            int i;
            i = MyLib.BoolToInt(val);
            this.val[N - 1] = i;
        }
        public override void SetValN(string val, int N)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[N - 1] = d;
        }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(0, i); }
            }
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArrString(string[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new int[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (int)Math.Round(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (int)Math.Round(val));
            }
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, (int)Math.Round(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, (int)Math.Round(val));
            }
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val);
            }
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, MyLib.BoolToInt(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, MyLib.BoolToInt(val));
            }
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, Convert.ToInt32(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, Convert.ToInt32(val));
            }
        }
        //
        public override void DelValN(int N)
        {
            MyLib.DelInVector(ref val, ref QVals, N);
        }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new double[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetDoubleVal();
            }
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new float[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetFloatVal();
            }
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new int[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetIntVal();
            }
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new bool[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetBoolVal();
            }
        }
        public override void ToStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new string[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = ToString();
            }
        }
    }//cl
    public class TCellBoolMemo : TDataCell
    {
        bool[] val;
        int QVals, ActiveValN;
        public TCellBoolMemo()
        {
            val = new bool[1];
            val[1 - 1] = false;
            QVals = 1;
            ActiveValN=1;
        }
        public TCellBoolMemo(double val) { SetByValDouble(val); }
        public TCellBoolMemo(float val) { SetByValFloat(val); }
        public TCellBoolMemo(int val) { SetByValInt(val); }
        public TCellBoolMemo(bool val) { SetByValBool(val); }
        public TCellBoolMemo(string val) { SetByValString(val); }
        //
        public TCellBoolMemo(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellBoolMemo(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellBoolMemo(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellBoolMemo(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellBoolMemo(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override int GetTypeN() { return TableConsts.BoolArrayTypeN; }
        public override int GetLength() { return QVals; }
        public override void SetLength(int L)
        {
            MyLib.ResizeVector<bool>(ref val, QVals, L, 1);
            if (L > QVals) for (int i = QVals; i <= L; i++) val[i - 1] = false;
            QVals = L;
        }
        public override int GetActiveN() { return ActiveValN; }
        public override void SetActiveN(int N) { this.ActiveValN = N; }
        //
        public override double GetDoubleVal()
        {
            int d;
            d = MyLib.BoolToInt(val[ActiveValN - 1]);
            return (double)d;
        }
        public override float GetFloatVal()
        {
            int d;
            d = MyLib.BoolToInt(val[ActiveValN - 1]);
            return (float)d;
        }
        public override int GetIntVal()
        {
            int d;
            d = MyLib.BoolToInt(val[ActiveValN - 1]);
            return d;
        }
        public override bool GetBoolVal()
        {
            return val[ActiveValN - 1];
        }
        public override string ToString() {
            int i;
            i = MyLib.BoolToInt(val[ActiveValN - 1]);
            return i.ToString();
        }
        //
        public override double GetDoubleValN(int N) {
            int i;
            i = MyLib.BoolToInt(val[N - 1]);
            return (double)i;
        }
        public override float GetFloatValN(int N)
        {
            int i;
            i = MyLib.BoolToInt(val[N - 1]);
            return (float)i;
        }
        public override int GetIntValN(int N)
        {
            int i;
            i = MyLib.BoolToInt(val[N - 1]);
            return i;
        }
        public override bool GetBoolValN(int N)
        {
            return val[N - 1];
        }
        public override string ToStringN(int N)
        {
            int i;
            i = MyLib.BoolToInt(val[N - 1]);
            return i.ToString();
        }
        //
        public override void SetByValDouble(double val) {
            this.val[ActiveValN - 1] = MyLib.IntToBool((int)val);
        }
        public override void SetByValFloat(float val) { this.val[ActiveValN - 1] = MyLib.IntToBool((int)val); }
        public override void SetByValInt(int val) { this.val[ActiveValN - 1] =  MyLib.IntToBool((int)val); }
        public override void SetByValBool(bool val)
        {
            this.val[ActiveValN - 1] = val;
        }
        public override void SetByValString(string val)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[ActiveValN - 1] = MyLib.IntToBool(d);
        }
        //
        public override void SetByValDoubleN(double val, int N) {
            this.val[N - 1] =  MyLib.IntToBool((int)val);
        }
        public override void SetByValFloatN(float val, int N) {
            this.val[N - 1] =  MyLib.IntToBool((int)val);
        }
        public override void SetByValIntN(int val, int N)
        {
            this.val[N - 1] =  MyLib.IntToBool(val);
        }
        public override void SetByValBoolN(bool val, int N)
        {
            this.val[N - 1] = val;
        }
        public override void SetByValStringN(string val, int N)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[N - 1] = MyLib.IntToBool(d);
        }
        //
        public override void SetVal(double val) { this.val[ActiveValN - 1] = MyLib.IntToBool((int)val); }
        public override void SetVal(int val) { this.val[ActiveValN - 1] = MyLib.IntToBool(val); }
        public override void SetVal(bool val)
        {
            this.val[ActiveValN - 1] = val;
        }
        public override void SetVal(string val)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[ActiveValN - 1] = MyLib.IntToBool(d);
        }
        //
        public override void SetValN(double val, int N) { this.val[N - 1] = MyLib.IntToBool((int)val); }
        public override void SetValN(int val, int N) { this.val[N - 1] = MyLib.IntToBool(val); }
        public override void SetValN(bool val, int N)
        {
            this.val[N - 1] = val;
        }
        public override void SetValN(string val, int N)
        {
            int d;
            d = Convert.ToInt32(val);
            this.val[N - 1] = MyLib.IntToBool(d);
        }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(0, i); }
            }
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArrString(string[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new bool[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, MyLib.IntToBool((int)Math.Round(val)), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, MyLib.IntToBool((int)Math.Round(val)));
            }
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, MyLib.IntToBool((int)Math.Round(val)), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, MyLib.IntToBool((int)Math.Round(val)));
            }
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, MyLib.IntToBool(val), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, MyLib.IntToBool(val));
            }
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val, N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val);
            }
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, MyLib.IntToBool(Convert.ToInt32(val)), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, MyLib.IntToBool(Convert.ToInt32(val)));
            }
        }
        //
        public override void DelValN(int N)
        {
            MyLib.DelInVector(ref val, ref QVals, N);
        }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new double[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetDoubleVal();
            }
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new float[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetFloatVal();
            }
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new int[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetIntVal();
            }
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new bool[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetBoolVal();
            }
        }
        public override void ToStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new string[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = ToString();
            }
        }
    }//cl
    public class TCellStringMemo : TDataCell
    {
        string[] val;
        int QVals, ActiveValN;
        public TCellStringMemo()
        {
            val = new string[1];
            val[1 - 1] = "";
            QVals = 1;
            ActiveValN = 1;
        }
        public TCellStringMemo(double val) { SetByValDouble(val); }
        public TCellStringMemo(float val) { SetByValFloat(val); }
        public TCellStringMemo(int val) { SetByValInt(val); }
        public TCellStringMemo(bool val) { SetByValBool(val); }
        public TCellStringMemo(string val) { SetByValString(val); }
        //
        public TCellStringMemo(double[] val, int Q) { SetByArrDouble(val, Q); }
        public TCellStringMemo(float[] val, int Q) { SetByArrFloat(val, Q); }
        public TCellStringMemo(int[] val, int Q) { SetByArrInt(val, Q); }
        public TCellStringMemo(bool[] val, int Q) { SetByArrBool(val, Q); }
        public TCellStringMemo(string[] val, int Q) { SetByArrString(val, Q); }
        //
        public override int GetTypeN() { return TableConsts.StringArrayTypeN; }
        public override int GetLength() { return QVals; }
        public override void SetLength(int L)
        {
            MyLib.ResizeVector<string>(ref val, QVals, L, 1);
            if (L > QVals) for (int i = QVals; i <= L; i++) val[i - 1] = "";
            QVals = L;
        }
        public override int GetActiveN() { return ActiveValN; }
        public override void SetActiveN(int N) { this.ActiveValN = N; }
        //
        public override double GetDoubleVal()
        {
            return NumberParse.StrToFloat(val[ActiveValN - 1]);
        }
        public override float GetFloatVal()
        {
            return (float)(NumberParse.StrToFloat(val[ActiveValN - 1]));
        }
        public override int GetIntVal()
        {
            double d, d1; 
            d = NumberParse.StrToFloat(val[ActiveValN - 1]);
            d1 = Math.Round(d);
            return (int)d1;
        }
        public override bool GetBoolVal()
        {
            return MyLib.StrToBool(val[ActiveValN - 1]);
        }
        public override string ToString()
        {
            return val[ActiveValN - 1];
        }
        //
        public override double GetDoubleValN(int N)
        {
            return NumberParse.StrToFloat(val[N - 1]);
        }
        public override float GetFloatValN(int N)
        {
            return (float)(NumberParse.StrToFloat(val[N - 1]));
        }
        public override int GetIntValN(int N)
        {
            double d, d1;
            d = NumberParse.StrToFloat(val[N - 1]);
            d1 = Math.Round(d);
            return (int)d1;
        }
        public override bool GetBoolValN(int N)
        {
            return MyLib.StrToBool(val[N - 1]);
        }
        public override string ToStringN(int N)
        {
            return val[N - 1];
        }
        //
        public override void SetByValDouble(double val){ this.val[ActiveValN - 1] = val.ToString(); }
        public override void SetByValFloat(float val) { this.val[ActiveValN - 1] = val.ToString(); }
        public override void SetByValInt(int val) { this.val[ActiveValN - 1] = val.ToString(); }
        public override void SetByValBool(bool val) { this.val[ActiveValN - 1] = MyLib.BoolToStr(val, "1", "0"); }
        public override void SetByValString(string val){this.val[ActiveValN - 1] = val;}
        //
        public override void SetByValDoubleN(double val, int N)
        {
            this.val[N - 1] = val.ToString();
        }
        public override void SetByValFloatN(float val, int N)
        {
            this.val[N - 1] = val.ToString();
        }
        public override void SetByValIntN(int val, int N)
        {
            this.val[N - 1] = val.ToString();
        }
        public override void SetByValBoolN(bool val, int N)
        {
            int n;
            n=MyLib.BoolToInt(val);
            this.val[N - 1] = n.ToString();
        }
        public override void SetByValStringN(string val, int N)
        {
            this.val[N - 1] = val;
        }
        //
        public override void SetVal(double val) { this.val[ActiveValN - 1] = val.ToString(); }
        public override void SetVal(int val) { this.val[ActiveValN - 1] = val.ToString(); }
        public override void SetVal(bool val)
        {
            int n;
            n = MyLib.BoolToInt(val);
            this.val[ActiveValN - 1] = n.ToString();
        }
        public override void SetVal(string val)
        {
            this.val[ActiveValN - 1] = val;
        }
        //
        public override void SetValN(double val, int N) { this.val[N - 1] = val.ToString(); }
        public override void SetValN(int val, int N) { this.val[ActiveValN - 1] = val.ToString(); }
        public override void SetValN(bool val, int N)
        {
            int n;
            n = MyLib.BoolToInt(val);
            this.val[N - 1] = n.ToString();
        }
        public override void SetValN(string val, int N){ this.val[N - 1] = val; }
        //
        public override void SetByArrDouble(double[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArrFloat(float[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValFloatN(0, i); }
            }
        }
        public override void SetByArrInt(int[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArrBool(bool[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArrString(string[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void SetByArr(double[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValDoubleN(0, i); }
            }
        }
        public override void SetByArr(int[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValIntN(0, i); }
            }
        }
        public override void SetByArr(bool[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValBoolN(MyLib.BoolValByDefault, i); }
            }
        }
        public override void SetByArr(string[] val, int Q)
        {
            this.val = new string[Q];
            if (val != null)
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN(val[i - 1], i); }
            }
            else
            {
                for (int i = 1; i <= Q; i++) { SetByValStringN("", i); }
            }
        }
        //
        public override void AddOrInsDoubleVal(double val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val.ToString(), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val.ToString());
            }
        }
        public override void AddOrInsFloatVal(float val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val.ToString(), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val.ToString());
            }
        }
        public override void AddOrInsIntVal(int val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val.ToString(), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val.ToString());
            }
        }
        public override void AddOrInsBoolVal(bool val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val.ToString(), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val.ToString());
            }
        }
        public override void AddOrInsStringVal(string val, int N)
        {
            if (N >= 1 && N <= this.GetLength())
            {
                MyLib.InsToVector(ref this.val, ref this.QVals, val.ToString(), N);
            }
            else
            {
                MyLib.AddToVector(ref this.val, ref this.QVals, val.ToString());
            }
        }
        //
        public override void DelValN(int N)
        {
            MyLib.DelInVector(ref val, ref QVals, N);
        }
        //
        public override void GetDoubleArr(ref double[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new double[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[i - 1] = GetDoubleVal();
            }
        }
        public override void GetFloatArr(ref float[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new float[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetFloatVal();
            }
        }
        public override void GetIntArr(ref int[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new int[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetIntVal();
            }
        }
        public override void GetBoolArr(ref bool[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new bool[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = GetBoolVal();
            }
        }
        public override void ToStringArr(ref string[] Arr, ref int QItems)
        {
            QItems = GetTypeN();
            Arr = new string[QItems];
            for (int i = 1; i <= QItems; i++)
            {
                Arr[1 - 1] = ToString();
            }
        }
    }//cl
    //
    //
    public class DataCell
    {
        TDataCell cell;
        public DataCell() { 
            cell = null;
            SetDefault0();
        }
        
        public DataCell(double val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeDouble(val);
        }
        public DataCell(float val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeFloat(val);
        }
        public DataCell(int val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeInt(val);
        }
        public DataCell(bool val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeBool(val);
        }
        public DataCell(string val)
        {
            cell = null;
            SetDefault0();
            SetValAndTypeString(val);
        }
        public DataCell(double[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeDouble(arr, Length);
        }
        public DataCell(float[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeFloat(arr, Length);
        }
        public DataCell(int[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeInt(arr, Length);
        }
        public DataCell(bool[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeBool(arr, Length);
        }
        public DataCell(string[] arr, int Length)
        {
            cell = null;
            SetDefault0();
            SetArrAndTypeString(arr, Length);
        }
        public DataCell(int val, bool ConstNotVar)
        {
            cell = null;
            SetDefault0();
            if (ConstNotVar)
            {
                cell = new TCellUniqueNumKeeper(val);
            }
            else
            {
                SetValAndTypeInt(val);
            }
        }
        public DataCell(int TypeN, int N)
        {
            double DoubleVal = 0;
            float FloatVal = 0;
            int IntVal = 0;
            bool BoolVal = MyLib.BoolValByDefault;
            string StringVal = "";
            double []DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            cell = null;
            SetDefault0();
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    cell = new TCellDouble();
                break;
                case TableConsts.FloatTypeN:
                    cell = new TCellFloat();
                break;
                case TableConsts.IntTypeN:
                    cell = new TCellInt();
                break;
                case TableConsts.BoolTypeN:
                    cell = new TCellBool();
                break;
                case TableConsts.StringTypeN:
                    cell = new TCellString();
                break;
                case TableConsts.DoubleArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    DoubleArr = new double[N];
                    for (int i = 1; i <= N; i++) DoubleArr[i - 1] = 0;
                    cell = new TCellDoubleMemo(DoubleArr, N);
                break;
                case TableConsts.FloatArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    FloatArr = new float[N];
                    for (int i = 1; i <= N; i++) FloatArr[i - 1] = 0;
                    cell = new TCellFloatMemo(FloatArr, N);
                break;
                case TableConsts.IntArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    IntArr = new int[N];
                    for (int i = 1; i <= N; i++) IntArr[i - 1] = 0;
                    cell = new TCellFloatMemo(IntArr, N);
                break;
                case TableConsts.BoolArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    BoolArr = new bool[N];
                    for (int i = 1; i <= N; i++) BoolArr[i - 1] = MyLib.BoolValByDefault;
                    cell = new TCellBoolMemo(IntArr, N);
                break;
                case TableConsts.StringArrayTypeN:
                    if (N < 1 || N > MyLib.MaxInt) N = 1;
                    StringArr = new string[N];
                    for (int i = 1; i <= N; i++) StringArr[i - 1] = "";
                    cell = new TCellStringMemo(StringArr, N);
                break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    cell = new TCellUniqueNumKeeper(N);
                break;
            }
            SetActiveN(1);
        }
        //
       public void SetDefault0()
        {
            int TypeN = TableConsts.DefaultAnyCellTypeN;
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    cell = new TCellDouble();
                break;
                case TableConsts.FloatTypeN:
                    cell = new TCellFloat();
                break;
                case TableConsts.IntTypeN:
                    cell = new TCellInt();
                break;
                case TableConsts.BoolTypeN:
                    cell = new TCellBool();
                break;
                case TableConsts.StringTypeN:
                    cell = new TCellString();
                break;
                case TableConsts.DoubleArrayTypeN:
                    cell = new TCellDoubleMemo();
                break;
                case TableConsts.FloatArrayTypeN:
                    cell = new TCellFloatMemo();
                break;
                case TableConsts.IntArrayTypeN:
                    cell = new TCellIntMemo();
                break;
                case TableConsts.BoolArrayTypeN:
                    cell = new TCellBoolMemo();
                break;
                case TableConsts.StringArrayTypeN:
                    cell = new TCellStringMemo();
                break;
            }//swch
            SetActiveN(1);
        }//fn
        //
        public TDataCell GetCell() { return this.cell; }
        //
        public double GetDoubleVal()
        {
            return cell.GetDoubleVal();
        }
        public float GetFloatVal()
        {
            return cell.GetFloatVal();
        }
        public int GetIntVal()
        {
            return cell.GetIntVal();
        }
        public bool GetBoolVal()
        {
            return cell.GetBoolVal();
        }
        public override string ToString()
        {
            return cell.ToString();
        }
        //
        public void GetDoubleArr(ref double[] vals, ref int count)
        {
            cell.GetDoubleArr(ref vals, ref count);
        }
        public void GetFloatArr(ref float[] vals, ref int count)
        {
            cell.GetFloatArr(ref vals, ref count);
        }
        public void GetIntArr(ref int[] vals, ref int count)
        {
            cell.GetIntArr(ref vals, ref count);
        }
        public void GetBoolArr(ref bool[] vals, ref int count)
        {
            cell.GetBoolArr(ref vals, ref count);
        }
        public void ToStringArr(ref string[] vals, ref int count)
        {
            cell.ToStringArr(ref vals, ref count);
        }
        //
        public double GetDoubleValN(int N)
        {
            return cell.GetDoubleValN(N);
        }
        public float GetFloatValN(int N)
        {
            return cell.GetFloatValN(N);
        }
        public int GetIntValN(int N)
        {
            return cell.GetIntValN(N);
        }
        public bool GetBoolValN(int N)
        {
            return cell.GetBoolValN(N);
        }
        public string ToStringN(int N)
        {
            return cell.ToStringN(N);
        }
        //
        public void SetVal(double val){ cell.SetVal(val); }
        public void SetVal(int val){ cell.SetVal(val); }
        public void SetVal(bool val) { cell.SetVal(val); }
        public void SetVal(string val) { cell.SetVal(val); }
        //
        public void SetValN(double val, int N) { cell.SetValN(val, N); }
        public void SetValN(float val, int N) { cell.SetValN(val, N); }
        public void SetValN(int val, int N) { cell.SetValN(val, N); }
        public void SetValN(bool val, int N) { cell.SetValN(val, N); }
        public void SetValN(string val, int N) { cell.SetValN(val, N); }
        //
        public int GetTypeN() { return cell.GetTypeN(); }
        public int GetLength() {
            int N = 0;
            if (cell != null) N = cell.GetLength();
            return N; 
        }
        public int GetActiveN() {
            int N = 0;
            if (cell != null) N = cell.GetActiveN();
            return N;
        }
        //
        public void SetActiveN(int N)
        {
            cell.SetActiveN(N);
        }
        public void SetLength(int Length){
            cell.SetLength(Length);
        }
        //
        public void DelValN(int N)
        {
            cell.DelValN(N);
        }
        //
        public void AddOrInsDoubleVal(double val, int N)
        {
            cell.AddOrInsDoubleVal(val, N);
        }
        public void AddOrInsFloatVal(float val, int N)
        {
            cell.AddOrInsFloatVal(val, N);
        }
        public void AddOrInsIntVal(int val, int N)
        {
            cell.AddOrInsIntVal(val, N);
        }
        public void AddOrInsBoolVal(bool val, int N)
        {
            cell.AddOrInsBoolVal(val, N);
        }
        public void AddOrInsStringVal(string val, int N)
        {
            cell.AddOrInsStringVal(val, N);
        }
        public void Assign(double val)
        {
            cell = new TCellDouble();
            cell.SetVal(val);
            //cell.SetValAndT
        }
        public void Assign(float val)
        {
            cell = new TCellFloat();
            cell.SetVal(val);
        }
        public void Assign(int val)
        {
            cell = new TCellInt();
            cell.SetVal(val);
        }
        public void Assign(bool val)
        {
            cell = new TCellBool();
            cell.SetVal(val);
        }
        public void Assign(string val)
        {
            cell = new TCellString();
            cell.SetVal(val);
        }
        public void Assign(double val, int N)
        {
            double[]arr=null;
            int ActualLength, PrevLength=cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell==null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell=cell;
                if(N<PrevLength) ActualLength=PrevLength; else ActualLength=N;
                if(ActualLength<=PrevLength) MinLength=ActualLength; else MinLength=PrevLength;
                arr=new double[ActualLength];
                for(int i=1; i<=ActualLength; i++) arr[i-1]=0;
                for(int i=1; i<=MinLength; i++) arr[i-1]=bufCell.GetDoubleValN(N);
                cell = new TCellDoubleMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(float val, int N)
        {
            float[] arr = null;
            int ActualLength, PrevLength = cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell==null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell = cell;
                if (N < PrevLength) ActualLength = PrevLength; else ActualLength = N;
                if (ActualLength <= PrevLength) MinLength = ActualLength; else MinLength = PrevLength;
                arr = new float[ActualLength];
                for (int i = 1; i <= ActualLength; i++) arr[i - 1] = 0;
                for (int i = 1; i <= MinLength; i++) arr[i - 1] = bufCell.GetFloatValN(N);
                cell = new TCellFloatMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(int val, int N)
        {
            int[] arr = null;
            int ActualLength, PrevLength = cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell==null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell = cell;
                if (N < PrevLength) ActualLength = PrevLength; else ActualLength = N;
                if (ActualLength <= PrevLength) MinLength = ActualLength; else MinLength = PrevLength;
                arr = new int[ActualLength];
                for (int i = 1; i <= ActualLength; i++) arr[i - 1] = 0;
                for (int i = 1; i <= MinLength; i++) arr[i - 1] = bufCell.GetIntValN(N);
                cell = new TCellIntMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(bool val, int N)
        {
            bool[] arr = null;
            int ActualLength, PrevLength = cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell==null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell = cell;
                if (N < PrevLength) ActualLength = PrevLength; else ActualLength = N;
                if (ActualLength <= PrevLength) MinLength = ActualLength; else MinLength = PrevLength;
                arr = new bool[ActualLength];
                for (int i = 1; i <= ActualLength; i++) arr[i - 1] = MyLib.BoolValByDefault;
                for (int i = 1; i <= MinLength; i++) arr[i - 1] = bufCell.GetBoolValN(N);
                cell = new TCellBoolMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(string val, int N)
        {
            string[] arr = null;
            int ActualLength, PrevLength = cell.GetLength(), MinLength;
            TDataCell bufCell;
            if (cell==null || (cell.GetTypeN() != TableConsts.DoubleTypeN && PrevLength < N))
            {
                bufCell = cell;
                if (N < PrevLength) ActualLength = PrevLength; else ActualLength = N;
                if (ActualLength <= PrevLength) MinLength = ActualLength; else MinLength = PrevLength;
                arr = new string[ActualLength];
                for (int i = 1; i <= ActualLength; i++) arr[i - 1] = "";
                for (int i = 1; i <= MinLength; i++) arr[i - 1] = bufCell.ToStringN(N);
                cell = new TCellBoolMemo(arr, ActualLength);
            }
            cell.SetValN(val, N);
        }
        public void Assign(double[] val, int count)
        {
            cell = new TCellDoubleMemo(val, count);
        }
        public void Assign(float[] val, int count)
        {
            cell = new TCellFloatMemo(val, count);
        }
        public void Assign(int[] val, int count)
        {
            cell = new TCellIntMemo(val, count);
        }
        public void Assign(bool[] val, int count)
        {
            cell = new TCellBoolMemo(val,  count);
        }
        public void Assign(string[] val, int count)
        {
            cell = new TCellStringMemo(val, count);
        }
        public void Assign(TDataCell obj)
        {
            cell = obj;
        }
        public void Assign(DataCell obj)
        {
            int TypeN, Length=0;
            double DoubleVal;
            float FloatVal;
            int IntVal;
            bool BoolVal;
            string StringVal;
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            if (obj == null) cell = null;
            else
            {
                TypeN = obj.GetTypeN();
                switch (TypeN)
                {
                    case TableConsts.DoubleTypeN:
                        DoubleVal = obj.GetDoubleVal();
                        cell = new TCellDouble(DoubleVal);
                        break;
                    case TableConsts.FloatTypeN:
                        FloatVal = obj.GetFloatVal();
                        cell = new TCellFloat(FloatVal);
                        break;
                    case TableConsts.IntTypeN:
                        IntVal = obj.GetIntVal();
                        cell = new TCellInt(IntVal);
                        break;
                    case TableConsts.BoolTypeN:
                        BoolVal = obj.GetBoolVal();
                        cell = new TCellBool(BoolVal);
                        break;
                    case TableConsts.StringTypeN:
                        StringVal = obj.ToString();
                        cell = new TCellString(StringVal);
                        break;
                    case TableConsts.DoubleArrayTypeN:
                        obj.GetDoubleArr(ref DoubleArr, ref Length);
                        cell = new TCellDoubleMemo(DoubleArr, Length);
                        break;
                    case TableConsts.FloatArrayTypeN:
                        obj.GetFloatArr(ref FloatArr, ref Length);
                        cell = new TCellFloatMemo(FloatArr, Length);
                        break;
                    case TableConsts.IntArrayTypeN:
                        obj.GetIntArr(ref IntArr, ref Length);
                        cell = new TCellIntMemo(IntArr, Length);
                        break;
                    case TableConsts.BoolArrayTypeN:
                        obj.GetBoolArr(ref BoolArr, ref Length);
                        cell = new TCellBoolMemo(BoolArr, Length);
                        break;
                    case TableConsts.StringArrayTypeN:
                        obj.ToStringArr(ref StringArr, ref Length);
                        cell = new TCellStringMemo(StringArr, Length);
                        break;
                }//swch
            }//if
        }//fn asgn
        //
        public void AssignBy(TDataCell CellFrom) 
        {
            TDataCell CellTo = this.cell;
            int TypeTo = CellTo.GetTypeN(), TypeFrom = CellFrom.GetTypeN(), LenFrom = CellFrom.GetLength(), LenTo = CellTo.GetLength(), LenMin;
            double DoubleVal;
            float FloatVal;
            int IntVal;
            bool BoolVal;
            string StringVal;
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            if (LenFrom >= LenTo) LenMin = LenFrom; else LenMin = LenTo;
            switch (TypeFrom)
            {
                case TableConsts.DoubleTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            //DoubleVal=CellFrom.GetDoubleVal();
                            //CellTo.SetByValDouble(DoubleVal);
                            break;
                        case TableConsts.FloatTypeN:
                            //CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            //CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            FloatVal = CellFrom.GetFloatVal();
                            CellTo.SetByValFloat(FloatVal);
                            DoubleVal = CellFrom.GetDoubleVal();
                            CellTo.SetByValDouble(DoubleVal);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.FloatTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            DoubleVal = CellFrom.GetDoubleVal();
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            FloatVal = CellFrom.GetFloatVal();
                            CellTo.SetByValFloat(FloatVal);
                            break;
                        case TableConsts.FloatTypeN:
                            FloatVal = CellFrom.GetFloatVal();
                            CellTo.SetByValFloat(FloatVal);
                            //IntVal=CellFrom.GetIntVal();
                            //CellTo.SetByValInt(IntVal);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            FloatVal = CellFrom.GetFloatVal();
                            CellTo.SetByValFloat(FloatVal);
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            //CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.IntTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntTypeN:
                            //CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellTo.SetByValString(CellFrom.ToString());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            //CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.BoolTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            //CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellTo.SetByValString(CellFrom.ToString());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            //CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.StringTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            //CellTo.SetByValBool(CellFrom.GetBoolVal());
                            CellTo.SetByValString(CellFrom.ToString());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            //CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.DoubleArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            //CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            //CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            //CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.FloatArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            //CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            //CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.IntArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            //CellTo.SetByArrFloat(FloatArr, LenFrom);
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.BoolArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            //CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            //CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                            break;
                    }//switch
                    break;
                case TableConsts.StringArrayTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValDouble(CellFrom.GetDoubleVal());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValFloat(CellFrom.GetFloatVal());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            break;
                        case TableConsts.BoolTypeN:
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            CellTo.SetByValBool(CellFrom.GetBoolVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValString(CellFrom.ToString());
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellFrom.GetDoubleArr(ref DoubleArr, ref LenFrom);
                            CellTo.SetByArrDouble(DoubleArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                            CellTo.SetByArrFloat(FloatArr, LenFrom);
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellFrom.GetIntArr(ref IntArr, ref LenFrom);
                            CellTo.SetByArrInt(IntArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            CellFrom.GetBoolArr(ref BoolArr, ref LenFrom);
                            CellTo.SetByArrBool(BoolArr, LenFrom);
                            break;
                        case TableConsts.StringArrayTypeN:
                            //CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            //CellTo.SetByArrString(StringArr, LenFrom);
                            CellFrom.ToStringArr(ref StringArr, ref LenFrom);
                            CellTo.SetByArrString(StringArr, LenFrom);
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            //NOp;
                        break;
                    }//switch
                    break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    switch (TypeTo)
                    {
                        case TableConsts.DoubleTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.StringTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.FloatArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.IntArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.BoolArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.StringArrayTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            CellTo.SetByValInt(CellFrom.GetIntVal());
                            break;
                    }//switch
                    break;
            }//switch 
            this.cell=CellTo;
        }
        public void AssignBy(DataCell obj)
        {
            TDataCell ObjCell = obj.GetCell();
            AssignBy(ObjCell);
        }
        //
        public void SetTypeN(int TypeN, TableCellAccessConfiguration cfgExt)
        {
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            TDataCell BufCell = null;
            TableCellAccessConfiguration cfg=null;
            if (cfgExt != null) cfg = cfgExt; //qu s'abl?
            else cfg = new TableCellAccessConfiguration();
            if (cfg.PreserveVal)
            {
                BufCell = cell;
            }
            switch (TypeN)
            {
                case TableConsts.DoubleTypeN:
                    if(!cfg.PreserveVal) cell = new TCellDouble();
                    else cell = new TCellDouble(BufCell.GetDoubleVal());
                break;
                case TableConsts.FloatTypeN:
                    cell = new TCellFloat();
                    if (cfg.PreserveVal) cell.SetByValFloat(BufCell.GetFloatVal()); 
                break;
                case TableConsts.IntTypeN:
                    cell = new TCellInt();
                    if (cfg.PreserveVal) cell.SetByValInt(BufCell.GetIntVal());
                break;
                case TableConsts.BoolTypeN:
                    cell = new TCellBool();
                    if (cfg.PreserveVal) cell.SetByValBool(BufCell.GetBoolVal());
                break;
                case TableConsts.StringTypeN:
                    cell = new TCellString();
                    if (cfg.PreserveVal) cell.SetByValString(BufCell.ToString());
                break;
                case TableConsts.UniqueIntValKeeperTypeN:
                    cell = new TCellUniqueNumKeeper(cfg.UniqueIntVal);
                    if (cfg.PreserveVal) cell.SetByValInt(BufCell.GetIntVal());
                break;
                case TableConsts.DoubleArrayTypeN:
                    if (cfg.PreserveVal) BufCell.GetDoubleArr(ref DoubleArr, ref cfg.LengthOfArrCellTypes);
                    cell = new TCellDoubleMemo(DoubleArr, cfg.LengthOfArrCellTypes);
                break;
                case TableConsts.FloatArrayTypeN:
                    if (cfg.PreserveVal) BufCell.GetFloatArr(ref FloatArr, ref cfg.LengthOfArrCellTypes);
                    cell = new TCellFloatMemo(FloatArr, cfg.LengthOfArrCellTypes);
                break;
                case TableConsts.IntArrayTypeN:
                    if (cfg.PreserveVal) BufCell.GetIntArr(ref IntArr, ref cfg.LengthOfArrCellTypes);
                    cell = new TCellIntMemo(IntArr, cfg.LengthOfArrCellTypes);
                break;
                case TableConsts.BoolArrayTypeN:
                    if (cfg.PreserveVal) BufCell.GetBoolArr(ref BoolArr, ref cfg.LengthOfArrCellTypes);
                    cell = new TCellBoolMemo(BoolArr, cfg.LengthOfArrCellTypes);
                break;
                case TableConsts.StringArrayTypeN:
                    if (cfg.PreserveVal) BufCell.ToStringArr(ref StringArr, ref cfg.LengthOfArrCellTypes);
                    cell = new TCellStringMemo(BoolArr, cfg.LengthOfArrCellTypes);
                break;
            }
        }
        //
        public void SetValAndTypeDouble(double val)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.DoubleTypeN)
            {
                cell = new TCellDouble(val);
            }
            else
            {
                cell.SetByValDouble(val);
            }
        }
        public void SetValAndTypeFloat(float val)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.FloatTypeN)
            {
                cell = new TCellFloat(val);
            }
            else
            {
                cell.SetByValFloat(val);
            }
        }
        public void SetValAndTypeInt(int val)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.IntTypeN)
            {
                cell = new TCellInt(val);
            }
            else
            {
                cell.SetByValInt(val);
            }
        }
        public void SetValAndTypeBool(bool val)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.BoolTypeN)
            {
                cell = new TCellBool(val);
            }
            else
            {
                cell.SetByValBool(val);
            }
        }
        public void SetValAndTypeString(string val)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.StringTypeN)
            {
                cell = new TCellString(val);
            }
            else
            {
                cell.SetByValString(val);
            }
        }
        public void SetArrAndTypeDouble(double[] arr, int Length)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.DoubleArrayTypeN)
            {
                cell = new TCellDoubleMemo(arr, Length);
            }
            else
            {
                cell.SetByArrDouble(arr, Length);
            }
        }
        public void SetArrAndTypeFloat(float[] arr, int Length)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.FloatArrayTypeN)
            {
                cell = new TCellFloatMemo(arr, Length);
            }
            else
            {
                cell.SetByArrFloat(arr, Length);
            }
        }
        public void SetArrAndTypeInt(int[] arr, int Length)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.IntArrayTypeN)
            {
                cell = new TCellIntMemo(arr, Length);
            }
            else
            {
                cell.SetByArrInt(arr, Length);
            }
        }
        public void SetArrAndTypeBool(bool[] arr, int Length)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.BoolArrayTypeN)
            {
                cell = new TCellBoolMemo(arr, Length);
            }
            else
            {
                cell.SetByArrBool(arr, Length);
            }
        }
        public void SetArrAndTypeString(string[] arr, int Length)
        {
            if (cell != null && cell.GetTypeN() != TableConsts.StringArrayTypeN)
            {
                cell = new TCellStringMemo(arr, Length);
            }
            else
            {
                cell.SetByArrString(arr, Length);
            }
        }
        public void SetValAndTypeUniqueIntNumKeeper(int val)
        {
            cell = new TCellUniqueNumKeeper(val);
        }
        //
        public void SetByValDouble(double val)
        {
            cell.SetByValDouble(val);
        }
        public void SetByValFloat(float val)
        {
            cell.SetByValFloat(val);
        }
        public void SetByValInt(int val)
        {
            cell.SetByValInt(val);
        }
        public void SetByValBool(bool val)
        {
            cell.SetByValBool(val);
        }
        public void SetByValString(string val)
        {
            cell.SetByValString(val);
        }
        //
        public void SetByValDoubleN(double val, int N)
        {
            cell.SetByValDoubleN(val, N);
        }
        public void SetByValFloatN(float val, int N)
        {
            cell.SetByValFloatN(val, N);
        }
        public void SetByValIntN(int val, int N)
        {
            cell.SetByValIntN(val, N);
        }
        public void SetByValBoolN(bool val, int N)
        {
            cell.SetByValBoolN(val, N);
        }
        public void SetByValStringN(string val, int N)
        {
            cell.SetByValStringN(val, N);
        }
        //
        public void SetByArrDouble(double[] val, int Length)
        {
            cell.SetByArrDouble(val, Length);
        }
        public void SetByArrFloat(float[] val, int Length)
        {
            cell.SetByArrFloat(val, Length);
        }
        public void SetByArrInt(int[] val, int Length)
        {
            cell.SetByArrInt(val, Length);
        }
        public void SetByArrBool(bool[] val, int Length)
        {
            cell.SetByArrBool(val, Length);
        }
        public void SetByArrString(string[] val, int Length)
        {
            cell.SetByArrString(val, Length);
        }
        //
        //public static DataCell operator +(DataCell obj1, DataCell obj2){
        public static DataCell operator +(DataCell obj1, DataCell obj2){
            DataCell sum = new DataCell();
            double[] DoubleArr = null;
            float[] FloatArr = null;
            int[] IntArr = null;
            bool[] BoolArr = null;
            string[] StringArr = null;
            int Type1N, Type2N, Length1, Length2;
            if (obj1 != null)
            {
                if (obj2 != null) //else NOp;
                {
                    Type1N = obj1.GetTypeN();
                    Type2N = obj2.GetTypeN();
                    switch (Type1N)
                    {
                        case TableConsts.DoubleTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.FloatTypeN:
                                    //sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.IntTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.BoolTypeN:
                                    //sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.StringTypeN:
                                    //sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength(); //1
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i +Length1- 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN: //ob double longer r' float: s'nee'd array of > long vars
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i +Length1- 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN://ob double longer r' float: s'nee'd array of > long vars
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i +Length1- 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN: //ob double longer r' float: s'nee'd array of > long vars
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i +Length1- 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i +Length1- 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    //
                                    //Length1 = obj1.GetLength();
                                    //Length2 = obj2.GetLength();
                                    //StringArr = new string[Length1 + Length2];
                                    //for (int i = 1; i <= Length1; i++){
                                    //    StringArr[i - 1] = obj1.ToStringN(i);
                                    //}
                                    //for (int i = 1; i <= Length2; i++)
                                    //{
                                    //    StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    //}
                                    //sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.FloatTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.FloatTypeN:
                                    //sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    break;
                                case TableConsts.IntTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    break;
                                case TableConsts.BoolTypeN:
                                    //sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    break;
                                case TableConsts.StringTypeN:
                                    //sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    //Length1 = obj1.GetLength();
                                    //Length2 = obj2.GetLength();
                                    //DoubleArr = new double[Length1 + Length2];
                                    //for (int i = 1; i <= Length1; i++){
                                    //    DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    //}
                                    //for (int i = 1; i <= Length2; i++)
                                    //{
                                    //    DoubleArr[i +Length1- 1] = obj2.GetDoubleValN(i);
                                    //}
                                    //sum = new DataCell(DoubleArr, Length1 + Length2);
                                    //
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                                    //CellTo.SetByArrFloat(FloatArr, LenFrom);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    //
                                    //Length1 = obj1.GetLength();
                                    //Length2 = obj2.GetLength();
                                    //StringArr = new string[Length1 + Length2];
                                    //for (int i = 1; i <= Length1; i++){
                                    //    StringArr[i - 1] = obj1.ToStringN(i);
                                    //}
                                    //for (int i = 1; i <= Length2; i++)
                                    //{
                                    //    StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    //}
                                    //sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.IntTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    sum = new DataCell(obj1.GetDoubleVal() + obj2.GetDoubleVal());
                                    break;
                                case TableConsts.FloatTypeN:
                                    //sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    break;
                                case TableConsts.IntTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    break;
                                case TableConsts.BoolTypeN:
                                    //sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    break;
                                case TableConsts.StringTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i +Length1- 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                                    //CellTo.SetByArrFloat(FloatArr, LenFrom);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    //
                                    //Length1 = obj1.GetLength();
                                    //Length2 = obj2.GetLength();
                                    //StringArr = new string[Length1 + Length2];
                                    //for (int i = 1; i <= Length1; i++){
                                    //    StringArr[i - 1] = obj1.ToStringN(i);
                                    //}
                                    //for (int i = 1; i <= Length2; i++)
                                    //{
                                    //    StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    //}
                                    //sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.BoolTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.FloatTypeN:
                                    //sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.IntTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.BoolTypeN:
                                    //sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.StringTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                                    //CellTo.SetByArrFloat(FloatArr, LenFrom);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    //
                                    //Length1 = obj1.GetLength();
                                    //Length2 = obj2.GetLength();
                                    //StringArr = new string[Length1 + Length2];
                                    //for (int i = 1; i <= Length1; i++){
                                    //    StringArr[i - 1] = obj1.ToStringN(i);
                                    //}
                                    //for (int i = 1; i <= Length2; i++)
                                    //{
                                    //    StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    //}
                                    //sum = new DataCell(StringArr, Length1 + Length2);
                                break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                break;
                            }//switch
                            break;
                        case TableConsts.StringTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    break;
                                case TableConsts.FloatTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    break;
                                case TableConsts.IntTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    break;
                                case TableConsts.BoolTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    break;
                                case TableConsts.StringTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    //CellTo.SetByValBool(CellFrom.GetBoolVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.FloatArrayTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.IntArrayTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.BoolTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.FloatTypeN:
                                    //sum = new DataCell(obj1.GetFloatVal() + obj2.GetFloatVal());
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.IntTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.BoolTypeN:
                                    //sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.StringTypeN:
                                    //sum = new DataCell(obj1.GetIntVal() + obj2.GetIntVal());
                                    sum = new DataCell(obj1.GetBoolVal() && obj2.GetBoolVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    //CellFrom.GetFloatArr(ref FloatArr, ref LenFrom);
                                    //CellTo.SetByArrFloat(FloatArr, LenFrom);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    //
                                    //Length1 = obj1.GetLength();
                                    //Length2 = obj2.GetLength();
                                    //StringArr = new string[Length1 + Length2];
                                    //for (int i = 1; i <= Length1; i++){
                                    //    StringArr[i - 1] = obj1.ToStringN(i);
                                    //}
                                    //for (int i = 1; i <= Length2; i++)
                                    //{
                                    //    StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    //}
                                    //sum = new DataCell(StringArr, Length1 + Length2);
                                break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                break;
                            }//switch
                            break;
                        case TableConsts.StringTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    break;
                                case TableConsts.FloatTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    break;
                                case TableConsts.IntTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    break;
                                case TableConsts.BoolTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    break;
                                case TableConsts.StringTypeN:
                                    sum = new DataCell(obj1.ToString() + obj2.ToString());
                                    //CellTo.SetByValBool(CellFrom.GetBoolVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.DoubleArrayTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.FloatArrayTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.IntArrayTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.BoolArrayTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    DoubleArr = new double[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        DoubleArr[i - 1] = obj1.GetDoubleValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        DoubleArr[i + Length1 - 1] = obj2.GetDoubleValN(i);
                                    }
                                    sum = new DataCell(DoubleArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    FloatArr = new float[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        FloatArr[i - 1] = obj1.GetFloatValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        FloatArr[i + Length1 - 1] = obj2.GetFloatValN(i);
                                    }
                                    sum = new DataCell(FloatArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    IntArr = new int[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        IntArr[i - 1] = obj1.GetIntValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        IntArr[i + Length1 - 1] = obj2.GetIntValN(i);
                                    }
                                    sum = new DataCell(IntArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    BoolArr = new bool[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        BoolArr[i - 1] = obj1.GetBoolValN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        BoolArr[i + Length1 - 1] = obj2.GetBoolValN(i);
                                    }
                                    sum = new DataCell(BoolArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.StringArrayTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    Length1 = obj1.GetLength();
                                    Length2 = obj2.GetLength();
                                    StringArr = new string[Length1 + Length2];
                                    for (int i = 1; i <= Length1; i++){
                                        StringArr[i - 1] = obj1.ToStringN(i);
                                    }
                                    for (int i = 1; i <= Length2; i++)
                                    {
                                        StringArr[i + Length1 - 1] = obj2.ToStringN(i);
                                    }
                                    sum = new DataCell(StringArr, Length1 + Length2);
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //NOp;
                                    break;
                            }//switch
                            break;
                        case TableConsts.UniqueIntValKeeperTypeN:
                            switch (Type2N)
                            {
                                case TableConsts.DoubleTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.FloatTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.IntTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.BoolTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.StringTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.DoubleArrayTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.FloatArrayTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.IntArrayTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.BoolArrayTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.StringArrayTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                                case TableConsts.UniqueIntValKeeperTypeN:
                                    //CellTo.SetByValInt(CellFrom.GetIntVal());
                                    break;
                            }//switch
                            break;
                    }//switch 
                }
                else sum.Assign(obj1);
            }
            else sum.Assign(obj2);
            return sum;
        }//+
        
    }//cl DataCell
    //
    //
    public class DataCellRow{
        DataCell[] cell;
        int Q;
        //
        public DataCellRow(){
            Q=1;
            cell=new DataCell[Q];
            for(int i=1; i<=Q; i++) cell[i-1]=new DataCell();
        }
        public DataCellRow(DataCellTypeInfo[] cfg, int Q){
            this.Q=Q;
            this.cell=new DataCell[Q];
            if(cfg!=null){
                for(int i=1; i<=Q; i++){
                    this.cell[i-1]=new DataCell(cfg[i-1].GetTypeN(), cfg[i-1].GetLength());
                }
            }else{
                for(int i=1; i<=Q; i++){
                    this.cell[i-1]=new DataCell();
                }
            }
        }
        public DataCellRow(DataCellTypeInfo cfg, int Q){
            if(cfg!=null){
                for(int i=1; i<=Q; i++){
                    this.cell[i-1]=new DataCell(cfg.GetTypeN(), cfg.GetLength());
                }
            }else{
                for(int i=1; i<=Q; i++){
                    this.cell[i-1]=new DataCell();
                }
            }
        }
        public DataCellRow(DataCell[] row, int Q){
            this.Q=Q;
            for(int i=1; i<=Q; i++){cell[i-1]=new DataCell(); this.cell[i-1]=row[i-1];}
        }
        public DataCellRow(int[] types, int[] lengths, int Quantity, TableCellAccessConfiguration cfgExt){
            //in C++ cell=null; Q=0;
            this.Q=Quantity;
            cell=new  DataCell[Q];
            SetTypes(types, lengths, cfgExt);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(int type, int length, int Quantity, TableCellAccessConfiguration cfgExt){
            //in C++ cell=null; Q=0;
            this.Q=Quantity;
            cell=new  DataCell[Q];
            SetSingleType(type, length, Quantity, cfgExt);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(double[] row, int Q){
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell=new DataCell[Q];
            SetSingleType(row, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(float[] row, int Q){
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell=new DataCell[Q];
            SetSingleType(row, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(int[] row, int Q){
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell=new DataCell[Q];
            SetSingleType(row, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(bool[] row, int Q){
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell=new DataCell[Q];
            SetSingleType(row, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(string[] row, int Q){
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell=new DataCell[Q];
            SetSingleType(row, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(string[] row1, string[] row2, int Q){
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell=new DataCell[Q];
            SetSingleType(row1, row2, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(int[] row1, int[] row2, int Q){
            //in C++ cell=null; Q=0;
            //this.Q=Q; // in SetSingleType
            cell=new DataCell[Q];
            SetSingleType(row1, row2, Q);
            //hope, so it abl work in C#, in C++ of cource not
        }
        public DataCellRow(double val){
            Q=1;
            cell=new DataCell[1];
            cell[1-1]=new DataCell(val);
        }
        public DataCellRow(float val){
            Q=1;
            cell=new DataCell[1];
            cell[1-1]=new DataCell(val);
        }
        /* 
        public DataCellRow(int val){
            Q=1;
            cell=new DataCell[1];
            cell[1-1]=new DataCell(val);
        }*/
        public DataCellRow(bool val){
            Q=1;
            cell=new DataCell[1];
            cell[1-1]=new DataCell(val);
        }
        public DataCellRow(string val){
            Q=1;
            cell=new DataCell[1];
            cell[1-1]=new DataCell(val);
        }
        public DataCellRow(string val1, string val2){
            string[] vals=new string[2];
            vals[1-1]=val1;
            vals[2-1]=val2;
            Q=1;
            cell=new DataCell[1];
            cell[1-1]=new DataCell(vals,2);
        }
        public DataCellRow(int val1, int val2){
            int[] vals=new int[2];
            vals[1-1]=val1;
            vals[2-1]=val2;
            Q=1;
            cell=new DataCell[1];
            cell[1-1]=new DataCell(vals,2);
        }
        public DataCellRow(int val){
            Q=1;
            cell=new DataCell[1];
            cell[1-1]=new DataCell(val);
        }
        //
        public void Add(DataCell cell){
            MyLib.AddToVector(ref this.cell, ref this.Q, cell);
        }
        public void InsertToN(DataCell cell, int N){
            if(N>=1 && N<MyLib.MaxInt)MyLib.InsToVector(ref this.cell, ref this.Q, cell, N);
        }
        public void DeleteN(int N){
            if(N>=1 && N<MyLib.MaxInt) MyLib.DelInVector(ref cell, ref this.Q, N);
        }
        public void Add(double val){
            DataCell cell=new DataCell(val);
            Add(cell);
        }
        public void Add(float val){
            DataCell cell=new DataCell(val);
            Add(cell);
        }
        public void Add(int val){
            DataCell cell=new DataCell(val);
            Add(cell);
        }
        public void Add(bool val){
            DataCell cell=new DataCell(val);
            Add(cell);
        }
        public void Add(string val){
            DataCell cell=new DataCell(val);
            Add(cell);
        }
        public void InsertToN(double val, int N){
            DataCell cell=null;
            if(N>=1 && N<MyLib.MaxInt){
                cell=new DataCell(val);
                InsertToN(cell, N);
            }
        }
        public void InsertToN(float val, int N){
            DataCell cell=null;
            if(N>=1 && N<MyLib.MaxInt){
                cell=new DataCell(val);
                InsertToN(cell, N);
            }
        }
        public void InsertToN(int val, int N){
            DataCell cell=null;
            if(N>=1 && N<MyLib.MaxInt){
                cell=new DataCell(val);
                InsertToN(cell, N);
            }
        }
        public void InsertToN(bool val, int N){
            DataCell cell=null;
            if(N>=1 && N<MyLib.MaxInt){
                cell=new DataCell(val);
                InsertToN(cell, N);
            }
        }
        public void InsertToN(string val, int N){
            DataCell cell=null;
            if(N>=1 && N<MyLib.MaxInt){
                cell=new DataCell(val);
                InsertToN(cell, N);
            }
        }
        //
        public int GetSize(){ return Q;}
        public void SetSize(int Q, bool PreserveVals){
            int MinQ=0;
            DataCell[] newRow=null;
            if(Q>1 && Q<MyLib.MaxInt && Q!=this.Q){
                if(Q<=this.Q) MinQ=Q; else MinQ=this.Q;
                if(PreserveVals){
                    newRow=new DataCell[Q];
                    for(int i=1; i<=MinQ; i++) newRow[i-1]=cell[i-1];
                }
                //in C++ amda mus be del[]cell
                cell=new DataCell[Q];
                if(PreserveVals){
                    for(int i=1; i<=MinQ; i++) cell[i-1]=newRow[i-1];
                    //in C++ amda mus be del[]newRow or better cell=newRow 
                }
            }
        }
        //
        public DataCell GetCellN(int N){ 
            DataCell acell=null;
            if(N>1 && N<Q) acell=cell[N-1];
            return acell;
        }
        public double GetDoubleValOfCellN(int N){
            double y=0;
            if(N>1 && N<Q){
                y=cell[N-1].GetDoubleVal();
            }
            return y;
        }
        public float GetFloatValOfCellN(int N){
            float y=0;
            if(N>1 && N<Q){
                y=cell[N-1].GetFloatVal();
            }
            return y;
        }
        public int GetIntValOfCellN(int N){
            int y=0;
            if(N>1 && N<Q){
                y=cell[N-1].GetIntVal();
            }
            return y;
        }
        public bool GetBoolValOfCellN(int N){
            bool y=MyLib.BoolValByDefault;
            if(N>1 && N<Q){
                y=cell[N-1].GetBoolVal();
            }
            return y;
        }
        public string CellNToString(int N){
            string y="";
            if(N>1 && N<Q){
                y=cell[N-1].ToString();
            }
            return y;
        }
        //
        public void GetDoubleArrOfCellN(int N, ref double [] arr, ref int Length){
            if(N>1 && N<Q){
                cell[N-1].GetDoubleArr(ref arr, ref Length);
            }
        }
        public void GetFloatArrOfCellN(int N, ref float [] arr, ref int Length){
            if(N>1 && N<Q){
                cell[N-1].GetFloatArr(ref arr, ref Length);
            }
        }
        public void GetIntArrOfCellN(int N, ref int [] arr, ref int Length){
            if(N>1 && N<Q){
                cell[N-1].GetIntArr(ref arr, ref Length);
            }
        }
        public void GetBoolArrOfCellN(int N, ref bool [] arr, ref int Length){
            if(N>1 && N<Q){
                cell[N-1].GetBoolArr(ref arr, ref Length);
            }
        }
        public void GetCellNToStringArr(int N, ref string [] arr, ref int Length){
            if(N>1 && N<Q){
                cell[N-1].ToStringArr(ref arr, ref Length);
            }
        }
        //
        public void SetTypes(DataCellTypeInfo[] typesInfExt, TableCellAccessConfiguration cfgExt){
            TableCellAccessConfiguration cfg;
            if(cfgExt!=null) cfg=cfgExt; else cfg=new TableCellAccessConfiguration();
            DataCellTypeInfo[] typesInf=new DataCellTypeInfo[this.Q];
            if(typesInfExt!=null) {for(int i=1; i<=this.Q; i++) typesInf[i-1]=typesInfExt[1-1];}
            else {for(int i=1; i<=this.Q; i++) typesInf[i-1]=new DataCellTypeInfo();}
            for(int i=1; i<=this.Q; i++){
                cfgExt.LengthOfArrCellTypes=typesInf[i-1].GetLength();
                cell[i-1].SetTypeN(typesInf[i-1].GetTypeN(),cfgExt);
            }
        }
        public void SetTypes(int[] types, int[] Lengths, TableCellAccessConfiguration cfgExt){
            TableCellAccessConfiguration cfg;
            int TypeN=0, length=2;
            if(cfgExt!=null) cfg=cfgExt; else cfg=new TableCellAccessConfiguration();
            for(int i=1; i<=Q; i++){
                //public void SetTypeN(int TypeN, TableCellAccessConfiguration cfgExt)
                if(types!=null && TableConsts.TypeNIsCorrect(types[i-1])) TypeN=types[i-1];
                else{
                    TypeN=TableConsts.DefaultAnyCellTypeN;
                }
                if(Lengths!=null && Lengths[i-1]>0 && Lengths[i-1]<MyLib.MaxInt) length=Lengths[i-1];
                else{
                    length=2;
                }
                cfg.LengthOfArrCellTypes=length;
                cell[i-1].SetTypeN(types[i-1], cfg);
            }
        }
        public void SetSingleType(double[] row, int Q){
            double val=0;
            //in C++ amda sol be if(!NULL)delete[]
            cell=new DataCell[Q];
            if(row!=null) for(int i=1; i<=Q; i++) cell[i-1]=new DataCell(row[i-1]);
            else for(int i=1; i<=Q; i++) cell[i-1]=new DataCell(val);
            this.Q=Q;
        }
        public void SetSingleType(float[] row, int Q){
            double val=0;
            //in C++ amda sol be if(!NULL)delete[]
            cell=new DataCell[Q];
            if(row!=null) for(int i=1; i<=Q; i++) cell[i-1]=new DataCell(row[i-1]);
            else for(int i=1; i<=Q; i++) cell[i-1]=new DataCell(val);
            this.Q=Q;
        }
        public void SetSingleType(int[] row, int Q){
            double val=0;
            //in C++ amda sol be if(!NULL)delete[]
            cell=new DataCell[Q];
            if(row!=null) for(int i=1; i<=Q; i++) cell[i-1]=new DataCell(row[i-1]);
            else for(int i=1; i<=Q; i++) cell[i-1]=new DataCell(val);
            this.Q=Q;
        }
        public void SetSingleType(bool[] row, int Q){
            double val=0;
            //in C++ amda sol be if(!NULL)delete[]
            cell=new DataCell[Q];
            if(row!=null) for(int i=1; i<=Q; i++) cell[i-1]=new DataCell(row[i-1]);
            else for(int i=1; i<=Q; i++) cell[i-1]=new DataCell(val);
            this.Q=Q;
        }
        public void SetSingleType(string[] row, int Q){
            double val=0;
            //in C++ amda sol be if(!NULL)delete[]
            cell=new DataCell[Q];
            if(row!=null) for(int i=1; i<=Q; i++) cell[i-1]=new DataCell(row[i-1]);
            else for(int i=1; i<=Q; i++) cell[i-1]=new DataCell(val);
            this.Q=Q;
        }
        public void SetSingleType(string[] row1, string[]row2, int Q){
            double val=0;
            string[] row=new string[2];
            for(int i=1; i<=2; i++) row[i-1]="";
            //in C++ amda sol be if(!NULL)delete[]
            cell=new DataCell[Q];
            for(int i=1; i<=Q; i++){
                if(row1!=null) row[1-1]=row1[i-1]; 
                if(row2!=null) row[2-1]=row2[i-1]; 
                cell[i-1]=new DataCell(row, 2);
            }
            this.Q=Q;
        }
        public void SetSingleType(int[] row1, int[]row2, int Q){
            double val=0;
            int[] row=new int[2];
            for(int i=1; i<=2; i++) row[i-1]=0;
            //in C++ amda sol be if(!NULL)delete[]
            cell=new DataCell[Q];
            for(int i=1; i<=Q; i++){
                if(row1!=null) row[1-1]=row1[i-1]; 
                if(row2!=null) row[2-1]=row2[i-1]; 
                cell[i-1]=new DataCell(row, 2);
            }
            this.Q=Q;
        }
        public void SetSingleType(int type, int length, int Q, TableCellAccessConfiguration cfgExt){
            int[] types=new int[Q];
            int[] Lengths=new int[Q];
            if(TableConsts.TypeNIsCorrect(type)){
                for(int i=1; i<=Q; i++){
                    types[i-1]=type;
                }
            }else{
                for(int i=1; i<=Q; i++){
                    types[i-1]=TableConsts.DefaultAnyCellTypeN;
                }
            }
            if(length>0 && length<MyLib.MaxInt){
                for(int i=1; i<=Q; i++){
                    Lengths[i-1]=length;
                }
            }else{
                for(int i=1; i<=Q; i++){
                    Lengths[i-1]=2;
                }
            }
            this.Q=Q;
            SetTypes(types, Lengths, cfgExt);
        }
        public void SetSingleType(DataCellTypeInfo typesInfExt, TableCellAccessConfiguration cfgExt){
            TableCellAccessConfiguration cfg;
            if(cfgExt!=null) cfg=cfgExt; else cfg=new TableCellAccessConfiguration();
            DataCellTypeInfo[] typesInf=new DataCellTypeInfo[this.Q];
            if(typesInfExt!=null) {for(int i=1; i<=this.Q; i++) typesInf[i-1]=typesInfExt;}
            else {for(int i=1; i<=this.Q; i++) typesInf[i-1]=new DataCellTypeInfo();}
            SetTypes(typesInf, cfgExt);
        }
    }//cl
    
}//ns
